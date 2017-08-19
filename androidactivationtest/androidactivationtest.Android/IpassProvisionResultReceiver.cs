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

namespace androidactivationtest.Droid
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { "client_x.android.prov.result" })]
    public class IpassProvisionResultReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var status = intent.GetIntExtra("EXTRA_RESULT", -1);
            Toast.MakeText(context, $"Power Connected {status}", ToastLength.Long).Show();
        }
    };
}