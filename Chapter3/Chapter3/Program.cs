using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class A
    {
        protected int a = 1;

        public A()
        {
            Console.WriteLine("A Class");
        }

        // 함수를 가상화 하고 자식에서 구현한다
        public virtual void func()
        {
            Console.WriteLine("a Function");
        }

        public virtual void func2()
        {
            Console.WriteLine("virtual func2 Function");
        }
    }

    class B : A
    {
        int b = 2;

        public B()
        {
            Console.WriteLine(base.a);
            Console.WriteLine("B Class");
        }

        // 가상화된 함수를 구현
        public override void func()
        {
            base.func();
            Console.WriteLine("Override func Function");
        }

        // abstract나 vitual은 sealed라는 키워드를 사용해서 봉인할 수 있다
        // 다음 자식이 오버라이드할 수 없음
        public override sealed void func2()
        {
            Console.WriteLine("virtual sealed func2 Function");
        }
    }

    class C : B
    {
        int c = 3;
        
        public C()
        {
            Console.WriteLine(base.b);
            Console.WriteLine("C Class");
        }

        // 에러 발생
        public override void func2()
        {
            Console.WriteLine("sealed func2 Function");
        }
    }

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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Practice p = new Practice();

            p.CurrentPrice = 1;
            Console.WriteLine(p.CurrentPrice);

            A a = new A();
            B b = new B();
        }
    }
}
