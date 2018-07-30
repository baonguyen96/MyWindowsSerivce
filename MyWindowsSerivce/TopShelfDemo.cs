using System;
using System.IO;
using System.Timers;
using Microsoft.Win32;

namespace MyWindowsSerivce
{
    class TopShelfDemo
    {
        readonly Timer _timer;
        private int _count = 0;

        public TopShelfDemo()
        {
            _timer = new Timer(1000) {AutoReset = true};
            _timer.Elapsed += Log;
        }

        private void Log(object sender, ElapsedEventArgs e)
        {
            const string path = @"C:\Users\Bao\Documents\Log.txt";
            Console.WriteLine($"Elapsed at {DateTime.Now}");

            _count++;

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"{DateTime.Now}");
            }

            if (_count == 5)
            {
                Console.WriteLine("Throwing exception now");
                throw new Exception("Too many times");
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