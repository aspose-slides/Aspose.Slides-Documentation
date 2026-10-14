---
title: تنسيق أشكال PowerPoint في .NET
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/net/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط شكل تخطيطي
- تنسيق نمط الانضمام
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة صورة
- تعبئة نسيجية
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بدرجات الرمادي
- تدوير الشكل
- تأثير الإمالة ثلاثية الأبعاد
- تأثير الدوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint باستخدام C# و Aspose.Slides — اضبط أنماط التعبئة، الخط، والتأثير لملفات PPT و PPTX بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال مكوَّنة من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد الإعدادات التي تتحكم في كيفية ملء داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides for .NET واجهات وخصائص تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة عن طريق فهرستها.
1. أضف [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [نمط الخط](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [نمط الشرط](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل.
    shape.FillFormat.FillType = FillType.NoFill;

    // تطبيق التنسيق على خطوط المستطيل.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // تعيين لون خط المستطيل.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

![الخطوط المنسقة في العرض](formatted-lines.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُضيف تأثير الرسم التخطيطي مظهرًا يدويًا لخط الشكل. استخدم [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) للوصول إلى إعدادات الخط، واستخدم [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) للوصول إلى إعدادات الرسم التخطيطي، واستخدم [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

الكود C# التالي يوضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

القيمة التي تُرجعها `ISketchFormat.SketchType` تمثل الإعداد المعين مباشرةً للشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/)، واطلب الوصول إلى [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/)، وقراءة [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). تمثل القيمة الفعلية التنسيق الذي يتم تطبيقه فعليًا بعد حل الوراثة:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **تنسيق أنماط الانضمام**

فيما يلي خيارات ثلاثة لأنواع الانضمام:

* مستدير
* قاطع
* منحدر

بشكل افتراضي، عندما يقوم PowerPoint بضم خطين بزاوية (مثلًا عند زاوية الشكل)، يستخدم الإعداد **مستدير**. ومع ذلك، إذا كنت ترسم شكلًا بزاويا حادة، قد تفضّل خيار **قاطع**.

![نمط الانضمام في العرض](join-style-powerpoint.png)

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة ثلاثة أشكال تلقائية من نوع Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // تعيين لون التعبئة لكل شكل مستطيل.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // تعيين عرض الخط.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // تعيين اللون لكل خط في المستطيلات.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // تعيين نمط الانضمام.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // إضافة نص إلى كل مستطيل.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **تعبئة متدرجة**

في PowerPoint، تعبئة التدرج هي خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بطريقة يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة متدرجة على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة عن طريق فهرستها.
1. أضف [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. أضف لونين مفضلين لديك مع تحديد المواقع باستخدام طرق `Add` لمجموعة نقاط التدرج التي ي exposeها واجهة [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. حفظ العرض المعدل كملف PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق تدرج على الشكل البيضاوي.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // تعيين اتجاه التدرج.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // إضافة نقطتي تدرج.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

![الإهليلج مع تعبئة متدرجة](gradient-fill.png)

إذا كان التدرج يبدو مختلفًا في صورة مُصدَّرة مقارنةً بما هو عليه في PowerPoint، راجع [اختر نمط عرض التدرج](/slides/ar/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة التدرج المخزنة في العرض.

## **تعبئة بنمط**

في PowerPoint، تعبئة النمط هي خيار تنسيق يتيح لك تطبيق تصميم ذو لونين — مثل النقاط أو الخطوط أو الشرائط المتقاطعة أو المربعات — على شكل. يمكنك اختيار ألوان مخصصة للجزء الأمامي والخلفي للنمط.

توفر Aspose.Slides أكثر من 45 نمطًا مُعرَّفًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز الجاذبية البصرية لعروضك التقديمية. حتى بعد اختيار نمط مُعرَّف مسبقًا، يمكنك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك كيفية تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة عن طريق فهرستها.
1. أضف [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط النمط من الخيارات المُعرَّفة مسبقًا.
1. تعيين [لون الخلفية](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) للنمط.
1. تعيين [لون المقدمة](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) للنمط.
1. حفظ العرض المعدل كملف PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // تعيين نمط النمط.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // تعيين ألوان الخلفية والأمامية للنمط.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

![المستطيل بتعبئة بنمط](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة الصورة هي خيار تنسيق يتيح لك إدراج صورة داخل شكل — وبالتالي استخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة عن طريق فهرستها.
1. أضف [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضع تعبئة الصورة إلى `Tile` (أو وضع آخر مفضل).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. تعيين هذه الصورة إلى خاصية `Picture.Image` في `PictureFillFormat` للshape.
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" يحتوي على الصورة التالية:

![صورة اللوتس](lotus.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // تعيين نوع التعبئة إلى Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // تعيين وضع تعبئة الصورة.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // تحميل صورة وإضافتها إلى موارد العرض التقديمي.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // تعيين الصورة.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

![الشكل بتعبئة صورة](picture-fill.png)

### **استخدام صورة متكررة كنقش**

إذا كنت ترغب في تعيين صورة متكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الخصائص التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) والفئة [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): تحدد وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): تحدد محاذاة البلاط داخل الشكل.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): تتحكم ما إذا كان البلاط يُقلب أفقياً أو رأسياً أو كليهما.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): تحدد الإزاحة الأفقية للبلاط (بالنقاط) من أصل الشكل.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): تحدد الإزاحة العمودية للبلاط (بالنقاط) من أصل الشكل.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): تحدد مقياس البلاط الأفقي كنسبة مئوية.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): تحدد مقياس البلاط العمودي كنسبة مئوية.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide firstSlide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // تعيين نوع التعبئة للشكل إلى Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // تعيين الصورة إلى الشكل.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // تهيئة وضع تعبئة الصورة وخصائص التبليط.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

![خيارات البلاط](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يملأ الشكل بلون واحد موحد. يتم تطبيق هذا اللون الخلفي البسيط دون أي تدرجات أو خامات أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة عن طريق فهرستها.
1. أضف [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين لون التعبئة المفضل للshape.
1. حفظ العرض المعدل كملف PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // تعيين لون التعبئة.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

![الشكل بتعبئة بلون صلب](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عند تطبيق لون صلب أو تعبئة متدرجة أو صورة أو خامة على أشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في مدى وضوح التعبئة. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح للرؤية الخلفية أو الكائنات الأسفل بأن تكون مرئية جزئيًا.

تتيح Aspose.Slides ضبط مستوى الشفافية من خلال تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك كيفية القيام بذلك:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة عن طريق فهرستها.
1. أضف [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) إلى `Solid`.
1. استخدم `Color.FromArgb(alpha, baseColor)` لتعريف لون مع شفافية (مكون `alpha` يتحكم في الشفافية).
1. حفظ العرض.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي مستطيل صلب.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // إضافة شكل تلقائي مستطيل شفاف فوق الشكل الصلب.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

تتيح Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية بمواضع محاذاة أو تصميم محددة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة عن طريق فهرستها.
1. أضف [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية `Rotation` للshape إلى الزاوية المطلوبة.
1. حفظ العرض.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بزاوية 5 درجات.
    shape.Rotation = 5;

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات إمالة ثلاثية الأبعاد**

تسمح Aspose.Slides لك بتطبيق تأثيرات إمالة ثلاثية الأبعاد على الأشكال عبر إعداد خصائص [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

لإضافة تأثيرات إمالة ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة عن طريق فهرستها.
1. أضف [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) للshape لتحديد إعدادات الإمالة.
1. حفظ العرض.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء نسخة من فئة Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة شكل إلى الشريحة.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // تعيين خصائص ThreeDFormat للشكل.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // حفظ العرض التقديمي كملف PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

![تأثير الإمالة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تسمح Aspose.Slides لك بتطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عبر إعداد خصائص [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة عن طريق فهرستها.
1. أضف [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) و[LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) للshape لتحديد الدوران ثلاثي الأبعاد.
1. حفظ العرض.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء نسخة من فئة Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // حفظ العرض التقديمي كملف PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

![تأثير دوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

خاصية [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) تحدد كيف يتم عرض شكل فردي عندما يتم مشاهدة أو معالجة عرض تقديمي بوضعية الأبيض والأسود. لا تمكّن العرض بالأبيض والأسود بحد ذاتها، ولا تغيّر تعبئة الشكل أو خطه أو تنسيقه الآخر في وضع اللون العادي.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) لاختيار السلوك المطلوب. على سبيل المثال، `Automatic` يتيح لتطبيق العرض اختيار التحويل، `Gray` و `LightGray` يستخدمان تلوينًا رماديًا، `BlackWhite` يستخدم فقط الأسود والأبيض، `Black` و `White` يفرضان لونًا موحدًا، `Color` يحافظ على تلوين عادي، و `Hidden` يستبعد الشكل في وضعية الأبيض والأسود. `NotDefined` يعني أنه لا يتم تعيين وضع على مستوى الشكل.

الكود C# التالي ينشئ شكلاً ملونًا ويجعل ظهوره رماديًا في وضع العرض بالأبيض والأسود:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// احتفظ بتعبئة اللون البرتقالي في وضع اللون، لكن عرض الشكل باللون الرمادي في وضع الأبيض والأسود.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

في وضع اللون الطبيعي، يحتفظ المستطيل بملئه البرتقالي. في سير عمل عرض بالأبيض والأسود، يستخدم تلوينًا رماديًا لأن وضعيته مضبوطة على `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تحديد مظهر متميز للطباعة أو المعاينة أو أي سير عمل يلتزم بإعدادات العرض بالأبيض والأسود للعرض.

## **إعادة تعيين التنسيق**

الكود C# التالي يوضح كيفية إعادة تعيين تنسيق شريحة وإرجاع موضع وحجم وتنسيق جميع الأشكال ذات القوالب في [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // إعادة تعيين كل شكل على الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

قليلًا فقط. الصور والوسائط المدمجة تشغل معظم مساحة الملف، بينما يتم تخزين معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا إضافيًا تقريبًا.

**كيف يمكنني اكتشاف الأشكال في شريحة تشترك في نفس التنسيق حتى أتمكن من تجميعها؟**

قارن الخصائص التنسيقية الرئيسية لكل شكل — إعدادات التعبئة، الخط، والتأثير. إذا تطابقت جميع القيم المقابلة، فاعتبر أن أنماطه متطابقة وقم بتجميع تلك الأشكال منطقياً، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ أشكالًا نموذجية بالأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المبنية بالأنماط التي تحتاجها، وأعد تطبيق تنسيقها حيثما يلزم.