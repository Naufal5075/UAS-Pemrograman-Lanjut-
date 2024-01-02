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
    public partial class FrmEntryBarang : Form
    {
        // deklarasi object collection untuk menampung object mahasiswa
        private List<BarangEntity> listOfBarang = new List<BarangEntity>();
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(BarangEntity brg);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi objek controller
        private BarangController controller;
        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;
        // deklarasi field untuk meyimpan objek mahasiswa
        private BarangEntity brg;

        // constructor untuk inisialisasi data ketika entri data baru
        public FrmEntryBarang(string title, BarangController controller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
        }
        // constructor untuk inisialisasi data ketika mengedit data
        public FrmEntryBarang(string title, BarangEntity obj, BarangController
        controller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
            isNewData = false; // set status edit data
            brg = obj; // set objek mhs yang akan diedit
                       // untuk edit data, tampilkan data lama
            tb_items.Text = brg.Nama_Barang;
            cb_category.Text = brg.Kategori_Barang;
            tb_harga.Text = brg.Harga_Barang;
            tb_stok.Text = brg.Stok;
            tb_pabrik.Text = brg.Pabrik_Barang;
        }

        // constructor default
        public FrmEntryBarang()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            if (isNewData) brg = new BarangEntity();
            
            brg.Nama_Barang = tb_items.Text;
            brg.Kategori_Barang = cb_category.Text;
            brg.Harga_Barang = tb_harga.Text;
            brg.Stok = tb_stok.Text;
            brg.Pabrik_Barang = tb_pabrik.Text;
            int result = 0;
            if (isNewData)
            {
                
                result = controller.Create(brg);
                if (result > 0) 
                {
                    OnCreate(brg); 
                    
                    tb_items.Clear();
                    cb_category.Text = "";
                    tb_harga.Clear();
                    tb_pabrik.Clear();
                    tb_stok.Focus();
                    tb_pabrik.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(brg);
                if (result > 0)
                {
                    OnUpdate(brg); // panggil event OnUpdate
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

        private void btn_dashboard_Click(object sender, EventArgs e)
        {

        }
    }
}

