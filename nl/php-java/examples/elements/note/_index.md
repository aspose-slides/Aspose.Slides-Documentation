---
title: Notitie
type: docs
weight: 240
url: /nl/php-java/examples/elements/note/
keywords:
- notitie
- notitiedia toevoegen
- toegang tot notitiedia
- notitiedia verwijderen
- notitietekst bijwerken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Voeg notities toe, lees, bewerk en exporteer sprekernotities in PHP met Aspose.Slides: formatteer tekst, beheer notities per dia en beheer de zichtbaarheid in PowerPoint en OpenDocument."
---
Toont hoe u notitiedia’s kunt toevoegen, lezen, verwijderen en bijwerken met **Aspose.Slides for PHP via Java**.

## **Notitiedia toevoegen**

Maak een notitiedia aan en wijs er tekst aan toe.

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

## **Toegang tot een notitiedia**

Lees de tekst van een bestaande notitiedia.

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

## **Notitiedia verwijderen**

Verwijder de notitiedia die bij een dia hoort.

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

## **Notitietekst bijwerken**

Wijzig de tekst van een notitiedia.

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