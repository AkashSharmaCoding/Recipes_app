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
    [Activity(Label = "Activity4signup")]
    public class Activity4signup : Activity
    {
        EditText SAuname, SAemail, SApassword;
        Button SAsignup;
        Realm myRealm;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Signup);
            myRealm = Realm.GetInstance();

            SAuname = FindViewById<EditText>(Resource.Id.SUusername);
            SAemail = FindViewById<EditText>(Resource.Id.SUemail);
            SApassword = FindViewById<EditText>(Resource.Id.SUpassword);
            SAsignup = FindViewById<Button>(Resource.Id.SUsignup);

            SAsignup.Click += delegate
            {
                if(SAuname.Text != "")
                {
                    if(SAemail.Text != "")
                    {
                        if(SApassword.Text != "")
                        {

                            var usermodel = new usermodel();
                            usermodel.UMuname = SAuname.Text;
                            usermodel.UMemail = SAemail.Text;
                            usermodel.UMpass = SApassword.Text;

                            myRealm.Write(() =>
                            {
                                myRealm.Add(usermodel);
                            });

                            var gotologin = new Intent(this, typeof(Activity4login));
                            StartActivity(gotologin);
                        }
                        else
                        {
                            Toast.MakeText(ApplicationContext, "Password field required", ToastLength.Long).Show();
                        }
                    }
                    else
                    {
                        Toast.MakeText(ApplicationContext, "Email field required", ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(ApplicationContext, "Username field required", ToastLength.Long).Show();
                }


            };
        }
    }
}