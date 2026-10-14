---
title: تنسيق أشكال PowerPoint في JavaScript
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/nodejs-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط الشكل الرسم التخطيطي
- تنسيق نمط الانضمام
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة بصورة
- تعبئة بنقش
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بدرجات الرمادي
- تدوير الشكل
- تأثير الحافة ثلاثية الأبعاد
- تأثير الدوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "قُم بتنسيق أشكال PowerPoint في JavaScript باستخدام Aspose.Slides — حدد أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **المقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد الإعدادات التي تتحكم في كيفية تعبئة داخلها.

![format-shape-powerpoint](format-shape-powerpoint.png)

توفر Aspose.Slides لـ Node.js عبر Java فئات وطرق تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [نمط الخط](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [نمط الشرط](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

يعرض الشيفرة التالية كيفية تنسيق `AutoShape` على شكل مستطيل:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // إزالة التعبئة من شكل المستطيل.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // تطبيق تنسيق على خطوط المستطيل.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // تحديد اللون لخط المستطيل.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // حفظ ملف PPTX إلى القرص.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The formatted lines in the presentation](formatted-lines.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُضيف تأثير الرسم التخطيطي مظهرًا يدويًا لخط الشكل. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) للوصول إلى إعدادات الخط، و[LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) لتحديد قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/).

يعرض الشيفرة JavaScript التالية كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) ، وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // الوصول إلى تنسيق خط الشكل وتنسيق الرسم التخطيطي الخاص به.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // تطبيق تأثير رسم تخطيطي.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // قراءة تأثير الرسم التخطيطي المعين مباشرةً إلى الشكل.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // إزالة تأثير الرسم التخطيطي.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

القيمة التي تُعيدها الدالة [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) تمثل الإعداد المعيّن مباشرةً إلى الشكل. إذا كان تنسيق الخط يمكن وراثته من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/)، ثم استدعِ `getSketchFormat` على الكائن المُعاد، ثم استدعِ طريقة `getSketchType` الخاصة به. القيمة الفعّالة تعكس التنسيق الذي يتم تطبيقه فعليًا بعد حل الوراثة:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **تنسيق أنماط الانضمام**

إليك الخيارات الثلاثة لنوع الانضمام:

* دائري
* زاوية حادة
* مقوس

افتراضيًا، عندما يجمع PowerPoint خطين بزاوية (مثل زاوية شكل)، يستخدم الإعداد **Round**. ومع ذلك، إذا كنت ترسم شكلاً بزاوية حادة، قد تفضل خيار **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

يعرض الشيفرة JavaScript التالية كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الانضمام Miter وBevel وRound:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة ثلاثة أشكال تلقائية من النوع Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // تعيين لون التعبئة لكل شكل مستطيل.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // تعيين عرض الخط.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // تعيين اللون لخط كل مستطيل.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // تعيين نمط الانضمام.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // إضافة نص إلى كل مستطيل.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // حفظ ملف PPTX إلى القرص.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعبئة متدرجة**

في PowerPoint، تعبئة المتدرج هي خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك طريقة تطبيق تعبئة متدرجة على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. أضف اللونين المفضلين لديك مع المواقع المحددة باستخدام طرق `add` لمجموعة إيقافات التدرج التي تعرضها الفئة [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/) .
1. حفظ العرض المعدل كملف PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق متدرج على الشكل البيضاوي.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // تعيين اتجاه التدرج.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // إضافة نقطتي توقف للتدرج.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The ellipse with gradient fill](gradient-fill.png)

إذا كان المظهر المتدرج يختلف في صورة مُصدَّرة مقارنةً بما هو في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة المتدرج المخزنة في العرض.

## **تعبئة بنمط**

في PowerPoint، تعبئة النمط هي خيار تنسيق يتيح لك تطبيق تصميم ثنائي اللون—مثل النقاط أو الخطوط أو التظليل المتقاطع أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة للخلفية والواجهة للنمط.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز جاذبية عروضك. حتى بعد اختيار نمط مُعرَّف مسبقًا، لا يزال بإمكانك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك طريقة تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختر نمطًا من الخيارات المسبقة.
1. تعيين [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) للنمط.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) للنمط.
1. حفظ العرض المعدل كملف PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // تعيين نمط النقشة.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // تعيين ألوان الخلفية والواجهة للنقش.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // حفظ ملف PPTX إلى القرص.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The rectangle with pattern fill](pattern-fill.png)

## **تعبئة بصورة**

في PowerPoint، تعبئة الصورة هي خيار تنسيق يتيح لك إدراج صورة داخل شكل—وبالتالي استخدام الصورة كخلفية للشكل.

إليك طريقة تطبيق تعبئة الصورة على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضع تعبئة الصورة إلى `Tile` (أو وضع آخر مفضل).
1. إنشاء كائن [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `ISlidesPicture.setImage` .
1. حفظ العرض المعدل كملف PPTX.

![The lotus picture](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // تعيين نوع التعبئة إلى Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // تعيين وضع تعبئة الصورة.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // تحميل صورة وإضافتها إلى موارد العرض.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // تعيين الصورة.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The shape with picture fill](picture-fill.png)

### **استخدام الصورة المتكررة كنقش**

إذا كنت ترغب في ضبط صورة مكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) يحدد وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment) يحدد محاذاة البلاط داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip) يتحكم فيما إذا كان البلاط يُقلب أفقياً أو عمودياً أو كليهما.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX) يحدد الإزاحة الأفقية للبلاط (بالنقطة) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY) يحدد الإزاحة العمودية للبلاط (بالنقطة) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX) يحدد مقياس البلاط الأفقى كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY) يحدد مقياس البلاط العمودي كنسبة مئوية.

