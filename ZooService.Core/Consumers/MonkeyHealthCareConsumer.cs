// Copyright @Frankie Yu - All Rights Reserved
// Filename: MonkeyHealthCareConsumer.cs
// Created By  :  Frankie
// Created Date:  22/08/2019  20:33
// Last Edit:
//    Author:   Frankie
//    Date:     22/08/2019  20:53

namespace ZooService.Core.Consumers
{
    using System;
    using System.Timers;

    using ZooService.Core.Abstracts;
    using ZooService.Core.Models;

    public class MonkeyHealthCareConsumer : AbstractAnimalHealthCareConsumer
    {
        private readonly Animal animal = new Animal { Id = Guid.NewGuid(), Category = "Monkey" };
        public override Animal Animal { get => base.Animal ?? this.animal; set => base.Animal = value; }
        public override int? ReducedHealth()
        {
            if (!this.Animal.SurvivalSituation)
            {
                return null;
            }

            var reducedHealthNumber = base.ReducedHealth();
            this.Animal.ReducedHealthNumber = reducedHealthNumber.Value;
            this.Animal.CurrentAnimalHealthNumber -= this.Animal.ReducedHealthNumber;
            this.Animal.SurvivalSituation = this.Animal.CurrentAnimalHealthNumber >= ZooServiceConfiguration.MonkeySurvivalHealthNumber;
            return reducedHealthNumber;
        }
    }
}