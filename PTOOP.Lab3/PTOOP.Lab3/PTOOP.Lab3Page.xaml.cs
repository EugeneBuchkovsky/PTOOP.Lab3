using System;
using System.Collections.Generic;
using System.Reflection;
using PTOOP.Lab3.BLL;
using PTOOP.Lab3.BLL.Entities;
using Xamarin.Forms;

namespace PTOOP.Lab3
{
	public partial class PTOOP_Lab3Page : ContentPage
	{
		public PTOOP_Lab3Page()
		{
			InitializeComponent();
			_mix = new Mixture();

			var stack = new StackLayout { Orientation = StackOrientation.Vertical };

			typeList = new Picker { Title = "Select", Margin = new Thickness(20) };
			typeList.Items.Add("Alcohol");
			typeList.Items.Add("Caffeine");
			typeList.Items.Add("CodeinePhosphate");
			typeList.Items.Add("Hydrocortisone");
			typeList.Items.Add("SodiumBromide");
			typeList.Items.Add("Water");
			typeList.SelectedIndexChanged += (sender, e) =>
			{
				int selectedIndex = typeList.SelectedIndex;
				if (selectedIndex != -1)
				{
					SelectedType = typeList.Items[selectedIndex];
					GetSelectedType();
				}
			};

			componentList = new ListView();
			componentList.ItemsSource = _mix.components;

			componentList.ItemTemplate = new DataTemplate(typeof(CustomCell));

			stack.Children.Add(typeList);
			stack.Children.Add(componentList);

			Content = stack;

		}

		ListView componentList;
		public string SelectedType { get; set; }
		public Type _selectedType { get; set; }
		Picker typeList;

		private Mixture _mix;

		private void GetSelectedType()
		{
			_mix.AddComponents(SelectedType);
		}
	}

	public class CustomCell : ViewCell
	{
		public CustomCell()
		{
			var nameLabel = new Label();
			var cLabel = new Label();
			var verticaLayout = new StackLayout();

			//set bindings
			nameLabel.SetBinding(Label.TextProperty, new Binding("Name"));
			cLabel.SetBinding(Label.TextProperty, new Binding("Conc"));

			nameLabel.FontSize = 24;

			//add views to the view hierarchy
			verticaLayout.Children.Add(nameLabel);
			verticaLayout.Children.Add(cLabel);

			// add to parent view
			View = verticaLayout;
		}
	}
}
