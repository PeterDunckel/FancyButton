using System;
using System.Drawing;
using System.Windows.Forms;

namespace FancyButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddRequiredLabel(Control target)
        {
            var newStar = new Label();
            newStar.Width = 15;
            newStar.Text = "*";
            newStar.Left = target.Left - newStar.Width;
            newStar.ForeColor = Color.Red;
            newStar.Font = new Font("", 14);
            newStar.Top = target.Top;
            newStar.Visible = true;
            this.Controls.Add(newStar);
            toolTip1.SetToolTip(newStar, "REQUIRED");
        }

        private void AddTooltipLabel(Control target)
        {
            var newLabel = new Label();
            newLabel.Width = 40;
            newLabel.Text = "?";
            newLabel.Left = target.Right + 10;
            newLabel.Top = target.Top;
            newLabel.Visible = true;
            this.Controls.Add(newLabel);
            toolTip1.SetToolTip(newLabel, target.Tag as String);
        }

        private void AddHelperLabels(Control target)
        {
            if (target.Tag != null)
            {
                AddTooltipLabel(target);

                AddRequiredLabel(target);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control cc in this.Controls)
            {
                if (cc is Button || cc is TextBox)
                {
                    AddHelperLabels(cc);
                }
            }
        }
    }
}
