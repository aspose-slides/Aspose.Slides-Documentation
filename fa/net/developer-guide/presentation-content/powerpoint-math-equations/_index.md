---
title: اضافه کردن معادلات ریاضی به ارائه‌های PowerPoint در .NET
linktitle: معادلات ریاضی PowerPoint
type: docs
weight: 80
url: /fa/net/powerpoint-math-equations/
keywords:
- معادله ریاضی
- نماد ریاضی
- فرمول ریاضی
- متن ریاضی
- اضافه کردن معادله ریاضی
- اضافه کردن نماد ریاضی
- اضافه کردن فرمول ریاضی
- اضافه کردن متن ریاضی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "درج و ویرایش معادلات ریاضی در فایل‌های PowerPoint PPT و PPTX با Aspose.Slides برای .NET، با پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های واضح کد C#."
---
## **بررسی کلی**

PowerPoint معادلات را به عنوان Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای .NET می‌توانید محتوای ریاضی مشابه را به‌صورت برنامه‌ای ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدود، عملگرهای N‑ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![برگه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متنی ریاضی قابل ویرایش روی اسلاید است:

![اسلاید PowerPoint حاوی یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) ایجاد می‌شود، شکلی است که معادله را در بر می‌گیرد.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) محتوای ریاضی را داخل فریم متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) است.

اکثرا مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) و روش‌های fluent از [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) برای کوتاه و خوانا بودن کد استفاده می‌کنند.

برای سناریوهای خروجی MathML، به [Export Math Equations from Presentations in .NET](/slides/fa/net/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیه فیثاغورث را اضافه می‌کند:

![معادله c² برابر a² به‌اضافه b²](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) یک شکل ایجاد می‌کند که قبلاً شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) را دریافت کنید، [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) آن را بگیرید، و بلوک‌های ریاضی یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

### **ترکیب بلوک‌های ریاضی**

هنگامی که قسمت‌های یک معادله به‌طور مستقل به عنوان اشیاء [IMathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/) ساخته می‌شوند، از [JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) برای ترکیب آن‌ها استفاده کنید. مثال `c² =` را در بلوک چپ و `a² + b²` را در بلوک راست می‌سازد. [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/) برای تمام سه توان فوق‌نویس‌های ریاضی قابل ویرایش ایجاد می‌کند.

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

[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) خود `leftBlock` را برمی‌گرداند، که اکنون هر دو بخش را به ترتیب در خود دارد و `rightBlock` را خالی می‌گذارد. بلوک ترکیب‌شده را فقط یک بار به [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) اضافه کنید. پس از باز کردن مجدد `equation.pptx`، پاراگراف یک بلوک حاوی `c² = a² + b²` دارد که هر سه توان به‌صورت فوق‌نویس ریاضی حفظ شده‌اند.

فراخوانی [Add](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelementcollection/add/) به صورت `leftBlock.Add(rightBlock)` به‌جای آن سعی می‌کند یک بلوک را مستقیم داخل بلوک دیگر تو در تو کند و `InvalidOperationException` پرتاب می‌شود.

## **اضافه کردن کسرها**

از [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) برای ایجاد یک کسر استفاده کنید. می‌توانید یک سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی کج که یک تقسیم بر x را نشان می‌دهد](powerpoint-math-equations_4.png)

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

برای یک کسر مرکب، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) استفاده کنید:

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **اضافه کردن رادیکال‌ها**

از [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) برای ایجاد ریشهٔ مربع، ریشهٔ مکعب یا ریشهٔ دیگر استفاده کنید. عنصر جاری به‌عنوان پایه می‌شود و آرگومان به‌عنوان درجه.

![یک عبارت رادیکال ریشه nام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

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

### **نمایش یا مخفی کردن درجه ریشهٔ مربع**

یک ریشهٔ مربع می‌تواند عدد ۲ صریح را نمایش دهد یا از نماد مرسوم √x استفاده کند. ویژگی [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) از [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) تعیین می‌کند کدام فرم ظاهر شود. هر دو فرم درجه ۲ و radicand x را در معادلهٔ قابل ویرایش حفظ می‌کند.

![همان ریشه مربع با HideDegree تنظیم شده به false در سمت چپ و true در سمت راست](square-root-degree.png)

مثال ریشهٔ مربع را دو بار ذخیره می‌کند. در `visible-degree.pptx` عدد ۲ قابل مشاهده است. در `hidden-degree.pptx` مخفی است.

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

## **اضافه کردن توابع و حدود**

از [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) یا [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) برای توابعی مانند `sin(x)`, `log(x)` یا نام توابع سفارشی استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) بگذارید یا از [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/) استفاده کنید.

