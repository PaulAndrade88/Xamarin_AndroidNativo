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
    public class AndroidManager
    {
        private const String DefaultCategory = "Android";

        private readonly Course[] Courses;
        int currentIndex = 0;
        private readonly int lastIndex;

        public AndroidManager()
            : this(DefaultCategory) { }

        public AndroidManager(String categoryTitle)
        {
            switch(categoryTitle)
            {
                case "Android":
                    Courses = AndroidCourses();
                    break;
                case "iOS":
                    Courses = IOSCourses();
                    break;
                case "Windows Phone":
                    Courses = WindowsPhoneCourses();
                    break;
            }

            if (Courses != null)
                lastIndex = Courses.Length - 1;
        }

        private Course[] AndroidCourses()
        {
            var initCourses = new Course[]
            {
                new Course()
                {
                    Title = "Android for .NET Developers",
                    Description = "Provides an overview of the tools used in the Android " +
                    "development process including the newly released Android Studio.",
                    Image = "AndroidBadGuy"
                },

                new Course()
                {
                    Title = "Android Dreams, Widgets, Notifications",
                    Description = "Provide users with a rich and interactive experience " +
                    "without ever requiring them to open your app.",
                    Image = "androiddatahero"
                },
                new Course()
                {
                    Title = "Android Photo/Video Programming",
                    Description = "Learn how to capitalize on the Android camera " +
                    "within your apps to capture still photos and video.",
                    Image = "AndroidLnP"
                },
                new Course()
                {
                    Title = "Android Location-Based Apps",
                    Description = "Cover the wide range of Android location capabilities " +
                    "including determining user location, power management, and " +
                    "translating location data to human-readable addresses.",
                    Image = "AndroidSuper"
                }
            };

            return initCourses;
        }
        
        private Course[] IOSCourses()
        {
            var initCourses = new Course[]
            {
                new Course()
                {
                    Title = "IOS for Developers",
                    Description = "Provides an overview of the tools used in the Android " +
                    "development process including the newly released Android Studio.",
                    Image = "AndroidBadGuy"
                },

                new Course()
                {
                    Title = "IOS Dreams, Widgets, Notifications",
                    Description = "Provide users with a rich and interactive experience " +
                    "without ever requiring them to open your app.",
                    Image = "androiddatahero"
                },
                new Course()
                {
                    Title = "IOS Photo/Video Programming",
                    Description = "Learn how to capitalize on the Android camera " +
                    "within your apps to capture still photos and video.",
                    Image = "AndroidLnP"
                },
                new Course()
                {
                    Title = "IOS Location-Based Apps",
                    Description = "Cover the wide range of Android location capabilities " +
                    "including determining user location, power management, and " +
                    "translating location data to human-readable addresses.",
                    Image = "AndroidSuper"
                }
            };

            return initCourses;
        }

        private Course[] WindowsPhoneCourses()
        {
            var initCourses = new Course[]
            {
                new Course()
                {
                    Title = "Windows Phone for Developers",
                    Description = "Provides an overview of the tools used in the Android " +
                    "development process including the newly released Android Studio.",
                    Image = "AndroidBadGuy"
                },

                new Course()
                {
                    Title = "Windows Phone Dreams, Widgets, Notifications",
                    Description = "Provide users with a rich and interactive experience " +
                    "without ever requiring them to open your app.",
                    Image = "androiddatahero"
                },
                new Course()
                {
                    Title = "Windows Phone Photo/Video Programming",
                    Description = "Learn how to capitalize on the Android camera " +
                    "within your apps to capture still photos and video.",
                    Image = "AndroidLnP"
                },
                new Course()
                {
                    Title = "Windows Phone Location-Based Apps",
                    Description = "Cover the wide range of Android location capabilities " +
                    "including determining user location, power management, and " +
                    "translating location data to human-readable addresses.",
                    Image = "AndroidSuper"
                }
            };

            return initCourses;
        }

        public int Length
        {
            get { return Courses.Length; }
        }

        public void MoveFirst()
        {
            currentIndex = 0;
        }

        public void MovePrev()
        {
            if (currentIndex > 0)
                --currentIndex;
        }

        public void MoveTo(int position)
        {
            if (position >= 0 && position <= lastIndex)
                currentIndex = position;
            else
                throw new IndexOutOfRangeException(
                    String.Format("{0} is an invalid position. Must be between 0 and {1}",
                    position, lastIndex));
        }

        public void MoveNext()
        {
            if (currentIndex < lastIndex)
                ++currentIndex;
        }

        public Course Current
        {
            get { return Courses[currentIndex];  }
        }

        public Boolean canMovePrev
        {
            get { return currentIndex > 0; }
        }

        public Boolean canMoveNext
        {
            get { return currentIndex < lastIndex; }
        }
    }
}