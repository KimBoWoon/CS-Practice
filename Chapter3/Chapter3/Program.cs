using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class Practice
    {
        // 필드 부분
        string name;
        int age;
        // 읽기 전용 쓰기 안 됨
        readonly int read;
        // 속성(Property)
        decimal currentPrice;
        public decimal CurrentPrice
        {
            get { return currentPrice; }
            set { currentPrice = value; }
        }

        // 람다식
        int func(int x) => x * 2;
        // 속성(Property)도 람다식으로 만들 수 있다
        decimal a, b;
        public decimal Worth => a * b;

        // is는 java의 instanceof랑 같다
        // abstract나 vitual은 sealed라는 키워드를 사용해서 봉인할 수 있다
        // base를 사용해 상위 클래스의 멤버를 사용할 수 있다
    }
    class Program
    {
        static void Main(string[] args)
        {
            Practice p = new Practice();

            p.CurrentPrice = 1;
            Console.WriteLine(p.CurrentPrice);
        }
    }
}
