using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsProject2._2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Program başlatıldı...");
            Console.WriteLine();



            double[,] veriSeti = { {6,5,1 }, {2,4,1 }, {-3,-5,-1 }, {-1,-1,-1 }, {1,1,1 }, {-2,7,1 }, {-4,-2,-1 }, {-6,3,-1 } };

            double[,] testVeri1 = { {7,4,1 }, {6,6,1 }, {-4,-4,-1 }, {-2,8,1 } };
            double[,] testVeri2 = { {-7,2,-1 }, {-8,3,-1 }, {-1,-2,-1 }, {4,4,1 },{7,5,1 } };
            double[,] testVeri3 = { { 6, 5, 1 }, { 2, 4, 1 }, { -3, -5, -1 }, { -1, -1, -1 }, { 1, 1, 1 }, { -2, 7, 1 }, { -4, -2, -1 }, { -6, 3, -1 } };
            double[,] testVeri4 = { {6,4,1 }, {-5,-4,-1 }, {-3,-4,-1 }, {3,3,1 },{1,1,1 },{3,6,1 },{2,1,1 },{ 2,2,1} };
            double[,] testVeri5 = { { -8,3,-1}, {6,5,1 }, {-3,-3,-1 }, {4,4,1 },{4,6,1 } };
            //Halihazırda 1 tur dönmeye ayarlı 'Learn' metodunu for içinde istediğimiz epok değerinde kullanabiliriz

            //birinci dönüş nöron1de 10 epok için:
            int epoch = 10;
            Neuron nöron1 = new Neuron();
            double cAccuracy=0;
            for(int i = 0; i < epoch; i++)
            {
                
                cAccuracy=nöron1.Learn(veriSeti);
              
              




            }
            Console.WriteLine( "10 epokluk verilen eğitim seti sonucundaki doğruluk değeri:");
            Console.WriteLine("%"+cAccuracy);
            Console.WriteLine();


            //ikinci dönüş nöron1 100 epok için:
            int epoch2 = 100;
            //Neuron nöron2 = new Neuron();
            double cAccuracy2 = 0;
            for(int j = 0; j < epoch2; j++)
            {
                cAccuracy2 = nöron1.Learn(veriSeti);

            }
            Console.WriteLine("100 epokluk verilen eğitim seti sonucundaki doğruluk değeri:");
            Console.WriteLine("%" + cAccuracy2);
            Console.WriteLine();



            //TEST KISMI:
            Console.WriteLine("Test verileri ile ölçülen (az önce eğitilmiş nöron 1 için) doğruluk değerleri sırasıyla:");

            //1. test seti:
            Console.WriteLine("Test 1 doğruluk değeri: %"+nöron1.Test(testVeri1));

            //2. test seti:
            Console.WriteLine("Test 2 doğruluk değeri: %" + nöron1.Test(testVeri2));

            //3. test seti:
            Console.WriteLine("Test 3 doğruluk değeri: %" + nöron1.Test(testVeri3));

            //4. test seti:
            Console.WriteLine("Test 4 doğruluk değeri: %" + nöron1.Test(testVeri4));

            //5. test seti:
            Console.WriteLine("Test 5 doğruluk değeri: %" + nöron1.Test(testVeri5));


            Console.Read();
        }
    }

    class Neuron
    {
        private double w1;
        private double w2;
        private double learingRate = 0.05;


        public Neuron()
        {
            Random r = new Random();
          
            this.w1 = r.NextDouble() * (double)(2)-(double)1;
            this.w2 = r.NextDouble() * (double)(2)-(double)1;
        }


        public double Learn(double[,] trainSet)
        {
            double valueY = 0;
            int CorrectAnsw = 0;
            int WrongAnsw = 0;
            double accuracy;         
            //eğitim setindeki verileri sırayla alıp işliyoruz
            for(int i=0;i< trainSet.GetLength(0); i++)
            {
                double x1 = trainSet[i,0] /10;
                double x2 = trainSet[i,1] /10;

                //Calculation Section        
                double sum = ((x1) * this.w1) + ((x2) * this.w2);           
                if (sum < 0.5)
                {
                    valueY = -1;
                }
                else if (sum >= 0.5)
                {
                    valueY = 1;
                }            
                //Learning Section
                //bulunan değer hedef değerden büyükse: 
                if (trainSet[i,2] < valueY)
                {
                    this.w1 = this.w1 + (learingRate * (trainSet[i,2] - valueY) * (double)(x1));
                    this.w2 = this.w2 + (learingRate * (trainSet[i,2] - valueY) * (double)(x2 ));
                 
                    WrongAnsw++;                                 
                }
                //bulunan değer hedef değerden küçükse:
                else if(trainSet[i,2]> valueY)
                {
                    this.w1 = this.w1 + (learingRate * (trainSet[i,2] - valueY) * (double)(x1));
                    this.w2 = this.w2 + (learingRate * (trainSet[i,2] - valueY) * (double)(x2));
                 
                    WrongAnsw++;                   
                }
                else
                {
                    CorrectAnsw++;                  
                }
            }

            //doğruluk değeri:                    
           
            accuracy = (double)CorrectAnsw / (double)(CorrectAnsw + WrongAnsw);
         
            double accuracyy= (double)accuracy*100;
            return accuracyy;        
        }
        //BU ÜSTTEKİ LEARN METODUNUN W1 VE W2 Yİ DEĞİŞTİRMEDEN SADECE TEST EDEN HALİ
        public double Test(double[,] trainSet)
        {
            double valueY = 0;
            int CorrectAnsw = 0;
            int WrongAnsw = 0;
            double accuracy;
            //eğitim setindeki verileri sırayla alıp işliyoruz
            for (int i = 0; i < trainSet.GetLength(0); i++)
            {
                double x1 = trainSet[i, 0] / 10;
                double x2 = trainSet[i, 1] / 10;

                //Calculation Section
             
                double sum = ((x1) * this.w1) + ((x2) * this.w2);
              

                if (sum < 0.5)
                {
                    valueY = -1;

                }
                else if (sum >= 0.5)
                {
                    valueY = 1;
                }
           

                //Test Section
                //bulunan değer hedef değerden büyükse: 
                if (trainSet[i, 2] < valueY)
                {
                    WrongAnsw++;                   
                }
                else if (trainSet[i, 2] > valueY)
                {                   
                    WrongAnsw++;              
                }
                else
                {
                    CorrectAnsw++;              
                }
            }

            //doğruluk değeri:      
            accuracy = (double)CorrectAnsw / (double)(CorrectAnsw + WrongAnsw);
         
            double accuracyy = (double)accuracy * 100;
            return accuracyy;

        }
    }
}
