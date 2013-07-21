using System;
using System.Threading;
using System.Diagnostics;

namespace SrcdsManager
{
    class SrcdsMonitor
    {
        private String exePath;
        private String commandLine;
        private String Name;
        private String sID;

        private bool running = false;

        private Process proc = new Process();
        private ProcessStartInfo startInfo;

        private int crashes = 0;

        Thread oThread;

        DateTime startTime;

        public SrcdsMonitor(String exePath, String commandLine, String Name, String sID)
        {
            this.exePath = exePath;
            this.commandLine = commandLine;
            this.Name = Name;
            this.sID = sID;

            startInfo = new ProcessStartInfo();
            startInfo.Arguments = commandLine;
            startInfo.FileName = exePath;

            proc.StartInfo = startInfo;
        }

        public void Start()
        {
            proc.Start();

            WaitForExit oWait = new WaitForExit(proc, this);
            oThread = new Thread(new ThreadStart(oWait.Waiting));

            running = true;

            startTime = DateTime.Now;
        }
        public void Restart()
        {
            this.crashes++;

            proc.Start();

            WaitForExit oWait = new WaitForExit(proc, this);
            Thread oThread = new Thread(new ThreadStart(oWait.Waiting));

            startTime = DateTime.Now;
        }
        public void Stop()
        {
            oThread.Abort();
            proc.Kill();

            running = false;
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
    }

    class WaitForExit
    {
        private Process proc;
        private SrcdsMonitor caller;
        public WaitForExit(Process proc, SrcdsMonitor caller)
        {
            this.proc = proc;
            this.caller = caller;
        }
        public void Waiting()
        {
            proc.WaitForExit();
            caller.Restart();
        }
    }
}