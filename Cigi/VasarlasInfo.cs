using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigi
{
    public class VasarlasInfo
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int CigiDohanyAr { get; set; }
        public int PipaDohanyAr { get; set; }
        public int HuvelyAr { get; set; }
        public int SzipkaAr { get; set; }
        public int CigiDohanyGr { get; set; }
        public int PipaDohanyGr { get; set; }
        public int HuvelyDb { get; set; }
        public int SzipkaDb { get; set; }
        public int VasarlasMaradek { get; set; }
    }
}
