---
title: Note
type: docs
weight: 240
url: /python-java/examples/elements/note/
keywords:
- code example
- note
- speaker note
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Work with slide notes in Aspose.Slides for Python via Java: add, read, remove, and update speaker notes in PowerPoint and OpenDocument presentations."
---

This article demonstrates how to add, read, remove, and update notes slides using **Aspose.Slides for Python via Java**.

Install the package as described in [Installation](/slides/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running.

## **Add a Notes Slide**

Create a notes slide and assign text to it.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **Access a Notes Slide**

Read text from an existing notes slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **Remove a Notes Slide**

Remove the notes slide associated with a slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **Update Notes Text**

Change the text of a notes slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```
