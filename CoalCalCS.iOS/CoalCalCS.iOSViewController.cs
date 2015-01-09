using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CoalCalCS.iOS
{
	public partial class CoalCalCS_iOSViewController : UIViewController
	{
		int selectedTabIndex = -1;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}


		public CoalCalCS_iOSViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			foreach (UIButton button in tabButtons) {
				button.TitleLabel.TextAlignment = UITextAlignment.Center;
			}
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

		partial void onTapContact (MonoTouch.Foundation.NSObject sender)
		{
		}

		partial void onTapHelp (MonoTouch.Foundation.NSObject sender)
		{
		}

		partial void onTapPrint (MonoTouch.Foundation.NSObject sender)
		{
		}

		partial void onTapShare (MonoTouch.Foundation.NSObject sender)
		{
		}

		partial void onTapVisit (MonoTouch.Foundation.NSObject sender)
		{
		}

		partial void onTapTabItem (MonoTouch.UIKit.UIButton sender)
		{
			int index = sender.Tag - 1;

			SelectTab(index);
		}

		protected void SelectTab(int tabIndex)
		{
			if (selectedTabIndex >= 0 && selectedTabIndex < tabButtons.Length) {
				tabButtons [selectedTabIndex].SetTitleColor (UIColor.FromWhiteAlpha(157.0f/255.0f, 1), UIControlState.Normal);
				tabButtons [selectedTabIndex].SetTitleColor (UIColor.FromWhiteAlpha(157.0f/255.0f, 1), UIControlState.Selected);
				tabButtons [selectedTabIndex].SetTitleColor (UIColor.FromWhiteAlpha(157.0f/255.0f, 1), UIControlState.Highlighted);
				tabButtons [selectedTabIndex].SetTitleColor (UIColor.FromWhiteAlpha(157.0f/255.0f, 1), UIControlState.Disabled);
			}

			selectedTabIndex = tabIndex;

			if (selectedTabIndex >= 0 && selectedTabIndex < tabButtons.Length) {
				tabButtons [selectedTabIndex].SetTitleColor (UIColor.White, UIControlState.Normal);
				tabButtons [selectedTabIndex].SetTitleColor (UIColor.White, UIControlState.Selected);
				tabButtons [selectedTabIndex].SetTitleColor (UIColor.White, UIControlState.Highlighted);
				tabButtons [selectedTabIndex].SetTitleColor (UIColor.White, UIControlState.Disabled);

				pageTitle.Text = "  " + tabButtons [selectedTabIndex].Title (UIControlState.Normal).ToUpper ();
			}
		}
	}
}

