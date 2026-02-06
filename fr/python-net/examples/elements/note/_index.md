---
title: Note
type: docs
weight: 240
url: /fr/python-net/examples/elements/note/
keywords:
- note
- ajouter diapositive de notes
- accéder diapositive de notes
- supprimer diapositive de notes
- mettre à jour texte des notes
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajouter, lire, modifier et exporter les notes du présentateur en Python avec Aspose.Slides : formater le texte, gérer les notes par diapositive et contrôler la visibilité dans PowerPoint et OpenDocument."
---
Montre comment ajouter, lire, supprimer et mettre à jour des diapositives de notes en utilisant **Aspose.Slides for Python via .NET**.

## **Ajouter une diapositive de notes**

Créer une diapositive de notes et lui attribuer du texte.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à une diapositive de notes**

Lire le texte d'une diapositive de notes existante.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Supprimer une diapositive de notes**

Supprimer la diapositive de notes associée à une diapositive.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Supprimer la diapositive de notes.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Mettre à jour le texte des notes**

Modifier le texte d'une diapositive de notes.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Mettre à jour le texte de la note.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```