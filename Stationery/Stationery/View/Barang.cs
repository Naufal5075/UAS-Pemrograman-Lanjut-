using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stationery.Model.Entity;
using Stationery.Controller;
using System.Windows.Forms;

namespace Stationery.View
{
    public partial class Barang : Form
    {
        // deklarasi object collection untuk menampung object mahasiswa
        private List<BarangEntity> listOfBarang = new List<BarangEntity>();
        private BarangController controller;
        public Barang()
        {
            InitializeComponent();
            InisialisasiListView();
            controller = new BarangController();
            LoadDataBarang();
        }
        // atur kolom listview
        private void InisialisasiListView()
        {
            lv_barang.View = System.Windows.Forms.View.Details;
            lv_barang.FullRowSelect = true;
            lv_barang.GridLines = true;
            lv_barang.Columns.Add("Id Barang",100,HorizontalAlignment.Center);
            lv_barang.Columns.Add("Nama Barang",200,HorizontalAlignment.Center);
            lv_barang.Columns.Add("Kategori Barang", 200, HorizontalAlignment.Center);
            lv_barang.Columns.Add("Harga Barang", 200, HorizontalAlignment.Center);
            lv_barang.Columns.Add("Pabrik Barang", 200, HorizontalAlignment.Center);
            lv_barang.Columns.Add("Stok", 200, HorizontalAlignment.Center);
        }
        private void LoadDataBarang()
        {
            // kosongkan listview
            lv_barang.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfBarang = controller.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var brg in listOfBarang)
            {
                var item = new ListViewItem(brg.Id_Barang);
                item.SubItems.Add(brg.Nama_Barang);
                item.SubItems.Add(brg.Kategori_Barang);
                item.SubItems.Add(brg.Harga_Barang);
                item.SubItems.Add(brg.Pabrik_Barang);
                item.SubItems.Add(brg.Stok);
                // tampilkan data mhs ke listview
                lv_barang.Items.Add(item);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            // buat objek form entry data mahasiswa
            FrmEntryBarang frmEntry = new FrmEntryBarang("Tambah Data Barang", controller);
            // mendaftarkan method event handler untuk merespon event OnCreate
            frmEntry.OnCreate += OnCreateEventHandler;
            // tampilkan form entry mahasiswa
            frmEntry.ShowDialog();
        }

        private void OnCreateEventHandler(BarangEntity brg)
        {
            listOfBarang.Add(brg);
            ListViewItem item = new ListViewItem(brg.Id_Barang);
            item.SubItems.Add(brg.Nama_Barang);
            item.SubItems.Add(brg.Kategori_Barang);
            item.SubItems.Add(brg.Harga_Barang);
            item.SubItems.Add(brg.Pabrik_Barang);
            item.SubItems.Add(brg.Stok);
            lv_barang.Items.Add(item);
        }

        private void OnUpdateEventHandler(BarangEntity brg)
        {
            // ambil index data mhs yang edit
            int index = lv_barang.SelectedIndices[0];
            // update informasi mhs di listview
            ListViewItem itemRow = lv_barang.Items[index];
            itemRow.SubItems[0].Text = brg.Id_Barang;
            itemRow.SubItems[1].Text = brg.Nama_Barang;
            itemRow.SubItems[2].Text = brg.Kategori_Barang;
            itemRow.SubItems[3].Text = brg.Harga_Barang;
            itemRow.SubItems[4].Text = brg.Pabrik_Barang;
            itemRow.SubItems[5].Text = brg.Stok;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (lv_barang.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                BarangEntity brg = listOfBarang[lv_barang.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                FrmEntryBarang frmEntry = new FrmEntryBarang("Edit Data Mahasiswa", brg, controller);
                // mendaftarkan method event handler untuk merespon event OnUpdate
                frmEntry.OnUpdate += OnUpdateEventHandler;
                // tampilkan form entry mahasiswa
                frmEntry.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (lv_barang.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data barang ingin dihapus ? ", "Konfirmasi",

                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    BarangEntity brg =
                   listOfBarang[lv_barang.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = controller.Delete(brg);
                    if (result > 0) LoadDataBarang();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_cari_Click(object sender, EventArgs e)
        {
            string keyword = tb_items.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(keyword))
            {
                lv_barang.Items.Clear();
                var filteredBarang = listOfBarang
                .Where(brg => brg.Id_Barang.ToLower().Contains(keyword) ||
                brg.Nama_Barang.ToLower().Contains(keyword) || brg.Kategori_Barang.ToLower().Contains(keyword))
                .ToList();
                foreach (var brg in filteredBarang)
                {
                    var item = new ListViewItem(brg.Id_Barang);
                    item.SubItems.Add(brg.Nama_Barang);
                    item.SubItems.Add(brg.Kategori_Barang);
                    item.SubItems.Add(brg.Harga_Barang);
                    item.SubItems.Add(brg.Pabrik_Barang);
                    item.SubItems.Add(brg.Stok);
                    lv_barang.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Masukkan kata kunci untuk melakukan pencarian.", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_customers_Click(object sender, EventArgs e)
        {

            Pelanggan pelanggan = new Pelanggan();
            pelanggan.Show();
            this.Hide();
            
        }

        private void btn_billing_Click(object sender, EventArgs e)
        {
            Pembayaran pembayaran = new Pembayaran();
            pembayaran.Show();
            this.Hide();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

         
        private void btn_logout_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lv_barang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}