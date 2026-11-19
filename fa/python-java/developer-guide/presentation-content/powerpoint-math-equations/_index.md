---
title: افزودن معادلات ریاضی به ارائه‌های پاورپوینت در پایتون
linktitle: معادلات ریاضی پاورپوینت
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
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "در پاورپوینت (PPT و PPTX) معادلات ریاضی را با Aspose.Slides برای پایتون از طریق جاوا وارد و ویرایش کنید، با پشتیبانی از OMML، کنترل‌های قالب‌بندی و نمونه‌های واضح کد پایتون."
---
## **بررسی کلی**

PowerPoint معادلات را به صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Python از طریق Java، می‌توانید همان نوع محتوای ریاضی را به‌صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدها، اپراتورهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

نتیجهٔ متن ریاضی قابل ویرایش روی اسلاید است:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) ایجاد می‌شود، شکلی است که معادله را در خود دارد.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) محتویات ریاضی را داخل چارچوب متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) است.

بیشتر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) و روش‌های زنجیره‌ای [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) برای کوتاه و قابل خواندن نگه داشتن کد استفاده می‌کنند.

برای سناریوهای خروجی MathML، به [Export Math Equations from Presentations in Python](/slides/fa/python-java/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیهٔ فیثاغورث را اضافه می‌کند:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="نکته" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) یک شکل را ایجاد می‌کند که پیش‌از پیش شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) را دسترسی گرفته، [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

### **ترکیب بلوک‌های ریاضی**

زمانی که قسمت‌های یک معادله به‌صورت مستقل به‌عنوان شیء [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) ساخته می‌شوند، از [joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) برای ترکیب آن‌ها استفاده کنید. مثال `c² =` را در بلوک چپ و `a² + b²` را در بلوک راست می‌سازد. [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript) برای همهٔ سه توان یک فوق‌نویس ریاضی قابل ویرایش ایجاد می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addMathShape(20, 20, 600, 100)
    math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    left_block = MathBlock()
    left_block.add(MathematicalText("c").setSuperscript("2"))
    left_block.add(MathematicalText("="))

    right_block = MathBlock()
    right_block.add(MathematicalText("a").setSuperscript("2"))
    right_block.add(MathematicalText("+"))
    right_block.add(MathematicalText("b").setSuperscript("2"))

    combined_block = left_block.joinBlock(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) خود `left_block` را برمی‌گرداند که حالا هر دو بخش را به ترتیب در خود دارد و `right_block` را خالی می‌کند. بلوک ترکیب‌شده را تنها یک‌بار به [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) اضافه کنید. پس از بازگشایی مجدد `equation.pptx`، پاراگراف یک بلوک شامل `c² = a² + b²` دارد و هر سه توان به‌صورت فوق‌نویس ریاضی حفظ می‌شوند.

فراخوانی [add](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#add) به شکل `left_block.add(right_block)` سعی می‌کند یک بلوک را به‌صورت مستقیم داخل بلوک دیگر تو در تو کند و `InvalidOperationException` صادر می‌شود.

## **افزودن کسرها**

از [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) انتخاب کنید.

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

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

برای یک کسر پشته‌ای، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar) استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **افزودن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) برای ایجاد رادیکال ریشهٔ دوم، رادیکال مکعب یا رادیکال‌های دیگر استفاده کنید. عنصر جاری به‌عنوان پایه می‌شود و آرگومان به‌عنوان درجهٔ رادیکال.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

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

### **نمایش یا مخفی‌سازی درجهٔ ریشهٔ دوم**

یک ریشهٔ دوم می‌تواند عدد ۲ را به‌صورت صریح نشان دهد یا از نماد مرسوم √x استفاده کند. متد [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) از [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) تعیین می‌کند که کدام فرم نمایش داده شود. هر دو فرم درجهٔ ۲ و زیر radicand x را در معادلهٔ قابل ویرایش حفظ می‌کنند.

![The same square root with the degree visible on the left and hidden on the right](square-root-degree.png)

مثال ریشهٔ دوم را دو بار ذخیره می‌کند. در `visible-degree.pptx` عدد ۲ دیده می‌شود. در `hidden-degree.pptx` مخفی است.

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

## **افزودن توابع و حدها**

