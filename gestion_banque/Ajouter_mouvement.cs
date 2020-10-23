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
    public partial class Ajouter_mouvement : Form
    {
        public Ajouter_mouvement()
        {
            InitializeComponent();
        }
        SqlConnection c = new SqlConnection(@"Data Source=desktop-35blbr5\sqlexpress;Initial Catalog=banque;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        SqlDataAdapter daa;
        SqlDataAdapter daaa;
        private void Ajouter_mouvement_Load(object sender, EventArgs e)
        {
            daaa = new SqlDataAdapter("select * from compte ", c);
            daaa.Fill(ds, "cp");
            da = new SqlDataAdapter("select * from mouvement ", c);
            da.Fill(ds, "mouv");
            comboBox1.DataSource = ds.Tables["cp"];
            comboBox1.ValueMember = "Num_Compte";
            dataGridView1.DataSource = ds.Tables["mouv"];
        }
        DataView dv;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text!="" && comboBox1.Text!="")
            {
                try
                {
                    DataRow ligne = ds.Tables["mouv"].NewRow();
                    ligne[0] = ds.Tables["mouv"].Rows.Count + 1;
                    ligne[1] = comboBox1.Text;
                    ligne[2] = textBox2.Text;
                    if (radioButton1.Checked)
                    {
                        try {
                            var rr = 'D';
                        ligne[3] = rr;
                        dv = new DataView(ds.Tables["sld"], "Num_Compte =" +
                      comboBox1.Text, "", DataViewRowState.CurrentRows);
                        dv[0].BeginEdit();
                            dv[0]["Sold"] = Decimal.Parse(dv[0]["Sold"].ToString()) + Decimal.Parse(textBox2.Text) + "";

                            dv[0].EndEdit();
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.SelectedIndex = 0;
                            MessageBox.Show("Ajout Effectué");
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                    if (radioButton2.Checked)
                    {
                      
                        if (Decimal.Parse(dv[0]["Sold"].ToString()) - Decimal.Parse(textBox2.Text) <= 0)
                        {
                            MessageBox.Show("Solde insuffisant pour le compte");
                        }
                        else
                        {
                            var dd = 'R';
                            ligne[3] = dd;
                            dv = new DataView(ds.Tables["sld"], "Num_Compte = " +  comboBox1.Text, "", DataViewRowState.CurrentRows);
                            dv[0].BeginEdit();
                            dv[0]["Sold"] = Decimal.Parse(dv[0]["Sold"].ToString()) - Decimal.Parse(textBox2.Text) + "";
                            dv[0].EndEdit();
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.SelectedIndex = 0;
                            MessageBox.Show("Ajout Effectué");
                        }
                    }

                    ligne[4] = DateTime.Now.ToString();
                    ds.Tables["mouv"].Rows.Add(ligne);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder bd = new SqlCommandBuilder(da);
                da.Update(ds,"mouv") ;
                SqlCommandBuilder bd1 = new SqlCommandBuilder(daa);
                daa.Update(ds, "sld");
              
                MessageBox.Show("sauvgarde effectue");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            daa = new SqlDataAdapter("select * from compte", c);
            daa.Fill(ds, "sld");
           
            for (int i = 0; i < ds.Tables["sld"].Rows.Count; i++)
            {
                if (ds.Tables["sld"].Rows[i].ItemArray[0].ToString() == comboBox1.Text)
                {
                    textBox1.Text = ds.Tables["sld"].Rows[i].ItemArray[2].ToString();
                    break;
                }
            }
        }
    }
}
