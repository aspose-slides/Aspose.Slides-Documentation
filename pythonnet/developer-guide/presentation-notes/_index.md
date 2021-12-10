---
title: Presentation Notes
type: docs
weight: 110
url: /pythonnet/presentation-notes/
keywords: "Notes, PowerPoint notes, add notes, remove notes, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add and remove notes in PowerPoint presentations in Python"
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
NotesStyle property has been added to [IMasterNotesSlide](https://apireference.aspose.com/slides/pythonnet/aspose.slides/imasternotesslide) interface and [MasterNotesSlide](https://apireference.aspose.com/slides/pythonnet/aspose.slides/masternotesslide) class respectively. This property specifies the style of a notes text.  The implementation is demonstrated in the example below.

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

