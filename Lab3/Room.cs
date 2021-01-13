using System.Collections.Generic;

namespace Lab3
{
    public class Room
    {
        public readonly int Id;
        public string Name;
        public string Description;
        public float Area;
        public IList<int> placeIds;

        public Room(int id, string name, string description, float area, IList<int> placeIds)
        {
            Id = id;
            Name = name;
            Description = description;
            Area = area;
            this.placeIds = placeIds;
        }
    }
}