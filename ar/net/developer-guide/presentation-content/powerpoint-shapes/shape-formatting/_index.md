---
title: تنسيق أشكال PowerPoint في .NET
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/net/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تنسيق نمط الوصل
- ملء تدرجي
- ملء بنمط
- ملء صورة
- ملء نسيج
- ملء لون صلب
- شفافية الشكل
- تدوير الشكل
- تأثير حافة ثلاثية الأبعاد
- تأثير تدوير ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في C# باستخدام Aspose.Slides—قم بتعيين أنماط الملء والخط والتأثير لملفات PPT و PPTX بدقة وتحكم كامل."
---

## **نظرة عامة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد الإعدادات التي تتحكم في كيفية ملء داخليتها.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET توفر الواجهات والخصائص التي تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص للشكل. الخطوات التالية توضح الإجراء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على إشارة إلى شريحة حسب مؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [نمط الخط](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [نمط الشرط](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

الكود التالي بلغة C# يوضح كيفية تنسيق `AutoShape` مستطيل:
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع مستطيل.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين لون التعبئة للشكل المستطيل.
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

## **تنسيق أنماط الوصل**

فيما يلي ثلاثة خيارات لنوع الوصل:

* Round
* Miter
* Bevel

إفتراضيًا، عندما يقوم PowerPoint بدمج خطين بزاوية (مثل زاوية شكل)، يستخدم إعداد **Round**. ومع ذلك، إذا كنت ترسم شكلًا بزاويات حادة، قد تفضل خيار **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

الكود التالي بلغة C# يوضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصل Mitter و Bevel و Round:
```c#
 // إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
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

     // تعيين اللون لكل خط من المستطيل.
     shape1.LineFormat.FillFormat.FillType = FillType.Solid;
     shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
     shape2.LineFormat.FillFormat.FillType = FillType.Solid;
     shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
     shape3.LineFormat.FillFormat.FillType = FillType.Solid;
     shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

     // تعيين نمط الوصل.
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


## **Gradient Fill**

في PowerPoint، يُعد Gradient Fill خيار تنسيق يتيح لك تطبيق مزيج متواصل من الألوان على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بطريقة يتلاشى فيها أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق ملء تدرجي على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على إشارة إلى شريحة حسب مؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. عيّن [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. أضف اللونين المفضلين لديك مع المواقع المحددة باستخدام طرق `Add` لمجموعة إيقاف التدرج التي تكشف عنها الواجهة [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. حفظ العرض التقديمي المعدل كملف PPTX.

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع إهليلجي.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق تدرج على الإهليلج.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // تعيين اتجاه التدرج.
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

## **Pattern Fill**

في PowerPoint، يُعد Pattern Fill خيار تنسيق يتيح لك تطبيق تصميم ذا لونين—مثل النقاط أو الخطوط أو التعرجات أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة لمقدمة وخلفية النمط.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتحسين جاذبية عروضك بصريًا. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك كيفية تطبيق نمط ملء على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على إشارة إلى شريحة حسب مؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. عيّن [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختر نمطًا من الخيارات المسبقة.
1. عيّن [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) للنمط.
1. عيّن [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) للنمط.
1. حفظ العرض التقديمي المعدل كملف PPTX.

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع مستطيل.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين نوع التعبئة إلى نمط.
    shape.FillFormat.FillType = FillType.Pattern;

    // تعيين نمط النمط.
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

## **Picture Fill**

في PowerPoint، يُعد Picture Fill خيار تنسيق يتيح لك إدراج صورة داخل شكل—وبالتالي استخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق ملء صورة على شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على إشارة إلى شريحة حسب مؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. عيّن [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Picture`.
1. عيّن وضع ملء الصورة إلى `Tile` (أو وضع آخر مفضل).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. اسند هذه الصورة إلى خاصية `Picture.Image` في `PictureFillFormat` الخاص بالشكل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

الكود التالي بلغة C# يوضح كيفية ملء شكل بالصورة:
```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع مستطيل.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // تعيين نوع التعبئة إلى صورة.
    shape.FillFormat.FillType = FillType.Picture;

    // تعيين وضع ملء الصورة.
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

### **Tile Picture As Texture**

إذا كنت ترغب في تعيين صورة مكررة كملمس وتخصيص سلوك التبليط، يمكنك استخدام الخصائص التالية للواجهة [IPictureFillFormat] والصف [PictureFillFormat]:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): يحدد وضع ملء الصورة — إما `Tile` أو `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): يبين محاذاة البلاط داخل الشكل.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): يتحكم فيما إذا كان البلاط يُقلب أفقيًا أو عموديًا أو كليهما.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): يحدد الإزاحة الأفقية للبلاط (بالنقاط) من أصل الشكل.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): يحدد الإزاحة العمودية للبلاط (بالنقاط) من أصل الشكل.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): يحدد مقياس البلاط الأفقي كنسبة مئوية.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): يحدد مقياس البلاط العمودي كنسبة مئوية.

