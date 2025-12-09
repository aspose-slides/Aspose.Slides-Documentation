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
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в .NET с помощью Aspose.Slides, предоставляя быстрые примеры кода C# и расширенные параметры конвертации."
---

## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на C# предоставляет множество преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для преобразования и применять стандарты соответствия к результирующим документам.

## **PowerPoint в PDF Конверсии**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в конструктор класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и затем сохраните презентацию как PDF с помощью метода [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) предоставляет метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), который обычно используется для преобразования презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в виде "*Aspose.Slides v XX.XX*". **Обратите внимание**, что изменить или удалить эту информацию из выходных документов нельзя.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты рендерятся точно при конвертации, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конверсии PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки с максимальным качеством.

Следующий код на C# показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:
```c#
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Сохраните презентацию в формате PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose предлагает бесплатный онлайн‑конвертер **PowerPoint в PDF**[https://products.aspose.app/slides/conversion/ppt-to-pdf](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс конверсии презентации в PDF. Вы можете протестировать этот конвертер для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с Параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — которые позволяют настроить результирующий PDF, защитить PDF паролем или указать, как должен проходить процесс конверсии.

### **Конвертировать PowerPoint в PDF с Пользовательскими Параметрами**

С помощью пользовательских параметров конверсии вы можете задать предпочтительные настройки качества растрированных изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже приведён пример кода, демонстрирующий конвертацию презентации PowerPoint в PDF с несколькими пользовательскими параметрами.
```c#
 // Создайте экземпляр класса PdfOptions.
var pdfOptions = new PdfOptions
{
    // Установите качество для JPG‑изображений.
    JpegQuality = 90,

    // Установите DPI для изображений.
    SufficientResolution = 300,

    // Установите поведение для метафайлов.
    SaveMetafilesAsPng = true,

    // Установите уровень сжатия текста для текстового содержимого.
    TextCompression = PdfTextCompression.Flate,

    // Задайте режим соответствия PDF.
    Compliance = PdfCompliance.Pdf15
};

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Сохраните презентацию как PDF‑документ.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Конвертировать PowerPoint в PDF со Скрытыми Слайдами**

Если презентация содержит скрытые слайды, вы можете использовать свойство [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в виде страниц в результирующий PDF.

Этот код на C# показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:
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


### **Конвертировать PowerPoint в Защищённый Паролем PDF**

Этот код на C# демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/):
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


### **Обнаружение Замены Шрифтов**

Aspose.Slides предоставляет свойство [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), позволяющее обнаруживать замену шрифтов во время процесса конверсии презентации в PDF.

Этот код на C# показывает, как обнаружить замену шрифтов:
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

Для получения дополнительной информации о получении обратных вызовов при замене шрифтов во время процесса рендеринга см. [Получение обратных вызовов при замене шрифтов](/slides/ru/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения дополнительной информации о замене шрифтов см. статью [Замена Шрифтов](/slides/ru/net/font-substitution/).

{{% /alert %}} 

## **Конвертировать Выбранные Слайды из PowerPoint в PDF**

Этот код на C# демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:
```c#
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Установите массив номеров слайдов.
int[] slides = { 1, 3 };

// Сохраните презентацию в PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **Конвертировать PowerPoint в PDF с Пользовательским Размером Слайда**

Этот код на C# демонстрирует, как конвертировать презентацию PowerPoint в PDF с указанным размером слайда:
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


## **Конвертировать PowerPoint в PDF в Представлении Слайдов с Заметками**

Этот код на C# демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:
```c#
// Загрузите презентацию PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Настройте параметры PDF с расположением заметок.
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


## **Доступность и Стандарты Соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конверсии, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Следующий код на C# демонстрирует процесс конверсии PowerPoint в PDF, создающий несколько PDF‑файлов в соответствии с различными стандартами соответствия:
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

Aspose.Slides поддерживает операции конверсии PDF, позволяя вам конвертировать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Другие операции конверсии PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конверсию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конверсии.

**Можно ли защитить полученный PDF паролем?**

Безусловно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) для установки пароля и определения прав доступа во время процесса конверсии.

**Как включить скрытые слайды в PDF?**

Установите свойство `ShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) в значение `true`, чтобы включить скрытые слайды в результирующий PDF.

**Сможет ли Aspose.Slides поддерживать высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, задавая свойства такие как `JpegQuality` и `SufficientResolution` в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) для обеспечения высокого качества изображений в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные Ресурсы**

- [Документация Aspose.Slides for .NET](/slides/ru/net/)
- [Ссылка на API Aspose.Slides for .NET]https://reference.aspose.com/slides/net/
- [Бесплатные Онлайн‑Конвертеры Aspose]https://products.aspose.app/slides/conversion