using System;

public class Place : ICloneable, IComparable, IComparable<Place>, IComparer<Place>
{
    internal float latitude,
          longitude;
    public override string ToString()
    {
        string ret = "Координаты: ";
        if (latitude > 0)
        {
            ret += "+" + latitude + "°ш, ";
        }
        else
        {
            ret += latitude + "°ш, ";
        }
        if (latitude > 0)
        {
            ret += "+" + longitude + "°д";
        }
        else
        {
            ret += longitude + "°д";
        }
        return ret;

    }
    public float Latitude
    {
        get { return latitude; }
        set
        {
            if (value >= -90 && value <= 90)
                latitude = value;
            else
                Console.WriteLine("Широта может быть больше -180 и меньше 180");
        }
    }
    public float Longitude
    {
        get { return longitude; }
        set
        {
            if (value >= -180 && value <= 180)
                longitude = value;
            else
                Console.WriteLine("Долгота может быть больше -180 и меньше 180");
        }
    }
    public Place(float la, float lo)
    {

        latitude = la;
        longitude = lo;

    }
    public Place(Random rnd)
    {
        latitude = rnd.Next(-90, 91);
        longitude = rnd.Next(-180, 181);
    }
    public Place()
    {
        latitude = default;
        longitude = default;
    }
    virtual public int CompareTo(object ex)
    {
        Place pl1 = (Place)this;
        Place pl2 = (Place)ex;
        if (pl1.Latitude > pl2.Latitude)
        {
            if (pl1.Longitude > pl2.Longitude)
                return 1;
            else if (pl1.Longitude == pl2.Longitude)
                return 1;
            else
                return -1;
        }
        else if (pl1.Latitude == pl2.Latitude)
        {
            if (pl1.Longitude > pl2.Longitude)
                return 1;
            else if (pl1.Longitude == pl2.Longitude)
                return 0;
            else
                return -1;
        }
        else
        {
            if (pl1.Longitude < pl2.Longitude)
                return -1;
            else if (pl1.Longitude == pl2.Longitude)
                return -1;
            else
                return 1;
        }
    }
    public Place ShallowCopy() //поверхностное копирование
    {
        return (Place)this.MemberwiseClone();
    }
    virtual public object Clone()
    {
        return new Place(this.Latitude, this.Longitude);
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        Place p = (Place)obj;
        return (latitude == p.Latitude) && (longitude == p.Longitude);
    }
    public static string RandomWord()
    {

        // Создаем массив букв, которые мы будем использовать.
        char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        char[] letters1 = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        // Создаем генератор случайных чисел.
        Random rand = new Random();
        int num_letters = rand.Next(0, 15);
        // Делаем слова.
        string word = "" + letters[rand.Next(0, letters.Length - 1)];
        for (int j = 1; j <= num_letters; j++)
        {
            // Выбор случайного числа от 0 до 25
            // для выбора буквы из массива букв.
            int letter_num = rand.Next(0, letters.Length - 1);

            // Добавить письмо.
            word += letters[letter_num];
        }
        return word;
    }
    public int CompareTo([AllowNull] Place other)
    {
        if (other == null)
            return 1;

        else
            return this.CompareTo(other);
    }
    public override int GetHashCode()
    {
        return Tuple.Create(latitude, longitude).GetHashCode();
    }
    public int Compare([AllowNull] Place x, [AllowNull] Place y)
    {
        if (y == null)
            return 1;
        else if (x == null)
            return -1;

        return x.CompareTo(y);
    }


}
