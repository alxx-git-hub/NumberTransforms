using NumberTransforms.Model;


namespace NumberTransforms.Transformation;


public class NumberTransformationTask3 : NumberTransformationTask,
    INumberTransformation
{
    public bool DivedExactly(long number, long number2)
    {

        if (number % number2 == 0)
        {
            return true;
        }
        else return false;
    }

    public override string Divisibility(long number)
    {
        var word = Division_3_5(number);
        word = Division_7(number, word);
        return word;
    }
   
    public override string Division_3_5(long number)
    {
        if (number % 3 == 0 && number % 5 == 0)
        {
            var word = "good-boy";
            return Division_4(number, word);
        }
        if (number % 3 == 0 || number % 4 == 0 || number % 5 == 0)
            return Division_3_4_5(number);
        return number.ToString();
    }

    public override string Division_3(long number, string word = "")
    {
        if (number % 3 == 0)
            return $"dog";
        return number.ToString();
    }

    public override string Division_5(long number, string word = "")
    {
        var newWord = "";
        if (!int.TryParse(word, out _))
        {
            newWord = $"{word}";
        }

        var dash = "";
        if (newWord != "") dash = "-";

        if (number % 5 == 0)
            return $"{newWord}{dash}cat";

        return newWord != "" ? newWord : number.ToString();
    }

    public override string Division_3_4_5(long number)
    {
        var word = Division_3(number);
        word = Division_4(number, word);
        word = Division_5(number, word);
        return word;
    }

    public List<FieldOutputModel> ApplyTransformation(List<FieldInputModel> models, ConsoleKeyInfo key,
        bool isOpenFile = true)
    {
        var modelsOutput = new List<FieldOutputModel>();
        foreach (var m in models)
        {
            var str = Divisibility(m.Field);
            modelsOutput.Add(new FieldOutputModel() { Field = m.Field, FieldExpected = m.FieldExpected, FieldActual = str });
        }

        WriteToJsonFile(modelsOutput, key, isOpenFile);
        return modelsOutput;
    }
}

