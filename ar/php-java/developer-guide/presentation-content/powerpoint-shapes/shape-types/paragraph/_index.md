---
title: فقرة
type: docs
weight: 60
url: /php-java/paragraph/
---


## الحصول على إحداثيات الفقرات والأجزاء في إطار النص ##
باستخدام Aspose.Slides لـ PHP عبر Java، يمكن للمطورين الآن الحصول على الإحداثيات المستطيلة لفقرات داخل مجموعة الفقرات في إطار النص. كما يسمح لك بالحصول على [إحداثيات الجزء](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) داخل مجموعة الأجزاء لفقرة. في هذا الموضوع، سنوضح بمساعدة مثال كيفية الحصول على الإحداثيات المستطيلة للفقرة مع موضع الجزء داخل الفقرة.

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
باستخدام [**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--) يمكن للمطورين الحصول على مستطيل حدود الفقرة.

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

## **الحصول على حجم الفقرة والجزء داخل إطار نص خلية الجدول** ##

للحصول على [الجزء](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) أو [الفقرة](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) وحجمها وإحداثياتها داخل إطار نص خلية الجدول، يمكنك استخدام [IPortion.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getRect--) و [IParagraph.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--) الطرق.

هذا الكود مثال يوضح العملية الموصوفة:

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