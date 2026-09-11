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
description: "درج و ویرایش معادلات ریاضی در PowerPoint PPT و PPTX با Aspose.Slides برای Python از طریق Java، با پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های واضح کد Python."
---
## **مرور کلی**

PowerPoint معادلات را به صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Python از طریق Java می‌توانید همان نوع محتواهای ریاضی را برنامه‌نویسی کنید: کسرها، رادیکال‌ها، توابع، حدها، عملگرهای N‑ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش بر روی اسلاید است:

![یک اسلاید PowerPoint حاوی یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [addMathShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addMathShape) ساخته می‌شود، شکل حاوی معادله است.
- [MathPortion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathportion/) محتویات ریاضی را داخل فریم متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathblock/) است.

بخش‌های زیر عمدتاً از [MathematicalText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathematicaltext/) و متدهای fluent از [MathElementBase](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/) برای کوتاه و خوانا نگه داشتن کد استفاده می‌کنند.

برای سناریوهای خروجی MathML، به صفحه [Export Math Equations from Presentations in Python](/slides/fa/python-java/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال یک شکل ریاضی می‌سازد و قضیه فیثاغورث را اضافه می‌کند:

![معادله c² = a² + b²](powerpoint-math-equations_3.png)

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

[addMathShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addMathShape) یک شکل را می‌سازد که از پیش شامل یک MathParagraph است. اولین [MathPortion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathportion/) را دریافت کنید، [MathParagraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathparagraph/) آن را بگیرید و بلوک‌های ریاضی یا عناصر ریاضی را به آن اضافه کنید.

{{% /alert %}}

## **اضافه کردن کسرها**

از [divide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#divide) برای ساخت یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی مورب که یک تقسیم بر x را نشان می‌دهد](powerpoint-math-equations_4.png)

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

برای یک کسر پشته‌ای، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathfractiontypes/#Bar) استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **اضافه کردن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#radical) برای ساخت رادیکال درجه دوم، سوم یا رادیکال‌های دیگر استفاده کنید. عنصر فعلی به عنوان پایه، و آرگومان به عنوان درجه در نظر گرفته می‌شود.

![یک عبارت رادیکال n‑ام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

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

## **اضافه کردن توابع و حدها**

برای توابعی مانند `sin(x)`, `log(x)` یا نام‌های توابع سفارشی از [asArgumentOfFunction](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) یا [function](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#function) استفاده کنید. برای حدها، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathlimit/) قرار دهید یا از [setLowerLimit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#setLowerLimit) استفاده کنید.

![حد x وقتی x به بی‌نهایت نزدیک می‌شود](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را به عنوان عنصر فعلی تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **اضافه کردن عملگرهای N‑ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#nary) برای جمع‌ها، اجتماع‌ها، اشتراک‌ها و سایر عملگرهای بزرگ استفاده کنید. برای انتگرال‌ها از [integral](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#integral) استفاده کنید. هر دو متد به شما امکان تنظیم حدهای پایین و بالا را می‌دهند.

![یک جمع با حدهای پایین و بالا](powerpoint-math-equations_7.png)

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

عملگرهای N‑ary برای عملگرهای بزرگ با حدهای اختیاری هستند. عملگرهای ساده مانند `+`, `-`, `=` معمولاً به عنوان [MathematicalText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathematicaltext/) اضافه شده و به عبارت متصل می‌شوند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#integral) استفاده کنید:

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

از [MathMatrix](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. ماتریس‌ها به طور پیش‌فرض کروشه ندارند، بنابراین وقتی نیاز به پرانتز، براکت یا آکولاد دارید، ماتریس را داخل آن‌ها بپیچید.

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

زمانی که به معادلات هم‌تراز یا یک پشته عمودی از عبارات نیاز دارید، از [toMathArray](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#toMathArray) استفاده کنید.

![یک آرایۀ ریاضی عمودی با x بالای y](powerpoint-math-equations_11.png)

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

زمانی که آرگومان عنصر فعلی است و نام تابع شناخته شده، از [asArgumentOfFunction](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) استفاده کنید.

![تابع مثلثاتی cos بر 2x اعمال شده](powerpoint-math-equations_6.png)

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

از کمکی‌های زیرنویس و بالانویس برای ایندکس‌ها و توان‌ها استفاده کنید. وقتی ایندکس‌ها باید در سمت چپ پایه ظاهر شوند، از [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) استفاده کنید.

![یک Y بزرگ با زیرنویس سمت چپ 1 و بالانویس n](powerpoint-math-equations_9.png)

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

از [enclose](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#enclose) برای قرار دادن یک عبارت داخل جداکننده‌ها استفاده کنید. همچنین می‌توانید یک کاراکتر جداکننده برای عبارات جداکننده‌ای که شامل چند عنصر هستند تنظیم کنید.

![عبارت جداکننده‌ای شامل x، y و z که با خط‌های عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

## **اضافه کردن جعبه حاشیه‌ای**

برای این که معادله خود به‌صورت یک قاب نمایش داده شود، از [toBorderBox](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#toBorderBox) استفاده کنید.

![یک معادله درون جعبه نشان می‌دهد a² = b² + c²](powerpoint-math-equations_12.png)

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

    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    boxed_equation = MathematicalText("a").setSuperscript("2").join("=").join(b_squared).join("+").join(c_squared).toBorderBox()

    math_block = MathBlock(boxed_equation)
    math_paragraph.add(math_block)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#group) برای قرار دادن یک کاراکتر گروه‌بندی بالای یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده می‌توانید حدی اضافه کنید.

![عبارت x + y که با برچسب متنی زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

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

از کمکی‌های قالب‌بندی فقط در مواردی استفاده کنید که فرمول را واضح‌تر می‌سازند. برای مثال، [overbar](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#overbar) یک خط بالای عنصر ریاضی می‌گذارد.

![یک عبارت ریاضی ABC با یک overbar](powerpoint-math-equations_14.png)

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

## **مرجع سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathematicaltext/) |
| ترکیب عناصر | [MathElementBase.join](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#join) |
| ایجاد کسرها | [MathElementBase.divide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#divide) |
| اضافه کردن بالانویس یا زیرنویس | [setSuperscript](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#setSubscript) |
| اضافه کردن توابع | [function](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| اضافه کردن رادیکال‌ها | [MathElementBase.radical](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#radical) |
| اضافه کردن حدها | [setLowerLimit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| اضافه کردن اسکریپت‌های سمت چپ | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| اضافه کردن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#integral) |
| اضافه کردن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathmatrix/) |
| اضافه کردن آرایه‌های معادله | [toMathArray](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#toMathArray) |
| اضافه کردن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#enclose) |
| اضافه کردن نوارها و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathelementbase/#group) |

## **سوالات متداول**

**آیا می‌توانم یک معادله PowerPoint موجود را ویرایش کنم؟**

بله. ارائه را باز کنید، شکل حاوی یک [MathPortion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathportion/) را پیدا کنید، [MathParagraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathparagraph/) آن را بگیرید و بلوک‌های ریاضی در آن پاراگراف را به‌روز کنید.

**آیا معادلات به‌صورت ریاضی ویرایش‌پذیر PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به قالب PPTX، Aspose.Slides معادله را به‌عنوان محتوای ریاضی Office قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [MathParagraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathportion/) آن دریافت کنید و متد [MathParagraph.toLatex](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathparagraph/#toLatex) را فراخوانی کنید تا مستقیماً صادر شود. برای یک مثال کامل، به صفحه [Export Math Equations from Presentations in Python](/slides/fa/python-java/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.