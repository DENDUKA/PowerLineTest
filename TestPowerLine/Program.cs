using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPowerLine
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Car car1 = new Car(7, 50, 100, 5, 0.4F);

			car1.PassengerCount = 2;
			
			Console.WriteLine($"{car1.FuelConsumptionInfo()}\nПассажиров : {car1.PassengerCount} Макс дистанция : {car1.DistanceMax()}км Осталось : {car1.DistanceLeft()}км Дистанию 200 с баком 20л проедет за {car1.TimePerDistance(200,20)} часа");

			car1.PassengerCount = 5;

			Console.WriteLine($"{car1.FuelConsumptionInfo()}\nПассажиров : {car1.PassengerCount} Макс дистанция : {car1.DistanceMax()}км Осталось : {car1.DistanceLeft()}км Дистанию 200 с баком 20л проедет за {car1.TimePerDistance(200, 20)} часа");

			Truck truck = new Truck(15, 140, 60, 2000, 0.8F);

			truck.LoadCapacity = 1300;

			Console.WriteLine($"{truck.FuelConsumptionInfo()}\nЗагрузка : {truck.LoadCapacity}кг Макс дистанция : {truck.DistanceMax()}км Осталось : {truck.DistanceLeft()}км Дистанию 200 с баком 30л проедет за {truck.TimePerDistance(200, 30)} часа");
			
			truck.LoadCapacity = 0;

			Console.WriteLine($"{truck.FuelConsumptionInfo()}\nЗагрузка : {truck.LoadCapacity}кг Макс дистанция : {truck.DistanceMax()}км Осталось : {truck.DistanceLeft()}км Дистанию 200 с баком 30л проедет за {truck.TimePerDistance(200, 30)} часа");

			Console.ReadKey();
		}
	}
}
