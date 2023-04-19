using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_Events
{
    public class MyEventArgs : EventArgs
    {
        private KeyType? keyType;

        public MyEventArgs() => keyType = null;
        public MyEventArgs(KeyType keyType) => this.keyType = keyType;

        public KeyType? KeyType => keyType;
    }


    // кнопки на которые реагирует класс KeyListener
    public enum KeyType { Up, Down, Left, Right, Spacebar, Enter };


    public class KeyListener
    {
        public delegate void KeyPressed(object sender, EventArgs e);

        public event KeyPressed MovePress;
        public event KeyPressed SpacebarPress;
        public event KeyPressed EnterPress;

        private ConsoleKeyInfo k;

        public void Listen()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    k = Console.ReadKey(true);

                    // есть ли название кнопки в перечислении KeyType
                    if (Enum.IsDefined(typeof(KeyType), k.Key.ToString().Replace("Arrow", "")))
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
                            KeyType keyType = (KeyType)Enum.Parse(typeof(KeyType), move);

                            if (MovePress != null) MovePress(this, new MyEventArgs(keyType));
                        }
                    }
                }
            }
        }
    }
}
