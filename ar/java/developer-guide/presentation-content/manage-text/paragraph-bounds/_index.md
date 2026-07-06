---
title: الحصول على حدود الفقرة من العروض التقديمية في Java
linktitle: حدود الفقرة
type: docs
weight: 43
url: /ar/java/paragraph-bounds/
keywords:
- حدود الفقرة
- إحداثيات الفقرة
- حجم الفقرة
- إطار النص
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود الفقرة في Aspose.Slides للغة Java لتحسين موضع النص في عروض PowerPoint التقديمية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية الحصول على حدود الفقرات وحجمها وإحداثياتها في Aspose.Slides. توضح كيفية استرجاع مستطيل الفقرة من [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) باستخدام [IParagraph.getRect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IParagraph#getRect--)، وكيفية الحصول على إحداثيات الفقرة داخل إطار نص خلية جدول، وتبرز تفاصيل مهمة مثل وحدات القياس، وتأثير تغليف النص على الحدود، وتحويل البكسل، وقيم تنسيق الفقرة الفعّالة.

## **الحصول على إحداثيات المستطيل للفقرة**

استخدم [IParagraph.getRect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IParagraph#getRect--) للحصول على المستطيل المحدد للفقرة.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **الحصول على حجم الفقرة داخل إطار نص خلية جدول**

للحصول على الحجم والإحداثيات ل[IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) داخل إطار نص خلية جدول، استخدم [IParagraph.getRect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IParagraph#getRect--). المستطيل المرتجع يكون نسبياً لإطار نص خلية الجدول، لذا أضف موضع الجدول وإزاحة الخلية عندما تحتاج إلى إحداثيات على مستوى الشريحة.

المثال التالي يحصل على حدود الفقرة داخل خلية جدول ويرسم مستطيلات على الشريحة لتصوير هذه الحدود:

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

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**ما هي الوحدات التي تقاس بها إحداثيات الفقرة؟**

يتم قياسها بالنقاط، حيث إن البوصة الواحدة تساوي 72 نقطة. ينطبق ذلك على جميع الإحداثيات والأبعاد في الشريحة.

**هل يؤثر تغليف الكلمات على حدود الفقرة؟**

نعم. إذا تم تمكين [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) لإطار النص [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/)، فإن النص يُقسم ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن ربط إحداثيات الفقرة بشكل موثوق بالبكسل في الصورة المُصدّرة؟**

نعم. حوّل النقاط إلى بكسلات باستخدام الصيغة التالية: pixels = points × (DPI / 72). تعتمد النتيجة على قيمة DPI المختارة للتصيير أو التصدير.

**كيف يمكنني الحصول على معلمات تنسيق الفقرة "الفعّالة"، مع مراعاة توريث الأنماط؟**

استخدم [الهيكل البياني لتنسيق الفقرة الفعّال](/slides/ar/java/shape-effective-properties/); يُعيد القيم النهائية المجمعة للمسافات البادئة، والمسافات بين السطور، والتغليف، والكتابة من اليمين إلى اليسار، وغيرها.