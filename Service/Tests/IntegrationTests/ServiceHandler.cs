using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Configuration;

namespace IntegrationTest
{

    public class ServiceHandler:IDisposable
    {

        private static Process _process;
        private static readonly string _processName ;

        static ServiceHandler()
        {
            _processName = ConfigurationManager.AppSettings["TestedProcess"];
        }

        public ServiceHandler()
        {
            Launch();
        }

        private static string GetExecutablePath()
        {
            var path = ConfigurationManager.AppSettings["TestedProcessPath"];
            return Path.Combine(path,_processName);
        }

        public static void Launch()
        {
            KillProcesses();
            _process = new Process();
            var appPathExe = GetExecutablePath();
            _process.StartInfo.FileName = Path.Combine(appPathExe, $"{_processName}.exe");
            _process.Start();
        }


        public static void Exit()
        {
            KillExistingProcess(_processName, killProcesses: true);
        }

        public static void KillExistingProcess(string processNameWithoutExtension, bool killProcesses = true)
        {
            if (killProcesses)
            {
                var pa = Process.GetProcessesByName(processNameWithoutExtension.ToLowerInvariant());
                foreach (var process in pa)
                {
                    Console.WriteLine($"Killing {processNameWithoutExtension} {process.Id}");
                    Thread.Sleep(3000);
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Failed to kill {process.ProcessName}", e);
                    }
                }
            }
        }

        private static void KillProcesses()
        {
            KillExistingProcess(_processName, killProcesses: true);
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
            KillExistingProcess(_processName, killProcesses: true);
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~ServiceHandler()
        {
            ReleaseUnmanagedResources();
        }
    }
}
