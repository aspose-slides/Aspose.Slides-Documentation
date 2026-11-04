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
- تعبئة تدرج لوني
- تعبئة بنمط
- تعبئة صورة
- تعبئة نسيج
- تعبئة لون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بالدرجات الرمادية
- تدوير الشكل
- تأثير بروز ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في C# باستخدام Aspose.Slides—حدد أنماط التعبئة والخط والتأثير لملفات PPT وPPTX بدقة وتحكم كامل."
---
## **مقدمة**

قم بتنسيق الأشكال في PowerPoint عن طريق ضبط حدودها وتعبئتها وتأثيراتها. يتيح لك Aspose.Slides for .NET التحكم في هذه الإعدادات برمجياً، بما في ذلك الشفافية، والدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

يوفر Aspose.Slides for .NET واجهات وخصائص تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

استخدم [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) للتحكم في حد الشكل. هذا المثال ينشئ مستطيلًا غير مملوء بحد أزرق متقطّع. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) يختار خطًا مركبًا سميك‑رقيق، بينما [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) يعيّن عرضه إلى 7 نقاط و[ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) يختار نمط الشرط.

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

![الخطوط المنسقة في العرض](formatted-lines.png)

### **تحديد أنماط الشرط المخصّصة للخط**

استخدم [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) عندما لا توفر الأنماط الخطية المعرفة مسبقًا أطوال الشرط والفواصل التي تحتاجها، على سبيل المثال للحدود ذات العلامة التجارية أو المخططات التقنية. يؤدي تعيين نمط إلى تعيين [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) تلقائيًا إلى [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

تتناوب مدخلات المصفوفة بين أطوال الشرط والفاصل، بدءًا بشرط. كل قيمة هي مضاعف لعرض الخط: `{ 4, 2 }` عند عرض 3 نقاط ينتج شرط بطول 12 نقطة يليه فجوة بطول 6 نقاط. استخدم أزواجًا من القيم النهائية غير السالبة لتعريف مقاطع الشرط‑الفاصل الكاملة. يستخدم المثال قيمًا موجبة لإبقاء كل شرط وفاصل مرئيًا.

هذا المثال ينشئ خمسة خطوط زرقاء بنفس الطول ونهايات مسطحة. المقاطع الثلاثة الأولى تقارن الأنماط عند عرض 3 نقاط. الرابع يكرر النمط الأول بعرض مضاعف، مما يضاعف أطوال الشرط والفاصل. الخامس يتحول من نمط مخصص إلى خط صلب.

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

// Return the last line to a solid style.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

للتراجع إلى نمط متقطع مُعرّف مسبقًا، عيّن [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) إلى [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). النمط المحدد يتحكم في مظهر الخط.

النتيجة في PowerPoint من أعلى إلى أسفل: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و**Solid, 3 pt**.

![ثلاثة أنماط شرط مخصّصة، خط أوسع يستخدم النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **تعيين نهايات الخط**

استخدم [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) لتعيين نهايات الخط المفتوح. تقدم تعداد [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) ثلاثة أنماط صريحة للنهايات:

- `Flat`: يتوقف الخط عند نقطة النهاية.
- `Round`: نهاية نصف دائرية تمتد إلى ما بعد نقطة النهاية بنصف عرض الخط.
- `Square`: نهاية مربعة تمتد إلى ما بعد نقطة النهاية بنصف عرض الخط.

التعداد يتضمن أيضًا `NotDefined`، ما يعني عدم تعيين نمط نهية صريح.

النهايات تختلف عن رؤوس السهام التي تضيف رموزًا إلى نهايات الخط، وعن الوصلات التي تتحكم في الزوايا بين مقاطع الخط. هذا المثال يعطل رؤوس السهام عبر [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) و[ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) بحيث تُقارن فقط أشكال النهايات.

المثال التالي ينشئ ثلاثة خطوط أفقية متماثلة، عرضها 20 نقطة. من أعلى إلى أسفل، تستخدم نهايات مسطحة، دائرية، ومربعة. نقاط النهاية لها نفس الإحداثيات الأفقية؛ النهايات الدائرية والمربعة تمتد 10 نقاط إلى ما بعد كل نقطة نهاية.

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

النتيجة في PowerPoint من أعلى إلى أسفل: **Flat**, **Round**, و**Square**.

![نهايات مسطّحة، دائرية، ومربعة على خطوط سميكة متماثلة في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

تجعل تأثيرات الرسم التخطيطي خط الشكل يبدو مرسمًا يدويًا. استخدم [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) للوصول إلى إعدادات الخط، و[ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) للوصول إلى إعدادات الرسم، و[ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

الكود التالي في C# يوضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) وقراءة القيمة المحددة صراحةً وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

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

القيمة التي تُعيدها [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان يمكن أن يرث تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/)، وصولًا إلى [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/)، وقراءة [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). القيمة الفعّالة تعكس التنسيق الذي يُطبق فعليًا بعد حل الوراثة. يتطلب هذا المثال عرضًا موجودًا يحتوي على شكل واحد على الشريحة الأولى على الأقل ويطبع القيمتين:

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

## **تنسيق أنماط الانضمام**

فيما يلي الخيارات الثلاثة لأنواع الانضمام:

* Round
* Miter
* Bevel

يتحكم نمط الانضمام في كيفية التقاء مقطعي الحد عند الزاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المستوية.

![نمط الانضمام في العرض](join-style-powerpoint.png)

هذا المثال ينشئ ثلاثة مستطيلات سوداء بحدود زرقاء عرضها 15 نقطة. يعيّن [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) إلى قيم الميتر، والبيفل، والرووند من [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) على التوالي، للمقارنة بين كيفية رسم الزوايا.

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

### **تقييد وصلات الميتر عند الزوايا الحادة**

استخدم [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) مع [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) محددًا إلى [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) لتقييد مدى امتداد الزاوية الحادة.

الحد هو نسبة المسافة بين الزوايا الداخلية والخارجية للوصلة إلى عرض الخط. على سبيل المثال، القيمة `8` تسمح بطول ميتر يصل إلى ثمان مرات عرض الخط؛ ليست قياسًا بالنقاط. إذا تجاوزت الزاوية الحد، يستخدم PowerPoint وصلة بيجلة عند تلك الزاوية. الحد الأكبر يسمح بنقاط أكثر حدة. هذا الإعداد يؤثر فقط على وصلات الميتر، ولا يُظهر أي تأثير مرئي عندما تبقى الزاوية ضمن الحدين.

هذا المثال ينشئ مثلثين غير مملوءين متطابقين بحدود عرضها 20 نقطة. المثلث الأيسر يستخدم حدًا قدره `2`، واليمين يستخدم `8`. كل مثلث عرضه 80 نقطة وارتفاعه 160 نقطة، مما يعطي زاوية علوية بنسبة تقريبية `4.12` بين طول الميتر وعرض الخط. نتيجةً لذلك، يقوم PowerPoint بإنشاء قمة بيجلة على اليسار ويحافظ على القمة الحادة على اليمين.

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

![قمة مكسوة بحد ميتر 2 وقمة حادة بحد ميتر 8 في PowerPoint](miter-limits.png)

## **تعبئة تدرج لوني**

تعبئة التدرج تمزج الألوان عبر الشكل. هذا المثال يملأ إهليلجًا بتدرج خطي بزاوية 45 درجة من الأحمر إلى البنفسجي باستخدام [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). طريقة [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) تضع نقاط التوقف اللونية عند 0 و1، بداية ونهاية التدرج. مسح النقاط الحالية يضمن استخدام هاتين اللونين فقط.

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

![الإهليلج بتعبئة تدرج لوني](gradient-fill.png)

إذا بدا التدرج مختلفًا في صورة مُصدَّرة مقارنةً بما هو عليه في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة التدرج المخزنة في العرض.

### **تعيين زاوية التدرج الخطي**

استخدم [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) للتحكم في توجيه تعبئة [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/). الزاوية تقاس بالدرجات وتزداد باتجاه عقارب الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و`270` من الأسفل إلى الأعلى. تدعم الزوايا الكسرية. الزوايا خارج النطاق `[0, 360)` تُنظم إلى دورة واحدة؛ على سبيل المثال، `-45` يصبح `315` و`360` يصبح `0`.

هذا المثال ينشئ ستة مستطيلات بنقاط توقف اللون الأحمر والأخضر والأزرق المتطابقة عند المواقع `0`، `0.5`، و`1`. تم تعطيل التحجيم حتى يمكن مقارنة الزاوية بغض النظر عن نسب المستطيلات. الزوايا من اليسار إلى اليمين هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

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

![تدرجات خطية عند 0، 45، و90 درجة في الصف العلوي، وعند 135، 180، و270 درجة في الصف السفلي](linear-gradient-angles.png)

### **تحجيم تدرج خطي مع الشكل**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) يقبل قيمة [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). اضبطها صراحةً إلى `False` للحفاظ على زاوية التدرج الهندسية مع تغيير أبعاد الشكل، أو إلى `True` لتحجيم التدرج مع عرض وارتفاع الشكل. مع تمكين التحجيم، قد تختلف الزاوية الظاهرة عن الزاوية المعينة على شكل غير مربع.

المثال التالي يستخدم زاوية `45` درجة ونقاط التوقف اللونية نفسها المستخدمة في مقارنة الزوايا. العمود الأيسر يستخدم `False`؛ العمود الأيمن يستخدم `True`. كل عمود يحتوي على مستطيل عريض فوق مستطيل طويل. يبدأ كلاهما بأبعاد عريضة متساوية؛ تغيير عرض وارتفاع المستطيل الثاني يظهر كيف يستجيب التعبئة لإعادة التحجيم دون تغيير إعدادات التدرج.

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

النتيجة في PowerPoint، مع تعطيل التحجيم على اليسار وتمكينه على اليمين:

![مستطيلات عريضة وطويلة مع تدرج بزاوية 45 درجة، مقارنة LinearGradientScaled False على اليسار مع True على اليمين](linear-gradient-scaling.png)

مع تعطيل التحجيم، تبقى أشرطة اللون المائلة ذات نفس التوجيه في كلا المستطيلين. مع تمكين التحجيم، تمتد الأشرطة مع نسب الشكل. يساعد ذلك في إعادة إنتاج تدرج قالب عند تعديل حجم الشكل. على شكل مربع، لا يُغيّر تمكين التحجيم مظهر هذا التدرج بزاوية `45` درجة.

كل من زاوية التدرج وإعدادات التحجيم تنطبق على التدرجات الخطية. لا تتحكم في تعبئات [GradientShape.Radial أو GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) يختار نمطًا من تعداد [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/); ليس بديلاً عن زاوية رقمية. بالنسبة لتدرج خطي، يمكن لأنماط الزوايا تغيير المنطقة التي تُوزع فيها الألوان دون تغيير [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). حافظ على الاتجاه ثابتًا عند مقارنة الزوايا أو التحجيم.

المثال التالي يطبق الإعدادات نفسها بترتيب عكسي. المستطيلان يبدوان متماثلين: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

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

تعبئة النمط تُطبق تصميمًا من لونين، مثل النقاط أو الخطوط أو المربعات. يستخدم هذا المثال [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) لاختيار نمط trellis. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) يزوّد الخلفية بالرمادي الفاتح، و[IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) يزوّد اللون الأصفر للنمط.

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

![المستطيل بتعبئة بنمط](pattern-fill.png)

## **تعبئة صورة**

تعبئة الصورة تستخدم صورة داخل الشكل. يتطلب هذا المثال صورة محلية ويستخدم [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) لتحميلها إلى مجموعة صور العرض. ضبط [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) إلى الوضع المتجدد (tile) يكرر الصورة داخل المستطيل. الصورة المصدر المستخدمة هنا موضحة أدناه:

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

![الشكل بتعبئة صورة](picture-fill.png)

### **تجميع الصورة كملمس**

إذا رغبت في تعيين صورة متجددّة كملمس وتخصيص سلوك التجميع، يمكنك استخدام الخصائص التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): يعيّن وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): يحدد محاذاة البلاطات داخل الشكل.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): يتحكم فيما إذا كانت البلاطة مقلوبة أفقياً أو عمودياً أو كليهما.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): يعيّن الإزاحة الأفقية للبلاطة (بالنقاط) من أصل الشكل.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): يعيّن الإزاحة العمودية للبلاطة (بالنقاط) من أصل الشكل.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): يحدد المقياس الأفقي للبلاطة كنسبة مئوية.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): يحدد المقياس العمودي للبلاطة كنسبة مئوية.

