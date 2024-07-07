# NumberTransforms

##### 
Описание тестового приложения NumberTransforms

Название: NumberTransforms
Тип приложения: консольное
Инструменты и платформа разработки: Visual Studio Community 2022, .NET 6.0
Используемые nuget пакеты:
    "Newtonsoft.Json" Version="13.0.3    
    "Microsoft.NET.Test.Sdk" Version="17.10.0"
    "Moq" Version="4.20.70"
    "NUnit" Version="4.1.0"
    "xunit" Version="2.8.1"
    "xunit.runner.visualstudio" Version="2.8.1"


##### 
Работа с приложением

При запуске приложения необходимо указать одну из задач:
 "№1 - fizz-buzz, №2 - muzz-guzz, №3 - dog-cat
 

После указания номера задачи будет сформирован результат в текстовый файл в json формате:

 


 

[
  {
    "Field": 1,
    "FieldExpected": "1",
    "FieldActual": "1"
  },
  {
    "Field": 2,
    "FieldExpected": "2",
    "FieldActual": "2"
  },
  {
    "Field": 3,
    "FieldExpected": "fizz",
    "FieldActual": "fizz"
  },
  {
    "Field": 4,
    "FieldExpected": "4",
    "FieldActual": "4"
  },
  {
    "Field": 5,
    "FieldExpected": "buzz",
    "FieldActual": "buzz"
  },
  {
    "Field": 6,
    "FieldExpected": "fizz",
    "FieldActual": "fizz"
  },
  {
    "Field": 7,
    "FieldExpected": "7",
    "FieldActual": "7"
  },
  {
    "Field": 8,
    "FieldExpected": "8",
    "FieldActual": "8"
  },
  {
    "Field": 9,
    "FieldExpected": "fizz",
    "FieldActual": "fizz"
  },
  {
    "Field": 10,
    "FieldExpected": "buzz",
    "FieldActual": "buzz"
  },
  {
    "Field": 11,
    "FieldExpected": "11",
    "FieldActual": "11"
  },
  {
    "Field": 12,
    "FieldExpected": "fizz",
    "FieldActual": "fizz"
  },
  {
    "Field": 13,
    "FieldExpected": "13",
    "FieldActual": "13"
  },
  {
    "Field": 14,
    "FieldExpected": "14",
    "FieldActual": "14"
  },
  {
    "Field": 15,
    "FieldExpected": "fizz-buzz",
    "FieldActual": "fizz-buzz"
  }
]

Если указан некорректный номер задачи, будет выведено соответствующее сообщение.


##### 
Запуск тестов

В Visual Studio 2022 Community необходимо из меню «Тест» – «Обозреватель тестов» выбрать «Выполнить все тесты в представлении (Ctrl+R)»

 
