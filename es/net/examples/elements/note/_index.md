---
title: Nota
type: docs
weight: 240
url: /es/net/examples/elements/elements/note/
keywords:
- ejemplo de nota
- agregar diapositiva de notas
- acceder a diapositiva de notas
- eliminar diapositiva de notas
- actualizar texto de notas
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Agregar, leer, editar y exportar notas del orador en C# con Aspose.Slides: dar formato al texto, gestionar notas por diapositiva y controlar la visibilidad en PowerPoint y OpenDocument."
---

Muestra cómo agregar, leer, eliminar y actualizar diapositivas de notas usando **Aspose.Slides for .NET**.

## Add a Notes Slide

Crear una diapositiva de notas y asignarle texto.
```csharp
static void Add_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```


## Access a Notes Slide

Leer el texto de una diapositiva de notas existente.
```csharp
static void Access_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```


## Remove a Notes Slide

Eliminar la diapositiva de notas asociada a una diapositiva.
```csharp
static void Remove_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```


## Update Notes Text

Cambiar el texto de una diapositiva de notas.
```csharp
static void Update_Note_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```