هذا المثال يتطلب صورة محلية ويُهيئ [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) لتكرارها بنسبة 50 % من حجمها الأصلي. إزاحات `−32` نقطة تُحَرّك البلاطات أفقيًا وعموديًا؛ المحاذاة السفلية‑اليمنى والقلب في الاتجاهين يُحددان كيفية ترتيب النسيج المتكرر.

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

تعبئة صلبة تعطي الشكل لونًا موحدًا واحدًا. يضبط هذا المثال [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) إلى وضع الملء الصلب ويُعيّن الأصفر عبر [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)، ثم يحفظ المستطيل في عرض.

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

![الشكل بتعبئة لون صلب](solid-color-fill.png)

## **استخدام خلفية الشريحة كملء الشكل**

استخدم [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) عندما يجب أن يطابق الشكل خلفية الشريحة، على سبيل المثال في قالب عرض تقديمي. اضبط أولاً [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) إلى [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) لإزالة أي ملء صريح. بهذه التركيبة، يستخدم الشكل خلفية الشريحة بدلًا من ملء النمط الخاص به. تفعيل العلامة وحدها لا يزيل أي ملء صريح موجود.

هذا يختلف عن [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): ملء الخلفية يغطي الكائنات خلف الشكل بمنطقة خلفية الشريحة المقابلة، بينما لا ملء يترك تلك الكائنات مرئية. يبقى التدرج مُحاذيًا مع الشريحة بدلًا من إعادة البدء داخل كل شكل.

