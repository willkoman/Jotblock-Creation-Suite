
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentPercentageValidation
{
    
    public partial class ImageSelection : Form
    {
        bool _isDown, _isMoving;
        Jotblock j = new Jotblock();
        JotblockTracker tracker = new JotblockTracker();

        public ImageSelection()
        {
            InitializeComponent();
            tracker.Show();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
                _isMoving = true;
            else
                _isMoving = false;
            tsl_pos.Text = (float) e.Location.X + ", " + (e.Location.Y-25);
            tsl_perc.Text = (((float) e.Location.X / pictureBox1.Size.Width))+"%, "+ (((float) (e.Location.Y+36) / pictureBox1.Size.Height))+ "%";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _isDown = true;
            j.xPos = tsl_perc.Text.Substring(0, tsl_perc.Text.IndexOf('%')-1);
            j.yPos = tsl_perc.Text.Substring(tsl_perc.Text.IndexOf(',')+1).Trim('%');

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isMoving && _isDown)
            {
                j.width = "" +
                ((float.Parse(tsl_perc.Text.Substring(0, tsl_perc.Text.IndexOf('%') - 1)) - float.Parse(j.xPos)));

                j.height = "" +
                ((float.Parse(tsl_perc.Text.Substring(tsl_perc.Text.IndexOf(',') + 1).Trim('%')) - float.Parse(j.yPos)));

                j.name = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for Jotblock",
                            "Name Jotblock",
                            "Default",
                            0,
                            0);

                tracker.addJotblock(j);
                j = new Jotblock();
                _isMoving = false;
                _isDown = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
