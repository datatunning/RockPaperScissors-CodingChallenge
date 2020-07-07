// <copyright file="EnumHelpers.cs" company="Bruno DUVAL.">
// Copyright (c) Bruno DUVAL.</copyright>

using System;

namespace Games.RockPaperScissors.Helpers
{
    public static class EnumHelpers
    {
        /// <summary>
        ///     Method to make a random choice out of 1, 2, 3 for the computer
        ///     which is then mapped to the enumerated type: GameChoice
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T RandomizeSelection<T>()
            where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            var random = new Random();
            return (T) values.GetValue(random.Next(values.Length));
        }
    }
}