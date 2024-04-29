---
title: Manage Zoom
type: docs
weight: 60
url: /java/manage-zoom/
keywords: "Zoom, Zoom frame, Add zoom, Format zoom frame, Summary zoom, PowerPoint presentation, Java, Aspose.Slides for PHP via Java"
description: "Add zoom or zoom frames to PowerPoint presentations in Java"
---

## **Overview**
Zooms in PowerPoint allow you to jump to and from specific slides, sections, and portions of a presentation. When you are presenting, this ability to navigate quickly across content might prove very useful. 

![overview_image](overview.png)

* To summarize an entire presentation on a single slide, use a [Summary Zoom](#Summary-Zoom).
* To show selected slides only, use a [Slide Zoom](#Slide-Zoom).
* To show a single section only, use a [Section Zoom](#Section-Zoom).

## **Slide Zoom**
A slide zoom can make your presentation more dynamic, allowing you to navigate freely between slides in any order you choose without interrupting the flow of your presentation. Slide zooms are great for short presentations without many sections, but you can still use them in different presentation scenarios.

Slide zooms help you drill into multiple pieces of information while you feel like you are on a single canvas. 

![overview_image](slidezoomsel.png)

For slide zoom objects, Aspose.Slides provides the [ZoomImageType](https://reference.aspose.com/slides/php-java/com.aspose.slides/ZoomImageType) enumeration, the [IZoomFrame](https://reference.aspose.com/slides/php-java/com.aspose.slides/IZoomFrame) interface, and some methods under the [IShapeCollection](https://reference.aspose.com/slides/php-java/com.aspose.slides/IShapeCollection) interface.

### **Creating Zoom Frames**

You can add a zoom frame on a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
2.	Create new slides to which you intend to link the zoom frames. 
3.	Add an identification text and background to the created slides.
4.  Add zoom frames (containing the references to created slides) to the first slide.
5.	Write the modified presentation as a PPTX file.

This Java code shows you how to create a zoom frame on a slide:

``` java
Presentation pres = new Presentation();
try {
    //Adds new slides to the presentation
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Creates a background for the second slide
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Creates a text box for the second slide
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Creates a background for the third slide
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Create a text box for the third slide
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Adds ZoomFrame objects
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Creating Zoom Frames with Custom Images**
With Aspose.Slides for PHP via Java, you can create a zoom frame with a different slide preview image this way:
1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
2.	Create a new slide to which you intend to link the zoom frame. 
3.	Add an identification text and background to the slide.
4.  Create an [IPPImage](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPPImage) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) object that will be used to fill the frame.
5.  Add zoom frames (containing the reference to created slide) to the first slide.
6.	Write the modified presentation as a PPTX file.

This Java code shows you how to create a zoom frame with a different image:

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Creates a background for the second slide
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Creates a text box for the third slide
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Creates a new image for the zoom object
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Adds the ZoomFrame object
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatting Zoom Frames**
In the previous sections, we showed you how to create simple zoom frames. To create more complicated zoom frames, you have to alter a simple frame's formatting. There are several formatting options you can apply to a zoom frame. 

You can control a zoom frame's formatting on a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
2.	Create new slides to link to which you intend to link the zoom frame. 
3.	Add some identification text and background to the created slides.
4.  Add zoom frames (containing the references to the created slides) to the first slide.
5.  Create an [IPPImage](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPPImage) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) object that will be used to fill the frame.
6.  Set a custom image for the first zoom frame object.
7.  Change the line format for the second zoom frame object.
8.  Remove the background from an image of the second zoom frame object.
5.	Write the modified presentation as a PPTX file.

This Java code shows you how to change a zoom frame's formatting on a slide: 

``` java 
Presentation pres = new Presentation();
try {
    //Adds new slides to the presentation
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Creates a background for the second slide
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Creates a text box for the second slide
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Creates a background for the third slide
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Creates a text box for the third slide
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Adds ZoomFrame objects
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Creates a new image for the zoom object
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Sets custom image for zoomFrame1 object
    zoomFrame1.setImage(picture);

    // Sets a zoom frame format for the zoomFrame2 object
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Setting for Do not show background for zoomFrame2 object
    zoomFrame2.setShowBackground(false);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Section Zoom**

A section zoom is a link to a section in your presentation. You can use section zooms to go back to sections you want to really emphasize. Or you can use them to highlight how certain pieces of your presentation connect. 

![overview_image](seczoomsel.png)

For section zoom objects, Aspose.Slides provides the [ISectionZoomFrame](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISectionZoomFrame) interface and some methods under the [IShapeCollection](https://reference.aspose.com/slides/php-java/com.aspose.slides/IShapeCollection) interface.

### **Creating Section Zoom Frames**

You can add a section zoom frame to a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
2.	Create a new slide. 
3.	Add an identification background to the created slide.
4.  Create a new section to which you intend to link the zoom frame. 
5.  Add a section zoom frame (containing references to the created section) to the first slide.
6.	Write the modified presentation as a PPTX file.

This Java code shows you how to create a zoom frame on a slide:

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new Section to the presentation
    pres.getSections().addSection("Section 1", slide);

    // Adds a SectionZoomFrame object
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Creating Section Zoom Frames with Custom Images**

Using Aspose.Slides for PHP via Java, you can create a section zoom frame with a different slide preview image this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
2.	Create a new slide.
3.	Add an identification background to created slide.
4.	Create a new section to which you intend to link the zoom frame. 
5.  Create an [IPPImage](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPPImage) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) object that will be used to fill the frame.
5.  Add a section zoom frame (containing a reference to the created section) to the first slide.
6.	Write the modified presentation as a PPTX file.

This Java code shows you how to create a zoom frame with a different image:

``` java 
Presentation pres = new Presentation();
try {
    //Adds new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new Section to the presentation
    pres.getSections().addSection("Section 1", slide);

    // Creates a new image for the zoom object
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adds SectionZoomFrame object
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatting Section Zoom Frames**

To create more complicated section zoom frames, you have to alter a simple frame's formatting. There are several formatting options you can apply to a section zoom frame. 

You can control a section zoom frame's formatting on a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
2.	Create a new slide.
3.	Add identification background to created slide.
4.	Create a new section to which you intend to link the zoom frame. 
5.	Add a section zoom frame (containing references to created section) to the first slide.
6.	Change the size and position for the created section zoom object.
7.	Create an [IPPImage](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPPImage) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) object that will be used to fill the frame.
8.	Set a custom image for the created section zoom frame object.
9.	Set the *return to the original slide from the linked section* ability. 
10.	Remove the background from an image of the section zoom frame object.
11.	Change the line format for the second zoom frame object.
12.	Change the transition duration.
13.	Write the modified presentation as a PPTX file.

This Java code shows you how to change a section zoom frame's formatting:

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new Section to the presentation
    pres.getSections().addSection("Section 1", slide);

    // Add SectionZoomFrame object
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formatting for SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Summary Zoom**

A summary zoom is like a landing page where all the pieces of your presentation are displayed at once. When you're presenting, you can use the zoom to go from one place in your presentation to another in any order you like. You can get creative, skip ahead, or revisit pieces of your slide show without interrupting the flow of your presentation.

![overview_image](sumzoomsel.png)

For summary zoom objects, Aspose.Slides provides the [ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISummaryZoomSection), and [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISummaryZoomSectionCollection) interfaces and some methods under the [IShapeCollection](https://reference.aspose.com/slides/php-java/com.aspose.slides/IShapeCollection) interface.

### **Creating Summary Zoom**

You can add a summary zoom frame to a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
2.	Create new slides with identification background and new sections for created slides.
3.  Add the summary zoom frame to the first slide.
4.	Write the modified presentation as a PPTX file.

This Java code shows you how to create a summary zoom frame on a slide:

``` java 
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 2", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 3", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 4", slide);

    // Adds a SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Adding and Removing Summary Zoom Section**

All sections in a summary zoom frame are represented by [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISummaryZoomSection) objects, which are stored in the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISummaryZoomSectionCollection) object. You can add or remove a summary zoom section object through the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISummaryZoomSectionCollection) interface this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
2.	Create new slides with identification background and new sections for created slides.
3.  Add a summary zoom frame into the first slide.
4.  Add a new slide and section to the presentation.
5.  Add the created section to the summary zoom frame.
6.  Remove the first section from the summary zoom frame.
7.	Write the modified presentation as a PPTX file.

This Java code shows you how to add and remove sections in a summary zoom frame:

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 2", slide);

    // Adds SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Adds a section to the Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Removes section from the Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatting Summary Zoom Sections**

To create more complicated summary zoom section objects, you have to alter a simple frame's formatting. There are several formatting options you can apply to a summary zoom section object. 

You can control the formatting for a summary zoom section object in a summary zoom frame this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
2.	Create new slides with identification background and new sections for created slides.
3.  Add a summary zoom frame to the first slide.
4.  Get a summary zoom section object for the first object from the `ISummaryZoomSectionCollection`.
7.  Create an [IPPImage](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPPImage) object by adding an image to the images collection associated with the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) object that will be used to fill the frame.
8.  Set a custom image for the created section zoom frame object.
9.  Set the *return to the original slide from the linked section* ability. 
11. Change the line format for the second zoom frame object.
12. Change the transition duration.
13.	Write the modified presentation as a PPTX file.

This Java code shows you how to change the formatting for a summary zoom section object:

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 2", slide);

    // Adds a SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Gets the first SummaryZoomSection object
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formatting for SummaryZoomSection object
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

  