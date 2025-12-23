---
title: Конвертация презентаций PowerPoint в режиме раздаточного материала с использованием PHP
linktitle: Режим раздаточного материала
type: docs
weight: 150
url: /ru/php-java/convert-powerpoint-in-Handout-mode/
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
description: "Конвертируйте презентации в раздаточные материалы с помощью PHP. Устанавливайте количество слайдов на страницу, сохраняйте заметки, экспортируйте в PDF или изображения с Aspose.Slides для PHP, используя пример кода. Попробуйте бесплатно."
---

## **Экспорт в режиме раздаточного материала**

Aspose.Slides предоставляет возможность преобразовывать презентации в различные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, установив метод `setSlidesLayoutOptions` в классах [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/), и [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/).

Чтобы настроить режим Handout, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/handoutlayoutingoptions/), который определяет, сколько слайдов размещается на одной странице и другие параметры отображения.

Ниже приведён пример кода, показывающий, как преобразовать презентацию в PDF в режиме Handout.
```php
// Загрузить презентацию.
$presentation = new Presentation("sample.pptx");

// Установить параметры экспорта.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 слайда на одной странице горизонтально
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // вывести номера слайдов
$slidesLayoutOptions->setPrintFrameSlide(true);                      // вывести рамку вокруг слайдов
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

Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/) до 9 миниатюр на странице с горизонтальным или вертикальным порядком: 1, 2, 3, 4 (горизонтальный/вертикальный), 6 (горизонтальный/вертикальный) и 9 (горизонтальный/вертикальный).

**Могу ли я задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго управляются классом [HandoutType](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/); произвольные макеты не поддерживаются.

**Можно ли включить скрытые слайды в вывод Handout?**

Да. Включите скрытые слайды, используя метод `setShowHiddenSlides` в настройках экспорта для целевого формата, например, [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/), или [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/).