
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
	public class SettingsFragment : Android.Support.V4.App.Fragment
	{
		public static SettingsFragment NewInstance ()
		{
			return new SettingsFragment ();
		}

		public SettingsFragment ()
		{
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View v = inflater.Inflate (Resource.Layout.FragmentSettings, container, false);

			return v;
		}
	}
}

