using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPowerLine
{
	internal class Truck : Automobile
	{
		//Класс грузового автомобиля дополните параметром грузоподъемность.
		//Также, как и у легкового автомобиля, грузоподъемность влияет на запас хода автомобиля.
		//Дополните класс проверкой может ли автомобиль принять полный груз на борт.
		//Каждые дополнительные 200кг веса уменьшают запас хода на 4%.
		public Truck(float fuelConsumption, float tankFuelVolume, float speed, float loadMaxCapacity, float tankFilledPercent = 1)
		{
			this.Type = VehicleType.Truck;
			this.FuelConsumption = fuelConsumption;
			this.TankFuelVolume = tankFuelVolume;
			this.TankFilledPercent = tankFilledPercent;
			this.MaxSpeed = speed;
			this.LoadMaxCapacity = loadMaxCapacity;
		}

		public float LoadCapacity
		{
			get => _loadCapacity;
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Вес должен быть > 0");
				}

				if (value > LoadMaxCapacity)
				{
					throw new ArgumentException("Превышено допустимая загрузка");
				}

				_loadCapacity = value;
			}
		}
		public float LoadMaxCapacity
		{
			get => _loadMaxCapacity;
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException("Вес должен быть > 0");
				}

				_loadMaxCapacity = value;
			}
		}

		public override float DistanceLeft()
		{
			return TankFuelVolume * TankFilledPercent / FuelConsumption * 100 * ReduceDistancePercent;
		}

		public override float DistanceMax()
		{
			return TankFuelVolume / FuelConsumption * 100 * ReduceDistancePercent;
		}

		public override string FuelConsumptionInfo()
		{
			return "Каждые дополнительные 200кг веса уменьшают запас хода на 4%.";
		}

		public override float TimePerDistance(float distance, float fuelVolume)
		{
			if (distance < 0 || fuelVolume < 0)
			{
				throw new ArgumentException("Значения должны быть больше 0");
			}

			//Иначе не понятно для чего нужен параметр "Кол-во топлива"
			if (fuelVolume / FuelConsumption * 100 * ReduceDistancePercent < distance)
			{
				return float.PositiveInfinity;
			}

			return distance / MaxSpeed;
		}

		private float ReduceDistancePercent => (float)(1 - (_reduceDistancePer200Load * Math.Truncate(LoadCapacity / 200)));

		private float _reduceDistancePer200Load = 0.04F;
		private float _loadCapacity;
		private float _loadMaxCapacity;
	}
}