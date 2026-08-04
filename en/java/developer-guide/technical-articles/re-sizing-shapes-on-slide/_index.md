---
title: Resize Shapes on Presentation Slides
type: docs
weight: 110
url: /java/re-sizing-shapes-on-slide/
keywords:
- resize shape
- change shape size
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Easily resize shapes on PowerPoint and OpenDocument slides with Aspose.Slides for Java—automate slide layout adjustments and boost productivity."
---

## **Overview**

One of the most common questions from Aspose.Slides for Java customers is how to resize shapes so that, when the slide size changes, the data isn’t cut off. This short technical article shows how to do that.

## **Resize Shapes**

To prevent shapes from becoming misaligned when the slide size changes, update each shape’s position and dimensions so they conform to the new slide layout.

```java
import com.aspose.slides.*;

// Load the presentation file.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Get the original slide size.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Change the slide size without scaling existing shapes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Get the new slide size.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Resize and reposition shapes on every slide.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Scale the shape size.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Scale the shape position.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}} 

Tables need no special treatment: setting a table's width and height rescales its columns and rows proportionally, so scaling the row heights and column widths again would apply the ratio twice.

{{% /alert %}} 

The code above changes only the shapes on the slides. Master slides and layout slides keep their own shapes, so scale them as well when you want the whole presentation to follow the new slide size:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Get the original slide size.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Change the slide size without scaling existing shapes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Get the new slide size.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Scale the shape size.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Scale the shape position.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Scale the shape size.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Scale the shape position.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Scale the shape size.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Scale the shape position.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

### Why are shapes distorted or cut off after resizing a slide?

When resizing a slide, shapes retain their original position and size unless the scale is explicitly changed. This can result in content being cropped or shapes being misaligned.

### Does the provided code work for all shape types?

Yes. Setting the height and width works for text boxes, images, charts, and tables alike.

### How do I resize tables when resizing a slide?

Scale the table shape itself, exactly like any other shape. Its rows and columns follow proportionally, so do not scale them again afterwards.

### Will this resizing work for master slides and layout slides?

Yes, but you should also loop through [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) and [Layout slides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) and apply the same scaling logic to their shapes to ensure consistency across the presentation.

### Can I change the orientation of a slide (portrait/landscape) along with the resizing?

Yes. You can use [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#setOrientation-int-) to change the orientation. Make sure you set the scaling logic accordingly to preserve the layout.

### Is there a limit to the slide size I can set?

Aspose.Slides supports custom sizes, but very large sizes may affect performance or compatibility with some versions of PowerPoint.

### How can I prevent fixed aspect ratio shapes from becoming distorted?

You can check the `getAspectRatioLocked` method of the shape before scaling. If it is locked, adjust the width or height proportionally rather than scaling them individually.
