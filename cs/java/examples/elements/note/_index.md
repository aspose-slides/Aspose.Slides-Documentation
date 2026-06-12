---
title: Poznámka
type: docs
weight: 240
url: /cs/java/examples/elements/note/
keywords:
- ukázka kódu
- poznámka
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Pracujte s poznámkami ke snímkům v Aspose.Slides pro Java: přidávejte, čtěte, upravujte a exportujte poznámky řečníka v PPT, PPTX a ODP pomocí přehledných příkladů v jazyce Java."
---
Tento článek ukazuje, jak pomocí **Aspose.Slides for Java** přidávat, číst, odstraňovat a aktualizovat snímky s poznámkami.

## **Přidat snímek s poznámkou**

Vytvořte snímek s poznámkou a přiřaďte mu text.

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

## **Přístup ke snímku s poznámkou**

Přečtěte text z existujícího snímku s poznámkou.

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

## **Odstranit snímek s poznámkou**

Odstraňte poznámkový snímek spojený se snímkem.

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

## **Aktualizovat text poznámky**

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