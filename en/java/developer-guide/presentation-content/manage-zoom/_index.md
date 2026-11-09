---
title: Manage Presentation Zoom in Java
linktitle: Manage Zoom
type: docs
weight: 60
url: /java/manage-zoom/
keywords:
- zoom
- zoom frame
- slide zoom
- section zoom
- summary zoom
- add zoom
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Create and customize Zoom with Aspose.Slides for Java — jump between sections, add thumbnails and transitions in PowerPoint presentations."
---

## **Introduction**

PowerPoint zooms let you navigate between specific slides and sections during a slide show. With Aspose.Slides for Java, you can create slide, section, and summary zooms and customize their previews, borders, and transitions.

![PowerPoint zoom overview](overview.png)

* To summarize an entire presentation on a single slide, use a [Summary Zoom](#summary-zoom).
* To show selected slides only, use a [Slide Zoom](#slide-zoom).
* To show a single section only, use a [Section Zoom](#section-zoom).

## **Slide Zoom**

A slide zoom can make your presentation more dynamic, allowing you to navigate freely between slides in any order you choose without interrupting the flow of your presentation. Slide zooms are great for short presentations without many sections, but you can still use them in different presentation scenarios.

Slide zooms let you explore related information from a single overview slide.

![Selecting slides for a slide zoom](slidezoomsel.png)

For slide zoom objects, Aspose.Slides provides the [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/zoomimagetype/) enumeration, the [IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/izoomframe/) interface, and methods on the [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) interface.

### **Create Zoom Frames**

Use [IShapeCollection.addZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addZoomFrame-float-float-float-float-com.aspose.slides.ISlide-) to place links to individual slides on an overview slide. This example creates two target slides with distinct backgrounds and labels, then adds a preview of each to the first slide and saves the presentation as PPTX. Frame positions and dimensions are specified in points.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide overviewSlide = presentation.getSlides().get_Item(0);

    ISlide secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(BackgroundType.OwnBackground);
    secondSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN);

    IAutoShape textBox = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(BackgroundType.OwnBackground);
    thirdSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(new Color(189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Create Zoom Frames with Custom Images**

Pass a custom image to [IShapeCollection.addZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addZoomFrame-float-float-float-float-com.aspose.slides.ISlide-com.aspose.slides.IPPImage-) to replace the target slide's default preview. This example requires a local image, loads it with [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-), and adds it to the presentation using [IImageCollection.addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). The resulting frame displays that image while still linking to the second slide.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide overviewSlide = presentation.getSlides().get_Item(0);

    ISlide slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN);

    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    IPPImage previewImage;
    IImage image = Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    overviewSlide.getShapes().addZoomFrame(20, 20, 300, 200, slide, previewImage);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Format Zoom Frames**

This example customizes two slide zoom frames. It assigns a local image to the first frame through [IZoomObject.setZoomImage](https://reference.aspose.com/slides/java/com.aspose.slides/izoomobject/#setZoomImage-com.aspose.slides.IPPImage-), and gives the second frame a five-point, dash-dot pink border through [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--). Passing `false` to [IZoomObject.setShowBackground](https://reference.aspose.com/slides/java/com.aspose.slides/izoomobject/#setShowBackground-boolean-) hides the second frame's background. A local image is required for the custom preview; both frames retain their slide targets in the saved PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide overviewSlide = presentation.getSlides().get_Item(0);

    ISlide secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(BackgroundType.OwnBackground);
    secondSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN);

    IAutoShape textBox = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(BackgroundType.OwnBackground);
    thirdSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(new Color(189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    IZoomFrame firstZoomFrame = overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    IZoomFrame secondZoomFrame = overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    IPPImage previewImage;
    IImage image = Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    firstZoomFrame.setZoomImage(previewImage);

    secondZoomFrame.getLineFormat().setWidth(5);
    secondZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    secondZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 105, 180));
    secondZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    secondZoomFrame.setShowBackground(false);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Section Zoom**

A section zoom links to a section in your presentation. Use it to revisit a topic or show how different parts of the presentation connect.

![Selecting a section for a section zoom](seczoomsel.png)

For section zoom objects, Aspose.Slides provides the [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/isectionzoomframe/) interface and methods on the [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) interface.

### **Create Section Zoom Frames**

Create a section with [ISectionCollection.addSection](https://reference.aspose.com/slides/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-), then pass the returned section to [IShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSectionZoomFrame-float-float-float-float-com.aspose.slides.ISection-). This example places a section zoom on the first slide and links it to a section beginning with a colored slide. The frame's position and dimensions are specified in points, and the presentation is saved as PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide overviewSlide = presentation.getSlides().get_Item(0);

    ISlide slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(new Color(154, 205, 50));
    slide.getBackground().setType(BackgroundType.OwnBackground);

    ISection section = presentation.getSections().addSection("Section 1", slide);
    ISectionZoomFrame sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Create Section Zoom Frames with Custom Images**

The image overload of [IShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSectionZoomFrame-float-float-float-float-com.aspose.slides.ISection-com.aspose.slides.IPPImage-) lets you display a custom preview without changing the destination section. This example requires a local image, which is loaded with [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) and added through [IImageCollection.addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). The saved presentation contains a section zoom on the first slide linked to the newly created section.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide overviewSlide = presentation.getSlides().get_Item(0);

    ISlide slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(new Color(154, 205, 50));
    slide.getBackground().setType(BackgroundType.OwnBackground);

    IPPImage previewImage;
    IImage image = Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    ISection section = presentation.getSections().addSection("Section 1", slide);
    ISectionZoomFrame sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, previewImage);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Change a Section Zoom's Target Section**

Use [ISectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/java/com.aspose.slides/isectionzoomframe/#setTargetSection-com.aspose.slides.ISection-) to redirect an existing section zoom without recreating it. Choose a populated section from the same presentation's [Presentation.getSections](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSections--) collection. Assigning an empty section leaves the current target unchanged, so check [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/java/com.aspose.slides/isection/#getSlidesListOfSection--) before assigning it. See [Manage Slide Sections](/slides/java/slide-section/) for more about sections.

The following example loads a presentation file, which must contain multiple populated sections, an existing section zoom named `Section navigation`, and a section with the unique name `Results`. It searches all slides for the zoom and finds the destination by name rather than by a collection index that can change when sections are reordered. If names are not unique, use [ISection.getSectionId](https://reference.aspose.com/slides/java/com.aspose.slides/isection/#getSectionId--) to identify the destination instead.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("section-zoom.pptx");
try {
    ISectionZoomFrame zoom = null;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ISectionZoomFrame && "Section navigation".equals(shape.getName())) {
                zoom = (ISectionZoomFrame) shape;
                break;
            }
        }
        if (zoom != null) {
            break;
        }
    }

    ISection targetSection = null;
    for (ISection section : presentation.getSections()) {
        if ("Results".equals(section.getName())) {
            targetSection = section;
            break;
        }
    }

    if (zoom == null || targetSection == null) {
        System.out.println("The section zoom or destination section was not found.");
    } else if (targetSection.getSlidesListOfSection().size() == 0) {
        System.out.println("The destination section is empty.");
    } else {
        ISection currentSection = zoom.getTargetSection();
        System.out.println("Current section: " + (currentSection == null ? "" : currentSection.getName()));
        zoom.setTargetSection(targetSection);
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

### **Format Section Zoom Frames**

This example moves and resizes a section zoom to 100 by 75 points, assigns a local image through [IZoomObject.setZoomImage](https://reference.aspose.com/slides/java/com.aspose.slides/izoomobject/#setZoomImage-com.aspose.slides.IPPImage-), and applies a 2.5-point, dash-dot brown border. It enables [IZoomObject.setReturnToParent](https://reference.aspose.com/slides/java/com.aspose.slides/izoomobject/#setReturnToParent-boolean-) to return to the originating slide after the section, disables [IZoomObject.setShowBackground](https://reference.aspose.com/slides/java/com.aspose.slides/izoomobject/#setShowBackground-boolean-), and sets [IZoomObject.setTransitionDuration](https://reference.aspose.com/slides/java/com.aspose.slides/izoomobject/#setTransitionDuration-float-) to 1.5 seconds. A local image is required for the custom preview.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide overviewSlide = presentation.getSlides().get_Item(0);

    ISlide slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(new Color(154, 205, 50));
    slide.getBackground().setType(BackgroundType.OwnBackground);

    ISection section = presentation.getSections().addSection("Section 1", slide);

    ISectionZoomFrame sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage previewImage;
    IImage image = Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    sectionZoomFrame.setZoomImage(previewImage);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(165, 42, 42));
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Summary Zoom**

A summary zoom provides an overview of presentation sections. During a slide show, you can use it to jump to a section, skip ahead, or revisit a topic without following the slide order.

![Selecting sections for a summary zoom](sumzoomsel.png)

For summary zoom objects, Aspose.Slides provides the [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/isummaryzoomsection/), and [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/isummaryzoomsectioncollection/) interfaces and methods on the [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) interface.

### **Create a Summary Zoom**

Use [IShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSummaryZoomFrame-float-float-float-float-) to create an overview of the presentation's sections. This example creates four sections with distinct slide backgrounds and adds a summary zoom to the first slide. The frame's position and dimensions are specified in points, and the resulting overview is saved in a PPTX presentation.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide overviewSlide = presentation.getSlides().get_Item(0);

    ISlide slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(new Color(165, 42, 42));
    slide.getBackground().setType(BackgroundType.OwnBackground);

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    presentation.getSections().addSection("Section 2", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(new Color(127, 255, 0));
    slide.getBackground().setType(BackgroundType.OwnBackground);

    presentation.getSections().addSection("Section 3", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(new Color(0, 100, 0));
    slide.getBackground().setType(BackgroundType.OwnBackground);

    presentation.getSections().addSection("Section 4", slide);

    ISummaryZoomFrame summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Add and Remove a Summary Zoom Section**

A summary zoom stores its [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/isummaryzoomsection/) objects in [ISummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/java/com.aspose.slides/isummaryzoomframe/#getSummaryZoomCollection--). This example creates an overview of two sections, adds a third section using [ISummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/isummaryzoomsectioncollection/#addSummaryZoomSection-com.aspose.slides.ISection-), and removes the first section's entry using [ISummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/isummaryzoomsectioncollection/#removeSummaryZoomSection-com.aspose.slides.ISection-). Removing the entry leaves the presentation section and its slides intact.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide overviewSlide = presentation.getSlides().get_Item(0);

    ISlide slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(new Color(165, 42, 42));
    slide.getBackground().setType(BackgroundType.OwnBackground);

    ISection firstSection = presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    presentation.getSections().addSection("Section 2", slide);

    ISummaryZoomFrame summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(new Color(127, 255, 0));
    slide.getBackground().setType(BackgroundType.OwnBackground);

    ISection thirdSection = presentation.getSections().addSection("Section 3", slide);

    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(thirdSection);

    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(firstSection);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Format Summary Zoom Sections**

This example formats the first entry in [ISummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/java/com.aspose.slides/isummaryzoomframe/#getSummaryZoomCollection--), using the zero-based index `0`. It requires a local image for [IZoomObject.setZoomImage](https://reference.aspose.com/slides/java/com.aspose.slides/izoomobject/#setZoomImage-com.aspose.slides.IPPImage-), applies a 1.5-point, dash-dot black border, and sets [IZoomObject.setTransitionDuration](https://reference.aspose.com/slides/java/com.aspose.slides/izoomobject/#setTransitionDuration-float-) to 1.5 seconds. Passing `false` to [IZoomObject.setReturnToParent](https://reference.aspose.com/slides/java/com.aspose.slides/izoomobject/#setReturnToParent-boolean-) disables the automatic return to the summary slide for this entry.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide overviewSlide = presentation.getSlides().get_Item(0);

    ISlide slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(new Color(165, 42, 42));
    slide.getBackground().setType(BackgroundType.OwnBackground);

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    presentation.getSections().addSection("Section 2", slide);

    ISummaryZoomFrame summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    IPPImage previewImage;
    IImage image = Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    summarySection.setZoomImage(previewImage);
    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

Yes. Call [IZoomObject.setReturnToParent](https://reference.aspose.com/slides/java/com.aspose.slides/izoomobject/#setReturnToParent-boolean-) with `true` to return to the originating slide after the target content is shown.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Yes. Use [IZoomObject.setTransitionDuration](https://reference.aspose.com/slides/java/com.aspose.slides/izoomobject/#setTransitionDuration-float-) to control the transition duration in seconds.

**Are there limits on how many Zoom objects a presentation can contain?**

There is no hard API limit documented. Practical limits depend on overall presentation complexity and the viewer's performance. You can add many Zoom frames, but consider file size and rendering time.
