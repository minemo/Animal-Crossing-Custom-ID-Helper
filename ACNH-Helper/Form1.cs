using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ACNH_Helper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            int maxsites = 10;
            for (int i = 1; i < maxsites; i++)
            {
                string website = @"https://nooksisland.com/designs?page=" + i;
                WebClient client = new WebClient();
                string antwort = client.DownloadString(@"https://nooksisland.com/designs");
                String[] htmlarr = antwort.Split();
                List<string> htmlist = htmlarr.ToList();
                foreach (string line in htmlist.ToArray())
                {
                    if (line == "")
                    {
                        htmlist.Remove(line);
                        //Console.WriteLine("Es wurde eine Leerzeile gelöscht");
                    }
                    else
                    {
                        //Console.WriteLine(line);
                    }
                }
                htmlarr = htmlist.ToArray();
                //Form frm2 = new Form2(htmlarr);
                //frm2.Show();
                foreach (string item in htmlarr)
                {
                    string pattern = @"(\/images\/designs\/.+)";
                    Regex rx = new Regex(pattern);
                    Match m = rx.Match(item);
                    if (m.Success)
                    {
                        Console.WriteLine("habe Eine id gefunden: " + m.Value);
                        string temp = m.Value;
                        temp = temp.Remove(temp.Length - 5, 5);
                        temp = temp.Remove(0, 16);

                        listBox1.Items.Add(temp);

                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo nooksisland = new ProcessStartInfo(@"https://nooksisland.com");
            Process.Start(nooksisland);
        }
    }
}
