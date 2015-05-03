using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace AidPlusAndroid
{
	[Activity (MainLauncher = true)]
	public class MainActivity : AppCompatActivity, Android.Support.V4.App.FragmentManager.IOnBackStackChangedListener
	{
		private const string TAG = "TestXamAnd";
		private Android.Support.V4.App.FragmentManager mFragmentManager;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			mFragmentManager = SupportFragmentManager;
			mFragmentManager.AddOnBackStackChangedListener (this);

			var toolbar = FindViewById<Toolbar> (Resource.Id.toolbar);
			SetSupportActionBar (toolbar);
			SupportActionBar.Title = GetString (Resource.String.app_name);

			if (bundle == null)
			{
				openFragment ();
			}

			shouldDisplayHomeUp ();
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.main, menu);

			return base.OnPrepareOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
			case Resource.Id.action_settings:
				var fragment = SettingsFragment.NewInstance ();

				var ft = mFragmentManager.BeginTransaction ();
				ft.SetCustomAnimations (Resource.Animation.slideout_left,
					Resource.Animation.slidein_right,
					Resource.Animation.slideout_right,
					Resource.Animation.slidein_left)
				.Replace (Resource.Id.frameContainer, fragment)
				.AddToBackStack (null)
				.Commit ();

				return true;
			}
			return base.OnOptionsItemSelected (item);
		}

		#region IOnBackStackChangedListener implementation

		public void OnBackStackChanged ()
		{
			shouldDisplayHomeUp ();
		}

		#endregion

		public override Boolean OnSupportNavigateUp ()
		{
			mFragmentManager.PopBackStack ();

			return true;
		}

		private void shouldDisplayHomeUp ()
		{
			var count = mFragmentManager.BackStackEntryCount;
			SupportActionBar.SetDisplayHomeAsUpEnabled (count > 0 ? true : false);
			SupportActionBar.SetHomeButtonEnabled (count > 0 ? true : false);
		}

		private void openFragment ()
		{
			var fragment = MainFragment.NewInstance ();

			var fragmentTransaction = mFragmentManager.BeginTransaction ();
			fragmentTransaction.Replace (Resource.Id.frameContainer, fragment);
			fragmentTransaction.Commit ();
		}
	}
}
