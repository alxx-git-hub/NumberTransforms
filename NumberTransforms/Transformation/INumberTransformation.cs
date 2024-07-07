using NumberTransforms.Model;


namespace NumberTransforms.Transformation;


public interface INumberTransformation
{
    List<FieldOutputModel> ApplyTransformation(List<FieldInputModel> models, ConsoleKeyInfo key,
        bool isOpenFile = true);
}