---
title: Nota
type: docs
weight: 240
url: /es/java/examples/elements/note/
keywords:
- ejemplo de código
- nota
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Trabaje con notas de diapositivas en Aspose.Slides for Java: añada, lea, edite y exporte notas del presentador en PPT, PPTX y ODP utilizando ejemplos claros de Java."
---
Este artículo muestra cómo añadir, leer, eliminar y actualizar diapositivas de notas usando **Aspose.Slides for Java**.

## **Agregar una diapositiva de notas**

Cree una diapositiva de notas y asigne texto a ella.

```java
static void addNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("My note");
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a una diapositiva de notas**

Lea el texto de una diapositiva de notas existente.

```java
static void accessNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        String notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una diapositiva de notas**

Elimine la diapositiva de notas asociada a una diapositiva.

```java
static void removeNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().removeNotesSlide();
    } finally {
        presentation.dispose();
    }
}
```

## **Actualizar texto de notas**

Cambie el texto de una diapositiva de notas.

```java
static void updateNoteText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Old");
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Updated");
    } finally {
        presentation.dispose();
    }
}
```