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
description: "درج و ویرایش معادلات ریاضی در PowerPoint PPT و PPTX با Aspose.Slides برای Python از طریق .NET، با پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های کد واضح Python."
---
## **مرور کلی**

PowerPoint معادلات را به صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Python از طریق .NET، می‌توانید همان نوع محتوای ریاضی را برنامه‌نویسی کنید: کسرها، رادیکال‌ها، توابع، حدها، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

![یک اسلاید PowerPoint حاوی معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides متن ریاضی را از طریق سه شیئ اصلی می‌سازد:

- یک شکل ریاضی، که با [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) ایجاد می‌شود، شکلی است که معادله را در بر دارد.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) محتویات ریاضی را داخل فریم متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) شامل یک یا چند شیئ [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) و متدهای fluent موجود در [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) برای کوتاه و قابل خواندن نگه داشتن کد استفاده می‌کنند.

برای سناریوهای صادرات MathML، به [Export Math Equations from Presentations in Python via .NET](/slides/fa/python-net/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیهٔ فیثاغورث را اضافه می‌نماید:

![معادله c² برابر a² به‌اضافه b²](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) یک شکل ایجاد می‌کند که قبلاً شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) را دسترسی یافته، [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) آن را دریافت کنید و بلوک‌های ریاضی یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **اضافه کردن کسرها**

از [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) برای ایجاد یک کسر استفاده کنید. می‌توانید یک سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی شیب‌دار که یک تقسیم بر x را نشان می‌دهد](powerpoint-math-equations_4.png)

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

برای یک کسر پشته‌ای، از [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) استفاده کنید:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **اضافه کردن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) برای ایجاد ریشه مربع، ریشه مکعب یا ریشه‌های دیگر استفاده کنید. عنصر جاری به عنوان پایه می‌شود و آرگومان به عنوان درجه.

