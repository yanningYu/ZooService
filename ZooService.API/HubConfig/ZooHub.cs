// Copyright @Frankie Yu - All Rights Reserved
// Filename: ZoonHub.cs
// Created By  :  Frankie
// Created Date:  22/08/2019  21:09
// Last Edit:
//    Author:   Frankie
//    Date:     22/08/2019  21:09

namespace ZooService.API.HubConfig
{
    using System;
    using Microsoft.AspNetCore.SignalR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ZooService.Core;
    using ZooService.Core.Abstracts;
    using ZooService.Core.Models;

    public class ZooHub : Hub
    {
        public async Task BroadcastZooData(List<Animal> data)
        {
            AnimalsHealthCareConsumerFactory.UpdateData(data);
            await this.Clients.All.SendAsync("broadcastzoodata", data);
        }
    }
}