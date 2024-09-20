---
title: Записки к презентации
type: docs
weight: 110
url: /php-java/presentation-notes/
keywords: "Заметки докладчика PowerPoint"
description: "Записки к презентации, заметки докладчика"
---


{{% alert color="primary" %}} 

Aspose.Slides поддерживает удаление заметок слайдов из презентации. В этом разделе мы представим эту новую функцию удаления заметок, а также добавления стиля заметок из любой презентации. 

{{% /alert %}} 

Aspose.Slides для PHP через Java предоставляет возможность удаления заметок с любого слайда, а также добавления стиля к существующим заметкам. Разработчики могут удалять заметки следующими способами:

* Удалить заметки конкретного слайда презентации.
* Удалить заметки со всех слайдов презентации


## **Удаление заметок со слайда**
Заметки конкретного слайда могут быть удалены, как показано в примере ниже:

```php
  # Создание объекта Presentation, представляющего файл презентации
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Удаление заметок с первого слайда
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Сохранение презентации на диск
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Удаление заметок из презентации**
Заметки со всех слайдов презентации могут быть удалены, как показано в примере ниже:

```php
  # Создание объекта Presentation, представляющего файл презентации
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Удаление заметок со всех слайдов
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Сохранение презентации на диск
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление стиля заметок**
Метод [getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) был добавлен в интерфейс [IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) и класс [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) соответственно. Эта функция определяет стиль текста заметок. Реализация показана в примере ниже.

```php
  # Создание объекта Presentation, представляющего файл презентации
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Получение стиля текста MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Установить символ для первого уровня абзацев
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```