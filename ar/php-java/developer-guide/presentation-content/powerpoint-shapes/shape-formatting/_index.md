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
- خط الشكل الرسم التخطيطي
- تنسيق نمط الانضمام
- تعبئة تدرج لوني
- تعبئة بنمط
- تعبئة صورة
- تعبئة قوام
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بتدرج رمادي
- تدوير الشكل
- تأثير الحافة ثلاثية الأبعاد
- تأثير الدوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في PHP باستخدام Aspose.Slides—حدد أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكوّن من خطوط، يمكنك تنسيقها عبر تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد الإعدادات التي تتحكم في كيفية ملء داخلها.

![format-shape-powerpoint](format-shape-powerpoint.png)

توفر Aspose.Slides للـ PHP عبر Java فئات وأساليب تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتوفرة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. توضح الخطوات التالية الإجراء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/ar/php-java/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/ar/php-java/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

الكود PHP التالي يوضح كيفية تنسيق مستطيل `AutoShape`:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // تطبيق تنسيق على خطوط المستطيل.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // تعيين اللون لخط المستطيل.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

تجعل تأثير الرسم التخطيطي خط الشكل يبدو مرسومًا يدويًا. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) للوصول إلى إعدادات الخط، و[LineFormat.getSketchFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/lineformat/) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat.setSketchType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sketchformat/) لتحديد قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/linesketchtype/).

الكود PHP التالي يوضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/ar/php-java/aspose.slides/linesketchtype/) ، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/ar/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // الوصول إلى تنسيق خط الشكل وتنسيق الرسم التخطيطي الخاص به.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // تطبيق تأثير رسم تخطيطي.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // قراءة تأثير الرسم التخطيطي المخصص مباشرةً للشكل.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // إزالة تأثير الرسم التخطيطي.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

القيمة التي تُرجعها الدالة [SketchFormat.getSketchType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sketchformat/) تمثل الإعداد المعين مباشرةً للشكل. إذا كان يمكن أن يتم وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/lineformat/)، وصول إلى طريقة `getSketchFormat` للكائن المُرجع، وقراءة قيمتها `getSketchType`. تمثل القيمة الفعلية التنسيق المطبق فعليًا بعد حل الوراثة:

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

## **تنسيق أنماط الانضمام**

فيما يلي خيارات ثلاثة لأنواع الانضمام:

* Round
* Miter
* Bevel

بشكل افتراضي، عندما يقوم PowerPoint بضم خطين بزاوية (مثل زاوية شكل)، يستخدم إعداد **Round**. ومع ذلك، إذا كنت ترسم شكلاً بزوايا حادة، قد تفضّل خيار **Miter**.

![نمط الانضمام في العرض التقديمي](join-style-powerpoint.png)

الكود PHP التالي يوضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الانضمام Miter وBevel وRound:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة ثلاثة أشكال تلقائية من نوع المستطيل.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // تعيين لون التعبئة لكل شكل مستطيل.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // تعيين عرض الخط.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // تعيين اللون لخط كل مستطيل.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // تعيين نمط الانضمام.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // إضافة نص إلى كل مستطيل.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعبئة تدرج لوني**

في PowerPoint، تعبئة التدرج اللوني هي خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يختفي أحدهما تدريجيًا في الآخر.

إليك كيفية تطبيق تعبئة تدرج لوني على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة لونين مفضلين لديك مع تحديد المواقع باستخدام طرق `add` لمجموعة نقاط التدرج التي تُظهرها الفئة [GradientFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/gradientformat/).
1. حفظ العرض التقديمي المعدل كملف PPTX.

الكود PHP التالي يوضح كيفية تطبيق تأثير تعبئة تدرج لوني على بيضاوي:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع القطع الناقص.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق التدرج اللوني على القطع الناقص.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // تعيين اتجاه التدرج.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // إضافة نقطتي تدرج.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![القطع الناقص بتعبئة تدرج لوني](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تعبئة النمط هي خيار تنسيق يتيح لك تطبيق تصميم من لونين—مثل النقاط أو الخطوط أو الشرائط أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة لمقدمة النمط وخلفيته.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتحسين المظهر البصري لعروضك. حتى بعد اختيار نمط مسبق، لا يزال بإمكانك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك كيفية تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط النمط من الخيارات المسبقة.
1. تعيين [Background Color](https://reference.aspose.com/slides/ar/php-java/aspose.slides/patternformat/#getBackColor) للنمط.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/ar/php-java/aspose.slides/patternformat/#getForeColor) للنمط.
1. حفظ العرض التقديمي المعدل كملف PPTX.

الكود PHP التالي يوضح كيفية تطبيق تعبئة بنمط على مستطيل:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى نمط.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // تعيين نمط النمط.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // تعيين ألوان خلفية ونص النمط.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![المستطيل بتعبئة نمط](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة الصورة هي خيار تنسيق يسمح لك بإدراج صورة داخل شكل—وبالتالي استخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضع تعبئة الصورة إلى `Tile` (أو وضع مفضّل آخر).
1. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `SlidesPicture.setImage`.
1. حفظ العرض التقديمي المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

الكود PHP التالي يوضح كيفية تعبئة شكل بالصورة:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // تعيين نوع التعبئة إلى صورة.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // تعيين وضع تعبئة الصورة.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // تحميل صورة وإضافتها إلى موارد العرض التقديمي.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // تعيين الصورة.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الشكل بتعبئة صورة](picture-fill.png)

### **صورة متكررة كملمس**

إذا أردت تعيين صورة مكرّرة كملمس وتخصيص سلوك التكرار، يمكنك استخدام الأساليب التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setPictureFillMode): يضبط وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة البلاط داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كان البلاط يُقلب أفقيًا أو عموديًا أو كليًا.
- [setTileOffsetX](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileOffsetX): يحدد الإزاحة الأفقية للبلاط (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileOffsetY): يحدد الإزاحة العمودية للبلاط (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileScaleX): يُعرّف مقياس البلاط الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileScaleY): يُعرّف مقياس البلاط العمودي كنسبة مئوية.

