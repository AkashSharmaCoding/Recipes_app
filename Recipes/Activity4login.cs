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
    [Activity(Label = "Activity4login")]
    public class Activity4login : Activity
    {
        EditText ALusername, ALpassword;
        Button ALlogin; Realm ALrealm;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);

            ALrealm = Realm.GetInstance();

            ALusername = FindViewById<EditText>(Resource.Id.LGusername);
            ALpassword = FindViewById<EditText>(Resource.Id.LGpassword);
            ALlogin = FindViewById<Button>(Resource.Id.LGsigninbtn);


            ALlogin.Click += delegate
            {
                var myinfo = ALrealm.All<usermodel>().Where(d => d.UMuname == ALusername.Text && d.UMpass == ALpassword.Text);
                if(ALusername.Text != "" )
                {
                    if(ALpassword.Text != "")
                    {
                        if(myinfo.Count()>=1)
                        {
                            var welcomeScr = new Intent(this, typeof(Activity4ClientWelcome));
                            welcomeScr.PutExtra("username", ALusername.Text);
                            //welcomeScr.PutExtra("password", ALpassword.Text);
                           
                            StartActivity(welcomeScr);
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            };




        }
    }
}