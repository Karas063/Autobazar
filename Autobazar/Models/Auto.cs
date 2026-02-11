using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Autobazar.Models
    {
        public class Auto
        {
            public string Znacka { get; set; }
            public string Model { get; set; }
            public string Barva { get; set; }
            public string SPZ { get; set; }
            public int RokVyroby { get; set; }
            public string Palivo { get; set; }
            public int Najezd { get; set; }

            public Vlastnik Vlastnik { get; set; }
        }
    }


