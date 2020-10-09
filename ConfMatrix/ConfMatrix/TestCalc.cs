using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ConfMatrix
{
    [TestFixture]
    class TestCalc
    {

        [Test]
        public void testPrecisionwithContainingNoLetter()
        {
            Calc calc;
            calc = new Calc("24", "12", "23", "34");
            Assert.AreEqual(24/(float)(24+12), calc.precision());
        }
        [Test]
        public void testPrecisionWithFirstContainingFloatString()
        {
            Calc calc;
            calc = new Calc("24.1", "12", "23", "34");
            Assert.AreEqual(24.1 / (float)(24.1 + 12), calc.precision());
        }
        [Test]
        public void testPrecisionWithSecondContainingFloatString()
        {
            Calc calc;
            calc = new Calc("24", "12.1", "23", "34");
            Assert.AreEqual(24 / (float)(24 + 12.1), calc.precision());
        }
        [Test]
        public void testPrecisionWithThirdContainingFloatString()
        {
            Calc calc;
            calc = new Calc("24", "12", "23.4", "34");
            Assert.AreEqual(24 / (float)(24 + 12), calc.precision());
        }
        [Test]
        public void testPrecisionWithFourthContainingFloatString()
        {
            Calc calc;
            calc = new Calc("24", "12", "23", "34.1");
            Assert.AreEqual(24 / (float)(24 + 12), calc.precision());
        }
        [Test]
        public void testPrecisionWithAllContainingFloatString()
        {
            Calc calc;
            calc = new Calc("24.1", "12.2", "23.3", "34.3");
            Assert.AreEqual(24.1 / (float)(24.1 + 12.2), calc.precision());
        }

        [Test]
        public void testPrecisionWithFirstContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("#", "12", "23", "34");
            Assert.Throws<FormatException>(() => calc.precision());
        }
        [Test]
        public void testPrecisionWithSecondContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "#", "23", "34");
            Assert.Throws<FormatException>(() => calc.precision());
        }

        [Test]
        public void testPrecisionWithThirdContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "14", "#", "34");
            Assert.Throws<FormatException>(() => calc.precision());
        }
        [Test]
        public void testPrecisionWithFourthContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "14", "34", "#");
            Assert.Throws<FormatException>(() => calc.precision());
        }





        [Test]
       public void testPrecisionwithFirstContainingLetter()
        {
            Calc calc;
            calc = new Calc("A123", "12", "23", "34");
            Assert.AreEqual(-1.0f, calc.precision());
        }
        [Test]
        public void testPrecisionwithSecondContainingLetter()
        {
            Calc calc;
            calc = new Calc("1","A123", "23", "34");
            Assert.AreEqual(-1.0f, calc.precision());
        }

        [Test]
        public void testPrecisionwithThirdContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "23", "A123",  "34");
            Assert.AreEqual(-1.0f, calc.precision());
        }
        [Test]
        public void testPrecisionwithFourthContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "23", "123", "A34");
            Assert.AreEqual(-1.0f, calc.precision());
        }
        [Test]
        public void testPrecisionwithAllContainingLetter()
        {
            Calc calc;
            calc = new Calc("A1", "23A", "A123", "A34");
            Assert.AreEqual(-1.0f, calc.precision());
        }

        [Test]
        public void testPrecisionwithFirstEmpty()
        {
            Calc calc;
            calc = new Calc("", "12", "23", "34");
            Assert.AreEqual(0.0f, calc.precision());
        }
        [Test]
        public void testPrecisionwithSecondEmpty()
        {
            Calc calc;
            calc = new Calc("1", "", "23", "34");
            Assert.AreEqual(0.0f, calc.precision());
        }

        [Test]
        public void testPrecisionwithThirdEmpty()
        {
            Calc calc;
            calc = new Calc("1", "23", "", "34");
            Assert.AreEqual(0.0f, calc.precision());
        }
        [Test]
        public void testPrecisionwithFourthEmpty()
        {
            Calc calc;
            calc = new Calc("1", "23", "123", "");
            Assert.AreEqual(0.0f, calc.precision());
        }
        [Test]
        public void testPrecisionwithAllEmpty()
        {
            Calc calc;
            calc = new Calc("", "", "", "");
            Assert.AreEqual(0.0f, calc.precision());
        }

        //Accuracy testing
        [Test]
        public void testAccuracywithContainingNoLetter()
        {
            Calc calc;
            calc = new Calc("24", "12", "23", "34");
            
            Assert.AreEqual((24+23) / (float)((24 + 34)+(12+23)), calc.accuracy());
        }

        [Test]
        public void testAccuracyWithFirstContainingFloat()
        {
            Calc calc;
            calc = new Calc("24.1", "12", "23", "34");
            
            Assert.AreEqual((24.1 + 23) / (float)((24.1 + 34) + (12 + 23)), calc.accuracy());
        }
        [Test]
        public void testAccuracyWithSecondContainingFloat()
        {
            Calc calc;
            calc = new Calc("24", "12.1", "23", "34");

            Assert.AreEqual((24 + 23) / (float)((24 + 34) + (12.1 + 23)), calc.accuracy());
        }
        [Test]
        public void testAccuracyWithThirdContainingFloat()
        {
            Calc calc;
            calc = new Calc("24", "12", "23.1", "34");

            Assert.AreEqual((24 + 23.1) / (float)((24 + 34) + (12 + 23.1)), calc.accuracy());
        }
        [Test]
        public void testAccuracyWithFourthContainingFloat()
        {
            Calc calc;
            calc = new Calc("24", "12", "23", "34.1");

            Assert.AreEqual((24 + 23) / (float)((24 + 34.1) + (12 + 23)), calc.accuracy());
        }
        [Test]
        public void testAccuracyWithAllContainingFloat()
        {
            Calc calc;
            calc = new Calc("24.1", "12.1", "23.1", "34.1");

            Assert.AreEqual((24.1 + 23.1) / (float)((24.1 + 34.1) + (12.1 + 23.1)), calc.accuracy());
        }

        [Test]
        public void testAccuracyWithFirstContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("#", "12", "23", "34");
            Assert.Throws<FormatException>(() => calc.accuracy());
        }
        [Test]
        public void testAccuracyWithSecondContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "#", "23", "34");
            Assert.Throws<FormatException>(() => calc.accuracy());
        }

        [Test]
        public void testAccuracyWithThirdContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "14", "#", "34");
            Assert.Throws<FormatException>(() => calc.accuracy());
        }
        [Test]
        public void testAccuracyWithFourthContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "14", "34", "#");
            Assert.Throws<FormatException>(() => calc.accuracy());
        }





        [Test]
        public void testAcuuracywithFirstContainingLetter()
        {
            Calc calc;
            calc = new Calc("A123", "12", "23", "34");
            Assert.AreEqual(-1.0f, calc.accuracy());
        }
        [Test]
        public void testAccuracywithSecondContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "A123", "23", "34");
            Assert.AreEqual(-1.0f, calc.accuracy());
        }

        [Test]
        public void testAccuracywithThirdContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "23", "A123", "34");
            Assert.AreEqual(-1.0f, calc.accuracy());
        }
        [Test]
        public void testAccuracywithFourthContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "23", "123", "A34");
            Assert.AreEqual(-1.0f, calc.accuracy());
        }
        [Test]
        public void testAccuracywithAllContainingLetter()
        {
            Calc calc;
            calc = new Calc("A1", "23A", "A123", "A34");
            Assert.AreEqual(-1.0f, calc.accuracy());
        }

        [Test]
        public void testAccuracywithFirstEmpty()
        {
            Calc calc;
            calc = new Calc("", "12", "23", "34");
            Assert.AreEqual(0.0f, calc.accuracy());
        }
        [Test]
        public void testAccuracywithSecondEmpty()
        {
            Calc calc;
            calc = new Calc("1", "", "23", "34");
            Assert.AreEqual(0.0f, calc.accuracy());
        }

        [Test]
        public void testAccuracywithThirdEmpty()
        {
            Calc calc;
            calc = new Calc("1", "23", "", "34");
            Assert.AreEqual(0.0f, calc.accuracy());
        }
        [Test]
        public void testAccuracywithFourthEmpty()
        {
            Calc calc;
            calc = new Calc("1", "23", "123", "");
            Assert.AreEqual(0.0f, calc.accuracy());
        }
        [Test]
        public void testAccuracywithAllEmpty()
        {
            Calc calc;
            calc = new Calc("", "", "", "");
            Assert.AreEqual(0.0f, calc.accuracy());
        }



        //Test Sensivity


        [Test]
        public void testSensitivitywithContainingNoLetter()
        {
            Calc calc;
            calc = new Calc("24", "12", "23", "34");
            Assert.AreEqual(24 / (float)(24 + 34), calc.sensitivity());
        }

        [Test]

        public void testSensitivityWithFirstContainingFloatString()
        {
            Calc calc;
            calc = new Calc("24.1", "12", "23", "34");
            Assert.AreEqual(24.1 / (float)(24.1 + 34), calc.sensitivity());
        }

        [Test]

        public void testSensitivityWithSecondContainingFloatString()
        {
            Calc calc;
            calc = new Calc("24", "12.1", "23", "34");
            Assert.AreEqual(24 / (float)(24 + 34), calc.sensitivity());
        }

        [Test]

        public void testSensitivityWithThirdContainingFloatString()
        {
            Calc calc;
            calc = new Calc("24", "12", "23.1", "34");
            Assert.AreEqual(24 / (float)(24 + 34), calc.sensitivity());
        }

        [Test]

        public void testSensitivityWithFourthContainingFloatString()
        {
            Calc calc;
            calc = new Calc("24", "12", "23", "34.1");
            Assert.AreEqual(24 / (float)(24 + 34.1), calc.sensitivity());
        }

        [Test]

        public void testSensitivityWithAllContainingFloatString()
        {
            Calc calc;
            calc = new Calc("24.1", "12.1", "23.1", "34.1");
            Assert.AreEqual(24.1 / (float)(24.1 + 34.1), calc.sensitivity());
        }

        [Test]
        public void testSensitivityWithFirstContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("#", "12", "23", "34");
            Assert.Throws<FormatException>(() => calc.sensitivity());
        }
        [Test]
        public void testSensitivityWithSecondContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "#", "23", "34");
            Assert.Throws<FormatException>(() => calc.sensitivity());
        }

        [Test]
        public void testSensitivityWithThirdContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "14", "#", "34");
            Assert.Throws<FormatException>(() => calc.sensitivity());
        }
        [Test]
        public void testSensitivityWithFourthContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "14", "34", "#");
            Assert.Throws<FormatException>(() => calc.sensitivity());
        }





        [Test]
        public void testSensitivitywithFirstContainingLetter()
        {
            Calc calc;
            calc = new Calc("A123", "12", "23", "34");
            Assert.AreEqual(-1.0f, calc.sensitivity());
        }
        [Test]
        public void testSensitivitywithSecondContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "A123", "23", "34");
            Assert.AreEqual(-1.0f, calc.sensitivity());
        }

        [Test]
        public void testSensitivitywithThirdContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "23", "A123", "34");
            Assert.AreEqual(-1.0f, calc.sensitivity());
        }
        [Test]
        public void testSensitivitywithFourthContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "23", "123", "A34");
            Assert.AreEqual(-1.0f, calc.sensitivity());
        }
        [Test]
        public void testSensitivitywithAllContainingLetter()
        {
            Calc calc;
            calc = new Calc("A1", "23A", "A123", "A34");
            Assert.AreEqual(-1.0f, calc.sensitivity());
        }

        [Test]
        public void testSensitivitywithFirstEmpty()
        {
            Calc calc;
            calc = new Calc("", "12", "23", "34");
            Assert.AreEqual(0.0f, calc.sensitivity());
        }
        [Test]
        public void testSensitivitywithSecondEmpty()
        {
            Calc calc;
            calc = new Calc("1", "", "23", "34");
            Assert.AreEqual(0.0f, calc.sensitivity());
        }

        [Test]
        public void testSensitivitywithThirdEmpty()
        {
            Calc calc;
            calc = new Calc("1", "23", "", "34");
            Assert.AreEqual(0.0f, calc.sensitivity());
        }
        [Test]
        public void testSensitivitywithFourthEmpty()
        {
            Calc calc;
            calc = new Calc("1", "23", "123", "");
            Assert.AreEqual(0.0f, calc.sensitivity());
        }
        [Test]
        public void testSensitivitywithAllEmpty()
        {
            Calc calc;
            calc = new Calc("", "", "", "");
            Assert.AreEqual(0.0f, calc.sensitivity());
        }

        //Test Specificity
        [Test]
        public void testSpecificitywithContainingNoLetter()
        {
            Calc calc;
            calc = new Calc("24", "12", "23", "34");
            
            Assert.AreEqual(23 / (float)(12 + 23), calc.specificity());
        }

        [Test]
        public void testSpecifityWithFirstContaingFloatSTring()
        {
            Calc calc;
            calc = new Calc("24.1", "12", "23", "34");

            Assert.AreEqual(23 / (float)(12 + 23), calc.specificity());
        }

        [Test]
        public void testSpecifityWithSecondContaingFloatSTring()
        {
            Calc calc;
            calc = new Calc("24", "12.1", "23", "34");

            Assert.AreEqual(23 / (float)(12.1 + 23), calc.specificity());
        }

        [Test]
        public void testSpecifityWithFourthContaingFloatSTring()
        {
            Calc calc;
            calc = new Calc("24", "12", "23", "34.1");

            Assert.AreEqual(23 / (float)(12 + 23), calc.specificity());
        }

        [Test]
        public void testSpecifityWithThirdContaingFloatSTring()
        {
            Calc calc;
            calc = new Calc("24", "12", "23.1", "34");

            Assert.AreEqual(23.1 / (float)(12 + 23.1), calc.specificity());
        }

        [Test]
        public void testSpecifityWithAllContaingFloatSTring()
        {
            Calc calc;
            calc = new Calc("24.1", "12.1", "23.1", "34.1");

            Assert.AreEqual(23.1 / (float)(12.1 + 23.1), calc.specificity());
        }




        [Test]
        public void testSpecificityWithFirstContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("#", "12", "23", "34");
            Assert.Throws<FormatException>(() => calc.specificity());
        }
        [Test]
        public void testSpecificityWithSecondContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "#", "23", "34");
            Assert.Throws<FormatException>(() => calc.specificity());
        }

        [Test]
        public void testSpecificityWithThirdContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "14", "#", "34");
            Assert.Throws<FormatException>(() => calc.specificity());
        }
        [Test]
        public void testSpecificityWithFourthContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "14", "34", "#");
            Assert.Throws<FormatException>(() => calc.specificity());
        }





        [Test]
        public void testSpecificitywithFirstContainingLetter()
        {
            Calc calc;
            calc = new Calc("A123", "12", "23", "34");
            Assert.AreEqual(-1.0f, calc.specificity());
        }
        [Test]
        public void testSpecificitywithSecondContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "A123", "23", "34");
            Assert.AreEqual(-1.0f, calc.specificity());
        }

        [Test]
        public void testSpecificitywithThirdContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "23", "A123", "34");
            Assert.AreEqual(-1.0f, calc.specificity());
        }
        [Test]
        public void testSpecificitywithFourthContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "23", "123", "A34");
            Assert.AreEqual(-1.0f, calc.specificity());
        }
        [Test]
        public void testSpecificitywithAllContainingLetter()
        {
            Calc calc;
            calc = new Calc("A1", "23A", "A123", "A34");
            Assert.AreEqual(-1.0f, calc.specificity());
        }

        [Test]
        public void testSpecificitywithFirstEmpty()
        {
            Calc calc;
            calc = new Calc("", "12", "23", "34");
            Assert.AreEqual(0.0f, calc.specificity());
        }
        [Test]
        public void testSpecificitywithSecondEmpty()
        {
            Calc calc;
            calc = new Calc("1", "", "23", "34");
            Assert.AreEqual(0.0f, calc.specificity());
        }

        [Test]
        public void testSpecificitywithThirdEmpty()
        {
            Calc calc;
            calc = new Calc("1", "23", "", "34");
            Assert.AreEqual(0.0f, calc.specificity());
        }
        [Test]
        public void testSpecificitywithFourthEmpty()
        {
            Calc calc;
            calc = new Calc("1", "23", "123", "");
            Assert.AreEqual(0.0f, calc.specificity());
        }
        [Test]
        public void testSpecificitywithAllEmpty()
        {
            Calc calc;
            calc = new Calc("", "", "", "");
            Assert.AreEqual(0.0f, calc.specificity());
        }


        //Test F1Score

        [Test]
        public void testF1ScorewithContainingNoLetter()
        {
            Calc calc;
            calc = new Calc("24", "12", "23", "34");
         
            Assert.AreEqual(2 * 24 / (float)(2 * 24 + 12 + 34), calc.f1Score());
        }

        [Test]
        public void testF1ScoreWithContaingFirstFloatSTring()
        {
            Calc calc;
            calc = new Calc("24.1", "12", "23", "34");

            Assert.AreEqual(2 * 24.1 / (float)(2 * 24.1 + 12 + 34), calc.f1Score());
        }

        [Test]
        public void testF1ScoreWithContaingSecondFloatSTring()
        {
            Calc calc;
            calc = new Calc("24", "12.1", "23", "34");

            Assert.AreEqual(2 * 24 / (float)(2 * 24 + 12.1 + 34), calc.f1Score());
        }

        [Test]
        public void testF1ScoreWithContaingThirdFloatSTring()
        {
            Calc calc;
            calc = new Calc("24", "12", "23.1", "34");

            Assert.AreEqual(2 * 24 / (float)(2 * 24 + 12 + 34), calc.f1Score());
        }

        [Test]
        public void testF1ScoreWithContaingFourthFloatSTring()
        {
            Calc calc;
            calc = new Calc("24", "12", "23", "34.1");

            Assert.AreEqual(2 * 24 / (float)(2 * 24 + 12 + 34.1), calc.f1Score());
        }

        [Test]
        public void testF1ScoreWithContaingAllFloatSTring()
        {
            Calc calc;
            calc = new Calc("24.1", "12.1", "23.1", "34.1");

            Assert.AreEqual(2 * 24.1 / (float)(2 * 24.1 + 12.1 + 34.1), calc.f1Score());
        }

        [Test]
        public void testF1ScorWithFirstContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("#", "12", "23", "34");
            Assert.Throws<FormatException>(() => calc.f1Score());
        }
        [Test]
        public void testF1ScorWithSecondContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "#", "23", "34");
            Assert.Throws<FormatException>(() => calc.f1Score());
        }

        [Test]
        public void testF1ScorWithThirdContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "14", "#", "34");
            Assert.Throws<FormatException>(() => calc.f1Score());
        }
        [Test]
        public void testF1ScorWithFourthContainingOtherSymbol()
        {
            Calc calc;
            calc = new Calc("12", "14", "34", "#");
            Assert.Throws<FormatException>(() => calc.f1Score());
        }





        [Test]
        public void testF1ScorwithFirstContainingLetter()
        {
            Calc calc;
            calc = new Calc("A123", "12", "23", "34");
            Assert.AreEqual(-1.0f, calc.f1Score());
        }
        [Test]
        public void testF1ScorwithSecondContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "A123", "23", "34");
            Assert.AreEqual(-1.0f, calc.f1Score());
        }

        [Test]
        public void testF1ScorwithThirdContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "23", "A123", "34");
            Assert.AreEqual(-1.0f, calc.f1Score());
        }
        [Test]
        public void testF1ScorwithFourthContainingLetter()
        {
            Calc calc;
            calc = new Calc("1", "23", "123", "A34");
            Assert.AreEqual(-1.0f, calc.f1Score());
        }
        [Test]
        public void testF1ScorwithAllContainingLetter()
        {
            Calc calc;
            calc = new Calc("A1", "23A", "A123", "A34");
            Assert.AreEqual(-1.0f, calc.f1Score());
        }

        [Test]
        public void testF1ScorwithFirstEmpty()
        {
            Calc calc;
            calc = new Calc("", "12", "23", "34");
            Assert.AreEqual(0.0f, calc.f1Score());
        }
        [Test]
        public void testF1ScorwithSecondEmpty()
        {
            Calc calc;
            calc = new Calc("1", "", "23", "34");
            Assert.AreEqual(0.0f, calc.f1Score());
        }

        [Test]
        public void testF1ScorwithThirdEmpty()
        {
            Calc calc;
            calc = new Calc("1", "23", "", "34");
            Assert.AreEqual(0.0f, calc.f1Score());
        }
        [Test]
        public void testF1ScorwithFourthEmpty()
        {
            Calc calc;
            calc = new Calc("1", "23", "123", "");
            Assert.AreEqual(0.0f, calc.f1Score());
        }
        [Test]
        public void testF1ScorwithAllEmpty()
        {
            Calc calc;
            calc = new Calc("", "", "", "");
            Assert.AreEqual(0.0f, calc.f1Score());
        }
    }
}
