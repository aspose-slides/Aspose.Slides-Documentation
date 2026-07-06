---
title: الحصول على حدود جزء النص من العروض التقديمية على Android
linktitle: حدود الجزء
type: docs
weight: 47
url: /ar/androidjava/portion-bounds/
keywords:
- حدود جزء النص
- جزء النص
- قطعة نص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية استرداد حدود جزء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **نظرة عامة**

يمثل جزء النص شظية محددة من النص داخل فقرة ويسمح لك بالعمل مع تلك الشظية بشكل مستقل عن المحتوى المحيط. في Aspose.Slides، يمكن استخدام الأجزاء عندما تحتاج إلى استرداد حدود شظية النص، أو تطبيق تنسيق على جزء فقط من الفقرة، أو التحكم في سلوك النص بمستوى أكثر تفصيلاً.

توضح هذه المقالة كيفية الحصول على المربع المحيط بجزء النص باستخدام [IPortion.getRect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPortion#getRect--). كما توضح كيفية الحصول على إحداثيات بداية جزء النص باستخدام [IPortion.getCoordinates](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPortion#getCoordinates--). بالإضافة إلى ذلك، تسلط الضوء على سيناريوهات شائعة متعلقة بالأجزاء، مثل تطبيق ارتباط تشعبي على شظية نص واحدة، وفهم كيفية حل التنسيق عبر الجزء والفقرة وإطار النص والوراثة من السمة، ومعالجة الحالات التي يكون فيها الخط المحدد غير متاح.

## **الحصول على حدود جزء النص**

استخدم [IPortion.getRect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPortion#getRect--) لاسترجاع المربع المحيط بجزء النص:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **الحصول على إحداثيات جزء النص**

استخدم [IPortion.getCoordinates](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPortion#getCoordinates--) لاسترجاع إحداثيات بداية جزء النص:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/androidjava/manage-hyperlinks/) إلى جزء فردي؛ سيصبح هذا الشظية فقط قابلة للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة النمط: ما الذي يتجاوز الجزء، وما الذي يُأخذ من الفقرة أو إطار النص؟**

لخصائص المستوى الجزء أولوية أعلى. إذا لم يتم تعيين خاصية على [IPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/)، فإن Aspose.Slides يأخذها من [IParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/). إذا لم تُحدد هناك أيضاً، يستخدم Aspose.Slides نمط [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) أو [theme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/theme/) .

**ماذا يحدث إذا كان الخط المحدد لجزء النص مفقوداً على الجهاز الهدف أو الخادم؟**

[قواعد استبدال الخط](/slides/ar/androidjava/font-selection-sequence/) تُطبق. قد يتدفق النص مجدداً: قد تتغير المقاييس، والكسرة، والعرض، وهو ما يؤثر على الدقة في التموضع.

**هل يمكنني ضبط شفافية تعبئة النص أو تدرج لون خاص بالجزء بشكل مستقل عن باقي الفقرة؟**

نعم، يمكن أن يختلف لون النص، والتعبئة، والشفافية على مستوى [IPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/) عن الشظايا المجاورة.