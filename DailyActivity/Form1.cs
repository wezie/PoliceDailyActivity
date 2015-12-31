using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace DailyActivity
{
    public partial class Form1 : Form
    {
        // Variables to hold our total counts.
        int totalStops = 0;
        int ticketCount = 0;
        int multickets = 0;
        int writtenWarning = 0;
        int verbalWarning = 0;
        int totalAccidents = 0;
        int callService = 0;
        int reportTaken = 0;

        // Variables to move the form.
        int mouseIsDown = 0;
        int MValX;
        int MValY;

        bool ticket = false;

        public Form1()
        {
            InitializeComponent();
        }

        // Submit button. When user clicks this will add to the daily totals.
        private void button1_Click(object sender, EventArgs e)
        {
            updateTickets();
            updateAccidents();
            updateCalls();
            resetBoxes(this);

            if (ticket == true)
            {
                gotEm();                
            }

            textBox8.Text = "";
            textBox1.Text = totalStops.ToString();
            textBox2.Text = ticketCount.ToString();
            textBox3.Text = writtenWarning.ToString();
            textBox4.Text = verbalWarning.ToString();
            textBox5.Text = callService.ToString();
            textBox6.Text = reportTaken.ToString();
            textBox7.Text = totalAccidents.ToString();

            ticket = false;
        }

        // Reset button. When user clicks this will reset the entire form.
        private void button2_Click(object sender, EventArgs e)
        {
            resetBoxes(this);
            resetAll(this);

            // Reset the totals
            totalStops = 0;
            ticketCount = 0;
            multickets = 0;
            writtenWarning = 0;
            verbalWarning = 0;
            totalAccidents = 0;
            callService = 0;
            reportTaken = 0;
        }

        // Function to process the traffic stop section.
        public void updateTickets()
        {
            int.TryParse(textBox8.Text, out multickets);

            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || multickets >= 1)
            {
                totalStops++;
                
            }

            if (checkBox1.Checked == true)
            {
                ticketCount++;
                ticket = true;
            }

            if (checkBox2.Checked == true)
            {
                writtenWarning++;
            }

            if (checkBox3.Checked == true)
            {
                verbalWarning++;
            }

            if (multickets >= 1)
            {
                ticketCount = ticketCount + multickets;
                ticket = true;
            }
        }

        public void updateAccidents()
        {
            if (checkBox4.Checked == true || checkBox5.Checked == true)
            {
                totalAccidents++;
            }

            if (checkBox6.Checked == true)
            {
                ticketCount++;
                ticket = true;          
            }
        }

        /// <summary>
        /// This method is used to update the CALL FOR SERVICE SECTION
        /// </summary>
        public void updateCalls()
        {
            if (checkBox7.Checked == true && checkBox8.Checked == true)
            {
                callService++;
                reportTaken++;
                ticketCount++;
                ticket = true; 
            }

            if (checkBox7.Checked == true && checkBox8.Checked == false)
            {
                callService++;
                reportTaken++;
            }

            if (checkBox7.Checked == false && checkBox8.Checked == true)
            {
                callService++;
                ticketCount++;
                ticket = true;
            }            

            if (checkBox9.Checked == true)
            {
                callService++;                
            }           
            
        }

        // Function to reset the checkboxes after submitting.
        private void resetBoxes(Control ctrl)
        {
            CheckBox chkBox = ctrl as CheckBox;
            
            if (chkBox == null)
            {
                foreach (Control child in ctrl.Controls)
                {
                    resetBoxes(child);
                }
            }

            else
            {
                chkBox.Checked = false;
            }
        }

        // Function to reset all of the textboxes after a full reset/clear.
        private void resetAll(Control ctrl)
        {
            TextBox txtBox = ctrl as TextBox;

            if (txtBox == null)
            {
                foreach (Control child in ctrl.Controls)
                {
                    resetAll(child);
                }
            }

            else
            {
                txtBox.Clear();
                
            }
        }

        #region Mouse move form
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = 0;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsDown = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void gotEm()
        {
            System.Media.SoundPlayer soundGotEm = new System.Media.SoundPlayer(@"C:\Users\bdeweese\Documents\Visual Studio 2015\Projects\DailyActivity\DailyActivity\Resources\gotem.wav");

            soundGotEm.Play();
        }
    }
}
