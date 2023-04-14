using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task3
{
    /*
     Створіть новий додаток, в котрому виконайте серіалізацію об’єкту з попереднього прикладу.
    Відобразіть стан об’єкту на екрані.
     */
    public class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }

        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        public Car()
        {

        }
    }

    public class CarXML
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Speed { get; set; }

        public CarXML(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        public CarXML()
        {

        }
    }

    class Program
    {
        static void Main()
        {


            XmlSerializer serializer = new XmlSerializer(typeof(Car));

            FileStream original = new FileStream("SerializationOriginal.xml", FileMode.Open, FileAccess.Read);

            Car auto = (Car)serializer.Deserialize(original);

            original.Close();

            Console.WriteLine(auto.Name + " " + auto.Speed);

            XmlSerializer serializerXML = new XmlSerializer(typeof(CarXML));

            FileStream streamXML = new FileStream("SerializationXML.xml", FileMode.Open, FileAccess.Read);

            CarXML autoXML = (CarXML)serializerXML.Deserialize(streamXML);

            streamXML.Close();

            Console.WriteLine(autoXML.Name + " " + autoXML.Speed);
        }
    }
}

