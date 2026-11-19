---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية باستخدام Python
linktitle: معادلات رياضية في PowerPoint
type: docs
weight: 80
url: /ar/python-java/powerpoint-math-equations/
keywords:
- معادلة رياضية
- رمز رياضي
- صيغة رياضية
- نص رياضي
- إضافة معادلة رياضية
- إضافة رمز رياضي
- إضافة صيغة رياضية
- إضافة نص رياضي
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدراج وتحرير المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides للغة Python عبر Java، مع دعم OMML، أدوات تنسيق، وأمثلة شفرة Python واضحة."
---
## **نظرة عامة**

يخزن PowerPoint المعادلات بصيغة Office Math Markup Language (OMML). باستخدام Aspose.Slides للغة Python عبر Java، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجياً: الكسور، الجذور، الدوال، الحدود، العوامل متعددة الحدود، المصفوفات، المصفوفات المتنوعة، وكتل الرياضيات المُنسقة.

في PowerPoint، يضيف المستخدمون عادةً المعادلات من **Insert > Equation**:

![علامة تبويب Insert في PowerPoint مع تحديد أمر Equation](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

يبني Aspose.Slides ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يُنشأ باستخدام [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape)، وهو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) يخزن محتوى الرياضيات داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) يحتوي على كائن واحد أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/).

تستخدم معظم الأمثلة أدناه [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) والطرق السلسة من [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) لجعل الكود قصيراً وسهل القراءة.

للتعامل مع تصدير MathML، راجع [Export Math Equations from Presentations in Python](/slides/ar/python-java/exporting-math-equations/).

## **إنشاء معادلة**

يستخدم هذا المثال [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) لإنشاء شكل رياضي ويضيف نظرية فيثاغورس:

![المعادلة c² = a² + b²](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="ملاحظة" %}}

[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) ينشئ شكلاً يحتوي مسبقاً على فقرة رياضية. الوصول إلى أول [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/)، استدعاء [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph)، وإضافة كتل أو عناصر رياضية إليها.

{{% /alert %}}

### **دمج كتل الرياضيات**

عند بناء أجزاء المعادلة بشكل مستقل ككائنات [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/)، استخدم [joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) لدمجها. يبني المثال `c² =` في الكتلة اليسرى و`a² + b²` في الكتلة اليمنى. [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript) ينشئ أسس رياضية قابلة للتحرير للثلاثة أسس.

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

[joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) يعيد `left_block` نفسه، والذي يحتوي الآن على الجزأين بترتيبهما، ويترك `right_block` فارغاً. أضف الكتلة المدمجة إلى [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) مرة واحدة فقط. بعد إعادة فتح `equation.pptx`، تحتوي الفقرة على كتلة واحدة تمثل `c² = a² + b²`، مع الحفاظ على الثلاثة أسس كأُسٍّ رياضية.

استدعاء [add](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#add) كـ `left_block.add(right_block)` يحاول بدلاً من ذلك تضمين كتلة داخل أخرى مباشرةً ويؤدي إلى رفع استثناء `InvalidOperationException`.

## **إضافة كسور**

استخدم [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) لإنشاء كسر. يمكنك اختيار نمط كسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/).

![كسر رياضي مائل يظهر واحد مقسوم على x](powerpoint-math-equations_4.png)

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

