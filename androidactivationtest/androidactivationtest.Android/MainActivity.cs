using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace androidactivationtest.Droid
{
    [Activity(Label = "androidactivationtest.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.myButton);
            FindViewById<EditText>(Resource.Id.profileId).Text = "11596";
            FindViewById<EditText>(Resource.Id.profilePin).Text = "8638";

            button.Click += delegate
            {
                var profileId = FindViewById<EditText>(Resource.Id.profileId).Text;
                var profilePin = FindViewById<EditText>(Resource.Id.profilePin).Text;
                button.Text = $"{count++} clicks";
                ActivateIpass(profileId, profilePin);
            };
        }


        private void ActivateIpass(String profileId, String pin)
        {
            var provisionIntent = new Intent("android.intent.action.VIEW");
            provisionIntent.SetData(Android.Net.Uri.Parse($"clientx://provision?pid={profileId}&pin={pin}"));
            Application.Context.StartService(provisionIntent);
        }
    }
}


