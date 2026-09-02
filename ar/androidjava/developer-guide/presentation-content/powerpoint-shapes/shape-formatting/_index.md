---
title: تنسيق أشكال PowerPoint على Android
linktitle: تنسيق الأشكال
type: docs
weight: 20
url: /ar/androidjava/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط الشكل الرسم التخطيطي
- تنسيق نمط الوصل
- تعبئة تدرجية
- تعبئة نمطية
- تعبئة صورة
- تعبئة قوام
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بالرمادي
- تدوير الشكل
- تأثير بروفيل ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعرّف على كيفية تنسيق أشكال PowerPoint على Android باستخدام Aspose.Slides—قم بتعيين أنماط التعبئة، الخط، والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **المقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكون من خطوط، يمكنك تنسيقها بتعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد الإعدادات التي تتحكم في كيفية ملء داخلها.

![format-shape-powerpoint](format-shape-powerpoint.png)

توفر Aspose.Slides لنظام Android عبر Java واجهات وطرق تمكّنك من تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [line style](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/linestyle/) للشكل.
1. ضبط عرض الخط.
1. ضبط [dash style](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/linedashstyle/) للخط.
1. ضبط لون الخط للشكل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

الكود التالي يُظهر كيفية تنسيق مستطيل `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // إزالة التعبئة من الشكل المستطيل بحيث تكون الخطوط فقط مرئية.
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

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

## **تطبيق تأثيرات الرسم الخطي على خطوط الشكل**

يُضفي تأثير الرسم الخطي مظهرًا يدويًا على خط الشكل. استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) للوصول إلى إعدادات الخط، و[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilineformat/) للوصول إلى إعدادات الرسم الخطي، و[ISketchFormat.setSketchType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isketchformat/) لاختيار قيمة من enumeration [LineSketchType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/linesketchtype/).

الكود Java التالي يوضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/linesketchtype/) ، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // الوصول إلى تنسيق خط الشكل وتنسيق الرسم التخطيطي الخاص به.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // تطبيق تأثير الرسم التخطيطي.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // قراءة تأثير الرسم التخطيطي المعين مباشرةً إلى الشكل.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // إزالة تأثير الرسم التخطيطي.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

القيمة التي تُعيدها [ISketchFormat.getSketchType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isketchformat/) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان يمكن أن يتم وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilineformat/)، وادخل إلى [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilineformateffectivedata/)، واقرأ [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isketchformateffectivedata/). القيمة الفعّالة تعكس التنسيق الذي يتم تطبيقه فعليًا بعد حل الوراثة:

```java
import com.aspose.slides.*;

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

إليك خيارات ثلاثة لأنواع الوصل:

* مستدير
* مِتر
* مشطوف

بشكل افتراضي، عندما يقوم PowerPoint بدمج خطين بزاوية (مثل زاوية شكل)، يستخدم الإعداد **مستدير**. ومع ذلك، إذا كنت ترسم شكلاً بزاويا حادة، قد تفضّل خيار **مِتر**.

![نمط الوصل في العرض التقديمي](join-style-powerpoint.png)

الكود Java التالي يوضح كيفية إنشاء ثلاثة مستطيلات (كما في الصورة أعلاه) باستخدام إعدادات نوع الوصل مِتر، مشطوف، ومستدير:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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

## **تعبئة تدرجية**

في PowerPoint، تعبئة تدرجية هي خيار تنسيق يتيح لك تطبيق مزج مستمر للألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

باستخدام Aspose.Slides، يمكنك تطبيق تعبئة تدرجية على شكل كما يلي:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) للشكل إلى `Gradient`.
1. أضف اللونين المفضلين لديك مع المواقع المحددة باستخدام طرق `add` في مجموعة إيقاف التدرج التي تُعرض عبر واجهة [IGradientFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/igradientformat/).
1. حفظ العرض التقديمي المعدل كملف PPTX.

الكود Java التالي يوضح كيفية تطبيق تأثير تعبئة تدرجية على إهليلج:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق تدرج على الإهليلج.
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

![الإهليلج مع تعبئة تدرجية](gradient-fill.png)

## **تعبئة نمطية**

في PowerPoint، تعبئة نمطية هي خيار تنسيق يتيح لك تطبيق تصميم ثنائي اللون—مثل النقاط أو الخطوط أو التظليل المتقاطع أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة لمقدمة النمط وخلفيته.

توفر Aspose.Slides أكثر من 45 نمطًا مبدئيًا يمكنك تطبيقها على الأشكال لتعزيز المظهر البصري لعروضك. حتى بعد اختيار نمط مبدئي، يمكنك تحديد الألوان الدقيقة التي سيستخدمها.

