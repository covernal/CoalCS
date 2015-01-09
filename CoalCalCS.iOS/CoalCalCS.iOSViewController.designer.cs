// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace CoalCalCS.iOS
{
	[Register ("CoalCalCS_iOSViewController")]
	partial class CoalCalCS_iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIView pageContainer { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel pageTitle { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton[] tabButtons { get; set; }

		[Action ("onTapContact:")]
		partial void onTapContact (MonoTouch.Foundation.NSObject sender);

		[Action ("onTapHelp:")]
		partial void onTapHelp (MonoTouch.Foundation.NSObject sender);

		[Action ("onTapPrint:")]
		partial void onTapPrint (MonoTouch.Foundation.NSObject sender);

		[Action ("onTapShare:")]
		partial void onTapShare (MonoTouch.Foundation.NSObject sender);

		[Action ("onTapTabItem:")]
		partial void onTapTabItem (MonoTouch.UIKit.UIButton sender);

		[Action ("onTapVisit:")]
		partial void onTapVisit (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (pageTitle != null) {
				pageTitle.Dispose ();
				pageTitle = null;
			}

			if (pageContainer != null) {
				pageContainer.Dispose ();
				pageContainer = null;
			}
		}
	}
}
