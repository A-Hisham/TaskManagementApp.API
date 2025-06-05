﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp.Application.DTOs
{
    public class CreateTaskDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline {  get; set; }
        public string? Status { get; set; }
    }

}
