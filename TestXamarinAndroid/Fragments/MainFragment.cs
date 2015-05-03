﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AidPlusAndroid
{
	public class MainFragment : Android.Support.V4.App.Fragment
	{
		public static MainFragment NewInstance ()
		{
			return new MainFragment ();
		}

		public MainFragment ()
		{
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View v = inflater.Inflate (Resource.Layout.FragmentMain, container, false);

			return v;
		}
	}
}

