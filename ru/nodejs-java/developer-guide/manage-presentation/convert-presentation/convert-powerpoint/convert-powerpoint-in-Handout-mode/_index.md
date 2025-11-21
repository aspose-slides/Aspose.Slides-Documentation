---
title: Конвертировать презентации в режиме раздаточного листа в JavaScript
type: docs
weight: 150
url: /ru/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- конвертировать PowerPoint
- режим раздаточного листа
- раздаточный лист
- PowerPoint
- PPT
- PPTX
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать презентации в режиме раздаточного листа на JavaScript"
---

## **Экспорт в режиме раздаточного листа**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных листов для печати в режиме раздаточного листа. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, установив метод `setSlidesLayoutOptions` в классах [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) и [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/).

Чтобы настроить режим раздаточного листа, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handoutlayoutingoptions/), который определяет, сколько слайдов размещается на одной странице, и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме раздаточного листа.
```js
// Загружаем презентацию.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Устанавливаем параметры экспорта.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 слайда на странице по горизонтали
slidesLayoutOptions.setPrintSlideNumbers(true);                                // печатать номера слайдов
slidesLayoutOptions.setPrintFrameSlide(true);                                  // печатать рамку вокруг слайдов
slidesLayoutOptions.setPrintComments(false);                                   // без комментариев

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Экспортируем презентацию в PDF с выбранным макетом.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="warning" %}} 
Имейте в виду, что метод `setSlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}} 

## **Часто задаваемые вопросы**

**Каково максимальное количество миниатюр слайдов на странице в режиме раздаточного листа?**

Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) до 9 миниатюр на странице с горизонтальным или вертикальным расположением: 1, 2, 3, 4 (горизонтальное/вертикальное), 6 (горизонтальное/вертикальное) и 9 (горизонтальное/вертикальное).

**Могу ли я задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/); произвольные макеты не поддерживаются.

**Могу ли я включить скрытые слайды в вывод раздаточного листа?**

Да. Используйте метод `setShowHiddenSlides` в настройках экспорта для целевого формата, такого как [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/).