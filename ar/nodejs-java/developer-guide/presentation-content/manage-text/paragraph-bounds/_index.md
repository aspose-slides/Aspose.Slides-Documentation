---
title: الحصول على حدود الفقرة من العروض التقديمية في JavaScript
linktitle: حدود الفقرة
type: docs
weight: 43
url: /ar/nodejs-java/paragraph-bounds/
keywords:
- حدود الفقرة
- إحداثيات الفقرة
- حجم الفقرة
- إطار النص
- PowerPoint
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية استرداد حدود الفقرة في Aspose.Slides لـ Node.js عبر Java لتحسين تموضع النص في عروض PowerPoint التقديمية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية الحصول على حدود وحجم وإحداثيات الفقرات في Aspose.Slides. تُظهر كيفية استخراج مستطيل فقرة من [إطار النص](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) باستخدام [Paragraph.getRect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/getrect/)، وكيفية الحصول على إحداثيات الفقرة داخل إطار نص خلية جدول، وتبرز تفاصيل هامة مثل وحدات القياس، تأثير تغليف النص على الحدود، تحويل البكسل، وقيم تنسيق الفقرة الفعّالة.

## **الحصول على إحداثيات مستطيلة للفقرة**

استخدم [Paragraph.getRect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/getrect/) للحصول على المستطيل المحيط بالفقرة.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **الحصول على حجم الفقرة داخل إطار نص خلية جدول**

للحصول على حجم وإحداثيات [الفقرة](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) في إطار نص خلية جدول، استخدم [Paragraph.getRect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/getrect/). المستطيل المُرجع يكون نسبياً لإطار نص خلية الجدول، لذا أضف موضع الجدول وإزاحة الخلية عندما تحتاج إلى إحداثيات على مستوى الشريحة.

المثال التالي يحصل على حدود الفقرة داخل خلية جدول ويرسم مستطيلات على الشريحة لتصوير تلك الحدود:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**بأي وحدات يتم قياس إحداثيات الفقرة؟**

يتم قياسها بالنقاط، حيث إن البوصة الواحدة تعادل 72 نقطة. ينطبق هذا على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر تغليف النص على حدود الفقرة؟**

نعم. إذا تم تمكين [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/setwraptext/) لـ [إطار النص](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/)، فإن النص ينكسر ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن ربط إحداثيات الفقرة بصورة موثوقة بالبكسل في الصورة المُصدّرة؟**

نعم. حوّل النقاط إلى بكسلات باستخدام الصيغة التالية: البكسل = النقاط × (DPI / 72). تعتمد النتيجة على DPI المختار للتصوير أو التصدير.

**كيف أحصل على معلمات تنسيق الفقرة "الفعّالة"، مع مراعاة وراثة الأنماط؟**

استخدم [هيكل بيانات تنسيق الفقرة الفعّال](/slides/ar/nodejs-java/shape-effective-properties/); فإنه يعيد القيم المجمعة النهائية للمسافات البادئة، والمسافات، والتغليف، والكتابة من اليمين إلى اليسار، وأكثر.