---
title: Notitie
type: docs
weight: 240
url: /nl/net/examples/elements/note/
aliases:
  - /net/examples/elements/elements/note/
keywords:
- notitie
- notitieslide toevoegen
- notitieslide openen
- notitieslide verwijderen
- notitietekst bijwerken
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Werk met dia-notities in Aspose.Slides voor .NET: voeg toe, lees, bewerk en exporteer presentatorenotities in PPT, PPTX en ODP met duidelijke C#-voorbeelden."
---
Dit artikel toont hoe u notitieslides kunt toevoegen, lezen, verwijderen en bijwerken met **Aspose.Slides for .NET**.

## **Een notitieslide toevoegen**

Maak een notitieslide aan en wijs er tekst aan toe.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Toegang tot een notitieslide**

Lees tekst van een bestaande notitieslide.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Een notitieslide verwijderen**

Verwijder de notitieslide die bij een slide hoort.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Notitietekst bijwerken**

Wijzig de tekst van een notitieslide.

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