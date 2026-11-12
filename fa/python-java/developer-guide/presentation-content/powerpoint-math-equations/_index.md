---
title: افزودن معادلات ریاضی به ارائه‌های PowerPoint در Python
linktitle: معادلات ریاضی PowerPoint
type: docs
weight: 80
url: /fa/python-java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "در PowerPoint (PPT و PPTX) معادلات ریاضی را با Aspose.Slides برای Python از طریق Java درج و ویرایش کنید؛ با پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های واضح کد Python."
---
## **نمای کلی**

PowerPoint معادلات را به صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Python از طریق Java، می‌توانید همان نوع محتوای ریاضی را به‌صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدود، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش بر روی اسلاید است:

![یک اسلاید PowerPoint شامل یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) ایجاد می‌شود، شکلی است که معادله را در خود دارد.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) محتویات ریاضی را در داخل چهارچوب متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) حاوی یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) است.

اکثراً مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) و متدهای fluent در [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) برای کوتاه و خوانا نگه داشتن کد استفاده می‌کنند.

برای صادرات MathML، به [Export Math Equations from Presentations in Python](/slides/fa/python-java/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیه فیثاغورث را اضافه می‌کند:

![معادله c مربع مساوی a مربع به علاوه b مربع](powerpoint-math-equations_3.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    equation = MathematicalText("c").setSuperscript("2").join("=").join(a_squared).join("+").join(b_squared)

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) یک شکل را ایجاد می‌کند که قبلاً شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) را دسترسی پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید و بلوک‌های ریاضی یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **اضافه کردن کسرها**

از [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) انتخاب کنید.

