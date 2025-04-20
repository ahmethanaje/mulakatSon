using System.Runtime.CompilerServices;

namespace backEnd_cs
{

    internal class Program

    {
        private static void urunGuncelle(string dosyaPath, ref Dictionary<string, int> değişecekVeriGrubu, string idNO, int eskiStok, string karar)
        {
            int yeniStok = 0;
            int yeniFiyat = 0;
            if (karar == "1")
            {
                Console.WriteLine("Stok Verisi Güncellenecektir...");
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Yeni Stok Sayısı: ");
                Console.ForegroundColor = ConsoleColor.Red;
                yeniStok = Convert.ToInt16(Console.ReadLine());
                değişecekVeriGrubu[idNO] = yeniStok;
                string path = dosyaPath + "\\" + idNO + ".txt";
                string[] satirlar = File.ReadAllLines(path);
                for (int i = 0; i < satirlar.Length; i++)
                {
                    if (satirlar[i][0] == 'S')
                    {
                        satirlar[i] = "Stok: " + yeniStok;
                    }
                }
                File.WriteAllLines(path, satirlar);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("İşlem Başarıyla Gerçekleştirildi..");

            }
            else if (karar == "2")
            {
                Console.WriteLine("Fiyat Verisi Güncellenecektir...");
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Yeni Fiyat : ");
                Console.ForegroundColor = ConsoleColor.Red;
                yeniFiyat = Convert.ToInt32(Console.ReadLine());
                değişecekVeriGrubu[idNO] = yeniFiyat;
                Console.ResetColor();
                string path = dosyaPath + "\\" + idNO + ".txt";
                string[] satirlar = File.ReadAllLines(path);
                for (int i = 0; i < satirlar.Length; i++)
                {
                    if (satirlar[i][0] == 'F')
                    {
                        satirlar[i] = "Fiyat: " + yeniFiyat;
                    }
                }
                File.WriteAllLines(path, satirlar);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("İşlem Başarıyla Gerçekleştirildi..");
            }
            else
            {
                Console.WriteLine("Hatalı Giriş...");
            }

            Console.WriteLine("Menüye Yönlendiriliyorsunuz...");
            Thread.Sleep(2500);
        }
        private static void veriDegistir(string kullaniciPath, string kullaniciAdi, ref string degisecekVeri, string karar)
        {
            Console.Clear();
            if (karar == "1")
            {
                Console.WriteLine("Adres Verisi Güncellenecektir...");
                Console.WriteLine("Yeni Adres Bilginizi Giriniz ...");
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Şehir: ");
                Console.ForegroundColor = ConsoleColor.Red;
                string yeniSehir = Console.ReadLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("İlçe: ");
                Console.ForegroundColor = ConsoleColor.Red;
                string yeniIlce = Console.ReadLine();
                degisecekVeri = yeniSehir + "/" + yeniIlce;
                string kullaniciDosyaKonumu = kullaniciPath + "\\" + kullaniciAdi + ".txt";
                string[] satirlar = File.ReadAllLines(kullaniciDosyaKonumu);
                for (int i = 0; i < satirlar.Length; i++)
                {
                    if (satirlar[i][0] == 'A')
                    {
                        satirlar[i] = "Adres: " + degisecekVeri;
                    }

                }
                File.WriteAllLines(kullaniciDosyaKonumu, satirlar);
                Console.WriteLine("Adres Başarıyla Değiştirilmiştir...");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else if (karar == "2")
            {
                Console.WriteLine("Telefon Numarası Verisi Güncellenecektir...");
                Console.WriteLine("Yeni Telefon Numarası Bilginizi Giriniz ...");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Yeni Telefon Numarası: ");
                Console.ForegroundColor = ConsoleColor.Red;
                string yeniTelNo = Console.ReadLine();
                degisecekVeri = yeniTelNo;
                string kullaniciDosyaKonumu = kullaniciPath + "\\" + kullaniciAdi + ".txt";
                string[] satirlar = File.ReadAllLines(kullaniciDosyaKonumu);
                for (int i = 0; i < satirlar.Length; i++)
                {
                    if (satirlar[i][0] == 'T')
                    {
                        satirlar[i] = "Telefon No: " + degisecekVeri;
                    }

                }
                File.WriteAllLines(kullaniciDosyaKonumu, satirlar);
                Console.WriteLine("Telefon Numarası Başarıyla Değiştirilmiştir...");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else if (karar == "3")
            {
                Console.WriteLine("Mail Verisi Güncellenecektir...");
                Console.WriteLine("Yeni Mail Bilginizi Giriniz ...");
                Console.WriteLine("-------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Yeni Mail: ");
                Console.ForegroundColor = ConsoleColor.Red;
                string yeniMail = Console.ReadLine();
                degisecekVeri = yeniMail;
                string kullaniciDosyaKonumu = kullaniciPath + "\\" + kullaniciAdi + ".txt";
                string[] satirlar = File.ReadAllLines(kullaniciDosyaKonumu);
                for (int i = 0; i < satirlar.Length; i++)
                {
                    if (satirlar[i][0] == 'M')
                    {
                        satirlar[i] = "Mail: " + degisecekVeri;
                    }

                }
                File.WriteAllLines(kullaniciDosyaKonumu, satirlar);
                Console.WriteLine("Mail Başarıyla Değiştirilmiştir...");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Hatalı Veri Girdiniz...");
                Thread.Sleep(1500);
                Console.Clear();
            }

        }
        private static void sifreDegistirme(string path, string kullaniciadi, ref string sifre, string gerceksifre, string denenensifre, ref bool onay, out string degisenSifre)
        {
            Random random = new Random();
            degisenSifre = "";
            int sayi1 = random.Next(0, 9);
            int sayi2 = random.Next(0, 9);
            int sonuc = sayi1 + sayi2;
            Console.WriteLine(sayi1 + "+" + sayi2 + " ?");
            int cevap = Convert.ToInt16(Console.ReadLine());
            if (cevap == sonuc && denenensifre == gerceksifre)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Verilen cevaplar doğrudur...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------");
                Console.WriteLine("Yeni Sifre Ne Olsun ?");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                string yeniSifre = Console.ReadLine();
                degisenSifre = sifre;
                onay = true;
                string[] yenidosyaSatirlari = File.ReadAllLines(path + "\\" + kullaniciadi + ".txt");
                for (int i = 0; i < yenidosyaSatirlari.Length; i++)
                {
                    if (yenidosyaSatirlari[i][0] == 'Ş')
                    {
                        sifre = yeniSifre;
                        yenidosyaSatirlari[i] = "Şifre: " + sifre;
                    }
                }
                File.WriteAllLines(path + "\\" + kullaniciadi + ".txt", yenidosyaSatirlari);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("İşlem Başarıyla Sonuclanmıştır...");
                Console.WriteLine("Ana Sayfaya Yönlendiriliyorsunuz...");
                Thread.Sleep(3000);
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                onay = false;
                Console.WriteLine("HATALI GİRİŞ ...");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

            }
        }
        private static void kullaniciadiDegistirme(string path, ref string kullaniciadi, string gerceksifre, string denenensifre, ref bool karar, out string degisenKullaniciAdi)
        {
            Random random = new Random();
            int sayi1 = random.Next(0, 9);
            int sayi2 = random.Next(0, 9);
            int sonuc = sayi1 + sayi2;
            Console.WriteLine(sayi1 + "+" + sayi2 + " ?");
            degisenKullaniciAdi = "";
            int cevap = Convert.ToInt16(Console.ReadLine());
            if (cevap == sonuc && denenensifre == gerceksifre)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Verilen cevaplar doğrudur...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------");
                Console.WriteLine("Yeni Kullanıcı Adı Ne Olsun ?");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                string yeniKullaniciAdi = Console.ReadLine();
                string eskiDosyaYolu = Path.Combine(path, kullaniciadi + ".txt");
                string yeniDosyaYolu = Path.Combine(path, yeniKullaniciAdi + ".txt");
                File.Move(eskiDosyaYolu, yeniDosyaYolu);
                degisenKullaniciAdi = kullaniciadi;
                kullaniciadi = yeniKullaniciAdi;
                string[] yenidosyaSatirlari = File.ReadAllLines(yeniDosyaYolu);
                for (int i = 0; i < yenidosyaSatirlari.Length; i++)
                {
                    if (yenidosyaSatirlari[i].StartsWith("Kullanıcı Adı:"))
                    {
                        yenidosyaSatirlari[i] = "Kullanıcı Adı: " + kullaniciadi;
                    }
                }
                File.WriteAllLines(yeniDosyaYolu, yenidosyaSatirlari);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("İşlem Başarıyla Sonuclanmıştır...");
                karar = true;
                Console.WriteLine("Ana Sayfaya Yönlendiriliyorsunuz...");
                Thread.Sleep(3000);
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("HATALI GİRİŞ ...");
                karar = false;
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
            }
        }
        private static void sifreKontrol(Dictionary<string, string> sifreHavuzu, string id, string sifre, ref bool sonuc, string kullaniciPath)
        {
            if (sifreHavuzu.ContainsKey(id) == true && sifreHavuzu[id] == sifre)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Giriş Yapılıyor..");
                Thread.Sleep(1000);
                sonuc = true;
                Console.Clear();
            }
            else if (sifreHavuzu.ContainsKey(id) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sistemde Böyle Bir Kullanıcı Adı Mevcut Değildir..!");
                Console.WriteLine("Girişe Yönlendiriliyorsunuz...");
                Thread.Sleep(2500);
                sonuc = false;
                Console.Clear();
            }
            else if (sifreHavuzu.ContainsKey(id) == true && sifreHavuzu[id] != sifre)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hatalı Şifre Girdiniz!");
                Console.WriteLine("══════════════════════════════════════");
                Console.WriteLine("1 - Şifremi Unuttum (Sıfırlama)");
                Console.WriteLine("0 - Ana Menüye Dön");
                Console.WriteLine("══════════════════════════════════════");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("══════════════════════════════════════");
                    Console.WriteLine("          ŞİFRE SIFIRLMA             ");
                    Console.WriteLine("══════════════════════════════════════");

