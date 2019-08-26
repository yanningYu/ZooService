using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooService.Core.Abstracts
{
    using System.Timers;

    using ZooService.Core.Models;

    public abstract class AbstractAnimalHealthCareConsumer
    {
        
        /// <summary>
        /// Gets the animal.
        /// </summary>
        public virtual Animal Animal { get; set; }

        public virtual int? ReducedHealth()
        {
            var random = new Random();
            var reducedNumber   = random.Next(0, 20);
            return reducedNumber;
        }


      
        /// <summary>
        /// The feed animal.
        /// </summary>
        protected virtual void FeedAnimal()
        {
            if (!this.Animal.SurvivalSituation || this.Animal.CurrentAnimalHealthNumber == 100)
            {
                return;
            }

            var random = new Random();
            var healthNumber = random.Next(10, 25);
            var temp = this.Animal.CurrentAnimalHealthNumber + healthNumber;
            if (temp > 100)
            {
                this.Animal.CurrentAnimalHealthNumber = 100;
            }
        }
    }
}
