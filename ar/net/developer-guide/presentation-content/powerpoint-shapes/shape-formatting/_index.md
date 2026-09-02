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
- تنسيق نمط الوصل
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة صورة
- تعبئة نقش
- تعبئة بلون صلب
- شفافية الشكل
- تدوير الشكل
- تأثير تشذيب ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في C# باستخدام Aspose.Slides — ضبط أنماط التعبئة والخط والتأثيرات لملفات PPT و PPTX بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكوّن من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد إعدادات تتحكم في كيفية ملء داخلها.

![format-shape-powerpoint](format-shape-powerpoint.png)

توفر Aspose.Slides for .NET واجهات وخصائص تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتوفرة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/ar/net/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/ar/net/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C# يوضح كيفية تنسيق شكل مستطيل `AutoShape`:

```c#
// إنشاء كائن من فئة Presentation التي تمثّل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين لون التعبئة لشكل المستطيل.
    shape.FillFormat.FillType = FillType.NoFill;

    // تطبيق تنسيق على خطوط المستطيل.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // تعيين اللون لخط المستطيل.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // حفظ ملف PPTX على القرص.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![The formatted lines in the presentation](formatted-lines.png)

## **تطبيق تأثيرات الرسم على خطوط الشكل**

تجعل تأثيرات الرسم خط الشكل يبدو كأنه مرسوم باليد. استخدم [IShape.LineFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/lineformat/) للوصول إلى إعدادات الخط، و[ILineFormat.SketchFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ilineformat/sketchformat/) للوصول إلى إعدادات الرسم، و[ISketchFormat.SketchType](https://reference.aspose.com/slides/ar/net/aspose.slides/isketchformat/sketchtype/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/net/aspose.slides/linesketchtype/) .

الكود التالي بلغة C# يوضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/ar/net/aspose.slides/linesketchtype/) ، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/ar/net/aspose.slides/linesketchtype/) :

```csharp
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

القيمة التي تُرجعها `ISketchFormat.SketchType` تمثّل الإعداد المعين مباشرةً إلى الشكل. إذا كان من الممكن أن يتم وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/ilineformat/geteffective/)، للوصول إلى [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ilineformateffectivedata/sketchformat/)، وقراءة [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/ar/net/aspose.slides/isketchformateffectivedata/sketchtype/). القيمة الفعّالة تعكس التنسيق المطبق فعليًا بعد حل الوراثة:

