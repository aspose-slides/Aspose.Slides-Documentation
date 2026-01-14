---
title: إدارة أشكال العرض التقديمي في PHP
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/php-java/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- نسخ شكل
- إزالة شكل
- إخفاء شكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل في Interop
- نص بديل للشكل
- تنسيقات تخطيط الشكل
- شكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إنشاء وتحرير وتحسين الأشكال في Aspose.Slides لـ PHP عبر Java وتقديم عروض PowerPoint عالية الأداء."
---

## **العثور على شكل في شريحة**
ستصف هذه الفقرة تقنية بسيطة لتسهيل عملية العثور على شكل محدد في شريحة دون الحاجة لاستخدام الـ Id الداخلي الخاص به. من المهم معرفة أن ملفات PowerPoint Presentation لا تملك طريقة لتحديد الأشكال في الشريحة سوى الـ Id الداخلي الفريد. يبدو أن العثور على شكل باستخدام الـ Id الفريد الداخلي صعب على المطورين. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل (Alt Text). نقترح على المطورين استخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتحديد النص البديل للكائنات التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مطلوب، يمكنك فتح تلك الع presentation باستخدام Aspose.Slides for PHP via Java والتجول عبر جميع الأشكال المضافة إلى الشريحة. خلال كل جولة، يمكنك فحص النص البديل للشكل، وسيكون الشكل الذي يطابق النص البديل هو الشكل المطلوب. لتوضيح هذه التقنية بشكل أفضل، أنشأنا الطريقة [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) التي تقوم بالعثور على شكل محدد في شريحة وتعيد هذا الشكل ببساطة.
```php
  # إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # النص البديل للشكل المطلوب العثور عليه
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


## **نسخ شكل**
لنسخ شكل إلى شريحة باستخدام Aspose.Slides for PHP via Java:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض.
1. نسخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
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
    # حفظ ملف PPTX إلى القرص
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إزالة شكل**
يسمح Aspose.Slides for PHP via Java للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بالنص البديل المحدد.
1. إزالة الشكل.
1. حفظ الملف إلى القرص.
```php
  # إنشاء كائن Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من نوع مستطيل
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
    # حفظ العرض التقديمي إلى القرص
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إخفاء شكل**
يسمح Aspose.Slides for PHP via Java للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بالنص البديل المحدد.
1. إخفاء الشكل.
1. حفظ الملف إلى القرص.
```php
  # إنشاء كائن Presentation الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من نوع مستطيل
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
    # حفظ العرض التقديمي إلى القرص
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تغيير ترتيب الشكل**
يسمح Aspose.Slides for PHP via Java للمطورين بإعادة ترتيب الأشكال. يحدد إعادة ترتيب الشكل أي شكل يكون في المقدمة أو الخلفية. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة نص إلى إطار نص الشكل.
1. إضافة شكل آخر بنفس الإحداثيات.
1. إعادة ترتيب الأشكال.
1. حفظ الملف إلى القرص.
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


## **الحصول على معرّف الشكل في Interop**
يسمح Aspose.Slides for PHP via Java للمطورين بالحصول على معرّف فريد للشكل ضمن نطاق الشريحة بالمقارنة مع طريقة [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getuniqueid/) التي تسمح بالحصول على معرّف فريد ضمن نطاق العرض. تم إضافة الطريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) إلى فئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/). القيمة التي تُرجعها طريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) تتطابق مع قيمة الـ Id لكائن Microsoft.Office.Interop.PowerPoint.Shape. يُعطى المثال التالي ككود عينة.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # الحصول على معرّف الشكل الفريد في نطاق الشريحة
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين نص بديل لشكل**
يسمح Aspose.Slides for PHP via Java للمطورين بتعيين AlternateText لأي شكل. يمكن التمييز بين الأشكال في عرض تقديمي باستخدام `Alternative Text` أو طريقة [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/). يمكن قراءة أو تعيين النص البديل باستخدام الطرق [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) و [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) عبر Aspose.Slides وكذلك Microsoft PowerPoint. باستخدام هذه الطريقة، يمكنك وضع علامة على شكل وإجراء عمليات مختلفة مثل إزالة الشكل، إخفاء الشكل أو إعادة ترتيب الأشكال على الشريحة. لتعيين AlternateText لشكل، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. إجراء بعض العمليات على الشكل المضاف حديثًا.
1. التجول بين الأشكال للعثور على الشكل.
1. تعيين AlternativeText.
1. حفظ الملف إلى القرص.
```php
  # إنشاء كائن Presentation الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من نوع مستطيل
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
    # حفظ العرض التقديمي إلى القرص
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الوصول إلى صيغ التخطيط لشكل**
يوفر Aspose.Slides for PHP via Java واجهة برمجة تطبيقات بسيطة للوصول إلى صيغ التخطيط لشكل. توضح هذه المقالة كيفية الوصول إلى صيغ التخطيط.

