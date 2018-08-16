using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidLibrary;

namespace AndroidApp
{
    //[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class CategoryActivity : ListActivity
    {
        AndroidCategoryManager AndroidCategoryManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            //string[] categoryTitles = { "Category1", "Category2", "Category3" };

            //ListAdapter =
            //    new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,
            //    categoryTitles);

            AndroidCategoryManager = new AndroidCategoryManager();
            ListAdapter =
                new AndroidCategoryManagerAdapter(this, Android.Resource.Layout.SimpleListItem1, 
                    AndroidCategoryManager);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            Intent intent = new Intent(this, typeof(AndroidActivity));

            AndroidCategoryManager.MoveTo(position);
            String categoryTitle = AndroidCategoryManager.Current.Title;

            intent.PutExtra(AndroidActivity.DISPLAY_CATEGORY_TITLE_EXTRA, categoryTitle);

            StartActivity(intent);
        }
    }
}