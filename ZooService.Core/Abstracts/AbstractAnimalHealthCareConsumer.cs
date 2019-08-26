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
            var reducedNumber   = random.Next(ZooServiceConfiguration.MinReducedHealthNumber, ZooServiceConfiguration.MaxReducedHealthNumber);
            return reducedNumber;
        }
    }
}
