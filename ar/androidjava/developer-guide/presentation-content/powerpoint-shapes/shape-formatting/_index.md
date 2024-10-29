---
title: تنسيق الأشكال
type: docs
weight: 20
url: /ar/androidjava/shape-formatting/
keywords: "تنسيق الشكل، تنسيق الخطوط، تنسيق أنماط الانضمام، تعبئة تدرج الألوان، تعبئة نمط، تعبئة صورة، تعبئة لون صلب، تدوير الأشكال، تأثيرات حواف ثلاثية الأبعاد، تأثير دوران ثلاثي الأبعاد، عرض PowerPoint، Java، Aspose.Slides for Android via Java"
description: "تنسيق الشكل في عرض PowerPoint بلغة Java"
---

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكون من خطوط، يمكنك تنسيق الأشكال عن طريق تعديل أو تطبيق تأثيرات معينة على خطوطها المكونة. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد الإعدادات التي تحدد كيف يتم تعبئتها (المساحة بداخلها).

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for Android via Java** يوفر واجهات وخصائص تسمح لك بتنسيق الأشكال استنادًا إلى الخيارات المعروفة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط الخط المفضل لديك لشكل معين. توضح هذه الخطوات مثل هذا الإجراء:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) إلى الشريحة.
4. تعيين لون لخطوط الشكل.
5. تعيين العرض لخطوط الشكل.
6. تعيين [نمط الخط](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) لخط الشكل.
7. تعيين [نمط dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) لخط الشكل.
8. كتابة العرض المعدل كملف PPTX.

هذا الكود بلغة Java يوضح عملية قمنا فيها بتنسيق مستطيل `AutoShape`:

```java
// إنشاء نسخة من فئة presentation التي تمثل ملف تقديم
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع مستطيل
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // تطبيق بعض التنسيق على خطوط المستطيل
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // تعيين اللون لخط المستطيل
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // كتابة ملف PPTX إلى القرص
    pres.save("RectShpLn_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنسيق أنماط الانضمام**
هذه هي الخيارات الثلاثة لأنماط الانضمام:

* دائري
* مائل
* حواف

بشكل افتراضي، عند انضمام PowerPoint لخطين بزاوية (أو زاوية شكل)، فإنه يستخدم إعداد **D دائري**. ومع ذلك، إذا كنت ترغب في رسم شكل بزوايا حادة جدًا، فقد ترغب في اختيار **مائل**.

![join-style-powerpoint](join-style-powerpoint.png)

هذا الكود بلغة Java يوضح عملية تم فيها إنشاء ثلاثة مستطيلات (الصورة أعلاه) باستخدام إعدادات أنماط الانضمام مائل، حواف، ودائري:

```java
// إنشاء نسخة من فئة presentation التي تمثل ملف تقديم
Presentation pres = new Presentation();
try {

    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة 3 أشكال تلقائية من نوع مستطيل
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل
    shp1.getFillFormat().setFillType(FillType.Solid);
    shp1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp3.getFillFormat().setFillType(FillType.Solid);
    shp3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // تعيين عرض الخط
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);

    // تعيين اللون لخط المستطيل
    shp1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // تعيين نمط الانضمام
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // إضافة نص لكل مستطيل
    ((IAutoShape)shp1).getTextFrame().setText("نمط انضمام مائل");
    ((IAutoShape)shp2).getTextFrame().setText("نمط انضمام حواف");
    ((IAutoShape)shp3).getTextFrame().setText("نمط انضمام دائري");

    // كتابة ملف PPTX إلى القرص
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعبئة تدرج الألوان**
في PowerPoint، تعتبر تعبئة التدرج خيار تنسيق يسمح لك بتطبيق تدرج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر في إعداد يتلاشى فيه لون تدريجياً ويتحول إلى لون آخر.

