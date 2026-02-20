---
title: Nota
type: docs
weight: 240
url: /es/php-java/examples/elements/note/
keywords:
- nota
- añadir diapositiva de notas
- acceder a diapositiva de notas
- eliminar diapositiva de notas
- actualizar texto de notas
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Añadir, leer, editar y exportar notas del presentador en PHP con Aspose.Slides: formatear texto, gestionar notas por diapositiva y controlar la visibilidad en PowerPoint y OpenDocument."
---
Muestra cómo añadir, leer, eliminar y actualizar diapositivas de notas usando **Aspose.Slides for PHP via Java**.

## **Añadir una diapositiva de notas**

Crea una diapositiva de notas y le asigna texto.

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

## **Acceder a una diapositiva de notas**

Lee el texto de una diapositiva de notas existente.

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

## **Eliminar una diapositiva de notas**

Elimina la diapositiva de notas asociada a una diapositiva.

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

## **Actualizar el texto de la diapositiva de notas**

Cambia el texto de una diapositiva de notas.

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