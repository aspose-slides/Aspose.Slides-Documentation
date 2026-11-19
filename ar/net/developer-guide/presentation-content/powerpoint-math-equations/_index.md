---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية في .NET
linktitle: معادلات رياضية PowerPoint
type: docs
weight: 80
url: /ar/net/powerpoint-math-equations/
keywords:
- معادلة رياضية
- رمز رياضي
- صيغة رياضية
- نص رياضي
- إضافة معادلة رياضية
- إضافة رمز رياضي
- إضافة صيغة رياضية
- إضافة نص رياضي
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدراج وتحرير المعادلات الرياضية في PowerPoint PPT و PPTX باستخدام Aspose.Slides لـ .NET، يدعم OMML، أدوات تنسيق، وعينات كود C# واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات كـ Office Math Markup Language (OMML). باستخدام Aspose.Slides لـ .NET، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجيًا: الكسور، الجذور، الدوال، الحدود، عوامل N-ary، المصفوفات، المصفوفات، والكتل الرياضية المنسقة.

في PowerPoint، عادةً ما يضيف المستخدمون المعادلات من **Insert > Equation**:

![علامة تبويب إدراج في PowerPoint مع تحديد أمر المعادلة](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يُنشأ باستخدام [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/)، هو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) يخزن محتوى الرياضيات داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) يحتوي على كائن واحد أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

معظم الأمثلة أدناه تستخدم [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) والطرق المتسلسلة من [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) لجعل الكود قصيرًا وسهل القراءة.

