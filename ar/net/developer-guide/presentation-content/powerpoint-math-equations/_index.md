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
description: "إدراج وتحرير المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides للـ .NET، مع دعم OMML، عناصر تنسيق، وأمثلة شفرة C# واضحة."
---
## **نظرة عامة**

يخزن PowerPoint المعادلات بصيغة Office Math Markup Language (OMML). باستخدام Aspose.Slides for .NET، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجيًا: الكسور، الجذور، الدوال، الحدود، عوامل N-ary، المصفوفات، المصفوفات المتعددة، وكتل الرياضيات المنسقة.

في PowerPoint، يضيف المستخدمون عادةً المعادلات من **Insert > Equation**:

![علامة تبويب Insert في PowerPoint مع تحديد أمر Equation](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

يبني Aspose.Slides ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يُنشأ باستخدام [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/)، وهو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) يخزن محتوى الرياضيات داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) يحتوي على كائن واحد أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

تستخدم معظم الأمثلة أدناه [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) والطُرق السلسة من [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) لجعل الكود مختصرًا وسهل القراءة.

لحالات تصدير MathML، راجع [Export Math Equations from Presentations in .NET](/slides/ar/net/exporting-math-equations/).

## **إنشاء معادلة**

يستخدم هذا المثال [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) لإنشاء شكل رياضي ويضيف مبرهنة فيثاغورس:

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) ينشئ شكلًا يحتوي بالفعل على فقرة رياضية. يمكن الوصول إلى أول [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)، الحصول على [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/)، وإضافة كتل رياضية أو عناصر رياضية إليها.
{{% /alert %}}

## **إضافة كسور**

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

