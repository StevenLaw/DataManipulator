using DataManipulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataManipulatorTests.Utilities
{
    class PersonConverter : IConverter<Person, PersonGrouped, string>
    {
        public Func<Person, string> KeySelector { get; private set; }
        public Func<Person, double> Fetch { get; private set; }

        public PersonConverter(Func<Person, string> keySelector, 
            Func<Person, double> fetch)
        {
            KeySelector = keySelector;
            Fetch = fetch;
        }

        public PersonGrouped AverageProperties(IEnumerable<PersonGrouped> item, int groupSize)
        {
            return new PersonGrouped
            {
                Name = item.Last().Name,
                Plumber = item.Sum(p => p.Plumber) / groupSize,
                Accountant = item.Sum(p => p.Accountant) / groupSize,
                Cook = item.Sum(p => p.Cook) / groupSize,
                Engineer = item.Sum(p => p.Engineer) / groupSize
            };
        }

        public PersonGrouped Convert(IEnumerable<Person> item)
        {
            return new PersonGrouped
            {
                Name = item.FirstOrDefault().Name,
                Plumber = item.Where(p => p.Position == "Plumber").Sum(Fetch),
                Accountant = item.Where(p => p.Position == "Accountant").Sum(Fetch),
                Cook = item.Where(p => p.Position == "Cook").Sum(Fetch),
                Engineer = item.Where(p => p.Position == "Engineer").Sum(Fetch)
            };
        }
    }
}
