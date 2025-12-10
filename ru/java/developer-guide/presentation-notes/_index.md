---
title: Управление заметками презентации в Java
linktitle: Заметки презентации
type: docs
weight: 110
url: /ru/java/presentation-notes/
keywords:
- заметки
- слайд заметок
- добавить заметки
- удалить заметки
- стиль заметок
- мастер заметок
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Настройте заметки презентации с помощью Aspose.Slides для Java. Бесшовно работайте с заметками PowerPoint и OpenDocument, повышая свою производительность."
---

{{% alert color="primary" %}} 

Aspose.Slides поддерживает удаление слайдов с заметками из презентации. В этой статье мы представим новую возможность удаления заметок, а также добавления стилей заметок к любому слайду. 

{{% /alert %}} 

Aspose.Slides for Java предоставляет возможность удалять заметки любого слайда, а также применять стиль к существующим заметкам. Разработчики могут удалять заметки следующими способами:

* Удалить заметки конкретного слайда презентации.
* Удалить заметки всех слайдов презентации


## **Remove Notes from a Slide**
Заметки конкретного слайда могут быть удалены, как показано в примере ниже:
```java
// Создайте объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Удаление заметок первого слайда
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Сохранение презентации на диск
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Remove Notes from a Presentation**
Заметки всех слайдов презентации могут быть удалены, как показано в примере ниже:
```java
// Создайте объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Удаление заметок со всех слайдов
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Сохранение презентации на диск
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Add a Notes Style**
Метод[getNotesStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) был добавлен в интерфейс[IMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide) и класс[MasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide) соответственно. Это свойство определяет стиль текста заметок. Реализация продемонстрирована в примере ниже.
```java
// Создайте объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Получить стиль текста MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Установить символный маркер для абзацев первого уровня
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

Заметки доступны через менеджер заметок слайда: у слайда есть[NotesSlideManager](https://reference.aspose.com/slides/java/com.aspose.slides/notesslidemanager/) и[method](https://reference.aspose.com/slides/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) который возвращает объект заметок, или `null`, если заметок нет.

**Are there differences in notes support across the PowerPoint versions the library works with?**

Библиотека охватывает широкий диапазон форматов Microsoft PowerPoint (97‑newer) и ODP; поддержка заметок реализована во всех этих форматах без зависимости от установленной копии PowerPoint.