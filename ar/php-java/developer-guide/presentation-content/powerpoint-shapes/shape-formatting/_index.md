---
title: تنسيق أشكال PowerPoint في PHP
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/php-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- رسم خط الشكل التخطيطي
- تنسيق نمط الوصل
- تعبئة تدرجية
- تعبئة بنمط
- تعبئة صورة
- تعبئة قوام
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بتدرج رمادي
- تدوير الشكل
- تأثير إزاحة ثلاثية الأبعاد
- تأثير تدوير ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في PHP باستخدام Aspose.Slides—ضبط التعبئة والحد والأنماط التأثيرية لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال تتكون من خطوط، يمكنك تنسيقها بتعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد الإعدادات التي تتحكم في كيفية ملء داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides لـ PHP عبر Java فئات وأساليب تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتوفرة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر مؤشرها.
1. إضافة [شكل تلقائي](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [نمط الخط](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) للشكل.
1. ضبط عرض الخط.
1. ضبط [نمط المتقطع](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) للخط.
1. ضبط لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

```php
// إنشاء كائن من فئة Presentation التي تمثّل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // ضبط لون التعبئة لشكل المستطيل.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // تطبيق تنسيق على خطوط المستطيل.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // ضبط لون خط المستطيل.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // حفظ ملف PPTX على القرص.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الخطوط المنسقة في العرض](formatted-lines.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يضيف تأثير الرسم التخطيطي مظهرًا يدويًا لخط الشكل. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) للوصول إلى إعدادات الخط، و[LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) لتحديد قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

يعرض الكود PHP التالي كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) ، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // الوصول إلى تنسيق الخط للشكل وتنسيق الرسم التخطيطي الخاص به.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // تطبيق تأثير رسم تخطيطي.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // قراءة تأثير الرسم التخطيطي المعين مباشرةً للشكل.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // إزالة تأثير الرسم التخطيطي.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

القيمة التي تُرجعها [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان بإمكان تنسيق الخط أن يُورَّث من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/)، والوصول إلى طريقة `getSketchFormat` للكائن المرتجع، وقراءة قيمة `getSketchType`. القيمة الفعّالة تعكس التنسيق الذي يُطبق فعليًا بعد حل الوراثة:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **تنسيق أنماط الوصل**

إليك خيارات الأنواع الثلاثة للوصل:

* **مستدير**
* **ميتر**
* **منحدر**

 بشكل افتراضي، عندما يجمع PowerPoint خطين بزاوية (مثلًا عند زاوية الشكل)، يستخدم إعداد **مستدير**. ومع ذلك، إذا كنت تُرسم شكلًا بزاوٍ حادة، قد تفضّل خيار **ميتر**.

![نمط الوصل في العرض](join-style-powerpoint.png)

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة ثلاثة أشكال تلقائية من النوع Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // ضبط لون التعبئة لكل شكل مستطيل.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // ضبط عرض الخط.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // ضبط لون خط كل مستطيل.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // ضبط نمط الوصل.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // إضافة نص إلى كل مستطيل.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // حفظ ملف PPTX على القرص.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعبئة تدرجية**

في PowerPoint، تعبئة تدرجية هي خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة تدرجية على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر مؤشرها.
1. إضافة [شكل تلقائي](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة لونين مفضلين مع تحديد المواقع باستخدام طرق `add` لمجموعة نقاط التدرج التي تُظهرها فئة [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/).
1. حفظ العرض المعدل كملف PPTX.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق تدرج على القطع الناقص.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // ضبط اتجاه التدرج.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // إضافة نقطتي توقف للتدرج.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // حفظ ملف PPTX على القرص.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![البيضاوية مع تعبئة تدرجية](gradient-fill.png)

إذا ظهر التدرج بصورة مختلفة في الصورة المُصدَّرة مقارنةً بما هو في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة التدرج المخزنة في العرض.

## **تعبئة بنمط**

في PowerPoint، تعبئة بنمط هي خيار تنسيق يتيح لك تطبيق تصميم ثنائي اللون—مثل النقاط أو الخطوط أو التعرجات المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة للجزء الأمامي والخلفي للنمط.

توفر Aspose.Slides أكثر من 45 نمطًا مُعرفًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز الجاذبية البصرية لعروضك. حتى بعد اختيار نمط مُعرف مسبقًا، يمكن لك تحديد الألوان الدقيقة التي يستخدمها.

إليك كيفية تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر مؤشرها.
1. إضافة [شكل تلقائي](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط النمط من الخيارات المُعرفّة مسبقًا.
1. ضبط [لون الخلفية](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) للنمط.
1. ضبط [لون المقدمة](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) للنمط.
1. حفظ العرض المعدل كملف PPTX.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ضبط نوع التعبئة إلى Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // ضبط نمط النقشة.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // ضبط ألوان الخلفية والواجهة للنمط.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // حفظ ملف PPTX على القرص.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة صورة هي خيار تنسيق يسمح لك بإدراج صورة داخل شكل—مما يستخدم الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر مؤشرها.
1. إضافة [شكل تلقائي](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) للشكل إلى `Picture`.
1. ضبط وضع تعبئة الصورة إلى `Tile` (أو أي وضع مفضل آخر).
1. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `SlidesPicture.setImage`.
1. حفظ العرض المعدل كملف PPTX.

![صورة اللوتس](lotus.png)

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // ضبط نوع التعبئة إلى Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // ضبط وضع تعبئة الصورة.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // تحميل صورة وإضافتها إلى موارد العرض.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // ضبط الصورة.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // حفظ ملف PPTX على القرص.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **استخدام الصورة المتكررة كملمس**

إذا رغبت في ضبط صورة متكررة كملمس وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): يحدد وضع تعبئة الصورة إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة البلاط داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كان البلاط يُقلب أفقيًا أو عموديًا أو كلاهما.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): يحدد الإزاحة الأفقية للبلاط (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): يحدد الإزاحة العمودية للبلاط (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): يعرّف مقياس البلاط الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): يعرّف مقياس البلاط العمودي كنسبة مئوية.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // ضبط نوع التعبئة للشكل إلى Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // تحميل الصورة وإضافتها إلى موارد العرض.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // تعيين الصورة إلى الشكل.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // تكوين وضع تعبئة الصورة وخصائص التكرار.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // حفظ ملف PPTX على القرص.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![خيارات التجزيء](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يملأ الشكل بلون واحد موحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر مؤشرها.
1. إضافة [شكل تلقائي](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين لون التعبئة المفضَّل للشكل.
1. حفظ العرض المعدل كملف PPTX.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ضبط نوع التعبئة إلى Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // ضبط لون التعبئة.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // حفظ ملف PPTX على القرص.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **ضبط الشفافية**

في PowerPoint، عند تطبيق لون صلب أو تدرج أو صورة أو تعبئة بقوام على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في وضوح التعبئة. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح للخلفية أو الكائنات التي تحته بأن تكون مرئية جزئيًا.

تتيح لك Aspose.Slides ضبط مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك كيفية القيام بذلك:

1. إنشاء نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر مؤشرها.
1. إضافة [شكل تلقائي](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) إلى `Solid`.
1. استخدام `Color` لتعريف لون مع شفافية (مكوّن `alpha` يتحكم في الشفافية).
1. حفظ العرض.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي مستطيل صلب.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // إضافة شكل تلقائي مستطيل شفاف فوق الشكل الصلب.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // حفظ ملف PPTX على القرص.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية مع احتياجات محاذاة أو تصميم محددة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر مؤشرها.
1. إضافة [شكل تلقائي](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط خاصية دوران الشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بزاوية 5 درجات.
    $shape->setRotation(5);

    // حفظ ملف PPTX على القرص.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات إزاحة ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات إزاحة ثلاثية الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

لإضافة تأثيرات إزاحة ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر مؤشرها.
1. إضافة [شكل تلقائي](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) لتعريف إعدادات الإزاحة.
1. حفظ العرض.

```php
// إنشاء نسخة من فئة Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل إلى الشريحة.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // ضبط خصائص ThreeDFormat للشكل.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // حفظ العرض التقديمي كملف PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تأثير الإزاحة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات تدوير ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات تدوير ثلاثية الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

لتطبيق تدوير ثلاثي الأبعاد على شكل:

1. إنشاء نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر مؤشرها.
1. إضافة [شكل تلقائي](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. استخدام [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) و[setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) لتحديد التدوير ثلاثي الأبعاد.
1. حفظ العرض.

```php
// إنشاء نسخة من فئة Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // حفظ العرض التقديمي كملف PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تأثير التدوير ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

طريقة [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) تحدد كيفية عرض شكل فردي عندما يُعرض العرض أو يُعالج في وضع الأبيض والأسود. لا تُفعِّل العرض بالأبيض والأسود بحد ذاتها، ولا تُغيِّر تعبئة الشكل أو خطه أو تنسيقه في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `Automatic` يسمح لتطبيق العرض باختيار التحويل، `Gray` و`LightGray` يستخدمان اللون الرمادي، `BlackWhite` يستخدم فقط الأسود والأبيض، `Black` و`White` يفرضان لونًا واحدًا، `Color` يحافظ على اللون الطبيعي، و`Hidden` يحذف الشكل في وضع الأبيض والأسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // احتفظ بتعبئة اللون البرتقالي في وضع اللون، لكن اعرض الشكل بتلوين رمادي في وضع الأسود والأبيض.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إعادة تعيين التنسيق**

يعرض الكود Java التالي كيفية إعادة تعيين تنسيق شريحة وإعادة موضع وحجم وتن格式 جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // إعادة تعيين كل شكل على الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

التأثير طفيف فقط. الصور والوسائط المدمجة هي التي تشغل معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال على شريحة تشترك في تنسيق متماثل لأتمكن من تجميعها؟**

قارن خصائص التنسيق الأساسية لكل شكل—التعبئة، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وجمع هذه الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ أشكالًا نموذجية بالأنماط المطلوبة في شريحة نموذج أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وأعد تطبيق تنسيقها حيثما دعت الحاجة.