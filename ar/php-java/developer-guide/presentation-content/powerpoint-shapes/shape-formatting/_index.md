---
title: تنسيق أشكال PowerPoint في PHP
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/php-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم
- خط الشكل المرسوم
- تنسيق نمط الوصلة
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة بصورة
- تعبئة بنسيج
- تعبئة بلون صلب
- شفافية الشكل
- تدوير الشكل
- تأثير حافة ثلاثية الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: تعلم كيفية تنسيق أشكال PowerPoint في PHP باستخدام Aspose.Slides—حدد أنماط التعبئة، الخط، والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل.
---
## **المقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد إعدادات تتحكم في كيفية تعبئة داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides for PHP عبر Java فئات وأساليب تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتوفرة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/ar/php-java/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/ar/php-java/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود PHP التالي يوضح كيفية تنسيق شكل مستطيل من نوع `AutoShape`:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // تطبيق التنسيق على خطوط المستطيل.
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

## **تطبيق تأثيرات الرسم على خطوط الشكل**

تجعل تأثيرات الرسم خط الشكل يبدو مرسومًا يدويًا. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) للوصول إلى إعدادات الخط، و[LineFormat.getSketchFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/lineformat/) للوصول إلى إعدادات الرسم، و[SketchFormat.setSketchType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sketchformat/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/linesketchtype/).

الكود PHP التالي يوضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/ar/php-java/aspose.slides/linesketchtype/)، وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/ar/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // الوصول إلى تنسيق خط الشكل وتنسيق الرسم الخاص به.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // تطبيق تأثير رسم.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // قراءة تأثير الرسم المعين مباشرةً إلى الشكل.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // إزالة تأثير الرسم.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

القيمة التي تُرجعها [SketchFormat.getSketchType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sketchformat/) تمثل الإعداد المعين مباشرةً للشكل. إذا كان تنسيق الخط يمكن أن يرث من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/lineformat/)، وادخل إلى طريقة `getSketchFormat` للكيان المرتجع، ثم اقرأ قيمتها `getSketchType`. القيمة الفعّالة تعكس التنسيق المطبق فعليًا بعد حل الوراثة:

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

## **تنسيق أنماط الوصلات**

فيما يلي ثلاثة خيارات لنوع الوصلة:

* Round
* Miter
* Bevel

افتراضيًا، عندما يجمع PowerPoint خطين بزاوية (مثل زاوية شكل)، يستخدم إعداد **Round**. ومع ذلك، إذا كنت ترسم شكلًا بزوايا حادة، قد تفضّل خيار **Miter**.

![نمط الوصلة في العرض التقديمي](join-style-powerpoint.png)

الكود PHP التالي يوضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصلة Miter وBevel وRound:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة ثلاثة أشكال تلقائية من نوع Rectangle.
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

    // تعيين لون خط كل مستطيل.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // تعيين نمط الوصلة.
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

## **التعبئة المتدرجة**

في PowerPoint، تُعدّ التعبئة المتدرجة خيارًا تنسيقيًا يتيح لك تطبيق انتقال سلس بين ألوان متعددة على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة متدرجة على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة اللونين المفضلين مع تحديد المواقع باستخدام طرق `add` لمجموعة إيقافات التدرج التي تُعرض عبر فئة [GradientFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/gradientformat/) .
1. حفظ العرض المعدل كملف PPTX.

الكود PHP التالي يوضح كيفية تطبيق تأثير تعبئة متدرجة على شكل بيضاوي:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق تدرج على الشكل البيضاوي.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // تعيين اتجاه التدرج.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // إضافة نقطتي توقف للتدرج.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![البيضاوي مع تعبئة متدرجة](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تُعدّ تعبئة النمط خيارًا يُتيح لك تطبيق تصميم من لونين—مثل النقاط أو الشرط أو التعرجات المتقابلة أو المربعات—على الشكل. يمكنك اختيار ألوان مخصصة للأمامي والخلفية للنمط.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز الجاذبية البصرية لعروضك. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب أن يستخدمها.

