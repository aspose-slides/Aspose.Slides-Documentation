---
title: Конвертация PowerPoint в PDF на C#
linktitle: Конвертация PowerPoint в PDF
type: docs
weight: 40
url: /net/convert-powerpoint-to-pdf/
keywords:
- конвертировать PowerPoint
- презентация
- PowerPoint в PDF
- PPT в PDF
- PPTX в PDF
- сохранить PowerPoint как PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C#
- Csharp
- .NET
- Aspose.Slides для .NET
description: "Конвертируйте презентации PowerPoint в PDF на C# или .NET. Сохраните PowerPoint как PDF с соблюдением норм или стандартов доступности."
---

## **Обзор**

Конвертация документов PowerPoint в формат PDF имеет несколько преимуществ, включая обеспечение совместимости с различными устройствами и сохранение макета и форматирования вашей презентации. Эта статья показывает, как конвертировать презентации в PDF-документы, использовать различные опции для контроля качества изображений, включать скрытые слайды, защищать PDF-документы паролем, обнаруживать замену шрифтов, выбирать слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

Используя Aspose.Slides, вы можете конвертировать презентации в следующих форматах в PDF:

* PPT
* PPTX
* ODP

Чтобы конвертировать презентацию в PDF, вам просто нужно передать имя файла в качестве аргумента в классе [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и затем сохранить презентацию как PDF с помощью метода [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Класс [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) предоставляет метод [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/#presentationsave-method-5-of-9), который обычно используется для конвертации презентации в PDF.

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Aspose.Slides для .NET напрямую записывает информацию о API и номер версии в выходные документы. Например, когда он конвертирует презентацию в PDF, Aspose.Slides для .NET заполняет поле приложения значением '*Aspose.Slides*' и поле производителя PDF значением в формате '*Aspose.Slides v XX.XX*'. **Обратите внимание**, что вы не можете указать Aspose.Slides для .NET изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* целую презентацию в PDF
* определенные слайды презентации в PDF
* презентацию 

Aspose.Slides экспортирует презентации в PDF таким образом, что содержимое полученных PDF очень похоже на содержимое оригинальных презентаций. Эти известные элементы и атрибуты часто правильно отображаются при конвертации презентации в PDF:

* изображения
* текстовые поля и другие фигуры
* тексты и их форматирование
* абзацы и их форматирование
* гиперссылки
* колонтитулы
* маркированные списки
* таблицы

## **Конвертация PowerPoint в PDF**

Стандартная операция конвертации PowerPoint в PDF выполняется с использованием настроек по умолчанию. В этом случае Aspose.Slides пытается конвертировать представленную презентацию в PDF, используя оптимальные настройки на максимальных уровнях качества.

Этот код на C# показывает, как конвертировать PowerPoint (PPT, PPTX, ODP) в PDF:

```c#
// Создание экземпляра класса Presentation, представляющего файл PowerPoint, это может быть PPT, PPTX, ODP и т.д.
Presentation presentation = new Presentation("PowerPoint.ppt");

// Сохранение презентации как PDF
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose предоставляет бесплатный онлайн [**конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс конвертации презентации в PDF. Для живой реализации процедуры, описанной здесь, вы можете провести тест с конвертером.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет настраиваемые параметры — свойства в классе [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), которые позволяют вам настроить PDF (полученный в результате процесса конвертации), заблокировать PDF паролем или даже указать, как должна проходить процедура конвертации.

### **Конвертация PowerPoint в PDF с настраиваемыми параметрами**

Используя настраиваемые параметры конвертации, вы можете установить желаемую настройку качества для растровых изображений, указать, как следует обрабатывать метафайлы, установить уровень сжатия для текстов, установить DPI для изображений и т.д.

Пример кода ниже демонстрирует операцию, в которой презентация PowerPoint конвертируется в PDF с несколькими пользовательскими параметрами:

```c#
// Создание экземпляра класса PdfOptions
PdfOptions pdfOptions = new PdfOptions
{
    // Установка качества для изображений JPG
    JpegQuality = 90,

    // Установка DPI для изображений
    SufficientResolution = 300,

    // Установка поведения для метафайлов
    SaveMetafilesAsPng = true,

    // Установка уровня сжатия текста для текстового контента
    TextCompression = PdfTextCompression.Flate,

    // Определение режима соответствия PDF
    Compliance = PdfCompliance.Pdf15
};

// Создание экземпляра класса Presentation, представляющего документ PowerPoint
using (Presentation presentation = new Presentation("PowerPoint.pptx"))
{
    // Сохранение презентации как PDF-документ
    presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
}
```

### **Конвертация PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать настраиваемую опцию — свойство [`ShowHiddenSlides`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) из класса [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), чтобы указать Aspose.Slides включить скрытые слайды в качестве страниц в результирующем PDF.

Этот код на C# показывает, как конвертировать презентацию PowerPoint в PDF с включенными скрытыми слайдами:

```c#
// Создание экземпляра класса Presentation, представляющего файл PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

// Создание экземпляра класса PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// Включение скрытых слайдов
pdfOptions.ShowHiddenSlides = true;

// Сохранение презентации как PDF
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Конвертация PowerPoint в PDF с защитой паролем**

Этот код на C# показывает, как конвертировать PowerPoint в защищенный PDF (с использованием параметров защиты из класса [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)):

```c#
// Создание экземпляра Presentation, представляющего файл PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

/// Создание экземпляра класса PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// Установка пароля PDF и разрешений на доступ
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Сохранение презентации как PDF
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет свойство [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) в классе [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/), позволяющее вам обнаруживать замены шрифтов в процессе конвертации презентации в PDF.

Этот код на C# показывает, как обнаружить замены шрифтов:

```c#
public static void Main()
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.WarningCallback = warningCallback;

    using (Presentation pres = new Presentation("pres.pptx", loadOptions))
    {
    }
}

private class FontSubstSendsWarningCallback : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Предупреждение о замене шрифта: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Для получения дополнительной информации о получении обратных вызовов для замен шрифтов в процессе рендеринга, см. [Получение обратных вызовов о предупреждениях для замены шрифтов](https://docs.aspose.com/slides/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения дополнительной информации о замене шрифтов см. статью [Замена шрифтов](https://docs.aspose.com/slides/net/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов в PowerPoint в PDF**

Этот код на C# показывает, как конвертировать конкретные слайды в презентации PowerPoint в PDF:

```c#
// Создание экземпляра Presentation, представляющего файл PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

// Установка массива позиций слайдов
int[] slides = { 1, 3 };

// Сохранение презентации как PDF
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Конвертация PowerPoint в PDF с настраиваемым размером слайда**

Этот код на C# показывает, как конвертировать PowerPoint, когда его размер слайда указан, в PDF:

```c#
// Создание экземпляра Presentation, представляющего файл PowerPoint 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];
auxPresentation.Slides.InsertClone(0, slide);

// Установка типа и размера слайда 
// auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F,SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
options.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Конвертация PowerPoint в PDF в виде заметок слайдов**

Этот код на C# показывает, как конвертировать PowerPoint в PDF заметок:

```c#
// Создание экземпляра класса Presentation, представляющего файл PowerPoint
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
	PdfOptions pdfOptions = new PdfOptions();
	INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
	options.NotesPosition = NotesPositions.BottomFull;

	// Сохранение презентации в PDF заметок
	presentation.Save("Pdf_Notes_out.tiff", SaveFormat.Pdf, pdfOptions);
}
```

## **Стандарты доступности и соблюдения для PDF**

Aspose.Slides позволяет вам использовать процедуру конвертации, которая соответствует [Руководящим принципам по доступности веб-контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF с использованием любого из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код на C# демонстрирует операцию конвертации PowerPoint в PDF, в которой получаются несколько PDF на основе различных стандартов соответствия:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1a
    });
   
    pres.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1b
    });
   
    pres.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
   {
        Compliance = PdfCompliance.PdfUa
    });
}
```

{{% alert title="Примечание" color="warning" %}} 

Поддержка Aspose.Slides операций по конвертации PDF расширяется до возможности конвертировать PDF в самые популярные форматы файлов. Вы можете осуществлять [PDF в HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) и [PDF в PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) и [PDF в XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}