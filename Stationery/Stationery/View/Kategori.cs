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
    public partial class Kategori : Form
    {
        public Kategori()
        {
            InitializeComponent();
        }

        private void btn_items_Click(object sender, EventArgs e)
        {
            Barang barang = new Barang();
            barang.Show();
            this.Hide();
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
    }
}
