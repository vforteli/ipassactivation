using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FlexinetsIpassActivationApp.Droid
{
    [Activity(Label = "iPassActivationApp.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //private IpassProvisionResultReceiver _receiver;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //_receiver = new IpassProvisionResultReceiver();

            SetContentView(Resource.Layout.Main);

            var button = FindViewById<Button>(Resource.Id.myButton);
            FindViewById<EditText>(Resource.Id.profileId).Text = "11596";
            FindViewById<EditText>(Resource.Id.profilePin).Text = "8638";

            button.Click += delegate
            {
                var profileId = FindViewById<EditText>(Resource.Id.profileId).Text;
                var profilePin = FindViewById<EditText>(Resource.Id.profilePin).Text;
                button.Text = GetString(Resource.String.activation_started_button);
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
