using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace gestion_banque
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            desing();
        }
        private void desing()
        {
            flowLayoutPanel_client.Visible = false;
            flowLayoutPanel_compte.Visible = false;
            flowLayoutPanel_mouvement.Visible = false;
            flowLayoutPanel_virement.Visible = false;
        }
        private void hidepanel()
        {
            if (flowLayoutPanel_client.Visible == true)
                flowLayoutPanel_client.Visible = false;
            if (flowLayoutPanel_compte.Visible == true)
                flowLayoutPanel_compte.Visible =false;
            if (flowLayoutPanel_mouvement.Visible == true)
                flowLayoutPanel_mouvement.Visible = false;
            if (flowLayoutPanel_virement.Visible == true)
                flowLayoutPanel_virement.Visible = false;
        }
        private Form activeForm = null;
        private void openChildForm(Form childform)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childform;
                childform.TopLevel = false;
                childform.FormBorderStyle = FormBorderStyle.None;
                childform.Dock = DockStyle.Fill;
                panel2.Controls.Add(childform);
                panel2.Tag = childform;
                childform.BringToFront();
                childform.Show();

                
            
        }
        private void showpanel(Panel menu)
        {
         if(menu.Visible==false)
            {
                hidepanel();
                menu.Visible = true;
            }
            else
            {
                menu.Visible = false;
            }
        }
     

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void client_Click(object sender, EventArgs e)
        {
            showpanel(flowLayoutPanel_client);
        }

        private void compte_Click(object sender, EventArgs e)
        {
            showpanel(flowLayoutPanel_compte);
        }

        private void mouvement_Click(object sender, EventArgs e)
        {
            showpanel(flowLayoutPanel_mouvement);
        }

        private void virement_Click(object sender, EventArgs e)
        {
            showpanel(flowLayoutPanel_compte);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Ajouter_compte());
            hidepanel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new compte());
            hidepanel();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Modification_compte());
            hidepanel();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Supprimer_compte());
            hidepanel();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            openChildForm(new Ajouter_mouvement());
            hidepanel();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            openChildForm(new supprimer_mouvement());
            hidepanel();
        }

        private void flowLayoutPanel_client_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel_virement_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            openChildForm(new recherche_client());
        hidepanel();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            openChildForm(new ajouter_client());
            hidepanel();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            openChildForm(new modifier_client());
            hidepanel();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            openChildForm(new supprimer_client());
            hidepanel();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            openChildForm(new ajouter_virement());
            hidepanel();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            openChildForm(new supprimer_virement());
            hidepanel();
        }

        private void mouvement_Click_1(object sender, EventArgs e)
        {
            showpanel(flowLayoutPanel_mouvement);
        }

        private void virm_Click(object sender, EventArgs e)
        {
            showpanel(flowLayoutPanel_virement);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
