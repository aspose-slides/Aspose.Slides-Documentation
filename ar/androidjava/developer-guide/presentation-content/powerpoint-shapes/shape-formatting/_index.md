---
title: تنسيق أشكال PowerPoint على Android
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/androidjava/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط الشكل التخطيطي
- تنسيق نمط التقاطع
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة بصورة
- تعبئة بقوام
- تعبئة بلون صلب
- شفافية الشكل
- تدوير الشكل
- تأثير القطع الثلاثي الأبعاد
- تأثير الدوران الثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint على Android باستخدام Aspose.Slides—حدد أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال مكوّنة من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد الإعدادات التي تتحكم في كيفية ملء داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر مكتبة Aspose.Slides for Android عبر Java واجهات وطرق تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل ما. الخطوات التالية توضح العملية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة الفهرس الخاص بها.
3. إضافة كائن [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. تحديد [line style](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/linestyle/) للشكل.
5. تحديد عرض الخط.
6. تحديد [dash style](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/linedashstyle/) للخط.
7. تحديد لون الخط للشكل.
8. حفظ العرض التقديمي المعدل كملف PPTX.

الشفرة التالية توضح كيفية تنسيق مستطيل `AutoShape`:

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // تطبيق تنسيق على خطوط المستطيل.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // تعيين لون الخط للمستطيل.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

تجعل تأثيرات الرسم التخطيطي خط الشكل يبدو كأنه مرسوم يدويًا. استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) للوصول إلى إعدادات الخط، و[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilineformat/) للوصول إلى إعدادات الرسم التخطيطي، و[ISketchFormat.setSketchType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isketchformat/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/linesketchtype/).

الشفرة Java التالية توضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/linesketchtype/) ، وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/linesketchtype/) :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // الوصول إلى تنسيق خط الشكل وتنسيق الرسم التخطيطي الخاص به.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // تطبيق تأثير رسم تخطيطي.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // قراءة تأثير الرسم التخطيطي المعيّن مباشرةً على الشكل.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // إزالة تأثير الرسم التخطيطي.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

القيمة التي تُعيدها الدالة [ISketchFormat.getSketchType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isketchformat/) تمثل الإعداد المخصص مباشرةً للشكل. إذا كان يمكن أن يرث تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilineformat/)، ثم وصول إلى [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilineformateffectivedata/)، واقرأ [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isketchformateffectivedata/). القيمة الفعّالة تعكس التنسيق الذي يُطبق فعليًا بعد حل الوراثة:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **تنسيق أنماط التقاطع**

فيما يلي خيارات ثلاثة لأنواع التقاطع:

* دائري
* مِتِر
* شَبِك

بشكل افتراضي، عندما يجمع PowerPoint خطين بزاوية (مثلًا عند زاوية الشكل)، يستخدم الإعداد **دائري**. ومع ذلك، إذا كنت ترسم شكلًا بزوايا حادة، قد تفضّل خيار **مِتِر**.

![نمط التقاطع في العرض التقديمي](join-style-powerpoint.png)

الشفرة Java التالية توضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات التقاطع مِتِر، شَبِك، ودائري:

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

    // تحديد لون التعبئة لكل شكل مستطيل.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // تحديد عرض الخط.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // تحديد لون خط كل مستطيل.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // تحديد نمط التقاطع.
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

في PowerPoint، تعبئة المتدرّج هي خيار تنسيق يتيح لك تطبيق دمج مستمر للألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بطريقة يتلاشى فيها أحدهما تدريجيًا إلى الآخر.

باستخدام Aspose.Slides، يمكنك تنفيذ ذلك عبر الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة الفهرس الخاص بها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. تحديد خاصية [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) للشكل إلى `Gradient`.
5. إضافة اللونين المفضلين لديك مع تحديد المواضع باستخدام طرق `add` لمجموعة إيقاف التدرج التي يوفرها الواجهة [IGradientFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/igradientformat/) .
6. حفظ العرض التقديمي المعدل كملف PPTX.

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق متدرج على الشكل البيضاوي.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // تحديد اتجاه التدرج.
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

