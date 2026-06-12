---
title: Note
type: docs
weight: 240
url: /it/nodejs-java/examples/elements/note/
keywords:
- esempio di codice
- note
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Lavora con le note delle diapositive in Aspose.Slides per Node.js: aggiungi, leggi, modifica ed esporta le note del relatore in PPT, PPTX e ODP usando chiari esempi JavaScript."
---
Questo articolo mostra come aggiungere, leggere, rimuovere e aggiornare le diapositive delle note utilizzando **Aspose.Slides for Node.js via Java**.

## **Aggiungi una diapositiva delle note**

Crea una diapositiva delle note e assegnale del testo.

```js
function addNote() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().addNotesSlide();
        notesSlide.getNotesTextFrame().setText("My note");

        presentation.save("note.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a una diapositiva delle note**

Leggi il testo da una diapositiva delle note esistente.

```js
function accessNote() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().getNotesSlide();

        let notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi una diapositiva delle note**

Rimuovi la diapositiva delle note associata a una diapositiva.

```js
function removeNote() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getNotesSlideManager().removeNotesSlide();

        presentation.save("note_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Aggiorna il testo delle note**

Modifica il testo di una diapositiva delle note.

```js
function updateNoteText() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().getNotesSlide();
        notesSlide.getNotesTextFrame().setText("Updated");

        presentation.save("note_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```