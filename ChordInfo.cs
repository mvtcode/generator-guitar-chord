using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenChord
{
    [Serializable]
    public class ChordInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<app> Apps { get; set; }
    }
}
