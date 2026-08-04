---
title: تنسيق أشكال PowerPoint في Java
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط الشكل التخطيطي
- تنسيق نمط الوصلة
- تعبئة تدرجية
- تعبئة نمطية
- تعبئة صورة
- تعبئة نسيج
- تعبئة لون صلب
- شفافية الشكل
- تدوير الشكل
- تأثير تقويس ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- باور بوينت
- عرض تقديمي
- جافا
- Aspose.Slides
description: تعلم كيفية تنسيق أشكال PowerPoint في Java باستخدام Aspose.Slides—حدد أنماط التعبئة والحدود والتأثيرات لملفات PPT و PPTX و ODP بدقة وتحكم كامل.
---
## **المقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال تتكوّن من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد إعدادات تتحكم في طريقة ملء داخلها.

![format-shape-powerpoint](format-shape-powerpoint.png)

توفر Aspose.Slides for Java واجهات وأساليب تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل ما. الخطوات التالية توضح الإجراء:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [line style](https://reference.aspose.com/slides/ar/java/com.aspose.slides/linestyle/) للشكل.
1. ضبط عرض الخط.
1. ضبط [dash style](https://reference.aspose.com/slides/ar/java/com.aspose.slides/linedashstyle/) للخط.
1. ضبط لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح كيفية تنسيق `AutoShape` على شكل مستطيل:

```java
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // تطبيق التنسيق على خطوط المستطيل.
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

![The formatted lines in the presentation](formatted-lines.png)

## **تطبيق تأثيرات الرسم اليدوي على خطوط الشكل**

تجعل تأثيرات الرسم اليدوي خط الشكل يبدو وكأنه مرسم يدويًا. استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) للوصول إلى إعدادات الخط، و[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilineformat/) للوصول إلى إعدادات الرسم اليدوي، و[ISketchFormat.setSketchType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isketchformat/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/linesketchtype/).

الكود التالي بالـ Java يوضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/ar/java/com.aspose.slides/linesketchtype/)، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/ar/java/com.aspose.slides/linesketchtype/) :

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

القيمة التي يرجعها [ISketchFormat.getSketchType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isketchformat/) تمثل الإعداد المعين مباشرةً للشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilineformat/)، وادخل إلى [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilineformateffectivedata/)، واقرأ [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isketchformateffectivedata/). القيمة الفعّالة تعكس التنسيق الذي يُطبق فعليًا بعد حل الوراثة:

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

## **تنسيق أنماط الوصلات**

هناك ثلاثة خيارات لأنواع الوصلات:

* Round
* Miter
* Bevel

افتراضيًا، عند وصل PowerPoint خطين بزاوية (مثلًا عند زاوية الشكل)، يستخدم الإعداد **Round**. ولكن إذا كنت ترسم شكلًا بزوايا حادة، قد تفضّل خيار **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

الكود التالي بالـ Java يوضح كيفية إنشاء ثلاثة مستطيلات (كما في الصورة أعلاه) باستخدام إعدادات الوصلات Miter وBevel وRound:

```java
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
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

## **تعبئة تدرجية**

في PowerPoint، تعبئة التدرج هي خيار تنسيق يسمح لك بتطبيق مزيج مستمر من الألوان على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة تدرجية على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط الخاصية [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة اللونين المفضلين مع تحديد مواضعهما باستخدام أساليب `add` لمجموعة نقاط التدرج التي يوفّرها واجهة [IGradientFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/igradientformat/) .
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بالـ Java يوضح كيفية تطبيق تأثير تعبئة تدرجية على شكل إهليلجي:

```java
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق تدرج على الشكل البيضاوي.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // تعيين اتجاه التدرج.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // إضافة نقطتي تدرج.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The ellipse with gradient fill](gradient-fill.png)

## **تعبئة نمطية**

في PowerPoint، تعبئة نمطية هي خيار تنسيق يتيح لك تطبيق تصميم ذو لونين—مثل النقاط أو الخطوط أو القطرات المتقاطعة أو المربعات—على الشكل. يمكنك اختيار ألوان مخصصة لخلفية ونمط الأمام.

توفر Aspose.Slides أكثر من 45 نمطًا نمطيًا محددًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز مظهر عروضك. حتى بعد اختيار نمط نمطي محدد مسبقًا، يمكنك تحديد الألوان الدقيقة التي يجب أن يستخدمها.

إليك كيفية تطبيق تعبئة نمطية على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط الخاصية [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمطي من الخيارات المحددة مسبقًا.
1. ضبط [Background Color](https://reference.aspose.com/slides/ar/java/com.aspose.slides/patternformat/#getBackColor--) للنمط.
1. ضبط [Foreground Color](https://reference.aspose.com/slides/ar/java/com.aspose.slides/patternformat/#getForeColor--) للنمط.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بالـ Java يوضح كيفية تطبيق تعبئة نمطية على مستطيل:

```java
    // إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
    Presentation presentation = new Presentation();
    try {
        // الحصول على الشريحة الأولى.
        ISlide slide = presentation.getSlides().get_Item(0);

        // إضافة شكل تلقائي من نوع Rectangle.
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

        // تعيين نوع التعبئة إلى Pattern.
        shape.getFillFormat().setFillType(FillType.Pattern);

        // تعيين نمط النقش.
        shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

        // تعيين ألوان خلفية ونص النقش.
        shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
        shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

        // حفظ ملف PPTX إلى القرص.
        presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

النتيجة:

![The rectangle with pattern fill](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة الصورة هي خيار تنسيق يسمح لك بإدراج صورة داخل شكل—بمعنى استخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط الخاصية [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) للشكل إلى `Picture`.
1. ضبط وضع تعبئة الصورة إلى `Tile` (أو أي وضع آخر مفضل).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى الطريقة `ISlidesPicture.setImage`.
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف “lotus.png” بالصورة التالية:

![The lotus picture](lotus.png)

الكود التالي بالـ Java يوضح كيفية تعبئة شكل بالصورة:

```java
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
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

    // تحميل صورة وإضافتها إلى موارد العرض.
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

![The shape with picture fill](picture-fill.png)

### **استخدام صورة متكررة كنقش**

إذا أردت تعيين صورة مكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الأساليب التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): يضبط وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): يحدد محاذاة المربعات داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): يتحكم فيما إذا كانت المربعات مقلوبة أفقيًا أو رأسيًا أو كلاهما.
- [setTileOffsetX](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): يضبط الإزاحة الأفقية للمربع (بالنقطة) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): يضبط الإزاحة الرأسية للمربع (بالنقطة) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): يحدد مقياس المربع الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): يحدد مقياس المربع الرأسي كنسبة مئوية.

الكود التالي يوضح كيفية إضافة شكل مستطيل مع تعبئة صورة متكررة وتكوين خيارات التكرار:

```java
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // تعيين نوع التعبئة للشكل إلى Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // تحميل الصورة وإضافتها إلى موارد العرض.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // تعيين الصورة إلى الشكل.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // تهيئة وضع تعبئة الصورة وخصائص التكرار.
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

![The tile options](tile-options.png)

## **تعبئة لون صلب**

في PowerPoint، تعبئة اللون الصلب هي خيار تنسيق يملأ الشكل بلون واحد موحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو نقوش أو أنماط.

لتطبيق تعبئة لون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط الخاصية [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين لون التعبئة المفضل للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بالـ Java يوضح كيفية تطبيق تعبئة لون صلب على مستطيل في شريحة PowerPoint:

```java
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
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

![The shape with solid color fill](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عند تطبيق تعبئة صلبة أو تدرجية أو صورة أو نقش على الأشكال، يمكنك أيضًا تعيين مستوى الشفافية للتحكم في قاتمة التعبئة. كلما ارتفعت قيمة الشفافية، أصبح الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو الكائنات الموجودة تحته جزئيًا.

تتيح Aspose.Slides لك تعيين مستوى الشفافية عبر تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط الخاصية [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) إلى `Solid`.
1. استخدم `Color` لتعريف لون مع شفافية (مكوّن `alpha` يتحكم في الشفافية).
1. حفظ العرض.

الكود التالي بالـ Java يوضح كيفية تطبيق لون تعبئة شفاف على مستطيل:

```java
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
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

![The transparent shape](shape-transparency.png)

## **تدوير الأشكال**

تتيح Aspose.Slides لك تدوير الأشكال في عروض PowerPoint. يمكن أن يكون هذا مفيدًا عند وضع العناصر البصرية بموضع معين أو لتلبية احتياجات تصميمية معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خاصية الدوران للshape إلى الزاوية المطلوبة.
1. حفظ العرض.

الكود التالي بالـ Java يوضح كيفية تدوير شكل بزاوية 5 درجات:

```java
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
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

![The shape rotation](shape-rotation.png)

## **إضافة تأثيرات تقويس ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات تقويس ثلاثية الأبعاد على الأشكال عبر تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات تقويس ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/threedformat/) للشكل لتحديد إعدادات التقويس.
1. حفظ العرض.

الكود التالي بالـ Java يوضح كيفية تطبيق تأثيرات تقويس ثلاثية الأبعاد على شكل:

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

    // ضبط خصائص ThreeDFormat للشكل.
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

![The 3D bevel effect](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عبر تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/threedformat/) الخاصة بها.

للتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. استخدم [setCameraType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icamera/#setCameraType-int-) و[setLightType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilightrig/#setLightType-int-) لتعريف دوران ثلاثي الأبعاد.
1. حفظ العرض.

الكود التالي بالـ Java يوضح كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:

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

النتيجة:

![The 3D rotation effect](3D-rotation-effect.png)

## **إعادة تعيين التنسيق**

الكود التالي بالـ Java يوضح كيفية إعادة تعيين تنسيق شريحة وإرجاع الموضع والحجم وتنسيق جميع الأشكال التي تحتوي على عناصر نائب على [LayoutSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // إعادة تعيين كل شكل في الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

يتأثر بحجم قليل فقط. الصور والوسائط المضمنة هي التي تشغل معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا ملحوظًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في نفس التنسيق لأتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإعدادات الخاصة بالملء، والحدود، والتأثيرات. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال المصممة التي تحتاجها، وأعد تطبيق تنسيقاتها حسب الحاجة.