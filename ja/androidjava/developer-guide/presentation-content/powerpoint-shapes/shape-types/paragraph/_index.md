---
title: 段落
type: docs
weight: 60
url: /androidjava/paragraph/
---


## テキストフレーム内の段落と部分の座標を取得する ##
Aspose.Slides for Android via Javaを使用することで、開発者はテキストフレームの段落コレクション内の段落の長方形座標を取得できるようになりました。また、段落の部分コレクション内の[部分の座標](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--)を取得することもできます。このトピックでは、例を使用して、段落の長方形座標と段落内の部分の位置を取得する方法を示します。

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **段落の長方形座標を取得する**
[**getRect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--)メソッドを使用することで、開発者は段落の境界長方形を取得できます。

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " 幅: " + rect.width + " 高さ: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルセルテキストフレーム内の段落と部分のサイズを取得する** ##

テーブルセルテキストフレーム内の[部分](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)または[段落](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph)のサイズと座標を取得するには、[IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getRect--)および[IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--)メソッドを使用できます。

このサンプルコードは、説明した操作を示しています：

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