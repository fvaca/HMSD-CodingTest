﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMSD.EncryptionService.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMSD.EncryptionService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeyRotatorController : ControllerBase
    {
        private readonly IKeyRotatorService service;
        public KeyRotatorController(IKeyRotatorService rotatorservice)
        {
            service = rotatorservice;
        }
        // GET: api/values
        [HttpGet]
        public string GetKey()
        {
            return service.GetActiveKey();
        }
    }
}
