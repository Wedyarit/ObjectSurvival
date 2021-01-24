using System;
using System.IO;
using System.Threading;

namespace FileSystem
{
    class Record
    {
        public TimeSpan TimeSpan { get; set; }
        private string path = @"record.txt";

        public void ReadRecord()
        {
            if (File.Exists(path))
                using (StreamReader sr = File.OpenText(path))
                    TimeSpan = new TimeSpan(0, 0, int.Parse(sr.ReadLine()));
        }

        public void SaveRecord(TimeSpan timeSpan)
        {
            if (File.Exists(path))
                using (StreamWriter sw = File.CreateText(path))
                    sw.WriteLine(Math.Round(timeSpan.TotalSeconds));
        }

        public static TimeSpan Max(TimeSpan span1, TimeSpan span2)
        {
            if (TimeSpan.Compare(span1, span2) == 1) return span1; return span2;
        }
    }
}