إليك كيفية تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمط من الخيارات المسبقة.
1. تعيين [Background Color](https://reference.aspose.com/slides/ar/php-java/aspose.slides/patternformat/#getBackColor) للنمط.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/ar/php-java/aspose.slides/patternformat/#getForeColor) للنمط.
1. حفظ العرض المعدل كملف PPTX.

الكود PHP التالي يوضح كيفية تطبيق تعبئة بنمط على مستطيل:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // تعيين نمط القالب.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // تعيين ألوان الخلفية والواجهة للنمط.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة بصورة**

في PowerPoint، تُعدّ تعبئة الصورة خيارًا يتيح لك إدراج صورة داخل الشكل—باستخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة بصورة على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضع تعبئة الصورة إلى `Tile` (أو أي وضع مفضّل آخر).
1. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `SlidesPicture.setImage` .
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

الكود PHP التالي يوضح كيفية تعبئة شكل بالصورة:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // تعيين نوع التعبئة إلى Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // تعيين وضع تعبئة الصورة.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // تحميل صورة وإضافتها إلى موارد العرض.
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

![الشكل مع تعبئة بصورة](picture-fill.png)

### **استخدام صورة مكررة كملمس**

إذا كنت ترغب في تعيين صورة مكررة كملمس وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setPictureFillMode): يحدد وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة المربعات داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كان المربع يُقلب أفقيًا أو عموديًا أو كليًا.
- [setTileOffsetX](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileOffsetX): يحدد الإزاحة الأفقية للمربع (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileOffsetY): يحدد الإزاحة العمودية للمربع (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileScaleX): يحدد مقياس المربع الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#setTileScaleY): يحدد مقياس المربع العمودي كنسبة مئوية.

الكود التالي يُظهر كيفية إضافة شكل مستطيل بتعبئة صورة مكررة وتكوين خيارات التكرار:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // تعيين نوع التعبئة للشكل إلى Picture.
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

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![خيارات التكرار](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تُعدّ تعبئة اللون الصلب خيارًا يملأ الشكل بلون موحّد واحد. يُطبق هذا اللون الخلفي بسيطًا دون أي تدرجات أو أنسجة أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين لون التعبئة المفضّل للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود PHP التالي يوضح كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Solid.
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

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **ضبط الشفافية**

في PowerPoint، عند تطبيق تعبئة صلبة أو متدرجة أو صورة أو نسيج على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في وضوح التعبئة. كلما ارتفعت قيمة الشفافية، يصبح الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو الكائنات تحتها جزئيًا.

تتيح لك Aspose.Slides ضبط مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) إلى `Solid`.
1. استخدام `Color` لتحديد لون مع شفافية (مكون `alpha` يتحكم في الشفافية).
1. حفظ العرض.

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

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. قد يكون هذا مفيدًا عند وضع العناصر البصرية باتجاهات أو تصاميم محددة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين خاصية الدوران لل shape إلى الزاوية المطلوبة.
1. حفظ العرض.

الكود PHP التالي يوضح كيفية تدوير شكل بزاوية 5 درجات:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
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

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات الحواف ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات حافة ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات حافة ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/) للشكل لتحديد إعدادات الحافة.
1. حفظ العرض.

الكود PHP التالي يوضح كيفية تطبيق تأثير حافة ثلاثية الأبعاد على شكل:

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
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
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

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/) الخاصة بها.

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
1. استخدام [setCameraType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/camera/#setCameraType) و[setLightType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/lightrig/#setLightType) لتحديد دوران ثلاثي الأبعاد.
1. حفظ العرض.

الكود PHP التالي يوضح كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:

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

## **إعادة تعيين التنسيق**

الكود Java التالي يوضح كيفية إعادة تعيين تنسيق شريحة وإرجاع الموضع والحجم وتنسيق جميع الأشكال التي تحتوي على عناصر نائبة في [LayoutSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

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

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

قليلًا فقط. تشغل الصور والوسائط المضمنة معظم مساحة الملف، في حين تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات تعريفية ولا تضيف حجمًا كبيرًا تقريبًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي لها تنسيق متماثل لأتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإعدادات الخاصة بالتعبئة، الخط، والتأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متماثلة وجرّب تجميع هذه الأشكال منطقيًا، ما يُسهل إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ أشكالًا نموذجية بالأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال ذات الأنماط التي تحتاجها، وأعد تطبيق تنسيقها حسب الحاجة.