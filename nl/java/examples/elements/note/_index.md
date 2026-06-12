---
title: Notitie
type: docs
weight: 240
url: /nl/java/examples/elements/note/
keywords:
- codevoorbeeld
- notitie
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Werken met notitieslides in Aspose.Slides for Java: toevoegen, lezen, bewerken en exporteren van spreker-notities in PPT, PPTX en ODP met duidelijke Java-voorbeelden."
---
Dit artikel toont hoe u notitieslides kunt toevoegen, lezen, verwijderen en bijwerken met **Aspose.Slides for Java**.

## **Een notitieslide toevoegen**

Maak een notitieslide aan en wijs er tekst aan toe.

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

## **Toegang tot een notitieslide**

Lees tekst van een bestaande notitieslide.

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

## **Een notitieslide verwijderen**

Verwijder de notitieslide die aan een slide is gekoppeld.

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

## **Notitietekst bijwerken**

Wijzig de tekst van een notitieslide.

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