---
title: Конвертировать PPT и PPTX в PDF в .NET [Включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/net/convert-powerpoint-to-pdf/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- PowerPoint в PDF
- презентацию в PDF
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
description: "Конвертировать PowerPoint PPT/PPTX в PDF высокого качества, поддерживающие поиск, в .NET с помощью Aspose.Slides, используя быстрые примеры кода на C# и расширенные параметры конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF с помощью C# предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как преобразовать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF паролем, определять замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к результатным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и затем сохраните презентацию как PDF с помощью метода [Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) предоставляет метод [Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/), который обычно используется для конвертации презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides для .NET вставляет свои сведения об API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer — значением в формате "*Aspose.Slides v XX.XX*". **Обратите внимание**, что вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально близкое соответствие полученных PDF оригинальным презентациям. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые блоки и формы
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать указанную презентацию в PDF, используя оптимальные настройки с максимальным качеством.

Следующий код C# показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:

```c#
// Создайте объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Сохраните презентацию в формате PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose предлагает бесплатный онлайн‑инструмент **конвертера PowerPoint в PDF**[https://products.aspose.app/slides/ru/conversion/ppt-to-pdf], который демонстрирует процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/) — которые позволяют настроить получаемый PDF, защитить PDF паролем или указать, как должен происходить процесс конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров конвертации вы можете задать предпочтительные настройки качества растровых изображений, определить, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже показан пример кода, который демонстрирует, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.

```c#
// Создайте экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions
{
    // Установите качество для JPG‑изображений.
    JpegQuality = 90,

    // Установите DPI для изображений.
    SufficientResolution = 300,

    // Установите режим обработки метафайлов.
    SaveMetafilesAsPng = true,

    // Установите уровень сжатия текста для текстового контента.
    TextCompression = PdfTextCompression.Flate,

    // Определите режим соответствия PDF.
    Compliance = PdfCompliance.Pdf15
};

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Сохраните презентацию в виде PDF‑документа.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Конвертация PowerPoint в PDF с включенными скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать свойство [ShowHiddenSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в качестве страниц в результирующем PDF.

Следующий код C# показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

```c#
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Создайте экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions();

// Добавьте скрытые слайды.
pdfOptions.ShowHiddenSlides = true;

// Сохраните презентацию в PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Конвертация PowerPoint в PDF с паролем**

Этот код C# демонстрирует, как преобразовать презентацию PowerPoint в защищённый паролем PDF, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/):

```c#
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Создайте экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions();

// Установите пароль PDF и разрешения доступа.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Сохраните презентацию в PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет свойство [WarningCallback](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveoptions/warningcallback/) в классе [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/), позволяющее обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Следующий код C# показывает, как обнаружить замену шрифтов:

```c#
public static void Main()
{
    // Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
    using var presentation = new Presentation("sample.pptx");

    // Установите обработчик предупреждений в параметрах PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Сохраните презентацию в PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Реализация обработчика предупреждений.
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

{{%  alert color="primary"  %}} 

Для получения более подробной информации о получении колбэков при замене шрифтов во время рендеринга см. [Получение предупреждающих колбэков для замены шрифтов](/slides/ru/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения дополнительной информации о замене шрифтов см. статью [Замена шрифтов](/slides/ru/net/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов PowerPoint в PDF**

Этот код C# демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:

```c#
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Set array of slide numbers.
int[] slides = { 1, 3 };

// Save the presentation as a PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Этот код C# демонстрирует, как конвертировать презентацию PowerPoint в PDF с указанным размером слайда:

```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **Конвертация PowerPoint в PDF в режиме заметок слайдов**

Этот код C# демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:

```c#
// Загрузите презентацию PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Настройте параметры PDF с раскладкой заметок.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Сохраните презентацию в PDF с заметками.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Доступность и стандарты соответствия PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Следующий код C# демонстрирует процесс конвертации PowerPoint в PDF, который создаёт несколько PDF‑файлов в соответствии с различными стандартами соответствия:

```c#
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

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/ru/net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/ru/net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/ru/net/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/ru/net/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/ru/net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/ru/net/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/ru/net/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть отмечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Безусловно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/) для установки пароля и определения разрешений доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Установите свойство `ShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/) в значение `true`, чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, задавая свойства такие как `JpegQuality` и `SufficientResolution` в классе [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF‑файлы, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы отвечают требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for .NET](/slides/ru/net/)
- [Ссылка на API Aspose.Slides for .NET](https://reference.aspose.com/slides/ru/net/)
- [Бесплатные онлайн‑конвертеры Aspose]https://products.aspose.app/slides/ru/conversion