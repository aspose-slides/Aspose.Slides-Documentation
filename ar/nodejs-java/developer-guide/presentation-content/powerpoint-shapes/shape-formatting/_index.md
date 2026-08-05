---
title: تنسيق أشكال PowerPoint باستخدام JavaScript
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/nodejs-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير تخطيط
- خط الشكل التخطيطي
- تنسيق نمط الانضمام
- تعبئة تدرجية
- تعبئة نمطية
- تعبئة صورة
- تعبئة نسيج
- تعبئة بلون صلب
- شفافية الشكل
- تدوير الشكل
- تأثير انحناء ثلاثي الأبعاد
- تأثير تدوير ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تنسيق أشكال PowerPoint باستخدام JavaScript عبر Aspose.Slides—تعيين أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **المقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال مكوَّنة من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد الإعدادات التي تتحكم في كيفية تعبئة داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

يوفر Aspose.Slides for Node.js عبر Java فئات وأساليب تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل ما. الخطوات التالية توضح الإجراء:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية توضح كيفية تنسيق مستطيل `AutoShape`:

```js
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // تطبيق تنسيق على خطوط المستطيل.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // تعيين لون خط المستطيل.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // حفظ ملف PPTX إلى القرص.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الخطوط المنسقة في العرض](formatted-lines.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُضفي تأثير الرسم التخطيطي مظهرًا يدويًا على خط الشكل. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/) للوصول إلى إعدادات الخط، و[LineFormat.getSketchFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/lineformat/) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat.setSketchType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sketchformat/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/linesketchtype/).

الشفرة التالية بلغة JavaScript توضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/linesketchtype/) وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/linesketchtype/):

```js
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

القيمة التي تُرجعها [SketchFormat.getSketchType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sketchformat/) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/lineformat/)، ثم استدعِ `getSketchFormat` على الكائن المرتجع، ثم استدعِ طريقة `getSketchType` الخاصة به. القيمة الفعّالة تعكس التنسيق المطبق فعليًا بعد حل الوراثة:

```js
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

إليك ثلاثة خيارات لنوع الانضمام:

* Round
* Miter
* Bevel

بشكل افتراضي، عندما يجمع PowerPoint خطين بزاوية (مثل زاوية شكل)، يستخدم الإعداد **Round**. ومع ذلك، إذا كنت ترسم شكلاً بزاوٍ حادة، قد تفضّل خيار **Miter**.

![نمط الانضمام في العرض](join-style-powerpoint.png)

الشفرة التالية بلغة JavaScript توضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الانضمام Miter وBevel وRound:

```js
    // إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
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

        // تعيين لون خط كل مستطيل.
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

## **تعبئة تدرجية**

في PowerPoint، تُعد تعبئة التدرج خيارًا تنسيقيًا يسمح لك بتطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة تدرج على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة اللونين المفضلين لديك مع تحديد المواقع باستخدام طرق `add` لمجموعة نقاط التدرج التي يُظهرها فئة [GradientFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/gradientformat/) .
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية بلغة JavaScript توضح كيفية تطبيق تأثير تعبئة تدرج على إهليلج:

```js
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق التدرج على الشكل البيضاوي.
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

![الإهليلج مع تعبئة تدرجية](gradient-fill.png)

## **تعبئة نمطية**

في PowerPoint، تُعد تعبئة النمط خيارًا تنسيقيًا يتيح لك تطبيق تصميم ثنائي اللون—مثل النقاط أو الخطوط المتقطعة أو التخطط المتقاطع أو الشيكات—على شكل. يمكنك اختيار ألوان مخصصة لمقدمة النمط وخلفيته.

يوفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز الجاذبية البصرية لعروضك. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب أن يستخدمها.

إليك كيفية تطبيق تعبئة نمطية على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمطي من الخيارات المسبقة.
1. تعيين [Background Color](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/patternformat/#getBackColor--) للنمط.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/patternformat/#getForeColor--) للنمط.
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية بلغة JavaScript توضح كيفية تطبيق تعبئة نمطية على مستطيل:

```js
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
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

    // تعيين ألوان الخلفية والواجهة للنمط.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // حفظ ملف PPTX إلى القرص.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![المستطيل مع تعبئة نمطية](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تُعد تعبئة الصورة خيارًا تنسيقيًا يسمح لك بإدراج صورة داخل شكل—وبالتالي استخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضع تعبئة الصورة إلى `Tile` (أو أي وضع مفضل آخر).
1. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `ISlidesPicture.setImage`.
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

