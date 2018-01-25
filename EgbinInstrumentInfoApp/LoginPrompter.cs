using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EgbinInstrumentInfoApp
{
    class LoginPrompter
    {
        Login c;
        DatabaseConnector connection;
        String password, staffId;
        TextBox tb;
        public LoginPrompter(Login c, String password,String staffId)
        {
            this.c = c;
            this.password = password;
            this.staffId = staffId;
        }
        Form f;
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
            lb.Text = "Enter your password:";
            lb.Location = new Point(2, 2);
            lb.TextAlign = ContentAlignment.MiddleLeft;
            lb.Height = 28;
            lb.AutoSize = false;
            lb.Width = (int)(0.9 * f.Width);
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
            fp.Location = new Point(2, 2 + lb.Height + 2);
            f.Controls.Add(fp);
            f.ShowDialog();
        }
        public void clickHandler(object sender, EventArgs e)
        {
            int passwordCorrect = checkPassword();
            if(passwordCorrect == 1)
            {
                MessageBox.Show("Correct Password ");
                connection = new DatabaseConnector("localhost", "root", "Keepdfaith7!", "instrumentinformation");
                connection.connect();
                List<String[]> searchResult = connection.select("select * from staff_details where staff_id='" + staffId + "'");//remember: varchar('')
                Categories categories = new Categories(searchResult.ElementAt(0));
                f.Dispose();
                c.Hide();
                categories.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
           //f.Dispose();
            
        }
        public int checkPassword()
        {
            return (password.Equals(Utility.GetMD5Hash(tb.Text)) ? 1 : 0);
            //condition ? first_expression : second_expression; 
            //The condition must evaluate to true or false. 
            //If condition is true, first_expression is evaluated and becomes the result. 
            //If condition is false, second_expression is evaluated and becomes the result. 
            //Only one of the two expressions is evaluated.
        }
    }

}