از [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) یا [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) برای توابعی مانند `sin(x)`, `log(x)` یا نام‌های توابع سفارشی استفاده کنید. برای حدها، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) قرار دهید یا از [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit) استفاده کنید.

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را به‌عنوان عنصر جاری قرار دهید و با [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) و آرگومان آن فراخوانی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **افزودن اپراتورهای N-ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) برای جمع‌ها، اتحادها، اشتراک‌ها و دیگر اپراتورهای بزرگ استفاده کنید. برای انتگرال‌ها از [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) استفاده کنید. هر دو متد امکان تنظیم حد پایین و بالا را می‌دهند.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

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

اپراتورهای N-ary برای اپراتورهای بزرگ با حدهای اختیاری هستند. اپراتورهای سادهٔ مانند `+`, `-`, `=` معمولاً به‌عنوان [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) اضافه می‌شوند و به عبارت ترکیب می‌گردند.

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

از [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به‌طور پیش‌فرض ماتریس‌ها پرانتز ندارند، بنابراین برای افزودن پرانتز، براکت یا کروشه، ماتریس را درون آن‌ها بگذارید.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

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

فرض کنید درس جبر خطی با ماتریس ضرایب در `matrix.pptx` آغاز می‌شود که توسط مثال پیشین ذخیره شده است. برای تمرین بعدی، معادلهٔ اول را نگه دارید، معادلهٔ دوم را با دو معادلهٔ جدید جایگزین کنید و مجموعهٔ متغیرها را بازنگری کنید. ماتریس موجود را با [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) باز کنید تا ضرایبی که هنوز معتبرند حفظ شوند.

![Original two-row coefficient matrix with entries 1, x, and an empty cell in the first row and x, 2, and y in the second](matrix-before-edit.png)

اندیس‌های ردیف و ستون از صفر شروع می‌شوند و به ماتریس در هر فراخوانی اشاره می‌کنند. درج ردیف قبل از اندیس ۱، ردیف دوم اصلی را به اندیس ۲ منتقل می‌کند. درج پس از اندیس ۲ سپس یک ردیف اضافه می‌کند. حذف ردیف ۲ ردیف دوم اصلی را حذف می‌کند و ردیف اضافه‌شده را یک موقعیت بالا می‌برد. ستون‌ها به همان شکل جابه‌جا می‌شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

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

    # سلول‌های جدید ابتدا خالی هستند. ابتدا ضرایب غیرصفر را تنظیم کنید.
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

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) ستون اول را به چپ تراز می‌کند. [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) سه ستون دیگر را از اندیس ۱ به سمت راست تراز می‌کند. در `updated-matrix.pptx`، ماتریس شامل سه معادله و چهار متغیر است. ضرایب ردیف اول اصلی `1` و `x` اکنون در ستون‌های اول و سوم ظاهر می‌شوند.

![Updated three-row matrix showing the rows 1, 0, x, 0; 12, 1, 0, 0; and 0, 0, 10, 1](matrix-after-edit.png)

## **افزودن آرایه‌های معادله**

از [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) زمانی که به معادلات هم‌تراز یا یک پشتهٔ عمودی از عبارات نیاز دارید، استفاده کنید.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

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

### **هم‌تراز کردن یک آرایه با عناصر اطراف**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) تراز عمودی یک آرایه را نسبت به عناصر ریاضی کشیدهٔ آن کنترل می‌کند. مثال زیر تراز را با ردیف اول، مرکز آرایه و ردیف آخر مقایسه می‌کند.

مثال زیر سه آرایهٔ یکسان، هر کدام با سه ردیف و عناصر همسایهٔ `A=` و `=B` ایجاد می‌کند. تمام متن ریاضی از Cambria Math با ۲۴ پوینت استفاده می‌کند. فقط تراز آرایه تغییر می‌کند.

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

![Equation arrays in PowerPoint with Top, Center, and Bottom alignment and identical neighboring elements](equation-array-alignment.png)

### **پیکربندی فاصلهٔ ردیف‌ها**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) قانون فاصلهٔ ردیف‌ها را درون آرایه انتخاب می‌کند. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) برای یک قانون صریح مقدار عددی فراهم می‌کند و توسط قوانین پیش‌تنظیم‌شده نادیده گرفته می‌شود.

برای فاصلهٔ دقیق، مقدار بر حسب نقطه اندازه‌گیری می‌شود. برای فاصلهٔ نسبی، بر حسب نیم‌خط‌ها اندازه‌گیری می‌شود: مقدار `3` در مثال برابر است با ۱٫۵ خط. هنگام مشخص کردن مقدار صریح، هر دو ویژگی را تنظیم کنید؛ تغییر مقدار عددی به‌تنهایی قانون فاصله را انتخاب نمی‌کند.

