using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.Model.Entity
{
    public class BarangEntity
    {
        public string Id_Barang { get; set; }
        public string Nama_Barang { get; set; }
        public string Kategori_Barang { get; set; }
        public string Harga_Barang { get; set; }
        public string Pabrik_Barang { get; set; }
        public string Stok { get; set; }
    }
}
