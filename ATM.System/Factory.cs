using System;
using System.Collections.Generic;
using System.Text;
using TransponderReceiver;

namespace ATM.System
{
    public class Factory
    {
        public Factory(ITransponderReceiver transponderReceiver)
        {
            transponderReceiver.TransponderDataReady += CreateTracks;
        }

        private void CreateTracks(object sender, RawTransponderDataEventArgs e)
        {
            Console.Clear();
            var filter = new Filter();
            var tracks = new List<string>();
            foreach (string track in e.TransponderData)
            {
                char[] seperator = { ';' };
                var list = track.Split(seperator, 5, StringSplitOptions.RemoveEmptyEntries);
                var l = new Track();
                MakePlane(l, list);

                if (filter.CheckXY(l.XCoordinate, l.YCoordinate))
                {
                    Console.BackgroundColor = ConsoleColor.White;

                    Console.WriteLine(l.SerialNumber + " " + l.XCoordinate + " " + l.YCoordinate);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(l.SerialNumber + " " + l.XCoordinate + " " + l.YCoordinate);
                    Console.ResetColor();
                }

            }
        }

        private void MakePlane(Track l, string[] list)
        {
            l.SerialNumber = list[0];
            l.XCoordinate = int.Parse(list[1]);
            l.YCoordinate = int.Parse(list[2]);
            l.Latitude = int.Parse(list[3]);
        }
    }
}