هذا هو كيفية استخدام Aspose.Slides لتطبيق تعبئة التدرج على شكل:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) للشكل إلى `تدرج`.
5. إضافة لونين مفضلين لديك مع مراكز محددة باستخدام طرق `Add` المعرضة من مجموعة `GradientStops` المرتبطة بفئة `GradientFormat`.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود بلغة Java يوضح العملية حيث تمت استخدام تأثير تعبئة التدرج على شكل بيضاوي:

```java
// إنشاء نسخة من فئة presentation التي تمثل ملف تقديم
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل بيضاوي تلقائي
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // تطبيق تنسيق التدرج على الشكل البيضاوي
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // تعيين اتجاه التدرج
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // إضافة 2 تدرجات ألوان
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // كتابة ملف PPTX إلى القرص
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعبئة نمط**
في PowerPoint، تعتبر تعبئة النمط خيار تنسيق يسمح لك بتطبيق تصميم من لونين يتكون من نقاط، خطوط، أو تقاطعات على شكل. بالإضافة إلى ذلك، يمكنك اختيار الألوان المفضلة لديك لخلفية ونمط النمط.

يوفر Aspose.Slides أكثر من 45 نمطًا محددًا مسبقًا يمكن استخدامها لتنسيق الأشكال وإثراء العروض التقديمية. حتى بعد اختيار نمط محدد مسبقًا، لا يزال بإمكانك تحديد الألوان التي يجب أن يحتوي عليها النمط.

هذا هو كيفية استخدام Aspose.Slides لتطبيق تعبئة النمط على شكل:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) للشكل إلى `نمط`.
5. تعيين نمط النمط المفضل لديك للشكل.
6. تعيين [لون الخلفية](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getBackColor--) لـ [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat).
7. تعيين [لون المقدمة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getForeColor--) لـ [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat).
8. كتابة العرض المعدل كملف PPTX.

هذا الكود بلغة Java يوضح عملية حيث تم استخدام تعبئة النمط لتجميل مستطيل:

```java
// إنشاء نسخة من فئة presentation التي تمثل ملف تقديم
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل مستطيل تلقائي
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // تعيين نوع التعبئة إلى نمط
    shp.getFillFormat().setFillType(FillType.Pattern);

    // تعيين نمط النمط
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // تعيين الألوان الخلفية والأمامية للنمط
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // كتابة ملف PPTX إلى القرص
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعبئة صورة**
في PowerPoint، تعتبر تعبئة الصورة خيار تنسيق يسمح لك بوضع صورة داخل شكل. بشكل أساسي، يمكنك استخدام صورة كخلفية للشكل.

هذا هو كيفية استخدام Aspose.Slides لملء شكل بصورة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) للشكل إلى `صورة`.
5. تعيين وضع تعبئة الصورة إلى Tile.
6. إنشاء كائن `IPPImage` باستخدام الصورة التي ستستخدم لتعبئة الشكل.
7. تعيين خاصية `Picture.Image` لكائن `PictureFillFormat` إلى `IPPImage` الذي تم إنشاؤه حديثًا.
8. كتابة العرض المعدل كملف PPTX.

هذا الكود بلغة Java يوضح لك كيفية ملء شكل بصورة:

