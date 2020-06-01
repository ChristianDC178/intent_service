using Android.App;
using Android.Content;
using Xamarin.Forms;

namespace IntentServiceDemo.Droid
{

    [Service]
    public class BackgroundService : IntentService
    {
        int Seconds = 2;
        int MaxToSync = 27;

        private string[] DataToSync = new string[]
     {
            "Homero",
            "Lisa",
            "Marge",
            "Bart",
            "Maggie",
            "Burns",
            "Smithers",
            "Barnie",
            "Krusty",
            "Carl",
            "Grandpa",
            "Homero",
            "Lisa",
            "Marge",
            "Bart",
            "Maggie",
            "Burns",
            "Smithers",
            "Barnie",
            "Krusty",
            "Carl",
            "Grandpa",
            "Homero",
            "Lisa",
            "Marge",
            "Bart",
            "Maggie",
            "Burns",
            "Smithers",
            "Barnie",
            "Krusty",
            "Carl",
            "Grandpa",
            "Homero",
            "Lisa",
            "Marge",
            "Bart",
            "Maggie",
            "Burns",
            "Smithers",
            "Barnie",
            "Krusty",
            "Carl",
            "Grandpa",
            "Homero",
            "Lisa",
            "Marge",
            "Bart",
            "Maggie",
            "Burns",
            "Smithers",
            "Barnie",
            "Krusty",
            "Carl",
            "Grandpa",
            "Homero",
            "Lisa",
            "Marge",
            "Bart",
            "Maggie",
            "Burns",
            "Smithers",
            "Barnie",
            "Krusty",
            "Carl",
            "Grandpa",
            "Homero",
            "Lisa",
            "Marge",
            "Bart",
            "Maggie",
            "Burns",
            "Smithers",
            "Barnie",
            "Krusty",
            "Carl",
            "Grandpa",
     };

        protected override void OnHandleIntent(Intent intent)
        {
            for (int i = 0; i < MaxToSync; i++)
            {

                //Simulates long pool synchronization
                System.Threading.Thread.Sleep(Seconds * 1000);

                //Log 
                System.Diagnostics.Debug.Write($"Synchronising {DataToSync[i]}");

                MessagingCenter.Send<object, SynchronizationInfo>(this, "SyncElement", new SynchronizationInfo(MaxToSync, i + 1, DataToSync[i]));

            }
           
            //StopForeground(StopForegroundFlags.Remove);

            MessagingCenter.Send<object, string>(this, "SyncElementFinished", "Done !");
        }


    }

}