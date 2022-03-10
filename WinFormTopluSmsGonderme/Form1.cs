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
    public partial class Form1 : Form
    {
        WinFormTopluSmsGondermeEntitiesConnectionDbString db = new WinFormTopluSmsGondermeEntitiesConnectionDbString();
        public Form1()
        {
            InitializeComponent();
        }
        void Temizle()
        {
            txtAd.Text = txtSoyad.Text = txtTel.Text = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Personel p = new Personel();
            p.Ad = txtAd.Text;
            p.Soyad = txtSoyad.Text;
            p.Telefon = txtTel.Text;
            db.Personel.Add(p);
            db.SaveChanges();
            dataGridView1.DataSource = db.Personel.ToList();
            Temizle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Personel.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Personel p = db.Personel.FirstOrDefault(x => x.Id == id);
            p.Ad = txtAd.Text;
            p.Soyad = txtSoyad.Text;
            p.Telefon = txtTel.Text;
            db.SaveChanges();
            dataGridView1.DataSource = db.Personel.ToList();
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Personel p = db.Personel.FirstOrDefault(x => x.Id == id);
            DialogResult Onay;
            Onay = MessageBox.Show($@"{dataGridView1.CurrentRow.Cells[1].Value.ToString()} {dataGridView1.CurrentRow.Cells[2].Value.ToString()} kişisi kalıcı olarak silinsin mi ?","Kalıcı Olarak Silinecek!",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
            if (Onay == DialogResult.Yes)
            {
                db.Personel.Remove(p);
                db.SaveChanges();
                Temizle();
                dataGridView1.DataSource = db.Personel.ToList();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TopluSMS tsms = new TopluSMS();
            this.Hide();
            tsms.ShowDialog();
            this.Show();
        }
    }
}
