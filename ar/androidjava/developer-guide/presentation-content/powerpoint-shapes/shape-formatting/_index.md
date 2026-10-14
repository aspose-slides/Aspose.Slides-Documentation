---
title: تنسيق أشكال PowerPoint على Android
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/androidjava/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم
- خط الشكل المرسوم
- تنسيق نمط التقاطع
- ملء تدرجي
- ملء بنمط
- ملء صورة
- ملء قوام
- ملء بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بتدرج رمادي
- تدوير الشكل
- تأثير حافة ثلاثية الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint على Android باستخدام Aspose.Slides — قم بتعيين أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال مكوَّنة من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد الإعدادات التي تتحكم في طريقة ملء داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر مكتبة Aspose.Slides for Android via Java واجهات وطرقً تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل ما. الخطوات التالية توضح الإجراء:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة معينة وفقًا لمؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدَّل كملف PPTX.

الكود التالي يوضح كيفية تنسيق شكل مستطيل `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // إزالة التعبئة من شكل المستطيل بحيث تكون الخطوط فقط مرئية.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // تطبيق تنسيق على خطوط المستطيل.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // تعيين اللون لخط المستطيل.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // حفظ ملف PPTX على القرص.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

## **تطبيق تأثيرات الرسم على خطوط الشكل**

تجعل تأثيرات الرسم الخط يبدو كأنه مرسوم يدويًا. استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) للوصول إلى إعدادات الخط، و[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) للوصول إلى إعدادات الرسم، و[ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

الكود التالي في Java يُظهر كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) وقراءة القيمة المُعيَّنة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // الوصول إلى تنسيق خط الشكل وتنسيق الرسم الخاص به.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // تطبيق تأثير رسم.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // قراءة تأثير الرسم المعين مباشرةً إلى الشكل.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // إزالة تأثير الرسم.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

القيمة التي يُرجعها [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) تمثل الإعداد المعَيَّن مباشرةً إلى الشكل. إذا كان يمكن توريث تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/)، ثم وصول إلى [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/)، وقراءة [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/). القيمة الفعلية تعكس التنسيق المطبق فعليًا بعد حل الوراثة:

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

## **تنسيق أنماط التقاطع**

فيما يلي ثلاثة خيارات لأنواع التقاطع:

* Round
* Miter
* Bevel

افتراضيًا، عندما يقوم PowerPoint بربط خطين بزاوية (مثلًا عند زاوية الشكل)، يستخدم الإعداد **Round**. ومع ذلك، إذا كنت ترسم شكلًا بزوايا حادة، قد تفضّل خيار **Miter**.

![نمط التقاطع في العرض التقديمي](join-style-powerpoint.png)

الكود التالي في Java يُظهر كيف تم إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات تقاطع Miter و Bevel و Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // تعيين نمط التقاطع.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // إضافة نص إلى كل مستطيل.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // حفظ ملف PPTX على القرص.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ملء تدرجي**

في PowerPoint، يُعد الملء التدريجي خيار تنسيق يتيح لك تطبيق تدرج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بطريقة يتلاشى فيها أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق ملء تدرجي على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لمؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة لونين مفضلين مع مواقع محددة باستخدام طرق `add` لمجموعة نقاط التدرج التي يوفّرها الواجهة [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/) .
1. حفظ العرض المعدَّل كملف PPTX.

الكود التالي في Java يُظهر كيفية تطبيق تأثير ملء تدرجي على إهليلج:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق التدرج على الشكل البيضاوي.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // تعيين اتجاه التدرج.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // إضافة نقطتي توقف للتدرج.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // حفظ ملف PPTX على القرص.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الإهليلج مع ملء تدرجي](gradient-fill.png)

إذا ظهر التدرج بشكل مختلف في الصورة المُصدَّرة مقارنةً بما هو في PowerPoint، راجع القسم [Choose a Gradient Rendering Style](/slides/ar/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير ملء التدرج المخزن في العرض.

## **ملء بنمط**

في PowerPoint، يُعد ملء النمط خيار تنسيق يتيح لك تطبيق تصميم ثنائي اللون—مثل النقاط أو الخطوط أو التعرجات المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة للخلفية واللون الأمامي للنمط.

توفر مكتبة Aspose.Slides أكثر من 45 نمط نمط مُعرَّف مسبقًا يمكنك تطبيقه على الأشكال لتعزيز المظهر البصري لعروضك التقديمية. حتى بعد اختيار نمط مُعرَّف مسبقًا، لا يزال بإمكانك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك كيفية تطبيق ملء بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لمؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمط من الخيارات المحددة مسبقًا.
1. تعيين [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) للنمط.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) للنمط.
1. حفظ العرض المعدَّل كملف PPTX.

الكود التالي في Java يُظهر كيفية تطبيق ملء بنمط على مستطيل:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ضبط نوع التعبئة إلى Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // ضبط نمط النمط.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // ضبط لون خلفية النمط ولون المقدمة.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // حفظ ملف PPTX على القرص.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![المستطيل مع ملء بنمط](pattern-fill.png)

## **ملء صورة**

في PowerPoint، يُعد ملء الصورة خيار تنسيق يتيح لك إدراج صورة داخل شكل—وبذلك تُستخدم الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق ملء صورة على شكل:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لمؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضع ملء الصورة إلى `Tile` (أو أي وضع مفضَّل آخر).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `ISlidesPicture.setImage`.
1. حفظ العرض المعدَّل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

الكود التالي في Java يُظهر كيفية ملء شكل بالصورة:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // ضبط نوع التعبئة إلى Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // ضبط وضع تعبئة الصورة.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // تحميل صورة وإضافتها إلى موارد العرض التقديمي.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // ضبط الصورة.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // حفظ ملف PPTX على القرص.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الشكل مع ملء صورة](picture-fill.png)

### **استخدام صورة متكررة كقوام**

إذا أردت ضبط صورة متكررة كقوام وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): يحدد وضع ملء الصورة — إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): يحدد محاذاة المربعات داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): يتحكم فيما إذا كانت المربعات مقلوبة أفقيًا أو عموديًا أو كلاهما.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): يحدد الإزاحة الأفقية للمربّع (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): يحدد الإزاحة العمودية للمربّع (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): يحدد مقياس المربّع الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): يحدد مقياس المربّع العمودي كنسبة مئوية.

الكود التالي يُظهر كيفية إضافة شكل مستطيل بملء صورة متكررة وتكوين خيارات التكرار:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ضبط نوع التعبئة للشكل إلى Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // إسناد الصورة إلى الشكل.
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

    // حفظ ملف PPTX على القرص.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![خيارات التكرار](tile-options.png)

## **ملء بلون صلب**

في PowerPoint، يُعد ملء اللون الصلب خيار تنسيق يملأ الشكل بلون موحد واحد. يُطبَّق هذا اللون الخلفي ببساطة دون أي تدرجات أو قوام أو أنماط.

لتطبيق ملء بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لمؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين لون التعبئة المفضل للشكل.
1. حفظ العرض المعدَّل كملف PPTX.

الكود التالي في Java يُظهر كيفية تطبيق ملء بلون صلب على مستطيل في شريحة PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ضبط نوع التعبئة إلى Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // ضبط لون التعبئة.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // حفظ ملف PPTX على القرص.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الشكل مع ملء بلون صلب](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عند تطبيق لون صلب أو تدرجي أو صورة أو قوام كملء للأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في مدى وضوح التعبئة. كلما ارتفعت قيمة الشفافية، يصبح الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو العناصر الموجودة تحته جزئيًا.

تتيح لك Aspose.Slides ضبط مستوى الشفافية عبر تعديل قيمة alpha في اللون المستخدم للملء. إليك الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لمؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) إلى `Solid`.
1. استخدام `Color` لتحديد لون مع شفافية (المكون alpha يتحكم في الشفافية).
1. حفظ العرض.

الكود التالي في Java يُظهر كيفية تطبيق لون تعبئة شفاف على مستطيل:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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

    // حفظ ملف PPTX على القرص.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **دوران الأشكال**

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. قد يكون ذلك مفيدًا عند موضع العناصر البصرية وفقًا لتصاميم أو محاذاة معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لمؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية الدوران للشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

الكود التالي في Java يُظهر كيفية تدوير شكل بمقدار 5 درجات:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بمقدار 5 درجات.
    shape.setRotation(5);

    // حفظ ملف PPTX على القرص.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات حافة ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات حافة ثلاثية الأبعاد على الأشكال عبر تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات حافة ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لمؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) للشكل لتحديد إعدادات الحافة.
1. حفظ العرض.

الكود التالي في Java يوضح كيفية تطبيق تأثيرات حافة ثلاثية الأبعاد على شكل:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عبر تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) الخاصة بها.

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة وفقًا لمؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. استخدام [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) و [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) لتحديد دوران ثلاثي الأبعاد.
1. حفظ العرض.

الكود التالي في Java يُظهر كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:

```java
import com.aspose.slides.*;

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

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

