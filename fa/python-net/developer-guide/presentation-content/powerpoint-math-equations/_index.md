---
title: افزودن معادلات ریاضی به ارائه‌های PowerPoint در Python
linktitle: معادلات ریاضی PowerPoint
type: docs
weight: 80
url: /fa/python-net/powerpoint-math-equations/
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
- Python
- Aspose.Slides
description: "در PowerPoint (PPT و PPTX) معادلات ریاضی را با Aspose.Slides برای Python از طریق .NET درج و ویرایش کنید؛ از OMML، کنترل‌های قالب‌بندی، و نمونه‌های واضح کد Python پشتیبانی می‌کند."
---
## **بررسی کلی**

PowerPoint معادلات را به عنوان Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Python از طریق .NET، می‌توانید همان نوع محتوای ریاضی را به‌صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدود، عملگرهای N‑ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با انتخاب فرمان Equation](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش بر روی اسلاید است:

![یک اسلاید PowerPoint حاوی یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی که با [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) ایجاد می‌شود، شکلی است که معادله را در بر می‌گیرد.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) محتویات ریاضی را داخل چارچوب متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) و متدهای fluent از [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) برای کوتاه و قابل‌خواندن نگه داشتن کد استفاده می‌کند.

برای سناریوهای صادرات MathML، see [صادر کردن معادلات ریاضی از ارائه‌ها در Python از طریق .NET](/slides/fa/python-net/exporting-math-equations/).

## **ایجاد یک معادله**

این مثال از [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) برای ایجاد یک شکل ریاضی استفاده می‌کند و نظریهٔ فیثاغورث را اضافه می‌کند:

![معادله c² برابر a² بعلاوه b²](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}

[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) یک شکل را ایجاد می‌کند که از پیش شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) را دریافت کنید، [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) آن را بگیرید، و بلوک‌های ریاضی یا عناصر ریاضی را به آن اضافه کنید.

{{% /alert %}}

## **اضافه کردن کسرها**

از [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی کج نشان‌دهنده یک تقسیم شده بر x](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

برای یک کسر لایه‌ای، از [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) استفاده کنید:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **اضافه کردن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) برای ایجاد ریشه‌ی مربع، ریشه‌ی مکعب یا سایر ریشه‌ها استفاده کنید. عنصر فعلی به‌عنوان پایه می‌شود و آرگومان به‌عنوان درجه.

![یک عبارت رادیکال n‑ام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **اضافه کردن توابع و حدود**

از [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) یا [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) برای توابعی مانند `sin(x)`، `log(x)` یا نام‌های توابع سفارشی استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) قرار دهید یا از [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) استفاده کنید.

![حد x هنگامی که x به بی‌نهایت نزدیک می‌شود](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

برای نام تابع سفارشی، نام تابع را به‌عنوان عنصر فعلی قرار دهید و [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) را با آرگومان آن فراخوانی کنید:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **اضافه کردن عملگرهای N‑ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) برای جمع‌ها، اتحادها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. برای انتگرال‌ها از [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) استفاده کنید. هر دو روش به شما امکان تنظیم حدود پایین و بالا را می‌دهند.

![یک جمع با حدود پایین و بالا](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

عملگرهای N‑ary برای عملگرهای بزرگ با حدود اختیاری هستند. عملگرهای ساده مثل `+`، `-` و `=` معمولاً به‌عنوان [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) اضافه شده و به عبارت متصل می‌شوند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) استفاده کنید:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **اضافه کردن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به‌طور پیش‌فرض ماتریس‌ها پرانتز ندارند، بنابراین وقتی نیاز به پرانتز، کروشه یا آکولاد دارید، ماتریس را درون این نشانه‌ها بگنجانید.

