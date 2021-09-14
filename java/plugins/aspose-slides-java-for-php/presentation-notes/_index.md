---
title: Presentation Notes
type: docs
weight: 110
url: /java/presentation-notes/
keywords: "PowerPoint speaker notes in Java"
description: "Presentation notes, speaker notes in Java"
---


{{% alert color="primary" %}} 

Aspose.Slides supports removing notes slides from a presentation. In this topic, we will introduce this new feature of removing Notes also adding notes style slides from any presentation. 

{{% /alert %}} 

Aspose.Slides for Java provides the feature of removing notes of any slide as well as add style to existing notes. Developers can remove notes in the following ways:

* Remove Notes of a Specific Slide of a presentation.
* Remove Notes of All Slides of a Presentation


## **Remove Notes from Slide**
Notes of some specific slide could be removed as shown in example below:

```php
// Instantiate a Presentation object that represents a presentation file
$pres = new Java("com.aspose.slides.Presentation", "presWithNotes.pptx");
try {
    // Removing notes of first slide
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();

    // Saving presentation to disk
    $pres->save("test.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Remove Notes from Presentation**
Notes of all the slides of a presentation could be removed as shown in example below:

```php
// Instantiate a Presentation object that represents a presentation file
$pres = new Java("com.aspose.slides.Presentation", "presWithNotes.pptx");
try {
    // Removing notes of all slides
    $mgr = null;
    for ($i = 0; $i < $pres->getSlides()->size(); $i++) {
        $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
        $mgr->removeNotesSlide();
    }
    
    // Saving presentation to disk
    $pres->save("test.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Add NotesStyle**
[getNotesStyle](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) method has been added to [IMasterNotesSlide](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide) interface and [MasterNotesSlide](https://apireference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide) class respectively. This property specifies the style of a notes text. The implementation is demonstrated in the example below.

```php
// Instantiate a Presentation object that represents a presentation file
$pres = new Java("com.aspose.slides.Presentation", "demo.pptx");
try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    
    if ($notesMaster != null)
    {
        // Get MasterNotesSlide text style
        $notesStyle = $notesMaster->getNotesStyle();
    
        //Set symbol bullet for the first level paragraphs
        $IparagraphFormat = $notesStyle->getLevel(0);
        $paragraphFormat->getBullet()->setType(Java("com.aspose.slides.BulletType")->Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```