إليك كيفية تطبيق تعبئة نمطية على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمطي من الخيارات المبدئية.
1. ضبط [Background Color](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/patternformat/#getBackColor--) للنمط.
1. ضبط [Foreground Color](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/patternformat/#getForeColor--) للنمط.
1. حفظ العرض التقديمي المعدل كملف PPTX.

الكود Java التالي يوضح كيفية تطبيق تعبئة نمطية على مستطيل:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ضبط نوع التعبئة إلى Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // ضبط نمط النقشة.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // ضبط ألوان الخلفية والواجهة للنقشة.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![المستطيل مع تعبئة نمطية](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة صورة هي خيار تنسيق يسمح لك بإدراج صورة داخل شكل—مُستخدمًا الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) للشكل إلى `Picture`.
1. ضبط وضع تعبئة الصورة إلى `Tile` (أو وضع مفضل آخر).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `ISlidesPicture.setImage`.
1. حفظ العرض التقديمي المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصور التالية:

![صورة اللوتس](lotus.png)

الكود Java التالي يوضح كيفية تعبئة شكل بالصورة:

```java
import com.aspose.slides.*;

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

النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **استخدام صورة متكررة كقوام**

إذا أردت ضبط صورة متكررة كقوام وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/) والفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): يحدد وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): يحدد محاذاة البلاط داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): يتحكم فيما إذا كان البلاط يُقلب أفقيًا أو رأسيًا أو كليًا.
- [setTileOffsetX](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): يحدد إزاحة البلاط أفقياً (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): يحدد إزاحة البلاط عموديًا (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): يحدد مقياس البلاط أفقيًا كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): يحدد مقياس البلاط رأسيًا كنسبة مئوية.

الكود التالي يوضح كيفية إضافة شكل مستطيل مع تعبئة صورة متكررة وضبط خيارات البلاط:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ضبط نوع التعبئة للشكل إلى Picture.
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

![خيارات التكرار](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يملئ الشكل بلون موحد واحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين لون التعبئة المفضل للشكل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

الكود Java التالي يُظهر كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ضبط نوع التعبئة إلى Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // ضبط لون التعبئة.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // حفظ ملف PPTX إلى القرص.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عند تطبيق تعبئة بلون صلب أو تدرج أو صورة أو قوام على الأشكال، يمكنك أيضًا تحديد مستوى الشفافية للتحكم في شفافية التعبئة. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح بظهور الخلفية أو الكائنات الأسفل جزئيًا.

تتيح لك Aspose.Slides ضبط مستوى الشفافية عن طريق تعديل قيمة الألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) إلى `Solid`.
1. استخدام `Color` لتعريف لون مع شفافية (مكوّن `alpha` يتحكم بالشفافية).
1. حفظ العرض التقديمي.

الكود Java التالي يُظهر كيفية تطبيق لون تعبئة شفاف على مستطيل:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية وفق محاذاة أو احتياجات تصميمية معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خاصية دوران الشكل إلى الزاوية المطلوبة.
1. حفظ العرض التقديمي.

الكود Java التالي يُظهر كيفية تدوير شكل بزاوية 5 درجات:

```java
import com.aspose.slides.*;

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

النتيجة:

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات بروفيل ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات بروفيل ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/threedformat/).

لإضافة تأثيرات بروفيل ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/threedformat/) لتحديد إعدادات البروفيل.
1. حفظ العرض التقديمي.

الكود Java التالي يوضح كيفية تطبيق تأثيرات بروفيل ثلاثية الأبعاد على شكل:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء مثيل من فئة Presentation.
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

![تأثير البروفيل ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/threedformat/).

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. استخدم [setCameraType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icamera/#setCameraType-int-) و[setLightType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) لتحديد دوران ثلاثي الأبعاد.
1. حفظ العرض التقديمي.

الكود Java التالي يُظهر كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:

```java
import com.aspose.slides.*;

// إنشاء مثيل من فئة Presentation.
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

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

طريقة [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) تحدد كيفية عرض شكل فردي عندما يُشاهد أو يُعالج العرض التقديمي في وضع الأبيض والأسود. لا تُفعِّل العرض بالأبيض والأسود بحد ذاتها، ولا تُغيِّر تعبئة الشكل أو خطه أو تنسيقه في وضع الألوان العادية.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `Automatic` يتيح لتطبيق العرض اختيار التحويل، `Gray` و`LightGray` يستخدمان اللون الرمادي، `BlackWhite` يستخدم فقط الأسود والأبيض، `Black` و`White` يفرضان لونًا واحدًا، `Color` يحافظ على الألوان العادية، و`Hidden` يُخفي الشكل في وضع الأبيض والأسود. `NotDefined` يعني أنه لم يتم تعيين وضع على مستوى الشكل.

الكود Java التالي ينشئ شكلًا ملونًا ويجعله يظهر باللون الرمادي في وضع العرض بالأبيض والأسود:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // احتفظ بالتعبئة البرتقالية في وضع اللون، لكن اعرض الشكل باللون الرمادي في وضع الأبيض والأسود.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في وضع الألوان العادية، يحتفظ المستطيل بملئه البرتقالي. في سير عمل العرض بالأبيض والأسود، يستخدم اللون الرمادي لأن وضعه مضبوط على `Gray`. يتيح لك هذا الحفاظ على شريحة ملونة بالكامل مع تحديد مظهر مميز للطباعة أو المعاينة أو أي سير عمل يراعي إعدادات العرض بالأبيض والأسود.

## **إعادة ضبط التنسيق**

الكود Java التالي يُظهر كيفية إعادة ضبط تنسيق شريحة وإعادة موضع وحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // إعادة تعيين كل شكل على الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض التقديمي النهائي؟**

يتأثر ذلك بشكل طفيف فقط. تشغل الصور والوسائط المضمنة الجزء الأكبر من مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا إضافيًا ملحوظًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في تنسيق متطابق حتى أتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإعدادات الخاصة بالملء، الخط، والتأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة إلى ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ أشكالًا نموذجية بالأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال ذات الأنماط التي تحتاجها، وأعد تطبيق تنسيقها حيثما يلزم.