![القطع الناقص مع تعبئة متدرجة](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تعبئة بنمط هي خيار تنسيق يتيح لك تطبيق تصميم بلونين—مثل النقاط أو الخطوط أو التعرّجات المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة لخلفية ونص النمط.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقه على الأشكال لتعزيز المظهر البصري لعروضك التقديمية. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يستخدمها.

لتطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة الفهرس الخاص بها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. تحديد خاصية [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) للشكل إلى `Pattern`.
5. اختيار نمط النمط من الخيارات المسبقة.
6. تحديد [Background Color](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/patternformat/#getBackColor--) للنمط.
7. تحديد [Foreground Color](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/patternformat/#getForeColor--) للنمط.
8. حفظ العرض التقديمي المعدل كملف PPTX.

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // تعيين نمط النمط.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // تعيين ألوان خلفية ونص النمط.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة بصورة**

في PowerPoint، تعبئة بصورة هي خيار تنسيق يتيح لك إدراج صورة داخل شكل—مما يجعل الصورة بمثابة خلفية الشكل.

لإستخدام Aspose.Slides لتطبيق تعبئة بصورة على شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة الفهرس الخاص بها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. تحديد خاصية [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) للشكل إلى `Picture`.
5. تحديد وضع تعبئة الصورة إلى `Tile` (أو وضع مفضَل آخر).
6. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
7. تمرير الصورة إلى طريقة `ISlidesPicture.setImage` .
8. حفظ العرض التقديمي المعدل كملف PPTX.

![صورة اللوتس](lotus.png)

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
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

![الشكل مع تعبئة صورة](picture-fill.png)

### **صورة متكررة كنقش**

إذا كنت تريد تعيين صورة متكررة كنقش وتخصيص سلوك التبليط، يمكنك استخدام الطرق التالية من الواجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/) والفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): يحدد وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): يحدد محاذاة البلاط داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): يتحكم فيما إذا كان البلاط يُعكس أفقيا أو رأسيا أو كليهما.
- [setTileOffsetX](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): يحدد الإزاحة الأفقية للبلاط (بنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): يحدد الإزاحة الرأسية للبلاط (بنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): يحدد مقياس البلاط الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): يحدد مقياس البلاط الرأسي كنسبة مئوية.

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // تعيين نوع التعبئة للشكل إلى Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // تعيين الصورة إلى الشكل.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // تكوين وضع تعبئة الصورة وخصائص التبليط.
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

![خيارات التبليط](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يملأ الشكل بلون موحّد واحد. يتم تطبيق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة الفهرس الخاص بها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. تحديد خاصية [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) للشكل إلى `Solid`.
5. تعيين لون التعبئة المفضّل للشكل.
6. حفظ العرض التقديمي المعدل كملف PPTX.

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

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عند تطبيق تعبئة بلون صلب أو تدرج أو صورة أو قوام على الأشكال، يمكنك أيضًا تعيين مستوى الشفافية للتحكم في مدى شفافية التعبئة. كلما ارتفعت قيمة الشفافية، يصبح الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو الكائنات تحتها جزئيًا.

تسمح لك Aspose.Slides بتعيين مستوى الشفافية عن طريق تعديل قيمة α في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة الفهرس الخاص بها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. تحديد خاصية [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) إلى `Solid`.
5. استخدام `Color` لتحديد لون مع شفافية (مكون الـ `alpha` يتحكم في الشفافية).
6. حفظ العرض التقديمي.

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

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية بمواضع أو تصاميم محددة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة الفهرس الخاص بها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. ضبط خاصية الدوران للShape إلى الزاوية المطلوبة.
5. حفظ العرض التقديمي.

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بمقدار 5 درجات.
    shape.setRotation(5);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات القطع الثلاثي الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات القطع الثلاثي الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات القطع الثلاثي الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة الفهرس الخاص بها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/threedformat/) للShape لتحديد إعدادات القطع.
5. حفظ العرض التقديمي.

```java
// إنشاء كائن من فئة Presentation.
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

![تأثير القطع الثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات الدوران الثلاثي الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات الدوران الثلاثي الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/threedformat/) الخاصة بها.

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة الفهرس الخاص بها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. استخدام [setCameraType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icamera/#setCameraType-int-) و[setLightType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) لتحديد إعدادات الدوران الثلاثي الأبعاد.
5. حفظ العرض التقديمي.

```java
// إنشاء كائن من فئة Presentation.
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

![تأثير الدوران الثلاثي الأبعاد](3D-rotation-effect.png)

## **إعادة تعيين التنسيق**

الشفرة Java التالية توضح كيفية إعادة تعيين تنسيق شريحة وإرجاع الموقع والحجم وتنسيق جميع الأشكال التي تحتوي على عناصر نائبة على الـ [LayoutSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/layoutslide/) إلى الإعدادات الافتراضية لها:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // إعادة تعيين كل شكل في الشريحة التي لديها عنصر نائب على التخطيط.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض التقديمي النهائي؟**

بشكل طفيف فقط. الصور والوسائط المضمنة تشغل معظم مساحة الملف، بينما معاملات الشكل مثل الألوان والتأثيرات والتدرجات تُخزن كبيانات وصفية وتضيف حجمًا ضئيلًا تقريبًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في تنسيق متطابق حتى أتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل — إعدادات التعبئة، الخط، والتأثيرات. إذا تطابقت جميع القيم المقابلة، اعتبر أن الأنماط متطابقة وجمّع تلك الأشكال معًا لتبسيط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ أشكالًا نموذجية تحمل الأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال ذات الأنماط التي تحتاجها، وأعد تطبيق تنسيقاتها حسب الحاجة.