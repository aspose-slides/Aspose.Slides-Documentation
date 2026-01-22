---
title: إدارة أجزاء النص في العروض التقديمية على Android
linktitle: جزء النص
type: docs
weight: 70
url: /ar/androidjava/portion/
keywords:
- جزء النص
- جزء من النص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة أجزاء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لنظام Android عبر Java، مما يعزز الأداء والتخصيص."
---

## **الحصول على إحداثيات جزء من النص**
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) تم إضافة الطريقة إلى فصول [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) و[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) التي تسمح باسترجاع إحداثيات بداية الجزء.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
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


## **الأسئلة الشائعة**

**هل يمكنني تطبيق رابط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين رابط تشعبي](/slides/ar/androidjava/manage-hyperlinks/) لجزء منفرد؛ سيصبح هذا الجزء فقط قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتجاوز الجزء وما الذي يُستَخدم من الفقرة/إطار النص؟**

تمتلك خصائص المستوى الخاص بالجزء أولوية قصوى. إذا لم يتم تعيين خاصية على [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/)، فإن المحرك يحصل عليها من [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/); وإذا لم تُعيّن هناك أيضًا، فإنه يقتبسها من [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) أو نمط [theme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/theme/).

**ماذا يحدث إذا كان الخط المحدد لجزء غير موجود على الجهاز أو الخادم المستهدف؟**

تنطبق [قواعد استبدال الخط](/slides/ar/androidjava/font-selection-sequence/). قد يتغير تدفق النص: قد تتغير المقاييس والكسرة وعرض النص، وهو ما يؤثر على الوضع الدقيق.

**هل يمكنني ضبط شفافية تعبئة النص أو تدرج لوني خاص بالجزء مستقلًا عن باقي الفقرة؟**

نعم، يمكن أن يختلف لون النص، والتعبئة، والشفافية على مستوى [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) عن القطع المجاورة.