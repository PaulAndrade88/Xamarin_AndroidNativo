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

namespace AndroidLibrary
{
    public class AndroidCategoryManager
    {
        private readonly AndroidCategory[] categories;
        private int currentIndex = 0;
        private readonly int lastIndex;

        public AndroidCategoryManager()
        {
            categories = InitCategories();
            lastIndex = categories.Length - 1;
        }

        private AndroidCategory[] InitCategories()
        {
            var initCategories = new AndroidCategory[] {
                new AndroidCategory()
                {
                    Title = "Android",
                    Description = "Android programming Courses"
                },
                new AndroidCategory()
                {
                    Title = "iOS",
                    Description = "iOS programming Courses"
                },
                new AndroidCategory()
                {
                    Title = "Windows Phone",
                    Description = "Windows Phone programming Courses"
                }
            };

            return initCategories;
        }

        public int Length
        {
            get { return categories.Length; }
        }

        public void MoveFirst()
        {
            currentIndex = 0;
        }

        public void MoveNext()
        {
            if (currentIndex < lastIndex)
                ++currentIndex;
        }

        public void MoveTo(int position)
        {
            if (position >= 0 && position <= lastIndex)
                currentIndex = position;
            else
                throw new IndexOutOfRangeException(
                    String.Format("{0} is an invalid position. Position must be between 0 and {1}",
                    position, lastIndex));

        }

        public AndroidCategory Current
        {
            get { return categories[currentIndex]; }
        }

        public Boolean CanMoveNext
        {
            get { return currentIndex < lastIndex; }
        }


    }
}
