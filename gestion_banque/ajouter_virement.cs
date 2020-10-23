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
    public partial class ajouter_virement : Form
    {
        public ajouter_virement()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=desktop-35blbr5\sqlexpress;Initial Catalog=banque;Integrated Security=True");
        SqlDataAdapter adp;
        SqlDataAdapter adp1;

        SqlDataAdapter adp2;
       
        DataSet dst = new DataSet();
        DataView dv1;
        DataView dv2;
        private void ajouter_virement_Load(object sender, EventArgs e)
        {
            adp1 = new SqlDataAdapter("Select distinct * from compte", cn);
            adp1.Fill(dst, "CV");
            adp2 = new SqlDataAdapter("Select distinct * from compte", cn);
            adp2.Fill(dst, "CVV");
            adp = new SqlDataAdapter("select * from Virement", cn);
            adp.Fill(dst, "vrm");
            comboBox1.DataSource = dst.Tables["CV"];
            comboBox1.ValueMember = "Num_Compte";
            comboBox2.DataSource = dst.Tables["CVV"];
            comboBox2.ValueMember = "Num_Compte";
            dataGridView1.DataSource = dst.Tables["vrm"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text== ""  )
            {
                MessageBox.Show("remplir tous les champs");
            }
            else {
                adp = new SqlDataAdapter("Select * from Virement", cn);
            adp.Fill(dst, "vrm");
            DataRow ligne = dst.Tables["vrm"].NewRow();
            ligne[0] = dst.Tables["vrm"].Rows.Count + 1;
            ligne[1] = comboBox1.Text;
            ligne[2] = comboBox2.Text;
            ligne[3] = textBox1.Text;
            ligne[4] = DateTime.Now.ToString();
                dst.Tables["vrm"].Rows.Add(ligne);
                adp1 = new SqlDataAdapter("Select * from compte", cn);
                adp1.Fill(dst, "cpt");
                dv1 = new DataView(dst.Tables["cpt"], "Num_Compte= " + comboBox1.SelectedValue, "", DataViewRowState.CurrentRows);

                if (Decimal.Parse(dv1[0]["Sold"].ToString()) - Decimal.Parse(textBox1.Text) <= 0)
                {
                    MessageBox.Show("Solde insuffisant pour le compte");
                  
                }
                else
                {
                    dv1[0]["Sold"] =Decimal.Parse( dv1[0]["Sold"].ToString() )-Decimal.Parse(textBox1.Text) + " ";
                   
                }
               
                dv2 = new DataView(dst.Tables["cpt"], "Num_Compte = " + comboBox2.SelectedValue, "", DataViewRowState.CurrentRows);

                dv2[0]["Sold"] = Decimal.Parse(dv2[0]["Sold"].ToString()) + Decimal.Parse(textBox1.Text) + " ";
                MessageBox.Show("Ajout Effectué");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cd = new SqlCommandBuilder(adp);
            adp.Update(dst, "vrm");
            SqlCommandBuilder cd1 = new SqlCommandBuilder(adp1);
            adp1.Update(dst, "cpt");
            MessageBox.Show("sauvgarde effectue");
            this.Close();
        }
    }
}