```java
// إنشاء نسخة من فئة presentation التي تمثل ملف تقديم
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل مستطيل تلقائي
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // تعيين نوع التعبئة إلى صورة
    shp.getFillFormat().setFillType(FillType.Picture);

    // تعيين وضع تعبئة الصورة
    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // تعيين الصورة
    IPPImage picture;
    IImage image = Images.fromFile("Tulips.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // كتابة ملف PPTX إلى القرص
    pres.save("RectShpPic_out.pptx", SaveFormat.Pptx);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعبئة لون صلب**
في PowerPoint، تعتبر تعبئة اللون الصلب خيار تنسيق يسمح لك بتعبئة شكل بلون واحد. اللون المختار عادة ما يكون لونًا عاديًا. يتم تطبيق اللون على خلفية الشكل مع أي تأثيرات أو تعديلات خاصة.

هذا هو كيفية استخدام Aspose.Slides لتطبيق تعبئة اللون الصلب على شكل:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) للشكل إلى `صلب`.
5. تعيين اللون المفضل لديك للشكل.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود بلغة Java يكشف لك كيفية تطبيق تعبئة اللون الصلب على مربع في PowerPoint:

```java
// إنشاء نسخة من فئة presentation التي تمثل ملف تقديم
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة شكل مستطيل تلقائي
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // تعيين نوع التعبئة إلى صلب
    shape.getFillFormat().setFillType(FillType.Solid);

    // تعيين اللون للمستطيل
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // كتابة ملف PPTX إلى القرص
    pres.save("RectShpSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين الشفافية**

في PowerPoint، عندما تقوم بتعبئة الأشكال بألوان صلبة أو تدرجات أو صور أو قوام، يمكنك تحديد مستوى الشفافية الذي يحدد عتامة التعبئة. بهذه الطريقة، على سبيل المثال، إذا قمت بتعيين مستوى شفافية منخفض، يمكن رؤية كائن الشريحة أو الخلفية وراء (الشكل).

يتيح لك Aspose.Slides تعيين مستوى الشفافية لشكل بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) إلى الشريحة.
4. استخدام `new Color` مع التركيبة ألفا مضبوطة.
5. حفظ الكائن كملف PowerPoint.

هذا الكود بلغة Java يوضح العملية:

```java
// إنشاء نسخة من فئة presentation التي تمثل ملف تقديم
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة شكل صلب
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // إضافة شكل شفاف فوق الشكل الصلب
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(204, 102, 0, 128));
    
    // كتابة ملف PPTX إلى القرص
    pres.save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تدوير الأشكال**
يتيح لك Aspose.Slides تدوير شكل تمت إضافته إلى شريحة بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) إلى الشريحة.
4. تدوير الشكل بالدرجات المطلوبة.
5. كتابة العرض المعدل كملف PPTX.

هذا الكود بلغة Java يوضح لك كيفية تدوير شكل بزاوية 90 درجة:

```java
// إنشاء نسخة من فئة presentation التي تمثل ملف تقديم
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل مستطيل تلقائي
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // تدوير الشكل بزاوية 90 درجة
    shp.setRotation(90);

    // كتابة ملف PPTX إلى القرص
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة تأثيرات حواف ثلاثية الأبعاد**
يتيح لك Aspose.Slides إضافة تأثيرات حواف ثلاثية الأبعاد إلى شكل عن طريق تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) إلى الشريحة.
4. تعيين المعلمات المفضلة لديك لخصائص [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) الخاصة بالشكل.
5. كتابة العرض إلى القرص.

هذا الكود بلغة Java يوضح لك كيفية إضافة تأثيرات حواف ثلاثية الأبعاد إلى شكل:

```java
// إنشاء نسخة من فئة Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة شكل إلى الشريحة
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // تعيين خصائص ThreeDFormat للشكل
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // كتابة العرض كملف PPTX
    pres.save("Bavel_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة تأثير دوران ثلاثي الأبعاد**
يتيح لك Aspose.Slides تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل عن طريق تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) إلى الشريحة.
4. تحديد الأشكال المفضلة لديك لـ [CameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICamera#getCameraType--) و[LightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRig#getLightType--).
5. كتابة العرض إلى القرص.

هذا الكود بلغة Java يوضح لك كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:

```java
// إنشاء نسخة من فئة Presentation
Presentation pres = new Presentation();
try {
    IShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(0, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // كتابة العرض كملف PPTX
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إعادة تعيين التنسيق**

هذا الكود بلغة Java يوضح لك كيفية إعادة تعيين التنسيق في شريحة واسترجاع الموضع والحجم والتنسيق لكل شكل له عنصر نائب على [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutSlide) إلى إعداداتهم الافتراضية:

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // كل شكل على الشريحة الذي لديه عنصر نائب على التصميم سيعاد ضبطه
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```