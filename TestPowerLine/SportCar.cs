using System;

namespace TestPowerLine
{
	internal class SportCar : Automobile
	{
		public SportCar(float fuelConsumption, float tankFuelVolume, float speed, float tankFilledPercent = 1)
		{
			this.Type = VehicleType.SportCar;
			this.FuelConsumption = fuelConsumption;
			this.TankFuelVolume = tankFuelVolume;
			this.TankFilledPercent = tankFilledPercent;
			this.MaxSpeed = speed;
		}
		public override float DistanceLeft()
		{
			return TankFuelVolume * TankFilledPercent / FuelConsumption * 100;
		}

		public override float DistanceMax()
		{
			return TankFuelVolume / FuelConsumption * 100;
		}

		public override string FuelConsumptionInfo()
		{
			return "Спортивный авто";
		}

		public override float TimePerDistance(float distance, float fuelVolume)
		{
			if (distance < 0 || fuelVolume < 0)
			{
				throw new ArgumentException("Значения должны быть больше 0");
			}

			//Иначе не понятно для чего нужен параметр "Кол-во топлива"
			if (fuelVolume / FuelConsumption * 100 < distance)
			{
				return float.PositiveInfinity;
			}

			return distance / MaxSpeed;
		}
	}
}
