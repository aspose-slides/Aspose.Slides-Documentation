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
description: "درج و ویرایش معادلات ریاضی در فایل‌های PowerPoint PPT و PPTX با Aspose.Slides برای .NET، با پشتیبانی از OMML، قابلیت‌های قالب‌بندی، و نمونه‌های کد C# واضح."
---
## **بررسی کلی**

PowerPoint معادلات را به عنوان Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای .NET، می‌توانید همان نوع محتویات ریاضی را به‌صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدها، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

نتیجه، متن ریاضی قابل ویرایش بر روی اسلاید است:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی که با [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) ایجاد می‌شود، شکلی است که معادله را در خود دارد.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) محتویات ریاضی را داخل فریم متنی شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) و روش‌های زنجیره‌ای [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) برای کوتاه و قابل خواندن نگه داشتن کد استفاده می‌کنند.

برای سناریوهای خروجی MathML، به [Export Math Equations from Presentations in .NET](/slides/fa/net/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیه فیثاغورث را اضافه می‌نماید:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) یک شکل را ایجاد می‌کند که از قبل شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) را دسترسی پیدا کنید، [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) آن را دریافت کنید و بلوک‌های ریاضی یا المان‌های ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **اضافه کردن کسرها**

از [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) برای ایجاد یک کسر استفاده کنید. می‌توانید یک سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) انتخاب کنید.

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

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

## **اضافه کردن رادیکال‌ها**

از [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) برای ایجاد ریشه دوم، ریشه سوم یا هر ریشه دیگری استفاده کنید. عنصر جاری پایه می‌شود و آرگومان درجه ریشه را تعیین می‌کند.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

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

## **اضافه کردن توابع و حدها**

از [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) یا [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) برای توابعی مانند `sin(x)`, `log(x)`, یا نام‌های توابع سفارشی استفاده کنید. برای حدها، `lim` را داخل یک [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) بگذارید یا از [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/) استفاده کنید.

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را به عنوان عنصر جاری قرار دهید و [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) را با آرگومان آن صدا بزنید:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **اضافه کردن عملگرهای N-ary و انتگرال‌ها**

از [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) برای جمع‌ها، اتحادها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. از [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) برای انتگرال‌ها استفاده کنید. هر دو روش به شما امکان تنظیم حد پایین و بالا را می‌دهند.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

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

عملگرهای N-ary برای عملگرهای بزرگ با حدهای اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به عنوان [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) اضافه می‌شوند و به عبارت ملحق می‌گردند.

برای یک انتگرال، از [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) استفاده کنید:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **اضافه کردن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به طور پیش‌فرض، ماتریس‌ها پرانتز ندارند، بنابراین هنگام نیاز به پرانتز، کروشه یا آکلاد، ماتریس را داخل آنها بگذارید.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

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

## **اضافه کردن آرایه‌های معادله**

از [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) زمانی که به معادلات هم‌ترازبندی یا یک پشته عمودی از عبارات نیاز دارید، استفاده کنید.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

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

## **اضافه کردن توابع مثلثاتی**

از [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) زمانی که آرگومان عنصر جاری است و نام تابع شناخته شده است، استفاده کنید.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

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

## **اضافه کردن زیرنویس و بالانویس**

از ابزارهای زیرنویس و بالانویس برای اندیس‌ها و توان‌ها استفاده کنید. زمانی که اندیس‌ها باید در سمت چپ پایه ظاهر شوند، از [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) استفاده کنید.

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

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

## **اضافه کردن جداکننده‌ها**

از [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) برای قرار دادن یک عبارت داخل جداکننده‌ها استفاده کنید. همچنین می‌توانید یک کاراکتر جداکننده برای عبارات دارای چند عنصر تنظیم کنید.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

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

مقدار [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) را به `true` تنظیم کنید تا پرانتزها با ارتفاع بزرگ عملوند بزرگ شوند، یا به `false` تنظیم کنید تا اندازه معمولی خود باقی بمانند. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) را می‌گیرد. `Centered` پرانتزها را بر محور ریاضی که از وسط علامت مساوی عبور می‌کند، مرکز می‌کند. `Match` آنها را با محتوای درون‌گذاری شده تراز می‌کند. هر دو تنظیم تنها بر جداکننده‌ها تأثیر می‌گذارد. عبارت در داخل همانند قبلی باقی می‌ماند.

مثال یک کسر را در توان `x` قرار می‌دهد به طوری که عبارت بالاتر از خط پایه بیشتر کشیده شود تا پایین‌تر کمتر. هر چهار معادله از یک پرانتز و تنظیمات قلم یکسان استفاده می‌کنند.

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

