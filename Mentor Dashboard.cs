using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_Management_System
{
    public partial class Mentor_Dashboard : Form
    {
        bool sidebarExpand;
        bool manageProfileCollapsed;

        public Mentor_Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Mentor_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            //set minimum amd maximum size of sidebar

            if (!sidebarExpand)
            {
                //if sidebar is shrunk, expand it
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                //if sidebar is expanded, shrink it
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();

                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            //set timer interval to lowest value to make it smooth
            sidebarTimer.Start();
        }

        private void manageProfileTimer_Tick(object sender, EventArgs e)
        {
            if(manageProfileCollapsed)
            {
                manageProfileContainer.Height += 10;
                if(manageProfileContainer.Height == manageProfileContainer.MaximumSize.Height)
                {
                    manageProfileCollapsed = false;
                    manageProfileTimer.Stop();
                }
            }
            else
            {
                manageProfileContainer.Height -= 10;
                if (manageProfileContainer.Height == manageProfileContainer.MinimumSize.Height)
                {
                    manageProfileCollapsed = true;
                    manageProfileTimer.Stop();
                }
            }
        }

        private void manageProfiles_Click(object sender, EventArgs e)
        {
            //set timer interval to lowest value to make it smooth
            manageProfileTimer.Start();
        }

        private void dateTimepanel_Paint(object sender, PaintEventArgs e)
        {
            dateTimeTimer.Start();
        }

        private void dateTimeTimer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToString("dd-MM-yyyy ddd");
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
        
