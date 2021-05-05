---
title: Slide Layout
type: docs
weight: 60
url: /java/slide-layout/
---


## **Add Slide Layout to Presentation**
Aspose.Slides also offer to add Layout slides in presentation. There are cases when there is missing Layout slide in presentation and once can now add the Layout Slides in presentation. Each slide has unique Id and Layout slides are maintained inside presentation Masters. One can access the Layout slide either by Type or by Name. Aspose.Slides for Java allows developers to add new Layout slides in presentation. To add a Layout Slide, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Access the [Master Slide](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) collection.
1. Try to find existing Layout slides to see if the required one is already available in [Layout Slide](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) collection or not.
1. Add a new Layout slide if the desired layout is unavailable.
1. Add an empty slide with a newly added Layout slide.
1. Finally, write the presentation file using the Presentation object.

In the example given below, we have added Layout Slides to Presentation.

```java
// Instantiate Presentation class that represents the presentation file
Presentation pres = new Presentation("AccessSlides.pptx");
try {
    // Try to search by layout slide type
    IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;

    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // The situation when a presentation doesn't contain some type of layouts.
        // Technographics.pptx presentation only contains Blank and Custom layout types.
        // But layout slides with Custom types has different slide names, like "Title", "Title and Content", etc. 
        // And it is possible to use these names for layout slide selection.
        // Also it is possible to use the set of placeholder shape types. For example,
        // Title slide should have only Title placeholder type, etc.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName() == "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }
        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName() == "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }
            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Adding empty slide with added layout slide
    pres.getSlides().insertEmptySlide(0, layoutSlide);

    // Save presentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Set Size and Type of Slide**
[SlideSize.getType](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideSize#getType--) and [SlideSize.setSize](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideSize#setSize-float-float-int-) are the properties of presentation class which could be set or get as shown below in the example.

```java
// Instantiate Presentation objects that represent presentation files
Presentation presentation = new Presentation("demo.pptx");
try {
    Presentation auxPresentation = new Presentation();
    try {
        // Set the slide size of generated presentations to that of source
        auxPresentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit);
        //getType());
        auxPresentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);
        
        // Clone required slide
        auxPresentation.getSlides().addClone(presentation.getSlides().get_Item(0));
        auxPresentation.getSlides().removeAt(0);
        
        // Save Presentation to disk
        auxPresentation.save("size.pptx", SaveFormat.Pptx);
    } finally {
        auxPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Set Footer Visibility Inside Slide**
To set footer in a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain a slide by its reference index.
1. Set Footer visible by making slide footer placeholder visible.
1. Set date-time placeholder visible by using the [setDateTimeText](https://apireference.aspose.com/slides/java/com.aspose.slides/IBaseSlideHeaderFooterManager#setDateTimeText-java.lang.String-) method.
1. Write the modified presentation file.

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // Method isFooterVisible is used for indicating that a slide footer placeholder is not present.
    {
        headerFooterManager.setFooterVisibility(true); // Method setFooterVisibility is used for making a slide footer placeholder visible.
    }
    if (!headerFooterManager.isSlideNumberVisible()) // Method isSlideNumberVisible is used for indicating that a slide page number placeholder is not present.
    {
        headerFooterManager.setSlideNumberVisibility(true); // Method setSlideNumberVisibility is used for making a slide page number placeholder visible.
    }
    if (!headerFooterManager.isDateTimeVisible()) // Method isDateTimeVisible is used for indicating that a slide date-time placeholder is not present.
    {
        headerFooterManager.setDateTimeVisibility(true); // Method setFooterVisibility is used for making a slide date-time placeholder visible.
    }
    headerFooterManager.setFooterText("Footer text"); // Method setFooterText is used for setting text to slide footer placeholder.
    headerFooterManager.setDateTimeText("Date and time text"); // Method setDateTimeText is used for setting text to slide date-time placeholder.
} finally {
    presentation.dispose();
}
```

## **Set Child Footer Visibility Inside Slide**
To set footer and child footer a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the master slide by using its index.
1. Set Footer and child footer visibility by making a master slide and all child footer placeholder visible.
1. Set text to master slide and all child footer placeholder by using [setFooterAndChildFootersText](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlideHeaderFooterManager#setFooterAndChildFootersText-java.lang.String-) method.
1. Set text to master slide and all child date-time placeholder by using [setDateTimeAndChildDateTimesText](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlideHeaderFooterManager#setDateTimeAndChildDateTimesText-java.lang.String-) method.
1. Write the modified presentation file.

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // Method setFooterAndChildFootersVisibility is used for making a master slide and all child footer placeholders visible.
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // Method setSlideNumberAndChildSlideNumbersVisibility is used for making a master slide and all child page number placeholders visible.
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // Method setDateTimeAndChildDateTimesVisibility is used for making a master slide and all child date-time placeholders visible.

    headerFooterManager.setFooterAndChildFootersText("Footer text"); // Method setFooterAndChildFootersText is used for setting text to master slide and all child footer placeholders.
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // Method setDateTimeAndChildDateTimesText is used for setting text to master slide and all child date-time placeholders.
} finally {
    presentation.dispose();
}
```

## **Set Slide Size with Respect to Content Scaling**
You can also set the slide size by using it with different ways of content scaling. [SlideSize.getType](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideSize#getType--) and [SlideSize.setSize](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideSize#setSize-int-int-) are the methods of presentation class which could be set or get as shown below in the example.

```java
// Instantiate Presentation objects that represent presentation files
Presentation presentation = new Presentation("demo.pptx");
try {
    // Set the slide size of generated presentations to that of source
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // Method SetSize is used for set slide size with scale content to ensure fit
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // Method SetSize is used for set slide size with maximize size of content

    // Save Presentation to disk
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Page Size when Generating PDF**
Slides in presentation could be set as different paper sizes. The [SlideSize.getType](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideSize#getType--) method can be used to set the slide size. Developers can set the size of a slide as shown below in the example.

```java
// Instantiate a Presentation object that represents a presentation file 
Presentation presentation = new Presentation();
try {
    // Set SlideSize.Type Property 
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);
    
    // Set different properties of PDF Options
    PdfOptions opts = new  PdfOptions();
    opts.setSufficientResolution(600);
    
    // Save presentation to disk
    presentation.save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```

