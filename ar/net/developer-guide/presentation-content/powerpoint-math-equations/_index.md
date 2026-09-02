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
description: "إدراج وتحرير معادلات رياضية في PowerPoint PPT و PPTX باستخدام Aspose.Slides لـ .NET، مع دعم OMML، وضوابط التنسيق، وأمثلة كود C# واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات بصيغة Office Math Markup Language (OMML). باستخدام Aspose.Slides لـ .NET، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجيًا: الكسور، الجذور، الدوال، الحدود، المشغلات ذات N-ary، المصفوفات، المصفوفات المتعددة الأبعاد، وكتل الرياضيات المنسقة.

في PowerPoint، يضيف المستخدمون عادةً المعادلات من **Insert > Equation**:

![علامة تبويب إدراج PowerPoint مع أمر المعادلة محدد](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يتم إنشاؤه باستخدام [AddMathShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addmathshape/)، هو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/) يخزن محتوى الرياضيات داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathparagraph/) يحتوي على كائن واحد أو أكثر من [MathBlock](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathblock/) .

معظم الأمثلة أدناه تستخدم [MathematicalText](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathematicaltext/) والطرق السلسة من [IMathElement](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/) للحفاظ على الشيفرة قصيرة وقابلة للقراءة.

للحالات التي تحتاج تصدير MathML، انظر [Export Math Equations from Presentations in .NET](/slides/ar/net/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال ينشئ شكلًا رياضيًا ويضيف نظرية فيثاغورس:

![المعادلة c تربيع يساوي a تربيع زائد b تربيع](powerpoint-math-equations_3.png)

```csharp
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

{{% alert color="primary" %}}
`AddMathShape` ينشئ شكلًا يحتوي بالفعل على فقرة رياضية. احصل على أول `MathPortion`، استخرج `MathParagraph` الخاص به، وأضف كتل رياضية أو عناصر رياضية إليه.
{{% /alert %}}

## **إضافة الكسور**

استخدم `Divide` لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathfractiontypes/).

![كسر رياضي مائل يظهر واحد مقسوم على x](powerpoint-math-equations_4.png)

```csharp
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
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **إضافة الجذور**

استخدم `Radical` لإنشاء جذر تربيعي، جذر مكعب، أو أي جذر آخر. العنصر الحالي يصبح القاعدة، والحجة تصبح الدرجة.

![تعبير جذري من الدرجة n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

```csharp
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

لإعطاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي:

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **إضافة المشغلات N-ary والتكاملات**

استخدم `Nary` للجمع، الاتحاد، التقاطع، وغيرها من المشغلات الكبيرة. استخدم `Integral` للتكاملات. كلا الطريقتين تتيحان ضبط الحدود السفلية والعلوية.

![جمع بحدود سفلى وعليا](powerpoint-math-equations_7.png)

```csharp
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

المشغلات N-ary مخصصة للمشغلات الكبيرة مع حدود اختيارية. المشغلات البسيطة مثل `+`, `-`, و `=` عادةً تُضاف كـ `MathematicalText` وتُدمج داخل التعبير.

للتكامل، استخدم `Integral`:

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **إضافة المصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تتضمن أقواس بحالتها الافتراضية، لذا أغلق المصفوفة عندما تحتاج إلى أقواس مستديرة أو مربعة أو معقوفة.

![مصفوفة رياضية ذات صفين وخلية فارغة واحدة](powerpoint-math-equations_10.png)

```csharp
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

استخدم `ToMathArray` عندما تحتاج إلى معادلات محاذية أو مجموعة عمودية من التعبيرات.

![مصفوفة رياضية عمودية مع x فوق y](powerpoint-math-equations_11.png)

```csharp
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

استخدم `AsArgumentOfFunction` عندما يكون المتغير هو العنصر الحالي ويكون اسم الدالة معروفًا.

![الدالة المثلثية cos تطبق على 2x](powerpoint-math-equations_6.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **إضافة المؤشرات والحمولات السفلية والعليا**

استخدم المساعدات الخاصة بالمؤشرات والحمولات للفهارس والقوى. عندما يجب أن تظهر الفهارس على الجانب الأيسر من القاعدة، استخدم `SetSubSuperscriptOnTheLeft`.

![حرف Y كبير مع مؤشر سفلي 1 وحمل علوي n على الجانب الأيسر](powerpoint-math-equations_9.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **إضافة محددات**

استخدم `Enclose` لوضع تعبير داخل محددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات محددات تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x ، y ، و z مفصولة بأعمدة عمودية](powerpoint-math-equations_13.png)

```csharp
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

## **إضافة إطار محيط**

استخدم `ToBorderBox` عندما يجب أن تكون المعادلة نفسها محاطة بإطار.

![معادلة في إطار تُظهر a² = b² + c²](powerpoint-math-equations_12.png)

```csharp
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

## **تجميع الحدود**

استخدم `Group` لوضع رمز تجميع فوق أو تحت التعبير. أضف حدًا لتسمية الحدود المجمعّة.

![التعبير x + y مُجَمّع مع التسمية أي نص تحته](powerpoint-math-equations_15.png)

```csharp
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

استخدم مساعدات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، `Overbar` يضع شريطًا فوق عنصر رياضي.

![تعبير رياضي ABC مع شريط فوقه](powerpoint-math-equations_14.png)

```csharp
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
| إنشاء كسور | [IMathElement.Divide](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/divide/) |
| إضافة أس فوق أو أس أسفل | [SetSuperscript](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| إضافة الدوال | [Function](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| إضافة جذور | [IMathElement.Radical](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/radical/) |
| إضافة حدود | [SetLowerLimit](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| إضافة مؤشرات على الجانب الأيسر | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| إضافة عمليات الجمع والتكامل | [Nary](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/integral/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathmatrix/) |
| إضافة مصفوفات المعادلات | [ToMathArray](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| إضافة محددات | [Enclose](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/enclose/) |
| إضافة أشرطة وإطارات | [Overbar](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| تجميع الحدود | [Group](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathelement/group/) |

## **الأسئلة الشائعة**

**هل يمكنني تحرير معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، ابحث عن الشكل الذي يحتوي على `MathPortion`، احصل على `MathParagraph` الخاص به، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف بصيغة PPTX، يكتب Aspose.Slides المعادلة كمحتوى رياضي Office قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [IMathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathparagraph/) للمعادلة من [MathPortion](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/)، ثم استدعِ [IMathParagraph.ToLatex](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathparagraph/tolatex/) لتصديره مباشرة. للحصول على مثال كامل، انظر [Export Math Equations from Presentations in .NET](/slides/ar/net/exporting-math-equations/#export-math-equations-to-latex).