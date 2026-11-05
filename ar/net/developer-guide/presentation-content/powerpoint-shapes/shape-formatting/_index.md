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
- رسم خط الشكل التخطيطي
- تنسيق نمط الوصلة
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة صورة
- تعبئة نسيج
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بدرجات الرمادي
- تدوير الشكل
- تأثير بيفيل ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في C# باستخدام Aspose.Slides — اضبط تعبئة الخط وتأثيرات الأنماط لملفات PPT و PPTX بدقة وتحكم كامل."
---
## **المقدمة**

قم بتنسيق الأشكال في PowerPoint عن طريق تعديل مخططاتها وتعبئتها وتأثيراتها. يتيح لك Aspose.Slides for .NET التحكم في هذه الإعدادات برمجياً، بما في ذلك الشفافية، والدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

يوفر Aspose.Slides for .NET واجهات وخصائص تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتوفرة في PowerPoint.

## **تنسيق الخطوط**

استخدم [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) للتحكم في مخطط الشكل. هذا المثال ينشئ مستطيلًا غير مملوء بخط أزرق متقطع. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) يختار خطًا مركبًا سميك-رفيع، بينما [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) يحدد عرضه إلى 7 نقاط و[ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) يختار نمط الشرطة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

النتيجة:

![الخطوط المُنسَّقة في العرض التقديمي](formatted-lines.png)

### **تعيين أنماط شرطات خط مخصصة**

