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
description: "درج و ویرایش معادلات ریاضی در فایل‌های PPT و PPTX PowerPoint با Aspose.Slides برای Python از طریق .NET، با پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های کد واضح Python."
---
## **بررسی کلی**

PowerPoint معادلات را به عنوان Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Python از طریق .NET، می‌توانید همان نوع محتویات ریاضی را به صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدها، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در پاورپوینت، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با دستور Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش بر روی اسلاید است:

![یک اسلاید PowerPoint شامل یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [add_math_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_math_shape/) ایجاد می‌شود، شکلی است که معادله را در خود دارد.
- [MathPortion](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathportion/) محتویات ریاضی را درون فریم متنی شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathematicaltext/) و متدهای زنجیره‌ای [IMathElement](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/) برای کوتاه و قابل خواندن بودن کد استفاده می‌کنند.

برای سناریوهای خروجی MathML، به [صدور معادلات ریاضی از ارائه‌ها در Python از طریق .NET](/slides/fa/python-net/exporting-math-equations/) مراجعه کنید.

## **ایجاد معادله**

این مثال یک شکل ریاضی ایجاد می‌کند و قضیه فیثاغورس را اضافه می‌کند:

![معادله c به توان دو برابر a به توان دو به علاوه b به توان دو](powerpoint-math-equations_3.png)

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

{{% alert color="primary" %}}
`add_math_shape` شکلی را ایجاد می‌کند که قبلاً شامل یک MathParagraph است. اولین `MathPortion` را دسترسی پیدا کنید، `MathParagraph` آن را بگیرید، و بلوک‌های ریاضی یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **اضافه کردن کسرها**

برای ایجاد یک کسر از [`divide`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/divide/) استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathfractiontypes/) انتخاب کنید.

![یک کسر شیب‌دار که یک تقسیم بر x را نشان می‌دهد](powerpoint-math-equations_4.png)

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

برای یک کسر لایه‌ای، از `MathFractionTypes.BAR` استفاده کنید:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **اضافه کردن رادیکال‌ها**

برای ایجاد رادیکال (جذر مربع، جذر مکعب یا سایر رادیکال‌ها) از [`radical`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/radical/) استفاده کنید. عنصر جاری به پایه تبدیل می‌شود و آرگومان به درجه رادیکال.

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

## **اضافه کردن توابع و حدها**

برای توابعی مانند `sin(x)`، `log(x)` یا نام‌های تابع سفارشی، از [`as_argument_of_function`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) یا [`function`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/function/) استفاده کنید. برای حدها، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathlimit/) قرار دهید یا از [`set_lower_limit`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) استفاده کنید.

![حد x وقتی x به سمت بی‌نهایت می‌رود](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را به عنوان عنصر جاری قرار دهید:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **اضافه کردن عملگرهای N-ary و انتگرال‌ها**

برای جمع‌ها، اتحادیه‌ها، اشتراک‌ها و سایر عملگرهای بزرگ از [`nary`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/nary/) استفاده کنید. برای انتگرال‌ها از [`integral`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/integral/) استفاده کنید. هر دو متد به شما امکان می‌دهند حد پایین و بالا را تنظیم کنید.

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

عملگرهای N-ary برای عملگرهای بزرگ با محدودیت‌های اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به عنوان `MathematicalText` اضافه شده و به عبارت ترکیب می‌شوند.

برای یک انتگرال، از `integral` استفاده کنید:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **اضافه کردن ماتریس‌ها**

برای ردیف‌ها و ستون‌ها از [MathMatrix](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathmatrix/) استفاده کنید. به طور پیش‌فرض ماتریس‌ها پرانتز ندارند، بنابراین هنگام نیاز به پرانتز، کروشه یا آکولاد، ماتریس را بغل بگیرید.

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

## **اضافه کردن آرایه‌های معادله**

وقتی به معادلات تراز شده یا یک پشته عمودی از عبارات نیاز دارید، از [`to_math_array`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/to_math_array/) استفاده کنید.

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

## **اضافه کردن توابع مثلثاتی**

وقتی آرگومان عنصر جاری است و نام تابع شناخته‌شده است، از [`as_argument_of_function`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) استفاده کنید.

![تابع مثلثاتی cos بر 2x](powerpoint-math-equations_6.png)

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

برای شاخص‌ها و توان‌ها از کمک‌کننده‌های زیرنویس و بالانویس استفاده کنید. وقتی شاخص‌ها باید در سمت چپ پایه ظاهر شوند، از [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) استفاده کنید.

![Y بزرگ با زیرنویس 1 سمت چپ و بالانویس n](powerpoint-math-equations_9.png)

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

برای قرار دادن یک عبارت داخل جداکننده‌ها از [`enclose`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/enclose/) استفاده کنید. همچنین می‌توانید یک کاراکتر جداکننده برای عبارات جداکننده‌ای که چند عنصر دارند تنظیم کنید.

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

## **اضافه کردن جعبه مرزی**

وقتی خود معادله باید در یک قاب قرار گیرد، از [`to_border_box`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/to_border_box/) استفاده کنید.

![یک معادله در جعبه که a² = b² + c² را نشان می‌دهد](powerpoint-math-equations_12.png)

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

برای قرار دادن یک کاراکتر گروه‌بندی بالا یا پایین یک عبارت از [`group`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/group/) استفاده کنید. یک حد اضافه کنید تا عبارات گروه‌بندی‌شده را برچسب بزنید.

![عبارتی x + y گروه‌بندی شده با برچسب هر متن زیر آن](powerpoint-math-equations_15.png)

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

از کمک‌کننده‌های قالب‌بندی تنها جایی استفاده کنید که فرمول را واضح‌تر می‌سازد. برای مثال، [`overbar`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/overbar/) یک خط بالای عنصر ریاضی قرار می‌دهد.

![یک عبارت ریاضی ABC با یک خط بالای آن](powerpoint-math-equations_14.png)

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

## **مرجع سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathematicaltext/) |
| ترکیب عناصر | [IMathElement.join](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/join/) |
| ایجاد کسرها | [IMathElement.divide](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/divide/) |
| اضافه کردن بالانویس یا زیرنویس | [set_superscript](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| اضافه کردن توابع | [function](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| اضافه کردن رادیکال‌ها | [radical](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/radical/) |
| اضافه کردن حدها | [set_lower_limit](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| اضافه کردن اسکریپت‌های سمت چپ | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| اضافه کردن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/integral/) |
| اضافه کردن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathmatrix/) |
| اضافه کردن آرایه‌های معادله | [to_math_array](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| اضافه کردن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| اضافه کردن خط‌ها و قاب‌ها | [overbar](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/imathelement/group/) |

## **سؤالات متداول**

**آیا می‌توانم یک معادله موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک `MathPortion` است پیدا کنید، `MathParagraph` آن را دریافت کنید و بلوک‌های ریاضی در آن پاراگراف را به‌روز کنید.

**آیا معادلات به صورت ریاضیات قابل ویرایش در PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتویات ریاضی قابل ویرایش Office می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

Aspose.Slides معادلات ریاضی را به MathML صادر می‌کند. اگر به LaTeX نیاز دارید، ابتدا به MathML صادر کنید و سپس MathML را با ابزاری که از دیالکت LaTeX هدف شما پشتیبانی می‌کند، تبدیل کنید.