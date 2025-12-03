---
title: Manage Presentation Notes in .NET
linktitle: Presentation Notes
type: docs
weight: 110
url: /net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Customize presentation notes with Aspose.Slides for .NET. Seamlessly work with PowerPoint and OpenDocument notes to boost your productivity."
---

Aspose.Slides supports removing notes slides from a presentation. In this topic, we will introduce this new feature of removing Notes also adding notes style slides from any presentation. Aspose.Slides for .NET provides the feature of removing notes of any slide as well as add style to existing notes. Developers can remove notes in the following ways:

- Remove Notes of a Specific Slide of a presentation.
- Remove Notes of All Slides of a Presentation.
## **Remove Notes from a Slide**
Notes of some specific slide could be removed as shown in the example below:

```c#
// Instantiate a Presentation object that represents a presentation file 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Removing notes of first slide
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Save presentation to disk
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Remove Notes from All Slides**
Notes of all the slides of a presentation could be removed as shown in the example below:

```c#
// Instantiate a Presentation object that represents a presentation file 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Removing notes of all slides
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Save presentation to disk
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Add a Notes Style**
NotesStyle property has been added to [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) interface and [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) class respectively. This property specifies the style of a notes text.  The implementation is demonstrated in the example below.

```c#
// Instantiate Presentation class that represents the presentation file
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Get MasterNotesSlide text style
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Set symbol bullet for the first level paragraphs
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Save the PPTX file to the Disk
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

Notes are accessed through the slide’s notes manager: the slide has a [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) and a [property](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/) that returns the notes object, or `null` if there are no notes.

**Are there differences in notes support across the PowerPoint versions the library works with?**

The library targets a broad range of Microsoft PowerPoint formats (97–newer) and ODP; notes are supported within these formats without depending on an installed copy of PowerPoint.
