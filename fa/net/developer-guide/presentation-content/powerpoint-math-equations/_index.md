---
title: افزودن معادلات ریاضی به ارائه‌های PowerPoint در .NET
linktitle: معادلات ریاضی PowerPoint
type: docs
weight: 80
url: /fa/net/powerpoint-math-equations/
keywords:
- معادله ریاضی
- نماد ریاضی
- فرمول ریاضی
- متن ریاضی
- افزودن معادله ریاضی
- افزودن نماد ریاضی
- افزودن فرمول ریاضی
- افزودن متن ریاضی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "در PowerPoint PPT و PPTX معادلات ریاضی را با Aspose.Slides برای .NET وارد و ویرایش کنید؛ پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های کد واضح C#."
---
## **بررسی کلی**

PowerPoint معادلات را به عنوان زبان نشانه‌گذاری ریاضی Office (OMML) ذخیره می‌کند. با Aspose.Slides برای .NET، می‌توانید همان نوع محتوای ریاضی را به صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدها، عملگرهای N‑ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![برگه Insert در PowerPoint با فرمان Equation انتخاب‌شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش روی اسلاید است:

![یک اسلاید PowerPoint شامل یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) ایجاد می‌شود، شکلی است که معادله را شامل می‌شود.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) محتویات ریاضی را داخل قاب متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) می‌باشد.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) و متدهای زنجیره‌ای [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) استفاده می‌کنند تا کد کوتاه و قابل خواندن بماند.

برای موارد صادرات MathML، به [Export Math Equations from Presentations in .NET](/slides/fa/net/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیه فیثاغورث را اضافه می‌کند:

![معادله c به توان دو برابر a به توان دو به‌علاوه b به توان دو است](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) شکلی ایجاد می‌کند که از پیش شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) را دسترسی پیدا کنید، [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) آن را دریافت کنید، و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **افزودن کسرها**

از [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی مورب که یک تقسیم بر x را نشان می‌دهد](powerpoint-math-equations_4.png)

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

برای یک کسر پشته‌ای، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) استفاده کنید:

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **افزودن رادیکال‌ها**

از [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) برای ایجاد ریشهٔ مربع، ریشهٔ مکعب یا ریشه‌های دیگر استفاده کنید. عنصر فعلی به پایه تبدیل می‌شود و آرگومان به درجه.

![یک عبارت رادیکال درجه n با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

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

### **نمایش یا مخفی‌کردن درجهٔ ریشهٔ مربع**

یک ریشهٔ مربع می‌تواند عدد ۲ صریح را نمایش دهد یا از نماد معمولی √x استفاده کند. ویژگی [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) در [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) تعیین می‌کند کدام شکل ظاهر شود. هردو فرم درجهٔ ۲ و رادیکاند x را در معادلهٔ قابل ویرایش حفظ می‌کند.

![یک ریشهٔ مربع مشابه با HideDegree تنظیم‌شده بر false در سمت چپ و true در سمت راست](square-root-degree.png)

این مثال همان ریشهٔ مربع را دو بار ذخیره می‌کند. در `visible-degree.pptx` عدد ۲ قابل مشاهده است. در `hidden-degree.pptx` مخفی است.

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

## **افزودن توابع و حدها**

از [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) یا [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) برای توابعی مانند `sin(x)`, `log(x)` یا نام‌های توابع سفارشی استفاده کنید. برای حدها، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) قرار دهید یا از [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/) استفاده کنید.

