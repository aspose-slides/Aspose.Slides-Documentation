---
title: 幻灯片上调整形状大小
type: docs
weight: 110
url: /zh/java/re-sizing-shapes-on-slide/
keywords:
- 调整形状大小
- 更改形状尺寸
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 轻松调整 PowerPoint 和 OpenDocument 幻灯片上的形状大小——自动化幻灯片布局调整，提高生产力。"
---

## **概述**

Aspose.Slides for Java 客户最常提出的问题之一是如何调整形状大小，以便在更改幻灯片尺寸时，数据不会被截断。本文简短的技术文章展示了如何实现此操作。

## **调整形状**

为防止幻灯片尺寸变化时形状错位，请更新每个形状的位置和尺寸，使其符合新的幻灯片布局。
```java
// 加载演示文稿文件。
Presentation presentation = new Presentation("sample.ppt");
try {
    // 获取原始幻灯片尺寸。
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 在不缩放现有形状的情况下更改幻灯片尺寸。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 获取新的幻灯片尺寸。
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // 调整每张幻灯片上形状的大小和位置。
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // 缩放形状尺寸。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 缩放形状位置。
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

如果幻灯片包含表格，上述代码将无法正常工作。在这种情况下，必须调整表格中每个单元格的大小。

{{% /alert %}} 

在您的代码中使用以下示例来调整包含表格的幻灯片。对于表格，设置宽度或高度是一种特殊情况：必须调整各行的高度和列的宽度，以更改表格的整体大小。
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // 获取原始幻灯片尺寸。
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 在不缩放现有形状的情况下更改幻灯片尺寸。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // 获取新的幻灯片尺寸。
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // 缩放形状尺寸。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 缩放形状位置。
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // 缩放形状尺寸。
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // 缩放形状位置。
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // 缩放形状尺寸。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 缩放形状位置。
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


## **常见问题**

**在调整幻灯片大小后，为什么形状会失真或被截断？**

在调整幻灯片大小时，形状会保留原始位置和尺寸，除非显式更改比例。这可能导致内容被裁剪或形状错位。

**提供的代码适用于所有形状类型吗？**

基本示例适用于大多数形状类型（文本框、图像、图表等）。但是，对于表格，需要单独处理行和列，因为表格的高度和宽度取决于各个单元格的尺寸。

**在调整幻灯片大小时，如何调整表格？**

需要遍历表格的所有行和列，并按比例调整它们的高度和宽度，如第二个代码示例所示。

**此调整能用于母版幻灯片和布局幻灯片吗？**

可以，但您还应该遍历[母版](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)和[布局幻灯片](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--)，并对它们的形状应用相同的缩放逻辑，以确保整个演示文稿的一致性。

**我可以在调整大小的同时更改幻灯片方向（纵向/横向）吗？**

可以。您可以使用[presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#setOrientation-int-)来更改方向。确保相应地设置缩放逻辑以保持布局。

**我可以设置的幻灯片尺寸是否有限制？**

Aspose.Slides 支持自定义尺寸，但非常大的尺寸可能会影响性能或与某些版本的 PowerPoint 的兼容性。

**如何防止固定宽高比的形状失真？**

在缩放之前，可以检查形状的`getAspectRatioLocked`方法。如果已锁定，则应按比例调整宽度或高度，而不是单独缩放它们。