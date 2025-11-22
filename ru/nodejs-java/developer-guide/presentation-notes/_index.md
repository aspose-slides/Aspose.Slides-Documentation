---
title: Заметки презентации
type: docs
weight: 110
url: /ru/nodejs-java/presentation-notes/
keywords: "Заметки докладчика PowerPoint в JavaScript"
description: "Заметки презентации, заметки докладчика в JavaScript"
---

{{% alert color="primary" %}} 

Aspose.Slides поддерживает удаление слайдов с заметками из презентации. В этой статье мы представим новую возможность удаления заметок, а также добавления стилей заметок к любой презентации. 

{{% /alert %}} 

Aspose.Slides for Node.js via Java предоставляет возможность удалять заметки любого слайда, а также добавлять стиль к существующим заметкам. Разработчики могут удалять заметки следующими способами:

* Убрать заметки конкретного слайда презентации.
* Убрать заметки со всех слайдов презентации


## **Удалить заметки со слайда**
Заметки конкретного слайда можно удалить, как показано в примере ниже:
```javascript
// Создать объект Presentation, который представляет файл презентации
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
Заметки всех слайдов презентации можно удалить, как показано в примере ниже:
```javascript
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


## **Добавить стиль заметок**
[getNotesStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) метод был добавлен в класс [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) и класс [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide). Это свойство определяет стиль текста заметок. Реализация продемонстрирована в примере ниже.
```javascript
// Создать объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Получить стиль текста MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Установить символный маркер для абзацев первого уровня
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Какой объект API предоставляет доступ к заметкам конкретного слайда?**

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/) и [method](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/), который возвращает объект заметок, или `null`, если заметок нет.

**Есть ли различия в поддержке заметок в разных версиях PowerPoint, с которыми работает библиотека?**

Библиотека поддерживает широкий диапазон форматов Microsoft PowerPoint (97-newer) и ODP; заметки поддерживаются в этих форматах без необходимости установленной копии PowerPoint.