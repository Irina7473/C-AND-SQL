
namespace DataModel
{
    public class SpaceStorageModel
    {
        public int Id { get; set; }
        public int IdExhibits { get; set; }
        public int IdStorage { get; set; }
        public bool SpecialConditions { get; set; }

        public SpaceStorageModel(int id, int idExhibits, int idStorage, bool specialConditions)
        {
            Id = id;
            IdExhibits = idExhibits;
            IdStorage = idStorage;
            SpecialConditions = specialConditions;
        }
        public SpaceStorageModel() { }
    }
}
