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
    public partial class Ajouter_compte : Form
    {
        public Ajouter_compte()
        {
            InitializeComponent();
        }
        SqlConnection c = new SqlConnection(@"Data Source=desktop-35blbr5\sqlexpress;Initial Catalog=banque;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter da;
         SqlDataAdapter daa;
        private void Ajouter_compte_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from compte", c);
            daa = new SqlDataAdapter("select * from client", c);
            try
            {
                da.Fill(ds, "DsComptes");
                daa.Fill(ds, "DsClients");
                dataGridView1.DataSource = ds.Tables["DsComptes"];
                comboBox2.SelectedIndex = 0;
                comboBox1.DisplayMember = "Num_Client";
                comboBox1.ValueMember = "Num_Client";
                comboBox1.DataSource = ds.Tables["DsClients"];

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text !=" " && comboBox1.Text !="" && comboBox1.Text !="")
            {
                try
                {
                    DataRow ligne = ds.Tables["DsComptes"].NewRow();
                    ligne[0] = textBox1.Text;
                    ligne[1] = comboBox1.Text;
                    ligne[2] = textBox2.Text;
                    ligne[3] = comboBox2.Text;
                  
                    ds.Tables["DsComptes"].Rows.Add(ligne);
                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    MessageBox.Show("ajout effectue");

                }
                catch(Exception ex)
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
                SqlCommandBuilder bldq = new SqlCommandBuilder(da);
                da.Update(ds, "DsComptes");
                MessageBox.Show("sauvgarde effectue");
                this.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
