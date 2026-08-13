---
title: Конвертация PPT и PPTX в PDF в .NET [Включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/net/convert-powerpoint-to-pdf/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- PowerPoint в PDF
- презентация в PDF
- PPT в PDF
- конвертировать PPT в PDF
- PPTX в PDF
- конвертировать PPTX в PDF
- сохранить PowerPoint как PDF
- сохранить PPT как PDF
- сохранить PPTX как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в .NET с помощью Aspose.Slides, с быстрыми примерами кода C# и расширенными параметрами конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в PDF в C# дает несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к итоговым документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете преобразовать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в конструктор класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и затем сохраните презентацию как PDF с помощью метода [Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) предоставляет метод [Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/), обычно используемый для преобразования презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением вида "*Aspose.Slides v XX.XX*". **Примечание**: изменить или удалить эту информацию из выходных документов с помощью Aspose.Slides нельзя.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально точное соответствие полученных PDF оригинальным презентациям. При конвертации точно отображаются элементы и атрибуты, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркированные списки
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки с максимальным качеством.

Следующий код на C# показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Сохранить презентацию в PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose предлагает бесплатный онлайн‑инструмент **PowerPoint to PDF converter**[(https://products.aspose.app/slides/ru/conversion/ppt-to-pdf)](https://products.aspose.app/slides/ru/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Вы можете выполнить тест с этим конвертером для практической реализации описанной процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/), позволяющие настроить получаемый PDF, защитить его паролем или задать порядок выполнения конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров конвертации вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI изображений и многое другое.

Ниже приведён пример кода, демонстрирующий конвертацию презентации PowerPoint в PDF с несколькими пользовательскими параметрами.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создать экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions
{
    // Установить качество для JPG‑изображений.
    JpegQuality = 90,

    // Установить DPI для изображений.
    SufficientResolution = 300,

    // Установить поведение для метафайлов.
    SaveMetafilesAsPng = true,

    // Установить уровень сжатия текста для текстового содержимого.
    TextCompression = PdfTextCompression.Flate,

    // Определить режим соответствия PDF.
    Compliance = PdfCompliance.Pdf15
};

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Сохранить презентацию как PDF‑документ.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Конвертация PowerPoint в PDF с включёнными скрытыми слайдами**

Если в презентации есть скрытые слайды, вы можете использовать свойство [ShowHiddenSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в виде страниц в результирующем PDF.

Этот код на C# показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Создать экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions();

// Добавить скрытые слайды.
pdfOptions.ShowHiddenSlides = true;

// Сохранить презентацию как PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Конвертация PowerPoint в PDF, защищённый паролем**

Этот код на C# демонстрирует, как преобразовать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Создать экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions();

// Установить пароль PDF и разрешения доступа.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Сохранить презентацию как PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет свойство [WarningCallback](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveoptions/warningcallback/) в классе [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/), позволяющее обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Этот код на C# показывает, как обнаружить замену шрифтов:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument. 
    using var presentation = new Presentation("sample.pptx");

    // Установить обратный вызов предупреждения в параметрах PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Сохранить презентацию как PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Реализация обратного вызова предупреждения.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

Для получения дополнительных сведений о получении обратных вызовов при замене шрифтов во время рендеринга см. [Getting Warning Callbacks for Fonts Substitution](/slides/ru/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для более подробной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/net/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов PowerPoint в PDF**

Этот код на C# демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Задать массив номеров слайдов.
int[] slides = { 1, 3 };

// Сохранить презентацию как PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Этот код на C# демонстрирует, как конвертировать презентацию PowerPoint в PDF с указанным размером слайда:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// Загрузить презентацию PowerPoint.
using var presentation = new Presentation("SelectedSlides.pptx");

// Создать новую презентацию с изменённым размером слайда.
using var resizedPresentation = new Presentation();

// Установить пользовательский размер слайда.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Клонировать первый слайд из оригинальной презентации.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Удалить пустой слайд, который был создан в новой презентации.
resizedPresentation.Slides.RemoveAt(1);

// Сохранить изменённую презентацию как PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Конвертация PowerPoint в PDF в режиме заметок слайдов**

Этот код на C# демонстрирует, как преобразовать презентацию PowerPoint в PDF, включающий заметки:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Загрузить презентацию PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Настроить параметры PDF с расположением заметок.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Сохранить презентацию в PDF с заметками.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Доступность и стандарты соответствия PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A‑1a**, **PDF/A‑1b** и **PDF/UA**.

Следующий код на C# демонстрирует процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов в соответствии с различными стандартами соответствия:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнить конвертации [PDF to HTML](https://products.aspose.com/slides/ru/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/ru/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/ru/net/conversion/pdf-to-jpg/), и [PDF to PNG](https://products.aspose.com/slides/ru/net/conversion/pdf-to-png/). Поддерживаются также специализированные конвертации: [PDF to SVG](https://products.aspose.com/slides/ru/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/ru/net/conversion/pdf-to-tiff/), и [PDF to XML](https://products.aspose.com/slides/ru/net/conversion/pdf-to-xml/).

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единый объект. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всего объекта.

## **Часто задаваемые вопросы**

### Можно ли массово конвертировать несколько файлов PowerPoint в PDF?

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать файлы и применить процесс конвертации программно.

### Возможно ли защитить полученный PDF паролем?

Абсолютно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/) для задания пароля и определения прав доступа во время конвертации.

### Как включить скрытые слайды в PDF?

Установите свойство `ShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/) в значение `true`, чтобы включить скрытые слайды в результирующий PDF.

### Может ли Aspose.Slides сохранять высокое качество изображений в PDF?

Да, вы можете контролировать качество изображений, задавая свойства такие как `JpegQuality` и `SufficientResolution` в классе [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/), обеспечивая высокое качество изображений в PDF.

### Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A‑1a, PDF/A‑1b и PDF/UA, обеспечивая соответствие требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Aspose.Slides for .NET Documentation](/slides/ru/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/ru/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ru/conversion)