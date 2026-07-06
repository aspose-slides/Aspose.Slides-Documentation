---
title: الحصول على حدود مقاطع النص من العروض التقديمية في جافا
linktitle: حدود المقطع
type: docs
weight: 47
url: /ar/java/portion-bounds/
keywords:
- حدود مقطع النص
- مقطع النص
- جزء النص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية استخراج حدود مقاطع النص في العروض التقديمية لبرنامج PowerPoint باستخدام Aspose.Slides للغة Java."
---
## **نظرة عامة**

يمثل مقطع النص ش fragment محدد من النص داخل فقرة ويتيح لك العمل مع هذا الجزء بشكل مستقل عن المحتوى المحيط. في Aspose.Slides، يمكن استخدام المقاطع عندما تحتاج إلى استرجاع حدود جزء من النص، أو تطبيق تنسيق على جزء فقط من الفقرة، أو التحكم في سلوك النص بمستوى أكثر تفصيلاً.

توضح هذه المقالة كيفية الحصول على مستطيل الحدود لمقطع باستخدام [IPortion.getRect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPortion#getRect--). كما توضح كيفية الحصول على إحداثيات بداية مقطع باستخدام [IPortion.getCoordinates](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPortion#getCoordinates--). بالإضافة إلى ذلك، تسلط الضوء على سيناريوهات شائعة متعلقة بالمقاطع، مثل تطبيق ارتباط تشعبي على جزء نصي واحد، وفهم طريقة حل التنسيق عبر المقطع، الفقرة، إطار النص، والوراثة من السمة، ومعالجة الحالات التي يكون فيها الخط المحدد غير متوفر.

## **الحصول على حدود مقطع النص**

استخدم [IPortion.getRect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPortion#getRect--) لاسترجاع مستطيل الحدود لمقطع النص:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **الحصول على إحداثيات مقطع النص**

استخدم [IPortion.getCoordinates](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPortion#getCoordinates--) لاسترجاع إحداثيات بداية مقطع النص:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/java/manage-hyperlinks/) إلى مقطع فردي؛ سيصبح هذا الجزء فقط قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ماذا تتجاوزه المقاطع، وماذا يُستمد من الفقرة أو إطار النص؟**

خصائص المستوى المقطعي لها أعلى أولوية. إذا لم يتم تعيين خاصية على [IPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/)، فإن Aspose.Slides يأخذها من [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/). إذا لم تُحدد هناك أيضًا، يستخدم Aspose.Slides النمط من [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) أو [theme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/theme/) .

**ماذا يحدث إذا كان الخط المحدد لمقطع النص غير موجود على الجهاز أو الخادم المستهدف؟**

[Font substitution rules](/slides/ar/java/font-selection-sequence/) تُطبق. قد يتغير تدفق النص: قد تتغير المقاييس، والكسرة، والعرض، وهو ما يؤثر على الموضع الدقيق.

**هل يمكنني ضبط شفافية تعبئة النص أو تدرج لوني لمقطع محدد بشكل مستقل عن باقي الفقرة؟**

نعم، يمكن أن تختلف لون النص، والتعبئة، والشفافية على مستوى [IPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/) عن القطع المجاورة.