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
namespace gestion_banque
{
    public partial class ajouter_client : Form
    {
        public ajouter_client()
        {
            InitializeComponent();
        }
        SqlConnection c = new SqlConnection(@"Data Source=desktop-35blbr5\sqlexpress;Initial Catalog=banque;Integrated Security=True");
        DataSet ds = new DataSet();
       
        SqlDataAdapter daa;
        private void ajouter_client_Load(object sender, EventArgs e)
        {
           
            daa = new SqlDataAdapter("select * from client", c);
            try
            {
             
                daa.Fill(ds, "DsClients");
                dataGridView1.DataSource = ds.Tables["DsClients"];
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != " " && textBox3.Text != "" )
            {
                try
                {
                    DataRow ligne = ds.Tables["DsClients"].NewRow();
                    ligne[0] = textBox1.Text;
                    ligne[1] = textBox2.Text;
                    ligne[2] = textBox3.Text;
                   
                    ds.Tables["DsClients"].Rows.Add(ligne);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    MessageBox.Show("ajout effectue");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("saisie incomplete");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder bldq = new SqlCommandBuilder(daa);
                daa.Update(ds,"DsClients");
                MessageBox.Show("sauvgarde effectue");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
