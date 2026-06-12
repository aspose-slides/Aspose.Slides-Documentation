---
title: Poznámka
type: docs
weight: 240
url: /cs/androidjava/examples/elements/note/
keywords:
- ukázkový kód
- poznámka
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Pracujte s poznámkami k snímkům v Aspose.Slides pro Android: přidávejte, čtěte, upravujte a exportujte poznámky přednášejícího v PPT, PPTX a ODP pomocí přehledných ukázek v Javě."
---
Tento článek ukazuje, jak pomocí **Aspose.Slides pro Android prostřednictvím Javy** přidávat, číst, odstraňovat a aktualizovat poznámkové snímky.

## **Přidat poznámkový snímek**

Vytvořte poznámkový snímek a přiřaďte mu text.

```java
static void addNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("My note");
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k poznámkovému snímku**

Přečtěte text z existujícího poznámkového snímku.

```java
static void accessNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        String notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit poznámkový snímek**

Odstraňte poznámkový snímek přiřazený ke snímku.

```java
static void removeNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().removeNotesSlide();
    } finally {
        presentation.dispose();
    }
}
```

## **Aktualizovat text poznámkového snímku**

Změňte text poznámkového snímku.

```java
static void updateNoteText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Old");
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Updated");
    } finally {
        presentation.dispose();
    }
}
```