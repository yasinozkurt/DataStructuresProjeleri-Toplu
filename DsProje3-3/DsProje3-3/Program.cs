using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsProje3_3
{
    class Program
    {
        static void Main(string[] args)
        {

            //#################################### 3 A ########################################
            Console.WriteLine("#################################### 3 A ########################################");
            Console.WriteLine("Heap veri yapıları oluşturuldu");
            //Yapıldı...
            //################################## 3 B  #######################################
            Console.WriteLine("#################################### 3 B ########################################");
           


            string[] mahalleler = { "Erzene", "Kazımdirik", "İnönü", "Kızılay", "Kemalpaşa", "Serintepe", "Naldöken", "Karacaoğlan", "Yeşilova", "Yeşilçam" };
            int[] nüfuslar = { 35135, 33934, 25778, 15795, 11742, 6905, 9892, 8818, 31008, 4095 };
            HeapMahalle hm = new HeapMahalle(mahalleler.Length);
            for (int i=0;i< mahalleler.Length; i++)
            {
                hm.insert(new MahalleSınıfı(mahalleler[i], nüfuslar[i]));

            }
            Console.WriteLine("Eklediğimiz elemanları yazdırıyoruz:");
            hm.display();
            Console.WriteLine("-------------------");

            Console.WriteLine("#################################### 3 C ########################################");
            Console.WriteLine("Nüfusu en yüksek 3 elemanı  silip yazdırıyoruz:");
            Console.WriteLine(hm.remove());
            Console.WriteLine(hm.remove());
            Console.WriteLine(hm.remove());
          
            Console.WriteLine("-------------------");
         
         



            //############################################################################





            Console.ReadLine();

            
        }
    }

    //  A MADDESİ İÇİN HEAP SINIFI:
    class HeapS // max heap veri yapısı
    {
        public int[] heapArray;
        public int maxSize;
        public int currentSize;


        public HeapS(int ms)
        {
            this.maxSize = ms;
            this.currentSize = 0;
            heapArray = new int[maxSize];

        }


        public void display()
        {
            for(int i=0;i< currentSize; i++)
            {
                Console.WriteLine(heapArray[i]);
            }
        }



        //-------------------------------------------------------------------------------------------

        public bool insert(int value) // elemanı önce en sona ekliyoruz, daha sonra kendisinden büyük bir elemana denk gelene kadar yukarı çıkarıyoruz
        {
            if (currentSize == maxSize)
            {
                return false;
            }
                          
            heapArray[currentSize] = value; 
            trickleUp(currentSize++);
            return true;

            void trickleUp(int index)
            {
                int bottom = heapArray[index];
                
                int parent = (index-1)/2;            
                while(index>0 && heapArray[parent] < bottom)
                {
                    heapArray[index] = heapArray[parent];
                    index = parent;
                    parent = (parent - 1) / 2;
                   
                }
                heapArray[index] = bottom;
            }         
        } 
        //-------------------------------------------------------------------------------------------

        public int remove()
        {
            int re = heapArray[0];
           
            heapArray[0] = heapArray[--currentSize];
            trickleDown(0);

            void trickleDown(int index)
            {
                int current = index;// root değerden başladı
               
                int largerChild;
                int top = heapArray[index];


                while (current< currentSize / 2)
                {
                    int lchild = current * 2;
                    int rchild = (current * 2) + 1;
                    if(rchild < currentSize && heapArray[rchild] > heapArray[lchild])// sağ child var ve sol childdan büyükse current eleman ile yer değiştirmeli
                    {
                        largerChild = rchild;


                    }
                    else
                    {
                        largerChild = lchild;
                    }
                    //larger child bulundu

                    if(top> heapArray[largerChild])// largerchild değeri current değerden küçükse elemanın gelmesi gereken yer bulunmuştur
                    {
                        break; // daha fazla aşağı inemez anlamına geliyor

                    }
                    heapArray[current] = heapArray[largerChild];
                    current = largerChild;

                }
                heapArray[current] = top;

            }

            return re;           
        }
    }


    class MahalleSınıfı // mahalle adı ve nüfusunu tutması için sınıf oluşturmak kodu daha düzenli gösterebilir.
    {
        public string mahalleAdı;
        public int nüfus;



        public MahalleSınıfı(string ma, int n)
        {
            this.mahalleAdı = ma;
            this.nüfus = n;
        }

    }









    class HeapMahalle // max heap veri yapısı
    {
        public MahalleSınıfı[] heapArray;
        public int maxSize;
        public int currentSize;


        public HeapMahalle(int ms)
        {
            this.maxSize = ms;
            this.currentSize = 0;
            heapArray = new MahalleSınıfı[maxSize];

        }


        public void display()
        {
            for (int i = 0; i < currentSize; i++)
            {
                Console.WriteLine("Mahalle adı: "+heapArray[i].mahalleAdı +" nüfus: "+heapArray[i].nüfus);
            }
        }



        //-------------------------------------------------------------------------------------------

        public bool insert(MahalleSınıfı value) // elemanı önce en sona ekliyoruz, daha sonra kendisinden büyük bir elemana denk gelene kadar yukarı çıkarıyoruz
        {
            if (currentSize == maxSize)
            {
                return false;

            }


            heapArray[currentSize]= value;
            trickleUp(currentSize++);
            return true;


            void trickleUp(int index)
            {
                MahalleSınıfı bottom = heapArray[index];

                int parent = (index - 1) / 2;
              

                while (index > 0 && heapArray[parent].nüfus < bottom.nüfus)
                {
                    heapArray[index] = heapArray[parent];
                    index = parent;
                    parent = (parent - 1) / 2;

                }
                heapArray[index]= bottom;

            }



        }
        //-------------------------------------------------------------------------------------------

        public string remove()
        {
            MahalleSınıfı re = heapArray[0];

            heapArray[0] = heapArray[--currentSize];
            trickleDown(0);

            void trickleDown(int index)
            {
                int current = index;// root değerden başladı

                int largerChild;
                MahalleSınıfı top = heapArray[index];


                while (current < currentSize / 2)
                {
                    int lchild = current * 2;
                    int rchild = (current * 2) + 1;
                    if (rchild < currentSize && heapArray[rchild].nüfus > heapArray[lchild].nüfus)// sağ child var ve sol childdan büyükse current eleman ile yer değiştirmeli
                    {
                        largerChild = rchild;


                    }
                    else
                    {
                        largerChild = lchild;
                    }
                    //larger child bulundu

                    if (top.nüfus > heapArray[largerChild].nüfus)// largerchild değeri current değerden küçükse elemanın gelmesi gereken yer bulunmuştur
                    {
                        break; // daha fazla aşağı inemez anlamına geliyor

                    }
                    heapArray[current] = heapArray[largerChild];
                    current = largerChild;



                }
                heapArray[current] = top;


            }

            string dön = re.mahalleAdı + " "+re.nüfus.ToString();

            return dön;


        }
    }


}