```csharp
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

فيما يلي خيارات ثلاثة لأنواع الوصلات:

* Round
* Miter
* Bevel

بشكل افتراضي، عندما يقوم PowerPoint بدمج خطين بزاوية (مثل زاوية شكل)، يستخدم إعداد **Round**. ومع ذلك، إذا كنت ترسم شكلًا بزاوٍ حادة، قد تفضّل خيار **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

الكود التالي بلغة C# يوضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصلة Miter و Bevel و Round:

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة ثلاثة أشكال تلقائية من النوع Rectangle.
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

    // تعيين اللون لكل خط من المستطيلات.
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

في PowerPoint، تعبئة المتدرجة هي خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة متدرجة على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة لونين مفضَّلين مع تحديد المواقع باستخدام طرق `Add` لمجموعة إيقاف المتدرجة التي يوفِّرها الواجهة [IGradientFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/igradientformat/) .
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C# يوضح كيفية تطبيق تعبئة متدرجة على شكل بيضوي:

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق التدرج على الشكل البيضاوي.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // تحديد اتجاه التدرج.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // إضافة نقطتي توقف للتدرج.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // حفظ ملف PPTX على القرص.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![The ellipse with gradient fill](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تعبئة النمط هي خيار تنسيق يتيح لك تطبيق تصميم ثنائي اللون—مثل النقاط أو الخطوط أو التعرجات المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة لخلفية النمط ومقدّمة النمط.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز الجاذبية البصرية لعروضك. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب أن يستخدمها.

إليك كيفية تطبيق تعبئة نمطية على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمط من الخيارات المسبقة.
1. تعيين [Background Color](https://reference.aspose.com/slides/ar/net/aspose.slides/ipatternformat/backcolor/) للنمط.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/ar/net/aspose.slides/ipatternformat/forecolor/) للنمط.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C# يوضح كيفية تطبيق تعبئة نمطية على مستطيل:

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // تعيين نمط النقش.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // تعيين ألوان خلفية ونص النمط.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // حفظ ملف PPTX على القرص.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![The rectangle with pattern fill](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة الصورة هي خيار تنسيق يتيح لك إدراج صورة داخل شكل—فعليًا باستخدام الصورة كخلفية الشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضع تعبئة الصورة إلى `Tile` (أو وضع آخر مفضَّل).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. إسناد هذه الصورة إلى خاصية `Picture.Image` في `PictureFillFormat` للشكل.
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![The lotus picture](lotus.png)

الكود التالي بلغة C# يوضح كيفية ملء شكل بالصورة:

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع Rectangle.
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

    // حفظ ملف PPTX على القرص.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![The shape with picture fill](picture-fill.png)

### **استخدام صورة متراكبة كنقش**

إذا كنت تريد تعيين صورة متراكبة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الخصائص التالية للواجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/picturefillmode/): يحدد وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tilealignment/): يحدد محاذاة البلاط داخل الشكل.
- [TileFlip](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tileflip/): يتحكم فيما إذا كان البلاط يُقلب أفقيا أو رأسيا أو كليهما.
- [TileOffsetX](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tileoffsetx/): يحدد إزاحة البلاط أفقيا (بنقاط) من أصل الشكل.
- [TileOffsetY](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tileoffsety/): يحدد إزاحة البلاط رأسيا (بنقاط) من أصل الشكل.
- [TileScaleX](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tilescalex/): يعرّف مقياس البلاط أفقيًا كنسبة مئوية.
- [TileScaleY](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/tilescaley/): يعرّف مقياس البلاط رأسيًا كنسبة مئوية.

الكود التالي يوضح كيفية إضافة شكل مستطيل بتعبئة صورة متكررة وتكوين خيارات البلاط:

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide firstSlide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع Rectangle.
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

![The tile options](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة اللون الصلب هي خيار تنسيق يملأ الشكل بلون موحد واحد. يُطبّق هذا اللون الخلفي البسيط دون أي تدرجات أو نقوش أو أنماط.

لتطبيق تعبئة لون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين لون التعبئة المفضَّل للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C# يوضح كيفية تطبيق تعبئة لون صلب على مستطيل في شريحة PowerPoint:

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // تعيين لون التعبئة.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // حفظ ملف PPTX على القرص.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![The shape with solid color fill](solid-color-fill.png)

## **ضبط الشفافية**

في PowerPoint، عند تطبيق لون صلب أو تعبئة متدرجة أو صورة أو نقش على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في عتامة التعبئة. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح بخلفية أو كائنات أسفلها أن تُرى جزئيًا.

تتيح لك Aspose.Slides ضبط مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) إلى `Solid`.
1. استخدم `Color.FromArgb(alpha, baseColor)` لتحديد لون بشفافية (مكوّن `alpha` يتحكم في الشفافية).
1. حفظ العرض.

الكود التالي بلغة C# يوضح كيفية تطبيق لون تعبئة شفاف على مستطيل:

```c#
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

![The transparent shape](shape-transparency.png)

## **تدوير الأشكال**

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون هذا مفيدًا عند وضع العناصر البصرية بمواضع محاذاة أو تصميم محددة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية `Rotation` للشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

الكود التالي بلغة C# يوضح كيفية تدوير شكل بزاوية 5 درجات:

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بزاوية 5 درجات.
    shape.Rotation = 5;

    // حفظ ملف PPTX على القرص.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![The shape rotation](shape-rotation.png)

## **إضافة تأثيرات تشذيب ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات تشذيب ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائصها [ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/threedformat/) .

لإضافة تأثيرات تشذيب ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين خاصية [ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/threedformat/) للشكل لتحديد إعدادات التشذيب.
1. حفظ العرض.

الكود التالي بلغة C# يوضح كيفية تطبيق تأثيرات تشذيب ثلاثية الأبعاد على شكل:

```c#
// إنشاء كائن من فئة Presentation.
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

النتيجة:

![The 3D bevel effect](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائصها [ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/threedformat/) .

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خصائص [CameraType](https://reference.aspose.com/slides/ar/net/aspose.slides/icamera/cameratype/) و[LightType](https://reference.aspose.com/slides/ar/net/aspose.slides/ilightrig/lighttype/) لتحديد دوران ثلاثي الأبعاد.
1. حفظ العرض.

الكود التالي بلغة C# يوضح كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:

```c#
// إنشاء كائن من فئة Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // حفظ العرض التقديمي كملف PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![The 3D rotation effect](3D-rotation-effect.png)

## **إعادة تعيين التنسيق**

الكود التالي بلغة C# يوضح كيفية إعادة تعيين تنسيق شريحة وإرجاع موضع وحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```c#
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

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

قليلًا فقط. الصور والوسائط المدمجة تشغل معظم مساحة الملف، بينما يتم تخزين معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا ملحوظًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في نفس التنسيق لكي أجمعها؟**

قارن خصائص التنسيق الرئيسة لكل شكل—إعدادات التعبئة، الخط، والتأثيرات. إذا تطابقت كافة القيم المقابلة، اعتبر أن أنماطها متطابقة واجمع هذه الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة نموذج أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال ذات النمط الذي تحتاجه، وأعد تطبيق تنسيقاتها أينما دُقِت الحاجة.