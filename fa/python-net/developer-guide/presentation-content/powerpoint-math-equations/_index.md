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
description: "درج و ویرایش معادلات ریاضی در PowerPoint PPT و PPTX با Aspose.Slides برای Python از طریق .NET، پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های کد واضح Python."
---
## **نمایش کلی**

PowerPoint معادلات را به‌صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Python از طریق .NET، می‌توانید همان نوع محتویات ریاضی را به‌صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدها، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint که فرمان Equation انتخاب شده است](powerpoint-math-equations_1.png)

نتیجه متنی قابل ویرایش ریاضی بر روی اسلاید است:

![یک اسلاید PowerPoint حاوی یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) ایجاد می‌شود، شکلی است که معادله را در خود دارد.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) محتویات ریاضی را داخل قاب متنی شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) و متدهای زنجیره‌ای [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) استفاده می‌کنند تا کد کوتاه و خوانا بماند.

برای سناریوهای خروجی MathML، به [صادرات معادلات ریاضی از ارائه‌ها در Python از طریق .NET](/slides/fa/python-net/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) برای ایجاد یک شکل ریاضی استفاده می‌کند و نظریهٔ فیثاغورث را اضافه می‌کند:

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) شکلی را ایجاد می‌کند که از پیش شامل یک پاراگراف ریاضی است. به اولین [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) دسترسی پیدا کنید، [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) آن را دریافت کنید و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **افزودن کسرها**

از [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی کج که یک بر x تقسیم شده است](powerpoint-math-equations_4.png)

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

## **افزودن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) برای ایجاد ریشهٔ مربع، ریشهٔ مکعب یا ریشه‌های دیگر استفاده کنید. عنصر جاری به‌عنوان پایه می‌شود و آرگومان به‌عنوان درجه.

![یک عبارت رادیکال nام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

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

## **افزودن توابع و حدود**

از [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) یا [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) برای توابعی مانند `sin(x)`، `log(x)` یا نام‌های سفارشی توابع استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) قرار دهید یا از [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) استفاده کنید.

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

برای نام تابع سفارشی، نام تابع را به‌عنوان عنصر جاری قرار داده و [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) را با آرگومان آن فراخوانی کنید:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **افزودن عملگرهای N-ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) برای جمع‌ها، اتحادها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. از [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) برای انتگرال‌ها استفاده کنید. هر دو متد به شما امکان تنظیم حد پایین و بالا را می‌دهند.

![یک جمع با حد پایین و بالا](powerpoint-math-equations_7.png)

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

عملگرهای N-ary برای عملگرهای بزرگ با حدهای اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به‌صورت [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) افزوده شده و به عبارت متصل می‌شوند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) استفاده کنید:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **افزودن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. ماتریس‌ها به‌صورت پیش‌فرض پرانتز ندارند، بنابراین وقتی به‌پرنیتز، کروشه یا آکولاد نیاز دارید، ماتریس را محصور کنید.

