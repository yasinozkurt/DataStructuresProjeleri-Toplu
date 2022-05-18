using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsProje3
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //Ağacı oluşturuyoruz (rastgele yemek ekleme vb listeye ekleme işleri ilgili sınıfların constructor metodlarında yapılıyor.)
            Tree ağaç1 = new Tree();
            ağaç1.elemanEkle("Evka 3");
            ağaç1.elemanEkle("Özkanlar");
            ağaç1.elemanEkle("Atatürk");
            ağaç1.elemanEkle("Erzene");
            ağaç1.elemanEkle("Kazımdirik");
            Console.WriteLine("Girilen mahalleye verilen 150 TL üstü siparişler ve her birinin içeriği:");
            ağaç1.Listele("Özkanlar");
            Console.WriteLine("#######################################################################################################");
            ağaç1.derinlikBulVeYazdır();
            
            Console.WriteLine("#######################################################################################################");
            string siparişVerilenYemek = "hamburger";
            int adet=ağaç1.kaçAdet(siparişVerilenYemek);
            Console.WriteLine(adet + " adet "+siparişVerilenYemek+ " sipariş edilmiş, hepsine yüzde 10 indirim uygulandı");




            Console.WriteLine("çalıştı");



            
            Console.ReadLine();

        }
    }



    class MahalleSınıfı
    {
        public MahalleSınıfı r;
        public MahalleSınıfı l;
        public string mahalleAdı;
        public ArrayList SiparişListesi;
        public static Random random= new Random();

        //Bu yapıcı metodda yemeksınıfı nesnelerinden oluşan sipariş bilgileri  listelerini siparişlistesi adlı büyük
        //listeye kaydediyoruz
        public MahalleSınıfı(string MA)
        {
        
            SiparişListesi=new ArrayList();

           
            this.mahalleAdı = MA;

           
            int siparişSayısı = random.Next(5)+5;

            int yemekSayısı;
        
          
            for (int i = 0; i < siparişSayısı; i++)
            {
                yemekSayısı = random.Next(2) + 3;
                ArrayList SiparişBilgileri = new ArrayList();
                for(int j = 0; j < yemekSayısı; j++)
                {
                    SiparişBilgileri.Add(new YemekSınıfı(random));
                    

                }
                SiparişListesi.Add(SiparişBilgileri);
            }

        }
       
    }

    //######################################################################################

    class YemekSınıfı
    {
        public string yemekAdı;
        public int adet;
        public  double birimFiyatı;
        //Yemek adı ve birim fiyatları için önceden hazırlanmış static yapılı listeler:
        static string[] yemekler = { "pizza", "pide", "kebap", "patlıcan musakka", "mantı", "sarma", "mercimek köftesi", "hamburger" };
        static int[] birimFiyatları = { 17, 16, 25, 32, 9, 20, 12, 7 };


        public YemekSınıfı(Random r)
        {
          
            int yemek = r.Next(7);
            this.yemekAdı = yemekler[r.Next(8)];
            this.adet = r.Next(7)+1;
            this.birimFiyatı =birimFiyatları[r.Next(8)];
        }
       
    }


    //######################################################################################


    class Tree
    {
        private MahalleSınıfı root;

        public Tree()
        {
            root = null;
        }
       
        public void elemanEkle(string mahalleAdı)
        {
            MahalleSınıfı newNode = new MahalleSınıfı(mahalleAdı);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                MahalleSınıfı current = root;
                MahalleSınıfı parent;
                while (true)
                {
                    parent = current;
                    if (string.Compare(mahalleAdı, current.mahalleAdı)>0)// sola gitme durumu:
                    {
                        current = current.l;
                        if (current == null)
                        {
                            parent.l = newNode;
                            return;                       
                        }
                    }
                    else// sağa gitme durumu
                    {
                        current = current.r;
                        if (current == null)
                        {
                            parent.r = newNode;
                            return;
                        }
                    }
                }                                             
            }            
        }

        //############################################################################################################################33


        public void Listele(string MahalleAdı)
        {
            ArrayList liste = new ArrayList();
                    
            void traverse(MahalleSınıfı node)
            {                                                           
                if (node != null)
                {

                    if (node.mahalleAdı == MahalleAdı)//adı verilen mahalle adını bulduk
                    {                   
                        foreach(ArrayList l in node.SiparişListesi)// Bu mahalleden yapılan her bir sipariş için dönecek
                            
                        {
                            double busiparişToplamı = 0;
                            int index = 0;
                           foreach(YemekSınıfı y in l)// Yapılan her bir siparişteki yemek çeşidi kadar dönecek
                            {
                                busiparişToplamı += y.adet * y.birimFiyatı;
                            }
                            if (busiparişToplamı > 150)
                            {
                                Console.WriteLine("sipariş toplamı: "+busiparişToplamı);
                                foreach (YemekSınıfı y in l)// Yapılan her bir siparişteki yemek çeşidi kadar dönecek
                                {
                                    Console.WriteLine("Yemek adı: " + y.yemekAdı + " Adedi: " + y.adet + " Birim fiyatı: " + y.birimFiyatı + " Bu yemek için toplam fiyat: " + y.birimFiyatı * y.adet);
                                }
                            }
                        }
                    }                  
                    traverse(node.l);
                    traverse(node.r);              
                }                                
            }
            traverse(root);
            Console.WriteLine();
        }
//############################################################################################################################33
        public void derinlikBulVeYazdır()
        {
          
            int traverse(MahalleSınıfı node)
            {

                if (node != null)                  
                {
                    int index = 0;
                    Console.WriteLine(node.mahalleAdı);
                    foreach (ArrayList l in node.SiparişListesi)// Bu mahalleden yapılan her bir sipariş için dönecek
                        {
                        Console.WriteLine(index+1 + ". sipariş");
                        Console.WriteLine("---------------------------");
                        index++;
                        
                                foreach (YemekSınıfı y in l)// Yapılan her bir siparişteki yemek çeşidi kadar dönecek
                                {
                                  
                                    
                                    Console.WriteLine("Yemek adı: " + y.yemekAdı + " Adedi: " + y.adet + " Birim fiyatı: " + y.birimFiyatı + " Bu yemek için toplam fiyat: " + y.birimFiyatı * y.adet);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();


                    int lDepth=traverse(node.l);
                    int rDepth=traverse(node.r);

                    if (lDepth > rDepth)
                        return (lDepth + 1);
                    else
                        return (rDepth + 1);
                }
                return -1;
                
            }
            int derinlik=traverse(root);

            Console.WriteLine("DERİNLİK: " + derinlik);

        }


      
        public int kaçAdet(string YemekAdı)
        {
            int kaçAdet = 0;
          

            void traverse(MahalleSınıfı node)
            {
                if (node != null)
                {                                   
                    foreach (ArrayList l in node.SiparişListesi)// Bu mahalleden yapılan her bir sipariş için dönecek
                    {
                     
                        foreach (YemekSınıfı y in l)// Yapılan her bir siparişteki yemek çeşidi kadar dönecek
                        {
                            if (YemekAdı == y.yemekAdı)
                            {
                                
                                kaçAdet+=y.adet;
                              
                                y.birimFiyatı = (y.birimFiyatı * 9) / 10;
                            }                        
                        }
                    }
                  
                    traverse(node.l);
                    traverse(node.r);
                }            
            }
          
            traverse(root);

            return kaçAdet;
        }
    }
 }

