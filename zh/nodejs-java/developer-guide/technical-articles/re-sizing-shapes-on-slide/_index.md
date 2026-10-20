---
title: 在 Node.js 中调整演示文稿幻灯片上的形状大小
type: docs
weight: 130
url: /zh/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
  - /zh/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- 调整形状
- 更改形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "轻松使用 Aspose.Slides for Node.js via Java 调整 PowerPoint 和 OpenDocument 幻灯片上的形状大小——自动化幻灯片布局调整并提升生产力。"
---
## **概述**

当您更改演示文稿的幻灯片尺寸时，可能还需要调整并重新定位其形状，以适应新的尺寸。本文展示了如何手动缩放形状以及如何处理幻灯片、母版和布局中的表格。

## **调整形状大小**

为了保持每个形状的相对位置和大小，将其水平坐标和宽度乘以新幻灯片宽度与原始宽度的比例。对垂直坐标和高度使用相应的高度比例。

第一个示例加载一个幻灯片中不包含表格的演示文稿，将幻灯片尺寸更改为 A4 并保存结果。它使用 [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) 与 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) ，以便后续循环控制缩放。比例是无单位的；形状的位置和尺寸以点为单位。不同的宽高比例会导致形状失真，并且更改形状尺寸不会缩放其字体大小。

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
表格需要单独处理：按列宽和行高进行缩放，而不是直接为表格整体设置宽度和高度。如果单元格内容需要更多空间，行高可能会保持大于请求的大小。
{{% /alert %}}

第二个示例支持表格，并在保存调整大小后的演示文稿之前处理母版和布局以及单个幻灯片上的形状。它的辅助方法通过 [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) 缩放列宽，并使用 [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) 缩放最小行高来处理每个 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)。随后在不单独缩放整体尺寸的情况下缩放表格的位置。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // 表格尺寸由列宽和行高控制。
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

    // 调整母版、布局以及单个幻灯片上定义的形状大小。
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

## **常见问题**

**为什么在调整幻灯片尺寸后形状会失真或被截断？**

如果在更改幻灯片尺寸时未对形状进行缩放，它们会保留原始位置和尺寸，可能会超出幻灯片范围。使用不同的宽高比例进行缩放也会导致形状失真。

**提供的代码能适用于所有形状类型吗？**

第一个示例直接更改形状边界，适用于没有表格的幻灯片。第二个示例单独处理表格。请检查生成的布局，尤其是文本和表格，因为这些示例不会缩放字体大小，表格内容可能限制行高。

**在调整幻灯片尺寸时如何调整表格大小？**

按宽度比例缩放列宽，按高度比例缩放最小行高，然后如第二个示例所示缩放表格的位置。

**此调整大小方法是否适用于母版幻灯片和布局幻灯片？**

是的。第二个示例遍历 [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) 并对每个母版的 [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) 进行相同的调整逻辑，以处理其形状。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**

可以。在更改幻灯片尺寸后、读取目标尺寸前调用 [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation)，以便比例因子反映最终方向。

**设置的幻灯片尺寸是否有限制？**

您可以使用 [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) 指定自定义幻灯片尺寸。支持的尺寸还取决于演示文稿的格式以及用于打开文件的应用程序。

**如何防止具有固定宽高比的形状被拉伸变形？**

对宽度和高度使用相同的比例因子。要在新幻灯片尺寸下保持原始布局，请使用宽高比例中较小的那个作为两个维度和位置的比例因子。这可保持比例，但可能在一侧留下未使用的空间。