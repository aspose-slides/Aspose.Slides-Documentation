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
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в .NET с использованием Aspose.Slides, с быстрыми примерами кода на C# и расширенными параметрами конвертации."
---

## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на C# предлагает ряд преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в документы PDF, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замены шрифтов, выбирать отдельные слайды для конвертации и применять стандарты соответствия к итоговым документам.

## **Конвертация PowerPoint в PDF**

Используя Aspose.Slides, вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) , а затем сохраните презентацию как PDF, используя метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Класс [Presentation] предоставляет метод [Save], который обычно используется для конвертации презентации в PDF.

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Aspose.Slides for .NET вставляет информацию о своей API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в форме "*Aspose.Slides v XX.XX*". **Примечание** , что вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально точное совпадение полученных PDF с оригинальными презентациями. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки при максимальном качестве.

Этот код C# показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:
```c#
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Сохраните презентацию в формате PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose предлагает бесплатный онлайн **конвертер PowerPoint в PDF**(https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — которые позволяют настроить получаемый PDF, защитить PDF паролем или указать, как должен происходить процесс конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Пример кода ниже демонстрирует, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.
```c#
// Создайте экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions
{
    // Установите качество JPG‑изображений.
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

// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Сохраните презентацию как PDF‑документ.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Конвертация PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете воспользоваться свойством [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) , чтобы включить скрытые слайды в виде страниц в получаемом PDF.

Этот код C# показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:
```c#
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Создайте экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions();

// Добавьте скрытые слайды.
pdfOptions.ShowHiddenSlides = true;

// Сохраните презентацию в формате PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Конвертация PowerPoint в защищённый паролем PDF**

Этот код C# демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) :
```c#
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Создайте экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions();

// Установите пароль PDF и права доступа.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Сохраните презентацию в формате PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет свойство [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) , позволяющее обнаружить замены шрифтов во время процесса конвертации презентации в PDF.

Этот код C# показывает, как обнаружить замены шрифтов:
```c#
public static void Main()
{
    // Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument. 
    using var presentation = new Presentation("sample.pptx");

    // Установите обработчик предупреждений в параметрах PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Сохраните презентацию в формате PDF.
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

Для получения дополнительной информации о получении обратных вызовов при заменах шрифтов во время процесса рендеринга см. [Getting Warning Callbacks for Fonts Substitution](/slides/ru/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/net/font-substitution/) .

{{% /alert %}} 

## **Конвертация выбранных слайдов PowerPoint в PDF**

Этот код C# демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:
```c#
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Задайте массив номеров слайдов.
int[] slides = { 1, 3 };

// Сохраните презентацию в формате PDF.
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
// Загрузить презентацию PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Настроить параметры PDF с разметкой заметок.
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


## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код C# демонстрирует процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов на основе разных стандартов соответствия:
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


{{% alert title="Примечание" color="warning" %}} 

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), и [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), и [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

## **ЧаВо**

**Могу ли я конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конвертации.

**Можно ли защитить парольем полученный PDF?**

Абсолютно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) , чтобы установить пароль и задать разрешения доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Установите свойство `ShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) в значение `true`, чтобы включить скрытые слайды в получаемый PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, задавая свойства такие как `JpegQuality` и `SufficientResolution` в классе [PdfOptions] , чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для .NET](/slides/ru/net/)
- [Справочник API Aspose.Slides для .NET](https://reference.aspose.com/slides/net/)
- [Бесплатные онлайн-конвертеры Aspose](https://products.aspose.app/slides/conversion)