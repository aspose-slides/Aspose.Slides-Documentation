---
title: "تنسيق أشكال PowerPoint في C#"
linktitle: "تنسيق الشكل"
type: docs
weight: 20
url: /ar/net/shape-formatting/
keywords:
- "تنسيق الشكل"
- "تنسيق الخط"
- "تنسيق نمط الوصل"
- "تعبئة متدرجة"
- "تعبئة بنقش"
- "تعبئة بصورة"
- "تعبئة بملمس"
- "تعبئة بلون صلب"
- "شفافية الشكل"
- "تدوير الشكل"
- "تأثير الحد ثلاثي الأبعاد"
- "تأثير التدوير ثلاثي الأبعاد"
- "إعادة تعيين التنسيق"
- "PowerPoint"
- "عرض تقديمي"
- "C#"
- "Csharp"
- ".NET"
- "Aspose.Slides"
description: "تعلم كيفية تنسيق أشكال PowerPoint في C# باستخدام Aspose.Slides—حدد أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---

## **نظرة عامة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكوّن من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال من خلال تحديد إعدادات تتحكم في كيفية ملء داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides for .NET واجهات وخصائص تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل ما. تُوضح الخطوات التالية الإجراء:

1. إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [نمط الخط](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [نمط الشرطية](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدّل كملف PPTX.

الكود C# التالي يوضح كيفية تنسيق عنصر AutoShape على شكل مستطيل:
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تعيين لون الملء لشكل المستطيل.
    shape.FillFormat.FillType = FillType.NoFill;

    // تطبيق تنسيق على خطوط المستطيل.
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


النتيجة:

![الخطوط المنسّقة في العرض](formatted-lines.png)

## **تنسيق أنماط الوصلات**

إليك خيارات ثلاثة لأنماط الوصلة:

* Round
* Miter
* Bevel

افتراضيًا، عندما يجمع PowerPoint خطين بزاوية (مثل زاوية شكل)، يستخدم الإعداد **Round**. ومع ذلك، إذا كنت ترسم شكلًا بزاويا حادة، قد تفضّل خيار **Miter**.

![نمط الوصلة في العرض](join-style-powerpoint.png)

الكود C# التالي يوضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصلات Miter وBevel وRound:
```c#
// إنشاء مثيل لفئة Presentation التي تمثل ملف عرض تقديمي.
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

    // تعيين لون الخط لكل مستطيل.
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

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```


## **التدرج اللوني**

في PowerPoint، يعتبر التدرج اللوني خيار تنسيق يسمح لك بتطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك طريقة تطبيق تدرج لوني على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة اللونين المفضلين مع تحديد المواقع باستخدام طرق `Add` لمجموعة نقاط التدرج التي يكشفها الواجهة [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) .
1. حفظ العرض المعدّل كملف PPTX.

الكود C# التالي يوضح كيفية تطبيق تأثير التدرج اللوني على شكل بيضاوي:
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // تطبيق تنسيق التدرج اللوني على الشكل البيضاوي.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // تعيين اتجاه التدرج اللوني.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // إضافة نقطتي تدرج.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![البيضاوي بالتدرج اللوني](gradient-fill.png)

## **نمط التعبئة بالنقش**

في PowerPoint، يتيح لك نمط التعبئة بالنقش تطبيق تصميم ذا لونين—مثل النقاط أو الخطوط أو التعرجات المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة للخلفية والواجهة للنقش.

توفر Aspose.Slides أكثر من 45 نمط نقشًا مُعرّفًا مسبقًا يمكنك تطبيقه على الأشكال لتعزيز المظهر البصري لعروضك. حتى بعد اختيار نمط نقش مُعرّف مسبقًا، لا يزال بإمكانك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك طريقة تطبيق نمط نقش على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط النقش من الخيارات المحددة مسبقًا.
1. تعيين [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) للنقش.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) للنقش.
1. حفظ العرض المعدّل كملف PPTX.

الكود C# التالي يوضح كيفية تطبيق نمط نقش على مستطيل:
```c#
// إنشاء مثيل لفئة Presentation التي تمثل ملف عرض تقديمي.
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

    // تعيين ألوان الخلفية والواجهة للنقش.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![المستطيل بنقش](pattern-fill.png)

## **التعبئة بالصور**

في PowerPoint، يتيح لك خيار التعبئة بالصور إدراج صورة داخل شكل—بشكل فعّال كخلفية للشكل.

إليك طريقة استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضع تعبئة الصورة إلى `Tile` (أو أي وضع مفضلة آخر).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. ربط هذه الصورة بالخاصية `Picture.Image` لتنسيق تعبئة الصورة `PictureFillFormat` للشكل.
1. حفظ العرض المعدّل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

الكود C# التالي يوضح كيفية تعبئة شكل بالصورة:
```c#
// إنشاء مثيل لفئة Presentation التي تمثل ملف عرض تقديمي.
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

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![الشكل بالتعبئة بالصورة](picture-fill.png)

### **تكرار الصورة كملمس**

إذا أردت تعيين صورة مكررة كملمس وتخصيص سلوك التكرار، يمكنك استخدام الخصائص التالية للواجهة [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) والفئة [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) : يحدد وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/) : يحدد محاذاة المربعات داخل الشكل.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/) : يتحكم في ما إذا كانت المربعات مقلوبة أفقيًا أو عموديًا أو كليهما.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/) : يحدد الإزاحة الأفقية للمربّع (بالنقطة) من أصل الشكل.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/) : يحدد الإزاحة الرأسية للمربّع (بالنقطة) من أصل الشكل.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/) : يحدد مقياس المربّع أفقيًا كنسبة مئوية.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/) : يحدد مقياس المربّع رأسيًا كنسبة مئوية.

