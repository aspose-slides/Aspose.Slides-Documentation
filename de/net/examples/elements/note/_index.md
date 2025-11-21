---
title: Notiz
type: docs
weight: 240
url: /de/net/examples/elements/elements/note/
keywords:
- Beispiel für Notiz
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
description: "Notizen in C# mit Aspose.Slides hinzufügen, lesen, bearbeiten und exportieren: Text formatieren, Notizen pro Folie verwalten und Sichtbarkeit in PowerPoint und OpenDocument steuern."
---

Zeigt, wie man Notizfolien hinzufügt, liest, entfernt und aktualisiert, indem man **Aspose.Slides for .NET** verwendet.

## Add a Notes Slide
Eine Notizfolie hinzufügen

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


## Access a Notes Slide
Auf eine Notizfolie zugreifen

Lesen Sie den Text einer bestehenden Notizfolie.
```csharp
static void Access_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```


## Remove a Notes Slide
Eine Notizfolie entfernen

Entfernen Sie die mit einer Folie verbundene Notizfolie.
```csharp
static void Remove_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```


## Update Notes Text
Notiztext aktualisieren

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
