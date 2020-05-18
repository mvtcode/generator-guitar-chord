using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenChord
{
    [Serializable]
    public class app
    {
        public string Fret { get; set; }
        public List<Finger> Listf { get; set; }
        public List<int> ListS { get; set; }
    }
}
