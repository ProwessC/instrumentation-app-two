using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Security.Cryptography;


namespace EgbinInstrumentInfoApp
{
    class Prompter2
    {
        PictureBox pic;
        TextBox tb;
        TextBox tb2;
        RichTextBox briefDescription;
        Categories c;
        Form f;
        string deptName,deptImage;
        Button done;


        DialogResult result;
        OpenFileDialog op;
        DatabaseConnector connection;

        public Prompter2(Categories c)
        {
            this.c = c;
        }
        public void ShowDialog()
        {
            f = new Form()
            {
                Width = 400,
                Height = 420,
                MaximizeBox = false,
                // BackColor = Color.Azure,
                BackColor = Color.Beige,
                Icon=EgbinInstrumentInfoApp.Properties.Resources.addredpicicon,
                Text="Add New Department",
                //StartPosition = FormStartPosition.CenterParent
                StartPosition=FormStartPosition.CenterScreen

            };
            
            Label lb = new Label();
            lb.Text = "Enter Department Name:";
            lb.Location = new Point(2, 2);
            lb.TextAlign = ContentAlignment.MiddleLeft;
            lb.Height = 28;
            lb.AutoSize = false;
            lb.Width = (int)(0.9 * f.Width);
            lb.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            FlowLayoutPanel fp = new FlowLayoutPanel();
            fp.Width = f.Width;
            fp.Height = f.Height - 200;
            fp.Location = new Point(2, 4);

            tb = new TextBox();
            tb.Width = fp.Width - 50;
            tb.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tb.TextAlign = HorizontalAlignment.Left;

            Label descriptionLabel = new Label()
            {
                Text = "Enter a brief description of the department:",
                Location = new Point(2, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 28,
                AutoSize = false,
                Width = (int)(0.9 * f.Width),
                Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular)


            };

            briefDescription = new RichTextBox()
            {
                Width = fp.Width - 50,
                Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular),
                //TextAlign = HorizontalAlignment.
                WordWrap = true,
                ZoomFactor=1,
                ScrollBars=RichTextBoxScrollBars.Both,
                DetectUrls=true,
                Multiline=true,
                AcceptsTab=false,
                TabStop=true


            };
            Label lb2 = new Label();
            lb2.Text = "Department Icon:";
            lb2.Location = new Point(2, 50);
            lb2.TextAlign = ContentAlignment.MiddleLeft;
            lb2.Height = 28;
            lb2.AutoSize = false;
            lb2.Width = (int)(0.9 * f.Width);
            lb2.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Panel p = new Panel();
            p.Width = fp.Width;
            tb2 = new TextBox();
            tb2.Width = fp.Width - 90;
            tb2.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tb2.TextAlign = HorizontalAlignment.Left;
            
            Button selectButton = new Button();
            selectButton.Text = "Select";
            selectButton.Width = 65;
            selectButton.Height = tb2.Height+2;
            selectButton.UseVisualStyleBackColor = true;
            selectButton.AutoSize = true;
            selectButton.Click += new EventHandler(showChooser);
            selectButton.Location = new Point(tb2.Location.X+tb2.Width,tb2.Location.Y-1);
            f.Controls.Add(lb);
            fp.Controls.Add(tb);
            fp.Controls.Add(descriptionLabel);
            fp.Controls.Add(briefDescription);
            fp.Controls.Add(lb2);
            p.Controls.Add(tb2);
            p.Controls.Add(selectButton);
            fp.Controls.Add(p);
            fp.Location = new Point(2, 2 + lb.Height + 2);
            pic = new PictureBox();
            pic.Width = 80;
            pic.Height = 80;
            pic.Location = new Point(fp.Location.X,fp.Location.Y+fp.Height);
            pic.BackColor = Color.MintCream;
            pic.BorderStyle = BorderStyle.FixedSingle;
            done = new Button();
            done.Text = "DONE";
            done.UseVisualStyleBackColor = true;
            done.AutoSize = true;
            done.Click += new EventHandler(doneHandler);
            done.Location = new Point(pic.Location.X,pic.Location.Y+pic.Height+5);
            f.Controls.Add(fp);
            f.Controls.Add(pic);
            f.Controls.Add(done);
            f.ShowDialog();
        }
        public void showChooser(object sender, EventArgs e)
        {
            op = new OpenFileDialog();
            op.Filter = "Image Files (*.jpeg, *.jpg, *.png, *.gif. *.bmp)|*.jpeg; *.jpg; *.png; *.gif; *.bmp";
            //DialogResult result = op.ShowDialog();
            result = op.ShowDialog();
            tb2.Text = op.FileName;
            pic.Image = Image.FromFile(op.FileName);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            Button bb = (Button)sender;
            //bb.BackColor = Color.Red;
        }
        public void doneHandler(object sender, EventArgs e)
        {
            if (result == DialogResult.OK)
            {
                //insert into database
                connection = new DatabaseConnector("localhost", "root", "Keepdfaith7!", "instrumentinformation");
                string UniqueIdHash = c.GetHashedPassword(tb.Text + tb2.Text);
                //MessageBox.Show(UniqueIdHash);

                connection.connect();
                int tableSize = connection.ReturnTableSize("departments");
                connection.insert("INSERT INTO departments (unique_id,department_name,index_number,brief_description) VALUES('" + UniqueIdHash + "', '" + tb.Text + "','" + (tableSize+1) + "', '" + briefDescription.Text + "')");
                
                connection.insertImage(tb2.Text,UniqueIdHash);
                MessageBox.Show("New Department Added!");

                deptName = tb.Text;
                deptImage = tb2.Text;
                //c.addDepartment(deptName, deptImage);
                c.emptyDepartmentsFlow();
                c.GetDeparmentsFromDatabase();
                f.Dispose();

                connection.disconnect();
            }
            //deptName = tb.Text;
            //deptImage = tb2.Text;
            //c.addDepartment(deptName, deptImage);
            //f.Dispose();

            //to upload the data int the departments database table
            //connection = new DatabaseConnector("localhost", "root", "Keepdfaith7!", "instrumentinformation");
            // connection.connect();
            // if (result==DialogResult.OK)
            // {
            //     MySqlCommand cmd = new MySqlCommand("insert into departments(id,url,image) values(@id, @url," + "@photo" + ")", conn);
            //     MemoryStream ms = new MemoryStream();
            //     //tb2.Text = op.FileName; has been assigned in the showChooser method so I don't know if it is necessary
            // }



        }
    }
    
}
