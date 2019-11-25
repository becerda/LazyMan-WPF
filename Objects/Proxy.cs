using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyManWPF.Objects
{
    class Proxy
    {
        private int Port { get; set; }

        private bool Ready { get; set; }

        private string Path { get; set; }

        private string MITM { get; set; }

        private Process Process { get; set; }

        public Proxy(int port)
        {
            if(port == -1)
            {
                Port = 5024;
            }
            else
            {
                Port = port;
            }
            Ready = false;

            MITM = "win" + System.IO.Path.DirectorySeparatorChar + "mlbamproxy.exe";
            Path = System.IO.Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "mlbamproxy" + System.IO.Path.DirectorySeparatorChar;
        }

        public void Run()
        {
            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = Path + MITM,
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            info.Arguments += "-p " + string.Empty + Port + " -d freegames.ga -s mf.svc.nhl.com,playback.svcs.mlb.com,mlb-ws-mf.media.mlb.com";

            Process = new Process();
            Process.StartInfo = info;
            try
            {
                Process.Start();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool IsRunning()
        {
            if (Process == null)
                return false;
            return !Process.HasExited;
        }

        public void Kill()
        {
            Ready = false;
            if(Process != null)
            {
                try
                {
                    Process.Kill();
                }
                catch(InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Process.Dispose();
            }
            Process = null;
        }

        public bool IsReady()
        {
            try
            {
                return !Process.WaitForExit(3000);
            }catch(SystemException e)
            {
                EventLog.WriteEntry(nameof(Proxy), e.Message, EventLogEntryType.Error);
                return false;
            }
        }
    }
}
