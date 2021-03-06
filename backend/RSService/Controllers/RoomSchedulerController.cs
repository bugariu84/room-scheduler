﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RSData.Models;
using RSRepository;
using RSService.ViewModels;
using System;
using System.Linq;

namespace RSService.Controllers
{
    // [Authorize]
    public class RoomSchedulerController : BaseController
    {
        private IEventRepository eventRepository;
        private IDbOperation dbOperation;
        private IRoomRepository roomRepository;

        public RoomSchedulerController(IEventRepository _eventRepository, IDbOperation _dbOperation, IRoomRepository _roomRepository)
        {
            eventRepository = _eventRepository;
            dbOperation = _dbOperation;
            roomRepository = _roomRepository;

        }
    
        [HttpPost("/event/create")]
        public void AddEvent([FromBody]EventViewModel model)
        {
            var newEvent = Mapper.Map<Event>(model);
            newEvent.DateCreated = DateTime.UtcNow;

            eventRepository.AddEvent(newEvent);
            dbOperation.Commit();
        }
        
        [HttpGet("/event/listall")]
        public IActionResult GetEvents()
        {
            var results = eventRepository.GetEvents();
            if (results == null) return NotFound();

            return Ok(results);
        }

        [HttpGet("/event/list")]
        public IActionResult GetEvents(DateTime startDate, DateTime endDate, int[] roomId, int hostId)
        {
            var results = eventRepository.GetEvents()
                              //.Where(e => e.StartDate >= startDate)        
                              //.Where(e => e.StartDate <= endDate);
                            .Where(e => e.StartDate >= DateTime.Parse("2019-01-01 09:00"))
                            .Where(e => e.StartDate <= DateTime.Parse("2019-12-31 18:00"));

            return Ok(results);
        }

        [HttpPut("/event/edit/{id}")]
        public IActionResult UpdateEvent(int id, [FromBody] EventViewModel model)
        {
            if (ModelState.IsValid)
            {

                var _model = Mapper.Map<Event>(model);

                var _event = eventRepository.GetEvents().FirstOrDefault(c => c.Id == id);
                if (_event == null)
                {
                    return NotFound();
                }

                _event.StartDate = _model.StartDate;
                _event.EndDate = _model.EndDate;
                _event.EventType = _model.EventType;
                _event.RoomId = _model.RoomId;
                _event.Notes = _model.Notes;
                _event.HostId = _model.HostId;
                _event.AttendeeId = _model.AttendeeId;
                _event.EventStatus = _model.EventStatus;
                _event.DateCreated = DateTime.UtcNow;
                dbOperation.Commit();

                return NoContent();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
       
        [HttpGet("/room/list")]
        public IActionResult GetRooms()
        {
            var results = roomRepository.GetRooms();
            if (results == null) return NotFound();

            return Ok(results);
        }

    }
}
