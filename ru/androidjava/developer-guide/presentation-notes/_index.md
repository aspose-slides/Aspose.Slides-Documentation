---
title: Презентационные заметки
type: docs
weight: 110
url: /ru/androidjava/presentation-notes/
keywords: "Примечания к слайдам PowerPoint на Java"
description: "Презентационные заметки, заметки к докладу на Java"
---


{{% alert color="primary" %}} 

Aspose.Slides поддерживает удаление слайдов заметок из презентации. В этой теме мы представим эту новую функцию удаления заметок, а также добавления стиля заметок из любой презентации. 

{{% /alert %}} 

Aspose.Slides для Android через Java предоставляет возможность удаления заметок с любого слайда, а также добавления стиля к существующим заметкам. Разработчики могут удалять заметки следующими способами:

* Удалить заметки конкретного слайда в презентации.
* Удалить заметки со всех слайдов презентации.


## **Удалить заметки с слайда**
Заметки некоторого конкретного слайда можно удалить, как показано в следующем примере:

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

## **Удалить заметки из презентации**
Заметки со всех слайдов презентации можно удалить, как показано в следующем примере:

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

## **Добавить стиль заметок**
Метод [getNotesStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) был добавлен в интерфейс [IMasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide) и класс [MasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterNotesSlide) соответственно. Это свойство определяет стиль текстовых заметок. Реализация демонстрируется в следующем примере.

```java
// Создайте объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Получить стиль текста MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Установить символ маркировки для абзацев первого уровня
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```