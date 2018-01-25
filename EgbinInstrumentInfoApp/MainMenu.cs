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
    public partial class MainMenu : Form
    {
        
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Resize(object sender, EventArgs e)
        {
            //HeaderPanel.Height = this.Height - 540;
            HeaderPanel.Width = (int)(this.Width - 40);
            BodyPanel.Width = HeaderPanel.Width;
            //BodyPanel.Height = this.Height - HeaderPanel.Height;
        }

        private void NewBtn2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
