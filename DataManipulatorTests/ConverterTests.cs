using System;
using DataManipulatorTests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataManipulatorTests
{
    [TestClass]
    public class ConverterTests
    {
        static readonly DateTime DATE = new DateTime(2020, 1, 1);
        const int CL_NUM1 = 1;
        const int CL_NUM2 = 2;
        const decimal CL_NUM3 = 3m;
        const int D_NUM1 = 1;
        const int D_NUM2 = 2;
        const decimal D_NUM3 = 3m;
        const int M_NUM1 = 1;
        const int M_NUM2 = 2;
        const decimal M_NUM3 = 3m;
        const int S_NUM1 = 1;
        const int S_NUM2 = 2;
        const decimal S_NUM3 = 3m;

        readonly InitialValues[] sampleData = new InitialValues[]
        {
            new InitialValues {
                Date = DATE,
                Status = "Common-Law",
                Num1 = CL_NUM1,
                Num2 = CL_NUM2,
                Num3 = CL_NUM3
            },
            new InitialValues {
                Date = DATE,
                Status = "Divorced",
                Num1 = D_NUM1,
                Num2 = D_NUM2,
                Num3 = D_NUM3
            },
            new InitialValues {
                Date = DATE,
                Status = "Married",
                Num1 = M_NUM1,
                Num2 = M_NUM2,
                Num3 = M_NUM3
            },
            new InitialValues {
                Date = DATE,
                Status = "Single",
                Num1 = S_NUM1,
                Num2 = S_NUM2,
                Num3 = S_NUM3
            }
        };

        [TestMethod]
        public void TestConversionNum1()
        {
            // assign
            var converter = new TestDataConverter(v => v.Num1);

            // arrange
            var finalData = converter.Convert(sampleData);

            // assert
            Assert.AreEqual(finalData.Date, DATE, $"The date in the sample data should be {DATE}");
            Assert.AreEqual(finalData.CommonLaw, CL_NUM1, $"Common-Law Num1 in the sample data should be {CL_NUM1}");
            Assert.AreEqual(finalData.Divorced, D_NUM1, $"Divorced Num1 in the sample data should be {D_NUM1}");
            Assert.AreEqual(finalData.Married, M_NUM1, $"Married Num1 in the sample data should be {M_NUM1}");
            Assert.AreEqual(finalData.Single, S_NUM1, $"Single Num1 in the sample data should be {S_NUM1}");
        }

        [TestMethod]
        public void TestConversionNum2()
        {
            // assign
            var converter = new TestDataConverter(v => v.Num2);

            // arrange
            var finalData = converter.Convert(sampleData);

            // assert
            Assert.AreEqual(finalData.Date, DATE, $"The date in the sample data should be {DATE}");
            Assert.AreEqual(finalData.CommonLaw, CL_NUM2, $"Common-Law Num2 in the sample data should be {CL_NUM2}");
            Assert.AreEqual(finalData.Divorced, D_NUM2, $"Divorced Num2 in the sample data should be {D_NUM2}");
            Assert.AreEqual(finalData.Married, M_NUM2, $"Married Num2 in the sample data should be {M_NUM2}");
            Assert.AreEqual(finalData.Single, S_NUM2, $"Single Num2 in the sample data should be {S_NUM2}");
        }

        [TestMethod]
        public void TestConversionNum3()
        {
            // assign
            var converter = new TestDataConverter(v => v.Num3);

            // arrange
            var finalData = converter.Convert(sampleData);

            // assert
            Assert.AreEqual(finalData.Date, DATE, $"The date in the sample data should be {DATE}");
            Assert.AreEqual(finalData.CommonLaw, CL_NUM3, $"Common-Law Num3 in the sample data should be {CL_NUM3}");
            Assert.AreEqual(finalData.Divorced, D_NUM3, $"Divorced Num3 in the sample data should be {D_NUM3}");
            Assert.AreEqual(finalData.Married, M_NUM3, $"Married Num3 in the sample data should be {M_NUM3}");
            Assert.AreEqual(finalData.Single, S_NUM3, $"Single Num3 in the sample data should be {S_NUM3}");
        }
    }
}
