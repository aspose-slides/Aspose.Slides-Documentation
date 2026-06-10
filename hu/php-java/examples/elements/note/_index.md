---
title: Jegyzet
type: docs
weight: 240
url: /hu/php-java/examples/elements/note/
keywords:
- jegyzet
- jegyzetdia hozzáadása
- jegyzetdia elérése
- jegyzetdia eltávolítása
- jegyzet szövegének frissítése
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Jegyzetek hozzáadása, olvasása, szerkesztése és exportálása PHP-ben az Aspose.Slides segítségével: szöveg formázása, jegyzetek kezelése diánként, és a láthatóság vezérlése PowerPoint-ban és OpenDocument-ban."
---
Bemutatja, hogyan lehet hozzáadni, olvasni, eltávolítani és frissíteni a jegyzetdiákot a **Aspose.Slides for PHP via Java** használatával.

## **Jegyzetdia hozzáadása**

Hozzon létre egy jegyzetdiát, és rendelje hozzá a szöveget.

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

## **Jegyzetdia elérése**

Olvassa el a szöveget egy meglévő jegyzetdiából.

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

## **Jegyzetdia eltávolítása**

Távolítsa el a diához kapcsolódó jegyzetdiát.

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

## **Jegyzet szövegének frissítése**

Módosítsa egy jegyzetdia szövegét.

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