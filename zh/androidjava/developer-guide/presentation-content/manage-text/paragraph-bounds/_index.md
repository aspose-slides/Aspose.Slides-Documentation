---
title: 在 Android 上获取演示文稿中的段落边界
linktitle: 段落边界
type: docs
weight: 43
url: /zh/androidjava/paragraph-bounds/
keywords:
- 段落边界
- 段落坐标
- 段落大小
- 文本框
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何通过 Java 在 Aspose.Slides for Android 中检索段落边界，以优化 PowerPoint 演示文稿中的文本定位。"
---
## **概述**

本文说明如何获取 Aspose.Slides 中段落的边界、大小和坐标。演示如何通过使用[IParagraph.getRect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IParagraph#getRect--)从[ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/)检索段落矩形，如何获取表格单元格 TextFrame 中段落的坐标，并重点说明测量单位、换行对边界的影响、像素转换以及有效段落格式化值等重要细节。

## **获取段落的矩形坐标**

使用[IParagraph.getRect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IParagraph#getRect--)获取段落的边界矩形。

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **获取表格单元格 TextFrame 中段落的大小**

要在表格单元格 TextFrame 中获取[IParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/)的大小和坐标，请使用[IParagraph.getRect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IParagraph#getRect--)。返回的矩形相对于表格单元格 TextFrame，因此在需要幻灯片级别坐标时，需要加上表格位置和单元格偏移。

以下示例获取表格单元格内段落的边界，并在幻灯片上绘制矩形以可视化这些边界：

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

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

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

**段落坐标使用什么单位？**

它们使用点（point）作为单位，1 英寸等于 72 点。这适用于幻灯片上的所有坐标和尺寸。

**自动换行会影响段落的边界吗？**

会。如果为[ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/)启用了[TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)，文本会根据区域宽度换行，导致段落实际边界发生变化。

**段落坐标能可靠地映射到导出图像的像素吗？**

能。使用公式 pixels = points × (DPI / 72) 将点转换为像素。结果取决于渲染或导出时选择的 DPI。

**如何获取考虑样式继承后的“有效”段落格式化参数？**

使用[effective paragraph formatting data structure](/slides/zh/androidjava/shape-effective-properties/)；它返回缩进、间距、换行、RTL 等参数的最终合并值。