using DataManipulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataManipulatorTests.TestData
{
    public class TestDataConverter : IConverter<InitialValues, FinalValues, DateTime>
    {
        public Func<InitialValues, DateTime> KeySelector => (InitialValues v) => v.Date;
        public Func<InitialValues, decimal> Fetch { get; private set; }

        public TestDataConverter(Func<InitialValues, decimal> fetch)
        {
            Fetch = fetch;
        }

        public FinalValues AverageProperties(IEnumerable<FinalValues> item, int groupSize)
        {
            return new FinalValues
            {
                Date = item.FirstOrDefault().Date,
                CommonLaw = item.Sum(v => v.CommonLaw) / groupSize,
                Divorced = item.Sum(v => v.Divorced) / groupSize,
                Married = item.Sum(v => v.Married) / groupSize,
                Single = item.Sum(v => v.Single) /groupSize
            };
        }

        public FinalValues Convert(IEnumerable<InitialValues> item)
        {
            return new FinalValues
            {
                Date = item.FirstOrDefault().Date,
                CommonLaw = item.Where(v => v.Status == "Common-Law").Sum(Fetch),
                Divorced = item.Where(v => v.Status == "Divorced").Sum(Fetch),
                Married = item.Where(v => v.Status == "Married").Sum(Fetch),
                Single = item.Where(v => v.Status == "Single").Sum(Fetch)
            };
        }
    }
}
