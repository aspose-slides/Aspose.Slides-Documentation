---
title: اضافه کردن معادلات ریاضی به ارائه‌های PowerPoint در Python
linktitle: معادلات ریاضی PowerPoint
type: docs
weight: 80
url: /fa/python-java/powerpoint-math-equations/
keywords:
- معادله ریاضی
- نماد ریاضی
- فرمول ریاضی
- متن ریاضی
- اضافه کردن معادله ریاضی
- اضافه کردن نماد ریاضی
- اضافه کردن فرمول ریاضی
- اضافه کردن متن ریاضی
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "در PowerPoint (PPT و PPTX) معادلات ریاضی را با Aspose.Slides برای Python از طریق Java وارد و ویرایش کنید، با پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های کد واضح Python."
---
## **بررسی کلی**

PowerPoint معادلات را به صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Python از طریق Java، می‌توانید همان نوع محتوای ریاضی را به‌صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدود، عملگرهای N‑ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش بر روی اسلاید است:

![یک اسلاید PowerPoint حاوی یک معادله ریاضی قابل ویرایشی](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی که با [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) ایجاد می‌شود، شکلی است که معادله را در خود دارد.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) محتوای ریاضی داخل قاب متن شکل را ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) است.

اکثریت مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) و متدهای fluent از [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) برای کوتاه و خوانا نگه داشتن کد استفاده می‌کنند.

برای سناریوهای خروجی MathML، به [Export Math Equations from Presentations in Python](/slides/fa/python-java/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیه فیثاغورس را اضافه می‌کند:

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) یک شکلی را ایجاد می‌کند که از پیش شامل یک پاراگراف ریاضی است. به اولین [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) دسترسی پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

### **ترکیب بلوک‌های ریاضی**

هنگامی که بخش‌های یک معادله به‌صورت مستقل به‌عنوان شیءهای [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) ساخته شوند، از [joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) برای ترکیب آن‌ها استفاده کنید. این مثال `c² =` را در بلوک سمت چپ و `a² + b²` را در بلوک سمت راست می‌سازد. [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript) برای تمام سه توان، بالانویس‌های ریاضی قابل ویرایشی ایجاد می‌کند.

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

[joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) `left_block` را بازمی‌گرداند؛ اکنون شامل هر دو قسمت به ترتیب است و `right_block` خالی می‌ماند. بلوک ترکیب‌شده را تنها یک‌بار به [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) اضافه کنید. پس از بازگشایی `equation.pptx`، پاراگراف شامل یک بلوک است که `c² = a² + b²` را نشان می‌دهد و هر سه توان به‌صورت بالانویس‌های ریاضی حفظ می‌شوند.

فراخوانی [add](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#add) به صورت `left_block.add(right_block)` سعی می‌کند یک بلوک را مستقیماً داخل بلوک دیگر قرار دهد و `InvalidOperationException` را پرتاب می‌کند.

## **افزودن کسرها**

از [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) انتخاب کنید.

![کسر ریاضی کج که یک بر x تقسیم می‌شود](powerpoint-math-equations_4.png)

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

برای یک کسر ستاپ‌شده، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar) استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **افزودن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) برای ایجاد ریشه دوم، ریشه سوم یا ریشه دیگر استفاده کنید. عنصر جاری به‌عنوان پایه می‌شود و آرگومان به‌عنوان درجه.

