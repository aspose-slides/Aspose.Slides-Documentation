---
title: Конвертировать презентации PowerPoint в режиме раздаточного материала в .NET
linktitle: Режим раздаточного материала
type: docs
weight: 150
url: /ru/net/convert-powerpoint-in-handout-mode/
keywords:
  - конвертация PowerPoint
  - конвертация презентации
  - режим раздаточного материала
  - раздаточный материал
  - PowerPoint
  - презентация
  - PPT
  - PPTX
  - .NET
  - C#
  - Aspose.Slides
description: "Конвертировать презентации в раздаточный материал в .NET. Установите количество слайдов на страницу, сохраняйте заметки, экспортируйте в PDF или изображения с помощью Aspose.Slides, с примером кода C#. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides позволяет конвертировать презентации в форматы вывода, поддерживающие режим раздаточного материала. В этом режиме несколько слайдов размещаются на одной странице, что удобно для печати материалов презентаций для конференций, семинаров и подобных мероприятий.

Режим раздаточного материала настраивается через свойство `SlidesLayoutOptions`, которое доступно в [IPdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ihtmloptions/), и [ITiffOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/itiffoptions/). Чтобы определить раздаточный шаблон, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/handoutlayoutingoptions/).

Чтобы задать размеры и ориентацию страницы раздаточного материала перед экспортом, см. раздел [Notes Page Size](/slides/ru/net/notes-size/).

## **Экспорт в режиме раздаточного материала**

Чтобы экспортировать презентацию в режиме раздаточного материала, задайте свойство `SlidesLayoutOptions` для целевых параметров экспорта и назначьте экземпляр [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/handoutlayoutingoptions/), определяющий количество слайдов на странице и связанные параметры отображения.

Ниже приведён пример кода, показывающий, как преобразовать презентацию в PDF в режиме раздаточного материала.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Load a presentation.
// Загрузка презентации.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
// Установка параметров экспорта.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 slides on one page horizontally
        // 4 слайда на одной странице горизонтально
        PrintSlideNumbers = true,                   // print slide numbers
        // печать номеров слайдов
        PrintFrameSlide = true,                     // print a frame around slides
        // печать рамки вокруг слайдов
        PrintComments = false                       // no comments
        // без комментариев
    }
};

// Export the presentation to PDF with the chosen layout.
// Экспорт презентации в PDF с выбранным макетом.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}}
Имейте в виду, что свойство `SlidesLayoutOptions` доступно только для некоторых форматов вывода, таких как PDF, HTML, TIFF и при рендеринге в виде изображений.
{{% /alert %}}

## **FAQ**

### Каково максимальное количество миниатюр слайдов на странице в режиме раздаточного материала?

Aspose.Slides поддерживает [пресеты](https://reference.aspose.com/slides/ru/net/aspose.slides.export/handouttype/) до 9 миниатюр на странице с горизонтальной или вертикальной раскладкой: 1, 2, 3, 4 (горизонтальная/вертикальная), 6 (горизонтальная/вертикальная) и 9 (горизонтальная/вертикальная).

### Можно ли определить пользовательскую сетку, например 5 или 8 слайдов на странице?

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/ru/net/aspose.slides.export/handouttype/); произвольные макеты не поддерживаются.

### Можно ли включить скрытые слайды в раздаточный вывод?

Да. Включите опцию `ShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmloptions/), или [TiffOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/tiffoptions/).