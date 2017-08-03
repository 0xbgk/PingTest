using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace pingtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool[] pingable = new bool[2];
        List<string> metin = new List<string>();

        Timer t = new Timer();
        


        private void button1_Click(object sender, EventArgs e)
        {
            
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected == "")
            {

            }
            else
            {
                pingbul(selected);
            }
        }

        private void pingbul(string x)
        {

            Ping p = new Ping();
            PingReply[] pr = new PingReply[2];

            

            for (int i = 0; i < 2; i++)
            {
                pingable[i] = false;
            }
            

            switch (x)
            {

                case "South East Asia, Singapore":
                    //South East Asia, Singapore                   
                    pr[0] = p.Send("103.28.54.1");
                    metin.Add("Singapore                     ");
                    metin.Add("Singapore                     ");                    
                    pr[1] = p.Send("103.10.124.1");                    
                    pingable[0] = pr[0].Status == IPStatus.Success;
                    pingable[1] = pr[1].Status == IPStatus.Success;                  
                    break;

                case "Europe":
                    //Europe  
                    metin.Add("(EU West) Luxembourg");
                    metin.Add("(EU East) Vienna          ");
                    pr[0] = p.Send("146.66.152.1");
                    pr[1] = p.Send("146.66.155.1");
                    pingable[0] = pr[0].Status == IPStatus.Success;
                    pingable[1] = pr[1].Status == IPStatus.Success;
                    break;

                case "United States":
                    //United States
                    metin.Add("(US West) Washington ");
                    metin.Add("(US East) Sterling         ");
                    pr[0] = p.Send("192.69.96.1");
                    pr[1] = p.Send("208.78.164.1");
                    pingable[0] = pr[0].Status == IPStatus.Success;
                    pingable[1] = pr[1].Status == IPStatus.Success;
                    break;

                case "Australia":
                    //Australia 
                    metin.Add("(AU) Sydney                 ");
                    metin.Add("");
                    pr[0] = p.Send("103.10.125.1");                  
                    pingable[0] = pr[0].Status == IPStatus.Success;
                    break;

                case "Russia":
                    //Russia  
                    metin.Add("(SW) Stockholm           ");
                    metin.Add("");
                    pr[0] = p.Send("146.66.156.1");
                    pingable[0] = pr[0].Status == IPStatus.Success;
                    break;

                case "South America":
                    //South America  
                    metin.Add("(BR)                              ");
                    metin.Add("(BR)                              ");
                    pr[0] = p.Send("209.197.29.1");                    
                    pr[1] = p.Send("209.197.25.1");                    
                    pingable[0] = pr[0].Status == IPStatus.Success;
                    pingable[1] = pr[1].Status == IPStatus.Success;
                    break;

                case "South Africa":
                    //South Africa  
                    metin.Add("(SA) Cape Town           ");
                    metin.Add("(SA) Cape Town           ");
                    pr[0] = p.Send("197.80.200.1");                    
                    pr[1] = p.Send("196.38.180.1");                   
                    pingable[0] = pr[0].Status == IPStatus.Success;
                    pingable[1] = pr[1].Status == IPStatus.Success;
                    break;

                case "Middle East":
                    //Middle East
                    metin.Add("(UAE) Dubai                 ");
                    metin.Add("");
                    pr[0] = p.Send("185.25.183.1");                    
                    pingable[0] = pr[0].Status == IPStatus.Success;                  
                    break;
                    
            }
            for (int i = 0; i < 2; i++)
            {
                if (pingable[i])
                {
                    richTextBox1.Text += string.Format("{0}, {1} --- >> {2}ms. {3}", metin.ElementAt(i), pr[i].Address.ToString(), pr[i].RoundtripTime.ToString(), Environment.NewLine);               
                }
                else
                {
                    richTextBox1.Text += "";
                }
            }

            richTextBox1.Text += "\n";
            for (int i = 1; i >= 0 ; i--)
            {
                metin.RemoveAt(i);
            }
            

           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            t = new Timer()
            {
                Interval = 1000
            };

            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected == "")
            {

            }
            else
            {                
                t.Start();
                t.Tick += delegate (object _s, EventArgs _e)
                {
                    pingbul(selected);
                };
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            t.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1.Text = "Bölge Seçin:";
            button1.Text = "Ping Bul";
            button2.Text = "Temizle";
            button3.Text = "Devamlı Ping Bul";
            button4.Text = "Dur";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label1.Text = "Select Region:";
            button1.Text = "Ping Now";
            button2.Text = "Clear Text";
            button3.Text = "Ping Continuously";
            button4.Text = "Stop";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
