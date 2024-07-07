using Moq;
using NumberTransforms.Model;
using NumberTransforms.Transformation;
using Xunit;


namespace NumberTransformsTest;


public class MuzzGuzzTest
{
    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { 1, "1" };
        yield return new object[] { 2, "2" };
        yield return new object[] { 3, "fizz" };
        yield return new object[] { 4, "muzz" };
        yield return new object[] { 5, "buzz" };
        yield return new object[] { 6, "fizz" };
        yield return new object[] { 7, "guzz" };
        yield return new object[] { 8, "muzz" };
        yield return new object[] { 9, "fizz" };
        yield return new object[] { 10, "buzz" };
        yield return new object[] { 11, "11" };
        yield return new object[] { 12, "fizz-muzz" };
        yield return new object[] { 13, "13" };
        yield return new object[] { 14, "guzz" };
        yield return new object[] { 15, "fizz-buzz" };
        yield return new object[] { 60, "fizz-buzz-muzz" };
        yield return new object[] { 105, "fizz-buzz-guzz" };
        yield return new object[] { 420, "fizz-buzz-muzz-guzz" };
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test_MuzzGuzz(int number, string expected)
    {
        // Arrange
        var muzzGuzz = new NumberTransformationTask2();

        // Act
        var result = muzzGuzz.Divisibility(number);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_MuzzGuzz_Should_ApplyTransformation_Not_Equivalent()
    {
        // Arrange
        Mock<NumberTransformationTask1> mock = new Mock<NumberTransformationTask1>();
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 4)))
            .Returns("muzz");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 7)))
            .Returns("guzz");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 60)))
            .Returns("fizz-buzz-muzz");

        var numtask = new ConsoleKeyInfo((char)ConsoleKey.D1, ConsoleKey.F1, false, false, false);
        var inputValue = new List<FieldInputModel>() {
             new FieldInputModel()  { Field = 4, FieldExpected = "muzz" },
             new FieldInputModel()  { Field = 7, FieldExpected = "guzz" } ,
             new FieldInputModel()  { Field = 60, FieldExpected = "fizz-buzz-muzz" }
        };
        var expected = new List<FieldOutputModel>() {
             new FieldOutputModel()  { Field = 4, FieldExpected = "muzz", FieldActual = "muzz" },
             new FieldOutputModel()  { Field = 7, FieldExpected = "guzz", FieldActual = "guzz" } ,
             new FieldOutputModel()  { Field = 60, FieldExpected = "fizz-buzz-muzz", FieldActual = "fizz-buzz-muzz-muzz" }
        };


        var target = new NumberTransformationTask(mock.Object);

        // Act
        var actual = target.ApplyTranformation(inputValue, numtask, false);


        // Assert
        Assert.Equivalent(expected, actual);
    }

    [Fact]
    public void Test_MuzzGuzz_Should_ApplyTransformation_Equivalent()
    {
        // Arrange
        Mock<NumberTransformationTask1> mock = new Mock<NumberTransformationTask1>();
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 4)))
            .Returns("muzz");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 7)))
            .Returns("guzz");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 60)))
            .Returns("fizz-buzz-muzz");

        var numtask = new ConsoleKeyInfo((char)ConsoleKey.D1, ConsoleKey.F1, false, false, false);
        var inputValue = new List<FieldInputModel>() {
             new FieldInputModel()  { Field = 4, FieldExpected = "muzz" },
             new FieldInputModel()  { Field = 7, FieldExpected = "guzz" } ,
             new FieldInputModel()  { Field = 60, FieldExpected = "fizz-buzz-muzz" }
        };
        var expected = new List<FieldOutputModel>() {
             new FieldOutputModel()  { Field = 4, FieldExpected = "muzz", FieldActual = "muzz" },
             new FieldOutputModel()  { Field = 7, FieldExpected = "guzz", FieldActual = "guzz" } ,
             new FieldOutputModel()  { Field = 60, FieldExpected = "fizz-buzz-muzz", FieldActual = "fizz-buzz-muzz" }
        };


        var target = new NumberTransformationTask(mock.Object);

        // Act
        var actual = target.ApplyTranformation(inputValue, numtask, false);


        // Assert
        Assert.Equivalent(expected, actual);
    }
}
