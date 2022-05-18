using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsProje4._3
{
    class Program
    {
        static void Main(string[] args)
        {

            //ÇEŞİTİ GRAF ALGORİTMALARINDA KULLANACAĞIM MATRİS VE LİSTELERİ ÖNCEDEN HAZIRLADIM
            int[,] graph = new int[,] { { 0, 4, 0, 0, 3},
                                      { 4, 0, 8, 0, 0},
                                      { 0, 8, 0, 7, 5},
                                      { 0, 0, 7, 0, 9},
                                      { 3, 0, 5, 9, 0} };

            // noktaların hangi noktalar ile bağlantısı olduğunu tutan liste (BFS algoritmasında kolaylık sağlaması için):
            int[] vertices = { 0, 1, 2, 3, 4 };
            int[][] adjm = new int[5][];
            adjm[0] =new int[]{ 1,4};
            adjm[1] = new int[] {0,2};
            adjm[2] = new int[] { 1, 3, 4 };
            adjm[3] = new int[] { 2, 4 };
            adjm[4] = new int[] { 0, 2, 3 };

           //Diğer BFS denemesi için farklı bir liste:
            int[] vertices2 = { 0, 1, 2, 3, 4, 5, 6 };
            int[][] adjm2 = new int[7][];
            adjm2[0] = new int[] { 1, 2 };
            adjm2[1] = new int[] { 3,4 };
            adjm2[2] = new int[] { 5,6 };
            adjm2[3] = new int[] { 1};
            adjm2[4] = new int[] {1};
            adjm2[5] = new int[] {2 };
            adjm2[6] = new int[] { 2 };

            //Dijkstra ve primde kullandım
            int[,] graphDijkstra =  {
                          { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                          { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
                          { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                          { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
                          { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                          { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                          { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
                          { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
                          { 0, 0, 2, 0, 0, 0, 6, 5, 0 }};



            //###################### Dijkstra deneme #############################


            Console.WriteLine("Dijkstra en kısa yol algoritması");

            DijkstraSP d = new DijkstraSP();

            Console.WriteLine("Dijkstra deneme 1:");

            d.DijkstraAlgo(graph, 2, 5);


            Console.WriteLine("############################");
            Console.WriteLine("Dijkstra deneme 2:");

            d.DijkstraAlgo(graphDijkstra, 3, 9);






            //###################### Prim deneme #############################
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Prim minimum spanning tree algoritması");
            Console.WriteLine("Deneme 1");
            
            PrimMSP pmsp = new PrimMSP();
            pmsp.Prim(graph, 5);
            Console.WriteLine("#############################");
            Console.WriteLine("Deneme 2");
            pmsp.Prim(graphDijkstra, 9);






            //############################ BFS DENEME ###############################
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Breadth First Search algoritması");
            Console.WriteLine("Bfs deneme1:");
            BFS( adjm, vertices);
            Console.WriteLine("##########################");
            Console.WriteLine("Bfs deneme2:");
            BFS(adjm2, vertices2);






            Console.ReadLine();





        }
        //KUYRUK YAPISI KULLANARAK OLUŞTURDUM
        static void BFS(int[][] adjM,int[] nodes)
        {
            Queue q = new Queue();
            ArrayList dolaşılanNodelar = new ArrayList();   // gezilen noktaları tutmak için

            q.Enqueue(nodes[0]);// root düğümü ekledik
           
           
            while (q.Count != 0)
            {
               

                int curNode = (int)q.Dequeue();
              
                if (!dolaşılanNodelar.Contains(curNode))
                {
                    Console.WriteLine(curNode);//Uğranan nokta
                    dolaşılanNodelar.Add(nodes[curNode]);

                    for (int i = 0; i < adjM[curNode].Length; i++)
                    {
                        q.Enqueue(adjM[curNode][i]);
                    }
                }

            }



        }
     
        
    }



    class DijkstraSP
    {
        //bu methodda roottan başlanıp daha önce hiç uğranmamış en yakın komşu bulunuyor
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
        //Yazdırıyoruz
        private static void Print(int[] distance, int verticesCount,int source)
        {
            Console.WriteLine("Vertex    Distance from vertex "+source);

            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }

        public  void DijkstraAlgo(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                //bütün değerlere uzalığı maks atıyoruz
                distance[i] = int.MaxValue;
                //tüm düğümleri ziyaret edilmedi olarak güncelliyoruz
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                //Kendisine olan en kısa uzaklık bulunmamış düğümler içinden roota en yakın olanını getiriyoruz
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;
                //hemen yukarıda tuttuğumuz düğümden diğer düğümlere en kısa yolları güncelliyoruz
                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            Print(distance, verticesCount,source);
        }

       
        
    }

    class PrimMSP
    {
        private int MinKey(int[] key, bool[] set, int verticesCount)
        {
            int min = int.MaxValue, minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (set[v] == false && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        private  void Print(int[] parent, int[,] graph, int verticesCount)
        {
            Console.WriteLine("Alınan Kenar  Ağırlık");
            for (int i = 1; i < verticesCount; ++i)
                Console.WriteLine("{0} - {1}         {2}", parent[i], i, graph[i, parent[i]]);
        }
        public  void Prim(int[,] graph, int verticesCount)
        {
            int[] parent = new int[verticesCount];
            int[] key = new int[verticesCount];
            bool[] mstSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;
            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinKey(key, mstSet, verticesCount);
                mstSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                {
                    if (Convert.ToBoolean(graph[u, v]) && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            Print(parent, graph, verticesCount);
        }


    }
}
