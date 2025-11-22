---
title: Преобразовать PPT и PPTX в PDF на C# [Включены расширенные возможности]
linktitle: Преобразовать PPT и PPTX в PDF
type: docs
weight: 40
url: /ru/net/convert-powerpoint-to-pdf/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- PowerPoint в PDF
- презентация в PDF
- PPT в PDF
- преобразовать PPT в PDF
- PPTX в PDF
- преобразовать PPTX в PDF
- ODP в PDF
- преобразовать ODP в PDF
- сохранить PowerPoint как PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C#
- Csharp
- .NET
- Aspose.Slides for .NET
description: "Узнайте, как преобразовать презентации PPT, PPTX и ODP в PDF на C# или .NET с помощью Aspose.Slides. Реализуйте расширенные функции, такие как защита паролем, стандарты соответствия и пользовательские параметры для создания PDF высокого качества и доступных документов."
---

## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на C# предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для конвертации и применять стандарты соответствия к итоговым документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла как аргумент классу [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) предоставляет метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), который обычно используется для преобразования презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET вставляет сведения о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer — значением вида "*Aspose.Slides v XX.XX*". **Примечание**: вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, гарантируя, что полученные PDF‑файлы максимально точно соответствуют оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые блоки и формы
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Преобразование PowerPoint в PDF**

Стандартный процесс преобразования PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки и максимальное качество.

Этот C#‑код показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:
```c#
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Сохраните презентацию в PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose предлагает бесплатный онлайн [**конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Вы можете протестировать этот конвертер для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Преобразование PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет настраиваемые параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), — которые позволяют вам адаптировать получаемый PDF, защищать PDF паролем или задавать порядок выполнения процесса конвертации.

### **Преобразование PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Пример кода ниже демонстрирует, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.
```c#
// Создайте экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions
{
    // Установите качество для JPG изображений.
    JpegQuality = 90,

    // Установите DPI для изображений.
    SufficientResolution = 300,

    // Установите поведение для метафайлов.
    SaveMetafilesAsPng = true,

    // Установите уровень сжатия текста для текстового содержимого.
    TextCompression = PdfTextCompression.Flate,

    // Определите режим соответствия PDF.
    Compliance = PdfCompliance.Pdf15
};

// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument файл.
using var presentation = new Presentation("PowerPoint.pptx");

// Сохраните презентацию как PDF документ.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Преобразование PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать свойство [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в виде страниц в результирующем PDF.

Этот C#‑код показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:
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


### **Преобразование PowerPoint в PDF, защищённый паролем**

Этот C#‑код демонстрирует, как преобразовать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/):
```c#
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Создайте экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions();

// Установите пароль PDF и права доступа.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Сохраните презентацию в PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет свойство [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), позволяя обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Этот C#‑код показывает, как обнаружить замену шрифтов:
```c#
public static void Main()
{
    // Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument file. 
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

Для получения обратных вызовов предупреждений при замене шрифтов во время процесса рендеринга см. [Получение обратных вызовов предупреждений для замены шрифтов](/slides/ru/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения дополнительной информации о замене шрифтов см. статью [Замена шрифтов](/slides/ru/net/font-substitution/).

{{% /alert %}} 

## **Преобразование выбранных слайдов из PowerPoint в PDF**

Этот C#‑код демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:
```c#
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Установите массив номеров слайдов.
int[] slides = { 1, 3 };

// Сохраните презентацию в PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **Преобразование PowerPoint в PDF с пользовательским размером слайда**

Этот C#‑код демонстрирует, как конвертировать презентацию PowerPoint в PDF с указанным размером слайда:
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


## **Преобразование PowerPoint в PDF в режиме заметок слайдов**

Этот C#‑код демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:
```c#
// Загрузите презентацию PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Configure the PDF options with Notes Layout.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Save the presentation to a PDF with notes.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот C#‑код демонстрирует процесс преобразования PowerPoint в PDF, создающий несколько PDF‑файлов на основе различных стандартов соответствия:
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

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Также поддерживаются другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/).

{{% /alert %}}

## **Вопросы и ответы**

**Могу ли я конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Абсолютно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) для задания пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Установите свойство `ShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) в значение `true`, чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, задавая такие свойства, как `JpegQuality` и `SufficientResolution` в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), чтобы обеспечить высокое качество изображений в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для .NET](/slides/ru/net/)
- [Справочник API Aspose.Slides для .NET](https://reference.aspose.com/slides/net/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)