استخدم [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) عندما لا توفر الأنماط الخطية المعرفة مسبقًا أطوال الشرطات والفواصل التي تحتاجها، على سبيل المثال للحدود ذات العلامة التجارية أو الرسومات التقنية. تعيين نمط تلقائيًا يضبط [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) إلى [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

تتناوب قيم المصفوفة بين أطوال الشرطة والفاصل، بدءًا بشرطة. كل قيمة هي مضاعف عرض الخط: `{ 4, 2 }` بعرض 3 نقاط ينتج شرطة بطول 12 نقطة ثم فجوة بطول 6 نقاط. استخدم أزواجًا من القيم المحدودة وغير السالبة لتعريف مقاطع الشرطـة‑الفاصل المكتملة. يستخدم المثال قيمًا موجبة للحفاظ على رؤية كل شرطة وفاصل.

هذا المثال ينشئ خمس خطوط زرقاء بنفس الطول ورؤوس مسطحة. الثلاثة الأولى تقارن الأنماط بعرض 3 نقاط. الرابع يكرر النمط الأول بعرض مضاعف، مما يضاعف أطوال الشرطة والفاصل. الخامس ينتقل من نمط مخصص إلى خط صلب.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// إرجاع الخط الأخير إلى نمط صلب.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

للعودة إلى نمط متقطع معرف مسبقًا، عيّن [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) إلى [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). النمط المختار يتحكم في مظهر الخط.

النتيجة في PowerPoint، من الأعلى إلى الأسفل: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و**Solid, 3 pt**.

![ثلاثة أنماط شرطة مخصصة، خط أوسع يستخدم النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)


### **تعيين رؤوس الخط**

استخدم [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) لتحديد نهايات الخط المفتوح. تعداد [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) يوفر ثلاثة أنماط رأس صريحة:

- `Flat`: يتوقف الخط عند النهاية.
- `Round`: رأس نصف دائري يمتد إلى ما بعد النهاية بمقدار نصف عرض الخط.
- `Square`: رأس مربع يمتد إلى ما بعد النهاية بمقدار نصف عرض الخط.

التعداد يتضمن أيضًا `NotDefined`، وهو يعني أنه لم يتم تعيين نمط رأس صريح.

الرؤوس تختلف عن رؤوس السهام، التي تضيف رموزًا إلى نهايات الخط، وعن الوصلات، التي تتحكم في الزوايا بين أجزاء الخط. يعطل هذا المثال رؤوس السهام عبر [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) و[ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) بحيث يتم مقارنة أشكال الرؤوس فقط.

المثال التالي ينشئ ثلاثة خطوط أفقية متطابقة، عرضها 20 نقطة. من الأعلى إلى الأسفل، تستخدم رؤوسًا مسطحة، ودائرية، ومربعة. نقاط نهاياتها تتطابق أفقياً؛ الرؤوس الدائرية والمربعة تمتد 10 نقاط إلى ما بعد كل نهاية.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

النتيجة في PowerPoint، من الأعلى إلى الأسفل: **Flat**، **Round**، و**Square**.

![رؤوس مسطحة، دائرية، ومربعة على خطوط سميكة متطابقة في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُضفي تأثير الرسم التخطيطي مظهرًا يدويًا على خط الشكل. استخدم [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) للوصول إلى إعدادات الخط، و[ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) للوصول إلى إعدادات الرسم التخطيطي، و[ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

يظهر الكود التالي في C# كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

القيمة التي تُرجعها [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان يمكن وراثة تنسيق الخط من موضوع، شريحة رئيسية، أو شريحة تخطيط، استخدم [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/)، للوصول إلى [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/)، وقراءة [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). القيمة الفعّالة تعكس التنسيق المطبق فعليًا بعد حل الوراثة. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على شكل واحد على الأقل في شريحته الأولى ويطبع القيمتين:

```csharp
using System;
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

إليك ثلاث خيارات لأنواع الوصلات:

* Round
* Miter
* Bevel

نمط الوصلة يتحكم في كيفية التقاء مقطعين من المخطط عند الزاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المسطحة.

![نمط الوصلة في العرض التقديمي](join-style-powerpoint.png)

هذا المثال ينشئ ثلاثة مستطيلات سوداء ذات مخططات زرقاء عرضها 15 نقطة. يعيّن [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) إلى قيم المتر، والعقرب، والمستدير من تعداد [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) على التوالي، للمقارنة بين كيفية رسم الزوايا.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **قصر وصلات المتري عند الزوايا الحادة**

استخدم [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) مع [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) معين إلى [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) لتقليل المسافة التي يمكن أن تمتد فيها الزاوية الحادة.

الحد هو نسبة المسافة بين الزاويتين الداخلية والخارجية للوصلة إلى عرض الخط. على سبيل المثال، القيمة `8` تسمح بطول متر يصل إلى ثماني أضعاف عرض الخط؛ ليست قياسًا بنقاط. إذا كانت الزاوية ستتجاوز الحد، يستخدم PowerPoint وصلة مكسّرة عند تلك الزاوية. حد أكبر يتيح نقاطًا أكثر حدة. الإعداد يؤثر على وصلات المتري فقط، وتغييره لا يؤثر عندما تبقى الزاوية ضمن كلا الحدين.

هذا المثال ينشئ مثلثين غير مملوءين متطابقين بعرض مخطط 20 نقطة. المثلث الأيسر يستخدم حدًا قدره `2`، واليمين يستخدم `8`. كل مثلث عرض 80 نقطة وارتفاع 160 نقطة، ما يمنح زاويته العليا نسبة طول المتري إلى عرض الخط تقارب `4.12`. نتيجةً لذلك، يكسّر PowerPoint قمة اليسار ويحافظ على قمة اليمين.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

النتيجة في PowerPoint: **Miter limit 2** على اليسار و**miter limit 8** على اليمين.

![قمة مكسّرة بحد متر 2 وقمة حادة بحد متر 8 في PowerPoint](miter-limits.png)

## **تعبئة متدرجة**

تعبئة متدرجة تمزج الألوان عبر الشكل. يملأ هذا المثال إهليجًا بتدرج خطي بزاوية 45 درجة من الأحمر إلى الأرجواني باستخدام [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). طريقة [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) تضع نقاط التوقف اللونية عند 0 و1، بداية ونهاية التدرج. مسح النقاط الموجودة يضمن استخدام هذين اللونين فقط.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

النتيجة:

![الإهليج مع تعبئة متدرجة](gradient-fill.png)

إذا بدا التدرج مختلفًا في صورة مُصدَّرة مقارنةً بما هو في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير التدرج المخزن في العرض التقديمي.

### **تحديد زاوية التدرج الخطي**

استخدم [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) للتحكم في اتجاه تعبئة [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد في اتجاه عقارب الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و`270` من الأسفل إلى الأعلى. تدعم الزوايا الكسرية. الزوايا المحدودة خارج `[0, 360)` تُطبع إلى دورة واحدة؛ على سبيل المثال، `-45` تصبح `315` و`360` تصبح `0`.

هذا المثال ينشئ ستة مستطيلات بنقاط توقف حمراء، خضراء، وزرقاء متطابقة عند المواقع `0`، `0.5`، و`1`. تم إلغاء مقياس الزاوية بحيث يمكن مقارنتها مستقلةً عن نسب المستطيلات. الزوايا، من اليسار إلى اليمين، هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

النتيجة في PowerPoint:

![تدرجات خطية عند 0، 45، و90 درجة في الصف العلوي، و135، 180، و270 درجة في الصف السفلي](linear-gradient-angles.png)

### **مقياس التدرج الخطي مع الشكل**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) يقبل قيمة [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). اضبطها صراحةً على `False` للحفاظ على زاوية التدرج الهندسية مع تغير أبعاد الشكل، أو إلى `True` لتوسيع التدرج مع عرض وارتفاع الشكل. مع تمكين المقياس، قد تختلف الزاوية الظاهرة عن الزاوية المعينة على شكل غير مربع.

المثال التالي يستخدم زاوية `45` درجة ونقاط توقف اللون نفسها كما في مقارنة الزوايا. العمود الأيسر يستخدم `False`؛ العمود الأيمن يستخدم `True`. يحتوي كل عمود على مستطيل عريض فوق مستطيل طويل. يبدأ كلاهما بأبعاد عريضة متساوية؛ تعديل عرض وارتفاع المستطيل الثاني يُظهر كيف يستجيب التعبئة للتمدد دون تغيير إعدادات التدرج.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

النتيجة في PowerPoint، مع إلغاء المقياس على اليسار وتفعيل المقياس على اليمين:

![مستطيلات عريضة وطويلة مع تدرج بزاوية 45 درجة، مقارنة LinearGradientScaled False على اليسار مع True على اليمين](linear-gradient-scaling.png)

مع إلغاء المقياس، تظل أحزمة اللون المائلة ذات توجيه ثابت في كلا المستطيلين. مع تفعيل المقياس، تمتد الأحزمة مع نسب الشكل. يساعد ذلك في إعادة إنتاج تدرج القالب عند تعديل حجم الشكل. على شكل مربع، لا يغيّر تفعيل المقياس مظهر هذا التدرج بزاوية `45` درجة.

تنطبق إعدادات الزاوية والمقياس على التدرجات الخطية فقط. لا تتحكم في تعبئات [GradientShape.Radial أو GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) يختار نمط التدرج من تعداد [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/); فهو ليس بديلاً للزاوية الرقمية. في التدرج الخطي، يمكن لأنماط الزوايا تغيير المنطقة التي تُوزَّع فيها الألوان دون تغيير [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). حافظ على اتجاه التدرج ثابتًا عند مقارنة الزوايا أو المقياس.

المثال التالي يطبق نفس الإعدادات بترتيب عكسي. المستطيلان يبدوان متطابقين: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **تعبئة بنمط**

تعبئة بنمط تطبق تصميمًا ثنائي اللون، مثل النقاط أو الخطوط أو المربعات. يستخدم هذا المثال [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) لاختيار نمط شبكة. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) يحدد خلفية رمادية فاتحة، و[IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) يحدد لون النمط الأصفر.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

النتيجة:

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة صورة**

تعبئة الصورة تستخدم صورة داخل شكل. يتطلب هذا المثال صورة محلية ويستخدم [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) لتحميلها إلى مجموعة صور العرض التقديمي. ضبط [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) إلى وضع البلاط يكرر الصورة داخل المستطيل. الصورة المصدر المستخدمة هنا موضحة أدناه:

![صورة اللوتس](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **بلاط الصورة كنقش**

إذا رغبت في تعيين صورة مبلطّة كنقش وتخصيص سلوك البلاط، يمكنك استخدام الخصائص التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): يحدد وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): يحدد محاذاة البلاط داخل الشكل.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): يتحكم فيما إذا كان البلاط يُقلب أفقيًا أو عموديًا أو كليًا.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): يحدد إزاحة البلاط أفقياً (بالنقاط) من أصل الشكل.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): يحدد إزاحة البلاط عموديًا (بالنقاط) من أصل الشكل.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): يُعرّف مقياس البلاط الأفقي كنسبة مئوية.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): يُعرّف مقياس البلاط العمودي كنسبة مئوية.

يتطلب هذا المثال صورة محلية ويُعدّ [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) لتكرارها بنسبة 50% من حجمها الأصلي. تحولات `−32` نقطة تُزقّ البلاط أفقيًا وعموديًا؛ محاذاة الزاوية السفلية اليمنى والقلب في الاتجاهين يحددان كيفية ترتيب النسيج المكرَّر.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

النتيجة:

![خيارات البلاط](tile-options.png)

## **تعبئة بلون صلب**

تعبئة صلبة تُعطي الشكل لونًا موحدًا. يضبط هذا المثال [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) إلى وضع التعبئة الصلبة ويعيّن الأصفر عبر [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)، ثم يحفظ المستطيل في عرض تقديمي.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

النتيجة:

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

### **نسخ الألوان مع الحفاظ على مراجع الموضوع**

استخدم [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) لنسخ تعريف اللون، بما في ذلك نوعه، مرجع الموضوع، والتحويلات. يُفيد هذا عند نقل لون تعبئة بين أشكال يجب أن تستمر في متابعة موضوع العرض التقديمي. الطريقة تنسخ اللون فقط؛ لا تنسخ نوع التعبئة أو المخطط أو تنسيقات الشكل الأخرى. اضبط صراحةً [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) للوجهة.

هذا المثال ينشئ ثلاثة مستطيلات، من اليسار إلى اليمين: المصدر، نسخة واعية للموضوع، ونسخة RGB ثابتة. يستخدم المصدر [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) للإشارة إلى اللون المميز الأول ويضيف لونًا فاتحًا عبر [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/). النسخة RGB تستخدم اللون الفعّال للمصدر لذا تبدو الثلاثة متماثلة في البداية. تعيين [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) يُحدّد قيمة RGB ثابتة ويمسح أي تحويلات لون قائمة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// مراجع السمة تتبع اللون المميز الجديد؛ قيمة RGB الثابتة لا تتبع ذلك.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

قبل تغيير الموضوع، جميع التعبئات الثلاثة متطابقة:

![المصدر، نسخة CopyFrom، ونسخة RGB ثابتة مع تعبئات زرقاء متطابقة](color-copy-before.png)

بعد تغيير الموضوع، يتبع المصدر والنسخة الواعية للموضوع اللون المميز الجديد وتحتفظ بظلالها. تبقى نسخة RGB الزرقاء:

![المصدر ونسخة CopyFrom مع تعبئات برتقالية، بينما تبقى نسخة RGB ثابتة زرقاء](color-copy-after.png)

التعريف المنسوخ مستقل عن المصدر. تعديل مرجع الموضوع للمصدر لاحقًا، أو تعيين لون آخر، أو إضافة أو إزالة تحويلاته لا يغيّر الوجهة. يظل تغيير الموضوع يؤثر على كلا الشكلين لأن كلًا منهما يشير إلى نفس لون الموضوع بشكل مستقل.

حفظ وإعادة فتح ملف PPTX يحافظ على [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/)، مرجع الموضوع، ومجموعة [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/) للتعريف المنسوخ؛ لا يتم تحويله إلى RGB.

عند النسخ بين سياقات موضوع مختلفة، مثل عروض تقديمية ذات لوحات ألوان مميزة متفاوتة، يُفسَّر المرجع المنسوخ وفقًا لموضوع الوجهة. لذلك يمكن لنفس المرجع والتحويلات أن ينتج عنهما لون مرئي مختلف. راجع [Presentation Theme](/slides/ar/net/presentation-theme/) لمزيد من التفاصيل حول تكوين ألوان الموضوع.

## **استخدام خلفية الشريحة كتعبئة الشكل**

استخدم [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) عندما ينبغي أن يتطابق الشكل مع خلفية الشريحة، على سبيل المثال في قالب عرض تقديمي. اضبط [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) إلى [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) أولًا لإزالة أي تعبئة صريحة. بهذه المجموعة، يستخدم الشكل خلفية الشريحة بدلًا من تعبئته النمطية. تمكين العلامة الوحيدة لا يزيل تعبئة صريحة موجودة.

هذا يختلف عن [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات خلف الشكل بمنطقة خلفية الشريحة المقابلة، بينما لا تعبئة تترك تلك الكائنات مرئية. يبقى التدرج محاذيًا للشرائح بدلاً من البدء داخل كل شكل.

المثال التالي ينشئ خلفية رئيسية يتم وراثتها من قبل الشريحة ويضع شريطًا أرجوانيًا خلف ثلاثة مستطيلات. المستطيل الأيسر يستخدم الخلفية، والوسطى لا تعبئة، واليمين يتحول من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// وراثة التدرج من القالب الرئيسي.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// أضف هذا الكائن أولًا حتى يظهر خلف المستطيلات.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// تعطيل تعبئة الخلفية قبل تطبيق تعبئة صريحة.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

النتيجة، من اليسار إلى اليمين: **تعبئة خلفية**، **بدون تعبئة**، و**تعبئة صريحة**. الشريط الأرجواني مخفي خلف المستطيلين الأيسر والأيمن لكنه يبقى مرئيًا عبر المستطيل الأوسط.

![تعبئة خلفية، بدون تعبئة، وتعبئة برتقالية صريحة فوق شريط أرجواني](background-fill.png)

ينطبق السلوك نفسه على خلفية معرفة مباشرةً على الشريحة أو موروثة من تخطيط. يستخدم الشكل خلفية الشريحة المُحلَّلة؛ يترك المثال كلاً من خلفية الشريحة والتخطيط غير معرفين لتزودهما الخلفية الرئيسية.

## **تعيين الشفافية**

في تعبئة صلبة، يتحكم مكون ألفا للون في عدم الشفافية: 0 يعني شفافية كاملة و255 يعني عدم شفافية كاملة. يستخدم هذا المثال قيمة ألفا 128 لمستطيل أصفر، ما يجعله شفافًا تقريبًا بنسبة 50% بحيث يظل المستطيل السفلي مرئيًا. يُعيّن اللون عبر [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **دوران الأشكال**

استخدم [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) لدوران الشكل في مستوى الشريحة. تُقاس الزاوية بالدرجات؛ يدور هذا المثال مستطيلًا 5 درجات باتجاه عقارب الساعة ويحفظ العرض التقديمي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

النتيجة:

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات بيفيل ثلاثية الأبعاد**

استخدم [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) لإعطاء الشكل عمقًا وحوافًا بيفيل. يُنشئ هذا المثال إهليجًا أخضرًا بحد برتقالي، يضبط [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) إلى 4 نقاط، ويُطبق بيفيل علوي دائري بعرض وارتفاع 6 نقاط عبر [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). تجعل كاميرا أرثوغرافية أمامية وإضاءة ثلاثية نقاط البيفيل مرئيًا.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

النتيجة:

![تأثير البيفيل ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تُتحكم إعدادات الكاميرا في عرض الشكل ثلاثي الأبعاد. يستخدم هذا المثال [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) بزاوية خطوط العرض والطول والثورة 40 و35 و20 درجة على التوالي. يختار كاميرا إسومتريّة عبر [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) وإضاءة متوازنة عبر [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/)، ثم يحفظ المستطيل المنسَّق.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

النتيجة:

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في عرض أبيض وأسود للأشكال**

تحدد خاصية [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) كيف يُعرض الشكل فرديًا عندما يُعرض أو يُعالج العرض التقديمي في وضع أبيض وأسود. لا تُفعّل وضعًا أبيض وأسود بحد ذاته، ولا تُغيّر تعبئة الشكل أو خطه أو تنسيقات أخرى في وضع اللون الطبيعي.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) لاختيار السلوك المرغوب. على سبيل المثال، `Automatic` يترك التطبيق يختار التحويل، و`Gray` و`LightGray` يستخدمان تلوينًا رماديًا، و`BlackWhite` يستخدم فقط الأسود والأبيض، و`Black` و`White` يجبران على لون واحد، و`Color` يحافظ على التلوين الطبيعي، و`Hidden` يحذف الشكل في وضع أبيض وأسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

هذا المثال ينشئ مستطيلًا برتقاليًا ويضبط [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) إلى رمادي. يحتفظ الشكل المحفوظ بتعبئته البرتقالية للعرض بالألوان الطبيعية ويطلب تلوينًا رماديًا من التطبيقات التي تحترم إعدادات العرض بالأبيض والأسود:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

في وضع اللون الطبيعي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل عرض أبيض وأسود، يستخدم تلوينًا رماديًا لأن وضعه مضبوط على `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو غيرها من سير العمل التي تحترم إعدادات عرض أبيض وأسود للعرض التقديمي.

## **إعادة تعيين التنسيق**

استخدم [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) لاستعادة موقع، حجم، وتنسيق عناصر النائب في الشريحة من عناصر النائب المقابلة في تخطيطها. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على عناصر نائب مرتبطة بالتخطيط ويعيد تعيين كل شريحة قبل الحفظ. لا تُعاد تعيين الأشكال التي لا تقابل عناصر نائب في التخطيط.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض التقديمي النهائي؟**

الألوان، أنماط الخطوط، وإعدادات التأثير عادةً ما تُضيف بيانات قليلة مقارنةً بالصور والوسائط المدمجة. قد تزيد تعبئات الصور من حجم الملف لأن صورها تُخزن في العرض.

**كيف يمكن اكتشاف الأشكال في شريحة تشارك نفس التنسيق لتجميعها؟**

قارن خصائص التنسيق الأساسية لكل شكل — التعبئة، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع هذه الأشكال منطقيًا، مما يُبسّط إدارة الأنماط لاحقًا.

**هل يمكن حفظ مجموعة من أنماط الشكل المخصصة إلى ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ أشكالًا نموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال ذات الأنماط المطلوبة، وطبق تنسيقها حيثما يلزم.