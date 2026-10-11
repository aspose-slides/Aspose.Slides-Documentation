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
description: "Настраивайте заметки презентации с помощью Aspose.Slides для .NET. Бесшовно работайте с заметками PowerPoint и OpenDocument, чтобы повысить свою продуктивность."
---
## **Обзор**

Aspose.Slides поддерживает удаление слайдов заметок из презентации. В этой статье мы представим эту функцию, включая то, как удалять заметки и как применять стиль к слайдам заметок в презентации. Aspose.Slides позволяет удалять заметки с любого слайда, а также применять стили к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки с конкретного слайда в презентации.
- Удалить заметки со всех слайдов в презентации.

Чтобы просмотреть или изменить размеры страницы заметок, изменить ориентацию и проверить поведение экспорта, см. [Notes Page Size](/slides/ru/net/notes-size/).

## **Удалить заметки со слайда**
Заметки с некоторого конкретного слайда могут быть удалены, как показано в примере ниже:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте объект Presentation, представляющий файл презентации
Presentation presentation = new Presentation("AccessSlides.pptx");

// Удаление заметок с первого слайда
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Сохранить презентацию на диск
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Удалить заметки со всех слайдов**
Заметки со всех слайдов презентации могут быть удалены, как показано в примере ниже:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте объект Presentation, представляющий файл презентации
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
Свойство NotesStyle было добавлено в интерфейс [IMasterNotesSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/imasternotesslide) и класс [MasterNotesSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/masternotesslide) соответственно. Это свойство определяет стиль текста заметок. Реализация продемонстрирована в примере ниже.

```c#
using Aspose.Slides;

// Создайте объект класса Presentation, представляющий файл презентации
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

## **Вопросы и ответы**

### Какой объект API предоставляет доступ к заметкам конкретного слайда?

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/ru/net/aspose.slides/notesslidemanager/) и [свойство](https://reference.aspose.com/slides/ru/net/aspose.slides/notesslidemanager/notesslide/), которое возвращает объект заметок, или `null`, если заметок нет.

### Есть ли различия в поддержке заметок между версиями PowerPoint, с которыми работает библиотека?

Библиотека поддерживает широкий спектр форматов Microsoft PowerPoint (97‑и новее) и ODP; заметки поддерживаются в этих форматах без зависимости от установленной копии PowerPoint.