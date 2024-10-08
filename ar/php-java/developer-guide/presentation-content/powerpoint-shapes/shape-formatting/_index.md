---
title: تنسيق الأشكال
type: docs
weight: 20
url: /ar/php-java/shape-formatting/
keywords: "تنسيق الشكل، تنسيق الخطوط، تنسيق أنماط الانضمام، تعبئة تدريجية، تعبئة نمطية، تعبئة صورة، تعبئة بلون صلب، تدوير الأشكال، تأثيرات حواف ثلاثية الأبعاد، تأثير الدوران ثلاثي الأبعاد، عرض باوربوينت، جافا، Aspose.Slides لـ PHP عبر جافا"
description: "تنسيق الشكل في عرض باوربوينت"
---

في باوربوينت، يمكنك إضافة الأشكال إلى الشرائح. بما أن الأشكال تتكون من خطوط، يمكنك تنسيق الأشكال من خلال تعديل أو تطبيق تأثيرات معينة على الخطوط المكونة لها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال من خلال تحديد الإعدادات التي تحدد كيفية (تعبئة المنطقة فيها). 

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides لـ PHP عبر جافا** يوفر واجهات وخصائص تسمح لك بتنسيق الأشكال بناءً على الخيارات المعروفة في باوربوينت.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد أسلوب الخط المفضل لديك لشكل ما. تحدد هذه الخطوات مثل هذه العملية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) إلى الشريحة.
4. تعيين لون لخطوط الشكل.
5. تعيين العرض لخطوط الشكل.
6. تعيين [أسلوب الخط](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) لخط الشكل.
7. تعيين [أسلوب الومض](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) لخط الشكل.
8. كتابة العرض المعدل كملف PPTX.

يوضح هذا الكود بلغة PHP عملية حيث قمنا بتنسيق مستطيل `AutoShape`:

```php
  # إنشاء مثيل لفئة العرض التي تمثل ملف عرض
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة الشكل الأوتوماتيكي من نوع مستطيل
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
    # تعيين لون التعبئة لشكل المستطيل
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # تطبيق بعض التنسيقات على خطوط المستطيل
    $shp->getLineFormat()->setStyle(LineStyle->ThickThin);
    $shp->getLineFormat()->setWidth(7);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->Dash);
    # تعيين اللون لخط المستطيل
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # كتابة ملف PPTX على القرص
    $pres->save("RectShpLn_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنسيق أنماط الانضمام**
هذه هي 3 خيارات أنواع الانضمام:

* دائري
* ميتير
* حواف

بشكل افتراضي، عندما ينضم باوربوينت إلى خطين بزاوية (أو زاوية شكل)، فإنه يستخدم إعداد **دائري**. ومع ذلك، إذا كنت ترغب في رسم شكل بزوايا حادة جدًا، قد ترغب في اختيار **ميتر**.

![join-style-powerpoint](join-style-powerpoint.png)

يوضح هذا المثال الجافا عملية حيث تم إنشاء 3 مستطيلات (الصورة أعلاه) بإعدادات نوع الانضمام ميتير، حواف، ودائري:

```php
  # إنشاء مثيل لفئة العرض التي تمثل ملف عرض
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة 3 أشكال أوتوماتيكية من مستطيل
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 150, 75);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
    $shp3 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);
    # تعيين لون التعبئة لشكل المستطيل
    $shp1->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp3->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين عرض الخط
    $shp1->getLineFormat()->setWidth(15);
    $shp2->getLineFormat()->setWidth(15);
    $shp3->getLineFormat()->setWidth(15);
    # تعيين اللون لخط المستطيل
    $shp1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # تعيين نمط الانضمام
    $shp1->getLineFormat()->setJoinStyle(LineJoinStyle->Miter);
    $shp2->getLineFormat()->setJoinStyle(LineJoinStyle->Bevel);
    $shp3->getLineFormat()->setJoinStyle(LineJoinStyle->Round);
    # إضافة نص إلى كل مستطيل
    $shp1->getTextFrame()->setText("نمط الانضمام ميتير");
    $shp2->getTextFrame()->setText("نمط الانضمام حواف");
    $shp3->getTextFrame()->setText("نمط الانضمام دائري");
    # كتابة ملف PPTX على القرص
    $pres->save("RectShpLnJoin_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعبئة تدريجية**
في باوربوينت، التعبئة التدريجية هي خيار تنسيق يسمح لك بتطبيق تدرج مستمر من الألوان على شكل ما. على سبيل المثال، يمكنك تطبيق لونين أو أكثر في إعداد حيث يتلاشى لون واحد تدريجياً ويتحول إلى لون آخر. 

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة تدريجية على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) للشكل إلى `Gradient`.
5. إضافة لونين مفضلين لديك مع المواقع المعرفة باستخدام طرق `Add` المعروضة من مجموعة `GradientStops` المرتبطة بفئة `GradientFormat`.
6. كتابة العرض المعدل كملف PPTX.

