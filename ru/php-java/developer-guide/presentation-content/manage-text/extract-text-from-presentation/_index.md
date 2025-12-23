---
title: "Продвинутое извлечение текста из презентаций на PHP"
linktitle: "Извлечение текста"
type: docs
weight: 90
url: /ru/php-java/extract-text-from-presentation/
keywords:
- извлечение текста
- извлечение текста со слайда
- извлечение текста из презентации
- извлечение текста из PowerPoint
- извлечение текста из OpenDocument
- извлечение текста из PPT
- извлечение текста из PPTX
- извлечение текста из ODP
- получение текста
- получение текста со слайда
- получение текста из презентации
- получение текста из PowerPoint
- получение текста из OpenDocument
- получение текста из PPT
- получение текста из PPTX
- получение текста из ODP
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Быстро извлеките текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---

{{% alert color="primary" %}}

Не редкость, когда разработчикам требуется извлечь текст из презентации. Для этого необходимо извлечь текст из всех фигур на всех слайдах презентации. В этой статье объясняется, как извлечь текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides.

{{% /alert %}}
## **Извлечение текста со слайдов**
Aspose.Slides for PHP via Java provides the [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) class. This class exposes a number of overloaded static methods for extracting the entire text from a presentation or slide. To extract the text from a slide in a PPTX presentation, use the [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) overloaded static method exposed by the [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) class. This method accepts the Slide object as a parameter. Upon execution, the Slide method scans the entire text from the slide passed as parameter and returns an array of [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) objects. This means that any text formatting associated with the text is available. The following piece of code extracts all the text on the first slide of the presentation:
```php
  # Создать экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # Получить массив объектов ITextFrame со всех слайдов в PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # Перебрать массив TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # Перебрать абзацы в текущем ITextFrame
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # Перебрать части в текущем IParagraph
          foreach($para->getPortions() as $port) {
            # Отобразить текст в текущей части
            echo($port->getText());
            # Отобразить высоту шрифта текста
            echo($port->getPortionFormat()->getFontHeight());
            # Отобразить название шрифта текста
            if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
              echo($port->getPortionFormat()->getLatinFont()->getFontName());
            }
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **Извлечение текста из презентаций**
To scan the text from the whole presentation, use the [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) static method exposed by the SlideUtil class. It takes two parameters:

1. First, a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) object that represents the presentation from which the text is being extracted.
2. Second, a boolean value determining whether the master slide is to be included when the text is scanned from the presentation. The method returns an array of [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) objects, complete with text formatting information. The code below scans the text and formatting information from a presentation, including the master slides.
```php
  # Создать экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Получить массив объектов ITextFrame со всех слайдов в PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # Перебрать массив TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # Перебрать абзацы в текущем ITextFrame
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # Перебрать части в текущем IParagraph
        foreach($para->getPortions() as $port) {
          # Отобразить текст в текущей части
          echo($port->getText());
          # Отобразить высоту шрифта текста
          echo($port->getPortionFormat()->getFontHeight());
          # Отобразить название шрифта текста
          if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
            echo($port->getPortionFormat()->getLatinFont()->getFontName());
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **Категоризированное и быстрое извлечение текста**
The new static method getPresentationText has been added to Presentation class. There are three overloads for this method:
```php

``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://reference.aspose.com/slides/php-java/aspose.slides/SlideText) class which implements the [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) interface.

The new API can be used like this:

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());

```


## **FAQ**

**Как быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже [large presentations](/slides/ru/php-java/open-presentation/), что делает его подходящим для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм внутри презентаций?**

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайда, позволяя легко получать и анализировать весь текстовый контент.

**Нужна ли особая лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, хотя она имеет определённые ограничения, например, обработку только ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.