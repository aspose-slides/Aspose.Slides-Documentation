---
title: تنسيق أشكال PowerPoint في Java
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تنسيق نمط الوصل
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة صورة
- تعبئة نقش
- تعبئة بلون صلب
- شفافية الشكل
- تدوير الشكل
- تأثير بروز ثلاثي الأبعاد
- تأثير تدوير ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في Java باستخدام Aspose.Slides-حدد أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---

## **نظرة عامة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد إعدادات تتحكم في ملء داخلها.

![تنسيق-الشكل-في-البوربوينت](format-shape-powerpoint.png)

توفر Aspose.Slides for Java واجهات وطرق تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل ما. الخطوات التالية توضح الإجراء:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لفهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) للشكل.
1. تحديد عرض الخط.
1. ضبط [dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) للخط.
1. تحديد لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية توضح كيفية تنسيق شكل `AutoShape` مستطيل:
```java
// إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // تطبيق تنسيق على خطوط المستطيل.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // تعيين اللون لخط المستطيل.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![الخطوط المنسقة في العرض](formatted-lines.png)

## **تنسيق أنماط الوصلات**

فيما يلي ثلاثة خيارات لنوع الوصلات:

* Round
* Miter
* Bevel

افتراضيًا، عندما يربط PowerPoint خطين بزاوية (مثلًا عند زاوية الشكل)، يستخدم إعداد **Round**. ومع ذلك، إذا كنت ترسم شكلًا بزوايا حادة، قد تفضل خيار **Miter**.

![نمط الوصلات في العرض](join-style-powerpoint.png)

الشفرة التالية بلغة Java توضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات الوصلات Miter وBevel وRound:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة ثلاثة أشكال تلقائية من نوع Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // تعيين لون التعبئة لكل شكل مستطيل.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // تعيين عرض الخط.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // تعيين اللون لخط كل مستطيل.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // تعيين نمط الوصلة.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // إضافة نص إلى كل مستطيل.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // حفظ ملف PPTX إلى القرص.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **تعبئة متدرجة**

في PowerPoint، تعبئة متدرجة هي خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على شكل ما. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة متدرجة على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لفهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة اللونين المفضلين مع تحديد المواقع باستخدام طرق `add` لمجموعة نقاط التدرج التي ي expose واجهة [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/) .
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية Java توضح كيفية تطبيق تأثير تعبئة متدرجة على إهليلج:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق التدرج على الشكل الإهليلجي.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // تعيين اتجاه التدرج.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // إضافة نقطتي توقف للتدرج.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![الإهليلج مع تعبئة متدرجة](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تعبئة بنمط هي خيار تنسيق يتيح لك تطبيق تصميم بلونين—مثل النقاط أو الشرائط أو الخطوط المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة لخلفية النمط وللجنبة الأمامية.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز المظهر البصري لعروضك. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك طريقة تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لفهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمط من الخيارات المسبقة.
1. ضبط [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) للنمط.
1. ضبط [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) للنمط.
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية Java توضح كيفية تطبيق تعبئة بنمط على مستطيل:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // تعيين نمط النمط.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // تعيين ألوان الخلفية والواجهة للنمط.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة صورة هي خيار تنسيق يسمح لك بإدراج صورة داخل شكل—بشكل فعال كخلفية للشكل.

إليك طريقة استخدام Aspose.Slides لتطبيق تعبئة بصورة على شكل:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لفهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) للشكل إلى `Picture`.
1. ضبط وضع تعبئة الصورة إلى `Tile` (أو أي وضع مفضل آخر).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `ISlidesPicture.setImage` .
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

الشفرة التالية Java توضح كيفية تعبئة شكل بالصورة:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // تعيين نوع التعبئة إلى Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // تعيين وضع تعبئة الصورة.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // تحميل صورة وإضافتها إلى موارد العرض التقديمي.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // تعيين الصورة.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **استخدام صورة متكررة كنقش**

إذا رغبت في تعيين صورة متكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): يحدد وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): يحدد محاذاة البلاط داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): يتحكم فيما إذا كان البلاط ينعكس أفقيًا أو عموديًا أو كليهما.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): يحدد الإزاحة الأفقية للبلاط (بنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): يحدد الإزاحة العمودية للبلاط (بنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): يعرّف مقياس البلاط الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): يعرّف مقياس البلاط العمودي كنسبة مئوية.

الشفرة التالية توضح كيفية إضافة شكل مستطيل مع تعبئة صورة متكررة وتكوين خيارات البلاط:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي مستطيل.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // تعيين نوع تعبئة الشكل إلى Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // تعيين الصورة إلى الشكل.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // تكوين وضع تعبئة الصورة وخصائص التكرار.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![خيارات البلاط](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يملأ الشكل بلون موحد واحد. يتم تطبيق هذا اللون الخلفي البسيط دون أي تدرجات أو نقوش أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لفهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين اللون المملوء المفضل للشكل.
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية Java توضح كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // تعيين لون التعبئة.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **ضبط الشفافية**

في PowerPoint، عندما تطبق تعبئة بلون صلب أو متدرجة أو صورة أو نقش على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في مدى وضوح التعبئة. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو الكائنات تحتها جزئيًا.

تمكنك Aspose.Slides من ضبط مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لفهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) إلى `Solid`.
1. استخدم `Color` لتحديد لون مع شفافية (مكون `alpha` يتحكم في الشفافية).
1. حفظ العرض.

الشفرة التالية Java توضح كيفية تطبيق لون تعبئة شفاف على مستطيل:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي مستطيل صلب.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // إضافة شكل تلقائي مستطيل شفاف فوق الشكل الصلب.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // حفظ ملف PPTX إلى القرص.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

تمكنك Aspose.Slides من تدوير الأشكال في عروض PowerPoint. يمكن أن يكون هذا مفيدًا عند وضع العناصر البصرية بموضع معين يتطلب محاذاة أو تصميم معين.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لفهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خاصية دوران الشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

الشفرة التالية Java توضح كيفية تدوير شكل بزاوية 5 درجات:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بزاوية 5 درجات.
    shape.setRotation(5);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات بروز ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات بروز ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات بروز ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لفهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) للشكل لتحديد إعدادات البروز.
1. حفظ العرض.

الشفرة التالية Java توضح كيفية تطبيق تأثيرات بروز ثلاثية الأبعاد على شكل:
```java
// إنشاء نسخة من فئة Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل إلى الشريحة.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // تعيين خصائص ThreeDFormat للشكل.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // حفظ العرض التقديمي كملف PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![تأثير البروز ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات تدوير ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات تدوير ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) الخاصة بها.

