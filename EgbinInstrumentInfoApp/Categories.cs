using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.IO;


namespace EgbinInstrumentInfoApp
{
    public partial class Categories : Form
    {
        DatabaseConnector connector;
        int departmentChosen = 0;
        int scrollRecords = 0;
        Panel MachinesPanel;
        Panel DepartmentInformationPanel;
        Panel DepartmentHeaderPanel;
        PictureBox DefaultDepartmentPictureBox;
        Label DefaultDepartmentLabel;
        Label DepartmentDescriptionHeaderLabel;
        Label DepartmentDescritptionLabel;
        Button EditButton;
        Button EditMachineButton;
        List<Label> recordRows = new List<Label>();
        List<Label> recordRows2 = new List<Label>();
        List<Label> recordRows3 = new List<Label>();
        List<PictureBox> recordRows4 = new List<PictureBox>();
        List<PictureBox> recordRows5 = new List<PictureBox>();
        List<Panel> recordRowFull = new List<Panel>();
        //Panel parentPanel;
        Panel SelectMachinePanel;
        Panel MachineInfoPanel;
        Label SelectUnitLabel;
        Label SelectVoltageLabel;
        ComboBox SelectUnitComboBox;
        ComboBox SelectVoltageComboBox;
        Button FindEquipmentButton;
        ListBox EquipmentListBox;
        Button AddNewMachineButton;
        Label MachineNameLabel;
        Label MachineDescriptionLabel;
        Label MaintenanceRecordsLabel;
        Label SNLabel;
        Label JobDescriptionLabel;
        Label DateStartedLabel;
        Label DateFinishedLabel;
        Button AddNewRecordButton;
        TextBox SearchTextBox;
        Button SearchButton;
        FlowLayoutPanel MaintenanceRecordFlowPanel;
        
        //the objects for my various dialog forms
        Form AboutPage;
        Form AddNewStaffForm;
        int numberOfRecords = 10;
        enum AccessLevel {Administrator=1, Recorder=2, Staff=3}
        ComboBox accesslevelDropdown;
        FlowLayoutPanel fp;
        Label AccessLevelLabel;
        Label SetDefaultPasswordLabel;
        Label StaffPasswordLabel;
        Button AddStaffButton;
        Label SurnameLabel;
        TextBox SurnameTextBox;
        Label FirstNameLabel;
        TextBox FirstNameTextBox;
        Label PhoneNumberLabel;
        TextBox PhoneNumberTextBox;
        Label DepartmentLabel;
        TextBox DepartmentTextBox;
        Label StaffIdLabel;
        TextBox StaffIdTextBox;

        string StaffPasswordHash;
        string UniqueIdHash;

        String[] staffDetails;

        string selectedUniqueId;


        //int tableSize = 0; //used when tryin to call departments in database
        //int currentIndex = 0;
        public Button b; //department button clicked
        int departmentButtonIndex;
        List<String[]> SelectDepartmentDetails;
        List<byte[]> SelectDepartmentImage;
        //MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection("server=127.0.0.1;uid=root;pwd=Keepdfaith7!;database=prowess;");
        List<string[]> SelectMachineDetails;
        List<string> MachineUniqueIdList;

        public Categories(String [] details)//I am passing the whole staff details as an array
        {
            InitializeComponent();
            MenuPnl.BringToFront();
            connector = new DatabaseConnector("localhost", "root", "Keepdfaith7!", "instrumentinformation");
            
            staffDetails = details;
            //addDepartment("BOILER", EgbinInstrumentInfoApp.Properties.Resources.boiler);
            //addDepartment("ELECTRICAL", EgbinInstrumentInfoApp.Properties.Resources.electrical);
            //addDepartment("I AND C", EgbinInstrumentInfoApp.Properties.Resources.ic);
            //addDepartment("TURBINE", EgbinInstrumentInfoApp.Properties.Resources.turbine);
            //addDepartment("WORKSHOP", EgbinInstrumentInfoApp.Properties.Resources.workshop);
            GetDeparmentsFromDatabase();
            

            FullnameLbl.Text = staffDetails[1].ToUpper() + " " + staffDetails[2].ToUpper();
            // AddNewStaff();
            ShowStaffView();
            
            //FullnameLbl.Location = (int(HeaderPnl.Width-FullnameLbl.Width), ProfilePic.Location.Y);
            //FullnameLbl.Anchor = AnchorStyles.Right;
            //connector.connect();
            //List<String[]> newResult = connector.select("select age, name from workers");
            //for (int i = 0; i < newResult.Count; i++)
            //{
            //    addDepartment(newResult.ElementAt(i)[0] + "--" + newResult.ElementAt(i)[1],
            //        "c:\\Users\\Prowess\\Documents\\Visual Studio 2015\\Projects\\EgbinInstrumentInfoApp\\EgbinInstrumentInfoApp\\Resources\\boiler.png");
            //}
        }

