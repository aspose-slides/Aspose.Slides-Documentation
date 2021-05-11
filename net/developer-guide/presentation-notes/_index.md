---
title: Presentation Notes
type: docs
weight: 110
url: /net/presentation-notes/
keywords: "PowerPoint presentation speaker notes"
description: "PowerPoint presentation notes, speaker notes with Aspose.Slides"
---



Aspose.Slides supports removing notes slides from a presentation. In this topic, we will introduce this new feature of removing Notes also adding notes style slides from any presentation. Aspose.Slides for .NET provides the feature of removing notes of any slide as well as add style to existing notes. Developers can remove notes in the following ways:

- Remove Notes of a Specific Slide of a presentation.
- Remove Notes of All Slides of a Presentation.
## **Remove Notes from Slide**
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
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Slides_Presentations_Notes();

// Instantiate a Presentation object that represents a presentation file 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Removing notes of all slides
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Save presentation to disk
presentation.Save(dataDir + "RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Add NotesStyle**
NotesStyle property has been added to [IMasterNotesSlide](https://apireference.aspose.com/net/slides/aspose.slides/imasternotesslide) interface and [MasterNotesSlide](https://apireference.aspose.com/net/slides/aspose.slides/masternotesslide) class respectively. This property specifies the style of a notes text.  The implementation is demonstrated in the example below.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Slides_Presentations_CRUD();

// Create directory if it is not already present.
bool IsExists = System.IO.Directory.Exists(dataDir);
if (!IsExists)
    System.IO.Directory.CreateDirectory(dataDir);

// Instantiate Presentation class that represents the presentation file
using (Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx"))
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
    presentation.Save(dataDir + "AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

