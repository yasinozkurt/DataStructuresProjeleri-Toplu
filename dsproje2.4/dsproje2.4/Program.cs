using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsproje2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] değerler = { 6, 7, 2, 1, 12, 5, 3, 7, 4, 2 };
            // işlem tamamlama sürelerini tutmak için arraylist kullandım:
          
            int toplamSure = 0;
            int kumulatifSure = 0;

            //Burada 10 adet int değer için kuyruk nesnemizi oluşturuyoruz:
            myQueue k = new myQueue(10);
           for(int i = 0; i < değerler.Length; i++)
            {
                k.insert(değerler[i]);
               
            }

            //Burada kasada geçecek ortalama süreyi hesaplıyoruz:
            
         
           for(int i = 0; i < değerler.Length; i++)
            {
                toplamSure += k.remove();
                Console.WriteLine((i+1) + ". müşterinin işlem tamamlama süresi: " + toplamSure*3);
               
                kumulatifSure += toplamSure;
            }
            Console.WriteLine("Geçen ortalama süre: " + (kumulatifSure * 3)/değerler.Length);



            Console.WriteLine("Öncelikli kuyruk yapısı ile artan sırada çıkarım yaptığımızda: ");
            
            
            //Aynısını öncelikli kuyruk yapısı kullanarak hesaplıyoruz:

            int toplamSurePQ = 0;
            int kumulatifSurePQ = 0;
            PriorityQueue pq = new PriorityQueue();

            for (int i = 0; i < değerler.Length; i++)
            {
                pq.insert(değerler[i]);

            }

            //Burada kasada geçecek ortalama süreyi hesaplıyoruz:


            for (int i = 0; i < değerler.Length; i++)
            {
                toplamSurePQ += pq.remove();
                Console.WriteLine((i+1) + ". müşterinin işlem tamamlama süresi: " + toplamSurePQ*3);

                kumulatifSurePQ += toplamSurePQ;
            }
            Console.WriteLine("Geçen ortalama süre: " + (kumulatifSurePQ * 3) / değerler.Length);



            //C kısmı öncelikli kuyruk ve normal kuyruk yapılarının bu gibi durumlarda avamtaj ve dezavantajları:
            // PQ(55,5sn) kullanımı Q(85,8sn)'dan daha verimli oldu çünkü normal queue yapısında çok büyük bir değer kuyruğun başlarındaysa onun harcayacağı süre  kartopu etkisi gibi diğer tüm elemanlara ekleniyor
            //ancak pqde bu kartopu olabilidğince ufak tutuluyor ve büyük değerler çok az sayıda elemanı etkilemiş oluyor
            //Dezavantajı ise her seferinde en az malzemeye sahip müşteriyi bulmak için harcanan zaman ve işlem gücü örnek verilebilir
            //Belki değerlerin birbirine çok yakın olduğu kuyruk yapılarında pq kullanmanın vereceği yarar her seferinde search işlemi yapmanın zararını karşılamayacaktır.






            Console.ReadLine();
        }
    }



    class myQueue
    {
        private int front;
        private int[] dizi;
        private int maxsize;
        private int nItems;
        private int rear;


        public myQueue(int m)
        {
            maxsize = m;
            dizi = new int[maxsize];
            front = 0;
            rear=0;
            nItems = 0;
        }

        public void insert(int değer)
        {
            dizi[rear++] = değer;
           
            nItems++;
        }
        public int remove()
        {

            int temp = dizi[front];
            front++;
            nItems--;
            return temp;

        }
        public int size()
        {
            return nItems;
        }
        public int peek()
        {
            return dizi[front];
        }

    }
    //################################################################3

    //Öncelikli Kuyruk Sınıfı
    class PriorityQueue
    {

        private List<int> queArray;
        private int nItems;

        public PriorityQueue()
        {
            queArray = new List<int>();
            nItems = 0;
        }

        public void insert(int i)
        {
            queArray.Add(i);
            nItems++;
        }

        //Elemanları artan sırada(önce en küçük) silen remove metodu
        public int remove()
        {
            //pivot değer ataması:
            int tempMin = queArray[0];
            int MinIndex = 0;
            for(int i = 0; i < nItems; i++)
            {
                if (queArray[i] < tempMin)
                {
                    tempMin = queArray[i];
                    MinIndex = i;
                }

            }
            //For döngüsünden silinecek eleman tempMin olarak dönüyor
            queArray.RemoveAt(MinIndex);
            nItems--;
            return tempMin;           
        }

        public bool isEmpty()
        {
            return (nItems == 0);
        }

    }

}
