using Newtonsoft.Json;
using System.Drawing;
using System.Xml.Serialization;

namespace Text_converter
{
    internal class Program
    {
        public string name;
        public int width;
        public int height;
        public static List<Shapes> shapes = new List<Shapes>();
        private static string jsonText;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла: ");
            Console.WriteLine("-----------------------");
            string path = Console.ReadLine();
            Console.Clear();
        }
        static void Model()
        {
            Shapes shapesOne = new Shapes()
            {
                name = "Прямоугольник",
                width = 25,
                height = 15,
            };
            shapes.Add(shapesOne);
            Shapes shapesTwo = new Shapes()
            {
                name = "Квадрат",
                width = 14,
                height = 14,
            };
            shapes.Add(shapesTwo);
            Shapes shapesTree = new Shapes()
            {
                name = "Квадрат",
                width = 17,
                height = 17,
            };
            shapes.Add(shapesTree);
            Console.WriteLine("Введите путь до файла, который хотите открыть(.txt/.json/.xml)\n" +
            "------------------------------------------------------------------");
            Console.SetCursorPosition(1, 2);
            string a = Console.ReadLine();
            string text = $"{shapesOne.name}\n{shapesOne.height}\n{shapesOne.width}\n" +
            $"{shapesTwo.name}\n{shapesTwo.height}\n{shapesTwo.width}\n" +
            $"{shapesTree.name}\n{shapesTree.height}\n{shapesTree.width}\n";
            if (a.Contains(".txt"))
            {
                string path = $"C:\\Users\\user\\Desktop\\Shapes.txt{a}";
                if (File.Exists(path))
                {
                    File.AppendAllText($"C:\\Users\\user\\Desktop\\Shapes.txt{a}", text);
                    Console.WriteLine(text);
                }
                else
                {
                    File.Create(path);
                }
                Console.Clear();
            }
            else if (a.Contains(".json"))
            {
                if (File.Exists(jsonText))
                {
                    string json = JsonConvert.SerializeObject(shapes);
                    File.WriteAllText($"C:\\Users\\user\\Desktop\\Shapes.json{a}", json);
                    List<Shapes> itog = JsonConvert.DeserializeObject<List<Shapes>>(text);
                    File.WriteAllText($"C:\\Users\\user\\Desktop\\Shapes.json{a}", text);
                    Console.WriteLine(itog);
                }
                else
                {
                    File.Create(jsonText);
                }
            }
            else if (a.Contains(".xml"))
            {
                string xmlText = $"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}";
                if (File.Exists(xmlText))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Shapes));
                    using (FileStream fs = new FileStream($"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}", FileMode.OpenOrCreate))
                    {
                        xml.Serialize(fs, shapesOne);
                        xml.Serialize(fs, shapesTwo);
                        xml.Serialize(fs, shapesTree);
                    }

                    Shapes shape;
                    XmlSerializer Dexml = new XmlSerializer(typeof(Shapes));
                    using (FileStream ds = new FileStream($"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}", FileMode.Open))
                    {
                        shape = (Shapes)Dexml.Deserialize(ds);
                    }
                    File.WriteAllText($"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}", text);
                    Console.WriteLine(text);
                }
                else
                {
                    File.Create(xmlText);
                }
            }


        }
   
    }

    class Shapes
    {
        internal string name;
        internal int width;
        internal int height;
    }
}