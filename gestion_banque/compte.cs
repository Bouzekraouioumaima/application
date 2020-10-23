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
    public partial class compte : Form
    {
        public compte()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=desktop-35blbr5\sqlexpress;Initial Catalog=banque;Integrated Security=True");
        DataSet st = new DataSet();
        int position;
        public void naviger()
        {
            textBox1.Text = st.Tables["compte"].Rows.Count.ToString();
            textBox2.Text = st.Tables["compte"].Rows[position][0].ToString();
            textBox3.Text = st.Tables["compte"].Rows[position][1].ToString();
            textBox4.Text = st.Tables["compte"].Rows[position][2].ToString();
            textBox5.Text = st.Tables["compte"].Rows[position][3].ToString();
            textBox6.Text = st.Tables["compte"].Rows[position][4].ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            position = 0;
            naviger();
        }

        private void compte_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select  Num_Compte ,Nom_Client,Prenom_Client,Sold,typeC from compte c join client cl on c.Num_Client = cl.Num_Client ", cn);
            st.Clear();
            ad.Fill(st, "compte");
            naviger();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            position = position + 1;
            naviger();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            position = position - 1;
            naviger();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            position = st.Tables["compte"].Rows.Count - 1;
            naviger();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
