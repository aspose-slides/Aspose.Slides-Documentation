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
- خط الرسم التخطيطي للشكل
- تنسيق نمط الوصل
- تعبئة التدرج
- تعبئة النمط
- تعبئة الصورة
- تعبئة النسيج
- تعبئة اللون الصلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بالتدرج الرمادي
- تدوير الشكل
- تأثير الحافة الثلاثية الأبعاد
- تأثير الدوران الثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرّف على كيفية تنسيق أشكال PowerPoint في Java باستخدام Aspose.Slides - حدد أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد الإعدادات التي تتحكم في كيفية تعبئة داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر مكتبة Aspose.Slides للغة Java واجهات وأساليب تمكنك من تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص للشكل. توضح الخطوات التالية الإجراء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // تعيين لون التعبئة للشكل المستطيل.
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

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يضيف تأثير الرسم التخطيطي مظهرًا خطًا كأنه مرسوم يدويًا. استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) للوصول إلى إعدادات الخط، و[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) للوصول إلى إعدادات الرسم التخطيطي، و[ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) لتحديد قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) .

النص التالي في Java يوضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) ، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // الوصول إلى تنسيق خط الشكل وتنسيق الرسم التخطيطي الخاص به.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // تطبيق تأثير الرسم التخطيطي.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // قراءة تأثير الرسم التخطيطي المعين مباشرةً للشكل.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // إزالة تأثير الرسم التخطيطي.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

القيمة التي تُرجعها [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/)، وادخل إلى [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/)، واقرأ [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/). القيمة الفعلية تعكس التنسيق الذي يُطبق فعليًا بعد حل الوراثة:

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

## **تنسيق أنماط الوصل**

فيما يلي خيارات ثلاثة لأنواع الوصل:

* مستدير
* محدب
* مشطوف

افتراضيًا، عندما يقوم PowerPoint بضم خطين بزاوية (مثل زاوية شكل)، يستخدم إعداد **مستدير**. ومع ذلك، إذا كنت ترسم شكلًا بزوايا حادة، قد تفضّل خيار **محدب**.

![نمط الوصل في العرض التقديمي](join-style-powerpoint.png)

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة ثلاثة أشكال تلقائية من النوع Rectangle.
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

    // تعيين نمط الوصل.
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

## **تعبئة التدرج**

في PowerPoint، تعبئة التدرج هي خيار تنسيق يتيح لك تطبيق تدرج لوني مستمر على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة تدرج على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة اللونين المفضلين لديك مع تحديد المواقع باستخدام أساليب `add` لمجموعة نقاط التدرج التي يوضحها واجهة [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/) .
1. حفظ العرض التقديمي المعدل كملف PPTX.

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق التدرج على الشكل البيضاوي.
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

![البيضاوي مع تعبئة تدرج](gradient-fill.png)

إذا كان التدرج يبدو مختلفًا في صورة مُصدَّر مقارنةً بما هو في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة التدرج المخزنة في العرض.

## **تعبئة النمط**

في PowerPoint، تعبئة النمط هي خيار تنسيق يتيح لك تطبيق تصميم ذا لونين—مثل النقاط أو الخطوط المستقيمة أو القطرات أو الشيكات—على شكل. يمكنك اختيار ألوان مخصصة لخلفية النمط ومقدمة النمط.

توفر مكتبة Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز المظهر البصري لعروضك. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب أن يستخدمها.

إليك كيفية تطبيق تعبئة نمط على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمط من الخيارات المسبقة.
1. تعيين [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) للنمط.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) للنمط.
1. حفظ العرض التقديمي المعدل كملف PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // تعيين نمط النقشة.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // تعيين ألوان الخلفية والواجهة للنقشة.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![المستطيل مع تعبئة نمط](pattern-fill.png)

## **تعبئة الصورة**

في PowerPoint، تعبئة الصورة هي خيار تنسيق يتيح لك إدراج صورة داخل شكل—وبالتالي استخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضع تعبئة الصورة إلى `Tile` (أو وضع مفضَّل آخر).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) من الصورة التي ترغب في استخدامها.
1. تمرير الصورة إلى أسلوب `ISlidesPicture.setImage`.
1. حفظ العرض التقديمي المعدل كملف PPTX.

![صورة اللوتس](lotus.png)

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
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

### **بلاطة الصورة كنقش**

