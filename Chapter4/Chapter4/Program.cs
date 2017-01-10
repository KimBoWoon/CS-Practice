using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    // 함수 포인터랑 비슷한 의미
    // 함수를 등록하고 등록된 순서에 따라 실행된다
    delegate int Practice(int x);
    // 여러개의 함수가 들어갈 수 있으며 등록된 함수 순서대로 실행된다
    delegate void mutipleDelegate();
    // 제네릭 함수도 등록 가능
    public delegate T Transformer<T>(T arg);
    // 이벤트 대리자 정의
    public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

    class Program
    {
        // 기본 값도 null이 될 수 있다
        int? q = null;
        // 동적 바인딩 런타임에 변수의 타입을 정한다
        // var과는 다르다
        // var은 컴파일러가 dynamic는 런타임에 결정됨
        dynamic a = 3;

        static void Main(string[] args)
        {
            Practice p = Square;
            int result = p(3);
            Console.WriteLine(result);

            mutipleDelegate md = func1;
            md += func2;

            md();

            int[] values = { 1, 2, 3 };
            Util.Transform(values, Square);
            foreach (int i in values)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Stock1 s = new Stock1("string");
            s.Price = 3;
            Console.WriteLine(s.Price);

            Stock2 stock = new Stock2("THPW");
            stock.Price = 27.10M;
            // PriceChanged 이벤트에 등록
            stock.PriceChanged += stock_PriceChanged;
            stock.Price = 31.59M;

            // C#에서 포인터 연산을 할 때 unsafe키워드를 사용
            // C#은 C++처럼 포인터 연산을 지원
            // fixed를 사용하면 참조된 메모리 주소를 기억할 수 있다
            // 하지만 메모리 효율성이 나빠질 수 있으므로 잠깐만 사용해야한다
            unsafe
            {
                int x = 3;
                int* ptr = &x;
                Console.WriteLine(*ptr);
            }

            // stackalloc를 사용하면 힙이 아닌 스택에 배열처럼 메모리를 할당
            unsafe
            {
                int* arr = stackalloc int[10];
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }

        static int Square(int x) => x * x;

        static void func1() => Console.WriteLine("func1");

        static void func2() => Console.WriteLine("func2");

        static void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
            {
                Console.WriteLine("Alert, 10% stock price increase!");
            }
        }
    }

    public class Util
    {
        public static void Transform<T> (T[] values, Transformer<T> t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        }
    }

    // 특정코드가 폐기 예정이라고 알려준다
    // 사용하면 경고를 나타냄
    // Attribute는 생략 가능
    [ObsoleteAttribute]
    public class Stock1
    {
        string symbol;
        decimal price;

        public Stock1(string symbol)
        {
            this.symbol = symbol;
        }

        public event PriceChangedHandler PriceChanged;

        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value)
                {
                    return;
                }
                decimal oldPrice = price;
                price = value;
                if (PriceChanged != null)
                {
                    PriceChanged(oldPrice, price);
                }
            }
        }
    }

    public class Stock2
    {
        string symbol;
        decimal price;

        public Stock2(string symbol)
        {
            this.symbol = symbol;
        }

        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value)
                {
                    return;
                }
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
                // OnPriceChanged(EventArgs.Empty);
            }
        }
    }

    public class PriceChangedEventArgs : System.EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }
}
