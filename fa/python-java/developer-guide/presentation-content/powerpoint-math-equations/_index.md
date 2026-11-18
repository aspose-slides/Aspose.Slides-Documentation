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
description: "درج و ویرایش معادلات ریاضی در فایل‌های PowerPoint PPT و PPTX با Aspose.Slides برای Python از طریق Java، با پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های کد واضح Python."
---
## **نمای کلی**

PowerPoint معادلات را به عنوان Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Python از طریق Java، می‌توانید همان نوع محتوای ریاضی را به صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدود، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **درج > معادله** اضافه می‌کنند:

![زبانه درج PowerPoint با فرمان معادله انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش در اسلاید است:

![یک اسلاید PowerPoint شامل یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) ایجاد می‌شود، شکلی است که معادله را در بر می‌گیرد.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) محتویات ریاضی را داخل فریم متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) و متدهای زنجیره‌ای [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) برای کوتاه و خوانا نگه داشتن کد استفاده می‌کنند.

برای موارد صادرات MathML، به [صادرات معادلات ریاضی از ارائه‌ها در Python](/slides/fa/python-java/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیه فیثاغورس را اضافه می‌کند:

![معادله c به توان۲ برابر a به توان۲ بعلاوه b به توان۲](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) شکلی ایجاد می‌کند که قبلاً شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) را دسترسی پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید، و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **افزودن کسرها**

از [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی کج که یک تقسیم بر x را نشان می‌دهد](powerpoint-math-equations_4.png)

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

برای یک کسر طبقه‌بندی‌شده، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar) استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **افزودن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) برای ایجاد ریشهٔ دوم، ریشهٔ سوم یا ریشهٔ دیگری استفاده کنید. عنصری که در حال حاضر است به عنوان پایه می‌شود و آرگومان به عنوان درجه.

![یک عبارت رادیکال n-ام که x زیر علامت رادیکال قرار دارد](powerpoint-math-equations_5.png)

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

### **نمایش یا مخفی کردن درجهٔ ریشهٔ دوم**

یک ریشهٔ دوم می‌تواند عدد ۲ صریح را نمایش دهد یا از نماد معمولی √x استفاده کند. متد [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) از [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) تعیین می‌کند کدام فرم ظاهر شود. هر دو فرم درجهٔ ۲ و radicand x را در معادلهٔ قابل‌ویرایش نگه می‌دارند.

![یک ریشهٔ دوم همانند که درجه در سمت چپ قابل‌مشاهده و در سمت راست مخفی است](square-root-degree.png)

این مثال ریشهٔ دوم را دو بار ذخیره می‌کند. در `visible-degree.pptx`، عدد ۲ قابل‌مشاهده است. در `hidden-degree.pptx`، مخفی است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    radical = MathematicalText("x").radical("2")
    math_block = MathBlock(radical)

    math_shape = slide.getShapes().addMathShape(20, 20, 200, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()
    math_paragraph.add(math_block)

    radical.setHideDegree(False)
    presentation.save("visible-degree.pptx", SaveFormat.Pptx)

    radical.setHideDegree(True)
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **افزودن توابع و حدود**

از [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) یا [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) برای توابعی مانند `sin(x)`، `log(x)` یا نام‌های تابع سفارشی استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) قرار دهید یا از [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit) استفاده کنید.

![حد x هنگامی که x به بی‌نهایت نزدیک می‌شود](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را به عنوان عنصر فعلی قرار دهید و [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) را با آرگومان آن فراخوانی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **افزودن عملگرهای N-ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) برای جمع‌ها، اتحادیه‌ها، تقاطع‌ها و دیگر عملگرهای بزرگ استفاده کنید. از [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) برای انتگرال‌ها استفاده کنید. هر دو متد به شما امکان می‌دهند حدود پایین و بالا را تنظیم کنید.

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

عملگرهای N-ary برای عملگرهای بزرگ با حدود اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به عنوان [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) اضافه می‌شوند و به عبارت متصل می‌گردند.

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

