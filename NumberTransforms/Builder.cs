using NumberTransforms.Model;
using NumberTransforms.Transformation;


namespace NumberTransforms;


public class Builder
{
    public void Run()
    {    
        NumberTransformationTask numberTransformationTask = new NumberTransformationTask();

        Console.WriteLine("Укажите номер задачи: ");
        Console.WriteLine("№1 - fizz-buzz, №2 - muzz-guzz, №3 - dog-cat (для выхода нажмите ESC) ... ");
        ConsoleKeyInfo numtask;
        numtask = Console.ReadKey();
        Console.WriteLine();
        List<FieldInputModel>? modelsInput;

        bool b = false;
        while (numtask.Key != ConsoleKey.Escape && !b)
        {
            switch (numtask.Key)
            {
                case ConsoleKey.D1:
                    numberTransformationTask.NumberTransformation = new NumberTransformationTask1();
                    modelsInput = numberTransformationTask.PopulateData(Constants.InNumTask1, Constants.OutNumTask1, numtask);
                    //modelsWrite = numberTransformationTask.PopulateData(1, 1000, numtask);
                    numberTransformationTask.ApplyTranformation(modelsInput, numtask);
                    Console.WriteLine("Задача №1 выполнена успешно!");
                    b = true;
                    break;

                case ConsoleKey.D2:
                    numberTransformationTask.NumberTransformation = new NumberTransformationTask2();
                    modelsInput = numberTransformationTask.PopulateData(Constants.InNumTask2, Constants.OutNumTask2, numtask);
                    numberTransformationTask.ApplyTranformation(modelsInput, numtask);
                    Console.WriteLine("Задача №2 выполнена успешно!");
                    b = true;
                    break;

                case ConsoleKey.D3:
                    numberTransformationTask.NumberTransformation = new NumberTransformationTask3();
                    modelsInput = numberTransformationTask.PopulateData(Constants.InNumTask3, Constants.OutNumTask3, numtask);
                    numberTransformationTask.ApplyTranformation(modelsInput, numtask);
                    Console.WriteLine("Задача №3 выполнена успешно!");
                    b = true;
                    break;

                default:
                    Console.WriteLine("Неверно указан номер задачи!");
                    b = false;
                    Console.WriteLine("Укажите номер задачи: ");
                    Console.WriteLine("№1 - fizz-buzz, №2 - muzz-guzz, №3 - dog-cat (для выхода нажмите ESC) ... ");
                    numtask = Console.ReadKey();
                    Console.WriteLine();
                    break;
            }

            if (b)
            {
                Console.WriteLine("Хотите указать еще один номер задачи? (Y (Yes)/ N (No)): ");
                numtask = Console.ReadKey();
                if (numtask.KeyChar != 'Y' && numtask.KeyChar != 'y')
                    break;
                else
                {
                    b = false;
                    Console.WriteLine();
                    Console.WriteLine("Укажите номер задачи: ");
                    Console.WriteLine("№1 - fizz-buzz, №2 - muzz-guzz, №3 - dog-cat (для выхода нажмите ESC) ... ");
                    numtask = Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }
      
    }
}