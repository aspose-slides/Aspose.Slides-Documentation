---
title: Jegyzet
type: docs
weight: 240
url: /hu/net/examples/elements/note/
aliases:
  - /net/examples/elements/elements/note/
keywords:
- jegyzet
- jegyzetdia hozzáadása
- jegyzetdia elérése
- jegyzetdia eltávolítása
- jegyzet szövegének frissítése
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET-ben a diához tartozó jegyzetek kezelése: jegyzetek hozzáadása, olvasása, szerkesztése és hangjegyzetek exportálása PPT, PPTX és ODP formátumokban, világos C# példákkal."
---
Ez a cikk bemutatja, hogyan lehet hozzáadni, olvasni, eltávolítani és frissíteni a jegyzetdia-kat a **Aspose.Slides for .NET** használatával.

## **Jegyzetdia hozzáadása**

Hozzon létre egy jegyzetdiát, és rendelje hozzá a szöveget.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Jegyzetdia elérése**

Olvassa ki a szöveget egy meglévő jegyzetdiáról.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Jegyzetdia eltávolítása**

Távolítsa el a diához kapcsolódó jegyzetdiát.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Jegyzet szövegének frissítése**

Módosítsa egy jegyzetdia szövegét.

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