---
title: اضافه کردن معادلات ریاضی به ارائه‌های PowerPoint در Python
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
description: "درج و ویرایش معادلات ریاضی در فایل‌های PowerPoint PPT و PPTX با Aspose.Slides برای Python از طریق .NET، با پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های واضح کد Python."
---
## **بررسی کلی**

PowerPoint معادلات را به‌صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Python از طریق .NET، می‌توانید همان نوع محتوای ریاضی را به‌صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدها، عملگرهای N‑ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![برگه Insert در PowerPoint با دستور Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش روی اسلاید است:

![اسلاید PowerPoint شامل یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی که با [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) ایجاد می‌شود، شکلی است که معادله را در خود دارد.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) محتوای ریاضی داخل چارچوب متن شکل را ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) و متدهای fluent از [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) برای کوتاه و خوانا نگه داشتن کد استفاده می‌کنند.

برای سناریوهای خروجی MathML، به [Export Math Equations from Presentations in Python via .NET](/slides/fa/python-net/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیه فیثاغوراس را اضافه می‌نماید:

![معادله c² = a² + b²](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) یک شکلی ایجاد می‌کند که از پیش شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) را دسترسی کنید، [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) آن را دریافت کنید، و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **اضافه کردن کسرها**

از [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) انتخاب کنید.

![یک کسر کج که یک عدد بر x تقسیم می‌شود](powerpoint-math-equations_4.png)

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

برای یک کسر stacked، از [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) استفاده کنید:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **اضافه کردن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) برای ایجاد ریشهٔ درجه دوم، سوم یا سایر ریشه‌ها استفاده کنید. عنصر جاری به‌عنوان پایه قرار می‌گیرد و آرگومان به‌عنوان درجه.

![عبارت رادیکال n‑th با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

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

### **نمایش یا پنهان‌سازی درجهٔ ریشهٔ مربع**

یک ریشهٔ مربع می‌تواند عدد ۲ صریح را نمایش دهد یا از نماد متداول √x استفاده کند. ویژگی [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) در [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) تعیین می‌کند کدام فرم ظاهر شود. هر دو فرم درجهٔ ۲ و رادیکاند x را در معادلهٔ قابل ویرایش حفظ می‌کنند.

![ریشهٔ مربع x با درجهٔ ۲ دیده‌شده در سمت چپ و پنهان‌شده در سمت راست](square-root-degree.png)

این مثال همان ریشهٔ مربع را دو بار ذخیره می‌کند. عدد ۲ در `visible-degree.pptx` دیده می‌شود و در `hidden-degree.pptx` پنهان است.

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

## **اضافه کردن توابع و حدود**

از [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) یا [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) برای توابعی مانند `sin(x)`, `log(x)` یا نام‌های تابع سفارشی استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) قرار دهید یا از [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/) استفاده کنید.

![حد x هنگامی که x به بی‌نهایت میل می‌کند](powerpoint-math-equations_8.png)

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

برای یک نام تابع سفارشی، نام تابع را عنصر جاری کنید و سپس [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) را با آرگومان آن فراخوانی کنید:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **اضافه کردن عملگرهای N‑ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) برای جمع‌ها، اجتماع‌ها، اشتراک‌ها و سایر عملگرهای بزرگ استفاده کنید. برای انتگرال‌ها از [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) استفاده کنید. هر دو متد اجازه می‌دهند حدود پایین و بالا تنظیم شوند.

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

عملگرهای N‑ary برای عملگرهای بزرگ با حدود اختیاری هستند. عملگرهای ساده مثل `+`, `-`, `=` معمولاً به‌صورت [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) اضافه شده و به عبارت ترکیب می‌شوند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) استفاده کنید:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **اضافه کردن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به‌طور پیش‌فرض ماتریس‌ها براکت ندارند، بنابراین هنگام نیاز به پرانتز، براکت یا آکولاد، ماتریس را درون آن‌ها بگذارید.

