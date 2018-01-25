using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace EgbinInstrumentInfoApp
{
    public partial class Login : Form

    {
        String password;
        String staffId;

        Form AboutPage;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
            StaffIdPanel.Left = (this.Width - StaffIdPanel.Width) / 2;
            LoginBtn.Left = (this.Width - LoginBtn.Width) / 2;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void PasswordLbl_Click(object sender, EventArgs e)
        {

        }

        private void Login_Resize(object sender, EventArgs e)
        {
            StaffIdPanel.Left = (this.Width - StaffIdPanel.Width) / 2;
            LoginBtn.Left = (this.Width - LoginBtn.Width) / 2;

        }

        public void checkStaffAccessLevel(int accessLevel)
        {
            if (accessLevel==1)
            {
                //MessageBox.Show("You are an Administrator");
                LoginPrompter askPassword = new LoginPrompter(this,password,staffId);
                askPassword.ShowDialog();
            }
            else if (accessLevel==2)
            {
                //MessageBox.Show("You are a Recorder");
                LoginPrompter askPassword = new LoginPrompter(this, password, staffId);
                askPassword.ShowDialog();
            }
            else if (accessLevel==3)
            {
                //MessageBox.Show("You are a Normal Staff");
                DatabaseConnector connection = new DatabaseConnector("localhost", "root", "Keepdfaith7!", "instrumentinformation");
                connection.connect();
                List<String[]> searchResult = connection.select("select * from staff_details where staff_id='" + staffId + "'");
                Categories categories = new Categories(searchResult.ElementAt(0));
                this.Hide();
                categories.Show();
                
            }
            else
            {
                MessageBox.Show("Incorrect Staff ID");
            }
        }
        //MainMenu Main = new MainMenu();

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            //LoginPrompter passwordPrompt = new LoginPrompter(this);
            DatabaseConnector connection = new DatabaseConnector("localhost", "root", "Keepdfaith7!", "instrumentinformation");
            connection.connect();

            List<String[]> searchResult = connection.select("select * from staff_details where staff_id='" + new Regex("[^a-zA-Z0-9 -]").Replace(StaffIdTextBox.Text,"")+"'");//handling non alphanumerics Regex
            //remember to put single quote for type varchar i.e. ('')
            //MessageBox.Show(searchResult.ElementAt(0).Length.ToString());
            
            if (searchResult.Count == 0)
            {
                checkStaffAccessLevel(0);
            }
            else if (searchResult.Count==1)
            {
                password = searchResult.ElementAt(0)[7];
                staffId = searchResult.ElementAt(0)[3];
                checkStaffAccessLevel(Int32.Parse(searchResult.ElementAt(0)[4]));
                
            }
            //passwordPrompt.ShowDialog();
            //this.Close();
            //Main.Show();
            //Main.ShowDialog(this);
            //this.Close();
            
            
        }
      
        private void InfoIcon_Click(object sender, EventArgs e)
        {
            AboutPage = new Form()
            {
                Width = 400,
                Height = 355,
                MaximizeBox = false,
                StartPosition = FormStartPosition.CenterParent,
                Icon = EgbinInstrumentInfoApp.Properties.Resources.about,
                BackColor = Color.White

            };

            Label AboutLabel = new Label()
            {
                Text = "ABOUT",
                Font = new Font("Cambria", 20F, FontStyle.Bold),
                AutoSize = true,
                //Left=5

                Left = (AboutPage.Width / 2) - 60

                //Anchor = AnchorStyles.Top|AnchorStyles.None,
            };

            Label AboutInfoLabel = new Label()
            {
                Font = new Font("Calibri", 12F, FontStyle.Regular),
                Text = "The Instrument Information app is a platform that provides you with basic information and maintenance records of the various equipment in Egbin Power Plc.\nWith Instrument Information you are able to see all the jobs done on an equipment with detailed explanation of what was done and how it was carried out.\nIt aims at helping to reduce downtime and makes rectifying faults faster than ever with the aid of a guide.\nIt provides you with a wealth of experience at your finger tips. \n\nThis app was designed and built by: \nRichard-Chukkas Prowess (08089000806) \nOyefeso Oluwagbemileke (08088658898)",
                Width = AboutPage.Width - 25,
                Height = AboutPage.Height - 10,
                Left = 5,
                Top = AboutLabel.Location.Y + AboutLabel.Height + 15,
                //Margin=new Padding(20,AboutPage.Height-AboutLabel.Height-5,5,5),

            };

            AboutPage.Controls.Add(AboutLabel);
            AboutPage.Controls.Add(AboutInfoLabel);
            AboutPage.ShowDialog();



        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
