using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Recipes
{
    [Activity(Label = "Activity4welcome")]
    public class Activity4welcome : Activity
    {
        TextView welcomeMsg;
        String myusername;
        Spinner AWspinner;
        EditText AWedittxt;
        Button AWbtn, signout;
        SearchView AWsrch;
        ListView AWlist;

        string[] myArray = { "Vegetarian", "Non-Vegetarian" };
        List<string> veg = new List<string>();
        List<string> nonveg = new List<string>();
        List<string> filterveg = new List<string>();
        List<string> filternonveg = new List<string>();

        ArrayAdapter ListAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.welcome);
            
            welcomeMsg = FindViewById<TextView>(Resource.Id.WWelcome);
            myusername = Intent.GetStringExtra("name");
            welcomeMsg.Text = "Welcome : " + myusername;
            //=========================================================
    
            veg.Add("Fried Rice");
            veg.Add("Shahi Paneer");
            veg.Add("Veggie Burger");
            nonveg.Add("Egg Fried Rice");
            nonveg.Add("Biryani");
            nonveg.Add("Egg Noodles");


            //--------------------------------------------------------
            AWspinner = FindViewById<Spinner>(Resource.Id.spinner1);
            AWedittxt = FindViewById<EditText>(Resource.Id.addtext);
            AWsrch = FindViewById<SearchView>(Resource.Id.searchView1);
            AWlist = FindViewById<ListView>(Resource.Id.listView1);
            AWbtn = FindViewById<Button>(Resource.Id.button1);
            signout = FindViewById<Button>(Resource.Id.Sout);
            //=========================================================
            AWsrch.QueryTextChange += mySearchFunction;

            AWlist.ItemClick += List_ItemSelected;

            //------------------------------------------------------------
            AWlist.ItemLongClick += List_ItemDelete;
            //------------------------------------------------------------

            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, myArray);
            AWspinner.Adapter = ListAdapter;
            //==================================================
            signout.Click += signoutbtnclicked;

            AWspinner.ItemSelected += spinner_ItemSelected;
            //--------------------------------------------------------
            AWbtn.Click += delegate
            {
                if (AWspinner.SelectedItem.ToString() == "Vegetarian")
                {
                    veg.Add(AWedittxt.Text);
                    AWedittxt.Text = "";
                    ListAdapter.Clear();
                    ListAdapter.AddAll(veg);
                    ListAdapter.NotifyDataSetInvalidated();
                }
                else if (AWspinner.SelectedItem.ToString() == "Non-Vegetarian")
                {
                    nonveg.Add(AWedittxt.Text);
                    AWedittxt.Text = "";
                    ListAdapter.Clear();
                    ListAdapter.AddAll(nonveg);
                    ListAdapter.NotifyDataSetInvalidated();
                }
            };

        }


        public void mySearchFunction(object sender, SearchView.QueryTextChangeEventArgs e)
        {


            var myText = e.NewText;
            System.Console.WriteLine("Search Text  : " + myText);

            if (AWspinner.SelectedItem.ToString() == "Vegetarian")
            {
                filterveg.Clear();
                foreach (string myValue in veg)
                {

                    if (myValue.ToLower().Contains(myText.ToLower()))
                    {
                        filterveg.Add(myValue);
                    }
                }
                ListAdapter.Clear();
                ListAdapter.AddAll(filterveg);
                ListAdapter.NotifyDataSetInvalidated();
            }
            else if (AWspinner.SelectedItem.ToString() == "Non-Vegetarian")
            {
                filternonveg.Clear();
                foreach (string myValue in nonveg)
                {

                    if (myValue.ToLower().Contains(myText.ToLower()))
                    {
                        filternonveg.Add(myValue);
                    }
                }
                ListAdapter.Clear();
                ListAdapter.AddAll(filternonveg);
                ListAdapter.NotifyDataSetInvalidated();
            }

        }

        private void List_ItemDelete(object sender, AdapterView.ItemLongClickEventArgs e)
        {

            ListView listall = (ListView)sender;
            //string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();

            var myValue = (string)listall.GetItemAtPosition(e.Position);
            // var selection = (string)spinner.GetItemAtPosition(e.Position);

            

            if (myValue == "recipe1")
            {
                veg.Remove("recipe1");
                ListAdapter.Clear();
                ListAdapter.AddAll(veg);
                ListAdapter.NotifyDataSetInvalidated();
            }
            else if (myValue == "recipe2")
            {
                veg.Remove("recipe2");
                ListAdapter.Clear();
                ListAdapter.AddAll(veg);
                ListAdapter.NotifyDataSetInvalidated();
            }

        }
        public void signoutbtnclicked(object sender,System.EventArgs e )
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            this.StartActivity(intent);
        }



            private void List_ItemSelected(object sender, AdapterView.ItemClickEventArgs e )
        {

            ListView listall = (ListView)sender;
            //string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();

            var myValue = (string)listall.GetItemAtPosition(e.Position);
            // var selection = (string)spinner.GetItemAtPosition(e.Position);

            //Toast.MakeText(this, "Clicked", ToastLength.Long).Show();

            if (myValue == "Fried Rice")
            {
                //   ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, veg);
                //  AWlist.Adapter = ListAdapter;
               
               
                
                var welcomeScreen = new Intent(this, typeof(Activity4friedrice));
                StartActivity(welcomeScreen);
            }
            else if (myValue == "Shahi Paneer")
            {
               
                var welcomeScreen = new Intent(this, typeof(Activity4shahipaneer));
                StartActivity(welcomeScreen);


            }
            else if (myValue == "Veggie Burger")
            {

                var welcomeScreen = new Intent(this, typeof(Activity4veggieburger));
                StartActivity(welcomeScreen);


            }
            else if (myValue == "Egg Fried Rice")
            {

                var welcomeScreen = new Intent(this, typeof(Activity4eggfriedrice));
                StartActivity(welcomeScreen);


            }
            else if (myValue == "Biryani")
            {

                var welcomeScreen = new Intent(this, typeof(Activity4biryani));
                StartActivity(welcomeScreen);


            }
            else if (myValue == "Egg Noodles")
            {

                var welcomeScreen = new Intent(this, typeof(Activity4eggnoodles));
                StartActivity(welcomeScreen);


            }
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            //string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();

            var myValue = (string)spinner.GetItemAtPosition(e.Position);
            // var selection = (string)spinner.GetItemAtPosition(e.Position);

           

            if (myValue == "Vegetarian")
            {
                ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, veg);
                AWlist.Adapter = ListAdapter;
                
            }
            else if (myValue == "Non-Vegetarian")
            {
                ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,nonveg );


                AWlist.Adapter = ListAdapter;

            }
        }
      


    }



}