![یک کسر کج که یک تقسیم بر x است](powerpoint-math-equations_4.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFractionTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    fraction = MathematicalText("1").divide("x", MathFractionTypes.Skewed)

    math_block = MathBlock(fraction)
    math_paragraph.add(math_block)

    presentation.save("fraction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای یک کسر عمودی، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar) استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **اضافه کردن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) برای ایجاد ریشه دوم، ریشه سوم یا سایر ریشه‌ها استفاده کنید. عنصر جاری به پایه تبدیل می‌شود و آرگومان به درجه ریشه.

![یک عبارت رادیکال nام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    radical = MathematicalText("x").radical("n")

    math_block = MathBlock(radical)
    math_paragraph.add(math_block)

    presentation.save("radical.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اضافه کردن توابع و حدود**

از [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) یا [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) برای توابعی مانند `sin(x)`، `log(x)` یا نام‌های تابع سفارشی استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) قرار دهید یا از [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit) استفاده کنید.

![حد x به‌هنگامیکه x به بی‌نهایت میل می‌کند](powerpoint-math-equations_8.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    limit = MathematicalText("lim").setLowerLimit("x\u2192\u221E").function("x")

    math_block = MathBlock(limit)
    math_paragraph.add(math_block)

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای نام تابع سفارشی، نام تابع را به‌عنوان عنصر جاری قرار دهید و با آرگومان آن، [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) را فراخوانی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **اضافه کردن عملگرهای N-ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) برای جمع‌ها، اجتماع‌ها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. از [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) برای انتگرال‌ها استفاده کنید. هر دو متد به شما امکان تنظیم حدود پایین و بالا را می‌دهند.

![یک جمع با حدود پایین و بالا](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathNaryOperatorTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_power = MathematicalText("a").setSuperscript("n-k")
    summation_base = MathematicalText("x").setSuperscript("k").join(a_power)

    summation = summation_base.nary(MathNaryOperatorTypes.Summation, "k=0", "n")

    math_block = MathBlock(summation)
    math_paragraph.add(math_block)

    presentation.save("nary-operators.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

عملگرهای N-ary برای عملگرهای بزرگ با حدود اختیاری هستند. عملگرهای ساده مثل `+`، `-` و `=` معمولاً به‌عنوان [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) اضافه شده و به عبارت متصل می‌شوند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **اضافه کردن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به‌طور پیش‌فرض ماتریس‌ها پرانتز ندارند، بنابراین هنگام نیاز به پرانتز، کروشه یا آکولاد، ماتریس را محصور کنید.

![یک ماتریس ریاضی دو ردیفی با یک سلول خالی](powerpoint-math-equations_10.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathMatrix, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    matrix = MathMatrix(2, 3)
    cell_0_0 = MathematicalText("1")
    matrix.set_Item(0, 0, cell_0_0)
    cell_0_1 = MathematicalText("x")
    matrix.set_Item(0, 1, cell_0_1)
    cell_1_0 = MathematicalText("x")
    matrix.set_Item(1, 0, cell_1_0)
    cell_1_1 = MathematicalText("2")
    matrix.set_Item(1, 1, cell_1_1)
    cell_1_2 = MathematicalText("y")
    matrix.set_Item(1, 2, cell_1_2)

    math_block = MathBlock(matrix)
    math_paragraph.add(math_block)

    presentation.save("matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اضافه کردن آرایه‌های معادله**

از [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) وقتی به معادلات تراز شده یا یک پشته عمودی از عبارات نیاز دارید استفاده کنید.

![یک آرایه عمودی ریاضی با x بالای y](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 140)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    equation_array = MathematicalText("x").join("y").toMathArray()

    math_block = MathBlock(equation_array)
    math_paragraph.add(math_block)

    presentation.save("equation-array.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اضافه کردن توابع مثلثاتی**

از [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) وقتی آرگومان عنصر جاری است و نام تابع معلوم است استفاده کنید.

![تابع مثلثاتی cos اعمال‌شده بر 2x](powerpoint-math-equations_6.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFunctionsOfOneArgument, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    cosine = MathematicalText("2x").asArgumentOfFunction(MathFunctionsOfOneArgument.Cos)

    math_block = MathBlock(cosine)
    math_paragraph.add(math_block)

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اضافه کردن زیرنویس و بالانویس**

از ابزارهای زیرنویس و بالانویس برای شاخص‌ها و توان‌ها استفاده کنید. وقتی شاخص‌ها باید در سمت چپ پایه ظاهر شوند، از [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) استفاده کنید.

![یک حرف Y بزرگ با زیرنویس 1 در سمت چپ و بالانویس n](powerpoint-math-equations_9.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    scripts = MathematicalText("Y").setSubSuperscriptOnTheLeft("1", "n")

    math_block = MathBlock(scripts)
    math_paragraph.add(math_block)

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اضافه کردن جداکننده‌ها**

از [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) برای قرار دادن یک عبارت داخل جداکننده‌ها استفاده کنید. همچنین می‌توانید یک کاراکتر جداکننده برای عبارات جداکننده که شامل چند عنصر هستند تنظیم کنید.

![عبارت جداکننده شامل x، y و z جدا شده با خطوط عمودی](powerpoint-math-equations_13.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    delimiter = MathematicalText("x").join("y").join("z").enclose('<', '>')
    delimiter.setSeparatorCharacter('|')

    math_block = MathBlock(delimiter)
    math_paragraph.add(math_block)

    presentation.save("delimiters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **اندازه و ترازبندی جداکننده‌ها**

با ارسال `True` به [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) اجازه دهید پرانتزها حول یک عملوند بلند بزرگ شوند، یا با ارسال `False` آن‌ها را به اندازه عادی نگه دارید. از [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) همراه با یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) استفاده کنید. `Centered` پرانتزها را در محور ریاضی (که از وسط علامت مساوی می‌گذرد) مرکزی می‌کند. `Match` آن‌ها را با محتوای داخل هم‌ترازبندی می‌کند. هر دو تنظیم فقط بر روی جداکننده‌ها اثر می‌گذارند. عبارت داخل همان‌طور باقی می‌ماند.

در این مثال یک کسر در توان `x` قرار داده می‌شود به‌طوری که عبارت بالاتر از خط پایه بیشتر از زیر آن گسترش یابد. تمام چهار معادله از یک نوع پرانتز و تنظیمات قلم استفاده می‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathDelimiterShape, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    for row, grow in enumerate((True, False)):
        for column, shape in enumerate((MathDelimiterShape.Centered, MathDelimiterShape.Match)):
            fraction = MathematicalText("a + b").divide("c + d")
            power = MathematicalText("x").setSuperscript(fraction)
            delimiter = power.enclose("(", ")")
            delimiter.setGrowToMatchOperandHeight(grow)
            delimiter.setDelimiterShape(shape)

            math_shape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100)
            portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            portion.getPortionFormat().setFontHeight(32)
            equation = MathematicalText("y = ").join(delimiter)
            portion.getMathParagraph().add(equation)

    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

در PowerPoint، سطرها را مقایسه کنید تا اثر رشد را ببینید. در سطر بالا، پرانتزها برای محصور کردن توان رشد می‌کنند و برای هر دو شکل یکسان به‌نظر می‌رسند. در سطر پایین، رشد خاموش است. پرانتزهای کوچکتر در سمت چپ (`Centered`) با علامت مساوی ترازبندی می‌شوند، در حالی که آن‌های سمت راست (`Match`) بالاتر از عبارت قرار می‌گیرند.

![چهار معادله در PowerPoint با رشد جداکننده فعال در بالا و غیرفعال در پایین، و Centered در چپ و Match در راست](delimiter-sizing.png)

## **اضافه کردن جعبه حاشیه‌دار**

روی یک کسر [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) را صدا بزنید تا کل عبارت را در یک قاب بپیچید. [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) برگردانده شده به‌طور پیش‌فرض چهار طرف را نشان می‌دهد. از [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop)، [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom)، [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) و [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) برای حذف طرف‌های جداگانه استفاده کنید.

در این مثال شش کپی از همان کسر بر روی یک اسلاید قرار داده می‌شود. برای نشان دادن حذف، تمام چهار طرف را مخفی کنید و `True` را به [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) برای قطر صعودی (↗) یا به [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) برای قطر نزولی (↘) پاس بدهید. همچنین می‌توانید از [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) یا [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) با ترکیب دلخواهی از طرف‌های قابل مشاهده استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    def add_fraction(x, y, hide_border):
        fraction = MathematicalText("x+1").divide("y+2")
        box = fraction.toBorderBox()
        box.setHideTop(hide_border)
        box.setHideBottom(hide_border)
        box.setHideLeft(hide_border)
        box.setHideRight(hide_border)

        shape = slide.getShapes().addMathShape(x, y, 160, 90)
        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(28)
        math_block = MathBlock(box)
        portion.getMathParagraph().add(math_block)
        return box

    add_fraction(10, 10, False)

    partial = add_fraction(190, 10, False)
    partial.setHideTop(True)
    partial.setHideRight(True)

    add_fraction(370, 10, True).setStrikethroughBottomLeftToTopRight(True)
    add_fraction(10, 120, True).setStrikethroughTopLeftToBottomRight(True)
    add_fraction(190, 120, True).setStrikethroughHorizontal(True)
    add_fraction(370, 120, False).setStrikethroughVertical(True)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![شش کسر قابل ویرایش در PowerPoint. سطر بالا: حاشیه کامل، طرف‌های پایین و چپ، قطر صعودی. سطر پایین: قطر نزولی، خط افقی، خط عمودی با حاشیه کامل](border-box-fractions.png)

در این کسر، خط افقی بر روی خط کسر می‌پوشد. خط عمودی هر دو صورت و مخرج را عبور می‌دهد در حالی که حاشیه اطراف قابل مشاهده باقی می‌ماند. این خطوط کل عبارت را تزئین می‌کنند. خط‌خوردهٔ متن عادی تنها برای کاراکترهای یک اجرای متنی اعمال می‌شود. پس از باز شدن دوباره ارائه در PowerPoint، همچنان می‌توانید صورت و مخرج را به‌صورت جداگانه ویرایش کنید.

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) برای قرار دادن یک کاراکتر گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی شده یک حد اضافه کنید.

![عبارت x به‌علاوه y گروه‌بندی‌شده با برچسب متن دلخواه زیر آن](powerpoint-math-equations_15.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathTopBotPositions, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    grouped = MathematicalText("x + y").group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top).setLowerLimit("any text")

    math_block = MathBlock(grouped)
    math_paragraph.add(math_block)

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **قالب‌بندی عناصر ریاضی**

از ابزارهای قالب‌بندی تنها در جایی که فرمول را واضح می‌کنند استفاده کنید. برای مثال، [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) یک خط بالای عنصر ریاضی قرار می‌دهد.

![یک عبارت ریاضی ABC با خط بالای آن](powerpoint-math-equations_14.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    overbar = MathematicalText("ABC").overbar()

    math_block = MathBlock(overbar)
    math_paragraph.add(math_block)

    presentation.save("overbar.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **قالب‌بندی متن در یک معادله موجود**

برای قالب‌بندی متن در تمام یک معادله موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) فقط فرزندان مستقیم را برمی‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و سایر ساختارهای تو در تو، به‌صورت بازگشتی فراخوانی کنید. عنصر جاری و فرزندان آن را بررسی کنید تا عنصر شروع شامل شود وقتی که [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) است.

این مثال فرض می‌کند که `input.pptx` شامل معادله‌ای مانند `z = xᵢ / ∛y` است، که شامل کسر با زیرنویس در صورت و رادیکال در مخرج می‌باشد. پردازش تنها عناصر سطح‌بالای بلوک متن داخل کسر را از دست می‌دهد. این مثال بخش‌های ریاضی را در چهارچوب‌های متن اسلاید پیدا می‌کند، بلوک‌هایشان را از طریق [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) دسترسی می‌دهد و با استفاده از [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) اندازه قلم را به ۲۸ پوینت برای هر عنصر متنی از طریق متد [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) تنظیم می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathematicalText, MathPortion, Presentation, SaveFormat


def format_math_text(element):
    if isinstance(element, MathematicalText):
        element.getFormat().setFontHeight(28)

    for child in element.getChildren():
        format_math_text(child)


presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    if isinstance(portion, MathPortion):
                        for block in portion.getMathParagraph():
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ارائهٔ ذخیره‌شده شامل قالب‌بندی متنی به‌روز شده در هر سطح از هر معادلهٔ پردازش‌شده است، در حالی که محتویات متن و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| ترکیب عناصر | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| ایجاد کسرها | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| اضافه کردن بالانویس یا زیرنویس | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| اضافه کردن توابع | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| اضافه کردن رادیکال‌ها | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| اضافه کردن حدود | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| اضافه کردن اسکریپت‌های سمت چپ | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| اضافه کردن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| اضافه کردن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| اضافه کردن آرایه‌های معادله | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| اضافه کردن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| اضافه کردن خط‌افقی و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **پرسش‌های متداول**

**آیا می‌توانم یک معادله PowerPoint موجود را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) است پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید و بلوک‌های ریاضی آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به‌عنوان ریاضیات قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتوای ریاضی قابل ویرایش Office می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) دریافت کنید و با فراخوانی [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) آن را مستقیماً صادر کنید. برای یک مثال کامل، به [Export Math Equations from Presentations in Python](/slides/fa/python-java/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.