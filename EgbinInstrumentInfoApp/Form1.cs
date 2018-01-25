using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EgbinInstrumentInfoApp
{
    public partial class Login : Form

    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void PasswordLbl_Click(object sender, EventArgs e)
        {

        }

        private void Login_Resize(object sender, EventArgs e)
        {
            
           
        }
        MainMenu Main = new MainMenu();

        private void LoginBtn_Click(object sender, EventArgs e)
        {

            //this.Close();
            //Main.Show();
            Main.ShowDialog(this);
            //this.Close();
            
            
        }
    }
}
