---
title: Параграф
type: docs
weight: 60
url: /ru/androidjava/paragraph/
---


## Получение координат параграфа и порции в TextFrame ##
Используя Aspose.Slides для Android через Java, разработчики теперь могут получать прямоугольные координаты для параграфа внутри коллекции параграфов TextFrame. Это также позволяет получить [координаты порции](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) внутри коллекции порций параграфа. В этой теме мы собираемся продемонстрировать с помощью примера, как получить прямоугольные координаты для параграфа вместе с положением порции внутри параграфа.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **Получение прямоугольных координат параграфа**
Используя [**getRect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--) метод, разработчики могут получить прямоугольные границы параграфа.

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

## **Получение размера параграфа и порции внутри текстового кадра ячейки таблицы** ##

Чтобы получить размер и координаты [Порции](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) или [Параграфа](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) в текстовом кадре ячейки таблицы, вы можете использовать методы [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getRect--) и [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--).

Этот пример кода демонстрирует описанную операцию:

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