لإنشاء كسر مكدس، استخدم [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **إضافة جذور**

استخدم [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) لإنشاء جذر تربيعي أو جذور أخرى. يصبح العنصر الحالي هو القاعدة، ويصبح الوسيط هو الدرجة.

![تعبير جذر n‑th مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

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

## **إضافة دوال وحدود**

استخدم [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) أو [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) للدوال مثل `sin(x)`, `log(x)`, أو أسماء دوال مخصصة. للحدود، ضع `lim` داخل [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) أو استخدم [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![حد x عندما يقترب x من المالانهاية](powerpoint-math-equations_8.png)

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

لإنشاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي واستدعِ [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) مع وسيلته:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **إضافة عوامل N-ary وتكاملات**

استخدم [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) للتجمعات، الاتحادات، اللقاءات، والعوامل الكبيرة الأخرى. استخدم [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) للتكاملات. تسمح الطريقتان بتعيين الحدود السفلية والعليا.

![تجميع مع حدود سفلية وعليا](powerpoint-math-equations_7.png)

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

العوامل N-ary مخصصة للعوامل الكبيرة مع حدود اختيارية. تُضاف العوامل البسيطة مثل `+`, `-`, `=` عادةً كـ [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) وتُدمج في التعبير.

للتكامل، استخدم [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) للصفوف والأعمدة. لا تتضمن المصفوفات الأقواس بحالتها الافتراضية، لذا احيط المصفوفة بأقواس أو أقواس معقوفة إذا احتجت ذلك.

![مصفوفة رياضية ذات صفين وخلية فارغة واحدة](powerpoint-math-equations_10.png)

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

## **إضافة مصفوفات معادلات**

استخدم [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) عندما تحتاج إلى معادلات محاذاة أو مجموعة رأسية من التعابير.

![مصفوفة رياضية رأسية مع x فوق y](powerpoint-math-equations_11.png)

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

### **محاذاة المصفوفة مع العناصر المجاورة**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) يتحكم في محاذاة المصفوفة الرأسية بالنسبة للعناصر الرياضية المجاورة لها. يوضح المثال أدناه المقارنة بين المحاذاة باستخدام الصف الأول، وسط المصفوفة، والصف الأخير.

المثال التالي يُنشئ ثلاث مصفوفات متماثلة، كل واحدة بثلاثة صفوف وعناصر الجوار `A=` و `=B`. يستخدم كل النص الرياضي Cambria Math بحجم 24 نقطة. يتغير فقط محاذاة المصفوفة.

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

تُظهر المقارنة التالية العرض المحفوظ في PowerPoint. لاحظ موضع `A=` و `=B` بجانب كل مصفوفة.

![مصفوفات معادلات في PowerPoint مع محاذاة أعلى، وسط، وأسفل وعناصر مجاورة متطابقة](equation-array-alignment.png)

### **تكوين تباعد الصفوف**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) يحدد قاعدة التباعد للصفوف داخل المصفوفة. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) يزوّد قيمة رقمية لقاعدة تباعد صريحة ويتم تجاهلها عندما تُختار القواعد المسبقة.

للتباعد الدقيق، تُقاس القيمة بالنقاط. للتباعد النسبي، تُقاس بنصف أسطر: القيمة `3` في المثال تمثل 1.5 سطر. عيّن كلتا الخاصيتين عند تحديد قيمة صريحة؛ تغيير القيمة الرقمية وحدها لا يختار قاعدة تباعد.

المثال أدناه يحفظ خمس عروض تقديمية بنفس المعادلات، والمحاذاة، وإعدادات الخط. الثلاثة الأولى تستخدم القواعد المسبقة؛ الأخيرة تُظهر قيمًا صريحة.

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

تباعد صفوف المصفوفة مستقل عن تباعد الفقرة. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) و [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) يضيفان مساحة حول الفقرة المحتوية، لا بين صفوف المصفوفة. وبالمثل، [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) يحدد موضع الفقرة الرياضية بأكملها أفقياً؛ ولا يُبدّل إعداد المحاذاة الرأسية للمصفوفة.

## **إضافة الدوال المثلثية**

استخدم [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) عندما يكون الوسيط هو العنصر الحالي ويكون اسم الدالة معروفًا.

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

## **إضافة أسفل وأسفل مرتفع (Subscript & Superscript)**

استخدم المساعدين للارتفاع الأسفل والعلوي للفهارس والقوى. عندما يجب أن تظهر الفهارس على الجانب الأيسر للقاعدة، استخدم [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![الحرف Y كبير مع أسفل يسار 1 وعلوي n](powerpoint-math-equations_9.png)

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

## **إضافة محددات (Delimiters)**

استخدم [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) لوضع تعبير داخل محددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات محددات تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x و y و z مفصولة بأعمدة عمودية](powerpoint-math-equations_13.png)

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

اضبط [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) إلى `true` لجعل الأقواس تنمو حول مُعامل طويل، أو إلى `false` لإبقائها بحجمها الطبيعي. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) يأخذ إحدى قيمتي [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` يوسّط الأقواس على محور الرياضيات الذي يمر بمنتصف علامة المساواة. `Match` يطابق ارتفاعها مع المحتوى المُحاط. كلا الإعدادين يؤثران فقط على المحددات؛ يبقى التعبير داخلها كما هو.

يضع المثال كسرًا في أُس `x` بحيث يمتد التعبير أعلى من خط القاعدة أكثر من أسفله. جميع المعادلات الأربع تستخدم نفس الأقواس وإعدادات الخط.

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

في PowerPoint، قارن الصفوف لرؤية تأثير النمو. في الصف العلوي، تنمو الأقواس لتُحاط بالأُس وتتشابه للنوعين. في الصف السفلي، يكون النمو معطلًا. الأقواس الصغيرة على اليسار (`Centered`) تُنسق مع علامة المساواة، بينما الأقواس على اليمين (`Match`) تُعلي فوق التعبير.

![أربع معادلات في PowerPoint مع تمكين نمو المحددات أعلاه وتعطيله أدناه، وCentered على اليسار وMatch على اليمين](delimiter-sizing.png)

## **إضافة صندوق حدودي (Border Box)**

استدعِ [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) على كسر لتأطير التعبير بالكامل. يُظهر [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) الأربعة جوانب بشكل افتراضي. استخدم [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/)، [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/)، [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/)، و [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) لإزالة الجوانب الفردية.

يضع المثال ست نسخ من نفس الكسر على شريحة واحدة. لإظهار الإلغاء، أخفِ جميع الجوانب الأربعة واضبط [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) لخط مائل صاعد (↗) أو [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) لخط مائل هابط (↘). يمكنك أيضًا استخدام [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) أو [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) مع أي تركيبة من الجوانب المرئية.

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

![ستة كسور قابلة للتحرير في PowerPoint. الصف العلوي: حد كامل، الجانب السفلي واليسار، خط مائل صاعد. الصف السفلي: خط مائل هابط، شطب أفقي، شطب عمودي مع حد كامل.](border-box-fractions.png)

في هذا الكسر، يتقاطع الشطب الأفقي مع خط الكسر. الشطب العمودي يمر عبر البسط والمقام بينما يبقى الحد المحيط مرئيًا. هذه الخطوط تُزيّن التعبير بالكامل. شطب النص العادي يطبق على الأحرف داخل مقطع النص. بعد إعادة فتح العرض التقديمي في PowerPoint، يمكنك لا يزال تعديل البسط والمقام بشكل مستقل.

## **تجميع المصطلحات**

استخدم [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) لوضع حرف تجميع فوق أو تحت تعبير. أضف حدًا لتسمية المصطلحات المجَمَّعة.

![التعبير x + y مُجمَّع مع تسمية أي نص تحته](powerpoint-math-equations_15.png)

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

استخدم مساعدات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) يضع شريطًا فوق عنصر رياضي.

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

لتنسيق النص عبر معادلة موجودة، تجول في شجرة عناصر كل كتلة رياضية. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) يُرجِع فقط الأطفال المباشرين، لذا استدعِه بشكل متكرر للوصول إلى النص داخل الكسور والأنساق والجذور والهياكل المتداخلة الأخرى. افحص العنصر الحالي وكذلك أطفاله لتضمين العنصر الابتدائي عندما يكون [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

يفترض هذا المثال أن العرض التقديمي يحتوي على معادلة مثل `z = xᵢ / ∛y`، حيث يحتوي الكسر على أسفل في البسط وجذر في المقام. معالجة العناصر العليا للكتلة فقط سيتخطى النص داخل الكسر. يجد المثال أجزاء رياضية داخل إطارات نص الشرائح، ويصل إلى كتلها عبر [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/)، ويضبط [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) إلى 28 نقطة لكل عنصر نصي عبر خاصية [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/).

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

العرض التقديمي المحفوظ يحتوي على تنسيق النص المحدث في كل مستوى من كل معادلة مُعالجة، مع الحفاظ على محتوى النص والهيكل الرياضي.

## **مرجع سريع**

| المهمة | API الرئيسي |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| دمج العناصر | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| إنشاء كسور | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| إضافة أسفل أو أعلى | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| إضافة دوال | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| إضافة جذور | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| إضافة حدود | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| إضافة سكربتات على الجانب الأيسر | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| إضافة تجميعات وتكاملات | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| إضافة مصفوفات معادلات | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| إضافة محددات | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| إضافة أشرطة وحدود | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| تجميع المصطلحات | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **الأسئلة المتكررة**

**هل يمكن تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، ابحث عن الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)، احصل على [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/)، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف كـ PPTX، يكتب Aspose.Slides المعادلة كمحتوى Office Math قابل للتحرير.

**هل يمكن تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) من [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) الخاص به، واستدعي [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) لتصديرها مباشرة. لمثال كامل، راجع [Export Math Equations from Presentations in .NET](/slides/ar/net/exporting-math-equations/#export-math-equations-to-latex).