إذا رغبت في تعيين صورة مبلطة كنقش وتخصيص سلوك التبليط، يمكنك استخدام الأساليب التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) : يحدد وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-) : يحدد محاذاة البلاط داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-) : يتحكم فيما إذا كان البلاط يُقلب أفقيًا أو عموديًا أو كليًا.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-) : يحدد إزاحة البلاط أفقياً (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-) : يحدد إزاحة البلاط عموديًا (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-) : يحدد مقياس البلاط الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-) : يحدد مقياس البلاط العمودي كنسبة مئوية.

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
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

![خيارات البلاط](tile-options.png)

## **تعبئة اللون الصلب**

في PowerPoint، تعبئة اللون الصلب هي خيار تنسيق يملأ الشكل بلون موحَّد واحد. يُطبَّق هذا اللون الخلفي البسيط دون أي تدرجات أو أنسجة أو أنماط.

لتطبيق تعبئة لون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين لون التعبئة المفضَّل للشكل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
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

![الشكل مع تعبئة لون صلب](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عند تطبيق تعبئة لون صلب أو تدرج أو صورة أو نسيج على الأشكال، يمكنك أيضًا تعيين مستوى الشفافية للتحكم في شفافية التعبئة. كلما ارتفعت قيمة الشفافية، أصبح الشكل أكثر شفافية، مما يسمح لرؤية الخلفية أو الكائنات السفلية جزئيًا.

تتيح لك Aspose.Slides تعيين مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك كيفية القيام بذلك:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) إلى `Solid`.
1. استخدم `Color` لتعريف لون مع شفافية (مكوّن `alpha` يتحكم في الشفافية).
1. حفظ العرض التقديمي.

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل مستطيل صلب تلقائي.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // إضافة شكل مستطيل شفاف فوق الشكل الصلب.
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

تمكِّنك Aspose.Slides من تدوير الأشكال في عروض PowerPoint. قد يكون هذا مفيدًا عند وضع عناصر بصرية بموضع معين أو لتلبية احتياجات تصميمية.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية تدوير الشكل إلى الزاوية المطلوبة.
1. حفظ العرض التقديمي.

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
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

## **إضافة تأثيرات الحواف الثلاثية الأبعاد**

تتيح لك Aspose.Slides إضافة تأثيرات حواف ثلاثية الأبعاد إلى الأشكال من خلال تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات حواف ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) للشكل لتحديد إعدادات الحافة.
1. حفظ العرض التقديمي.

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء مثيل من الفئة Presentation.
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

![تأثير الحافة الثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات الدوران الثلاثية الأبعاد**

تتيح لك Aspose.Slides إضافة تأثيرات دوران ثلاثية الأبعاد إلى الأشكال من خلال تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) الخاصة بها.

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. استخدام [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) و [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) لتحديد دوران ثلاثي الأبعاد.
1. حفظ العرض التقديمي.

```java
import com.aspose.slides.*;

// إنشاء مثيل من الفئة Presentation.
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

## **التحكم في عرض الأسود والأبيض للأشكال**

الطريقة [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) تحدد كيفية عرض شكل فردي عندما يُعرض أو يُعالج العرض التقديمي في وضع الأسود والأبيض. لا تقوم بتمكين العرض الأسود والأبيض بحد ذاته، ولا تغير تعبئة الشكل أو خطه أو أي تنسيق آخر في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `Automatic` يترك تطبيق العرض يختار التحويل، `Gray` و `LightGray` يستخدمان تلوينًا رماديًا، `BlackWhite` يستخدم فقط الأسود والأبيض، `Black` و `White` يفرضان لونًا واحدًا، `Color` يحافظ على التلوين العادي، و `Hidden` يحذف الشكل في وضع الأسود والأبيض. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // احتفظ بالتعبئة البرتقالية في وضع اللون، ولكن اعرض الشكل بتلوين رمادي في وضع الأسود والأبيض.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إعادة تعيين التنسيق**

يظهر الكود التالي في Java كيفية إعادة تعيين تنسيق شريحة وإعادة موقعها وحجمها وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) إلى الإعدادات الافتراضية لها:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // إعادة تعيين كل شكل في الشريحة التي لديها عنصر نائب في التخطيط.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض التقديمي النهائي؟**

فقط بشكل ضئيل. تحتل الصور والوسائط المضمَّنة معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا إضافيًا تقريبًا.

**كيف يمكنني اكتشاف الأشكال في شريحة التي تشترك في تنسيق متطابق حتى أتمكن من تجميعها؟**

قارن الخصائص التنسيقية الرئيسية لكل شكل — تعبئة، خط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال ذات الأنماط التي تحتاجها، ثم أعد تطبيق تنسيقها حسب الحاجة.