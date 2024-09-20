---
title: Заметки к презентации
type: docs
weight: 110
url: /java/presentation-notes/
keywords: "Заметки выступающего PowerPoint на Java"
description: "Заметки к презентации, заметки выступающего на Java"
---


{{% alert color="primary" %}} 

Aspose.Slides поддерживает удаление слайдов заметок из презентации. В этой теме мы представим эту новую функцию удаления заметок, а также добавления стилей заметок из любой презентации. 

{{% /alert %}} 

Aspose.Slides для Java предоставляет возможность удаления заметок из любого слайда, а также добавления стилей к существующим заметкам. Разработчики могут удалять заметки следующими способами:

* Удаление заметок с конкретного слайда презентации.
* Удаление заметок со всех слайдов презентации.


## **Удаление заметок со слайда**
Заметки с конкретного слайда можно удалить, как показано в примере ниже:

```java
// Создание объекта Presentation, представляющего файл презентации
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Удаление заметок с первого слайда
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Сохранение презентации на диск
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удаление заметок из презентации**
Заметки со всех слайдов презентации можно удалить, как показано в примере ниже:

```java
// Создание объекта Presentation, представляющего файл презентации
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

## **Добавление стиля заметок**
Метод [getNotesStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) был добавлен в интерфейс [IMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide) и класс [MasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide) соответственно. Это свойство определяет стиль текста заметок. Реализация демонстрируется в примере ниже.

```java
// Создание объекта Presentation, представляющего файл презентации
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Получение стиля текста MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Установка символа ”точка” для параграфов первого уровня
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```