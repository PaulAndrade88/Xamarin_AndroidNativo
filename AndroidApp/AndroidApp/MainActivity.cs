using System;
using Android;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using AndroidLibrary;

namespace AndroidApp
{
    //[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        Button buttonPrev;
        Button buttonNext;
        TextView textTitle;
        ImageView imageAndroid;
        TextView textDescription;
        AndroidManager AndroidManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {            

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            /*
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            */
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
            buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
            textTitle = FindViewById<TextView>(Resource.Id.textTitle);
            imageAndroid = FindViewById<ImageView>(Resource.Id.imageAndroid);
            textDescription = FindViewById<TextView>(Resource.Id.textDescription);

            buttonPrev.Click += buttonPrev_Click;
            buttonNext.Click += buttonNext_Click;

            AndroidManager = new AndroidManager();
            AndroidManager.MoveFirst();
            UpdateUI();

        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            AndroidManager.MovePrev();
            UpdateUI();
            //textTitle.Text = "Prev Clicked";
            //textDescription.Text = "Prev clicked description";
            //imageAndroid.SetImageResource(Resource.Mipmap.AndroidBadGuy);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            AndroidManager.MoveNext();
            UpdateUI();
            //textTitle.Text = "Next Clicked";
            //textDescription.Text = "Next clicked description";
            //imageAndroid.SetImageResource(Resource.Mipmap.androiddatahero);
        }

        private void UpdateUI()
        {
            textTitle.Text = AndroidManager.Current.Title;
            textDescription.Text = AndroidManager.Current.Description;
            imageAndroid.SetImageResource(
                ResourceHelper.TranslateMipmapWithReflection(
                    AndroidManager.Current.Image));
            buttonPrev.Enabled = AndroidManager.canMovePrev;
            buttonNext.Enabled = AndroidManager.canMoveNext;
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
        /*FabOnClick(object sender, EventArgs eventArgs)
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        */
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_camera)
            {
                // Handle the camera action
            }
            else if (id == Resource.Id.nav_gallery)
            {

            }
            else if (id == Resource.Id.nav_slideshow)
            {

            }
            else if (id == Resource.Id.nav_manage)
            {

            }
            else if (id == Resource.Id.nav_share)
            {

            }
            else if (id == Resource.Id.nav_send)
            {

            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}

