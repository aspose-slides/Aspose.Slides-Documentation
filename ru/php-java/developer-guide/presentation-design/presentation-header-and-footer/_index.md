---
title: Заголовок и нижний колонтитул презентации
type: docs
weight: 140
url: /ru/php-java/presentation-header-and-footer/
keywords: "Заголовок и нижний колонтитул PowerPoint"
description: "Заголовок и нижний колонтитул PowerPoint"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ru/php-java/) предоставляет поддержку для работы с текстом заголовков и нижних колонтитулов слайдов, которые фактически находятся на уровне главного слайда.

{{% /alert %}} 

[Aspose.Slides для PHP через Java](/slides/ru/php-java/) предоставляет возможность управления заголовками и нижними колонтитулами внутри слайдов презентации. Эти элементы фактически управляются на уровне главной презентации.

## **Управление заголовком и нижним колонтиталом в презентации**
Заметки некоторых конкретных слайдов могут быть удалены, как показано в примере ниже:

```php
  # Загрузка презентации
  $pres = new Presentation("headerTest.pptx");
  try {
    # Установка нижнего колонтитула
    $pres->getHeaderFooterManager()->setAllFootersText("Мой текст нижнего колонтитула");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Доступ и обновление заголовка
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Сохранение презентации
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Управление заголовком и нижним колонтиталом в раздаточных материалах и заметках к слайдам**
Aspose.Slides для PHP через Java поддерживает заголовки и нижние колонтитулы в раздаточных материалах и заметках к слайдам. Пожалуйста, следуйте приведенным ниже шагам:

- Загрузите [Презентацию](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащую видео.
- Измените настройки заголовка и нижнего колонтитула для главных заметок и всех заметок слайдов.
- Установите видимость главных заметок слайда и всех дочерних элементов нижнего колонтитула.
- Установите видимость главных заметок слайда и всех дочерних элементов с датой и временем.
- Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок.
- Установите видимость элемента заголовка слайда заметок.
- Установите текст в элемент заголовка слайда заметок.
- Установите текст в элемент с датой и временем слайда заметок.
- Запишите измененный файл презентации.

Кодовый фрагмент представлен в следующем примере.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Измените настройки заголовка и нижнего колонтитула для главных заметок и всех заметок слайдов
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// сделать главный слайд заметок и все дочерние элементы нижнего колонтитула видимыми

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// сделать главный слайд заметок и все дочерние элементы заголовка видимыми

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// сделать главный слайд заметок и все дочерние элементы номера слайда видимыми

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// сделать главный слайд заметок и все дочерние элементы с датой и временем видимыми

      $headerFooterManager->setHeaderAndChildHeadersText("Текст заголовка");// установить текст для главного слайда заметок и всех дочерних элементов заголовка

      $headerFooterManager->setFooterAndChildFootersText("Текст нижнего колонтитула");// установить текст для главного слайда заметок и всех дочерних элементов нижнего колонтитула

      $headerFooterManager->setDateTimeAndChildDateTimesText("Текст даты и времени");// установить текст для главного слайда заметок и всех дочерних элементов с датой и временем

    }
    # Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// сделать этот элемент заголовка слайда заметок видимым

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// сделать этот элемент нижнего колонтитула слайда заметок видимым

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// сделать этот элемент номера слайда заметок видимым

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// сделать этот элемент с датой и временем слайда заметок видимым

      $headerFooterManager->setHeaderText("Новый текст заголовка");// установить текст для элемента заголовка слайда заметок

      $headerFooterManager->setFooterText("Новый текст нижнего колонтитула");// установить текст для элемента нижнего колонтитула слайда заметок

      $headerFooterManager->setDateTimeText("Новый текст даты и времени");// установить текст для элемента с датой и временем слайда заметок

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```