---
title: Конвертировать презентации PowerPoint в режиме Handout на Android
linktitle: Режим Handout
type: docs
weight: 150
url: /ru/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим handout
- раздаточный материал
- PPT
- PPTX
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Конвертировать презентации в раздаточные материалы в Java. Установить количество слайдов на страницу, сохранить заметки, экспортировать в PDF или изображения с Aspose.Slides для Android, с примером кода. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, задав метод `setSlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihtmloptions/), и [ITiffOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiffoptions/) .

Чтобы задать размеры и ориентацию страницы раздаточного материала перед экспортом, см. [Размер страницы заметок](/slides/ru/androidjava/notes-size/).

## **Экспорт в режиме Handout**

Чтобы настроить режим Handout, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/handoutlayoutingoptions/), который определяет, сколько слайдов размещается на одной странице, и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.

```java
import com.aspose.slides.*;

// Загрузить презентацию.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Задать параметры экспорта.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 слайда на одной странице по горизонтали
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // печатать номера слайдов
	slidesLayoutOptions.setPrintFrameSlide(true);                     // печатать рамку вокруг слайдов
	slidesLayoutOptions.setPrintComments(false);                      // без комментариев

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Экспортировать презентацию в PDF с выбранным макетом.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Имейте в виду, что метод `setSlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, и при рендеринге в виде изображений.
{{% /alert %}}

## **FAQ**

**Каково максимальное количество миниатюр слайдов на странице в режиме Handout?**

Aspose.Slides поддерживает [предустановки](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/handouttype/) до 9 миниатюр на странице с горизонтальным или вертикальным расположением: 1, 2, 3, 4 (горизонтально/вертикально), 6 (горизонтально/вертикально) и 9 (горизонтально/вертикально).

**Могу ли я задать собственную сетку, например 5 или 8 слайдов на странице?**

Нет. Количество и порядок миниатюр строго контролируются классом [HandoutType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/handouttype/); произвольные макеты не поддерживаются.

**Могу ли я включить скрытые слайды в вывод Handout?**

Да. Включите скрытые слайды, используя метод `setShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/htmloptions/), или [TiffOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tiffoptions/).