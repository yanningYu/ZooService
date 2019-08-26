// Copyright @Frankie Yu - All Rights Reserved
// Filename: MonkeyHealthCareConsumer.cs
// Created By  :  Frankie
// Created Date:  22/08/2019  20:33
// Last Edit:
//    Author:   Frankie
//    Date:     22/08/2019  20:53

namespace ZooService.Core.Consumers
{
    using System.Timers;

    using ZooService.Core.Abstracts;
    using ZooService.Core.Models;

    public class MonkeyHealthCareConsumer : AbstractAnimalHealthCareConsumer
    {
        private readonly Animal animal = new Animal { Category = "Monkey" };
        public override Animal Animal => this.animal;
        public override int? ReducedHealth()
        {
            if (!this.Animal.SurvivalSituation)
            {
                return null;
            }

            var reducedHealthNumber = base.ReducedHealth();
            this.Animal.ReducedHealthNumber = reducedHealthNumber.Value;
            this.Animal.CurrentAnimalHealthNumber -= this.Animal.ReducedHealthNumber;
            this.Animal.SurvivalSituation = this.Animal.CurrentAnimalHealthNumber >= 30;
            return reducedHealthNumber;
        }
    }
}