![عبارت رادیکال n‑ام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

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

### **نمایش یا مخفی‌سازی درجه ریشه دوم**

یک ریشه دوم می‌تواند عدد 2 صریح را نمایش دهد یا از نماد متعارف √x استفاده کند. متد [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) از [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) تعیین می‌کند کدام شکل ظاهر شود. هر دو شکل درجه 2 و رادیکاند x را در معادله قابل ویرایش حفظ می‌کنند.

![همان ریشه دوم با درجه‌ی قابل مشاهده در سمت چپ و مخفی در سمت راست](square-root-degree.png)

مثال همان ریشه دوم را دو بار ذخیره می‌کند. در `visible-degree.pptx` عدد 2 قابل مشاهده است. در `hidden-degree.pptx` عدد مخفی است.

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

برای توابعی مانند `sin(x)`، `log(x)` یا نام‌های توابع سفارشی، از [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) یا [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) قرار دهید یا از [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit) بهره ببرید.

![حد x وقتی x به بی‌نهایت میل می‌کند](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را به‌عنوان عنصر جاری قرار داده و با آرگومان آن [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) را فراخوانی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **افزودن عملگرهای N‑ary و انتگرال‌ها**

برای جمع‌ها، اجتماع‌ها، اشتراک‌ها و سایر عملگرهای بزرگ از [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) استفاده کنید. برای انتگرال‌ها از [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) بهره ببرید. هر دو متد امکان تنظیم حدهای پایین و بالا را می‌دهند.

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

عملگرهای N‑ary برای عملگرهای بزرگ با حدهای اختیاری استفاده می‌شوند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به‌عنوان [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) اضافه می‌شوند و به عبارت متصل می‌گردند.

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

برای ردیف‌ها و ستون‌ها از [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) استفاده کنید. به‌طور پیش‌فرض ماتریس‌ها براکت ندارند، بنابراین هنگام نیاز به پرانتز، کروشه یا آکولاد، ماتریس را درون آنها بگذارید.

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

فرض کنید درس جبر خطی با ماتریس ضرایب در `matrix.pptx` که توسط مثال قبلی ذخیره شده، آغاز می‌شود. برای تمرین بعدی، معادله اول را نگه داشته، معادله دوم را با دو معادله جدید جایگزین می‌کنید و مجموعه متغیرها را بازنگری می‌کنید. ماتریس موجود را از طریق [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) باز کنید تا ضرایبی که هنوز معتبرند حفظ شوند.

![ماتریس ضرایب دو ردیفی اولیه با مقادیر 1، x و یک سلول خالی در ردیف اول و x، 2 و y در ردیف دوم](matrix-before-edit.png)

شاخص‌های ردیف و ستون از صفر شروع می‌شوند و به ماتریس در هر فراخوانی اشاره می‌کنند. درج یک ردیف قبل از شاخص 1، ردیف دوم اصلی را به شاخص 2 منتقل می‌کند. درج پس از شاخص 2 سپس یک ردیف اضافه می‌کند. حذف ردیف 2 معادله دوم اصلی را حذف کرده و ردیف افزوده‌شده را یک موقعیت بالا می‌برد. ستون‌ها به‌طور مشابه جابه‌جا می‌شوند.

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

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) ستون اول را به چپ تراز می‌کند. [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) سه ستون باقی‌مانده را از شاخص 1 به راست تراز می‌کند. در `updated-matrix.pptx`، ماتریس دارای سه معادله و چهار متغیر است. ضرایب ردیف اول اولیه `1` و `x` اکنون در ستون‌های اول و سوم ظاهر می‌شوند.

![ماتریس سه ردیفی بروز شده که ردیف‌ها به صورت 1, 0, x, 0؛ 12, 1, 0, 0؛ و 0, 0, 10, 1 نمایش داده می‌شوند](matrix-after-edit.png)

## **افزودن آرایه‌های معادله**

هنگامی که به معادلات هم‌تراز یا یک پشته عمودی از عبارات نیاز دارید، از [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) استفاده کنید.

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

### **ترازبندی یک آرایه با عناصر اطراف**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) ترازبندی عمودی آرایه را نسبت به عناصر ریاضی هم‌جوار کنترل می‌کند. مثال زیر ترازبندی را با ردیف اول، مرکز آرایه و ردیف آخر مقایسه می‌کند.

مثال زیر سه آرایهٔ یکسان، هر کدام با سه ردیف و عناصر همسایه `A=` و `=B` می‌سازد. تمامی متن ریاضی از Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند. فقط ترازبندی آرایه تغییر می‌کند.

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

مقایسهٔ زیر ارائهٔ ذخیره‌شده در PowerPoint را نشان می‌دهد. به موقعیت `A=` و `=B` در کنار هر آرایه توجه کنید.

![آرایه‌های معادله در PowerPoint با ترازبندی بالا، مرکز و پایین و عناصر همسایهٔ یکسان](equation-array-alignment.png)

### **پیکربندی فاصله بین ردیف‌ها**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) قانون فاصلهٔ بین ردیف‌های داخل آرایه را انتخاب می‌کند. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) مقدار عددی برای یک قانون فاصلهٔ صریح فراهم می‌کند و توسط قوانین پیش‌فرض نادیده گرفته می‌شود.

برای فاصلهٔ دقیق، مقدار بر حسب پوینت اندازه‌گیری می‌شود. برای فاصلهٔ نسبی، بر حسب نیم‌خط اندازه‌گیری می‌شود: مقدار `3` در مثال برابر ۱٫۵ خط است. هنگام تعیین یک مقدار صریح هر دو ویژگی را تنظیم کنید؛ فقط تغییر مقدار عددی قانون فاصله را انتخاب نمی‌کند.

مثال زیر پنج ارائهٔ با معادلات، ترازبندی و تنظیمات قلم یکسان ذخیره می‌کند. سه ارائهٔ اول از پیش‌تنظیم‌ها استفاده می‌کنند؛ دو ارائهٔ آخر مقادیر صریح را نشان می‌دهند.

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

فاصلهٔ ردیف در آرایه جدا از فاصلهٔ پاراگراف است. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) و [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) فاصلهٔ اطراف پاراگراف حاوی آرایه را اضافه می‌کند، نه بین ردیف‌های آرایه. به‌طور مشابه، [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) کل پاراگراف ریاضی را به‌صورت افقی موقعیت می‌دهد؛ این تنظیم جایگزین تنظیم ترازبندی عمودی آرایه نمی‌شود.

