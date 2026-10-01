---
title: Конвертировать презентации PowerPoint в режиме раздатки с использованием Java
linktitle: Режим раздатки
type: docs
weight: 150
url: /ru/java/convert-powerpoint-in-handout-mode/
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
description: "Конвертировать презентации в раздатки на Java. Установить количество слайдов на страницу, сохранить примечания, экспортировать в PDF или изображения с Aspose.Slides, с примером кода на Java. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides позволяет конвертировать презентации в форматы вывода, поддерживающие режим раздатки. В этом режиме несколько слайдов размещаются на одной странице, что удобно для печати материалов презентаций для конференций, семинаров и подобных мероприятий.

Режим раздатки настраивается с помощью метода `setSlidesLayoutOptions`, который доступен в [IPdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ihtmloptions/), и [ITiffOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiffoptions/). Чтобы определить макет раздатки, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/handoutlayoutingoptions/).

Чтобы задать размеры и ориентацию страницы раздатки перед экспортом, см. [Notes Page Size](/slides/ru/java/notes-size/).

## **Экспорт в режиме раздатки**

Чтобы экспортировать презентацию в режиме раздатки, задайте метод `setSlidesLayoutOptions` для целевых параметров экспорта и назначьте экземпляр [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/handoutlayoutingoptions/) , который определяет количество слайдов на странице и связанные параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме раздатки.

```java
import com.aspose.slides.*;

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

    // Экспортировать презентацию в PDF с выбранным макетом.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" title="Warning" %}}
Имейте в виду, что метод `setSlidesLayoutOptions` доступен только для определённых форматов вывода, таких как PDF, HTML, TIFF, и при визуализации в виде изображений.
{{% /alert %}} 

## **FAQ**

**Каково максимальное количество миниатюр слайдов на странице в режиме раздатки?**

Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/ru/java/com.aspose.slides/handouttype/) до 9 миниатюр на странице с горизонтальной или вертикальной сортировкой: 1, 2, 3, 4 (горизонтальная/вертикальная), 6 (горизонтальная/вертикальная) и 9 (горизонтальная/вертикальная).

**Могу ли я задать пользовательскую сетку, например 5 или 8 слайдов на странице?**

Нет. Количество и порядок миниатюр строго контролируются классом [HandoutType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/handouttype/); произвольные макеты не поддерживаются.

**Могу ли я включить скрытые слайды в вывод раздатки?**

Да. Включите скрытые слайды, используя метод `setShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmloptions/), или [TiffOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tiffoptions/).