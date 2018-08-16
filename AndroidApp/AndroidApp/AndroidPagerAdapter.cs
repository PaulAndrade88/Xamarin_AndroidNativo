using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using AndroidLibrary;
using Java.Lang;

namespace AndroidApp
{
    public class AndroidPagerAdapter : FragmentStatePagerAdapter
    {
        AndroidManager androidManager;

        public AndroidPagerAdapter(FragmentManager fm, AndroidManager AndroidManager)
            :base(fm)
        {
            this.androidManager = AndroidManager;
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            androidManager.MoveTo(position);
            AndroidFragment AndroidFragment = new AndroidFragment
            {
                Course = androidManager.Current
            };

            return AndroidFragment;
        }

        public override int Count
        {
            get { return androidManager.Length; }
        }

        public AndroidManager AndroidManager
        {
            set
            {
                androidManager = value;
                NotifyDataSetChanged();
            }
        }

        public override int GetItemPosition(Java.Lang.Object @object)
        {
            return PositionNone;
        }
    }
}