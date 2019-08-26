// Copyright @Frankie Yu - All Rights Reserved
// Filename: ZooServiceConfiguration.cs
// Created By  :  Frankie
// Created Date:  26/08/2019  16:28
// Last Edit:
//    Author:   Frankie
//    Date:     26/08/2019  17:11

namespace ZooService.Core
{
    public class ZooServiceConfiguration
    {
        public static double InitialHealthNumber => 100;

        public static int PassingRate => 20;

        public static int ElephantSurvivalHealthNumber => 70;

        public static int MinReducedHealthNumber => 0;

        public static int MaxReducedHealthNumber => 20;

        public static int MonkeySurvivalHealthNumber => 30;

        public static int GiraffeSurvivalHealthNumber => 50;

        public static string ConsumerAssemblies => string.Concat(
            "ZooService.Core.Consumers.ElephantHealthCareConsumer;",
            "ZooService.Core.Consumers.GiraffeHealthCareConsumer;",
            "ZooService.Core.Consumers.MonkeyHealthCareConsumer");
    }
}