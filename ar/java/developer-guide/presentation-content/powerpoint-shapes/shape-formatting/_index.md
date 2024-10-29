---
title: تنسيق الأشكال
type: docs
weight: 20
url: /ar/java/shape-formatting/
keywords: "تنسيق الشكل، تنسيق الخطوط، تنسيق أنماط الانضمام، تعبئة تدرج الألوان، تعبئة نمطية، تعبئة صورة، تعبئة بلون صلب، تدوير الأشكال، تأثيرات حواف ثلاثية الأبعاد، تأثير دوران ثلاثي الأبعاد، عرض PowerPoint، Java، Aspose.Slides لـ Java"
description: "تنسيق الشكل في عرض PowerPoint باستخدام Java"
---

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال مصنوعة من خطوط، يمكنك تنسيق الأشكال عن طريق تعديل أو تطبيق تأثيرات معينة على خطوطها المكونة. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال من خلال تحديد الإعدادات التي تحدد كيفية تعبئتها (المنطقة داخلها).

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

**Aspose.Slides لـ Java** يوفر واجهات وخصائص تُتيح لك تنسيق الأشكال بناءً على الخيارات المعروفة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط الخط المفضل لديك لشكل ما. توضح هذه الخطوات مثل هذا الإجراء:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) إلى الشريحة.
4. تعيين لون لخطوط الشكل.
5. تعيين عرض لخطوط الشكل.
6. تعيين [نمط الخط](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) لخط الشكل.
7. تعيين [نمط الخط المتقطع](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) لخط الشكل.
8. كتابة العرض المعدل كملف PPTX.

يظهر هذا الرمز بلغة Java عملية قمنا فيها بتنسيق مستطيل `AutoShape`:

```java
// إنشاء مثيل من فئة العرض التقديمي الذي يمثل ملف عرض تقديمي
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
هذه هي 3 خيارات لنوع الانضمام:

* دائري
* مائل
* حواف

بشكل افتراضي، عندما ينضم PowerPoint خطان عند زاوية (أو زاوية شكل ما)، يستخدم إعداد **دائري**. ومع ذلك، إذا كنت تبحث عن رسم شكل بزوايا حادة جداً، قد ترغب في اختيار **مائل**.

![نمط الانضمام في PowerPoint](join-style-powerpoint.png)

يظهر هذا الرمز بلغة Java عملية تم فيها إنشاء 3 مستطيلات (الصورة أعلاه) مع إعدادات نوع الانضمام مائل، حواف، ودائري:

```java
// إنشاء مثيل من فئة العرض التقديمي الذي يمثل ملف عرض تقديمي
Presentation pres = new Presentation();
try {

    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة 3 أشكال تلقائية على شكل مستطيل
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

    // إضافة نص إلى كل مستطيل
    ((IAutoShape)shp1).getTextFrame().setText("نمط الانضمام المائل");
    ((IAutoShape)shp2).getTextFrame().setText("نمط الانضمام الحواف");
    ((IAutoShape)shp3).getTextFrame().setText("نمط الانضمام الدائري");

    // كتابة ملف PPTX إلى القرص
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعبئة تدرج الألوان**
في PowerPoint، تعبير تدرج الألوان هو خيار تنسيق يسمح لك بتطبيق مزيج مستمر من الألوان على شكل ما. على سبيل المثال، يمكنك تطبيق لونين أو أكثر في إعداد حيث يتلاشى لون واحد تدريجياً ويتحول إلى لون آخر.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة تدرج على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) للشكل إلى `Gradient`.
5. إضافة 2 من الألوان المفضلة لديك مع مواقع محددة باستخدام طرق `Add` المتاحة من مجموعة `GradientStops` المرتبطة بفئة `GradientFormat`.
6. كتابة العرض المعدل كملف PPTX.

يظهر هذا الرمز بلغة Java عملية تم فيها استخدام تأثير تعبئة تدرج على شكل بيضاوي:

```java
// إنشاء مثيل من فئة العرض التقديمي الذي يمثل ملف عرض تقديمي
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل بيضاوي تلقائي
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // تطبيق تنسيق التدرج على البيضاوي
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // تعيين اتجاه التدرج
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // إضافة 2 محطات تدرج
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // كتابة ملف PPTX إلى القرص
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعبئة نمطية**
في PowerPoint، تعبير التعبئة النمطية هو خيار تنسيق يسمح لك بتطبيق تصميم ثنائي اللون يتكون من نقاط، أو خطوط، أو تشكيلات متقاطعة، أو مربعات على شكل. بالإضافة إلى ذلك، يمكنك اختيار الألوان المفضلة لديك للخلفية والأمامية لنمطك.

يوفر Aspose.Slides أكثر من 45 نمطاً مسبق التحديد يمكن استخدامها لتنسيق الأشكال وزيادة قيمة العروض التقديمية. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان التي يجب أن يحتوي عليها النمط.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة نمط على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) للشكل إلى `Pattern`.
5. تعيين نمط النمط المفضل لديك للشكل. 
6. تعيين [لون الخلفية](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getBackColor--) لـ [PatternFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat).
7. تعيين [لون المقدمة](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getForeColor--) لـ [PatternFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat).
8. كتابة العرض المعدل كملف PPTX.

يظهر هذا الرمز بلغة Java عملية تم فيها استخدام التعبئة النمطية لتجميل مستطيل: 

```java
// إنشاء مثيل من فئة العرض التقديمي الذي يمثل ملف عرض تقديمي
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

    // تعيين ألوان النمط الخلفية والأمامية
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // كتابة ملف PPTX إلى القرص
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعبئة صورة**
في PowerPoint، تعبير تعبئة الصورة هو خيار تنسيق يسمح لك بوضع صورة داخل شكل ما. بشكل أساسي، يمكنك استخدام صورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتعبئة شكل بصورة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) للشكل إلى `Picture`.
5. تعيين نمط تعبئة الصورة إلى Tile.
6. إنشاء كائن `IPPImage` باستخدام الصورة التي ستستخدم لتعبئة الشكل.
7. تعيين خاصية `Picture.Image` لكائن `PictureFillFormat` على `IPPImage` الذي تم إنشاؤه حديثاً.
8. كتابة العرض المعدل كملف PPTX.

