---
title: تلاعبات الأشكال
type: docs
weight: 40
url: /ar/php-java/shape-manipulations/
---

## **البحث عن شكل في الشريحة**
سيوضح هذا الموضوع تقنية بسيطة لتسهيل على المطورين العثور على شكل معين في شريحة دون استخدام معرفه الداخلي. من المهم معرفة أن ملفات عرض PowerPoint لا تحتوي على أي وسيلة لتحديد الأشكال في الشريحة باستثناء معرف داخلي فريد. يبدو أن من الصعب على المطورين العثور على شكل باستخدام معرفه الداخلي الفريد. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل. نقترح على المطورين استخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتعريف النص البديل للأشياء التي تخطط لتغييرها في المستقبل.

بعد ضبط النص البديل لأي شكل مرغوب، يمكنك فتح ذلك العرض باستخدام Aspose.Slides لـ PHP عبر Java والتكرار من خلال جميع الأشكال المضافة إلى شريحة. خلال كل تكرار، يمكنك التحقق من النص البديل للشكل والشكل الذي يتطابق مع النص البديل سيكون هو الشكل المطلوب لديك. لإظهار هذه التقنية بشكل أفضل، أنشأنا طريقة، [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) التي تقوم بالعملية للعثور على شكل معين في شريحة ثم تعيد ببساطة ذلك الشكل.

```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف العرض
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # النص البديل للشكل المراد العثور عليه
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("اسم الشكل: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **استنساخ الشكل**
لاستنساخ شكل إلى شريحة باستخدام Aspose.Slides لـ PHP عبر Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع من شريحة باستخدام فهرسها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض.
1. استنساخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. حفظ العرض المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.

```php
  # إنشاء كائن Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # كتابة ملف PPTX إلى القرص
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إزالة الشكل**
Aspose.Slides لـ PHP عبر Java يسمح للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إيجاد الشكل مع نص بديل محدد.
1. إزالة الشكل.
1. حفظ الملف على القرص.

```php
  # إنشاء كائن Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من نوع مستطيل
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "مستخدم معرف";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount); $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # حفظ العرض إلى القرص
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إخفاء الشكل**
Aspose.Slides لـ PHP عبر Java يسمح للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إيجاد الشكل مع نص بديل محدد.
1. إخفاء الشكل.
1. حفظ الملف على القرص.

```php
  # إنشاء كائن Presentation يمثل PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من نوع مستطيل
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "مستخدم معرف";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount); $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # حفظ العرض إلى القرص
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغيير ترتيب الأشكال**
Aspose.Slides لـ PHP عبر Java يسمح للمطورين بإعادة ترتيب الأشكال. إعادة ترتيب الشكل تحدد أي شكل في المقدمة وأي شكل في الخلف. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة بعض النص في إطار نص الشكل.
1. إضافة شكل آخر بنفس الإحداثيات.
1. إعادة ترتيب الأشكال.
1. حفظ الملف على القرص.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("نص علامة مائية نص علامة مائية نص علامة مائية");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الحصول على معرف الشكل Interop**
Aspose.Slides لـ PHP عبر Java يسمح للمطورين بالحصول على معرف شكل فريد في نطاق الشريحة بالمقارنة مع الطريقة [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--)، التي تسمح بالحصول على معرف فريد في نطاق العرض. تم إضافة الطريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) إلى واجهات [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) وفئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) وفقًا لها. القيمة التي تعيدها الطريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) تتوافق مع قيمة المعرف لكائن Microsoft.Office.Interop.PowerPoint.Shape. أدناه نموذج رمز موضح.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # الحصول على معرف الشكل الفريد في نطاق الشريحة
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين نص بديل للشكل**
Aspose.Slides لـ PHP عبر Java يسمح للمطورين بتعيين النص البديل لأي شكل. يمكن تمييز الأشكال في العرض بواسطة الطريقة [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) أو [اسم الشكل](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-). يمكن قراءة أو تعيين الطريقتين [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) و [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) باستخدام Aspose.Slides وكذلك Microsoft PowerPoint. باستخدام هذه الطريقة، يمكنك وضع علامة على شكل وأداء عمليات مختلفة مثل إزالة شكل، إخفاء شكل أو إعادة ترتيب الأشكال في شريحة. لتعيين النص البديل للشكل، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. القيام ببعض الأعمال مع الشكل الذي تم إضافته حديثًا.
1. التنقل عبر الأشكال للعثور على شكل.
1. تعيين النص البديل.
1. حفظ الملف على القرص.

```php
  # إنشاء كائن Presentation يمثل PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من نوع مستطيل
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()); $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("مستخدم معرف");
      }
    }
    # حفظ العرض إلى القرص
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الوصول إلى تنسيقات التخطيط للشكل**
Aspose.Slides لـ PHP عبر Java يوفر واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط لشكل. توضح هذه المقالة كيفية الوصول إلى تنسيقات التخطيط.

أدناه نموذج رمز موضح.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **رسم الشكل كـ SVG**
الآن يدعم Aspose.Slides لـ PHP عبر Java رسم شكل كـ svg. تم إضافة الطريقة [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (وازدياد عددها) إلى فئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) وواجهة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape). تسمح هذه الطريقة بحفظ محتوى الشكل كملف SVG. الكود الأدناه يوضح كيفية تصدير شكل الشريحة إلى ملف SVG.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **محاذاة الأشكال**
Aspose.Slides يسمح بمحاذاة الأشكال سواء بالنسبة لهوامش الشريحة أو بالنسبة لبعضها البعض. لهذا الغرض، تمت إضافة الطريقة المعاد تحميلها [SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) . تعرف التعداد [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType) خيارات المحاذاة الممكنة.

**مثال 1**

الكود المصدر أدناه يقوم بمحاذاة الأشكال ذات الفهارس 1، 2 و 4 على طول الحدود العليا للشرائح.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3)));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**مثال 2**

المثال أدناه يوضح كيفية محاذاة مجموعة كاملة من الأشكال نسبياً إلى الشكل السفلي في المجموعة.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```