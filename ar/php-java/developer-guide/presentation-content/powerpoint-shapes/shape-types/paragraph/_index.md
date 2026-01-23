---
title: الحصول على حدود الفقرة من العروض التقديمية في PHP
linktitle: الفقرة
type: docs
weight: 60
url: /ar/php-java/paragraph/
keywords:
- حدود الفقرة
- حدود جزء النص
- إحداثيات الفقرة
- إحداثيات الجزء
- حجم الفقرة
- حجم جزء النص
- إطار النص
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود الفقرة وجزء النص في Aspose.Slides للـ PHP عبر Java لتحسين موضع النص في عروض PowerPoint."
---

## **الحصول على إحداثيات الفقرة والجزء داخل إطار النص**
باستخدام Aspose.Slides لـ PHP عبر Java، يمكن للمطورين الآن الحصول على الإحداثيات المستطيلة للفقرة داخل مجموعة الفقرات لإطار النص. كما يتيح لك الحصول على [إحداثيات الجزء](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getCoordinates) داخل مجموعة الأجزاء لفقرة. في هذا الموضوع، سنوضح بمساعدة مثال كيفية الحصول على الإحداثيات المستطيلة للفقرة بالإضافة إلى موضع الجزء داخل الفقرة.
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```



## **الحصول على الإحداثيات المستطيلة للفقرة**
باستخدام طريقة [**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) يمكن للمطورين الحصول على مستطيل حدود الفقرة.
```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على حجم الفقرة والجزء داخل إطار نص خلية جدول**

للحصول على حجم [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) أو [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) وإحداثياتهما داخل إطار نص خلية جدول، يمكنك استخدام الطريقتين [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) و[Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect).

يقوم هذا الكود النموذجي بعرض العملية الموصوفة:
```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**بأي وحدات يتم إرجاع الإحداثيات للفقرة وأجزاء النص؟**

بالنقاط، حيث إن 1 بوصة = 72 نقطة. ينطبق هذا على جميع الإحداثيات والأبعاد في الشريحة.

**هل يؤثر [التفاف](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/) على حدود الفقرة؟**

نعم. إذا تم تمكين [wrapping](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/) في الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)، يتم كسر النص ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن تحويل إحداثيات الفقرة إلى بكسلات في الصورة المصدرة بثقة؟**

نعم. يمكن تحويل النقاط إلى بكسلات باستخدام الصيغة: pixels = points × (DPI / 72). تعتمد النتيجة على قيمة DPI المختارة للتصيير/التصدير.

**كيف أحصل على معلمات تنسيق الفقرة "الفعّالة" مع مراعاة وراثة النمط؟**

استخدم [effective paragraph formatting data structure](/slides/ar/php-java/shape-effective-properties/); تُعيد القيم النهائية الموحدة للإزاحات، والمسافات، والالتفاف، والاتجاه من اليمين إلى اليسار، وغيرها.