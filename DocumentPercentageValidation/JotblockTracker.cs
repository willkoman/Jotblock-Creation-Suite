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
    public partial class JotblockTracker : Form
    {
        int index = 0;
        CodeExport export = new CodeExport();
        public JotblockTracker()
        {
            InitializeComponent();
            
        }
        public void addJotblock(Jotblock j)
        {
            listView1.Items.Add(new ListViewItem(new string[] { index++.ToString("D2"), j.name, j.xPos, j.yPos, j.width, j.height, j.instruction }));
        }
        public void replaceJotblock(Jotblock j,int id)
        {
            listView1.Items.RemoveAt(id);
            listView1.Items.Add(new ListViewItem(new string[] { id.ToString("D2"), j.name, j.xPos, j.yPos, j.width, j.height, j.instruction }));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
                listView1.Items.Remove(eachItem);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(toolStripComboBox1.SelectedText, out int x))
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                    export.AddToExport(item, toolStripComboBox1.SelectedText);

                export.ShowDialog();
            }
            else
                MessageBox.Show("You haven't selected a page number!");
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            float avg = 0;
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                avg+=float.Parse(item.SubItems[3].Text);
            }
            avg /= listView1.SelectedItems.Count;
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                item.SubItems[3].Text = avg.ToString();
            }
            float avgh = 0;
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                avgh += float.Parse(item.SubItems[5].Text);
            }
            avgh /= listView1.SelectedItems.Count;
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                item.SubItems[5].Text = avgh.ToString();
            }
        }
        private void JotblockTracker_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            JotBlockEditor jb = new JotBlockEditor(new Jotblock(listView1.SelectedItems[0].SubItems[1].Text,  float.Parse(listView1.SelectedItems[0].SubItems[2].Text), float.Parse(listView1.SelectedItems[0].SubItems[3].Text), float.Parse(listView1.SelectedItems[0].SubItems[4].Text), float.Parse(listView1.SelectedItems[0].SubItems[5].Text), listView1.SelectedItems[0].SubItems[6].Text), this,listView1.SelectedItems[0].Index);
            jb.ShowDialog();
        }



    }
}
