---
title: Anteckning
type: docs
weight: 240
url: /sv/php-java/examples/elements/note/
keywords:
- anteckning
- lägg till anteckningsbild
- åtkomst till anteckningsbild
- ta bort anteckningsbild
- uppdatera anteckningstext
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lägg till, läs, redigera och exportera talarnoter i PHP med Aspose.Slides: formatera text, hantera noteringar per bild och styra synlighet i PowerPoint och OpenDocument."
---
Visar hur du lägger till, läser, tar bort och uppdaterar anteckningsbilder med **Aspose.Slides for PHP via Java**.

## **Lägg till en anteckningsbild**

Skapa en anteckningsbild och tilldela text till den.

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

## **Åtkomst till en anteckningsbild**

Läs text från en befintlig anteckningsbild.

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

## **Ta bort en anteckningsbild**

Ta bort anteckningsbilden som är associerad med en bild.

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

## **Uppdatera anteckningstext**

Ändra texten i en anteckningsbild.

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