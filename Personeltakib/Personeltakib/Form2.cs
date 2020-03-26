using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;

namespace Personeltakib
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=personel.accdb;Persist Security Info=False;");
        DataSet dtst = new DataSet();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        private void kullanicilari_goster()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter kullanicilari_listele = new OleDbDataAdapter
                ("select tcno AS[TC KİMLİK NO], Ad AS[ADI],soyad AS[SOYADI],yetki AS[YETKİ],kullaniciadi AS[KULLANICI ADI], parola AS[PAROLA] from kullanicilar Order By ad ASC", baglanti);
                DataSet dshafiza = new DataSet();
                kullanicilari_listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message, "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
                
            }
        }
        private void personelleri_goster()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter personelleri_listele = new OleDbDataAdapter
                ("select tcno AS[TC KİMLİK NO], Ad AS[ADI],soyad AS[SOYADI], cinsiyet AS[CİNSİYETİ], mezuniyet AS[MEZUNİYETİ], dogumtarihi AS[DOĞUM TARİHİ], gorevi AS[GÖREVİ], gorevyeri AS[GÖREV YERİ], maasi AS[MAAŞI] from personeller Order By ad ASC", baglanti);
                DataSet dshafiza = new DataSet();
                personelleri_listele.Fill(dshafiza);
                dataGridView2.DataSource = dshafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message, "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
                throw;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelDataSet4.personeller' table. You can move, or remove it, as needed.
            this.personellerTableAdapter1.Fill(this.personelDataSet4.personeller);
           
            pictureBox1.Height = 150;
            pictureBox1.Width = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kallaniciresimler\\" + Form1.tcno + ".png");

            }

            catch
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kallaniciresimler\\resimyok.png");
            }
            this.Text = "YÖNETİCİ İŞLEMLERİ";
            label1.ForeColor = Color.DarkRed;
            label1.Text = Form1.adi + " " + Form1.soyadi;
            textBox7.MaxLength = 11;
            textBox10.MaxLength = 8;
            toolTip1.SetToolTip(this.textBox7, "Tc Kimlik No 11 Karakter Olmalı!");
            radioButton3.Checked = true;

            textBox8.CharacterCasing = CharacterCasing.Upper;
            textBox9.CharacterCasing = CharacterCasing.Upper;
            textBox11.MaxLength = 10;
            textBox12.MaxLength = 10;
            progressBar2.Maximum = 100;
            progressBar2.Minimum = 0;
            kullanicilari_goster();

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Width = 100; pictureBox2.Height = 100;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            maskedTextBox1.Mask = "00000000000";
            maskedTextBox2.Mask = "LL????????????????????";
            maskedTextBox3.Mask = "LL????????????????????";
            maskedTextBox4.Mask = "0000";
            maskedTextBox2.Text.ToUpper();
            maskedTextBox3.Text.ToUpper();

            comboBox1.Items.Add("İlköğretim"); comboBox1.Items.Add("Ortaöğretim");
            comboBox1.Items.Add("Lise"); comboBox1.Items.Add("Üniversite");

            comboBox2.Items.Add("Yönetici");
            comboBox2.Items.Add("Memur");
            comboBox2.Items.Add("Şoför");
            comboBox2.Items.Add("İşci");

            comboBox3.Items.Add("AR-GE");
            comboBox3.Items.Add("Bilgi İşlem");
            comboBox3.Items.Add("Muhasebe");
            comboBox3.Items.Add("Üretim");
            comboBox3.Items.Add("Paketleme");
            comboBox3.Items.Add("Nakliye");

            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            dateTimePicker1.MinDate = new DateTime(1960, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(yil - 18, ay, gun);
            dateTimePicker1.Format = DateTimePickerFormat.Short;

            radioButton1.Checked = true;








        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length < 11)
                errorProvider1.SetError(textBox7, "TC Kimlik No 11 Karakter olmalı!");
            else
                errorProvider1.Clear();

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;


        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text.Length != 8)
                errorProvider1.SetError(textBox10, "Kullanıcı adı 8 karakter olmalı!");
            else
                errorProvider1.Clear();

        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsDigit(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;

        }
        int parola_skoru = 0;

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            string parola_seviyesi = "";
            int kucuk_harf_skoru = 0, buyuk_harf_skoru = 0, rakam_skoru = 0, sembol_skoru = 0;
            string sifre = textBox11.Text;
            string duzeltilmis_sifre = "";
            duzeltilmis_sifre = sifre;
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('İ', 'I');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('i', 'ı');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ç', 'C');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ç', 'c');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ş', 'S');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ş', 's');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ğ', 'G');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ğ', 'g');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ü', 'U');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ü', 'u');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ö', 'O');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ö', 'o');
            if (sifre != duzeltilmis_sifre)
            {
                sifre = duzeltilmis_sifre;
                textBox11.Text = sifre;
                MessageBox.Show("Paroladaki Türkçe karakterler İngilizce karakterlere dönüştürülmüştür!");

                int az_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;
                kucuk_harf_skoru = Math.Min(2, az_karakter_sayisi) * 10;

                int AZ_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[A-Z]", "").Length;
                buyuk_harf_skoru = Math.Min(2, AZ_karakter_sayisi) * 10;

                int rakam_sayisi = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length;
                rakam_skoru = Math.Min(2, rakam_sayisi) * 10;

                int sembol_sayisi = sifre.Length - az_karakter_sayisi - AZ_karakter_sayisi - rakam_sayisi;
                sembol_skoru = Math.Min(2, sembol_sayisi) * 10;

                parola_skoru = kucuk_harf_skoru + buyuk_harf_skoru + rakam_skoru + sembol_skoru;
                if (sifre.Length == 9)
                    parola_skoru += 10;
                else if (sifre.Length == 10)
                    parola_skoru += 20;

                if (kucuk_harf_skoru == 0 || buyuk_harf_skoru == 0 || rakam_skoru == 0 || sembol_skoru == 0)

                    label22.Text = "Büyük harf, küçük harf, rakam ve sembeol mutlaka kullanmalısın!";
                if (kucuk_harf_skoru != 0 && buyuk_harf_skoru != 0 && rakam_skoru != 0 && sembol_skoru != 0)
                    label22.Text = "";

                if (parola_skoru < 70)
                    parola_seviyesi = "Kabul edilemez!";
                else if (parola_skoru == 70 || parola_skoru == 80)
                    parola_seviyesi = "Güçlü";
                else if (parola_skoru == 90 || parola_skoru == 100)
                    parola_seviyesi = "Çok Güçlü";

                label18.Text = "%" + Convert.ToString(parola_skoru);
                label19.Text = parola_seviyesi;
                progressBar2.Value = parola_skoru;




            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text != textBox11.Text)
                errorProvider1.SetError(textBox11, "Parola tekrarı eşleşmiyor!");
            else
                errorProvider1.Clear();


        }
        private void topPage_temizle()
        {
            textBox7.Clear(); textBox8.Clear(); textBox9.Clear(); textBox10.Clear(); textBox11.Clear();
            textBox12.Clear();
        }
        private void topPage2_temizle()
        {
            pictureBox2.Image = null; maskedTextBox1.Clear(); maskedTextBox2.Clear(); maskedTextBox3.Clear(); maskedTextBox4.Clear(); comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1; comboBox3.SelectedIndex = -1;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string yetki = "";
            bool kayitkontrol = false;

            baglanti.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + textBox7.Text + "'", baglanti);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                kayitkontrol = true;
                break;

            }
            baglanti.Close();

            if (kayitkontrol == false)
            {
                if (textBox7.Text.Length < 11 || textBox7.Text == "")
                    label11.ForeColor = Color.Red;
                else
                    label11.ForeColor = Color.Black;

                if (textBox8.Text.Length < 2 || textBox8.Text == "")
                    label12.ForeColor = Color.Red;
                else
                    label12.ForeColor = Color.Black;

                if (textBox9.Text.Length < 2 || textBox9.Text == "")
                    label13.ForeColor = Color.Red;
                else
                    label13.ForeColor = Color.Black;

                if (textBox10.Text.Length != 8 || textBox10.Text == "")
                    label15.ForeColor = Color.Red;
                else
                    label15.ForeColor = Color.Black;

                if (textBox11.Text == "" || parola_skoru < 70)
                    label16.ForeColor = Color.Red;
                else
                    label16.ForeColor = Color.Black;

                if (textBox12.Text == "" || textBox11.Text != textBox12.Text)
                    label17.ForeColor = Color.Red;
                else
                    label17.ForeColor = Color.Black;

                if (textBox7.Text.Length == 11 && textBox7.Text != "" && textBox8.Text != "" && textBox8.Text.Length > 1 && textBox9.Text != "" && textBox9.Text.Length > 1 && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox11.Text == textBox12.Text && parola_skoru >= 70)
                {
                    if (radioButton3.Checked == true)
                        yetki = "Yönetici";
                    else if (radioButton4.Checked == true)
                        yetki = "Kullanıcı";
                    try
                    {
                        baglanti.Open();
                        OleDbCommand eklemekomutu = new OleDbCommand("inset into kullanicilar values('" + textBox7.Text + "','" + textBox8.Text + "', '" + textBox9.Text + "','" + yetki + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "')", baglanti);
                        eklemekomutu.ExecuteNonQuery();
                        baglanti.Close();
                         MessageBox.Show("Yeni kullanıcı kaydı oluşturuldu!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message);
                        baglanti.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçiriniz", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Girilen TC Kimlik Numarası daha önce kayıtlıdır!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);




            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (textBox7.Text.Length == 11)
            {
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + textBox7.Text + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    textBox8.Text = kayitokuma.GetValue(1).ToString();
                    textBox9.Text = kayitokuma.GetValue(2).ToString();
                    if (kayitokuma.GetValue(3).ToString() == "Yönetici")
                        radioButton3.Checked = true;

                    else
                        radioButton4.Checked = true;
                    textBox10.Text = kayitokuma.GetValue(4).ToString();
                    textBox11.Text = kayitokuma.GetValue(5).ToString();
                    textBox12.Text = kayitokuma.GetValue(5).ToString();
                    break;


                }
                if (kayit_arama_durumu == false)
                
                    MessageBox.Show("Aranan kayıt bulunamadı", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Lutfen 11 haneli bir TC kimlik No giriniz!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                topPage2_temizle();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
                  string yetki="";
                if (textBox7.Text.Length < 11 || textBox7.Text == "")
                    label11.ForeColor = Color.Red;
                else
                    label11.ForeColor = Color.Black;

                if (textBox8.Text.Length < 2 || textBox8.Text == "")
                    label12.ForeColor = Color.Red;
                else
                    label12.ForeColor = Color.Black;

                if (textBox9.Text.Length < 2 || textBox9.Text == "")
                    label13.ForeColor = Color.Red;
                else
                    label13.ForeColor = Color.Black;

                if (textBox10.Text.Length != 8 || textBox10.Text == "")
                    label15.ForeColor = Color.Red;
                else
                    label15.ForeColor = Color.Black;

                if (textBox11.Text == "" || parola_skoru < 70)
                    label16.ForeColor = Color.Red;
                else
                    label16.ForeColor = Color.Black;

                if (textBox12.Text == "" || textBox11.Text != textBox12.Text)
                    label17.ForeColor = Color.Red;
                else
                    label17.ForeColor = Color.Black;

                if (textBox7.Text.Length == 11 && textBox7.Text != "" && textBox8.Text != "" && textBox8.Text.Length > 1 && textBox9.Text != "" && textBox9.Text.Length > 1 && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox11.Text == textBox12.Text && parola_skoru >= 70)
                {
                    if (radioButton3.Checked == true)
                        yetki = "Yönetici";
                    else if (radioButton4.Checked == true)
                        yetki = "Kullanıcı";
                    try
                    {
                        baglanti.Open();
                        OleDbCommand guncellekomutu = new OleDbCommand("inset into kullanicilar set ad='"+textBox8.Text+"'soyad='"+textBox9.Text+"',yetki'"+yetki+"',kullaniciadi='"+textBox10.Text+"',parola'"+textBox11.Text+"'",baglanti);
                          guncellekomutu.ExecuteNonQuery();
                        baglanti.Close();
                         MessageBox.Show("Yeni kullanıcı kaydı oluşturuldu!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                         kullanicilari_goster();



                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message, "Personel Takip Programı", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        baglanti.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçiriniz", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length == 11)
            {
                bool kayit_arama_durumu = false;
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + textBox7.Text + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    OleDbCommand deletesorgu = new OleDbCommand("delete from kullanicilar where tcno='" + textBox7.Text + "'", baglanti);
                    deletesorgu.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı kaydı silindi!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    baglanti.Close();
                    kullanicilari_goster();
                    topPage_temizle();
                    break;
                }
                if(kayit_arama_durumu==false)
                    MessageBox.Show("Silinecek kayıt bulunamadı!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
                topPage_temizle();

            }
            else
                MessageBox.Show("Lütfen 11 karakterden oluşan bir TC Kimlik No Giriniz!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            topPage_temizle();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog resimsec = new OpenFileDialog();
            resimsec.Title = "Personel resmi seçiniz.";
            resimsec.Filter = "JPG Dosyalar (*.jpg) | *.jpg";
            if (resimsec.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox2.Image = new Bitmap(resimsec.OpenFile());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";
            bool kayitkontrol = false;
            baglanti.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from personeller where tcno='" + maskedTextBox1.Text + "'", baglanti);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                kayitkontrol = true;
                break;
            }
            baglanti.Close();

            if (kayitkontrol == false)
            {
                if (pictureBox2.Image == null)
                    button1.ForeColor = Color.Red;
                else
                    button1.ForeColor = Color.Black;
                if (maskedTextBox1.MaskCompleted == false)
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;
                if (maskedTextBox2.MaskCompleted == false)
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;
                if (maskedTextBox3.MaskCompleted == false)
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;
                if (comboBox1.Text == "")
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;
                if (comboBox2.Text == "")
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;
                if (comboBox3.Text == "")
                    label19.ForeColor = Color.Red;
                else
                    label19.ForeColor = Color.Black;
                if (maskedTextBox4.MaskCompleted == false)
                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.Black;
                if (int.Parse(maskedTextBox4.Text) < 1000)
                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.Black;
                if (pictureBox1.Image != null && maskedTextBox1.MaskCompleted != false && maskedTextBox2.MaskCompleted != false && maskedTextBox3.MaskCompleted != false && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && maskedTextBox4.MaskCompleted != false)

                    if (radioButton1.Checked == true)
                        cinsiyet = "Bay";
                    else if (radioButton2.Checked == true)
                        cinsiyet = "Bayan";
                try
                {
                    baglanti.Open();
                    OleDbCommand eklekomutu = new OleDbCommand("insert into personeller values ('" + maskedTextBox1.Text + "','" + maskedTextBox2.Text + "', '" + maskedTextBox3.Text + "', '" + cinsiyet + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "','" + dateTimePicker1.Text + "', '" + comboBox3.Text + "', '" + maskedTextBox4.Text + "')", baglanti);
                    eklekomutu.ExecuteNonQuery();
                    baglanti.Close();
                    if (!Directory.Exists(Application.StartupPath + "\\personelresimler"))
                        Directory.CreateDirectory(Application.StartupPath + "\\personelresimler");
                    else
                        pictureBox2.Image.Save(Application.StartupPath + "\\personelresimler\\" + maskedTextBox1.Text + ".jpg");
                    MessageBox.Show("Yeni personel kaydı oluştruldu", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    personelleri_goster();
                    topPage2_temizle();

                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message, "Personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }

            }

            else

                MessageBox.Show("Yazı Rengi rengi kırmızı olan alanları yeniden gözden geçiriniz!", "Personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void button11_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (maskedTextBox1.Text.Length == 11)
            {
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from personeller where tcno='" + maskedTextBox1 + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    try
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\personelresimler\\" + kayitokuma.GetValue(0).ToString() + ".jpg");

                    }
                    catch 
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\personelresimler\\resimyok.jpg");
                    }
                    maskedTextBox2.Text=kayitokuma.GetValue(1).ToString();
                    maskedTextBox3.Text=kayitokuma.GetValue(2).ToString();
                    if(kayitokuma.GetValue(3).ToString()=="Bay")
                        radioButton1.Checked=true;
                    else
                        radioButton2.Checked=true;

                    comboBox1.Text = kayitokuma.GetValue(4).ToString();
                    dateTimePicker1.Text = kayitokuma.GetValue(5).ToString();
                    comboBox2.Text = kayitokuma.GetValue(6).ToString();
                    comboBox3.Text = kayitokuma.GetValue(7).ToString();
                    maskedTextBox4.Text = kayitokuma.GetValue(8).ToString();
                    break;
                }
                if (kayit_arama_durumu == false)
                    MessageBox.Show("Aranan kayıt bulunamadı", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("11 haneli TC no giriniz!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();



                        
                    }
                }

        private void button3_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";
          
           
                if (pictureBox2.Image == null)
                    button1.ForeColor = Color.Red;
                else
                    button1.ForeColor = Color.Black;
                if (maskedTextBox1.MaskCompleted == false)
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;
                if (maskedTextBox2.MaskCompleted == false)
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;
                if (maskedTextBox3.MaskCompleted == false)
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;
                if (comboBox1.Text == "")
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;
                if (comboBox2.Text == "")
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;
                if (comboBox3.Text == "")
                    label19.ForeColor = Color.Red;
                else
                    label19.ForeColor = Color.Black;
                if (maskedTextBox4.MaskCompleted == false)
                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.Black;
                if (int.Parse(maskedTextBox4.Text) < 1000)
                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.Black;
                if (pictureBox1.Image != null && maskedTextBox1.MaskCompleted != false && maskedTextBox2.MaskCompleted != false && maskedTextBox3.MaskCompleted != false && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && maskedTextBox4.MaskCompleted != false)

                    if (radioButton1.Checked == true)
                        cinsiyet = "Bay";
                    else if (radioButton2.Checked == true)
                        cinsiyet = "Bayan";
                try
                {
                    baglanti.Open();
                    OleDbCommand guncellekomutu = new OleDbCommand("uptade personeller set '" + maskedTextBox2.Text + "',soyad= '" + maskedTextBox3.Text + "',cinsiyet= '" + cinsiyet + "',mezuniyet= '" + comboBox1.Text + "',dogumtarihi= '" + dateTimePicker1.Text + "',gorevi='" + comboBox2.Text + "',gorevyeri= '" + comboBox3.Text + "', maasi='" + maskedTextBox4.Text + "'where tcno='"+maskedTextBox1.Text+"'", baglanti);
                    guncellekomutu.ExecuteNonQuery();
                    baglanti.Close();
                   
                    personelleri_goster();
                    topPage2_temizle();
                    maskedTextBox4.Text="0";

                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message, "Personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }

            }

        private void button4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskCompleted == true)
            {
                bool kayit_arama_durumu = false;
                baglanti.Open();
                OleDbCommand arama_sorgu=new OleDbCommand("select * from personeller where tcno='"+maskedTextBox1.Text+ "'",baglanti);
                OleDbDataReader kayitokuma = arama_sorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    OleDbCommand deletesorgu = new OleDbCommand("delete from personeller where tcno='" + maskedTextBox1 + "'", baglanti);
                    deletesorgu.ExecuteNonQuery();
                    break;
                }
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı!", "Personel Kayıt Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                baglanti.Close();
                personelleri_goster();
                topPage2_temizle();
                maskedTextBox4.Text = "0";
            }

            else 

            {
                MessageBox.Show("Lütfen 11 karakterden oluşan bir TC Kimlik no giriniz!", "Personel Takip Programı",MessageBoxButtons.OK,MessageBoxIcon.Error);
                topPage2_temizle();
                maskedTextBox4.Text="0";

            }
                }

        private void button5_Click(object sender, EventArgs e)
        {
            topPage2_temizle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
            }
        }

       











        
       

    
    

    

