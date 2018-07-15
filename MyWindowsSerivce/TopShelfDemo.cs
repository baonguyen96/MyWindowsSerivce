using System;
using System.IO;
using System.Timers;
using Microsoft.Win32;

namespace MyWindowsSerivce
{
    class TopShelfDemo
    {
        readonly Timer _timer;

        public TopShelfDemo()
        {
            _timer = new Timer(1000) {AutoReset = true};
            _timer.Elapsed += Log;
        }

        private void Log(object sender, System.Timers.ElapsedEventArgs e)
        {
            const string path = "./Log.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"{DateTime.Now}");
            }
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

       

    }
}