![یک عبارت رادیکال n-ام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

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

### **نمایش یا مخفی کردن درجهٔ ریشهٔ مربع**

یک ریشهٔ مربع می‌تواند عدد ۲ صریح را نمایش دهد یا از نماد متداول √x استفاده کند. ویژگی [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathradical/hide_degree/) از [IMathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathradical/) تعیین می‌کند که کدام شکل ظاهر شود. هر دو فرم درجهٔ ۲ و رادیکاند x را در معادلهٔ قابل ویرایش حفظ می‌کنند.

![ریشهٔ مربع x با درجهٔ ۲ که در سمت چپ قابل مشاهده و در سمت راست مخفی است](square-root-degree.png)

مثال ریشهٔ مربع یکسان را دو بار ذخیره می‌کند. عدد ۲ در `visible-degree.pptx` قابل مشاهده و در `hidden-degree.pptx` مخفی است.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    radical = math.MathematicalText("x").radical("2")

    shape = slide.shapes.add_math_shape(20, 20, 200, 100)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.math_paragraph.add(math.MathBlock(radical))

    radical.hide_degree = False
    presentation.save("visible-degree.pptx", slides.export.SaveFormat.PPTX)

    radical.hide_degree = True
    presentation.save("hidden-degree.pptx", slides.export.SaveFormat.PPTX)
```

## **اضافه کردن توابع و حدها**

از [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) یا [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) برای توابعی مثل `sin(x)`، `log(x)` یا نام‌های توابع سفارشی استفاده کنید. برای حدها، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) قرار دهید یا از [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) استفاده کنید.

![حد x هنگامی که x به بی‌نهایت می‌رسد](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را به‌عنوان عنصر جاری قرار داده و [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) را با آرگومان آن فراخوانی کنید:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **اضافه کردن عملگرهای N-ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) برای جمع‌ها، اتحادها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. برای انتگرال‌ها از [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) استفاده کنید. هر دو روش امکان تنظیم حدهای پایین و بالا را می‌دهند.

![یک جمع با حدهای پایین و بالا](powerpoint-math-equations_7.png)

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

عملگرهای N-ary برای عملگرهای بزرگ با حدهای اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به‌عنوان [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) اضافه شده و به عبارت پیوست می‌شوند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) استفاده کنید:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **اضافه کردن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) برای سطرها و ستون‌ها استفاده کنید. ماتریس‌ها به‌طور پیش‌فرض پرانتز ندارند، بنابراین هنگام نیاز به پرانتز، کروشه یا آکولاد، ماتریس را درون آن‌ها بپیچید.

![یک ماتریس ریاضی دو سطری با یک سلول خالی](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # ماتریس خود به خود پرانتزی ندارد، بنابراین آن را درون پرانتز بگذارید.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` شبکهٔ سطر و ستون را می‌سازد، فاصله‌ها بین آن‌ها را تنظیم می‌کند و ستون‌ها را هم‌راستا می‌سازد، اما Aspose.Slides برای Python از طریق .NET دسترسی به یک سلول منفرد ماتریس را افشا نمی‌کند. بنابراین یک ماتریس ایجاد شده در کد سلول‌های خالی را حفظ می‌کند؛ سلول‌های ماتریسی که از ارائهٔ موجود می‌آیند می‌توان با `get_children` خواند. وقتی نیاز به پر کردن سطرها از کد دارید، از یک آرایهٔ معادله استفاده کنید.
{{% /alert %}}

## **اضافه کردن آرایه‌های معادله**

از [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) وقتی به معادلات هم‌تراز یا یک پشتهٔ عمودی از عبارات نیاز دارید استفاده کنید.

![یک آرایهٔ ریاضی عمودی با x بالای y](powerpoint-math-equations_11.png)

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

### **تراز کردن یک آرایه با عناصر اطراف**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) تراز عمودی آرایه نسبت به عناصر ریاضی در کنارش را کنترل می‌کند. مثال زیر تراز را با سطر اول، مرکز آرایه و سطر آخر مقایسه می‌کند.

مثال زیر سه آرایهٔ یکسان ایجاد می‌کند، هر کدام با سه سطر و عناصر همسایهٔ `A=` و `=B`. تمام متن ریاضی از Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند. فقط تراز آرایه تغییر می‌کند.

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

مقایسهٔ زیر ارائهٔ ذخیره‌شده در PowerPoint را نشان می‌دهد. موقعیت `A=` و `=B` در کنار هر آرایه را مشاهده کنید.

![آرایه‌های معادله در PowerPoint با تراز بالا، مرکز و پایین و عناصر همسایهٔ یکسان](equation-array-alignment.png)

### **پیکربندی فاصلهٔ سطرها**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) قاعدهٔ فاصلهٔ سطرها درون آرایه را انتخاب می‌کند. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) مقدار عددی برای قاعدهٔ فاصلهٔ صریح فراهم می‌کند و توسط قواعد پیش‌فرض نادیده گرفته می‌شود.

برای فاصلهٔ دقیق، مقدار بر حسب پوینت اندازه‌گیری می‌شود. برای فاصلهٔ نسبی، بر حسب نیم‌خط محاسبه می‌شود: مقدار `3` در مثال برابر ۱.۵ خط است. هنگام تعیین یک مقدار صریح، هر دو ویژگی را تنظیم کنید؛ تغییر تنها مقدار عددی قاعدهٔ فاصله را انتخاب نمی‌کند.

مثال زیر پنج ارائهٔ با همان معادلات، تراز و تنظیمات قلم ذخیره می‌کند. اولین سه مورد از پیش‌تنظیم‌ها استفاده می‌کنند؛ دو مورد آخر مقادیر صریح را نشان می‌دهند.

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

فاصلهٔ سطرهای آرایه جدا از فاصلهٔ پاراگراف است. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) و [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) فضای اطراف پاراگراف حاوی را اضافه می‌کند، نه بین سطرهای آرایه. به همین ترتیب، [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) کل پاراگراف ریاضی را افقی موقعیت می‌دهد؛ تنظیم عمودی آرایه را جایگزین نمی‌کند.

## **اضافه کردن توابع مثلثی**

از [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) وقتی آرگومان عنصر جاری است و نام تابع شناخته شده می‌باشد استفاده کنید.

![تابع مثلثی cos بر 2x اعمال شده](powerpoint-math-equations_6.png)

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

## **اضافه کردن زیرنویس‌ها و بالانویس‌ها**

از راهنماهای زیرنویس و بالانویس برای اندیس‌ها و توان‌ها استفاده کنید. زمانی که اندیس‌ها باید در سمت چپ پایه ظاهر شوند، از [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) استفاده کنید.

![یک Y بزرگ با زیرنویس ۱ در سمت چپ و بالانویس n](powerpoint-math-equations_9.png)

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

## **اضافه کردن جداکننده‌ها**

از [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) برای قرار دادن یک عبارت درون جداکننده‌ها استفاده کنید. می‌توانید برای عبارات حاوی چند عنصر، کاراکتر جداکننده‌ای نیز تعیین کنید.

