using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace PrefUcSecSSharEx
{
    [Activity(Label = "ShareEx")]
    public class ShareEx : Activity
    {
        private Button myshareText;
        private Button myshareLink;
        private Button myShareAttachment;
        private Button myShareMultiAttach;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.shareDemo);

            myshareText = FindViewById<Button>(Resource.Id.buttonS1);
            myshareLink= FindViewById<Button>(Resource.Id.buttonS2);
            myShareAttachment = FindViewById<Button>(Resource.Id.buttonS3);
           myShareMultiAttach = FindViewById<Button>(Resource.Id.buttonS4);

            myshareText.Click += MyshareText_Click;
            myshareLink.Click += MyshareLink_Click;
            myShareAttachment.Click += MyShareAttachment_Click;
            myShareMultiAttach.Click += MyShareMultiAttach_Click;
        }

        private async void MyShareMultiAttach_Click(object sender, EventArgs e)
        {
            
            var file1 = Path.Combine(FileSystem.CacheDirectory, "Shin1.txt");
            File.WriteAllText(file1, "I am Shinchain ");

            var file2 = Path.Combine(FileSystem.CacheDirectory, "Shin2.txt");
            File.WriteAllText(file2, "I live in Kasukabe");

            await Share.RequestAsync(new ShareMultipleFilesRequest
            {
                Title = Title,
                Files = new List<ShareFile> {new ShareFile(file1), new ShareFile(file2) }
            });
        }

        private async void MyShareAttachment_Click(object sender, EventArgs e)
        {
            var fn = "Shin.txt";
            var file = Path.Combine(FileSystem.CacheDirectory, fn);
            File.WriteAllText(file, "I am Shinchain and I am 5 years old");

            await Share.RequestAsync(new ShareFileRequest
            {
                Title =Title,
                File = new ShareFile(file)
            });
        }

        private async void MyshareLink_Click(object sender, EventArgs e)
        {
            string uri = "https://github.com/";
            await Share.RequestAsync(new ShareTextRequest

            {
                Uri = uri,
                Title = "Share Web Link"
            
            });
        }

        private async void MyshareText_Click(object sender, EventArgs e)
        {
            string text = "Hello W0rld";
            await Share.RequestAsync(new ShareTextRequest
            { 
                Text = text,
                Title = "Share Text"
            
            
            });

                
        }
    }
}