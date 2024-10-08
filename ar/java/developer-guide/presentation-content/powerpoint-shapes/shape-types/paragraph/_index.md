---
title: فقرة
type: docs
weight: 60
url: /ar/java/paragraph/
---


## الحصول على إحداثيات الفقرة والجزء في TextFrame ##
باستخدام Aspose.Slides لـ Java، يمكن للمطورين الآن الحصول على الإحداثيات المستطيلة للفقرة داخل مجموعة الفقرات في TextFrame. كما يتيح لك الحصول على [إحداثيات الجزء](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) داخل مجموعة الأجزاء الخاصة بفقرة. في هذا الموضوع، سنوضح بمساعدة مثال كيفية الحصول على الإحداثيات المستطيلة للفقرة بالإضافة إلى موقع الجزء داخل الفقرة.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **الحصول على الإحداثيات المستطيلة للفقرة**
باستخدام [**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) يمكن للمطورين الحصول على مستطيل حدود الفقرة.

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

## **الحصول على حجم الفقرة والجزء داخل إطار نص خلية الجدول** ##

للحصول على [الجزء](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) أو [الفقرة](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) وحجمها وإحداثياتها في إطار نص خلية الجدول، يمكنك استخدام [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--) و [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) الطريقتين.

هذا مثال على الشيفرة يوضح العملية الموصوفة:

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