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
    public partial class JotBlockEditor : Form
    {
        Jotblock s = null;
        int id = 0;
        JotblockTracker jt = new JotblockTracker();
        public JotBlockEditor()
        {
            InitializeComponent();
        }
        public JotBlockEditor(Jotblock j, JotblockTracker jt, int id)
        {
            InitializeComponent();
            s = j;
            this.jt = jt;
            this.id = id;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void JotBlockEditor_Load(object sender, EventArgs e)
        {
            textBox1.Text = s.name;
            richTextBox1.Text = s.instruction;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.name = textBox1.Text;
            s.instruction = richTextBox1.Text;
            jt.replaceJotblock(s, id);
            this.Close();
        }
    }
}
