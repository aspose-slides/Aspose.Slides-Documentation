---
title: Управление заметками презентации в .NET
linktitle: Заметки презентации
type: docs
weight: 110
url: /ru/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Настройте заметки презентации с помощью Aspose.Slides для .NET. Беспрепятственно работайте с заметками PowerPoint и OpenDocument, чтобы повысить свою производительность."
---

Aspose.Slides поддерживает удаление слайдов с заметками из презентации. В этой статье мы представим новую возможность удаления заметок, а также добавления стилей заметок к слайдам в любой презентации. Aspose.Slides для .NET предоставляет возможность удаления заметок с любого слайда, а также добавления стиля к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки с конкретного слайда презентации.
- Удалить заметки со всех слайдов презентации.
## **Удалить заметки со слайда**
Заметки с некоторого конкретного слайда можно удалить, как показано в примере ниже:
```c#
// Создать объект Presentation, представляющий файл презентации 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Удаление заметок первого слайда
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Save presentation to disk
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```



## **Удалить заметки со всех слайдов**
Заметки со всех слайдов презентации можно удалить, как показано в примере ниже:
```c#
// Создать объект Presentation, представляющий файл презентации 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Удаление заметок со всех слайдов
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Сохранить презентацию на диск
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```



## **Добавить стиль заметок**
Свойство NotesStyle было добавлено в интерфейс [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) и класс [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) соответственно. Это свойство задает стиль текста заметок. Реализация продемонстрирована в примере ниже.
```c#
// Создать объект Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Получить стиль текста MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Установить символный маркер для абзацев первого уровня
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Сохранить файл PPTX на диск
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


## **FAQ**

**Какой объект API предоставляет доступ к заметкам конкретного слайда?**

Заметки доступны через менеджер заметок слайда: у слайда есть объект [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) и [свойство](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/), которое возвращает объект заметок, или `null`, если заметок нет.

**Есть ли различия в поддержке заметок в разных версиях PowerPoint, с которыми работает библиотека?**

Библиотека поддерживает широкий спектр форматов Microsoft PowerPoint (97‑и новее) и ODP; заметки поддерживаются в этих форматах без необходимости установленной копии PowerPoint.