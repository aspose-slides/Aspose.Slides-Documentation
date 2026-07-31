---
title: Anteckning
type: docs
weight: 240
url: /sv/net/examples/elements/note/
aliases:
  - /net/examples/elements/elements/anteckning/
keywords:
- anteckning
- lägg till anteckningsbild
- få åtkomst till anteckningsbild
- ta bort anteckningsbild
- uppdatera anteckningstext
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Arbeta med bildanteckningar i Aspose.Slides för .NET: lägg till, läs, redigera och exportera talaranteckningar i PPT, PPTX och ODP med tydliga C#-exempel."
---
Denna artikel visar hur du lägger till, läser, tar bort och uppdaterar anteckningsbilder med **Aspose.Slides for .NET**.

## **Lägg till en anteckningsbild**

Skapa en anteckningsbild och tilldela text till den.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Få åtkomst till en anteckningsbild**

Läs text från en befintlig anteckningsbild.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Ta bort en anteckningsbild**

Ta bort anteckningsbilden som är associerad med en bild.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Uppdatera anteckningstext**

Ändra texten på en anteckningsbild.

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