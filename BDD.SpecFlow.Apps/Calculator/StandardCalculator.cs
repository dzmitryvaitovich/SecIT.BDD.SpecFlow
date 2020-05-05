using System;

namespace BDD.SpecFlow.Apps.Calculator
{
	public class StandardCalculator
	{
		private CalculatorOperations _latestOperation;
		private double _latestParameter;

		public StandardCalculator()
		{
			_latestOperation = CalculatorOperations.None;
		}

		public double CurrentResult { get; private set; }

		public void EnterNumber(double number)
		{
			CurrentResult = number;
		}

		public double Plus(double summand)
		{
			CurrentResult += summand;
			_latestOperation = CalculatorOperations.Plus;
			_latestParameter = summand;
			return CurrentResult;
		}

		public double Minus(double subtrahend)
		{
			CurrentResult -= subtrahend;
			_latestOperation = CalculatorOperations.Minus;
			_latestParameter = subtrahend;
			return CurrentResult;
		}

		public double Multiply(double multiplier)
		{
			CurrentResult *= multiplier;
			_latestOperation = CalculatorOperations.Multiply;
			_latestParameter = multiplier;
			return CurrentResult;
		}

		public double Divide(double divisor)
		{
			if (divisor == 0)
			{
				throw new ArgumentException("Divisor cannot be 0!");
			}

			CurrentResult /= divisor;
			_latestOperation = CalculatorOperations.Divide;
			_latestParameter = divisor;
			return CurrentResult;
		}

		public double Square()
		{
			_latestOperation = CalculatorOperations.Square;
			return CurrentResult * CurrentResult;
		}

		public double Cube()
		{
			_latestOperation = CalculatorOperations.Cube;
			return CurrentResult * CurrentResult * CurrentResult;
		}

		public void Clear()
		{
			_latestOperation = CalculatorOperations.Clear;
			CurrentResult = 0;
			_latestParameter = 0;
		}

		public double Equals()
		{
			switch (_latestOperation)
			{
				case CalculatorOperations.None:
					return 0;
				case CalculatorOperations.Clear:
					return _latestParameter;
				case CalculatorOperations.Plus:
					return Plus(_latestParameter);
				case CalculatorOperations.Minus:
					return Minus(_latestParameter);
				case CalculatorOperations.Multiply:
					return Multiply(_latestParameter);
				case CalculatorOperations.Divide:
					return Divide(_latestParameter);
				case CalculatorOperations.Cube:
				case CalculatorOperations.Square:
					return CurrentResult;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}