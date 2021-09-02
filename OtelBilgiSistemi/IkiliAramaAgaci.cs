using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelBilgiSistemi
{
    public class IkiliAramaAgaci
    {
        private IkiliAramaAgacDugumu kok;
        private string dugumler;
        public IkiliAramaAgaci()
        {
        }
        public IkiliAramaAgaci(IkiliAramaAgacDugumu kok)
        {
            this.kok = kok;
        }
        public int DugumSayisi()
        {
            return DugumSayisi(kok);
        }
        public int DugumSayisi(IkiliAramaAgacDugumu dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                count = 1;
                count += DugumSayisi(dugum.sol);
                count += DugumSayisi(dugum.sag);
            }
            return count;
        }
        public int YaprakSayisi()
        {
            return YaprakSayisi(kok);
        }
        public int YaprakSayisi(IkiliAramaAgacDugumu dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                if ((dugum.sol == null) && (dugum.sag == null))
                    count = 1;
                else
                    count = count + YaprakSayisi(dugum.sol) + YaprakSayisi(dugum.sag);
            }
            return count;
        }
        public string DugumleriYazdir()
        {
            return dugumler;
        }
        public void PreOrder()
        {
            dugumler = "";
            PreOrderInt(kok);
        }
        private void PreOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            Ziyaret(dugum);
            PreOrderInt(dugum.sol);
            PreOrderInt(dugum.sag);
        }
        public void InOrder()
        {
            dugumler = "";
            InOrderInt(kok);
        }
        private void InOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            InOrderInt(dugum.sol);
            Ziyaret(dugum);
            InOrderInt(dugum.sag);
        }
        private void Ziyaret(IkiliAramaAgacDugumu dugum)
        {
            dugumler += ((OtelBilgileri) dugum.veri).Ad + "Otel İl:" + ((OtelBilgileri)dugum.veri).Il +
                " Otel İlçe" + ((OtelBilgileri)dugum.veri).Ilce + "Adres:  " + ((OtelBilgileri)dugum.veri).Adres + "Otel Puan:" + ((OtelBilgileri)dugum.veri).puan +
                "Otel Telefon: " + ((OtelBilgileri)dugum.veri).Telefon + "Oda Sayisi: " + ((OtelBilgileri)dugum.veri).OdaSayisi + "Oda Tipi: " + ((OtelBilgileri)dugum.veri).OdaTipi +
                "Yıldız Sayısı: " + ((OtelBilgileri)dugum.veri).YildizSayisi + "E-Posta: " + ((OtelBilgileri)dugum.veri).email;
        }

        public void Bilgiler(IkiliAramaAgacDugumu dugum) {

            Ziyaret(dugum);

        }
        public void PostOrder()
        {
            dugumler = "";
            PostOrderInt(kok);
        }
        private void PostOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            PostOrderInt(dugum.sol);
            PostOrderInt(dugum.sag);
            Ziyaret(dugum);
        }
        public void Ekle(OtelBilgileri otelBilgileri)
        {
            //Yeni eklenecek düğümün parent'ı
            IkiliAramaAgacDugumu tempParent = new IkiliAramaAgacDugumu();
            //Kökten başla ve ilerle
            IkiliAramaAgacDugumu tempSearch = kok;

            while (tempSearch != null)
            {
                tempParent = tempSearch;
                //Deger var...
                if (otelBilgileri.Ad == ((OtelBilgileri) tempSearch.veri).Ad)
                    return;
                else if (otelBilgileri.Isimint < ((OtelBilgileri)tempSearch.veri).Isimint)
                    tempSearch = tempSearch.sol;
                else
                    tempSearch = tempSearch.sag;
            }
            IkiliAramaAgacDugumu eklenecek = new IkiliAramaAgacDugumu(otelBilgileri);
            //Ağaç boşsa, köke ekle...
            if (kok == null)
                kok = eklenecek;
            else if (otelBilgileri.Isimint < ((OtelBilgileri)tempParent.veri).Isimint)
                tempParent.sol = eklenecek;
            else
                tempParent.sag = eklenecek;
        }
        public IkiliAramaAgacDugumu Ara(int anahtar)
        {
            return AraInt(kok, anahtar);
        }
        private IkiliAramaAgacDugumu AraInt (IkiliAramaAgacDugumu dugum, int anahtar)
        {
            if (dugum == null)
                return null;
            else if ((int)dugum.veri == anahtar)
                return dugum;
            else if ((int)dugum.veri > anahtar)
                return (AraInt(dugum.sol, anahtar));
            else
                return (AraInt(dugum.sag, anahtar));
        }

        public IkiliAramaAgacDugumu MinDeger()
        {
            IkiliAramaAgacDugumu tempSol = kok;
            while (tempSol.sol != null)
                tempSol = tempSol.sol;
            return tempSol;
        }

        public IkiliAramaAgacDugumu MaksDeger()
        {
            IkiliAramaAgacDugumu tempSag = kok;
            while (tempSag.sag != null)
                tempSag = tempSag.sag;
            return tempSag;
        }

        private IkiliAramaAgacDugumu Successor(IkiliAramaAgacDugumu silDugum)
        {
            IkiliAramaAgacDugumu successorParent = silDugum;
            IkiliAramaAgacDugumu successor = silDugum;
            IkiliAramaAgacDugumu current = silDugum.sag;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.sol;
            }
            if (successor != silDugum.sag)
            {
                successorParent.sol = successor.sag;
                successor.sag = silDugum.sag;
            }
            return successor;
        }
        public bool OtelSil(int deger)
        {
            IkiliAramaAgacDugumu current = kok;
            IkiliAramaAgacDugumu parent = kok;
            bool solmu = true;
            //DÜĞÜMÜ BUL
            while (((OtelBilgileri)current.veri).Isimint != deger)
            {
                parent = current;
                if (deger < ((OtelBilgileri)current.veri).Isimint)
                {
                    solmu = true;
                    current = current.sol;
                }
                else
                {
                    solmu = false;
                    current = current.sag;
                }
                if (current == null)
                    return false;
            }
            //DURUM 1: YAPRAK DÜĞÜM
            if (current.sol == null && current.sag == null)
            {
                if (current == kok)
                    kok = null;
                else if (solmu)
                    parent.sol = null;
                else
                    parent.sag = null;
            }
            //DURUM 2: TEK ÇOCUKLU DÜĞÜM
            else if (current.sag == null)
            {
                if (current == kok)
                    kok = current.sol;
                else if (solmu)
                    parent.sol = current.sol;
                else
                    parent.sag = current.sol;
            }
            else if (current.sol == null)
            {
                if (current == kok)
                    kok = current.sag;
                else if (solmu)
                    parent.sol = current.sag;
                else
                    parent.sag = current.sag;
            }
            //DURUM 3: İKİ ÇOCUKLU DÜĞÜM
            else
            {
                IkiliAramaAgacDugumu successor = Successor(current);
                if (current == kok)
                    kok = successor;
                else if (solmu)
                    parent.sol = successor;
                else
                    parent.sag = successor;
                successor.sol = current.sol;
            }
            return true;
        }

        public void Guncelle(IkiliAramaAgacDugumu dugum)
        {
            OtelBilgileri otelBilgileri = (OtelBilgileri) dugum.veri;

            IkiliAramaAgacDugumu tempSearch = kok;

            while (tempSearch != null)
            {
                if (otelBilgileri.Ad == ((OtelBilgileri)tempSearch.veri).Ad)
                {
                    tempSearch.veri = otelBilgileri;
                    break;
                }
                else if (otelBilgileri.Isimint < ((OtelBilgileri)tempSearch.veri).Isimint)
                    tempSearch = tempSearch.sol;
                else
                    tempSearch = tempSearch.sag;
            }
        }


    }
}
