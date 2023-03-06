using System;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {

        var User = FillInfo();
        Print(User);
        

    }

    static (string Name, string LastName, int Age, int HowPets, string[] Pets, int NumFavColors, string[] FavoriteColors) FillInfo()
    {
        (string Name, string LastName, int Age, int HowPets,string[] Pets, int NumFavColors, string[] FavoriteColors) User;

        Console.Write("Введите имя: ");
        User.Name = Console.ReadLine();

        Console.Write("Введите фамилию: ");
        User.LastName = Console.ReadLine();

        string age;
        int dage;
        do
        {
            Console.Write("Введите возраст цифрами: ");
            age = Console.ReadLine();
        } while (CheckNum(age, out dage));

        User.Age = dage;

        string HPets;
        int HowPets;
        do
        {
            Console.Write("Введите количество питомцев: ");
            HPets = Console.ReadLine();
        } while (CheckNum(HPets, out HowPets));

        User.HowPets = HowPets;
        User.Pets = CreateArrayPets(HowPets);


        string NFColors;
        int NumFavColors;
        do
        {
            Console.Write("Введите количество любимых цветов: ");
            NFColors = Console.ReadLine();
        } while (CheckNum(NFColors, out NumFavColors));
        User.NumFavColors= NumFavColors;
        User.FavoriteColors = FillFavoriteColors(NumFavColors);

        return User;
        
    }

    static string[] CreateArrayPets(int num)
    {
        var result = new string[num];

        for (int i = 0; i < num; i++)
        {
            Console.Write("Введите кличку {0} питомца: ", i + 1);
            result[i] = Console.ReadLine();
        }
        return result;
    }
    static bool CheckNum(string number, out int cornnumber)
    {
        if (int.TryParse(number, out int intnum))
        {
            if (intnum > 0)
            {
                cornnumber = intnum;
                return false;
            }
        }
        {
            cornnumber = 0;
            return true;
        }
    }
    
    static string[] FillFavoriteColors(int num)
    {
        var result = new string[num];   
        for (int i = 0; i < num; i++)
        {
            Console.Write("Введите {0} любимый цвет: ", i + 1);
            result[i] = Console.ReadLine();
        }
        return result;
    }

    static void ShowArray(string[] array, int num)
    {
        
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    static void Print((string Name, string LastName, int Age, int HowPets, string[] Pets, int NumFavColors, string[] FavoriteColors) User)
    {
        Console.WriteLine("Имя: {0}", User.Name);
        Console.WriteLine("Фамилия: {0}", User.LastName);
        Console.WriteLine("Возраст: {0}", User.Age);
        Console.WriteLine("Клички питомцев: ");
        ShowArray(User.Pets, User.HowPets);
        Console.WriteLine("Любимые цвета: ");
        ShowArray(User.FavoriteColors,User.NumFavColors);
        
        
    }
        

}
