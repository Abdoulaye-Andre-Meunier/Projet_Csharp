using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Global_Expertise
{
    public partial class Sellers : Form
    {
        public Sellers()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sellers_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            .Text = Sellerview.SelectedRows[0].Cells[0].Value.ToString();
            Prodname.Text = Sellerview.SelectedRows[0].Cells[1].Value.ToString();
            ProdQty.Text = Sellerview.SelectedRows[0].Cells[2].Value.ToString();
            ProdPrice.Text = Sellerview.SelectedRows[0].Cells[3].Value.ToString();
            CatCb.SelectedValue = Sellerview.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}
