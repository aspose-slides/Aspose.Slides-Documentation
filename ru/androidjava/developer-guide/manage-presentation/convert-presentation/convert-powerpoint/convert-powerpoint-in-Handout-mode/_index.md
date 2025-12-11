---
title: Конвертация презентаций PowerPoint в режиме раздаточного листа на Android
linktitle: Режим раздаточного листа
type: docs
weight: 150
url: /ru/androidjava/convert-powerpoint-in-Handout-mode/
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
description: "Конвертировать презентации в раздаточные листы на Java. Устанавливайте количество слайдов на страницу, сохраняйте примечания, экспортируйте в PDF или изображения с помощью Aspose.Slides для Android, с примером кода. Попробуйте бесплатно."
---

## **Экспорт в режиме раздаточного листа**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных листов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, установив метод `setSlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihtmloptions/), и [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) интерфейсов.

Чтобы настроить режим Handout, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handoutlayoutingoptions/), который определяет, сколько слайдов размещается на одной странице и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.
```java
// Загрузить презентацию.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Установить параметры экспорта.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 слайда на одной странице по горизонтали
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // печатать номера слайдов
	slidesLayoutOptions.setPrintFrameSlide(true);                     // печатать рамку вокруг слайдов
	slidesLayoutOptions.setPrintComments(false);                      // без комментариев

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Export the presentation to PDF with the chosen layout.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```


{{% alert color="warning" %}} 
Имейте в виду, что метод `setSlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}} 

## **Часто задаваемые вопросы**

**Каково максимальное количество миниатюр слайдов на странице в режиме Handout?**

Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) до 9 миниатюр на странице с горизонтальной или вертикальной сортировкой: 1, 2, 3, 4 (горизонтальная/вертикальная), 6 (горизонтальная/вертикальная) и 9 (горизонтальная/вертикальная).

**Могу ли я задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются классом [HandoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/); произвольные макеты не поддерживаются.

**Могу ли я включить скрытые слайды в вывод Handout?**

Да. Включите скрытые слайды, используя метод `setShowHiddenSlides` в параметрах экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/htmloptions/), или [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/).