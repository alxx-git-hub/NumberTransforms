using Newtonsoft.Json;
using NumberTransforms.Model;
using System.Diagnostics;


namespace NumberTransforms.Transformation;


public class NumberTransformationTask : INumberTransformationTask
{

    public INumberTransformation NumberTransformation { get; set; }

    public NumberTransformationTask()
    {
    }

    public NumberTransformationTask(INumberTransformation numberTransformation)
    {
        this.NumberTransformation = numberTransformation;
    }

    public List<FieldOutputModel> ApplyTranformation(List<FieldInputModel> models, ConsoleKeyInfo key,
        bool isOpenFile = true)
    {
        return NumberTransformation.ApplyTransformation(models, key, isOpenFile);
    }

    public virtual string Divisibility(long number)
    {
        return number.ToString();
    }

    public virtual string Division_3(long number, string word = "")
    {
        if (number % 3 == 0)
            return "fizz";
        return number.ToString();
    }

    public virtual string Division_5(long number, string word = "")
    {
        var newWord = "";
        if (!int.TryParse(word, out _))
        {
            newWord = $"{word}";
        }

        var dash = "";
        if (newWord != "") dash = "-";

        if (number % 5 == 0)
            return $"{newWord}{dash}buzz";

        return newWord != "" ? newWord : number.ToString();
    }

    public virtual string Division_4(long number, string word)
    {
        var newWord = "";
        if (!int.TryParse(word, out _))
        {
            newWord = $"{word}";
        }

        var dash = "";
        if (newWord != "") dash = "-";

        if (number % 4 == 0)
            return $"{newWord}{dash}muzz";

        return newWord != "" ? newWord : number.ToString();
    }

    public virtual string Division_7(long number, string word)
    {
        var newWord = "";
        if (!int.TryParse(word, out _))
        {
            newWord = $"{word}";
        }

        var dash = "";
        if (newWord != "") dash = "-";

        if (number % 7 == 0)
            return $"{newWord}{dash}guzz";

        return newWord != "" ? newWord : number.ToString();
    }

    public virtual string Division_3_5(long number)
    {
        if (number % 3 == 0 && number % 5 == 0)
            return "good-boy";
        if (number % 3 == 0)
            return Division_3(number);
        if (number % 5 == 0)
            return Division_5(number);
        return number.ToString();
    }

    public virtual string Division_3_4_5(long number)
    {
        return number.ToString();
    }

   

    public List<FieldInputModel> PopulateData(List<int> InL, List<string> InL2, ConsoleKeyInfo key)
    {

        var models = new List<FieldInputModel>();

        for (int i = 0; i <= InL.Count() - 1; i++)
        {
            models.Add(new FieldInputModel
            { Field = InL.ElementAt(i), FieldExpected = InL2.ElementAt(i) });
        }

        var fileName = $"{Constants.DirectoryApplicationName}\\" +
            $"NumberInputTransforms_Task{int.Parse(key.KeyChar.ToString())}.json";
        WriteToJsonFile<List<FieldInputModel>>(fileName, models);

        if (File.Exists(fileName)) models = ReadFromJsonFile<FieldInputModel>(fileName);

        return models;
    }

    public List<FieldInputModel> PopulateData(int start, int count, ConsoleKeyInfo key)
    {
        //int start = 1; // Start of the sequence
        //int count = 1000; // Number of elements in the sequence

        var models = new List<FieldInputModel>();

        var numbers = Enumerable.Range(start, count);
        foreach (var number in numbers)
        {
            models.Add(new FieldInputModel { Field = number, FieldExpected = number.ToString() });
        }

        var fileName = $"{Constants.DirectoryApplicationName}\\" +
            $"NumberInputTransforms_Task{int.Parse(key.KeyChar.ToString())}.json";
        WriteToJsonFile<List<FieldInputModel>>(fileName, models);

        if (File.Exists(fileName)) models = ReadFromJsonFile<FieldInputModel>(fileName);

        return models;
    }

    private void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
    {
        if (objectToWrite == null)
        {
            throw new ArgumentNullException(nameof(objectToWrite));
        }

        var dataToWriteToFile = JsonConvert.SerializeObject(objectToWrite, new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
        });
        using (var writer = new StreamWriter(filePath, append))
        {
            writer.Write(dataToWriteToFile);
        }
    }

    private List<T>? ReadFromJsonFile<T>(string filePath) where T : new()
    {

        List<T> models = new List<T>();
        string jsonString = File.ReadAllText(filePath);

        if (String.IsNullOrEmpty(jsonString))
        {
            return default(List<T>);
        }

        dynamic jsonModels = JsonConvert.DeserializeObject<List<T>>(jsonString);
        return jsonModels;

    }

    public void ReadFromJsonFile(string fileName)
    {
        var modelsRead = ReadFromJsonFile<FieldInputModel>(fileName);

        foreach (var m in modelsRead)
            Console.WriteLine(m.Field);
    }

    protected void WriteToJsonFile(List<FieldOutputModel> models, ConsoleKeyInfo key,
        bool isOpenFile = true)
    {
        var fileName = $"{Constants.DirectoryApplicationName}\\" +
            $"NumberOutputTransforms_Task{int.Parse(key.KeyChar.ToString())}.json";
        WriteToJsonFile<List<FieldOutputModel>>(fileName, models);

        if (File.Exists(fileName) && isOpenFile) Process.Start("notepad.exe", fileName);
    }

}
