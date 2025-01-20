using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace OddOrEven
{
    public partial class Form1 : Form
    {
        double girilensayi;
        const string upper = "HATA!";
        const string success = "Hesaplama Başarılı!";
        const string info = "Bilgilendirme";
     
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                if(textBox1.Text == "-")
                {
                        MessageBox.Show("Lütfen Sadece '-' Operatörü Koymayınız ve Tekrar Deneyiniz", upper,
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                    
                }
                else
                {
                    girilensayi = Convert.ToDouble(textBox1.Text);
                    if (girilensayi % 2 == 0)
                    {
                        MessageBox.Show("Girdiğiniz sayı : " + girilensayi + "\n" + "Sonuç :" + " Çift", success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        MessageBox.Show("Girdiğiniz sayı : " + girilensayi + "\n" + "Sonuç :" + " Tek", success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                
            }
            else
            {
                MessageBox.Show("Lütfen Bir Sayı Giriniz ve Tekrar Deneyiniz", upper, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if(textBox1.Text == "Lütfen Bir Değer Giriniz")
            {
                MessageBox.Show("Gireceğiniz değer yazı OLMAMALIDIR", upper, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            /*const yazarak 'upper' değişkenini string sabiti haline getirdim. Olası durumlarda çıkacak hataları önlemek amaçlı da MessageBox'a kullanıcı uyarması için bildiriler ekledim. */


            if (textBox1.Text.Contains("--"))
            {
                MessageBox.Show("Lütfen Girdiğiniz Değerin Yanına Birden Fazla '-' veya '+' Koymadan Tekrar Deneyiniz", upper,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                e.Cancel = false;
            }
            else if (textBox1.Text.Contains(girilensayi + "-"))
            {
                MessageBox.Show("Lütfen Girdiğiniz Değerin Sonuna Birden Fazla '-' veya '+' Koymadan Tekrar Deneyiniz", upper,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
            }
        }
            
        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
       
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message =
                "Uygulamayı kapatmak istediğinize emin misiniz?";
            const string caption = "Tek mi Çift mi Kapatılıyor ";
            // 'result' değişkeni var ile tanımlandığında otomatik olarak string değişkeni olarak tanımlanır.
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question); 

            // Eğer Kullanıcı "Hayır" Tuşuna Basarsa.   
            if (result == DialogResult.No)
            {
                // Sistem Kendisini Kapatmasını Engeller ve Çalışmaya (Değer Beklemeye ve İşlemeye) Devam Eder.  
                e.Cancel = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (   e.KeyChar >= 'a' && e.KeyChar <= 'z' || e.KeyChar >= 'A' && e.KeyChar <= 'Z' 
                || e.KeyChar == '"' || e.KeyChar == '!' || e.KeyChar == ' ' || e.KeyChar == '#'
                || e.KeyChar == '$' || e.KeyChar == '½' || e.KeyChar == '{' || e.KeyChar == '[' 
                || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == '<' || e.KeyChar == '>'
                || e.KeyChar == '#' || e.KeyChar == '|' || e.KeyChar == 'é' || e.KeyChar == '!'
                || e.KeyChar == '^' || e.KeyChar == '%' || e.KeyChar == '&' || e.KeyChar == '.'
                || e.KeyChar == '/' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '='
                || e.KeyChar == '?' || e.KeyChar == '_' || e.KeyChar == 'ş' || e.KeyChar == ';'
                || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '£' || e.KeyChar == '\\'
                || e.KeyChar == 'ç' || e.KeyChar == 'ö' || e.KeyChar == 'ı' || e.KeyChar == 'ğ'
                || e.KeyChar == 'ü' || e.KeyChar == '+' || e.KeyChar == '*')
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Enter tuşunun varsayılan işlemini engeller
                button1.Focus(); // Odaklanmak istediğiniz TextBox'a geçiş yapar
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if(textBox1.Text.IndexOf('-') >= 1)
            {
                for (int i = 1; i < textBox1.Text.Length;  i++)
                {
                    if (textBox1.Text[i] == '-')
                    {
                        MessageBox.Show("'-' Operatörü Sayının Başında Olmalıdır Lütfen Tekrar Deneyiniz.", upper, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = textBox1.Text.Remove(i, 1);
                        textBox1.SelectionStart = textBox1.Text.Length;
                        break;
                    }
                }

            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
