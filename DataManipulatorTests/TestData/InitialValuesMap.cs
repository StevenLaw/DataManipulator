using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulatorTests.TestData
{
    public class InitialValuesMap : ClassMap<InitialValues>
    {
        public InitialValuesMap()
        {
            Map(m => m.Date).Name("Date");
            Map(m => m.Status).Name("Status");
            Map(m => m.Num1).Name("Num1");
            Map(m => m.Num2).Name("Num2");
            Map(m => m.Num3).Name("Num3");
        }
    }
}
