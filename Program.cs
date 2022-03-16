using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization; 
using System.Collections;                //used to store different type of data[non-generic]
using System.Collections.Generic;        //used to store single type of data
using System.Threading;                  //Function delegate
using System.Threading.Tasks;            //Action delegate


namespace ConsoleApp3
{
    /*
    // Delegate:-
    delegate void MyDelegate();
    class demo
    {
        public void method1()
        {
            Console.WriteLine("Hello");
        }
        public void method2()
        {
            Console.WriteLine("C# Programming");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            demo obj = new demo();
            MyDelegate del1 = new MyDelegate(obj.method1);
            del1();
            MyDelegate del2 = new MyDelegate(obj.method2);
            del2();
        }
    }

=========================================================================================================================================================================


    delegate void MyDelegate(string s1, string s2);
    class demo
    {
        public void method1(string s1, string s2)
        {
            Console.WriteLine(s1 + s2);
        }
        public void method2(string s1, string s2)
        {
            Console.WriteLine(string.Concat(s1, s2));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            demo obj = new demo();
            MyDelegate del1 = new MyDelegate(obj.method1);
            del1("C#", ".NET");
            MyDelegate del2 = new MyDelegate(obj.method2);
            del2(".NET", "Fullstack");
        }
    }

    
     ==========================================================================================================================================

    //Multicast Deligates or Nested Deligates:-

    delegate void Mydelegate(int a, int b);

    class demo
    {
        public void method1(int a, int b)
        {
            Console.WriteLine("Add:-" + (a + b));
        }
        public void method2(int a , int b)
        {
            Console.WriteLine("Sub:-" + (a - b));
        }
        public void method3(int a, int b)
        {
            Console.WriteLine("Product:-" + (a * b));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            demo obj = new demo();
            Mydelegate del1 = new Mydelegate(obj.method1);
            del1(10, 20);
            Mydelegate del2 = new Mydelegate(obj.method2);
            del2(10, 20);
            Mydelegate del3 = new Mydelegate(obj.method3);
            del3(10, 20);


            Console.WriteLine("------------------------------------------");

            Mydelegate del4 = del1 + del2 + del3;      //Multicast Deligate
            del4(50, 25);

            Mydelegate del5 = del1 + del2 - del3;      //Multicast Deligate
            del5(25, 20);
        }
    }
    
     ==========================================================================================================================================

    // Events:

    //event>delegate>method
    //events are created using keyword
    //it cannot return values it is always void, it is associated with event handler

    class demo
    {
        public delegate void DG_NUMBERS();
        public event DG_NUMBERS ev_oddno;
        public event DG_NUMBERS ev_evenno;

        public void add()
        {
            int a, b;
            Console.WriteLine("Enter two numbers:-");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            int res = a + b;
            if (res % 2 != 0)
                ev_oddno();
            else
                ev_evenno();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            demo obj = new demo();
            obj.ev_oddno += new demo.DG_NUMBERS(msg1);
            obj.ev_evenno += new demo.DG_NUMBERS(msg2);
            obj.add();

            static void msg1()
            {
                Console.WriteLine("Odd Number");
            }
            static void msg2()
            {
                Console.WriteLine("Even Number");
            }

        }
    }
    
     ==========================================================================================================================================

    // File Handling:-  FILE, Fileinfo,streamwriter, streamreader, Binarywriter and binaryreader
    // using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText(@"D:\Myfile1.txt", "this is file handling using io namespace");

            //string str = File.ReadAllText("D:\\Myfile1.txt");
            //Console.WriteLine(str);
        }
    }

    ==========================================================================================================================================

    class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter bw = new BinaryWriter(File.Open("D:\\File1.dat", FileMode.Create));     //BinaryWriter
            bw.Write(10);
            bw.Write("Hello");
            bw.Write(123.23);
            bw.Close();

            //BinaryReader br = new BinaryReader(File.Open("D:\\File1.dat", FileMode.Open));          //BinaryReader
            //Console.WriteLine(br.ReadInt32());
            //Console.WriteLine(br.ReadString());
            //Console.WriteLine(br.ReadDouble());
            //br.Close();
        }
    }

    
    ==========================================================================================================================================


    // FileStream:-

    class Program
    {
        static void Main(string[] args)
        {
            //byte[] b1 = new byte[] { 10, 20, 30, 40, 50, 60, 70 };
            //FileStream fs = new FileStream("d:\\Demo1.txt", FileMode.Create);
            //fs.Write(b1, 0, b1.Length);
            //fs.Close();

            FileStream fs = new FileStream("d:\\Demo1.txt", FileMode.Open);
            fs.Seek(0, SeekOrigin.Begin);
            for(int i = 0;i<fs.Length;i++)
            {
                Console.WriteLine(fs.ReadByte());
            }
            fs.Close();
        }
    }
       
    ==========================================================================================================================================

    // Streamwriter and streamreader:-

    {
    
    }
 
    ==========================================================================================================================================

    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("d:\\Demo2.txt"))
            {
                FileStream fs = new FileStream("d:\\Demo2.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                Console.WriteLine(sr.ReadLine());
                sr.Close();
                fs.Close();
            }
            else
                Console.WriteLine("File odes not exist");
        }
    }
    
    ==========================================================================================================================================
    //copyto and moveto:-
    {
    }

     ==========================================================================================================================================

    [DataContract]
    class Product
    {
        [DataMember]
        public int pid;
        [DataMember]
        public string pname;
        [DataMember]
        public double price;
        public Product()
        {
            pid = 1;
            pname = "computer";
            price = 45000;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //FileStream fs = new FileStream("D:\\file10.txt", FileMode.Create);
            //Product Pobj = new Product();
            //DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(Product));
            //sr.WriteObject(fs, Pobj);
            //fs.Close();

            FileStream fs = new FileStream("D:\\file10.txt", FileMode.Open);
            DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(Product));
            Product Pobj = (Product)sr.ReadObject(fs);
            Console.WriteLine(Pobj.pid + "," + Pobj.pname + "," + Pobj.price);
            fs.Close();
        }
    }

      ==========================================================================================================================================

    //Array Methods:-

    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[3] { 400, 500, 600 };  // Static Array

            ArrayList List1 = new ArrayList();  // Dynamic array
            List1.Add(100);
            List1.Add(200);
            List1.Add(300);
            List1.Add(400);

            List1.AddRange(array1);

            List1.Sort();
            List1.Reverse();

            List1.Remove(300);
            List1.RemoveAt(2);
            List1.RemoveRange(0, 2);

            foreach(int i in List1)
            {
                Console.WriteLine(i);
            }
        }
    }
    
      ==========================================================================================================================================

    //Hashtable:-

    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add("XML","Extensible markup lang");
            ht.Add("JSON","javascript object notation");
            ht.Add("SOAP","SIMPLE OBJECT ACCESS PROTOCOL");
            ht.Add("XAML","Extensible Application markup lang");
            ht.Add("AJAX","Asynchronous javascript and xml");

            ICollection Ckeys = ht.Keys;

            foreach(string i in Ckeys)
            {
                Console.WriteLine(i);
            }

            ICollection CValues = ht.Values;
            foreach (string i in CValues)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("----------------------------");

            IDictionaryEnumerator IDE = ht.GetEnumerator();
            while(IDE.MoveNext())
            {
                Console.WriteLine(IDE.Key + "-->" + IDE.Value);
            }

            Console.WriteLine("----------------------------");
            foreach(DictionaryEntry DE in ht)
            {

                Console.WriteLine(DE.Key+"----"+DE.Value);
            }
        }
    }

    
      ==========================================================================================================================================

    //Sorting list class:-
    class Program
    {
        static void Main(string[] args)
        {
            SortedList ht = new SortedList();
            ht.Add("XML", "Extensible markup lang");
            ht.Add("JSON", "javascript object notation");
            ht.Add("SOAP", "SIMPLE OBJECT ACCESS PROTOCOL");
            ht.Add("XAML", "Extensible Application markup lang");
            ht.Add("AJAX", "Asynchronous javascript and xml");

            ICollection Ckeys = ht.Keys;

            foreach (string i in Ckeys)
            {
                Console.WriteLine(i);
            }

            ICollection CValues = ht.Values;
            foreach (string i in CValues)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("----------------------------");

            IDictionaryEnumerator IDE = ht.GetEnumerator();
            while (IDE.MoveNext())
            {
                Console.WriteLine(IDE.Key + "-->" + IDE.Value);
            }

            Console.WriteLine("----------------------------");
            foreach (DictionaryEntry DE in ht)
            {

                Console.WriteLine(DE.Key + "----" + DE.Value);
            }
        }
    }
        
      ==========================================================================================================================================

    //Stack:-

    class Program
    {
        static void Main(string[] args)
        {
            Stack obj = new Stack();  //it follows last in first out method [LIFO]
            obj.Push(11500);
            obj.Push(2100);
            obj.Push(30047);
            obj.Push(300);
            obj.Push(400);

            obj.Pop();
            foreach(int i in obj)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("---------------------");

            Stack obj1 = new Stack();  //it follows last in first out method [LIFO]
            obj1.Push("Nikhil");
            obj1.Push("Prasad");
            obj1.Push("Madhu");
            obj1.Push(300);
            obj1.Push(400);

            obj1.Pop();
            foreach (var i in obj1)
            {
                Console.WriteLine(i);
            }
        }
    }
        
      ==========================================================================================================================================

    //Queue Class:-

    class Program
    {
        static void Main(string[] args)
        {
            Queue obj = new Queue();   //It follows first in first out method[FIFO]
            obj.Enqueue("Hello");
            obj.Enqueue("Nikhil");
            obj.Enqueue("Welcome");
            obj.Enqueue(40);
            obj.Enqueue(58);
            obj.Enqueue(58);

            obj.Dequeue();

            foreach( var i in obj)
            {
                Console.WriteLine(i);
            }
        }
    }
       
      ==========================================================================================================================================

    class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = new List<string>();
            list1.Add("Nikhil");
            list1.Add("Is");
            list1.Add("Learning");
            list1.Add("C#.Net");

            list1.AddRange(new string[3] { "Ajax", "JQUERY", "HTML" });

            //list1.Remove("HTML");
            //list1.RemoveAt(2);
            //list1.RemoveRange(0, 2);

            list1.Sort();
            list1.Reverse();

            foreach(string i in list1)
            {
                Console.WriteLine(i);
            }
        }
    }
      
      ==========================================================================================================================================

    //Dictionary Class:-

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> di = new Dictionary<int, string>();    //SortedDictionary can be used for sorting
            di.Add(3,"ASP.NET");
            di.Add(2,"MVC");
            di.Add(1,"WPF");
            di.Add(4,"Nikhil");

            ICollection<int> keys = di.Keys;

            foreach(int i in keys)
            {
                Console.WriteLine(i);
            }

            ICollection<string> values = di.Values;

            foreach( string i in values)
            {
                Console.WriteLine(i);
            }


            IDictionaryEnumerator IDE = di.GetEnumerator();
            while(IDE.MoveNext())
            {
                Console.WriteLine(IDE.Key + "," + IDE.Value);
            }

            foreach(KeyValuePair<int,string> kvp in di)
            {
                Console.WriteLine(kvp.Key + "-->" + kvp.Value);
            }
        }
    }
     
      ==========================================================================================================================================

    // Hashset class:-

    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> hs = new HashSet<string>();
            hs.Add("HTML");
            hs.Add("HTML");       //hashsets override the duplicate elements
            hs.Add("DHTML");
            hs.Add("JAVASCRIPT");
            hs.Add("JQUERY");

            HashSet<string> hs1 = new HashSet<string>();
            hs1.Add("JAVA");
            hs1.Add("PHP");
            hs1.Add("HTML");
            hs1.Add("DHTML");

            //hs.UnionWith(hs1);
            //foreach (string i in hs)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("---------------------");

            //hs.IntersectWith(hs1);
            //foreach (string i in hs)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("---------------------");

            hs1.ExceptWith(hs);
            foreach (string i in hs1)
            {
                Console.WriteLine(i);
            }
        }
    }
    
      ==========================================================================================================================================

    //Generic stack and generic queue:-

    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> obj = new Stack<string>();  //it follows last in first out method [LIFO]
            obj.Push("hello");
            obj.Push("Nikhil");
            obj.Push("Pts");
            obj.Push("are");
            obj.Push("good");

            obj.Pop();
            foreach (string i in obj)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("--------------------------");

            Queue<string> obj1 = new Queue<string>();   //It follows first in first out method[FIFO]
            obj1.Enqueue("Hello");
            obj1.Enqueue("Nikhil");
            obj1.Enqueue("Welcome");
            obj1.Enqueue("Its");
            obj1.Enqueue("good");
            obj1.Enqueue("Day");

            obj1.Dequeue();

            foreach (var i in obj1)
            {
                Console.WriteLine(i);
            }
        }
    }

      ==========================================================================================================================================

    class Book<T1,T2,T3>   // User defined generic class
    {
        T1 Bid;
        T2 Bname;
        T3 Bprice;

        public Book(T1 Bid, T2 Bname, T3 Bprice)
        {
            this.Bid = Bid;
            this.Bname = Bname;
            this.Bprice = Bprice;
        }
        public void print()
        {
            Console.WriteLine($"Book id:{this.Bid}");
            Console.WriteLine($"Book Name:{Bname}");
            Console.WriteLine($"Book Price:{Bprice}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book<int, string, double> Bobj1 = new Book<int, string, double>(1, "C#.NET", 4.4);
            Bobj1.print();
            Book<int, string, string> Bobj2 = new Book<int, string, string>(2, "C#.NET", "$56");
            Bobj2.print();
            Book<string, string, string> Bobj3 = new Book<string, string, string>("V005C", "C#.NET", "$87");
            Bobj3.print();

        }
    }
    
      ==========================================================================================================================================

    //Exception Handling:-

    //trry - catch method:-

    class Program
    {
        static void Main(string[] args)
        {
            Stack obj = new Stack();
            obj.Push("Hello");
            obj.Push("Hii");
            obj.Push("Welcome");
            obj.Push(300);
            obj.Push(400.34);

            try
            {
                foreach(string D in obj)
                {
                    Console.WriteLine(D);
                }
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
      ==========================================================================================================================================

    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            a = 100;
            b = 4;
            try
            {
                Console.WriteLine("Result:-" + (a / b));
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("End of program");
            }
        }
    }
    
      ==========================================================================================================================================

    class Program
    {
        static void Main(string[] args)
        {

            int[] a = new int[] { 11, 22, 33, 44, 55 };
            int[] b = new int[3];

            try
            {
                a.CopyTo(b, 0);
                foreach(int i in b)
                {
                    Console.WriteLine(i);
                }
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Destination array length is not sufficient");
            }
            finally
            {
                Console.WriteLine("End of the program");
            }
        }
    }
    
      ==========================================================================================================================================
    
    //Throw:-

    class demo
    {
        public void validate(string username)
        {
            if (username.Length >= 3 && username!="null")
                Console.WriteLine("welcome ....." + username);
            else
                throw new ArgumentNullException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string username;
            Console.WriteLine("enter your name:");
            username = Console.ReadLine();
            try
            {
                demo obj = new demo();
                obj.validate(username);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("Invalid username");
            }
            finally
            {
                Console.WriteLine("End of program");
            }
        }
    }
    
      ==========================================================================================================================================

    // User defined exception class:-

    class InvalidAgeException:Exception
    {
        public InvalidAgeException():base()
        {

        }
    }
    class demo
    {
        public void validate(int age)
        {
            if (age >= 18 && age <= 65)
                Console.WriteLine("Valid user");
            else
                throw new InvalidAgeException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int age;
            Console.WriteLine("Enter your age:-");
            age = int.Parse(Console.ReadLine());
            try
            {
                demo obj = new demo();
                obj.validate(age);
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine("Invalid age" + "," + ex.Source + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("End of program");
            }
        }
    }
    
      ==========================================================================================================================================

    //inner exception:- to finf error inside catch block

    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int() { 10, 20, 30, 40 };

            try
            {
                try
                {
                    for (int i = 0 ; i < 5 ; i++)
                    {
                        Console.WriteLine(a[i]);
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (File.Exists("d:\\file2.txt") == false)
                    {
                        throw new FileNotFoundException();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                if(ex.InnerException!=null)
                {
                    Console.WriteLine("Inner exception");
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    
      ==========================================================================================================================================

    //Error checking methods:-
    // dynamic: Runtime Checking
    // var: Compile time checking

    class Program
    {
        static void Main(string[] args)
        {
            //int x = 100;
            //string y = x;  //Compile time checking

            //string str = "hello";
            //int result = str;
            //-------------------------------------
            //dynamic x;
            //x = "hello";
            //string y = x;  // Runtime checking

            //Console.WriteLine(y);
            //-------------------------------------
            var x = 100;
            string y = x;
            Console.WriteLine(y);  //Compile time checking
        }
    }
    
      ==========================================================================================================================================

    class demo
    {
        public void method1(dynamic x, dynamic y)
        {
            Console.WriteLine(x + y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            dynamic v1 = 1.2;
            dynamic v2 = "HELLO";
            dynamic v3 = true;

            Console.WriteLine(v1.GetType().ToString());
            Console.WriteLine(v2.GetType().ToString());
            Console.WriteLine(v3.GetType().ToString());

            demo obj = new demo();
            obj.method1(10, 20);
            obj.method1("C#.net",6.0);
            obj.method1(1.22,6.0);
            obj.method1("MVC","Core");
        }
    }
    
      ==========================================================================================================================================
    
    //Anonymous datatype:-


    class demo
    {
        public static void display(dynamic det)
        {
            Console.WriteLine(det);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var studentdet = new { Regno = 1, Name = "Ajay", course = "Java fullstack",
            coursedet = new { Cdesc = "C#.NET,SQL,LINQ,EF-CORE,WEBAPI",Cduration = "2 months",cfee = 8500}
            };

            Console.WriteLine(studentdet.Regno + "," + studentdet.Name);
            Console.WriteLine(studentdet.course);
            Console.WriteLine(studentdet.coursedet.Cdesc);

            demo.display(studentdet);
        }
    }
    
      ==========================================================================================================================================

    // Annonymous method:-  using delegates

    delegate void method1();
    delegate void method2(int n);
    class Program
    {
        static void Main(string[] args)
        {
            method1 obj = delegate { Console.WriteLine("anonnymous method"); };
            obj();
            method2 obj1 = delegate (int n)
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine(i);
                }
            };
            obj1(5);
        }
    }
    
      ==========================================================================================================================================

    //annonymous with return type:-
    delegate int method3(int a, int b);
    delegate int method4(int n);
    class Rpogram
    {
        static void Main(string[] args)
        {
            method3 obj2 = delegate (int a, int b)
                                        {
                                            return(a + b);
                                        };
            Console.WriteLine("Sum=" + obj2(10, 20));
            method4 obj3 = delegate (int n)
            {
                int sum = 0;
                for (int i = 1; i <= n; i++)
                {
                    sum += 1;
                }
                return sum;
            };
            Console.WriteLine("Sum of numbers=" + obj3(10));
                    
        }
    }
    
      ==========================================================================================================================================

    //Extension methods:-this are writtren by static class and static methods

    static class demo
    {
        public static int ToNumber(this string value1)
        {
            return int.Parse(value1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "1234";
            int result = str1.ToNumber();
            Console.WriteLine(result);

            //int x = 100;
            //string str2 = x.ToString();
            //Console.WriteLine(str2);
        }
    }
    
      ==========================================================================================================================================

    static class example
    {
        public static void method3(this demo obj,string uname)
        {
            Console.WriteLine("welcome=" + uname);
        }
        public static void method4(this demo obj,string fname, string lname)
        {
            Console.WriteLine($"{fname}.{lname}@gmail.com");
        }
    }
    class demo
    {
        public void method1()
        {
            Console.WriteLine("First method");
        }
        public void method2()
        {
            Console.WriteLine("Second meethod");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            demo obj = new demo();
            obj.method1();
            obj.method2();
            obj.method3("Nikhil");           //with this method we dont need to create new another object to access the method3 or method4
            obj.method4("Nikhil","Prasad");
        }
    }
    
      ==========================================================================================================================================

    // Multithreading:- A thread is an independent execution path,these paths can run simultaneously with other threads in order to achieve multithreading.

    class demo
    {
        public void function1()
        {
            for(int i = 0;i < 5;i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(2000);     //it shows parallel execution of 2 or 3 or multiple different threads
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            demo obj = new demo();
            Thread th1 = new Thread(new ThreadStart(obj.function1));
            th1.Start();

            Thread th2 = new Thread(new ThreadStart(obj.function1));
            th2.Start();

            Thread th3 = new Thread(new ThreadStart(obj.function1));
            th3.Start();
        }
    }
    
      ==========================================================================================================================================

    // Lock in thread or Thread Synchronization:- it allows only one thread to acces the resource, no other thread are allowed to interupt,until 
    // the specified task is completed by thread. It shares the resource and executes asynchronous[deposits and withdrawls]

    class demo
    {
        public void function1()
        {

            lock (this)              // it dosen't allows all threads to get access simultaneously
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(2000);      
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            demo obj = new demo();
            Thread th1 = new Thread(new ThreadStart(obj.function1));
            th1.Start();

            Thread th2 = new Thread(new ThreadStart(obj.function1));
            th2.Start();

            Thread th3 = new Thread(new ThreadStart(obj.function1));
            th3.Start();
        }
    }
    
      ==========================================================================================================================================

    //Threadpool:-multithreading takes too much time thats why we use threadpool
    // It is a collection / group of preconfigured threads which handles the n number of requests which are coming in.
    // "ThreadPool" class is available under System.Threading namespace.
    // It increases the responsiveness of application.

    class demo
    {
        public void function1(object threadno)
        {
            string tname = "Thread:-" + threadno.ToString();
            for(int i = 0;i<10;i++)
            {
                Console.WriteLine(tname + ":" + i);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            demo obj = new demo();
            for(int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(obj.function1), i);
                Thread.Sleep(2000);
            }
        }
    }
    
      ==========================================================================================================================================

    // Tight coupling and loose coupling

    // Tightly Coupled code:

    class Demo        //developer get access to this class
    {
        public void add()
        {
            Console.WriteLine("add method");
        }
        public void diff()
        {
            Console.WriteLine("susbstract method");
        }
        public void square()
        {
            Console.WriteLine("square method");
        }
        public void area()
        {
            Console.WriteLine("area method");
        }
    }
    class dependencyInj   // clientcget access for this class
    {
        Demo obj = new Demo();
        public void compute()
        {
            obj.add();
            obj.diff();
            obj.square();
            obj.area();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            dependencyInj d1 = new dependencyInj();
            d1.compute();
        }
    }
    
      ==========================================================================================================================================

    // Loosely coupled code:-  we were not dependent on client code

    interface  Icalculator
    {
        void calculate();
    }
    class Add : Icalculator
    {
        public void calculate()
        {
            Console.WriteLine("Sum");
        }
    }
    class Sub : Icalculator
    {
        public void calculate()
        {
            Console.WriteLine("Sub");
        }
    }
    class Square : Icalculator
    {
        public void calculate()
        {
            Console.WriteLine("Square");
        }
    }
    class Cube : Icalculator
    {
        public void calculate()
        {
            Console.WriteLine("Cube");
        }
    }
    class DependencyInj     //Client
    {
        Icalculator objcal = null;
        public DependencyInj(Icalculator obj)   // Dependency obj
        {
            objcal = obj;
        }
        public void compute()
        {
            objcal.calculate();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DependencyInj d1 = new DependencyInj(new Add());
            d1.compute();
            DependencyInj d2 = new DependencyInj(new Sub());
            d2.compute();
            DependencyInj d3 = new DependencyInj(new Square());
            d3.compute();
            DependencyInj d4 = new DependencyInj(new Cube());
            d4.compute();
        }
    }
    
      ==========================================================================================================================================

    // Generic Delegates:-function,action and predicate

    //Func delegate:

    class Sample
    {
        public static int addition(int a,int b)
        {
            return (a + b);
        }
        public static string function1(string x, string y, string z)
        {
            return string.Concat(x, y, z);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> res1 = new Func<int, int, int>(Sample.addition);
            Console.WriteLine("sum="+res1(10, 20));

            Func<string, string, string, string> res2 = new Func<string, string, string, string>(Sample.function1);
            Console.WriteLine("New strng is="+res2("Mo0del", "View", "Controller"));
        }
    }
    
      ==========================================================================================================================================

    class Demo
    {
        public static int lstring(string a)
        {
            return a.Length;
        }
        public static double ave(int m1, int m2, int m3, int m4)
        {
            return ((m1 + m2 + m3 + m4) / 4);
        }
        public static double ar(int b , int h)
        {
            return (0.5 * b * h);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> res1 = new Func<string, int>(Demo.lstring);
            Console.WriteLine("Length of string is:-" + res1("Nikhil"));

            Func<int, int, int, int, double> res2 = new Func<int, int, int, int, double>(Demo.ave);
            Console.WriteLine("Average :-" + res2(10, 20, 30, 40));

            Func<int, int, double> res3 = new Func<int, int, double>(Demo.ar);
            Console.WriteLine("Aeraof triangle is:-" + res3(10, 20));

        }
    }
    
      ==========================================================================================================================================

    //Action delegate:-  their is no return type

    class sample
    {
        public static void print1()
        {
            Console.WriteLine("Welcome");
        }
        public static void print2(string x, string y)
        {
            Console.WriteLine("New string is:-" + string.Concat(x, y));
        }
        public static void print3(int svalue,int evalue)
        {
            for(int i = svalue; i < evalue; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Action a1 = new Action(sample.print1);
            a1();

            Action<string, string> a2 = new Action<string, string>(sample.print2);
            a2("New", "York");

            Action<int, int> a3 = new Action<int, int>(sample.print3);
            a3(1, 10);
        }
    }
    
      ==========================================================================================================================================

    // Predicate delegate:-
    
    class Sample
    {
        public static bool print1(string str)
        {
            return str.StartsWith("a");
        }
        public static bool print2(string str)
        {
            return str.EndsWith("n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> p1 = new Predicate<string>(Sample.print1);
            Console.WriteLine(p1("ajay"));

            Predicate<string> p2 = new Predicate<string>(Sample.print2);
            Console.WriteLine(p2("Delhi"));
        }
    }
    
      ==========================================================================================================================================

    //Task parallel library[tpl]:-

    class sample
    {
        //Synchronous Programming
        public void print()
        {
            Console.WriteLine("Function");
            Thread.Sleep(2000);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            sample obj = new sample();
            obj.print();

            for(int i = 0;i < 5; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("End");
        }
    }
    
      ==========================================================================================================================================


    // Asynchronous Programming:-

    class sample
    {
        public void print()
        {
            for(int i = 0; i < 10;i++)
            {
                Console.WriteLine(i);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            sample obj = new sample();

            //Task task1 = new Task(obj.print);
            //task1.Start();

            //Task task1 = Task.Factory.StartNew(obj.print);

            //Task task1 = Task.Run(() => { obj.print(); });

            Task task1 = Task.Run(new Action(obj.print));

            Console.WriteLine("End");

            Console.ReadKey();
        }
    }
    
      ==========================================================================================================================================

    // IComparable


    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = { "WPf", "WCF", "MVC", "ASP.NET", "VB.NET" };
            Array.Sort(array1);

            foreach (var i in array1)
            {
                Console.WriteLine(i);
            }
        }
    }

      ==========================================================================================================================================

    class TechDet:IComparable
    {
        public int tid { get; set; }
        public string tname { get; set; }
        public double tduration { get; set; }

        public int CompareTo(object obj)
        {
            TechDet tobj = obj as TechDet;
            if(tobj != null)
            {
                return this.tname.CompareTo(tobj.tname);
            }
            return -1;
        }
    }

    class Durationcomparer: IComparer<TechDet>
    {
        public int Compare(TechDet x, TechDet y)
        {
            return x.tduration.CompareTo(y.tduration);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TechDet[] techarrayobj = new TechDet[]
            {
                new TechDet{tid = 1, tname = "WPf",tduration = 4},
                new TechDet{tid = 2, tname = "WCF",tduration = 1},
                new TechDet{tid = 3, tname = "MVC",tduration = 3},
                new TechDet{tid = 4, tname = "ASP.NET",tduration = 2}
            };

            Array.Sort(techarrayobj);

            foreach (var i in techarrayobj)
            {
                Console.WriteLine(i.tname);
            }
        }
    }
    
      ==========================================================================================================================================
    */



}
