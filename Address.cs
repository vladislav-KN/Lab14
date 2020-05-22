using System;

public class Address : Megapolice
{
    string streatName;
    int numberOfStreat;

    public new Place BasePlace
    {
        get
        {
            return new Place(latitude, longitude);//возвращает объект базового класса
        }

    }
    public new Area BaseArea
    {
        get
        {
            return new Area(BasePlace, nameOfArea, nameOfContinetn, countOfCity, squearOfArea);//возвращает объект базового класса
        }

    }
    public new City BaseCity
    {
        get
        {
            return new City(BaseArea, nameOfCity, countOfPeople, squearOfCity);//возвращает объект базового класса
        }

    }
    public Megapolice BaseMegapolice
    {
        get
        {
            return new Megapolice(BaseCity, countOfAglommeration);//возвращает объект базового класса
        }

    }

    public Address(Megapolice megapolice, string name, int num)
    {
        latitude = megapolice.Latitude;
        longitude = megapolice.Longitude;
        nameOfContinetn = megapolice.NameOfContinetn;
        nameOfArea = megapolice.NameOfArea;
        countOfCity = megapolice.CountOfCity;
        squearOfArea = megapolice.SquearOfArea;
        countOfPeople = megapolice.CountOfPeople;
        nameOfCity = megapolice.NameOfCity;
        squearOfCity = megapolice.SquearOfCity;
        countOfAglommeration = megapolice.CountOfAglommeration;
        placeSaver = (Place)megapolice.placeSaver.Clone();
        streatName = name;
        numberOfStreat = num;
    }
    public Address(City city, string name, int num)
    {
        placeSaver = (Place)city.placeSaver.Clone();
        latitude = city.Latitude;
        nameOfContinetn = city.NameOfContinetn;
        longitude = city.Longitude;
        nameOfArea = city.NameOfArea;
        countOfCity = city.CountOfCity;
        squearOfArea = city.SquearOfArea;
        countOfPeople = city.CountOfPeople;
        nameOfCity = city.NameOfCity;
        squearOfCity = city.SquearOfCity;
        countOfAglommeration = -1;
        streatName = name;
        numberOfStreat = num;
    }
    public Address(Random rnd)
    {

        City city = new City(rnd);
        placeSaver = (Place)city.placeSaver.Clone();
        latitude = placeSaver.Latitude;
        longitude = placeSaver.Longitude;
        nameOfArea = city.NameOfArea;
        countOfCity = city.CountOfCity;
        squearOfArea = city.SquearOfArea;
        countOfPeople = city.CountOfPeople;
        nameOfCity = city.NameOfCity;
        squearOfCity = city.SquearOfCity;
        countOfAglommeration = -1;
        streatName = RandomWord();
        numberOfStreat = rnd.Next(1, 500);
    }
    public Address()
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
        streatName = default;
        numberOfStreat = default;
    }

    public string StreatName
    {
        get { return streatName; }
        set { streatName = value; }
    }
    public override string ToString()
    {
        return $"ул. {streatName} д. {numberOfStreat}";
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        Address p = (Address)obj;
        return (latitude == p.Latitude) && (longitude == p.Longitude);
    }
    public override int GetHashCode()
    {
        return Tuple.Create(streatName, numberOfStreat).GetHashCode();
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
    public new Address ShallowCopy() //поверхностное копирование
    {
        return (Address)this.MemberwiseClone();
    }
    public override object Clone()
    {
        Place clone = new Place(this.Latitude, this.Longitude);
        Area clone1 = new Area(clone, this.NameOfArea, this.NameOfContinetn, this.CountOfCity, this.SquearOfArea);
        City clone2 = new City(clone1, this.NameOfCity, this.CountOfPeople, this.SquearOfCity);
        Megapolice clone3 = new Megapolice(clone2, this.CountOfAglommeration);
        return new Address(clone3, this.streatName, this.numberOfStreat);
    }
}
