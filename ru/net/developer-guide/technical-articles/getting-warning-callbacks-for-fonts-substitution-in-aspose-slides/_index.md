---
title: Получить обратные вызовы предупреждений для замены шрифтов в .NET
type: docs
weight: 120
url: /ru/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- обратный вызов предупреждения
- замена шрифтов
- процесс рендеринга
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как получать обратные вызовы предупреждений для замены шрифтов в Aspose.Slides для .NET и точно отображать презентации PowerPoint и OpenDocument."
---

## **Обзор**

Aspose.Slides for .NET позволяет получать обратные вызовы предупреждений о замене шрифтов, когда требуемый шрифт недоступен на машине во время рендеринга. Эти обратные вызовы помогают диагностировать проблемы с отсутствующими или недоступными шрифтами.

## **Включение обратных вызовов предупреждений**

Aspose.Slides for .NET предоставляет простые API для получения обратных вызовов предупреждений при рендеринге слайдов презентации. Выполните следующие шаги, чтобы настроить обратные вызовы предупреждений:

1. Создайте пользовательский класс обратного вызова, реализующий интерфейс [IWarningCallback](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarningcallback/) для обработки предупреждений.
2. Установите обратный вызов предупреждений, используя классы параметров, такие как [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) и другие.
3. Загрузите презентацию, использующую шрифт, недоступный на целевой машине.
4. Создайте миниатюру слайда или экспортируйте презентацию, чтобы увидеть результат.

**Пользовательский класс обратного вызова предупреждений:**
```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Пример вывода:
//
// Шрифт будет заменён с XYZ на {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```


**Создать миниатюру слайда:**
```c#
// Настройте обратный вызов предупреждений для обработки предупреждений, связанных со шрифтами, во время рендеринга слайдов.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Загрузите презентацию из указанного пути к файлу.
using var presentation = new Presentation("sample.pptx");

// Сгенерируйте миниатюрное изображение для каждого слайда в презентации.
foreach (var slide in presentation.Slides)
{
    // Получите миниатюру слайда, используя указанные параметры рендеринга.
    using var image = slide.GetImage(options);
    // ...
}
```


**Экспорт в формат PDF:**
```c#
// Настройте обратный вызов предупреждений для обработки предупреждений, связанных со шрифтами, при экспорте в PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Загрузите презентацию из указанного пути к файлу.
using var presentation = new Presentation("sample.pptx");

// Экспортируйте презентацию в PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```


**Экспорт в формат HTML:**
```c#
// Настройте обратный вызов предупреждений для обработки предупреждений, связанных со шрифтами, при экспорте в HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Загрузите презентацию из указанного пути к файлу.
using var presentation = new Presentation("sample.pptx");

// Экспортируйте презентацию в формате HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```
