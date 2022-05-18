using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsProje4._2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("AVL ağacı için insertion methodu deneme: ");
            Console.WriteLine("");
            Console.WriteLine("########################################");

            AVL tree = new AVL();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(51);
            tree.Add(2);
            tree.Add(8);
            tree.Add(18);
            tree.Add(4);
            tree.Add(23);
            tree.Add(13);
            Console.WriteLine("AVL ağacının inorder yazdırılması:");
            tree.DisplayTree();
            Console.ReadLine();


        }
    }






    class AVL
    {

        //Jenerik yapılı olması için Node sınıfı olarak inner class
        class Node
        {
            public int data;
            public Node left;
            public Node right;
            public Node(int data)
            {
                this.data = data;
            }
        }
        Node root;
        public AVL()
        {
        }
        public void Add(int data)
        {
            Node newItem = new Node(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }

        //ELEMAN EKLEME- REKÜRSİF BİÇİMDE BİNARY YOLDA EN UYGUN YERİ BULUP NODE U EKLEYEN METHOD
        private Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.data < current.data)
            {
                //rekürsif şekilde bir leaf'e gidince balance_tree metodu çağırılıyor
                
                current.left = RecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (n.data > current.data)
            {
                current.right = RecursiveInsert(current.right, n);
                current = balance_tree(current);
            }
            return current;
        }


        //ELEMAN EKLEDİKTEN SONRA DENGESİZLİK OLUŞTUYSA KULLANILAN METHOD
        private Node balance_tree(Node current)
        {
            int b_factor = balance_factor(current);
            //1den büyükse sola doğru derinlik kaymış demek
            if (b_factor > 1)
            {
                //burada sola kaydıktan sonra da sola doğru tekrar bir kayma var mı diye bakılıyor
                if (balance_factor(current.left) > 0)
                {
                    //sadece left rotate
                    current = RotateLL(current);
                }
                else
                //önce sola sonra sağa kayma durumu
                {

                    current = RotateLR(current);
                }
            }
            //-1den küçükse sağa doğru derinlik kaymış demek
            else if (b_factor < -1)
            {
                if (balance_factor(current.right) > 0)
                {
                    //önce sağa sonra sola kayma durumu
                    current = RotateRL(current);
                }
                else
                {
                    //önce sağa sonra yine sağa kayma durumu
                    current = RotateRR(current);
                }
            }
            return current;
        }
        
       
      //AĞACI KONTROL İÇİN YAZDIRIYORUZ
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }


        //AĞACI İNORDER ŞEKLİNDE DOLAŞIP ELEMANLARI BASAN METHOD
        private void InOrderDisplayTree(Node current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.left);
                Console.Write("({0}) ", current.data);
                InOrderDisplayTree(current.right);
            }
        }
        private int max(int l, int r)
        {
            return l > r ? l : r;
        }

        //VERİLEN DÜĞÜMÜN DERİNLİĞİNİ BULAN REKÜRSİF METHOD(ÇOK BENZERİNİ PROJE 3'TE  AĞAÇ DERİNLİĞİNİ BULMAK İÇİN KULLANMIŞTIK)
        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int balance_factor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }



        //ROTATE METHODLARI

        // her eleman eklemeden sonra dengesizlik olup olmadığı kontrol edildiği için bu 4 durum dışında bir durum oluşmuyor
        //ve bu methodar işimizi görüyor

        //right right case , burada left rotation yapılıyor
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        //left left case , burada right rotation yapılıyor
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }

        //left right case, burada önce left rotation sonra right rotation yapılıyor
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        //right left case, burada çnce right sonra left rotation yapılıyor
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }




    }
}
