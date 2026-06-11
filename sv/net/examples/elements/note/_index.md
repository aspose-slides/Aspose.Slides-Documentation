---
title: Anteckning
type: docs
weight: 240
url: /sv/net/examples/elements/note/
keywords:
- anteckning
- lägg till anteckningsslide
- åtkomst till anteckningsslide
- ta bort anteckningsslide
- uppdatera anteckningstext
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Arbeta med bildanteckningar i Aspose.Slides för .NET: lägg till, läs, redigera och exportera presentatörsanteckningar i PPT, PPTX och ODP med tydliga C#-exempel."
---
Denna artikel visar hur man lägger till, läser, tar bort och uppdaterar notslides med **Aspose.Slides for .NET**.

## **Lägg till en anteckningsslide**

Skapa en anteckningsslide och tilldela text till den.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Åtkomst till en anteckningsslide**

Läs text från en befintlig anteckningsslide.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Ta bort en anteckningsslide**

Ta bort anteckningssliden som är kopplad till en bild.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Uppdatera anteckningstexten**

Ändra texten på en anteckningsslide.

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