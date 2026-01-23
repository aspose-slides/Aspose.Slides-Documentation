---
title: أشكال مجموعة العرض التقديمي في PHP
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
description: "تعلم كيفية تجميع وإلغاء تجميع الأشكال في عروض PowerPoint باستخدام Aspose.Slides for PHP via Java — دليل سريع خطوة بخطوة مع كود مجاني."
---

## **إضافة شكل مجموعة**
يدعم Aspose.Slides العمل مع أشكال المجموعات على الشرائح. تساعد هذه الميزة المطورين على إنشاء عروض تقديمية أغنى. يدعم Aspose.Slides for PHP via Java إضافة أو الوصول إلى أشكال المجموعات. يمكن إضافة أشكال إلى شكل مجموعة مضاف لتعبئته أو الوصول إلى أي خاصية من خصائص شكل المجموعة. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides for PHP via Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها
1. إضافة شكل مجموعة إلى الشريحة.
1. إضافة الأشكال إلى شكل المجموعة المضاف.
1. حفظ العرض التقديمي المعدل كملف PPTX.

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
    # إضافة إطار مجموعة الشكل
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # حفظ ملف PPTX إلى القرص
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الوصول إلى خاصية AltText**
يوضح هذا الموضوع خطوات بسيطة، مصحوبة بأمثلة شفرة، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعات على الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides for PHP via Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تمثل ملف PPTX.
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
1. الوصول إلى مجموعة الأشكال في الشرائح.
1. الوصول إلى شكل المجموعة.
1. الوصول إلى خاصية [Alternative Text](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getAlternativeText).

المثال أدناه يصل إلى النص البديل لشكل المجموعة.
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
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


## **الأسئلة المتكررة**

**هل يتم دعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) على طريقة [getParentGroup](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getparentgroup/) التي تشير مباشرةً إلى دعم الهرمية (يمكن أن تكون المجموعة طفلًا لمجموعة أخرى).

**كيف يمكنني التحكم في ترتيب Z للمجموعة بالنسبة للكائنات الأخرى على الشريحة؟**

استخدم طريقة [getZOrderPosition](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) الخاصة بـ [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) للتحقق من موقعها في مكدس العرض.

**هل يمكنني منع التحريك/التعديل/إلغاء التجميع؟**

نعم. يتم كشف قسم القفل للمجموعة عبر [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getgroupshapelock/)، مما يتيح لك تقييد العمليات على الكائن.