using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace HW_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Daniil", "Soboliev", 18);

            Console.WriteLine("Запуск!");
            KeyListener keyListener = new KeyListener();

            keyListener.MovePress += p.Move;
            keyListener.SpacebarPress += p.Jump;
            keyListener.EnterPress += p.Select;

            keyListener.Listen();
        }
    }
}
