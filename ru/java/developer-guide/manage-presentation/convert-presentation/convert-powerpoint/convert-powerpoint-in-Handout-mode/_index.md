---
title: Конвертация презентаций PowerPoint в режиме раздатки в Java
linktitle: Режим раздатки
type: docs
weight: 150
url: /ru/java/convert-powerpoint-in-Handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим раздатки
- раздатка
- PPT
- PPTX
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Конвертируйте презентации в раздаточные материалы на Java. Устанавливайте количество слайдов на страницу, сохраняйте заметки, экспортируйте в PDF или изображения с помощью Aspose.Slides, с примером кода Java. Попробуйте бесплатно."
---

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настраивать отображение нескольких слайдов на одной странице, что делает его полезным для конференций, семинаров и прочих мероприятий. Вы можете включить этот режим, используя метод `setSlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ihtmloptions/), и [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/).

Для настройки режима Handout используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/handoutlayoutingoptions/), который определяет количество слайдов, помещаемых на одну страницу, и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.
```java
// Загрузить презентацию.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Задать параметры экспорта.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 слайда на одной странице по горизонтали
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // печать номеров слайдов
    slidesLayoutOptions.setPrintFrameSlide(true);                     // печать рамки вокруг слайдов
    slidesLayoutOptions.setPrintComments(false);                      // без комментариев

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Экспортировать презентацию в PDF с выбранным расположением.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```


{{% alert color="warning" %}} 
Имейте в виду, что метод `setSlidesLayoutOptions` доступен только для определённых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}}