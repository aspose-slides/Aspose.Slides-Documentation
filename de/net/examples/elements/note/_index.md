---
title: Notiz
type: docs
weight: 240
url: /de/net/examples/elements/note/
keywords:
- Notiz
- Notizfolie hinzufügen
- Zugriff auf Notizfolie
- Notizfolie entfernen
- Notiztext aktualisieren
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit Foliennotizen in Aspose.Slides für .NET: Hinzufügen, Lesen, Bearbeiten und Exportieren von Rednernotizen in PPT, PPTX und ODP mit klaren C#-Beispielen."
---
Dieser Artikel zeigt, wie man Notizfolien hinzufügt, liest, entfernt und aktualisiert, indem man **Aspose.Slides for .NET** verwendet.

## **Notizfolie hinzufügen**

Erstellen Sie eine Notizfolie und weisen Sie ihr Text zu.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Zugriff auf eine Notizfolie**

Lesen Sie Text aus einer vorhandenen Notizfolie.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Notizfolie entfernen**

Entfernen Sie die Notizfolie, die einer Folie zugeordnet ist.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Notiztext aktualisieren**

Ändern Sie den Text einer Notizfolie.

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