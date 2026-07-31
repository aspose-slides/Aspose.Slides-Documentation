---
title: Заметка
type: docs
weight: 240
url: /ru/net/examples/elements/note/
aliases:
  - /net/examples/elements/elements/note/
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
description: "Работа со слайдами заметок в Aspose.Slides for .NET: добавление, чтение, редактирование и экспорт заметок докладчика в PPT, PPTX и ODP с помощью понятных примеров C#."
---
В этой статье демонстрируется, как добавлять, читать, удалять и обновлять слайды заметок с использованием **Aspose.Slides for .NET**.

## **Добавить слайд заметок**

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

## **Доступ к слайду заметок**

Прочитайте текст из существующего слайда заметок.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Удалить слайд заметок**

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

## **Обновить текст заметок**

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