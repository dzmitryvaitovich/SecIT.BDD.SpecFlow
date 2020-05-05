using BDD.SpecFlow.PageObjects.Common;
using BDD.SpecFlow.PageObjects.Controls;
using System;
using System.Linq;

namespace BDD.SpecFlow.Tests.Steps.UI.Extensions
{
	public static class ContextBaseExtensions
	{
		public static void SetFields<T>(this ContextBase context, T transformation)
		{
			var contextControlProperties = context.GetType().GetProperties().Where(p => p.PropertyType.BaseType.Equals(typeof(ControlBase)));
			var transformationProperties = transformation.GetType().GetProperties().Where(p => p.GetValue(transformation) != null).ToList();

			foreach (var transformationProperty in transformationProperties)
			{
				var contextControlProperty = contextControlProperties.Single(c => c.Name.Equals(transformationProperty.Name, StringComparison.InvariantCultureIgnoreCase));
				var contextControlPropertyType = contextControlProperty.PropertyType;
				var contextControl = contextControlProperty.GetValue(context);
				var transformationPropertyValue = transformationProperty.GetValue(transformation);

				if (contextControlPropertyType.Equals(typeof(Textbox)))
				{
					((Textbox) contextControl).Value = transformationPropertyValue.ToString();
					continue;
				}
				if (contextControlPropertyType.Equals(typeof(RadioButtonGroup)))
				{
					((RadioButtonGroup) contextControl).Select(transformationPropertyValue.ToString());
				}
			}
		}
	}
}