يظهر هذا الرمز بلغة Java كيفية تعبئة شكل بصورة:

```java
// إنشاء مثيل من فئة العرض التقديمي الذي يمثل ملف عرض تقديمي
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل مستطيل تلقائي
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // تعيين نوع التعبئة إلى صورة
    shp.getFillFormat().setFillType(FillType.Picture);

    // تعيين نمط تعبئة الصورة
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

## **تعبئة بلون صلب**
في PowerPoint، تعبير تعبئة بلون صلب هو خيار تنسيق يتيح لك تعبئة الشكل بلون واحد. اللون المختار هو عادةً لون عادي. يتم تطبيق اللون على خلفية الشكل مع أي تأثيرات أو تعديلات خاصة.

إليك كيفية استخدام Aspose.Slides لتطبيق التعبئة بلون صلب على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) للشكل إلى `Solid`.
5. تعيين اللون المفضل لديك للشكل.
6. كتابة العرض المعدل كملف PPTX.

يظهر هذا الرمز بلغة Java كيفية تطبيق التعبئة بلون صلب على صندوق في PowerPoint:

```java
// إنشاء مثيل من فئة العرض التقديمي الذي يمثل ملف عرض تقديمي
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

في PowerPoint، عندما تقوم بتعبئة الأشكال بألوان صلبة، أو تدرجات، أو صور، أو قوام، يمكنك تحديد مستوى الشفافية الذي يحدد درجة الشفافية للتعبئة. بهذه الطريقة، على سبيل المثال، إذا قمت بتعيين مستوى شفافية منخفض، يظهر كائن الشريحة أو الخلفية الخلفية (الشكل) من خلالها.

يتيح لك Aspose.Slides تعيين مستوى الشفافية لشكل بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) إلى الشريحة.
4. استخدم `new Color` مع مكون ألفا محدد.
5. حفظ الكائن كملف PowerPoint.

يظهر هذا الرمز بلغة Java عملية:

```java
// إنشاء مثيل من فئة العرض التقديمي الذي يمثل ملف عرض تقديمي
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
يتيح لك Aspose.Slides تدوير شكل أضيف إلى شريحة بهذه الطريقة: 

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) إلى الشريحة.
4. تدوير الشكل بالدرجات المطلوبة. 
5. كتابة العرض المعدل كملف PPTX.

يظهر هذا الرمز بلغة Java كيفية تدوير شكل بزاوية 90 درجة:

```java
// إنشاء مثيل من فئة العرض التقديمي الذي يمثل ملف عرض تقديمي
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
يتيح لك Aspose.Slides إضافة تأثيرات حواف ثلاثية الأبعاد إلى شكل عن طريق تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) الخاصة به بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) إلى الشريحة.
3. تعيين المعلمات المفضلة لديك لخصائص [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) للشكل. 
4. كتابة العرض إلى القرص.

يظهر هذا الرمز بلغة Java كيفية إضافة تأثيرات حواف ثلاثية الأبعاد إلى شكل:

```java
// إنشاء مثيل من فئة العرض التقديمي الذي يمثل ملف عرض تقديمي
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
يسمح لك Aspose.Slides بتطبيق تأثيرات دوران ثلاثي الأبعاد على شكل من خلال تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) إلى الشريحة.
3. تحديد الأشكال المفضلة لديك لـ [CameraType](https://reference.aspose.com/slides/java/com.aspose.slides/ICamera#getCameraType--) و [LightType](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRig#getLightType--).
4. كتابة العرض إلى القرص.

يظهر هذا الرمز بلغة Java كيفية تطبيق تأثيرات دوران ثلاثي الأبعاد على شكل:

```java
// إنشاء مثيل من فئة العرض التقديمي الذي يمثل ملف عرض تقديمي
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

يظهر هذا الرمز بلغة Java كيفية إعادة تعيين التنسيق في شريحة وإعادة وضع، وحجم، وتنسيق كل شكل يحتوي على موضع في [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutSlide) إلى القيم الافتراضية:

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // سيتم إعادة كل شكل على الشريحة الذي يحتوي على موضع في التخطيط إلى قيمتها الافتراضية
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```