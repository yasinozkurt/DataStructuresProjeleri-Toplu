using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsProje3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 9, 4, 5, 2, 8, 3, 1, 6, 7 };


            Console.WriteLine("Sıralanmadanki hali: ");
            display(list);

           

            SelectionSort(list);
            Console.WriteLine("Sıralandıktan sonraki hali: ");

            display(list);


            Console.ReadLine();



            //SELECTİON SORT VE İNSERTİON SORT ALGORİTMALARINI YAZDIM, İKİSİNİNDE ZAMAN KARMAŞIKLIĞI O(n'2)'DİR

            //SELECTİON SORT İÇİNDE ÇOK SIK KARŞILAŞTIRMA YAPILIRKEN, İNSERTİON SORTTA ÇOK SIK YER DEĞİŞİMİ YAPILIR
            //Bu nedenle Selection Sort büyük kayıtlardan oluşan az elemanlı veri grupları için(atamaların süresi çok fazla olmaz) ve karşılaştırmaların daha az yük getireceği basit anahtarlı durumlarda uygundur.
            //Tam tersi için, insertion sort uygundur.Elemanlar bağlı listedelerse araya eleman
            //eklemelerde veri kaydırma olmayacağından insertion sort mantığı uygundur.

            //Algoritmaları anlamada görselleştirme metodları genel olarak algoritmanın ne yaptığını anlamada kod okumaktan çok daha yardımcı oluyor. 

            //Artık çoğu videoda da algoritma görselleştirme aaraçları benzeri animasyonlar kullanıldığından algorütmayı anlama kısmında görselleştiirme araçlarının tek avantajı bence bizim istediğimiz değerler için programı çalıştırabiliyor oluşumuz.







        }

      
       static void SelectionSort(int[] liste)
        {
            for(int i = 0; i < liste.Length - 1;i++)
            {
                int tempMin = liste[i];
                int tempİndex = i;
                for(int j = i + 1; j < liste.Length; j++)
                {
                    if (liste[j] < tempMin)
                    {
                        tempMin = liste[j];
                        tempİndex = j;
                    }

                   

                }

                //swap işlemi
                int kova = liste[i];
                liste[i] = liste[tempİndex];
                liste[tempİndex] = kova;
            }
        }


    

        static void InsertionSort(int[] liste)
        {
            for(int i=0; i < liste.Length-1; i++)
            {
                int j = i;
                while (liste[j + 1] < liste[j])// index+1 < index durumunda bir sola swap edilecek 
                {
                    //swap işlemi
                    int temp = liste[j + 1];
                    liste[j + 1] = liste[j];
                    liste[j] = temp;
                    j-=1;


                    if (j == -1)
                    {
                        break;
                    }


                }


            }
        }

        static void display(int[] liste)
        {
            for (int i = 0; i < liste.Length; i++)
            {
                Console.WriteLine(liste[i]);
            }
        }
    }
}
