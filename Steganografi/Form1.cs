using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Steganografi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Bitmap bmp = null;
        private string cikarilanYazi = string.Empty;
        private void btnAc_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Resim Dosyaları (*.png,*.bmp,*.jpg)|*.png;*.bmp;*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picIsleme.Image = Image.FromFile(dialog.FileName);
                btnGizle.Enabled = true;
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "Png Image|*.png|Bitmap Image|*.bmp";
            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                switch (save_dialog.FilterIndex)
                {
                    case 0:
                        {
                            bmp.Save(save_dialog.FileName, ImageFormat.Png);
                        }
                        break;
                    case 1:
                        {
                            bmp.Save(save_dialog.FileName, ImageFormat.Bmp);
                        }
                        break;
                }
            }
            txtMesaj.Clear();
        }
        private void btnGizle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMesaj.Text == "")
                {
                    MessageBox.Show("Hiçbir şey yazmadınız");
                }
                else
                {
                    bmp = (Bitmap)picIsleme.Image;
                    string yazi = txtMesaj.Text;
                    bmp = StegoIslem.yaziGizle(yazi, bmp);
                    MessageBox.Show("İşlendi. Resmi Kaydetmeyi unutmayın!");
                    txtMesaj.Clear();
                }
            }
            catch (Exception)
            {
                if (txtMesaj.Text == "")
                {
                    MessageBox.Show("Hiçbir şey yazmadınız");
                }
            }
        }
        private void btnCoz_Click(object sender, EventArgs e)
        {
            bmp = (Bitmap)picIsleme.Image;
            string coz = StegoIslem.Coz(bmp);
            txtMesaj.Text = "";
            txtMesaj.Text = coz;
        }
        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-ozkanqaratas@gmail.com\n-Ozkan KARATAS");
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-'Aç' butonu ile bilgisayarınızdan bir resim dosyası seçebilirsiniz." +
                "\n-Textbox içine gizlemek istediğiniz metni yazdıktan sonra 'Gizle' " +
                "butonu ile metni resme gizleyebilirsiniz." +
                "\n-'Kaydet' butonu ile şifrelenmiş metin dosyasını kaydedebilirsiniz." +
                "\n-'Çöz' butonu ile daha önceden şifrelenmiş bir resim dosyasını çözümleyebilirsiniz.");
        }

        private void txtMesaj_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
