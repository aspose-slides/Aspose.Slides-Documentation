---
title: Извлечение текста из презентации
type: docs
weight: 90
url: /ru/php-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Не редкость, когда разработчикам необходимо извлечь текст из презентации. Для этого нужно извлечь текст из всех фигур на всех слайдах презентации. Эта статья объясняет, как извлечь текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. 

{{% /alert %}} 
## **Извлечение текста из слайда**
Aspose.Slides для PHP через Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). Этот класс предлагает несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст из слайда в презентации PPTX, используйте перегруженный статический метод [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) класса [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). Этот метод принимает объект Slide в качестве параметра. При выполнении метод Slide сканирует весь текст со слайда, переданного в качестве параметра, и возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame). Это означает, что вся информация о форматировании текста доступна. Следующий фрагмент кода извлекает весь текст на первом слайде презентации:

```php
  # Создайте экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # Получите массив объектов ITextFrame со всех слайдов в PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # Пройдите через массив TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # Пройдите через абзацы в текущем ITextFrame
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # Пройдите через части в текущем IParagraph
          foreach($para->getPortions() as $port) {
            # Выведите текст в текущей части
            echo($port->getText());
            # Выведите высоту шрифта текста
            echo($port->getPortionFormat()->getFontHeight());
            # Выведите имя шрифта текста
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

## **Извлечение текста из презентации**
Чтобы просканировать текст из всей презентации, используйте статический метод [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) класса SlideUtil. Он принимает два параметра:

1. Во-первых, объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged), который представляет собой презентацию, из которой извлекается текст.
1. Во-вторых, логическое значение, определяющее, следует ли включать мастер-слайд при сканировании текста из презентации.
   Метод возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), включая информацию о форматировании текста. В приведенном ниже коде сканируются текст и информация о форматировании из презентации, включая мастер-слайды.

```php
  # Создайте экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Получите массив объектов ITextFrame со всех слайдов в PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # Пройдите через массив TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # Пройдите через абзацы в текущем ITextFrame
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # Пройдите через части в текущем IParagraph
        foreach($para->getPortions() as $port) {
          # Выведите текст в текущей части
          echo($port->getText());
          # Выведите высоту шрифта текста
          echo($port->getPortionFormat()->getFontHeight());
          # Выведите имя шрифта текста
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

## **Классифицированное и быстрое извлечение текста**
В класс Presentation был добавлен новый статический метод getPresentationText. У этого метода есть три перегрузки:

```php

``` 

Аргумент перечисления [TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode) указывает режим организации вывода текста и может быть установлен на следующие значения:
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - сырой текст без учета положения на слайде
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Arranged) - текст располагается в том же порядке, что и на слайде

Режим **Unarranged** может быть использован, когда скорость критична, он быстрее, чем режим Arranged.

[IPresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) представляет собой сырой текст, извлеченный из презентации. Он содержит метод [getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText#getSlidesText--) который возвращает массив объектов [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText). Каждый объект представляет текст на соответствующем слайде. Объект [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) имеет следующие методы:

- [ISlideText.getText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getText--) - текст на фигурах слайда
- [ISlideText.getMasterText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getMasterText--) - текст на фигурах мастер-страницы для этого слайда
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getLayoutText--) - текст на фигурах страницы макета для этого слайда
- [ISlideText.getNotesText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getNotesText--) - текст на фигурах страницы заметок для этого слайда

Существует также класс [SlideText](https://reference.aspose.com/slides/php-java/aspose.slides/SlideText), который реализует интерфейс [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText).

Новое API можно использовать следующим образом:

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());

```