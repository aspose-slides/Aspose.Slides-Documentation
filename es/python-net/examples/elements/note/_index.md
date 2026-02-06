---
title: Nota
type: docs
weight: 240
url: /es/python-net/examples/elements/note/
keywords:
- nota
- agregar diapositiva de notas
- acceder a diapositiva de notas
- eliminar diapositiva de notas
- actualizar texto de notas
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Agregar, leer, editar y exportar notas del orador en Python con Aspose.Slides: dar formato al texto, gestionar notas por diapositiva y controlar la visibilidad en PowerPoint y OpenDocument."
---
Muestra cómo agregar, leer, eliminar y actualizar diapositivas de notas usando **Aspose.Slides for Python via .NET**.

## **Agregar una diapositiva de notas**

Crea una diapositiva de notas y asigna texto a ella.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a una diapositiva de notas**

Lee el texto de una diapositiva de notas existente.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Eliminar una diapositiva de notas**

Elimina la diapositiva de notas asociada a una diapositiva.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Eliminar la diapositiva de notas.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Actualizar el texto de notas**

Cambia el texto de una diapositiva de notas.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Actualizar texto de la nota.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```