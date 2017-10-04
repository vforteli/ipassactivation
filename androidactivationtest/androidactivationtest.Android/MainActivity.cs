using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Util;

namespace FlexinetsIpassActivationApp.Droid
{
    [Activity(Label = "iPassActivationApp.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //private IpassProvisionResultReceiver _receiver;
        // todo handle broadcast in activity and write result in app log somewhere
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //_receiver = new IpassProvisionResultReceiver();

            SetContentView(Resource.Layout.Main);

            var foo = CheckIpassInstalled();
            Log.Debug("IpassActivation", foo.ToString());
            // todo disable controls if ipass not installed

            var button = FindViewById<Button>(Resource.Id.myButton);
            FindViewById<EditText>(Resource.Id.profileId).Text = "28894";
            FindViewById<EditText>(Resource.Id.profilePin).Text = "8907";

            button.Click += delegate
            {
                var profileId = FindViewById<EditText>(Resource.Id.profileId).Text;
                var profilePin = FindViewById<EditText>(Resource.Id.profilePin).Text;
                button.Text = GetString(Resource.String.activation_started_button);

                if (ProfileIdIsValid() && ProfilePinIsValid())
                {
                    Log.Debug("IpassActivation", "Profile Id and Pin are valid, starting activation");
                    ActivateIpass(profileId, profilePin);
                }
            };
        }


        private void ActivateIpass(String profileId, String pin)
        {
            var uri = Android.Net.Uri.Parse($"clientx://provision?pid={profileId}&pin={pin}");
            var provisionIntent = new Intent("android.intent.action.VIEW");
            provisionIntent.SetData(uri);
            Application.Context.StartService(provisionIntent);
            Log.Debug("IpassActivation", $"Activation started with uri {uri}");
        }


        private Boolean CheckIpassInstalled()
        {
            Log.Debug("IpassActivation", "Checking if iPass app is installed");
            var ipassAppName = "com.iPass.OpenMobile";

            try
            {
                PackageManager.GetApplicationInfo(ipassAppName, 0);
                Log.Debug("IpassActivation", "iPass app is installed");
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }


        // todo refactor...
        private Boolean ProfileIdIsValid()
        {
            var profileIdView = FindViewById<EditText>(Resource.Id.profileId);
            var profileIdLayout = FindViewById<TextInputLayout>(Resource.Id.profile_id_layout);
            if (string.IsNullOrWhiteSpace(profileIdView.Text))
            {
                profileIdLayout.ErrorEnabled = true;
                profileIdLayout.Error = "Profile id required...";   // todo change to string resource
                return false;
            }
            else
            {
                profileIdLayout.ErrorEnabled = false;
                return true;
            }
        }

        private Boolean ProfilePinIsValid()
        {
            var editText = FindViewById<EditText>(Resource.Id.profilePin);
            var layout = FindViewById<TextInputLayout>(Resource.Id.profile_pin_layout);
            if (string.IsNullOrWhiteSpace(editText.Text))
            {
                layout.ErrorEnabled = true;
                layout.Error = "Profile id required...";   // todo change to string resource
                return false;
            }
            else
            {
                layout.ErrorEnabled = false;
                return true;
            }
        }
    }
}
