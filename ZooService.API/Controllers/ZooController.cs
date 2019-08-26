// Copyright @Frankie Yu - All Rights Reserved
// Filename: ZooController.cs
// Created By  :  Frankie
// Created Date:  22/08/2019  21:10
// Last Edit:
//    Author:   Frankie
//    Date:     22/08/2019  21:12

namespace ZooService.API.Controllers
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore.Internal;

    using ZooService.API.DataStorage;
    using ZooService.API.HubConfig;
    using ZooService.API.TimerFeatures;

    [Route("api/zoo")]
    [ApiController]
    public class ZooController : ControllerBase
    {
        private IHubContext<ZooHub> hub;

        public ZooController(IHubContext<ZooHub> hub)
        {
            this.hub = hub;
        }

        public IActionResult Get()
        {
            Func<bool> condition = () =>
                {
                    var data = ZooDataManager.GetData();

                    return data.Any(x=>x.SurvivalSituation); };
            var timerManager = new TimerManager(() => this.hub.Clients.All.SendAsync("transferzoodata", ZooDataManager.GetData()),condition);

            return this.Ok(new { Message = "Request Completed" });
        }
    }
}