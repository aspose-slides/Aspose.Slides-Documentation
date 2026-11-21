---
title: Конвертировать презентации PowerPoint в режиме раздаточного материала с использованием PHP
linktitle: Режим раздаточного материала
type: docs
weight: 150
url: /ru/php-java/convert-powerpoint-in-handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим раздаточного материала
- раздаточный материал
- PPT
- PPTX
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Конвертировать презентации в раздаточные материалы с помощью PHP. Установите количество слайдов на страницу, сохраните заметки, экспортируйте в PDF или изображения с Aspose.Slides для PHP, с примером кода. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, установив метод `setSlidesLayoutOptions` в классах [PdfOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/) и [TiffOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tiffoptions/).

Чтобы задать размеры и ориентацию страницы раздаточного материала перед экспортом, см. [Размер страницы заметок](/slides/ru/php-java/notes-size/).

## **Экспорт в режиме Handout**

Чтобы настроить режим Handout, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/handoutlayoutingoptions/), который определяет, сколько слайдов помещается на одну страницу и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.

```php
// Загрузить презентацию.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 слайда на одной странице горизонтально
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // печатать номера слайдов
$slidesLayoutOptions->setPrintFrameSlide(true);                      // печатать рамку вокруг слайдов
$slidesLayoutOptions->setPrintComments(false);                       // без комментариев

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
Имейте в виду, что метод `setSlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}} 

## **Часто задаваемые вопросы**

**Каково максимальное количество миниатюр слайдов на странице в режиме Handout?**

Aspose.Slides поддерживает [предустановки](https://reference.aspose.com/slides/ru/php-java/aspose.slides/handouttype/) до 9 миниатюр на странице с горизонтальным или вертикальным расположением: 1, 2, 3, 4 (горизонтально/вертикально), 6 (горизонтально/вертикально) и 9 (горизонтально/вертикально).

**Можно ли задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются классом [HandoutType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/handouttype/); произвольные макеты не поддерживаются.

**Можно ли включить скрытые слайды в вывод Handout?**

Да. Включите скрытые слайды, используя метод `setShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tiffoptions/).