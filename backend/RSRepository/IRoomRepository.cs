﻿using RSData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSRepository
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetRooms();
        Room GetRoomById(int id);
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(Room room);
        void SaveChanges();
    }
}