![یک عبارت جداکننده شامل x، y و z که با خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

### **اندازه و تراز جداکننده‌ها**

مقدار [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) را روی `True` تنظیم کنید تا پرانتزها اطراف یک عملوند بلند بزرگ شوند، یا روی `False` تا اندازهٔ عادی خود را حفظ کنند. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) را می‌گیرد. `CENTERED` پرانتزها را در محور ریاضی که از وسط علامت مساوی عبور می‌کند، مرکزی می‌کند. `MATCH` آن‌ها را با محتوای درون‌پوشش هم‌راستا می‌سازد. هر دو تنظیم تنها بر جداکننده‌ها تأثیر دارند. عبارت داخل بدون تغییر می‌ماند.

مثال یک کسر را در توان `x` قرار می‌دهد تا عبارت بالاتر از خط پایه بیش‌تر گسترش یابد تا زیر آن. چهار معادلهٔ زیر از همان پرانتزها و تنظیمات قلم استفاده می‌کنند.

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

در PowerPoint، ردیف‌ها را برای دیدن اثر رشد مقایسه کنید. در ردیف بالا، پرانتزها برای محصور کردن توان بزرگ می‌شوند و برای هر دو شکل یک‌سان به‌نظر می‌رسند. در ردیف پایین، رشد خاموش است. پرانتزهای کوچکتر در سمت چپ (`CENTERED`) با علامت مساوی هم‌راستا می‌شوند، در حالی که آن‌ها در سمت راست (`MATCH`) بالاتر نسبت به عبارت قرار دارند.

![چهار معادله در PowerPoint با فعال بودن رشد جداکننده در بالا و غیرفعال در پایین، و CENTERED در سمت چپ و MATCH در سمت راست](delimiter-sizing.png)

## **اضافه کردن جعبه مرزی**

[to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) را بر یک کسر صدا بزنید تا کل عبارت چارچوب‌بندی شود. [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) بازگردانده‌شده به‌طور پیش‌فرض چهار طرف را نشان می‌دهد. برای حذف طرف‌های جداگانه از [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/)، [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/)، [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/) و [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) استفاده کنید.

مثال شش کپی از همان کسر را روی یک اسلاید قرار می‌دهد. برای نمایش حذف، چهار طرف را مخفی کنید و [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) را برای یک قطر صعودی (↗) یا [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) برای یک قطر نزولی (↘) تنظیم کنید. می‌توانید همچنین از [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) یا [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) با هر ترکیبی از طرف‌های قابل مشاهده استفاده کنید.

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

![شش کسر قابل ویرایش در PowerPoint. ردیف بالا: حاشیه کامل، سمت‌های پایین و چپ، قطر بالا‌روند. ردیف پایین: قطر پایین‌روند، خط مورب افقی، خط عمودی با حاشیهٔ کامل](border-box-fractions.png)

در این کسر، خط افقی بر روی نوار کسر می‌گذرد. خط عمودی هم‌زمان اعدد سر و مقسوم را می‌گذرد در حالی که حاشیهٔ اطراف همچنان قابل مشاهده است. این خطوط کل عبارت را تزئین می‌کنند. خط‌خوردهٔ متن معمولی فقط بر روی کاراکترهای یک بخش متن اعمال می‌شود. پس از بازگشایی ارائه در PowerPoint، همچنان می‌توانید سر و مقسوم را به‌صورت مستقل ویرایش کنید.

## **کنترل قابلیت مشاهده و چینش با عناصر فانتوم**

یک عبارت را در [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) بپیچید تا قابلیت مشاهده آن و فضایی که به معادله اضافه می‌کند را به‌صورت مستقل کنترل کنید. ویژگی‌های [IMathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/) موارد زیر را کنترل می‌کنند:

| ویژگی | اثر |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/show/) | مقدار را روی `False` تنظیم کنید تا عبارت مخفی شود. ابعاد آن همچنان به چینش کمک می‌کند مگر اینکه ویژگی‌های مربوطه در زیر `True` باشند. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_width/) | عرض افقی عبارت را صفر در نظر بگیرید تا عناصر همسایه بتوانند به‌یکدیگر نزدیک‌تر شوند. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_asc/) | ارتفاع بالای خط پایه (ascender) را صفر در نظر بگیرید. این می‌تواند فضای رزرو شده بالای عناصر همسایه را کاهش دهد. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_desc/) | ارتفاع پایین خط پایه (descender) را صفر در نظر بگیرید. این می‌تواند نوار کسر یا محتوای زیرین را به‌نزدیک‌تر عناصر همسایه بکشاند. |

خط پایه خط مرجع است که حروف ریاضی عادی بر روی آن قرار می‌گیرند. مخفی کردن محتوا ابعاد آن را حذف نمی‌کند و در نظر گرفتن یک بُعد به‌عنوان صفر، عبارت را حذف نمی‌کند. عبارت زیرساختی همچنان از طریق [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/base/) در دسترس است. برای نمایش مجدد، [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/show/) را به `True` برگردانید؛ تنظیمات بُعد تغییر نمی‌کند.

