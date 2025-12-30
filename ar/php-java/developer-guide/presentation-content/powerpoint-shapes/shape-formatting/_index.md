---
title: تنسيق أشكال PowerPoint في PHP
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/php-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تنسيق نمط الوصل
- ملء تدرجي
- ملء نمط
- ملء صورة
- ملء قوام
- ملء لون صلب
- شفافية الشكل
- تدوير الشكل
- تأثير الحافة ثلاثية الأبعاد
- تأثير الدوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرّف على كيفية تنسيق أشكال PowerPoint في PHP باستخدام Aspose.Slides—حدد أنماط التعبئة، الخط، والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---

## **نظرة عامة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد الإعدادات التي تتحكم في كيفية تعبئة داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides for PHP عبر Java الفئات والأساليب التي تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. توضح الخطوات التالية الإجراء:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) للشكل.
5. تعيين عرض الخط.
6. تعيين [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) للخط.
7. تعيين لون الخط للشكل.
8. حفظ العرض المعدل كملف PPTX.

يظهر الكود PHP التالي كيفية تنسيق مستطيل `AutoShape`:
```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
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


![الخطوط المنسقة في العرض](formatted-lines.png)

## **تنسيق أنماط الوصل**

إليك خيارات ثلاثة لأنواع الوصل:

* Round
* Miter
* Bevel

بشكل افتراضي، عندما يقوم PowerPoint بضم خطين بزاوية (مثل زاوية شكل)، يستخدم إعداد **Round**. ومع ذلك، إذا كنت ترسم شكلًا بزوايا حادة، قد تفضل خيار **Miter**.

![نمط الوصل في العرض](join-style-powerpoint.png)

يظهر الكود PHP التالي كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصل Miter و Bevel و Round:
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

    // تعيين اللون لكل خط مستطيل.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // تعيين نمط الوصل.
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


## **ملء تدرجي**

في PowerPoint، الملء التدرجي هو خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث ينتقل أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق ملء تدرجي على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) للشكل إلى `Gradient`.
5. أضف لونين مفضلين مع مواقع محددة باستخدام أساليب `add` في مجموعة نقاط التدرج التي يُظهرها الفصل [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/) .
6. حفظ العرض المعدل كملف PPTX.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق التدرج على الشكل البيضاوي.
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


![الإهليلج مع ملء تدرجي](gradient-fill.png)

## **ملء النمط**

في PowerPoint، ملء النمط هو خيار تنسيق يتيح لك تطبيق تصميم من لونين—مثل النقاط أو الخطوط أو المتعرجات المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة للمقدمة والخلفية للنمط.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتحسين المظهر البصري لعروضك. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك كيفية تطبيق ملء نمط على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) للشكل إلى `Pattern`.
5. اختيار نمط نمط من الخيارات المسبقة.
6. تعيين [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) للنمط.
7. تعيين [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) للنمط.
8. حفظ العرض المعدل كملف PPTX.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // تعيين نمط التعبئة.
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


![المستطيل مع ملء نمط](pattern-fill.png)

## **ملء صورة**

في PowerPoint، ملء الصورة هو خيار تنسيق يتيح لك إدراج صورة داخل شكل—وبالتالي استخدام الصورة كخلفية الشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق ملء صورة على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) للشكل إلى `Picture`.
5. تعيين وضع ملء الصورة إلى `Tile` (أو وضع آخر مفضل).
6. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
7. تمرير الصورة إلى طريقة `SlidesPicture.setImage` .

![صورة اللوتس](lotus.png)

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // تعيين نوع التعبئة إلى Picture.
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


![الشكل مع ملء صورة](picture-fill.png)

### **استخدام صورة متكررة كقوام**

إذا أردت تعيين صورة متكررة كقوام وتخصيص سلوك التكرار، يمكنك استخدام الأساليب التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) : يحدد وضع ملء الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment) : يحدد محاذاة البلاط داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip) : يتحكم فيما إذا كان البلاط يُقلب أفقياً أو عمودياً أو كليهما.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX) : يحدد إزاحة البلاط أفقياً (بنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY) : يحدد إزاحة البلاط عمودياً (بنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX) : يعرّف مقياس البلاط أفقياً كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY) : يعرّف مقياس البلاط عمودياً كنسبة مئوية.

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

    // تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // إسناد الصورة إلى الشكل.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // تكوين وضع تعبئة الصورة وخصائص التبليط.
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


![خيارات التكرار](tile-options.png)

## **ملء بلون صلب**

في PowerPoint، ملء اللون الصلب هو خيار تنسيق يملأ الشكل بلون واحد موحد. يتم تطبيق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو أنماط.

إليك خطوات تطبيق ملء بلون صلب على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) للشكل إلى `Solid`.
5. تعيين اللون المملوء المفضل للشكل.
6. حفظ العرض المعدل كملف PPTX.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
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


![الشكل مع ملء بلون صلب](solid-color-fill.png)

## **ضبط الشفافية**

في PowerPoint، عندما تطبق ملء بلون صلب أو تدرجي أو صورة أو قوام على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في نسبة وضوح الملء. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح بالخلفية أو الكائنات تحتها أن تكون مرئية جزئيًا.

تتيح لك Aspose.Slides ضبط مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للملء. إليك الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) إلى `Solid`.
5. استخدام `Color` لتعريف لون مع شفافية (مكون الألفا يتحكم في الشفافية).
6. حفظ العرض.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل مستطيل صلب تلقائي.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // إضافة شكل مستطيل شفاف تلقائي فوق الشكل الصلب.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


![الشكل الشفاف](shape-transparency.png)

## **دوران الأشكال**

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية بمواضع تتطلب محاذاة أو تصميمًا معينًا.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين خاصية دوران الشكل إلى الزاوية المطلوبة.
5. حفظ العرض.

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

    // حفظ ملف PPTX إلى القرص.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات الحواف ثلاثية الأبعاد**

يتيح لك Aspose.Slides تطبيق تأثيرات الحواف ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) .

لإضافة تأثيرات الحواف ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. تكوين [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) للشكل لتحديد إعدادات الحافة.
5. حفظ العرض.

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


![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات الدوران ثلاثية الأبعاد**

يتيح لك Aspose.Slides تطبيق تأثيرات الدوران ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) .

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. استخدام [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) و [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) لتحديد دوران ثلاثي الأبعاد.
5. حفظ العرض.

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


![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **إعادة ضبط التنسيق**

يظهر الكود Java التالي كيفية إعادة ضبط تنسيق شريحة وإعادة موضع وحجم وتنسيق جميع الأشكال التي تحتوي على نائبات على [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:
```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // إعادة ضبط كل شكل على الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

يتأثر الحجم بشكل طفيف فقط. الصور والوسائط المدمجة هي التي تحتل معظم مساحة الملف، بينما تُخزن معاملات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية وتضيف حجمًا ضئيلًا جدًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في تنسيق متماثل حتى أتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—إعدادات التعبئة، الخط، والتأثيرات. إذا تطابقت جميع القيم المقابلة، يمكن اعتبار أن أسلوبها متماثل وتجميع تلك الأشكال معًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الأشكال المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ أشكالًا عينة ذات الأنماط المطلوبة في مجموعة شرائح نموذجية أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وأعد تطبيق تنسيقها حيثما دُقِّيت الحاجة.