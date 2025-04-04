using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp14;

namespace NUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateInput_ValidValues_ReturnsCorrectResult()
        {
            // Проверка корректных значений
            Assert.AreEqual(5, MainWindow.CalculatorService.ValidateInput("5", 10));
            Assert.AreEqual(30, MainWindow.CalculatorService.ValidateInput("30", 50));
            Assert.AreEqual(15, MainWindow.CalculatorService.ValidateInput("15", 30));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateInput_InvalidValues_ThrowsException()
        {
            // Проверка пустого значения
            MainWindow.CalculatorService.ValidateInput("", 10);

            // Проверка некорректного числа
            MainWindow.CalculatorService.ValidateInput("abc", 10);

            // Проверка значения вне допустимого диапазона
            MainWindow.CalculatorService.ValidateInput("15", 10);
        }

        [TestMethod]
        public void CalculateGrade_ValidTotals_ReturnsCorrectGrade()
        {
            // Проверка корректных оценок
            Assert.AreEqual("5 (отлично)", MainWindow.CalculatorService.CalculateGrade(70));
            Assert.AreEqual("4 (хорошо)", MainWindow.CalculatorService.CalculateGrade(50));
            Assert.AreEqual("3 (удовлетворительно)", MainWindow.CalculatorService.CalculateGrade(30));
            Assert.AreEqual("2 (неудовлетворительно)", MainWindow.CalculatorService.CalculateGrade(10));
        }

      
    }
}
