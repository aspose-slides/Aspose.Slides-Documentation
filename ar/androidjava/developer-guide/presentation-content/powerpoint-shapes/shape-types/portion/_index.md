---
title: إدارة أجزاء النص في العروض التقديمية على Android
linktitle: جزء النص
type: docs
weight: 70
url: /ar/androidjava/portion/
keywords:
- جزء النص
- جزء النص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة أجزاء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لنظام Android عبر Java، مما يحسن الأداء والتخصيص."
---

## **الحصول على إحداثيات جزء من النص**
تمت إضافة طريقة [**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) إلى الفئة [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPortion) و[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) التي تسمح باسترجاع إحداثيات بداية الجزء.
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


## **الأسئلة المتكررة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/androidjava/manage-hyperlinks/) لجزء فردي؛ سيصبح هذا الجزء فقط قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي تتجاوزُه الـ Portion، وما الذي يُؤخذ من Paragraph/TextFrame؟**

لدى خصائص المستوى Portion أولوية أعلى. إذا لم يتم تعيين خاصية على [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/)، فإن المحرك يأخذها من [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/); إذا لم تُحدد هناك أيضًا، فإنه يأخذها من [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) أو نمط [theme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/theme/).

**ماذا يحدث إذا كان الخط المحدد لـ Portion غير موجود على الجهاز/الخادم الهدف؟**

تنطبق [قواعد استبدال الخطوط](/slides/ar/androidjava/font-selection-sequence/). قد يتغير تدفق النص: يمكن أن تتغير المقاييس والكسرة والعرض، مما يؤثر على التحديد الدقيق.

**هل يمكنني تعيين شفافية تعبئة النص أو تدرج لجزء Portion بشكل مستقل عن باقي الفقرة؟**

نعم، يمكن أن تختلف لون النص، والتعبئة، والشفافية على مستوى [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) عن القطع المجاورة.