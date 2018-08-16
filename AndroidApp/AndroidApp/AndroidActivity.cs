using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using AndroidLibrary;

namespace AndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    //[Activity(Label = "Android Activity")]
    public class AndroidActivity : FragmentActivity
    {
        public const String DISPLAY_CATEGORY_TITLE_EXTRA = "DisplayCategoryTitleExtra";
        private const String DEFAULT_CATEGORY_TITLE = "Android";
        AndroidCategoryManager AndroidCategoryManager;
        AndroidManager AndroidManager;
        AndroidPagerAdapter AndroidPagerAdapter;
        ViewPager viewPager;
        DrawerLayout drawerLayout;
        ListView categoryDrawerListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AndroidActivity);

            AndroidCategoryManager = new AndroidCategoryManager();
            AndroidCategoryManager.MoveFirst();

            String displayCategoryTitle = AndroidCategoryManager.Current.Title;
            //String displayCategoryTitle = DEFAULT_CATEGORY_TITLE;
            //Intent startupIntent = this.Intent;
            //if(startupIntent != null)
            //{
            //    String displayCategoryTitleExtra =
            //        startupIntent.GetStringExtra(DISPLAY_CATEGORY_TITLE_EXTRA);
            //    if (displayCategoryTitleExtra != null)
            //        displayCategoryTitle = displayCategoryTitleExtra;
            //}


            AndroidManager = new AndroidManager(displayCategoryTitle);
            AndroidManager.MoveFirst();

            AndroidPagerAdapter = 
                new AndroidPagerAdapter(SupportFragmentManager, AndroidManager);

            viewPager = FindViewById<ViewPager>(Resource.Id.coursePager);
            viewPager.Adapter = AndroidPagerAdapter;

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            categoryDrawerListView = FindViewById<ListView>(Resource.Id.categoryDrawerListView);

            categoryDrawerListView.Adapter =
                new AndroidCategoryManagerAdapter(this, 
                Resource.Layout.AndroidCategoryItem,
                AndroidCategoryManager);

            categoryDrawerListView.SetItemChecked(0, true);
            categoryDrawerListView.ItemClick += CategoryDrawerListView_ItemClick;
        }

        private void CategoryDrawerListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            drawerLayout.CloseDrawer(categoryDrawerListView);

            AndroidCategoryManager.MoveTo(e.Position);
            AndroidManager = new AndroidManager(AndroidCategoryManager.Current.Title);
            AndroidPagerAdapter.AndroidManager = AndroidManager;

            viewPager.CurrentItem = 0;
        }
    }
}