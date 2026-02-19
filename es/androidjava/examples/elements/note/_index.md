---
title: Nota
type: docs
weight: 240
url: /es/androidjava/examples/elements/note/
keywords:
- ejemplo de código
- nota
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Trabaje con notas de diapositivas en Aspose.Slides para Android: añada, lea, edite y exporte notas del ponente en PPT, PPTX y ODP usando ejemplos claros en Java."
---
Este artículo muestra cómo añadir, leer, eliminar y actualizar diapositivas de notas usando **Aspose.Slides for Android vía Java**.

## **Añadir una diapositiva de notas**

Crea una diapositiva de notas y asigna texto a ella.

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

Lee el texto de una diapositiva de notas existente.

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

Elimina la diapositiva de notas asociada a una diapositiva.

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

Modifica el texto de una diapositiva de notas.

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