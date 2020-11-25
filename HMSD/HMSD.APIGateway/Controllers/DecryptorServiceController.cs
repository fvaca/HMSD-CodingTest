﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HMSD.APIGateway.Model;
using HMSD.APIGateway.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMSD.APIGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecryptorServiceController : ControllerBase
    {
       
        private readonly EncryptionServiceConfig config;
        private readonly IEndpointCallerService service;

        public DecryptorServiceController(IOptionsMonitor<EncryptionServiceConfig> optionsMonitor, IEndpointCallerService endpointcaller)
        {
            config = optionsMonitor.CurrentValue;
            service = endpointcaller;
        }
        
        [HttpGet]
        public string Decrypt(string secret)
        {
            
            var activekey = service.CallServiceEnpoint(config.BaseUrl, config.KeyRotator);
            string result = service.CallServiceEnpoint(config.BaseUrl, config.DecryptorEndpoint, $"?secret={secret}&activekey={Uri.EscapeDataString(activekey)}");
            return result;
        }
    }
}
