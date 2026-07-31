---
title: Конвертировать презентации PowerPoint в режиме раздаточного листа на Android
linktitle: Режим раздаточного листа
type: docs
weight: 150
url: /ru/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим раздаточного листа
- раздаточный лист
- PPT
- PPTX
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Конвертировать презентации в раздаточные листы в Java. Установить количество слайдов на страницу, сохранять примечания, экспортировать в PDF или изображения с помощью Aspose.Slides для Android, с примером кода. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что полезно для конференций, семинаров и прочих мероприятий. Вы можете включить этот режим, задав метод `setSlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihtmloptions/) и [ITiffOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiffoptions/).

## **Экспорт в режиме Handout**

Для настройки режима Handout используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/handoutlayoutingoptions/), который определяет, сколько слайдов помещается на одну страницу и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.

```java
// Загрузить презентацию.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Установить параметры экспорта.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 слайда на одной странице по горизонтали
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // печать номеров слайдов
	slidesLayoutOptions.setPrintFrameSlide(true);                     // печать рамки вокруг слайдов
	slidesLayoutOptions.setPrintComments(false);                      // без комментариев

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Экспортировать презентацию в PDF с выбранным макетом.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 

Имейте в виду, что метод `setSlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF и при рендеринге в виде изображений.

{{% /alert %}} 

## **FAQ**

**Каково максимальное количество миниатюр слайдов на страницу в режиме Handout?**

Aspose.Slides поддерживает [preset'ы](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/handouttype/) до 9 миниатюр на страницу с горизонтальным или вертикальным расположением: 1, 2, 3, 4 (горизонтально/вертикально), 6 (горизонтально/вертикально) и 9 (горизонтально/вертикально).

**Можно ли задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются классом [HandoutType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/handouttype/); произвольные раскладки не поддерживаются.

**Можно ли включить скрытые слайды в вывод Handout?**

Да. Включите скрытые слайды, используя метод `setShowHiddenSlides` в параметрах экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tiffoptions/).