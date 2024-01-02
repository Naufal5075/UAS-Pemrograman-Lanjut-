using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.Model.Entity
{
    public class PembayaranEntity
    {
        public string Nama_Barang { get; set; }
        public decimal Harga { get; set; }
        public string Kategori { get; set; }
        public string Pabrik { get; set; }
    }
}
