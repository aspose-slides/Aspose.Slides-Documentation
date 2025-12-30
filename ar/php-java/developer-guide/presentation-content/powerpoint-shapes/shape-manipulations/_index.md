---
title: إدارة أشكال العروض التقديمية في PHP
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/php-java/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على الشكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل Interop
- النص البديل للشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل وتحسين الأشكال في Aspose.Slides for PHP عبر Java وتقديم عروض PowerPoint عالية الأداء."
---

## **العثور على شكل في شريحة**
سوف تصف هذه المادة تقنية بسيطة لتسهيل عملية الباحثين عن شكل محدد في شريحة دون الحاجة لاستخدام المعرف الداخلي الخاص به. من المهم معرفة أن ملفات عرض PowerPoint لا تملك طريقة لتحديد الأشكال في الشريحة سوى المعرف الفريد الداخلي. يبدو أن العثور على شكل باستخدام المعرف الفريد الداخلي صعب للمطورين. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل. نقترح على المطورين استخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتحديد النص البديل للكائنات التي تخطط لتغييرها في المستقبل.

بعد ضبط النص البديل لأي شكل ترغب فيه، يمكنك فتح ذلك العرض باستخدام Aspose.Slides for PHP via Java والتجول عبر جميع الأشكال المضافة إلى شريحة. خلال كل تكرار، يمكنك فحص النص البديل للشكل، والشكل الذي يتطابق نصه البديل هو الشكل الذي تحتاجه. لتوضيح هذه التقنية بشكل أفضل، أنشأنا طريقة، [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) التي تقوم بالمهمة للعثور على شكل معين في شريحة وتعيد ذلك الشكل ببساطة.
```php
  # إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # النص البديل للشكل المراد العثور عليه
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **استنساخ شكل**
لاستنساخ شكل إلى شريحة باستخدام Aspose.Slides for PHP via Java:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض.
1. استنساخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. حفظ العرض المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # حفظ ملف PPTX على القرص
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إزالة شكل**
يسمح Aspose.Slides for PHP via Java للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. البحث عن الشكل الذي يحتوي على نص بديل معين.
1. إزالة الشكل.
1. حفظ الملف على القرص.
```php
  # إنشاء كائن Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من نوع المستطيل
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # حفظ العرض التقديمي على القرص 
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إخفاء شكل**
يسمح Aspose.Slides for PHP via Java للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. البحث عن الشكل الذي يحتوي على نص بديل معين.
1. إخفاء الشكل.
1. حفظ الملف على القرص.
```php
  # إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من نوع المستطيل
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # حفظ العرض التقديمي على القرص
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تغيير ترتيب الشكل**
يسمح Aspose.Slides for PHP via Java للمطورين بإعادة ترتيب الأشكال. تحديد ترتيب الشكل يحدد أي شكل يكون في المقدمة أو الخلفية. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة بعض النص إلى إطار النص الخاص بالشكل.
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
    $portion->setText("Watermark Text Watermark Text Watermark Text");
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
يسمح Aspose.Slides for PHP via Java للمطورين بالحصول على معرّف شكل فريد ضمن نطاق الشريحة بالمقارنة مع طريقة [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--) التي تسمح بالحصول على معرّف فريد ضمن نطاق العرض. تم إضافة الطريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) إلى واجهة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) وفئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) على التوالي. القيمة التي تُرجعها الطريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) تتطابق مع قيمة المعرف لكائن Microsoft.Office.Interop.PowerPoint.Shape. تم تقديم نموذج شفرة أدناه.
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


## **تحديد النص البديل لشكل**
يسمح Aspose.Slides for PHP via Java للمطورين بتحديد AlternateText لأي شكل. يمكن تمييز الأشكال في عرض ما باستخدام طريقة [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) أو طريقة [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-). يمكن قراءة أو تعيين الطريقتين [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) و [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) باستخدام Aspose.Slides وكذلك Microsoft PowerPoint. باستخدام هذه الطريقة، يمكنك وضع علامة على شكل وتنفيذ عمليات مختلفة مثل إزالة الشكل، إخفاء الشكل أو إعادة ترتيب الأشكال على شريحة. لتحديد AlternateText لشكل، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. إجراء بعض الأعمال مع الشكل المضاف حديثًا.
1. التجول عبر الأشكال للعثور على شكل.
1. تحديد AlternativeText.
1. حفظ الملف على القرص.
```php
  # إنشاء كائن Presentation الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من نوع المستطيل
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # حفظ العرض التقديمي على القرص
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الوصول إلى تنسيقات التخطيط لشكل**
توفر Aspose.Slides for PHP via Java واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط لشكل. توضح هذه المقالة كيفية الوصول إلى تنسيقات التخطيط.

