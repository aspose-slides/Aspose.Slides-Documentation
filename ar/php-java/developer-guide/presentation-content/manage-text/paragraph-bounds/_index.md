---
title: الحصول على حدود الفقرة من العروض التقديمية في PHP
linktitle: حدود الفقرة
type: docs
weight: 43
url: /ar/php-java/paragraph-bounds/
keywords:
- حدود الفقرة
- إحداثيات الفقرة
- حجم الفقرة
- إطار النص
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود الفقرة في Aspose.Slides للغة PHP عبر Java لتحسين تموضع النص في عروض PowerPoint التقديمية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية الحصول على حدود وحجم وإحداثيات الفقرات في Aspose.Slides. توضح كيفية استرجاع مستطيل الفقرة من [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) باستخدام [Paragraph::getRect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/getrect/)، وكيفية الحصول على إحداثيات الفقرة داخل إطار نص خلية جدول، وتبرز تفاصيل مهمة مثل وحدات القياس، تأثير تغليف النص على الحدود، تحويل البكسل، وقيم تنسيق الفقرة الفعّالة.

## **الحصول على إحداثيات مستطيلة للفقرة**

استخدم [Paragraph::getRect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/getrect/) للحصول على المستطيل المحيط بالفقرة.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **الحصول على حجم الفقرة داخل TextFrame خلية جدول**

للحصول على حجم وإحداثيات [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) في إطار نص خلية جدول، استخدم [Paragraph::getRect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/getrect/). المستطيل المرتجع يكون نسبياً لإطار نص خلية الجدول، لذا أضف موضع الجدول وإزاحة الخلية عندما تحتاج إلى إحداثيات على مستوى الشريحة.

المثال التالي يحصل على حدود الفقرة داخل خلية جدول ويرسم مستطيلات على الشريحة لتصوير تلك الحدود:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة الشائعة**

**ما هي الوحدات التي تُقاس بها إحداثيات الفقرة؟**

يتم قياسها بالنقاط، حيث إن البوصة الواحدة تساوي 72 نقطة. ينطبق هذا على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر تغليف النص على حدود الفقرة؟**

نعم. إذا تم تمكين [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/setwraptext/) لإطار النص [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/)، فإن النص ينقسم ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن ربط إحداثيات الفقرة بشكل موثوق بالبكسل في الصورة المُصدَّرة؟**

نعم. حوّل النقاط إلى بكسلات باستخدام الصيغة التالية: pixels = points × (DPI / 72). تعتمد النتيجة على DPI المختار للتصوير أو التصدير.

**كيف أحصل على معلمات تنسيق الفقرة "الفعّالة" مع مراعاة وراثة الأنماط؟**

استخدم [effective paragraph formatting data structure](/slides/ar/php-java/shape-effective-properties/); تُعيد القيم النهائية الموحدة للمسافات البادئة، التباعد، التغليف، الاتجاه من اليمين إلى اليسار، والمزيد.