using System;
using System.IO;
using System.Net.Mail;
using Topshelf;

namespace MyWindowsSerivce
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
//                if (!File.Exists(@"C:\Users\Bao\Documents\nonexist.txt"))
//                {
//                    throw new Exception("This should stop the service");
//                }

                
                var rc = HostFactory.New(x =>
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

                    x.StartAutomatically();

                    x.OnException(ex =>
                    {
                        Console.WriteLine("TopShelf caught exception");
                        Console.WriteLine(ex.Message);
                    });
                    

                });
                
                rc.Run();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Catch exception '{e.Message}'");
            }
        }
    }
}
