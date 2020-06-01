using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntentServiceDemo
{

    public class Synchronizer
    {

        private static int MaxToSync = 27;
        private static Synchronizer _instance;
        private static int Seconds = 2;

        //public Thread Thread { get; set; }

        Guid _id = Guid.Empty;

        public Synchronizer()
        {
            _id = Guid.NewGuid();
        }

        public Guid SynchronizerId
        {
            get
            {
                return _id;
            }
        }

        bool Running { get; set; }

        public override string ToString()
        {
            return _id.ToString();
        }

        public static Synchronizer Instance
        {
            get
            {

                if (_instance == null)
                    _instance = new Synchronizer();

                return _instance;
            }
        }

        public delegate void SyncElementFinished(SynchronizationInfo info, string element);
        public event SyncElementFinished OnSyncElementFinished;
        public delegate void SyncFinished();
        public event SyncFinished OnSyncFinished;


        #region Demo Data

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

        #endregion



        public void Start()
        {
            if (Running)
                return;

            Running = true;

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < MaxToSync; i++)
                {

                    //Simula la sincronziacion contra algun server
                    Thread.Sleep(Seconds * 1000);

                    //Log 
                    System.Diagnostics.Debug.Write($"Synchronising {DataToSync[i]}");

                    //Sincroniza con el thread de la UI
                    OnSyncElementFinished?.Invoke(new SynchronizationInfo(MaxToSync, i + 1), DataToSync[i]);
                }
                
                Running = false;
                OnSyncFinished?.Invoke();

            });
        }

    }

}
