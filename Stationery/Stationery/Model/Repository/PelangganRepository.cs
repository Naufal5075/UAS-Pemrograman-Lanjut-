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
    public class PelangganRepository
    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public PelangganRepository(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }
        public int Create(PelangganEntity plnggn)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into Pelanggan (nama_pelanggan, jenis_kelamin, alamat, no_telphone) values (@nama_pelanggan, @jenis_kelamin, @alamat, @no_telphone)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@nama_pelanggan", plnggn.Nama_Pelanggan);
                cmd.Parameters.AddWithValue("@jenis_kelamin", plnggn.Jenis_Kelamin);
                cmd.Parameters.AddWithValue("@alamat", plnggn.Alamat);
                cmd.Parameters.AddWithValue("@no_telphone", plnggn.No_Telphone);
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

        public int Update(PelangganEntity plnggn)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update Pelanggan set nama_pelanggan = @nama_pelanggan, jenis_kelamin = @jenis_kelamin, alamat = @alamat, no_telphone = @no_telphone where id_pelanggan = @id_pelanggan";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@nama_pelanggan", plnggn.Nama_Pelanggan);
                cmd.Parameters.AddWithValue("@jenis_kelamin", plnggn.Jenis_Kelamin);
                cmd.Parameters.AddWithValue("@alamat", plnggn.Alamat);
                cmd.Parameters.AddWithValue("@no_telphone", plnggn.No_Telphone);
                cmd.Parameters.AddWithValue("@id_pelanggan", plnggn.Id_Pelanggan);

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

        public int Delete(PelangganEntity plnggn)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from Pelanggan
                           where id_pelanggan = @id_pelanggan";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_pelanggan", plnggn.Id_Pelanggan);

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

        public List<PelangganEntity> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<PelangganEntity> list = new List<PelangganEntity>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_pelanggan, nama_pelanggan, jenis_kelamin, alamat, no_telphone
                               from Pelanggan
                               order by id_pelanggan";

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
                            PelangganEntity plnggn = new PelangganEntity();
                            plnggn.Id_Pelanggan = dtr["Id_Pelanggan"].ToString();
                            plnggn.Nama_Pelanggan = dtr["Nama_Pelanggan"].ToString();
                            plnggn.Jenis_Kelamin = dtr["Jenis_Kelamin"].ToString();
                            plnggn.Alamat = dtr["Alamat"].ToString();
                            plnggn.No_Telphone = dtr["No_Telphone"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(plnggn);
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
        public List<PelangganEntity> ReadByNama(string nama)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<PelangganEntity> list = new List<PelangganEntity>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_pelanggan, nama_pelanggan, jenis_kelamin, alamat, no_telphone
                               from Pelanggan 
                               where nama_pelanggan like @nama_pelanggan
                               order by nama_pelanggan";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@nama_pelanggan", string.Format("{0}", nama));

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            PelangganEntity plnggn = new PelangganEntity();
                            plnggn.Id_Pelanggan = dtr["Id_Pelanggan"].ToString();
                            plnggn.Nama_Pelanggan = dtr["Nama_Pelanggan"].ToString();
                            plnggn.Jenis_Kelamin = dtr["Jenis_Kelamin"].ToString();
                            plnggn.Alamat = dtr["Alamat"].ToString();
                            plnggn.No_Telphone = dtr["No_Telphone"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(plnggn);
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
