---
title: Nota
type: docs
weight: 240
url: /es/nodejs-java/examples/elements/note/
keywords:
- ejemplo de código
- nota
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Trabaje con notas de diapositivas en Aspose.Slides para Node.js: añada, lea, edite y exporte notas del orador en PPT, PPTX y ODP mediante ejemplos claros en JavaScript."
---
Este artículo muestra cómo añadir, leer, eliminar y actualizar diapositivas de notas utilizando **Aspose.Slides for Node.js via Java**.

## **Agregar una diapositiva de notas**

Crear una diapositiva de notas y asignarle texto.

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

## **Acceder a una diapositiva de notas**

Leer el texto de una diapositiva de notas existente.

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

## **Eliminar una diapositiva de notas**

Eliminar la diapositiva de notas asociada a una diapositiva.

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

## **Actualizar el texto de notas**

Cambiar el texto de una diapositiva de notas.

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