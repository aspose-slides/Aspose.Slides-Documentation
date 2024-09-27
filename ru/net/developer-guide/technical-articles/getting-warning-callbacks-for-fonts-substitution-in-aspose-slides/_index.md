---
title: Получение обработчиков предупреждений для замены шрифтов в Aspose.Slides
type: docs
weight: 120
url: /ru/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides для .NET позволяет получать обработчики предупреждений для замены шрифтов в случае, если используемый шрифт недоступен на машине в процессе рендеринга. Обработчики предупреждений полезны для отладки проблем с отсутствующими или недоступными шрифтами во время рендеринга.

{{% /alert %}} 
## **Получение обработчиков предупреждений для замены шрифтов**
Aspose.Slides для .NET предоставляет простые методы API для получения обработчиков предупреждений во время процесса рендеринга. Все, что вам нужно сделать, это следовать приведенным ниже шагам, чтобы настроить обработчики предупреждений на вашей стороне:

1. Создайте класс обратного вызова для получения обработчиков.
1. Установите обработчики предупреждений, используя класс LoadOptions
1. Загрузите файл презентации, в котором используется шрифт для текста, который недоступен на вашей целевой машине.
1. Сгенерируйте миниатюру слайда, чтобы увидеть эффект.

```c#
//Установка обработчиков предупреждений
LoadOptions lo = new LoadOptions();
lo.WarningCallback = new HandleFontsWarnings();

//Создание презентации
Presentation presentation = new Presentation("1.ppt", lo);

//Генерация миниатюры слайда
foreach (ISlide slide in presentation.Slides)
{
    Image image = slide.GetThumbnail();
}
```

```c#
class HandleFontsWarnings : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        Console.WriteLine(warning.WarningType); // 1 - WarningType.DataLoss
        Console.WriteLine(warning.Description); // "Шрифт будет заменен с X на Y"
        return ReturnAction.Continue;
    }
}
```