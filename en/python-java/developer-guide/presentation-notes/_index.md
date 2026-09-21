---
title: Manage Presentation Notes in Python via Java
linktitle: Presentation Notes
type: docs
weight: 110
url: /python-java/presentation-notes/
keywords:
- notes
- notes slide
- add notes
- remove notes
- notes style
- master notes
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Customize presentation notes with Aspose.Slides for Python via Java. Seamlessly work with PowerPoint and OpenDocument notes to boost your productivity."
---

## **Overview**

Aspose.Slides supports removing notes slides from a presentation. This topic introduces this feature, including how to remove notes and how to apply a style to notes slides in a presentation. Aspose.Slides allows you to remove notes from any slide and apply styling to existing notes. Developers can remove notes in the following ways:

- Remove notes from a specific slide in a presentation.
- Remove notes from all slides in a presentation.

To read or change notes page dimensions, switch orientation, and check export behavior, see [Notes Page Size](/slides/python-java/notes-size/).

## **Remove Notes from a Slide**

Notes from a specific slide can be removed as shown in the example below:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantiate a Presentation object that represents a presentation file.
presentation = Presentation("presWithNotes.pptx")
try:
    # Remove notes from the first slide.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Save the presentation to disk.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remove Notes from a Presentation**

Notes from all slides in a presentation can be removed as shown in the example below:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantiate a Presentation object that represents a presentation file.
presentation = Presentation("presWithNotes.pptx")
try:
    # Remove notes from all slides.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Save the presentation to disk.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Add a Notes Style**

The [getNotesStyle](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslide/#getNotesStyle) method of the [MasterNotesSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslide/) class provides access to the style of notes text. The implementation is demonstrated in the example below.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Instantiate a Presentation object that represents a presentation file.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Get the master notes slide text style.
        notes_style = notes_master.getNotesStyle()

        # Set symbol bullets for first-level paragraphs.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

Notes are accessed through the slide’s notes manager: the slide has a [NotesSlideManager](https://reference.aspose.com/slides/python-java/aspose.slides/notesslidemanager/) and a [getNotesSlide](https://reference.aspose.com/slides/python-java/aspose.slides/notesslidemanager/#getNotesSlide) method that returns the notes object, or `None` if there are no notes.

**Are there differences in notes support across the PowerPoint versions the library works with?**

The library targets a broad range of Microsoft PowerPoint formats (97 and later) and ODP; notes are supported within these formats without depending on an installed copy of PowerPoint.