![یک ماتریس ریاضی دو ردیفه با یک سلول خالی](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")
    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

### **ویرایش یک ماتریس موجود**

فرض کنید یک درس جبر خطی با ماتریس ضرایب در `matrix.pptx` آغاز می‌شود که توسط مثال قبلی ذخیره شده است. برای تمرین بعدی، معادلهٔ اول را نگه دارید، معادلهٔ دوم را با دو معادلهٔ جدید جایگزین کنید و مجموعهٔ متغیرها را بازبینی کنید. برای حفظ ضرایبی که هنوز معتبرند، ماتریس موجود را به‌عنوان یک [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) دسترسی بگیرید.

![ماتریس ضرایب دو ردیفهٔ اصلی با مقادیر 1، x و یک سلول خالی در ردیف اول و x، 2، y در ردیف دوم](matrix-before-edit.png)

اندیس‌های ردیف و ستون از صفر شروع می‌شوند و به ماتریس در هر فراخوانی اشاره می‌کنند. درج یک ردیف قبل از اندیس 1 ردیف دوم اصلی را به اندیس 2 منتقل می‌کند. درج پس از اندیس 2 سپس یک ردیف اضافه می‌کند. حذف ردیف 2 معادلهٔ دوم اصلی را حذف کرده و ردیف اضافه‌شده را یک موقعیت بالا می‌برد. ستون‌ها به‌همین شکل جابجا می‌شوند.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation("matrix.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    portion = shape.text_frame.paragraphs[0].portions[0]
    matrix = portion.math_paragraph[0][0]

    matrix.insert_row_before(1)
    matrix.insert_row_after(2)
    matrix.delete_row(2)

    matrix.insert_column_before(1)
    matrix.insert_column_after(3)
    matrix.delete_column(3)

    matrix[1, 0] = math.MathematicalText("12")
    matrix[1, 1] = math.MathematicalText("1")
    matrix[2, 2] = math.MathematicalText("10")
    matrix[2, 3] = math.MathematicalText("1")
    for row in range(matrix.row_count):
        for column in range(matrix.column_count):
            if matrix[row, column] is None:
                matrix[row, column] = math.MathematicalText("0")

    matrix.set_column_alignment(0, math.MathHorizontalAlignment.LEFT)
    matrix.set_columns_alignment(1, 3, math.MathHorizontalAlignment.RIGHT)

    presentation.save("updated-matrix.pptx", slides.export.SaveFormat.PPTX)
```

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) اولین ستون را به سمت چپ تنظیم می‌کند. [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) سه ستون متوالی را از اندیس 1 به سمت راست تنظیم می‌کند. در `updated-matrix.pptx`، ماتریس شامل سه معادله و چهار متغیر است. ضرایب ردیف اول اصلی `1` و `x` اکنون در ستون‌های اول و سوم ظاهر می‌شوند.

![ماتریس سه ردیفهٔ به‌روز شده که ردیف‌ها به ترتیب 1، 0، x، 0؛ 12، 1، 0، 0؛ و 0، 0، 10، 1 نشان داده می‌شوند](matrix-after-edit.png)

## **اضافه کردن آرایه‌های معادله**

زمانی که به معادلات هم‌تراز یا یک پشتهٔ عمودی از عبارات نیاز دارید، از [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) استفاده کنید.

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

### **هم‌ترازی آرایه با عناصر اطراف**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) تراز عمودی آرایه را نسبت به عناصر ریاضی کناری کنترل می‌کند. مثال زیر تراز را با ردیف اول، مرکز آرایه و ردیف آخر مقایسه می‌کند.

مثال زیر سه آرایهٔ یکسان با هر سه ردیف و عناصر همسایهٔ `A=` و `=B` ایجاد می‌کند. تمام متن ریاضی از Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند؛ تنها تراز آرایه تغییر می‌کند.

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

مقایسهٔ زیر ارائهٔ ذخیره‌شده در PowerPoint را نشان می‌دهد. به موقعیت `A=` و `=B` در کنار هر آرایه دقت کنید.

![آرایه‌های معادله در PowerPoint با تراز بالا، مرکز و پایین و عناصر همسایهٔ یکسان](equation-array-alignment.png)

### **پیکربندی فاصلهٔ ردیف‌ها**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) قانون فاصلهٔ ردیف‌ها را درون آرایه انتخاب می‌کند. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) مقدار عددی برای یک قانون فاصلهٔ صریح فراهم می‌کند و توسط قوانین پیش‌فرض نادیده گرفته می‌شود.

برای فاصلهٔ دقیق، مقدار بر حسب پوینت اندازه‌گیری می‌شود. برای فاصلهٔ نسبی، بر حسب نیم‌خط‌ها محاسبه می‌شود: مقدار `3` در مثال معادل ۱٫۵ خط است. هنگام تعیین مقدار صریح، هر دو ویژگی باید تنظیم شوند؛ تغییر فقط مقدار عددی قانون فاصله را انتخاب نمی‌کند.

مثال زیر پنج ارائه را با همان معادلات، تراز و تنظیمات فونت ذخیره می‌کند. سه مورد اول از پیش‌تنظیم‌ها استفاده می‌کنند؛ دو مورد آخر مقادیر صریح را نشان می‌دهند.

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

فاصلهٔ ردیف آرایه جدا از فاصلهٔ پاراگراف است. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) و [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) فضای اطراف پاراگراف حاوی آرایه را اضافه می‌کنند، نه بین ردیف‌های آرایه. به‌طور مشابه، [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) کل پاراگراف ریاضی را افقی موقعیت می‌دهد؛ تنظیمات تراز عمودی آرایه را جایگزین نمی‌کند.

## **اضافه کردن توابع مثلثاتی**

وقتی آرگومان عنصر جاری است و نام تابع شناخته شده، از [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) استفاده کنید.

![تابع مثلثاتی cos برروی 2x اعمال شده](powerpoint-math-equations_6.png)

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

از کمک‌کننده‌های زیرنویس و بالانویس برای نمایه‌ها و توان‌ها استفاده کنید. وقتی نمایه‌ها باید در سمت چپ پایه ظاهر شوند، از [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) استفاده کنید.

![حرف بزرگ Y با زیرنویس 1 در سمت چپ و بالانویس n](powerpoint-math-equations_9.png)

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

## **اضافه کردن محدوده‌گذاری‌ها**

از [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) برای قرار دادن یک عبارت داخل محدوده‌گذاری استفاده کنید. می‌توانید برای عبارات دارای چند عنصر، کاراکتر جداساز نیز تنظیم کنید.

![عبارت محدوده‌گذاری شامل x، y و z که با خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

### **اندازه و تراز محدوده‌گذاری‌ها**

[grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) را روی `True` بگذارید تا پرانتزها در اطراف یک عملوند بلند بزرگ شوند، یا روی `False` بگذارید تا اندازهٔ معمولی خود را حفظ کنند. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) را می‌گیرد. `CENTERED` پرانتزها را بر محور ریاضی (که از وسط علامت مساوی می‌گذرد) مرکز می‌کند. `MATCH` آن‌ها را با محتوای درون‌دار هم‌تراز می‌کند. هر دو تنظیم فقط بر محدوده‌گذاری‌ها تأثیر می‌گذارند؛ عبارت داخل همان‌جا می‌ماند.

مثال یک کسر را در توان `x` قرار می‌دهد تا عبارت بیشتر از خط پایه بالا کشیده شود تا پایین. هر چهار معادله از همان پرانتز و تنظیمات فونت استفاده می‌کند.

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

در PowerPoint، ردیف‌ها را برای مشاهدهٔ اثر رشد مقایسه کنید. در ردیف بالایی، پرانتزها برای محصور کردن توان رشد می‌کنند و برای هر دو شکل یکسان به‌نظر می‌رسند. در ردیف پایینی، رشد غیرفعال است. پرانتزهای کوچکتر سمت چپ (`CENTERED`) با علامت مساوی هم‌تراز هستند، در حالی که سمت راست (`MATCH`) بالاتر اطراف عبارت قرار می‌گیرند.

![چهار معادله در PowerPoint با رشد محدوده‌گذاری فعال در بالا و غیرفعال در پایین، و Centered در چپ و Match در راست](delimiter-sizing.png)

## **اضافه کردن جعبهٔ مرزی**

برای یک کسر، متد [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) را فراخوانی کنید تا تمام عبارت در یک قاب قرار گیرد. [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) به‌صورت پیش‌فرض تمام چهار طرف را نشان می‌دهد. از [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/)، [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/)، [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/) و [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/) برای حذف طرف‌های جداگانه استفاده کنید.

مثال شش نسخهٔ یکسان از همان کسر را روی یک اسلاید قرار می‌دهد. برای نشان دادن لغو، تمام چهار طرف را مخفی کنید و برای یک مورب بالا به راست [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) یا برای یک مورب پایین به راست [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) تنظیم کنید. همچنین می‌توانید از [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) یا [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) همراه با ترکیبی از طرف‌های قابل نمایش استفاده کنید.

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

![شش کسر قابل ویرایش در PowerPoint. ردیف بالا: مرز کامل، طرف‌های پایین و چپ، مورب بالا. ردیف پایین: مورب پایین، خط افقی، خط عمودی با مرز کامل](border-box-fractions.png)

در این کسر، خط افقی بر روی خط کسر همپوشانی دارد. خط عمودی هر دو مخرج و صورت را می‌گذرد در حالی که مرز اطراف قابل مشاهده می‌ماند. این خطوط کل عبارت را تزئین می‌کنند. Strikethrough متنی معمولی فقط بر کاراکترهای یک اجرای متن اعمال می‌شود. پس از باز کردن مجدد ارائه در PowerPoint، می‌توانید مخرج و صورت را به‌صورت مستقل ویرایش کنید.

## **کنترل نمایش و چیدمان با عناصر شبحی**

یک عبارت را در [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) بپیچید تا نمایش آن و فضایی که به یک معادله اضافه می‌کند را به‌صورت مستقل کنترل کنید. ویژگی‌های آن موارد زیر را تنظیم می‌کنند:

| Property | Effect |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | مقدار `False` آن را مخفی می‌کند. ابعاد آن همچنان به چیدمان کمک می‌کند مگر اینکه ویژگی‌های مربوطه زیر `True` شوند. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | عرض افقی عبارت را صفر در نظر می‌گیرد تا عناصر همسایه نزدیک‌تر شوند. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | ارتفاع بالای خط پایه (ascender) را صفر می‌داند و می‌تواند فضای بالای عناصر همسایه را کاهش دهد. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | عمق زیر خط پایه (descender) را صفر می‌داند و می‌تواند خط کسر یا محتوای دیگر زیر عبارت را به همسایه‌ها نزدیک‌تر کند. |

خط پایه خطی است که حروف ریاضی معمولی بر روی آن قرار می‌گیرند. مخفی کردن محتوا ابعاد آن را حذف نمی‌کند و در نظر گرفتن یک بعد به‌عنوان صفر همچنان عبارت را حذف نمی‌کند. عبارت پایه از طریق [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/) در دسترس می‌ماند. برای نمایش مجدد، [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) را به `True` برگردانید؛ تنظیمات بعدی بدون تغییر باقی می‌مانند.

مثال زیر پنج گونهٔ کنار هم ایجاد می‌کند: یک کسر قابل مشاهده، یک کسر مخفی که فضا را رزرو می‌کند، و سه کسر مخفی که یک بعد آن به صفر تبدیل شده است. هر گونه از همان عبارت اطراف و Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند. تمام شکل‌های معادله موقعیت بالا مشابهی دارند که با راهنمای خاکستری مشخص شده است. قرار دادن شبح در صورت یک کسر بیرونی تغییرات چیدمان عمودی را راحت‌تر نشان می‌دهد.

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

![پنج معادله در PowerPoint که یک کسر قابل مشاهده، یک کسر مخفی که فضا را رزرو می‌کند و کسرهای مخفی با ZeroWidth، ZeroAsc یا ZeroDesc فعال را مقایسه می‌کند](math-phantom.png)

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) برای قرار دادن یک کاراکتر گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده می‌توانید یک حد اضافه کنید.

![عبارتی x + y که با برچسب متنی دلخواه زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

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

از کمک‌کننده‌های قالب‌بندی فقط در جایی که فرمول را واضح می‌کند استفاده کنید. برای مثال، [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) یک نوار بالای عنصر ریاضی می‌گذارد.

![عبارت ریاضی ABC با یک overbar](powerpoint-math-equations_14.png)

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

برای قالب‌بندی متن در سراسر یک معادلهٔ موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) تنها فرزندان مستقیم را برمی‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و ساختارهای تو در تو باید به‌صورت بازگشتی فراخوانی شود. عنصر جاری و فرزندان آن را نیز بررسی کنید تا وقتی عنصر [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) باشد، شامل شود.

این مثال فرض می‌کند `input.pptx` شامل معادله‌ای نظیر `z = xᵢ / ∛y` باشد، که یک کسر با زیرنویس در صورت و یک رادیکال در مخرج دارد. پردازش تنها عناصر سطح بالای بلوک متن را از دست می‌دهد. مثال، بخش‌های ریاضی را در فریم‌های متن اسلاید پیدا می‌کند، بلوک‌های آن‌ها را از طریق [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) دسترسی می‌یابد و [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) را برای هر عنصر متن به‌واسطهٔ ویژگی [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) به ۲۸ پوینت تنظیم می‌کند.

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

ارائهٔ ذخیره‌شده متن قالب‌بندی شده را در هر سطح از هر معادلهٔ پردازش‌شده نگه می‌دارد، در حالی که محتوای متن و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| Task | Main API |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| ترکیب عناصر | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| ایجاد کسرها | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| افزودن بالانویس یا زیرنویس | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| افزودن توابع | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| افزودن رادیکال‌ها | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| افزودن حدود | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| افزودن اسکریپت‌های سمت چپ | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| افزودن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| افزودن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| افزودن آرایه‌های معادله | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| افزودن محدوده‌گذاری‌ها | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| افزودن نوارها و مرزها | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **سؤالات متداول**

**آیا می‌توان معادلهٔ موجود در PowerPoint را ویرایش کرد؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) است پیدا کنید، [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) آن را دریافت کنید و بلوک‌های ریاضی در آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به‌عنوان ریاضی قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌صورت محتوای Office Math قابل ویرایش می‌نویسد.

**آیا می‌توان معادلات را به LaTeX صادر کرد؟**

بله. [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) دریافت کنید و سپس [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) را فراخوانی کنید تا مستقیماً صادر شود. برای یک مثال کامل، به [Export Math Equations from Presentations in Python via .NET](/slides/fa/python-net/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.