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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ANDRE_a_MEUNIER\Documents\BDglobal.mdf;Integrated Security=True;Connect Timeout=30");
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into TblCategory values(" + idCat.Text + ",'" + nameCat.Text + "','" + descCat.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success");
                Con.Close();
                populate();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
private void populate()
        {
            Con.Open();
            string query = "select * from TblCategory";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            int v = sda.Fill(ds);
            Catview.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idCat.Text = Catview.SelectedRows[0].Cells[0].Value.ToString();
            nameCat.Text = Catview.SelectedRows[0].Cells[1].Value.ToString();
            descCat.Text = Catview.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if(idCat.Text == "")
                {
                    MessageBox.Show("select the category");
                }
                else
                {
                    Con.Open();
                    string query = "delete from TblCategory where idCat=" + idCat.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category deleted");
                    Con.Close();
                    populate();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if(idCat.Text=="" || nameCat.Text=="" || descCat.Text=="")
                {
                    MessageBox.Show("missing information");
                }
                else
                {
                    Con.Open();
                    string query = "update TblCategory set nameCat='" + nameCat.Text + "',descCat='" + descCat.Text + "'where idCat=" + idCat.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category updated");
                    Con.Close();
                    populate();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }
    }
}
