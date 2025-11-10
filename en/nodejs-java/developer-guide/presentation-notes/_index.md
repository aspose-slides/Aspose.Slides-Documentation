---
title: Presentation Notes
type: docs
weight: 110
url: /nodejs-java/presentation-notes/
keywords: "PowerPoint speaker notes in JavaScript"
description: "Presentation notes, speaker notes in JavaScript"
---


{{% alert color="primary" %}} 

Aspose.Slides supports removing notes slides from a presentation. In this topic, we will introduce this new feature of removing Notes also adding notes style slides from any presentation. 

{{% /alert %}} 

Aspose.Slides for Node.js via Java provides the feature of removing notes of any slide as well as add style to existing notes. Developers can remove notes in the following ways:

* Remove Notes of a Specific Slide of a presentation.
* Remove Notes of All Slides of a Presentation


## **Remove Notes from Slide**
Notes of some specific slide could be removed as shown in example below:

```javascript
// Instantiate a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Removing notes of first slide
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Saving presentation to disk
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Remove Notes from Presentation**
Notes of all the slides of a presentation could be removed as shown in example below:

```javascript
// Instantiate a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Removing notes of all slides
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Saving presentation to disk
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Add NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) method has been added to [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) class and [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) class respectively. This property specifies the style of a notes text. The implementation is demonstrated in the example below.

```javascript
// Instantiate a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Get MasterNotesSlide text style
        var notesStyle = notesMaster.getNotesStyle();
        // Set symbol bullet for the first level paragraphs
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

Notes are accessed through the slide’s notes manager: the slide has a [NotesSlideManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/) and a [method](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) that returns the notes object, or `null` if there are no notes.

**Are there differences in notes support across the PowerPoint versions the library works with?**

The library targets a broad range of Microsoft PowerPoint formats (97–newer) and ODP; notes are supported within these formats without depending on an installed copy of PowerPoint.
