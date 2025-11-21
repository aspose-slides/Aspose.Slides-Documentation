---
title: Заметка
type: docs
weight: 240
url: /ru/net/examples/elements/elements/note/
keywords:
- пример заметки
- добавить слайд заметок
- доступ к слайду заметок
- удалить слайд заметок
- обновить текст заметок
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Добавляйте, читайте, редактируйте и экспортируйте заметки спикера в C# с Aspose.Slides: форматируйте текст, управляйте заметками для каждого слайда и контролируйте их видимость в PowerPoint и OpenDocument."
---

Показывает, как добавлять, читать, удалять и обновлять слайды заметок с помощью **Aspose.Slides for .NET**.

## Добавить слайд заметок

Создайте слайд заметок и назначьте ему текст.
```csharp
static void Add_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```


## Доступ к слайду заметок

Прочитайте текст из существующего слайда заметок.
```csharp
static void Access_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```


## Удалить слайд заметок

Удалите слайд заметок, связанный со слайдом.
```csharp
static void Remove_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```


## Обновить текст заметок

Измените текст слайда заметок.
```csharp
static void Update_Note_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```
