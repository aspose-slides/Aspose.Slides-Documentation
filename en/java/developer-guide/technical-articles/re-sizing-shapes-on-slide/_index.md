---
title: Resize Shapes on Presentation Slides in Java
type: docs
weight: 130
url: /java/resizing-shapes-on-slide/
aliases:
  /java/re-sizing-shapes-on-slide/
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

When you change a presentation's slide size, you may also need to resize and reposition its shapes to fit the new dimensions. This article shows how to scale shapes manually and how to handle tables on slides, masters, and layouts.

## **Resize Shapes**

To preserve each shape's relative position and size, multiply its horizontal coordinates and width by the ratio of the new slide width to the original width. Apply the corresponding height ratio to its vertical coordinates and height.

The first example loads a presentation whose slides contain no tables, changes the slide size to A4, and saves the result. It uses [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) with [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) so that the subsequent loop controls the scaling. The ratios are unitless; shape positions and dimensions are measured in points. Different width and height ratios can distort shapes, and changing a shape's dimensions does not scale its font sizes.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calculate independent horizontal and vertical scale factors.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Tables require separate handling: scale their column widths and row heights instead of assigning the table's overall width and height. Row heights may remain larger than requested if the cell content requires more space.

{{% /alert %}}

The second example supports tables and processes shapes on masters and layouts as well as individual slides before saving the resized presentation. Its helper handles each [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) by scaling column widths with [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) and minimum row heights with [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). It then scales the table's position without separately scaling its overall dimensions.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Table dimensions are controlled by column widths and row heights.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calculate independent horizontal and vertical scale factors.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Resize shapes defined on masters and layouts as well as individual slides.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Why are shapes distorted or cut off after resizing a slide?**

If you change the slide size without scaling the shapes, they keep their original positions and dimensions and may extend beyond the slide. Scaling width and height by different ratios can also distort shapes.

**Does the provided code work for all shape types?**

The first example changes shape bounds directly and is intended for slides without tables. The second example handles tables separately. Check the resulting layout, particularly text and tables, because these examples do not scale font sizes and table content can constrain row heights.

**How do I resize tables when resizing a slide?**

Scale column widths by the width ratio and minimum row heights by the height ratio, then scale the table's position, as shown in the second example.

**Will this resizing work for master slides and layout slides?**

Yes. The second example iterates through [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) and each master's [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) and applies the same resizing logic to their shapes.

**Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Yes. Call [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) after changing the slide size and before reading the target dimensions, so the scale factors reflect the final orientation.

**Is there a limit to the slide size I can set?**

You can specify custom slide dimensions with [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). The supported dimensions also depend on the presentation format and the application used to open the file.

**How can I prevent shapes with a fixed aspect ratio from becoming distorted?**

Use the same scale factor for width and height. To fit the original layout within the new slide dimensions, use the smaller of the width and height ratios for both dimensions and positions. This preserves proportions but may leave unused space along one edge.
