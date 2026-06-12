---
title: Notitie
type: docs
weight: 240
url: /nl/python-net/examples/elements/note/
keywords:
- notitie
- notitieslide toevoegen
- toegang tot notitieslide
- notitieslide verwijderen
- notitiestekst bijwerken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Voeg sprekernotities toe, lees ze, bewerk ze en exporteer ze in Python met Aspose.Slides: formatteer tekst, beheer notities per slide en beheer de zichtbaarheid in PowerPoint en OpenDocument."
---
Toont hoe je notitieslides kunt toevoegen, lezen, verwijderen en bijwerken met **Aspose.Slides for Python via .NET**.

## **Notitieslide toevoegen**

Maak een notitieslide en ken er tekst aan toe.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot een notitieslide**

Lees de tekst van een bestaande notitieslide.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Notitieslide verwijderen**

Verwijder de notitieslide die bij een slide hoort.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Verwijder de notitieslide.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Notitiestekst bijwerken**

Wijzig de tekst van een notitieslide.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Werk notitietekst bij.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```