![حد x هنگامی که x به بی‌نهایت نزدیک می‌شود](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را عنصر فعلی کنید و با آرگومان‌اش [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) را فراخوانی کنید:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **افزودن عملگرهای N‑ary و انتگرال‌ها**

از [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) برای جمع‌ها، اتحادها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. برای انتگرال‌ها از [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) استفاده کنید. هر دو متد به شما امکان تعیین حد پایین و بالایی را می‌دهند.

![یک جمع با حدهای پایین و بالا](powerpoint-math-equations_7.png)

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

عملگرهای N‑ary برای عملگرهای بزرگ با حدهای اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به عنوان [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) اضافه می‌شوند و به عبارت می‌پیوندند.

برای یک انتگرال، از [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) استفاده کنید:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **افزودن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به‌طور پیش‌فرض ماتریس‌ها پرانتز ندارند، بنابراین هنگام نیاز به پرانتز، کروشه یا آکولاد، ماتریس را در آن‌ها بپیچید.

![یک ماتریس ریاضی دو ردیفی با یک سلول خالی](powerpoint-math-equations_10.png)

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

## **افزودن آرایه‌های معادله**

از [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) زمانی که به معادلات تراز شده یا یک پشته عمودی از عبارات نیاز دارید، استفاده کنید.

![یک آرایه ریاضی عمودی با x بالای y](powerpoint-math-equations_11.png)

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

### **تراز یک آرایه با عناصر اطراف**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) تنظیم‌کنندهٔ تراز عمودی آرایه نسبت به عناصر ریاضی کناری است. مثال زیر تراز را با ردیف اول، مرکز آرایه و ردیف آخر مقایسه می‌کند.

مثال زیر سه آرایهٔ یکسان ایجاد می‌کند که هر کدام سه ردیف و عناصر همسایهٔ `A=` و `=B` دارند. تمام متن ریاضی از Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند. فقط تراز آرایه تغییر می‌کند.

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

مقایسهٔ زیر ارائهٔ ذخیره‌شده در PowerPoint را نشان می‌دهد. به موقعیت `A=` و `=B` در کنار هر آرایه توجه کنید.

![آرایه‌های معادله در PowerPoint با تراز بالا، مرکز و پایین و عناصر همسایهٔ یکسان](equation-array-alignment.png)

### **پیکربندی فاصلهٔ ردیف‌ها**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) قانون فاصلهٔ ردیف‌ها در داخل آرایه را انتخاب می‌کند. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) مقدار عددی برای یک قانون فاصلهٔ صریح فراهم می‌کند و توسط قوانین پیش‌فرض نادیده گرفته می‌شود.

برای فاصلهٔ دقیق، مقدار به پوینت اندازه‌گیری می‌شود. برای فاصلهٔ نسبی، به نیم‌خط اندازه‌گیری می‌شود: مقدار `3` در مثال معادل ۱٫۵ خط است. هنگام تعیین مقدار صریح، هر دو ویژگی را تنظیم کنید؛ تغییر فقط مقدار عددی قانون فاصله را انتخاب نمی‌کند.

مثال زیر پنج ارائه را با همان معادلات، تراز و تنظیمات قلم ذخیره می‌کند. سه ارائهٔ اول از پیش‌تنظیم‌ها استفاده می‌کنند؛ دو ارائهٔ آخر مقادیر صریح را نشان می‌دهند.

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

فاصلهٔ ردیف آرایه جدا از فاصلهٔ پاراگراف است. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) و [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) فضای اطراف پاراگراف حاوی را اضافه می‌کنند، نه بین ردیف‌های آرایه. به‌طور مشابه، [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) موقعیت افقی تمام پاراگراف ریاضی را تنظیم می‌کند؛ این تنظیم جایگزین تنظیم تراز عمودی آرایه نمی‌شود.

## **افزودن توابع مثلثاتی**

از [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) زمانی که آرگومان عنصر فعلی است و نام تابع شناخته شده است، استفاده کنید.

![تابع مثلثاتی cos بر روی 2x اعمال شده](powerpoint-math-equations_6.png)

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

## **افزودن زیرنویس و بالانویس**

از ابزارهای زیرنویس و بالانویس برای نمایه‌ها و توان‌ها استفاده کنید. هنگامی که نمایه‌ها باید در سمت چپ پایه ظاهر شوند، از [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) استفاده کنید.

![یک Y بزرگ با زیرنویس ۱ در سمت چپ و بالانویس n](powerpoint-math-equations_9.png)

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

## **افزودن جداکننده‌ها**

از [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) برای قرار دادن یک عبارت داخل جداکننده‌ها استفاده کنید. می‌توانید برای عبارات جداکننده‌ای که چند عنصر دارند، کاراکتر جداساز تنظیم کنید.

