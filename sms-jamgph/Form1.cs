using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sms_jamgph
{
    public partial class Form1 : Form
    {
        public static string no, msg, api;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            no = txtNo.Text;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            sendBtn.Hide();
            string[] err = { "Message Sent!", "Invalid Number", "Number not supported", "Invalid API Code", "Only 10 sms per day", "Too many message characters", "System Offline", "Expired API Code", "Error", "Cannot be empty", "Recipients mobile has been blocked", "Invalid Request", "Invalid sender ID", "Invalid Server Number" };
            dynamic result = itexmo(no, msg, api);
            int res = Convert.ToInt32(result);
            MessageBox.Show(err[res]);
            sendBtn.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            msg = txtMsg.Text + "\n\n\n\n\n\n\nhttps://jamgph.com";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            api = apiBox.Text;
        }
        

        public object itexmo(string Number, string Message, string API_CODE)
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "https://www.itexmo.com/php_api/api.php";
                parameter.Add("1", Number);
                parameter.Add("2", Message);
                parameter.Add("3", API_CODE);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            return functionReturnValue;
        }

    }
}
