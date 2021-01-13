using System;

namespace Lab3
{
    public class CheckIn
    {
        public readonly int Id;
        public int UserId;
        public int RoomId;
        public bool IsEnter;
        public DateTime Timestamp;

        public CheckIn(int id, int userId, int roomId, bool isEnter, DateTime timestamp)
        {
            Id = id;
            UserId = userId;
            RoomId = roomId;
            IsEnter = isEnter;
            Timestamp = timestamp;
        }
    }
}