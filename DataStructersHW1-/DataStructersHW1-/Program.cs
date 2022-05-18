using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructersHW1_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application has started...");
            int[,] matris2 = { { 1, 2, 3}, { 1, 2, 3 }, { 1, 2, 3 } };

            int[,] matris1 = { { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 } };
            int toplam = 0;
            int matrisLenght = matris1.GetLength(0);




            //Method:

            //N satıra sahip matrisin (n+1)/2 satırını (piramit artan) toplayan for bloğu:
            int NumtoTake = 1;
            for (int i= 0; i < (matrisLenght + 1) / 2; i++)
            {
              
                for (int j = 0; j < matrisLenght; j++)
                {
                    if (i + j == (matrisLenght - 1) / 2)
                    {
                        for(int k = 0; k < NumtoTake; k++)
                        {
                            toplam += matris1[i, j+k];

                        }

                        

                    }
                }
                NumtoTake += 2;

            }
            


            //N satıra sahip matrisin (n+-)/2 satırını (piramit azalan) toplayan for bloğu:
            int startRow = (matrisLenght + 1) / 2;
            int startColumn = 1;
            int NumToTake2 = matrisLenght - 2;
            for (int i = (matrisLenght + 1) / 2; i < matrisLenght; i++)
            {
                for (int j = 0; j < NumToTake2; j++)
                {
                    toplam += matris1[startRow , startColumn+j];
                  



                }
            
                NumToTake2 -= 2;
                startColumn += 1;
                startRow += 1;


            }

            Console.WriteLine();

            Console.WriteLine("Bu matrisin karo toplamı : " + toplam);
            Console.ReadLine();
        }
        
    }
}
