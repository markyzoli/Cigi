using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigi
{
    public class KeszletInfo
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public int DohanyGr { get; set; }
        public int SzipkaDb { get; set; }
        public int HuvelyDb { get; set; }
        public int FDohanyGr { get; set; }
        public int FSzipkaDb { get; set; }
        public int FHuvelyDb { get; set; }
        public int Napok { get; set; }
    }
}
