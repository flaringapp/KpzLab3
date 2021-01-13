using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public static class Program
    {
        private static List<User> users = new List<User>
        {
            new User(1, "Bob", "Anderson", "bobanderson@gmail.com",
                new DateTime(2000, 10, 10), "I am a cool person", null),
            new User(2, "Andreas", "Pupkin", "apupkin@gmail.com",
                new DateTime(1989, 8, 21), "I am a cool person", 1),
            new User(3, "Nicola", "Tesla", "nictesla@gmail.com",
                new DateTime(1991, 2, 15), "I am a cool person", 2),
            new User(4, "Dany", "Boy", "boydany@gmail.com",
                new DateTime(1995, 5, 27), "I am a cool person", null),
            new User(5, "Lera", "Chrona", "chronolera@gmail.com",
                new DateTime(2001, 10, 2), "I am a cool person", 3),
            new User(6, "Alex", "Tray", "alextray@gmail.com",
                new DateTime(1983, 8, 9), "I am a cool person", 4),
            new User(7, "Mon", "Danson", "danson@gmail.com",
                new DateTime(1970, 2, 22), "I am a cool person", null),
            new User(8, "Sonda", "Lex", "lexsonda@gmail.com",
                new DateTime(2005, 6, 19), "I am a cool person", 5),
            new User(9, "Lia", "Miandra", "liamiandra@gmail.com",
                new DateTime(1992, 1, 6), "I am a cool person", null),
            new User(10, "Keya", "Kyoto", "keya.kyoto@gmail.com",
                new DateTime(1991, 2, 17), "I am a cool person", 6),
        };

        private static List<Place> places = new List<Place>
        {
            new Place(1, "Place 1", "Description", 2f, 100f),
            new Place(2, "Place 2", "Description", 2f, 90f),
            new Place(3, "Place 3", "Description", 2f, 100f),
            new Place(4, "Place 4", "Description", 2f, 100f),
            new Place(5, "Place 5", "Description", 2f, 80f),
            new Place(6, "Place 6", "Description", 2f, 90f),
            new Place(7, "Place 7", "Description", 2f, 100f),
            new Place(8, "Place 8", "Description", 2f, 110f)
        };

        private static List<Room> rooms = new List<Room>
        {
            new Room(1, "Room 1", "Description", 50f, new List<int> { 1, 2 }),
            new Room(2, "Room 2", "Description", 70f, new List<int> { 3, 4, 5 }),
            new Room(3, "Room 3", "Description", 40f, new List<int> { 6, 7, 8 })
        };

        public static List<CheckIn> checkIns = new List<CheckIn>
        {
            new CheckIn(1, 1, 1, true, DateTime.Now),
            new CheckIn(2, 1, 2, true, DateTime.Now),
            new CheckIn(3, 1, 2, false, DateTime.Now),
            new CheckIn(4, 1, 1, false, DateTime.Now),
            new CheckIn(5, 2, 1, true, DateTime.Now),
            new CheckIn(6, 2, 2, true, DateTime.Now),
            new CheckIn(7, 2, 2, false, DateTime.Now),
            new CheckIn(8, 2, 2, true, DateTime.Now),
            new CheckIn(9, 2, 2, false, DateTime.Now),
            new CheckIn(10, 2, 1, false, DateTime.Now),
            new CheckIn(11, 3, 1, true, DateTime.Now)
        };

        public static void Main(string[] args)
        {
            Query1();
            Console.WriteLine();
            Query2();
            Console.WriteLine();
            Query3();
            Console.WriteLine();
            Query4();
            Console.WriteLine();
            Query5();
            Console.WriteLine();
            Query6();
            Console.WriteLine();
            Query7();
            Console.WriteLine();
            Query8();
            Console.WriteLine();
            Query9();
            Console.WriteLine();
            Query10();
        }

        private static void Query1()
        {
            var query = users.FindAll(user => user.RentPlaceId != null)
                .Join(places,
                    user => user.RentPlaceId,
                    place => place.Id,
                    (user, place) => new
                    {
                        UserId = user.Id,
                        UserName = user.FirstName,
                        PlaceName = place.Name,
                        PlacePrice = place.Price
                    });

            foreach (var obj in query)
            {
                Console.WriteLine(
                    $"{obj.UserId} - {obj.UserName} - {obj.PlaceName} - {obj.PlacePrice}");
            }
        }

        private static void Query2()
        {
            var usersWithPlacesCount = users.Count(user => user.RentPlaceId != null);
            Console.WriteLine($"Users who rent a place: {usersWithPlacesCount}");
        }

        private static void Query3()
        {
            var room1 = rooms.Find(room => room.Id == 1);
            var room1UserByMaxAge = users.Where(user =>
                    user.RentPlaceId != null && room1.placeIds.Contains((int) user.RentPlaceId))
                .FindUserByMaxAge();

            Console.WriteLine($"User in room 1 with max age: {room1UserByMaxAge.Id} - {room1UserByMaxAge.FirstName}");
        }

        private static void Query4()
        {
            var usersWithoutRent = users.Where(user => user.RentPlaceId == null);
            var usersOlderThan20 = users.Where(user => user.Age > 20);
            var both = usersWithoutRent.Union(usersOlderThan20);
            Console.WriteLine("Users order than 20 and without rent place:");
            foreach (var user in both)
            {
                Console.WriteLine($"{user.Id} - {user.FirstName} - {user.Age}");
            }
        }

        private static void Query5()
        {
            var maxIncome = places.Sum(place => place.Price);
            Console.WriteLine($"Max potential income - {maxIncome}");
        }

        private static void Query6()
        {
            var actualIncome = users.Select(user => user.RentPlaceId)
                .Where(placeId => placeId != null)
                .Select(placeId => places.Find(place => place.Id == placeId))
                .Sum(place => place?.Price ?? 0);
            Console.WriteLine($"Current income - {actualIncome}");
        }

        private static void Query7()
        {
            var usersByYearBirth = users.GroupBy(user => user.DateOfBirth.Year);
            Console.WriteLine($"Users by year of birth");
            foreach (var grouping in usersByYearBirth)
            {
                Console.Write($"{grouping.Key} -");
                foreach (var user in grouping.ToList())
                {
                    Console.Write($" {user.Id} {user.FirstName},");
                }
                Console.WriteLine();
            }
        }

        private static void Query8()
        {
            var something = users
                .Skip(2)
                .Take(5)
                .Select(user => new {user.FirstName, user.LastName});

            foreach (var user in something)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }

        private static void Query9()
        {
            var orderedUsersByNameWhoRentAPlace = users.Where(user => user.RentPlaceId != null)
                .OrderBy(user => user.FirstName)
                .ThenBy(user => user.LastName);

            foreach (var user in orderedUsersByNameWhoRentAPlace)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }

        private static void Query10()
        {
            var biggestRoom = rooms.MaxBy(room => room.Area);
            Console.WriteLine($"Biggest room: {biggestRoom.Id} {biggestRoom.Area}m^2");
        }

        private static User FindUserByMaxAge(this IEnumerable<User> source)
        {
            return source.MaxBy(user => user.Age);
        }
    }
}