المثال التالي ينشئ خلفية رئيسية موروثة من الشريحة ويضع شريطًا أرجوانيًا خلف ثلاثة مستطيلات. المستطيل الأيسر يستخدم الخلفية، المستطيل الأوسط لا يحتوي على ملء، والمستطيل الأيمن يتحول من ملء الخلفية إلى ملء برتقالي صريح.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// ارثِ التدرج اللوني من القالب الرئيسي.
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

// أضف هذا الكائن أولاً حتى يظهر خلف المستطيلات.
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

// عطّل ملء الخلفية قبل تطبيق ملء صريح.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

النتيجة من اليسار إلى اليمين: **ملء خلفية**, **لا ملء**, و**ملء صريح**. الشريط الأرجواني مخفي خلف المستطيلين الأيسر والأيمن لكنه يبقى مرئيًا من خلال المستطيل الأوسط.

![تعبئة خلفية، لا تعبئة، وتعبئة برتقالية صريحة فوق شريط أرجواني](background-fill.png)

السلوك نفسه ينطبق على خلفية مُحددة مباشرةً على الشريحة أو موروثة من التخطيط. يستخدم الشكل الخلفية التي تم حلها للعرض؛ المثال يترك كلًا من خلفية الشريحة والتخطيط غير محددتين بحيث يزودهما الرئيس.

