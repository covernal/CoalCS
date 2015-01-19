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

		CBasisVC cBasisVC;


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

			AppDelegate.CurrentVC = this;
			
			foreach (UIButton button in tabButtons) {
				button.TitleLabel.TextAlignment = UITextAlignment.Center;
			}

			cBasisVC = this.Storyboard.InstantiateViewController ("CBasisVC") as CBasisVC;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			showPage (1);
		}

		#endregion

		protected void showPage(int index)
		{
			foreach (UIView subview in this.pageContainer.Subviews) {
				subview.RemoveFromSuperview ();
			}

			this.pageContainer.AddSubview (cBasisVC.View);
			cBasisVC.View.Frame = this.pageContainer.Bounds;

			this.pageContainer.Layer.BorderColor = UIColor.Blue.CGColor;
			this.pageContainer.Layer.BorderWidth = 1;
		}

		partial void onTapContact (UIButton sender)
		{
		}

		partial void onTapHelp (UIButton sender)
		{
		}

		partial void onTapPrint (UIButton sender)
		{
		}

		partial void onTapShare (UIButton sender)
		{
		}

		partial void onTapVisit (UIButton sender)
		{
		}

		partial void onTapTabItem (UIButton sender)
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

