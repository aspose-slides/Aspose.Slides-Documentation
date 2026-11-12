---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية في Python
linktitle: معادلات رياضية PowerPoint
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
description: "إدراج وتحرير المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides للغة Python عبر .NET، مع دعم OMML، أدوات تنسيق، وعينات شفرة Python واضحة."
---
## **نظرة عامّة**

PowerPoint يخزن المعادلات بصيغة Office Math Markup Language (OMML). باستخدام Aspose.Slides for Python عبر .NET، يمكنك إنشاء نفس نوع المحتوى الرياضي برمجياً: الكسور، الجذور، الدوال، الحدود، المشغلات المتعددة (N-ary)، المصفوفات، المصفوفات المتراصة، وكتل الرياضيات المنسقة.

في PowerPoint، عادةً ما يضيف المستخدمون المعادلات من **Insert > Equation**:

![علامة تبويب Insert في PowerPoint مع تحديد أمر Equation](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

يبني Aspose.Slides ذلك النص الرياضي عبر ثلاثة كائنات رئيسية:

- شكل رياضي، يتم إنشاؤه باستخدام [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), هو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) يخزن المحتوى الرياضي داخل إطار النص بالشكل.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) يحتوي على كائن (أو أكثر) من نوع [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

تستخدم معظم الأمثلة أدناه [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) والطرق المتسلسلة من [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) للحفاظ على قصر الكود وقراءته.

للحالات التي تحتاج إلى تصدير MathML، راجع [تصدير المعادلات الرياضية من العروض التقديمية في Python عبر .NET](/slides/ar/python-net/exporting-math-equations/).

## **إنشاء معادلة**

يستخدم هذا المثال [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) لإنشاء شكل رياضي ويضيف نظرية فيثاغورس:

![المعادلة c² = a² + b²](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) ينشئ شكلاً يحتوي مسبقًا على فقرة رياضية. احصل على أول [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، ثم على [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)، وأضف كتل رياضية أو عناصر رياضية إليه.
{{% /alert %}}

## **إضافة كسور**

استخدم [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![كسر رياضي مائل يُظهر واحد مقسومًا على x](powerpoint-math-equations_4.png)

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

لإنشاء كسر مكدس، استخدم [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **إضافة جذر**

استخدم [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) لإنشاء جذر تربيعي، جذر تكعيبي، أو جذر آخر. العنصر الحالي يصبح القاعدة، والوسيط يصبح الدرجة.

![تعبير جذر n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

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

## **إضافة دوال وحدود**

استخدم [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) أو [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) للدوال مثل `sin(x)`, `log(x)`, أو أسماء دوال مخصصة. للحدود، ضع `lim` في [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) أو استخدم [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![حد x عندما يقترب x إلى اللانهاية](powerpoint-math-equations_8.png)

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

لإسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي واستدعِ [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) مع وسيطه:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **إضافة المشغلات المتعددة والتكاملات**

استخدم [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) للجمعيات، الاتحاد، التقاطع، وغيرها من المشغلات الكبيرة. استخدم [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) للتكاملات. كلا الطريقتين تسمح لك بتحديد الحدود السفلية والعلوية.

![جمع بحدود سفلية وعليا](powerpoint-math-equations_7.png)

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

المشغلات المتعددة مخصصة للمشغلات الكبيرة مع حدود اختيارية. المشغلات البسيطة مثل `+`, `-`, و `=` عادةً ما تُضاف كـ[MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) وتُدمج في التعبير.

لإنشاء تكامل، استخدم [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تتضمن الأقواس بشكل افتراضي، لذا قم بإحاطة المصفوفة عندما تحتاج إلى أقواس، مربعات، أو أقواس معقوفة.

![مصفوفة رياضية ذات صفين وخلية واحدة فارغة](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # المصفوفة لا تحتوي على أقواس خاصة بها، لذا أُحِطها بأقواس.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` يبني شبكة الصفوف والأعمدة، يحدد الفجوات بينها، ويوازن الأعمدة، ولكن Aspose.Slides for Python عبر .NET لا يتيح مُعرفًا للوصول إلى خلية مفردة في المصفوفة. لذلك تبقى الخلايا الفارغة في المصفوفة التي تم إنشاؤها برمجيًا؛ يمكن قراءة خلايا مصفوفة موجودة في عرض تقديمي باستخدام `get_children`. استخدم مصفوفة معادلات عندما تحتاج إلى ملء الصفوف من الشيفرة.
{{% /alert %}}

## **إضافة مصفوفات معادلات**

استخدم [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) عندما تحتاج إلى معادلات مُحاذاة أو رص عمودي للتعبيرات.

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

### **محاذاة مصفوفة مع العناصر المحيطة**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) يتحكم في محاذاة المصفوفة عموديًا بالنسبة للعناصر الرياضية المجاورة لها. المثال أدناه يقارن المحاذاة مع الصف الأول، وسط المصفوفة، والصف الأخير.

المثال التالي ينشئ ثلاث مصفوفات متطابقة، كل واحدة بـثلاث صفوف والعنصران المجاوران `A=` و `=B`. كل النص الرياضي يستخدم Cambria Math بحجم 24 نقطة. فقط محاذاة المصفوبة هي المتغيرة.

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

المقارنة التالية تُظهر العرض المحفوظ في PowerPoint. لاحظ موقع `A=` و `=B` بجانب كل مصفوفة.

![مصفوفات المعادلات في PowerPoint مع محاذاة أعلى، وسط، وأسفل وعناصر مجاورة متطابقة](equation-array-alignment.png)

### **تكوين تباعد الصفوف**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) يختار قاعدة التباعد للصفوف داخل المصفوفة. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) يقدم قيمة رقمية لقاعدة تباعد صريحة ويتم تجاهلها من قبل القواعد المسبقة.

للتباعد الدقيق، تُقاس القيمة بالنقاط. للتباعد النسبي، تُقاس بنصف السطور: القيمة `3` في المثال تمثل 1.5 سطر. اضبط الخصيتين معًا عند تحديد قيمة صريحة؛ تغيير القيمة الرقمية فقط لا يختار قاعدة تباعد.

تباعد صفوف المصفوفة منفصل عن تباعد الفقرة. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) و[space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) يضيفان مساحة حول الفقرة الحاوية، وليس بين صفوف المصفوفة. وبالمثل، [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) يموضع الفقرة الرياضية بأكملها أفقيًا؛ ولا يستبدل إعداد المحاذاة العمودية للمصفوفة.

المثال أدناه يحفظ خمسة عروض تقديمية بنفس المعادلات، والمحاذاة، وإعدادات الخط. الثلاثة الأولى تستخدم القوالب المسبقة؛ الأخيرة تُظهر قيمًا صريحة.

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

## **إضافة دوال مثلثية**

استخدم [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) عندما يكون الوسيط هو العنصر الحالي وتكون اسم الدالة معروفًا.

![دالة المثلثية cos مطبقة على 2x](powerpoint-math-equations_6.png)

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

## **إضافة موشرات سفلى وعليا**

استخدم المساعدات الخاصة بالموشرات السفلية والعليا للفهارس والقوى. عندما يجب أن تظهر الفهارس على الجانب الأيسر من القاعدة، استخدم [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![حرف Y كبير مع موشر سفلي 1 وموشر علوي n على الجانب الأيسر](powerpoint-math-equations_9.png)

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

استخدم [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) لوضع تعبير داخل محددات. يمكنك أيضًا تحديد حرف فاصل لتعبيرات المحددات التي تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x، y، و z مفصولين بأعمدة رأسية](powerpoint-math-equations_13.png)

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

### **حجم ومحاذاة المحددات**

اضبط [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) إلى `True` لتمكين الأقواس من التوسع حول عامل عالي، أو إلى `False` للحفاظ على حجمها الطبيعي. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) يأخذ إحدى قيمتي [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/). `CENTERED` يوسّط الأقواس على محور الرياضيات، الذي يمر عبر منتصف علامة التساوي. `MATCH` يطابقها مع المحتوى المحاط. كلا الإعدادين يؤثران فقط على المحددات. يبقى التعبير الداخلي كما هو.

يوضع المثال كسرًا في أس `x` بحيث يمتد التعبير أعلى من الخط الأساسي أكثر مما يمتد أسفله. جميع المعادلات الأربعة تستخدم نفس الأقواس وإعدادات الخط.

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

في PowerPoint، قارن الصفوف لملاحظة تأثير التوسع. في الصف العلوي، تتوسع الأقواس لتضمّن الأس وتظهر متشابهة لكلا الشكلين. في الصف السفلي، تم إيقاف التوسع. الأقواس الأصغر على اليسار (`CENTERED`) تتماشى مع علامة التساوي، بينما الأقواس على اليمين (`MATCH`) تُعلّق أعلى حول التعبير.

![أربع معادلات في PowerPoint مع تمكين نمو المحددات أعلاه وتعطيله أدناه، وCENTERED على اليسار وMATCH على اليمين](delimiter-sizing.png)

## **إضافة صندوق حد**

استدعِ [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) على كسر لتأطير التعبير بالكامل. يُظهر [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) المُعاد جميع الجوانب الأربعة افتراضيًا. استخدم [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), و[hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) لإزالة جوانب فردية.

يوضع المثال ست نسخ من نفس الكسر على شريحة واحدة. لإظهار الإلغاء، أخفِ جميع الجوانب الأربعة واضبط [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) لخط قطري صاعد (↗) أو [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) لخط قطري هابط (↘). يمكنك أيضًا استخدام [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) أو [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) مع أي تركيبة من الجوانب الظاهرية.

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

![ستة كسور قابلة للتحرير في PowerPoint. الصف العلوي: حد كامل، الجانبين السفلي واليسار، خط قطري صاعد. الصف السفلي: خط قطري هابط، شطب أفقي، شطب عمودي مع حد كامل.](border-box-fractions.png)

في هذا الكسر، يتقاطع الشطب الأفقي مع شريط الكسر. الشطب العمودي يعبر بين البسط والمقام بينما يبقى الحد المحيط مرئيًا. هذه الخطوط تُزيّن التعبير بأكمله. شطب النص العادي يطبق على الأحرف في مقطع النص. بعد إعادة فتح العرض في PowerPoint، لا يزال بإمكانك تحرير البسط والمقام بشكل مستقل.

## **تجميع المصطلحات**

استخدم [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) لوضع حرف تجميع فوق أو تحت تعبير. أضف حدًا لتسمية المصطلحات المجمعّة.

![التعبير x + y مُجّمّع مع تسمية أي نص تحته](powerpoint-math-equations_15.png)

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

استخدم مساعدات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) يضع شريطًا فوق عنصر رياضي.

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

لتنسيق النص عبر معادلة موجودة، تجول في شجرة عناصر كل كتلة رياضية. [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) تُرجع فقط الأطفال المباشرين، لذا استدعِها بشكل تكراري للوصول إلى النص داخل الكسور، المقامات، الجذور، وغيرها من البُنى المتداخلة. تحقق من العنصر الحالي وكذلك من أطفاله لتضمين العنصر الابتدائي عندما يكون [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

يفترض هذا المثال أن الملف `input.pptx` يحتوي على معادلة مثل `z = xᵢ / ∛y`، مع كسر يحتوي على موشر سفلي في البسط وجذر في المقام. معالجة العناصر العليا للكتلة فقط سيفوت النص داخل الكسر. يَبحث المثال عن أجزاء رياضية في إطارات نص الشرائح، ويصل إلى كتلها عبر [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)، ويضبط [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) إلى 28 نقطة عبر خاصية [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) لكل عنصر نصي.

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

العرض المحفوظ يحتوي على تنسيق النص المحدث في كل مستوى من كل معادلة تمت معالجتها، مع الحفاظ على محتوى النص وبنيته الرياضية.

## **مرجع سريع**

| المهمة | واجهة برمجة التطبيقات الأساسية |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| دمج العناصر | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| إنشاء كسور | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| إضافة أس علوي أو أس سفلي | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| إضافة دوال | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| إضافة جذور | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| إضافة حدود | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| إضافة مؤشرات على الجانب الأيسر | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| إضافة جمعيات وتكاملات | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| إضافة مصفوفات معادلات | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| إضافة أشرطة وإطارات | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| تجميع مصطلحات | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **الأسئلة المتكررة**

**هل يمكنني تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض، وابحث عن الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), احصل على [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند الحفظ إلى PPTX، يقوم Aspose.Slides بكتابة المعادلة كقcontent رياضي Office قابل للتحرير.

**هل أستطيع تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) للمعادلة من [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), ثم استدعِ [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) لتصديره مباشرة. للحصول على مثال كامل، راجع [تصدير المعادلات الرياضية من العروض التقديمية في Python عبر .NET](/slides/ar/python-net/exporting-math-equations/#export-math-equations-to-latex).