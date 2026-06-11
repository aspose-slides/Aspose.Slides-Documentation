---
title: Notatka
type: docs
weight: 240
url: /pl/java/examples/elements/note/
keywords:
- przykład kodu
- notatka
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Pracuj z notatkami slajdów w Aspose.Slides for Java: dodawaj, odczytuj, edytuj i eksportuj notatki prelegenta w formatach PPT, PPTX i ODP, używając przejrzystych przykładów w języku Java."
---
Ten artykuł demonstruje, jak dodać, odczytać, usunąć i zaktualizować slajdy notatek przy użyciu **Aspose.Slides for Java**.

## **Dodaj slajd notatek**

Utwórz slajd notatek i przypisz do niego tekst.

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

## **Uzyskaj dostęp do slajdu notatek**

Odczytaj tekst z istniejącego slajdu notatek.

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

## **Usuń slajd notatek**

Usuń slajd notatek powiązany ze slajdem.

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

## **Zaktualizuj tekst notatek**

Zmień tekst slajdu notatek.

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