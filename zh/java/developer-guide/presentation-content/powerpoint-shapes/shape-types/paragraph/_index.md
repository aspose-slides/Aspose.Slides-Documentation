---
title: 段落
type: docs
weight: 60
url: /zh/java/paragraph/
---


## 获取文本框中段落和部分的坐标 ##
使用 Aspose.Slides for Java，开发人员现在可以获取文本框中段落集合内的段落的矩形坐标。它还允许您获取段落中部分的 [坐标](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--)。在本主题中，我们将通过示例演示如何获取段落的矩形坐标及段落内部分的位置。

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
使用 [**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) 方法，开发人员可以获取段落边界矩形。

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " 宽度: " + rect.width + " 高度: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取表格单元格文本框中段落和部分的大小** ##

要获取表格单元格文本框中 [部分](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) 或 [段落](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) 的大小和坐标，可以使用 [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--) 和 [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) 方法。

以下示例代码演示了所述操作：

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