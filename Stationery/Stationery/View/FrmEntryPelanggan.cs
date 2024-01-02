using Stationery.Controller;
using Stationery.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stationery.View
{
    public partial class FrmEntryPelanggan : Form
    {
        // deklarasi object collection untuk menampung object mahasiswa
        private List<PelangganEntity> listOfPelanggan = new List<PelangganEntity>();
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(PelangganEntity plnggn);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi objek controller
        private PelangganController controller;
        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;
        // deklarasi field untuk meyimpan objek mahasiswa
        private PelangganEntity plnggn;

        // constructor untuk inisialisasi data ketika entri data baru
        public FrmEntryPelanggan(string title, PelangganController controller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
        }
        // constructor untuk inisialisasi data ketika mengedit data
        public FrmEntryPelanggan(string title, PelangganEntity obj, PelangganController
         controller)
          : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
            isNewData = false; // set status edit data
            plnggn = obj; // set objek mhs yang akan diedit
                       // untuk edit data, tampilkan data lama
            tb_pelanggan.Text = plnggn.Nama_Pelanggan;
            cb_jeniskelamin.Text = plnggn.Jenis_Kelamin;
            tb_alamat.Text = plnggn.Alamat;
            tb_notlpn.Text = plnggn.No_Telphone;
        }
        public FrmEntryPelanggan()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (isNewData) plnggn = new PelangganEntity();

            plnggn.Nama_Pelanggan = tb_pelanggan.Text;
            plnggn.Jenis_Kelamin = cb_jeniskelamin.Text;
            plnggn.Alamat = tb_alamat.Text;
            plnggn.No_Telphone = tb_notlpn.Text;
            int result = 0;
            if (isNewData)
            {

                result = controller.Create(plnggn);
                if (result > 0)
                {
                    OnCreate(plnggn);

                    tb_pelanggan.Clear();
                    cb_jeniskelamin.Text = "";
                    tb_alamat.Clear();
                    tb_notlpn.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(plnggn);
                if (result > 0)
                {
                    OnUpdate(plnggn); // panggil event OnUpdate
                    this.Close();
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
