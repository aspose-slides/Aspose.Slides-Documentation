---
title: إدارة أجزاء النص في العروض التقديمية باستخدام PHP
linktitle: جزء النص
type: docs
weight: 70
url: /ar/php-java/portion/
keywords:
- جزء النص
- جزء من النص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إدارة أجزاء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ PHP عبر Java، مما يحسن الأداء والتخصيص."
---

## **احصل على إحداثيات جزء من النص**
تم إضافة طريقة [**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) إلى الفئة [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) و[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) التي تسمح باسترجاع إحداثيات بداية الجزء.
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
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

**هل يمكنني تطبيق رابط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين رابط تشعبي](/slides/ar/php-java/manage-hyperlinks/) لجزء منفرد؛ فقط ذلك الجزء سيكون قابلاً للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتجاوزه الـ Portion، وما الذي يُؤخذ من الـ Paragraph/​TextFrame؟**

خصائص مستوى الـ Portion لها أعلى أولوية. إذا لم يتم تعيين خاصية على الـ [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)، فإن المحرك يأخذها من الـ [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)؛ إذا لم تُحدد هناك أيضاً، فإنه يأخذها من الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) أو نمط الـ [theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/) .

**ماذا يحدث إذا الخط المحدد للـ Portion غير موجود على الجهاز/الخادم الهدف؟**

يتم تطبيق [قواعد استبدال الخطوط](/slides/ar/php-java/font-selection-sequence/). قد يتم إعادة تنسيق النص: قد تتغير القياسات، والكسرة، والعرض، وهذا مهم لتحديد المواقع بدقة.

**هل يمكنني تعيين شفافية تعبئة النص أو تدرج لوني خاص بـ Portion بشكل مستقل عن باقي الفقرة؟**

نعم، لون النص، والتعبئة، والشفافية على مستوى الـ [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) يمكن أن تختلف عن القطع المجاورة.