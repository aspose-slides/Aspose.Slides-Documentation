---
title: إدارة أجزاء النص في العروض التقديمية باستخدام Java
linktitle: جزء النص
type: docs
weight: 70
url: /ar/java/portion/
keywords:
- جزء النص
- قسم النص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة أجزاء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة Java، مع تحسين الأداء والتخصيص."
---

## **احصل على إحداثيات جزء من النص**
تمت إضافة طريقة [**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) إلى الفئة [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPortion) و[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) التي تسمح باسترجاع إحداثيات بداية الجزء.
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


## **الأسئلة الشائعة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/java/manage-hyperlinks/) إلى جزء فردي؛ سيفتح فقط هذا الجزء، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ماذا يتجاوز الجزء (Portion) وماذا يُؤخذ من الفقرة (Paragraph)/إطار النص (TextFrame)؟**

لدي خصائص المستوى الخاص بالجزء (Portion) أعلى أولوية. إذا لم يتم تعيين الخاصية على [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)، فإن المحرك يأخذها من [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/)؛ إذا لم تُحدد هناك أيضاً، من [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) أو من نمط [theme](https://reference.aspose.com/slides/java/com.aspose.slides/theme/) .

**ماذا يحدث إذا كان الخط المحدد للجزء غير موجود على الجهاز/الخادم الهدف؟**

تُطبق [قواعد استبدال الخطوط](/slides/ar/java/font-selection-sequence/). قد يتغير تدفق النص: المقاييس، والقطع، والعرض قد يتغير، وهذا مهم لتحديد المواقع بدقة.

**هل يمكنني ضبط شفافية تعبئة النص أو تدرج اللون للجزء بشكل مستقل عن بقية الفقرة؟**

نعم، يمكن أن تختلف لون النص، والتعبئة، والشفافية على مستوى [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) عن الأجزاء المجاورة.