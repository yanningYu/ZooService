// Copyright @Frankie Yu - All Rights Reserved
// Filename: ElephantHealthCareConsumer.cs
// Created By  :  Frankie
// Created Date:  22/08/2019  20:30
// Last Edit:
//    Author:   Frankie
//    Date:     26/08/2019  09:19

namespace ZooService.Core.Consumers
{
    using System;

    using ZooService.Core.Abstracts;
    using ZooService.Core.Models;

    public class ElephantHealthCareConsumer : AbstractAnimalHealthCareConsumer
    {
        private readonly Animal animal = new Animal { Id= Guid.NewGuid(),  Category = "Elephant" };
        public override Animal Animal { get => base.Animal ?? this.animal; set => base.Animal = value; } 
        public override int? ReducedHealth()
        {
            var reducedHealthNumber = base.ReducedHealth();
            if (this.Animal.CurrentAnimalHealthNumber < 70)
            {
                this.Animal.SurvivalSituation = false;
                return null;
            }

            this.Animal.ReducedHealthNumber = reducedHealthNumber.Value;
            this.Animal.CurrentAnimalHealthNumber -= this.Animal.ReducedHealthNumber;
            return reducedHealthNumber;
        }
    }
}