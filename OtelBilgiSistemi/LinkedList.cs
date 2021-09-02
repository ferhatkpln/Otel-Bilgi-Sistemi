using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelBilgiSistemi
{
    public class LinkedList : LinkedListADT
    {
        public override node GetElement(object position)
        {
            //Geri dönülecek eleman
            node retNode = null;
            //Head'den başlanarak Next node'a gidilecek
            node tempNode = head;
            int count = 0;

            while (tempNode != null)
            {
                if (((PersonelBilgileri) tempNode.Data).KimlikNo == ((PersonelBilgileri) position).KimlikNo)
                {
                    retNode = tempNode;
                    break;
                }
                //Next node'a git
                tempNode = tempNode.Next;
                count++;
            }
            return retNode;
        }

        public override void Insert(object value)
        {
            node oldLast = head;
            node newLast = new node
            {
                Data = value
            };
            node retNode = null;
            //Head'den başlanarak Next node'a gidilecek
            node tempNode = head;
            while (tempNode != null)
            {
                if (((PersonelBilgileri) tempNode.Data).KimlikNo == ((PersonelBilgileri)newLast.Data).KimlikNo)
                {

                    System.Windows.Forms.MessageBox.Show("Bu kayıtta personel bulunmakta..");
                    return;
                }
                //Next node'a git
                tempNode = tempNode.Next;

            }

            if (head == null)
                head = newLast;
            else
            {
                while (oldLast != null)
                {
                    if (oldLast.Next != null)
                        oldLast = oldLast.Next;
                    else
                        break;
                }

                oldLast.Next = newLast;

            }
        }

        public string PersonelBilgiGetir()
        {
            string temp = "";
            node item = head;
            while (item != null)
            {
                PersonelBilgileri personel = (PersonelBilgileri) item.Data;
                temp += "Adi : " + personel.Ad +
                        "soyad : " + personel.Soyad +
                        " tck  : " + personel.KimlikNo +
                        " Gorevi : " + personel.Pozisyon +
                        " puan : " + personel.PersonelPuan + Environment.NewLine;
                item = item.Next;
            }

            return temp;
        }

        public void PersonelBilgiGüncelle(PersonelBilgileri personel)
        {

            //Geri dönülecek eleman
            node retNode = null;
            //Head'den başlanarak Next node'a gidilecek
            node tempNode = head;
            int count = 0;

            while (tempNode != null)
            {
                if (((PersonelBilgileri)tempNode.Data).KimlikNo == personel.KimlikNo)
                {
                    retNode = tempNode;
                    retNode.Data = personel;
                    break;
                }
                //Next node'a git
                tempNode = tempNode.Next;
                count++;
            }
            if (retNode == null)
            {
                System.Windows.Forms.MessageBox.Show("Kimlik Numarası yanlış...");
            }

        }

        public string DepartmanListe(string departman)
        {
            string temp = "";
            node item = head;
            while (item != null)
            {
                if (departman == ((PersonelBilgileri)item.Data).Departman)
                {
                    PersonelBilgileri p = (PersonelBilgileri)item.Data;
                    temp += "Adi : " + p.Ad +
                            "soyad : " + p.Soyad +
                            " tck  : " + p.KimlikNo +
                            " Gorevi : " + p.Pozisyon +
                            " puan : " + p.PersonelPuan + Environment.NewLine;
                }
                item = item.Next;
            }

            return temp;
        }
    }
}
