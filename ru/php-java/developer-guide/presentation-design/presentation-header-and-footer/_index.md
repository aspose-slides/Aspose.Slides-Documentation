---
title: Управление заголовками и нижними колонтитулами презентации в PHP
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/php-java/presentation-header-and-footer/
keywords:
- заголовок
- текст заголовка
- нижний колонтитул
- текст нижнего колонтитула
- установить заголовок
- установить нижний колонтитул
- раздаточный материал
- заметки
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Используйте Aspose.Slides for PHP via Java, чтобы добавлять и настраивать заголовки и нижние колонтитулы в презентациях PowerPoint и OpenDocument для профессионального вида."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ru/php-java/) предоставляет поддержку работы с текстом заголовков и нижних колонтитулов слайдов, которые фактически управляются на уровне мастер‑слайда.

{{% /alert %}} 

[Aspose.Slides for PHP via Java](/slides/ru/php-java/) предоставляет возможность управления заголовками и нижними колонтитулами внутри слайдов презентации. Они фактически управляются на уровне мастер‑презентации.

## **Управление заголовками и нижними колонтитулами в презентации**
Заметки некоторых конкретных слайдов могут быть удалены, как показано в примере ниже:
```php
  # Загрузить презентацию
  $pres = new Presentation("headerTest.pptx");
  try {
    # Установка нижнего колонтитула
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Доступ и обновление заголовка
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Сохранить презентацию
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **Управление заголовками и нижними колонтитулами в раздаточных и заметках слайдах**
Aspose.Slides for PHP via Java поддерживает заголовки и нижние колонтитулы в раздаточных и нотных слайдах. Пожалуйста, выполните следующие шаги:

- Загрузите презентацию, содержащую видео.
- Измените настройки заголовка и нижнего колонтитула для мастера заметок и всех слайдов заметок.
- Сделайте видимыми заполнители нижнего колонтитула на мастер‑слайде заметок и всех дочерних слайдах.
- Сделайте видимыми заполнители даты и времени на мастер‑слайде заметок и всех дочерних слайдах.
- Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок.
- Сделайте видимым заполнитель заголовка на слайде заметок.
- Установите текст в заполнитель заголовка слайда заметок.
- Установите текст в заполнитель даты и времени слайда заметок.
- Сохраните изменённый файл презентации.

Ниже приведён пример кода.
```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Изменить настройки заголовка и нижнего колонтитула для мастера заметок и всех слайдов заметок
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// сделать мастер слайд заметок и все дочерние заполнители нижнего колонтитула видимыми

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// сделать мастер слайд заметок и все дочерние заполнители заголовка видимыми

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// сделать мастер слайд заметок и все дочерние заполнители номеров слайдов видимыми

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// сделать мастер слайд заметок и все дочерние заполнители даты и времени видимыми

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// установить текст в мастер слайд заметок и все дочерние заполнители заголовка

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// установить текст в мастер слайд заметок и все дочерние заполнители нижнего колонтитула

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// установить текст в мастер слайд заметок и все дочерние заполнители даты и времени

    }
    # Изменить настройки заголовка и нижнего колонтитула только для первого слайда заметок
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// сделать заполнитель заголовка этого слайда заметок видимым

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// сделать заполнитель нижнего колонтитула этого слайда заметок видимым

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// сделать заполнитель номера слайда этого слайда заметок видимым

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// сделать заполнитель даты и времени этого слайда заметок видимым

      $headerFooterManager->setHeaderText("New header text");// установить текст в заполнитель заголовка слайда заметок

      $headerFooterManager->setFooterText("New footer text");// установить текст в заполнитель нижнего колонтитула слайда заметок

      $headerFooterManager->setDateTimeText("New date and time text">// установить текст в заполнитель даты и времени слайда заметок

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **Часто задаваемые вопросы**

**Можно ли добавить "заголовок" к обычным слайдам?**

В PowerPoint заголовок существует только для заметок и раздаточных материалов; на обычных слайдах поддерживаются лишь нижний колонтитул, дата/время и номер слайда. В Aspose.Slides это соответствует тем же ограничениям: заголовок только для заметок/раздаточных, а на слайдах — нижний колонтитул, дата/время и номер слайда.

**Что если макет не содержит области нижнего колонтитула — можно ли включить её видимость?**

Да. Проверьте видимость через менеджер заголовков/нижних колонтитулов и включите её при необходимости. Эти индикаторы API и методы предназначены для случаев, когда заполнитель отсутствует или скрыт.

**Как сделать так, чтобы нумерация слайдов начиналась с значения, отличного от 1?**

Установите [первый номер слайда](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/); после этого вся нумерация пересчитается. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они рендерятся как обычные текстовые элементы презентации. То есть, если элементы видимы на слайдах/страницах заметок, они также появятся в выходном формате вместе с остальным содержимым.