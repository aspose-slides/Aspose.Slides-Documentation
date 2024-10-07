---
title: مجموعة
type: docs
weight: 40
url: /php-java/group/
---

## **إضافة شكل مجموعة**
يدعم Aspose.Slides العمل مع أشكال المجموعات على الشرائح. تساعد هذه الميزة المطورين في دعم العروض التقديمية الأكثر غنى. يدعم Aspose.Slides لـ PHP عبر Java إضافة أشكال أو الوصول إلى أشكال المجموعة. من الممكن إضافة أشكال إلى شكل مجموعة تم إضافته لتعبئته أو الوصول إلى أي خاصية من خصائص شكل المجموعة. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides لـ PHP عبر Java:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. احصل على مرجع الشريحة باستخدام فهرسها.
1. أضف شكل مجموعة إلى الشريحة.
1. أضف الأشكال إلى شكل المجموعة المضاف.
1. احفظ العرض التقديمي المعدل كملف PPTX.

يقوم المثال أدناه بإضافة شكل مجموعة إلى شريحة.

```php
  # إنشاء مثيل لفئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # الوصول إلى مجموعة الأشكال في الشرائح
    $slideShapes = $sld->getShapes();
    # إضافة شكل مجموعة إلى الشريحة
    $groupShape = $slideShapes->addGroupShape();
    # إضافة أشكال داخل شكل المجموعة المضاف
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # إضافة إطار شكل المجموعة
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # كتابة ملف PPTX إلى القرص
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الوصول إلى خاصية AltText**
تُظهر هذه الموضوع خطوات بسيطة، كاملة مع أمثلة الشيفرة، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعة على الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides لـ PHP عبر Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تمثل ملف PPTX.
1. الحصول على مرجع للشريحة باستخدام فهرسها.
1. الوصول إلى مجموعة الأشكال في الشرائح.
1. الوصول إلى شكل المجموعة.
1. الوصول إلى خاصية [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) .

المثال أدناه يقوم بالوصول إلى النص البديل لشكل المجموعة.

```php
  # إنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # الوصول إلى مجموعة الأشكال في الشرائح
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # الوصول إلى شكل المجموعة.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # الوصول إلى خاصية AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```