در PowerPoint، سطرها را مقایسه کنید تا تأثیر رشد را ببینید. در سطر بالایی، پرانتزها برای محصور کردن توان رشد می‌کنند و برای هر دو شکل یکسان به نظر می‌رسند. در سطر پایین، رشد غیر فعال است. پرانتزهای کوچکتر در سمت چپ (`Centered`) با علامت مساوی هم‌تراز می‌شوند، در حالی که آن‌ها در سمت راست (`Match`) بالاتر اطراف عبارت قرار دارند.

![Four equations in PowerPoint with delimiter growth enabled above and disabled below, and Centered on the left and Match on the right](delimiter-sizing.png)

## **اضافه کردن جعبه‌حاشیه**

روی یک کسر [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) را صدا بزنید تا کل عبارت در یک قاب قرار گیرد. [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) بازگشتی به‌طور پیش‌فرض تمام چهار طرف را نشان می‌دهد. از [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/)، [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/)، [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) و [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) برای حذف طرف‌های جداگانه استفاده کنید.

مثال شش نسخه از همان کسر را روی یک اسلاید قرار می‌دهد. برای نشان دادن حذف، تمام چهار طرف را مخفی کنید و [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) را برای مسیر مورب صعودی (↗) یا [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) برای مسیر مورب نزولی (↘) تنظیم کنید. همچنین می‌توانید از [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) یا [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) همراه با ترکیبی از طرف‌های قابل مشاهده استفاده کنید.

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

![Six editable fractions in PowerPoint. Top row: full border, bottom and left sides, rising diagonal. Bottom row: falling diagonal, horizontal strike, vertical strike with a full border.](border-box-fractions.png)

در این کسر، خط افقی بر روی خط کسر قرار می‌گیرد. خط عمودی هر دو عدد صورت و مخرج را می‌گذرد در حالی که قاب اطراف همچنان قابل مشاهده است. این خطوط تمام عبارت را تزئین می‌کند. Strikethrough متن معمولی بر روی کاراکترهای یک ران متن اعمال می‌شود. پس از باز کردن مجدد ارائه در PowerPoint، می‌توانید صورت و مخرج را به‌صورت مستقل ویرایش کنید.

## **گروه‌بندی عبارات**

از [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) برای قرار دادن یک کاراکتر گروه‌بندی در بالای یا پایین یک عبارت استفاده کنید. یک حد اضافه کنید تا عبارات گروه‌بندی‌شده را برچسب بزنید.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

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

از ابزارهای قالب‌بندی فقط در جاهایی که فرمول را واضح‌تر می‌کند استفاده کنید. برای مثال، [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) یک نوار بالای یک عنصر ریاضی قرار می‌دهد.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

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

برای قالب‌بندی متن در سرتاسر یک معادله موجود، درخت المان‌های هر بلوک ریاضی را پیمایش کنید. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) فقط فرزندان مستقیم را برمی‌گرداند، بنابراین برای رسیدن به متن داخل کسرها، زیرنویس‌ها، رادیکال‌ها و سایر ساختارهای تو در تو به صورت بازگشتی فراخوانی کنید. عنصر جاری و فرزندان آن را بررسی کنید تا زمانی که عنصر [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) باشد، نیز شامل شود.

این مثال فرض می‌کند یک ارائه شامل معادله‌ای مانند `z = xᵢ / ∛y` باشد، که یک کسر شامل زیرنویس در صورت و رادیکال در مخرج دارد. پردازش تنها عناصری در سطح بالای بلوک متن‌های ریاضی را نمی‌پوشاند. مثال بخش‌های ریاضی در فریم‌های متنی اسلایدها را پیدا می‌کند، به بلوک‌هایشان از طریق [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) دسترسی پیدا می‌کند و [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) را از طریق ویژگی [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) هر عنصر متنی به ۲۸ پوینت تنظیم می‌کند.

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

ارائه ذخیره‌شده شامل قالب‌بندی متن به‌روز شده در هر سطح از هر معادله پردازش‌شده است، در حالی که محتوی متن و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| ترکیب عناصر | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| ایجاد کسرها | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| افزودن بالانویس یا زیرنویس | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| افزودن توابع | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| افزودن رادیکال‌ها | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| افزودن حدها | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| افزودن اسکریپت‌های سمت چپ | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| افزودن جمع‌ها و انتگرال‌ها | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| افزودن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| افزودن آرایه‌های معادله | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| افزودن جداکننده‌ها | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| افزودن نوارها و حاشیه‌ها | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| گروه‌بندی عبارات | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **سوالات متداول**

**آیا می‌توانم یک معادله موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکل حاوی یک [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) را پیدا کنید، [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) آن را دریافت کنید و بلوک‌های ریاضی را در آن پاراگراف به‌روزرسانی کنید.

**آیا معادلات به‌صورت ریاضیات ویرایش‌پذیر PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتویات ریاضی قابل ویرایش Office می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX خروجی بگیرم؟**

بله. [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) دریافت کنید و [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) را برای خروجی مستقیم فراخوانی کنید. برای یک مثال کامل، به [Export Math Equations from Presentations in .NET](/slides/fa/net/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.