## **افزودن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به‌طور پیش‌فرض ماتریس‌ها پرانتز ندارند، بنابراین هنگام نیاز به پرانتز، کروشه یا آکولاد، ماتریس را درون آنها بگذارید.

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

### **ویرایش یک ماتریس موجود**

فرض کنید یک درس جبر خطی با ماتریس ضرایب در `matrix.pptx` که توسط مثال قبلی ذخیره شده، شروع می‌شود. برای تمرین بعدی، معادلهٔ اول را نگه دارید، معادلهٔ دوم را با دو معادلهٔ جدید جایگزین کنید و مجموعهٔ متغیرها را بازنگری کنید. با استفاده از [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) ماتریس موجود را باز کنید تا ضرایبی که هنوز معتبر هستند حفظ شوند.

![ماتریس ضرایب دو ردیفی اصلی با ورودی‌های 1، x و یک سلول خالی در ردیف اول و x، 2، و y در ردیف دوم](matrix-before-edit.png)

اندیس‌های ردیف و ستون از صفر شروع می‌شوند و به ماتریس در هر فراخوانی اشاره دارند. درج یک ردیف پیش از اندیس 1، ردیف دوم اصلی را به اندیس 2 منتقل می‌کند. درج پس از اندیس 2 سپس یک ردیف جدید اضافه می‌کند. حذف ردیف 2 معادلهٔ دوم اصلی را حذف می‌کند و ردیف اضافه‌شده را یک موقعیت به بالا می‌برد. ستون‌ها به همان شکل جابجا می‌شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathHorizontalAlignment, MathematicalText, Presentation, SaveFormat

