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
description: "در PowerPoint (PPT و PPTX) معادلات ریاضی را با Aspose.Slides برای Python از طریق .NET وارد کنید و ویرایش کنید؛ پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های واضح کد Python."
---
## **بررسی کلی**

PowerPoint معادلات را به صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Python از طریق .NET، می‌توانید همان نوع محتوای ریاضی را به‌صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدود، عملگرهای N‑ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش بر روی اسلاید است:

![یک اسلاید PowerPoint حاوی یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی که با [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) ایجاد می‌شود، شکلی است که معادله را در بر داشته است.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) محتوای ریاضی را داخل قاب متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) و متدهای fluent از [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) برای کوتاه و قابل خواندن نگه داشتن کد استفاده می‌کنند.

برای سناریوهای خروجی MathML، به [Export Math Equations from Presentations in Python via .NET](/slides/fa/python-net/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیه فیثاغورث را اضافه می‌کند:

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

[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) یک شکل ایجاد می‌کند که قبلاً شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) را دریافت کنید، [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) آن را بگیرید و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.

{{% /alert %}}

### **ترکیب بلوک‌های ریاضی**

هنگامی که بخش‌هایی از یک معادله به‌صورت مستقل به عنوان شیء [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) ساخته می‌شوند، از [join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) برای ترکیב آن‌ها استفاده کنید. این مثال `c² =` را در بلوک چپ و `a² + b²` را در بلوک راست می‌سازد. [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/) نمایانی‌های ریاضی قابل ویرایش برای هر سه توان ایجاد می‌کند.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_math_shape(20, 20, 600, 100)
    math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph

    left_block = math.MathBlock()
    left_block.add(math.MathematicalText("c").set_superscript("2"))
    left_block.add(math.MathematicalText("="))

    right_block = math.MathBlock()
    right_block.add(math.MathematicalText("a").set_superscript("2"))
    right_block.add(math.MathematicalText("+"))
    right_block.add(math.MathematicalText("b").set_superscript("2"))

    combined_block = left_block.join_block(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", slides.export.SaveFormat.PPTX)
```

[join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) مقدار `left_block` را برمی‌گرداند که اکنون هر دو بخش را به ترتیب در خود دارد و `right_block` را خالی می‌گذارد. بلوک ترکیبی را تنها یک بار به [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) اضافه کنید. پس از باز کردن مجدد `equation.pptx`، پاراگراف شامل یک بلوک است که معادل `c² = a² + b²` را نشان می‌دهد و هر سه توان به‌عنوان نمایانی‌های ریاضی حفظ شده‌اند.

فراخوانی [add](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/add/) به شکل `left_block.add(right_block)` به‌جای این کار سعی می‌کند یک بلوک را مستقیماً داخل بلوک دیگر قرار دهد و `RuntimeError`ی حاکی از `InvalidOperationException` .NET را ایجاد می‌کند.

## **اضافه کردن کسرها**

از [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی اریبی که یک بر x تقسیم شده است](powerpoint-math-equations_4.png)

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

از [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) برای ایجاد رادیکال ریشه دوم، ریشه سوم یا ریشه‌های دیگر استفاده کنید. عنصر جاری به‌عنوان پایه می‌شود و آرگومان به‌عنوان درجه.

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

### **نمایش یا مخفی کردن درجه رادیکال ریشه دوم**

یک ریشه دوم می‌تواند عدد ۲ صریح را نمایش دهد یا از نماد متداول √x استفاده کند. ویژگی [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) از [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) کنترل می‌کند کدام شکل ظاهر شود. هر دو شکل درجه ۲ و رادیکاند x را در معادله قابل ویرایش حفظ می‌کنند.

![ریشه دوم x با درجه ۲ که در سمت چپ قابل رؤیت و در سمت راست مخفی است](square-root-degree.png)

این مثال ریشه دوم را دو بار ذخیره می‌کند. عدد ۲ در `visible-degree.pptx` قابل رؤیت است و در `hidden-degree.pptx` مخفی است.

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

از [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) یا [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) برای توابعی مانند `sin(x)`, `log(x)` یا نام‌های سفارشی توابع استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) قرار دهید یا از [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/) استفاده کنید.

![حد x وقتی x به بی‌نهایت میل می‌کند](powerpoint-math-equations_8.png)

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

برای یک نام تابع سفارشی، نام تابع را به عنوان عنصر جاری در‌آورده و سپس [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) را با آرگومان آن فراخوانی کنید:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **اضافه کردن عملگرهای N‑ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) برای جمع‌ها، اتحادیه‌ها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. از [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) برای انتگرال‌ها استفاده کنید. هر دو متد امکان تنظیم حدود پایین و بالا را می‌دهند.

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

عملگرهای N‑ary برای عملگرهای بزرگ با حدود اختیاری هستند. عملگرهای ساده مثل `+`, `-`, `=` معمولاً به‌صورت [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) اضافه می‌شوند و به عبارت ترکیب می‌گردند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) استفاده کنید:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **اضافه کردن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به طور پیش‌فرض ماتریس‌ها قلاب ندارند، بنابراین برای نیاز به پرانتز، کروشه یا قوس‌کمان، ماتریس را درون آن‌ها بپیچید.

![یک ماتریس ریاضی دو ردیفی با یک سلول خالی](powerpoint-math-equations_10.png)

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

فرض کنید یک درس جبر خطی با ماتریس ضرایب در `matrix.pptx` که توسط مثال قبلی ذخیره شده، شروع می‌شود. برای تمرین بعدی، معادله اول را حفظ کنید، معادله دوم را با دو معادله جدید جایگزین کنید و مجموعه متغیرها را بازنگری کنید. ماتریس موجود را به عنوان یک [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) دریافت کنید تا ضرایبی که هنوز معتبرند حفظ شوند.

![ماتریس ضرایب دو ردیفی اصلی با مقادیر 1، x و یک سلول خالی در ردیف اول و x، 2، y در ردیف دوم](matrix-before-edit.png)

اندیس‌های ردیف و ستون از صفر شروع می‌شوند و به ماتریسی که در هر فراخوانی وجود دارد اشاره می‌کنند. درج یک ردیف قبل از اندیس 1، ردیف دوم اصلی را به اندیس 2 جابه‌جا می‌کند. درج پس از اندیس 2 سپس یک ردیف اضافه می‌کند. حذف ردیف 2 معادله دوم اصلی را حذف می‌کند و ردیف افزوده شده را یک موقعیت بالا می‌برد. ستون‌ها به همان شیوه جابه‌جا می‌شوند.

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

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) ستون اول را به چپ تراز می‌کند. [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) سه ستون متوالی را از اندیس 1 به راست تراز می‌کند. در `updated-matrix.pptx`، ماتریس دارای سه معادله و چهار متغیر است. ضرایب ردیف اول اصلی `1` و `x` اکنون در ستون‌های اول و سوم ظاهر می‌شوند.

![ماتریس سه ردیفی به‌روزرسانی‌شده که ردیف‌ها را به شکل 1, 0, x, 0؛ 12, 1, 0, 0؛ و 0, 0, 10, 1 نشان می‌دهد](matrix-after-edit.png)

## **اضافه کردن آرایه‌های معادله**

از [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) زمانی که به معادلات هم‌تراز یا یک پشته عمودی از عبارات نیاز دارید، استفاده کنید.

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

### **هم‌تراز کردن یک آرایه با عناصر اطراف**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) تراز عمودی آرایه نسبت به عناصر ریاضی کناری را کنترل می‌کند. مثال زیر تراز را با اولین ردیف، مرکز آرایه و آخرین ردیف مقایسه می‌کند.

مثال زیر سه آرایه یکسان ایجاد می‌کند که هر کدام سه ردیف و عناصر همسایه `A=` و `=B` دارند. تمام متن ریاضی از Cambria Math با اندازه ۲۴ پوینت استفاده می‌کند. فقط تراز آرایه تغییر می‌کند.

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

مقایسه زیر ارائه ذخیره‌شده در PowerPoint را نشان می‌دهد. به موقعیت `A=` و `=B` در کنار هر آرایه توجه کنید.

![آرایه‌های معادله در PowerPoint با تراز Top، Center و Bottom و عناصر همسایه یکسان](equation-array-alignment.png)

### **پیکربندی فاصله ردیف‌ها**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) قانون فاصله ردیف‌ها درون آرایه را انتخاب می‌کند. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) مقدار عددی برای یک قانون فاصله صریح فراهم می‌کند و توسط قوانین پیش‌فرض نادیده گرفته می‌شود.

برای فاصله دقیق، مقدار بر حسب پوینت اندازه‌گیری می‌شود. برای فاصله نسبی، بر حسب نیم‌خط اندازه‌گیری می‌شود: مقدار `3` در مثال به‌معنی ۱٫۵ خط است. هنگام تعیین مقدار صریح هر دو خصوصیت را تنظیم کنید؛ تغییر مقدار عددی به تنهایی قانون فاصله را انتخاب نمی‌کند.

مثال زیر پنج ارائه با معادلات، تراز و تنظیمات قلم یکسان ذخیره می‌کند. سه مورد اول از پیش‌تنظیم‌ها استفاده می‌کنند؛ دو مورد آخر مقادیر صریح را نشان می‌دهند.

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

فاصله ردیف آرایه جدا از فاصله پاراگراف است. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) و [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) فضای اطراف پاراگراف حاوی آرایه را اضافه می‌کنند، نه بین ردیف‌های آرایه. به‌علاوه، [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) کل پاراگراف ریاضی را به‌صورت افقی موقعیت می‌دهد؛ این تنظیم جایگزین تنظیم عمودی آرایه نمی‌شود.

## **اضافه کردن توابع مثلثاتی**

از [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) وقتی آرگومان عنصر جاری است و نام تابع شناخته شده، استفاده کنید.

![تابع مثلثاتی cos بر ۲x اعمال شده](powerpoint-math-equations_6.png)

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

از کمک‌کنندگان زیرنویس و بالانویس برای شاخص‌ها و توان‌ها استفاده کنید. وقتی شاخص‌ها باید در سمت چپ پایه ظاهر شوند، از [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) استفاده کنید.

![یک حرف بزرگ Y با زیرنویس ۱ در سمت چپ و بالانویس n](powerpoint-math-equations_9.png)

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

از [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) برای قرار دادن یک عبارت داخل جداکننده‌ها استفاده کنید. می‌توانید یک کاراکتر جداکننده برای عبارات حاوی چند عنصر نیز تنظیم کنید.

![عبارتی با جداکننده شامل x، y و z که توسط خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

[grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) را به `True` تنظیم کنید تا پرانتزها برای یک عملوند بلند بزرگ شوند، یا به `False` تا اندازهٔ معمولی خود بمانند. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) را می‌گیرد. `CENTERED` پرانتزها را بر محور ریاضی که از وسط علامت مساوی عبور می‌کند، متمرکز می‌کند. `MATCH` آن‌ها را با محتوای بسته شده هم‌راستا می‌کند. هر دو تنظیم فقط بر جداکننده‌ها تأثیر می‌گذارند. عبارت داخل همان‌طور می‌ماند.

مثال یک کسر را در توان `x` قرار می‌دهد تا عبارت بالاتر از خط پایه بیشتر از زیر آن گسترش یابد. تمام چهار معادله از همان پرانتزها و تنظیمات قلم استفاده می‌کنند.

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

در PowerPoint، ردیف‌ها را مقایسه کنید تا تأثیر رشد را ببینید. در ردیف بالایی، پرانتزها برای محصور کردن توان رشد می‌کنند و برای هر دو شکل یکسان به‌نظر می‌رسند. در ردیف پایینی، رشد خاموش است. پرانتزهای کوچکتر در سمت چپ (`CENTERED`) با علامت مساوی هم‌راستا می‌شوند، در حالی که در سمت راست (`MATCH`) بالاتر می‌نشینند.

![چهار معادله در PowerPoint با رشد جداکننده فعال در بالا و غیرفعال در پایین، و Centered در سمت چپ و Match در سمت راست](delimiter-sizing.png)

## **اضافه کردن جعبه مرزی**

متد [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) را روی یک کسر فراخوانی کنید تا کل عبارت چارچوب شود. [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) بازگردانده‌شده به‌طور پیش‌فرض چهار طرف را نشان می‌دهد. از [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/)، [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/) و [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/) برای حذف طرف‌های جداگانه استفاده کنید.

مثال شش نسخه از همان کسر را روی یک اسلاید قرار می‌دهد. برای نشان دادن لغو، چهار طرف را مخفی کنید و [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) را برای یک قطر صعودی (↗) یا [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) برای یک قطر نزولی (↘) تنظیم کنید. می‌توانید از [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) یا [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) به همراه ترکیبی از طرف‌های قابل رؤیت نیز استفاده کنید.

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

![شش کسر قابل ویرایش در PowerPoint. ردیف بالا: حاشیه کامل، طرف‌های پایین و چپ، قطر صعودی. ردیف پایین: قطر نزولی، خط افقی، خط عمودی با حاشیه کامل.](border-box-fractions.png)

در این کسر، خط افقی بر روی میله کسر قرار می‌گیرد. خط عمودی هر دو صورت و مخرج را می‌گذرد در حالی که حاشیه اطراف همچنان قابل رؤیت است. این خطوط کل عبارت را تزئین می‌کنند. خط کشی معمولی بر روی حروف یک رشتهٔ متنی اعمال می‌شود. پس از باز کردن مجدد ارائه در PowerPoint، هنوز می‌توانید صورت و مخرج را به‌صورت جداگانه ویرایش کنید.

## **کنترل دید و چیدمان با عناصر Phantom**

عبارت را در [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) بپیچید تا دید آن و فضای که به معادله می‌سازد را به‌صورت مستقل کنترل کنید. ویژگی‌های آن موارد زیر را کنترل می‌کنند:

| ویژگی | تأثیر |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | مقدار `False` برای مخفی کردن عبارت. ابعاد آن هنوز به چیدمان کمک می‌کند مگر اینکه خصوصیات زیر `True` باشند. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | عرض افقی عبارت را به صفر در نظر بگیرد، اجازه می‌دهد عناصر همسایه به‌هم نزدیک‌تر شوند. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | صعود (ارتفاع بالای خط پایه) را به صفر در نظر بگیرد. این می‌تواند فضای بالای عناصر همسایه را کاهش دهد. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | نزول (عمق زیر خط پایه) را به صفر در نظر بگیرد. این می‌تواند میله کسر یا محتوای دیگر زیر عبارت را به‌سوی همسایگان نزدیک‌تر کند. |

خط پایه مرجع خطی است که حروف ریاضی عادی بر روی آن قرار می‌گیرند. مخفی کردن محتوا ابعاد آن را حذف نمی‌کند، و در نظر گرفتن یک بعد به عنوان صفر عبارت را حذف نمی‌کند. عبارت زیرین از طریق [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/) در دسترس است. [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) را به `True` برگردانید تا دوباره ظاهر شود؛ تنظیمات بعدی ثابت می‌مانند.

مثال زیر پنج واریانت کنار هم ایجاد می‌کند: یک کسر قابل رؤیت، یک کسر مخفی که فضا را رزرو می‌کند، و سه کسر مخفی که یکی از ابعاد آن‌ها به صفر تنظیم شده است. هر واریانت از همان عبارت اطراف و Cambria Math با اندازه ۲۴ پوینت استفاده می‌کند. تمام شکل‌های معادله موقعیت عمودی یکسانی دارند که با راهنمای خاکستری نشان داده شده است. قرار دادن Phantom در صورت یک کسر خارجی باعث می‌شود تغییرات چیدمان عمودی راحت‌تر دیده شوند.

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

![پنج معادله در PowerPoint مقایسه‌کننده یک کسر قابل رؤيت، یک کصر مخفی که فضا را رزرو می‌کند، و کسرهای مخفی با ZeroWidth، ZeroAsc یا ZeroDesc فعال](math-phantom.png)

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) برای قرار دادن یک علامت گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده یک حد اضافه کنید.

![عبارت x به‌علاوه y که با برچسب any text در زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

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

از کمک‌کنندگان قالب‌بندی فقط درجایی که فرمول را واضح‌تر می‌کند استفاده کنید. برای مثال، [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) یک خط بالای عنصر ریاضی می‌گذارد.

![یک عبارت ریاضی ABC با یک خط بالایی](powerpoint-math-equations_14.png)

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

برای قالب‌بندی متن در سراسر یک معادله موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) فقط فرزندان مستقیم را باز می‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و ساختارهای تو در تو دیگر باید به‌صورت بازگشتی فراخوانی شود. عنصر جاری و همچنین فرزندان آن را بررسی کنید تا عنصر شروع زمانی که [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) باشد نیز شامل شود.

این مثال فرض می‌کند `input.pptx` شامل معادله‌ای نظیر `z = xᵢ / ∛y` است که یک کسر با زیرنویس در صورت و یک رادیکال در مخرج دارد. پردازش فقط عناصر سطح بالایی بلوک متن را از دست می‌دهد. مثال بخش‌های ریاضی در قاب‌های متن اسلاید را پیدا می‌کند، بلوک‌های آن‌ها را از طریق [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) دسترسی می‌یابد و [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) را برای هر عنصر متنی از طریق ویژگی [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) به ۲۸ پوینت تنظیم می‌کند.

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

ارائه ذخیره‌شده متن قالب‌بندی‌شده به‌روز شده را در هر سطح از هر معادله پردازش‌شده دارد، در حالی که محتوای متنی و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| وظیفه | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| ترکیب عناصر | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| ایجاد کسرها | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| اضافه کردن بالانویس یا زیرنویس | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| اضافه کردن توابع | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| اضافه کردن رادیکال‌ها | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| اضافه کردن حدود | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| اضافه کردن اسکریپت‌های سمت چپ | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| اضافه کردن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| اضافه کردن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| اضافه کردن آرایه‌های معادله | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| اضافه کردن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| اضافه کردن خط‌ها و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **سؤالات متداول**

**آیا می‌توانم معادلهٔ PowerPoint موجود را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) است پیدا کنید، [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) آن را دریافت کنید و بلوک‌های ریاضی آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به‌عنوان ریاضی قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتوای Office math قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. معادلهٔ [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) را از [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) دریافت کنید و [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) را برای صادرات مستقیم فراخوانی کنید. برای مثال کامل، به [Export Math Equations from Presentations in Python via .NET](/slides/fa/python-net/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.