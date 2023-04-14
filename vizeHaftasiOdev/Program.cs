using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading.Channels;
using System.Xml;

namespace vizeHaftasiOdev
{
    internal class Siparis
    {
        public static string[] Menu = { "Çorba", "Ana Yemek", "Meze", "Tatlı", "İçecek" };
        public static int[] Fiyat = { 15, 50, 10, 40, 5 };

        string musteriAdi;
        string odemeTipi;
        int musteriSayisi;
        bool odemeDurumu;
        float toplamUcret;
        ArrayList siparisDetaylari = new ArrayList();

        public Siparis(string musteriAdi)
        {
            this.musteriAdi = musteriAdi;
        }

        //Ekrana menüyü yazdırma ve kullanıcıdan sipariş alma:
        public static void MenuYazdir()
        {
            Console.WriteLine("Menü:\n");

            for (int i = 0; i < Menu.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + Menu[i] + ": " + Fiyat[i] + "TL");
            }

            Console.WriteLine("\nİsminizi girin:\n");

            string musteriAdi = Console.ReadLine();

            Console.WriteLine("\nİstediğiniz ürünün veya ürünlerin numarasını girin. Seçme işleminizi sonlandırmak için 0 yazın.\n");
            Console.WriteLine("\nSipariş Oluştur\n");

            ArrayList liste = new ArrayList();
            ArrayList fiyat = new ArrayList();
            int secim = Convert.ToInt32(Console.ReadLine());


            while (secim > 0)
            {
                secim = Convert.ToInt32(Console.ReadLine());

                if (secim == 1)
                {
                    liste.Add(Menu[0]);
                }
                else if (secim == 2)
                {
                    liste.Add(Menu[1]);
                }
                else if (secim == 3)
                {
                    liste.Add(Menu[2]);
                }
                else if (secim == 4)
                {
                    liste.Add(Menu[3]);
                }
                else if (secim == 5)
                {
                    liste.Add(Menu[4]);
                }
                else if (secim < 0 || secim > 5)
                {
                    Console.WriteLine("Lütfen listedeki numaralardan seçim yapınız.");
                }

            }

            Console.WriteLine("\nSiparişiniz:\n");

            int toplamUcret = 0;

            foreach (string i in liste)
            {
                for (int j = 0; j < Menu.Length; j++)
                {
                    if (Menu[j] == i)
                    {
                        Console.WriteLine(Menu[j] + ": " + Fiyat[j] + " " + "TL");
                        toplamUcret += Fiyat[j];
                    }
                }
            }

            Console.WriteLine("\nÖdenecek Tutar: " + toplamUcret + " " + "TL");

            //Siparişi iptal etme veya onaylama:
            Console.WriteLine("\nSiparişi onaylıyor musunuz?:\nEvet: 1    Hayır: 0");

            int siparisonay = Convert.ToInt32(Console.ReadLine());

            if (siparisonay == 0 || siparisonay == 1)
            {
                if (siparisonay == 0)
                {
                    liste.Clear();
                    Console.WriteLine("\nSipariş sıfırlandı.");
                }
                else if (siparisonay == 1)
                {
                    Console.WriteLine("\nSipariş onaylandı.");
                    Console.WriteLine("\nSipariş, sipariş sahibi " + musteriAdi + " tarafından onaylandı:");
                }
            }
            else
            {
                Console.WriteLine("\n1 veya 0 yazın!\n\nSiparişi onaylıyor musunuz?:\nEvet: 1    Hayır: 0");

                siparisonay = Convert.ToInt32(Console.ReadLine());
            }
        }
        static void Main(string[] args)
        {
            MenuYazdir();
        }
    }



    internal class Musteri
    {
        string musteriAdi;
        ArrayList odemeBilgileri = new ArrayList();
        ArrayList siparisler = new ArrayList();

        public Musteri(string musteriAdi, ArrayList odemeBilgileri, ArrayList siparisler)
        {
            this.musteriAdi = musteriAdi;
            this.siparisler = siparisler;
            this.odemeBilgileri = odemeBilgileri;
        }

        //Ödeme bilgileri alma ve siparişi tamamlama:
        public static void OdemeBilgi()
        {
            ArrayList odemeBilgileri = new ArrayList();

            Console.WriteLine("İsim:\n");
            string musteriAdi = Console.ReadLine();
            odemeBilgileri.Add(musteriAdi);
            

            Console.WriteLine("Ödeme tipi:\n" + "Kart: 1      Nakit: 2");
            int kartnakit = Convert.ToInt32(Console.ReadLine());

            if (kartnakit == 1 || kartnakit == 2)
            {
                if (kartnakit == 1)
                {
                    string odemeTipi = "Kart";
                    odemeBilgileri.Add(odemeTipi);
                    Console.WriteLine("Kart Numarası: " + Console.ReadLine() + "\n");
                    Console.WriteLine("Kart Sahibinin Adı Soyadı: " + Console.ReadLine() + "\n");
                    Console.WriteLine("SKT: " + Console.ReadLine() + "\n");
                    Console.WriteLine("CVC Kodu: " + Console.ReadLine() + "\n");

                }
                else if (kartnakit == 2)
                {
                    string odemeTipi = "Nakit";
                    odemeBilgileri.Add(odemeTipi);
                }
            }
            else
            {
                Console.WriteLine("1 veya 2 yazınız.");
                kartnakit = Convert.ToInt32(Console.ReadLine());
            }

            foreach (int i in odemeBilgileri)
            {
                Console.WriteLine("Ödeme Bilgileri:\n");
                Console.WriteLine(odemeBilgileri);
            }

            Console.WriteLine("Siparişi tamamlamak ister misiniz");
        }
    }




    internal class Restoran
    {
        int musteriSayisi;
        ArrayList siparisler = new ArrayList();
        ArrayList musteri = new ArrayList();
        public Restoran()
        {
            this.musteriSayisi = new int();
            this.siparisler = new ArrayList();
        }

        //Müşteri sayma:
        public static void MusteriSay()
        {
            int musteriSayisi;
            ArrayList siparisler = new ArrayList();
            ArrayList musteriler = new ArrayList();

            musteriSayisi = musteriler.Count;
            Console.WriteLine("Müşteri Sayısı: " + musteriSayisi);
        }

        //Siparişleri tutma:
        public static void Siparisler()
        {
            int siparissayisi;
            ArrayList siparisler = new ArrayList();

            siparissayisi = siparisler.Count;

            Console.WriteLine("Sipariş Sayısı: " + siparissayisi  + "\n");
            Console.WriteLine("Siparişler: \n");
            foreach (int i in siparisler)
            {
                Console.WriteLine(i);
            }
        }

    }
}