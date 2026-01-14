---
title: Продвинутое извлечение текста из презентаций на PHP
linktitle: Извлечение текста
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

Не редкость, когда разработчикам необходимо извлечь текст из презентации. Для этого нужно извлечь текст из всех фигур на всех слайдах презентации. В этой статье объясняется, как извлечь текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. 

{{% /alert %}} 
## **Извлечение текста со слайдов**
Aspose.Slides for PHP via Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/). Этот класс раскрывает несколько перегруженных статических методов для извлечения полного текста из презентации или слайда. Чтобы извлечь текст со слайда в PPTX‑презентации, используйте перегруженный статический метод [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextboxes/) , предоставляемый классом [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/). Этот метод принимает объект Slide в качестве параметра.
При выполнении метод Slide сканирует весь текст со слайда, переданного в качестве параметра, и возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) . Это означает, что любое форматирование текста доступно. Следующий фрагмент кода извлекает весь текст с первого слайда презентации:
```php
  # Создайте экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # Получить массив объектов ITextFrame со всех слайдов в PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # Итерировать массив TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # Итерировать абзацы в текущем ITextFrame
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # Итерировать части в текущем IParagraph
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
Чтобы просканировать текст всей презентации, используйте статический метод [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextframes/) , предоставляемый классом SlideUtil. Он принимает два параметра:

1. Во‑первых, объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) , представляющий презентацию, из которой извлекается текст.
2. Во‑вторых, булево значение, определяющее, включать ли главный слайд при сканировании текста презентации.  
Метод возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) , содержащих информацию о форматировании текста. Приведённый ниже код сканирует текст и информацию о форматировании из презентации, включая главные слайды.
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
В класс Presentation добавлен новый статический метод getPresentationText. У этого метода три перегрузки:
```php

```


## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже большие презентации, что делает его подходящим для сценариев реального времени или пакетной обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм в презентациях?**

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайда, позволяя легко получать и анализировать весь текстовый контент.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, однако она имеет определённые ограничения, например, обработку только ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.