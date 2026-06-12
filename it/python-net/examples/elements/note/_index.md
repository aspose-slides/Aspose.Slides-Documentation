---
title: Note
type: docs
weight: 240
url: /it/python-net/examples/elements/note/
keywords:
- note
- aggiungere diapositiva delle note
- accedere diapositiva delle note
- rimuovere diapositiva delle note
- aggiornare testo delle note
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Aggiungere, leggere, modificare ed esportare le note del relatore in Python con Aspose.Slides: formattare il testo, gestire le note per diapositiva e controllare la visibilità in PowerPoint e OpenDocument."
---
Mostra come aggiungere, leggere, rimuovere e aggiornare le diapositive delle note utilizzando **Aspose.Slides per Python tramite .NET**.

## **Aggiungere una diapositiva delle note**

Crea una diapositiva delle note e assegnale del testo.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedere a una diapositiva delle note**

Leggi il testo da una diapositiva delle note esistente.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Rimuovere una diapositiva delle note**

Rimuovi la diapositiva delle note associata a una diapositiva.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Rimuovi la diapositiva delle note.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiornare il testo delle note**

Modifica il testo di una diapositiva delle note.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Aggiorna il testo della nota.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```