الكود التالي يوضح كيفية إضافة شكل مستطيل بملء صورة مكررة وتكوين خيارات البلاط:
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide firstSlide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع المستطيل.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // تعيين نوع التعبئة للشكل إلى صورة.
    shape.FillFormat.FillType = FillType.Picture;

    // تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // تعيين الصورة إلى الشكل.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // تكوين وضع ملء الصورة وخصائص التبليط.
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

## **Solid Color Fill**

في PowerPoint، يُعد Solid Color Fill خيار تنسيق يملأ الشكل بلون موحد واحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو أنماط.

لتطبيق ملء بلون صلب على شكل باستخدام Aspose.Slides، اتبع هذه الخطوات:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على إشارة إلى شريحة حسب مؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. عيّن [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Solid`.
1. اسند اللون المفضل كملء للشكل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

```c#
 // إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
 using (Presentation presentation = new Presentation())
 {
     // الحصول على الشريحة الأولى.
     ISlide slide = presentation.Slides[0];

     // إضافة شكل تلقائي من النوع مستطيل.
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

![The shape with solid color fill](solid-color-fill.png)

## **Set Transparency**

في PowerPoint، عند تطبيق ملء بلون صلب أو تدرج أو صورة أو نقش على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في مدى شفافية الملء. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو الكائنات الأساسية جزئيًا.

تمكنك Aspose.Slides من ضبط مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للملء. إليك الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على إشارة إلى شريحة حسب مؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. عيّن [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) إلى `Solid`.
1. استخدم `Color.FromArgb(alpha, baseColor)` لتعريف لون مع شفافية (مكوّن ألفا يتحكم في الشفافية).
1. حفظ العرض التقديمي.

```c#
const int alpha = 128;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
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

## **Rotate Shapes**

تمكنك Aspose.Slides من تدوير الأشكال في عروض PowerPoint. قد يكون ذلك مفيدًا عند وضع العناصر المرئية مع احتياجات محاذاة أو تصميم معينة.

لتدوير شكل على شريحة، اتبع هذه الخطوات:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على إشارة إلى شريحة حسب مؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. عيّن الخاصية `Rotation` للشكل إلى الزاوية المطلوبة.
1. حفظ العرض التقديمي.

الكود التالي بلغة C# يوضح كيفية تدوير شكل بزاوية 5 درجات:
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع مستطيل.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بزاوية 5 درجات.
    shape.Rotation = 5;

    // حفظ ملف PPTX على القرص.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![The shape rotation](shape-rotation.png)

## **Add 3D Bevel Effects**

تمكنك Aspose.Slides من تطبيق تأثيرات الحافة ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat] الخاصة بها.

لإضافة تأثيرات حافة ثلاثية الأبعاد إلى شكل، اتبع هذه الخطوات:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على إشارة إلى شريحة حسب مؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat] للشكل لتحديد إعدادات الحافة.
1. حفظ العرض التقديمي.

الكود التالي يوضح كيفية تطبيق تأثيرات حافة ثلاثية الأبعاد على شكل:
```c#
// إنشاء مثيل من فئة Presentation.
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

## **Add 3D Rotation Effects**

تمكنك Aspose.Slides من تطبيق تأثيرات تدوير ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat] الخاصة بها.

لتطبيق تدوير ثلاثي الأبعاد على شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على إشارة إلى شريحة حسب مؤشرها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. عيّن [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) و[LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) لتحديد تدوير ثلاثي الأبعاد.
1. حفظ العرض التقديمي.

الكود التالي يوضح كيفية تطبيق تأثيرات تدوير ثلاثي الأبعاد على شكل:
```c#
// إنشاء مثيل من فئة Presentation.
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

## **Reset Formatting**

الكود التالي بلغة C# يوضح كيفية إعادة تعيين تنسيق شريحة وإرجاع موضع وحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide] إلى إعداداتها الافتراضية:
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // إعادة ضبط كل شكل على الشريحة الذي لديه عنصر نائب في التخطيط.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض التقديمي النهائي؟**

قليلًا فقط. تحتل الصور والوسائط المضمّنة معظم مساحة الملف، في حين تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا إضافيًا تقريبًا.

**كيف يمكنني اكتشاف الأشكال في شريحة التي تشترك في تنسيق متطابق لأتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإعدادات الخاصة بالملء، الخط، والتأثيرات. إذا تطابقت جميع القيم المقابلة، اعتبر أن الأنماط متطابقة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الأشكال المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف .POTX القالب. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال ذات الأنماط التي تحتاجها، وأعد تطبيق تنسيقها حيثما يلزم.