![حد x هنگامی که x به بی‌نهایت میل می‌کند](powerpoint-math-equations_8.png)

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

برای نام توابع سفارشی، نام تابع را به‌عنوان عنصر جاری قرار داده و [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) را با آرگومان آن صدا بزنید:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **اضافه کردن عملگرهای N‑ary و انتگرال‌ها**

از [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) برای جمع‌ها، اتحادیه‌ها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. برای انتگرال‌ها از [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) استفاده کنید. هر دو روش امکان تعیین حدود پایین و بالا را می‌دهند.

![یک جمع با حدود پایین و بالا](powerpoint-math-equations_7.png)

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

عملگرهای N‑ary برای عملگرهای بزرگ با حدود اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به‌عنوان [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) اضافه شده و به عبارت ملحق می‌شوند.

برای یک انتگرال، از [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) استفاده کنید:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **اضافه کردن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به‌طور پیش‌فرض ماتریس‌ها براکت ندارند، بنابراین وقتی نیاز به پرانتز، براکت یا کروشه دارید، ماتریس را داخل آن‌ها بگذارید.

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

### **ویرایش یک ماتریس موجود**

فرض کنید یک درس جبر خطی با ماتریس ضریب در `matrix.pptx` شروع می‌شود که توسط مثال قبلی ذخیره شده است. برای تمرین بعدی، معادلهٔ اول را نگه داشته، دومین معادله را با دو معادلهٔ جدید جایگزین کنید و مجموعهٔ متغیرها را بازنگری کنید. با استفاده از [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) ماتریس موجود را باز کنید تا ضرایبی که هنوز معتبرند حفظ شوند.

![ماتریس ضریب دو ردیفی اصلی با مقادیر 1، x، و یک سلول خالی در ردیف اول و x، 2، و y در ردیف دوم](matrix-before-edit.png)

اندیس‌های ردیف و ستون از صفر شروع می‌شوند و به ماتریس در هر فراخوانی اشاره می‌کنند. افزودن یک ردیف قبل از اندیس 1، ردیف دوم اصلی را به اندیس 2 منتقل می‌کند. افزودن پس از اندیس 2 سپس یک ردیف اضافه می‌کند. حذف ردیف 2 معادلهٔ دوم اصلی را حذف کرده و ردیف اضافه‌شده را یک موقعیت بالا می‌برد. ستون‌ها نیز به‌ همین صورت جابه‌جا می‌شوند.

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

// سلول‌های جدید در ابتدا null هستند. ابتدا ضرایب غیرصفر را تنظیم کنید.
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

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) ستون اول را به چپ هم‌راستا می‌کند. [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) سه ستون متوالی را از اندیس 1 به راست هم‌راستا می‌کند. در `updated-matrix.pptx`، ماتریس سه معادله و چهار متغیر دارد. ضرایب ردیف اول اصلی `1` و `x` اکنون در ستون‌های اول و سوم ظاهر می‌شوند.

![ماتریس به‌روزرسانی‌شدهٔ سه ردیفی نشان‌دهنده ردیف‌های 1, 0, x, 0؛ 12, 1, 0, 0؛ و 0, 0, 10, 1](matrix-after-edit.png)

## **اضافه کردن آرایه‌های معادله**

وقتی به معادلات هم‌راستا یا یک پشتهٔ عمودی از عبارات نیاز دارید، از [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) استفاده کنید.

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

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) تراز عمودی آرایه نسبت به عناصر ریاضی کناری را کنترل می‌کند. مثال زیر تراز را با ردیف اول، مرکز آرایه و ردیف آخر مقایسه می‌کند.

مثال زیر سه آرایهٔ یکسان ایجاد می‌کند، هر کدام با سه ردیف و عناصر همسایهٔ `A=` و `=B`. تمام متن‌های ریاضی از Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کنند. تنها تراز آرایه تغییر می‌کند.

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

مقایسه زیر ارائه ذخیره‌شده در PowerPoint را نشان می‌دهد. موقعیت `A=` و `=B` کنار هر آرایه را ببینید.

![آرایه‌های معادله در PowerPoint با تراز بالا، مرکز و پایین و عناصر همسایه یکسان](equation-array-alignment.png)

