using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelBilgiSistemi
{
    public partial class PersonelIslemleri : Form
    {
        public PersonelIslemleri()
        {
            InitializeComponent();
        }

        OtelBilgileri otelB;
        IkiliAramaAgaci oAgac = new IkiliAramaAgaci();
        IkiliAramaAgacDugumu oDugum = new IkiliAramaAgacDugumu();

        private void PersonelIslemleri_Load(object sender, EventArgs e)
        {

        }
        public int IsimIntYap(char ad) {

            int ASCII = Convert.ToInt32(ad);

            return ASCII;
        }

        private void btnYeniOtel_Click(object sender, EventArgs e)
        {
            otelB = new OtelBilgileri();
           
            int toplam = 0;
            foreach (var AdString in otel_adi_per.Text)
            {
                int gelenInt = IsimIntYap(AdString);
                toplam += gelenInt;
            }
            otelB.Ad = otel_adi_per.Text;
            otelB.Il = otel_il_per.Text;
            otelB.Ilce = otel_ilce_per.Text;
            otelB.Isimint = toplam;
            otelB.OdaSayisi = Convert.ToInt32(otel_odasayisi_per.Text);
            otelB.OdaTipi = otel_odatipi_per.Text;
            otelB.YildizSayisi = Convert.ToInt32(otel_yildiz_per.Text);
            otelB.email = otel_eposta_per.Text;
            otelB.Telefon = Convert.ToInt32(otel_tel_per.Text);
            otelB.puan = Convert.ToInt32(otel_puan_per.Text);

            oAgac.Ekle(otelB);

            MessageBox.Show("Dugum Sayısı: " + oAgac.DugumSayisi());


         
        }

        private void btnOtelGoster_Click(object sender, EventArgs e)
        {

           /* string adindanbilgi = otel_adi_per.Text;

            oAgac.Bilgi(adindanbilgi);
            MessageBox.Show(oDugum.yazdır());*/


        }

        private void btnOtelSil_Click(object sender, EventArgs e)
        {
            int toplam = 0;
            foreach (var AdString in otel_adi_per.Text)
            {
                int gelenInt = IsimIntYap(AdString);
                toplam += gelenInt;
            }

            oAgac.OtelSil(toplam);


        }

        private void btnKayitGuncelle_Click(object sender, EventArgs e)
        {
            int toplam = 0;
            foreach (var AdString in otel_adi_per.Text)
            {
                int gelenInt = IsimIntYap(AdString);
                toplam += gelenInt;
            }

            otelB.Ad = otel_adi_per.Text;
            otelB.Il = otel_il_per.Text;
            otelB.Ilce = otel_ilce_per.Text;
            otelB.Isimint = toplam;
            otelB.OdaSayisi = Convert.ToInt32(otel_odasayisi_per.Text);
            otelB.OdaTipi = otel_odatipi_per.Text;
            otelB.YildizSayisi = Convert.ToInt32(otel_yildiz_per.Text);
            otelB.email = otel_eposta_per.Text;
            otelB.Telefon = Convert.ToInt32(otel_tel_per.Text);
            otelB.puan = Convert.ToInt32(otel_puan_per.Text);


            IkiliAramaAgacDugumu dugum = new IkiliAramaAgacDugumu(otelB);
            oAgac.Guncelle(dugum);

            oAgac.Bilgiler(dugum);

            MessageBox.Show(" " + oAgac.DugumleriYazdir());

        }
    }
}
