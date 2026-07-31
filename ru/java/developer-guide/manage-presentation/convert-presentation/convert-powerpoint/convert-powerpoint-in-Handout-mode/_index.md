---
title: Конвертация презентаций PowerPoint в режим раздатки с использованием Java
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
description: "Конвертируйте презентации в раздатки на Java. Установите количество слайдов на страницу, сохраните заметки, экспортируйте в PDF или изображения с Aspose.Slides, с примером кода на Java. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides позволяет конвертировать презентации в форматы вывода, поддерживающие режим раздатки. В этом режиме несколько слайдов размещаются на одной странице, что удобно при печати материалов презентаций для конференций, семинаров и аналогичных мероприятий.

Режим раздатки настраивается с помощью метода `setSlidesLayoutOptions`, который доступен в [IPdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ihtmloptions/), и [ITiffOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiffoptions/). Для определения разметки раздатки используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/handoutlayoutingoptions/).

## **Экспорт в режиме раздатки**

Чтобы экспортировать презентацию в режиме раздатки, установите метод `setSlidesLayoutOptions` для целевых параметров экспорта и задайте экземпляр [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/handoutlayoutingoptions/), определяющий количество слайдов на страницу и связанные параметры отображения.

Ниже приведён пример кода, показывающий, как преобразовать презентацию в PDF в режиме раздатки.

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

    // Экспортировать презентацию в PDF с выбранной разметкой.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 

Учтите, что метод `setSlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, и при рендеринге в виде изображений.

{{% /alert %}} 

## **Вопросы и ответы**

**Каково максимальное количество миниатюр слайдов на странице в режиме раздатки?**

Aspose.Slides поддерживает [preset'ы](https://reference.aspose.com/slides/ru/java/com.aspose.slides/handouttype/) до 9 миниатюр на страницу с горизонтальным или вертикальным расположением: 1, 2, 3, 4 (горизонтальное/вертикальное), 6 (горизонтальное/вертикальное) и 9 (горизонтальное/вертикальное).

**Можно ли задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются классом [HandoutType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/handouttype/); произвольные макеты не поддерживаются.

**Можно ли включить скрытые слайды в вывод раздатки?**

Да. Включите скрытые слайды, используя метод `setShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmloptions/), или [TiffOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tiffoptions/).