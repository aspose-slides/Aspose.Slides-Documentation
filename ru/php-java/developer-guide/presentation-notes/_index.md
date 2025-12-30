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
- мастер заметки
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Настройте заметки презентации с Aspose.Slides для PHP через Java. Без проблем работайте с заметками PowerPoint и OpenDocument, повышая продуктивность."
---

{{% alert color="primary" %}} 

Aspose.Slides поддерживает удаление слайдов заметок из презентации. В этой статье мы представляем новую возможность удаления заметок, а также добавления стилей заметок к любой презентации. 

{{% /alert %}} 

Aspose.Slides for PHP via Java предоставляет возможность удалять заметки любого слайда, а также добавлять стиль к существующим заметкам. Разработчики могут удалять заметки следующими способами:

* Удалить заметки конкретного слайда презентации.
* Удалить заметки всех слайдов презентации.


## **Remove Notes from a Slide**
Заметки некоторого конкретного слайда можно удалить, как показано в примере ниже:
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


## **Remove Notes from a Presentation**
Заметки всех слайдов презентации можно удалить, как показано в примере ниже:
```php
  # Создать объект Presentation, представляющий файл презентации
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Удаление заметок всех слайдов
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


## **Add a Notes Style**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) метод был добавлен в интерфейс [IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) и класс [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) соответственно. Это свойство задает стиль текста заметок. Реализация продемонстрирована в примере ниже.
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

**Which API entity provides access to the notes of a specific slide?**

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/) и [method](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/getnotesslide/) который возвращает объект заметок, или `null`, если заметок нет.

**Are there differences in notes support across the PowerPoint versions the library works with?**

Библиотека поддерживает широкий диапазон форматов Microsoft PowerPoint (97‑newer) и ODP; заметки поддерживаются в этих форматах независимо от установленной копии PowerPoint.