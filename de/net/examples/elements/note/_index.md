---
title: Notiz
type: docs
weight: 240
url: /de/net/examples/elements/elements/note/
keywords:
- Notizbeispiel
- Notizfolie hinzufügen
- Zugriff auf Notizfolie
- Notizfolie entfernen
- Notiztext aktualisieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Notizen hinzufügen, lesen, bearbeiten und exportieren in C# mit Aspose.Slides: Text formatieren, Notizen pro Folie verwalten und Sichtbarkeit in PowerPoint und OpenDocument steuern."
---

Zeigt, wie man Notizfolien hinzufügt, liest, entfernt und aktualisiert, indem man **Aspose.Slides for .NET** verwendet.

## **Notizfolie hinzufügen**

Erstellen Sie eine Notizfolie und weisen Sie ihr Text zu.
```csharp
static void Add_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```


## **Zugriff auf eine Notizfolie**

Lesen Sie Text von einer vorhandenen Notizfolie.
```csharp
static void Access_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```


## **Notizfolie entfernen**

Entfernen Sie die Notizfolie, die einer Folie zugeordnet ist.
```csharp
static void Remove_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```


## **Notiztext aktualisieren**

Ändern Sie den Text einer Notizfolie.
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
