---
title: Clone Slides
type: docs
weight: 35
url: /nodejs-java/clone-slides/
---


## **Clone Slides in Presentation**
Cloning is the process of making an exact copy or replica of something. Aspose.Slides for Node.js via Java also makes it possible to make a copy or clone of any slide and then insert that cloned slide to the current or any other opened presentation. The process of slide cloning creates a new slide that can be modified by developers without changing the original slide. There are several possible ways to clone a slide:

- Clone at End within a Presentation.
- Clone at Another Position within Presentation.
- Clone at End in another Presentation.
- Clone at Another Position in another Presentation.
- Clone at a specific position in another Presentation.

In Aspose.Slides for Node.js via Java, (a collection of [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) objects) exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) object provides the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) and [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methods to perform the above types of slide cloning

## **Clone at End within a Presentation**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method according to the steps listed below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Instantiate the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) class by referencing the Slides collection exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) object.
1. Call the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method exposed by the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) object and pass the slide to be cloned as a parameter to the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method.
1. Write the modified presentation file.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

```javascript
// Instantiate Presentation class that represents a presentation file
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clone the desired slide to the end of the collection of slides in the same presentation
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Write the modified presentation to disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clone at Another Position with in Presentation**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) method:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Instantiate the class by referencing the [**Slides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) collection exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) object.
1. Call the [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) method exposed by the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) object and pass the slide to be cloned along with the index for the new position as a parameter to the [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) method.
1. Write the modified presentation as a PPTX file.

In the example given below, we have cloned a slide (lying at the zero index – position 1 – of the presentation) to index 1 – Position 2 – of the presentation.

```javascript
// Instantiate Presentation class that represents a presentation file
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clone the desired slide to the end of the collection of slides in the same presentation
    var slds = pres.getSlides();
    // Clone the desired slide to the specified index in the same presentation
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Write the modified presentation to disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clone at End in another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the destination presentation that the slide will be added to.
1. Instantiate the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) class by referencing the [**Slides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) collection exposed by the Presentation object of the destination presentation.
1. Call the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method exposed by the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) object and pass the slide from the source presentation as a parameter to the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the first index of the source presentation) to the end of the destination presentation.

```javascript
// Instantiate Presentation class to load the source presentation file
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantiate Presentation class for destination PPTX (where slide is to be cloned)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clone the desired slide from the source presentation to the end of the collection of slides in destination presentation
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Write the destination presentation to disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clone at Another Position in another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the presentation the slide will be added to.
1. Instantiate the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) class by referencing the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) method exposed by the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) object and pass the slide from the source presentation along with the desired position as a parameter to the [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

```javascript
// Instantiate Presentation class to load the source presentation file
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantiate Presentation class for destination PPTX (where slide is to be cloned)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clone the desired slide from the source presentation to the end of the collection of slides in destination presentation
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Write the destination presentation to disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clone at specific position in another Presentation**
If you need to clone a slide with a master slide from one presentation from and use it in another presentation, you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) expects a master slide from destination presentation rather than from source presentation. In order to clone the slide with a master, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the destination presentation the slide will be cloned to.
1. Access the slide to be cloned along with the master slide.
1. Instantiate the [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) class by referencing the Masters collection exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) object of the destination presentation.
1. Call the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method exposed by the [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) object and pass the master from the source PPTX to be cloned as a parameter to the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method.
1. Instantiate the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) class by setting the reference to the Slides collection exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) object of the destination presentation.
1. Call the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method exposed by the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) object and pass the slide from the source presentation to be cloned and master slide as a parameter to the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide with a master (lying at the zero index of the source presentation) to the end of the destination presentation using a master from source slide.

```javascript
// Instantiate Presentation class to load the source presentation file
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instantiate Presentation class for destination presentation (where slide is to be cloned)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instantiate ISlide from the collection of slides in source presentation along with
        // Master slide
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clone the desired master slide from the source presentation to the collection of masters in the
        // Destination presentation
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clone the desired master slide from the source presentation to the collection of masters in the
        // Destination presentation
        var iSlide = masters.addClone(SourceMaster);
        // Clone the desired slide from the source presentation with the desired master to the end of the
        // Collection of slides in the destination presentation
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Save the destination presentation to disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clone at End in Specified Section**
If you want to clone a slide and then use it within the same presentation file but at a different section, then use the [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) method exposed by the [**SlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) class. Aspose.Slides for Node.js via Java makes it possible to clone a slide from the first section and then insert that cloned slide to the second section of the same presentation.

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Save the destination presentation to disk
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```
