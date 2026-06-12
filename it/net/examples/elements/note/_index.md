---
title: Note
type: docs
weight: 240
url: /it/net/examples/elements/note/
keywords:
- note
- aggiungi diapositiva delle note
- accedi alla diapositiva delle note
- rimuovi diapositiva delle note
- aggiorna il testo delle note
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Lavora con le note delle diapositive in Aspose.Slides per .NET: aggiungi, leggi, modifica ed esporta le note del relatore in PPT, PPTX e ODP con esempi chiari in C#."
---
Questo articolo dimostra come aggiungere, leggere, rimuovere e aggiornare le diapositive delle note utilizzando **Aspose.Slides for .NET**.

## **Aggiungere una diapositiva delle note**

Crea una diapositiva delle note e assegna del testo.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Accedere a una diapositiva delle note**

Leggi il testo da una diapositiva delle note esistente.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Rimuovere una diapositiva delle note**

Rimuovi la diapositiva delle note associata a una diapositiva.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Aggiornare il testo delle note**

Modifica il testo di una diapositiva delle note.

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