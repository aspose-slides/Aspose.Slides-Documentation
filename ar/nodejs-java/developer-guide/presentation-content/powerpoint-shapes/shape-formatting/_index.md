---
title: تنسيق أشكال PowerPoint في JavaScript
linktitle: تنسيق الأشكال
type: docs
weight: 20
url: /ar/nodejs-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تنسيق نمط الوصل
- تعبئة تدرجية
- تعبئة بنمط
- تعبئة صورة
- تعبئة نسيج
- تعبئة بلون صلب
- شفافية الشكل
- تدوير الشكل
- تأثير الحافة ثلاثية الأبعاد
- تأثير الدوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "تعرف على كيفية تنسيق أشكال PowerPoint في JavaScript باستخدام Aspose.Slides—اضبط أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---

## **نظرة عامة**

في PowerPoint، يمكنك إضافة الأشكال إلى الشرائح. بما أن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد إعدادات تتحكم في كيفية ملء داخلها.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java يوفر فئات وطرق تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [line style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) للشكل.
5. تعيين عرض الخط.
6. تعيين [dash style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) للخط.
7. تعيين لون الخط للشكل.
8. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح كيفية تنسيق مستطيل `AutoShape`:
```js
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // تعيين لون التعبئة للشكل المستطيل.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // تطبيق التنسيق على خطوط المستطيل.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // تعيين اللون لخط المستطيل.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // حفظ ملف PPTX إلى القرص.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![الخطوط المُنسقة في العرض التقديمي](formatted-lines.png)

## **تنسيق أنماط الانضمام**

إليك خيارات ثلاثة لأنماط الوصل:

* مستدير
* زاوية
* مشطوف

افتراضيًا، عندما يربط PowerPoint خطين بزاوية (مثل زاوية الشكل)، يستخدم إعداد **مستدير**. ومع ذلك، إذا كنت ترسم شكلًا بزويا حادة، قد تفضل خيار **زاوية**.

![نمط الوصل في العرض التقديمي](join-style-powerpoint.png)

الكود التالي في JavaScript يوضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصل الزاوية، المشطوف، والمستدير:
```js
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى.
    let slide = presentation.getSlides().get_Item(0);

    // إضافة ثلاثة أشكال تلقائية من نوع المستطيل.
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

    // تعيين نمط الوصل.
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

في PowerPoint، التعبئة التدرجية هي خيار تنسيق يتيح لك تطبيق تدرج مستمر من الألوان على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة تدرجية على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) للشكل إلى `Gradient`.
5. إضافة اللونين المفضلين لديك مع تحديد المواقع باستخدام طرق `add` لمجموعة نقاط التدرج التي يوفرها الفئة [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/) .
6. حفظ العرض المعدل كملف PPTX.

الكود التالي في JavaScript يوضح كيفية تطبيق تأثير تعبئة تدرجية على قطع بيضاوي:
```js
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

![القطع البيضاوي مع تعبئة تدرجية](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تعبئة بنمط هي خيار تنسيق يتيح لك تطبيق تصميم بلونين—مثل النقاط أو الخطوط أو التماسك أو المربعات—على الشكل. يمكنك اختيار ألوان مخصصة لخلفية والنمط الأمامي.

Aspose.Slides يوفر أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتحسين المظهر البصري لعروضك. وحتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي سيستخدمها.

إليك كيفية تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) للشكل إلى `Pattern`.
5. اختيار نمط نمط من الخيارات المسبقة.
6. تعيين [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) للنمط.
7. تعيين [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) للنمط.
8. حفظ العرض المعدل كملف PPTX.

الكود التالي في JavaScript يوضح كيفية تطبيق تعبئة بنمط على مستطيل:
```js
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

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة بصورة**

في PowerPoint، تعبئة بصورة هي خيار تنسيق يسمح لك بإدراج صورة داخل الشكل—بشكل فعّال كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) للشكل إلى `Picture`.
5. تعيين وضع تعبئة الصورة إلى `Tile` (أو أي وضع آخر مفضل).
6. إنشاء كائن [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
7. تمرير الصورة إلى طريقة `ISlidesPicture.setImage` .
8. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" مع الصورة التالية:

![صورة اللوتس](lotus.png)

الكود التالي في JavaScript يوضح كيفية تعبئة شكل بالصورة:
```js
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

### **تعبئة الصورة كملمس متكرر**

إذا أردت ضبط صورة متكررة كملمس وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): يحدد وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة القوالب داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كانت القالب تُقلب أفقيًا أو رأسيًا أو كليهما.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): يحدد الإزاحة أفقية للقالب (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): يحدد الإزاحة العمودية للقالب (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): يحدد مقياس القالب الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): يحدد مقياس القالب العمودي كنسبة مئوية.

الكود التالي يوضح كيفية إضافة شكل مستطيل مع تعبئة صورة متكررة وتكوين خيارات القالب:
```js
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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

    // إسناد الصورة إلى الشكل.
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

![خيارات القالب](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يملأ الشكل بلون موحد واحد. يتم تطبيق هذا اللون الخلفي دون أي تدرجات أو خامات أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) للشكل إلى `Solid`.
5. تعيين اللون المفضل كملء للشكل.
6. حفظ العرض المعدل كملف PPTX.

الكود التالي في JavaScript يوضح كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:
```js
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

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عند تطبيق تعبئة بلون صلب أو تدرج أو صورة أو خامة على الأشكال، يمكنك أيضًا تعيين مستوى الشفافية للتحكم في مدى وضوح التعبئة. كلما ارتفع قيمة الشفافية، يصبح الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو الكائنات الموجودة تحته جزئيًا.

Aspose.Slides يتيح لك ضبط مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) إلى `Solid`.
5. استخدام `Color` لتحديد لون مع شفافية (المكوّن `alpha` يتحكم في الشفافية).
6. حفظ العرض.

الكود التالي في JavaScript يوضح كيفية تطبيق لون تعبئة شفاف على مستطيل:
```js
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

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

Aspose.Slides يتيح لك تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية وفقًا لمحاذاة أو احتياجات تصميم معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين خاصية دوران الشكل إلى الزاوية المطلوبة.
5. حفظ العرض.

الكود التالي في JavaScript يوضح كيفية تدوير شكل بزاوية 5 درجات:
```js
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات الحواف ثلاثية الأبعاد**

Aspose.Slides يسمح لك بتطبيق تأثيرات حواف ثلاثية الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) .

لإضافة تأثيرات حواف ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. ضبط [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) للشكل لتحديد إعدادات الحواف.
5. حفظ العرض.

الكود التالي في JavaScript يوضح كيفية تطبيق تأثيرات حواف ثلاثية الأبعاد على شكل:
```js
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

    // حفظ العرض كملف PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات الدوران ثلاثية الأبعاد**

Aspose.Slides يسمح لك بتطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) .

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. استخدام [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) و [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) لتحديد دوران ثلاثي الأبعاد.
5. حفظ العرض.

الكود التالي في JavaScript يوضح كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:
```js
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

    // حفظ العرض كملف PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **إعادة تعيين التنسيق**

الكود التالي في Java يوضح كيفية إعادة تعيين تنسيق شريحة وإرجاع موضع وحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:
```js
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


## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

التأثير طفيف جدًا. معظم حجم الملف يُستحوذ عليه الصور والوسائط المضمنة، في حين تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في نفس التنسيق لتجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإملء، والحد، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع هذه الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية التي تحمل الأنماط المطلوبة في مجموعة شرائح قالب أو ملف .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال ذات الأنماط المطلوبة، وأعد تطبيق تنسيقها حسب الحاجة.