---
title: "Управление заметками презентации в JavaScript"
linktitle: "Заметки презентации"
type: docs
weight: 110
url: /ru/nodejs-java/presentation-notes/
keywords:
- "заметки"
- "слайд заметок"
- "добавить заметки"
- "удалить заметки"
- "стиль заметок"
- "основные заметки"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Настройте заметки презентации в JavaScript с помощью Aspose.Slides для Node.js. Бесшовно работайте с заметками PowerPoint и OpenDocument, чтобы повысить свою продуктивность."
---
## **Обзор**

Aspose.Slides поддерживает удаление слайдов с заметками из презентации. В этой статье мы представим эту функцию, включая способы удаления заметок и применения стиля к слайдам с заметками в презентации. Aspose.Slides позволяет удалять заметки с любого слайда, а также применять стили к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки с определённого слайда в презентации.
- Удалить заметки со всех слайдов в презентации.

Чтобы прочитать или изменить размеры страницы заметок, переключить ориентацию и проверить поведение при экспорте, см. [Размер страницы заметок](/slides/ru/nodejs-java/notes-size/).

## **Удалить заметки со слайда**
Заметки с определённого слайда можно удалить, как показано в примере ниже:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создать объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Удаление заметок первого слайда
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Сохранение презентации на диск
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Удалить заметки из презентации**
Заметки со всех слайдов в презентации можно удалить, как показано в примере ниже:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создать объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Удаление заметок со всех слайдов
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Сохранение презентации на диск
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Добавить NotesStyle**
Метод [getNotesStyle](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) был добавлен в класс [MasterNotesSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/MasterNotesSlide) и класс [MasterNotesSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/MasterNotesSlide) соответственно. Это свойство задаёт стиль текста заметок. Реализация продемонстрирована в примере ниже.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создать объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Получить стиль текста MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Установить маркировку символом для абзацев первого уровня
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Какой объект API предоставляет доступ к заметкам определённого слайда?**

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notesslidemanager/) и [метод](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/), который возвращает объект заметок, или `null`, если заметок нет.

**Есть ли различия в поддержке заметок между версиями PowerPoint, с которыми работает библиотека?**

Библиотека поддерживает широкий набор форматов Microsoft PowerPoint (97‑и новее) и ODP; заметки поддерживаются в этих форматах без необходимости установленной копии PowerPoint.