---
title: تنسيق أشكال PowerPoint في JavaScript
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/nodejs-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسمة
- خط الشكل المرسوم
- تنسيق نمط الوصلة
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة بصورة
- تعبئة بنقش
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بدرجات الرمادي
- تدوير الشكل
- تأثير شطب ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "قم بتنسيق أشكال PowerPoint في JavaScript باستخدام Aspose.Slides—حدد أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **المقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد إعدادات تتحكم في كيفية تعبئة داخلها.

![format-shape-powerpoint](format-shape-powerpoint.png)

توفر Aspose.Slides for Node.js via Java فئات وطرق تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتوفرة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. تُوضح الخطوات التالية الإجراء:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الحصول على مرجع لشريحة حسب فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [line style](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/linestyle/) للشكل.
5. تعيين عرض الخط.
6. تعيين [dash style](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/linedashstyle/) للخط.
7. تعيين لون الخط للشكل.
8. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح كيفية تنسيق `AutoShape` بشكل مستطيل:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // إزالة التعبئة من الشكل المستطيل.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // تطبيق تنسيق على خطوط المستطيل.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // تحديد لون خط المستطيل.
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

## **تطبيق تأثيرات الرسم على خطوط الشكل**

يُضيف تأثير الرسم مظهرًا يدويًا لخط الشكل. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/) للوصول إلى إعدادات الخط، و[LineFormat.getSketchFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/lineformat/) للوصول إلى إعدادات الرسم، و[SketchFormat.setSketchType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sketchformat/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/linesketchtype/).

الكود التالي في JavaScript يُظهر كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/linesketchtype/)، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // الوصول إلى تنسيق خط الشكل وتنسيق الرسم.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // تطبيق تأثير رسم.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // قراءة تأثير الرسم المعيّن مباشرةً إلى الشكل.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // إزالة تأثير الرسم.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

القيمة التي تُعيدها [SketchFormat.getSketchType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sketchformat/) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان يمكن توريث تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/lineformat/)، استدعِ `getSketchFormat` على الكائن المرجعي، ثم استدعِ طريقة `getSketchType` الخاصة به. القيمة الفعلية تعكس التنسيق المطبق فعليًا بعد حل التوريث:

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

## **تنسيق أنماط الوصلات**

إليك خيارات الأنواع الثلاثة للوصلات:

* Round  
* Miter  
* Bevel  

افتراضيًا، عندما يجمع PowerPoint خطين بزاوية (مثلًا عند زاوية الشكل)، يستخدم إعداد **Round**. ومع ذلك، إذا كنت ترسم شكلاً بزاويا حادة، قد تفضّل خيار **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

الكود التالي في JavaScript يوضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات وصلات Miter وBevel وRound:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة ثلاثة أشكال تلقائية من نوع Rectangle.
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

    // تعيين اللون لكل خط من المستطيلات.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // تعيين نمط الوصلة.
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

في PowerPoint، تُعد تعبئة المتدرج خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك طريقة تطبيق تعبئة متدرجة على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الحصول على مرجع لشريحة حسب فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) للشكل إلى `Gradient`.
5. إضافة لونين مفضلين مع مواقع محددة باستخدام طرق `add` لمجموعة نقاط التدرج التي تُعرض عبر فئة [GradientFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/gradientformat/).
6. حفظ العرض المعدل كملف PPTX.

الكود التالي في JavaScript يوضح كيفية تطبيق تأثير تعبئة متدرجة على إهليلج:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق تدرج على الشكل البيضاوي.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // تحديد اتجاه التدرج.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // إضافة نقطتي تدرج.
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

## **تعبئة بنمط**

في PowerPoint، تُعد تعبئة النمط خيار تنسيق يتيح لك تطبيق تصميم بلونين—مثل النقاط أو الخطوط أو التعرجات المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة للمقدمة والخلفية للنمط.

توفر Aspose.Slides أكثر من 45 نمطًا مُعرّفًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز الجاذبية البصرية لعروضك. وحتى بعد اختيار نمط مُعرّف مسبقًا، لا يزال بإمكانك تحديد الألوان الدقيقة التي يجب أن يستخدمها.

إليك طريقة تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الحصول على مرجع لشريحة حسب فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) للشكل إلى `Pattern`.
5. اختيار نمط نمط من الخيارات المُعرّفة مسبقًا.
6. تعيين [Background Color](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/patternformat/#getBackColor--) للنمط.
7. تعيين [Foreground Color](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/patternformat/#getForeColor--) للنمط.
8. حفظ العرض المعدل كملف PPTX.

الكود التالي في JavaScript يوضح كيفية تطبيق تعبئة بنمط على مستطيل:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // تعيين نمط النمط.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // تعيين ألوان خلفية ونص النمط.
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

## **تعبئة صورة**

في PowerPoint، تُعد تعبئة الصورة خيار تنسيق يتيح لك إدراج صورة داخل شكل—وبالتالي استخدام الصورة كخلفية للشكل.

إليك طريقة استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الحصول على مرجع لشريحة حسب فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) للشكل إلى `Picture`.
5. تعيين وضع تعبئة الصورة إلى `Tile` (أو وضع مفضل آخر).
6. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
7. تمرير الصورة إلى طريقة `ISlidesPicture.setImage`.
8. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![The lotus picture](lotus.png)

الكود التالي في JavaScript يوضح كيفية تعبئة شكل بالصورة:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // تعيين نوع التعبئة إلى Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // تعيين وضع تعبئة الصورة.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // تحميل صورة وإضافتها إلى موارد العرض التقديمي.
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

### **استخدام صورة متكررة كنقش**

إذا كنت تريد ضبط صورة مكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية في فئة [PictureFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): يحدد وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة القرميد داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كان القرميد يُقلب أُفقيًا أو عموديًا أو كليًا.
- [setTileOffsetX](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): يحدد الإزاحة الأُفقية للقرميد (بنقاط) عن أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): يحدد الإزاحة العمودية للقرميد (بنقاط) عن أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): يحدد مقياس القرميد الأُفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): يحدد مقياس القرميد العمودي كنسبة مئوية.

