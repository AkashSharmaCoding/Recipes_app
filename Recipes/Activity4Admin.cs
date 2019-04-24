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
    [Activity(Label = "Activity4Admin")]
    public class Activity4Admin : Activity
    {
        EditText AAusername, AApassword;
        Button AAlogin; Realm myRealms;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Adminlogin);

            myRealms = Realm.GetInstance();
            AAusername = FindViewById<EditText>(Resource.Id.ALusername);
            AApassword = FindViewById<EditText>(Resource.Id.ALpassword);
            AAlogin = FindViewById<Button>(Resource.Id.ALsigninbtn);

            usermodel u1 = new usermodel();
            u1.UMuname = "Admin";
            u1.UMemail = "akash@gmail.com";
            u1.UMpass = "12345";

            myRealms.Write(() =>
            {
                myRealms.Add(u1);
            });

            AAlogin.Click += delegate
            {
                var userDetail = myRealms.All<usermodel>().Where(u => u.UMuname == AAusername.Text && u.UMpass == AApassword.Text);


                if (AAusername.Text != "" && AApassword.Text != "")
                {

                    if (userDetail.Count() >= 1)
                    {
                        usermodel user = userDetail.ElementAt(0);

                       
                        //warning_txt.Visibility = Android.Views.ViewStates.Gone;
                        var welcomeScreen = new Intent(this, typeof(Activity4welcome));
                        welcomeScreen.PutExtra("name", user.UMuname);
                        StartActivity(welcomeScreen);
                    }
                    else
                    {
                        Toast.MakeText(ApplicationContext, "Error", ToastLength.Long).Show();
                        //warning_txt.Visibility = Android.Views.ViewStates.Visible;
                        //warning_txt.Text = "Invalid Username and Password";
                    }
                }
                else
                {
                    Toast.MakeText(ApplicationContext, "field required", ToastLength.Long).Show();
                    //warning_txt.Visibility = Android.Views.ViewStates.Visible;
                    //warning_txt.Text = "Please fill the  Username and Password first";
                }
            };


        }

        

    }
}