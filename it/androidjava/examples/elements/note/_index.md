---
title: Nota
type: docs
weight: 240
url: /it/androidjava/examples/elements/note/
keywords:
- esempio di codice
- nota
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Lavorare con le note delle diapositive in Aspose.Slides per Android: aggiungere, leggere, modificare ed esportare le note del relatore in PPT, PPTX e ODP usando chiari esempi Java."
---
Questo articolo dimostra come aggiungere, leggere, rimuovere e aggiornare le diapositive di note usando **Aspose.Slides for Android via Java**.

## **Aggiungi una diapositiva di note**

Crea una diapositiva di note e assegnale del testo.

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

## **Accedi a una diapositiva di note**

Leggi il testo da una diapositiva di note esistente.

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

## **Rimuovi una diapositiva di note**

Rimuovi la diapositiva di note associata a una diapositiva.

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

## **Aggiorna il testo delle note**

Modifica il testo di una diapositiva di note.

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