![یک عبارت جداکننده شامل x، y و z که با خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

### **اندازه و تراز جداکننده‌ها**

[GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) را روی `true` تنظیم کنید تا پرانتزها اطراف عملوند بلند بزرگ شوند، یا روی `false` تا اندازهٔ عادی خود باقی بمانند. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) را می‌پذیرد. `Centered` پرانتزها را روی محور ریاضی که از وسط علامت مساوی می‌گذرد، متمرکز می‌کند. `Match` آن‌ها را با محتوای محصور هم‌راستا می‌کند. هر دو تنظیم فقط بر روی جداکننده‌ها تأثیر می‌گذارد. عبارت داخلی همان‌گونه می‌ماند.

مثال یک کسر را در توان `x` قرار می‌دهد تا عبارت بالاتر از خط پایه نسبت به پایین طولانی‌تر شود. هر چهار معادله از همان پرانتزها و تنظیمات قلم استفاده می‌کنند.

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

در PowerPoint، ردیف‌ها را مقایسه کنید تا اثر رشد را ببینید. در ردیف بالا، پرانتزها برای محصور کردن توان بزرگ می‌شوند و برای هر دو شکل مشابه به نظر می‌رسند. در ردیف پایین، رشد غیرفعال است. پرانتزهای کوچکتر در سمت چپ (`Centered`) با علامت مساوی هم‌تراز می‌شوند، در حالی که در سمت راست (`Match`) بالاتر در اطراف عبارت قرار می‌گیرند.

![چهار معادله در PowerPoint با فعال بودن رشد جداکننده در بالا و غیرفعال بودن در پایین، و `Centered` در سمت چپ و `Match` در سمت راست](delimiter-sizing.png)

## **افزودن جعبهٔ مرزی**

بر یک کسر، [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) را فراخوانی کنید تا کل عبارت را در یک چارچوب بپیچید. [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) بازگردانده‌شده به‌طور پیش‌فرض چهار طرف را نشان می‌دهد. برای حذف هر طرف به‌صورت جداگانه، از [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/)، [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/)، [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) و [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) استفاده کنید.

مثال شش نسخهٔ یکسان از همان کسر را در یک اسلاید قرار می‌دهد. برای نشان دادن حذف، هر چهار طرف را مخفی کنید و [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) را برای یک قطر صعودی (↗) یا [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) برای قطر نزولی (↘) تنظیم کنید. می‌توانید از [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) یا [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) با هر ترکیبی از طرف‌های قابل مشاهده استفاده کنید.

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

![شش کسر قابل ویرایش در PowerPoint. ردیف arriba: مرز کامل، طرف‌های پایین و چپ، قطر صعودی. ردیف پایین: قطر نزولی، خط افقی، خط عمودی با مرز کامل.](border-box-fractions.png)

در این کسر، خط افقی بر روی خط کسر قرار می‌گیرد. خط عمودی هر دو صورت و مخرج را می‌قاطعند در حالی که مرز اطراف قابل مشاهده می‌ماند. این خطوط تمام عبارت را تزئین می‌کنند. خط‌کش معمولی متن بر روی کاراکترهای یک ران متن اعمال می‌شود. پس از باز کردن دوباره ارائه در PowerPoint، می‌توانید صورت و مخرج را به‌صورت جداگانه ویرایش کنید.

## **کنترل قابل مشاهده بودن و چیدمان با عناصر فانتوم**

یک عبارت را در [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) بپیچید تا قابل مشاهده بودن آن و فضای مشارکتی‌اش در یک معادله را به‌صورت مستقل کنترل کنید. ویژگی‌های [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) موارد زیر را کنترل می‌کنند:

| Property | Effect |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | مقدار `false` باعث مخفی شدن عبارت می‌شود. ابعاد آن همچنان در چیدمان مشارکت می‌کند مگر این‌که ویژگی‌های زیر `true` تنظیم شوند. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | عرض افقی عبارت را به صفر درنظر بگیرد؛ این باعث می‌شود عناصر همسایه به‌هم نزدیک شوند. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | ارتفاع بالای پایه (ascent) را صفر درنظر بگیرد؛ این می‌تواند فضای رزرو شده بالای عناصر همسایه را کاهش دهد. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | ارتفاع پایین (descent) را صفر درنظر بگیرد؛ این می‌تواند خط کسر یا محتوای زیر عبارت را به‌سوی همسایه‌ها نزدیک‌تر کند. |

