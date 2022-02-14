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
    public class UnitConverterEx : Activity
    {
        private Button calcB;
        private EditText numbET;
        private TextView textfareneittoCelsius;
        private TextView textkmtoMiles;
        private TextView textdegtoradians;
        private TextView textkgtopounds;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.unitConvertorDemo);
            calcB = FindViewById<Button>(Resource.Id.buttonUC);
            numbET = FindViewById<EditText>(Resource.Id.editTextUC);
            textfareneittoCelsius = FindViewById<TextView>(Resource.Id.textViewUC1);
            textkmtoMiles = FindViewById<TextView>(Resource.Id.textViewUC2);
            textdegtoradians = FindViewById<TextView>(Resource.Id.textViewUC3);
            textkgtopounds = FindViewById<TextView>(Resource.Id.textViewUC4);

            calcB.Click += CalcB_Click;
        }

        private void CalcB_Click(object sender, EventArgs e)
        {
            int userinput = Convert.ToInt32(numbET.Text);
            textfareneittoCelsius.Text = $"Fahrenheit To Celsius {UnitConverters.FahrenheitToCelsius(userinput)}";
            textkmtoMiles.Text = $"Kilometers To Miles {UnitConverters.KilometersToMiles(userinput)}";
            textdegtoradians.Text = $"Degrees To Radians {UnitConverters.DegreesToRadians(userinput)}";
            textkgtopounds.Text = $"Kilograms To Pounds {UnitConverters.KilogramsToPounds(userinput)}";
        }
    }
}