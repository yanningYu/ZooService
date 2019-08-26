// Copyright @Frankie Yu - All Rights Reserved
// Filename: ZooDataManager.cs
// Created By  :  Frankie
// Created Date:  22/08/2019  21:03
// Last Edit:
//    Author:   Frankie
//    Date:     22/08/2019  21:07

namespace ZooService.API.DataStorage
{
    using System;
    using System.Collections.Generic;

    using ZooService.Core;
    using ZooService.Core.Abstracts;
    using ZooService.Core.Models;

    public class ZooDataManager
    {
        public static List<Animal> GetData()
        {
            var tempList = new List<Animal>();
            tempList.AddRange(AnimalsHealthCareConsumerFactory.Data);
            return tempList;
        }
    }
}