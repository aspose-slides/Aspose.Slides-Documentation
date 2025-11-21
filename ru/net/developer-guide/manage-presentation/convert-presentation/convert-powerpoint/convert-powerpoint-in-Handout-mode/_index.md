---
title: Преобразование презентаций PowerPoint в режиме Handout в .NET
linktitle: Режим Handout
type: docs
weight: 150
url: /ru/net/convert-powerpoint-in-Handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим раздаточного листа
- раздаточный лист
- PowerPoint
- презентация
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Преобразуйте презентации в раздаточные листы в .NET. Установите количество слайдов на страницу, сохраняйте заметки, экспортируйте в PDF или изображения с помощью Aspose.Slides, с примером кода C#. Попробуйте бесплатно."
---

## **Экспорт в режиме раздаточного листа**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, в том числе создавать раздаточные листы для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов будут расположены на одной странице, что удобно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, установив свойство `SlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/) и [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/)  

Чтобы настроить режим Handout, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/), который определяет количество слайдов, размещаемых на одной странице, и другие параметры отображения.

Ниже приведен пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.
```c#
 // Load a presentation.
 using var presentation = new Presentation("sample.pptx");

 // Set the export options.
 var pdfOptions = new PdfOptions
 {
     SlidesLayoutOptions = new HandoutLayoutingOptions
     {
         Handout = HandoutType.Handouts4Horizontal,  // 4 слайда на одной странице горизонтально
         PrintSlideNumbers = true,                   // печать номеров слайдов
         PrintFrameSlide = true,                     // выводить рамку вокруг слайдов
         PrintComments = false                       // без комментариев
     }
 };

 // Export the presentation to PDF with the chosen layout.
 presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
Имейте в виду, что свойство `SlidesLayoutOptions` доступно только для определённых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений. 
{{% /alert %}} 

## **Часто задаваемые вопросы**

**Каково максимальное количество миниатюр слайдов на странице в режиме Handout?**  
Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) до 9 миниатюр на странице с горизонтальным или вертикальным расположением: 1, 2, 3, 4 (горизонтальное/вертикальное), 6 (горизонтальное/вертикальное) и 9 (горизонтальное/вертикальное).

**Могу ли я задать собственную сетку, например 5 или 8 слайдов на страницу?**  
Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/); произвольные макеты не поддерживаются.

**Могу ли я включить скрытые слайды в вывод Handout?**  
Да. Включите опцию `ShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).