/*
 Делегаты Лямбды и Ивенты Анонимные методы
Lambda Delegates and Events Anonymous Methods

Делегаты-  Хотим создать емтод в нутри метода то можем создать делегат
Делегат - Это анонимный метод.(Как лямдва в С++)
Объявляется ключевым словом 
Delegate в C# - это тип данных, который позволяет вызывать методы, не зная их конкретных сигнатур или реализаций.

Вот как это работает:

Сначала вы определяете делегата, указывая тип возвращаемого значения и параметры метода. Например:
public delegate void MyDelegate(int x, string y);
Затем вы создаете экземпляр делегата с помощью оператора new:
MyDelegate myDelegate = new MyDelegate(MethodToCall);
Теперь вы можете вызывать метод, переданный в делегат, используя myDelegate.Invoke() или myDelegate():
myDelegate.Invoke(10, "Hello");
Внутри MethodToCall вы должны реализовать логику метода с сигнатурой, указанной в определении делегата.
Важно понимать, что делегат - это просто ссылка на метод, он не выполняет метод непосредственно. 
Когда вы вызываете делегат, он в свою очередь вызывает связанный с ним метод.

Делегаты могут быть использованы для создания событий, обратного вызова и других сценариев, 
где вам нужно вызвать метод, не зная его реализации.
 .....................................................
Метод Invoke
.............................
 
Метод Invoke в C# вызывает указанный метод, который хранится в делегате. Он используется, когда вы хотите вызвать метод, связанный с делегатом, из другого места программы.

Например, у вас может быть делегат с методом, который выводит сообщение на экран:

    public delegate void PrintMessage(string message);

    // Метод, который выводит переданное сообщение на экран
    private void Print(string message)
    {
        Console.WriteLine(message);
    }

    public void CallPrintMethod()
    {
        // Создаем делегат с помощью метода Print
        PrintMessage printDelegate = new PrintMessage(Print);

        // Вызываем делегат
        printDelegate.Invoke("Hello, World!");
    }
В этом примере мы создаем делегат PrintMessage, который принимает строку и вызывает метод Print, 
который выводит эту строку на экран. Затем мы создаем экземпляр делегата и вызываем его метод Invoke,
передавая ему сообщение “Hello, World!”.


\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
Событие - Метод в Сбытие вписывается через делегат 
\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
Событие в C# используется для оповещения других объектов о том, что что-то произошло
Например, вы можете создать событие, которое оповещает всех пользователей, что новый товар поступил в продажу:

Вот пример использования события:

using System;

class Program
{
    static void Main()
    {
        Product p = new Product();

        p.ProductAvailable += HandleProductAvailable;
        p.MakeProductAvailable();
    }

    static void HandleProductAvailable(string productName, int productId)
    {
        Console.WriteLine($"Новый товар {productName} с ID {productId} поступил в продажу!");
    }
}

class Product
{
    public event EventHandler<ProductAvailableEventArgs> ProductAvailable;

    void MakeProductAvailable()
    {
        var productAvailableEventArgs = new ProductAvailableEventArgs("ProductName", 123);
        OnProductAvailable(productAvailableEventArgs);
    }

    protected virtual void OnProductAvailable(ProductAvailableEventArgs e)
    {
        EventHandler<ProductAvailableEventArgs> handler = ProductAvailable;
        if (handler != null)

 */

//..................................
//Делегаты - delegate
//..................................

//namespace _16_10_23_C_Sharp_Lambda_Delegates_and_Events_Anonymous_Methods
//{
//    internal class Program
//    {

//        delegate void Message();// Сам делегат определяется отдельно как метод

//        static void Main(string[] args)
//        {
//            Message mes = Hello;
//            mes();// В данном примере у нас mes() это метод !!!

//        }
//        static void Hello() => Console.WriteLine("World")
//    }
//}

//..................................
// Создаем Делегат - анонимный метод
//..................................

//namespace _16_10_23_C_Sharp_Lambda_Delegates_and_Events_Anonymous_Methods
//{
//    internal class Program
//    {

//        delegate void Message();// Сам делегат определяется отдельно как метод

//        static void Main(string[] args)
//        {
//            Message mes = delegate () // Это Анонимный метод
//            {
//                Console.WriteLine("I Love C#");
//            };
//            mes(); // Так мы вызываем Анонимный мкетод

//        }
//        static void Hello() => Console.WriteLine("World")
//    }
//}

//..................................
// Лямбда 
//.........................

//namespace _16_10_23_C_Sharp_Lambda_Delegates_and_Events_Anonymous_Methods
//{
//    internal class Program
//    {

//        delegate void Message2();// Сам делегат определяется отдельно как метод

//        static void Main(string[] args)
//        {
//            Message2 mes = delegate () // Это Анонимный метод
//            {
//                Console.WriteLine("I Love C#");
//            };
//            Message2 hello = () =>  // Так работает Лямда.(Нужно обрабатывать событие!!!
//            {

//            };
//            mes();

//        }
//        static void Hello() => Console.WriteLine("World")
//    }
//}


