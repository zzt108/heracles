using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Configuration;

namespace IntegrationTest
{

    public class ServiceHandler : IDisposable
    {

        private static Process _process;
        private static readonly string _processName;

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
            return ConfigurationManager.AppSettings["TestedProcessPath"];
        }

        public static void Launch()
        {
            KillProcesses();
            _process = new Process();
            var appPath = GetExecutablePath();
            Console.WriteLine(appPath);
            _process.StartInfo.FileName = Path.Combine(appPath, _processName);
            _process.Start();
        }


        public static void Exit()
        {
            KillExistingProcess(_processName, killProcesses: true);
        }

        public static void KillExistingProcess(string processName, bool killProcesses = true)
        {
            var processNameWithoutExtension = Path.GetFileNameWithoutExtension(processName);
            //Console.WriteLine($"KillExistingProcess {processNameWithoutExtension} {killProcesses}");
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
