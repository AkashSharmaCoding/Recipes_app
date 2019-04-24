using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Recipes
{
    [Activity(Label = "Recipes", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button MAlogin, MAsignup, MAadminlogin, MAfrag;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            MAlogin = FindViewById<Button>(Resource.Id.Mlogin);
            MAsignup = FindViewById<Button>(Resource.Id.Msignup);
            MAadminlogin = FindViewById<Button>(Resource.Id.MAdminlogin);
            MAfrag = FindViewById<Button>(Resource.Id.Mfrag);

            MAsignup.Click += signupclicked;
            //---------------------------------
            MAlogin.Click += loginclicked;
            //---------------------------------
            MAadminlogin.Click += Adminloginclicked;
            //---------------------------------
            MAfrag.Click += Fragclicked;
        }

        private void signupclicked(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity4signup));
            this.StartActivity(intent);
        }
        private void loginclicked(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity4login));
            this.StartActivity(intent);
        }
        private void Adminloginclicked(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity4Admin));
            this.StartActivity(intent);
        }
        private void Fragclicked(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity4fragments));
            this.StartActivity(intent);
        }
    }
}

