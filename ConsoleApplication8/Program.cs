using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("1-Admin Girisi");
            Console.WriteLine("2-Kullanici Girisi");
            int secim =Convert.ToInt32(Console.ReadLine());
            if (secim == 1)
            {
                string dosya_yolu = @"D:\Users\st900398\Desktop\sorular.txt";
                string dosya_yolu1 = @"D:\Users\st900398\Desktop\cikarim.txt";
                File.WriteAllText(dosya_yolu, String.Empty);
                File.WriteAllText(dosya_yolu1, String.Empty);
                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                FileStream fs1 = new FileStream(dosya_yolu1, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw1 = new StreamWriter(fs1);
                Console.Write("Kac soru sorulacak :");
                int sorusayisi = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= sorusayisi; i++)
                {
                    Console.Write("{0}. Soruyu Yazin :", i);
                    string soru = Convert.ToString(Console.ReadLine());
                    sw.WriteLine(i +" "+ soru);
                    Console.Write("{0}. Sorunun Cevap Sayisi :", i);
                    int cevapsayisi = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("{0}. Sorunun Cevapları", i);
                    char c1 = 'A';
                    for (int k = 1; k <= cevapsayisi; k++)
                    {
                        Console.Write(c1);
                        string cevaplar = Convert.ToString(Console.ReadLine());
                        sw.WriteLine(c1 + " " + cevaplar);
                        c1++;
                    }
                    sw.WriteLine("---");
                    sw.Flush();
                }
                sw.Close();
                fs.Close();

                Console.WriteLine("Çıkarımlar");
                while (true)
                {
                    for (int i = 0; i < sorusayisi; i++)
                    {
                        Console.Write("{0} .Sorunun cevabı ", i);
                        string secilen = Convert.ToString(Console.ReadLine());
                        sw1.Write(secilen.ToUpper());
                    }
                    Console.Write("Sonuc ");
                    string sonuc=Convert.ToString(Console.ReadLine());
                    sw1.WriteLine("=" + sonuc);
                    Console.WriteLine("Başka Çıkarım Yapmak İstiyor musunuz? y/n");
                    string tercih = Convert.ToString(Console.ReadLine());
                    if (tercih == "n")
                    {
                        break;
                    }
                }
                    Console.ReadKey();
                    sw1.Flush();
                    sw1.Close();
                
            }
            if (secim == 2)
            {
                string dosya_yolu = @"D:\Users\st900398\Desktop\sorular.txt";
                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                string dosya_yolu1 = @"D:\Users\st900398\Desktop\cevaplar.txt";
                File.WriteAllText(dosya_yolu1, String.Empty);
                FileStream fs1 = new FileStream(dosya_yolu1, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw1 = new StreamWriter(fs1);
                string yazi = sw.ReadLine();
                while (yazi != null)
                {
                    Console.WriteLine(yazi);
                    string cevap = sw.ReadLine();
                    while (cevap != null && cevap != "---")
                    {
                        Console.WriteLine(cevap);
                        cevap = sw.ReadLine();
                    }
                    Console.Write("Cevabınız.. ");
                    string kullanicicevap =Convert.ToString(Console.ReadLine());
                    sw1.Write(kullanicicevap.ToUpper());
                    yazi = sw.ReadLine();
                }
                sw1.Flush();
                sw1.Close();
                sw.Close();
                FileStream fs2 = new FileStream(dosya_yolu1, FileMode.Open, FileAccess.Read);
                StreamReader sw2 = new StreamReader(fs2);
                string kontrol = sw2.ReadLine();
                string dosya_yolu3 = @"D:\Users\st900398\Desktop\cikarim.txt";
                FileStream fs3 = new FileStream(dosya_yolu3, FileMode.Open, FileAccess.Read);
                StreamReader sw3 = new StreamReader(fs3);
                string aracvp = sw3.ReadLine();
                while(aracvp!=null)
                {
                    int intcvp = aracvp.IndexOf('=');
                    string cvp = aracvp.Substring(0, intcvp);
                    int sondeger = aracvp.Length - cvp.Length;
                    if (kontrol == cvp)
                    {
                        string sonuc = aracvp.Substring(intcvp, sondeger);
                        Console.WriteLine("Anket sonucu"+sonuc);
                    }
                    aracvp = sw3.ReadLine();
                }
                Console.ReadKey();
                fs.Close();
            }
        }
    }
}
