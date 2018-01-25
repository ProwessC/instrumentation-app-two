using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace EgbinInstrumentInfoApp
{
    class Prompter
    {
        Categories c;
        public Prompter(Categories c)
        {
            this.c = c;
        }
        Form f;
        TextBox tb;
        public void ShowDialog()
        {
            f = new Form()
            {
                Width = 400,
                Height = 120,
                MaximizeBox = false,
               
                StartPosition = FormStartPosition.CenterParent
            };
            FlowLayoutPanel fp = new FlowLayoutPanel();
            fp.Width = f.Width;
            Label lb = new Label();
            lb.Text = "Kindly confirm your admin password:";
            lb.Location = new Point(2, 2);
            lb.TextAlign = ContentAlignment.MiddleLeft;
            lb.Height = 28;
            lb.AutoSize = false;
            lb.Width = (int)(0.9*f.Width);
            lb.Font = new Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tb = new TextBox();
            tb.Width = fp.Width - 100;
            tb.Font = new Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tb.PasswordChar = '*';
            tb.TextAlign = HorizontalAlignment.Left;
            Button okay = new Button();
            okay.Text = "Confirm";
            okay.Height = tb.Height;
            okay.Width = 70;
            okay.Click += new EventHandler(clickHandler);
            f.Controls.Add(lb);
            fp.Controls.Add(tb);
            fp.Controls.Add(okay);
            fp.Location = new Point(2,2+lb.Height+2);
            f.Controls.Add(fp);
            f.ShowDialog();
        }
        public void clickHandler(object sender, EventArgs e)
        {
            DatabaseConnector connection = new DatabaseConnector("localhost", "root", "Keepdfaith7!", "instrumentinformation");
            connection.connect();
            string hashedAdminPass = Utility.GetMD5Hash(tb.Text.ToString());
            List<String[]> searchResult = connection.select("select * from staff_details where password='" +hashedAdminPass + "'");//handling non alphanumerics Regex
            if (searchResult.Count == 0)
            {
                MessageBox.Show("Incorrect Password");
                //if the password does not exist in the database
            }
            else 
            {
                for (int i = 0; i < searchResult.Count; i++)//for as many staff with that password in the database
                {
                    
                    if (int.Parse(searchResult.ElementAt(i)[4])==1)//if the access level of the staff is administrator(1)
                    {
                        //MessageBox.Show("Correct!");
                        f.Dispose();
                        c.confirm2();
                    }

                    else
                    {
                        //no matter who you are if you are not an admin, you cannot add department
                        MessageBox.Show("You do not have access to this feature");
                    }
                }
               
            }
            connection.disconnect();    
        }
    }
    
}
