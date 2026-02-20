---
title: Notiz
type: docs
weight: 240
url: /de/php-java/examples/elements/note/
keywords:
- Notiz
- Notizfolie hinzufügen
- Zugriff auf Notizfolie
- Notizfolie entfernen
- Notiztext aktualisieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Hinzufügen, Lesen, Bearbeiten und Exportieren von Sprecher-Notizen in PHP mit Aspose.Slides: Text formatieren, Notizen pro Folie verwalten und die Sichtbarkeit in PowerPoint und OpenDocument steuern."
---
Zeigt, wie man Notizfolien hinzufügt, liest, entfernt und aktualisiert, indem man **Aspose.Slides for PHP via Java** verwendet.

## **Notizfolie hinzufügen**

Erstellen Sie eine Notizfolie und weisen Sie ihr Text zu.

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

## **Auf eine Notizfolie zugreifen**

Lesen Sie den Text einer vorhandenen Notizfolie.

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

## **Notizfolie entfernen**

Entfernen Sie die Notizfolie, die einer Folie zugeordnet ist.

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

## **Notiztext aktualisieren**

Ändern Sie den Text einer Notizfolie.

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