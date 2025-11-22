---
title: Примечания к презентации
type: docs
weight: 110
url: /ru/net/presentation-notes/
keywords: "Примечания, Примечания PowerPoint, добавить примечания, удалить примечания, Презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Добавлять и удалять примечания в презентациях PowerPoint на C# или .NET"
---

Aspose.Slides поддерживает удаление слайдов с заметками из презентации. В этой статье мы представим новую возможность удаления заметок, а также добавления стилей заметок к слайдам любой презентации. Aspose.Slides для .NET предоставляет возможность удалять заметки с любого слайда, а также добавлять стиль к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки с определённого слайда презентации.
- Удалить заметки со всех слайдов презентации.

## **Удалить заметки со слайда**
Заметки с конкретного слайда могут быть удалены, как показано в примере ниже:
```c#
// Создать объект Presentation, который представляет файл презентации 
// Удалить заметки первого слайда
// Сохранить презентацию на диск
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Removing notes of first slide
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Save presentation to disk
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Удалить заметки со всех слайдов**
Заметки со всех слайдов презентации могут быть удалены, как показано в примере ниже:
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


## **Добавить NotesStyle**
Свойство NotesStyle было добавлено в интерфейс [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) и класс [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) соответственно. Это свойство задаёт стиль текста заметок. Реализация демонстрируется в примере ниже.
```c#
// Создать объект Presentation, который представляет файл презентации
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Получить стиль текста MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Set символный маркер для абзацев первого уровня
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Сохранить файл PPTX на диск
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


## **FAQ**

**Какой объект API предоставляет доступ к заметкам конкретного слайда?**

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) и [property](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/), который возвращает объект заметок, или `null`, если заметок нет.

**Существуют ли различия в поддержке заметок в разных версиях PowerPoint, с которыми работает библиотека?**

Библиотека поддерживает широкий спектр форматов Microsoft PowerPoint (97 и новее) и ODP; заметки поддерживаются в этих форматах без необходимости установленной копии PowerPoint.