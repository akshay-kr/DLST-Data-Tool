using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Quest_DLST_Data_Tool
{
    public class ConsoleWriter : TextWriter
    {
        RichTextBox _output = null;
 
        public ConsoleWriter(RichTextBox output)
        {
            _output = output;
        }
 
        public override void Write(char value)
        {
            base.Write(value);
            _output.AppendText(value.ToString()); // When character data is written, append it to the text box.
        }
 
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
    
