---
title: Конвертировать презентации PowerPoint в режиме раздаточного материала с помощью JavaScript
linktitle: Режим раздаточного материала
type: docs
weight: 150
url: /ru/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим раздаточного материала
- раздаточный материал
- PPT
- PPTX
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать презентации в раздаточный материал. Установите количество слайдов на страницу, сохраняйте заметки, экспортируйте в PDF или изображения с помощью Aspose.Slides для Node.js, с примером кода. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, задав метод `setSlidesLayoutOptions` в классах [PdfOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/) и [TiffOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tiffoptions/).

Чтобы задать размеры и ориентацию страницы раздаточного материала перед экспортом, см. [Размер страницы заметок](/slides/ru/nodejs-java/notes-size/).

## **Экспорт в режиме Handout**

Чтобы настроить режим Handout, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/handoutlayoutingoptions/), который определяет количество слайдов, размещаемых на одной странице, и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.

```js
const asposeSlides = require("aspose.slides.via.java");

// Загрузить презентацию.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Задать параметры экспорта.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 слайда на одной странице горизонтально
slidesLayoutOptions.setPrintSlideNumbers(true);                                // печатать номера слайдов
slidesLayoutOptions.setPrintFrameSlide(true);                                  // печатать рамку вокруг слайдов
slidesLayoutOptions.setPrintComments(false);                                   // без комментариев

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Экспортировать презентацию в PDF с выбранным макетом.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
Имейте в виду, что метод `setSlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, и при рендеринге в виде изображений.
{{% /alert %}} 

## **Часто задаваемые вопросы**

**Каково максимальное количество миниатюр слайдов на страницу в режиме Handout?**

Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/handouttype/) до 9 миниатюр на страницу с горизонтальной или вертикальной расстановкой: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) и 9 (horizontal/vertical).

**Можно ли задать собственную сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/handouttype/); произвольные макеты не поддерживаются.

**Можно ли включать скрытые слайды в вывод Handout?**

Да. Используйте метод `setShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tiffoptions/).