---
title: Управление заметками презентации на Android
linktitle: Заметки презентации
type: docs
weight: 110
url: /ru/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "Настройте заметки презентации с помощью Aspose.Slides для Android на Java. Без проблем работайте с заметками PowerPoint и OpenDocument, повышая свою продуктивность."
---
## **Обзор**

Aspose.Slides поддерживает удаление листов заметок из презентации. В этой теме мы представим эту возможность, включая то, как удалить заметки и как применить стиль к листам заметок в презентации. Aspose.Slides позволяет удалять заметки с любого слайда, а также применять оформление к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки с конкретного слайда в презентации.
- Удалить заметки со всех слайдов в презентации.

Чтобы просмотреть или изменить размеры страницы заметок, переключить ориентацию и проверить поведение экспорта, см. [Размер страницы заметок](/slides/ru/androidjava/notes-size/).

## **Удалить заметки со слайда**
Заметки с конкретного слайда можно удалить, как показано в примере ниже:

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
Заметки со всех слайдов в презентации можно удалить, как показано в примере ниже:

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
[getNotesStyle](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) method был добавлен в интерфейс [IMasterNotesSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IMasterNotesSlide) и класс [MasterNotesSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/MasterNotesSlide) соответственно. Это свойство задаёт стиль текста заметок. Реализация продемонстрирована в примере ниже.

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
    
        // Установить символный маркер для абзацев первого уровня
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Вопросы и ответы**

**Какой объект API предоставляет доступ к заметкам конкретного слайда?**

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/notesslidemanager/) и [метод](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) , который возвращает объект заметок, или `null`, если заметок нет.

**Есть ли различия в поддержке заметок в разных версиях PowerPoint, с которыми работает библиотека?**

Библиотека поддерживает широкий спектр форматов Microsoft PowerPoint (97 и новее) и ODP; заметки поддерживаются в этих форматах без зависимости от установленной копии PowerPoint.