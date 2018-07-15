using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MyWindowsSerivce
{
    class Program
    {
        static void Main(string[] args)
        {

            var rc = HostFactory.Run(x =>                                 
            {
                x.Service<TopShelfDemo>(s =>                                 
                {
                    s.ConstructUsing(name => new TopShelfDemo());                
                    s.WhenStarted(tc => tc.Start());                         
                    s.WhenStopped(tc => tc.Stop());                          
                });

                x.RunAsLocalSystem();                                       
       
                x.SetDescription("Sample Topshelf Host");                   
                x.SetDisplayName("TopShelf");                                  
                x.SetServiceName("TopShelf");
                

                // since we will call the vbs (it then calls this exe with correct parameters) we dont need the following codes:

//                x.AfterInstall(settings =>
//                {
//                    Console.WriteLine("after install");
//                    RunCmdCommand("start");
//                });
//                
//
//                x.BeforeUninstall(() =>
//                {
//                    Console.WriteLine("before uninstall");
//                    RunCmdCommand("stop");
//                });
//                
//                x.StartAutomatically();

            });                                                             


            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  
            Environment.ExitCode = exitCode;

        }

        private static void RunCmdCommand(string command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/C ./MyWindowsService.exe {command}";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            const string path = "./Command.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(command);
            }

        }

    }
}
