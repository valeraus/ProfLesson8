using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AddTask
{
    /*
     Створіть користувацький тип (наприклад, клас) і виконайте серіалізацію об’єкта цього типу,
    враховуючи той факт, що стан об’єкту необхідно передати по мережі.
     */
    [Serializable]
    class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }

        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }
    }

    class Program
    {
        static void Main()
        {
            Car auto = new Car("Mercedes", 250);

            FileStream stream = File.Create("CarData.data");

            BinaryFormatter formatter = new BinaryFormatter();

            // Cериализация.
            formatter.Serialize(stream, auto);
            stream.Close();
        }
    }
}
