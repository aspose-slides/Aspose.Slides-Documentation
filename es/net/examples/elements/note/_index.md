---
title: Nota
type: docs
weight: 240
url: /es/net/examples/elements/note/
keywords:
- nota
- agregar diapositiva de notas
- acceder a la diapositiva de notas
- eliminar diapositiva de notas
- actualizar texto de notas
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con notas de diapositiva en Aspose.Slides for .NET: agregue, lea, edite y exporte notas del presentador en PPT, PPTX y ODP usando ejemplos claros en C#."
---
Este artículo muestra cómo agregar, leer, eliminar y actualizar diapositivas de notas usando **Aspose.Slides for .NET**.

## **Agregar una diapositiva de notas**

Crear una diapositiva de notas y asignarle texto.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Acceder a una diapositiva de notas**

Leer el texto de una diapositiva de notas existente.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Eliminar una diapositiva de notas**

Eliminar la diapositiva de notas asociada a una diapositiva.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Actualizar el texto de la diapositiva de notas**

Cambiar el texto de una diapositiva de notas.

```csharp
static void UpdateNoteText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```