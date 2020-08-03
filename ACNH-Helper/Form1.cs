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
                //Fetch the Website
                string website = @"https://nooksisland.com/designs?page=" + i;
                WebClient client = new WebClient();
                string antwort = client.DownloadString(@"https://nooksisland.com/designs");
                String[] htmlarr = antwort.Split();
                List<string> htmlist = htmlarr.ToList();
                //Format the HTML
                foreach (string line in htmlist.ToArray())
                {
                    if (line == "")
                    {
                        htmlist.Remove(line);
                    }
                }
                htmlarr = htmlist.ToArray();
                foreach (string item in htmlarr)
                {
                    //REGEX to find Design urls
                    string pattern = @"(\/images\/designs\/.+)";
                    Regex rx = new Regex(pattern);
                    Match m = rx.Match(item);
                    if (m.Success)
                    {
                        //Isolate the ID
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
            //Nooksisland Link
            ProcessStartInfo nooksisland = new ProcessStartInfo(@"https://nooksisland.com");
            Process.Start(nooksisland);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //My Github link
            ProcessStartInfo mgithub = new ProcessStartInfo(@"https://github.com/minemo");
            Process.Start(mgithub);
        }
    }
}
