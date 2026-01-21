---
title: إدارة أجزاء النص في العروض التقديمية باستخدام Java
linktitle: جزء النص
type: docs
weight: 70
url: /ar/java/portion/
keywords:
- جزء النص
- جزء النص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرف على كيفية إدارة أجزاء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java، مما يعزز الأداء والتخصيص."
---

## **احصل على إحداثيات جزء من النص**
تمت إضافة طريقة [**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) إلى فصلي [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) و [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) والتي تسمح باسترجاع إحداثيات بداية الجزء.
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

**هل يمكنني تطبيق رابط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**
نعم، يمكنك [تعيين رابط تشعبي](/slides/ar/java/manage-hyperlinks/) إلى جزء فردي؛ سيصبح ذلك الجزء فقط قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ماذا يتجاوز الجزء (Portion) وماذا يُؤخذ من الفقرة (Paragraph) / إطار النص (TextFrame)؟**
للممتلكات على مستوى الجزء أولوية قصوى. إذا لم يتم تعيين خاصية على [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)، فالمحرك يأخذها من [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/); إذا لم تُحدد هناك أيضًا، فإنه يأخذها من [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) أو نمط [theme](https://reference.aspose.com/slides/java/com.aspose.slides/theme/) .

**ماذا يحدث إذا كان الخط المحدد لجزء (Portion) غير موجود على الجهاز/الخادم الهدف؟**
تطبق [قواعد استبدال الخطوط](/slides/ar/java/font-selection-sequence/). قد يتغير تدفق النص: قد تتغير المقاييس، والشرط، والعرض، وهو ما يؤثر على التمركز الدقيق.

**هل يمكنني ضبط شفافية تعبئة النص أو تدرج اللون لجزء (Portion) بشكل مستقل عن بقية الفقرة؟**
نعم، يمكن أن تختلف لون النص، التعبئة، والشفافية على مستوى [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) عن الأجزاء المجاورة.