---
title: 从 JavaScript 中获取演示文稿的段落边界
linktitle: 段落边界
type: docs
weight: 43
url: /zh/nodejs-java/paragraph-bounds/
keywords:
- 段落边界
- 段落坐标
- 段落大小
- 文本框
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Node.js 中通过 Java 检索段落边界，以优化 PowerPoint 演示文稿中的文本定位。"
---
## **概述**

本文说明了如何获取 Aspose.Slides 中段落的边界、大小和坐标。它展示了如何从 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/getrect/) 检索段落矩形，如何获取表格单元格文本框内段落的坐标，并重点说明了测量单位、文本换行对边界的影响、像素转换以及有效段落格式化值等重要细节。

## **获取段落的矩形坐标**

使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/getrect/) 获取段落的边界矩形。

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **获取表格单元格 TextFrame 中段落的大小**

要获取表格单元格文本框中 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 的大小和坐标，请使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/getrect/)。返回的矩形是相对于表格单元格文本框的，因此在需要幻灯片级别坐标时，需要加上表格位置和单元格偏移量。

下面的示例获取表格单元格内段落的边界，并在幻灯片上绘制矩形以可视化这些边界：

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**段落坐标的单位是什么？**

它们使用点（point）作为单位，1 英寸等于 72 点。这适用于幻灯片上的所有坐标和尺寸。

**换行会影响段落的边界吗？**

是的。如果为 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 启用了 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframeformat/setwraptext/)，文本会换行以适应区域宽度，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

可以。使用公式将点转换为像素：像素 = 点 × (DPI / 72)。结果取决于渲染或导出时选择的 DPI。

**如何获取考虑样式继承的“有效”段落格式化参数？**

使用 [effective paragraph formatting data structure](/slides/zh/nodejs-java/shape-effective-properties/)，它返回缩进、间距、换行、RTL 等的最终合并值。