يعرض مثال الشيفرة التالي كيفية إضافة شكل مستطيل بتعبئة صورة متكررة وتكوين خيارات البلاط:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let firstSlide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // تعيين نوع تعبئة الشكل إلى Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // تحميل الصورة وإضافتها إلى موارد العرض.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // تعيين الصورة إلى الشكل.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // تكوين وضع تعبئة الصورة وخصائص التوزيع.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The tile options](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة اللون الصلب هي خيار تنسيق يملأ الشكل بلون واحد موحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو أنسجة أو أنماط.

لتطبيق تعبئة اللون الصلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين اللون المملوء المفضَّل للشكل.
1. حفظ العرض المعدل كملف PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // تعيين لون التعبئة.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // حفظ ملف PPTX إلى القرص.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The shape with solid color fill](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عند تطبيق تعبئة صلبة أو متدرجة أو صورة أو نقش على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في مدى شفافية التعبئة. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو الكائنات الموجودة تحته جزئيًا.

يسمح Aspose.Slides بتعيين مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) إلى `Solid`.
1. استخدم `Color` لتحديد لون مع شفافية (المكوّن `alpha` يتحكم في الشفافية).
1. حفظ العرض.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي مستطيل صلب.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // إضافة شكل مستطيل شفاف فوق الشكل الصلب.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // حفظ ملف PPTX إلى القرص.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The transparent shape](shape-transparency.png)

## **تدوير الأشكال**

يسمح Aspose.Slides بتدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية بمواضع معينة أو لتحقيق احتياجات تصميمية معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط خاصية دوران الشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بمقدار 5 درجات.
    shape.setRotation(5);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The shape rotation](shape-rotation.png)

## **إضافة تأثيرات الانحدار ثلاثية الأبعاد**

يسمح Aspose.Slides لك بتطبيق تأثيرات الانحدار ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات الانحدار ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) لتحديد إعدادات الانحدار.
1. حفظ العرض.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء مثيل للفئة Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل إلى الشريحة.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // تعيين خصائص ThreeDFormat للشكل.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // حفظ العرض كملف PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The 3D bevel effect](3D-bevel-effect.png)

## **إضافة تأثيرات الدوران ثلاثية الأبعاد**

يسمح Aspose.Slides لك بتطبيق تأثيرات الدوران ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) الخاصة بها.

لتحقيق دوران ثلاثي الأبعاد لشكل:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. استخدم [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) و[setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) لتحديد الدوران ثلاثي الأبعاد.
1. حفظ العرض.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء مثيل للفئة Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // حفظ العرض كملف PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The 3D rotation effect](3D-rotation-effect.png)

## **التحكم في عرض بالأبيض والأسود للأشكال**

تحدد طريقة [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) كيف يتم عرض شكل فردي عندما يُعرض العرض أو يُعالج بوضع الأبيض والأسود. لا تمكّن طريقة العرض بالأبيض والأسود بحد ذاتها، ولا تغير تعبئة أو خط أو تنسيق الشكل في وضع الألوان العادي.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، تسمح القيمة `Automatic` لتطبيق العرض باختيار التحويل، وتستخدم القيم `Gray` و`LightGray` اللون الرمادي، وتستخدم `BlackWhite` الأسود والأبيض فقط، وتفرض القيم `Black` و`White` لونًا واحدًا، وتحافظ `Color` على الألوان الطبيعية، وتُخفي `Hidden` الشكل في وضع الأبيض والأسود. وتعني `NotDefined` عدم تعيين وضع على مستوى الشكل.

يوضح الشيفرة JavaScript التالية كيفية إنشاء شكل ملون وجعله يظهر بالرمادي في وضع العرض بالأبيض والأسود:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // احتفظ بتعبئة اللون البرتقالي في وضع اللون، لكن اعرض الشكل بألوان رمادية في وضع الأبيض والأسود.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في وضع الألوان العادي، يحتفظ المستطيل بملئه البرتقالي. في سير عمل العرض بالأبيض والأسود، يستخدم اللون الرمادي لأن وضعه مضبوط على `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة كاملة مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل يراعي إعدادات العرض بالأبيض والأسود.

## **إعادة تعيين التنسيق**

يوضح الشيفرة JavaScript التالية كيفية إعادة تعيين تنسيق شريحة وإعادة وضعية وحجم وتنسيق كل الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // إعادة تعيين كل شكل في الشريحة الذي له عنصر نائبي في التخطيط.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

قليلًا فقط. الصور والوسائط المضمَّنة تشغل معظم مساحة الملف، بينما تُخزَّن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات تعريفية ولا تُضيف حجمًا إضافيًا تقريبًا.

**كيف يمكنني اكتشاف الأشكال في شريحة تشترك في نفس التنسيق لكي أُجَمِّعها؟**

قارن الخصائص التنسيقية الرئيسية لكل شكل—إعدادات التعبئة، الخط، والتأثيرات. إذا تطابقت جميع القيم المقابلة، اعتبر أن أسلوبها متماثل وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ أشكالًا نموذجية بالمظهر المطلوب في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال ذات النمط المطلوب، وأعد تطبيق تنسيقها حيثما كان ذلك ضروريًا.