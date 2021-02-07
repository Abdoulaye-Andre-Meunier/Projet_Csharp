using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Global_Expertise
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ANDRE_a_MEUNIER\Documents\BDglobal.mdf;Integrated Security=True;Connect Timeout=30");

        public object idProd { get; private set; }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
private void fillcombo()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select nameCat from TblCategory", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("nameCat", typeof(string));
            dt.Load(rdr);
            CatCb.ValueMember = "nameCat";
            CatCb.DataSource = dt;
            Con.Close();
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into TblProduct values(" + Prodid.Text + ",'" + Prodname.Text + "'," + ProdQty.Text + "," + ProdPrice.Text + ",'" + CatCb.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added");
                Con.Close();
                //populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
private void populate()
        {
            Con.Open();
            string query = "select * from TblProduct";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            int v = sda.Fill(ds);
            Prodview.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Prodid.Text = Prodview.SelectedRows[0].Cells[0].Value.ToString();
            Prodname.Text = Prodview.SelectedRows[0].Cells[1].Value.ToString();
            ProdQty.Text = Prodview.SelectedRows[0].Cells[2].Value.ToString();
            ProdPrice.Text = Prodview.SelectedRows[0].Cells[3].Value.ToString();
            CatCb.SelectedValue = Prodview.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void CatCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
