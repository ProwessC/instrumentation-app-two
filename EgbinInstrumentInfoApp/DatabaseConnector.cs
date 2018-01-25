using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EgbinInstrumentInfoApp
{
    class DatabaseConnector
    {
        MySqlConnection connection;
        String connectionParameters;
        //int tableSize = 0;
        String host, user, password, database;
        public DatabaseConnector(String host, String user, String password, String database)
        {
            connectionParameters = "server=" + host + ";uid=" + user + ";pwd=" + password + ";database=" + database;
            this.database = database; this.host = host; this.password = password; this.user = user;
        }
        public void connect()
        {
            try
            {
                connection = new MySqlConnection(connectionParameters);
                connection.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error Connecting : " + e.Message);
            }
        }
        public void disconnect()
        {
            try
            {
                connection.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error in Dis-connecting : " + e.Message);
            }
        }
        public List<String[]> select(String query)
        {
            List<String[]> result = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //MessageBox.Show(query);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int fields = dataReader.FieldCount;
                result = new List<string[]>();
                int records = 0;
                while (dataReader.Read())
                {
                    String[] row = new String[fields];
                    for (int i = 0; i < row.Length; i++)
                    {
                        row[i] = dataReader[i].ToString();
                    }
                    result.Add(row);
                    records++;
                }

                dataReader.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error Connecting : " + e.Message);
            }
            return result;

        }

        public List<byte[]> selectImage(String query)
        {
            List<byte[]> resultImage = new List<byte[]>();
            try
            {
                MySqlCommand cmd2 = new MySqlCommand(query, connection);
                //USING DATAADAPTER AND DATASET, WE CAN HANDLE READING OF DATA IN A MORE AUTOMATED WAY AS COMPARED TO DATAREADER
                //WHERE WE HAVE TO READ IT MANUALLY AND ADD TO AN ARRAY.
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd2);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                //OUR DATASET CAN CONTAIN DATA FROM MANY TABLES, BUT SINCE WE HAVE ONLY 1 TABLE, we use 'ds.Tables[0]' WHHICH 
                //PICKS DATA FROM THE FIRST AND ALSO ONLY TABLE.
                //tableSize = ds.Tables[0].Rows.Count;
                //if (ds.Tables[0].Rows.Count > 0)
                //{

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //'ds.Tables[0].Rows' RETURNS A COLLECTION WHICH CONTAINS THE RESULT OF THE QUERY, SO FOR INSTANCE IF WE WANT TO
                    //GET THE FOURTH ELEMENT ON THE SECOND ROW, WE DO 'ds.Tables[0].Rows[1][3]'

                    byte[] photo_aray = (byte[])ds.Tables[0].Rows[i]["department_image"];//CREATE A BYTE ARRAY AND READ IMAGE BLOB INTO IT
                    //MemoryStream ms = new MemoryStream(photo_aray);//READ BYTE ARRAY AS STREAM INPUT
                    //button.Image = Image.FromStream(ms);
                    //textBox1.Text = ds.Tables[0].Rows[currentIndex][1].ToString();
                    resultImage.Add(photo_aray);

                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error Connecting : " + e.Message);
            }


            return resultImage;

        }

        public int ReturnTableSize(String tableName)
        {
            //String query = "select count(" + tableName + ") from " + database;
            string query = "select count(unique_id) from " + tableName;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //MessageBox.Show(query);
            return Int32.Parse(cmd.ExecuteScalar().ToString());
        }

        public int ReturnMachineColumnCount(String tagname)
        {
            //String query = "select count(" + tableName + ") from " + database;
            string query = "select count(unique_id) from machine_details where tag_name='"+tagname+"'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //MessageBox.Show(query);
            return Int32.Parse(cmd.ExecuteScalar().ToString());
        }

        
        public int insert(String query)
        {
            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";
            int result = 0;
            try
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Execute command
                cmd.ExecuteNonQuery();
                result = 1;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error Connecting : " + e.Message);
                result = 0;
            }
            return result;
        }

        public int insertImage(string filename, string uniqueId)
        {
            //openFileDialog1.Filter = "Image Files (Jpeg, Png, Gif)|*.jpg; *png; *.jpeg; *.gif";
            //DialogResult res = openFileDialog1.ShowDialog(); in the show chooser method
            //if (res == DialogResult.OK)
            //{
            int n = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("update departments set department_image=@department_image where unique_id='"+uniqueId+"'", connection);
                MemoryStream ms = new MemoryStream();
                //textBox1.Text = openFileDialog1.FileName;

                //SAVING THE IMAGE FROM THE OPENFILEDIALOG AS A STREAM
                Image.FromFile(filename).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                //CREATE BYTE ARRAY OF THE EXACT LENGTH AS THE STREAM SINCE WERE ARE CONVERTING THE STREAM TO BYTES
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;

                //READ STREAM DATA BYTE BY BYTE INTO THE BYTE ARRAY, STARTING FROM BEGINNING 0, TO THE END
                ms.Read(photo_aray, 0, photo_aray.Length);
                cmd.Parameters.AddWithValue("@department_image", photo_aray);
                //cmd.Parameters.AddWithValue("@url", openFileDialog1.FileName);
                //cmd.Parameters.AddWithValue("@id", GetMD5Hash(openFileDialog1.FileName));

                //try

                //n =cmd.ExecuteNonQuery();//RETURNS 1 IF SUCCESSFUL OR 0 IF NOT
                cmd.ExecuteNonQuery();
                n = 1;
                //MessageBox.Show("New Image Inserted");
            }

            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Number + "--" + ex.Message);
                //:) I DIDN'T JUST KNOW WHAT ERROR 1062 REPRESENTED, I FIRST TRIED DISPLAYING THE ERROR NUMBER AND MESSAGE 
                //ASSOCIATED WITH THE ERROR AS SEEN ABOVE. SO I KNOW 1062 OCCURS WHEN IT TRYS TO PUT IN A RECORD THAT ALREADY 
                //HAS THE SAME PRIMARY KEY.
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Image Already Exists in Database");
                    n = -1;
                }
                else
                {
                    MessageBox.Show("insertion failed"+ex.Message);
                }
            }
            return n;
            //if (n > 0)
            //{
            //    MessageBox.Show("New Image inserted");
            //}
            //else if (n == -1)
            //{

            //}
            //else
            //{
            //    MessageBox.Show("insertion failed");
            //}
            //tableSize++;

        }

        public int update(String query)
        {
            int result = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                result = 1;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error Connecting : " + e.Message);
                result = 0;
            }
            return result;
        }
        public int delete(String query)
        {
            int result = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                result = 1;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error Connecting : " + e.Message);
                result = 0;
            }
            return result;
        }
    }
}
