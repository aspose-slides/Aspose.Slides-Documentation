---
title: الحصول على حدود الفقرة من العروض التقديمية على Android
linktitle: حدود الفقرة
type: docs
weight: 43
url: /ar/androidjava/paragraph-bounds/
keywords:
- حدود الفقرة
- إحداثيات الفقرة
- حجم الفقرة
- إطار النص
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية استرداد حدود الفقرة في Aspose.Slides لنظام Android عبر Java لتحسين موضع النص في عروض PowerPoint التقديمية."
---
## **نظرة عامة**

توضح هذه المقالة كيفية الحصول على حدود الفقرة وحجمها وإحداثياتها في Aspose.Slides. تُظهر كيفية استرداد مستطيل الفقرة من [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) باستخدام [IParagraph.getRect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IParagraph#getRect--)، كيفية الحصول على إحداثيات الفقرة داخل إطار نص خلية جدول، وتبرز تفاصيل هامة مثل وحدات القياس، تأثير التفاف النص على الحدود، تحويل البكسل، وقيم تنسيق الفقرة الفعّالة.

## **الحصول على إحداثيات مستطيلة للفقرة**

استخدم [IParagraph.getRect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IParagraph#getRect--) للحصول على المستطيل المحيط بالفقرة.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **الحصول على حجم الفقرة داخل إطار نص خلية جدول**

للحصول على الحجم والإحداثيات لـ [IParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/) في إطار نص خلية جدول، استخدم [IParagraph.getRect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IParagraph#getRect--). المستطيل المرتجع يكون نسبياً إلى إطار نص خلية الجدول، لذا أضف موقع الجدول وإزاحة الخلية عندما تحتاج إلى إحداثيات على مستوى الشريحة.

المثال التالي يحصل على حدود الفقرة داخل خلية جدول ويرسم مستطيلات على الشريحة لتصوير تلك الحدود:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**بأي وحدات تُقاس إحداثيات الفقرة؟**

يتم قياسها بالنقاط، حيث إنّ البوصة الواحدة تساوي 72 نقطة. ينطبق ذلك على جميع الإحداثيات والأبعاد في الشريحة.

**هل يؤثر التفاف الكلمات على حدود الفقرة؟**

نعم. إذا تم تمكين [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) لإطار النص [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/)، فإن النص يُكسر ليناسب عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن ربط إحداثيات الفقرة بشكل موثوق بالبكسلات في الصورة المصدرة؟**

نعم. قم بتحويل النقاط إلى بكسلات باستخدام الصيغة التالية: البكسلات = النقاط × (DPI / 72). تعتمد النتيجة على DPI المختار للتصيير أو التصدير.

**كيف يمكنني الحصول على معلمات تنسيق الفقرة "الفعّالة"، مع مراعاة توريث الأنماط؟**

استخدم [effective paragraph formatting data structure](/slides/ar/androidjava/shape-effective-properties/); تُعيد القيم النهائية المجمعة للمسافات البادئة، والمسافات، واللف، والاتجاه من اليمين إلى اليسار، والمزيد.