presentation = Presentation("matrix.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    matrix = portion.getMathParagraph().get_Item(0).get_Item(0)

    matrix.insertRowBefore(1)
    matrix.insertRowAfter(2)
    matrix.deleteRow(2)

    matrix.insertColumnBefore(1)
    matrix.insertColumnAfter(3)
    matrix.deleteColumn(3)

    # سلول‌های جدید ابتدا خالی هستند. ابتدا ضرایب غیر صفر را تنظیم کنید.
    matrix.set_Item(1, 0, MathematicalText("12"))
    matrix.set_Item(1, 1, MathematicalText("1"))
    matrix.set_Item(2, 2, MathematicalText("10"))
    matrix.set_Item(2, 3, MathematicalText("1"))
    for row in range(matrix.getRowCount()):
        for column in range(matrix.getColumnCount()):
            if matrix.get_Item(row, column) is None:
                matrix.set_Item(row, column, MathematicalText("0"))

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left)
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right)
    
    presentation.save("updated-matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) ستون اول را به چپ تراز می‌کند. [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) سه ستون باقی‌مانده را به راست تراز می‌کند، شروع از اندیس 1. در `updated-matrix.pptx`، ماتریس شامل سه معادله و چهار متغیر است. ضرایب ردیف اول اصلی `1` و `x` اکنون در ستون‌های اول و سوم ظاهر می‌شوند.

![ماتریس سه‌ردیفی به‌روز شده که ردیف‌های 1، 0، x، 0؛ 12، 1، 0، 0؛ و 0، 0، 10، 1 را نشان می‌دهد](matrix-after-edit.png)

## **افزودن آرایه‌های معادله**

از [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) زمانی که به معادلات تراز شده یا یک پشتهٔ عمودی از عبارات نیاز دارید، استفاده کنید.

![یک آرایه ریاضی عمودی با x بالای y](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

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

### **تراز یک آرایه با عناصر اطراف**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) تراز عمودی یک آرایه نسبت به عناصر ریاضی کنار آن را کنترل می‌کند. مثال زیر تراز را با ردیف اول، مرکز آرایه و ردیف آخر مقایسه می‌کند.

مثال زیر سه آرایهٔ یکسان ایجاد می‌کند، هر کدام با سه ردیف و عناصر همسایه `A=` و `=B`. تمام متن ریاضی از Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند. تنها تراز آرایه تغییر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

مقایسهٔ زیر ارائهٔ ذخیره‌شده در PowerPoint را نشان می‌دهد. موقعیت `A=` و `=B` در کنار هر آرایه را مشاهده کنید.

![آرایه‌های معادله در PowerPoint با تراز بالا، وسط و پایین و عناصر همسایهٔ یکسان](equation-array-alignment.png)

### **پیکربندی فاصلهٔ ردیف‌ها**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) قانون فاصلهٔ ردیف‌ها درون آرایه را انتخاب می‌کند. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) مقدار عددی برای یک قانون فاصلهٔ صریح فراهم می‌کند و توسط قوانین پیش‌فرض نادیده گرفته می‌شود.

برای فاصلهٔ دقیق، مقدار بر حسب پوینت اندازه‌گیری می‌شود. برای فاصلهٔ نسبی، بر حسب نیم‌خط اندازه‌گیری می‌شود: مقدار `3` در مثال معادل ۱٫۵ خط است. هنگام تعیین مقدار صریح هر دو خصوصیت را تنظیم کنید؛ تغییر تنها مقدار عددی، قانون فاصله را انتخاب نمی‌کند.

برای فاصلهٔ دقیق، مقدار بر حسب پوینت اندازه‌گیری می‌شود. برای فاصلهٔ نسبی، بر حسب نیم‌خط اندازه‌گیری می‌شود: مقدار `3` در مثال معادل ۱٫۵ خط است. هنگام تعیین مقدار صریح هر دو خصوصیت را تنظیم کنید؛ تغییر تنها مقدار عددی، قانون فاصله را انتخاب نمی‌کند.

مثال زیر پنج ارائه را با معادلات، تراز و تنظیمات قلم یکسان ذخیره می‌کند. سه نمونهٔ اول از پیش‌تنظیمات استفاده می‌کنند؛ دو نمونهٔ آخر مقادیر صریح را نشان می‌دهند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

فاصلهٔ ردیف‌های آرایه جدا از فاصلهٔ پاراگراف است. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) و [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) فضای اطراف پاراگراف حاوی را اضافه می‌کنند، نه بین ردیف‌های آرایه. به همین ترتیب، [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) پاراگراف ریاضی را به صورت افقی موقعیت می‌دهد؛ این تنظیم جایگزین تنظیم تراز عمودی آرایه نمی‌شود.

## **افزودن توابع مثلثاتی**

از [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) زمانی که آرگومان عنصر فعلی است و نام تابع شناخته شده است، استفاده کنید.

![تابع مثلثاتی cos بر روی 2x اعمال شده](powerpoint-math-equations_6.png)

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

## **افزودن زیرنویس و بالانویس**

از کمکی‌های زیرنویس و بالانویس برای نمایه‌ها و توان‌ها استفاده کنید. وقتی نمایه‌ها باید در سمت چپ پایه ظاهر شوند، از [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) استفاده کنید.

![یک Y بزرگ با زیرنویس 1 در سمت چپ و بالانویس n](powerpoint-math-equations_9.png)

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

## **افزودن جداسازها**

از [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) برای قرار دادن یک عبارت داخل جداسازها استفاده کنید. می‌توانید برای عبارات جداساز که شامل چندین عنصر هستند، یک کاراکتر جداکننده تنظیم کنید.

![یک عبارت جداساز شامل x، y و z که با خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

### **اندازه و تراز جداسازها**

`True` را به [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) پاس دهید تا پرانتزها اطراف یک عملوند بلند بزرگ شوند، یا `False` را پاس دهید تا اندازهٔ معمولی خود را حفظ کنند. از [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) با یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) استفاده کنید. `Centered` پرانتزها را در محور ریاضی که از وسط علامت مساوی می‌گذرد، مرکز می‌کند. `Match` آنها را با محتوای درون‑enclosed تراز می‌کند. هر دو تنظیم فقط بر جداسازها تأثیر می‌گذارد. عبارت داخلی همانند قبلی باقی می‌ماند.

این مثال کسر را در نمای `x` قرار می‌دهد تا عبارت بالای خط پایه بیشتر از زیر آن گسترش یابد. همهٔ چهار معادله از همان پرانتزها و تنظیمات قلم استفاده می‌کنند.

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

در PowerPoint، ردیف‌ها را مقایسه کنید تا اثر رشد را ببینید. در ردیف بالایی، پرانتزها برای بستن نمای بزرگ می‌شوند و برای هر دو شکل یک‌سان به نظر می‌رسند. در ردیف پایین، رشد غیرفعال است. پرانتزهای کوچکتر در سمت چپ (`Centered`) با علامت مساوی تراز می‌شوند، در حالی که در سمت راست (`Match`) بالاتر در اطراف عبارت قرار دارند.

![چهار معادله در PowerPoint با فعال بودن رشد جداساز در بالا و غیرفعال در پایین، و `Centered` در چپ و `Match` در راست](delimiter-sizing.png)

## **افزودن جعبه حاشیه‌دار**

بر یک کسر [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) را فراخوانی کنید تا کل عبارت را در یک جعبه قاب بندی کنید. [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) بازگشت‌پذیر به طور پیش‌فرض چهار طرف را نشان می‌دهد. از [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop)، [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom)، [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) و [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) برای حذف طرف‌های جداگانه استفاده کنید.

این مثال شش نسخه از همان کسر را روی یک اسلاید قرار می‌دهد. برای نشان دادن لغو، تمام چهار طرف را مخفی کنید و `True` را به [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) برای یک قطر صعودی (↗) یا به [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) برای یک قطر نزولی (↘) پاس دهید. می‌توانید از [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) یا [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) همراه با هر ترکیبی از طرف‌های قابل مشاهده استفاده کنید.

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

![شش کسر قابل ویرایش در PowerPoint. ردیف بالا: قاب کامل، طرف‌های پایین و چپ، قطر صعودی. ردیف پایین: قطر نزولی، خط افقی، خط عمودی با قاب کامل](border-box-fractions.png)

در این کسر، خط افقی بر روی خط کسر همپوشانی دارد. خط عمودی هم صورت و هم مخرج را می‌پوشاند در حالی که حاشیهٔ اطراف قابل مشاهده می‌ماند. این خطوط کل عبارت را تزئین می‌کنند. خط‌کش معمولی روی متن بر روی کاراکترهای یک بخش متنی اعمال می‌شود. پس از باز کردن دوباره ارائه در PowerPoint، می‌توانید همچنان صورت و مخرج را به طور مستقل ویرایش کنید.

## **کنترل نمایش و طرح‌بندی با عناصر فانتوم**

یک عبارت را در [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) بپیچید تا نمایش و فضای آن را که به یک معادله اضافه می‌کند به‌صورت مستقل کنترل کنید. متدهای [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) موارد زیر را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | با پاس کردن `False` عبارت را مخفی کنید. ابعاد آن هنوز به طرح‌بندی کمک می‌کند مگر اینکه متدهای زیر با `True` مقداردهی شوند. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | عرض افقی عبارت را صفر در نظر بگیرید تا عناصر همسایه بتوانند به یکدیگر نزدیک‌تر شوند. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | ارتفاع بالای خط پایه (ascender) را صفر در نظر بگیرید. این می‌تواند فضای محفوظ بالای عناصر همسایه را کاهش دهد. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | عمق زیر خط پایه (descender) را صفر در نظر بگیرید. این می‌تواند خط کسر یا محتوای زیر عبارت را به همسایه‌ها نزدیک‌تر کند. |

خط پایه خط مرجع است که حروف ریاضی معمولی بر روی آن قرار می‌گیرند. مخفی کردن محتوا ابعاد آن را حذف نمی‌کند و در نظر گرفتن یک بعد به عنوان صفر، عبارت را حذف نمی‌کند. عبارت پایه‌ای از طریق [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase) در دسترس باقی می‌ماند. با پاس کردن `True` به [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) مجدداً آن را نمایش دهید؛ تنظیمات بعدی بدون تغییر می‌مانند.

مثال زیر پنج گونهٔ در کنار هم ایجاد می‌کند: یک کسر قابل مشاهده، یک کسر مخفی که فضا را حفظ می‌کند و سه کسر مخفی که یک بعد آنها به صفر تبدیل شده است. هر گونه از همان عبارت اطراف و Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند. تمام اشکال معادله موقعیت بالای یکسانی دارند که با راهنمای خاکستری نشان داده شده است. قرار دادن فانتوم در صورت یک کسر بیرونی تغییرات طرح‌عمودی را قابل مشاهده‌تر می‌سازد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathBlock, MathFraction, MathematicalText, MathPhantom, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color


def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    labels = ("Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc")

    guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0)
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)

    for index, name in enumerate(labels):
        left = 10 + index * 200
        
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(14)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = MathFraction(fraction_numerator, fraction_denominator)
        phantom = MathPhantom(fraction)
        phantom.setShow(index == 0)
        phantom.setZeroWidth(index == 2)
        phantom.setZeroAsc(index == 3)
        phantom.setZeroDesc(index == 4)

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = MathFraction(numerator, denominator)

        shape = slide.getShapes().addMathShape(left, 60, 190, 100)
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        math_paragraph = math_portion.getMathParagraph()
        math_block = MathBlock(equation)
        math_paragraph.add(math_block)

    presentation.save("math-phantom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![پنج معادله در PowerPoint مقایسهٔ یک کسر قابل مشاهده، یک کسر مخفی که فضا را حفظ می‌کند، و کسرهای مخفی با ZeroWidth، ZeroAsc یا ZeroDesc فعال](math-phantom.png)

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) برای قرار دادن یک کاراکتر گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. یک حد اضافه کنید تا عبارات گروه‌بندی‌شده را برچسب بزنید.