للتصدير إلى MathML، راجع [Export Math Equations from Presentations in .NET](/slides/ar/net/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال يستخدم [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) لإنشاء شكل رياضي ويضيف نظرية فيثاغورس:

![المعادلة c² = a² + b²](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) يُنشئ شكلًا يحتوي بالفعل على فقرة رياضية. احصل على أول [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)، ثم على [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/)، وأضف كتلًا رياضية أو عناصر رياضية إليها.
{{% /alert %}}

### **دمج كتل الرياضيات**

عند بناء أجزاء المعادلة بشكل مستقل ككائنات [IMathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/)، استخدم [JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) لدمجها. يبني المثال `c² =` في الكتلة اليسرى و`a² + b²` في الكتلة اليمنى. [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/) يُنشئ روفات رياضية قابلة للتحرير لجميع القوى الثلاث.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddMathShape(20, 20, 600, 100);
var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var leftBlock = new MathBlock();
leftBlock.Add(new MathematicalText("c").SetSuperscript("2"));
leftBlock.Add(new MathematicalText("="));

var rightBlock = new MathBlock();
rightBlock.Add(new MathematicalText("a").SetSuperscript("2"));
rightBlock.Add(new MathematicalText("+"));
rightBlock.Add(new MathematicalText("b").SetSuperscript("2"));

var combinedBlock = leftBlock.JoinBlock(rightBlock);
mathParagraph.Add(combinedBlock);

presentation.Save("equation.pptx", SaveFormat.Pptx);
```

[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) تُعيد `leftBlock` نفسها، الآن تحتوي على الجزئين بالترتيب، وتترك `rightBlock` فارغة. أضف الكتلة المدمجة إلى [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) مرة واحدة فقط. بعد إعادة فتح `equation.pptx`، تحتوي الفقرة على كتلة واحدة تمثل `c² = a² + b²`، مع الحفاظ على جميع الروفات كروفات رياضية.

استدعاء [Add](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelementcollection/add/) كـ `leftBlock.Add(rightBlock)` يحاول بدلًا من ذلك دمج كتلة داخل أخرى مباشرةً ويرمي استثناء `InvalidOperationException`.

## **إضافة الكسور**

استخدم [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![كسر مائل يظهر 1 مقسومًا على x](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

للكسور المتراصة، استخدم [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **إضافة الجذور**

استخدم [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) لإنشاء جذر تربيعي أو مكعب أو جذر آخر. يصبح العنصر الحالي القاعدة، والمُعامل هو الدرجة.

![تعبير جذر n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

### **إظهار أو إخفاء درجة الجذر التربيعي**

يمكن للجذر التربيعي إظهار 2 صريحة أو استخدام الصيغة التقليدية √x. خاصية [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) في [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) تتحكم في الشكل الظاهر. كلا الشكلين يحتفظان بالدرجة 2 والجوهر x في المعادلة القابلة للتحرير.

![نفس الجذر مع HideDegree مضبوطة على false على اليسار وtrue على اليمين](square-root-degree.png)

يحفظ المثال الجذر نفسه مرتين. في `visible-degree.pptx` تكون الـ2 مرئية. في `hidden-degree.pptx` تكون مخفية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var radical = new MathematicalText("x").Radical("2");

var shape = slide.Shapes.AddMathShape(20, 20, 200, 100);
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
portion.MathParagraph.Add(new MathBlock(radical));

radical.HideDegree = false;
presentation.Save("visible-degree.pptx", SaveFormat.Pptx);

radical.HideDegree = true;
presentation.Save("hidden-degree.pptx", SaveFormat.Pptx);
```

## **إضافة الدوال والحدود**

استخدم [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) أو [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) للدوال مثل `sin(x)`, `log(x)`, أو أسماء دوال مخصصة. للحدود، ضع `lim` داخل [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) أو استخدم [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![حد x عندما يقترب x من مالانهاية](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

لإنشاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي واستدعِ [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) مع معاملها:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **إضافة عوامل N-ary والتكاملات**

استخدم [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) للجمع، الاتحاد، التقاطع، وغيرها من العوامل الكبيرة. استخدم [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) للتكاملات. كلا الطريقتين تسمحان بضبط الحدود السفلية والعليا.

![جمع مع حدود سفلية وعليا](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

العوامل N-ary مخصصة للعوامل الكبيرة مع حدود اختيارية. العوامل البسيطة مثل `+`, `-`, `=` غالبًا ما تُضاف كـ [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) وتُدمج في التعبير.

للتكامل، استخدم [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **إضافة المصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تتضمن الأقواس بشكل افتراضي، لذا أغلق المصفوفة بالأقواس أو القوسين أو الأقواس المعقوفة عند الحاجة.

![مصفوفة رياضية ذات صفّين وخلية فارغة واحدة](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

### **تحرير مصفوفة موجودة**

افترض أن درس الجبر الخطي يبدأ بمصفوفة المعاملات في `matrix.pptx`، التي حفظها المثال السابق. للتمرين التالي، احتفظ بالمعادلة الأولى، استبدل الثانية بمعادلتين جديدتين، وعدّل مجموعة المتغيّرات. افتح المصفوفة الموجودة عبر [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) للحفاظ على المعاملات التي لا تزال صالحة.

![المصفوفة الأصلية ذات صفّين مع القيم 1، x، وخلية فارغة في الصف الأول، وx، 2، y في الصف الثاني](matrix-before-edit.png)

تبدأ مؤشرات الصف والعمود من الصفر وتشير إلى المصفوفة كما هي عند كل استدعاء. إدراج صف قبل الفهرس 1 ينقل الصف الأصلي الثاني إلى الفهرس 2. الإدراج بعد الفهرس 2 يضيف صفًا. حذف الصف 2 يزيل المعادلة الأصلية الثانية وينقل الصف المضاف أعلى موقعًا واحدًا. الأعمدة تتحرك بنفس الطريقة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("matrix.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
var matrix = (IMathMatrix)portion.MathParagraph[0][0];

matrix.InsertRowBefore(1);
matrix.InsertRowAfter(2);
matrix.DeleteRow(2);

matrix.InsertColumnBefore(1);
matrix.InsertColumnAfter(3);
matrix.DeleteColumn(3);

// الخلايا الجديدة في البداية تكون null. عيّن المعاملات غير الصفرية أولاً.
matrix[1, 0] = new MathematicalText("12");
matrix[1, 1] = new MathematicalText("1");
matrix[2, 2] = new MathematicalText("10");
matrix[2, 3] = new MathematicalText("1");
for (var row = 0; row < matrix.RowCount; row++)
{
    for (var column = 0; column < matrix.ColumnCount; column++)
    {
        matrix[row, column] ??= new MathematicalText("0");
    }
}

matrix.SetColumnAlignment(0, MathHorizontalAlignment.Left);
matrix.SetColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

presentation.Save("updated-matrix.pptx", SaveFormat.Pptx);
```

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) يحدّد محاذاة العمود الأول إلى اليسار. [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) يحدّد محاذاة ثلاث أعمدة متتالية إلى اليمين، بدءًا من الفهرس 1. في `updated-matrix.pptx`، تحتوي المصفوفة على ثلاث معادلات وأربعة متغيّرات. أصبحت المعاملات الأصلية للصف الأول `1` و`x` الآن في العمودين الأول والثالث.

![المصفوفة المحدثة ذات ثلاث صفوف تُظهر الصفوف 1،0،x،0؛ 12،1،0،0؛ و0،0،10،1](matrix-after-edit.png)

## **إضافة مصفوفات المعادلات**

استخدم [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) عندما تحتاج إلى معادلات محاذاة أو رصة عمودية من التعابير.

![مصفوفة رياضية عمودية مع x فوق y](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

### **محاذاة مصفوفة مع العناصر المحيطة**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) تتحكم في محاذاة المصفوفة عموديًا بالنسبة للعناصر الرياضية المجاورة. يقارن المثال أدناه المحاذاة مع الصف الأول، مركز المصفوفة، والصف الأخير.

المثال التالي ينشئ ثلاث مصفوفات متطابقة، كل واحدة بثلاث صفوف والعناصر المجاورة `A=` و`=B`. جميع النصوص الرياضية تستخدم Cambria Math بحجم 24 نقطة. تغير فقط محاذاة المصفوفة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(780, 200, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var alignments = new[] { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };

for (int i = 0; i < alignments.Length; i++)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = alignments[i].ToString();
    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 16;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var mathShape = slide.Shapes.AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    var mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Justification = MathJustification.LeftJustified;

    var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
    var equationArray = new MathArray(rows);
    equationArray.BaseJustification = alignments[i];
    var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
    mathParagraph.Add(equation);
}

presentation.Save("equation-array-alignment.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

المقارنة التالية تُظهر العرض المحفوظ في PowerPoint. لاحظ موضع `A=` و`=B` بجانب كل مصفوفة.

![مصفوفات المعادلات في PowerPoint مع محاذاة عليا، مركزية، وسفلية وعناصر مجاورة متطابقة](equation-array-alignment.png)

### **تكوين تباعد الصفوف**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) تحدد قاعدة التباعد للصفوف داخل المصفوفة. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) تُعطي قيمة عددية لقاعدة تباعد صريحة وتُهمل عندما تُستخدم القواعد المسبقة.

للتباعد الدقيق، تُقاس القيمة بالنقاط. للتباعد النسبي، تُقاس بنصف خطوط: القيمة `3` في المثال تعني 1.5 خط. ضع كلا الخاصيتين عند تحديد قيمة صريحة؛ تغيير القيمة العددية فقط لا يغيّر القاعدة.

المثال أدناه يحفظ خمس عروض تقديمية بنفس المعادلات، المحاذاة، وإعدادات الخط. الثلاثة الأولى تستخدم القواعد المسبقة؛ الأخيرتين تُظهران قيمًا صريحة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

var settings = new (MathRowSpacingRule Rule, uint Spacing)[]
{
    (MathRowSpacingRule.SingleLineGap, 0),
    (MathRowSpacingRule.OneAndAHalfLineGap, 0),
    (MathRowSpacingRule.TwoLineGap, 0),
    (MathRowSpacingRule.Exactly, 20),
    (MathRowSpacingRule.Multiple, 3)
};

foreach (var setting in settings)
{
    var fileName = $"equation-array-{setting.Rule}.pptx";
    using (var presentation = new Presentation())
    {
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(20, 20, 600, 300);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        paragraph.ParagraphFormat.SpaceBefore = 0;
        paragraph.ParagraphFormat.SpaceAfter = 0;
        var mathParagraph = ((IMathPortion)paragraph.Portions[0]).MathParagraph;
        mathParagraph.Justification = MathJustification.LeftJustified;

        var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
        var equationArray = new MathArray(rows);
        equationArray.BaseJustification = MathVerticalAlignment.Center;
        equationArray.RowSpacingRule = setting.Rule;
        equationArray.RowSpacing = setting.Spacing;
        var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
        mathParagraph.Add(equation);

        presentation.Save(fileName, SaveFormat.Pptx);
    }

}

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

تباعد صفوف المصفوفة منفصل عن تباعد الفقرة. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) و[SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) يضيفان مسافة حول الفقرة المحتوية، وليس بين صفوف المصفوفة. كذلك، [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) يحدد موضع الفقرة الرياضية ككل أفقيًا؛ لا يُستبدل بإعدادات المحاذاة العمودية للمصفوفة.

## **إضافة الدوال المثلثية**

استخدم [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) عندما يكون المتغيّر هو العنصر الحالي ويُعرف اسم الدالة.

![الدالة المثلثية cos مطبقة على 2x](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **إضافة المؤشرات والروفات**

استخدم الأدوات المساعدة للمؤشرات والروفات للفهارس والقوى. عندما يجب أن تظهر المؤشرات على الجانب الأيسر من القاعدة، استخدم [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![حرف Y كبير مع مؤشر سفلي 1 وروفة عليا n على الجانب الأيسر](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **إضافة المحددات**

استخدم [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) لوضع تعبير داخل محددات. يمكنك أيضًا ضبط حرف فاصل لتعبيرات المحدد التي تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x، y، وz مفصول بأعمدة رأسية](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

### **حجم وتنسيق المحددات**

اضبط [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) إلى `true` لتسمح للأقواس بالنمو حول عامل طويل، أو إلى `false` لإبقائها بحجمها الطبيعي. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) تقبل إحدى قيمتي [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` يوسّط الأقواس على محور الرياضيات، الذي يمر عبر منتصف علامة المساواة. `Match` يطابقها مع المحتوى المغلق. كلا الإعدادين يؤثران فقط على المحددات؛ يبقى التعبير الداخلي كما هو.

المثال يضع كسرًا في أسس `x` بحيث يمتد التعبير أعلى الخط الأساسي أكثر من أسفله. جميع المعادلات الأربعة تستخدم نفس الأقواس وإعدادات الخط.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

في PowerPoint، قارن الصفوف لترى تأثير النمو. في الصف العلوي، تنمو الأقواس لتغلق الأس وتبدو متشابهة لكلا الشكلين. في الصف السفلي، يكون النمو مُعطَّلًا. الأقواس الأصغر على اليسار (`Centered`) تتطابق مع علامة المساواة، بينما الأقواس على اليمين (`Match`) ترتفع حول التعبير.

![أربع معادلات في PowerPoint مع تمكين نمو المحددات أعلاه وتعطيله أدناه، و`Centered` على اليسار و`Match` على اليمين](delimiter-sizing.png)

## **إضافة صندوق حدود**

استدعِ [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) على كسر لتؤطّر التعبير بالكامل. الكائن المُُرجع [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) يُظهر جميع الجوانب الأربعة افتراضيًا. استخدم [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/)، [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/)، [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/)، و[HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) لإزالة جوانب محددة.

المثال يضع ست نسخ من نفس الكسر على شريحة واحدة. لإظهار الإلغاء، أخفِ جميع الجوانب الأربعة واضبط [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) لخط قطري صاعد (↗) أو [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) لخط قطري هابط (↘). يمكنك أيضًا استخدام [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) أو [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) مع أي تركيبة من الجوانب المرئية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(540, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

IMathBorderBox AddFraction(float x, float y, bool hideBorder = false)
{
    var fraction = new MathematicalText("x+1").Divide("y+2");
    var box = fraction.ToBorderBox();
    box.HideTop = box.HideBottom = box.HideLeft = box.HideRight = hideBorder;

    var shape = slide.Shapes.AddMathShape(x, y, 160, 90);
    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 28;
    portion.MathParagraph.Add(new MathBlock(box));
    return box;
}

AddFraction(10, 10);

var partial = AddFraction(190, 10);
partial.HideTop = true;
partial.HideRight = true;

AddFraction(370, 10, hideBorder: true).StrikethroughBottomLeftToTopRight = true;
AddFraction(10, 120, hideBorder: true).StrikethroughTopLeftToBottomRight = true;
AddFraction(190, 120, hideBorder: true).StrikethroughHorizontal = true;
AddFraction(370, 120).StrikethroughVertical = true;

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

![ستة كسور قابلة للتحرير في PowerPoint. الصف العلوي: حد كامل، جوانب أسفل ويسار، وخط قطري صاعد. الصف السفلي: خط قطري هابط، خط أفقي، خط عمودي مع حد كامل.](border-box-fractions.png)

في هذا الكسر، يتقاطع الخط الأفقي مع شريط الكسر. الخط العمودي يقطع البسط والمقام مع بقاء الحد الخارجي مرئيًا. هذه الخطوط تزيّن التعبير كاملًا. يُطبق الشطب العادي على الأحرف داخل مقطع نصي. بعد إعادة فتح العرض التقديمي في PowerPoint، لا يزال بإمكانك تحرير البسط والمقام بشكل مستقل.

## **التحكم في الإظهار والتخطيط باستخدام عناصر الفانتوم**

لفّ تعبير داخل [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) للتحكم في إظهاره والمسافة التي يضيفها إلى المعادلة بشكل مستقل. خصائص [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) تتحكم فيما يلي:

| الخاصية | التأثير |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | اضبطها على `false` لإخفاء التعبير. أبعاده لا تزال تُساهم في التخطيط ما لم تكن الخصائص المقابلة أدناه `true`. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | اعتبر العرض الأفقي للتعبير صفرًا، مما يسمح للعناصر المجاورة بالاقتراب أكثر. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | اعتبر الصعود (الارتفاع أعلى الخط الأساسي) صفرًا. يمكن أن يقلل ذلك من المسافة المحجوزة فوق العناصر المجاورة. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | اعتبر النزول (العمق أسفل الخط الأساسي) صفرًا. يمكن أن يقرّب شريط الكسر أو محتوى آخر أسفل التعبير من جيرانه. |

الخط الأساسي هو الخط المرجعي الذي تجلس عليه الأحرف الرياضية العادية. إخفاء المحتوى لا يزيل أبعاده، وتعيين بعد كصفر لا يحذف التعبير. يبقى التعبير الأساسي متاحًا عبر [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/). اضبط [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) مرة أخرى إلى `true` لإظهاره مرة أخرى؛ تظل إعدادات الأبعاد كما هي.

المثال أدناه ينشئ خمس متغيّرات متجاورة: كسر مرئي، كسر مخفي يحتفظ بالمسافة، وثلاث كسور مخفية مع تعيين بعد واحد إلى صفر. كل متغيّر يستخدم نفس التعبير المحيط وCambria Math بحجم 24 نقطة. جميع أشكال المعادلة لها نفس الموضع العلوي، المعلَّم بالدليل الرمادي. وضع الفانتوم في البسط لكسر خارجي يجعل تغيّر التخطيط العمودي أسهل للتمييز.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(1000, 180, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var labels = new[] { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

var guide = slide.Shapes.AddAutoShape(ShapeType.Line, 10, 60, 980, 0);
guide.LineFormat.FillFormat.FillType = FillType.Solid;
guide.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

for (var i = 0; i < labels.Length; i++)
{
    var left = 10 + i * 200;
    
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = labels[i];

    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 14;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var fraction = new MathFraction(CreateText("a+b"), CreateText("c+d"));
    var phantom = new MathPhantom(fraction);
    phantom.Show = i == 0;
    phantom.ZeroWidth = i == 2;
    phantom.ZeroAsc = i == 3;
    phantom.ZeroDesc = i == 4;

    var numerator = new MathBlock(CreateText("x+")).Join(phantom).Join(CreateText("+y"));
    var equation = new MathFraction(numerator, CreateText("z"));

    var shape = slide.Shapes.AddMathShape(left, 60, 190, 100);
    shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;

    var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Add(new MathBlock(equation));
}

presentation.Save("math-phantom.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

![خمسة معادلات في PowerPoint تقارن كسرًا مرئيًا، كسرًا مخفيًا يحتفظ بالمسافة، وكسرًا مخفيًا مع ZeroWidth أو ZeroAsc أو ZeroDesc مفعَّل](math-phantom.png)

## **تجميع المصطلحات**

استخدم [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) لوضع حرف تجميع فوق أو تحت تعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![التعبير x + y مُجمَّع مع تسمية any text أسفله](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **تنسيق عناصر الرياضيات**

استخدم أدوات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) يضع شريطًا فوق عنصر رياضي.

![تعبير رياضي ABC مع شريط فوقه](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **تنسيق النص في معادلة موجودة**

لتنسيق النص عبر معادلة موجودة، استعرض شجرة عناصر كل كتلة رياضية. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) تُعيد الأطفال المباشرين فقط، لذا استدعها بشكلٍ متكرر للوصول إلى النص داخل الكسور، الروفات، الجذور، والبنى المتداخلة الأخرى. افحص العنصر الحالي بالإضافة إلى أطفاله لتضمين العنصر الابتدائي عندما يكون [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

يفترض هذا المثال أن عرضًا تقديميًا يحتوي على معادلة مثل `z = xᵢ / ∛y`، مع كسر يحتوي على مؤشر سفلي في البسط وجذر في المقام. معالجة العناصر ذات المستوى الأعلى فقط سيفوت النص داخل الكسر. يجد المثال أجزاء رياضية في إطارات نص الشرائح، يصل إلى كتلها عبر [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/)، ويضبط [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) إلى 28 نقطة من خلال خاصية [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) لكل عنصر نصي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

العرض التقديمي المحفوظ يحتوي على تنسيق نص محدث على كل مستوى من كل معادلة تم معالجتها، مع الحفاظ على محتوى النص والبنية الرياضية.

## **مرجع سريع**

| المهمة | واجهة برمجة التطبيقات الأساسية |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| دمج العناصر | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| إنشاء الكسور | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| إضافة رُفعة أو مؤشر سفلي | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| إضافة الدوال | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| إضافة الجذور | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| إضافة الحدود | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| إضافة الروفات الجانبية | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| إضافة الجمع والتكامل | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| إضافة المصفوفات | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| إضافة مصفوفات المعادلات | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| إضافة المحددات | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| إضافة الشرط والحدود | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| تجميع المصطلحات | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **الأسئلة المتكررة**

**هل يمكنني تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، ابحث عن الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)، احصل على [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) الخاص به، وحدث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف بصيغة PPTX، يكتب Aspose.Slides المعادلة كقابلية تحرير لمحتوى Office الرياضي.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) للمعادلة من [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)، ثم استدعِ [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) لتصديره مباشرةً. لمثال كامل، راجع [Export Math Equations from Presentations in .NET](/slides/ar/net/exporting-math-equations/#export-math-equations-to-latex).