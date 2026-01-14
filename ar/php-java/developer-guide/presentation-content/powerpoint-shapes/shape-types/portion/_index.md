---
title: إدارة أقسام النص في العروض التقديمية باستخدام PHP
linktitle: قسم النص
type: docs
weight: 70
url: /ar/php-java/portion/
keywords:
- قسم النص
- جزء النص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إدارة أقسام النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ PHP عبر Java، مما يعزز الأداء والتخصيص."
---

## **الحصول على إحداثيات جزء من النص**
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/portion/getcoordinates/) method has been added to [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) class which allows retrieving the coordinates of the beginning of the portion.
```php
  # إنشاء كائن Presentation الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # إعادة تشكيل سياق العرض التقديمي
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/php-java/manage-hyperlinks/) إلى جزء منفرد؛ سيكون هذا الجزء فقط قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتجاوزه Portion، وما الذي يُستمد من Paragraph/TextFrame؟**

لخصائص المستوى Portion أولوية قصوى. إذا لم يتم تعيين خاصية على Portion، فإن المحرك يأخذها من Paragraph؛ وإذا لم تُعيّن هناك أيضًا، فإنه يأخذها من TextFrame أو نمط الـ theme.

**ماذا يحدث إذا كان الخط المحدد لـ Portion غير موجود على الجهاز/الخادم الهدف؟**

تنطبق [قواعد استبدال الخطوط](/slides/ar/php-java/font-selection-sequence/). قد يتغير تنسيق النص: قد تتغير المقاييس، والفواصل، والعرض، وهو ما يؤثر على الموقع الدقيق.

**هل يمكنني ضبط شفافية تعبئة النص أو تدرج لوني خاص بـ Portion بشكل مستقل عن باقي الفقرة؟**

نعم، يمكن أن يختلف لون النص، والتعبئة، والشفافية على مستوى Portion عن القطع المجاورة.