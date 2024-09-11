---
title: Remove Slide from Presentation
type: docs
weight: 30
url: /nodejs-java/remove-slide-from-presentation/
keywords: "Remove slide, Delete slide, PowerPoint, Presentation, Java, Aspose.Slides"
description: "Remove slide from PowerPoint by reference or index in Javascript"

---

If a slide (or its contents) becomes redundant, you can delete it. Aspose.Slides provides the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class that encapsulates [ISlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/islidecollection/), which is a repository for all slides in a presentation. Using pointers (reference or index) for a known [ISlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/islide/) object, you can specify the slide you want to remove.

## **Remove Slide by Reference**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
1. Get a reference of the slide you want to remove through its ID or Index.
1. Remove the referenced slide from the presentation.
1. Save the modified presentation. 

This Javascript code shows you how to remove a slide through its reference:

```javascript
    // Instantiate a Presentation object that represents a presentation file
    var pres = new  aspose.slides.Presentation("demo.pptx");
    try {
        // Accesses a slide through its index in the slides collection
        var slide = pres.getSlides().get_Item(0);
        // Removes a slide through its reference
        pres.getSlides().remove(slide);
        // Saves the modified presentation
        pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        pres.dispose();
    }
```


## **Remove Slide by Index**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
1. Remove the slide from the presentation through its index position.
1. Save the modified presentation. 

This Javascript code shows you how to remove a slide through its index:

```javascript
    // Instantiates a Presentation object that represents a presentation file
    var pres = new  aspose.slides.Presentation("demo.pptx");
    try {
        // Removes a slide through its slide index
        pres.getSlides().removeAt(0);
        // Saves the modified presentation
        pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        pres.dispose();
    }
```

## **Remove Unused Layout Slide**

Aspose.Slides provides the [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) method (from the [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) class) to allow you to delete unwanted and unused layout slides. This Javascript code shows you how to remove a layout slide from a PowerPoint presentation:

```javascript
    var pres = new  aspose.slides.Presentation("pres.pptx");
    try {
        aspose.slides.Compress.removeUnusedLayoutSlides(pres);
        pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Remove Unused Master Slide**

Aspose.Slides provides the [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) method (from the [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) class) to allow you to delete unwanted and unused master slides. This Javascript code shows you how to remove a master slide from a PowerPoint presentation:

```javascript
    var pres = new  aspose.slides.Presentation("pres.pptx");
    try {
        aspose.slides.Compress.removeUnusedMasterSlides(pres);
        pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

