---
title: Absatz
type: docs
weight: 60
url: /java/paragraph/
---


## Absatz- und Portion-Koordinaten im TextFrame abrufen ##
Mit Aspose.Slides für Java können Entwickler jetzt die rechteckigen Koordinaten für Absätze in der Absatzsammlung von TextFrame abrufen. Es ermöglicht auch, die [Koordinaten von Portionen](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) in der Portionssammlung eines Absatzes abzurufen. In diesem Thema werden wir anhand eines Beispiels demonstrieren, wie man die rechteckigen Koordinaten für einen Absatz zusammen mit der Position der Portion innerhalb eines Absatzes erhält.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **Rechteckige Koordinaten des Absatzes abrufen**
Mit der Methode [**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) können Entwickler die Grenzen des Absatzrechtecks abrufen.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Breite: " + rect.width + " Höhe: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Größe des Absatzes und der Portion innerhalb des Textrahmens einer Tabellenzelle abrufen** ##

Um die [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) oder die [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) Größe und Koordinaten in einem Textrahmen einer Tabellenzelle abzurufen, können Sie die Methoden [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--) und [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) verwenden.

Dieser Beispielcode demonstriert die beschriebene Operation:

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