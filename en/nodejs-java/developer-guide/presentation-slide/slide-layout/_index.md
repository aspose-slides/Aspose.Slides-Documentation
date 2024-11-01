---
title: Slide Layout
type: docs
weight: 60
url: /nodejs-java/slide-layout/
keyword: "Set slide size, set slide options, specify slide size, Footer visibility, Child footer, Content scaling, page size, Java, Aspose.Slides"
description: "Set PowerPoint slide size and options in JavaScript"
---

A slide layout contains the placeholder boxes and formatting information for all the content that appears on a slide. The layout determines the available content placeholders and where they are placed. 

Slide layouts allow you to create and design presentations quickly (whether simple or complex). These are some of the most popular slide layouts used in PowerPoint presentations: 

* **Title Slide layout**. This layout consists of two text placeholders. One placeholder is for the title and the other is for the subtitle. 
* **Title and Content layout**. This layout contains a relatively small placeholder at the top for the title and a bigger placeholder for the core content (chart, paragraphs, bullet list, numbered list, images, etc).
* **Blank layout**. This layout lacks placeholders, so it allows you to create elements from scratch. 

Since a slide master is the top hierarchical slide that stores information about slide layouts, you can use the master slide to access slide layouts and make changes to them. A layout slide can be accessed by type or name. Similarly, every slide has a unique id, which can be used to access it. 

Alternatively, you can make changes directly to a specific slide layout in a presentation. 

* To allow you to work with slide layouts (including those in master slides), Aspose.Slides provides properties like [getLayoutSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides--) and [getMasters()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) under the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
* To perform related tasks, Aspose.Slides provides [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslideheaderfootermanager/), and many other types.

{{% alert title="Info" color="info" %}}

