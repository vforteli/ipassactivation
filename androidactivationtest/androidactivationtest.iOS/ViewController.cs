using System;

using UIKit;

namespace FlexinetsIpassActivationApp.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            // todo refactor
            ProfileIdText.Text = "1234";
            PinText.Text = "123";

            base.ViewDidLoad();

            CheckIfOpenMobileInstalled();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.TouchUpInside += delegate
            {
                Button.SetTitle($"{count++} clicks!", UIControlState.Normal);
                var url = $"ipass://activate?pid={ProfileIdText.Text}&pin={PinText.Text}";
                UIApplication.SharedApplication.OpenUrl(new Foundation.NSUrl(url));
            };


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        /// <summary>
        /// Checks if ipass:// url scheme is registered.
        /// Basically checks if ipass is installed
        /// </summary>
        private void CheckIfOpenMobileInstalled()
        {
            //var ipassBaseUrl = new Foundation.NSUrl($"ipass://");
            var ipassBaseUrl = new Foundation.NSUrl($"http://www.example.com");
            if (!UIApplication.SharedApplication.CanOpenUrl(ipassBaseUrl))
            {
                Button.SetTitle("iPass not installed", UIControlState.Disabled);
                Button.Enabled = false;
            }
        }
    }
}

