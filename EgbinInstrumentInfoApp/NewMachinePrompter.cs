using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Security.Cryptography;

namespace EgbinInstrumentInfoApp
{
    class NewMachinePrompter
    {
        //PictureBox pic;
        TextBox MachineNameTextbox;
        //TextBox tb2;
        ComboBox SelectUnitComboBox;
        ComboBox SelectVoltageRating;
        TextBox TagNameTextBox;
        RichTextBox MachineBriefDescription;
        Categories MainForm;
        Form NewMachineForm;
        string deptName, deptImage;
        Button done;
        //int ButtonClickedTag;
        int currentDepartmentIndex;
        

       
        DatabaseConnector connection;
        //List<string[]>

        public NewMachinePrompter(Categories MainForm, int currentDepartmentIndex)
        {
            this.MainForm = MainForm;
            this.currentDepartmentIndex = currentDepartmentIndex;
            //this.ButtonClickedTag = ButtonClickedTag;
        }
        public void ShowDialog()
        {
            NewMachineForm = new Form()
            {
                Width = 400,
                Height = 450,
                MaximizeBox = false,
                // BackColor = Color.Azure,
                BackColor = Color.Beige,

                Icon = EgbinInstrumentInfoApp.Properties.Resources.addredpicicon,
                Text = "Add New Machine",
                StartPosition = FormStartPosition.CenterParent
            };

            Label lb = new Label();
            lb.Text = "Enter Machine Name:";
            lb.Location = new Point(2, 2);
            lb.TextAlign = ContentAlignment.MiddleLeft;
            lb.Height = 28;
            lb.AutoSize = false;
            lb.Width = (int)(0.9 * NewMachineForm.Width);
            lb.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            FlowLayoutPanel fp = new FlowLayoutPanel();
            fp.Width = NewMachineForm.Width;
            fp.Height = NewMachineForm.Height - 110;
            //fp.Location = new Point(2, 4);
            fp.Location = new Point(2, 2 + lb.Height + 2);

            MachineNameTextbox = new TextBox();
            MachineNameTextbox.Width = fp.Width - 50;
            MachineNameTextbox.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            MachineNameTextbox.TextAlign = HorizontalAlignment.Left;
            MachineNameTextbox.Height = 28;

            Label TagNameLabel = new Label()
            {
                Text = "Enter Tag Name:",
                Location = new Point(2, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 28,
                AutoSize = false,
                Width = (int)(0.9 * NewMachineForm.Width),
                Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular)
            };
            TagNameTextBox = new TextBox()
            {
                Width = fp.Width - 50,
                Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular),
                TextAlign = HorizontalAlignment.Left,
                Height = 28
            };
            TagNameTextBox.LostFocus += TagNameTextBox_LostFocus;

            Label descriptionLabel = new Label()
            {
                Text = "Enter a brief description of the machine:",
                Location = new Point(2, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 28,
                AutoSize = false,
                Width = (int)(0.9 * NewMachineForm.Width),
                Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular)


            };

            MachineBriefDescription = new RichTextBox()
            {
                Width = fp.Width - 50,
                Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular),
                //TextAlign = HorizontalAlignment.
                WordWrap = true,
                ZoomFactor = 1,
                ScrollBars = RichTextBoxScrollBars.Both,
                DetectUrls = true,
                Multiline = true,
                AcceptsTab = false,
                TabStop = true


            };
            Label SelectUnitLabel = new Label();
            SelectUnitLabel.Text = "Select Unit:";
            SelectUnitLabel.Location = new Point(2, 50);
            SelectUnitLabel.TextAlign = ContentAlignment.MiddleLeft;
            SelectUnitLabel.Height = 28;
            SelectUnitLabel.AutoSize = false;
            SelectUnitLabel.Width = (int)(0.9 * NewMachineForm.Width);
            SelectUnitLabel.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //Panel p = new Panel();
            //p.Width = fp.Width;
            SelectUnitComboBox = new ComboBox();
            SelectUnitComboBox.Width = fp.Width - 50;
            SelectUnitComboBox.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SelectUnitComboBox.Items.AddRange(new string[] { "UNIT 1", "UNIT 2", "UNIT 3", "UNIT 4", "UNIT 5", "UNIT 6", "COMMON SERVICES" });

            //SelectUnitComboBox.TextAlign = HorizontalAlignment.Left;

            //Button selectButton = new Button();

            //selectButton.Text = "Select";
            Label SelectVoltageRatingLabel = new Label()
            {
                Text = "Select Voltage Rating:",
                Location = new Point(2, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 28,
                AutoSize = false,
                Width = (int)(0.9 * NewMachineForm.Width),
                Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular)


            };

            SelectVoltageRating = new ComboBox();
            SelectVoltageRating.Width = fp.Width-50;
            SelectVoltageRating.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //SelectVoltageRating.Height = SelectUnitComboBox.Height + 2;
            //selectButton.Click += new EventHandler(showChooser);
            SelectVoltageRating.Location = new Point(SelectUnitComboBox.Location.X + SelectUnitComboBox.Width, SelectUnitComboBox.Location.Y - 1);
            SelectVoltageRating.Items.AddRange(new string[] { "16KV", "6.6KV", "415V", "240V", "110V" });

