using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace IntentServiceDemo
{

    public partial class ProgressBarXamlPage : ContentPage
    {
        float progress = 0f;

        public ProgressBarXamlPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            Debug.Write("OnAppearing");

            //Synchronizer.Instance.OnSyncElementFinished += Synchronizer_OnSyncElementFinished;
            //Synchronizer.Instance.OnSyncFinished += Synchronizer_OnSyncFinished;

            MessagingCenter.Subscribe<object, SynchronizationInfo>(this, "SyncElement", async (s, info) =>
            {
                    string message = $"Synchronized {info.ElementName} - Pending {info.TotalToSync - info.Synchronized}/{info.TotalToSync}";

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        lblElement.Text = message;
                    });

                    var total = (float)info.TotalToSync;
                    var syncdone = (float)info.Synchronized;

                    progress = (float)Math.Round(syncdone / total, 2);

                    await styledProgressBar.ProgressTo(progress, 750, Easing.Linear);
               
            });


            MessagingCenter.Subscribe<object, string>(this, "SyncElementFinished",  (s, msg) =>
            {
                
                Device.BeginInvokeOnMainThread(() =>
                {
                    lblElement.Text = msg;
                });

            });
          

        }

        protected override void OnDisappearing()
        {
            Debug.Write("OnDisappearing");

            //Synchronizer.Instance.OnSyncElementFinished -= Synchronizer_OnSyncElementFinished;
            //Synchronizer.Instance.OnSyncFinished -= Synchronizer_OnSyncFinished;

            MessagingCenter.Unsubscribe<object, SynchronizationInfo>(this, "SyncElement");
            MessagingCenter.Unsubscribe<object, SynchronizationInfo>(this, "SyncElementFinished");

        }

        async void Synchronizer_OnSyncElementFinished(SynchronizationInfo info, string elementName)
        {

            string message = $"Synchronized {elementName} - Pending {info.TotalToSync - info.Synchronized}/{info.TotalToSync}";

            Device.BeginInvokeOnMainThread(() =>
            {
                lblElement.Text = message;
            });

            var total = (float)info.TotalToSync;
            var syncdone = (float)info.Synchronized;

            progress = (float)Math.Round(syncdone / total, 2);

            await styledProgressBar.ProgressTo(progress, 750, Easing.Linear);
        }

        async void Synchronizer_OnSyncFinished()
        {
            Device.BeginInvokeOnMainThread(() =>
           {
               lblElement.Text = "Done !";
           });
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            Synchronizer.Instance.Start();
        }
    }
}