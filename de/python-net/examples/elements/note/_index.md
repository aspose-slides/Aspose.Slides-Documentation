---
title: Notiz
type: docs
weight: 240
url: /de/python-net/examples/elements/note/
keywords:
- Notiz
- Notizfolie hinzufügen
- Notizfolie abrufen
- Notizfolie entfernen
- Notiztext aktualisieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie Sprechernotizen in Python mit Aspose.Slides hinzu, lesen, bearbeiten und exportieren Sie sie: Text formatieren, Notizen pro Folie verwalten und die Sichtbarkeit in PowerPoint und OpenDocument steuern."
---
Zeigt, wie man Notizfolien hinzufügt, liest, entfernt und aktualisiert, indem man **Aspose.Slides for Python via .NET** verwendet.

## **Eine Notizfolie hinzufügen**

Erstelle eine Notizfolie und weise ihr Text zu.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Auf eine Notizfolie zugreifen**

Lese den Text einer vorhandenen Notizfolie.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Eine Notizfolie entfernen**

Entferne die mit einer Folie verbundene Notizfolie.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Entferne die Notizfolie.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Notiztext aktualisieren**

Ändere den Text einer Notizfolie.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Notiztext aktualisieren.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```