مثال زیر پنج ارائه با معادلات، تراز و تنظیمات فونت یکسان ذخیره می‌کند. سه ارائهٔ اول از پیش‌تنظیم‌ها استفاده می‌کنند؛ دو ارائهٔ آخر مقادیر صریح را نشان می‌دهند.

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

فاصلهٔ ردیف آرایه جدا از فاصلهٔ پاراگراف است. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) و [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) فضای اطراف پاراگراف حامل را اضافه می‌کنند، نه بین ردیف‌های آرایه. به‌همین ترتیب، [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) کل پاراگراف ریاضی را افقی موقعیت می‌دهد؛ تنظیم تراز عمودی آرایه را جایگزین نمی‌کند.

## **افزودن توابع مثلثاتی**

از [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) وقتی آرگومان عنصر جاری است و نام تابع شناخته‌شده است، استفاده کنید.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

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

از کمک‌کننده‌های زیرنویس و بالانویس برای اندیس‌ها و توان‌ها استفاده کنید. وقتی اندیس‌ها باید در سمت چپ پایه ظاهر شوند، از [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) استفاده کنید.

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

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

از [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) برای قرار دادن یک عبارت داخل جداسازها استفاده کنید. می‌توانید برای عبارات جداساز که شامل چند عنصر هستند، یک کاراکتر جداساز تعیین کنید.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

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

به [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) مقدار `True` بدهید تا پرانتزها حول یک عملوند بلند رشد کنند، یا مقدار `False` بدهید تا اندازهٔ معمولی خود را حفظ کنند. از [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) همراه با یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) استفاده کنید. `Centered` پرانتزها را بر محور ریاضی (که از میان علامت مساوی می‌گذرد) مرکزی می‌کند. `Match` آن‌ها را با محتوای داخل هماهنگ می‌سازد. هر دو تنظیم فقط بر جداسازها تأثیر دارد؛ عبارت داخل همان‌طور می‌ماند.

مثال یک کسر را در نمایندهٔ `x` قرار می‌دهد تا عبارت بالاتر از خط پایه بیشتر از زیر آن گسترش یابد. تمام چهار معادله از همان پرانتزها و تنظیمات فونت استفاده می‌کنند.

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

در PowerPoint، ردیف‌ها را برای دیدن اثر رشد مقایسه کنید. در ردیف بالایی، پرانتزها برای دربرگیری نماینده رشد می‌کنند و برای هر دو شکل یک‌سان به‌نظر می‌رسند. در ردیف زیرین، رشد خاموش است. پرانتزهای کوچکتر سمت چپ (`Centered`) با علامت مساوی هم‌خط می‌شوند، در حالی که سمت راست (`Match`) بالاتر دور عبارت می‌مانند.

![Four equations in PowerPoint with delimiter growth enabled above and disabled below, and Centered on the left and Match on the right](delimiter-sizing.png)

## **افزودن یک کادر مرزی**

با فراخوانی [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) بر روی یک کسر، کل عبارت را در یک کادر قرار می‌دهید. [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) به‌طور پیش‌فرض چهار طرف را نشان می‌دهد. از [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) و [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) برای حذف طرف‌های جداگانه استفاده کنید.

مثال شش کپی یکسان از همان کسر را روی یک اسلاید قرار می‌دهد. برای نشان دادن لغو، چهار طرف را مخفی کنید و مقدار `True` را به [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) برای یک قطر صعودی (↗) یا به [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) برای یک قطر نزولی (↘) بدهید. همچنین می‌توانید از [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) یا [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) با هر ترکیبی از طرف‌های قابل مشاهده استفاده کنید.

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

![Six editable fractions in PowerPoint. Top row: full border, bottom and left sides, rising diagonal. Bottom row: falling diagonal, horizontal strike, vertical strike with a full border.](border-box-fractions.png)

در این کسر، خط افقی بر روی خط کسر هم‌پوشان می‌شود. خط عمودی هم‌زمان بر صورت و مخرج عبور می‌کند در حالی که کادر اطراف قابل رؤیت می‌ماند. این خطوط تمام عبارت را تزئین می‌کنند. خط زدن متنی معمولی فقط بر روی کاراکترهای یک اجرا اعمال می‌شود. پس از بازگشایی ارائه در PowerPoint، می‌توانید صورت و مخرج را به‌صورت مستقل ویرایش کنید.

## **کنترل نمایش و طرح با عناصر فانتوم**

