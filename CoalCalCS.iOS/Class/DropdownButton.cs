using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.CodeDom.Compiler;
using CoalCalCS.iOS;

namespace CoalCalCS.iOS
{
	//[Register ("DropdownButton")]
	public partial class DropdownButton : UIButton
	{
		static UIColor GrayColor = UIColor.FromRGB (143.0f / 255.0f, 148.0f / 255.0f, 156.0f / 255.0f);

		UIView mBGView;
		UILabel mLabel;
		List<string> listItems = new List<string> ();

		UIPopoverController popoverControl = null;
		UITableViewController popoverTable = null;
		UINavigationController popoverNavVC = null;

		public DropdownButton (IntPtr handle) : base (handle)
		{
			innerInit ();
		}

		public DropdownButton() : base(UIButtonType.Custom)
		{
			innerInit ();
		}

		private void innerInit()
		{
			mBGView = new UIView ();
			mBGView.BackgroundColor = UIColor.White;
			AddSubview (mBGView);

			mLabel = new UILabel ();
			mLabel.Text = "";
			mLabel.BackgroundColor = UIColor.White;
			AddSubview (mLabel);

			SetTitle ("", UIControlState.Normal);
			SetImage (UIImage.FromFile ("down_arrow.png"), UIControlState.Normal);
			BackgroundColor = UIColor.White;
			HorizontalAlignment = UIControlContentHorizontalAlignment.Right;

			TouchUpInside += delegate(object sender, EventArgs e) {
				ShowList();
			};
		}

		public void ShowList()
		{
			bool isPhone = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone;

			if (isPhone) {
				popoverTable = new UITableViewController (UITableViewStyle.Plain);
				popoverTable.TableView.DataSource = new ListDataSource(listItems);
				popoverTable.TableView.Delegate = new ListDelegate(this);

				//UINavigationBar navBar = new UINavigationBar (new RectangleF (0, 0, this.Frame.Width, 44));
				UINavigationItem navItem = new UINavigationItem ("");

				UIBarButtonItem doneButtonItem = new UIBarButtonItem ("Back", UIBarButtonItemStyle.Done, (sender,args) => {
					popoverTable.DismissModalViewControllerAnimated(true);
				});

				popoverTable.NavigationItem.SetLeftBarButtonItem (doneButtonItem, true);

				popoverControl = null;
				popoverNavVC = new UINavigationController (popoverTable);

				AppDelegate.CurrentVC.PresentViewController (popoverNavVC, true, null);
			} else {
				popoverTable = new UITableViewController (UITableViewStyle.Plain);
				popoverTable.TableView.DataSource = new ListDataSource(listItems);
				popoverTable.TableView.Delegate = new ListDelegate(this);

				popoverControl = new UIPopoverController (popoverTable);
				popoverControl.PopoverContentSize = new SizeF (this.Frame.Width, listItems.Count * popoverTable.TableView.RowHeight);

				popoverControl.PresentFromRect (this.Frame, this.Superview, UIPopoverArrowDirection.Any, true);
			}
		}

		class ListDataSource : UITableViewDataSource
		{
			List<string> listItems;
			string cellIdentifier = "TableCell";

			public ListDataSource(List<string> items)
			{
				listItems = items;
			}

			public override int RowsInSection (UITableView tableView, int section)
			{
				return listItems.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

				if (cell == null)
					cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
				cell.TextLabel.Text = listItems[indexPath.Row];

				return cell;
			}
		}

		class ListDelegate : UITableViewDelegate
		{
			DropdownButton parent;

			public ListDelegate(DropdownButton button)
			{
				parent = button;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				parent.RowSelected (indexPath.Row);
			}
		}

		protected void RowSelected(int index)
		{
			Text = listItems [index];

			if (popoverControl != null)
				popoverControl.Dismiss (true);
			else
				popoverNavVC.DismissModalViewControllerAnimated (true);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			mBGView.Frame = new System.Drawing.RectangleF (0, 0, Frame.Width - 20, Frame.Height);
			mLabel.Frame = new System.Drawing.RectangleF (11, 1, Frame.Width - 32, Frame.Height - 2);

			Layer.BorderColor = DropdownButton.GrayColor.CGColor;
			Layer.BorderWidth = 1;
		}

		public List<string> Items
		{
			get { return listItems; }
			set {
				listItems.Clear ();
				listItems.AddRange (value);
			}
		}

		public string Text
		{
			get {
				return mLabel.Text;
			}
			set {
				mLabel.Text = value;
			}
		}
	}
}
