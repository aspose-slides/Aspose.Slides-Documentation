---
title: Note
type: docs
weight: 240
url: /it/php-java/examples/elements/note/
keywords:
- note
- aggiungi diapositiva di note
- accedi alla diapositiva di note
- rimuovi diapositiva di note
- aggiorna testo delle note
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Aggiungi, leggi, modifica ed esporta le note del relatore in PHP con Aspose.Slides: formatta il testo, gestisci le note per diapositiva e controlla la visibilità in PowerPoint e OpenDocument."
---
Mostra come aggiungere, leggere, rimuovere e aggiornare le diapositive delle note utilizzando **Aspose.Slides for PHP via Java**.

## **Aggiungi una diapositiva di note**

Crea una diapositiva di note e assegna del testo.

```php
function addNote() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("My note");

        $presentation->save("note.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedi a una diapositiva di note**

Leggi il testo da una diapositiva di note esistente.

```php
function accessNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notes = $notesSlide->getNotesTextFrame()->getText();
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi una diapositiva di note**

Rimuovi la diapositiva di note associata a una diapositiva.

```php
function removeNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getNotesSlideManager()->removeNotesSlide();

        $presentation->save("note_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Aggiorna il testo delle note**

Modifica il testo di una diapositiva di note.

```php
function updateNoteText() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("Updated");

        $presentation->save("note_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```