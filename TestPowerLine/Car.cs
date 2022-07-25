using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPowerLine
{
	//У легкового автомобиля добавьте параметр количество перевозимых пассажиров.
	//На основе данного параметра может изменяться запас хода.
	//Предусмотрите проверку на допустимое количество пассажиров.
	//Каждый дополнительный пассажир уменьшает запас хода на дополнительные 6%. 
	internal class Car : Automobile
	{
		public Car(float fuelConsumption, float tankFuelVolume, float speed, int passengerMaxCount, float tankFilledPercent = 1)
		{
			this.Type = VehicleType.Car;
			this.FuelConsumption = fuelConsumption;
			this.TankFuelVolume = tankFuelVolume;
			this.TankFilledPercent = tankFilledPercent;
			this.MaxSpeed = speed;
			this.PassengerMaxCount = passengerMaxCount;
		}
		
		public int PassengerCount 
		{
			get => _passengerCount;		
			set
			{
				if(value <0 )
				{
					throw new ArgumentException("Пассажиров должно быть > 0");
				}

				if (value > PassengerMaxCount)
				{
					throw new ArgumentException("Превышено допустимое кол-во пасажиров");
				}

				_passengerCount = value;
			}
		}
		public int PassengerMaxCount 
		{ 
			get => _passengerMaxCount;
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException("Пассажиров должно быть > 0");
				}

				_passengerMaxCount = value;
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
			return "Каждый дополнительный пассажир уменьшает запас хода на дополнительные 6%. ";
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

		private float ReduceDistancePercent => 1 - (_reduceDistancePerPassenger * PassengerCount);

		private int _passengerCount;
		private int _passengerMaxCount;
		private float _reduceDistancePerPassenger = 0.06F;
	}
}
