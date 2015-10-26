using EncoderApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Data.Html;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EncoderApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		//next time, databind 
		public Models.Victim Victim { get; set; }
		public MainPage()
        {
			Victim = new Victim();

			this.InitializeComponent();
			Gender.Items.Add("Male");
			Gender.Items.Add("Female");
			Gender.Items.Add("N/A");

			UrgencyLevel.Items.Add("Critical Condition");
			UrgencyLevel.Items.Add("Urgent");
			UrgencyLevel.Items.Add("By End of Day");

			BleadingLevel.Items.Add("Internally");
			BleadingLevel.Items.Add("Externally from core");
			BleadingLevel.Items.Add("Externally from limbs");
			BleadingLevel.Items.Add("Minor");

			Name.TextChanged += Name_TextChanged;
			Gender.SelectionChanged += Gender_SelectionChanged;
			Age.SelectionChanged += Age_SelectionChanged;
			UrgencyLevel.SelectionChanged += UrgencyLevel_SelectionChanged;
			HasFood.Unchecked += HasFood_Unchecked;
			HasFood.Checked += HasFood_Checked;
			HasWater.Unchecked += HasWater_Unchecked;
			HasWater.Checked += HasWater_Checked;
			HasMedication.Checked += HasMedication_Checked;
			HasMedication.Unchecked += HasMedication_Unchecked;
			BleadingLevel.SelectionChanged += BleadingLevel_SelectionChanged;

			copybutton.Tapped += Copybutton_Tapped;


		}

		private void Copybutton_Tapped(object sender, TappedRoutedEventArgs e)
		{
			var dataPackage = new DataPackage();			
			string plainText = HtmlUtilities.ConvertToText(output.Text);
			dataPackage.SetText(plainText);

			Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
        }

		private void StateChanged()
		{
			Victim.Name = Name.Text;

			switch ( Gender?.SelectionBoxItem?.ToString() ) {
				case "Male":
					Victim.Gender = Models.Gender.male;
					break;
				case "Female":
					Victim.Gender = Models.Gender.female;
					break;
				case "N/A":
					Victim.Gender = Models.Gender.na;
					break;
			}
			Victim.Age = Age.Text;
			switch (UrgencyLevel?.SelectionBoxItem?.ToString())
			{
				case "Critical Condition":
					Victim.UrgencyLevel = Models.UrgencyLevel.P1Immediate;
					break;
				case "Urgent":
					Victim.UrgencyLevel = Models.UrgencyLevel.P2WaitHour;
					break;
				case "By End of Day":
					Victim.UrgencyLevel = Models.UrgencyLevel.P3WaitFour;
					break;
			}
			Victim.HaveFood = (bool)HasFood.IsChecked;
			Victim.HaveWater = (bool)HasWater.IsChecked;
			Victim.HaveExistingMedication = (bool)HasMedication.IsChecked;

			switch (BleadingLevel?.SelectionBoxItem?.ToString())
			{
				case "Internally":
					Victim.BleedingLevel = Models.BleedingLevel.Internal;
					break;
				case "Externally from core":
					Victim.BleedingLevel = Models.BleedingLevel.ExternalCore;
					break;
				case "Externally from limbs":
					Victim.BleedingLevel = Models.BleedingLevel.ExternalExtremities;
					break;
				case "Minor":
					Victim.BleedingLevel = Models.BleedingLevel.Minor;
					break;
			}

			output.Text = Models.VictimTools.VictimEncode(Victim);
		}


		private void BleadingLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			StateChanged();
        }

		private void HasMedication_Unchecked(object sender, RoutedEventArgs e)
		{
			StateChanged();
        }

		private void HasMedication_Checked(object sender, RoutedEventArgs e)
		{
			StateChanged();
        }

		private void HasWater_Checked(object sender, RoutedEventArgs e)
		{
			StateChanged();
        }

		private void HasWater_Unchecked(object sender, RoutedEventArgs e)
		{
			StateChanged();
        }

		private void HasFood_Checked(object sender, RoutedEventArgs e)
		{
			StateChanged();
        }

		private void HasFood_Unchecked(object sender, RoutedEventArgs e)
		{
			StateChanged();
        }

		private void UrgencyLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			StateChanged();
        }

		private void Age_SelectionChanged(object sender, RoutedEventArgs e)
		{
			StateChanged();
		}

		private void Gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			StateChanged();
        }

		private void Name_TextChanged(object sender, TextChangedEventArgs e)
		{
			StateChanged();
        }
	}
}