الشفرة التالية بلغة JavaScript توضح كيفية تعبئة شكل بالصورة:

```js
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
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

![الشكل مع تعبئة صورة](picture-fill.png)

### **استخدام صورة متكررة كنقش**

إذا رغبت في تعيين صورة متكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): يحدد وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة التكرارات داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كانت التكرارة مقلوبة أفقيًا أو عموديًا أو كليهما.
- [setTileOffsetX](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): يحدد إزاحة التكرارة أفقًا (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): يحدد إزاحة التكرارة عموديًا (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): يحدد مقياس التكرارة أفقيًا كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): يحدد مقياس التكرارة عموديًا كنسبة مئوية.

الشفرة التالية توضح كيفية إضافة شكل مستطيل بتعبئة صورة متكررة وتكوين خيارات التكرار:

```js
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let firstSlide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // تعيين نوع التعبئة للشكل إلى Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // تحميل الصورة وإضافتها إلى موارد العرض.
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

![خيارات التكرار](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تُعد تعبئة بلون صلب خيارًا تنسيقيًا يملأ الشكل بلون موحد واحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين اللون المفضل للتعبئة إلى الشكل.
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية بلغة JavaScript توضح كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:

```js
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
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

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **ضبط الشفافية**

في PowerPoint، عند تطبيق تعبئة بلون صلب أو تدرج أو صورة أو قوام على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في درجة وضوح التعبئة. كلما ارتفعت قيمة الشفافية، يصبح الشكل أكثر شفافية، مما يسمح للخلفية أو الكائنات الموجودة تحته بأن تُرى جزئيًا.

يتيح لك Aspose.Slides ضبط مستوى الشفافية عن طريق تعديل قيمة alfa في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) إلى `Solid`.
1. استخدام `Color` لتحديد لون مع شفافية (المكوّن `alpha` يتحكم في الشفافية).
1. حفظ العرض.

الشفرة التالية بلغة JavaScript توضح كيفية تطبيق لون تعبئة شفاف على مستطيل:

```js
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل مستطيل صلب تلقائي.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // إضافة شكل مستطيل شفاف تلقائي فوق الشكل الصلب.
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

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

يتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية وفقًا لمحاذاة أو متطلبات تصميم معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين خاصية تدوير الشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

الشفرة التالية بلغة JavaScript توضح كيفية تدوير شكل بزاوية 5 درجات:

```js
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بزاوية 5 درجات.
    shape.setRotation(5);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات انحناء ثلاثية الأبعاد**

يتيح لك Aspose.Slides تطبيق تأثيرات انحناء ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات انحناء ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/) للشكل لتحديد إعدادات الانحناء.
1. حفظ العرض.

الشفرة التالية بلغة JavaScript توضح كيفية تطبيق تأثيرات انحناء ثلاثية الأبعاد على شكل:

```js
// إنشاء نسخة من فئة Presentation.
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

![تأثير الانحناء ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات تدوير ثلاثية الأبعاد**

يتيح لك Aspose.Slides تطبيق تأثيرات تدوير ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/) الخاصة بها.

لتطبيق تدوير ثلاثي الأبعاد على شكل:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
1. استخدام [setCameraType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/camera/#setCameraType) و[setLightType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/lightrig/#setLightType) لتحديد التدوير ثلاثي الأبعاد.
1. حفظ العرض.

الشفرة التالية بلغة JavaScript توضح كيفية تطبيق تأثيرات تدوير ثلاثية الأبعاد على شكل:

```js
// إنشاء نسخة من فئة Presentation.
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

![تأثير التدوير ثلاثي الأبعاد](3D-rotation-effect.png)

## **إعادة تعيين التنسيق**

الشفرة التالية بلغة Java توضح كيفية إعادة تعيين تنسيق شريحة وإرجاع الموضع والحجم وتنسيق جميع الأشكال التي تحتوي على عناصر نائبة في [LayoutSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // إعادة ضبط كل شكل على الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

القليل فقط. الصور المدمجة والوسائط تشغل معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا كبيرًا عمليًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في نفس التنسيق لتجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإعدادات الخاصة بالتعبئة والخط والتأثير. إذا تطابقت جميع القيم المقابلة، فاعتبر أن أنماطها متطابقة وقم بتجميع هذه الأشكال منطقيًا، مما يبسّط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصَّصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ أشكالًا نموذجية بالأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، انسخ الأشكال المنمَّطة التي تحتاجها، وطبق تنسيقها حيثما يلزم.