العينة التالية تُظهر كيفية إضافة شكل مستطيل بتعبئة صورة مكررة وتكوين خيارات القرميد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let firstSlide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي مستطيل.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // تعيين نوع التعبئة للشكل إلى Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // تعيين الصورة إلى الشكل.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // تكوين وضع تعبئة الصورة وخصائص التكرار.
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

في PowerPoint، تُعد تعبئة اللون الصلب خيار تنسيق يملأ الشكل بلون موحد واحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو نقوش أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الحصول على مرجع لشريحة حسب فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) للشكل إلى `Solid`.
5. تحديد لون التعبئة المفضل للشكل.
6. حفظ العرض المعدل كملف PPTX.

الكود التالي في JavaScript يُظهر كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
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

## **ضبط الشفافية**

في PowerPoint، عند تطبيق لون صلب أو متدرج أو صورة أو تعبئة نقشة على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في عتامة التعبئة. كلما ارتفعت قيمة الشفافية، أصبح الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو الكائنات الفرعية جزئيًا.

تتيح لك Aspose.Slides ضبط مستوى الشفافية عن طريق تعديل قيمة الألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الحصول على مرجع لشريحة حسب فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) إلى `Solid`.
5. استخدم `Color` لتعريف لون مع شفافية (المكوّن `alpha` يتحكم في الشفافية).
6. حفظ العرض.

الكود التالي في JavaScript يُظهر كيفية تطبيق لون تعبئة شفاف على مستطيل:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي مستطيل صلب.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // إضافة شكل تلقائي مستطيل شفاف فوق الشكل الصلب.
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

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون هذا مفيدًا عند وضع العناصر البصرية مع متطلبات معينة للمواءمة أو التصميم.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الحصول على مرجع لشريحة حسب فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين خاصية تدوير الشكل إلى الزاوية المطلوبة.
5. حفظ العرض.

الكود التالي في JavaScript يُظهر كيفية تدوير شكل بزاوية 5 درجات:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بـ 5 درجات.
    shape.setRotation(5);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The shape rotation](shape-rotation.png)

## **إضافة تأثيرات شطب ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات شطب ثلاثية الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/).

لإضافة تأثير شطب ثلاثي الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الحصول على مرجع لشريحة حسب فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. ضبط [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/) للشكل لتحديد إعدادات الشطب.
5. حفظ العرض.

الكود التالي في JavaScript يُظهر كيفية تطبيق تأثير شطب ثلاثي الأبعاد على شكل:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن من فئة Presentation.
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

    // حفظ العرض التقديمي كملف PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The 3D bevel effect](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/).

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الحصول على مرجع لشريحة حسب فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. استخدم [setCameraType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/camera/#setCameraType) و[setLightType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/lightrig/#setLightType) لتحديد دوران ثلاثي الأبعاد.
5. حفظ العرض.

الكود التالي في JavaScript يُظهر كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من فئة Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // حفظ العرض التقديمي كملف PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The 3D rotation effect](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

طريقة [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) تُحدِّد كيف يُعرض شكل فردي عندما يُعرض أو يُعالج العرض بوضع الأبيض والأسود. لا تُفعِّل هذا الطريقة العرض بالأبيض والأسود بحد ذاتها، ولا تغير تعبئة الشكل أو خطه أو تنسيقه في وضع الألوان العادية.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/blackwhitemode/) لاختيار السلوك المطلوب. على سبيل المثال، `Automatic` يسمح لتطبيق العرض باختيار التحويل، `Gray` و`LightGray` يستخدمان اللون الرمادي، `BlackWhite` يستخدم فقط الأسود والأبيض، `Black` و`White` يفرضان لونًا واحدًا، `Color` يحافظ على الألوان العادية، و`Hidden` يزيل الشكل في وضع الأبيض والأسود. `NotDefined` تعني عدم تعيين وضع على مستوى الشكل.

الكود التالي في JavaScript يُنشئ شكلًا ملونًا ويجعله يظهر بالرمادي في وضع العرض بالأبيض والأسود:

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

    // احتفظ بتعبئة اللون البرتقالي في وضع الألوان، لكن عرض الشكل بلون رمادي في وضع الأبيض والأسود.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في وضع الألوان العادية، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل العرض بالأبيض والأسود، يستخدم اللون الرمادي لأن وضعه مضبوط على `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تحديد مظهر مخصص للطباعة أو المعاينة أو أي سير عمل يلتزم بإعدادات العرض بالأبيض والأسود للعرض.

## **إعادة تعيين التنسيق**

الكود التالي في JavaScript يُظهر كيفية إعادة تعيين تنسيق شريحة وإرجاع موضع وحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // إعادة تعيين كل شكل على الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

بشكل ضئيل فقط. تُشغل الصور والوسائط المضمنة معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تُضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تتشارك تنسيقًا متماثلًا حتى أتمكن من تجميعها؟**

قارن الخصائص التنسيقية الرئيسية لكل شكل—التعبئة، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع هذه الأشكال منطقيًا، ما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة إلى ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في مجموعة شرائح قالب أو ملف .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وأعد تطبيق تنسيقاتها حسب الحاجة.