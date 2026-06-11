---
title: Notatka
type: docs
weight: 240
url: /pl/net/examples/elements/note/
keywords:
- notatka
- dodaj slajd z notatkami
- dostęp do slajdu z notatkami
- usuń slajd z notatkami
- zaktualizuj tekst notatek
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Pracuj z notatkami slajdów w Aspose.Slides dla .NET: dodawaj, odczytuj, edytuj i eksportuj notatki prelegenta w formatach PPT, PPTX i ODP, używając przejrzystych przykładów w C#."
---
Ten artykuł demonstruje, jak dodać, odczytać, usunąć i zaktualizować slajdy notatek przy użyciu **Aspose.Slides for .NET**.

## **Dodaj slajd z notatkami**

Utwórz slajd z notatkami i przypisz do niego tekst.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Uzyskaj dostęp do slajdu z notatkami**

Odczytaj tekst z istniejącego slajdu z notatkami.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Usuń slajd z notatkami**

Usuń slajd z notatkami powiązany ze slajdem.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Zaktualizuj tekst notatek**

Zmień tekst slajdu z notatkami.

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