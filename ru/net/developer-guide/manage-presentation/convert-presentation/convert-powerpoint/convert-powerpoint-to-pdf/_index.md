---
title: Конвертировать PPT и PPTX в PDF в .NET [включены расширенные функции]
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
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в .NET с помощью Aspose.Slides, с быстрыми примерами кода C# и расширенными параметрами конвертации."
---

## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.п.) в формат PDF в C# предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования презентации. Это руководство демонстрирует, как конвертировать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к результирующим документам.

## **Преобразование PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и затем сохраните презентацию как PDF с помощью метода [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) предоставляет метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), который обычно используется для преобразования презентации в PDF.

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Aspose.Slides for .NET вставляет информацию о своём API и номер версии в выходные документы. Например, при преобразовании презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в формате "*Aspose.Slides v XX.XX*". **Обратите внимание**, что вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Весь набор слайдов в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки на максимальном уровне качества.

Этот код C# показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.п.) в PDF:
```c#
 // Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
 using var presentation = new Presentation("PowerPoint.ppt");

// Save the presentation as a PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose предлагает бесплатный онлайн‑инструмент [**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Вы можете протестировать конвертер для живой реализации процедуры, описанной здесь.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет настраиваемые параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — которые позволяют изменять получаемый PDF, защищать его паролем или задавать порядок выполнения процесса конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, определить способ обработки метафайлов, установить уровень сжатия текста, задать DPI для изображений и многое другое.

Ниже приведён пример кода, демонстрирующий, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.
```c#
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


### **Конвертация PowerPoint в PDF со скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать свойство [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) для включения скрытых слайдов как страниц в результирующий PDF.

Этот код C# показывает, как конвертировать презентацию PowerPoint в PDF со скрытыми слайдами:
```c#
 // Actually no leading spaces: 

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

Этот код C# демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/):
```c#
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

Aspose.Slides предоставляет свойство [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), позволяющее обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Этот код C# показывает, как обнаружить замену шрифтов:
```c#
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


{{%  alert color="primary"  %}} 

Для получения обратных вызовов при заменах шрифтов во время рендеринга см. [Получение предупреждающих обратных вызовов для замены шрифтов](/slides/ru/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для более подробной информации о замене шрифтов см. статью [Замена шрифтов](/slides/ru/net/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов PowerPoint в PDF**

Этот код C# демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:
```c#
// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Задать массив номеров слайдов.
int[] slides = { 1, 3 };

// Сохранить презентацию как PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Этот код C# демонстрирует, как конвертировать презентацию PowerPoint в PDF с указанным размером слайда:
```c#
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

// Сохранить изменённую презентацию в PDF с заметками.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```


## **Конвертация PowerPoint в PDF в режиме заметок слайда**

Этот код C# демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:
```c#
// Загрузить презентацию PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Настроить параметры PDF с размещением заметок.
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


## **Доступность и стандарты соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководствам по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

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

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию множества файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Абсолютно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) для установки пароля и определения разрешений доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Установите свойство `ShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) в значение `true`, чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, задавая свойства такие как `JpegQuality` и `SufficientResolution` в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), чтобы обеспечить высокое качество изображений в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for .NET](/slides/ru/net/)
- [Ссылка на API Aspose.Slides for .NET](https://reference.aspose.com/slides/net/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)