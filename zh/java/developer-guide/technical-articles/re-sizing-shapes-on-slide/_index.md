---
title: 在 Java 中调整演示文稿幻灯片上的形状大小
type: docs
weight: 130
url: /zh/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /zh/java/re-sizing-shapes-on-slide/
keywords:
  - 调整形状大小
  - 更改形状尺寸
  - PowerPoint
  - OpenDocument
  - 演示文稿
  - Java
  - Aspose.Slides
description: "使用 Aspose.Slides for Java 轻松调整 PowerPoint 和 OpenDocument 幻灯片上的形状大小——自动化幻灯片布局调整，提升工作效率。"
---
## **概述**

当您更改演示文稿的幻灯片尺寸时，可能还需要调整形状的大小和位置，以适应新的尺寸。本文展示了如何手动缩放形状以及如何处理幻灯片、母版和布局中的表格。

## **调整形状**

为了保持每个形状的相对位置和大小，将其水平坐标和宽度乘以新幻灯片宽度与原始宽度的比率。对其垂直坐标和高度应用相应的高度比率。

第一个示例加载一个幻灯片中不包含表格的演示文稿，将幻灯片尺寸更改为 A4 并保存结果。它使用 [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) 与 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) 来确保后续循环控制缩放。比率是无单位的；形状的位置和尺寸以点为单位测量。不同的宽高比率会导致形状变形，并且更改形状尺寸不会缩放其字体大小。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 计算独立的水平和垂直缩放因子。
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
表格需要单独处理：通过缩放列宽和行高来调整，而不是直接设置表格的整体宽度和高度。如果单元格内容需要更多空间，行高可能会保持大于请求的值。
{{% /alert %}}

第二个示例支持表格，并在保存调整大小的演示文稿之前处理母版、布局以及各个幻灯片上的形状。它的辅助工具通过使用 [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) 缩放列宽和使用 [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) 缩放最小行高来处理每个 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/)。然后仅缩放表格的位置，而不单独缩放其整体尺寸。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // 表格尺寸由列宽和行高控制。
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
    // 计算独立的水平和垂直缩放因子。
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // 调整在母版、布局以及各个幻灯片上定义的形状大小。
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

## **常见问题**

**为什么在调整幻灯片大小后形状会失真或被截断？**  
如果在更改幻灯片尺寸时未对形状进行缩放，它们会保持原始位置和尺寸，可能超出幻灯片范围。使用不同的宽高比进行缩放也会导致形状失真。

**提供的代码是否适用于所有形状类型？**  
第一个示例直接修改形状边界，适用于没有表格的幻灯片。第二个示例单独处理表格。请检查生成的布局，尤其是文本和表格，因为这些示例不对字体大小进行缩放，且表格内容可能限制行高。

**在调整幻灯片大小时如何调整表格？**  
按宽度比率缩放列宽，按高度比率缩放最小行高，然后如第二个示例所示缩放表格的位置。

**此调整大小是否适用于母版幻灯片和布局幻灯片？**  
是的。第二个示例遍历 [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) 以及每个母版的 [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--)，对其形状应用相同的调整大小逻辑。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**  
可以。请在更改幻灯片尺寸后、读取目标尺寸之前调用 [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-)，以便缩放因子反映最终方向。

**我可以设定的幻灯片尺寸是否有限制？**  
您可以使用 [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) 指定自定义幻灯片尺寸。支持的尺寸还取决于演示文稿的格式以及用于打开文件的应用程序。

**如何防止固定宽高比的形状被扭曲？**  
对宽度和高度使用相同的缩放因子。若要在新幻灯片尺寸内保持原始布局，请对宽高和位置均使用宽度比率和高度比率中较小的那个。这可以保持比例，但可能在某一边留下未使用的空间。