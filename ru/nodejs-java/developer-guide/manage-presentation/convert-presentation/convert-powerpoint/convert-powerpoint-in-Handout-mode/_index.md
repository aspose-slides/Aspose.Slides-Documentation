---
title: Конвертировать презентации PowerPoint в режиме Handout с помощью JavaScript
linktitle: Режим Handout
type: docs
weight: 150
url: /ru/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим раздатки
- раздатка
- PPT
- PPTX
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать презентации в раздаточный материал. Установить количество слайдов на страницу, сохранять примечания, экспортировать в PDF или изображения с помощью Aspose.Slides для Node.js, с примером кода. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, установив метод `setSlidesLayoutOptions` в классах [PdfOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/), и [TiffOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tiffoptions/).

## **Экспорт в режиме Handout**

Для настройки режима Handout используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/handoutlayoutingoptions/), который определяет, сколько слайдов помещается на одну страницу и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.

```js
// Загрузить презентацию.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 слайда на одной странице по горизонтали
slidesLayoutOptions.setPrintSlideNumbers(true);                                // печать номеров слайдов
slidesLayoutOptions.setPrintFrameSlide(true);                                  // печать рамки вокруг слайдов
slidesLayoutOptions.setPrintComments(false);                                   // без комментариев

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Имейте в виду, что метод `setSlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}} 

## **FAQ**

**Каково максимальное количество миниатюр слайдов на странице в режиме Handout?**

Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/handouttype/) до 9 миниатюр на странице с горизонтальной или вертикальной компоновкой: 1, 2, 3, 4 (горизонтально/вертикально), 6 (горизонтально/вертикально) и 9 (горизонтально/вертикально).

**Можно ли задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/handouttype/); произвольные макеты не поддерживаются.

**Можно ли включить скрытые слайды в вывод Handout?**

Да. Используйте метод `setShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/), или [TiffOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tiffoptions/).