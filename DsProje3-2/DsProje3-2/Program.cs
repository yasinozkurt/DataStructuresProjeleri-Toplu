using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsProje3_2
{
    class Program
    {
        static void Main(string[] args)
        {

        

            string[] mahalleler = { "Erzene", "Kazımdirik", "İnönü", "Kızılay", "Kemalpaşa" ,"Serintepe","Naldöken","Karacaoğlan","Yeşilova","Yeşilçam"};
            int[] nüfuslar = { 35135, 33934, 25778, 15795, 11742,6905,9892,8818,31008,4095 };

            //################# 2 A kısmı #######################



            Hashtable HTable = new Hashtable();


            for(int i = 0; i < mahalleler.Length; i++)
            {
                HTable.Add(mahalleler[i], nüfuslar[i]);
            }


            //################# 2 B kısmı #######################

            string başHarf = "K";


            ArrayList alist = new ArrayList(HTable.Keys); // keyleri bir arrayliste dolduruyoruz


            for(int i = 0; i < mahalleler.Length; i++)
            {
                
               

                if ((((string)alist[i])[0].ToString()).Equals(başHarf))// baş harfi verilen mahallenin nüfusunu bir artırıp bastırıyoruz
                {
                   
                    Console.Write((string)alist[i]+"   eski nüfus: ");
                    Console.Write(HTable[alist[i]]);
                    HTable[alist[i]] = (int)HTable[alist[i]] + 1;
                    Console.WriteLine(" yeni nüfus: " +HTable[alist[i]]);
                }
            }



            Console.Read();
        }
    }



}       