مثال زیر پنج گونهٔ کنار هم را ایجاد می‌کند: یک کسر قابل مشاهده، یک کسر مخفی که فضای خود را حفظ می‌کند و سه کسر مخفی با یک بُعد صفر شده. هر گونه از همان عبارت اطراف و Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند. تمام اشکال معادله موقعیت بالایی یکسانی دارند که با راهنمای خاکستری نشان داده شده است. قرار دادن فانتوم در سر کسر بیرونی باعث می‌شود تغییرات چینش عمودی واضح‌تر دیده شود.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(1000, 180, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"]

    guide = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 10, 60, 980, 0)
    guide.line_format.fill_format.fill_type = slides.FillType.SOLID
    guide.line_format.fill_format.solid_fill_color.color = slides.Color.light_gray

    for i, label_text in enumerate(labels):
        left = 10 + i * 200
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, left, 10, 190, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = label_text
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 14
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = math.MathFraction(fraction_numerator, fraction_denominator)
        phantom = math.MathPhantom(fraction)
        phantom.show = i == 0
        phantom.zero_width = i == 2
        phantom.zero_asc = i == 3
        phantom.zero_desc = i == 4

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = math.MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = math.MathFraction(numerator, denominator)

        shape = slide.shapes.add_math_shape(left, 60, 190, 100)
        shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.add(math.MathBlock(equation))

    presentation.save("math-phantom.pptx", slides.export.SaveFormat.PPTX)
```

![پنج معادله در PowerPoint که یک کسر قابل مشاهده، یک کسر مخفی که فضای خود را حفظ می‌کند و کسرهای مخفی با ZeroWidth، ZeroAsc یا ZeroDesc فعال را مقایسه می‌کنند](math-phantom.png)

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) برای قرار دادن یک کاراکتر گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده یک حد اضافه کنید.

![عبارت x به‌اضافه y که با برچسب هر متنی زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

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

از راهنماهای قالب‌بندی فقط در جایی که فرمول را روشن می‌کند استفاده کنید. برای مثال، [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) نوار بالای یک عنصر ریاضی می‌گذارد.

![عبارت ریاضی ABC با یک نوار بالای آن](powerpoint-math-equations_14.png)

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

### **قالب‌بندی متن در یک معادلهٔ موجود**

برای قالب‌بندی متن در تمام یک معادلهٔ موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) فقط فرزندان مستقیم را برمی‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و سایر ساختارهای تو در تو به‌صورت بازگشتی فراخوانی کنید. عنصر جاری و فرزندان آن را بررسی کنید تا زمانی که عنصر شروع [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) باشد شامل شود.

این مثال فرض می‌کند که `input.pptx` شامل معادله‌ای مانند `z = xᵢ / ∛y` است، که یک کسر با زیرنویس در سر و رادیکال در زیر دارد. پردازش فقط عناصر سطح‑بالای بلوک متن را از دست می‌دهد. مثال بخش‌های ریاضی را در فریم‌های متن اسلاید پیدا می‌کند، بلوک‌هایشان را از طریق [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) دسترسی می‌کند و [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) را به ۲۸ پوینت برای هر عنصر متنی از طریق ویژگی [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) تنظیم می‌کند.

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

ارائهٔ ذخیره‌شده متن قالب‌بندی‌شده به‌روز شده را در هر سطح از هر معادلهٔ پردازش‌شده شامل می‌شود، در حالی که محتوای متنی و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| وظیفه | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| ترکیب عناصر | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| ایجاد کسرها | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| افزودن بالانویس یا زیرنویس | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| افزودن توابع | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| افزودن رادیکال‌ها | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| افزودن حدها | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| افزودن اسکریپت‌های سمت چپ | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| افزودن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| افزودن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| افزودن آرایه‌های معادله | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| افزودن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| افزودن نوارها و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **سوالات متداول**

**آیا می‌توانم معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) است پیدا کنید، [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) آن را دریافت کنید و بلوک‌های ریاضی در آن پاراگراف را به‌روز کنید.

**آیا معادلات به‌عنوان ریاضی ویرایش‌پذیر PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتوای Office ریاضی ویرایش‌پذیر می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) دریافت کنید و [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) را برای صادرات مستقیم فراخوانی کنید. برای یک مثال کامل، به [Export Math Equations from Presentations in Python via .NET](/slides/fa/python-net/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.