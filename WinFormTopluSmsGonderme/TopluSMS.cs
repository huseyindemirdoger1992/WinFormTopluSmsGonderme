using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTopluSmsGonderme.Models;

namespace WinFormTopluSmsGonderme
{
    public partial class TopluSMS : Form
    {
        WinFormTopluSmsGondermeEntitiesConnectionDbString db = new WinFormTopluSmsGondermeEntitiesConnectionDbString();
        public TopluSMS()
        {
            InitializeComponent();
        }

        private void TopluSMS_Load(object sender, EventArgs e)
        {
            label1.Text = $@"Toplam içerik gönderilecek personel sayısı: {db.Personel.Count().ToString()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TopluSMSAction tsms = new TopluSMSAction();
            tsms.SMSGonder(textBox1.Text);
            MessageBox.Show("Toplu SMS Gönderimi Başarılı.","Durum",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
