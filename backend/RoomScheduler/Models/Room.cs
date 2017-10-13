﻿using System;
using System.Collections.Generic;

namespace RoomScheduler.Models
{
    public partial class Room
    {
        public Room()
        {
            Event = new HashSet<Event>();
            TimeSlot = new HashSet<TimeSlot>();
        }

        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Event> Event { get; set; }
        public ICollection<TimeSlot> TimeSlot { get; set; }
    }
}