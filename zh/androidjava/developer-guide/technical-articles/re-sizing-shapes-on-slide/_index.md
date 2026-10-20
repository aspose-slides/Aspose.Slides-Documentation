---
title: 在 Android 上调整演示文稿幻灯片的形状大小
type: docs
weight: 130
url: /zh/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
keywords:
- 调整形状大小
- 改变形状尺寸
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，轻松调整 PowerPoint 和 OpenDocument 幻灯片上的形状大小——自动化幻灯片布局调整，提高工作效率。"
---
## **概述**

当您更改演示文稿的幻灯片尺寸时，可能还需要调整形状的大小并重新定位它们，以适应新尺寸。本文展示了如何手动缩放形状以及如何处理幻灯片、母版和布局中的表格。

## **调整形状大小**

为了保持每个形状的相对位置和大小，需要将其水平坐标和宽度乘以新幻灯片宽度与原始宽度的比例。将相应的高度比例应用于其垂直坐标和高度。

第一个示例加载一个幻灯片中不包含表格的演示文稿，将幻灯片尺寸更改为 A4，并保存结果。它使用 [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) 与 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) 来确保后续循环控制缩放。比例是无单位的；形状的位置和尺寸以点（points）为单位。不同的宽高比例会导致形状变形，且更改形状尺寸不会缩放其字体大小。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 计算独立的水平和垂直缩放因子。
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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
表格需要单独处理：通过缩放其列宽和行高，而不是直接设置表格的整体宽度和高度来实现。如果单元格内容需要更多空间，行高可能会保持大于设定值。
{{% /alert %}}

第二个示例支持表格，并在保存已调整大小的演示文稿之前处理母版、布局以及单个幻灯片上的形状。它的辅助工具通过使用 [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) 缩放列宽，使用 [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) 缩放最小行高来处理每个 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/)。随后，它仅缩放表格的位置，而不单独缩放其整体尺寸。

```java
import com.aspose.slides.*;

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
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // 调整母版、布局以及单个幻灯片上定义的形状大小。
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

如果在更改幻灯片尺寸时未对形状进行缩放，它们会保持原始位置和尺寸，可能会超出幻灯片范围。使用不同的宽高比例进行缩放也会导致形状失真。

**提供的代码适用于所有形状类型吗？**

第一个示例直接修改形状边界，适用于不含表格的幻灯片。第二个示例单独处理表格。请检查生成的布局，尤其是文本和表格，因为这些示例不会缩放字体大小，且表格内容可能限制行高。

**在调整幻灯片大小时如何调整表格大小？**

按宽度比例缩放列宽，按高度比例缩放最小行高，然后如第二个示例所示缩放表格的位置。

**此调整大小方法适用于母版幻灯片和布局幻灯片吗？**

是的。第二个示例遍历 [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) 并遍历每个母版的 [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--)，对它们的形状应用相同的调整大小逻辑。

**我能在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**

可以。请在更改幻灯片尺寸后、读取目标尺寸之前调用 [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-)，以便缩放系数反映最终的方向。

**我可以设置的幻灯片尺寸是否有上限？**

您可以使用 [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) 指定自定义幻灯片尺寸。支持的尺寸还取决于演示文稿的格式以及用于打开文件的应用程序。

**如何防止具有固定宽高比的形状失真？**

对宽度和高度使用相同的缩放系数。为了使原始布局适配新幻灯片尺寸，可对宽高使用较小的比例来计算尺寸和位置。这样可以保持比例，但可能在某一侧留下未使用的空间。