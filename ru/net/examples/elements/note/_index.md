---
title: Заметка
type: docs
weight: 240
url: /ru/net/examples/elements/elements/note/
keywords:
- пример заметки
- добавить слайд с заметками
- доступ к слайду с заметками
- удалить слайд с заметками
- обновить текст заметок
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Добавляйте, читайте, редактируйте и экспортируйте заметки докладчика на C# с помощью Aspose.Slides: форматируйте текст, управляйте заметками для каждого слайда и контролируйте их видимость в PowerPoint и OpenDocument."
---

Показывает, как добавлять, читать, удалять и обновлять слайды с заметками с помощью **Aspose.Slides for .NET**.

## **Добавить слайд с заметками**

Создайте слайд с заметками и задайте ему текст.
```csharp
static void Add_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```


## **Доступ к слайду с заметками**

Прочитайте текст из существующего слайда с заметками.
```csharp
static void Access_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```


## **Удалить слайд с заметками**

Удалите слайд с заметками, связанный со слайдом.
```csharp
static void Remove_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```


## **Обновить текст заметок**

Измените текст слайда с заметками.
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
