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

        private void feed_Paint(object sender, PaintEventArgs e)
        {
            LoadFeed();
        }

        private void LoadFeed()
        {
            feed.Controls.Clear(); // Clear old posts

            // Simulated post data - replace with real DB fetch
            List<(string Author, string Content, List<string> Comments)> posts = new List<(string, string, List<string>)>
    {
        ("Mentor M001", "Welcome to the club!", new List<string> { "Thank you!", "Excited to join." }),
        ("Admin A002", "Upcoming event on Friday!", new List<string> { "I'll be there.", "Sounds great!" }),
        ("Executive E003", "Team A meeting today.", new List<string> { "Got it!", "Thanks for the heads-up." }),
    };

            // Add latest posts to top
            foreach (var post in posts)
            {
                Panel postPanel = CreatePostPanel(post.Author, post.Content, post.Comments);
                feed.Controls.Add(postPanel);
                feed.Controls.SetChildIndex(postPanel, 0); // Add to top
            }
        }

        private Panel CreatePostPanel(string author, string content, List<string> comments)
        {
            Panel panel = new Panel();
            panel.Width = feed.Width - 30;
            panel.Height = 150;
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label lblAuthor = new Label();
            lblAuthor.Text = $"Author: {author}";
            lblAuthor.Location = new Point(10, 10);
            lblAuthor.AutoSize = true;

            Label lblContent = new Label();
            lblContent.Text = content;
            lblContent.Location = new Point(10, 35);
            lblContent.AutoSize = true;

            Button btnLike = new Button();
            btnLike.Text = "Like";
            btnLike.Location = new Point(10, 70);
            btnLike.AutoSize = true;

            Button btnComment = new Button();
            btnComment.Text = "Comment";
            btnComment.Location = new Point(70, 70);
            btnComment.AutoSize = true;

            FlowLayoutPanel commentPanel = new FlowLayoutPanel();
            commentPanel.Location = new Point(10, 105);
            commentPanel.Width = panel.Width - 20;
            commentPanel.Height = 0; // Collapsed by default
            commentPanel.AutoScroll = true;
            commentPanel.Visible = false;
            commentPanel.FlowDirection = FlowDirection.TopDown;
            commentPanel.WrapContents = false;

            // Populate comments (latest first)
            foreach (string comment in comments.AsEnumerable().Reverse())
            {
                Label lblComment = new Label();
                lblComment.Text = "↪ " + comment;
                lblComment.AutoSize = true;
                commentPanel.Controls.Add(lblComment);
            }

            btnComment.Click += (s, e) =>
            {
                commentPanel.Visible = !commentPanel.Visible;
                commentPanel.Height = commentPanel.Visible ? (comments.Count * 20 + 10) : 0;
            };

            panel.Controls.Add(lblAuthor);
            panel.Controls.Add(lblContent);
            panel.Controls.Add(btnLike);
            panel.Controls.Add(btnComment);
            panel.Controls.Add(commentPanel);

            return panel;
        }

    }
}
        
