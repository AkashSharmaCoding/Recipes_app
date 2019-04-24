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
using Realms;

namespace Recipes
{
    class usermodel : RealmObject
    {
        public string UMuname { get; set; }
        public string UMemail { get; set; }
        public string UMpass { get; set; }

    }
}