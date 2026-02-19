---
title: Заметка
type: docs
weight: 240
url: /ru/net/examples/elements/note/
keywords:
- заметка
- добавить слайд заметок
- доступ к слайду заметок
- удалить слайд заметок
- обновить текст заметок
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работа с заметками слайдов в Aspose.Slides for .NET: добавление, чтение, редактирование и экспорт заметок диктора в форматах PPT, PPTX и ODP с помощью понятных примеров на C#."
---
В этой статье демонстрируется, как добавлять, считывать, удалять и обновлять слайды заметок с помощью **Aspose.Slides for .NET**.

## **Add a Notes Slide**
Создайте слайд заметок и задайте ему текст.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Access a Notes Slide**
Считайте текст из существующего слайда заметок.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Remove a Notes Slide**
Удалите слайд заметок, связанный со слайдом.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Update Notes Text**
Измените текст слайда заметок.

```csharp
static void UpdateNoteText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```