## **تعيين الشفافية**

في تعبئة صلبة، يتحكم مكوّن ألفا للون في الشفافية: 0 يعني شفاف تمامًا و255 يعني غير شفاف تمامًا. يستخدم هذا المثال قيمة ألفا 128 لمستطيل أصفر، مما يجعله شفافًا تقريبًا بنسبة 50 % بحيث يظل المستطيل الموجود تحته مرئيًا. يتم تعيين اللون عبر [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

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

## **تدوير الأشكال**

استخدم [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) لتدوير الشكل في مستوى الشريحة. الزاوية تقاس بالدرجات؛ هذا المثال يدور مستطيلًا 5 درجات باتجاه عقارب الساعة ويحفظ العرض.

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

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات بروز ثلاثي الأبعاد**

استخدم [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) لإضفاء عمق وحواف بروز على الشكل. ينشئ هذا المثال إهليلجًا أخضرًا بحد برتقالي، يعيّن [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) إلى 4 نقاط، ويطبق بروزًا علويًا دائريًا بعرض وارتفاع 6 نقاط عبر [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). تجعل كاميرا أُرثوغرافية أمامية وإضاءة ثلاثية النقاط البروز مرئيًا.

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

![تأثير البروز ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثي الأبعاد**

يُتحكم في عرض الشكل ثلاثي الأبعاد عبر إعدادات الكاميرا. يستخدم هذا المثال [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) بزاوياتي العرض والطول ودوران 40، 35، و20 درجة على التوالي. يختار كاميرا إسومتريّة عبر [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) وإضاءة متوازنة عبر [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/)، ثم يحفظ المستطيل المُنسق.

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

خاصية [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) تحدد كيفية عرض شكل فردي عند مشاهدة أو معالجة عرض تقديمي في وضع أبيض وأسود. لا تُفعِّل العرض بالأبيض والأسود بمفردها، ولا تُغيّر ملء الشكل أو خطه أو تنسيقه في وضع اللون العادي.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) لاختيار السلوك المطلوب. على سبيل المثال، `Automatic` يترك تطبيق العرض يختار التحويل، و`Gray` و`LightGray` يستخدمان تلوينًا رماديًا، و`BlackWhite` يستخدم فقط الأسود والأبيض، و`Black` و`White` يجبران على لون واحد، و`Color` يحافظ على التلوين العادي، و`Hidden` يحذف الشكل في وضع الأبيض والأسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

هذا المثال ينشئ مستطيلًا برتقاليًا ويعيّن [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) إلى رمادي. الشكل المحفوظ يحتفظ بملئه البرتقالي للعرض بالألوان العادية ويطلب تلوينًا رماديًا من التطبيقات التي تحترم إعدادات العرض بالأبيض والأسود:

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

في وضع اللون العادي، يحتفظ المستطيل بملئه البرتقالي. في سير عمل عرض بالأبيض والأسود، يستخدم تلوينًا رماديًا لأن وضعه مُعيّن إلى `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل يحترم إعدادات العرض بالأبيض والأسود للعرض التقديري.

## **إعادة ضبط التنسيق**

استخدم [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) لاستعادة موضع وحجم وتنسيق العناصر النائبة في الشريحة من العناصر النائبة المقابلة في تخطيط الشريحة. يتطلب هذا المثال عرضًا موجودًا به عناصر نائبة مرتبطة بالتخطيط ويعيد ضبط كل شريحة قبل الحفظ. لا تُعاد ضبط الأشكال التي لا تقابل عنصرًا نائبًا في التخطيط.

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

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

عادةً ما تضيف الألوان وأنماط الخطوط وإعدادات التأثيرات بيانات قليلة مقارنةً بالصور والوسائط المضمَّنة. قد تزيد تعبئات الصور من حجم الملف لأن صورها تُخزن في العرض.

**كيف يمكنني اكتشاف الأشكال في شريحة تشترك في تنسيق متماثل حتى أتمكن من تجميعها؟**

قارن كل خاصية تنسيق رئيسية للشكل — التعبئة، الخط، وإعدادات التأثير. إذا طابقت جميع القيم المقابلة، اعتبر أن أنماطها متماثلة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصَّصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال ذات الأنماط المطلوبة، وأعد تطبيق تنسيقها حيثما يلزم.