## **افزودن توابع مثلثاتی**

زمانی که آرگومان عنصر جاری است و نام تابع شناخته‌شده، از [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) استفاده کنید.

![تابع مثلثاتی cos اعمال شده روی 2x](powerpoint-math-equations_6.png)

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

## **افزودن زیرنویس‌ها و بالانویس‌ها**

برای اندیس‌ها و توان‌ها از ابزارهای زیرنویس و بالانویس استفاده کنید. هنگامی که اندیس‌ها باید در سمت چپ پایه ظاهر شوند، از [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) بهره ببرید.

![حرف بزرگ Y با زیرنویس سمت چپ 1 و بالانویس n](powerpoint-math-equations_9.png)

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

### **ترازبندی زیرنویس‌ها و بالانویس‌های راست**

هنگامی که یک زیرنویس و یک بالانویس پایهٔ مشترکی داشته باشند، از [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-java/aspose.slides/mathrightsubsuperscriptelement/) استفاده کنید. متد [setAlignScripts](https://reference.aspose.com/slides/python-java/aspose.slides/mathrightsubsuperscriptelement/#setAlignScripts) موقعیت افقی آن‌ها را کنترل می‌کند. با مقدار پیش‌فرض `False`، هر اسکریپت پیروی‌کنندهٔ شکل پایه است. با مقدار `True`، اسکریپت‌ها از همان موقعیت افقی شروع می‌شوند.

این مثال دو نسخهٔ یک عبارت قابل ویرایش را کنار هم قرار می‌دهد. هر دو از یک حرف ایتالیک ریاضی f (U+1D453) با زیرنویس 1 و بالانویس 2 در Cambria Math با اندازهٔ ۷۲ پوینت استفاده می‌کنند. شیب f باعث می‌شود تفاوت در PowerPoint قابل مشاهده باشد. پیش از اجرای مثال Cambria Math را نصب کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathBlock, MathematicalText, MathRightSubSuperscriptElement
from asposeslides.api import PortionFormat, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(900, 250, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    text_format = PortionFormat()
    font = FontData("Cambria Math")
    text_format.setFontHeight(72)
    text_format.setLatinFont(font)

    for left, align_scripts in [(40, False), (480, True)]:
        shape = slide.getShapes().addMathShape(left, 75, 380, 150)
        base = MathematicalText("\U0001D453", text_format)
        subscript = MathematicalText("1", text_format)
        superscript = MathematicalText("2", text_format)
        scripts = MathRightSubSuperscriptElement(base, subscript, superscript)
        scripts.setAlignScripts(align_scripts)

        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(text_format.getFontHeight())
        portion.getPortionFormat().setLatinFont(font)
        block = MathBlock(scripts)
        portion.getMathParagraph().add(block)

    presentation.save("aligned-scripts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![دو عبارت قابل ویرایش در PowerPoint با setAlignScripts برابر False در سمت چپ و True در سمت راست](aligned-scripts.png)

در سمت چپ، زیرنویس نسبت به بالانویس بیشتر به سمت چپ می‌آید و شکل f را دنبال می‌کند. در سمت راست، لبهٔ چپ دو اسکریپت هم‌راستا می‌شوند.

## **افزودن جداسازها**

از [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) برای قرار دادن یک عبارت درون جداسازها استفاده کنید. همچنین می‌توانید یک کاراکتر جداکننده برای عبارات جداساز که شامل چند عنصر هستند تنظیم کنید.

![عبارت جداساز شامل x، y و z که با خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

### **اندازه و ترازبندی جداسازها**

برای اجازه دادن به پرانتزها برای گسترش به‌محض یک عملوند بلند، `True` را به [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) پاس می‌دهید؛ یا `False` می‌گذارید تا اندازهٔ معمولی خود باقی بمانند. با استفاده از [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) و یکی از مقادیر [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) `Centered` پرانتزها را بر محور ریاضی (میان علامت مساوی) مرکز می‌کند؛ `Match` آن‌ها را با محتوای محاط‌شده هم‌تراز می‌کند. هر دو تنظیم فقط بر جداسازها اثر می‌گذارند؛ عبارت داخلی بدون تغییر می‌ماند.

مثال یک کسر را در توان `x` قرار می‌دهد تا عبارت بالاتر از خط پایه نسبت به پایین‌تر گسترش یابد. هرچهار معادله از یک پرانتز و تنظیمات قلم یکسان استفاده می‌کنند.

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

در PowerPoint، ردیف‌ها را مقایسه کنید تا اثر گسترش را ببینید. در ردیف بالایی، پرانتزها برای محاط کردن توان گسترش می‌یابند و برای هر دو شکل یکسان به‌نظر می‌رسند. در ردیف پایینی، گسترش خاموش است. پرانتزهای کوچکتر سمت چپ (`Centered`) با علامت مساوی هم‌تراز می‌شوند، در حالی که پرانتزهای سمت راست (`Match`) بالاتر دور عبارت می‌نشینند.

![چهار معادله در PowerPoint با فعال‌سازی رشد جداساز در بالا و غیرفعال‌سازی آن در پایین؛ `Centered` در چپ و `Match` در راست](delimiter-sizing.png)

## **افزودن جعبهٔ حواشی**

روی یک کسر [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) را صدا بزنید تا کل عبارت در یک جعبهٔ حواشی قرار گیرد. [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) به‌صورت پیش‌فرض چهار طرف را نشان می‌دهد. برای حذف طرف‌های جداگانه از [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop)، [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom)، [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) و [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) استفاده کنید.

مثال شش نسخهٔ یک کسر را روی یک اسلاید قرار می‌دهد. برای نشان دادن حذف، تمام چهار طرف را مخفی کنید و `True` را به [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) برای یک قطعهٔ قطری صعودی (↗) یا به [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) برای یک قطعهٔ قطری نزولی (↘) بدهید. همچنین می‌توانید از [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) یا [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) همراه با ترکیبی از طرف‌های قابل مشاهده استفاده کنید.

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

![شش کسر قابل ویرایش در PowerPoint. ردیف بالا: حاشیه کامل، طرف‌های پایین و چپ، قطعهٔ قطری صعودی. ردیف پایین: قطعهٔ قطری نزولی، خط افقی، خط عمودی با حاشیهٔ کامل](border-box-fractions.png)

در این کسر، خط افقی بر روی نوار کسر هم‌پوشانی دارد. خط عمودی هر دو صورت و مخرج را می‌پوشاند در حالی که حاشیهٔ اطراف قابل مشاهده می‌ماند. این خطوط کل عبارت را تزئین می‌کنند. Strikethrough معمولی فقط به کاراکترهای داخل یک Run متن اعمال می‌شود. پس از بازگشایی ارائه در PowerPoint، هنوز می‌توانید صورت و مخرج را به‌صورت جداگانه ویرایش کنید.

## **کنترل قابلیت مشاهده و چینش با عناصر Phantom**

یک عبارت را در [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) بپیچید تا قابلیت مشاهدهٔ آن و فضایی که به معادله اضافه می‌کند را به‌صورت مستقل کنترل کنید. متدهای [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) موارد زیر را تنظیم می‌کنند:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | مقدار `False` باعث مخفی شدن عبارت می‌شود؛ ابعاد آن همچنان در چینش لحاظ می‌شود مگر اینکه متدهای زیر مقدار `True` بگیرند. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | عرض افقی عبارت را صفر در نظر می‌گیرد تا عناصر همسایه بتوانند به‌یکدیگر نزدیک‌تر شوند. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | ارتفاع بالای خط (ascender) را صفر می‌کند و می‌تواند فضای بالای عناصر همسایه را کاهش دهد. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | عمق زیر خط (descender) را صفر می‌کند و می‌تواند نوار کسر یا محتوای دیگر زیر عبارت را به‌نزدیک عناصر همسایه براند. |

خط پایه خط مرجع است که حروف ریاضی معمولی بر روی آن قرار می‌گیرند. مخفی کردن محتوا ابعاد آن را حذف نمی‌کند و تنظیم ابعاد به‌صورت صفر، عبارت را حذف نمی‌کند. عبارت زیرین از طریق [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase) در دسترس می‌ماند. مقدار `True` را به [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) بدهید تا دوباره نمایش داده شود؛ تنظیمات ابعاد بدون تغییر باقی می‌مانند.

مثال زیر پنج نوع متفاوت را به‌صورت کنار هم ایجاد می‌کند: یک کسر قابل مشاهده، یک کسر مخفی که فضا را حفظ می‌کند و سه کسر مخفی که هر یک یک بُعد را به‌صورت صفر در نظر می‌گیرد. هر نوع از همان عبارت اطراف و Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند. تمام شکل‌های معادله موقعیت بالایی یکسانی دارند که توسط راهنمای خاکستری نشان‌گذاری شده است. قرار دادن phantom در صورت یک کسر بیرونی باعث می‌شود تغییرات چینش عمودی به‌راحتی دیده شوند.

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

![پنج معادله در PowerPoint که یک کسر قابل مشاهده، یک کسر مخفی که فضا را حفظ می‌کند و کسرهای مخفی با ZeroWidth، ZeroAsc یا ZeroDesc فعال را مقایسه می‌کند](math-phantom.png)

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) برای قرار دادن یک نماد گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده یک حد اضافه کنید.

![عبارت x + y که با برچسب any text در زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

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

از ابزارهای قالب‌بندی فقط در مواردی استفاده کنید که فرمول را روشن‌تر می‌کنند. به عنوان مثال، [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) یک نوار بالای یک عنصر ریاضی می‌گذارد.

![عبارت ریاضی ABC با یک overbar](powerpoint-math-equations_14.png)

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

برای قالب‌بندی متن در سراسر یک معادلهٔ موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) تنها فرزندان مستقیم را باز می‌گرداند؛ بنابراین باید به‌صورت بازگشتی فراخوانی شود تا به متنی داخل کسرها، اسکریپت‌ها، رادیکال‌ها و ساختارهای تو در تو دسترسی پیدا کنید. عنصر جاری و فرزندانش را نیز بررسی کنید تا زمانی که عنصر [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) باشد، شامل شود.

این مثال فرض می‌کند `input.pptx` شامل معادله‌ای نظیر `z = xᵢ / ∛y` باشد که یک کسر با زیرنویس در صورت و رادیکال در مخرج دارد. پردازش تنها عناصر سطح‑بالای بلوک متن‌های داخل کسرها را از دست می‌دهد. مثال بخش‌های ریاضی در فریم‌های متن اسلاید را پیدا می‌کند، بلوک‌هایشان را از طریق [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) دسترسی می‌دهد و از [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) برای تنظیم اندازهٔ قلم به ۲۸ پوینت برای هر عنصر متنی از طریق متد [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) استفاده می‌کند.

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

ارائهٔ ذخیره‌شده متن قالب‌بندی‌شدهٔ به‌روز‌شده را در هر سطح از هر معادلهٔ پردازش‌شده شامل می‌شود، در حالی که محتوا و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| Task | Main API |
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
| افزودن نوارها و حواشی | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **پرسش‌های متداول**

**آیا می‌توانم یک معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکل حاوی یک [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) را پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید و بلوک‌های ریاضی آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به‌صورت ریاضی قابل ویرایش در PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌صورت محتوای Office Math قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) دریافت کنید و سپس [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) را فراخوانی کنید تا مستقیماً صادر شود. برای یک مثال کامل، به [Export Math Equations from Presentations in Python](/slides/fa/python-java/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.