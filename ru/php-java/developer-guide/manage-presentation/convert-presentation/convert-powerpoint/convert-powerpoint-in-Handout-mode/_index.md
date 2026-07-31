---
title: Конвертировать презентации PowerPoint в режиме Handout с использованием PHP
linktitle: Режим Handout
type: docs
weight: 150
url: /ru/php-java/convert-powerpoint-in-handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим handout
- раздаточный материал
- PPT
- PPTX
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Конвертировать презентации в раздаточные материалы с помощью PHP. Установите количество слайдов на страницу, сохраняйте заметки, экспортируйте в PDF или изображения с Aspose.Slides для PHP, с примером кода. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов выводятся на одной странице, что удобно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, задав метод `setSlidesLayoutOptions` в классах [PdfOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/), и [TiffOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tiffoptions/).

## **Экспорт в режиме Handout**

Для настройки режима Handout используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/handoutlayoutingoptions/), который определяет, сколько слайдов размещается на одной странице и другие параметры отображения.

Ниже приведён пример кода, показывающий, как преобразовать презентацию в PDF в режиме Handout.

```php
// Загрузить презентацию.
$presentation = new Presentation("sample.pptx");

// Установить параметры экспорта.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 слайда на одной странице горизонтально
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // печатать номера слайдов
$slidesLayoutOptions->setPrintFrameSlide(true);                      // печатать рамку вокруг слайдов
$slidesLayoutOptions->setPrintComments(false);                       // без комментариев

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Экспортировать презентацию в PDF с выбранным макетом.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 

Имейте в виду, что метод `setSlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.

{{% /alert %}} 

## **FAQ**

**Каково максимальное количество миниатюр слайдов на странице в режиме Handout?**

Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/ru/php-java/aspose.slides/handouttype/) до 9 миниатюр на странице с горизонтальной или вертикальной ориентацией: 1, 2, 3, 4 (горизонтальная/вертикальная), 6 (горизонтальная/вертикальная) и 9 (горизонтальная/вертикальная).

**Могу ли я определить собственную сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются классом [HandoutType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/handouttype/); произвольные макеты не поддерживаются.

**Можно ли включить скрытые слайды в вывод Handout?**

Да. Включите скрытые слайды, используя метод `setShowHiddenSlides` в параметрах экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tiffoptions/).