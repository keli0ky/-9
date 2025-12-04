using System;
using System.Collections.Generic;

public abstract class Vehicle
{
    protected string brand;
    protected string model;
    protected int year;

    public Vehicle(string brand, string model, int year)
    {
        this.brand = brand;
        this.model = model;
        this.year = year;
    }

    public string Brand
    {
        get { return brand; }
    }

    public string Model
    {
        get { return model; }
    }

    public int Year
    {
        get { return year; }
    }

    public abstract void StartEngine();

    public virtual string GetInfo()
    {
        return $"{brand} {model}, {year} год";
    }
}

public class Car : Vehicle
{
    private int numberOfDoors;

    public Car(string brand, string model, int year, int numberOfDoors)
        : base(brand, model, year)
    {
        this.numberOfDoors = numberOfDoors;
    }

    public int NumberOfDoors
    {
        get { return numberOfDoors; }
    }

    public override void StartEngine()
    {
        Console.WriteLine($"Автомобиль {brand} {model}: двигатель заведен");
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", {numberOfDoors} дверей";
    }
}

public class Motorcycle : Vehicle
{
    private bool hasSidecar;

    public Motorcycle(string brand, string model, int year, bool hasSidecar)
        : base(brand, model, year)
    {
        this.hasSidecar = hasSidecar;
    }

    public bool HasSidecar
    {
        get { return hasSidecar; }
    }

    public override void StartEngine()
    {
        Console.WriteLine($"Мотоцикл {brand} {model}: двигатель заведен");
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", коляска: {(hasSidecar ? "есть" : "нет")}";
    }
}

class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        Car car1 = new Car("Toyota", "Camry", 2022, 4);
        Car car2 = new Car("BMW", "X5", 2023, 5);
        Motorcycle moto1 = new Motorcycle("Harley-Davidson", "Sportster", 2021, false);
        Motorcycle moto2 = new Motorcycle("Ural", "Gear-Up", 2020, true);

        vehicles.Add(car1);
        vehicles.Add(car2);
        vehicles.Add(moto1);
        vehicles.Add(moto2);

        Console.WriteLine("Список транспортных средств:");
        

        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine(vehicle.GetInfo());
            vehicle.StartEngine();
            Console.WriteLine();
        }

        Console.WriteLine("Детальная информация:");
        

        Console.WriteLine($"Автомобиль 1: {car1.Brand} {car1.Model}, дверей: {car1.NumberOfDoors}");
        Console.WriteLine($"Мотоцикл 1: {moto1.Brand} {moto1.Model}, коляска: {moto1.HasSidecar}");
        Console.WriteLine($"Мотоцикл 2: {moto2.Brand} {moto2.Model}, коляска: {moto2.HasSidecar}");

      
        Console.ReadKey();
    }
}