        private void AddDepartmentInformationPanel(Image departmentImage, String departmentName, string briefDescription)
        {
            
            DepartmentInformationPanel = new Panel()
            {
                BackColor = System.Drawing.SystemColors.MenuBar,
                //BackColor=SystemColors.InactiveCaption,
                Location = new System.Drawing.Point(297, 80),
                Padding = new System.Windows.Forms.Padding(10),
                Size = WelcomePagePanel.Size,
                TabIndex = 4
            };
            DepartmentHeaderPanel = new Panel()
            {
                BackColor = System.Drawing.SystemColors.Menu,
                //BackColor=SystemColors.InactiveCaption,
                Location = new System.Drawing.Point(0, 0),
                
                Size = new System.Drawing.Size(WelcomePagePanel.Width, 48),
                TabIndex = 0
            };
            DefaultDepartmentPictureBox = new PictureBox()
            {
                Anchor = System.Windows.Forms.AnchorStyles.None,
                Image = departmentImage,
                Location = new System.Drawing.Point(283, 3),
                Size = new System.Drawing.Size(55, 42),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
                TabIndex = 6,
                TabStop = false
            };
            DepartmentDescriptionHeaderLabel = new Label()
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline),
                ForeColor = System.Drawing.SystemColors.ControlText,
                Location = new System.Drawing.Point(0, 72),
                Size = new System.Drawing.Size(209, 25),
                TabIndex = 1,
                Text = "Descriptive Information",
            };
            DepartmentDescritptionLabel = new Label()
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular),
                Location = new System.Drawing.Point(2, 108),
                Size = new System.Drawing.Size(475, 17),
                TabIndex = 2,
                //Text = "Brief description to guide first time users or just for the sake of being there",
                Text=briefDescription
            };
            DefaultDepartmentLabel = new Label()
            {
                Anchor = System.Windows.Forms.AnchorStyles.None,
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular), 
                ForeColor = System.Drawing.SystemColors.ControlText,
                Location = new System.Drawing.Point(341, 9),
                Size = new System.Drawing.Size(167, 29),
                TabIndex = 0,
                Text = departmentName
            };
            EditButton = new Button()
            {
                Location = new System.Drawing.Point(DepartmentInformationPanel.Width-90, 9),
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 7,
                Text = "EDIT"
            };
            if (int.Parse (staffDetails[4])==1)
            {
                EditButton.Visible = true;
            }
            else
            {
                EditButton.Visible = false;
            }
            DepartmentHeaderPanel.Controls.Add(DefaultDepartmentPictureBox);
            DepartmentHeaderPanel.Controls.Add(DefaultDepartmentLabel);
            DepartmentHeaderPanel.Controls.Add(EditButton);
            DepartmentInformationPanel.Controls.Add(DepartmentHeaderPanel);
            DepartmentInformationPanel.Controls.Add(DepartmentDescriptionHeaderLabel);
            DepartmentInformationPanel.Controls.Add(DepartmentDescritptionLabel);
            //DepartmentInformationPanel.BringToFront();
            
            AddMachinesPanel();
            this.Controls.Add(DepartmentInformationPanel);
        }

        private void AddMachinesPanel()
        {
            MachinesPanel = new Panel()
            {
                BackColor = Color.DimGray,
                Height = (int)(this.Height - 290),
                Width = WelcomePagePanel.Width - 20,
                Top = 150,
                Left = 10,
                //Margin = new Padding() { All = (int)(0.01 * MachineInfoPanel.Width)}
                //Padding Margin
                //Padding = new Padding() { All = 10, /*Top=10, Bottom=10, Left=10, Right=10*/}
            };
            
            AddSelectMachinePanel(MachinesPanel);
            AddMachineInfoPanel(MachinesPanel);
            DepartmentInformationPanel.Controls.Add(MachinesPanel);
            MachinesPanel.BringToFront();

        }

        private void AddSelectMachinePanel(Panel parentPanel)
        {
            SelectMachinePanel = new Panel()
            {
                BackColor = SystemColors.MenuBar,
                Height = (int)(parentPanel.Height - 8),
                Width = (int)(250),
                Left = (int)(0.005 * parentPanel.Width),
                Top = (int)(0.005 * parentPanel.Width),

                //Padding=new Padding() {All=5 }

            };

            SelectUnitLabel = new Label()
            {
                Text = "Select Unit",
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular),
                ForeColor = SystemColors.ControlText,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(4, 22),
                Size = new Size(90, 20),
                TabIndex = 0

            };

            SelectUnitComboBox = new ComboBox()
            {
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular), /*System.Drawing.GraphicsUnit.Point, ((byte)(0))),*/
                FormattingEnabled = true,
                Location = new Point(95, 22),
                Size = new Size(145, 28),
                TabIndex = 2,
                Text = "--Select--"

            };
            SelectUnitComboBox.Items.AddRange(new object[] { "Unit 1", "Unit 2", "Unit 3", "Unit 4", "Unit 5", "Unit 6", "Common Equipment" });

            SelectVoltageLabel = new Label()
            {
                Location = new Point(4, 68),
                Size = new Size(100, 45),
                TabIndex = 1,
                Text = "Select Voltage\nRating",
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular),
                ForeColor = SystemColors.ControlText
            };

            SelectVoltageComboBox = new ComboBox()
            {
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular),
                FormattingEnabled = true,
                Location = new Point(105, 68),
                Size = new Size(135, 28),
                TabIndex = 3,
                Text = "--Select--",

            };
            SelectVoltageComboBox.Items.AddRange(new object[] { "16KV","6.6KV", "415V", "240V", "110V" });


            FindEquipmentButton = new Button()
            {
                Size = new Size(175, 27),
                TabIndex = 4,
                Text = "FIND",
                Location = new Point(35, 119),
                UseVisualStyleBackColor = true
            };
            FindEquipmentButton.Click += FindEquipmentButton_Click;
            EquipmentListBox = new ListBox()
            {
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular),
                FormattingEnabled = true,
                ItemHeight = 20,
                Location = new Point(7, 157),
                Size = new Size(233, (int)(SelectMachinePanel.Height - 200)),
                TabIndex = 5
                

            };
            EquipmentListBox.SelectedIndexChanged += EquipmentListBox_SelectedIndexChanged;
            AddNewMachineButton = new Button()
            {
                Size = new Size(130, 27),
                TabIndex = 4,
                Text = "New Machine",
                Location = new Point((SelectMachinePanel.Width - 130) / 2, EquipmentListBox.Location.Y + EquipmentListBox.Height),
                UseVisualStyleBackColor = true,
                Cursor = Cursors.Hand

            };
            AddNewMachineButton.Click += AddNewMachineButton_Click;
            if (int.Parse(staffDetails[4])==1)
            {
                AddNewMachineButton.Visible = true;
            }
            else
            {
                AddNewMachineButton.Visible = false;
            }
            //SelectUnitComboBox.SelectedIndexChanged += SelectUnitComboBox_SelectedIndexChanged;
            //SelectUnitComboBox.SelectedIndexChanged+=  
            //this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            //this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            //this.button4.Click += new System.EventHandler(this.button4_Click)};
            //this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);


            SelectMachinePanel.Controls.Add(SelectUnitLabel);
            SelectMachinePanel.Controls.Add(SelectUnitComboBox);
            SelectMachinePanel.Controls.Add(SelectVoltageLabel);
            SelectMachinePanel.Controls.Add(SelectVoltageComboBox);
            SelectMachinePanel.Controls.Add(FindEquipmentButton);
            SelectMachinePanel.Controls.Add(EquipmentListBox);
            SelectMachinePanel.Controls.Add(AddNewMachineButton);
            //SelectMachinePanel.Controls.AddRange(Control[]controls = new Control { SelectUnitLabel, });

            parentPanel.Controls.Add(SelectMachinePanel);
            SelectMachinePanel.BringToFront();

            
        }

        private void EquipmentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //to get the id of the machine selected
            int machineSelected = EquipmentListBox.SelectedIndex;
            selectedUniqueId = MachineUniqueIdList.ElementAt(machineSelected);

            connector.connect();
            List<string[]> machineSelectedDetails = new List<string[]>();
                machineSelectedDetails = connector.select("select machine_name,description from machine_details where unique_id='" + selectedUniqueId + "'");
            foreach (string[] item in machineSelectedDetails)
            {
                MachineNameLabel.Text = item[0];
                MachineDescriptionLabel.AutoEllipsis = true;
                MachineDescriptionLabel.Text = item[1];
            }
        }

        private void FindEquipmentButton_Click(object sender, EventArgs e)
        {
            connector.connect();
            //SelectDepartmentDetails = connector.select("select unique_id,machine_name,description from departments order by department_name asc");
            SelectMachineDetails = new List<string[]>();
            SelectMachineDetails = connector.select("select * from machine_details where unit='" + (SelectUnitComboBox.SelectedIndex + 1) + "' and voltage_rating='" + (SelectVoltageComboBox.SelectedIndex + 1) + "' order by machine_name asc");

            if (EquipmentListBox != null)
            {
                EquipmentListBox.Items.Clear();
                //MessageBox.Show(SelectMachineDetails.ElementAt(0)[1]);
                foreach (string[] item in SelectMachineDetails)
                {

                    MachineUniqueIdList = new List<string>();
                    MachineUniqueIdList.Add(item[0]);
                    EquipmentListBox.Items.Add(item[1]);     
                }
            }
            else
            {
                foreach (string[] item in SelectMachineDetails)
                {

                    MachineUniqueIdList = new List<string>();
                    MachineUniqueIdList.Add(item[0]);
                    EquipmentListBox.Items.Add(item[1]);
                }
            }


            if (SelectMachineDetails.Count==0)
            {
                MessageBox.Show("There are no machines added in this category");
            }

            connector.disconnect();
  
        }

        private void AddNewMachineButton_Click(object sender, EventArgs e)
        {
            //to add a new machine: called when the addnewmachine button is clicked
            new NewMachinePrompter(this,departmentButtonIndex).ShowDialog();
            //calls the class to save a new machine to the database
            //two arguments: the form it is called in, index of the department that is presently open 
        }

        //private void SelectUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void AddMachineInfoPanel(Panel parentPanel)
        {
            MachineInfoPanel = new Panel()
            {
                BackColor = SystemColors.MenuBar,
                Height = (int)(parentPanel.Height - 8),
                Width = (int)(MachinesPanel.Width - SelectMachinePanel.Width-15),
                Left = (int)(SelectMachinePanel.Width+10),
                Top = (int)(0.005 * parentPanel.Width),
                
            //Padding=new Padding() {All=5 }
            AutoScroll = true
            };

            MachineNameLabel = new Label()
            {

                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 15.75F, /*FontStyle.Regular*/ System.Drawing.FontStyle.Underline),
                ForeColor = SystemColors.ControlText,
                Location = new Point(12, 22),
                Size = new Size(156, 25),
                TabIndex = 8,
                Text = "Machine Name",
                Anchor = AnchorStyles.Top | AnchorStyles.Left

            };


            MachineDescriptionLabel = new Label()
            {

                Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular),
                Location = new Point(16, 55),
                //Size = new Size(600, 56),
                AutoSize = true,
                TabIndex = 9,
                Text = "Brief description and information about the selected machine"
            };
            EditMachineButton = new Button()
            {
                Location = new System.Drawing.Point(MachineInfoPanel.Width - 90, 9),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 7,
                Text = "EDIT",
                UseVisualStyleBackColor = true,
                //Cursor = Cursors.Hand

            };
            if (int.Parse(staffDetails[4]) == 1)
            {
                EditMachineButton.Visible = true;
            }
            else
            {
                EditMachineButton.Visible = false;
            }
            
            EditMachineButton.Click += EditMachineButton_Click;
            MaintenanceRecordsLabel = new Label()
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular),
                Location = new Point(20, 100),
                Left = 20,
                Size = new Size(165, 25),
                TabIndex = 7,
                Text = "Maintenance Records"
            };

            SearchTextBox = new TextBox()
            {
                Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular),
                Location = new Point(MaintenanceRecordsLabel.Location.X + MaintenanceRecordsLabel.Width, 100),
                //Size = new Size(400, 24),
                Width = MachineInfoPanel.Width - MaintenanceRecordsLabel.Width-MaintenanceRecordsLabel.Location.X-100,
                Height=19,
                TabIndex = 2,
            };

            SearchButton = new Button()
            {
                Location = new Point(SearchTextBox.Location.X + SearchTextBox.Width, SearchTextBox.Location.Y),
                //Size = new Size(75, 24),
                Width = 75,
                Visible = false,
                Height = SearchTextBox.Height,
                TabIndex = 3,
                Text = "SEARCH",
                UseVisualStyleBackColor = true,
                //this.button3.Click += new System.EventHandler(this.button3_Click);
            };
            SNLabel = new Label()
            {
                BackColor = Color.LightGray,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular),
                Location = new Point(22, 130),
                Left = 22,
                Size = new Size(32, 28),
                TabIndex = 4,
                Text = "S/N",
                TextAlign = ContentAlignment.MiddleLeft
            };
            JobDescriptionLabel = new Label()
            {
                BackColor = Color.DarkGray,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular),
                //Location = new Point(102, 344),
                Location = new Point (SNLabel.Location.X+SNLabel.Width,SNLabel.Location.Y),
                //Size = new Size(300, 28),
                Width= DepartmentHeaderPanel.Width -420 - (32 + 65 + 70 + 128),
                Height =28,
                TabIndex = 5,
                Text = "JOB DESCRIPTION",
                TextAlign = ContentAlignment.MiddleLeft
            };

            DateStartedLabel = new Label()
            {
                BackColor = Color.LightGray,
                Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular),
                Location = new Point(SNLabel.Location.X + SNLabel.Width + JobDescriptionLabel.Width, SNLabel.Location.Y),
                Size = new Size(65, 28),
                TabIndex = 6,
                Text = "Date Started",
                TextAlign = ContentAlignment.TopLeft,
                AutoEllipsis = true
                
            };

            DateFinishedLabel = new Label()
            {
                BackColor = Color.LightGray,
                Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular),
                Location = new Point(SNLabel.Location.X + SNLabel.Width + JobDescriptionLabel.Width+DateStartedLabel.Width, SNLabel.Location.Y),
                Size = new Size(70, 28),
                TabIndex = 6,
                Text = "Date Finished",
                TextAlign = ContentAlignment.TopLeft,
                AutoEllipsis=true
                
            };
            AddNewRecordButton = new Button()
            {
                Text = "New Record",
                Width = 75,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular),
                Height = SNLabel.Height,
                Location = new Point(MachineInfoPanel.Width - 13 - 75, DateFinishedLabel.Location.Y),
                UseVisualStyleBackColor = true
            };
            if (int.Parse(staffDetails[4])==1||int.Parse(staffDetails[4])==2)
            {
                AddNewRecordButton.Visible = true;
            }
            else
            {
                AddNewRecordButton.Visible = false;
            }
            AddNewRecordButton.Click += AddNewRecordButton_Click; //when the new record button is clicked

            MaintenanceRecordFlowPanel = new FlowLayoutPanel()
            {
                BackColor = Color.DarkGray,
                Location = new Point(22, 160),
                Size = new Size(670, 167),
                Width = (int)(0.94 * MachineInfoPanel.Width),
                Height = (int)(MachineInfoPanel.Height - SNLabel.Location.Y - SNLabel.Height - 9),
                TabIndex = 10,
                AutoScroll = true
            };
            //MessageBox.Show(MachineInfoPanel.Height.ToString() + "--" + MachineNameLabel.Location.Y.ToString()+"-" + MaintenanceRecordsLabel.Location.Y.ToString());
            MachineInfoPanel.Controls.Add(MachineNameLabel);
            MachineInfoPanel.Controls.Add(MachineDescriptionLabel);
            MachineInfoPanel.Controls.Add(EditMachineButton);
            MachineInfoPanel.Controls.Add(MaintenanceRecordsLabel);
            MachineInfoPanel.Controls.Add(SearchTextBox);
            MachineInfoPanel.Controls.Add(SearchButton);
            MachineInfoPanel.Controls.Add(SNLabel);
            MachineInfoPanel.Controls.Add(JobDescriptionLabel);
            MachineInfoPanel.Controls.Add(DateStartedLabel);
            MachineInfoPanel.Controls.Add(DateFinishedLabel);
            MachineInfoPanel.Controls.Add(AddNewRecordButton);

            MachineInfoPanel.Controls.Add(MaintenanceRecordFlowPanel);
            AddMaintenanceRecord(numberOfRecords,MaintenanceRecordFlowPanel.Height/30);
            
            

            parentPanel.Controls.Add(MachineInfoPanel);
            MachineInfoPanel.BringToFront();
        }

        private void AddNewRecordButton_Click(object sender, EventArgs e)
        {
           new AddNewRecordPrompter(this).ShowDialog();
        }

        private void EditMachineButton_Click(object sender, EventArgs e)
        {
            //if (EquipmentListBox.SelectedValue==null)
            //{
            //    MessageBox.Show("Please select a machine");

            //}
            //else
            //{
                EditMachineButton.Cursor = Cursors.Hand;
                new EditMachinePrompter(this, selectedUniqueId).ShowDialog();
            //}
           
        }

        public void RefreshEquipmentListBox()
        {
            //this method is to refresh my equipment listbox when i click update
            //not in use now
            EquipmentListBox.Controls.Clear();
            MachineUniqueIdList.Clear();
        }
        private void AddMaintenanceRecord(int rowsize, int result)
        {

            for (int i = 0; i < rowsize; i++)
            {
                Panel p = new Panel();

                p.Margin = new Padding(p.Margin.Left, 1, p.Margin.Right, 0);
                if (rowsize > result)
                {
                    scrollRecords = 1;
                    p.Width = MaintenanceRecordFlowPanel.Width - 25;
                }
                else
                {
                    p.Width = MaintenanceRecordFlowPanel.Width - 7;
                    scrollRecords = 0;
                }
                
                p.Height = 30;
                p.Cursor = Cursors.Hand;
                
                if (i % 2 == 0)
                {
                    p.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    p.BackColor = Color.LightGray;
                }
                Label l1 = new Label();
                Label l2 = new Label();
                Label l3 = new Label();
                Label l4 = new Label();
                PictureBox image = new PictureBox();
                PictureBox image2 = new PictureBox();

                Button b2 = new Button();

                l1.Width = SNLabel.Width - 5;
                l1.Text = Convert.ToString(i + 1) + ".";
                l1.AutoSize = false;
                l1.Height = p.Height;
                //l1.BackColor = Color.Red;
                l1.TextAlign = ContentAlignment.MiddleLeft;

                l2.Width = JobDescriptionLabel.Width;
                l2.Text = "Random maintenance carried out by a random fellow";
                l2.AutoSize = false;
                l2.Height = p.Height;
                l2.Location = new Point(l1.Location.X + l1.Width, l1.Location.Y);
                l2.TextAlign = ContentAlignment.MiddleLeft;

                l3.Width = DateStartedLabel.Width;
                l3.Text = "dd/mm/yyyy";
                l3.AutoSize = false;
                l3.Height = p.Height;
                l3.Location = new Point(l1.Location.X + l1.Width + l2.Width, l1.Location.Y);
                l3.TextAlign = ContentAlignment.MiddleLeft;

                l4.Width = DateFinishedLabel.Width;
                l4.Text = "dd/mm/yyyy";
                l4.AutoSize = false;
                l4.Height = p.Height;
                l4.Location = new Point(l1.Location.X + l1.Width + l2.Width+l3.Width, l1.Location.Y);
                l4.TextAlign = ContentAlignment.MiddleLeft;

                //image.Image = Image.FromFile("c:\\Users\\Prowess\\Documents\\Visual Studio 2015\\Projects\\EgbinInstrumentInfoApp\\EgbinInstrumentInfoApp\\Resources\\edit2.png");
                //image.SizeMode = PictureBoxSizeMode.Zoom;
                image.Image = EgbinInstrumentInfoApp.Properties.Resources.edit2;
                image.SizeMode = PictureBoxSizeMode.Zoom;
                image.Location = new Point(l1.Location.X + l1.Width + l2.Width + l3.Width+l4.Width+15, l1.Location.Y);
                image.Width = 30;
                image.Height = 30;
                ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                ToolTip1.SetToolTip(image, "Edit Record");
                image.Cursor = Cursors.Hand;
                
                image2.Image = EgbinInstrumentInfoApp.Properties.Resources.deletepic;
                image2.SizeMode = PictureBoxSizeMode.Zoom;
                image2.Location = new Point(l1.Location.X + l1.Width + l2.Width + l3.Width + l4.Width + 15+image.Width+15, l1.Location.Y);
                image2.Width = 30;
                image2.Height = 30;
                ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
                ToolTip2.SetToolTip(image2, "Delete");
                image2.Cursor = Cursors.Hand;

                if (int.Parse(staffDetails[4])==1||int.Parse(staffDetails[4])==2)
                {
                    image.Visible = true;
                    image2.Visible = true;
                }
                else
                {
                    image.Visible = false;
                    image2.Visible = false;
                }

                l2.MouseEnter += new EventHandler((object sender, EventArgs e) => {
                    l2.ForeColor = Color.FromArgb(1,240,146,32);
                });
                l3.MouseEnter += new EventHandler((object sender, EventArgs e) => {
                    l2.ForeColor = Color.FromArgb(1, 240, 146, 32);
                });
                l4.MouseEnter += new EventHandler((object sender, EventArgs e) => {
                    l2.ForeColor = Color.FromArgb(1, 240, 146, 32);
                });
                l2.MouseLeave += new EventHandler((object sender, EventArgs e) => {
                    l2.ForeColor = Color.Black;
                });
                l3.MouseLeave += new EventHandler((object sender, EventArgs e) => {
                    l2.ForeColor = Color.Black;
                });
                l4.MouseLeave += new EventHandler((object sender, EventArgs e) => {
                    l2.ForeColor = Color.Black;
                });

                //b1.Text = "View";
                //b1.Location = new Point(l1.Location.X + l1.Width + l2.Width + l3.Width, l1.Location.Y);
                //b1.Margin = new Padding(9, 9, 0, 0);
                //b2.Text = "Edit";
                //b2.Location = new Point(l1.Location.X + l1.Width + l2.Width + l3.Width + b1.Width, l1.Location.Y);
                p.Controls.Add(l1);
                p.Controls.Add(l2);
                p.Controls.Add(l3);
                p.Controls.Add(l4);
                p.Controls.Add(image);
                p.Controls.Add(image2);
                recordRows.Add(l2);
                recordRows2.Add(l3);
                recordRows3.Add(l4);
                recordRows4.Add(image);
                recordRows5.Add(image2);
                recordRowFull.Add(p);
                MaintenanceRecordFlowPanel.Controls.Add(p);
            }
            //MaintenanceRecordFlowPanel.Visible = true;
            
        }
        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        

        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void Categories_Resize(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            
            int formWidth = form.Width;
            int formHeight = form.Height;
            HeaderPnl.Width = formWidth - 40;
            DepartmentsFlowLayoutPanel.Height = (int)(formHeight - HeaderPnl.Height - 219);
            WelcomePagePanel.Height = formHeight - WelcomePagePanel.Location.Y-50;
            WelcomePagePanel.Width = formWidth - (DepartmentsFlowLayoutPanel.Width + 40);
            if (departmentChosen == 1)
            {
                DepartmentInformationPanel.Width = WelcomePagePanel.Width;
                DepartmentInformationPanel.Height = WelcomePagePanel.Height;
                DepartmentHeaderPanel.Width = DepartmentInformationPanel.Width;
                 
                EditButton.Location = new System.Drawing.Point(WelcomePagePanel.Width - 90, 9);
                MachinesPanel.Height = (int)(formHeight - 290);
                MachinesPanel.Width = WelcomePagePanel.Width - 20;

                SelectMachinePanel.Height = (int)(SelectMachinePanel.Parent.Height - 8);

                MachineInfoPanel.Height = SelectMachinePanel.Height;
                MachineInfoPanel.Width = (int)(MachinesPanel.Width - SelectMachinePanel.Width - 15);

               
                EquipmentListBox.Height = (int)(EquipmentListBox.Parent.Height - 200);
                EquipmentListBox.Location = new Point(7, 157);

                AddNewMachineButton.Location = new Point((SelectMachinePanel.Width - 130) / 2, EquipmentListBox.Location.Y + EquipmentListBox.Height+10);

                MaintenanceRecordFlowPanel.Width = (int)(0.94 * MachineInfoPanel.Width);
                //MaintenanceRecordFlowPanel.Width = (int)(MachineInfoPanel.Width - 15);
                MaintenanceRecordFlowPanel.Height = (int)(MachineInfoPanel.Height - SNLabel.Location.Y - SNLabel.Height - 8.9);
                SearchTextBox.Width = MachineInfoPanel.Width - MaintenanceRecordsLabel.Width - MaintenanceRecordsLabel.Location.X - 100;
                SearchButton.Location = new Point(SearchTextBox.Location.X + SearchTextBox.Width, SearchTextBox.Location.Y);

                //JobDescriptionLabel.Location = new Point(SNLabel.Location.X + SNLabel.Width, SNLabel.Location.Y);
                JobDescriptionLabel.Width = MaintenanceRecordFlowPanel.Width - (32 + 65 + 70 +128);
                DateStartedLabel.Location = new Point(SNLabel.Location.X + SNLabel.Width + JobDescriptionLabel.Width, SNLabel.Location.Y);
                DateFinishedLabel.Location = new Point(SNLabel.Location.X + SNLabel.Width + JobDescriptionLabel.Width + DateStartedLabel.Width, SNLabel.Location.Y);
                AddNewRecordButton.Location = new Point(MachineInfoPanel.Width - 13 - 75, DateFinishedLabel.Location.Y);
                for (int i = 0; i < recordRows.Count; i++)
                {
                    recordRows.ElementAt(i).Width = JobDescriptionLabel.Width;
                    recordRows2.ElementAt(i).Location = new Point(recordRows.ElementAt(i).Location.X + JobDescriptionLabel.Width, recordRows2.ElementAt(i).Location.Y);
                    recordRows3.ElementAt(i).Location = new Point(recordRows.ElementAt(i).Location.X + JobDescriptionLabel.Width + DateStartedLabel.Width, recordRows3.ElementAt(i).Location.Y);
                    recordRows4.ElementAt(i).Location = new Point(recordRows.ElementAt(i).Location.X + JobDescriptionLabel.Width + DateStartedLabel.Width + DateFinishedLabel.Width + 15, recordRows4.ElementAt(i).Location.Y);
                    recordRows5.ElementAt(i).Location = new Point(recordRows.ElementAt(i).Location.X + JobDescriptionLabel.Width + DateStartedLabel.Width + DateFinishedLabel.Width + 15 + 30 + 15, recordRows5.ElementAt(i).Location.Y);
                    if (numberOfRecords > (MaintenanceRecordFlowPanel.Height/30))
                    {
                        scrollRecords = 1;
                    }
                    else
                    {
                        scrollRecords = 0;
                    }
                    if (scrollRecords == 0)
                    {
                        recordRowFull.ElementAt(i).Width = MaintenanceRecordFlowPanel.Width - 7;
                    }
                    else
                    {
                        recordRowFull.ElementAt(i).Width = MaintenanceRecordFlowPanel.Width - 25;
                    }
                    
                }
                //MessageBox.Show(MaintenanceRecordFlowPanel.Height.ToString());
            }
        }

        private void MenuIcon_Click(object sender, EventArgs e)
        {
            MenuPnl.Visible = !MenuPnl.Visible;
            //Image img1 = System.Drawing.Image.FromFile("c:\\Users\\Prowess\\Documents\\Visual Studio 2015\\Projects\\EgbinInstrumentInfoApp\\EgbinInstrumentInfoApp\\Resources\\makefg.png");
            Image img1 = global::EgbinInstrumentInfoApp.Properties.Resources.makefg;
            //Image img2 = System.Drawing.Image.FromFile("c:\\Users\\Prowess\\Documents\\Visual Studio 2015\\Projects\\EgbinInstrumentInfoApp\\EgbinInstrumentInfoApp\\Resources\\hamburger.png");
            Image img2 = global::EgbinInstrumentInfoApp.Properties.Resources.hamburger;
            MenuIcon.Image = MenuPnl.Visible ?
                img1 : img2;

        }

        private void ShowStaffView()
        {
            AddNewStaff();
            if (int.Parse(staffDetails[4])==2)
            {
                AddNewPanel.Visible = false;
                newLbl.Visible = false;
                pictureBox6.Visible = false;
                //if (DepartmentInformationPanel!=null)
                //{
                //    EditButton.Visible = false;
                //    AddNewMachineButton.Visible = false;
                //    AddNewRecordButton.Visible = true;
                //}
               
                
            }
            else if (int.Parse(staffDetails[4])==3)
            {
                
                AddNewPanel.Visible = false;
                newLbl.Visible = false;
                pictureBox6.Visible = false;
                //if (DepartmentInformationPanel != null)
                //{
                //    EditButton.Visible = false;
                //    AddNewMachineButton.Visible = false;
                //    AddNewRecordButton.Visible = false;
                //}

                
            
            }
        }
        
        private void AddNewStaff()
        {
            if (int.Parse(staffDetails[4]) == 1)//if staff is an administrator
            {
                ProfilePic.Image = EgbinInstrumentInfoApp.Properties.Resources.adduser2;
                ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                ToolTip1.SetToolTip(ProfilePic, "Add New Staff");
                ProfilePic.Cursor = Cursors.Hand;
                ProfilePic.Click += ProfilePic_Click;

            }

            else
            {
                ProfilePic.Image = EgbinInstrumentInfoApp.Properties.Resources.userprofile;
            }
        }

        private void ProfilePic_Click(object sender, EventArgs e)
        {
            AddNewStaffForm = new Form()
            {
                Width = 380,
                Height = 460,
                MaximizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Add New User",
                //BackColor = Color.Azure,
                BackColor=Color.AliceBlue,
                Icon = EgbinInstrumentInfoApp.Properties.Resources.adduserredicon,
            };


             fp = new FlowLayoutPanel()
            {
                Width = AddNewStaffForm.Width,
                Height = AddNewStaffForm.Height - 95,
                Location = new Point(2, 4)
            };

            SurnameLabel = new Label()
            {
                Text = "Surname:",
                Location = new Point(10, 2),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 28,
                Width = (int)(0.9 * AddNewStaffForm.Width),
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular)
            };

            SurnameTextBox = new TextBox()
            {
                Width = fp.Width - 70,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Left,
                Location = new Point(SurnameLabel.Location.X, SurnameLabel.Location.Y + SurnameLabel.Height)
            };

            FirstNameLabel = new Label()
            {
                Text = "First Name:",
                Location = new Point(SurnameLabel.Location.X, SurnameTextBox.Location.Y + SurnameTextBox.Height),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 28,
                Width = SurnameLabel.Width,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular)
            };

            FirstNameTextBox = new TextBox()
            {
                Width = SurnameTextBox.Width,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Left,
                Location = new Point(SurnameLabel.Location.X, FirstNameLabel.Location.Y + FirstNameLabel.Height)
            };

            StaffIdLabel = new Label()
            {
                Text = "Staff Id:",
                Location = new Point(SurnameLabel.Location.X, FirstNameTextBox.Location.Y + FirstNameTextBox.Height),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 28,
                AutoSize = false,
                Width = SurnameLabel.Width,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular)
            };

            StaffIdTextBox = new TextBox()
            {
                Width = FirstNameTextBox.Width,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Left,
                Location = new Point(SurnameLabel.Location.X, StaffIdLabel.Location.Y + StaffIdLabel.Height)
            };
            //access level
            AccessLevelLabel = new Label()
            {
                Text = "Set Access Level:",
                Location = new Point(SurnameLabel.Location.X, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 28,
                AutoSize = false,
                Width = SurnameLabel.Width,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular)
            };

            accesslevelDropdown = new ComboBox()
            {
                DataSource = Enum.GetValues(typeof(AccessLevel)),
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular),
                Location = new System.Drawing.Point(SurnameLabel.Location.X, AccessLevelLabel.Location.Y),
                Size = new System.Drawing.Size(121, 28),
                TabIndex = 3
            };
            accesslevelDropdown.FormattingEnabled = true;

            PhoneNumberLabel = new Label()
            {
                Text = "Phone Number:",
                Location = new Point(SurnameLabel.Location.X, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 28,
                AutoSize = false,
                Width = SurnameLabel.Width,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular)
            };

            PhoneNumberTextBox = new TextBox()
            {
                //Width = fp.Width - 100,
                Width=fp.Width-180,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Left,
                Location = new Point(SurnameLabel.Location.X, PhoneNumberLabel.Location.X)
            };

            DepartmentLabel = new Label()
            {
                Text = "Department:",
                Location = new Point(SurnameLabel.Location.X, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 28,
                AutoSize = false,
                Width = SurnameLabel.Width,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular)
            };

            DepartmentTextBox = new TextBox()
            {
                Width = SurnameTextBox.Width,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Left,
                Location = new Point(SurnameLabel.Location.X, DepartmentLabel.Location.Y)
            };

            SetDefaultPasswordLabel = new Label()
            {
                Text = "Default Password:",
                ForeColor=Color.Red,
                Location = new Point(SurnameLabel.Location.X, 50),
                TextAlign = ContentAlignment.MiddleLeft,

                //Height = 28,
                AutoSize = true,
                //Width = SurnameLabel.Width,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular),
                Visible = false
            };
         
            StaffPasswordLabel= new Label();
            StaffPasswordLabel.AutoSize = true;
            //StaffPasswordLabel.Width = fp.Width - 90;
            StaffPasswordLabel.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular);
            StaffPasswordLabel.ForeColor = Color.Red;
            StaffPasswordLabel.TextAlign = ContentAlignment.MiddleCenter;
            StaffPasswordLabel.Location = new Point(SetDefaultPasswordLabel.Location.X+SetDefaultPasswordLabel.Width, SetDefaultPasswordLabel.Location.Y);
            StaffPasswordLabel.Visible = false;
            //StaffPasswordLabel.ReadOnly = true;

            accesslevelDropdown.SelectedIndexChanged += AccesslevelDropdown_SelectedIndexChanged;
            //what happens when I select an access level
            //password, only visible when administrator or recorder is selected

            fp.Controls.Add(SurnameLabel);
            fp.Controls.Add(SurnameTextBox);
            fp.Controls.Add(FirstNameLabel);
            fp.Controls.Add(FirstNameTextBox);
            fp.Controls.Add(StaffIdLabel);
            fp.Controls.Add(StaffIdTextBox);
            fp.Controls.Add(AccessLevelLabel);
            fp.Controls.Add(accesslevelDropdown);
            fp.Controls.Add(PhoneNumberLabel);
            fp.Controls.Add(PhoneNumberTextBox);
            fp.Controls.Add(DepartmentLabel);
            fp.Controls.Add(DepartmentTextBox);
            fp.Controls.Add(SetDefaultPasswordLabel);
            fp.Controls.Add(StaffPasswordLabel);


            AddStaffButton = new Button()
            {
                Text = "ADD",
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular),
                AutoSize = true,
                UseVisualStyleBackColor = true,
                Location = new Point(StaffPasswordLabel.Location.X + (StaffPasswordLabel.Width / 2)-20, fp.Location.Y + fp.Height)
            };
            AddStaffButton.Click += AddStaffButton_Click;

            AddNewStaffForm.Controls.Add(fp);
            AddNewStaffForm.Controls.Add(AddStaffButton);

            AddNewStaffForm.ShowDialog();

        }

        private void AddStaffButton_Click(object sender, EventArgs e)
        {
            UniqueIdHash = GetHashedPassword(SurnameTextBox.Text + FirstNameTextBox.Text + StaffIdTextBox.Text);
            MessageBox.Show(UniqueIdHash);
            connector.connect();
            connector.insert("INSERT INTO staff_details(unique_id,surname,firstname,staff_id,access_level,phone_number,department,password) VALUES('" + UniqueIdHash + "', '" + SurnameTextBox.Text + "','" + FirstNameTextBox.Text + "','" + StaffIdTextBox.Text + "', '" + (accesslevelDropdown.SelectedIndex + 1) + "','" + PhoneNumberTextBox.Text + "', '" + DepartmentTextBox.Text + "','" + StaffPasswordHash + "')");
            MessageBox.Show("Staff Added!");
            AddNewStaffForm.Dispose();
            connector.disconnect();
            
        }

        public string GetHashedPassword(string originalpassword)
        {
            string hashedpassword = Utility.GetMD5Hash(originalpassword);
            return hashedpassword;
        }
        private void AccesslevelDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accesslevelDropdown.SelectedIndex+1==(int)(AccessLevel.Administrator/*1*/))
            {
                SetDefaultPasswordLabel.Visible = true;
                StaffPasswordLabel.Visible = true;

                StaffPasswordLabel.Text = "admin" + StaffIdTextBox.Text;
                StaffPasswordHash = GetHashedPassword(StaffPasswordLabel.Text);
                MessageBox.Show(StaffPasswordHash);
            }
            else if (accesslevelDropdown.SelectedIndex + 1 == (int)(AccessLevel.Recorder/*2*/))
            {
                SetDefaultPasswordLabel.Visible = true;
                StaffPasswordLabel.Visible = true;

                StaffPasswordLabel.Text = "record" + StaffIdTextBox.Text;
                StaffPasswordHash = GetHashedPassword(StaffPasswordLabel.Text);
                MessageBox.Show(StaffPasswordHash);
            }
            else
            {
                SetDefaultPasswordLabel.Visible = false;
                StaffPasswordLabel.Visible = false;
            }
            
        }




        /*private void SplitUnitTab()
{
   foreach (TabPage unit in categoryTabControl.TabPages)
   {
       splitCategoryTab = new SplitContainer()
       {
           Dock = DockStyle.Fill,
           //BackColor = Color.Gray,
           Visible = true,


       };
       //splitCategoryTab.Panel1.Controls.Add(voltageCheckListBox);
       splitCategoryTab.SplitterDistance = 40;


       GetVoltageLevel();
       splitCategoryTab.Panel1.Controls.Add(voltageLevelLabel);
       splitCategoryTab.Panel1.Controls.Add(voltageCheckListBox);
       splitCategoryTab.Panel2.BackColor = Color.White;
       //splitCategoryTab.Panel2.

       splitCategoryTab.Panel2.AutoScroll = true;

       unit.Controls.Add(splitCategoryTab);


   }

   //Controls.Add(splitCategoryTab);
   //splitCategoryTab.Panel1.Controls.Add(voltageCheckListBox);
}


private void GetVoltageLevel()
{

   Font voltageLabelFont = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

   voltageLevelLabel = new Label()
   {
       Text = "VOLTAGE LEVELS",
       Font = voltageLabelFont,
       ForeColor = Color.Black,

       //Width = 200,
       //Dock = DockStyle.Top

   }; 

   voltageCheckListBox = new CheckedListBox();
   voltageCheckListBox.Items.AddRange(new string[] { "16KV", "6.6KV", "415V", "240V", "110V" });
   //voltageCheckListBox.Height = 200;
   voltageCheckListBox.BackColor = SystemColors.MenuBar;

   Font checklistFont = new Font(voltageCheckListBox.Text, 15, FontStyle.Regular);
   voltageCheckListBox.Font = checklistFont;

   //voltageCheckListBox.Dock = DockStyle.Bottom;
   //voltageCheckListBox.Anchor = AnchorStyles.None;
   voltageCheckListBox.BorderStyle = BorderStyle.None;



}
*/

        private void UnitFiveLbl_Click(object sender, EventArgs e)
        {

        }

        private void UnitTwoLbl_Click(object sender, EventArgs e)
        {

        }

        private void categoryTabControl_Selected(object sender, TabControlEventArgs e)
        {
            //categoryTabControl.SelectedTab.Controls.Add(voltageCheckListBox);
            //SplitUnitTab();
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void DepartmentsPnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CategoryInfoPnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void newLbl_MouseUp(object sender, MouseEventArgs e)
        {
            newLbl.Visible = true;
            pictureBox6.Visible = true;
            confirm1();
        }

        private void newLbl_MouseDown(object sender, MouseEventArgs e)
        {
            newLbl.Visible = false;
            pictureBox6.Visible = false;
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            newLbl.Visible = true;
            pictureBox6.Visible = true;
            confirm1();
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            newLbl.Visible = false;
            pictureBox6.Visible = false;
        }

        public void GetDeparmentsFromDatabase()
        {
            connector.connect();
            int tableSize=connector.ReturnTableSize("departments");
            //MessageBox.Show(tableSize.ToString());
            SelectDepartmentDetails = connector.select("select unique_id,department_name,index_number,brief_description from departments order by department_name asc");
            SelectDepartmentImage = connector.selectImage("select department_image from departments order by department_name asc");
            for (int i = 0; i < tableSize; i++)
            {
                MemoryStream ms = new MemoryStream(SelectDepartmentImage.ElementAt(i));//READ BYTE ARRAY AS STREAM INPUT
                Image image = Image.FromStream(ms);
                string text = SelectDepartmentDetails.ElementAt(i)[1];
                addDepartment(text, image);
                
            }
            //MessageBox.Show("department database successfully connected!");
            connector.disconnect();
        }

        public void emptyDepartmentsFlow()
        {
            DepartmentsFlowLayoutPanel.Controls.Clear();
        }
        
 
        public void addDepartment(String s, String imageName)
        {
            b = new Button();
            b.Text = s.ToUpper();
            b.BackColor = System.Drawing.SystemColors.MenuBar;
            b.Size = new System.Drawing.Size(250, 71);
            b.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            b.ImageAlign = ContentAlignment.MiddleLeft;
            //b.Image = Image.FromFile("c:\\Users\\Prowess\\Documents\\Visual Studio 2015\\Projects\\view (3).png");
            Image img = Image.FromFile(imageName);
            

            b.Image = resizeImage(img,new Size(62,56));
            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b.Click += new EventHandler(ShowDepartmentInformationPanelHandler);
            DepartmentsFlowLayoutPanel.Controls.Add(b);
           
        }
        public void addDepartment(String s, Image imageName)
        {
            b = new Button();
            b.Text = s.ToUpper();
            b.TextAlign = ContentAlignment.MiddleCenter;
            b.Width = 150;
            b.Height = 50;
            b.BackColor = System.Drawing.SystemColors.MenuBar;
            b.Size = new System.Drawing.Size(250, 71);
            b.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            b.ImageAlign = ContentAlignment.MiddleLeft;
            //b.Image = Image.FromFile("c:\\Users\\Prowess\\Documents\\Visual Studio 2015\\Projects\\view (3).png");
            b.Image = resizeImage(imageName, new Size(62, 56));
            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b.Click += new EventHandler(ShowDepartmentInformationPanelHandler);
            //b.Tag=
            DepartmentsFlowLayoutPanel.Controls.Add(b);
            //List<String[]> searchResult = connection.select("select * from staff_details where staff_id='" + staffId + "'");
        }


        public void ShowDepartmentInformationPanelHandler(object sender, EventArgs e)
        {
            // this is what happens when  a department's button is clicked
            Button source = (Button)sender;
            departmentChosen = 1;
            //WelcomePagePanel.Dispose();
            connector.connect();
            List<string[]> departmentInfo = connector.select("select unique_id,department_name,index_number,brief_description from departments where department_name='" + source.Text + "'");
            foreach (string[] item in departmentInfo)
            {
                //MessageBox.Show(item[1]);
                source.Tag = item[2];//tag of selected button is the unique_id and the department of the department
                departmentButtonIndex = int.Parse(source.Tag.ToString());//this is so that I know what department I am on identified by an index and I know what to save in the department column of the machine database
                if (DepartmentInformationPanel == null)
                {
                    AddDepartmentInformationPanel(source.Image, source.Text, item[3]);
                    //it populates the topic with the text of the button clicked and image and the brief description label with database info
                }
                else
                {
                    DepartmentInformationPanel.Controls.Clear();
                    AddDepartmentInformationPanel(source.Image, source.Text, item[3]);
                }


                JobDescriptionLabel.Width = MaintenanceRecordFlowPanel.Width - (32 + 65 + 70 + 128);
                DateStartedLabel.Location = new Point(SNLabel.Location.X + SNLabel.Width + JobDescriptionLabel.Width, SNLabel.Location.Y);
                DateFinishedLabel.Location = new Point(SNLabel.Location.X + SNLabel.Width + JobDescriptionLabel.Width + DateStartedLabel.Width, SNLabel.Location.Y);
                AddNewRecordButton.Location = new Point(MachineInfoPanel.Width - 13 - 75, DateFinishedLabel.Location.Y);
                for (int i = 0; i < recordRows.Count; i++)
                {
                    recordRows.ElementAt(i).Width = JobDescriptionLabel.Width;
                    recordRows2.ElementAt(i).Location = new Point(recordRows.ElementAt(i).Location.X + JobDescriptionLabel.Width, recordRows2.ElementAt(i).Location.Y);
                    recordRows3.ElementAt(i).Location = new Point(recordRows.ElementAt(i).Location.X + JobDescriptionLabel.Width + DateStartedLabel.Width, recordRows3.ElementAt(i).Location.Y);
                    recordRows4.ElementAt(i).Location = new Point(recordRows.ElementAt(i).Location.X + JobDescriptionLabel.Width + DateStartedLabel.Width + DateFinishedLabel.Width + 15, recordRows4.ElementAt(i).Location.Y);
                    recordRows5.ElementAt(i).Location = new Point(recordRows.ElementAt(i).Location.X + JobDescriptionLabel.Width + DateStartedLabel.Width + DateFinishedLabel.Width + 15 + 30 + 15, recordRows5.ElementAt(i).Location.Y);
                    if (numberOfRecords > (MaintenanceRecordFlowPanel.Height / 30))
                    {
                        scrollRecords = 1;
                    }
                    else
                    {
                        scrollRecords = 0;
                    }
                    if (scrollRecords == 0)
                    {
                        recordRowFull.ElementAt(i).Width = MaintenanceRecordFlowPanel.Width - 7;
                    }
                    else
                    {
                        recordRowFull.ElementAt(i).Width = MaintenanceRecordFlowPanel.Width - 25;
                    }

                }

                //MaintenanceRecordFlowPanel
                DepartmentInformationPanel.BringToFront();
                connector.disconnect();
            }
        }
        public Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public void confirm1()
        {
            new Prompter(this).ShowDialog();
        }
        public void confirm2()
        {
            new Prompter2(this).ShowDialog();
        }
       
        private void FullnameLbl_Click(object sender, EventArgs e)
        {

        }

        private void Categories_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void AboutOptn_Click(object sender, EventArgs e)
        {
            AboutPage = new Form()
            {
                Width = 400,
                Height = (this.Height / 2) + 20,
                MaximizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Icon = EgbinInstrumentInfoApp.Properties.Resources.about,
                BackColor=Color.White

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
                Text ="The Instrument Information app is a platform that provides you with basic information and maintenance records of the various equipment in Egbin Power Plc.\nWith Instrument Information you are able to see all the jobs done on an equipment with detailed explanation of what was done and how it was carried out.\nIt aims at helping to reduce downtime and makes rectifying faults faster than ever with the aid of a guide.\nIt provides you with a wealth of experience at your finger tips. \n\nThis app was designed and built by: \nRichard-Chukkas Prowess (08089000806) \nOyefeso Oluwagbemileke (08088658898)",
                Width=AboutPage.Width-25,
                Height=AboutPage.Height-10,
                Left=5,
                Top=AboutLabel.Location.Y+AboutLabel.Height+15,
                //Margin=new Padding(20,AboutPage.Height-AboutLabel.Height-5,5,5),

            };

            AboutPage.Controls.Add(AboutLabel);
            AboutPage.Controls.Add(AboutInfoLabel);
            //MessageBox.Show(AboutPage.Height.ToString());
            AboutPage.ShowDialog();
        

        }

        private void LogoutOptn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login loginPage = new Login();
            loginPage.Show();
        }
    }
}