للحصول على كسر مكدس، استخدم [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **إضافة جذور**

استخدم [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) لإنشاء جذر تربيعي أو مكعب أو أي جذر آخر. يصبح العنصر الحالي هو الأساس، وتصبح الوسيط هي الدرجة.

![تعبير جذري من الدرجة n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

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

### **إظهار أو إخفاء درجة الجذر التربيعي**

يمكن للجذر التربيعي عرض 2 صريحة أو استخدام التدوين التقليدي √x. تتحكم طريقة [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) في [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) في الشكل الظاهر. كلا الشكلين يحتفظان بالدرجة 2 والمتغير x في المعادلة القابلة للتحرير.

![نفس الجذر التربيعي مع درجة ظاهرة على اليسار ومخفاة على اليمين](square-root-degree.png)

يحفظ المثال نفس الجذر التربيعي مرتين. في `visible-degree.pptx`، تكون الـ2 ظاهرة. في `hidden-degree.pptx`، تكون مخفية.

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

## **إضافة دوال وحدود**

استخدم [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) أو [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) للدوال مثل `sin(x)`, `log(x)`, أو أسماء دوال مخصصة. للحدود، ضع `lim` في [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) أو استخدم [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit).

![حد x عندما يقترب x من اللانهاية](powerpoint-math-equations_8.png)

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

لإنشاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي واستدعِ [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) مع وسيطها:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **إضافة عوامل N-ary وتكاملات**

استخدم [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) للجمع، الاتحاد، التقاطع، والعوامل الكبيرة الأخرى. استخدم [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) للتكاملات. تسمح كلا الطريقتين بتعيين الحدود السفلية والعلوية.

![جمع مع حدود سفلية وعليا](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

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

العوامل N-ary مخصصة للعوامل الكبيرة مع حدود اختيارية. عادةً ما تُضاف العوامل البسيطة مثل `+`, `-`, `=` كـ [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) وتُدمج في التعبير.

للتكامل، استخدم [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

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

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) للصفوف والأعمدة. لا تشمل المصفوفات الأقواس بشكل افتراضي، لذا أغلق المصفوفة عندما تحتاج إلى أقواس أو قوسين أو أقواس معقوفة.

![مصفوفة رياضية ذات صفين وخلية فارغة واحدة](powerpoint-math-equations_10.png)

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

### **تحرير مصفوفة موجودة**

افترض أن درس الجبر الخطي يبدأ بمصفوفة المعاملات في `matrix.pptx`، التي تم حفظها بالمثال السابق. للتمرين التالي، احتفظ بالمعادلة الأولى، استبدل الثانية بمعادلتين جديدتين، وراجع مجموعة المتغيرات. افتح المصفوفة الموجودة عبر [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) للحفاظ على المعاملات التي لا تزال صالحة.

![مصفوفة معاملية ذات صفين أصلية مع القيم 1، x، وخلية فارغة في الصف الأول، وx، 2، y في الصف الثاني](matrix-before-edit.png)

تبدأ فهارس الصفوف والأعمدة من الصفر وتشير إلى المصفوفة كما هي في كل استدعاء. إدراج صف قبل الفهرس 1 يحرك الصف الأصلي الثاني إلى الفهرس 2. الإدراج بعد الفهرس 2 يضيف صفاً في النهاية. حذف الصف 2 يزيل المعادلة الأصلية الثانية ويحرك الصف المضاف إلى أعلى موضع واحد. الأعمدة تتحرك بنفس الطريقة.

```python
import jpage
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

    # الخلايا الجديدة فارغة في البداية. ضع المعاملات غير الصفرية أولاً.
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

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) يزين العمود الأول إلى اليسار. [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) يزين الأعمدة الثلاثة المتبقية إلى اليمين، بدءاً من الفهرس 1. في `updated-matrix.pptx`، تحتوي المصفوفة على ثلاث معادلات وأربعة متغيرات. تظهر معاملات الصف الأول الأصلية `1` و`x` الآن في العمودين الأول والثالث.

![مصفوفة محدثة ذات ثلاثة صفوف تُظهر الصفوف 1, 0, x, 0؛ 12, 1, 0, 0؛ و 0, 0, 10, 1](matrix-after-edit.png)

## **إضافة مصفوفات معادلات**

استخدم [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) عندما تحتاج إلى معادلات محاذاة أو مجموعة رأسية من التعبيرات.

![مصفوفة رياضية رأسية مع x فوق y](powerpoint-math-equations_11.png)

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

### **محاذاة مصفوفة مع العناصر المجاورة**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) يتحكم في محاذاة المصفوفة عمودياً بالنسبة للعناصر الرياضية المجاورة لها. يقارن المثال أدناه المحاذاة مع الصف الأول، مركز المصفوفة، والصف الأخير.

المثال التالي ينشئ ثلاث مصفوفات متطابقة، كل منها بثلاث صفوف والعناصر المجاورة `A=` و`=B`. جميع النصوص الرياضية تستخدم خط Cambria Math بحجم 24 نقطة. يتغير فقط محاذاة المصفوفة.

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

المقارنة التالية تُظهر العرض المحفوظ في PowerPoint. لاحظ موضع `A=` و`=B` بجوار كل مصفوفة.

![مصفوفات معادلات في PowerPoint مع محاذاة أعلى، وسط، وأسفل وعناصر مجاورة متطابقة](equation-array-alignment.png)

### **ضبط تباعد الصفوف**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) يحدد قاعدة التباعد للصفوف داخل المصفوفة. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) يزود قيمة عددية لقاعدة تباعد صريحة ويُهملها عندما تُستخدم القواعد المسبقة.

للتباعد الدقيق، تُقاس القيمة بالنقاط. للتباعد النسبي، تُقاس بالنصف خطوط: القيمة `3` في المثال تعني 1.5 خط. عيّن الخاصيتين معاً عندما تحدد قيمة صريحة؛ تغيير القيمة العددية وحدها لا يحدد قاعدة التباعد.

يحفظ المثال أدناه خمس عروض تقديمية بنفس المعادلات، المحاذاة، وإعدادات الخط. الثلاثة الأولى تستخدم القواعد المسبقة؛ الأخيرة تُظهر قيم صريحة.

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

تباعد صفوف المصفوفة منفصل عن تباعد الفقرات. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) و[setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) يضيفان مسافة حول الفقرة المحتوية، لا بين صفوف المصفوفة. بالمثل، [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) يحدد موضع الفقرة الرياضية بالكامل أفقياً؛ ولا يحل محل إعداد المحاذاة العمودية للمصفوفة.

## **إضافة دوال مثلثية**

استخدم [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) عندما يكون الوسيط هو العنصر الحالي ويكون اسم الدالة معروفاً.

![الدالة المثلثية cos مطبقة على 2x](powerpoint-math-equations_6.png)

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

## **إضافة مؤشرات فرعية وأساسية**

استخدم مساعدي المؤشرات الفرعية والأساسية للفهارس والقوى. عندما يجب أن تظهر المؤشرات على الجانب الأيسر من الأساس، استخدم [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![حرف Y كبير مع مؤشر فرعي 1 على اليسار ومؤشر أساسي n على اليمين](powerpoint-math-equations_9.png)

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

## **إضافة محددات**

استخدم [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) لوضع تعبير داخل محددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات محددات تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x، y، وz مفصولين بأعمدة عمودية](powerpoint-math-equations_13.png)

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

### **حجم وتنسيق المحددات**

مرّر `True` إلى [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) لجعل الأقواس تنمو حول العنصر الطويل، أو مرّر `False` لإبقائها بحجمها الطبيعي. استخدم [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) مع إحدى قيمتين من [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/). `Centered` يوسّط الأقواس على محور الرياضيات، والذي يمر عبر منتصف علامة المساواة. `Match` يطابقها مع المحتوى المغلق. كلا الإعدادين يؤثران فقط على المحددات. يبقى التعبير داخلها دون تغيير.

يضع المثال كسرًا في القوة لـ`x` بحيث يمتد التعبير أعلى من خط القاعدة أكثر من أسفله. جميع المعادلات الأربعة تستخدم نفس الأقواس وإعدادات الخط.

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

في PowerPoint، قارن الصفوف لرؤية تأثير النمو. في الصف العلوي، تنمو الأقواس لتضمّن الأس وتبدو متشابهة لكلا الشكلين. في الصف السفلي، يكون النمو معطلاً. الأقواس الأصغر على اليسار (`Centered`) تتماشى مع علامة المساواة، بينما تلك على اليمين (`Match`) تجلس أعلى حول التعبير.

![أربعة معادلات في PowerPoint مع تمكين نمو المحددات في الأعلى وتعطيله في الأسفل، وCentered على اليسار وMatch على اليمين](delimiter-sizing.png)

## **إضافة صندوق حد**

استدعِ [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) على كسر لتأطير التعبير الكامل. تُظهر [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) الأربعة جوانب بشكل افتراضي. استخدم [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop)، [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom)، [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft)، و[setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) لإزالة جوانب فردية.

يضع المثال ست نسخ من نفس الكسر على شريحة واحدة. لإظهار الإلغاء، أخفِ جميع الجوانب الأربعة ومرّر `True` إلى [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) لخط مائل تصاعدي (↗) أو [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) لخط مائل تنازلي (↘). يمكنك أيضًا استخدام [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) أو [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) مع أي توليفة من الجوانب الظاهرة.

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

![ستة كسور قابلة للتحرير في PowerPoint. الصف العلوي: حد كامل، جوانب سفلية ويسرى، خط مائل تصاعدي. الصف السفلي: خط مائل تنازلي، خط أفقي، خط عمودي مع حد كامل](border-box-fractions.png)

على هذا الكسر، يتقاطع الخط الأفقي مع شريط الكسر. يتقاطع الخط العمودي مع كل من البسط والمقام بينما يظل الحد المحيط مرئياً. تُزين هذه الخطوط التعبير كاملًا. يُطبق خط الشطب العادي على الأحرف داخل تشغيل نص. بعد إعادة فتح العرض في PowerPoint، يمكنك ما زال تعديل البسط والمقام بشكل مستقل.

## **التحكم في الرؤية والتخطيط باستخدام عناصر شبحية**

احطِ التعبير داخل [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) للتحكم في رؤيته والمساحة التي يساهم بها في المعادلة بشكل مستقل. تُتحكم طرق [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) في ما يلي:

| الطريقة | التأثير |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | مرّر `False` لإخفاء التعبير. لا تزال أبعاده تُساهم في التخطيط ما لم تستقبل الطرق المقابلة أدناه `True`. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | اعتبر عرض التعبير الأفقي صفرًا، مما يسمح للعناصر المجاورة بالاقتراب. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | اعتبر ارتفاعه الأعلى (الارتفاع فوق الخط الأساسي) صفرًا. يمكن أن يُقلل ذلك المسافة المخصصة فوق العناصر المجاورة. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | اعتبر انخفاضه (العمق تحت الخط الأساسي) صفرًا. يمكن أن يقترب شريط الكسر أو محتوى آخر أسفل التعبير من جيرانه. |

الخط الأساسي هو الخط المرجعي الذي تقف عليه الحروف الرياضية العادية. إخفاء المحتوى لا يزيل أبعاده، ومعالجة البعد كصفر لا تحذف التعبير. يظل التعبير الأساسي متاحًا عبر [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase). مرّر `True` إلى [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) لإظهاره مرة أخرى؛ تبقى إعدادات الأبعاد دون تغيير.

يُنشئ المثال أدناه خمس متغيرات جنبًا إلى جنب: كسر مرئي، كسر مخفي يحتفظ بالمسافة، وثلاثة أكسرات مخفية مع معالجة بعد واحد كصفر. كل متغير يستخدم نفس التعبير المحيط وخط Cambria Math بحجم 24 نقطة. جميع أشكال المعادلة لها نفس الموضع العلوي، مميزًا بخط دليل رمادي. وضع الشبح في بسط كسر خارجي يجعل تغييرات التخطيط العمودي أسهل في الملاحظة.

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

![خمسة معادلات في PowerPoint تُقارن كسرًا مرئيًا، كسرًا مخفيًا يحتفظ بالمسافة، وأكسرات مخفية مع تمكين ZeroWidth أو ZeroAsc أو ZeroDesc](math-phantom.png)

## **تجميع المصطلحات**

استخدم [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) لوضع حرف تجميع فوق أو تحت تعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![التعبير x + y مجمع مع تسمية أي نص تحته](powerpoint-math-equations_15.png)

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

## **تنسيق عناصر الرياضيات**

استخدم مُساعدي التنسيق فقط حيث يوضح الصيغة. على سبيل المثال، [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) يضع شريطًا فوق عنصر رياضي.

![تعبير رياضي ABC مع شريط فوقه](powerpoint-math-equations_14.png)

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

### **تنسيق النص في معادلة موجودة**

لتنسيق النص في جميع أجزاء المعادلة الموجودة، تجول في شجرة عناصر كل كتلة رياضية. تُعيد [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) الأطفال المباشرين فقط، لذا استدعها بصورة متكررة للوصول إلى النص داخل الكسور، الأسس، الجذور، والهياكل المتداخلة الأخرى. افحص العنصر الحالي وكذلك أطفاله لتشمل العنصر الابتدائي عندما يكون [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/).

يفترض هذا المثال أن `input.pptx` يحتوي على معادلة مثل `z = xᵢ / ∛y`، مع كسر يحتوي على مؤشر فرعي في البسط وجذر في المقام. معالجة العناصر العليا للكتلة فقط سيفوت النص داخل الكسر. يعثر المثال على الأجزاء الرياضية في إطارات نص الشرائح، يَدخل إلى كتلها عبر [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph)، ويستخدم [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) لتعيين حجم الخط إلى 28 نقطة عبر طريقة [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) لكل عنصر نصي.

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

العرض المحفوظ يحتوي على تنسيق النص المحدث في كل مستوى من كل معادلة معالجة، مع الحفاظ على محتوى النص والبنية الرياضية.

## **مرجع سريع**

| المهمة | API الرئيسي |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| دمج العناصر | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| إنشاء كسور | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| إضافة أسس أو مؤشرات فرعية | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| إضافة دوال | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| إضافة جذور | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| إضافة حدود | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| إضافة مؤشرات على اليسار | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| إضافة مجموعات وتكاملات | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| إضافة مصفوفات معادلات | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| إضافة أشرطة وحدود | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **الأسئلة المتكررة**

**هل يمكن تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض، اعثر على الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/)، استدعِ [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph)، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف إلى PPTX، يكتب Aspose.Slides المعادلة كق content رياضي Office قابل للتحرير.

**هل يمكن تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) للمعادلة من [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/)، واستدعِ [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) لتصديره مباشرة. لمثال كامل، راجع [Export Math Equations from Presentations in Python](/slides/ar/python-java/exporting-math-equations/#export-math-equations-to-latex).