لتطبيق تدوير ثلاثي الأبعاد على شكل:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لفهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. استخدم [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) و[setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) لتحديد التدوير ثلاثي الأبعاد.
1. حفظ العرض.

الشفرة التالية Java توضح كيفية تطبيق تأثيرات تدوير ثلاثية الأبعاد على شكل:
```java
// إنشاء نسخة من فئة Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // حفظ العرض التقديمي كملف PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![تأثير التدوير ثلاثي الأبعاد](3D-rotation-effect.png)

## **إعادة تعيين التنسيق**

الشفرة التالية Java توضح كيفية إعادة تعيين تنسيق شريحة وإعادة موضع وحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // إعادة تعيين كل شكل على الشريحة التي تحتوي على عنصر نائب في التخطيط.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

بشكل طفيف فقط. الصور والوسائط المضمنة تشغل معظم مساحة الملف، بينما يتم تخزين معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات تعريفية ولا تضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال في شريحة التي تشترك في نفس التنسيق لتجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإعدادات الخاصة بالملء، والخط، والتأثير. إذا تطابقت جميع القيم المقابلة، فاعتبر أن أنماطها متماثلة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الأشكال المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ أشكالًا نموذجية ذات الأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وأعد تطبيق تنسيقاتها حسب الحاجة.