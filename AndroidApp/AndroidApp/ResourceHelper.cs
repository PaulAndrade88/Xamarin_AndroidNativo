using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApp
{
    public class ResourceHelper
    {
        static Dictionary<string, int> resourceDictionary = new Dictionary<string, int>();
        
        public static int TranslateMipmapWithReflection(string mipmapName)
        {
            int resourceValue = -1;

            if (resourceDictionary.ContainsKey(mipmapName))
            {
                resourceValue = resourceDictionary[mipmapName];
            }
            else
            {
                Type mipMapType = typeof(Resource.Mipmap);
                FieldInfo resourceFieldInfo = mipMapType.GetField(mipmapName);

                resourceValue = (int)resourceFieldInfo.GetValue(null);

                resourceDictionary.Add(mipmapName, resourceValue);
            }

            return resourceValue;
        }

    }
}