using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
class Program
{
    static void Main(string[] args)
    {
        Person yan = new Person("Yan", 18);
        Person pasha = new Person("Pasha", 19);
        Person anton = new Person("Anton", 18);
        Person[] people = new Person[] { yan, pasha, anton };
        Console.WriteLine($"{yan.name} - {yan.age}");
        BinaryFormatter Binformatter = new BinaryFormatter();
        SoapFormatter SoapFormatter = new SoapFormatter();
        JsonSerializer jsonSerializer = new JsonSerializer();
        XmlSerializer XmlSerializer = new XmlSerializer(typeof(Person));
        XmlSerializer XmlSerializer1 = new XmlSerializer(typeof(Person[]));
        using (FileStream fs = new FileStream("BinSer.dat", FileMode.Create))
        {
            Binformatter.Serialize(fs, yan);
            Console.WriteLine("Бинарная сериализация");
        }
        using (FileStream fs = new FileStream("BinSer.dat", FileMode.Open))
        {
            Person yan1 = (Person)Binformatter.Deserialize(fs);
            Console.WriteLine($"{yan1.name} - {yan1.age}");
            Console.WriteLine("Бинарная десериализация");
        }
        using (FileStream fs = new FileStream("SoapSer.soap", FileMode.Create))
        {
            SoapFormatter.Serialize(fs, yan);
            Console.WriteLine("Соап сериализация");
        }
        using (FileStream fs = new FileStream("SoapSer.soap", FileMode.Open))
        {
            Person yan1 = (Person)SoapFormatter.Deserialize(fs);
        }
        jsonSerializer.Serialize(TextWriter.Null, yan);
        Console.WriteLine("JSON сериализация");
        using (FileStream fs = new FileStream("XmlSer.xml", FileMode.Create))
        {
            XmlSerializer.Serialize(fs, yan);
            Console.WriteLine("XML сериализация");
        }
        using (FileStream fs = new FileStream("XmlSer.xml", FileMode.Open))
        {
            Person yan1 = (Person)XmlSerializer.Deserialize(fs);
            Console.WriteLine("XML десериализация");
        }
        using (FileStream fs = new FileStream("BinSerArr.dat", FileMode.Create))
        {
            Binformatter.Serialize(fs, people);
            Console.WriteLine("Массив Сериализзован");
        }
        using (FileStream fs = new FileStream("BinSerArr.dat", FileMode.Open))
        {
            Person[] newpeople = (Person[])Binformatter.Deserialize(fs);
            Console.WriteLine("Массив Десериализзован");
        }
        using (FileStream fs = new FileStream("XmlSerArr.xml", FileMode.Create))
        {
            XmlSerializer1.Serialize(fs, people);
            Console.WriteLine("XML сериализация");
        }
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("XmlSerArr.xml");
        XmlElement xRoot = xDoc.DocumentElement;
        XmlNodeList childnodes = xRoot.SelectNodes("//Person/name");
        foreach (XmlNode n in childnodes)
            Console.WriteLine(n.InnerText);
        childnodes = xRoot.SelectNodes("//Person/age");
        foreach (XmlNode n in childnodes)
            Console.WriteLine(n.InnerText);
        XDocument xDocument = new XDocument();
        XElement Person1 = new XElement("Person");
        XElement name1 = new XElement("name", "Vasya");
        XElement age1 = new XElement("age", "21");
        Person1.Add(name1);
        Person1.Add(age1);
        XElement Person2 = new XElement("Person");
        XElement name2 = new XElement("name", "Kolya");
        XElement age2 = new XElement("age", "22");
        Person2.Add(name2);
        Person2.Add(age2);
        XElement People = new XElement("People");
        People.Add(Person1);
        People.Add(Person2);
        xDocument.Add(People);
        xDocument.Save("People.xml");

    }
        
}

[Serializable]
public class Person
{
    public string name { get; set; }
    public int age { get; set; }
    public Person(string _name, int _age)
    {
        name = _name;
        age = _age;
    }
    public Person()
    { }
}