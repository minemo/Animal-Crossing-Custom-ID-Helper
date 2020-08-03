using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACNH_Helper
{
    public partial class Form2 : Form
    {
        public Form2(String[] htmlarr)
        {
            InitializeComponent();
            foreach(string item in htmlarr)
            {
                listBox1.Items.Add(item);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {  
            
        }
    }
}
