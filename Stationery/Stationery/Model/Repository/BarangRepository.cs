using Stationery.Model.Context;
using Stationery.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.Model.Repository
{
    public class BarangRepository
    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public BarangRepository(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(BarangEntity brg)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into Barang (nama_barang, kategori_barang, harga_barang, stok, pabrik_barang) values (@nama_barang, @kategori_barang, @harga_barang, @stok, @pabrik_barang)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@nama_barang", brg.Nama_Barang);
                cmd.Parameters.AddWithValue("@kategori_barang", brg.Kategori_Barang);
                cmd.Parameters.AddWithValue("@harga_barang", brg.Harga_Barang);
                cmd.Parameters.AddWithValue("@stok", brg.Stok);
                cmd.Parameters.AddWithValue("@pabrik_barang", brg.Pabrik_Barang);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Update(BarangEntity brg)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update Barang set nama_barang = @nama_barang, kategori_barang = @kategori_barang, harga_barang = @harga_barang, stok = @stok, pabrik_barang = @pabrik_barang
                           where id_barang = @id_barang";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@nama_barang", brg.Nama_Barang);
                cmd.Parameters.AddWithValue("@kategori_barang", brg.Kategori_Barang);
                cmd.Parameters.AddWithValue("@harga_barang", brg.Harga_Barang);
                cmd.Parameters.AddWithValue("@stok", brg.Stok);
                cmd.Parameters.AddWithValue("@pabrik_barang", brg.Pabrik_Barang);
                cmd.Parameters.AddWithValue("@id_barang", brg.Id_Barang);

                try
                {
                    // jalankan perintah UPDATE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Delete(BarangEntity brg)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from Barang
                           where id_barang = @id_barang";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_barang", brg.Id_Barang);

                try
                {
                    // jalankan perintah DELETE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result;
        }

        public List<BarangEntity> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<BarangEntity> list = new List<BarangEntity>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_barang, nama_barang, stok,kategori_barang, harga_barang, pabrik_barang 
                               from Barang
                               order by id_barang";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                        // proses konversi dari row result set ke object
                        BarangEntity brg = new BarangEntity();
                        brg.Id_Barang = dtr["Id_Barang"].ToString();
                        brg.Nama_Barang = dtr["Nama_Barang"].ToString();
                        brg.Stok = dtr["Stok"].ToString();
                        brg.Kategori_Barang = dtr["Kategori_Barang"].ToString();
                        brg.Harga_Barang = dtr["Harga_Barang"].ToString();
                        brg.Pabrik_Barang = dtr["Pabrik_Barang"].ToString();

                        // tambahkan objek mahasiswa ke dalam collection
                        list.Add(brg);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return list;
        }

        // Method untuk menampilkan data mahasiwa berdasarkan pencarian nama
        public List<BarangEntity> ReadByNama(string nama)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<BarangEntity> list = new List<BarangEntity>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_barang, nama_barang, desk_barang, stok, kategori_barang, harga_barang, pabrik_barang 
                               from Barang 
                               where nama_barang like @nama_barang
                               order by nama_barang";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@nama_barang", string.Format("{0}", nama));

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                        // proses konversi dari row result set ke object
                        BarangEntity brg = new BarangEntity();
                        brg.Id_Barang = dtr["Id_Barang"].ToString();
                        brg.Nama_Barang = dtr["Nama_Barang"].ToString();
                        brg.Stok = dtr["Stok"].ToString();
                        brg.Kategori_Barang = dtr["Kategori_Barang"].ToString();
                        brg.Harga_Barang = dtr["Harga_Barang"].ToString();
                        brg.Pabrik_Barang = dtr["Pabrik_Barang"].ToString();
                        // tambahkan objek mahasiswa ke dalam collection
                        list.Add(brg);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }

            return list;
        }
    }
}