For more information on working with Master Slides in particular, see the [Slide Master](https://docs.aspose.com/slides/nodejs-java/slide-master/) article.

{{% /alert %}}

## **Add Slide Layout to Presentation**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
1. Access the [MasterSlide collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/).
1. Go through the existing layout slides to confirm that the required layout slide already exists in the Layout Slide collection. Otherwise, add the Layout slide you want. 
1. Add an empty slide based on the new layout slide.
1. Save the presentation. 

This JavaScript code shows you how to add a slide layout to a PowerPoint presentation:

```javascript
// Instantiates a Presentation class that represents the presentation file
var pres = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Goes through layout slide types
    var layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    var layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }
    if (layoutSlide == null) {
        // The situation where a presentation doesn't contain some layout types.
        // presentation File only contains Blank and Custom layout types.
        // But layout slides with Custom types have different slide names,
        // like "Title", "Title and Content", etc. And it is possible to use these
        // names for layout slide selection.
        // You can also use a set of placeholder shape types. For example,
        // Title slide should have only Title placeholder type, etc.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }
        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }
            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }
    // Adds empty slide with added layout slide
    pres.getSlides().insertEmptySlide(0, layoutSlide);
    // Saves the presentation to disk
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Remove Unused Layout Slide**

Aspose.Slides provides the [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) method from the [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) class to allow you to delete unwanted and unused layout slides. This JavaScript code shows you how to remove a layout slide from a PowerPoint presentation:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Set Size and Type for Slide Layout**

To allow you to set the size and type for a specific layout slide, Aspose.Slides provides the [getType()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#getType--) and [getSize()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#getSize--) properties (from the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class). This JavaScript demonstrates the operation:

```javascript
// Instantiates a Presentation object that represents presentation file
var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var auxPresentation = new aspose.slides.Presentation();
    try {
        // Sets the slide size for the generated presentation to that of the source
        auxPresentation.getSlideSize().setSize(540, 720, aspose.slides.SlideSizeScaleType.EnsureFit);
        // getType());
        auxPresentation.getSlideSize().setSize(aspose.slides.SlideSizeType.A4Paper, aspose.slides.SlideSizeScaleType.Maximize);
        // Clones the required slide
        auxPresentation.getSlides().addClone(presentation.getSlides().get_Item(0));
        auxPresentation.getSlides().removeAt(0);
        // Saves the presentation to disk
        auxPresentation.save("size.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        auxPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **Set Footer Visibility Inside Slide**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
1. Get a slide's reference through its index.
1. Set the slide footer placeholder to visible. 
1. Set the date-time placeholder to visible. 
1. Save the presentation. 

This JavaScript code shows you how to set the visibility for a slide footer (and perform related tasks):

```javascript
var presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    var headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    // Method isFooterVisible is used to specify that a slide footer placeholder is missing
    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);// Method setFooterVisibility is used to set a slide footer placeholder to visible
    }
    // Method isSlideNumberVisible is used to specify that a slide page number placeholder is missing
    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);// Method setSlideNumberVisibility is used to set a slide page number placeholder to visible
    }
    // Method isDateTimeVisible is used to specify that a slide date-time placeholder is missing
    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);// Method SetFooterVisibility is used to set a slide date-time placeholder to visible
    }
    headerFooterManager.setFooterText("Footer text");// Method SetFooterText is used to set a text for a slide footer placeholder.
    headerFooterManager.setDateTimeText("Date and time text");// Method SetDateTimeText is used to set a text for a slide date-time placeholder.
} finally {
    presentation.dispose();
}
```

## **Set Child Footer Visibility Inside Slide**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
1. Get a reference for the master slide through its index. 
1. Set the master slide and all child footer placeholders to visible.
1. Set a text for the master slide and all child footer placeholders. 
1. Set a text for the master slide and all child date-time placeholders. 
1. Save the presentation. 

This JavaScript code demonstrates the operation:

```javascript
var presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    var headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);// Method setFooterAndChildFootersVisibility is used to set the master slide and all child footer placeholders to visible
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// Method setSlideNumberAndChildSlideNumbersVisibility is used to set the master slide and all child page number placeholders to visible
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// Method setDateTimeAndChildDateTimesVisibility is used to set a master slide and all child date-time placeholders to visible
    headerFooterManager.setFooterAndChildFootersText("Footer text");// Method setFooterAndChildFootersText is used to set texts for the master slide and all child footer placeholders
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// Method setDateTimeAndChildDateTimesText is used for set text for the master slide and all child date-time placeholders
} finally {
    presentation.dispose();
}
```

## **Set Slide Size with Respect to Content Scaling**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class and load the presentation containing the slide whose size you want to set.
1. Create another instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class to generate a new presentation.
1. Get the slide's reference (from the first presentation) through its index.
1. Set the slide footer placeholder to visible. 
1. Set the date-time placeholder to visible. 
1. Save the presentation. 

This JavaScript code demonstrates the operation:

```javascript
// Instantiates a Presentation object that represents a presentation file
var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    // Sets the slide size for the generated presentations to that of the source
    presentation.getSlideSize().setSize(540, 720, aspose.slides.SlideSizeScaleType.EnsureFit);// Method SetSize is used to set slide size with scale content to ensure fit
    presentation.getSlideSize().setSize(aspose.slides.SlideSizeType.A4Paper, aspose.slides.SlideSizeScaleType.Maximize);// Method SetSize is used to set slide size with maximum size of content
    // Saves the presentation to disk
    presentation.save("Set_Size&Type_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Page Size when Generating PDF**

Certain presentations (like posters) are often converted to PDF docs. If you are looking to convert your PowerPoint to PDF to access the best printing and accessibility options, you want to set your slides to sizes that suit PDF documents (A4, for example).

Aspose.Slides provides the [SlideSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/) class to allow you to specify your preferred settings for slides. This JavaScript code shows you how to use the [getType()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#getType--) property (from the `SlideSize` class) to set a specific paper size for the slides in a presentation:

```javascript
// Instantiates a Presentation object that represents a presentation file
var presentation = new aspose.slides.Presentation();
try {
    // Sets the SlideSize.Type Property
    presentation.getSlideSize().setSize(aspose.slides.SlideSizeType.A4Paper, aspose.slides.SlideSizeScaleType.EnsureFit);
    // Sets different properties for PDF Options
    var opts = new aspose.slides.PdfOptions();
    opts.setSufficientResolution(600);
    // Saves the presentation to disk
    presentation.save("SetPDFPageSize_out.pdf", aspose.slides.SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```
