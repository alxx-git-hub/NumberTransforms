namespace NumberTransforms.Transformation;


public interface INumberTransformationTask
{
    string Divisibility(long number);

    string Division_3(long number, string word = "");

    string Division_5(long number, string word = "");

    string Division_3_5(long number);

    public string Division_3_4_5(long number);

    string Division_4(long number, string word);

    string Division_7(long number, string word);

}