            NewMachineForm.Controls.Add(lb);
            fp.Controls.Add(MachineNameTextbox);
            fp.Controls.Add(TagNameLabel);
            fp.Controls.Add(TagNameTextBox);
            fp.Controls.Add(descriptionLabel);
            fp.Controls.Add(MachineBriefDescription);
            fp.Controls.Add(SelectUnitLabel);
            fp.Controls.Add(SelectUnitComboBox);
            fp.Controls.Add(SelectVoltageRatingLabel);
            fp.Controls.Add(SelectVoltageRating);
            //p.Controls.Add(selectButton);
            
            
            //pic = new PictureBox();
            //pic.Width = 80;
            //pic.Height = 80;
            //pic.Location = new Point(fp.Location.X, fp.Location.Y + fp.Height);
            //pic.BackColor = Color.Red;
            done = new Button();
            done.Text = "ADD";
            done.Font= new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            done.AutoSize = true;
            done.UseVisualStyleBackColor = true;
            //done.Click += new EventHandler(doneHandler);
            //done.Location = new Point(SelectVoltageRating.Location.X, SelectVoltageRating.Location.Y + SelectVoltageRating.Height + 5);
            done.Location = new Point(fp.Location.X, fp.Location.Y + fp.Height);
           
            NewMachineForm.Controls.Add(fp);
            //NewMachineForm.Controls.Add(pic);
            NewMachineForm.Controls.Add(done);
            NewMachineForm.ShowDialog();
        }

        private void TagNameTextBox_LostFocus(object sender, EventArgs e)
        {
            connection= new DatabaseConnector("localhost", "root", "Keepdfaith7!", "instrumentinformation");
            connection.connect();
            int itemcount=connection.ReturnMachineColumnCount(TagNameTextBox.Text);
            //String query = "select count(" + tableName + ") from " + database;
           
            if (itemcount==0)
            {
                done.Cursor = Cursors.Hand;
                done.Click += Done_Click;

            }

            else
            {
                MessageBox.Show("This machine already exists");
            }
            
        }

        private void Done_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MachineNameTextbox.Text+"--"+(SelectUnitComboBox.SelectedIndex+1)+(SelectVoltageRating.SelectedIndex+1));
            string UniqueIdHash = MainForm.GetHashedPassword(MachineNameTextbox.Text + (SelectUnitComboBox.SelectedIndex + 1)+TagNameTextBox.Text);
            if (MachineNameTextbox.Text.Length<=5||MachineBriefDescription.Text.Length<=5||TagNameTextBox.Text.Length<=5)
            {
                MessageBox.Show("There is an invalid text somewhere");
            }

            else
            {
                connection = new DatabaseConnector("localhost", "root", "Keepdfaith7!", "instrumentinformation");
                connection.connect();
                connection.insert("INSERT INTO machine_details (unique_id,machine_name,description,unit,voltage_rating,department,tag_name) VALUES('" + UniqueIdHash + "', '" + MachineNameTextbox.Text + "','" + MachineBriefDescription.Text + "', '" + (SelectUnitComboBox.SelectedIndex+1) + "', '"+(SelectVoltageRating.SelectedIndex+1)+"', '"+currentDepartmentIndex+"','"+TagNameTextBox.Text+"')");
                MessageBox.Show("Machine Added!");
                connection.disconnect();
            }
            
            
            //connection.insert()
        }

        //public void doneHandler(object sender, EventArgs e)
        //{
        //    if (result == DialogResult.OK)
        //    {
        //        //insert into database
        //        connection = new DatabaseConnector("localhost", "root", "Keepdfaith7!", "instrumentinformation");
        //        string UniqueIdHash = MainForm.GetHashedPassword(tb.Text + tb2.Text);
        //        MessageBox.Show(UniqueIdHash);

        //        connection.connect();
        //        int tableSize = connection.ReturnTableSize("departments");
        //        connection.insert("INSERT INTO departments (unique_id,department_name,index_number,brief_description) VALUES('" + UniqueIdHash + "', '" + tb.Text + "','" + (tableSize + 1) + "', '" + briefDescription.Text + "')");

        //        connection.insertImage(tb2.Text, UniqueIdHash);


        //        deptName = tb.Text;
        //        deptImage = tb2.Text;
        //        //c.addDepartment(deptName, deptImage);
        //        MainForm.emptyDepartmentsFlow();
        //        MainForm.GetDeparmentsFromDatabase();
        //        f.Dispose();

        //        connection.disconnect();
        //    }
        //    //deptName = tb.Text;
        //    //deptImage = tb2.Text;
        //    //c.addDepartment(deptName, deptImage);
        //    //f.Dispose();

        //    //to upload the data int the departments database table
        //    //connection = new DatabaseConnector("localhost", "root", "Keepdfaith7!", "instrumentinformation");
        //    // connection.connect();
        //    // if (result==DialogResult.OK)
        //    // {
        //    //     MySqlCommand cmd = new MySqlCommand("insert into departments(id,url,image) values(@id, @url," + "@photo" + ")", conn);
        //    //     MemoryStream ms = new MemoryStream();
        //    //     //tb2.Text = op.FileName; has been assigned in the showChooser method so I don't know if it is necessary
        //    // }



        //}

    }
}
