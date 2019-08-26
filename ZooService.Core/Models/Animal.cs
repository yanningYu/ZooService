// Copyright @Frankie Yu - All Rights Reserved
// Filename: Animal.cs
// Created By  :  Frankie
// Created Date:  26/08/2019  09:19
// Last Edit:
//    Author:   Frankie
//    Date:     26/08/2019  10:15

namespace ZooService.Core.Models
{
    using System;

    public class Animal
    {
        public Guid Id { get; set; }

        public string Category { get; set; }

        public double CurrentAnimalHealthNumber { get; set; } = ZooServiceConfiguration.InitialHealthNumber;

        public int ReducedHealthNumber { get; set; }

        public bool SurvivalSituation { get; set; } = true;
    }
}