تحدد الطريقة [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) كيفية عرض شكل فردي عندما يتم عرض أو معالجة العرض في وضع الأبيض والأسود. لا تُفعِّل هذه الطريقة العرض بالأبيض والأسود بحد ذاتها، ولا تُغيّر ملء الشكل أو خطه أو تنسيقه في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `Automatic` يترك تطبيق العرض يختار التحويل، و`Gray` و`LightGray` يستخدمان اللون الرمادي، و`BlackWhite` يستخدم فقط الأسود والأبيض، و`Black` و`White` يفرضان لونًا موحدًا، و`Color` يحافظ على الألوان العادية، و`Hidden` يخفي الشكل في وضع الأبيض والأسود. `NotDefined` يعني أنه لم يتم تعيين وضع على مستوى الشكل.

الكود التالي في Java ينشئ شكلًا ملونًا ويجعله يظهر باللون الرمادي في وضع العرض بالأبيض والأسود:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // حافظ على تعبئة اللون البرتقالي في وضع الألوان، ولكن اعرض الشكل بلون رمادي في وضع الأبيض والأسود.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في وضع اللون العادي، يحتفظ المستطيل بملئه البرتقالي. في سير عمل عرض بالأبيض والأسود، يستخدم اللون الرمادي لأن وضعه مضبوط على `Gray`. يتيح لك ذلك الاحتفاظ بشريحة ملونة بالكامل مع تحديد مظهر مميز للطباعة أو المعاينة أو أي سير عمل يحترم إعدادات العرض بالأبيض والأسود للعرض.

## **إعادة ضبط التنسيق**

الكود التالي في Java يُظهر كيفية إعادة ضبط تنسيق شريحة وإرجاع الموضع والحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) إلى الإعدادات الافتراضية:

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

**هل يؤثر تنسيق الشكل على حجم الملف النهائي للعرض؟**

التأثير ضئيل فقط. تشغل الصور والوسائط المضمَّنة معظم مساحة الملف، بينما تُخزَّن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال في شريحة التي تشترك في تنسيق متطابق لتجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإعدادات الخاصة بالملء، الخط، والتأثير. إذا تطابقت جميع القيم، اعتبر أن أنماطه متماثلة وقم بتجميع تلك الأشكال منطقياً، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وطبق تنسيقها حيثما يلزم.