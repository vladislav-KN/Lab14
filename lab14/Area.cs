using System;

public class Area : Place
{
    public Place placeSaver;
    internal string nameOfArea;
    internal int countOfCity;
    internal float squearOfArea;
   
    

    public Place BasePlace
    {
        get
        {
            return new Place(latitude, longitude,nameOfContinetn);//возвращает объект базового класса
        }

    }
    public string NameOfArea
    {
        get { return nameOfArea; }
        set { nameOfArea = value; }
    }
    
    public int CountOfCity
    {
        get { return countOfCity; }
        set { countOfCity = value; }
    }
    public float SquearOfArea
    {
        get { return squearOfArea; }
        set
        {
            if (value > 0)
                squearOfArea = value;
            else
                Console.WriteLine("Невозможно присвоить отрицательную площадь");
        }
    }

    public Area(Place pl, string nameInCountry , int co, float sq)
    {
        nameOfArea = nameInCountry;
        nameOfContinetn = pl.nameOfContinetn;
        latitude = pl.latitude;
        longitude = pl.longitude;
        countOfCity = co;
        squearOfArea = sq;
        placeSaver = (Place)pl.Clone();
    }
    public Area(Place pl, Random rnd)
    {

        nameOfArea = RandomWord();
        countOfCity = rnd.Next(1, 100);
        placeSaver = (Place)pl.Clone();
        nameOfContinetn = pl.nameOfContinetn;
        latitude = pl.latitude;
        longitude = pl.longitude;
        squearOfArea = rnd.Next(100, 1000000) + ((float)rnd.Next(0, 100)) / 100;

        

    }
    public Area()
    {
        nameOfArea = default;
        countOfCity = default;
        placeSaver = new Place();
        latitude = default;
        longitude = default;
        squearOfArea = default;
        nameOfContinetn = default;
    }
    public override int GetHashCode()
    {
        return Tuple.Create(nameOfArea, countOfCity, squearOfArea, nameOfContinetn).GetHashCode();
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
    public new Area ShallowCopy() //поверхностное копирование
    {
        return (Area)this.MemberwiseClone();
    }
    public override object Clone()
    {
        Place clone = new Place(this.Latitude, this.Longitude, this.NameOfContinetn);
        return new Area(clone, this.NameOfArea,  this.CountOfCity, this.SquearOfArea);
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        Area p = (Area)obj;
        return (latitude == p.Latitude) && (longitude == p.Longitude);
    }
    public override string ToString()
    {
        return $"Область:{nameOfArea} с площадью {squearOfArea}км^2 содержит {countOfCity}";
    }
}
