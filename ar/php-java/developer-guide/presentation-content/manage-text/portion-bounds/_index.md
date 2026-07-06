---
title: الحصول على حدود جزء النص من العروض التقديمية في PHP
linktitle: حدود الجزء
type: docs
weight: 47
url: /ar/php-java/portion-bounds/
keywords:
- حدود جزء النص
- جزء النص
- جزء من النص
- إحداثيات النص
- موضع النص
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود جزء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

يمثل جزء النص شظية محددة من النص داخل الفقرة ويسمح لك بالعمل مع تلك الشظية بشكل مستقل عن المحتوى المحيط. في Aspose.Slides، يمكن استخدام الأجزاء عندما تحتاج إلى استرداد حدود شظية النص، أو تطبيق تنسيق على جزء فقط من الفقرة، أو التحكم في سلوك النص على مستوى أكثر تفصيلاً. توضح هذه المقالة كيفية الحصول على المستطيل المحدد للجزء باستخدام [Portion::getRect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/getrect/). كما توضح كيفية الحصول على إحداثيات بداية الجزء باستخدام [Portion::getCoordinates](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/getcoordinates/). بالإضافة إلى ذلك، تسلط الضوء على سيناريوهات شائعة تتعلق بالأجزاء، مثل تطبيق ارتباط تشعبي على شظية نص واحدة، وفهم كيفية حل التنسيق عبر الجزء والفقرة وإطار النص ووراثة السمة، ومعالجة الحالات التي يكون فيها الخط المحدد غير متوفر.

## **الحصول على حدود جزء النص**

استخدم [Portion::getRect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/getrect/) لاسترجاع المستطيل المحدد لجزء النص:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **الحصول على إحداثيات جزء النص**

استخدم [Portion::getCoordinates](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/getcoordinates/) لاسترجاع إحداثيات بداية جزء النص:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/php-java/manage-hyperlinks/) لجزء فردي؛ سيتم جعل تلك الشظية فقط قابلة للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتجاوزّه الجزء، وما الذي يُستَمدّ من الفقرة أو إطار النص؟**

تتمتع خصائص المستوى الجزئي بالأولوية الأعلى. إذا لم تُحدد خاصية على الـ[Portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/)، فإن Aspose.Slides يأخذها من الـ[Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/). إذا لم تُحدد هناك أيضاً، يستخدم Aspose.Slides نمط الـ[TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) أو الـ[theme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/theme/) .

**ماذا يحدث إذا كان الخط المحدد لجزء ما غير موجود على الجهاز أو الخادم المستهدف؟**

تنطبق [قواعد استبدال الخطوط](/slides/ar/php-java/font-selection-sequence/). قد يتدفق النص مجدداً: يمكن أن تتغير المقاييس والكسرة والعرض، وهو ما يؤثر على الدقة في تحديد المواقع.

**هل يمكنني تعيين شفافية تعبئة النص أو تدرج لوني خاص بالجزء بشكل مستقل عن باقي الفقرة؟**

نعم، يمكن أن يختلف لون النص والتعبئة والشفافية على مستوى الـ[Portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/) عن الشظايا المجاورة.