//..................................
// Событие - Метод в Сбытие вписывается через делегат 
//.........................


//namespace _16_10_23_C_Sharp_Lambda_Delegates_and_Events_Anonymous_Methods
//{
//    internal class Program
//    {

//        delegate void Message2(string msg);
//        static event Message2 Notify; // Это осбытие event
//        static void Output(string message) => Console.WriteLine(message);// Это Обработчик события
//         static void Main(string[] args)
//         {
//            Notify += Output;
//            Notify("I see you");

//         }      
//    }
//}


// Task На event

//using static _16_10_23_C_Sharp_Lambda_Delegates_and_Events_Anonymous_Methods.Program;

//namespace _16_10_23_C_Sharp_Lambda_Delegates_and_Events_Anonymous_Methods
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            People p = new People(20);
//            p.Age = 21;

//        }
//        public class People
//        {
//            private int age;

//            public int Age
//            {
//                get { return Age; }
//                set
//                {
//                    if (age != value)
//                    {
//                        age = value;
//                        PropertyChangeed(this, age);
//                    }
//                }
//            }

//            event PropertyEventHasndler PropertyChangeed;

//            public People(int age)
//            {

//                this.age = age;
//                PropertyChangeed += Output;

//            }
//            public void Output(People objekt, int age) => Console.WriteLine($" Теперь возраст человека = {Age}");
//        }

//        public delegate void PropertyEventHasndler(People sender, int Age);
//    }

//}

////////////////////
// LIST
///////////////

//using static _16_10_23_C_Sharp_Lambda_Delegates_and_Events_Anonymous_Methods.Program;

//namespace _16_10_23_C_Sharp_Lambda_Delegates_and_Events_Anonymous_Methods
//{
//    internal class Program
//    {

//        static void Main(string[] args)
//        {
//            // Это все коллекции
//          List<string> name = new List<string>(4);// vector <T> List<string>() - Это конструктор листа

//            LinkedList<string> list = new LinkedList<string>(); //Это Двусвязный список
//                                                                 //count, 
//            Queue<string> queue = new Queue<string>(4);// Очередъ . Ferst in Ferst out/
//            Stack<string> stack = new Stack<string>(4); // Стек Ferst in Last out
//            Dictionary<int, string> dict = new Dictionary<int, string>(); // Map (Ключь, Значетие)
//            SortedList<int,string> sortedlist = new SortedList<int,string>(); // Сортированный Дист
//             // Дженерики Это Классы со всеми типами которые работают. В С++ <T> Шаблонный класс.

//        }



//    }
//////////////////////////////////////////////////
// Дженерики Это Классы со всеми типами которые работают. В С++ <T> Шаблонный класс.
///////////////////////////////////

/// <summary>
/// //////////////////////
/// 
/// В C# оператор ">" не работает с обобщёнными типами. Однако, 
/// для сравнения можно использовать интерфейс IComparable<T>,
/// который позволяет определить метод CompareTo, используемый для сравнения двух объектов.

//    В вашем случае, чтобы сравнить два значения типа T,
//    нужно ограничить обобщение T на IComparable<T>, чтобы убедиться,
//    что у типа T есть метод CompareTo.Затем можно использовать метод CompareTo для сравнения значений.

//    Вот пример исправленного кода:

//public class Vector3<T> where T : IComparable<T>
//{
//    public bool F1(T t1, T t2)
//    {
//        if (t1.CompareTo(t2) > 0)
//            return false;
//        return true;
//    }
//}

//    В этом примере кода обобщение T ограничено интерфейсом IComparable<T>,
//    что позволяет использовать метод CompareTo для сравнения значений t1 и t2.
/// </summary>
/// <typeparam name="T"></typeparam>

//    public class Vector3<T1>// Дженерик. Причем Vector3 это (.)
//    {
//        public T1? x;// Тут можем описать SortedList или любую коллекцию.

//        public bool F1<T>(T t1, T t2)
//        {
//            if(t1 == null)
//                return false;
//            return true;
//        }
//    }


//}

//  Задача.На языке C# создать коллекцию List. Используя класс Vector3<T> . List должен Хранить в себе числа, Добавить или убрать элемент.
//


using System.Numerics;
using static _16_10_23_C_Sharp_Lambda_Delegates_and_Events_Anonymous_Methods.Program;

namespace _16_10_23_C_Sharp_Lambda_Delegates_and_Events_Anonymous_Methods
{

    public class Vector3<T>
    {
        public T A { get; set; }
        public T B { get; set; }
        public T[] values; 

        public Vector3(T a, T b)
        {
            A = a;
            B = b;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Vector3<int>> vecList = new List<Vector3<int>>();

            vecList.Add(new Vector3<int>)(1, 2, 3);
            vecList.Add(new Vector3<int> (4, 5, 6));

            foreach (var vecLis in vecList)
            {
                Console.WriteLine($"X: {vecLis.A}, Y: {vecLis.B}");
            }
            Console.ReadLine();
        }
        
    }
}