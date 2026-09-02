---
title: تنسيق أشكال PowerPoint في جافا
linktitle: تنسيق الأشكال
type: docs
weight: 20
url: /ar/java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم اليدوي
- خط الشكل السكتش
- تنسيق نمط الوصلة
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة بصورة
- تعبئة بنقشة
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بدرجات الرمادي
- تدوير الشكل
- تأثير الحواف الثلاثية الأبعاد
- تأثير التدوير ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- جافا
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في جافا باستخدام Aspose.Slides - حدّد أنماط التعبئة, الخط, والتأثير لملفات PPT وPPTX وODP بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال تتكوّن من خطوط، يمكنك تنسيقها من خلال تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد إعدادات تتحكم في كيفية تعبئة داخلها.

![format-shape-powerpoint](format-shape-powerpoint.png)

توفر Aspose.Slides for Java واجهات وطرق تُتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل ما. الخطوات التالية توضح الإجراء:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)‎.
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [line style](https://reference.aspose.com/slides/ar/java/com.aspose.slides/linestyle/) للشكل.
1. تحديد عرض الخط.
1. تحديد [dash style](https://reference.aspose.com/slides/ar/java/com.aspose.slides/linedashstyle/) للخط.
1. ضبط لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية توضح كيفية تنسيق مستطيل `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // تطبيق التنسيق على خطوط المستطيل.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // تحديد لون خط المستطيل.
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

## **تطبيق تأثيرات السكتش على خطوط الشكل**

تُعطي تأثيرات السكتش مظهر الخط كأنه مرسوم يدوياً. استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) للوصول إلى إعدادات الخط، و[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilineformat/) للوصول إلى إعدادات السكتش، و[ISketchFormat.setSketchType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isketchformat/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/linesketchtype/).

الشفرة التالية بلغة Java تُظهر كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/ar/java/com.aspose.slides/linesketchtype/)، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/ar/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // الوصول إلى تنسيق الخط للشكل وتنسيق السكتش الخاص به.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // تطبيق تأثير سكتش.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // قراءة تأثير السكتش المعيّن مباشرةً للشكل.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // إزالة تأثير السكتش.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

القيمة المرتجعة من [ISketchFormat.getSketchType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isketchformat/) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان تنسيق الخط يمكن أن يُورث من السمة أو الشريحة الأساسية أو شريحة التخطيط، استخدم [ILineFormat.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilineformat/)، و[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilineformateffectivedata/)، ثم اقرأ [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isketchformateffectivedata/). القيمة الفعّالة تعكس التنسيق المطبق فعلياً بعد حل الوراثة:

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

إليك ثلاثة خيارات لأنواع الوصلات:

* مستديرة
* زاوية حادة
* مائلة

بشكل افتراضي، عندما يربط PowerPoint خطين بزاوية (مثل زاوية الشكل)، يستخدم إعداد **مستديرة**. ومع ذلك، إذا كنت ترسم شكلاً بزاوئ حادة، قد تفضّل خيار **زاوية حادة**.

![The join style in the presentation](join-style-powerpoint.png)

الشفرة التالية بلغة Java تُظهر كيف تم إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصلة زاوية حادة، مائلة، ومستديرة:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة ثلاثة أشكال تلقائية من نوع المستطيل.
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

    // تعيين لون خط كل مستطيل.
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

في PowerPoint، تعد تعبئة متدرجة خيار تنسيق يسمح لك بتطبيق تدرج مستمر من الألوان على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجياً إلى الآخر.

إليك كيفية تطبيق تعبئة متدرجة على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)‎.
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة اللونين المفضلين لديك مع تحديد المواضع باستخدام طرق `add` لمجموعة نقاط التوقف المتدرجة المتوفرة عبر واجهة [IGradientFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/igradientformat/).
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية بلغة Java تُظهر كيفية تطبيق تأثير تعبئة متدرجة على إهليلج:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع الإهليلج.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق التدرج على الإهليلج.
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

![The ellipse with gradient fill](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تُتيح تعبئة بنمط لك تطبيق تصميم مكوّن من لونين—مثل النقاط أو الخطوط أو التعرجات أو الشيكات—على الشكل. يمكنك اختيار ألوان مخصصة لخلفية النمط ومقدّمته.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتحسين المظهر البصري لعروضك. حتى بعد اختيار نمط مسبق، ما زال بإمكانك تحديد الألوان الدقيقة التي سيستخدمها.

إليك كيفية تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)‎.
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط النمط من الخيارات المسبقة.
1. ضبط [Background Color](https://reference.aspose.com/slides/ar/java/com.aspose.slides/patternformat/#getBackColor--) للنمط.
1. ضبط [Foreground Color](https://reference.aspose.com/slides/ar/java/com.aspose.slides/patternformat/#getForeColor--) للنمط.
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية بلغة Java تُظهر كيفية تطبيق تعبئة بنمط على مستطيل:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى نمط.
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

![The rectangle with pattern fill](pattern-fill.png)

## **تعبئة بصورة**

في PowerPoint، تُتيح تعبئة بصورة لك إدراج صورة داخل الشكل—وبالتالي استخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة بصورة على شكل:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)‎.
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) للشكل إلى `Picture`.
1. ضبط وضع تعبئة الصورة إلى `Tile` (أو أي وضع مفضل آخر).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `ISlidesPicture.setImage`.
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![The lotus picture](lotus.png)

الشفرة التالية بلغة Java تُظهر كيفية تعبئة شكل بالصورة:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // تعيين نوع التعبئة إلى صورة.
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

![The shape with picture fill](picture-fill.png)

### **استخدام الصورة كبطانة مكررة**

إذا أردت تعيين صورة مكررة كقوام وتخصيص سلوك التكرار، يمكنك استعمال الطرق التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): يحدد وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): يحدد محاذاة المربعات داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): يتحكم فيما إذا كان المربع يُقلب أفقياً أو عمودياً أو كليهما.
- [setTileOffsetX](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): يحدد الإزاحة الأفقية للمربع (بالنقطة) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): يحدد الإزاحة الرأسية للمربع (بالنقطة) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): يعرّف مقياس المربع الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): يعرّف مقياس المربع العمودي كنسبة مئوية.

الشفرة التالية تُظهر كيف تُضيف شكلًا مستطيلًا بتعبئة صورة مكررة وتضبط خيارات المربعات:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي مستطيل.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // تعيين نوع التعبئة للشكل إلى صورة.
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

النتيجة:

![The tile options](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب تُعد خيار تنسيق يملأ الشكل بلون موحّد واحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)‎.
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين اللون المملوء المفضّل للشكل.
1. حفظ العرض المعدل كملف PPTX.

الشفرة التالية بلغة Java تُظهر كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى صلب.
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

في PowerPoint، عند تطبيق لون صلب أو تدرج أو صورة أو تعبئة قوام على الأشكال، يمكنك أيضاً تعيين مستوى الشفافية للتحكم في مدى وضوح التعبئة. كلما ارتفعت قيمة الشفافية، يصبح الشكل أكثر شفافية، مما يسمح للعمق أو الكائنات الخلفية بأن تكون مرئية جزئياً.

تسمح لك Aspose.Slides بتعيين مستوى الشفافية عن طريق تعديل قيمة alpha في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)‎.
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) إلى `Solid`.
1. استخدام `Color` لتعريف لون مع شفافية (المكوّن `alpha` يتحكم في الشفافية).
1. حفظ العرض.

الشفرة التالية بلغة Java تُظهر كيفية تطبيق لون تعبئة شفاف على مستطيل:

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

![The transparent shape](shape-transparency.png)

## **تدوير الأشكال**

يتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. قد يكون هذا مفيدًا عند ترتيب العناصر البصرية بمواضع أو تصاميم محددة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)‎.
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خاصية تدوير الشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

الشفرة التالية بلغة Java تُظهر كيفية تدوير شكل بزاوية 5 درجات:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع المستطيل.
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

## **إضافة تأثيرات ب bevel ثلاثي الأبعاد**

يتيح لك Aspose.Slides تطبيق تأثيرات bevel ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/threedformat/).

لإضافة تأثيرات bevel ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)‎.
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/threedformat/) لتحديد إعدادات bevel.
1. حفظ العرض.

الشفرة التالية بلغة Java تُظهر كيفية تطبيق تأثيرات bevel ثلاثية الأبعاد على شكل:

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

![The 3D bevel effect](3D-bevel-effect.png)

## **إضافة تأثيرات تدوير ثلاثي الأبعاد**

يتيح لك Aspose.Slides تطبيق تأثيرات تدوير ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/threedformat/).

لتطبيق تدوير ثلاثي الأبعاد على شكل:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)‎.
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. استخدم [setCameraType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icamera/#setCameraType-int-) و[setLightType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilightrig/#setLightType-int-) لتحديد التدوير ثلاثي الأبعاد.
1. حفظ العرض.

الشفرة التالية بلغة Java تُظهر كيفية تطبيق تأثيرات تدوير ثلاثية الأبعاد على شكل:

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

![The 3D rotation effect](3D-rotation-effect.png)

## **التحكم في عرض الأبيض والأسود للأشكال**

طريقة [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) تحدّد كيف يتم عرض شكل فردي عندما يُعرض أو يُعالج العرض في وضع الأبيض والأسود. لا تمكّن هذه الطريقة العرض بالأبيض والأسود بحد ذاتها، ولا تُغيّر تعبئة أو خط أو تنسيق الشكل في وضع الألوان العادية.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `Automatic` يترك لتطبيق العرض اختيار التحويل، `Gray` و`LightGray` يستخدمان اللون الرمادي، `BlackWhite` يقتصر على الأسود والأبيض، `Black` و`White` يفرضان لونًا واحدًا، `Color` يحافظ على اللون الطبيعي، و`Hidden` يُخفي الشكل في وضع الأبيض والأسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

الشفرة التالية بلغة Java تُنشئ شكلًا ملونًا وتجعله يظهر بالرمادي في وضع العرض بالأبيض والأسود:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // الاحتفاظ بملء اللون البرتقالي في وضع الألوان، لكن عرض الشكل بتلوين رمادي في وضع الأبيض والأسود.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في وضع الألوان العادية، يحتفظ المستطيل بملئه البرتقالي. في سير عمل العرض بالأبيض والأسود، يستخدم اللون الرمادي لأن وضعه عُيّن إلى `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تحديد مظهر مميز للطباعة أو المعاينة أو أي سير عمل يراعي إعدادات العرض بالأبيض والأسود.

## **إعادة ضبط التنسيق**

الشفرة التالية بلغة Java تُظهر كيفية إعادة ضبط تنسيق شريحة وإعادة موضع وحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // إعادة ضبط كل شكل في الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

بشكل طفيف فقط. تحتل الصور والوسائط المضمنة معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا ملحوظًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في نفس التنسيق لأتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإعدادات الخاصة بالملء، الخط، والتأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن الأنماط متماثلة وقم بتجميع هذه الأشكال منطقياً، ما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصّصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو في ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال المنسّقة التي تحتاجها، وأعد تطبيق تنسيقها حسب الحاجة.