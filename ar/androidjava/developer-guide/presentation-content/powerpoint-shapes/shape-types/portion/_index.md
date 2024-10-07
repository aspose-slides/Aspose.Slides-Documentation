---
title: جزء
type: docs
weight: 70
url: /androidjava/portion/
---

## **احصل على إحداثيات موضع الجزء**
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) تم إضافته إلى [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPortion) و [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) الفئة التي تتيح استرجاع إحداثيات بداية الجزء.

```java
// إنشاء فئة Presentation التي تمثل ملف PPTX
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