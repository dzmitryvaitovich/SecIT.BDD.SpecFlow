using BDD.SpecFlow.Apps.Calculator;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BDD.SpecFlow.Tests.Steps.API
{
	[Binding]
	[Scope(Feature = "Calculator")]
	public class CalculatorSteps
	{
		private ScenarioContext _context;

		private StandardCalculator calculator => _context.Get<StandardCalculator>("calculator");

		public CalculatorSteps(ScenarioContext context)
		{
			_context = context;
		}

		[BeforeScenario]
		public void ScenarioSetup()
		{
			var calculator = new StandardCalculator();
			_context.Add("calculator", calculator);
		}

		[AfterScenario]
		public void ScenarioCleanup()
		{
			var calculator = _context.Get<StandardCalculator>("calculator");
			calculator = null;
		}

		[Given(@"I entered number ([-]?[0-9]*\.?[0-9]*)")]
		public void GivenIEnteredNumber(double number)
		{
			calculator.EnterNumber(number);
		}

		[When(@"I'm multiplying by ([-]?[0-9]*\.?[0-9]*)")]
		public void WhenIMMultiplyingBy(double input)
		{
			calculator.Multiply(input);
		}

		[When(@"I press equals")]
		public void WhenIPressEquals()
		{
			ScenarioContext.Current.Pending();
		}

		[When(@"I'm adding ([-]?[0-9]*\.?[0-9]*)")]
		public void WhenIMAdding(double number)
		{
			calculator.Plus(number);
		}

		[When(@"I'm substracting ([-]?[0-9]*\.?[0-9]*)")]
		public void WhenIMSubstracting(double number)
		{
			calculator.Minus(number);
		}

		[Then(@"result should be equal to (\d+)")]
		public void ThenResultShouldBeEqualTo(double expectedResult)
		{
			calculator.CurrentResult.Should().Be(expectedResult);
		}
	}
}
