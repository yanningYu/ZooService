// Copyright @Frankie Yu - All Rights Reserved
// Filename: AnimalsHealthCareConsumerFactory.cs
// Created By  :  Frankie
// Created Date:  22/08/2019  20:37
// Last Edit:
//    Author:   Frankie
//    Date:     22/08/2019  21:00

namespace ZooService.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using ZooService.Core.Abstracts;
    using ZooService.Core.Consumers;
    using ZooService.Core.Models;

    public class AnimalsHealthCareConsumerFactory
    {
        private static AnimalsHealthCareConsumerFactory me = new AnimalsHealthCareConsumerFactory();

        private static List<AbstractAnimalHealthCareConsumer> listConsumer;

        public static List<Animal> Data
        {
            get
            {
                if (listConsumer != null)
                {
                    listConsumer.ForEach(x => x.ReducedHealth());
                }
                else
                {
                    listConsumer = me.List();
                }

                
                return listConsumer.Select(x => x.Animal).OrderBy(x => x.Category).ToList();
            }
        }

        public static bool AnyLive => listConsumer?.Any(x => x.Animal.SurvivalSituation) ?? true;
        public static void UpdateData(List<Animal> data)
        {
            try
            {
                foreach (var source in data)
                {
                    foreach (var des in listConsumer)
                    {
                        if (des.Animal.Id == source.Id)
                        {
                            des.Animal.CurrentAnimalHealthNumber = source.CurrentAnimalHealthNumber;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
        private List<AbstractAnimalHealthCareConsumer> List()
        {
            var list = new List<AbstractAnimalHealthCareConsumer>();
            var instanceSpec = ZooServiceConfiguration.ConsumerAssemblies;
            string[] instances = instanceSpec.Split(';');
           
            for (int i = 0; i < 5; i++)
            {
                object item;
                for (int j = 0; j < instances.Length; j++)
                {
                    
                    item = Activator.CreateInstance(Type.GetType(instances[j]));
                    
                    list.Add(item as AbstractAnimalHealthCareConsumer);
                }
            }

            return list;
        }
    }
}