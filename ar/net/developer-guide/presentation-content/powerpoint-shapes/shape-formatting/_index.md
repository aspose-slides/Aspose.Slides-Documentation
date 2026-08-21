---
title: تنسيق أشكال PowerPoint في .NET
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/net/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم
- خط الشكل المرسوم
- تنسيق نمط الوصلة
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة بصورة
- تعبئة بنسيج
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بالدرجات الرمادية
- تدوير الشكل
- تأثير حافة ثلاثية الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرّف على كيفية تنسيق أشكال PowerPoint في C# باستخدام Aspose.Slides—ضبط أنماط التعبئة، الخط، والتأثيرات لملفات PPT و PPTX بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكوّن من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد إعدادات تتحكم في كيفية ملء داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides for .NET واجهات وخصائص تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل ما. الخطوات التالية توضح الإجراء:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط [نمط الخط](https://reference.aspose.com/slides/ar/net/aspose.slides/linestyle/) للشكل.
1. ضبط عرض الخط.
1. ضبط [نمط الشرط](https://reference.aspose.com/slides/ar/net/aspose.slides/linedashstyle/) للخط.
1. ضبط لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C# يوضح كيفية تنسيق شكل مستطيل `AutoShape`:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع المستطيل.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل.
    shape.FillFormat.FillType = FillType.NoFill;

    // تطبيق التنسيقات على خطوط المستطيل.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // تعيين لون الخط للمستطيل.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // حفظ ملف PPTX على القرص.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الخطوط المنسقة في العرض](formatted-lines.png)

## **تطبيق تأثيرات الرسم على خطوط الشكل**

تجعل تأثيرات الرسم خط الشكل يبدو كما لو أنه مرسوم يدويًا. استخدم [IShape.LineFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/lineformat/) للوصول إلى إعدادات الخط، و[ILineFormat.SketchFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ilineformat/sketchformat/) للوصول إلى إعدادات الرسم، و[ISketchFormat.SketchType](https://reference.aspose.com/slides/ar/net/aspose.slides/isketchformat/sketchtype/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/net/aspose.slides/linesketchtype/).

الكود التالي بلغة C# يوضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/ar/net/aspose.slides/linesketchtype/) وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/ar/net/aspose.slides/linesketchtype/):

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

القيمة التي تُرجِعها `ISketchFormat.SketchType` تمثّل الإعداد المعين مباشرةً للشكل. إذا كان يمكن وراثة تنسيق الخط من سمة، شريحة رئيسية، أو شريحة تخطيط، استخدم [ILineFormat.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/ilineformat/geteffective/)، ثم وصول إلى [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ilineformateffectivedata/sketchformat/)، وقراءة [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/ar/net/aspose.slides/isketchformateffectivedata/sketchtype/). القيمة الفعّالة تعكس التنسيق الذي يُطبّق فعليًا بعد حل وراثة الإعدادات:

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

## **تنسيق أنماط الوصلات**

إليك خيارات ثلاثة لأنواع الوصلات:

* مستدير
* ميتّر
* مائل

بشكل افتراضي، عندما يجمع PowerPoint خطين بزاوية (مثل زاوية شكل)، يستخدم الإعداد **مستدير**. ومع ذلك، إذا كنت ترسم شكلًا بزاوية حادة، قد تفضّل خيار **ميتّر**.

![نمط الوصلة في العرض](join-style-powerpoint.png)

الكود التالي بلغة C# يوضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصلة ميتّر، مائل، ومستدير:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة ثلاثة أشكال تلقائية من نوع المستطيل.
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

    // تعيين اللون لكل خط للمستطيل.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // تعيين نمط الوصلة.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // إضافة نص إلى كل مستطيل.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // حفظ ملف PPTX على القرص.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **تعبئة متدرجة**

في PowerPoint، تعبئة متدرجة هي خيار تنسيق يسمح لك بتطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بطريقة ينتقل فيها أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة متدرجة على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خاصية [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة اللونين المفضلين مع تحديد مواضعهما باستخدام دوال `Add` لمجموعة نقاط التدرج التي يوفّرها الواجهة [IGradientFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/igradientformat/).
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C# يوضح كيفية تطبيق تأثير تعبئة متدرجة على قطع ناقص:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع القطع الناقص.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق التدرج على القطع الناقص.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // ضبط اتجاه التدرج.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // إضافة نقطتي تدرج.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // حفظ ملف PPTX على القرص.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![القطع الناقص مع تعبئة متدرجة](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تعبئة بنمط هي خيار تنسيق يتيح لك تطبيق تصميم ثنائي اللون—مثل النقاط أو الخطوط أو التعرجات المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة للمقدمة والخلفية للنمط.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتحسين الجاذبية البصرية لعروضك التقديمية. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك كيفية تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خاصية [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط بنمط من الخيارات المسبقة.
1. ضبط [Background Color](https://reference.aspose.com/slides/ar/net/aspose.slides/ipatternformat/backcolor/) لخلفية النمط.
1. ضبط [Foreground Color](https://reference.aspose.com/slides/ar/net/aspose.slides/ipatternformat/forecolor/) لمقدمة النمط.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C# يوضح كيفية تطبيق تعبئة بنمط على مستطيل:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع المستطيل.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى نمط.
    shape.FillFormat.FillType = FillType.Pattern;

    // تعيين نمط النقشة.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // تعيين ألوان خلفية ومقدمة النقشة.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // حفظ ملف PPTX على القرص.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة صورة هي خيار تنسيق يسمح لك بإدراج صورة داخل شكل—بما يجعل الصورة خلفية الشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خاصية [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) للشكل إلى `Picture`.
1. ضبط وضع تعبئة الصورة إلى `Tile` (أو وضع مفضّل آخر).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. إسناد هذه الصورة إلى الخاصية `Picture.Image` لتنسيق تعبئة الصورة الخاصة بالشكل.
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

الكود التالي بلغة C# يوضح كيفية تعبئة شكل بالصورة:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع المستطيل.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // تعيين نوع التعبئة إلى صورة.
    shape.FillFormat.FillType = FillType.Picture;

    // تعيين وضع تعبئة الصورة.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // تحميل صورة وإضافتها إلى موارد العرض التقديمي.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // تعيين الصورة.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // حفظ ملف PPTX على القرص.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **استخدام صورة متكررة كقماش**

إذا أردت تعيين صورة متكررة كقماش وتخصيص سلوك التكرار، يمكنك استخدام الخصائص التالية للواجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/) والفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/picturefillmode/): يحدد وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tilealignment/): يحدد محاذاة القوالب داخل الشكل.
- [TileFlip](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tileflip/): يتحكم فيما إذا كانت القالب مقلوبة أفقيًا أو عموديًا أو كليهما.
- [TileOffsetX](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tileoffsetx/): يحدد الإزاحة الأفقية للقالب (بالنقطة) من أصل الشكل.
- [TileOffsetY](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tileoffsety/): يحدد الإزاحة العمودية للقالب (بالنقطة) من أصل الشكل.
- [TileScaleX](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tilescalex/): يحدد مقياس القالب الأفقي كنسبة مئوية.
- [TileScaleY](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tilescaley/): يحدد مقياس القالب العمودي كنسبة مئوية.

الكود التالي يوضح كيفية إضافة شكل مستطيل مع تعبئة صورة متكررة وتكوين خيارات القالب:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide firstSlide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع المستطيل.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ضبط نوع التعبئة للشكل إلى صورة.
    shape.FillFormat.FillType = FillType.Picture;

    // تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // إسناد الصورة إلى الشكل.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // تكوين وضع تعبئة الصورة وخصائص التكرار.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // حفظ ملف PPTX على القرص.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![خيارات القالب](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يملأ الشكل بلون موحَّد واحد. يتم تطبيق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خاصية [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) للشكل إلى `Solid`.
1. إسناد اللون المملأ المفضَّل إلى الشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C# يوضح كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع المستطيل.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى صلب.
    shape.FillFormat.FillType = FillType.Solid;

    // تعيين لون التعبئة.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // حفظ ملف PPTX على القرص.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عند تطبيق تعبئة بلون صلب أو متدرج أو صورة أو قوام على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في عتامة التعبئة. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح للرؤية الخلفية أو الكائنات تحتها بأن تكون مرئية جزئيًا.

تتيح لك Aspose.Slides ضبط مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خاصية [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) إلى `Solid`.
1. استخدم `Color.FromArgb(alpha, baseColor)` لتعريف لون بشفافية (مكوّن `alpha` يتحكم في الشفافية).
1. حفظ العرض.

الكود التالي بلغة C# يوضح كيفية تطبيق لون تعبئة شفاف على مستطيل:

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

    // حفظ ملف PPTX على القرص.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

تسمح لك Aspose.Slides بتدوير الأشكال في عروض PowerPoint. قد يكون ذلك مفيدًا عند وضع العناصر البصرية وفقًا لمحاذاة أو احتياجات تصميم معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط الخاصية `Rotation` للشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

الكود التالي بلغة C# يوضح كيفية تدوير شكل بزاوية 5 درجات:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع المستطيل.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بمقدار 5 درجات.
    shape.Rotation = 5;

    // حفظ ملف PPTX على القرص.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات حافة ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات حافة ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/threedformat/).

لإضافة تأثيرات حافة ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين خاصية [ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/threedformat/) للشكل لتعريف إعدادات الحافة.
1. حفظ العرض.

الكود التالي بلغة C# يوضح كيفية تطبيق تأثيرات حافة ثلاثية الأبعاد على شكل:

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

    // ضبط خصائص ThreeDFormat للشكل.
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

النتيجة:

![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/threedformat/).

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء نسخة من الفئة [العرض](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خصائص [CameraType](https://reference.aspose.com/slides/ar/net/aspose.slides/icamera/cameratype/) و[LightType](https://reference.aspose.com/slides/ar/net/aspose.slides/ilightrig/lighttype/) لتحديد دوران ثلاثي الأبعاد.
1. حفظ العرض.

الكود التالي بلغة C# يوضح كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:

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

النتيجة:

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

خاصية [IShape.BlackWhiteMode](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/blackwhitemode/) تُحدِّد كيف يُعرض شكل فردي عندما تُعرض أو تُعالج العرض في وضع الأبيض والأسود. لا تُفعِّل هذه الخاصية وضع العرض بالأبيض والأسود بحد ذاته، ولا تُغيّر تعبئة الشكل أو خطه أو تنسيقه في وضع اللون الطبيعي.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/ar/net/aspose.slides/blackwhitemode/) لاختيار السلوك المرغوب. على سبيل المثال، `Automatic` يتيح لتطبيق العرض اختيار التحويل، و`Gray` و`LightGray` يستخدمان التلوين الرمادي، و`BlackWhite` يستخدم فقط الأسود والأبيض، و`Black` و`White` يفرضان لونًا واحدًا، و`Color` يحافظ على التلوين الطبيعي، و`Hidden` يحذف الشكل في وضع الأبيض والأسود. `NotDefined` يعني عدم تعيين نمط على مستوى الشكل.

الكود التالي بلغة C# ينشئ شكلًا ملونًا ويجعله يظهر بالرمادي في وضع العرض بالأبيض والأسود:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// احتفظ بتعبئة البرتقالي في وضع اللون، ولكن اعرض الشكل بتلوين رمادي في وضع الأسود والأبيض.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

في وضع اللون الطبيعي، يحتفظ المستطيل بملئه البرتقالي. في سير عمل العرض بالأبيض والأسود، يستخدم تلوينًا رماديًا لأن وضعه مضبوط على `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل يلتزم بإعدادات العرض بالأبيض والأسود.

## **إعادة تعيين التنسيق**

الكود التالي بلغة C# يوضح كيفية إعادة تعيين تنسيق شريحة وإعادة موضع وحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // إعادة تعيين كل شكل في الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم الملف النهائي للعرض؟**

بشكل طفيف فقط. تستهلك الصور والوسائط المدمجة معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال في شريحة التي تشترك في نفس التنسيق لأتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإملأ، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقيًا، وهو ما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ أشكالًا نموذجية ذات الأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال ذات الأنماط التي تحتاجها، وأعد تطبيق تنسيقها حسب الحاجة.