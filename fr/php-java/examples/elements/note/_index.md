---
title: Note
type: docs
weight: 240
url: /fr/php-java/examples/elements/note/
keywords:
- note
- ajouter une diapositive de notes
- accéder à une diapositive de notes
- supprimer une diapositive de notes
- mettre à jour le texte des notes
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Ajoutez, lisez, modifiez et exportez les notes du présentateur en PHP avec Aspose.Slides : formatez le texte, gérez les notes par diapositive et contrôlez la visibilité dans PowerPoint et OpenDocument."
---
Montre comment ajouter, lire, supprimer et mettre à jour des diapositives de notes en utilisant **Aspose.Slides for PHP via Java**.

## **Ajouter une diapositive de notes**

Créez une diapositive de notes et attribuez du texte.

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

## **Accéder à une diapositive de notes**

Lisez le texte d'une diapositive de notes existante.

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

## **Supprimer une diapositive de notes**

Supprimez la diapositive de notes associée à une diapositive.

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

## **Mettre à jour le texte d'une diapositive de notes**

Modifiez le texte d'une diapositive de notes.

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