using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace PrefUcSecSSharEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button myPerSec;
        private Button ucB;
        private Button shareb;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            myPerSec = FindViewById<Button>(Resource.Id.button1);
            ucB = FindViewById<Button>(Resource.Id.button2);
            shareb = FindViewById<Button>(Resource.Id.button3);

            myPerSec.Click += MyPerSec_Click; 
            ucB.Click += UcB_Click;
            shareb.Click += Shareb_Click;
        }

        private void Shareb_Click(object sender, System.EventArgs e)
        {
            Intent k = new Intent(Application.Context, typeof(ShareEx));
            StartActivity(k);
        }

        private void UcB_Click(object sender, System.EventArgs e)
        {
            Intent j = new Intent(Application.Context, typeof(UnitConverterEx));
            StartActivity(j);
        }

        private void MyPerSec_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(Application.Context, typeof(PreferenceandSecureStoEx));
            StartActivity(i);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}