using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FancyButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void addRequiredLabel(Control target)
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
            return;
        }

        private Label addTooltipLabel(Control target)
        {
            var newLabel = new Label();
            newLabel.Width = 40;
            newLabel.Text = "?";
            newLabel.Left = target.Right + 10;
            newLabel.Top = target.Top;
            newLabel.Visible = true;

            this.Controls.Add(newLabel);
            toolTip1.SetToolTip(newLabel, target.Tag as String);
            return newLabel;
        }

        private void addHelperLabels(Control target)
        {
            if (target.Tag != null)
            {
                addTooltipLabel(target);

                addRequiredLabel(target);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control cc in this.Controls)
            {
                if (cc is Button || cc is TextBox)
                {
                    addHelperLabels(cc);
                }
            }
        }
    }
}
