---
title: 在 Node.js 中调整演示文稿幻灯片上的形状大小
type: docs
weight: 130
url: /zh/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /zh/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- 调整形状大小
- 更改形状尺寸
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，轻松调整 PowerPoint 和 OpenDocument 幻灯片上的形状大小——自动化幻灯片布局调整并提升生产力。"
---
## **Overview**

当您更改演示文稿的幻灯片大小时，可能还需要调整形状的大小和位置以适应新的尺寸。本文展示了如何手动缩放形状以及如何处理幻灯片、母版和布局中的表格。

## **Resize Shapes**

为了保持每个形状的相对位置和大小，将其水平坐标和宽度乘以新幻灯片宽度与原始宽度的比例。将相应的高度比例应用于其垂直坐标和高度。

第一个示例加载一个幻灯片中不包含表格的演示文稿，将幻灯片大小更改为 A4，并保存结果。它使用[SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize)与[SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale)结合，以便后续循环控制缩放。比例是无单位的；形状的位置和尺寸以点为单位。不同的宽度和高度比例可能导致形状变形，且更改形状的尺寸不会缩放其字体大小。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // 计算独立的水平和垂直缩放因子。
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
表格需要单独处理：按列宽和行高进行缩放，而不是直接设置表格的整体宽度和高度。如果单元格内容需要更多空间，行高可能会保持大于请求的值。
{{% /alert %}}

第二个示例支持表格，并在保存已调整大小的演示文稿之前处理母版和布局以及各个幻灯片上的形状。它的辅助方法通过使用[Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth)缩放列宽，并使用[Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight)设置最小行高来处理每个[Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)。随后，它在不单独缩放整体尺寸的情况下缩放表格的位置。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // 表的尺寸由列宽和行高控制。
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // 计算独立的水平和垂直缩放因子。
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // 调整在母版、布局以及各个幻灯片上定义的形状大小。
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**为什么在调整幻灯片大小后形状会失真或被裁剪？**

如果在更改幻灯片大小时不对形状进行缩放，它们会保持原始的位置和尺寸，可能超出幻灯片范围。使用不同的宽高比例进行缩放也会导致形状失真。

**提供的代码适用于所有形状类型吗？**

第一个示例直接修改形状边界，适用于没有表格的幻灯片。第二个示例单独处理表格。请检查生成的布局，特别是文本和表格，因为这些示例不对字体大小进行缩放，且表格内容可能限制行高。

**在调整幻灯片大小时如何调整表格大小？**

如第二个示例所示，按宽度比例缩放列宽，按高度比例设置最小行高，然后缩放表格的位置。

**此调整大小方法适用于母版幻灯片和布局幻灯片吗？**

是的。第二个示例遍历[Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters)以及每个母版的[MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides)，并对其形状应用相同的调整大小逻辑。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**

可以。请在更改幻灯片大小后、读取目标尺寸前调用[SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation)，使缩放系数反映最终的方向。

**我可以设置的幻灯片大小是否有限制？**

您可以使用[SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize)指定自定义幻灯片尺寸。支持的尺寸还取决于演示文稿的格式以及用于打开文件的应用程序。

**如何防止具有固定纵横比的形状被拉伸变形？**

对宽度和高度使用相同的缩放因子。要在新的幻灯片尺寸内保持原始布局，请对宽高比例取较小者，并将其用于所有尺寸和位置的缩放。这样可以保持比例，但可能在某一边留下未使用的空间。