![عبارت x به‌اضافه y گروه‌بندی شده با برچسب هر متن در پایین آن](powerpoint-math-equations_15.png)

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

از کمکی‌های قالب‌بندی فقط در جایی که فرمول را واضح می‌کند استفاده کنید. برای مثال، [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) یک خط بالای عنصر ریاضی می‌گذارد.

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

برای قالب‌بندی متن در تمام معادلهٔ موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) فقط فرزندان مستقیم را برمی‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و سایر ساختارهای تو در تو آن را به‌صورت بازگشتی صدا بزنید. عنصر فعلی و همچنین فرزندان آن را بررسی کنید تا عنصر شروع را زمانی که [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) است، شامل شود.

این مثال فرض می‌کند که `input.pptx` شامل معادله‌ای مانند `z = xᵢ / ∛y` است، که یک کسر دارای زیرنویس در صورت و رادیکال در مخرج دارد. پردازش تنها عناصر سطح بالای بلوک متن را از دست می‌دهد. این مثال بخش‌های ریاضی را در فریم‌های متن اسلاید پیدا می‌کند، بلوک‌هایشان را از طریق [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) دسترسی می‌دهد و از [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) برای تنظیم اندازهٔ قلم به ۲۸ پوینت برای هر عنصر متن از طریق متد [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) استفاده می‌کند.

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

ارائهٔ ذخیره‌شده قالب‌بندی متن به‌روز شده را در هر سطح از هر معادله پردازش‌شده دارد، در حالی که محتویات متن و ساختار ریاضی را حفظ می‌کند.

## **مرجع سریع**

| وظیفه | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| ترکیب عناصر | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| ایجاد کسرها | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| افزودن بالانویس یا زیرنویس | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| افزودن توابع | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| افزودن رادیکال‌ها | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| افزودن حدود | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| افزودن اسکریپت‌های سمت چپ | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| افزودن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| افزودن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| افزودن آرایه‌های معادله | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| افزودن جداسازها | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| افزودن نوارها و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **سوالات متداول**

**آیا می‌توانم یک معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکل حاوی یک [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) را پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید و بلوک‌های ریاضی آن پاراگرف را به‌روز کنید.

**آیا معادلات به‌صورت ریاضی قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتوای ریاضی Office قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) دریافت کنید و [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) را فراخوانی کنید تا مستقیماً صادر شود. برای یک مثال کامل، به [صادرات معادلات ریاضی از ارائه‌ها در Python](/slides/fa/python-java/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.