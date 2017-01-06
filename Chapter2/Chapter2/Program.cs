using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 예약된 키워드는 @를 사용하여 피할 수 있다
            int @if = 3;
            Console.WriteLine("@if = " + @if);
            // 변수가 오버플로가 됐는지 검사 할 수 있다
            // 컴파일 할 때 똑같은 옵션을 줄 수 있다
            // 하지만 unchecked를 설정하면 컴파일 타임에도 잡히지 않는다
            int a = checked(int.MaxValue - 1 + 1);
            int b = unchecked(int.MaxValue + 1);
            // 부동소수점은 특별한 값이 있다
            // NaN(not a number 수가 아님), 양수 무한대, 음수 무한대, 0.0
            // 0이 아닌 수를 0으로 나누면 무한대 값이 나온다
            Console.WriteLine("3.0 / 0.0 = " + 3.0 / 0.0);
            Console.WriteLine("-3.0 / 0.0 = " + -3.0 / 0.0);
            // 0을 0으로 나누거나 무한대에서 무한대를 뺀 결과는 NaN이다
            Console.WriteLine("0.0 / 0.0 = " + 0.0 / 0.0);
            Console.WriteLine("double.PositiveInfinity / double.PositiveInfinity = " + (double.PositiveInfinity - double.PositiveInfinity));
            // ==를 사용해 같은 값인지 판단 할 수 없다
            // double.isNaN or float.isNaN을 사용하여 비교해야 한다
            Console.WriteLine("0.0 == double.Nan = " + (0.0 == double.NaN));
            Console.WriteLine("double.IsNaN(0.0 / 0.0) = " + double.IsNaN(0.0 / 0.0));
            // @를 사용해 문자열에 특수문자를 수월하게 사용할 수 있다
            // "은 두번 써줘야함
            string s = @"\a\b\c\d\e";
            Console.WriteLine("@ 사용 = " + s);
            // $를 사용하여 문자열에 변수를 넣을 수 있다
            // 반드시 한 줄로 완성 시켜야 한다 하지만 @를 사용하면 여러줄로 만들 수 있다
            s = $"asdfaefa {a}";
            Console.WriteLine("$ 사용 = " + s);
            // [,] 를 사용해 2차원 배열을 쉽게 선언할 수 있다
            int[,] mat = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            foreach (int i in mat)
            {
                Console.WriteLine(i);
            }
            // C++ auto 느낌, var는 컴파일러가 할당된 값을 보고 알아서 타입을 정함
            // 대신 한번 정해진 타입은 바꿀 수 없음
            var x = 10;
            Console.WriteLine("var x = 10 " + x.GetType());
            // 변수를 참조를 넘기기 위해 ref를 사용한다
            feetToInch(ref a);
            // ref와 비슷한 역할을 하는 out도 있다
            // out는 전달받을 때는 지정되지 않아도 되지만 반환할 때는 반드시 지정되어 있어야 한다
            string c, d;
            feetToInch2(s, out c, out d);
            Console.WriteLine("c = " + c + " d = " + d);
            // params를 사용하면 전달 받을 때 배열로 받을 수 있다
            Console.WriteLine(sum(1, 2, 3, 4, 5));
            // ??를 사용하면 특정변수가 null일때 다른값을 할당할 수 있다
            string z = null;
            string w = z ?? "NULL";
            Console.WriteLine("w = " + w);
            // ?를 사용하면 null일 때 오류를 뿜어내지 않는다
            // null이면 오류를 내지 않고 null를 배정한다
            string v = null;
            string t = v?.ToString();
            Console.WriteLine("t = " + t);
            // 나머지는 다른 프로그래밍 언어와 같다
            // 특히 java와 제일 비슷함
        }

        static int feetToInch(ref int feet)
        {
            return feet * 12;
        }

        static void feetToInch2(string s, out string s1, out string s2)
        {
            s1 = s.Substring(0, 2);
            s2 = s.Substring(2, 3);
        }

        static int sum(params int[] n)
        {
            int s = 0;

            for (int i = 0; i < n.Length; i++)
            {
                s += n[i];
            }

            return s;
        }
    }
}
