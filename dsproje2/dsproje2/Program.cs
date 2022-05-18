using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsproje2
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] MahalleAdı = { "Özkanlar", "Evka 3", "Atatürk", "Erzene", "Kazımdirik", "Mevlana", "Doğanlar", "Ergene" };
            int[] TeslimatSayısı = { 5, 2, 7, 2, 7, 3, 0, 1 };

            //Aralarından random seçim yapılacak yemek türü listesi:

            string[] yemekCesidi = { "pizza", "pide", "kebap", "patlıcan musakka", "mantı", "sarma", "mercimek köftesi", "hamburger" };

            Random rnd = new Random();

            //###################################### 1A   ################################################
           
            //Bir arraylist oluşturup  for döngüsü ile her indeksine birer mahallesınıfı objesi koyuyorum:
            ArrayList Moto_Kurye = new ArrayList();

            void ElemanEkle()
            {
                for (int i = 0; i < MahalleAdı.Length; i++)
                {

                    MahalleSınıfı tempMh = new MahalleSınıfı(MahalleAdı[i]);

                    for (int j = 0; j < TeslimatSayısı[i]; j++)
                    {
                        tempMh.liste.Add(new TeslimatSınıfı(yemekCesidi[rnd.Next(7) + 1], rnd.Next(5) + 1));

                    }
                    Moto_Kurye.Add(tempMh);

                }

            }
            //Method:
            ElemanEkle();



            //###################################### 1B   ################################################
         
            //  BİLEŞİK VERİ YAPILI MOTO_KURYE ARRAYLİSTİ YAZDIRIYORUZ


            for (int i = 0; i < MahalleAdı.Length; i++)
            {
                //mahalle adı:
                Console.WriteLine(((MahalleSınıfı)Moto_Kurye[i]).mahalleAdı);
               
                for(int j = 0; j < TeslimatSayısı[i]; j++)
                {
                    //bu mahalleye verilen siparişlerin  detayı:
                    Console.Write(((MahalleSınıfı)Moto_Kurye[i]).liste[j].adet);
                    Console.Write("   ");
                    Console.WriteLine(((MahalleSınıfı)Moto_Kurye[i]).liste[j].yemekAdı);
                }
            }



            Console.WriteLine("################################################");
            //###################################### 1C  ################################################
            // Arraylistteki toplam eleman (liste) sayısı ve toplam teslimat sayısını bulan kod:
            int elemanSayısı = 0;
            int teslimatToplam = 0;
            for (int i = 0; i < MahalleAdı.Length; i++)
            {
                elemanSayısı++;

                //teslimat sayısı için;
                teslimatToplam += TeslimatSayısı[i];


            }

            Console.Write("Eleman sayısı : ");
            Console.WriteLine(elemanSayısı);
            Console.Write("Toplam teslimat sayısı: ");
            Console.WriteLine(teslimatToplam);




            //###################################### 2A  ################################################
            // 1a kısmında arrayliste atadığımız tüm bilgileri bu sefer stack içinde tutuyoruz:
            Stack_Moto_Kurye s = new Stack_Moto_Kurye(MahalleAdı.Length);
            for (int i = 0; i < MahalleAdı.Length; i++)
            {

                MahalleSınıfı tempMh = new MahalleSınıfı(MahalleAdı[i]);

                for (int j = 0; j < TeslimatSayısı[i]; j++)
                {
                    tempMh.liste.Add(new TeslimatSınıfı(yemekCesidi[rnd.Next(7) + 1], rnd.Next(5) + 1));

                }
                s.push(tempMh);

            }


            //Yığıttaki elemanları yazdıran kod:
            // ÖNEMLİ: MOTO_KURYE ARRAYLİSTİNİ KOPYALAMADAN YENİ RANDOM YEMEK ÇEŞİDİ VE SAYISI DEĞERLERİ İLE OLUŞTURULDUĞUNDAN STACK İLE ARRAYLİST TIPTAIP AYNI DEĞİL,
            // MAHALLE ADLARI VE KARŞILIK GELEN TESLİMAT SAYILARI AYNI
            Console.WriteLine("################################################");
            for (int i = 0; i < MahalleAdı.Length; i++)
            {

                MahalleSınıfı m = s.pop();
                Console.WriteLine(m.mahalleAdı);

               
                //stack veri yapısında objeler sondan başlayarak çıktığı için:
                for (int j = 0; j < TeslimatSayısı[(MahalleAdı.Length-1) - i]; j++)
                {
                    Console.Write(m.liste[j].adet);
                    Console.Write("   ");
                    Console.WriteLine(m.liste[j].yemekAdı);
                   

                }
               

            }



            //###################################### 2B  ################################################
            // 1a kısmında arrayliste atadığımız tüm bilgileri bu sefer queue içinde tutuyoruz:
            Queue_Moto_Kurye q= new Queue_Moto_Kurye(MahalleAdı.Length);
            for (int i = 0; i < MahalleAdı.Length; i++)
            {

                MahalleSınıfı tempMh = new MahalleSınıfı(MahalleAdı[i]);

                for (int j = 0; j < TeslimatSayısı[i]; j++)
                {
                    tempMh.liste.Add(new TeslimatSınıfı(yemekCesidi[rnd.Next(7) + 1], rnd.Next(5) + 1));

                }
                q.insert(tempMh);

            }


            //Kuyruktaki elemanları yazdıran kod:
            // ÖNEMLİ: MOTO_KURYE ARRAYLİSTİNİ KOPYALAMADAN YENİ RANDOM YEMEK ÇEŞİDİ VE SAYISI DEĞERLERİ İLE OLUŞTURULDUĞUNDAN KUYRUK İLE ARRAYLİST TIPTAIP AYNI DEĞİL,
            // MAHALLE ADLARI VE KARŞILIK GELEN TESLİMAT SAYILARI AYNI
            Console.WriteLine("################################################");
            for (int i = 0; i < MahalleAdı.Length; i++)
            {

                MahalleSınıfı m = q.remove();
                Console.WriteLine(m.mahalleAdı);



                for (int j = 0; j < TeslimatSayısı[i]; j++)
                {
                    Console.Write(m.liste[j].adet);
                    Console.Write("   ");
                    Console.WriteLine(m.liste[j].yemekAdı);


                }


            }





            //###################################### 3A  ################################################
            Console.WriteLine("################################################");
            //Öncelikli kuyruğa verilerimizi ekliyoruz:
            PriorityQueue pq = new PriorityQueue();
            for (int i = 0; i < MahalleAdı.Length; i++)
            {
                // aynı referansı tutuyorlar ancak biz listede bir değişiklik yapmayacağımızdan bir dezavantajı bulunmuyor.
                pq.insert((MahalleSınıfı)Moto_Kurye[i]);

            }

            //###################################### 3A test ################################################

           for(int i = 0; i < MahalleAdı.Length; i++)
            {
                Console.WriteLine((pq.remove()).mahalleAdı);
                Console.WriteLine(pq.isEmpty());

            }

            //############# 3B #############
            //Öncelikli Kuyruğun gerçekleştiriminde altyapıda mahallelerin tutulmasında List yerine dizi kullanılırsa kuyruktan her eleman çıkardığımızda manuel olarak dizi içerisinde 
            //kaydırma yapmamız gerekir. List veri yapısı bunu otomatik yapıyor.











            Console.ReadLine();


        }
    }
  
    class MahalleSınıfı
    {
        public string mahalleAdı;
        public List<TeslimatSınıfı> liste = new List<TeslimatSınıfı>();

        public MahalleSınıfı(string ma)
        {
            this.mahalleAdı = ma;
          
        }
        
    }

    class TeslimatSınıfı
    {
        public string yemekAdı;
        public int adet;

        public TeslimatSınıfı(string y,int a)
        {
            this.yemekAdı = y;
            this.adet = a;

        }
    }



    //Chapter 4teki stackı güncelledim
    class Stack_Moto_Kurye
    {
        private int maxSize; // size of stack array
        private MahalleSınıfı[] stackArray;
        private int top; // top of stack
    //-------------------------------------------------------------

     public Stack_Moto_Kurye(int s) // constructor
            {
                maxSize = s; // set array size
                stackArray = new MahalleSınıfı[maxSize]; // create array
                top = -1; // no items yet
            }
    //-------------------------------------------------------------
    
     public void push(MahalleSınıfı j) // put item on top of stack
            {
                stackArray[++top] = j; // increment top, insert item
            }
    //-------------------------------------------------------------
    
     public MahalleSınıfı pop() // take item from top of stack
            {
                return stackArray[top--]; // access item, decrement top
            }
    //-------------------------------------------------------------
    
     public MahalleSınıfı peek() // peek at top of stack
            {
                return stackArray[top];
            }
    //-------------------------------------------------------------
    
     public bool isEmpty() // true if stack is empty
            {
                return(top == -1);
            }
    //-------------------------------------------------------------
    
     public bool isFull() // true if stack is full
            {
                return (top == maxSize - 1);
            }
        //-------------------------------------------------------------

    } // end class Stack_Moto_Kurye




    //Chapter 4teki Queue'yu güncelledim
    class Queue_Moto_Kurye
    {
        private int maxSize;
        private MahalleSınıfı[] queArray;
        private int front;
        private int rear;
        private int nItems;
    //-------------------------------------------------------------
    
     public Queue_Moto_Kurye(int s) // constructor
            {
                maxSize = s;
                queArray = new MahalleSınıfı[maxSize];
                front = 0;
                rear = -1;
                nItems = 0;
            }
    //-------------------------------------------------------------
    
     public void insert(MahalleSınıfı j) // put item at rear of queue
            {
                if (rear == maxSize - 1) // deal with wraparound
                    rear = -1;
                queArray[++rear] = j; // increment rear and  insert
                 nItems++; // one more item
            }
    //-------------------------------------------------------------
    
     public MahalleSınıfı remove() // take item from front of queue
            {
                MahalleSınıfı temp = queArray[front++]; // get value and incr front
                if (front == maxSize) // deal with wraparound
                    front = 0;
                nItems--; // one less item
                return temp;
            }
    //-------------------------------------------------------------
    
     public MahalleSınıfı peekFront() // peek at front of queue
            {
               
            return queArray[front];
            }
    //-------------------------------------------------------------
    
     public bool isEmpty() // true if queue is empty
            {
                return (nItems == 0);
            }
    //-------------------------------------------------------------
    
     public bool isFull() // true if queue is full
            {
                return (nItems == maxSize);
            }
    //-------------------------------------------------------------
    
     public int size() // number of items in queue
            {
                return nItems;
            }
    //-------------------------------------------------------------
    
     } // end class Queue




    //Öncelikli Kuyruk Sınıfı
    class PriorityQueue
    {    
        private List<MahalleSınıfı> queArray;
              
        private int nItems;

        public PriorityQueue()
        {          
            queArray = new List<MahalleSınıfı>();        
           
            nItems = 0;         
        }
        public void insert(MahalleSınıfı m)
        {
            queArray.Add(m);
            nItems++;
        }
        public MahalleSınıfı remove()
        {
            //burada en fazla teslimat yapılan mahalleyi arıyoruz:
            //pivot değer bulalım:
            int Max = -1;
            int MaxIndeks = -1;
            //pivottan ve diğerlerinden büyük olan değeri bulalım:
                       
            for(int i = 0; i < nItems; i++)
            {
                MahalleSınıfı tempM = queArray[i];
                
                int tempMax = 0;
                int adet = tempM.liste.Count;
                while (adet != 0) 
                {
                    adet--;
                    tempMax++;
    
                }
                if (tempMax > Max)
                {
                    Max = tempMax;
                    MaxIndeks = i;
                }

            }
            nItems--;
            MahalleSınıfı rM = queArray[MaxIndeks];
            queArray.RemoveAt(MaxIndeks);

            return rM ;
        }


        public bool isEmpty()
        {
            return (nItems == 0);
        }

    }
}
