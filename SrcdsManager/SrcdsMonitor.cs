﻿using System;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace SrcdsManager
{
    class SrcdsMonitor : IDisposable
    {
        public SrcdsStatus Status = SrcdsStatus.Offline;
        public bool isAutoStart = false;
        public String Log = "";
        public String AffinityMask = new String('1', Environment.ProcessorCount);

        private String exePath;
        private String commandLine;
        private String Name;
        private String sID;
        private String game;
        private IPAddress ipAddr;
        private int port;
        private Manager caller;
        private bool running = false;
        private bool cleanExit = true;
        private Process proc = new Process();
        private ProcessStartInfo startInfo;
        private int crashes = 0;
        private DateTime startTime;
        private SrcdsPinger pinger;
        private Thread oThread;

        public SrcdsMonitor(String exePath, String game, String commandLine, String Name, String sID, String ipAddr, String port, String AffinityMask, object caller)
        {
            this.exePath = exePath;
            this.commandLine = commandLine;
            this.Name = Name;
            this.sID = sID;
            this.game = game;
            this.AffinityMask = AffinityMask;

            startInfo = new ProcessStartInfo();
            startInfo.FileName = exePath;


            if (ipAddr == "0.0.0.0")
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress addr in host.AddressList)
                {
                    if (addr.AddressFamily == AddressFamily.InterNetwork)
                    {
                        this.ipAddr = addr;
                        break;
                    }
                }
            }
            else
            {
                this.ipAddr = IPAddress.Parse(ipAddr);
            }
            this.port = int.Parse(port);

            proc.StartInfo = startInfo;

            this.caller = (Manager)caller;

            pinger = new SrcdsPinger(this, this.ipAddr, this.port, proc);
        }

        public void Start()
        {
            startInfo.Arguments = String.Format("-game {0} -console -ip {1} -port {2}", game, ipAddr, port) + " " + commandLine;

            //Change endian because our string is built left to right
            char[] temp = AffinityMask.ToCharArray();
            Array.Reverse(temp);
            
            try
            {
                proc.Start();
                proc.ProcessorAffinity = new IntPtr(Convert.ToInt32(new String(temp), 2));
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(System.ComponentModel.Win32Exception))
                {
                    caller.ErrorBox(1);
                    return;
                }
                else
                {
                    throw ex;
                }
            }
            pinger.StartPinging();

            WaitForExit oWait = new WaitForExit(proc, this, 0);
            oThread = new Thread(new ThreadStart(oWait.Waiting));
            oThread.Start();

            running = true;
            this.Status = SrcdsStatus.Online;
            cleanExit = false;

            startTime = DateTime.Now;
        }
        public void Crashed()
        {
            this.crashes++;

            this.LogMessage("Server crashed, attempting to restart");

            proc.Dispose();
            proc = new Process();
            proc.StartInfo = startInfo;


            try
            {
                this.Start();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(System.InvalidOperationException))
                {
                    caller.ErrorBox(1);
                    return;
                }
                else
                {
                    throw ex;
                }
            }

            startTime = DateTime.Now;
            this.Status = SrcdsStatus.Online;
        }
        public void Stop()
        {
            cleanExit = true;
            pinger.Dispose();
            proc.Kill();

            running = false;
            this.Status = SrcdsStatus.Offline;
        }
        public void Exited(object caller)
        {
            caller = null;
            if (cleanExit != true)
            {
                pinger.Dispose();
                Crashed();
            }
        }
        public void WaitForUpdate(Process proc)
        {
            this.Status = SrcdsStatus.Updating;
            WaitForExit oWait = new WaitForExit(proc, this, 1);
            Thread wThread = new Thread(new ThreadStart(oWait.Waiting));
            wThread.Start();
        }
        public void DoneUpdating()
        {
            this.Status = SrcdsStatus.Offline;
        }
        public void WaitForInstall(Process proc)
        {
            this.Status = SrcdsStatus.Installing;
            WaitForExit oWait = new WaitForExit(proc, this, 2);
            Thread wThread = new Thread(new ThreadStart(oWait.Waiting));
            wThread.Start();
        }
        public void DoneInstalling()
        {
            this.Status = SrcdsStatus.Offline;
        }

        public String getCmd()
        {
            return commandLine;
        }
        public void setCmd(String commandLine)
        {
            this.commandLine = commandLine;

            startInfo.Arguments = commandLine;
        }

        public String getExe()
        {
            return exePath;
        }
        public void setExe(String exePath)
        {
            this.exePath = exePath;

            startInfo.FileName = exePath;
        }

        public String getAddr()
        {
            return ipAddr.ToString();
        }
        public void setIPAddr(String ipAddr)
        {
            this.ipAddr = IPAddress.Parse(ipAddr);
        }

        public String getPort()
        {
            return port.ToString();
        }
        public void setPort(String port)
        {
            this.port = int.Parse(port);
        }

        public String getName()
        {
            return Name;
        }
        public void setName(String Name)
        {
            this.Name = Name;
        }

        public String getId()
        {
            return sID;
        }
        public bool isRunning()
        {
            return running;
        }
        public String getUptime()
        {
            if (this.isRunning())
            {
                TimeSpan time = DateTime.Now - startTime;
                return String.Format("{0}:{1}:{2}", Math.Floor(time.TotalHours), time.Minutes, time.Seconds);
            }
            else
            {
                return "0:0:0";
            }
        }
        public String getCrashes()
        {
            return crashes.ToString();
        }
        public void Dispose()
        {
            proc.Dispose();
            pinger.Dispose();
        }
        public void LogMessage(String msg)
        {
            msg = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": " + msg + "\r\n";
            this.Log += msg;

            if (!System.IO.File.Exists(@"logs\serv_" + this.getId() + ".log"))
            {
                var stream = System.IO.File.CreateText(@"logs\serv_" + this.getId() + ".log");
                stream.Dispose();
            }
            try
            {
                var append = System.IO.File.AppendText(@"logs\serv_" + this.getId() + ".log");
                append.Write(msg);
                append.Dispose();
            }
            catch (System.IO.IOException)
            {
                Thread.Sleep(1000);
            }
        }
    }

    class WaitForExit
    {
        private Process proc;
        private SrcdsMonitor caller;
        private int procType;

        public WaitForExit(Process proc, object caller, int procType)
        {
            this.proc = proc;
            this.caller = (SrcdsMonitor)caller;
            this.procType = procType;
        }
        public void Waiting()
        {
            proc.WaitForExit();
            switch (procType)
            {
                case 0:
                    caller.Exited(this);
                    return;
                case 1:
                    caller.DoneUpdating();
                    return;
                case 2:
                    caller.DoneInstalling();
                    return;
            }
        }
    }

    class SrcdsPinger : IDisposable
    {
        private IPEndPoint serverEP;
        private Socket sock = new Socket(SocketType.Dgram, ProtocolType.Udp);
        private System.Timers.Timer pingTimer;
        private int timeouts = 0;
        private byte[] query = {0xff, 0xff, 0xff, 0xff, 0x54, 0x53, 0x6f, 0x75, 0x72, 0x63, 0x65, 0x20, 0x45, 0x6e,
                                  0x67, 0x69, 0x6e, 0x65, 0x20, 0x51, 0x75, 0x65, 0x72, 0x79, 0x00};
        private SrcdsMonitor caller;
        private Process proc;
        private System.Timers.Timer timeoutTimer;

        public SrcdsPinger(object source, IPAddress addr, int port, Process proc)
        {
            serverEP = new IPEndPoint(addr, port);
            this.caller = (SrcdsMonitor)source;
            this.proc = proc;
        }
        public void StartPinging()
        {
            sock = new Socket(SocketType.Dgram, ProtocolType.Udp);
            sock.Bind(new IPEndPoint(IPAddress.Any, 0));

            sock.ReceiveTimeout = 1500;
            sock.SendTimeout = 1500;

            pingTimer = new System.Timers.Timer(15000);
            pingTimer.SynchronizingObject = null;
            pingTimer.Elapsed += new System.Timers.ElapsedEventHandler(PingServer);
            pingTimer.AutoReset = true;
            pingTimer.Enabled = true;
            pingTimer.Start();

            timeoutTimer = new System.Timers.Timer(3000);
            timeoutTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timedout);
            timeoutTimer.AutoReset = true;
            timeoutTimer.Enabled = false;
        }
        private void PingServer(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                sock.SendTo(query, serverEP);
            }
            catch (ObjectDisposedException)
            {
                this.Dispose();
            }
            byte[] rec = new byte[256];

            try
            {
                try
                {
                    sock.Receive(rec);
                }
                catch (ObjectDisposedException)
                {
                    this.Dispose();
                }
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.TimedOut)
                {
                    timeouts++;
                    caller.Status = SrcdsStatus.NoReply;
                    pingTimer.Enabled = false;
                    pingTimer.Stop();

                    timeoutTimer.Enabled = true;
                    timeoutTimer.Start();
                }
            }
        }
        private void Timedout(object source, System.Timers.ElapsedEventArgs e)
        {
            sock.SendTo(query, serverEP);
            byte[] rec = new byte[265];

            try
            {
                sock.Receive(rec);
            }
            catch (SocketException ex)
            {
                if ((SocketError)ex.ErrorCode == SocketError.TimedOut)
                {
                    timeouts++;

                    caller.LogMessage("Server timedout, retry in 3 seconds");

                    if (timeouts > 3)
                    {
                        proc.Kill();
                        timeoutTimer.Enabled = false;
                        timeoutTimer.Stop();

                        pingTimer.Enabled = true;
                        pingTimer.AutoReset = true;
                        pingTimer.Start();

                        timeouts = 0;

                        caller.LogMessage("Max timeouts reached, restarting");
                    }

                }
                return;
            }
            caller.Status = SrcdsStatus.Online;
            timeoutTimer.Enabled = false;
            timeoutTimer.Stop();

            pingTimer.Enabled = true;
            pingTimer.AutoReset = true;
            pingTimer.Start();

            timeouts = 0;
        }
        public void Dispose()
        {
            try
            {
                pingTimer.Dispose();
                timeoutTimer.Dispose();
                sock.Dispose();
            }
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(System.NullReferenceException))
                {
                    throw (ex);
                }
            }
        }
    }
}