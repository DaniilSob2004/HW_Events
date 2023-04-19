using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_Events
{
    public enum Direction { Up, Down, Left, Right };

    public class MyEventArgs : EventArgs
    {
        private Direction? direction;

        public MyEventArgs() => direction = null;
        public MyEventArgs(Direction direction) => this.direction = direction;

        public Direction? Direction => direction;
    }

    public class KeyListener
    {
        // кнопки на которые реагирует данный класс
        private enum KeyType { UpArrow, DownArrow, LeftArrow, RightArrow, Spacebar, Enter };

        public delegate void MyDel(object sender, EventArgs e);

        public event MyDel MovePress;
        public event MyDel SpacebarPress;
        public event MyDel EnterPress;

        private ConsoleKeyInfo k;

        public void Listen()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    k = Console.ReadKey(true);

                    // есть ли название кнопки в перечислении KeyType
                    if (Enum.IsDefined(typeof(KeyType), k.Key.ToString()))
                    {
                        // если это Spacebar
                        if (k.Key.ToString() == KeyType.Spacebar.ToString())
                        {
                            if (SpacebarPress != null) SpacebarPress(this, new MyEventArgs());
                        }

                        // если это Enter
                        else if (k.Key.ToString() == KeyType.Enter.ToString())
                        {
                            if (EnterPress != null) EnterPress(this, new MyEventArgs());
                        }

                        // если это кнопки управления (вверх, вниз, вправо, влево)
                        else
                        {
                            // удаляем у название кнопки 'Arrow', например DownArrow -> Down
                            string move = k.Key.ToString().Replace("Arrow", "");

                            // находим значение в перечеслении Direction по названию 'move'
                            Direction direction = (Direction)Enum.Parse(typeof(Direction), move);

                            if (MovePress != null) MovePress(this, new MyEventArgs(direction));
                        }
                    }
                }
            }
        }
    }
}
