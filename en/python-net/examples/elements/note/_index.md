---
title: Note
type: docs
weight: 240
url: /python-net/examples/elements/note/
keywords:
- note
- add notes slide
- access notes slide
- remove notes slide
- update notes text
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Add, read, edit, and export speaker notes in Python with Aspose.Slides: format text, manage notes per slide, and control visibility in PowerPoint and OpenDocument."
---

Shows how to add, read, remove, and update notes slides using **Aspose.Slides for Python via .NET**.

## **Add a Notes Slide**

Create a notes slide and assign text to it.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Notes Slide**

Read text from an existing notes slide.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Remove a Notes Slide**

Remove the notes slide associated with a slide.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Remove the notes slide.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Update Notes Text**

Change the text of a notes slide.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Update note text.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```
