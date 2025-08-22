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

If a slide contains a table, the code above will not work correctly. In that case, each cell in the table must be resized.

{{% /alert %}} 

Use the following code on your end to resize slides that contain tables. For tables, setting the width or height is a special case: you must adjust individual row heights and column widths to change the table’s overall size.

```java
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
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Q: Why are shapes distorted or cut off after resizing a slide?**

When resizing a slide, shapes retain their original position and size unless the scale is explicitly changed. This can result in content being cropped or shapes being misaligned.

**Q: Does the provided code work for all shape types?**

The basic example works for most shape types (text boxes, images, charts, etc.). However, for tables, you need to handle rows and columns separately, since the height and width of a table are determined by the dimensions of individual cells.

**Q: How do I resize tables when resizing a slide?**

You need to loop through all the rows and columns of the table and resize their height and width proportionally, as shown in the second code example.

**Q: Will this resizing work for master slides and layout slides?**

Yes, but you should also loop through [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) and [Layout slides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) and apply the same scaling logic to their shapes to ensure consistency across the presentation.

**Q: Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Yes. You can use [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#setOrientation-int-) to change the orientation. Make sure you set the scaling logic accordingly to preserve the layout.

**Q: Is there a limit to the slide size I can set?**

Aspose.Slides supports custom sizes, but very large sizes may affect performance or compatibility with some versions of PowerPoint.

**Q: How can I prevent fixed aspect ratio shapes from becoming distorted?**

You can check the `getAspectRatioLocked` method of the shape before scaling. If it is locked, adjust the width or height proportionally rather than scaling them individually.