### **پیکربندی فاصله ردیف‌ها**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) قانون فاصلهٔ ردیف‌ها درون آرایه را انتخاب می‌کند. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) مقدار عددی برای یک قانون صریح فراهم می‌کند و توسط قوانین پیش‌فرض نادیده گرفته می‌شود.

برای فاصلهٔ دقیق، مقدار بر حسب پوینت اندازه‌گیری می‌شود. برای فاصلهٔ متناسب، بر حسب نیم‌خط اندازه‌گیری می‌شود: مقدار `3` در مثال برابر با ۱٫۵ خط است. هنگام تعیین مقدار صریح، هر دو ویژگی را تنظیم کنید؛ تغییر تنها مقدار عددی قانون فاصله را انتخاب نمی‌کند.

مثال زیر پنج ارائه با معادلات، تراز و تنظیمات قلم یکسان ذخیره می‌کند. سه ارائهٔ نخست از پیش‌تنظیم‌ها استفاده می‌کنند؛ دو مورد آخر مقادیر صریح نشان می‌دهند.

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

فاصله ردیف آرایه مستقل از فاصلهٔ پاراگراف است. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) و [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) فضای اطراف پاراگراف حاوی را اضافه می‌کنند، نه بین ردیف‌های آرایه. به‌طور مشابه، [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) کل پاراگراف ریاضی را افقی موقعیت می‌دهد؛ تنظیمات تراز عمودی آرایه را جایگزین نمی‌کند.

## **اضافه کردن توابع مثلثی**

وقتی آرگومان عنصر جاری است و نام تابع شناخته شده، از [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) استفاده کنید.

![تابع مثلثاتی cos به 2x اعمال شده](powerpoint-math-equations_6.png)

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

## **اضافه کردن زیرنویس و فوق‌نویس**

برای ایندکس‌ها و توان‌ها از کمک‌کننده‌های زیرنویس و فوق‌نویس استفاده کنید. وقتی ایندکس‌ها باید در سمت چپ پایه ظاهر شوند، از [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) استفاده کنید.

![یک Y بزرگ با زیرنویس سمت چپ 1 و فوق‌نویس n](powerpoint-math-equations_9.png)

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

### **هم‌راست کردن زیرنویس و فوق‌نویس راست**

وقتی هر دو اسکریپت به یک پایه تعلق دارند، از [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement/) استفاده کنید. ویژگی [AlignScripts](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathrightsubsuperscriptelement/alignscripts/) موقعیت افقی آن‌ها را کنترل می‌کند: `false` (پیش‌فرض) آن‌ها را مطابق منحنی پایه می‌گذارد، در حالی که `true` اسکریپت‌ها را افقی هم‌راستا می‌کند.

