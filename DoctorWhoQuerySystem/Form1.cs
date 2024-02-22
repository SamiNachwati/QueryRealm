using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorWhoQuerySystem
{
    /// <summary>
    /// Class that contains the code of the form
    /// </summary>
    public partial class DoctorWhoQuerySystem : Form
    {
        SqlConnection connection; // SqlConnection object used to make connections the database
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=COMP10204_DB_PRACTICE;Integrated Security=True"; // the connection string used to connect
        List<Doctor> doctors = new List<Doctor>(); // list used to store Doctor objects when found via database query
        List<Companion> companions = new List<Companion>(); // list used to store Companion objects when found via database query
        List<Episode> episodes = new List<Episode>(); // list used to store Episode objects when found via database query
        byte[] photos; // byte array used to store byte sequences for retrieving photograph information


        public DoctorWhoQuerySystem()
        {

            InitializeComponent();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("Success!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR! " + ex.Message);
            }


            try
            {
                SqlCommand s1 = new SqlCommand("SELECT * FROM DOCTOR", connection); // command used to obtain all the information from the DOCTOR table
                SqlDataReader r1 = s1.ExecuteReader(); // data reader object used to read the information of each Doctor
                while (r1.Read())
                {
                    photos = (byte[])r1["Picture"];
                    Doctor d = new Doctor((int)r1[0], (string)r1[1], photos);
                    doctors.Add(d);
                    doctorBox.Items.Add(d);

                }
                r1.Close();


                SqlCommand s2 = new SqlCommand("select * from COMPANION", connection); // command used to obtain all the information from the COMPANION table
                SqlDataReader r2 = s2.ExecuteReader(); // data reader object used to read the information of each Companion
                while (r2.Read())
                {
                    Companion c = new Companion((string)r2[0], (string)r2[1], (int)r2[2], (string)r2[3]);
                    companions.Add(c);
                }
                r2.Close();



                SqlCommand s3 = new SqlCommand("select * from EPISODE", connection); // command used to obtain all the information from the EPISODE table
                SqlDataReader r3 = s3.ExecuteReader(); // data reader object used to read the information of each Episode
                while (r3.Read())
                {
                    Episode e = new Episode((string)r3[0], (string)r3[3]);
                    episodes.Add(e);
                }
                r3.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR! " + ex.GetBaseException());
            }

        }


        /// <summary>
        /// Method used to run specific operations when the index value of the list of Doctors 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doctorBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            travelledWith.Items.Clear();
            titleBox.Items.Clear();
            int selectedDoctor = doctorBox.SelectedIndex; // obtain the index value of the selected doctor
            SelectedDoctor.Text = doctors[selectedDoctor].ToString();
            foreach (Companion c in companions)
            {
                if (c.doctorID == doctors[selectedDoctor].ID)
                {
                    travelledWith.Items.Add($"Companion {c} travelled with doctor {doctors[selectedDoctor]}");
                }
            }
            // query string used to retrieve distinct titles from the EPISODE table where the story id's of the COMPANION and EPISODE match, and where the doctorid of the selected DOCTOR matches with doctorid of the COMPANION
            string cmd = $"SELECT distinct title FROM EPISODE E join COMPANION C on C.storyid = E.storyid join DOCTOR D on c.doctorid=d.doctorid WHERE c.doctorid = {doctors[selectedDoctor].ID}";
            SqlCommand getTtles = new SqlCommand(cmd, connection); // actual command used to run the query string in getting the titles
            SqlDataReader readTitles = getTtles.ExecuteReader(); // reader object used to read each line of the results from the query
            while (readTitles.Read())
            {
                titleBox.Items.Add(readTitles.GetString(0));
            }
            readTitles.Close();
            pictureBox1.Image = doctors[selectedDoctor].picture;

        }



        /// <summary>
        /// Method used to exit out of the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
