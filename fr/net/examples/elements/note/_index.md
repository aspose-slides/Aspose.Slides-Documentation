---
title: Note
type: docs
weight: 240
url: /fr/net/examples/elements/note/
keywords:
- note
- ajouter diapositive de notes
- accéder à une diapositive de notes
- supprimer diapositive de notes
- mettre à jour texte des notes
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travailler avec les notes de diapositive dans Aspose.Slides for .NET : ajouter, lire, modifier et exporter les notes du présentateur au format PPT, PPTX et ODP à l’aide d’exemples clairs en C#."
---
Cet article montre comment ajouter, lire, supprimer et mettre à jour des diapositives de notes à l’aide de **Aspose.Slides for .NET**.

## **Ajouter une diapositive de notes**

Créez une diapositive de notes et assignez-lui du texte.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Accéder à une diapositive de notes**

Lisez le texte d'une diapositive de notes existante.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Supprimer une diapositive de notes**

Supprimez la diapositive de notes associée à une diapositive.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Mettre à jour le texte des notes**

Modifiez le texte d'une diapositive de notes.

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