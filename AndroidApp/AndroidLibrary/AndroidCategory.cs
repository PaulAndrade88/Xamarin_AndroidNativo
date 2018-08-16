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

namespace AndroidLibrary
{
    public class AndroidCategory
    {
        public String Title { get; internal set; }
        public String Description { get; internal set; }
        public override string ToString()
        {
            return Title;
        }
    }
}