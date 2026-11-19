---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية باستخدام بايثون
linktitle: معادلات رياضية في PowerPoint
type: docs
weight: 80
url: /ar/python-net/powerpoint-math-equations/
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
- Aspose.Slides
description: "إدراج وتحرير المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides لبايثون عبر .NET، مع دعم OMML، التحكم بالتنسيق، وعينات شفرة بايثون واضحة."
---
## **نظرة عامة**

يخزن PowerPoint المعادلات بصيغة Office Math Markup Language (OMML). باستخدام Aspose.Slides لبايثون عبر .NET، يمكنك إنشاء نفس نوع المحتوى الرياضي برمجياً: الكسور، الجذور، الدوال، الحدود، عمليات N-ary، المصفوفات، المصفوفات المتعددة، وكتل الرياضيات المنسقة.

في PowerPoint، يضيف المستخدمون عادة المعادلات من **إدراج > معادلة**:

![علامة تبويب إدراج في PowerPoint مع أمر المعادلة محدد](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي عبر ثلاث كائنات رئيسية:

- شكل رياضي، يُنشأ باستخدام [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/)، هو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) يخزن المحتوى الرياضي داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) يحتوي على عنصر (أو أكثر) من نوع [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

تستخدم معظم الأمثلة أدناه [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) والطرق المتسلسلة من [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) للحفاظ على الكود قصيرًا وسهل القراءة.

للحالات التي تتطلب تصدير MathML، انظر [تصدير معادلات رياضية من العروض التقديمية في بايثون عبر .NET](/slides/ar/python-net/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال يستخدم [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) لإنشاء شكل رياضي ويضيف مبرهنة فيثاغورس:

![المعادلة c تربيع تساوي a تربيع زائد b تربيع](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) ينشئ شكلاً يحتوي مسبقًا على فقرة رياضية. احصل على أول [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، استخرج [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) الخاص به، وأضف كتل رياضية أو عناصر رياضية إليه.
{{% /alert %}}

### **دمج كتل الرياضيات**

عندما يتم بناء أجزاء من معادلة بشكل مستقل ككائنات [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)، استخدم [join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) لدمجها. يبني المثال `c² =` في الكتلة اليسرى و `a² + b²` في الكتلة اليمنى. [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/) ينشئ مرتفعات رياضية قابلة للتحرير لجميع القوى الثلاث.

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

[join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) يرجع `left_block` نفسه، الذي يحتوي الآن على الجزأين بالترتيب، ويترك `right_block` فارغًا. أضف الكتلة المدمجة إلى [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) مرة واحدة فقط. بعد إعادة فتح `equation.pptx`، يحتوي الفقرة على كتلة واحدة تمثل `c² = a² + b²`، مع الحفاظ على جميع المرتفعات الثلاثة كمرتفع رياضي.

استدعاء [add](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/add/) كـ `left_block.add(right_block)` تحاول بدلاً من ذلك تضمين كتلة داخل أخرى مباشرةً وتثير `RuntimeError` يغلف استثناء .NET `InvalidOperationException`.

## **إضافة كسور**

استخدم [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![كسر رياضي مائل يظهر 1 مقسومًا على x](powerpoint-math-equations_4.png)

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

للكسور المتراصة، استخدم [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **إضافة جذور**

استخدم [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) لإنشاء جذر تربيعي، جذر مكعب، أو جذر آخر. يصبح العنصر الحالي هو القاعدة، ويصبح الوسيط هو الدرجة.

![تعبير جذري من الدرجة n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

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

### **إظهار أو إخفاء درجة الجذر التربيعي**

يمكن للجذر التربيعي أن يعرض رقم 2 صريحًا أو يستخدم التدوين التقليدي √x. تتحكم خاصية [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) في [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) في الشكل الذي يظهر. يحتفظ كلا الشكلين بالدرجة 2 والقاعدية x في المعادلة القابلة للتحرير.

![الجذر التربيعي لـ x مع الدرجة 2 مرئية على اليسار ومخفية على اليمين](square-root-degree.png)

يقوم المثال بحفظ نفس الجذر مرتين. تكون الـ 2 مرئية في `visible-degree.pptx` ومخفية في `hidden-degree.pptx`.

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

## **إضافة دوال وحدود**

استخدم [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) أو [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) للدوال مثل `sin(x)`, `log(x)`, أو أسماء دوال مخصصة. للحدود، ضع `lim` في [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) أو استخدم [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/).

![حد x عندما يقترب x من اللانهاية](powerpoint-math-equations_8.png)

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

لإعطاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي واستدعِ [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) مع وسيله:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **إضافة عوامل N-ary وتكاملات**

استخدم [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) للجمع، الاتحاد، التقاطع، وغيرها من العوامل الكبيرة. استخدم [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) للتكاملات. كلا الطريقتين تسمحان بتعيين حدود دنيا وعليا.

![جمع مع حدود دنيا وعليا](powerpoint-math-equations_7.png)

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

العوامل N-ary مخصصة للعمليات الكبيرة مع حدود اختيارية. عادةً ما تُضاف العوامل البسيطة مثل `+`، `-`، و `=` كـ [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) وتُدمج في التعبير.

للتكامل، استخدم [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تشمل الأقواس بشكل افتراضي، لذا أغلق المصفوفة عندما تحتاج إلى أقواس أو أقواس مربعة أو معقوفة.

![مصفوفة رياضية من صفين تحتوي على خلية فارغة واحدة](powerpoint-math-equations_10.png)

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

### **تحرير مصفوفة موجودة**

افترض أن درس الجبر الخطي يبدأ بمصفوفة المعاملات في `matrix.pptx`، التي حفظها المثال السابق. للتمرين التالي، احتفظ بالمعادلة الأولى، استبدل الثانية بمعادلتين جديدتين، وعدّل مجموعة المتغيرات. احصل على المصفوفة الحالية كـ [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) للحفاظ على المعاملات التي لا تزال صالحة.

![مصفوفة معاملية أصلية من صفين مع القيم 1، x، وخلية فارغة في الصف الأول، و x، 2، y في الصف الثاني](matrix-before-edit.png)

تبدأ مؤشرات الصف والعمود من الصفر وتشير إلى المصفوفة كما هي عند كل استدعاء. إدراج صف قبل الفهرس 1 ينقل الصف الثاني الأصلي إلى الفهرس 2. الإدراج بعد الفهرس 2 يضيف صفًا. حذف الصف 2 يزيل المعادلة الثانية الأصلية ويحرك الصف المضاف لأعلى موضعًا واحدًا. الأعمدة تتحرك بنفس الطريقة.

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

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) يضبط العمود الأول إلى اليسار. [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) يضبط ثلاثة أعمدة متتالية إلى اليمين، بدءًا من الفهرس 1. في `updated-matrix.pptx`، تحتوي المصفوفة على ثلاث معادلات وأربعة متغيرات. الآن تظهر المعاملات الأصلية للصف الأول `1` و `x` في العمود الأول والثالث.

![مصفوفة محدثة من ثلاثة صفوف تظهر الصفوف 1, 0, x, 0؛ 12, 1, 0, 0؛ و 0, 0, 10, 1](matrix-after-edit.png)

## **إضافة مصفوفات معادلات**

استخدم [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) عندما تحتاج إلى معادلات محاذاة أو مجموعة رأسية من التعبيرات.

![مصفوفة رياضية عمودية مع x فوق y](powerpoint-math-equations_11.png)

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

### **محاذاة مصفوفة مع العناصر المجاورة**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) يتحكم في محاذاة المصفوفة عموديًا بالنسبة للعناصر الرياضية بجانبها. يقارن المثال أدناه المحاذاة مع الصف الأول، وسطر وسط المصفوفة، والصف الأخير.

تنشئ المثال التالي ثلاث مصفوفات متطابقة، كل واحدة بثلاث صفوف والعناصر المجاورة `A=` و `=B`. جميع النصوص الرياضية تستخدم خط Cambria Math بحجم 24 نقطة. يتغير فقط محاذاة المصفوفة.

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

المقارنة التالية تُظهر العرض المحفوظ في PowerPoint. لاحظ موضع `A=` و `=B` بجانب كل مصفوفة.

![مصفوفات المعادلات في PowerPoint مع محاذاة أعلى، وسط، وأسفل وعناصر مجاورة متطابقة](equation-array-alignment.png)

### **تكوين تباعد الصفوف**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) يحدد قاعدة التباعد للصفوف داخل المصفوفة. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) يزود قيمة عددية لقاعدة تباعد صريحة ويُهمل بواسطة القواعد المسبقة.

للتباعد الدقيق، تُقاس القيمة بالنقاط. للتباعد النسبي، تُقاس بنصف أسطر: القيمة `3` في المثال تُحدد 1.5 سطر. عيّن كلتا الخاصيتين عند تحديد قيمة صريحة؛ تغيير القيمة العددية وحدها لا يختار قاعدة تباعد.

يحفظ المثال أدناه خمس عروض تقديمية بنفس المعادلات، والمحاذاة، وإعدادات الخط. الثلاثة الأولى تستخدم إعدادات مسبقة؛ الأخيرة تُظهر قيمًا صريحة.

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

تباعد صفوف المصفوفة منفصل عن تباعد الفقرة. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) و [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) يضيفان مسافة حول الفقرة المحتوية، وليس بين صفوف المصفوفة. بالمثل، [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) يحدد موضع الفقرة الرياضية كاملةً أفقياً؛ ولا يستبدل إعداد المحاذاة العمودية للمصفوفة.

## **إضافة دوال مثلثية**

استخدم [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) عندما يكون الوسيط هو العنصر الحالي ويُعرف اسم الدالة.

![دالة المثلثات cos مطبقة على 2x](powerpoint-math-equations_6.png)

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

## **إضافة مؤشرات ومرتفع**

استخدم مساعدات المؤشر والمرتفع للمؤشرات والقوى. عندما يجب أن تظهر المؤشرات على الجانب الأيسر للقاعدة، استخدم [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/).

![حرف Y كبير مع مؤشر 1 على الجانب الأيسر ومرتفع n](powerpoint-math-equations_9.png)

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

## **إضافة محددات**

استخدم [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) لوضع تعبير داخل محددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات المحدد التي تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x و y و z مفصولة بأشرطة عمودية](powerpoint-math-equations_13.png)

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

### **حجم وتحديد موضع المحددات**

اضبط [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) إلى `True` لتسمح للأقواس بالنمو حول قيمة طويلة، أو إلى `False` لإبقائها بحجمها الطبيعي. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) يأخذ إحدى قيمتي [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/). `CENTERED` يوسط الأقواس على محور الرياضيات، الذي يمر عبر منتصف علامة المساواة. `MATCH` يطابقها مع المحتوى المُحاط. كل الإعدادات تؤثر فقط على المحددات. يبقى التعبير الداخلي كما هو.

يضع المثال كسرًا في أسـ`x` بحيث يمتد التعبير أعلى من الخط الأساسي أكثر من أسفله. جميع المعادلات الأربع تستخدم نفس الأقواس وإعدادات الخط.

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

في PowerPoint، قارن الصفوف لترى تأثير النمو. في الصف العلوي، تنمو الأقواس لتضمّن الأس وتظهر متشابهة لكلا الشكلين. في الصف السفلي، يكون النمو معطلاً. الأقواس الأصغر على اليسار (`CENTERED`) تُحاذى مع علامة المساواة، بينما تلك على اليمين (`MATCH`) تُوضع أعلى حول التعبير.

![أربعة معادلات في PowerPoint مع تمكين نمو المحددات في الأعلى وتعطيله في الأسفل، وCENTERED على اليسار وMATCH على اليمين](delimiter-sizing.png)

## **إضافة إطار حدود**

استدعِ [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) على كسر لتأطير التعبير كله. يُظهر [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) المُعاد جميع الجوانب الأربعة افتراضيًا. استخدم [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/)، [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/)، [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/)، و [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/) لإزالة جوانب فردية.

يضع المثال ست نسخ من نفس الكسر على شريحة واحدة. لإظهار الإلغاء، أخفِ جميع الجوانب الأربعة واضبط [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) لخط قطري صاعد (↗) أو [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) لخط قطري هابط (↘). يمكنك أيضًا استخدام [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) أو [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) مع أي تركيبة من الجوانب الظاهرة.

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

![ستة كسور قابلة للتحرير في PowerPoint. الصف العلوي: حدود كاملة، الجانب السفلي واليسار، قطري صاعد. الصف السفلي: قطري هابط، شطب أفقي، شطب عمودي مع حدود كاملة](border-box-fractions.png)

في هذا الكسر، يتقاطع الشطب الأفقي مع شريط الكسر. الشطب العمودي يقطع البسط والمقام مع بقاء الحد الخارجي مرئيًا. هذه الخطوط تزيّن التعبير كله. الشطب النصي العادي يُطبق على الأحرف داخل وحدة نصية. بعد إعادة فتح العرض في PowerPoint، لا يزال بإمكانك تحرير البسط والمقام بشكل مستقل.

## **التحكم في الرؤية والتخطيط باستخدام عناصر Phantom**

لفّ تعبير داخل [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) للتحكم في رؤيته والمساحة التي يضيفها إلى المعادلة بشكل مستقل. تتحكم خصائصه في ما يلي:

| الخاصية | التأثير |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | اضبط إلى `False` لإخفاء التعبير. لا تزال أبعاده تُساهم في التخطيط ما لم تُضبط الخصائص المقابلة أدناه إلى `True`. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | عالج عرض التعبير الأفقي كصفر، مما يسمح للعناصر المجاورة بالاقتراب. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | عالج الارتفاع فوق الخط الأساسي كصفر. يمكن أن يقلل هذا من المسافة المخصصة فوق العناصر المجاورة. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | عالج العمق تحت الخط الأساسي كصفر. يمكن أن يقترب شريط الكسر أو محتوى آخر أسفل التعبير من جيرانه. |

الخط الأساسي هو الخط المرجعي الذي تجلس عليه الأحرف الرياضية العادية. إخفاء المحتوى لا يزيل أبعاده، ومعاملة البعد كصفر لا تحذف التعبير. يبقى التعبير الأساسي متاحًا عبر [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/). اضبط [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) مرة أخرى إلى `True` لإظهاره مرة أخرى؛ تظل إعدادات الأبعاد كما هي.

يخلق المثال أدناه خمسة متغيّرات جنبًا إلى جنب: كسر مرئي، كسر مخفي يحجز مساحة، وثلاثة كسور مخفية مع معالجة بُعد واحد كصفر. كل متغيّر يستخدم نفس التعبير المحيط وخط Cambria Math بحجم 24 نقطة. جميع أشكال المعادلة لها نفس موضع القمة، محددة بالدليل الرمادي. وضع الـ phantom في بسط كسر خارجي يجعل تغييرات التخطيط العمودي أكثر وضوحًا.

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

![خمس معادلات في PowerPoint تقارن كسرًا مرئيًا، كسرًا مخفيًا يحجز مساحة، وكسرًا مخفيًا مع تمكين ZeroWidth أو ZeroAsc أو ZeroDesc](math-phantom.png)

## **تجميع المصطلحات**

استخدم [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) لوضع حرف تجميع فوق أو تحت تعبير. أضف حدًا لتسمية المصطلحات المُجمعة.

![التعبير x زائد y مُجمَّع مع التسمية أي نص تحته](powerpoint-math-equations_15.png)

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

## **تنسيق عناصر الرياضيات**

استخدم مساعدات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) يضع شريطًا فوق عنصر رياضي.

![تعبير رياضي ABC مع شريط فوقه](powerpoint-math-equations_14.png)

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

### **تنسيق النص في معادلة موجودة**

لتنسيق النص في جميع أنحاء معادلة موجودة، استعرض شجرة العناصر لكل كتلة رياضية. [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) يُعيد فقط الأطفال المباشرين، لذا استدعِه بصورة متكررة للوصول إلى النص داخل الكسور، والسكريبتات، والجذور، والهياكل المتداخلة الأخرى. افحص العنصر الحالي وكذلك أطفاله لتضمين العنصر الابتدائي عندما يكون [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

يفترض هذا المثال أن `input.pptx` يحتوي على معادلة مثل `z = xᵢ / ∛y`، مع كسر يحتوي على مؤشر في البسط وجذر في المقام. معالجة العناصر ذات المستوى العلوي فقط ستفقد النص داخل الكسر. يجد المثال الأجزاء الرياضية في إطارات نص الشرائح، ويصل إلى كتلها عبر [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)، ويضبط [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) إلى 28 نقطة عبر خاصية [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) لكل عنصر نصي.

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

العرض المحفوظ يحتوي على تنسيق النص المحدث في كل مستوى من كل معادلة معالجة، مع الحفاظ على محتوى النص والبنية الرياضية.

## **مرجع سريع**

| المهمة | الواجهة البرمجية الرئيسية |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| دمج العناصر | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| إنشاء كسور | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| إضافة مرتفع أو مؤشر | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| إضافة دوال | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| إضافة جذور | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| إضافة حدود | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| إضافة مؤشرات على الجانب الأيسر | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| إضافة جمع وتكاملات | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| إضافة مصفوفات معادلات | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| إضافة أشرطة وإطارات | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **الأسئلة المتكررة**

**هل يمكنني تحرير معادلة PowerPoint موجودة؟**

نعم. افتح العرض، ابحث عن الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، احصل على [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)، وقم بتحديث كتل الرياضيات في ذلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند الحفظ إلى PPTX، يقوم Aspose.Slides بكتابة المعادلة كمحتوى Office Math قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) للمعادلة من [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، واستدعِ [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) لتصديره مباشرةً. لمثال كامل، انظر [تصدير معادلات رياضية من العروض التقديمية في بايثون عبر .NET](/slides/ar/python-net/exporting-math-equations/#export-math-equations-to-latex).