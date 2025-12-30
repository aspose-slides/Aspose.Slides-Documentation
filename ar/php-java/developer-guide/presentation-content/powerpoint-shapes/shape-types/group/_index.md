---
title: أشكال مجموعة العروض التقديمية في PHP
linktitle: مجموعة الشكل
type: docs
weight: 40
url: /ar/php-java/group/
keywords:
- شكل مجموعة
- مجموعة الشكل
- إضافة مجموعة
- نص بديل
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية تجميع وفك تجميع الأشكال في عروض PowerPoint باستخدام Aspose.Slides for PHP عبر Java - دليل سريع خطوة بخطوة مع شفرة مجانية."
---

## **إضافة شكل مجموعة**
Aspose.Slides يدعم العمل مع أشكال المجموعات على الشرائح. هذه الميزة تساعد المطورين على إنشاء عروض تقديمية أكثر غنى. Aspose.Slides for PHP via Java يدعم إضافة أو الوصول إلى أشكال المجموعات. من الممكن إضافة أشكال إلى شكل مجموعة مضاف لملئه أو للوصول إلى أي خاصية من خصائص شكل المجموعة. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides for PHP via Java:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع شريحة باستخدام فهرستها
1. إضافة شكل مجموعة إلى الشريحة.
1. إضافة الأشكال إلى شكل المجموعة المضاف.
1. حفظ العرض المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # الوصول إلى مجموعة الأشكال في الشرائح
    $slideShapes = $sld->getShapes();
    # إضافة شكل مجموعة إلى الشريحة
    $groupShape = $slideShapes->addGroupShape();
    # إضافة أشكال داخل مجموعة الشكل المضافة
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # إضافة إطار لشكل المجموعة
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
هذه المقالة تعرض خطوات بسيطة، مع أمثلة شفرة، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعات على الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides for PHP via Java:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تمثل ملف PPTX.
1. الحصول على مرجع شريحة باستخدام فهرستها.
1. الوصول إلى مجموعة الأشكال في الشرائح.
1. الوصول إلى شكل المجموعة.
1. الوصول إلى خاصية [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) .

المثال أدناه يصل إلى النص البديل لشكل المجموعة.
```php
  # إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
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


## **الأسئلة الشائعة**

**هل يتم دعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. لدى [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) طريقة [getParentGroup](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getparentgroup/) التي تشير مباشرةً إلى دعم التسلسل الهرمي (يمكن أن تكون المجموعة طفلاً لمجموعة أخرى).

**كيف يمكنني التحكم بترتيب Z للمجموعة بالنسبة للكائنات الأخرى على الشريحة؟**

استخدم طريقة [getZOrderPosition](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) الخاصة بـ [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) لتفحص موضعها في مكدس العرض.

**هل يمكنني منع التحريك/التحرير/فك التجميع؟**

نعم. يتم كشف قسم القفل للمجموعة عبر [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getgroupshapelock/)، مما يتيح لك تقييد العمليات على الكائن.