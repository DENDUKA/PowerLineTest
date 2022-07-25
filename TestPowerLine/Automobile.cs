using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPowerLine
{
	/*
	 * Опишите класс автомобиль у которого есть базовые параметры в виде типа ТС, среднего расхода топлива, объем топливного бака, скорость. +
	 * Опишите метод, с помощью которого можно вычислить сколько автомобиль может проехать на полном баке топлива или на остаточном количестве топлива в баке 
	 * на данный момент. + 
	 * Метод, который на основе параметров количества топлива и заданного расстояния вычисляет за сколько автомобиль его преодолеет. +
	 * Реализуйте на его основе классы легковой автомобиль, грузовой автомобиль, спортивный автомобиль. 
	 * Метод для отображения текущей информации о состоянии запаса хода в зависимости от пассажиров и груза. +
	  */
	internal abstract class Automobile
	{
		public VehicleType Type { get; protected set; }
		public float MaxSpeed { get; protected set; }
		public float FuelConsumption 
		{
			get => _fuelConsumption;
			protected set
			{
				if (value < 0)
				{
					throw new ArgumentException("Расход не может быть отрицательным");
				}

				_fuelConsumption = value;
			}
		}
		public float TankFuelVolume 
		{
			get => _tankFuelVolume;
			protected set
			{
				if (value < 0)
				{
					throw new ArgumentException("Объем бака не может быть отрицательным");
				}

				_tankFuelVolume = value;
			}
		}
		public float TankFilledPercent 
		{
			get => _tankFilledPercent;
			protected set 
			{
				if (value < 0 || value > 100)
				{
					throw new ArgumentException("Значение % должно быть от 0 до 100");
				}

				_tankFilledPercent = value;
			} 
		}		

		/// <summary>
		/// На основе параметров количества топлива и заданного расстояния вычисляет за сколько автомобиль его преодолеет.
		/// </summary>
		public abstract float TimePerDistance(float distance, float fuelVolume);
		/// <summary>
		/// Запас хода Авто при полном баке.
		/// </summary>
		/// <returns></returns>
		public abstract float DistanceMax();
		/// <summary>
		/// Осталось проехать на оставшемся запасе топлива.
		/// </summary>
		/// <returns></returns>
		public abstract float DistanceLeft();
		/// <summary>
		/// Информации о состоянии запаса хода в зависимости от пассажиров и груза.
		/// </summary>
		public abstract string FuelConsumptionInfo();

		private float _fuelConsumption;
		private float _tankFuelVolume;
		private float _tankFilledPercent;
	}
}