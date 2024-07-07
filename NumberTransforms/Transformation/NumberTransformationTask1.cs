using NumberTransforms.Model;


namespace NumberTransforms.Transformation;


public class NumberTransformationTask1 : NumberTransformationTask,
        INumberTransformation
{
    public override string Divisibility(long number)
    {
        var word = Division_3(number);
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

