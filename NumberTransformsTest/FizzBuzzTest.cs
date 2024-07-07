using Moq;
using NumberTransforms.Model;
using NumberTransforms.Transformation;
using Xunit;


namespace NumberTransformsTest;


public class FizzBuzzTest
{
    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { 1, "1" };
        yield return new object[] { 2, "2" };
        yield return new object[] { 3, "fizz" };
        yield return new object[] { 4, "4" };
        yield return new object[] { 5, "buzz" };
        yield return new object[] { 6, "fizz" };
        yield return new object[] { 7, "7" };
        yield return new object[] { 8, "8" };
        yield return new object[] { 9, "fizz" };
        yield return new object[] { 10, "buzz" };
        yield return new object[] { 11, "11" };
        yield return new object[] { 12, "fizz" };
        yield return new object[] { 13, "13" };
        yield return new object[] { 14, "14" };
        yield return new object[] { 15, "fizz-buzz" };
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test_FizzBuzz(int number, string expected)
    {
        // Arrange
        var fizzBuzz = new NumberTransformationTask1();

        // Act
        var result = fizzBuzz.Divisibility(number);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_FizzBuzz_Should_ApplyTransformation_ArgumentOutOfRangeException()
    {
        // Arrange
        Mock<NumberTransformationTask1> mock = new Mock<NumberTransformationTask1>();
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 3)))
            .Returns("fizz");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 423)))
            .Throws<System.ArgumentOutOfRangeException>();
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 15)))
            .Returns("fizz-buzz");

        var numtask = new ConsoleKeyInfo((char)ConsoleKey.D1, ConsoleKey.F1, false, false, false);
        var inputValue = new List<FieldInputModel>() {
             new FieldInputModel()  { Field = 3, FieldExpected = "fizz" },
             new FieldInputModel()  { Field = 5, FieldExpected = "buzz" } ,
             new FieldInputModel()  { Field = 15, FieldExpected = "fizz-buzz" }
        };
        var expected = new[] { "fizz", "buzz", "fizz-buzz" };      


        var target = new NumberTransformationTask(mock.Object);

        // Act
        var actual = target.ApplyTranformation(inputValue, numtask, false);


        // Assert
        Assert.Equivalent(expected, actual);
    }

    [Fact]
    public void Test_FizzBuzz_Should_ApplyTransformation_Not_Equivalent()
    {
        // Arrange
        Mock<NumberTransformationTask1> mock = new Mock<NumberTransformationTask1>();
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 3)))
            .Returns("fizz");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 5)))
            .Returns("buzz");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 15)))
            .Returns("fizz-buzz");

        var numtask = new ConsoleKeyInfo((char)ConsoleKey.D1, ConsoleKey.F1, false, false, false);
        var inputValue = new List<FieldInputModel>() {
             new FieldInputModel()  { Field = 3, FieldExpected = "fizz" },
             new FieldInputModel()  { Field = 5, FieldExpected = "buzz" } ,
             new FieldInputModel()  { Field = 15, FieldExpected = "fizz-buzz" }
        };
        var expected = new List<FieldOutputModel>() {
             new FieldOutputModel()  { Field = 3, FieldExpected = "fizz", FieldActual = "fizz" },
             new FieldOutputModel()  { Field = 5, FieldExpected = "buzz", FieldActual = "buzz1" } ,
             new FieldOutputModel()  { Field = 15, FieldExpected = "fizz-buzz", FieldActual = "fizz-buzz" }
        };


        var target = new NumberTransformationTask(mock.Object);

        // Act
        var actual = target.ApplyTranformation(inputValue, numtask, false);


        // Assert
        Assert.Equivalent(expected, actual);
    }

    [Fact]
    public void Test_FizzBuzz_Should_ApplyTransformation_Equivalent()
    {
        // Arrange
        Mock<NumberTransformationTask1> mock = new Mock<NumberTransformationTask1>();
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 3)))
            .Returns("fizz");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 5)))
            .Returns("buzz");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 15)))
            .Returns("fizz-buzz");

        var numtask = new ConsoleKeyInfo((char)ConsoleKey.D1, ConsoleKey.F1, false, false, false);
        var inputValue = new List<FieldInputModel>() {
             new FieldInputModel()  { Field = 3, FieldExpected = "fizz" },
             new FieldInputModel()  { Field = 5, FieldExpected = "buzz" } ,
             new FieldInputModel()  { Field = 15, FieldExpected = "fizz-buzz" }
        };
        var expected = new List<FieldOutputModel>() {
             new FieldOutputModel()  { Field = 3, FieldExpected = "fizz", FieldActual = "fizz" },
             new FieldOutputModel()  { Field = 5, FieldExpected = "buzz", FieldActual = "buzz" } ,
             new FieldOutputModel()  { Field = 15, FieldExpected = "fizz-buzz", FieldActual = "fizz-buzz" }
        };


        var target = new NumberTransformationTask(mock.Object);

        // Act
        var actual = target.ApplyTranformation(inputValue, numtask, false);


        // Assert
        Assert.Equivalent(expected, actual);
    }

}
