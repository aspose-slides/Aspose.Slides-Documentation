---
title: جزء
type: docs
weight: 70
url: /java/portion/
---

## **احصل على إحداثيات موضع الجزء**
تمت إضافة [**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) إلى [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPortion) و[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) والتي تتيح استرجاع إحداثيات بداية الجزء.

```java
// إنشاء كائن من فئة Prseetation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // إعادة تشكيل سياق العرض التقديمي
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```