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
    class AndroidCategoryManagerAdapter : BaseAdapter<AndroidCategory>
    {
        Context context;
        int layoutResourceId;
        AndroidCategoryManager AndroidCategoryManager;

        public AndroidCategoryManagerAdapter(Context context,
            int layoutResourceId, AndroidCategoryManager AndroidCategoryManager)
        {
            this.context = context;
            this.layoutResourceId = layoutResourceId;
            this.AndroidCategoryManager = AndroidCategoryManager;
        }

        public override AndroidCategory this[int position]
        {
            get
            {
                AndroidCategoryManager.MoveTo(position);
                return AndroidCategoryManager.Current;
            }
        }
            

        public override int Count
        {
            get { return AndroidCategoryManager.Length; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if(view == null)
            {
                LayoutInflater inflater =
                    context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(layoutResourceId, null);
            }

            TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);

            textView.Text = this[position].Title;

            return view;

        }
    }
}