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
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в .NET с использованием Aspose.Slides, с быстрыми примерами кода C# и расширенными параметрами конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и др.) в формат PDF на C# предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как конвертировать презентации в документы PDF, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для преобразования и применять стандарты соответствия к итоговым документам.

## **Конвертации PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), а затем сохраните презентацию как PDF, используя метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) предоставляет метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), который обычно используется для преобразования презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer — значением вида "*Aspose.Slides v XX.XX*". **Примечание**: вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая близкое соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты воспроизводятся точно, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркированные списки
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать указанную презентацию в PDF, используя оптимальные настройки на максимальном уровне качества.

Следующий пример загружает презентацию и сохраняет все видимые слайды в PDF, используя стандартные параметры экспорта.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose предлагает бесплатный онлайн‑[**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной процедуры.
{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), — позволяющие настроить полученный PDF, защитить PDF паролем или указать, как должен происходить процесс конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, конфигурировать DPI для изображений и многое другое.

Следующий пример экспортирует презентацию в PDF 1.5 с качеством JPEG, установленным в 90, разрешением изображения 300 DPI, сохраняет метафайлы в PNG и использует сжатие текста Flate.

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

### **Автоматический выбор сжатия изображений**

Когда в презентации содержится много фотографий или скриншотов, уменьшение размера экспортированного PDF может упростить отправку по электронной почте или загрузку. Установите [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) в `true`, чтобы автоматически выбирать наиболее подходящий алгоритм сжатия для каждого изображения во время экспорта PDF.

Следующий пример загружает существующую презентацию, включает автоматический выбор сжатия изображений и сохраняет её в PDF‑документ. Все остальные параметры экспорта PDF сохраняются со значениями по умолчанию.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Этот параметр выбирает алгоритм сжатия для каждого изображения. Понижение [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) уменьшает качество JPEG‑изображения, а понижение [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) позволяет понизить разрешение изображений, что может уменьшить детализацию. Включение автоматического выбора сжатия само по себе не меняет эти настройки.

Выбор алгоритмов сжатия изображений требует дополнительных ресурсов процессора и памяти. Снижение размера зависит от изображений в презентации и параметров экспорта; фиксированного снижения для каждой презентации не гарантируется.

### **Сохранить встроенные OLE‑файлы как вложения PDF**

Если в презентации есть встроенная книга Excel, вы можете захотеть, чтобы получатели PDF имели доступ к данным книги, а также могли просматривать слайды. Установите [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) в `true`, чтобы сохранить встроенные OLE‑файлы как вложения в результирующем PDF.

Значение по умолчанию — `false`: превью‑изображение или значок OLE‑объекта отображается на странице PDF, но сам встроенный файл не включается как вложение. Установка параметра в `true` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не становится интерактивным листом Excel на странице PDF.

Следующий пример загружает презентацию, уже содержащую встроенную книгу Excel, и экспортирует её в PDF с прикреплённой книгой.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Чтобы проверить результат:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например в Adobe Acrobat Reader.
2. Откройте панель **Attachments** просмотрщика и найдите встроенную книгу.
3. Сохраните вложение и откройте его в Excel, чтобы проверить данные, либо откройте напрямую, если просмотрщик позволяет. Превью на странице PDF отделено от вложения.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A-1 запрещает встроенные файлы, PDF/A-2 допускает только вложения PDF/A, а PDF/A-3 допускает прочие типы файлов, включая книги Excel. Это требования самих стандартов, а не ограничения, специфичные для Aspose.Slides. Пример использует настройку соответствия PDF по умолчанию и не демонстрирует экспорт в PDF/A.
{{% /alert %}}

### **Конвертировать PowerPoint в PDF с включением скрытых слайдов**

Если в презентации есть скрытые слайды, вы можете использовать свойство [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), чтобы включить скрытые слайды в виде страниц в результирующий PDF.

Следующий пример экспортирует презентацию в PDF, включая любые скрытые слайды.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Конвертировать PowerPoint в PDF с паролем**

Следующий пример экспортирует презентацию в PDF, требующий пароль `password` для открытия. Права доступа позволяют печатать, включая печать высокого качества.

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

Aspose.Slides предоставляет свойство [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), позволяющее обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Следующий пример экспортирует презентацию в PDF и выводит предупреждения о замене шрифтов в консоль. Предупреждение выводится только тогда, когда при экспорте недоступный шрифт заменяется другим.

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

### **Работа со шрифтами без отдельного полужирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у её шрифта нет отдельного полужирного начертания. Текст всё равно может выглядеть полужирным за счёт синтетического полужирного начертания, которое искусственно утолщает обычные глифы. Когда такой текст выглядит слишком тяжёлым или иначе отличается от желаемого отображения в PDF, попробуйте установить [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) в `true`. Этот параметр рендерит затронутый текст как растровое изображение при экспорте PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `false`.

В образце презентации два текстовых блока: один с обычным текстом, а второй с полужирным оформлением того же шрифта, у которого нет отдельного полужирного начертания. Следующий пример загружает презентацию, включает растеризацию неподдерживаемых стилей шрифтов и экспортирует её в PDF:

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

Ниже показаны превью с отключённым и включённым параметром. В этом примере при отключённом параметре полужирный текст имеет более тяжёлые штрихи. При включённом параметре штрихи становятся легче; обычный текст остаётся без изменений. Сравните результаты перед выбором настройки для вашей презентации.

| Параметр отключён (`false`, по умолчанию) | Параметр включён (`true`) |
|---|---|
| ![PDF с отключённым растеризацией неподдерживаемого стиля шрифта](unsupported-bold-disabled.png) | ![PDF с включённым растеризацией неподдерживаемого стиля шрифта](unsupported-bold-enabled.png) |

В данном примере включение параметра превращает только полужирный текст в растровое изображение: его нельзя выделять, копировать или искать как текст без OCR, а его края выглядят мягче при 800 % зуме. Обычный текст остаётся доступным для поиска. При отключённом параметре оба фрагмента остаются текстом.

Этот параметр растеризует текст, отформатированный как полужирный, когда у шрифта нет отдельного полужирного начертания. [Замена шрифтов](/slides/ru/net/font-substitution/) вместо этого выбирает другой шрифт, если оригинальный недоступен.

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

Следующий пример копирует первый слайд из презентации в новую презентацию с размером слайда 612 × 792 points (8,5 × 11 дюймов). Он масштабирует содержимое слайда, чтобы оно помещалось, и экспортирует единичный слайд в PDF.

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

## **Конвертировать PowerPoint в PDF в режиме заметок слайда**

Следующий пример экспортирует презентацию в PDF, размещая заметки докладчика каждого слайда под самим слайдом. Используйте презентацию с заметками докладчика, чтобы увидеть результат.

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

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код C# демонстрирует процесс конвертации PowerPoint в PDF, который генерирует несколько PDF‑файлов в соответствии с различными стандартами соответствия:

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
Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять [PDF в HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) конвертации. Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — также поддерживаются.
{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides обрабатывает сложную графику, такую как SmartArt, диаграммы и формулы, как единый объект. Отдельные элементы контура не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всего объекта.

## **FAQ**

**Можно ли преобразовать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетное преобразование нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Установите свойство [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) в `true`, чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, задав свойства такие как [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) и [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Additional Resources**

- [Документация Aspose.Slides для .NET](/slides/ru/net/)
- [Справочник API Aspose.Slides для .NET](https://reference.aspose.com/slides/net/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)