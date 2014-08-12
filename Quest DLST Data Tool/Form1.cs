using System;
using System.Xml;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;

namespace Quest_DLST_Data_Tool
{
    public partial class Form1 : Form
    {
        TextWriter _writer = null;
        Quest_DLST_Data_Tool.Models.DLST_DB_Context db = new Quest_DLST_Data_Tool.Models.DLST_DB_Context();
        public Form1()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();           
            Console.WriteLine("Select File to import...");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             // Instantiate the writer
             _writer = new ConsoleWriter(txtConsole);
             // Redirect the out Console stream
             Console.SetOut(_writer);
          
 
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                fileName.Text = file;
            }
            else
                Console.WriteLine();
        }

        private void importLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(openFileDialog1.FileName))
            {
               Console.WriteLine("No file selected for import. Select file...");
                return;
            }

            try
            {
                var existingFile = openFileDialog1.FileName;

                var lines = File.ReadAllLines(existingFile);
                Quest_DLST_Data_Tool.Models.LoginTrack importLogin = new Quest_DLST_Data_Tool.Models.LoginTrack();
                Quest_DLST_Data_Tool.Models.PageTrack importNav = new Quest_DLST_Data_Tool.Models.PageTrack();
                DateTime LoginStartTime = DateTime.MinValue;
                DateTime LoginEndTime = DateTime.MinValue;
                DateTime NavStartTime = DateTime.MinValue;
                DateTime NavEndTime = DateTime.MinValue;
                String LoginDateIn = null;
                String LoginTimeIn=null;
                String NavDateIn = null;
                String NavTimeIn = null;
                String GroupId = null;
                String ModuleId = null;
                string LoginSessionId = null;
                string NavSessionId = null;
                int i;
                int j=0;
                   for (i = j; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        string[] values = line.Split(',');
                       if(values[1].Equals("Log In"))
                       {
                           string Date = values[3];
                           string Time = values[4];
                           LoginDateIn = (Convert.ToDateTime(Date)).ToString("%M/%d/yyyy");
                           LoginTimeIn = Time;
                           var dateTime = new DateTime(Convert.ToDateTime(Time).Ticks);
                           var formattedTime = dateTime.ToString("h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                           string[] arr = { Date, formattedTime};
                           String LoginDate = string.Join(" ", arr);
                           LoginStartTime = Convert.ToDateTime(LoginDate);
                           LoginSessionId = values[0];
                       }

                       if (values[1].Equals("Navigation In"))
                       {
                           string Date = values[3];
                           string Time = values[4];
                           NavDateIn = (Convert.ToDateTime(Date)).ToString("%M/%d/yyyy");
                           NavTimeIn = Time;
                           GroupId = values[5];
                           ModuleId = values[6];
                           var dateTime = new DateTime(Convert.ToDateTime(Time).Ticks);
                           var formattedTime = dateTime.ToString("h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                           string[] arr = { Date, formattedTime };
                           String LoginDate = string.Join(" ", arr);
                           NavStartTime = Convert.ToDateTime(LoginDate);
                           NavSessionId = values[0];
                       }


                       if (values[1].Equals("Navigation Out") && values[0].Equals(NavSessionId))
                       {
                           string Date = values[3];
                           string Time = values[4];
                           var dateTime = new DateTime(Convert.ToDateTime(Time).Ticks);
                           var formattedTime = dateTime.ToString("h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                           string[] arr = { Date, formattedTime };
                           String LogoutDate = string.Join(" ", arr);
                           NavEndTime = Convert.ToDateTime(LogoutDate);
                           TimeSpan span = NavEndTime.Subtract(NavStartTime);
                           int duration = int.Parse(span.Minutes.ToString());
                           importNav.SessionId = values[0];
                           importNav.UserName = values[2];
                           importNav.Date = NavDateIn;
                           importNav.Time = NavTimeIn;
                           importNav.GroupId = GroupId;
                           importNav.ModuleId = ModuleId;
                           importNav.Duration = duration;
                           var targetSession = db.PageTracks.Where(p => p.SessionId == importNav.SessionId).SingleOrDefault();
                           if (targetSession == null)
                           {
                               db.PageTracks.Add(importNav);
                               db.SaveChanges();
                               Console.WriteLine("Data Added for: "+values[0] + "," + values[2] + "," + NavDateIn + "," + NavTimeIn + "," + GroupId + "," + ModuleId + "," + "Duration :" + span.Minutes);
                           }
                           else
                           {
                               targetSession.UserName = importNav.UserName;
                               targetSession.Date = importNav.Date;
                               targetSession.Time = importNav.Time;
                               targetSession.GroupId = importNav.GroupId;
                               targetSession.ModuleId = importNav.ModuleId;
                               targetSession.Duration = importNav.Duration;
                               db.SaveChanges();
                               Console.WriteLine("Data Updated for: " + values[0] + "," + values[2] + "," + NavDateIn + "," + NavTimeIn + "," + GroupId + "," + ModuleId + "," + "Duration :" + span.Minutes);
                           }                           
                           
                           j = i + 1;
                       }


                       if (values[1].Equals("Log Out") && values[0].Equals(LoginSessionId))
                       {
                           string Date = values[3];
                           string Time = values[4];
                           var dateTime = new DateTime(Convert.ToDateTime(Time).Ticks);
                           var formattedTime = dateTime.ToString("h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                           string[] arr = { Date, formattedTime };
                           String LogoutDate = string.Join(" ", arr);
                           LoginEndTime = Convert.ToDateTime(LogoutDate);
                           TimeSpan span = LoginEndTime.Subtract(LoginStartTime);
                           int duration = int.Parse(span.Minutes.ToString());
                           importLogin.SessionId = values[0];
                           importLogin.UserName = values[2];
                           importLogin.Date = LoginDateIn;
                           importLogin.Time = LoginTimeIn;
                           importLogin.Duration = duration;
                           var targetSession = db.LoginTracks.Where(p => p.SessionId == importLogin.SessionId).SingleOrDefault();
                           if (targetSession == null)
                           {
                               db.LoginTracks.Add(importLogin);
                               db.SaveChanges();
                               Console.WriteLine("Data Added for : "+ values[0] + "," + values[2] + "," + LoginDateIn + "," + LoginTimeIn + "," + "Duration :" + span.Minutes);
                           }
                           else
                           {
                               targetSession.UserName = importLogin.UserName;
                               targetSession.Date = importLogin.Date;
                               targetSession.Time = importLogin.Time;
                               targetSession.Duration = importLogin.Duration;
                               db.SaveChanges();
                               Console.WriteLine("Data Updated for"+values[0] + "," + values[2] + "," + LoginDateIn + "," + LoginTimeIn + "," + "Duration :" + span.Minutes);
                           }
                          
                           j = i + 1;                    
                       }
                }                  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }        
        }

    }

