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
description: "Agregar, leer, editar y exportar notas del orador en C# con Aspose.Slides: formatear texto, administrar notas por diapositiva y controlar la visibilidad en PowerPoint y OpenDocument."
---

Muestra cómo agregar, leer, eliminar y actualizar diapositivas de notas usando **Aspose.Slides for .NET**.

## **Agregar una diapositiva de notas**
Crea una diapositiva de notas y asígnale texto.
```csharp
static void Add_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```


## **Acceder a una diapositiva de notas**
Lee el texto de una diapositiva de notas existente.
```csharp
static void Access_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```


## **Eliminar una diapositiva de notas**
Elimina la diapositiva de notas asociada a una diapositiva.
```csharp
static void Remove_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```


## **Actualizar el texto de notas**
Cambia el texto de una diapositiva de notas.
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
