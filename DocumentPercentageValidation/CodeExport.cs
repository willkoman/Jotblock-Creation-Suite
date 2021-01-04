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
    public partial class CodeExport : Form
    {
        public CodeExport()
        {
            InitializeComponent();
        }
        public void AddToExport(ListViewItem item,string page)
        {
            
            richTextBox1.AppendText("{{!##{Name:\""+item.SubItems[1].Text+ "\",InputType:\"Signatory\",FieldType:\"Typed\",Instructions:\"" + item.SubItems[6].Text + "\",SigningStep:\"1\",Height:\"" + item.SubItems[5].Text + "\",Width:\"" + item.SubItems[4].Text + "\", PositionX:\"" + item.SubItems[2].Text + "\", PositionY:\"" + item.SubItems[3].Text + "\", Page:\""+page+"\",SignatoryEmailParameterName:\"Signatory 1 Email Address\", Required:\"true\", SignatoryInputType:\"FreeText\"}##!}}\n\n");
        }
    }
}
