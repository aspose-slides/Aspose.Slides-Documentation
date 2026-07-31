---
title: Poznámka
type: docs
weight: 240
url: /cs/net/examples/elements/note/
aliases:
  - /net/examples/elements/elements/note/
keywords:
- poznámka
- přidat poznámkový snímek
- přístup k poznámkovému snímku
- odstranit poznámkový snímek
- aktualizovat text poznámek
- ukázkový kód
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Práce s poznámkami ke snímkům v Aspose.Slides pro .NET: přidávejte, čtěte, upravujte a exportujte poznámky přednášejícího v PPT, PPTX a ODP pomocí přehledných příkladů v C#."
---
Tento článek ukazuje, jak pomocí **Aspose.Slides for .NET** přidávat, číst, odstraňovat a aktualizovat poznámkové snímky.

## **Přidání poznámkového snímku**

Vytvořte poznámkový snímek a přiřaďte mu text.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Přístup k poznámkovému snímku**

Načtěte text z existujícího poznámkového snímku.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Odstranění poznámkového snímku**

Odstraňte poznámkový snímek přiřazený ke snímku.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Aktualizace textu poznámkového snímku**

Změňte text poznámkového snímku.

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