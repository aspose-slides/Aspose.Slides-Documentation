---
title: Notatka
type: docs
weight: 240
url: /pl/php-java/examples/elements/note/
keywords:
- notatka
- dodaj slajd z notatkami
- dostęp do slajdu z notatkami
- usuń slajd z notatkami
- zaktualizuj tekst notatek
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dodaj, odczytaj, edytuj i eksportuj notatki prelegenta w PHP przy użyciu Aspose.Slides: formatuj tekst, zarządzaj notatkami na slajdzie i kontroluj ich widoczność w PowerPoint i OpenDocument."
---
Pokazuje, jak dodać, odczytać, usunąć i zaktualizować slajdy z notatkami przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj slajd z notatkami**

Utwórz slajd z notatkami i przypisz do niego tekst.

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

## **Uzyskaj dostęp do slajdu z notatkami**

Odczytaj tekst z istniejącego slajdu z notatkami.

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

## **Usuń slajd z notatkami**

Usuń slajd z notatkami powiązany ze slajdem.

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

## **Zaktualizuj tekst notatek**

Zmień tekst slajdu z notatkami.

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