خط پایه، خط مرجع است که حروف ریاضی معمولی روی آن قرار می‌گیرند. مخفی‌کردن محتوا ابعاد آن را حذف نمی‌کند و درنظر گرفتن یک ابعاد به‌عنوان صفر عبارت را حذف نمی‌کند. عبارت پایه از طریق [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) در دسترس باقی می‌ماند. برای نمایش دوباره، [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) را به `true` برگردانید؛ تنظیمات ابعاد تغییر نمی‌کند.

مثال زیر پنج گونهٔ کنار هم ایجاد می‌کند: یک کسر قابل مشاهده، یک کسر مخفی که فضا را نگه می‌دارد، و سه کسر مخفی با یک بعد به‌عنوان صفر. هر گونه از همان عبارت اطراف و قلم Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند. تمام اشکال معادله موقعیت بالایی یکسانی دارند که توسط راهنمای خاکستری نشان داده شده است. قرار دادن فانتوم در صورت یک کسر بیرونی، تغییرات چیدمان عمودی را به‌ظاهر می‌آورد.

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

![پنج معادله در PowerPoint که یک کسر قابل مشاهده، یک کسر مخفی که فضا را نگه می‌دارد و کسرهای مخفی با ZeroWidth، ZeroAsc یا ZeroDesc فعال را مقایسه می‌کنند](math-phantom.png)

## **گروه‌بندی عبارات**

از [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) برای قرار دادن یک علامت گروه‌بندی بالای یا زیر یک عبارت استفاده کنید. یک حد اضافه کنید تا عبارات گروه‌بندی‌شده را برچسب‌گذاری کنید.

![عبارت x به‌علاوه y که با برچسب هر متنی زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

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

## **قالب‌بندی عناصر ریاضی**

از ابزارهای قالب‌بندی تنها در جایی که فرمول را واضح می‌کنند استفاده کنید. به عنوان مثال، [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) یک نوار بالای عنصر ریاضی می‌گذارد.

![یک عبارت ریاضی ABC با نوار بالا](powerpoint-math-equations_14.png)

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

### **قالب‌بندی متن در یک معادله موجود**

برای قالب‌بندی متن در سراسر یک معادله موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) تنها فرزندان مستقیم را برمی‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و سایر ساختارهای تو درتو، آن را به‌صورت بازگشتی فراخوانی کنید. عنصر فعلی و فرزندانش را بررسی کنید تا عنصر شروع شامل شود زمانی که [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) باشد.

این مثال فرض می‌کند که یک ارائه شامل معادله‌ای مانند `z = xᵢ / ∛y` است، که کسر شامل زیرنویس در صورت و رادیکال در مخرج می‌شود. پردازش فقط عناصر سطح بالای بلوک متن را از دست می‌دهد. مثال بخش‌های ریاضی را در قاب‌های متن اسلاید پیدا می‌کند، بلوک‌هایشان را از طریق [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) دسترسی می‌دهد و [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) را به ۲۸ پوینت از طریق ویژگی [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) هر عنصر متنی تنظیم می‌کند.

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

ارائهٔ ذخیره‌شده متن قالب‌بندی‌شده به‌روزشده را در هر سطح از هر معادله پردازش‌شده شامل می‌شود، در حالی که محتوای متن و ساختار ریاضی آن حفظ می‌شود.

## **راهنمای سریع**

| Task | Main API |
| --- | --- |
| Create math text | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Combine elements | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Create fractions | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Add superscript or subscript | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Add functions | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Add radicals | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Add limits | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Add left-side scripts | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Add summations and integrals | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Add matrices | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Add equation arrays | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Add delimiters | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Add bars and borders | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Group terms | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **سوالات متداول**

**آیا می‌توانم یک معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) است پیدا کنید، [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) آن را دریافت کنید و بلوک‌های ریاضی در آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به‌صورت ریاضیات قابل ویرایش در PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتوای ریاضی Office قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. معادلهٔ خود را از طریق [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) به [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) دریافت کنید و سپس [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) را برای صادرات مستقیم فراخوانی کنید. برای یک مثال کامل، به [Export Math Equations from Presentations in .NET](/slides/fa/net/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.