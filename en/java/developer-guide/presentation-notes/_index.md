---
title: Manage Presentation Notes in Java
linktitle: Presentation Notes
type: docs
weight: 110
url: /java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Customize presentation notes with Aspose.Slides for Java. Seamlessly work with PowerPoint and OpenDocument notes to boost your productivity."
---


{{% alert color="primary" %}} 

Aspose.Slides supports removing notes slides from a presentation. In this topic, we will introduce this new feature of removing Notes also adding notes style slides from any presentation. 

{{% /alert %}} 

Aspose.Slides for Java provides the feature of removing notes of any slide as well as add style to existing notes. Developers can remove notes in the following ways:

* Remove Notes of a Specific Slide of a presentation.
* Remove Notes of All Slides of a Presentation


## **Remove Notes from a Slide**
Notes of some specific slide could be removed as shown in example below:

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Removing notes of first slide
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Saving presentation to disk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remove Notes from a Presentation**
Notes of all the slides of a presentation could be removed as shown in example below:

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Removing notes of all slides
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Saving presentation to disk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add a Notes Style**
[getNotesStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) method has been added to [IMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide) interface and [MasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide) class respectively. This property specifies the style of a notes text. The implementation is demonstrated in the example below.

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Get MasterNotesSlide text style
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Set symbol bullet for the first level paragraphs
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

Notes are accessed through the slide’s notes manager: the slide has a [NotesSlideManager](https://reference.aspose.com/slides/java/com.aspose.slides/notesslidemanager/) and a [method](https://reference.aspose.com/slides/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) that returns the notes object, or `null` if there are no notes.

**Are there differences in notes support across the PowerPoint versions the library works with?**

The library targets a broad range of Microsoft PowerPoint formats (97–newer) and ODP; notes are supported within these formats without depending on an installed copy of PowerPoint.
