using System;
using System.Collections.Generic;
using System.Linq;

namespace LowestValueApp
{
    public class ValueFinder
    {
        /// <summary>
        /// Finds the lowest integer value in the provided sequence.
        /// Handles null and empty sequences gracefully by throwing exceptions.
        /// </summary>
        /// <param name="inputValues">Sequence of integers to evaluate.</param>
        /// <returns>The lowest integer in the sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown when inputValues is null.</exception>
        /// <exception cref="ArgumentException">Thrown when inputValues is empty.</exception>
        public int GetLowestValue(IEnumerable<int> inputValues)
        {
            if (inputValues == null)
                throw new ArgumentNullException(nameof(inputValues), "Input sequence cannot be null.");

            if (!inputValues.Any())
                throw new ArgumentException("Input sequence cannot be empty.", nameof(inputValues));

            int lowest = int.MaxValue;

            foreach (int value in inputValues)
            {
                if (value < lowest)
                {
                    lowest = value;
                }
            }

            return lowest;
        }
    }
}
