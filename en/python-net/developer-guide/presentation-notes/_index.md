---
title: Manage Presentation Notes in Python
linktitle: Presentation Notes
type: docs
weight: 110
url: /python-net/presentation-notes/
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
- Aspose.Slides
description: "Customize presentation notes with Aspose.Slides for Python via .NET. Seamlessly work with PowerPoint and OpenDocument notes to boost your productivity."
---

Aspose.Slides supports removing notes slides from a presentation. In this topic, we will introduce this new feature of removing Notes also adding notes style slides from any presentation. Aspose.Slides for Python via .NET provides the feature of removing notes of any slide as well as add style to existing notes. Developers can remove notes in the following ways:

- Remove Notes of a Specific Slide of a presentation.
- Remove Notes of All Slides of a Presentation.
## **Remove Notes from Slide**
Notes of some specific slide could be removed as shown in the example below:

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of first slide
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # save presentation to disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Remove Notes from All Slides**
Notes of all the slides of a presentation could be removed as shown in the example below:

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of all slides
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # save presentation to disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Add NotesStyle**
The [notes_style](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/notes_style/) property has been added to the [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) class. This property specifies the style of a notes text.  The implementation is demonstrated in the example below.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Get MasterNotesSlide text style
        notesStyle = notesMaster.notes_style

        #Set symbol bullet for the first level paragraphs
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # save the PPTX file to the Disk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

Notes are accessed through the slide’s notes manager: the slide has a [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) and a [property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) that returns the notes object, or `None` if there are no notes.

**Are there differences in notes support across the PowerPoint versions the library works with?**

The library targets a broad range of Microsoft PowerPoint formats (97–newer) and ODP; notes are supported within these formats without depending on an installed copy of PowerPoint.
