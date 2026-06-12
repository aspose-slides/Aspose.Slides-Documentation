---
title: Notitie
type: docs
weight: 240
url: /nl/androidjava/examples/elements/note/
keywords:
- codevoorbeeld
- notitie
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Werk met notities van dia's in Aspose.Slides voor Android: voeg toe, lees, bewerk en exporteer spreker‑notities in PPT, PPTX en ODP met duidelijke Java‑voorbeelden."
---
Dit artikel laat zien hoe u notitieslides kunt toevoegen, lezen, verwijderen en bijwerken met **Aspose.Slides for Android via Java**.

## **Notitieslide toevoegen**

Maak een notitieslide en ken er tekst aan toe.

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

Lees de tekst van een bestaande notitieslide.

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

## **Notitieslide verwijderen**

Verwijder de notitieslide die gekoppeld is aan een slide.

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

## **Tekst van notitieslide bijwerken**

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