نموذج الشفرة أدناه مقدم.
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


## **تحويل شكل إلى SVG**
الآن يدعم Aspose.Slides for PHP via Java تحويل شكل إلى svg. تم إضافة الطريقة [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (وبالإصدار المتعدد) إلى فئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) وواجهة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape). تسمح هذه الطريقة بحفظ محتوى الشكل كملف SVG. يوضح مقطع الشفرة أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.
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


## **محاذاة شكل**
يسمح Aspose.Slides بمحاذاة الأشكال إما بالنسبة لهوامش الشريحة أو بالنسبة لبعضها البعض. لهذا الغرض، تمت إضافة الطريقة المُحمَّلة [SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) . تحدد تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType) خيارات المحاذاة الممكنة.

**مثال 1**

الكود المصدر أدناه يقوم بمحاذاة الأشكال ذات الفهارس 1 و2 و4 على الحافة العلوية للشرائح.
```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


**مثال 2**

المثال أدناه يوضح كيفية محاذاة مجموعة الأشكال بالكامل بالنسبة إلى الشكل السفلي في المجموعة.
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


## **خصائص القلب**

في Aspose.Slides، توفر فئة [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) التحكم في عكس الأشكال أفقياً وعمودياً عبر خاصيتي `flipH` و `flipV`. كلتا الخاصيتين من نوع [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/)، وتسمح بقيم `True` للدلالة على عكس، `False` لعدم العكس، أو `NotDefined` لاستخدام السلوك الافتراضي. يمكن الوصول إلى هذه القيم من خلال [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) الشكل.

لتعديل إعدادات العكس، يتم إنشاء كائن جديد من فئة [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) باستخدام موقع الشكل الحالي وحجمه، والقيم المطلوبة لـ `flipH` و `flipV`، وزاوية الدوران. يتم إسناد هذا الكائن إلى [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) الشكل وحفظ العرض لتطبيق عمليات العكس على الملف الناتج.

لنفترض أن لدينا ملف sample.pptx يحتوي على شريحة أولى تحتوي على شكل واحد بإعدادات عكس افتراضية، كما هو موضح أدناه.

![The shape to be flipped](shape_to_be_flipped.png)

الكود التالي يسترجع خصائص العكس الحالية للشكل ويعكسه أفقيًا وعموديًا.
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // استرجاع خاصية الانعكاس الأفقي للشكل.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // استرجاع خاصية الانعكاس العمودي للشكل.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // انعكاس أفقي.
    $flipV = NullableBool::True; // انعكاس عمودي.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


النتيجة:

![The flipped shape](flipped_shape.png)

## **الأسئلة الشائعة**

**Can I combine shapes (union/intersect/subtract) on a slide like in a desktop editor?**  
ليس هناك واجهة برمجة تطبيقات مدمجة للعمليات البوليانية. يمكنك تقليد ذلك بإنشاء المخطط المطلوب بنفسك — على سبيل المثال، حساب الهندسة الناتجة عبر [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) وإنشاء شكل جديد باستخدام هذا المخطط، مع إمكانية حذف الأشكال الأصلية.

**How can I control the stacking order (z-order) so a shape always stays "on top"?**  
غيّر ترتيب الإدراج/النقل داخل مجموعة [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) الخاصة بالشفرة. للحصول على نتائج متوقعة، اجعل ترتيب z-order نهائيًا بعد إكمال جميع التعديلات الأخرى على الشريحة.

**Can I "lock" a shape to prevent users from editing it in PowerPoint?**  
نعم. قم بتعيين [علامات الحماية على مستوى الشكل](/slides/ar/php-java/applying-protection-to-presentation/) (مثل قفل التحديد، الحركة، تغيير الحجم، تحرير النص). إذا لزم الأمر، يمكنك تطبيق القيود على القالب أو التخطيط. لاحظ أن هذه الحماية على مستوى واجهة المستخدم وليست ميزة أمان؛ للحصول على حماية أقوى، اجمعها مع قيود على مستوى الملف مثل التوصيات للقراءة فقط أو كلمات المرور [/slides/php-java/password-protected-presentation/].