                    Random rnd = new Random();
                    int sayi1 = rnd.Next(0, 10);
                    int sayi2 = rnd.Next(0, 10);
                    int toplam = sayi1 + sayi2;

                    Console.Write("Güvenlik Sorusu: {0} + {1} = ", sayi1, sayi2);
                    int cevap;
                    try
                    {
                        cevap = Convert.ToInt16(Console.ReadLine());
                    }
                    catch
                    {
                        cevap = -1;
                    }

                    if (cevap == toplam)
                    {
                        Console.Write("Yeni Şifrenizi Girin: ");
                        string yeniSifre = Console.ReadLine();


                        sifreHavuzu[id] = yeniSifre;


                        string dosyaYolu = Path.Combine(kullaniciPath, id + ".txt");
                        string[] satirlar = File.ReadAllLines(dosyaYolu);

                        for (int i = 0; i < satirlar.Length; i++)
                        {
                            if (satirlar[i].StartsWith("Şifre:"))
                            {
                                satirlar[i] = "Şifre: " + yeniSifre;
                            }
                        }

                        File.WriteAllLines(dosyaYolu, satirlar);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Şifreniz başarıyla güncellendi!");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Güvenlik sorusunu yanlış cevapladınız!");
                        Thread.Sleep(2000);
                    }
                }
                else if (secim == "0")
                {
                    // Ana menüye dön
                    sonuc = false;
                    Console.Clear();
                    return;
                }

                sonuc = false;
                Console.Clear();
            }
            else
            {
                sonuc = false;
                Console.Clear();
            }
        }



        //----------------------------------------------------********************************************************************************-------------------------------------------------------------------------------




        static void Main(string[] args)
        {
            string adminId = "";
            string adminSifre = "";
            string kullaniciAdi = "";
            string sifre = "";
            string mail = "";
            string telNo = "";
            string adres = "";
            // DOSYALAR- ------------------------------------------------------------------------------------------------------------------------------
            Random random = new Random();
            Console.Title = "BackEnd";
            Dictionary<string, string> sifreler = new Dictionary<string, string>();
            Dictionary<string, string> adminSifreleri = new Dictionary<string, string>();
            Dictionary<string, int> urunFiyatlari = new Dictionary<string, int>();
            Dictionary<string, int> urunStoklari = new Dictionary<string, int>();
            Dictionary<string, string> urunMarkalari = new Dictionary<string, string>();
            Dictionary<string, string> urunKategorileri = new Dictionary<string, string>();
            Dictionary<string, string> urunRenkleri = new Dictionary<string, string>();
            Dictionary<string, string> urunTurleri = new Dictionary<string, string>();
            Dictionary<string, string> telefonlar = new Dictionary<string, string>();
            Dictionary<string, string> mailler = new Dictionary<string, string>();
            Dictionary<string, string> adresler = new Dictionary<string, string>();
            Dictionary<string, string> sepetim = new Dictionary<string, string>();

            //yanda olan dosyaları Cnin içine atınız..
            string kullaniciPath = "C:\\backend\\kullanicilar";
            string adminPath = "C:\\backend\\adminler";
            string urunPath = "C:\\backend\\ürünler";
            //-------------------------------------------------------------------------------------------------------------------------------------------
            /*
             --------------------------------------------------------------------------------------------------------------------DOSYA OKUMA BÖLÜMÜ---------------------------------------------------------------------------
                                      */

            //----------------------------------------------------------------------------------------------------------------------------------------------
            // KAYITLI DOSYALARI OKUMA (kullanıcı şifreleri-telefon no-mail-adres-sepet)
            string[] kullaniciDosyalari = Directory.GetFiles(kullaniciPath);
            List<string> kullaniciDosyaAdlari = new List<string>();
            foreach (string eklenecek in kullaniciDosyalari)
            {
                string txtAdi = Path.GetFileName(eklenecek);
                kullaniciDosyaAdlari.Add(txtAdi);
            }

            for (int i = 0; i < kullaniciDosyaAdlari.Count; i++)
            {
                string[] kullaniciSatirlari = File.ReadAllLines(kullaniciPath + "\\" + kullaniciDosyaAdlari[i]);
                string eklenecekKullaniciAdi = "";
                string eklenecekSifre = "";
                string eklenecekTelNo = "";
                string eklenecekMail = "";
                string eklenecekAdres = "";
                string eklenecekSepet = "";
                for (int j = 0; j < kullaniciSatirlari.Length; j++)
                {
                    if (kullaniciSatirlari[j][0] == 'K')
                    {
                        for (int k = 15; k < kullaniciSatirlari[j].Length; k++)
                        {
                            eklenecekKullaniciAdi += kullaniciSatirlari[j][k];
                        }
                    }
                    else if (kullaniciSatirlari[j][0] == 'Ş')
                    {
                        for (int k = 7; k < kullaniciSatirlari[j].Length; k++)
                        {
                            eklenecekSifre += kullaniciSatirlari[j][k];
                        }
                    }
                    else if (kullaniciSatirlari[j][0] == 'T')
                    {
                        for (int k = 12; k < kullaniciSatirlari[j].Length; k++)
                        {
                            eklenecekTelNo += kullaniciSatirlari[j][k];
                        }
                    }
                    else if (kullaniciSatirlari[j][0] == 'M')
                    {
                        for (int k = 6; k < kullaniciSatirlari[j].Length; k++)
                        {
                            eklenecekMail += kullaniciSatirlari[j][k];
                        }
                    }
                    else if (kullaniciSatirlari[j][0] == 'A')
                    {
                        for (int k = 7; k < kullaniciSatirlari[j].Length; k++)
                        {
                            eklenecekAdres += kullaniciSatirlari[j][k];
                        }
                    }
                    else if (kullaniciSatirlari[j][0] == 'S')
                    {
                        for (int k = 7; k < kullaniciSatirlari[j].Length; k++)
                        {
                            eklenecekSepet += kullaniciSatirlari[j][k];
                        }
                    }

                }
                sifreler[eklenecekKullaniciAdi] = eklenecekSifre;
                telefonlar[eklenecekKullaniciAdi] = eklenecekTelNo;
                mailler[eklenecekKullaniciAdi] = eklenecekMail;
                adresler[eklenecekKullaniciAdi] = eklenecekAdres;
                sepetim[eklenecekKullaniciAdi] = eklenecekSepet;
            }





            //kayıtlı adminleri okuma
            string[] admindosyaYollari = Directory.GetFiles(adminPath);
            List<string> adminDosyaAdlari = new List<string>();
            foreach (string txtAdlar in admindosyaYollari)
            {
                string eklenecekTxt = Path.GetFileName(txtAdlar);
                adminDosyaAdlari.Add(eklenecekTxt);
            }
            for (int i = 0; i < adminDosyaAdlari.Count; i++)
            {
                string[] adminSatirlari = File.ReadAllLines(adminPath + "\\" + adminDosyaAdlari[i]);
                string eklenecekAdminId = "";
                string eklenecekAdminSifre = "";
                for (int j = 0; j < adminSatirlari.Length; j++)
                {
                    if (adminSatirlari[j][0] == 'İ')
                    {
                        for (int k = 4; k < adminSatirlari[j].Length; k++)
                        {
                            eklenecekAdminId += adminSatirlari[j][k];
                        }
                    }
                    else if (adminSatirlari[j][0] == 'Ş')
                    {
                        for (int k = 7; k < adminSatirlari[j].Length; k++)
                        {
                            eklenecekAdminSifre += adminSatirlari[j][k];
                        }
                    }
                    adminSifreleri[eklenecekAdminId] = eklenecekAdminSifre;
                }
            }



            //******************************************************************
            // KAYITLI ÜRÜNLERİ OKUMA
            string[] urunlerinUzunDosyaYollari = Directory.GetFiles(urunPath);
            List<string> urunlerinDosyaAdlari = new List<string>();
            foreach (string kisaAdBul in urunlerinUzunDosyaYollari)
            {
                string urunlerinDosyasininTxtAdi = Path.GetFileName(kisaAdBul);
                urunlerinDosyaAdlari.Add(urunlerinDosyasininTxtAdi);
            }
            for (int i = 0; i < urunlerinDosyaAdlari.Count; i++)
            {
                string[] dosyadakiSatirlar = File.ReadAllLines(urunPath + "\\" + urunlerinDosyaAdlari[i]);
                string eklenecekTur = "";
                string eklenecekMarka = "";
                string eklenecekFiyat = "";
                string eklenecekStok = "";
                string eklenecekİd = "";
                string eklenecekRenk = "";
                string eklenecekKategori = "";

                for (int j = 0; j < dosyadakiSatirlar.Length; j++)
                {
                    if (dosyadakiSatirlar[j][0] == 'T')
                    {
                        for (int k = 5; k < dosyadakiSatirlar[j].Length; k++)
                        {
                            eklenecekTur += dosyadakiSatirlar[j][k];
                        }
                    }
                    else if (dosyadakiSatirlar[j][0] == 'M')
                    {
                        for (int k = 7; k < dosyadakiSatirlar[j].Length; k++)
                        {
                            eklenecekMarka += dosyadakiSatirlar[j][k];
                        }
                    }
                    else if (dosyadakiSatirlar[j][0] == 'İ')
                    {
                        for (int k = 4; k < dosyadakiSatirlar[j].Length; k++)
                        {
                            eklenecekİd += dosyadakiSatirlar[j][k];
                        }
                    }
                    else if (dosyadakiSatirlar[j][0] == 'F')
                    {
                        for (int k = 7; k < dosyadakiSatirlar[j].Length; k++)
                        {
                            eklenecekFiyat += dosyadakiSatirlar[j][k];
                        }
                    }
                    else if (dosyadakiSatirlar[j][0] == 'S')
                    {
                        for (int k = 6; k < dosyadakiSatirlar[j].Length; k++)
                        {
                            eklenecekStok += dosyadakiSatirlar[j][k];
                        }
                    }

                    else if (dosyadakiSatirlar[j][0] == 'R')
                    {
                        for (int k = 6; k < dosyadakiSatirlar[j].Length; k++)
                        {
                            eklenecekRenk += dosyadakiSatirlar[j][k];
                        }
                    }
                    else if (dosyadakiSatirlar[j][0] == 'K')
                    {
                        for (int k = 10; k < dosyadakiSatirlar[j].Length; k++)
                        {
                            eklenecekKategori += dosyadakiSatirlar[j][k];
                        }
                    }

                }
                int eklenecekFiyatINT = Convert.ToInt32(eklenecekFiyat);
                int eklenecekStokINT = Convert.ToInt32(eklenecekStok);
                urunFiyatlari[eklenecekİd] = eklenecekFiyatINT;
                urunMarkalari[eklenecekİd] = eklenecekMarka;
                urunRenkleri[eklenecekİd] = eklenecekRenk;
                urunStoklari[eklenecekİd] = eklenecekStokINT;
                urunTurleri[eklenecekİd] = eklenecekTur;
                urunKategorileri[eklenecekİd] = eklenecekKategori;

            }
            //                          ******************************************************************************************











            //
            byte sifreSayaci = 0;
            bool kullaniciMi = false;
            bool adminMi = false;

            List<string> kullaniciAdlari = new List<string>();
            foreach (string kullaniciAdi2 in sifreler.Keys)
            {
                kullaniciAdlari.Add(kullaniciAdi2);
            }
            //
            // 
            //            ---------------------------------------------------------------------------------------GİRİŞ EKRANI
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;


                string[] girisEkrani = {
            "════════════════════════════════════════════",
            "                                            ",
            "            HOŞGELDİNİZ - GİRİŞ EKRANI      ",
            "                                            ",
            "════════════════════════════════════════════"
        };

                foreach (string satir in girisEkrani)
                {
                    Console.WriteLine(satir);
                    Thread.Sleep(20);
                }

                Thread.Sleep(400);

                // GİRİŞ EKRANI------------------------------------------------------------
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("════════════════════════════════════════════");
                Console.WriteLine("1.  Kullanıcı Girişi                  ");
                Thread.Sleep(200);
                Console.WriteLine("2.  Kayıt Ol                          ");
                Thread.Sleep(200);
                Console.WriteLine("3.  Admin Girişi                     ");
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("0.  Çıkış                         ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("════════════════════════════════════════════");

                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nLütfen bir seçenek girin (0-3): ");
                Console.ResetColor();
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    bool sonuc = false;
                    Console.Clear();
                    Console.Title = "Kullanıcı Giriş Paneli";

                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("══════════════════════════════════════");
                    Console.WriteLine("          KULLANICI GİRİŞİ           ");
                    Console.WriteLine("══════════════════════════════════════");
                    Console.WriteLine("  Lütfen bilgilerinizi giriniz.      ");
                    Console.WriteLine("══════════════════════════════════════");
                    Console.ResetColor();

                    Thread.Sleep(1000);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("           Kullanıcı Adı:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string kullaniciGiris = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("           Sifre: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string sifreGiris = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("");
                    sifreSayaci++;
                    sifreKontrol(sifreler, kullaniciGiris, sifreGiris, ref sonuc, kullaniciPath);
                    if (sonuc == true)
                    {
                        kullaniciMi = true;
                        kullaniciAdi = kullaniciGiris;
                        sifre = sifreGiris;
                        break;
                    }
                    if (sifreSayaci == 3)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("3 Defa Hatalı Giriş Yaptınız!!!");
                        for (int sn = 10; sn >= 0; sn--)
                        {
                            Console.WriteLine("{0} saniye bekleyiniz..", sn);
                            Thread.Sleep(1000);
                            Console.Clear();
                            if (sn == 0)
                            {
                                sifreSayaci = 0;
                            }
                        }
                    }
                    Console.Clear();
                }
                else if (secim == "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;

                    string[] panel = {
            "════════════════════════════════════════════════════",
            "                                                    ",
            "           YENİ KULLANICI KAYIT SİSTEMİ             ",
            "                                                    ",
            "════════════════════════════════════════════════════",
            "  Lütfen aşağıdaki bilgileri eksiksiz doldurunuz.  ",
            "════════════════════════════════════════════════════"
        };

                    foreach (string satir in panel)
                    {
                        Console.WriteLine(satir);
                        Thread.Sleep(200);
                    }

                    Thread.Sleep(300);
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine();
                    string yeniID;
                    string yenitelNo;
                    string yeniadres;
                    string yenimail;
                    string yeniSifre;
                    while (true)
                    {
                        Console.Write("Kullanıcı Adı: ");
                        yeniID = Console.ReadLine();
                        if (sifreler.ContainsKey(yeniID))
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Bu Kullanıcı Adı Sistemde Mevcuttur!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine();
                    Console.Write("Şifre: ");
                    yeniSifre = Console.ReadLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("***Şifrenizi Tekrar Giriniz***");
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Şifre Tekrar: ");
                    string sifreKontrol = Console.ReadLine();
                    if (sifreKontrol != yeniSifre)
                    {
                        Console.Clear();
                        Console.WriteLine("ŞİFRELER AYNI DEĞİL...");
                        Console.WriteLine("ANA SAYFAYA YÖNLENDİRİLİYORSUNUZ...");
                        Thread.Sleep(2500);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("════════════════════════════════════════════");
                        Console.Write("Kullanıcı Adı: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(yeniID);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Şifre: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(yeniSifre);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("════════════════════════════════════════════");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("Telefon No: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        yenitelNo = Console.ReadLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("Mail: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        yenimail = Console.ReadLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("Adres: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        yeniadres = Console.ReadLine();
                        Console.WriteLine();
                        int sayi1 = random.Next(0, 10);
                        int sayi2 = random.Next(0, 10);
                        int sonuc = sayi1 + sayi2;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("***********************");
                        Console.WriteLine("GÜVENLİK SORUSU= " + sayi1 + " + " + sayi2 + " ?");
                        Console.WriteLine("***********************");
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.White;

                            int cevap = Convert.ToInt16(Console.ReadLine());
                            if (cevap == sonuc)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Cevap Doğru..");
                                Console.WriteLine("***Kaydınız Başarıyla Tamamlanmıştır***");
                                Console.ForegroundColor = ConsoleColor.White;
                                kullaniciAdlari.Add(yeniID);
                                sifreler[yeniID] = yeniSifre;
                                mailler[yeniID] = yenimail;
                                adresler[yeniID] = yeniadres;
                                telefonlar[yeniID] = yenitelNo;
                                File.Create(kullaniciPath + "\\" + yeniID + ".txt").Close();
                                List<string> yeniTxt = new List<string>();
                                yeniTxt.Add("Kullanıcı Adı: " + yeniID);
                                yeniTxt.Add("Şifre: " + yeniSifre);
                                yeniTxt.Add("Telefon No: " + yenitelNo);
                                yeniTxt.Add("Mail: " + yenimail);
                                yeniTxt.Add("Adres: " + yeniadres);
                                File.WriteAllLines(kullaniciPath + "\\" + yeniID + ".txt", yeniTxt);
                                Console.WriteLine("Girişe Yönlendiriliyorsunuz...");
                                Thread.Sleep(1000);
                                Console.Clear();

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Cevap Yanlış...");
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                        }
                        catch
                        {
                            Console.WriteLine("BİR HATA OLUŞTU!");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }


                    }

                }
                else if (secim == "3")
                {
                    bool sonuc = false;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("════════════════════════════════════════");
                    Console.WriteLine("        ADMİN PANELİ GİRİŞ EKRANI       ");
                    Console.WriteLine("════════════════════════════════════════");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Kullanıcı Adı: ");
                    string kullaniciGiris = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Sifre: ");
                    string sifreGiris = Console.ReadLine();
                    Console.WriteLine("");
                    sifreSayaci++;
                    sifreKontrol(adminSifreleri, kullaniciGiris, sifreGiris, ref sonuc, adminPath);
                    if (sonuc == true)
                    {
                        adminMi = true;
                        sifreSayaci = 0;
                        adminId = kullaniciGiris;
                        adminSifre = sifreGiris;
                        break;
                    }
                    if (sifreSayaci == 3)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("3 Defa Hatalı Giriş Yaptınız!!!");
                        for (int sn = 10; sn >= 0; sn--)
                        {
                            Console.WriteLine("{0} saniye bekleyiniz..", sn);
                            Thread.Sleep(1000);
                            Console.Clear();
                            if (sn == 0)
                            {
                                sifreSayaci = 0;
                            }
                        }
                    }
                    Console.Clear();

                }
                else if (secim == "0")
                {
                    Console.WriteLine("Çıkış Yapılıyor.. :)");
                    Thread.Sleep(1500);
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı Veri Girdiniz.. Tekrar Deneyiniz! ");
                    Thread.Sleep(1500);
                }







            }



            // ---------------***************--------------****************KULLANICI GİRİŞ PANELİ     ------------****************---------------------------
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            while (kullaniciMi)
            {
                adres = adresler[kullaniciAdi];
                mail = mailler[kullaniciAdi];
                telNo = telefonlar[kullaniciAdi];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("════════════════════════════════════ ");
                Console.WriteLine("           KULLANICI PANELİ        ");
                Console.WriteLine("════════════════════════════════════ ");
                Console.WriteLine($"  Kullanıcı Adı : {kullaniciAdi,-20}");
                Console.WriteLine($"  Şifre         : {sifre,-20}     ");
                Console.WriteLine("════════════════════════════════════");
                Console.ResetColor();
                Console.WriteLine("1 -> Profil Düzenle");
                Console.WriteLine("2 -> Sepetim");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("════════════════════════════════════════════════════════");
                Console.WriteLine("                     ÜRÜN KATEGORİSİ                    ");
                Console.WriteLine("════════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("════════════════════════════════════════════════════════");
                Console.WriteLine("A -> TEKNOLOJİ");
                Console.WriteLine("B -> GİYİM");
                Console.WriteLine("C -> EV EŞYASI");
                Console.WriteLine("D -> TÜM ÜRÜNLER");
                Console.WriteLine("════════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.Write("Seçiminiz:");
                string secim = Console.ReadLine();


                if (secim == "1")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        string baslik = "***PROFİL DÜZENLE***";
                        for (int i = 0; i < baslik.Length; i++)
                        {
                            Console.Write(baslik[i]);
                            Thread.Sleep(70);
                        }
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("------------------");
                        Console.WriteLine("1 -> Kullanıcı Adı Değiş");
                        Console.WriteLine("2 -> Şifre Değiş");
                        Console.WriteLine("3 -> Kullanıcı Bilgilerini Güncelle");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("0 -> Ana Ekrana Dön");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("------------------");
                        Console.WriteLine("");
                        Console.Write("SEÇİMİNİZ: ");
                        string secim2 = Console.ReadLine();
                        if (secim2 == "1")
                        {
                            bool onay = true;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Bu işlemi yapabilmeniz için şifrenizi girmeniz ve ekrandaki doğrulama işlemini yapmanız gerekmektedir!");
                            Thread.Sleep(3000);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("GÜNCEL ŞİFRENİZ: ");
                            string dogrulamaSifresi = Console.ReadLine();
                            kullaniciadiDegistirme(kullaniciPath, ref kullaniciAdi, sifre, dogrulamaSifresi, ref onay, out string degisenkullaniciAdi);
                            if (onay == true)
                            {

                                sifreler.Remove(degisenkullaniciAdi);
                                adresler[kullaniciAdi] = adresler[degisenkullaniciAdi];
                                adresler.Remove(degisenkullaniciAdi);
                                sepetim[kullaniciAdi] = sepetim[degisenkullaniciAdi];
                                sepetim.Remove(degisenkullaniciAdi);
                                telefonlar[kullaniciAdi] = telefonlar[degisenkullaniciAdi];
                                telefonlar.Remove(degisenkullaniciAdi);
                                mailler[kullaniciAdi] = mailler[degisenkullaniciAdi];
                                mailler.Remove(degisenkullaniciAdi);
                                sifreler.Add(kullaniciAdi, sifre);
                            }
                            else if (onay == false)
                            {
                                Console.WriteLine("BİR HATA OLUŞTU..SİSTEMDE AYNI İSİMDE BİR DOSYA VAR...  BAŞKA BİR KULLANICI ADIYLA TEKRAR DENEYİNİZ");
                                Thread.Sleep(2000);
                            }

                        }
                        else if (secim2 == "2")
                        {
                            bool onay = true;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Bu işlemi yapabilmeniz için şifrenizi girmeniz ve ekrandaki doğrulama işlemini yapmanız gerekmektedir!");
                            Thread.Sleep(3000);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("GÜNCEL ŞİFRENİZ: ");
                            string dogrulamaSifresi = Console.ReadLine();
                            sifreDegistirme(kullaniciPath, kullaniciAdi, ref sifre, sifre, dogrulamaSifresi, ref onay, out string degisenSifre);
                            if (onay == true)
                            {
                                sifreler[kullaniciAdi] = sifre;
                            }
                        }
                        else if (secim2 == "3")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("GÜNCEL BİLGİLERİNİZ");
                            Console.WriteLine("*******************");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("1) Adres: " + adresler[kullaniciAdi]);
                            Console.WriteLine("2) Telefon No: " + telefonlar[kullaniciAdi]);
                            Console.WriteLine("3) Mail: " + mailler[kullaniciAdi]);
                            Console.WriteLine("Sepet: " + sepetim[kullaniciAdi]);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("*******************");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.Write("Değiştirmek İstediğiniz Verinizi Seçiniz: ");
                            string secim3 = Console.ReadLine();
                            if (secim3 == "1")
                            {
                                veriDegistir(kullaniciPath, kullaniciAdi, ref adres, secim3);
                                adresler[kullaniciAdi] = adres;
                            }
                            else if (secim3 == "2")
                            {
                                veriDegistir(kullaniciPath, kullaniciAdi, ref telNo, secim3);
                                telefonlar[kullaniciAdi] = telNo;

                            }
                            else if (secim3 == "3")
                            {
                                veriDegistir(kullaniciPath, kullaniciAdi, ref mail, secim3);
                                mailler[kullaniciAdi] = mail;
                            }
                        }
                        else if (secim2 == "0")
                        {
                            Console.WriteLine("Kullanıcı Paneline Geri Dönülüyor..");
                            Thread.Sleep(1500);
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("HATALI GİRİŞ !");
                        }
                    }

                }
                else if (secim == "2")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("     _______");
                        Console.WriteLine("    /       \\");
                        Console.WriteLine("   /         \\");
                        Console.WriteLine("     SEPETİM   ");
                        Console.WriteLine("  |           |");
                        Console.WriteLine("  |___________|");
                        Console.WriteLine();
                        Console.ResetColor();
                        foreach (string keys in sepetim.Keys)
                        {
                            Console.WriteLine(sepetim[keys]);
                        }
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("A) Sipariş Sil");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("B) Sepeti Onayla");
                        Console.WriteLine("0 -> Ana Menü");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.Write("Seçim: ");
                        string sepetSecimi = Console.ReadLine();
                        if (sepetSecimi == "A")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("BÜYÜK KÜÇÜK HARFE DUYARLIDIR!!!!!");
                            Console.WriteLine("Silmek İstediğiniz Ürünün Adını Giriniz..");
                            string sepettenSilinecekAd = Console.ReadLine();
                            Console.WriteLine("Silmek İstediğiniz Ürünün İD Numarasını Giriniz...");
                            string sepettenSilinecekİd = Console.ReadLine();
                            try
                            {
                                string silinecekKısım = sepettenSilinecekAd + " id:(" + sepettenSilinecekİd + ")";
                                sepetim[kullaniciAdi] = sepetim[kullaniciAdi].Replace(silinecekKısım, "");
                                urunStoklari[sepettenSilinecekİd]++;
                                string[] kullaniciSatirlari = File.ReadAllLines(kullaniciPath + "\\" + kullaniciAdi + ".txt");
                                string[] urunSatirlari = File.ReadAllLines(urunPath + "\\" + sepettenSilinecekİd + ".txt");
                                for (int i = 0; i < urunSatirlari.Length; i++)
                                {
                                    if (urunSatirlari[i][0] == 'S')  //stok
                                    {
                                        urunSatirlari[i] = "Stok: " + urunStoklari[sepettenSilinecekİd];
                                    }
                                }
                                File.WriteAllLines(urunPath + "\\" + sepettenSilinecekİd + ".txt", urunSatirlari);
                                for (int i = 0; i < kullaniciSatirlari.Length; i++)
                                {
                                    if (kullaniciSatirlari[i][0] == 'S')  //sepet
                                    {
                                        kullaniciSatirlari[i] = "Sepet: " + sepetim[kullaniciAdi];
                                    }
                                }
                                File.WriteAllLines(kullaniciPath + "\\" + kullaniciAdi + ".txt", kullaniciSatirlari);
                                Console.WriteLine("İşlem Tamamlandı");
                                Thread.Sleep(1500);
                                Console.Clear();
                            }
                            catch
                            {
                                Console.WriteLine("Bir Hata Oluştu");
                            }
                        }
                        else if (secim == "")
                        {

                        }
                        else
                        {
                            Console.WriteLine("Bir Hata Oluştu.. İşleminizi Gerçekleştiremiyoruz...");
                            Thread.Sleep(1500);

                            Console.Clear();
                            break;
                        }
                    }







                }
                else if (secim == "A")
                {
                    Console.Clear();
                    List<string> teknolojikİndexler = new List<string>();
                    Console.WriteLine("════════════════════════════════════════════════════════");
                    Console.WriteLine("                 TEKNOLOJİK ÜRÜNLER                     ");
                    Console.WriteLine("════════════════════════════════════════════════════════");
                    Console.WriteLine();
                    Console.ResetColor();
                    foreach (string teknolojikler in urunKategorileri.Keys)
                    {
                        if (urunKategorileri[teknolojikler][0] == 'T')
                        {
                            teknolojikİndexler.Add(teknolojikler);
                        }
                    }
                    foreach (string id in teknolojikİndexler)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("════════════════════════════════════════════════════════");
                        if (urunTurleri[id] == "Telefon")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("╔══╗");
                            Console.WriteLine("║█░║");
                            Console.WriteLine("╚══╝");
                        }
                        else if (urunTurleri[id] == "Bilgisayar")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("  __________");
                            Console.WriteLine(" |  ██████  |");
                            Console.WriteLine(" |__________|");
                            Console.WriteLine(" | [___] [] |");
                            Console.WriteLine(" |__________|");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("    {0}    ", urunTurleri[id]);
                        Console.WriteLine(" Marka: {0} ", urunMarkalari[id]);
                        Console.WriteLine(" Renk:  {0} ", urunRenkleri[id]);
                        if (urunStoklari[id] <= 3 && urunStoklari[id] != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(" Stok:  {0}  !!! TÜKENİYOR", urunStoklari[id]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (urunStoklari[id] == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(" Stok:  {0}  TÜKENDİ!", urunStoklari[id]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" Stok:  {0}", urunStoklari[id]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine(" Fiyat: {0}", urunFiyatlari[id]);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("  İD:{0} ", id);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("════════════════════════════════════════════════════════");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Sepete Eklemek İstediğiniz Ürününün İD sini Giriniz! / Bir Şey Almayacaksanız 0 a Basınız...");
                    string sepetİd = Console.ReadLine();
                    Console.Clear();
                    if (sepetİd == "0")
                    {

                    }
                    else
                    {
                        Console.Clear();
                        Console.ResetColor();
                        Console.WriteLine("Sepete Eklenecek Ürünün Stok Durumu: " + urunStoklari[sepetİd]);
                        if (urunStoklari[sepetİd] == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;

                            Console.WriteLine("Stokta Olmadığı İçin Geri Yönlendiriliyorsunuz.. Üzgünüz..");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("     _______");
                            Console.WriteLine("    /       \\");
                            Console.WriteLine("   /         \\");
                            Console.WriteLine("      SEPET    ");
                            Console.WriteLine("  |           |");
                            Console.WriteLine("  |___________|");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Stoklar Mevcuttur ! Ürün Sepetinize Eklensin Mi? -- E  /  H --");
                            Console.ForegroundColor = ConsoleColor.White;
                            string eklensinMi = Console.ReadLine();
                            if (eklensinMi == "E")
                            {
                                if (sepetim[kullaniciAdi] == "")
                                {
                                    sepetim[kullaniciAdi] = urunTurleri[sepetİd] + " id:(" + sepetİd + ")";
                                    urunStoklari[sepetİd]--;
                                }
                                else
                                {
                                    sepetim[kullaniciAdi] = sepetim[kullaniciAdi] + " " + urunTurleri[sepetİd] + " id:(" + sepetİd + ")";
                                    urunStoklari[sepetİd]--;
                                }

                                string[] kullaniciSatirlari = File.ReadAllLines(kullaniciPath + "\\" + kullaniciAdi + ".txt");
                                string[] urunSatirlari = File.ReadAllLines(urunPath + "\\" + sepetİd + ".txt");
                                for (int i = 0; i < urunSatirlari.Length; i++)
                                {
                                    if (urunSatirlari[i][0] == 'S')  //stok
                                    {
                                        urunSatirlari[i] = "Stok: " + urunStoklari[sepetİd];
                                    }
                                }
                                File.WriteAllLines(urunPath + "\\" + sepetİd + ".txt", urunSatirlari);
                                for (int i = 0; i < kullaniciSatirlari.Length; i++)
                                {
                                    if (kullaniciSatirlari[i][0] == 'S')  //sepet
                                    {
                                        kullaniciSatirlari[i] = "Sepet: " + sepetim[kullaniciAdi];
                                    }
                                }
                                File.WriteAllLines(kullaniciPath + "\\" + kullaniciAdi + ".txt", kullaniciSatirlari);
                                Console.WriteLine("Ürün Başarıyla Sepetinize Eklenmiştir..");
                                Console.WriteLine("Herhangi Bir Tuşa Basınız..");
                                Console.ReadKey();
                                Console.Clear();

                            }
                            else if (eklensinMi == "H")
                            {
                                Console.WriteLine("Menüye Dönülüyor .. Herhangi Bir Tuşa Basınız..");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                    }

                }
                else if (secim == "B")
                {
                    Console.Clear();
                    List<string> giysiİndexler = new List<string>();
                    Console.WriteLine("════════════════════════════════════════════════════════");
                    Console.WriteLine("                         GİYSİLER                       ");
                    Console.WriteLine("════════════════════════════════════════════════════════");
                    Console.WriteLine();
                    Console.ResetColor();
                    foreach (string giysiler in urunKategorileri.Keys)
                    {
                        if (urunKategorileri[giysiler][0] == 'G')
                        {
                            giysiİndexler.Add(giysiler);
                        }
                    }
                    foreach (string id in giysiİndexler)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("════════════════════════════════════════════════════════");
                        if (urunTurleri[id] == "Tişört")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("╔══╗");
                            Console.WriteLine("║█░║");
                            Console.WriteLine("╚══╝");
                        }
                        else if (urunTurleri[id] == "Pantolon")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("   █████████");
                            Console.WriteLine("   █       █");
                            Console.WriteLine("   █       █");
                            Console.WriteLine("   █       █");
                            Console.WriteLine("   █       █");
                        }
                        else if (urunTurleri[id] == "Ayakkabı")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine(" ________    ________ ");
                            Console.WriteLine("|        |  |        |");
                            Console.WriteLine("|        |  |        |");
                            Console.WriteLine("|  ____  |  |  ____  |");
                            Console.WriteLine("| |    | |  | |    | |");
                            Console.WriteLine("| |____| |  | |____| |");
                            Console.WriteLine("|________|  |________|");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("    {0}    ", urunTurleri[id]);
                        Console.WriteLine(" Marka: {0} ", urunMarkalari[id]);
                        Console.WriteLine(" Renk:  {0} ", urunRenkleri[id]);
                        if (urunStoklari[id] <= 3 && urunStoklari[id] != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(" Stok:  {0}  !!! TÜKENİYOR", urunStoklari[id]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (urunStoklari[id] == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(" Stok:  {0}  TÜKENDİ!", urunStoklari[id]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" Stok:  {0}", urunStoklari[id]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine(" Fiyat: {0}", urunFiyatlari[id]);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("  İD:{0} ", id);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("════════════════════════════════════════════════════════");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Sepete Eklemek İstediğiniz Ürününün İD sini Giriniz! / Bir Şey Almayacaksanız 0 a Basınız...");
                    string sepetİd = Console.ReadLine();
                    Console.Clear();
                    if (urunStoklari[sepetİd] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("Stokta Olmadığı İçin Geri Yönlendiriliyorsunuz.. Üzgünüz..");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("     _______");
                        Console.WriteLine("    /       \\");
                        Console.WriteLine("   /         \\");
                        Console.WriteLine("      SEPET    ");
                        Console.WriteLine("  |           |");
                        Console.WriteLine("  |___________|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Stoklar Mevcuttur ! Ürün Sepetinize Eklensin Mi? -- E  /  H --");
                        Console.ForegroundColor = ConsoleColor.White;
                        string eklensinMi = Console.ReadLine();
                        if (eklensinMi == "E")
                        {
                            if (sepetim[kullaniciAdi] == "")
                            {
                                sepetim[kullaniciAdi] = urunTurleri[sepetİd] + " id:(" + sepetİd + ")";
                                urunStoklari[sepetİd]--;
                            }
                            else
                            {
                                sepetim[kullaniciAdi] = sepetim[kullaniciAdi] + " " + urunTurleri[sepetİd] + " id:(" + sepetİd + ")";
                                urunStoklari[sepetİd]--;
                            }
                            string[] kullaniciSatirlari = File.ReadAllLines(kullaniciPath + "\\" + kullaniciAdi + ".txt");
                            string[] urunSatirlari = File.ReadAllLines(urunPath + "\\" + sepetİd + ".txt");
                            for (int i = 0; i < urunSatirlari.Length; i++)
                            {
                                if (urunSatirlari[i][0] == 'S')  //stok
                                {
                                    urunSatirlari[i] = "Stok: " + urunStoklari[sepetİd];
                                }
                            }
                            File.WriteAllLines(urunPath + "\\" + sepetİd + ".txt", urunSatirlari);
                            for (int i = 0; i < kullaniciSatirlari.Length; i++)
                            {
                                if (kullaniciSatirlari[i][0] == 'S')  //sepet
                                {
                                    kullaniciSatirlari[i] = "Sepet: " + sepetim[kullaniciAdi];
                                }
                            }
                            File.WriteAllLines(kullaniciPath + "\\" + kullaniciAdi + ".txt", kullaniciSatirlari);
                            Console.WriteLine("Ürün Başarıyla Sepetinize Eklenmiştir..");
                            Console.WriteLine("Herhangi Bir Tuşa Basınız..");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else if (eklensinMi == "H")
                        {
                            Console.WriteLine("Menüye Dönülüyor .. Herhangi Bir Tuşa Basınız..");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    }

                }
                else if (secim == "C")
                {
                    Console.Clear();
                    List<string> evİndexler = new List<string>();
                    Console.WriteLine("════════════════════════════════════════════════════════");
                    Console.WriteLine("                        EV EŞYALARI                     ");
                    Console.WriteLine("════════════════════════════════════════════════════════");
                    Console.WriteLine();
                    Console.ResetColor();
                    foreach (string esyalar in urunKategorileri.Keys)
                    {
                        if (urunKategorileri[esyalar][0] == 'E')
                        {
                            evİndexler.Add(esyalar);
                        }
                    }
                    foreach (string id in evİndexler)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("════════════════════════════════════════════════════════");
                        if (urunTurleri[id] == "Kanepe")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("  ___________");
                            Console.WriteLine(" |           \\");
                            Console.WriteLine(" |            \\________");
                            Console.WriteLine(" |                     \\");
                            Console.WriteLine(" |                     |");
                            Console.WriteLine(" \\____________________/");
                        }
                        else if (urunTurleri[id] == "Masa")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("  ________  ");
                            Console.WriteLine(" |        | ");
                            Console.WriteLine(" |        | ");
                            Console.WriteLine(" |________| ");
                            Console.WriteLine("    ||||    ");
                            Console.WriteLine("    ||||    ");
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("    {0}    ", urunTurleri[id]);
                        Console.WriteLine(" Marka: {0} ", urunMarkalari[id]);
                        Console.WriteLine(" Renk:  {0} ", urunRenkleri[id]);
                        if (urunStoklari[id] <= 3 && urunStoklari[id] != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(" Stok:  {0}  !!! TÜKENİYOR", urunStoklari[id]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (urunStoklari[id] == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(" Stok:  {0}  TÜKENDİ!", urunStoklari[id]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" Stok:  {0}", urunStoklari[id]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine(" Fiyat: {0}", urunFiyatlari[id]);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("  İD:{0} ", id);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("════════════════════════════════════════════════════════");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Sepete Eklemek İstediğiniz Ürününün İD sini Giriniz! / Bir Şey Almayacaksanız 0 a Basınız...");
                    string sepetİd = Console.ReadLine();
                    Console.Clear();
                    if (urunStoklari[sepetİd] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("Stokta Olmadığı İçin Geri Yönlendiriliyorsunuz.. Üzgünüz..");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("     _______");
                        Console.WriteLine("    /       \\");
                        Console.WriteLine("   /         \\");
                        Console.WriteLine("      SEPET    ");
                        Console.WriteLine("  |           |");
                        Console.WriteLine("  |___________|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Stoklar Mevcuttur ! Ürün Sepetinize Eklensin Mi? -- E  /  H --");
                        Console.ForegroundColor = ConsoleColor.White;
                        string eklensinMi = Console.ReadLine();
                        if (eklensinMi == "E")
                        {
                            if (sepetim[kullaniciAdi] == "")
                            {
                                sepetim[kullaniciAdi] = urunTurleri[sepetİd] + " id:(" + sepetİd + ")";
                                urunStoklari[sepetİd]--;
                            }
                            else
                            {
                                sepetim[kullaniciAdi] = sepetim[kullaniciAdi] + " " + urunTurleri[sepetİd] + " id:(" + sepetİd + ")";
                                urunStoklari[sepetİd]--;
                            }
                            string[] kullaniciSatirlari = File.ReadAllLines(kullaniciPath + "\\" + kullaniciAdi + ".txt");
                            string[] urunSatirlari = File.ReadAllLines(urunPath + "\\" + sepetİd + ".txt");
                            for (int i = 0; i < urunSatirlari.Length; i++)
                            {
                                if (urunSatirlari[i][0] == 'S')  //stok
                                {
                                    urunSatirlari[i] = "Stok: " + urunStoklari[sepetİd];
                                }
                            }
                            File.WriteAllLines(urunPath + "\\" + sepetİd + ".txt", urunSatirlari);
                            for (int i = 0; i < kullaniciSatirlari.Length; i++)
                            {
                                if (kullaniciSatirlari[i][0] == 'S')  //sepet
                                {
                                    kullaniciSatirlari[i] = "Sepet: " + sepetim[kullaniciAdi];
                                }
                            }
                            File.WriteAllLines(kullaniciPath + "\\" + kullaniciAdi + ".txt", kullaniciSatirlari);
                            Console.WriteLine("Ürün Başarıyla Sepetinize Eklenmiştir..");
                            Console.WriteLine("Herhangi Bir Tuşa Basınız..");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else if (eklensinMi == "H")
                        {
                            Console.WriteLine("Menüye Dönülüyor .. Herhangi Bir Tuşa Basınız..");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    }

                }







            }

            // eğer adminse
            while (adminMi)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("════════════════════════════════════════");
                Console.WriteLine("              ADMIN PANELİ              ");
                Console.WriteLine("════════════════════════════════════════");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"                {adminId}              ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("════════════════════════════════════════");
                Console.ResetColor();
                Console.WriteLine("****************************************");
                Console.WriteLine("1 -> Ürün Ekle");
                Console.WriteLine("2 -> Ürün Güncelle");
                Console.WriteLine("3 -> Ürün Sil");
                Console.WriteLine("4 -> Sipariş Düzenle");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("5 -> Kullanıcı Hesaplarını Düzenle");
                Console.ResetColor();
                Console.WriteLine("0 -> Çıkış");
                Console.WriteLine("***************************************");
                Console.WriteLine("SEÇİM : ");
                string karar = Console.ReadLine();
                if (karar == "0")
                {
                    adminMi = false;
                    Console.WriteLine("Çıkış Yapılıyor...");
                    Thread.Sleep(1000);
                    break;
                }
                else if (karar == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Geçiçi Süreliğine Hizmet Veremiyoruz... Ana Menüye Yönlendiriliyorsunuz...");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
                else if (karar == "1")
                {

                    Console.Clear();
                    while (true)
                    {
                        bool anaMenu = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("════════════════════════════════════════");
                        Console.WriteLine("               ÜRÜN EKLEME              ");
                        Console.WriteLine("════════════════════════════════════════");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unutmayın.. Var olan bir ürün eklenemez.. Her Kelimeye Büyük Harfe Başlayınız!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                        Console.Write("Eklenecek Ürünün Türü:");
                        string eklenecekTur = Console.ReadLine();
                        Console.WriteLine("");
                        Console.Write("Eklenecek Ürünün Rengi:");
                        string eklenecekRenk = Console.ReadLine();
                        Console.WriteLine("");
                        Console.Write("Eklenecek Ürünün Fiyatı:");
                        int eklenecekFiyat;
                        try
                        {
                            eklenecekFiyat = Convert.ToInt16(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("HATALI VERİ GİRDİNİZ!!!");
                            Console.WriteLine("ANA SAYFAYA YÖNLENDİRİLİYORLSUNUZ...");
                            Thread.Sleep(3000);
                            Console.Clear();
                            break;

                        }

                        Console.WriteLine("");
                        Console.Write("Eklenecek Ürünün Markası:");
                        string eklenecekMarka = Console.ReadLine();
                        Console.WriteLine("");
                        Console.Write("Eklenecek Ürünün Kategorisi:");
                        string eklenecekKategori = Console.ReadLine();
                        Console.WriteLine("");
                        Console.Write("Eklenecek Ürünün Sayısı:");
                        int eklenecekStok;
                        try
                        {
                            eklenecekStok = Convert.ToInt16(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("HATALI VERİ GİRDİNİZ!!!");
                            Console.WriteLine("ANA SAYFAYA YÖNLENDİRİLİYORLSUNUZ...");
                            Thread.Sleep(3000);
                            Console.Clear();
                            break;

                        }
                        while (true)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Eklenecek Ürünün ID Numarası:");
                            Console.ForegroundColor = ConsoleColor.White;
                            string eklenecekurununIDno = Console.ReadLine();
                            if (urunFiyatlari.ContainsKey(eklenecekurununIDno))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("BU ID NUMARASINA SAHİP ÜRÜN MEVCUTTUR.. ");
                                Console.WriteLine("TEKRAR DENEYİNİZ.!");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            else
                            {
                                urunFiyatlari[eklenecekurununIDno] = eklenecekFiyat;
                                urunMarkalari[eklenecekurununIDno] = eklenecekMarka;
                                urunRenkleri[eklenecekurununIDno] = eklenecekRenk;
                                urunStoklari[eklenecekurununIDno] = eklenecekStok;
                                urunTurleri[eklenecekurununIDno] = eklenecekTur;
                                urunKategorileri[eklenecekurununIDno] = eklenecekKategori;
                                File.Create(urunPath + "\\" + eklenecekurununIDno + ".txt").Close();
                                List<string> eklenecekListe = new List<string>();
                                eklenecekListe.Add("Tür: " + eklenecekTur);
                                eklenecekListe.Add("Renk: " + eklenecekRenk);
                                eklenecekListe.Add("Marka: " + eklenecekMarka);
                                eklenecekListe.Add("Stok: " + eklenecekStok);
                                eklenecekListe.Add("Fiyat: " + eklenecekFiyat);
                                eklenecekListe.Add("Kategori: " + eklenecekKategori);
                                eklenecekListe.Add("İD: " + eklenecekurununIDno);
                                Console.Clear();
                                Console.WriteLine("*** ÜRÜN SİSTEME BAŞARIYLA EKLENMİŞTİR ***");
                                Thread.Sleep(2500);
                                Console.Clear();
                                File.WriteAllLines(urunPath + "\\" + eklenecekurununIDno + ".txt", eklenecekListe);
                                anaMenu = true;
                                break;

                            }
                        }
                        if (anaMenu == true)
                        { break; }
                    }
                }
                else if (karar == "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("════════════════════════════════════════");
                    Console.WriteLine("              ÜRÜN DÜZENLEME            ");
                    Console.WriteLine("════════════════════════════════════════");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Düzenlemek istediğiniz ürünün İD numarasını giriniz:");
                    string girilenİD = Console.ReadLine();
                    if (urunFiyatlari.ContainsKey(girilenİD))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("════════════════════════════════════════");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("        Ürünün Türü: {0}               ", urunTurleri[girilenİD]);
                        Console.WriteLine("        Ürünün Markası: {0}               ", urunMarkalari[girilenİD]);
                        Console.WriteLine("        Ürünün Rengi: {0}               ", urunRenkleri[girilenİD]);
                        Console.WriteLine("        Ürünün Fiyatı: {0}TL               ", urunFiyatlari[girilenİD]);
                        Console.WriteLine("        Ürünün Kategorisi: {0}               ", urunKategorileri[girilenİD]);
                        Console.WriteLine("        Ürünün Stoğu: {0} Adet               ", urunStoklari[girilenİD]);
                        Console.WriteLine("        Ürünün İD NO: {0}               ", girilenİD);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("════════════════════════════════════════");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("1 ) Stok Sayısını Değiştir");
                        Console.WriteLine("2 ) Fiyatını Değiştir");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.Write("SEÇİM:");
                        string secim2 = Console.ReadLine();
                        if (secim2 == "1")
                        {
                            int guncelStok = urunStoklari[girilenİD];
                            urunGuncelle(urunPath, ref urunStoklari, girilenİD, guncelStok, "1");
                            Console.Clear();
                        }
                        else if (secim2 == "2")
                        {
                            int guncelFiyat = urunFiyatlari[girilenİD];
                            urunGuncelle(urunPath, ref urunFiyatlari, girilenİD, guncelFiyat, "2");
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Giriş..");
                            Console.WriteLine("Menüye Yönlendiriliyorsunuz...");
                            Thread.Sleep(2500);
                            Console.Clear();
                        }


                    }
                    else
                    {
                        Console.WriteLine("Girilen İd Sistemde Yoktur");
                        Console.WriteLine("Menüye Yönlendiriliyorsunuz...");
                        Thread.Sleep(2500);
                        Console.Clear();
                    }

                }
                else if (karar == "3")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("════════════════════════════════════════");
                    Console.WriteLine("               ÜRÜN SİLME               ");
                    Console.WriteLine("════════════════════════════════════════");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Silinecek Ürünün İd Numarasını Giriniz: ");
                    string silinecekİd = Console.ReadLine();
                    if (urunFiyatlari.ContainsKey(silinecekİd) == true)
                    {
                        try
                        {
                            File.Delete(urunPath + "\\" + silinecekİd + ".txt");
                            urunFiyatlari.Remove(silinecekİd);
                            urunRenkleri.Remove(silinecekİd);
                            urunTurleri.Remove(silinecekİd);
                            urunMarkalari.Remove(silinecekİd);
                            urunStoklari.Remove(silinecekİd);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Ürün Sistemden Silinmiştir..");
                            Console.WriteLine("Menüye Yönlendiriliyorsunuz...");
                            Thread.Sleep(2500);
                            Console.Clear();
                        }
                        catch
                        {
                            Console.WriteLine("Beklenmeyen Bir Hata Oluştu!");
                        }


                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sistemde Zaten Böyle Bir Ürün Yok");
                        Console.WriteLine("Menüye Yönlendiriliyorsunuz...");
                        Thread.Sleep(2500);
                    }


                }

                else if (karar == "5")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("════════════════════════════════════════");
                    Console.WriteLine("        KULLANICI YÖNETİM PANELİ        ");
                    Console.WriteLine("════════════════════════════════════════");
                    Console.WriteLine("             KULLANICI İDLERİ           ");
                    Console.WriteLine("════════════════════════════════════════");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    for (int i = 0; i < kullaniciAdlari.Count; i++)
                    {
                        Console.WriteLine("KULLANICI İD: " + kullaniciAdlari[i] + " ŞİFRE: " + sifreler[kullaniciAdlari[i]]);
                    }

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Yönetilecek Kullanıcının Kullanıcı Adını Giriniz: ");
                    string yönetilecekKullaniciAdi = Console.ReadLine();
                    if (sifreler.ContainsKey(yönetilecekKullaniciAdi))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("════════════════════════════════════════");
                        Console.WriteLine("KULLANICI İD: " + yönetilecekKullaniciAdi);
                        Console.WriteLine("════════════════════════════════════════");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("1-> ŞİFRE SIFIRLA");
                        Console.WriteLine("2-> BANLA");
                        string secim4 = Console.ReadLine();
                        if (secim4 == "1")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("════════════════════════════════════════");
                            Console.WriteLine("          YENİ ŞİFREYİ GİRİNİZ          ");
                            Console.WriteLine("════════════════════════════════════════");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string kullanicininYeniSifresi = Console.ReadLine();
                            sifreler[yönetilecekKullaniciAdi] = kullanicininYeniSifresi;
                            string dosyaKonumu = kullaniciPath + "\\" + yönetilecekKullaniciAdi + ".txt";
                            string[] yönetilenSatirlar = File.ReadAllLines(dosyaKonumu);
                            for (int i = 0; i < yönetilenSatirlar.Length; i++)
                            {
                                if (yönetilenSatirlar[i][0] == 'Ş')
                                {
                                    yönetilenSatirlar[i] = "Şifre: " + kullanicininYeniSifresi;
                                }
                            }
                            File.WriteAllLines(dosyaKonumu, yönetilenSatirlar);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Şifre Başarıyla Değiştirilmiştir..");
                            Console.WriteLine("Yeni Şifre: " + sifreler[yönetilecekKullaniciAdi]);
                            Console.WriteLine("ANASAYFAYA YÖNLENDİRİLİYOR...");
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                        else if (secim4 == "2")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("════════════════════════════════════════");
                            Console.WriteLine("           KULLANICI BANLANDI           ");
                            Console.WriteLine("════════════════════════════════════════");
                            Console.WriteLine();
                            Console.WriteLine("ANASAYFAYA YÖNLENDİRİLİYOR...");
                            Thread.Sleep(1500);
                            File.Delete(kullaniciPath + "\\" + yönetilecekKullaniciAdi + ".txt");
                            kullaniciAdlari.Remove(yönetilecekKullaniciAdi);
                            sifreler.Remove(yönetilecekKullaniciAdi);
                            mailler.Remove(yönetilecekKullaniciAdi);
                            telefonlar.Remove(yönetilecekKullaniciAdi);
                            adresler.Remove(yönetilecekKullaniciAdi);
                            Console.Clear();


                        }




                    }


                }










            }

















































        }
    }
}