یک عبارت را با [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) بپوشانید تا نمایش آن و فضایی که به یک معادله اضافه می‌کند، به‌صورت مستقل کنترل شود. متدهای [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) موارد زیر را تنظیم می‌کنند:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | مقدار `False` را بدهید تا عبارت مخفی شود. ابعاد آن همچنان در طرح لحاظ می‌شوند مگر اینکه متدهای زیر مقدار `True` بگیرند. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | عرض افقی عبارت را صفر در نظر بگیرید تا عناصر همسایه نزدیک‌تر شوند. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | ارتفاع بالایی (ascender) را صفر کنید تا فضای رزرو شده بالای عناصر همسایه کاهش یابد. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | ارتفاع پایین (descender) را صفر کنید تا خط کسر یا محتوای دیگر زیر عبارت به همسایه‌هایش نزدیک‌تر شود. |

خط پایه خط مرجع است که حروف ریاضی معمولی بر روی آن قرار می‌گیرند. مخفی‌سازی محتوا ابعاد آن را حذف نمی‌کند و در نظر گرفتن یک بعد به‌عنوان صفر، عبارت را حذف نمی‌سازد. عبارت زیرین همچنان از طریق [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase) در دسترس است. مقدار `True` را به [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) بدهید تا دوباره نمایش داده شود؛ تنظیمات بعدی همان‌گونه باقی می‌مانند.

مثال زیر پنج گونهٔ کنار هم ایجاد می‌کند: یک کسر قابل مشاهده، یک کسر مخفی که فضا را حفظ می‌کند و سه کسر مخفی که یکی از ابعاد آن‌ها به صفر تنظیم شده است. هر گونه از همان عبارت اطراف و Cambria Math با ۲۴ پوینت استفاده می‌کند. تمام اشکال معادله موقعیت بالایی یکسانی دارند که با راهنمای خاکستری مشخص شده است. قرار دادن فانتوم در صورت یک کسر خارجی، تغییرات طرح عمودی را آسان‌تر مشاهده می‌کند.

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

![Five equations in PowerPoint comparing a visible fraction, a hidden fraction that reserves space, and hidden fractions with ZeroWidth, ZeroAsc, or ZeroDesc enabled](math-phantom.png)

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) برای قرار دادن یک کاراکتر گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. یک حد اضافه کنید تا عبارات گروه‌بندی‌شده برچسب‌گذاری شوند.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

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

از کمک‌کننده‌های قالب‌بندی فقط در جایی استفاده کنید که فرمول را روشن می‌کند. برای مثال، [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) یک خط افقی بالای یک عنصر ریاضی می‌گذارد.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

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

برای قالب‌بندی متن در تمام یک معادله موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) تنها فرزندان مستقیم را برمی‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، نمای‌ها، رادیکال‌ها و سایر ساختارهای تو در تو، به‌صورت بازگشتی فراخوانی کنید. عنصر جاری و فرزندانش را بررسی کنید تا وقتی عنصر [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) است، خود آن را نیز شامل شود.

این مثال فرض می‌کند `input.pptx` حاوی معادله‌ای مانند `z = xᵢ / ∛y` باشد که یک کسر با زیرنویس در صورت و رادیکال در مخرج دارد. پردازش فقط عناصر سطح بالای بلوک، متن داخل کسر را از دست می‌دهد. مثال بخش‌های ریاضی را در چارچوب‌های متن اسلاید پیدا می‌کند، بلوک‌هایشان را از طریق [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) دسترسی می‌یابد و از [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) برای تنظیم اندازهٔ فونت به ۲۸ پوینت برای هر عنصر متنی از طریق متد [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) استفاده می‌کند.

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

ارائهٔ ذخیره‌شده متن قالب‌بندی‌شده به‌روز شده را در هر سطح از هر معادلهٔ پردازش‌شده شامل می‌شود، در حالی که محتوا و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| Task | Main API |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| ترکیب عناصر | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| ایجاد کسرها | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| افزودن بالانویس یا زیرنویس | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| افزودن توابع | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| افزودن رادیکال‌ها | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| افزودن حدها | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| افزودن اسکریپت‌های سمت چپ | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| افزودن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| افزودن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| افزودن آرایهٔ معادله | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| افزودن جداسازها | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| افزودن بارها و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **سوالات متداول**

**آیا می‌توانم یک معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) است پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید و بلوک‌های ریاضی در آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به‌صورت ریاضی قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتوای ریاضی Office قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) دریافت کنید و متد [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) را برای صادرات مستقیم فراخوانی کنید. برای یک مثال کامل، به [Export Math Equations from Presentations in Python](/slides/fa/python-java/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.