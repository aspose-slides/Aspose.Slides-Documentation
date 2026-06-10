---
title: Jegyzet
type: docs
weight: 240
url: /hu/net/examples/elements/note/
keywords:
- jegyzet
- jegyzet dia hozzáadása
- jegyzet dia elérése
- jegyzet dia eltávolítása
- jegyzet szövegének frissítése
- kód példa
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Dolgozzon a diák jegyzeteivel az Aspose.Slides for .NET-ben: adjon hozzá, olvasson, szerkesszen, és exportáljon előadó jegyzeteket PPT, PPTX és ODP formátumban, tiszta C# példákkal."
---
Ez a cikk bemutatja, hogyan lehet hozzáadni, olvasni, eltávolítani és frissíteni a jegyzetdia‑kat a **Aspose.Slides for .NET** használatával.

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

Olvassa ki a szöveget egy meglévő jegyzetdiából.

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

Távolítsa el a diához társított jegyzetdiát.

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

Módosítsa a jegyzetdia szövegét.

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