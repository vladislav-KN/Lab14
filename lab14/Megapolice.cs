using System;

 
public class Megapolice : City
{
    internal int countOfAglommeration;

    public override string ToString()
    {
        return $"Мегаполис {nameOfCity} с площадью {squearOfCity}км^2 содержит {countOfPeople} людей а также {countOfAglommeration}";
    }
    public new Place BasePlace
    {
        get
        {
            return new Place(latitude, longitude, nameOfContinetn);//возвращает объект базового класса
        }

    }
    public new Area BaseArea
    {
        get
        {
            return new Area(BasePlace, nameOfArea,  countOfCity, squearOfArea);//возвращает объект базового класса
        }

    }
    public City BaseCity
    {
        get
        {
            return new City(BaseArea, nameOfCity, countOfPeople, squearOfCity);//возвращает объект базового класса
        }

    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        Megapolice p = (Megapolice)obj;
        return (latitude == p.Latitude) && (longitude == p.Longitude);
    }

    public Megapolice(City city, int count)
    {
        latitude = city.latitude;
        longitude = city.longitude;
        nameOfArea = city.nameOfArea;
        countOfCity = city.countOfCity;
        nameOfContinetn = city.nameOfContinetn;
        squearOfArea = city.squearOfArea;
        countOfPeople = city.countOfPeople;
        nameOfCity = city.nameOfCity;
        squearOfCity = city.squearOfCity;
        countOfAglommeration = count;
        placeSaver = (Place)city.placeSaver.Clone();
    }
    public Megapolice(City city, Random rnd)
    {
 
        placeSaver = (Place)city.placeSaver.Clone();
        latitude = city.latitude;
        longitude = city.longitude;
        nameOfArea = city.nameOfArea;
        countOfCity = city.countOfCity;
        nameOfContinetn = city.nameOfContinetn;
        squearOfArea = city.squearOfArea;
        countOfPeople = city.countOfPeople;
        nameOfCity = city.nameOfCity;
        squearOfCity = city.squearOfCity;
        countOfAglommeration = rnd.Next(1, 20);

    }
    public Megapolice()
    {
        City city = new City();
        placeSaver = new Place();
        latitude = default;
        longitude = default;
        nameOfArea = default;
        countOfCity = default;
        squearOfArea = default;
        countOfPeople = default;
        nameOfCity = default;
        squearOfCity = default;
        countOfAglommeration = default;
    }
    public override int GetHashCode()
    {
        return Tuple.Create(countOfAglommeration, nameOfCity).GetHashCode();
    }
    public int CountOfAglommeration
    {
        get { return countOfAglommeration; }
        set { countOfAglommeration = value; }
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
    public new Megapolice ShallowCopy() //поверхностное копирование
    {
        return (Megapolice)this.MemberwiseClone();
    }
    public override object Clone()
    {
        Place clone = new Place(this.Latitude, this.Longitude,this.nameOfContinetn);
        Area clone1 = new Area(clone, this.NameOfArea , this.CountOfCity, this.SquearOfArea);
        City clone2 = new City(clone1, this.NameOfCity, this.CountOfPeople, this.SquearOfCity);
        return new Megapolice(clone2, this.CountOfAglommeration);
    }
}


