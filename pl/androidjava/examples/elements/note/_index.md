---
title: Notatka
type: docs
weight: 240
url: /pl/androidjava/examples/elements/note/
keywords:
- przykład kodu
- notatka
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Pracuj z notatkami slajdów w Aspose.Slides for Android: dodawaj, odczytuj, edytuj i eksportuj notatki prelegenta w formatach PPT, PPTX i ODP, korzystając z przejrzystych przykładów w języku Java."
---
Ten artykuł demonstruje, jak dodać, odczytać, usunąć i zaktualizować slajdy z notatkami przy użyciu **Aspose.Slides for Android via Java**.

## **Dodaj slajd z notatkami**

Utwórz slajd z notatkami i przypisz do niego tekst.

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

## **Uzyskaj dostęp do slajdu z notatkami**

Odczytaj tekst z istniejącego slajdu z notatkami.

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

## **Usuń slajd z notatkami**

Usuń slajd z notatkami powiązany z danym slajdem.

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

Zmień tekst slajdu z notatkami.

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