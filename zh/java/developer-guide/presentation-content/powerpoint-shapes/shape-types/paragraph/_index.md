---
title: 在 Java 中获取演示文稿的段落边界
linktitle: 段落
type: docs
weight: 60
url: /zh/java/paragraph/
keywords:
- 段落边界
- 文本部分边界
- 段落坐标
- 部分坐标
- 段落大小
- 文本部分大小
- 文本框
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中检索段落和文本部分的边界，以优化 PowerPoint 演示文稿中的文本定位。"
---

## **获取 TextFrame 中段落和部分的坐标**
使用 Aspose.Slides for Java，开发人员现在可以获取 TextFrame 中段落集合内段落的矩形坐标。它还允许您获取段落的部分集合中的[部分的坐标](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--)。在本主题中，我们将通过示例演示如何获取段落的矩形坐标以及段落内部部分的位置。
``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **获取段落的矩形坐标**
使用[**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--)方法，开发人员可以获取段落的边界矩形。
```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取表格单元格 TextFrame 中段落和部分的大小**
为了获取表格单元格 TextFrame 中[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)或[Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph)的大小和坐标，您可以使用[IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--)和[IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--)方法。

此示例代码演示了上述操作：
```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**
**段落和文本部分的坐标以什么单位返回？**  
以点（point）为单位，1 英寸 = 72 点。该单位适用于幻灯片上的所有坐标和尺寸。

**文字换行会影响段落的边界吗？**  
是的。如果在[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/)中启用了[wrapping](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setWrapText-byte-)，文本会换行以适应区域宽度，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**  
是的。使用以下公式将点转换为像素：pixels = points × (DPI / 72)。结果取决于渲染/导出时选择的 DPI。

**如何获取考虑样式继承的“有效”段落格式化参数？**  
使用[effective paragraph formatting data structure](/slides/zh/java/shape-effective-properties/)；它返回缩进、间距、换行、从右到左（RTL）等参数的最终合并值。