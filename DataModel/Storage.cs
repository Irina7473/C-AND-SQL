
namespace DataModel
{
    public class StorageModel
    {
        public int Id { get; set; }
        public string StorageName { get; set; }
        
        public StorageModel(int id, string storageName)
        {
            Id = id;
            StorageName = storageName;
        }
        public StorageModel() { }
    }
}