يُعطى كود عينة أدناه.
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


## **تصيير شكل كـ SVG**
الآن يدعم Aspose.Slides for PHP via Java تصيير شكل كملف svg. تمت إضافة الطريقة [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) (مع تجاوزها) إلى فئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/). تسمح هذه الطريقة بحفظ محتوى الشكل كملف SVG. يوضح المقتطف البرمجي أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.
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
يسمح Aspose.Slides بمحاذاة الأشكال إما بالنسبة لهوامش الشريحة أو بالنسبة لبعضها البعض. لهذا الغرض، تمت إضافة الطريقة المُحمّلة [SlidesUtil::alignShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/alignshapes/). تحدد تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/shapesalignmenttype/) خيارات المحاذاة الممكنة.

**مثال 1**

الكود المصدر أدناه يَمحّو الأشكال ذات الفهارس 1 و2 و4 على الحد العلوي للشريحة.
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

المثال أدناه يوضح كيفية محاذاة مجموعة الأشكال بالكامل بالنسبة إلى الشكل الأدنى في المجموعة.
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

في Aspose.Slides، توفر الفئة [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) التحكم في عكس الأشكال أفقيًا وعموديًا عبر الخصائص `flipH` و `flipV`. كلا الخصيصين من نوع [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/)، وتسمح القيم `True` بالقيام بعكس، و `False` بدون عكس، أو `NotDefined` لاستخدام السلوك الافتراضي. يمكن الوصول إلى هذه القيم من خلال [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) الخاص بالشكل.

لتعديل إعدادات العكس، يتم إنشاء كائن جديد من [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) باستخدام الموقع والحجم الحاليين للشكل، والقيم المطلوبة لـ `flipH` و `flipV`، وزاوية الدوران. تعيين هذا الكائن إلى [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) الخاص بالشكل وحفظ العرض يطبق التحولات العكسية ويثبتها في ملف الإخراج.

لنفترض أن لدينا ملف sample.pptx يحتوي على شريحة أولى بها شكل واحد بإعدادات عكس افتراضية، كما هو موضح أدناه.

![The shape to be flipped](shape_to_be_flipped.png)

الكود التالي يسترجع خصائص العكس الحالية للشكل ويقلبه أفقيًا وعموديًا.
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // استرجاع خاصية القلب الأفقي للشكل.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // استرجاع خاصية القلب العمودي للشكل.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // قلب أفقيًا.
    $flipV = NullableBool::True; // قلب أفقيًا.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


النتيجة:

![The flipped shape](flipped_shape.png)

## **الأسئلة المتكررة**

**هل يمكنني دمج الأشكال (الاتحاد/التقاطع/الطرح) على شريحة كما هو في محرر سطح المكتب؟**

لا توجد واجهة برمجة تطبيقات للعمليات البوليانية مدمجة. يمكنك تقليد ذلك بإنشاء المخطط المطلوب يدويًا—مثلاً حساب الهندسة الناتجة عبر [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) وإنشاء شكل جديد بهذه الحدود، مع إمكانية إزالة الأشكال الأصلية.

**كيف يمكنني التحكم في ترتيب الطبقات (z-order) بحيث يبقى الشكل دائمًا "في الأعلى"؟**

غيّر ترتيب الإدراج/النقل داخل مجموعة [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) في الشريحة. للحصول على نتائج متوقعة، قم بتحديد ترتيب z بعد إتمام جميع التعديلات الأخرى على الشريحة.

**هل يمكنني "قفل" شكل لمنع المستخدمين من تحريره في PowerPoint؟**

نعم. عيّن [flags حماية على مستوى الشكل](/slides/ar/php-java/applying-protection-to-presentation/) (مثل قفل الاختيار، النقل، تغيير الحجم، تحرير النص). إذا لزم الأمر، طبّق القيود على القالب أو التخطيط. لاحظ أن هذه الحماية على مستوى واجهة المستخدم وليست ميزة أمنية؛ للحصول على حماية أقوى، يمكن دمجها مع قيود على مستوى الملف مثل [توصيات للقراءة فقط أو كلمات مرور](/slides/ar/php-java/password-protected-presentation/).