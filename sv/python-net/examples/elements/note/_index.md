---
title: Anteckning
type: docs
weight: 240
url: /sv/python-net/examples/elements/note/
keywords:
- anteckning
- lägg till anteckningsbild
- komma åt anteckningsbild
- ta bort anteckningsbild
- uppdatera anteckningstext
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lägg till, läs, redigera och exportera talaranteckningar i Python med Aspose.Slides: formatera text, hantera anteckningar per bild och kontrollera synlighet i PowerPoint och OpenDocument."
---
Visar hur man lägger till, läser, tar bort och uppdaterar anteckningsbilder med **Aspose.Slides for Python via .NET**.

## **Lägg till en anteckningsbild**

Skapa en anteckningsbild och tilldela text till den.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Kom åt en anteckningsbild**

Läs text från en befintlig anteckningsbild.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Ta bort en anteckningsbild**

Ta bort anteckningsbilden som är kopplad till en bild.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Ta bort anteckningsbilden.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Uppdatera anteckningstext**

Ändra texten i en anteckningsbild.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Uppdatera anteckningstext.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```