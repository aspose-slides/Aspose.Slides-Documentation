---
title: 段落
type: docs
weight: 60
url: /ja/java/paragraph/
---


## テキストフレーム内の段落および部分の座標を取得 ##
Aspose.Slides for Javaを使用すると、開発者はテキストフレームの段落コレクション内の段落の矩形座標を取得できます。また、段落の部分コレクション内の[部分の座標](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--)を取得することも可能です。このトピックでは、段落の矩形座標と段落内の部分の位置を取得する方法を例を用いて示します。

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **段落の矩形座標を取得**
[**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--)メソッドを使用すると、開発者は段落の境界矩形を取得できます。

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

## **テーブルセルのテキストフレーム内の段落および部分のサイズを取得 ** ##

テーブルセルのテキストフレーム内の[部分](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)または[段落](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph)のサイズと座標を取得するには、[IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--)および[IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--)メソッドを使用できます。

このサンプルコードは、説明された操作を示します：

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