namespace IntentServiceDemo
{
    public class SynchronizationInfo
    {

        public SynchronizationInfo(int totalToSync, int synchronized)
        {
            TotalToSync = totalToSync;
            Synchronized = synchronized;

        }

        public SynchronizationInfo(int totalToSync, int synchronized, string element) : this(totalToSync, synchronized)
        {
            ElementName = element;
        }

        public string ElementName { get; private set; }

        public int TotalToSync { get; private set; }

        public int Synchronized { get; private set; }
    }

}
