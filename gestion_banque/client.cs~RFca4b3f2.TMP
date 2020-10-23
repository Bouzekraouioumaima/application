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
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=desktop-35blbr5\sqlexpress;Initial Catalog=banque;Integrated Security=True");
        DataSet st = new DataSet();
        int position;
        public void naviger()
        {
            textBox1.Text = st.Tables["client"].Rows.Count.ToString();
            textBox2.Text = st.Tables["client"].Rows[position][0].ToString();
            textBox3.Text = st.Tables["client"].Rows[position][1].ToString();
            textBox4.Text = st.Tables["client"].Rows[position][2].ToString();
             }
        private void client_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select  Num_Client ,Nom_Client,Prenom_Client from client ", cn);
            st.Clear();
            ad.Fill(st, "client");
            naviger();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            position = 0;
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
            position = st.Tables["client"].Rows.Count - 1;
            naviger();
        }
    }
}
