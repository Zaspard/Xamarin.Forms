﻿using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

#if UITEST
using Xamarin.Forms.Core.UITests;
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Xamarin.Forms.Controls.Issues
{
#if UITEST
	[Category(UITestCategories.ManualReview)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 2204, "Font aliasing and color aren't displayed correctly in MacOS without a retina display", PlatformAffected.macOS)]
	public class Issue2204 : TestContentPage // or TestMasterDetailPage, etc ...
	{
		readonly string _fontFamilyMacOs = "Roboto";
		protected override void Init()
		{
			var grid = new Grid();
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			var layout = new StackLayout
			{
				BackgroundColor = Color.FromHex("#32d2c8")
			};
			var layout2 = new StackLayout
			{
				BackgroundColor = Color.FromHex("#32d2c8")
			};

			for (int i = 10; i < 20; i++)
			{
				AddToLayout(layout, i, _fontFamilyMacOs);
				AddToLayout(layout2, i, null);
			}
			grid.Children.Add(layout);
			grid.Children.Add(layout2, 1, 0);
			Content = new ScrollView { Content = grid } ;
		}

		private static void AddToLayout(StackLayout layout, int i, string fontFamily)
		{
			var text = $"Xamarin Forms FontSize:{i}";
			layout.Children.Add(new Label { Text = text, FontSize = i, FontFamily = fontFamily, TextColor = Color.White });
			layout.Children.Add(new Label { Text = text, FontSize = i, FontFamily = fontFamily, FontAttributes = FontAttributes.Bold, TextColor = Color.White });
			layout.Children.Add(new Label { Text = text, FontSize = i, FontFamily = fontFamily, FontAttributes = FontAttributes.Italic, TextColor = Color.White });
			layout.Children.Add(new Label { Text = text, FontSize = i, FontFamily = fontFamily, FontAttributes = FontAttributes.Italic | FontAttributes.Bold, TextColor = Color.White });
		}
	}
}