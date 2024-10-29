---
title: Примечания к презентации
type: docs
weight: 110
url: /ru/net/presentation-notes/
keywords: "Примечания, примечания PowerPoint, добавление заметок, удаление заметок, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавление и удаление заметок в презентациях PowerPoint на C# или .NET"
---



Aspose.Slides поддерживает удаление слайдов с заметками из презентации. В этой теме мы познакомим вас с новой функцией удаления заметок, а также добавления слайдов стиля заметок из любой презентации. Aspose.Slides для .NET предоставляет возможность удаления заметок любого слайда, а также добавления стиля к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки конкретного слайда презентации.
- Удалить заметки всех слайдов презентации.
## **Удалить заметки со слайда**
Заметки с конкретного слайда могут быть удалены, как показано в примере ниже:

```c#
// Создаем объект Presentation, представляющий файл презентации 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Удаление заметок первого слайда
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Сохранение презентации на диск
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Удалить заметки со всех слайдов**
Заметки всех слайдов презентации могут быть удалены, как показано в примере ниже:

```c#
// Создаем объект Presentation, представляющий файл презентации 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Удаление заметок со всех слайдов
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Сохранение презентации на диск
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Добавить стиль заметок**
Свойство NotesStyle было добавлено к интерфейсу  [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) и классу [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) соответственно. Это свойство определяет стиль текста заметок. Реализация продемонстрирована в примере ниже.

```c#
// Создаем класс Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Получаем стиль текста MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // Установить символ буллета для параграфов первого уровня
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Сохранить файл PPTX на диск
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```