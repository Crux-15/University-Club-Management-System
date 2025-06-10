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
    public partial class MentorManageAdmin : Form
    {
        public MentorManageAdmin()
        {
            InitializeComponent();
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

        private void manageExecutive_Click(object sender, EventArgs e)
        {
            mentorManageExecutive manageExecutiveForm = new mentorManageExecutive();
            manageExecutiveForm.Show();
            this.Hide(); // Hide the current form (MentorManageAdmin)
        }

        private void manageMember_Click(object sender, EventArgs e)
        {
            MentorManageMember manageMemberForm = new MentorManageMember();
            manageMemberForm.Show();
            this.Hide(); // Hide the current form (MentorManageAdmin)
        }
    }
}
