---
title: Преобразование PPT и PPTX в PDF в .NET [включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/net/convert-powerpoint-to-pdf/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- PowerPoint в PDF
- презентацию в PDF
- PPT в PDF
- преобразовать PPT в PDF
- PPTX в PDF
- преобразовать PPTX в PDF
- сохранить PowerPoint как PDF
- сохранить PPT как PDF
- сохранить PPTX как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Преобразуйте PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в .NET с помощью Aspose.Slides, используя быстрые примеры кода на C# и расширенные параметры преобразования."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF в C# предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как преобразовать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для преобразования и применять стандарты соответствия к результирующим документам.

## **Преобразования PowerPoint в PDF**

Используя Aspose.Slides, вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы преобразовать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и затем сохраните презентацию как PDF с помощью метода [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) предоставляет метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), который обычно используется для преобразования презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET вставляет информацию о своём API и номер версии в выходные документы. Например, при преобразовании презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer значением в форме "*Aspose.Slides v XX.XX*". **Примечание**: вы не можете указать Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет вам преобразовывать:
* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая точное соответствие получаемых PDF оригинальным презентациям. Элементы и атрибуты отображаются точно при преобразовании, включая:
* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркированные списки
* Таблицы

## **Преобразование PowerPoint в PDF**

Стандартный процесс преобразования PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки с максимальными уровнями качества.

В следующем примере загружается презентация и сохраняются все видимые слайды в PDF с использованием настроек экспорта по умолчанию.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose предоставляет бесплатный онлайн [**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Вы можете выполнить тест с этим конвертером для практической реализации описанной здесь процедуры.
{{% /alert %}}

## **Преобразование PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), которые позволяют настроить результирующий PDF, защитить PDF паролем или указать, как должен проходить процесс преобразования.

### **Преобразование PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры преобразования, вы можете задать предпочтительные настройки качества растровых изображений, указать способ обработки метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

В следующем примере презентация экспортируется в PDF 1.5 с качеством JPEG, установленным на 90, разрешением изображения 300 DPI, метафайлы сохраняются как PNG и используется сжатие текста Flate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Сохранить вложенные OLE‑файлы в виде вложений PDF**

Если презентация содержит встроенную книгу Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным книги, а также просматривать слайды. Установите [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) в `true`, чтобы сохранить вложенные OLE‑файлы в виде вложений в результирующем PDF.

Значение по умолчанию — `false`: изображение предварительного просмотра OLE‑объекта или его значок отображаются на странице PDF, но встроенный файл не включается как вложение. Установка параметра в `true` дополнительно включает данные файла. Предпросмотр остаётся визуальным представлением; вложение позволяет получателям открывать или сохранять встроенный файл отдельно. OLE‑объект не превращается в интерактивный лист Excel на странице PDF.

В следующем примере загружается презентация, уже содержащая встроенную книгу Excel, и экспортируется в PDF с прикреплённой книгой.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Чтобы проверить результат:
1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Вложения** в просмотрщике и найдите встроенную книгу.
3. Сохраните вложение и откройте его в Excel, чтобы проверить данные, или откройте его напрямую, если просмотрщик позволяет. Предпросмотр на странице PDF отделён от вложения.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A-1 запрещает встроенные файлы, PDF/A-2 допускает только вложения PDF/A, а PDF/A-3 допускает другие типы файлов, включая книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. В этом примере используется настройка соответствия PDF по умолчанию и не демонстрируется экспорт PDF/A.
{{% /alert %}}

### **Преобразование PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать свойство [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), чтобы включить скрытые слайды как страницы в результирующий PDF.

В следующем примере презентация экспортируется в PDF с включением всех скрытых слайдов.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Преобразование PowerPoint в PDF, защищённый паролем**

В следующем примере презентация экспортируется в PDF, который требует пароль `password` для открытия. Права доступа позволяют печать, включая печать высокого качества.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет свойство [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), позволяющее обнаружить замену шрифтов во время процесса преобразования презентации в PDF.

В следующем примере презентация экспортируется в PDF, а предупреждения о замене шрифтов выводятся в консоль. Предупреждение выводится только при замене недоступного шрифта во время экспорта.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
Для получения дополнительной информации о замене шрифтов см. статью [Замена шрифтов](/slides/ru/net/font-substitution/).
{{% /alert %}} 

### **Обработка шрифтов без отдельного жирного начертания**

Презентация может применять жирное форматирование к тексту, даже если у шрифта нет отдельного жирного начертания. Текст всё равно может выглядеть жирным за счёт синтетического жирного начертания, которое искусственно утолщает обычные глифы. Если такой текст выглядит слишком тяжёлым или иначе отличается от ожидаемого вида в PDF, попробуйте установить [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) в `true`. Этот параметр рендерит затронутый текст как растровое изображение во время экспорта PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `false`.

Пример презентации содержит два текстовых блока: один с обычным текстом и один с применённым жирным форматом к тем же шрифту, у которого нет отдельного жирного начертания. В следующем примере презентация загружается, включается растрирование неподдерживаемых стилей шрифтов, и экспортируется в PDF:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

Ниже показаны предварительные просмотры вывода с отключённым и включённым параметром. В этом примере жирный текст имеет более тяжёлые штрихи при отключённом параметре. При включённом параметре его штрихи становятся легче; обычный текст остаётся без изменений. Сравните результаты перед тем, как выбрать настройку для вашей презентации.

| Параметр отключён (`false`, по умолчанию) | Параметр включён (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

В этом примере включение параметра превращает только жирный текст в растр: его нельзя выделить, скопировать или искать как текст без OCR, а его края выглядят мягче при увеличении 800 %. Обычный текст остаётся доступным для поиска. При отключённом параметре оба текста остаются текстовыми.

Этот параметр растрирует текст, отформатированный как жирный, когда у шрифта нет отдельного жирного начертания. Вместо этого [Замена шрифтов](/slides/ru/net/font-substitution/) выбирает другой шрифт, когда оригинал недоступен.

## **Преобразование выбранных слайдов из PowerPoint в PDF**

В следующем примере экспортируются слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве начинаются с единицы, и входная презентация должна содержать как минимум три слайда.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Преобразование PowerPoint в PDF с пользовательским размером слайда**

В следующем примере первый слайд из презентации копируется в новую презентацию с размером слайда 612 × 792 пунктов (8,5 × 11 дюймов). Содержимое слайда масштабируется под размер и экспортируется как один слайд в PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Преобразование PowerPoint в PDF в представлении слайдов с нотами**

В следующем примере презентация экспортируется в PDF, размещая заметки докладчика каждого слайда под самим слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру преобразования, соответствующую [Руководствам по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

```csharp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides поддерживает операции преобразования PDF, позволяя конвертировать PDF‑файлы в популярные форматы. Вы можете выполнить преобразования [PDF в HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) и [PDF в PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Другие операции преобразования PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) и [PDF в XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — также поддерживаются.
{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**  
Да, Aspose.Slides поддерживает пакетное преобразование нескольких файлов PPT или PPTX в PDF. Вы можете перебрать файлы и программно применить процесс преобразования.

**Можно ли защитить полученный PDF паролем?**  
Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) для установки пароля и определения прав доступа во время процесса преобразования.

**Как включить скрытые слайды в PDF?**  
Установите свойство [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) в `true`, чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**  
Да, вы можете контролировать качество изображений, задавая свойства, такие как [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) и [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/), в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**  
Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы соответствуют требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для .NET](/slides/ru/net/)
- [Справочник API Aspose.Slides для .NET](https://reference.aspose.com/slides/net/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)