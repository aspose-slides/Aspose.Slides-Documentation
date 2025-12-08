---
title: Конвертировать презентации в режиме раздаточного листа в C#
type: docs
weight: 150
url: /ru/net/convert-powerpoint-in-Handout-mode/
keywords:
- конвертировать PowerPoint
- режим раздаточного листа
- раздаточный лист
- PowerPoint
- PPT
- PPTX
- презентация
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Конвертировать презентации в режиме раздаточного листа в C#"
---

## **Экспорт в режиме раздаточного листа**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, в том числе создавать раздаточные материалы для печати в режиме Handout. Этот режим позволяет настроить отображение нескольких слайдов на одной странице, что удобно для конференций, семинаров и прочих мероприятий. Вы можете включить этот режим, задав свойство `SlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/) и [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/).

Для настройки режима раздаточного листа используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/), который определяет количество слайдов, помещаемых на одну страницу, и другие параметры отображения.

Ниже приведён пример кода, демонстрирующий, как конвертировать презентацию в PDF в режиме Handout.
```c#
// Загрузить презентацию.
using var presentation = new Presentation("sample.pptx");

// Установить параметры экспорта.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 слайда на одной странице по горизонтали
        PrintSlideNumbers = true,                   // печатать номера слайдов
        PrintFrameSlide = true,                     // печатать рамку вокруг слайдов
        PrintComments = false                       // без комментариев
    }
};

// Экспортировать презентацию в PDF с выбранным макетом.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
Имейте в виду, что свойство `SlidesLayoutOptions` доступно только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}} 

## **FAQ**

**Каково максимальное количество миниатюр слайдов на странице в режиме Handout?**

Aspose.Slides поддерживает [предустановки](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) до 9 миниатюр на странице с горизонтальной или вертикальной сортировкой: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) и 9 (horizontal/vertical).

**Могу ли я задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/); произвольные макеты не поддерживаются.

**Могу ли я включить скрытые слайды в вывод раздаточного листа?**

Да. Включите параметр `ShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).