العينة التالية توضح كيفية إضافة شكل مستطيل بتعبئة صورة مكررة وتكوين خيارات التكرار:
```c#
// إنشاء مثيل لفئة Presentation التي تمثل ملف عرض تقديمي.
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

    // تكوين وضع تعبئة الصورة وخصائص التبليط.
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


النتيجة:

![خيارات التكرار](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، يعبّئ خيار التعبئة بلون صلب الشكل بلون موحد واحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو نقوش.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين اللون المملوء المفضّل للشكل.
1. حفظ العرض المعدّل كملف PPTX.

الكود C# التالي يوضح كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:
```c#
// إنشاء مثيل لفئة Presentation التي تمثل ملف عرض تقديمي.
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

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![الشكل بتعبئة بلون صلب](solid-color-fill.png)

## **تحديد الشفافية**

في PowerPoint، عندما تُطبق لونًا صلبًا أو تدرجًا أو صورة أو قوامًا على أشكال، يمكنك أيضًا تحديد مستوى شفافية للتحكم في مدى وضوح التعبئة. تزيد قيمة الشفافية من شفافية الشكل، مما يسمح للمحتوى الخلفي أو الكائنات الأسفل بأن تكون مرئية جزئيًا.

تتيح لك Aspose.Slides تعيين مستوى الشفافية من خلال تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) إلى `Solid`.
1. استخدام `Color.FromArgb(alpha, baseColor)` لتحديد لون مع شفافية (مكوّن الـ `alpha` يتحكم في الشفافية).
1. حفظ العرض.

الكود C# التالي يوضح كيفية تطبيق لون تعبئة شفاف على مستطيل:
```c#
const int alpha = 128;

// إنشاء مثيل لفئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي صلب من نوع المستطيل.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // إضافة شكل تلقائي شفاف من نوع المستطيل فوق الشكل الصلب.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية بتنسيق أو حاجة تصميمية معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية `Rotation` للشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

الكود C# التالي يوضح كيفية تدوير شكل بزاوية 5 درجات:
```c#
// إنشاء مثيل لفئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تدوير الشكل بمقدار 5 درجات.
    shape.Rotation = 5;

    // حفظ ملف PPTX إلى القرص.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات حد ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات حد ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات حد ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين خاصية [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) للشكل لتحديد إعدادات الحد.
1. حفظ العرض.

الكود C# التالي يوضح كيفية تطبيق تأثيرات حد ثلاثية الأبعاد على شكل:
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

![تأثير الحد ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات تدوير ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات تدوير ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) الخاصة بها.

لتطبيق تدوير ثلاثي الأبعاد على شكل:

1. إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة عنصر [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصيتي [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) و [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) لتحديد تدوير ثلاثي الأبعاد.
1. حفظ العرض.

الكود C# التالي يوضح كيفية تطبيق تأثيرات تدوير ثلاثية الأبعاد على شكل:
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

![تأثير التدوير ثلاثي الأبعاد](3D-rotation-effect.png)

## **إعادة تعيين التنسيق**

الكود C# التالي يوضح كيفية إعادة تعيين تنسيق شريحة وإرجاع الموقع والحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:
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

**هل يؤثر تنسيق الشكل على حجم الملف النهائي للعرض التقديمي؟**

التأثير ضئيل فقط. تحتل الصور والوسائط المضمّنة الجزء الأكبر من مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات تعريفية ولا تضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في نفس التنسيق بحيث يمكن تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإملأ، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متماثلة وقم بتجميع تلك الأشكال منطقيًا، ما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال ذات الأنماط التي تحتاجها، وأعد تطبيق تنسيقها حسب الحاجة.