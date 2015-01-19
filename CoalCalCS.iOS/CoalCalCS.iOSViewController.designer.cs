// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
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
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void onTapContact (UIButton sender);

		[Action ("onTapHelp:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void onTapHelp (UIButton sender);

		[Action ("onTapPrint:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void onTapPrint (UIButton sender);

		[Action ("onTapShare:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void onTapShare (UIButton sender);

		[Action ("onTapTabItem:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void onTapTabItem (UIButton sender);

		[Action ("onTapVisit:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void onTapVisit (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
		}
	}
}
