using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace PrefUcSecSSharEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class PreferenceandSecureStoEx : Activity
    {
        private Button prefButton;
        private Button secureStoButton;
        private Button saveSettingsButton;
        private Button getDataB;
        private Button removeDataB;
        private Button removeAllDataB;
        private Button saveSettingsSSButton;
        private Button getDataSSB;
        private Button removeDataSSB;
        private Button removeAllDataSSB;
        private EditText myedT;
        private Switch mySwitch;
        private SeekBar myVolume;
        private TextView myView;
        public const string Name = "name";
        public const string StreamSelection = "streamselection";
        public const string Volume = "volume";

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.perfandSecuStoDemo);
            UIReference();
            UIClickEvents();
        }

        private void UIClickEvents()
        {
            prefButton.Click += PrefButton_Click;
            secureStoButton.Click += SecureStoButton_Click;
        }

        private void SecureStoButton_Click(object sender, EventArgs e)
        {
            SecureStorageDemo();
          
        }

        private void SecureStorageDemo()
        {
            myedT.Visibility = ViewStates.Visible;
            mySwitch.Visibility = ViewStates.Visible;
            myVolume.Visibility = ViewStates.Visible;
            myView.Visibility = ViewStates.Visible;

            saveSettingsSSButton.Visibility = ViewStates.Visible;
            getDataSSB.Visibility = ViewStates.Visible;
            removeDataSSB.Visibility = ViewStates.Visible;
            removeAllDataSSB.Visibility = ViewStates.Visible;

            saveSettingsButton.Visibility = ViewStates.Invisible;
            getDataB.Visibility = ViewStates.Invisible;
            removeAllDataB.Visibility = ViewStates.Invisible;
            removeDataB.Visibility = ViewStates.Invisible;

            saveSettingsSSButton.Click += SaveSettingsSSButton_Click;
            getDataSSB.Click += GetDataSSB_Click;
            removeDataSSB.Click += RemoveDataSSB_Click;
            removeAllDataSSB.Click += RemoveAllDataSSB_Click;



        }

        private void RemoveAllDataSSB_Click(object sender, EventArgs e)
        {

            SecureStorage.RemoveAll();
          
        }

        private void RemoveDataSSB_Click(object sender, EventArgs e)
        {
            SecureStorage.Remove(Name);
            SecureStorage.Remove(StreamSelection);
            SecureStorage.Remove(Volume);
       
        }

        private async void GetDataSSB_Click(object sender, EventArgs e)
        {
            myedT.Text = await SecureStorage.GetAsync(Name);

            
            mySwitch.Checked = bool.Parse(await SecureStorage.GetAsync(StreamSelection));
           
       
            int vol = int.Parse(await SecureStorage.GetAsync(Volume));
            myVolume.SetProgress(vol,true);
          


        }

        private void SaveSettingsSSButton_Click(object sender, EventArgs e)
        {
            string userName = myedT.Text;
            bool shouldStremOnWifi = mySwitch.Checked;
            int volume = myVolume.Progress;
            SecureStorage.SetAsync(Name, userName);
            SecureStorage.SetAsync(StreamSelection,shouldStremOnWifi.ToString());
            SecureStorage.SetAsync(Volume, volume.ToString());

            userName = string.Empty;
            shouldStremOnWifi = false;
            volume = 0;
           



        }

        private void PrefButton_Click(object sender, EventArgs e)
        {
            PreferenceDemo();
        }

        private void PreferenceDemo()
        {
            myedT.Visibility = ViewStates.Visible;
            mySwitch.Visibility = ViewStates.Visible;
            myVolume.Visibility = ViewStates.Visible;
            myView.Visibility = ViewStates.Visible;
            saveSettingsButton.Visibility = ViewStates.Visible;
            getDataB.Visibility = ViewStates.Visible;
            removeAllDataB.Visibility = ViewStates.Visible;
            removeDataB.Visibility = ViewStates.Visible;
            saveSettingsSSButton.Visibility = ViewStates.Invisible;
            getDataSSB.Visibility = ViewStates.Invisible;
            removeDataSSB.Visibility = ViewStates.Invisible;
            removeAllDataSSB.Visibility = ViewStates.Invisible;
            saveSettingsButton.Click += SaveSettingsButton_Click;
            getDataB.Click += GetDataB_Click;
            removeDataB.Click += RemoveDataB_Click;
            removeAllDataB.Click += RemoveAllDataB_Click;
        }

        private void RemoveAllDataB_Click(object sender, EventArgs e)
        {
            Preferences.Clear();
           
        }

        private void RemoveDataB_Click(object sender, EventArgs e)
        {
            Preferences.Remove(Name);
            Preferences.Remove(StreamSelection);
            Preferences.Remove(Volume);
          
        }

        private void GetDataB_Click(object sender, EventArgs e)
        {
            if (Preferences.ContainsKey(Name))
            {
                myedT.Text = Preferences.Get(Name, string.Empty);
            
            }
            if (Preferences.ContainsKey(StreamSelection))
            {
                mySwitch.Checked = Preferences.Get(StreamSelection, false);
            
            }

            int volume = Preferences.Get(Volume, 0);
            myVolume.SetProgress(volume, true);
           
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            string userName = myedT.Text;
            bool shouldStremOnWifi = mySwitch.Checked;
            int volume = myVolume.Progress;

            Preferences.Set(Name, userName);
            Preferences.Set(StreamSelection, shouldStremOnWifi);
            Preferences.Set(Volume, volume);
           

            
        }

        private void UIReference()
        {
            prefButton = FindViewById<Button>(Resource.Id.buttonPS);
            secureStoButton = FindViewById<Button>(Resource.Id.buttonSS);
            saveSettingsButton = FindViewById<Button>(Resource.Id.buttonPS1);
            getDataB = FindViewById<Button>(Resource.Id.buttonPS2);
            removeDataB = FindViewById<Button>(Resource.Id.buttonPS3);
            removeAllDataB = FindViewById<Button>(Resource.Id.buttonPS4);
            saveSettingsSSButton = FindViewById<Button>(Resource.Id.buttonSS1);
            getDataSSB = FindViewById<Button>(Resource.Id.buttonSS2);
            removeDataSSB = FindViewById<Button>(Resource.Id.buttonSS3);
            removeAllDataSSB = FindViewById<Button>(Resource.Id.buttonSS4);
            myedT = FindViewById<EditText>(Resource.Id.editTextPS);
            mySwitch = FindViewById<Switch>(Resource.Id.switchPS);
            myVolume = FindViewById<SeekBar>(Resource.Id.seekBarPS);
            myView = FindViewById<TextView>(Resource.Id.textViewPS);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}