![یک ماتریس ریاضی دو ردیفه با یک سلول خالی](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # ماتریس براکت‌های خود را ندارد، بنابراین آن را در پرانتز بپیچید.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` شبکه ردیف و ستون را می‌سازد، فاصله‌ها را تنظیم می‌کند و ستون‌ها را تراز می‌کند، اما Aspose.Slides برای Python از طریق .NET دسترسی به سلول فردی ماتریس را در اختیار نمی‌گذارد. بنابراین یک ماتریس ایجاد شده در کد سلول‌های خالی را حفظ می‌کند؛ سلول‌های ماتریس استخراج شده از یک ارائه موجود می‌توانند با `get_children` خوانده شوند. وقتی نیاز به پر کردن ردیف‌ها از کد دارید، از آرایهٔ معادله استفاده کنید.
{{% /alert %}}

## **افزودن آرایه‌های معادله**

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

## **افزودن توابع مثلثاتی**

از [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) وقتی آرگومان عنصر جاری است و نام تابع شناخته شده می‌باشد استفاده کنید.

![تابع مثلثاتی cos اعمال شده بر 2x](powerpoint-math-equations_6.png)

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

## **افزودن زیرنویس و بالا نویس**

از ابزارهای زیرنویس و بالا نویس برای اندیس‌ها و توان‌ها استفاده کنید. وقتی اندیس‌ها باید در سمت چپ پایه ظاهر شوند، از [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) استفاده کنید.

![یک حرف بزرگ Y با زیرنویس 1 در سمت چپ و بالا نویس n](powerpoint-math-equations_9.png)

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

## **افزودن جداکننده‌ها**

از [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) برای قرار دادن یک عبارت داخل جداکننده‌ها استفاده کنید. همچنین می‌توانید یک کاراکتر جداکننده برای عبارات جداکننده که شامل چند عنصر هستند تنظیم کنید.

![یک عبارت جداکننده شامل x، y و z که با خط‌های عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

با تنظیم [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) به `True` اجازه دهید پرانتزها اطراف یک عملوند بلند بسط یابند، یا به `False` تنظیم کنید تا اندازهٔ عادی خود را حفظ کنند. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) را می‌گیرد. `CENTERED` پرانتزها را بر محور ریاضی که از وسط علامت مساوی عبور می‌کند، مرکز می‌کند. `MATCH` آن‌ها را با محتوای محصور هم‌تراز می‌کند. هر دو تنظیم فقط بر جداکننده‌ها تأثیر می‌گذارند. عبارت داخل همانند قبل می‌ماند.

این مثال یک کسر را به‌عنوان توان `x` قرار می‌دهد تا عبارت بالاتر از خط پایه بیشتر گسترش یابد تا زیر آن. هر چهار معادله از یک مجموعهٔ پرانتز و تنظیمات قلم یکسان استفاده می‌کنند.

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

در PowerPoint، ردیف‌ها را مقایسه کنید تا اثر رشد را ببینید. در ردیف بالایی، پرانتزها برای محصور کردن توان رشد می‌کنند و برای هر دو شکل یکسان به نظر می‌رسند. در ردیف پایینی، رشد غیرفعال است. پرانتزهای کوچکتر در سمت چپ (`CENTERED`) با علامت مساوی هم‌تراز می‌شوند، در حالی که آن‌ها در سمت راست (`MATCH`) بالاتر از عبارت قرار می‌گیرند.

![چهار معادله در PowerPoint با فعال بودن رشد جداکننده در بالا و غیرفعالی در پایین، و `CENTERED` در سمت چپ و `MATCH` در سمت راست](delimiter-sizing.png)

## **افزودن جعبهٔ حاشیه‌دار**

از [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) زمانی که خود معادله باید در یک قاب قرار گیرد استفاده کنید.

![یک معادله درون جعبه که a² برابر b² به‌اضافه c² است](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) برای قرار دادن یک کاراکتر گروه‌بندی بالا یا زیر یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده یک حد اضافه کنید.

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

از ابزارهای قالب‌بندی فقط در مواردی که فرمول را واضح‌تر کنند استفاده کنید. برای مثال، [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) یک خط بالای یک عنصر ریاضی می‌گذارد.

![یک عبارت ریاضی ABC با یک خط بالا](powerpoint-math-equations_14.png)

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

برای قالب‌بندی متن در سراسر یک معادله موجود، درخت عناصر هر بلوک ریاضی را پیمایش کنید. [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) فقط فرزندان مستقیم را برمی‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و سایر ساختارهای تو در تو، به صورت بازگشتی فراخوانی کنید. عنصر جاری و فرزندان آن را بررسی کنید تا عنصر شروع نیز زمانی که یک [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) است، گنجانده شود.

این مثال فرض می‌کند که `input.pptx` شامل معادله‌ای مانند `z = xᵢ / ∛y` است، به‌طوری‌که یک کسر با زیرنویس در صورت و رادیکال در مخرج دارد. پردازش فقط عناصر سطح‑بالای بلوک متن داخل کسر را از دست می‌دهد. این مثال بخش‌های ریاضی را در قاب‌های متنی اسلاید پیدا می‌کند، بلوک‌های آن‌ها را از طریق [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) دسترسی می‌یابد، و [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) را به ۲۸ پوینت برای هر عنصر متنی از طریق ویژگی [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) تنظیم می‌کند.

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

ارائهٔ ذخیره‌شده شامل قالب‌بندی به‌روز شدهٔ متن در هر سطح از هر معادله پردازش‌شده است، در حالی که محتوای متن و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| ترکیب عناصر | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| ایجاد کسرها | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| اضافه کردن بالا نویس یا زیرنویس | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| اضافه کردن توابع | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| اضافه کردن رادیکال‌ها | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| اضافه کردن حدود | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| اضافه کردن اسکریپت‌های سمت چپ | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| اضافه کردن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| اضافه کردن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| اضافه کردن آرایه‌های معادله | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| اضافه کردن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| اضافه کردن نوارها و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **سوالات متداول**

**آیا می‌توانم یک معادله موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) است پیدا کنید، [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) آن را دریافت کنید و بلوک‌های ریاضی در آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به‌صورت ریاضی قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌صورت محتوای ریاضی قابل ویرایش Office می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) دریافت کنید و [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) را برای خروجی مستقیم فراخوانی کنید. برای یک مثال کامل، به [صادرات معادلات ریاضی از ارائه‌ها در Python از طریق .NET](/slides/fa/python-net/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.