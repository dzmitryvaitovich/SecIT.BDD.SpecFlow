using BDD.SpecFlow.PageObjects.Pages;
using BDD.SpecFlow.Tests.Steps.UI.Common;
using BDD.SpecFlow.Tests.Steps.UI.Extensions;
using BDD.SpecFlow.Tests.Steps.UI.Transformations;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BDD.SpecFlow.Tests.Steps.UI
{
	[Binding]
	[Scope(Feature = "CreateAnAccount")]
	public class CreateAnAccountSteps
	{
		private UiContext _context;

		private MainPage MainPage => new MainPage(_context.Driver);

		private AuthenticationPage AuthenticationPage => new AuthenticationPage(_context.Driver);

		private CreateAnAccountPage CreateAnAccountPage => new CreateAnAccountPage(_context.Driver);

		public CreateAnAccountSteps(UiContext context)
		{
			_context = context;
		}

		[Given(@"I have navigated to My Account page")]
		public void GoToMyAccountPage()
		{
			MainPage.GoToMyAccount();
		}

		[Given(@"I went to create an account page with (.+@.+\..+) email")]
		public void GoToCreateAnAccountPageWithEmail(string email)
		{
			AuthenticationPage.CreateAnAccount_EmailAddress.Value = email;
			AuthenticationPage.CreateAnAccount();
		}

		[When(@"I register the following information")]
		public void WhenIRegisterTheFollowingInformation(CreateAnAccountTransformation transformation)
		{
			// In order to pass parameter different than Table you have to create 
			// a method marked by StepArgumentTransformation attribute as shown below.
			// It makes sense to do when you have same transformation used across multiple steps.
			// Otherwise yuo can do transformation directly in the step (i.e. in this method).
			CreateAnAccountPage.SetFields(transformation);
			CreateAnAccountPage.Register();
		}

		[StepArgumentTransformation("I register the following information")]
		public CreateAnAccountTransformation TransformToCreateAnAccount(Table table)
		{
			return table.CreateInstance<CreateAnAccountTransformation>();
		}

		[Then(@"exceptions should be shown")]
		public void ThenExceptionsShouldBeShown()
		{
			CreateAnAccountPage.AreExceptionsShown().Should().BeTrue();
		}
	}
}