يوضح هذا الكود بلغة PHP عملية حيث تم استخدام تأثير التعبئة التدريجية على شكل بيضاوي:

```php
  # إنشاء مثيل لفئة العرض التي تمثل ملف عرض
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل بيضاوي تلقائي
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);
    # تطبيق التنسيق التدريجي على البيضاوي
    $shp->getFillFormat()->setFillType(FillType::Gradient);
    $shp->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape->Linear);
    # تعيين اتجاه التدرج
    $shp->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);
    # إضافة 2 مواقف تدريجية
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor->Purple);
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor->Red);
    # كتابة ملف PPTX على القرص
    $pres->save("EllipseShpGrad_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعبئة نمطية**
في باوربوينت، التعبئة النمطية هي خيار تنسيق يسمح لك بتطبيق تصميم ثنائي اللون يتكون من نقاط، خطوط، تقاطعات، أو علامات على شكل ما. بالإضافة إلى ذلك، يمكنك اختيار الألوان المفضلة لديك لخلفية ونمط التعبئة.

يوفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكن استخدامها لتنسيق الأشكال وتجميل العروض. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان التي يجب أن يحتوي عليها النمط.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة نمطية على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) للشكل إلى `Pattern`.
5. تعيين نمط التعبئة المفضل لديك للشكل. 
6. تعيين [اللون الخلفي](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getBackColor--) لفئة [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat).
7. تعيين [اللون الأمامي](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getForeColor--) لفئة [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat).
8. كتابة العرض المعدل كملف PPTX.

يوضح هذا الكود بلغة PHP عملية حيث تم استخدام تعبئة نمطية لتجميل مستطيل:

```php
  # إنشاء مثيل لفئة العرض التي تمثل ملف عرض
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل مستطيل أوتوماتيكي
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # تعيين نوع التعبئة إلى نمط
    $shp->getFillFormat()->setFillType(FillType::Pattern);
    # تعيين نمط التعبئة
    $shp->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->Trellis);
    # تعيين الألوان الخلفية والأمامية للنمط
    $shp->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shp->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);
    # كتابة ملف PPTX على القرص
    $pres->save("RectShpPatt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعبئة بصورة**
في باوربوينت، تعبئة الصورة هي خيار تنسيق يسمح لك بوضع صورة داخل شكل. بشكل أساسي، يمكنك استخدام صورة كخلفية لشكل ما.

إليك كيفية استخدام Aspose.Slides لتعبئة شكل بصورة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) للشكل إلى `Picture`.
5. تعيين وضع تعبئة الصورة إلى Tile.
6. إنشاء كائن `IPPImage` باستخدام الصورة التي ستستخدم لملء الشكل.
7. تعيين خاصية `Picture.Image` لكائن `PictureFillFormat` إلى `IPPImage` الذي تم إنشاؤه مؤخرًا.
8. كتابة العرض المعدل كملف PPTX.

يوضح هذا الكود بلغة PHP لك كيفية تعبئة شكل بصورة:

