using Stationery.Model.Context;
using Stationery.Model.Entity;
using Stationery.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stationery.Controller
{
    public class PelangganController
    {
        // deklarasi objek Repository untuk menjalankan operasi CRUD
        private PelangganRepository _repository;

        /// <summary>
        /// Method untuk menampilkan data barang berdasarkan nama
        /// </summary>
        /// <param name="nama"></param>
        /// <returns></returns>
        public List<PelangganEntity> ReadByNama(string nama)
        {
            // membuat objek collection
            List<PelangganEntity> list = new List<PelangganEntity>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method ReadByNama yang ada di dalam class repository
                list = _repository.ReadByNama(nama);
            }

            return list;
        }

        /// <summary>
        /// Method untuk menampilkan semua data mahasiswa
        /// </summary>
        /// <returns></returns>
        public List<PelangganEntity> ReadAll()
        {
            // membuat objek collection
            List<PelangganEntity> list = new List<PelangganEntity>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method ReadAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }

            return list;
        }

        public int Create(PelangganEntity plnggn)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(plnggn.Nama_Pelanggan))
            {
                MessageBox.Show("Nama Pelanggan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(plnggn.Jenis_Kelamin))
            {
                MessageBox.Show("Jenis Kelamin harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(plnggn.Alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(plnggn.No_Telphone))
            {
                MessageBox.Show("No Telphone harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new PelangganRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(plnggn);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pelanggan berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data pelanggan gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Update(PelangganEntity plnggn)
        {
            int result = 0;

            
            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(plnggn.Id_Pelanggan))
            {
                MessageBox.Show("Id Pelanggan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            
            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(plnggn.Nama_Pelanggan))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(plnggn.Jenis_Kelamin))
            {
                MessageBox.Show("Jenis Kelamin harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(plnggn.Alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(plnggn.No_Telphone))
            {
                MessageBox.Show("No Telphone harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.Update(plnggn);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Pelanggan berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Pelanggan gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(PelangganEntity plnggn)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(plnggn.Id_Pelanggan))
            {
                MessageBox.Show("Id Pelanggan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(plnggn);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pelanggan berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data pelanggan gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
    }
}
