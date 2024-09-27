---
title: Печать презентации
type: docs
weight: 50
url: /ru/net/print-presentation/
keywords: "Печать PowerPoint, PPT, PPTX, Печать презентации, C#, Csharp, .NET, Принтер, Параметры печати"
description: "Печать презентации PowerPoint на C# или .NET"
---
Aspose.Slides для .NET предоставляет 4 перегруженных [метода печати](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/print), которые позволяют распечатывать презентации. Перегруженные методы принимают разные аргументы, поэтому вы всегда найдете метод, который соответствует вашим потребностям в печати.

## **Печать на принтер по умолчанию**

Эта простая операция печати используется для распечатки всех слайдов в презентации PowerPoint через системный принтер по умолчанию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и передайте презентацию, которую хотите распечатать.
2. Вызовите метод [Print](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/print/#ipresentationprint-method-1-of-4) (без параметров). 

Этот код на C# показывает, как распечатать презентацию PowerPoint:

```c#
// Загружает презентацию
Presentation presentation = new Presentation("Print.ppt");

// Вызывает метод печати без параметров
presentation.Print();
```

## **Печать на конкретный принтер**

Эта операция используется для распечатки всех слайдов в презентации PowerPoint через конкретный принтер.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и передайте презентацию, которую хотите распечатать.
2. Вызовите метод печати и передайте имя принтера в виде строки.

Этот код на C# показывает, как распечатать презентацию PowerPoint, используя конкретный принтер:

```c#
try
{
    // Загружает презентацию
    Presentation presentation = new Presentation("Print.ppt");

    // Вызывает метод печати с именем принтера 
    presentation.Print("Пожалуйста, установите имя вашего принтера здесь");

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message + "\nПожалуйста, установите имя принтера как строковый параметр для метода печати Presentation");
}
```

## **Динамическая настройка параметров печати**

Используя свойства класса [PrinterSettings](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings?view=dotnet-plat-ext-6.0), вы можете применить параметры, которые определяют операцию печати. Вы можете указать, сколько копий следует напечатать, должны ли слайды печататься в альбомной или портретной ориентации, ваши предпочтительные поля и т. д.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и передайте презентацию, которую хотите распечатать.
2. Создайте экземпляр класса [PrinterSettings](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings?view=dotnet-plat-ext-6.0).
3. Укажите ваши предпочтительные параметры для операции печати:
   * количество копий
   * ориентация страницы
   * поля и т. д.
4. Вызовите метод `Print`.

Этот код на C# показывает, как распечатать презентацию PowerPoint с определенными параметрами печати:

```c#
using (Presentation pres = new Presentation())
{
	PrinterSettings printerSettings = new PrinterSettings();
	printerSettings.Copies = 2;
	printerSettings.DefaultPageSettings.Landscape = true;
	printerSettings.DefaultPageSettings.Margins.Left = 10;
	   //...и т. д.
	pres.Print(printerSettings);
}
```