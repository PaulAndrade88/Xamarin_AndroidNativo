using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidLibrary;

namespace AndroidApp
{
    public class AndroidFragment : Fragment
    {
        TextView textTitle;
        ImageView imageAndroid;
        TextView textDescription;

        public Course Course { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View rootView = inflater.Inflate(Resource.Layout.AndroidFragment, container, false);

            textTitle = rootView.FindViewById<TextView>(Resource.Id.textTitle);
            imageAndroid = rootView.FindViewById<ImageView>(Resource.Id.imageAndroid);
            textDescription = rootView.FindViewById<TextView>(Resource.Id.textDescription);

            textTitle.Text = Course.Title;
            textDescription.Text = Course.Description;
            imageAndroid.SetImageResource(
                ResourceHelper.TranslateMipmapWithReflection(
                    Course.Image));

            return rootView;
        }
    }
}