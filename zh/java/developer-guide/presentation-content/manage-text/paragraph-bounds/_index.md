---
title: 在 Java 中获取演示文稿的段落边界
linktitle: 段落边界
type: docs
weight: 43
url: /zh/java/paragraph-bounds/
keywords:
- 段落边界
- 段落坐标
- 段落大小
- 文本框
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中检索段落边界，以优化 PowerPoint 演示文稿中的文本定位。"
---
## **概述**

本文说明如何获取 Aspose.Slides 中段落的边界、大小和坐标。它展示了如何通过使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IParagraph#getRect--) 从 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/) 检索段落矩形，如何获取表格单元格文本框内段落的坐标，并强调了重要细节，如度量单位、换行对边界的影响、像素转换以及有效段落格式值。

## **获取段落的矩形坐标**

使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IParagraph#getRect--) 获取段落的边界矩形。

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **获取表格单元格 TextFrame 中段落的大小**

要在表格单元格文本框中获取 [IParagraph](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/) 的大小和坐标，请使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IParagraph#getRect--)。返回的矩形相对于表格单元格文本框，因此在需要幻灯片级坐标时应添加表格位置和单元格偏移。

下面的示例获取表格单元格内段落的边界，并在幻灯片上绘制矩形以可视化这些边界：

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**段落坐标使用什么单位测量？**

它们以点为单位，1 英寸等于 72 点。这适用于幻灯片上的所有坐标和尺寸。

**换行会影响段落的边界吗？**

是的。如果为 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/) 的 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) 启用换行，文本会根据区域宽度换行，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

可以。使用公式：像素 = 点 × (DPI / 72) 将点转换为像素。结果取决于渲染或导出时选择的 DPI。

**如何获取考虑样式继承后的“有效”段落格式参数？**

使用 [effective paragraph formatting data structure](/slides/zh/java/shape-effective-properties/); 它返回缩进、间距、换行、RTL 等的最终合并值。