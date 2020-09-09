/*Написать класс Money, предназначенный для хранения денежной суммы(в гривнах и копейках). Для класса
реализовать перегрузку операторов + (сложение денежных сумм), – (вычитание сумм), / (деление суммы на целое
число), * (умножение суммы на целое число), ++ (сумма увеличивается на 1 копейку), -- (сумма уменьшается на 1 копейку), <, >, ==, !=.
Класс не может содержать отрицательную сумму.
В случае если при исполнении какой-либо операции получается отрицательная сумма денег, то класс генерирует
исключительную ситуацию «Банкрот».
Программа должна с помощью меню продемонстрировать все возможности класса Money. Обработка исключительных ситуаций производится в программе.*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Home_Task_07
{
    public class MyExaption : Exception
    {
        public DateTime TimeExaption { get; private set; }
        public MyExaption() : base("Банкрот!")
        {
            TimeExaption = DateTime.Now;
        }

    }
    class Money
    {
        public int grn { get; set; }
        public int cop { get; set; }
        public Money()  {    }
        public Money (int grn, int cop)
        {
            if (cop > 99)
            {
                grn += cop/100;
                cop = cop % 100;
            }
            this.grn = grn;
            this.cop = cop;
        }
        public int getGrn (int grn)
        {
            return this.grn = grn;
        }
        public int getCop (int cop)
        {
            return this.cop = cop;
        }
        public void setGrn()
        {
            Write("Введите гривны: ");
            int grn = Convert.ToInt32(ReadLine());
            getGrn(grn);
            Write("\nВведите копейки: ");
            int cop = Convert.ToInt32(ReadLine());
            getCop(cop);
        }
        public void Show()
        {
            WriteLine($"{grn} грн {cop} коп");
        }
        public static Money operator +(Money obj1, Money obj2)
        {
            return new Money { grn = (obj1.grn * 100 + obj1.cop + obj2.grn * 100 + obj2.cop) / 100, cop = (obj1.grn * 100 + obj1.cop + obj2.grn * 100 + obj2.cop) % 100 };
        }
        public static Money operator -(Money obj1, Money obj2)
        {
            return new Money { grn = (obj1.grn*100 + obj1.cop - obj2.grn*100 - obj2.cop)/100, cop = (obj1.grn * 100 + obj1.cop - obj2.grn * 100 - obj2.cop) % 100 };
        }
        public static Money operator *(Money obj1, int volume)
        {
            return new Money { grn = volume * (obj1.grn * 100 + obj1.cop) / 100, cop = volume * (obj1.grn * 100 + obj1.cop) % 100 };
        }
        public static Money operator /(Money obj1, int volume)
        {
            return new Money { grn = (obj1.grn * 100 + obj1.cop) / volume / 100, cop = (obj1.grn * 100 + obj1.cop) / volume % 100 };
        }
        public static Money operator ++(Money obj1)
        {
            return new Money { grn = (1 + obj1.grn * 100 + obj1.cop) / 100, cop = (1 + obj1.grn * 100 + obj1.cop) % 100 };
        }
        public static Money operator --(Money obj1)
        {
            return new Money { grn = ((obj1.grn * 100 + obj1.cop) - 1) / 100, cop = ((obj1.grn * 100 + obj1.cop) - 1) % 100 };
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Money obj1, Money obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Money obj1, Money obj2)
        {
            return !(obj1 == obj2);
        }
        public static bool operator >(Money obj1, Money obj2)
        {
            if (obj1.grn * 100 + obj1.cop > obj1.grn * 100 + obj2.cop)
                return true;
            else
                return false;
        }
        public static bool operator <(Money obj1, Money obj2)
        {
            if (obj1.grn * 100 + obj1.cop < obj1.grn * 100 + obj2.cop)
                return true;
            else
                return false;
        }
        public static bool operator <(Money obj1, int volume)
        {
            if (obj1.grn < volume || obj1.cop < volume)
                return true;
            else
                return false;
        }
        public static bool operator >(Money obj1, int volume)
        {
            if ((obj1.grn * 100 + obj1.cop) > volume)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return $"{grn} грн {cop} коп";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ForegroundColor = ConsoleColor.Green;
                Money obj = new Money();
                Money obj1 = new Money();
                Money obj2 = new Money();
                WriteLine("Давайте создадим первый объект.");
                obj1.setGrn();
                obj1.Show();
                WriteLine("Давайте создадим второй объект.");
                obj2.setGrn();
                obj2.Show();
                WriteLine(@"Вы можете производить такие операции как: 
                                 + (сложение денежных сумм), 
                                 – (вычитание сумм), 
                                 / (деление суммы на целое число), 
                                 *(умножение суммы на целое число), 
                                 ++(сумма увеличивается на 1 копейку), 
                                 --(сумма уменьшается на 1 копейку), 
                                 а так же: <, >, ==, != ");
                WriteLine("Выбирите первый объект (нажав 1 или 2) и операцию (нажав соответсвующий символ)");
                int _object;
                do
                {
                    _object = Convert.ToInt32(ReadLine());
                }
                while (_object != 1 || _object != 2);
                string operation;
                do
                {
                    operation = ReadLine();
                }
                while (operation != "+" || operation != "-");
                switch (_object)
                {
                    case 1:
                        switch (operation)
                        {
                            case "+":
                                obj = obj1 + obj2;
                                Write("obj1 + obj2: "); obj.Show();
                                break;
                            case "-":
                                break;
                        }
                        break;
                    case 2:
                        break;
                }
                //    Money obj1 = new Money(10, 50);
                //    Write("obj1 = "); obj1.Show();
                //    Money obj2 = new Money(10, 1411875);
                //    Write("obj2 = "); obj2.Show();
                //    Money obj3 = new Money();
                //    obj3 = obj1 + obj2;
                //    Write("obj1 + obj2: "); obj3.Show();
                //    obj3 = obj2 - obj1;
                //    Write("obj2 - obj1: "); obj3.Show();
                //    obj3 = obj1 * 3;
                //    Write("obj1 * 3: "); obj3.Show();
                //    obj3 = obj2 / 125;
                //    WriteLine($"obj2 / 125: {obj3}");
                //    ++obj1;
                //    WriteLine($"++obj1: {obj1}");
                //    --obj1;
                //    --obj1;
                //    WriteLine($"--obj1: {obj1}");
                //    WriteLine($"obj1 == obj2: {obj1 == obj2}");
                //    WriteLine($"obj1 != obj2: {obj1 != obj2}");
                //    WriteLine($"obj1 > obj2: {obj1 > obj2}");
                //    WriteLine($"obj1 < obj2: {obj1 < obj2}");
                //    obj3 = obj1 - obj2;
                //    if (obj3 < 0)
                //    {
                //        throw new MyExaption();
                //    }
                //    Write("obj1 - obj2: "); obj3.Show();
            }
                catch (MyExaption my)
            {
                WriteLine(my.Message);
                WriteLine(my.TimeExaption);
            }
            ReadKey();
        }
    }
}
