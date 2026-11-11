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
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в PDF высокого качества, позволяющие поиск, в .NET с использованием Aspose.Slides, с быстрыми примерами кода C# и расширенными параметрами конверсии."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и др.) в формат PDF на C# предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать определённые слайды для конвертации и применять стандарты соответствия к получаемым документам.

## **Конверсии PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) предоставляет метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET вставляет информацию о своём API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer — значением в форме "*Aspose.Slides v XX.XX*". **Note** что вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая плотное соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты точно воспроизводятся при конвертации, включая:

* Изображения
* Текстовые поля и формы
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конверсии PowerPoint‑в‑PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать указанную презентацию в PDF, используя оптимальные настройки при максимальном уровне качества.

Следующий пример загружает презентацию и сохраняет все видимые слайды в PDF, используя параметры экспорта по умолчанию.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose предлагает бесплатный онлайн‑[**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конверсии презентации в PDF. Вы можете протестировать его для живой реализации описанной здесь процедуры.
{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), позволяющие настроить получаемый PDF, защитить PDF паролем или указать, как должна проходить конверсия.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конверсии, вы можете задать предпочтительное качество растровых изображений, указать способ обработки метафайлов, установить уровень сжатия текста, задать DPI для изображений и т.д.

Следующий пример экспортирует презентацию в PDF 1.5 с качеством JPEG = 90, разрешением изображений = 300 DPI, сохраняет метафайлы в PNG и использует сжатие текста Flate.

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

> **Note:** Вы можете улучшить качество рендеринга теней и эффектов отражения текста при конвертации в PDF, задав `PdfOptions.SufficientResolution` более высоким значением (например, `300`). Это приводит к PDF‑выводу, более точно соответствующему внешнему виду в Microsoft PowerPoint.

### **Автоматический выбор сжатия изображений**

Когда в презентации содержится множество фотографий или скриншотов, уменьшение размера экспортированного PDF упрощает его отправку по почте или загрузку. Установите [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) в `true`, чтобы автоматически выбирать наиболее подходящий алгоритм сжатия для каждого изображения при экспорте в PDF.

Следующий пример загружает существующую презентацию, включает автоматический выбор сжатия изображений и сохраняет её в PDF‑документ. Все остальные параметры экспорта PDF сохраняют значения по умолчанию.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Этот параметр выбирает алгоритм сжатия для каждого изображения. Понижение [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) уменьшает качество JPEG‑изображений, а понижение [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) позволяет уменьшать разрешение изображений, что может сократить детализацию. Включение автоматического выбора сжатия само по себе не уменьшает ни один из этих параметров.

Выбор алгоритмов сжатия изображений требует дополнительных процессорного времени и памяти. Степень уменьшения размера зависит от изображений в презентации и настроек экспорта; фиксированное сокращение не гарантировано для каждой презентации.

### **Сохранить встроенные OLE‑файлы как вложения PDF**

Если в презентации присутствует встроенная рабочая книга Excel, получатели PDF могут захотеть получить доступ к данным книги, а также просмотреть слайды. Установите [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) в `true`, чтобы сохранять встроенные OLE‑файлы как вложения в получаемом PDF.

Значение по умолчанию — `false`: изображение‑предпросмотр или значок OLE‑объекта отображается на странице PDF, но сам вложенный файл не включается как вложение. При установке параметра в `true` дополнительно включаются данные файла. Предпросмотр остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не превращается в интерактивный лист Excel на странице PDF.

Следующий пример загружает презентацию, уже содержащую встроенную рабочую книгу Excel, и экспортирует её в PDF с вложенной книгой.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Чтобы проверить результат:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Attachments** и найдите встроенную рабочую книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, либо откройте напрямую, если просмотрщик позволяет это.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает встроенные файлы, PDF/A‑2 допускает только вложения PDF/A, а PDF/A‑3 допускает другие типы файлов, включая рабочие книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. Пример использует значение соответствия PDF по умолчанию и не демонстрирует экспорт в PDF/A.
{{% /alert %}}

### **Конвертировать PowerPoint в PDF с скрытыми слайдами**

Если в презентации имеются скрытые слайды, вы можете использовать свойство [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), чтобы включить скрытые слайды как страницы в получаемом PDF.

Следующий пример экспортирует презентацию в PDF, включая любые скрытые слайды.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Конвертировать PowerPoint в PDF, защищённый паролем**

Следующий пример экспортирует презентацию в PDF, для открытия которого требуется пароль `password`. Права доступа позволяют печать, включая печать высокого качества.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Обнаружить замену шрифтов**

Aspose.Slides предоставляет свойство [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), позволяющее обнаружить замену шрифтов во время процесса конверсии презентации в PDF.

Следующий пример экспортирует презентацию в PDF и выводит предупреждения о замене шрифтов в консоль. Предупреждение выводится только тогда, когда недоступный шрифт заменяется при экспорте.

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

### **Обрабатывать шрифты без отдельного жирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у шрифта нет отдельного жирного начертания. Текст может выглядеть жирным за счёт синтетического удвоения, которое искусственно утолщает обычные глифы. Если такой текст выглядит слишком тяжёлым или иначе отличается от желаемого вида в PDF, попробуйте установить [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) в `true`. Эта опция рендерит затронутый текст как растровое изображение при экспорте в PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `false`.

В демонстрационной презентации два текстовых блока: один с обычным текстом и один с полужирным форматированием того же шрифта, у которого нет отдельного жирного начертания. Следующий пример загружает презентацию, включает растеризацию неподдерживаемых стилей шрифтов и экспортирует её в PDF:

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

Следующие превью показывают вывод с отключённой и включённой опцией. В этом примере полужирный текст имеет более тяжёлые штрихи при отключённой опции. При включённой опции штрихи становятся легче; обычный текст остаётся без изменений. Сравните результаты перед выбором настройки для вашей презентации.

| Параметр отключён (`false`, значение по умолчанию) | Параметр включён (`true`) |
|---|---|
| ![PDF с отключённым растеризацией неподдерживаемых стилей шрифта](unsupported-bold-disabled.png) | ![PDF с включённым растеризацией неподдерживаемых стилей шрифта](unsupported-bold-enabled.png) |

В этом примере включение опции превращает только полужирный текст в растровое изображение: его нельзя выделять, копировать или искать как текст без OCR, а его контуры выглядят мягче при масштабировании 800 %. Обычный текст остаётся доступным для поиска. При отключённой опции обе строки остаются текстом.

Эта опция растеризует текст, отформатированный как полужирный, когда у шрифта нет отдельного жирного начертания. [Замена шрифтов](/slides/ru/net/font-substitution/) вместо этого выбирает другой шрифт, если оригинальный недоступен.

## **Конвертировать выбранные слайды PowerPoint в PDF**

Следующий пример экспортирует слайды 1 и 3 из презентации в PDF. Номера слайдов в массиве начинаются с 1, и входная презентация должна содержать как минимум три слайда.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Следующий пример копирует первый слайд из презентации в новую презентацию с размером слайда 612 × 792 пунктов (8,5 × 11 дюймов). Он масштабирует содержимое слайда, чтобы оно помещалось, и экспортирует одиночный слайд в PDF.

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

## **Конвертировать PowerPoint в PDF в режиме заметок к слайдам**

Следующий пример экспортирует презентацию в PDF, размещая заметки докладчика под каждым слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

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

Aspose.Slides позволяет использовать процедуру конверсии, соответствующую [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код C# демонстрирует процесс конверсии PowerPoint‑в‑PDF, который создает несколько PDF‑файлов на основе разных стандартов соответствия:

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
Aspose.Slides поддерживает операции конверсии PDF, позволяя конвертировать PDF‑файлы в популярные форматы. Вы можете выполнять [PDF в HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) конверсии. Другие операции конверсии PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — также поддерживаются.
{{% /alert %}}

> **Note:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как отдельную фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**  
Да, Aspose.Slides поддерживает пакетную конверсию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конверсии.

**Можно ли защитить полученный PDF паролем?**  
Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) для установки пароля и определения прав доступа во время процесса конверсии.

**Как включить скрытые слайды в PDF?**  
Установите свойство [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) в `true`, чтобы включить скрытые слайды в получаемом PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**  
Да, вы можете контролировать качество изображений, устанавливая такие свойства, как [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) и [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**  
Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для .NET](/slides/ru/net/)
- [Справочник API Aspose.Slides для .NET](https://reference.aspose.com/slides/net/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)

Связанная функция: [Экспорт презентаций в PDF](/slides/ru/features/pdf-export/).