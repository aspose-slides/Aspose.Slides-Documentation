---
title: "إضافة معادلات رياضية إلى عروض PowerPoint التقديمية في .NET"
linktitle: "معادلات رياضية PowerPoint"
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
description: "إدراج وتحرير المعادلات الرياضية في PowerPoint بصيغ PPT و PPTX باستخدام Aspose.Slides لـ .NET، مع دعم OMML، أدوات تنسيق، وعينات شفرة C# واضحة."
---
## **نظرة عامة**

يخزن PowerPoint المعادلات بصيغة Office Math Markup Language (OMML). باستخدام Aspose.Slides لـ .NET، يمكنك إنشاء نفس نوع المحتوى الرياضي برمجيًا: الكسور، الجذور، الدوال، الحدود، المشغّلات المتعددة، المصفوفات، المصفوفات المتعددة الأبعاد، وكتل الرياضيات المنسقة.

في PowerPoint، يضيف المستخدمون عادةً المعادلات من **Insert > Equation**:

![علامة تبويب Insert في PowerPoint مع تحديد أمر Equation](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي يتم إنشاؤه باستخدام [AddMathShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addmathshape/)، وهو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/) يخزن محتوى الرياضيات داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathparagraph/) يحتوي على عنصر واحد أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathblock/).

معظم الأمثلة أدناه تستخدم [MathematicalText](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathematicaltext/) وأساليب fluent من [IMathElement](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/) لتقليل طول الكود وجعله مقروءًا.

للحالات التي تحتاج إلى تصدير MathML، راجع [Export Math Equations from Presentations in .NET](/slides/ar/net/exporting-math-equations/).

## **إنشاء معادلة**

يمثل هذا المثال شكلًا رياضيًا ويضيف نظرية فيثاغورس:

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

{{% alert color="info" %}}
`AddMathShape` ينشئ شكلًا يحتوي بالفعل على فقرة رياضية. احصل على أول `MathPortion`، ثم `MathParagraph` الخاص به، وأضف كتل رياضية أو عناصر رياضية إليها.
{{% /alert %}}

## **إضافة الكسور**

استخدم `Divide` لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathfractiontypes/).

![كسرة رياضية مائلة تُظهر 1 مقسومًا على x](powerpoint-math-equations_4.png)

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

لإنشاء كسر مكدس، استخدم `MathFractionTypes.Bar`:

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **إضافة الجذور**

استخدم `Radical` لإنشاء جذر تربيعي، جذر مكعب، أو جذر آخر. العنصر الحالي يصبح القاعدة، والحجة تصبح الدرجة.

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

## **إضافة الدوال والحدود**

استخدم `AsArgumentOfFunction` أو `Function` للدوال مثل `sin(x)`, `log(x)`, أو أسماء دوال مخصصة. للحدود، ضع `lim` داخل [MathLimit](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathlimit/) أو استخدم `SetLowerLimit`.

![حد x عندما يقترب x من اللانهاية](powerpoint-math-equations_8.png)

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

لإنشاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **إضافة المشغلات المتعددة والتكاملات**

استخدم `Nary` للجمع، الاتحاد، التقاطع، وغيرها من المشغلات الكبيرة. استخدم `Integral` للتكاملات. كلا الطريقتين تسمحان بتحديد الحدود السفلية والعلوية.

![مجموع مع حدود سفلية وعليا](powerpoint-math-equations_7.png)

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

المشغلات المتعددة مخصصة للمشغلات الكبيرة مع حدود اختيارية. المشغلات البسيطة مثل `+`, `-`, `=` تُضاف عادةً كـ `MathematicalText` وتُدمج في التعبير.

للتكامل، استخدم `Integral`:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **إضافة المصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathmatrix/) للصفوف والأعمدة. لا تشمل المصفوفات الأقواس افتراضيًا، لذا ضع المصفوفة بين أقواس أو أقواس مربعة أو أقواس معقوفة عند الحاجة.

![مصفوفة رياضية ذات صفين وخلية واحدة فارغة](powerpoint-math-equations_10.png)

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

## **إضافة مصفوفات المعادلات**

استخدم `ToMathArray` عندما تحتاج إلى معادلات مُحاذاة أو مجموعة رأسية من التعبيرات.

![مصفوفة رياضية عمودية بها x فوق y](powerpoint-math-equations_11.png)

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

## **إضافة الدوال المثلثية**

استخدم `AsArgumentOfFunction` عندما يكون المتغيّر هو العنصر الحالي ويكون اسم الدالة معروفًا.

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

## **إضافة المؤشرات السفلية والعلوية**

استخدم المساعدات للسوابق والعلويات للمؤشرات والقوى. عندما يجب أن تظهر المؤشرات على الجانب الأيسر من القاعدة، استخدم `SetSubSuperscriptOnTheLeft`.

![حرف Y كبير مع مؤشر سفلي 1 أعلى اليسار ومؤشر علوي n](powerpoint-math-equations_9.png)

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

## **إضافة المحدّدات**

استخدم `Enclose` لتضمين تعبير داخل محددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات محددات تحتوي على عدة عناصر.

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

## **إضافة صندوق حد**

استخدم `ToBorderBox` عندما يجب أن تكون المعادلة نفسها مُحاطة بإطار.

![معادلة محاطة بصندوق تُظهر a² = b² + c²](powerpoint-math-equations_12.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **تجميع المصطلحات**

استخدم `Group` لوضع علامة تجميع فوق أو تحت تعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![التعبير x + y مُجمّع مع تسمية أي نص أدناه](powerpoint-math-equations_15.png)

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

استخدم مساعدين التنسيق فقط حيث يوضحون الصيغة. على سبيل المثال، `Overbar` يضع شريطًا فوق عنصر رياضي.

![تعبير رياضي ABC مع شريط أعلي](powerpoint-math-equations_14.png)

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

## **مرجع سريع**

| المهمة | API الرئيسي |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathematicaltext/) |
| دمج العناصر | [IMathElement.Join](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/join/) |
| إنشاء الكسور | [IMathElement.Divide](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/divide/) |
| إضافة مرتفع أو منخفض | [SetSuperscript](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| إضافة الدوال | [Function](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| إضافة الجذور | [IMathElement.Radical](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/radical/) |
| إضافة الحدود | [SetLowerLimit](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| إضافة المؤشرات الجانبية | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| إضافة الجمع والتكامل | [Nary](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/integral/) |
| إضافة المصفوفات | [MathMatrix](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathmatrix/) |
| إضافة مصفوفات المعادلات | [ToMathArray](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| إضافة المحددات | [Enclose](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/enclose/) |
| إضافة الشرائط والإطارات | [Overbar](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| تجميع المصطلحات | [Group](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/group/) |

## **الأسئلة المتكررة**

**هل يمكنني تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، ابحث عن الشكل الذي يحتوي على `MathPortion`، احصل على `MathParagraph` الخاص به، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل يتم حفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند الحفظ بصيغة PPTX، يكتب Aspose.Slides المعادلة كمحتوى Office Math قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [IMathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathparagraph/) للمعادلة من [MathPortion](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/)، ثم استدعِ [IMathParagraph.ToLatex](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathparagraph/tolatex/) لتصديره مباشرة. لمثال كامل، راجع [Export Math Equations from Presentations in .NET](/slides/ar/net/exporting-math-equations/#export-math-equations-to-latex).