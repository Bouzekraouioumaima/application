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
    public partial class Modification_compte : Form
    {
        public Modification_compte()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=desktop-35blbr5\sqlexpress;Initial Catalog=banque;Integrated Security=True");
        SqlDataAdapter ad;
       
        DataSet ds=new DataSet();
        DataView dv = new DataView();
        DataView dv1 = new DataView();
        private void Modification_compte_Load(object sender, EventArgs e)
        {
            try
            {
                
                ad = new SqlDataAdapter("select * from  compte", cn);
                ad.Fill(ds, "cpt");
                comboBox1.DataSource = ds.Tables["cpt"];
                comboBox1.ValueMember = "num_Compte";
                dataGridView1.DataSource = ds.Tables["cpt"];
                dv = new DataView(ds.Tables["cpt"], "", "", DataViewRowState.ModifiedCurrent);
                dataGridView2.DataSource = dv;
            }
            catch(Exception ex )
            {
                MessageBox.Show("lod"+ex.Message);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dv1 = new DataView(ds.Tables["cpt"], "Num_Compte = " + comboBox1.SelectedValue, "", DataViewRowState.CurrentRows);
                dv1[0].BeginEdit();
                dv1[0]["Num_Client"] = textBox1.Text;

                dv1[0]["typeC"] = comboBox2.Text;
                dv1[0].EndEdit();
                MessageBox.Show("modification effectuee");
            }
            catch (Exception ex)
            {
                MessageBox.Show("erreur bt"+ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dv1 = new DataView(ds.Tables["cpt"], "Num_Compte = " + comboBox1.SelectedValue, "", DataViewRowState.CurrentRows);
                textBox1.Text = dv1[0].Row["Num_Client"].ToString();
                textBox2.Text = dv1[0].Row["Sold"].ToString();
                comboBox2.Text = dv1[0].Row["typeC"].ToString();
            }catch(Exception ex)
            {
                MessageBox.Show("com"+ex.Message);
            }
           
        }

        private void Modification_compte_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(dv.Count !=0)
            {
                DialogResult res = MessageBox.Show("voulez vous appliquer les modifications", "comfirmation modification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(res == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommandBuilder bldr = new SqlCommandBuilder(ad);
                        ad.Update(ds, "cpt");
                        
                    }catch(Exception ex)
                    {
                        MessageBox.Show("mo"+ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