```php
  # إنشاء مثيل لفئة العرض التي تمثل ملف عرض
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل مستطيل أوتوماتيكي
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # تعيين نوع التعبئة إلى صورة
    $shp->getFillFormat()->setFillType(FillType::Picture);
    # تعيين وضع تعبئة الصورة
    $shp->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Tile);
    # تعيين الصورة
    $picture;
    $image = Images->fromFile("Tulips.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $shp->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # كتابة ملف PPTX على القرص
    $pres->save("RectShpPic_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعبئة بلون صلب**
في باوربوينت، تعبئة اللون الصلب هي خيار تنسيق يسمح لك بملء شكل بلون واحد. اللون المختار عادة ما يكون لونًا عاديًا. يتم تطبيق اللون على خلفية الشكل مع أي تأثيرات خاصة أو تعديلات.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة اللون الصلب على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) للشكل إلى `Solid`.
5. تعيين لونك المفضل للشكل.
6. كتابة العرض المعدل كملف PPTX.

يوضح هذا الكود بلغة PHP لك كيفية تطبيق تعبئة اللون الصلب على صندوق في باوربوينت:

```php
  # إنشاء مثيل لفئة العرض التي تمثل ملف عرض
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل مستطيل أوتوماتيكي
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # تعيين نوع التعبئة إلى صلب
    $shape->getFillFormat()->setFillType(FillType::Solid);
    # تعيين اللون للمستطيل
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # كتابة ملف PPTX على القرص
    $pres->save("RectShpSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين الشفافية**

في باوربوينت، عندما تقوم بملء الأشكال بألوان صلبة، تدرجات، صور، أو أنسجة، يمكنك تحديد مستوى الشفافية الذي يحدد مستوى عتمة التعبئة. بهذه الطريقة، على سبيل المثال، إذا قمت بتعيين مستوى شفافية منخفض، فإن الكائن الخلفي أو الخلفية (الشكل) يظهر من خلاله.

يسمح لك Aspose.Slides بتعيين مستوى الشفافية لشكل بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) إلى الشريحة.
4. استخدام `new Color` مع مكون ألفا مضبوط.
5. حفظ الكائن كملف باوربوينت.

يوضح هذا الكود بلغة PHP العملية:

```php
  # إنشاء مثيل لفئة العرض التي تمثل ملف عرض
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل صلب
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);
    # إضافة شكل شفاف فوق الشكل الصلب
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 204, 102, 0, 128));
    # كتابة ملف PPTX على القرص
    $pres->save("ShapeTransparentOverSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تدوير الأشكال**
يسمح لك Aspose.Slides بتدوير شكل تمت إضافته إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) إلى الشريحة.
4. تدوير الشكل بالدرجات المطلوبة. 
5. كتابة العرض المعدل كملف PPTX.

يوضح هذا الكود بلغة PHP لك كيفية تدوير شكل بزاوية 90 درجة:

```php
  # إنشاء مثيل لفئة العرض التي تمثل ملف عرض
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل مستطيل أوتوماتيكي
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # تدوير الشكل بزاوية 90 درجة
    $shp->setRotation(90);
    # كتابة ملف PPTX على القرص
    $pres->save("RectShpRot_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة تأثيرات الحواف ثلاثية الأبعاد**
يسمح لك Aspose.Slides بإضافة تأثيرات الحواف ثلاثية الأبعاد إلى شكل من خلال تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) إلى الشريحة.
4. تعيين المعلمات المفضلة لديك لخصائص [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) للشكل.
5. كتابة العرض على القرص.

يوضح هذا الكود بلغة PHP لك كيفية إضافة تأثيرات الحواف ثلاثية الأبعاد إلى شكل:

```php
  # إنشاء مثيل من فئة العرض
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل إلى الشريحة
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 30, 30, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $format = $shape->getLineFormat()->getFillFormat();
    $format->setFillType(FillType::Solid);
    $format->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);
    # تعيين خصائص ThreeDFormat للشكل
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    # كتابة العرض كملف PPTX
    $pres->save("Bavel_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة تأثير دوران ثلاثي الأبعاد**
يسمح لك Aspose.Slides بتطبيق تأثيرات الدوران ثلاثية الأبعاد على شكل من خلال تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) إلى الشريحة.
4. تحديد الأشكال المفضلة لديك لـ [CameraType](https://reference.aspose.com/slides/php-java/aspose.slides/ICamera#getCameraType--) و [LightType](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRig#getLightType--).
5. كتابة العرض على القرص. 

يوضح هذا الكود بلغة PHP لك كيفية تطبيق تأثيرات الدوران ثلاثية الأبعاد على شكل:

```php
  # إنشاء مثيل من فئة العرض
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Line, 30, 300, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(0, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    # كتابة العرض كملف PPTX
    $pres->save("Rotation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إعادة تعيين التنسيق**

يوضح هذا الكود بلغة PHP لك كيفية إعادة تعيين التنسيق في شريحة وإرجاع موضع وحجم وتنسيق كل شكل يحتوي على عنصر نائب على [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutSlide) إلى إعداداتها الافتراضية:

```php
  $pres = new Presentation();
  try {
    foreach($pres->getSlides() as $slide) {
      # سيتم إرجاع كل شكل على الشريحة الذي يحتوي على عنصر نائب على التخطيط
      $slide->reset();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```