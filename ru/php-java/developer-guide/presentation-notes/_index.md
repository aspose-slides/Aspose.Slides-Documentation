---
title: Управление заметками презентации в PHP
linktitle: Заметки презентации
type: docs
weight: 110
url: /ru/php-java/presentation-notes/
keywords:
- заметки
- слайд заметок
- добавить заметки
- удалить заметки
- стиль заметок
- мастер-заметки
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Настраивайте заметки презентации с помощью Aspose.Slides для PHP через Java. Беспрепятственно работайте с заметками PowerPoint и OpenDocument, чтобы повысить свою продуктивность."
---
## **Обзор**

Aspose.Slides поддерживает удаление заметок со слайдов презентации. В этой статье мы расскажем об этой возможности, включая то, как удалить заметки и как применить стиль к слайдам заметок в презентации. Aspose.Slides позволяет удалять заметки с любого слайда и также применять стили к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки с конкретного слайда в презентации.
- Удалить заметки со всех слайдов в презентации.

Чтобы прочитать или изменить размеры страницы заметок, сменить ориентацию и проверить поведение экспорта, см. [Размер страницы заметок](/slides/ru/php-java/notes-size/).

## **Удалить заметки со слайда**
Заметки с конкретного слайда можно удалить, как показано в примере ниже:

```php
  # Создать объект Presentation, представляющий файл презентации
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Удаление заметок первого слайда
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

## **Удалить заметки из презентации**
Заметки со всех слайдов в презентации можно удалить, как показано в примере ниже:

```php
  # Создать объект Presentation, представляющий файл презентации
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

## **Добавить стиль заметок**
Метод [getNotesStyle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) класса [MasterNotesSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/MasterNotesSlide) предоставляет доступ к стилю текста заметок. Реализация продемонстрирована в примере ниже.

```php
  # Создать объект Presentation, представляющий файл презентации
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Получить стиль текста MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Установить символный маркер для абзацев первого уровня
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

## **FAQ**

**Какой объект API предоставляет доступ к заметкам конкретного слайда?**

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notesslidemanager/) и [method](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notesslidemanager/getnotesslide/), который возвращает объект заметок, либо `null`, если заметок нет.

**Есть ли различия в поддержке заметок между версиями PowerPoint, с которыми работает библиотека?**

Библиотека ориентирована на широкий диапазон форматов Microsoft PowerPoint (97‑newer) и ODP; заметки поддерживаются в этих форматах без зависимости от установленной копии PowerPoint.