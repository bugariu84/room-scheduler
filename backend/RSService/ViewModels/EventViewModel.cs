﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSService.ViewModels
{
    public class EventViewModel
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string EventType { get; set; }

        public int RoomId { get; set; }

        public string Notes { get; set; }

        public int HostId { get; set; }

        public int AttendeeId { get; set; }

        public int EventStatus { get; set; }

    }
}
