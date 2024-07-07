using Moq;
using NumberTransforms.Model;
using NumberTransforms.Transformation;
using Xunit;


namespace NumberTransformsTest;


public class DogCatTest
{
    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { 1, "1" };
        yield return new object[] { 2, "2" };
        yield return new object[] { 3, "dog" };
        yield return new object[] { 4, "muzz" };
        yield return new object[] { 5, "cat" };
        yield return new object[] { 6, "dog" };
        yield return new object[] { 7, "guzz" };
        yield return new object[] { 8, "muzz" };
        yield return new object[] { 9, "dog" };
        yield return new object[] { 10, "cat" };
        yield return new object[] { 11, "11" };
        yield return new object[] { 12, "fizz-muzz" };
        yield return new object[] { 13, "13" };
        yield return new object[] { 14, "guzz" };
        yield return new object[] { 15, "good-boy" };
        yield return new object[] { 60, "good-boy-muzz" };
        yield return new object[] { 105, "good-boy-guzz" };
        yield return new object[] { 420, "good-boy-muzz-guzz" };
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test_DogCat(int number, string expected)
    {
        // Arrange
        var dogCat = new NumberTransformationTask3();

        // Act
        var result = dogCat.Divisibility(number);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_DogCat_Should_ApplyTransformation_Not_Equivalent()
    {
        // Arrange
        Mock<NumberTransformationTask1> mock = new Mock<NumberTransformationTask1>();
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 3)))
            .Returns("dog");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 5)))
            .Returns("cat");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 420)))
            .Returns("good-boy-muzz-guzz");

        var numtask = new ConsoleKeyInfo((char)ConsoleKey.D1, ConsoleKey.F1, false, false, false);
        var inputValue = new List<FieldInputModel>() {
             new FieldInputModel()  { Field = 3, FieldExpected = "dog" },
             new FieldInputModel()  { Field = 5, FieldExpected = "cat" } ,
             new FieldInputModel()  { Field = 420, FieldExpected = "good-boy-muzz-guzz" }
        };
        var expected = new List<FieldOutputModel>() {
             new FieldOutputModel()  { Field = 3, FieldExpected = "dog", FieldActual = "dog" },
             new FieldOutputModel()  { Field = 5, FieldExpected = "cat", FieldActual = "cat" } ,
             new FieldOutputModel()  { Field = 420, FieldExpected = "good-boy-muzz-guzz", FieldActual = "good-boy-muzz-guzz-guzz" }
        };


        var target = new NumberTransformationTask(mock.Object);

        // Act
        var actual = target.ApplyTranformation(inputValue, numtask, false);


        // Assert
        Assert.Equivalent(expected, actual);
    }

    [Fact]
    public void Test_DogCat_Should_ApplyTransformation_Equivalent()
    {
        // Arrange
        Mock<NumberTransformationTask1> mock = new Mock<NumberTransformationTask1>();
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 3)))
            .Returns("dog");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 5)))
            .Returns("cat");
        mock.Setup(m => m.Divisibility(It.Is<long>(v => v == 420)))
            .Returns("good-boy-muzz-guzz");

        var numtask = new ConsoleKeyInfo((char)ConsoleKey.D1, ConsoleKey.F1, false, false, false);
        var inputValue = new List<FieldInputModel>() {
             new FieldInputModel()  { Field = 3, FieldExpected = "dog" },
             new FieldInputModel()  { Field = 5, FieldExpected = "cat" } ,
             new FieldInputModel()  { Field = 420, FieldExpected = "good-boy-muzz-guzz" }
        };
        var expected = new List<FieldOutputModel>() {
             new FieldOutputModel()  { Field = 3, FieldExpected = "dog", FieldActual = "dog" },
             new FieldOutputModel()  { Field = 5, FieldExpected = "cat", FieldActual = "cat" } ,
             new FieldOutputModel()  { Field = 420, FieldExpected = "good-boy-muzz-guzz", FieldActual = "good-boy-muzz-guzz" }
        };


        var target = new NumberTransformationTask(mock.Object);

        // Act
        var actual = target.ApplyTranformation(inputValue, numtask, false);


        // Assert
        Assert.Equivalent(expected, actual);
    }


}