![یک ماتریس ریاضی دو ردیفه با یک خانه خالی](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # یک ماتریس پرانتزهای خود را ندارد، بنابراین آن را در پرانتز بگذارید.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}

`MathMatrix` شبکه ردیف و ستون را می‌سازد، فاصله‌ها را تنظیم می‌کند و ستون‌ها را هم‌تراز می‌نماید، اما Aspose.Slides برای Python از طریق .NET دسترسی به یک سلول منفرد ماتریس را فراهم نمی‌کند. یک ماتریس که در کد ایجاد می‌شود، بنابراین سلول‌های خالی را حفظ می‌کند؛ سلول‌های ماتریسی که از ارائه‌ی موجود می‌آیند می‌توانند با `get_children` خوانده شوند. وقتی نیاز به پر کردن ردیف‌ها از کد دارید، از یک آرایه معادله استفاده کنید.

{{% /alert %}}

## **اضافه کردن آرایه‌های معادله**

از [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) وقتی به معادلات هم‌تراز یا یک پشتهٔ عمودی از عبارات نیاز دارید، استفاده کنید.

![یک آرایه ریاضی عمودی با x بالای y](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

### **هم‌ترازی یک آرایه با عناصر اطراف**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) هم‌ترازی عمودی آرایه را نسبت به عناصر ریاضی در کنار آن کنترل می‌کند. مثال زیر هم‌ترازی ردیف اول، مرکز آرایه و ردیف آخر را مقایسه می‌کند.

مثال زیر سه آرایهٔ یکسان با هر کدام سه ردیف و عناصر همسایهٔ `A=` و `=B` ایجاد می‌کند. تمام متن‌های ریاضی از Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کنند. تنها هم‌ترازی آرایه تغییر می‌کند.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(780, 200, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    alignments = [math.MathVerticalAlignment.TOP, math.MathVerticalAlignment.CENTER, math.MathVerticalAlignment.BOTTOM]
    labels = ["Top", "Center", "Bottom"]

    for i, alignment in enumerate(alignments):
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20 + i * 260, 10, 240, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = labels[i]
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 16
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        math_shape = slide.shapes.add_math_shape(20 + i * 260, 60, 240, 130)
        math_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = alignment
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", slides.export.SaveFormat.PPTX)
```

مقایسه زیر ارائهٔ ذخیره‌شده در PowerPoint را نشان می‌دهد. به موقعیت `A=` و `=B` در کنار هر آرایه توجه کنید.

![آرایه‌های معادله در PowerPoint با هم‌ترازی بالا، مرکز و پایین و عناصر همسایهٔ یکسان](equation-array-alignment.png)

### **پیکربندی فاصلهٔ ردیف‌ها**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) قانون فاصلهٔ ردیف‌ها را درون آرایه انتخاب می‌کند. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) مقدار عددی برای یک قانون فاصلهٔ صریح فراهم می‌کند و توسط قوانین پیش‌فرض نادیده گرفته می‌شود.

برای فاصلهٔ دقیق، مقدار بر حسب پوینت اندازه‌گیری می‌شود. برای فاصلهٔ نسبی، بر حسب نیم‌خط‌ها اندازه‌گیری می‌شود: مقدار `3` در مثال برابر ۱٫۵ خط است. هنگام مشخص کردن مقدار صریح، هر دو ویژگی را تنظیم کنید؛ تغییر فقط مقدار عددی قانون فاصله را انتخاب نمی‌کند.

مثال زیر پنج ارائه با معادلات، هم‌ترازی و تنظیمات فونت یکسان ذخیره می‌کند. سه مورد اول از پیش‌تنظیم‌ها استفاده می‌کند؛ دو مورد آخر مقادیر صریح را نشان می‌دهد.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


settings = [
    (math.MathRowSpacingRule.SINGLE_LINE_GAP, 0),
    (math.MathRowSpacingRule.ONE_AND_A_HALF_LINE_GAP, 0),
    (math.MathRowSpacingRule.TWO_LINE_GAP, 0),
    (math.MathRowSpacingRule.EXACTLY, 20),
    (math.MathRowSpacingRule.MULTIPLE, 3)
]

for rule, spacing in settings:
    file_name = f"equation-array-{rule.name}.pptx"
    with slides.Presentation() as presentation:
        math_shape = presentation.slides[0].shapes.add_math_shape(20, 20, 600, 300)
        paragraph = math_shape.text_frame.paragraphs[0]
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        math_paragraph = paragraph.portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = math.MathVerticalAlignment.CENTER
        equation_array.row_spacing_rule = rule
        equation_array.row_spacing = spacing
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

فاصلهٔ ردیف آرایه جدا از فاصلهٔ پاراگراف است. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) و [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) فضا را دور پاراگراف حاوی آرایه اضافه می‌کند، نه بین ردیف‌های آرایه. به‌همین ترتیب، [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) پاراگراف ریاضی را به‌صورت افقی موقعیت می‌دهد؛ تنظیم عمودی آرایه را جایگزین نمی‌کند.

## **اضافه کردن توابع مثلثاتی**

از [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) وقتی آرگومان عنصر فعلی است و نام تابع شناخته شده است، استفاده کنید.

![تابع مثلثاتی cos اعمال شده روی 2x](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **اضافه کردن زیرنویس و بالانویس**

از ابزارهای زیرنویس و بالانویس برای شاخص‌ها و توان‌ها استفاده کنید. وقتی شاخص‌ها باید در سمت چپ پایه ظاهر شوند، از [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) استفاده کنید.

![یک Y بزرگ با زیرنویس چپ‌دست ۱ و بالانویس n](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **اضافه کردن جداسازها**

از [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) برای قرار دادن یک عبارت داخل جداسازها استفاده کنید. می‌توانید برای عبارات جداساز که چندین عنصر دارند، یک کاراکتر جداکننده تعیین کنید.

![یک عبارت جداساز شامل x، y و z که با خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

### **اندازه و هم‌ترازی جداسازها**

[grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) را روی `True` تنظیم کنید تا پرانتزها برای عملوند بلند بزرگ شوند، یا روی `False` برای حفظ اندازهٔ عادی. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) را می‌گیرد. `CENTERED` پرانتزها را روی محور ریاضی که از وسط علامت برابر می‌گذرد، وسط‌گذاری می‌کند. `MATCH` آنها را با محتوای داخل سازگار می‌کند. هر دو تنظیم فقط بر جداسازها تأثیر می‌گذارند؛ عبارت داخل به همان صورت می‌ماند.

مثال یک کسر را در توان `x` قرار می‌دهد تا عبارت بالاتر از خط پایه گسترش یابد. همهٔ چهار معادله از یک نوع پرانتز و تنظیمات فونت استفاده می‌کنند.

```python
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_expression(slide, left, top, grow, shape):
    fraction = math.MathematicalText("a + b").divide("c + d")
    power = math.MathematicalText("x").set_superscript(fraction)
    delimiter = power.enclose("(", ")")
    delimiter.grow_to_match_operand_height = grow
    delimiter.delimiter_shape = shape

    math_shape = slide.shapes.add_math_shape(left, top, 300, 100)
    portion = math_shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 32
    equation = math.MathematicalText("y = ").join(delimiter)
    portion.math_paragraph.add(equation)


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    add_expression(slide, 20, 20, True, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 20, True, math.MathDelimiterShape.MATCH)
    add_expression(slide, 20, 140, False, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 140, False, math.MathDelimiterShape.MATCH)

    presentation.save("delimiter-sizing.pptx", slides.export.SaveFormat.PPTX)
```

در PowerPoint، ردیف‌ها را مقایسه کنید تا اثر رشد را ببینید. در ردیف بالا، پرانتزها برای محصور کردن توان رشد می‌کنند و برای هر دو شکل مشابه هستند. در ردیف پایین، رشد خاموش است. پرانتزهای کوچکتر سمت چپ (`CENTERED`) با علامت برابر هم‌تراز می‌شوند، در حالی که آن‌های سمت راست (`MATCH`) بالاتر اطراف عبارت می‌نشینند.

![چهار معادله در PowerPoint با فعال بودن رشد جداسازها در بالا و غیرفعال در پایین، و CENTERED در چپ و MATCH در راست](delimiter-sizing.png)

## **اضافه کردن جعبهٔ حاشیه‌ای**

روی یک کسر متد [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) را فراخوانی کنید تا کل عبارت در یک جعبهٔ حاشیه‌ای قرار گیرد. [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) بازگشتی به‌طور پیش‌فرض چهار طرف را نشان می‌دهد. از [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/)، [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/)، [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/) و [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) برای حذف هر طرف به‌صورت جداگانه استفاده کنید.

مثال شش نسخهٔ یکسان از همان کسر را روی یک اسلاید قرار می‌دهد. برای نشان دادن حذف، تمام چهار طرف را مخفی کنید و برای خط مورب صعودی (↗) از [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) یا برای خط مورب سقوطی (↘) از [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) استفاده کنید. می‌توانید همچنین از [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) یا [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) به‌همراه ترکیبی از طرف‌های قابل مشاهده بهره ببرید.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_fraction(slide, x, y, hide_border=False):
    fraction = math.MathematicalText("x+1").divide("y+2")
    box = fraction.to_border_box()
    box.hide_top = box.hide_bottom = box.hide_left = box.hide_right = hide_border

    shape = slide.shapes.add_math_shape(x, y, 160, 90)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 28
    portion.math_paragraph.add(math.MathBlock(box))
    return box


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(540, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    add_fraction(slide, 10, 10)

    partial = add_fraction(slide, 190, 10)
    partial.hide_top = True
    partial.hide_right = True

    add_fraction(slide, 370, 10, hide_border=True).strikethrough_bottom_left_to_top_right = True
    add_fraction(slide, 10, 120, hide_border=True).strikethrough_top_left_to_bottom_right = True
    add_fraction(slide, 190, 120, hide_border=True).strikethrough_horizontal = True
    add_fraction(slide, 370, 120).strikethrough_vertical = True

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

![شش کسر قابل ویرایش در PowerPoint. ردیف بالا: حاشیه کامل، طرف پایین و چپ، مورب صعودی. ردیف پایین: مورب سقوطی، خط افقی، خط عمودی با حاشیه کامل.](border-box-fractions.png)

در این کسر، خط افقی بر روی نوار کسر می‌افتد. خط عمودی هر دو صورت و مخرج را می‌گذرد در حالی که حاشیهٔ اطراف قابل مشاهده می‌ماند. این خطوط کل عبارت را تزئین می‌کنند. خط کشی معمولی متن صرفاً بر حروف داخل یک رن متن اعمال می‌شود. پس از باز کردن دوباره ارائه در PowerPoint، همچنان می‌توانید صورت و مخرج را به‌صورت جداگانه ویرایش کنید.

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) برای قرار دادن یک علامت گروه‌بندی بالای یا زیر یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده می‌توانید یک حد اضافه کنید.

![عبارت x به‌اضافه y که با برچسب متن دلخواه زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **قالب‌بندی عناصر ریاضی**

از ابزارهای قالب‌بندی فقط در جایی استفاده کنید که فرمول را واضح‌تر می‌کند. برای مثال، [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) یک نوار بالای عنصر ریاضی می‌گذارد.

![یک عبارت ریاضی ABC با یک overbar](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

### **قالب‌بندی متن در یک معادله موجود**

برای قالب‌بندی متن در سرتاسر یک معادله موجود، درخت عناصر هر بلوک ریاضی را پیمایش کنید. [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) فقط فرزندان مستقیم را برمی‌گرداند، بنابراین برای رسیدن به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و سایر ساختارهای تو در تو باید به‌صورت بازگشتی فراخوانی شود. عنصر فعلی و فرزندانش را بررسی کنید تا عنصر شروعی که [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) است نیز شامل شود.

این مثال فرض می‌کند که `input.pptx` شامل معادله‌ای مانند `z = xᵢ / ∛y` باشد، که شامل یک کسر با زیرنویس در صورت و رادیکال در مخرج است. پردازش فقط عناصر سطح بالای بلوک، متن داخل کسر را نادیده می‌گیرد. مثال قسمت‌های ریاضی را در چارچوب‌های متن اسلایدها پیدا می‌کند، بلوک‌هایشان را از طریق [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) دسترسی می‌دهد و [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) را برای هر عنصر متنی از طریق ویژگی [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) به ۲۸ پوینت تنظیم می‌کند.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def format_math_text(element):
    if isinstance(element, math.MathematicalText):
        element.format.font_height = 28

    for child in element.get_children():
        format_math_text(child)


with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if isinstance(portion, math.MathPortion):
                        for block in portion.math_paragraph:
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", slides.export.SaveFormat.PPTX)
```

ارائهٔ ذخیره‌شده متن قالب‌بندی‌شده جدید را در هر سطح از هر معادلهٔ پردازش‌شده دارد، در حالی که محتوای متنی و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| ترکیب عناصر | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| ایجاد کسرها | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| اضافه کردن بالانویس یا زیرنویس | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| اضافه کردن توابع | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| اضافه کردن رادیکال‌ها | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| اضافه کردن حدود | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| اضافه کردن اسکریپت‌های سمت چپ | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| اضافه کردن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| اضافه کردن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| اضافه کردن آرایه‌های معادله | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| اضافه کردن جداسازها | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| اضافه کردن نوارها و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **سؤال‌های متداول**

**آیا می‌توانم یک معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) است پیدا کنید، [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) آن را دریافت کنید و بلوک‌های ریاضی در آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به‌عنوان ریاضی قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتوای Office Math قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) دریافت کنید و متد [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) را فراخوانی کنید تا مستقیماً صادر شود. برای یک مثال کامل، به [Export Math Equations from Presentations in Python via .NET](/slides/fa/python-net/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.