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
- главные заметки
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Настраивайте заметки презентации с помощью Aspose.Slides для Java. Беспрепятственно работайте с заметками PowerPoint и OpenDocument, чтобы повысить свою продуктивность."
---
## **Обзор**

Aspose.Slides поддерживает удаление заметок из презентации. В этой статье мы представим эту возможность, включая то, как удалять заметки и как применять стиль к слайдам заметок в презентации. Aspose.Slides позволяет удалять заметки с любого слайда, а также применять стили к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки с конкретного слайда в презентации.
- Удалить заметки со всех слайдов в презентации.

Чтобы прочитать или изменить размеры страницы заметок, поменять ориентацию и проверить поведение при экспорте, см. [Notes Page Size](/slides/ru/java/notes-size/).

## **Удалить заметки со слайда**
Заметки с конкретного слайда могут быть удалены, как показано в примере ниже:

```java
import com.aspose.slides.*;

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
Заметки со всех слайдов в презентации могут быть удалены, как показано в примере ниже:

```java
import com.aspose.slides.*;

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
Метод [getNotesStyle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) был добавлен в интерфейс [IMasterNotesSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IMasterNotesSlide) и класс [MasterNotesSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/MasterNotesSlide) соответственно. Это свойство задаёт стиль текста заметок. Реализация демонстрируется в примере ниже.

```java
import com.aspose.slides.*;

// Создайте объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Получить стиль текста MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Установить символный маркер для абзацев первого уровня
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Часто задаваемые вопросы**

**Какой объект API предоставляет доступ к заметкам конкретного слайда?**

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/notesslidemanager/) и [метод](https://reference.aspose.com/slides/ru/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) который возвращает объект заметок, или `null`, если заметок нет.

**Есть ли различия в поддержке заметок в разных версиях PowerPoint, с которыми работает библиотека?**

Библиотека охватывает широкий диапазон форматов Microsoft PowerPoint (97‑и новее) и ODP; поддержка заметок реализована во всех этих форматах без зависимости от установленной копии PowerPoint.