الكود التالي يوضح كيفية إضافة شكل مستطيل بتعبئة صورة مكررة وتكوين خيارات البلاط:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // تعيين نوع التعبئة للشكل إلى صورة.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // إسناد الصورة إلى الشكل.
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

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![خيارات التكرار](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة اللون الصلب هي خيار تنسيق يملأ الشكل بلون واحد موحد. يتم تطبيق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين لون التعبئة المفضل لك إلى الشكل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

الكود PHP التالي يوضح كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى صلب.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // تعيين لون التعبئة.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الشكل بتعبئة لون صلب](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عند تطبيق تعبئة بلون صلب أو تدرج أو صورة أو قوام على الأشكال، يمكنك أيضًا تعيين مستوى الشفافية للتحكم في شفافية التعبئة. كلما ارتفعت قيمة الشفافية، يصبح الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو العناصر الكامنة جزئيًا.

تتيح لك Aspose.Slides تعيين مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك كيفية القيام بذلك:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) إلى `Solid`.
1. استخدام `Color` لتعريف لون بشفافية (مكون `alpha` يتحكم في الشفافية).
1. حفظ العرض التقديمي.

الكود PHP التالي يوضح كيفية تطبيق لون تعبئة شفاف على مستطيل:

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

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية بمواضع معينة تتطلب محاذاة أو تصميمًا خاصًا.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين خاصية دوران الشكل إلى الزاوية المطلوبة.
1. حفظ العرض التقديمي.

الكود PHP التالي يوضح كيفية تدوير شكل بزاوية 5 درجات:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بزاوية 5 درجات.
    $shape->setRotation(5);

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات الحافة ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات الحافة ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/).

لإضافة تأثيرات الحافة ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/) للشكل لتحديد إعدادات الحافة.
1. حفظ العرض التقديمي.

الكود PHP التالي يوضح كيفية تطبيق تأثيرات الحافة ثلاثية الأبعاد على شكل:

```php
// إنشاء مثيل من فئة Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل إلى الشريحة.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // تعيين خصائص ThreeDFormat للشكل.
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

![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات الدوران ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات الدوران ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/).

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. استخدم [setCameraType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/camera/#setCameraType) و[setLightType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/lightrig/#setLightType) لتحديد دوران ثلاثي الأبعاد.
1. حفظ العرض التقديمي.

الكود PHP التالي يوضح كيفية تطبيق تأثيرات الدوران ثلاثية الأبعاد على شكل:

```php
// إنشاء مثيل من فئة Presentation.
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

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في عرض الأبيض والأسود للأشكال**

تحدد طريقة [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#setBlackWhiteMode) كيفية عرض شكل فردي عندما يُعرض أو يُعالج العرض التقديمي في وضع الأبيض والأسود. لا تُفعّل طريقة العرض بالأبيض والأسود بحد ذاتها، ولا تغيّر تعبئة الشكل أو خطه أو تنسيقه في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/blackwhitemode/) لاختيار السلوك المطلوب. على سبيل المثال، `Automatic` يتيح لتطبيق العرض اختيار التحويل، `Gray` و`LightGray` يستخدمان اللون الرمادي، `BlackWhite` يستخدم فقط الأسود والأبيض، `Black` و`White` يجبران على لون واحد، `Color` يحافظ على الألوان العادية، و`Hidden` يحذف الشكل في وضع الأبيض والأسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

الكود PHP التالي ينشئ شكلاً ملونًا ويجعل عرضه رماديًا في وضع العرض بالأبيض والأسود:

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

    // إبقاء تعبئة اللون البرتقالي في وضع اللون، ولكن عرض الشكل بتلوين رمادي في وضع الأبيض والأسود.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

في وضع اللون العادي، يحتفظ المستطيل بملئه البرتقالي. في سير عمل العرض بالأبيض والأسود، يستخدم اللون الرمادي لأن وضعه تم تعيينه إلى `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تحديد مظهر مميز للطباعة أو المعاينة أو أي سير عمل يولي اهتمامًا لإعدادات العرض بالأبيض والأسود.

## **إعادة تعيين التنسيق**

الكود Java التالي يوضح كيفية إعادة تعيين تنسيق شريحة وإعادة موضع وحجم وتنسيق جميع الأشكال التي تحتوي على عناصر نائبة على [LayoutSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // إعادة تعيين كل شكل على الشريحة التي لديها عنصر نائبة في التخطيط.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

بحد أدنى فقط. الصور والوسائط المضمّنة هي التي تشغل معظم مساحة الملف، بينما يتم تخزين معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال على شريحة تشترك في نفس التنسيق حتى أتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—ملئه، خطه، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطه متطابقة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ أشكالًا نموذجية بالأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المنمطة التي تحتاجها، وأعد تطبيق تنسيقها أينما كان ذلك مطلوبًا.