using System;

public class City : Area
{

    internal string nameOfCity;
    internal int countOfPeople;
    internal float squearOfCity;

    public new Place BasePlace
    {
        get
        {
            return new Place(latitude, longitude);//возвращает объект базового класса
        }

    }
    public Area BaseArea
    {
        get
        {
            return new Area(BasePlace, nameOfArea, nameOfContinetn, countOfCity, squearOfArea);//возвращает объект базового класса
        }

    }
    public float SquearOfCity
    {
        get
        {
            return squearOfCity;
        }
        set
        {

            if (value > 0)
                squearOfCity = value;
            else
                Console.WriteLine("Невозможно присвоить отрицательную площадь");
        }
    }
    public string NameOfCity
    {
        get { return nameOfCity; }
        set { nameOfCity = value; }
    }
    public int CountOfPeople
    {
        get { return countOfPeople; }
        set { countOfPeople = value; }
    }

    public City(Area ar, string name, int count, float squear)
    {
        latitude = ar.Latitude;
        longitude = ar.Longitude;
        nameOfArea = ar.NameOfArea;
        nameOfContinetn = ar.NameOfContinetn;
        countOfCity = ar.CountOfCity;
        squearOfArea = ar.SquearOfArea;
        nameOfCity = name;
        countOfPeople = count;
        squearOfCity = squear;
        placeSaver = (Place)ar.placeSaver.Clone();
    }
    public City(Random rnd)
    {
        Area ar = new Area(rnd);
        placeSaver = (Place)ar.placeSaver.Clone();
        latitude = placeSaver.Latitude;
        longitude = placeSaver.Longitude;
        nameOfArea = ar.NameOfArea;
        countOfCity = ar.CountOfCity;
        squearOfArea = ar.SquearOfArea;
        nameOfCity = RandomWord();
        countOfPeople = rnd.Next(0, 99999999);
        squearOfCity = rnd.Next(1, 1000) + ((float)rnd.Next(0, 100)) / 100;
    }
    public City()
    {
        Area ar = new Area();
        placeSaver = new Place();
        latitude = default;
        longitude = default;
        nameOfArea = default;
        countOfCity = default;
        squearOfArea = default;
        nameOfCity = default;
        countOfPeople = default;
        squearOfCity = default;
    }
    public override int GetHashCode()
    {
        return Tuple.Create(countOfPeople, squearOfCity, nameOfCity).GetHashCode();
    }
    public override string ToString()
    {
        return $"Город {nameOfCity} с площадью {squearOfCity}км^2 содержит {countOfPeople} людей";
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        City p = (City)obj;
        return (latitude == p.Latitude) && (longitude == p.Longitude);
    }
    public override int CompareTo(object ex)
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
    public new City ShallowCopy() //поверхностное копирование
    {
        return (City)this.MemberwiseClone();
    }
    public override object Clone()
    {
        Place clone = new Place(this.Latitude, this.Longitude);
        Area clone1 = new Area(clone, this.NameOfArea, this.NameOfContinetn, this.CountOfCity, this.SquearOfArea);
        return new City(clone1, this.NameOfCity, this.CountOfPeople, this.SquearOfCity);
    }

}
