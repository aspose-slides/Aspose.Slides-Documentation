---
title: Note
type: docs
weight: 240
url: /net/examples/elements/elements/note
---

Shows how to add, read, remove, and update notes slides using **Aspose.Slides for .NET**.

## Add a Notes Slide

Create a notes slide and assign text to it.

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

Read text from an existing notes slide.

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

Remove the notes slide associated with a slide.

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

Change the text of a notes slide.

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