این مثال دو نسخهٔ یک عبارت قابل ویرایش را کنار هم قرار می‌دهد. هر دو از حرف ایتالیک ریاضی f (U+1D453)، یک زیرنویس 1، یک فوق‌نویس 2 و Cambria Math با اندازهٔ ۷۲ پوینت استفاده می‌کنند. پایهٔ مایل تفاوت را در PowerPoint نمایان می‌سازد. قبل از اجرای مثال Cambria Math را نصب کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(900, 250, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var format = new PortionFormat
{
    FontHeight = 72,
    LatinFont = new FontData("Cambria Math")
};

for (var i = 0; i < 2; i++)
{
    var left = 40 + i * 440;
    var shape = slide.Shapes.AddMathShape(left, 75, 380, 150);

    var baseText = new MathematicalText("\U0001D453", format);
    var subscript = new MathematicalText("1", format);
    var superscript = new MathematicalText("2", format);
    var scripts = new MathRightSubSuperscriptElement(baseText, subscript, superscript);
    scripts.AlignScripts = i == 1;

    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = format.FontHeight;
    portion.PortionFormat.LatinFont = format.LatinFont;
    portion.MathParagraph.Add(new MathBlock(scripts));
}

presentation.Save("aligned-scripts.pptx", SaveFormat.Pptx);
```

![دو عبارت قابل ویرایش در PowerPoint با AlignScripts تنظیم شده به false در سمت چپ و true در سمت راست](aligned-scripts.png)

در سمت چپ، زیرنویس پایین‌تر نسبت به فوق‌نویس به سمت چپ آغاز می‌شود و منحنی پایه را دنبال می‌کند. در سمت راست، دو اسکریپت افقی هم‌راستا هستند.

## **اضافه کردن جداکننده‌ها**

از [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) برای گذاشتن یک عبارت داخل جداکننده‌ها استفاده کنید. می‌توانید یک کاراکتر جداکننده برای عبارات جداکننده‌ای که شامل چند عنصر هستند تنظیم کنید.

![عبارتی دارای جداکننده شامل x، y و z که با خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

### **اندازه و هم‌راست کردن جداکننده‌ها**

[GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) را به `true` تنظیم کنید تا پرانتزها برای عملوند بلند بزرگ شوند، یا به `false` تنظیم کنید تا اندازهٔ معمولی خود را حفظ کنند. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) را می‌گیرد. `Centered` پرانتزها را روی محور ریاضی که از وسط علامت برابر عبور می‌کند، مرکز می‌کند. `Match` آن‌ها را با محتوای محصور هم‌راستا می‌کند. هر دو تنظیم فقط بر جداکننده‌ها اثر می‌گذارند؛ عبارت داخلی همانند قبل می‌ماند.

مثال یک کسر را در توان `x` قرار می‌دهد تا عبارت بالاتر از خط پایه نسبت به زیر آن گسترش یابد. همهٔ چهار معادله از یک پرانتز و تنظیمات قلم یکسان استفاده می‌کنند.

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

در PowerPoint، ردیف‌ها را برای مشاهدهٔ تأثیر رشد مقایسه کنید. در ردیف بالا، پرانتزها برای محصور کردن توان بزرگ می‌شوند و برای هر دو شکل مشابه به نظر می‌رسند. در ردیف پایین، رشد غیرفعال است. پرانتزهای کوچکتر در سمت چپ (`Centered`) با علامت برابر هم‌راستا هستند، در حالی که آن‌ها در سمت راست (`Match`) بالاتر از عبارت قرار گرفته‌اند.

![چهار معادله در PowerPoint با رشد جداکننده فعال در بالا و غیرفعال در پایین، و Centered در سمت چپ و Match در سمت راست](delimiter-sizing.png)

## **اضافه کردن یک جعبهٔ حاشیه**

بر یک کسر [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) فراخوانی کنید تا کل عبارت در قاب قرار گیرد. [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) به‌طور پیش‌فرض چهار طرف را نشان می‌دهد. با استفاده از [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/)، [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/)، [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) و [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) می‌توانید طرف‌های جداگانه را حذف کنید.

مثال شش نسخهٔ یک کسر را روی یک اسلاید قرار می‌دهد. برای نشان دادن لغو، همهٔ چهار طرف را مخفی کنید و برای یک قطر صعودی (↗) [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) یا برای یک قطر نزولی (↘) [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) را تنظیم کنید. همچنین می‌توانید از [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) یا [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) همراه با هر ترکیبی از طرف‌های قابل مشاهده استفاده کنید.

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

![شش کسر قابل ویرایش در PowerPoint. ردیف بالا: حاشیه کامل، طرف‌های پایین و چپ، قطر صعودی. ردیف پایین: قطر نزولی، خط افقی، خط عمودی با حاشیه کامل](border-box-fractions.png)

در این کسر، خط افقی بر روی نوار کسر پوشیده می‌شود. خط عمودی هر دو صورت و مخرج را می‌پوشاند در حالی که حاشیه اطراف قابل مشاهده می‌ماند. این خطوط کل عبارت را تزئین می‌کنند. خط‌خطی معمولی فقط بر روی کاراکترهای یک اجرا اعمال می‌شود. پس از باز کردن مجدد ارائه در PowerPoint، می‌توانید صورت و مخرج را به‌صورت مستقل ویرایش کنید.

## **کنترل نمایش و چیدمان با عناصر Phantom**

یک عبارت را با [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) بپوشانید تا نمایش و فضایی که به معادله اضافه می‌کند را به‌صورت جداگانه کنترل کنید. ویژگی‌های [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) موارد زیر را تنظیم می‌کند:

| ویژگی | اثر |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | به `false` تنظیم کنید تا عبارت مخفی شود. ابعاد آن همچنان در چیدمان مؤثر است مگر اینکه ویژگی‌های زیر `true` شوند. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | عرض افقی عبارت را صفر در نظر می‌گیرد، اجازه می‌دهد عناصر همسایه به‌یکدیگر نزدیک‌تر شوند. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | ارتفاع بالای خط پایه (ascender) را صفر در نظر می‌گیرد. این می‌تواند فضای رزرو شدهٔ بالا برای عناصر همسایه را کاهش دهد. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | عمق زیر خط پایه (descender) را صفر در نظر می‌گیرد. این می‌تواند نوار کسر یا محتوای دیگر زیر عبارت را به‌نزدیک عناصر همسایه براند. |

خط پایه خط مرجعی است که حروف ریاضی عادی روی آن قرار می‌گیرند. مخفی کردن محتوا ابعاد آن را حذف نمی‌کند و در نظر گرفتن یک بعد به‌عنوان صفر عبارت را حذف نمی‌کند. عبارت اصلی از طریق [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) در دسترس می‌ماند. برای نمایش دوباره، [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) را به `true` برگردانید؛ تنظیمات ابعاد دست‌نخورده می‌مانند.

مثال زیر پنج نسخهٔ کنار هم ایجاد می‌کند: یک کسر قابل مشاهده، یک کسر مخفی که فضای اش را ذخیره می‌کند و سه کسر مخفی با ZeroWidth، ZeroAsc یا ZeroDesc فعال. هر ورژن از همان عبارت اطراف و Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند. تمام اشکال معادله موقعیت بالایی یکسانی دارند که با راهنمای خاکستری مشخص شده است. قرار دادن phantom در صورت یک کسر بیرونی تغییرات چیدمان عمودی را آشکارتر می‌کند.

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

![پنج معادله در PowerPoint که یک کسر قابل مشاهده، یک کسر مخفی که فضای اش را ذخیره می‌کند، و کسرهای مخفی با ZeroWidth، ZeroAsc یا ZeroDesc فعال را مقایسه می‌کند](math-phantom.png)

## **گروه‌بندی عبارات**

از [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) برای قرار دادن یک کاراکتر گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی شده می‌توانید یک حد اضافه کنید.

![عبارتی x به‌علاوۀ y که با برچسب هر متنی در زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

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

از کمک‌کننده‌های قالب‌بندی فقط در جایی که فرمول را واضح می‌کند استفاده کنید. به‌عنوان مثال، [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) یک خط بالایی روی یک عنصر ریاضی می‌گذارد.

![یک عبارت ریاضی ABC با یک خط بالایی](powerpoint-math-equations_14.png)

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

برای قالب‌بندی متن در تمام یک معادله موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) فقط فرزندان مستقیم را برمی‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و سایر ساختارهای تو در تو به‌صورت بازگشتی از آن استفاده کنید. عنصر جاری و فرزندان آن را بررسی کنید تا وقتی که عنصر [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) باشد، آن را نیز شامل کنید.

این مثال فرض می‌کند که یک ارائه شامل معادله‌ای مانند `z = xᵢ / ∛y` است که کسر دارای زیرنویس در صورت و رادیکال در مخرج است. پردازش تنها عناصر سطح بالا باعث از دست رفتن متن داخل کسر می‌شود. مثال بخش‌های ریاضی را در فریم‌های متن اسلاید پیدا می‌کند، بلوک‌هایشان را از طریق [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) دسترسی می‌دهد و از طریق ویژگی [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) هر عنصر متن، [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) را به ۲۸ پوینت تنظیم می‌کند.

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

ارائهٔ ذخیره‌شده شامل قالب‌بندی متن به‌روز شده در هر سطح از هر معادله پردازش‌شده است، در حالی که محتوای متنی و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| وظیفه | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| ترکیب عناصر | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| ایجاد کسرها | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| اضافه کردن فوق‌نویس یا زیرنویس | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| اضافه کردن توابع | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| اضافه کردن رادیکال‌ها | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| اضافه کردن حدود | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| اضافه کردن اسکریپت‌های سمت چپ | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| اضافه کردن جمع‌ها و انتگرال‌ها | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| اضافه کردن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| اضافه کردن آرایه‌های معادله | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| اضافه کردن جداکننده‌ها | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| اضافه کردن میله‌ها و حاشیه‌ها | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| گروه‌بندی عبارات | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **سوالات متداول**

**آیا می‌توانم یک معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) است پیدا کنید، [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) آن را دریافت کنید و بلوک‌های ریاضی را در آن پاراگراف به‌روزرسانی کنید.

**آیا معادلات به‌عنوان ریاضیات قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتوای Office Math قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) دریافت کنید و [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) را فراخوانی کنید تا به‌صورت مستقیم صادر شود. برای یک مثال کامل، به [Export Math Equations from Presentations in .NET](/slides/fa/net/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.