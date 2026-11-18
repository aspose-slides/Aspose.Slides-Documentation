---
title: إضافة معادلات رياضية إلى عروض PowerPoint في Python
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
description: "إدراج وتحرير المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides لـ Python عبر .NET، مع دعم OMML، وضوابط تنسيق، وأمثلة شفرة Python واضحة."
---
## **نظرة عامة**

يخزن PowerPoint المعادلات بصيغة Office Math Markup Language (OMML). باستخدام Aspose.Slides لـ Python عبر .NET، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجيًا: الكسور، الجذور، الدوال، الحدود، المشغلات N-ary، المصفوفات، المصفوفات المتعددة، وكتل الرياضيات المنسقة.

في PowerPoint، يضيف المستخدمون عادة المعادلات من **Insert > Equation**:

![علامة تبويب Insert في PowerPoint مع تحديد أمر Equation](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

يبني Aspose.Slides ذلك النص الرياضي عبر ثلاث كائنات رئيسية:

- شكل رياضي، يُنشأ باستخدام [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/)، هو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) يُخزّن محتوى الرياضيات داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) يحتوي على كائن واحد أو أكثر من [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

تستخدم معظم الأمثلة أدناه [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) والطرق السلسة من [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) لجعل الكود قصيرًا وقابلًا للقراءة.

للحالات التي تحتاج إلى تصدير MathML، راجع [Export Math Equations from Presentations in Python via .NET](/slides/ar/python-net/exporting-math-equations/).

## **إنشاء معادلة**

يستخدم هذا المثال [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) لإنشاء شكل رياضي ويضيف مبرهنة فيثاغورس:

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) يُنشئ شكلاً يحتوي مسبقًا على فقرة رياضية. يمكن الوصول إلى أول [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، الحصول على [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)، وإضافة كتل رياضية أو عناصر رياضية إليها.
{{% /alert %}}

## **إضافة كسور**

استخدم [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![كسر مائل يُظهر 1 ÷ x](powerpoint-math-equations_4.png)

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

## **إضافة جذور**

استخدم [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) لإنشاء جذر تربيعي أو جذر مكعب أو أي جذر آخر. العنصر الحالي يصبح القاعدة، والحجة تصبح الدرجة.

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

يمكن للجذر التربيعي إظهار رقم 2 صراحةً أو استخدام الصيغة التقليدية √x. تتحكم الخاصية [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathradical/hide_degree/) في فئة [IMathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathradical/) في أي شكل سيظهر. كلا الشكلين يحتفظان بالدرجة 2 والقاعدة x في المعادلة القابلة للتحرير.

![جذر تربيعي لـ x مع إظهار الدرجة 2 على اليسار وإخفائها على اليمين](square-root-degree.png)

يحفظ المثال الجذر التربيعي نفسه مرتين. يكون الرقم 2 مرئيًا في `visible-degree.pptx` ومخفيًا في `hidden-degree.pptx`.

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

استخدم [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) أو [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) للدوال مثل `sin(x)`، `log(x)`، أو لأسماء دوال مخصصة. للحدود، ضع `lim` في [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) أو استخدم [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![حد x عندما يقترب x من ما لا نهائي](powerpoint-math-equations_8.png)

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

لإنشاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي واستدعِ [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) مع حجته:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **إضافة مشغلات N-ary وتكاملات**

استخدم [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) للجمع، الاتحاد، التقاطع، وغيرها من المشغلات الكبيرة. استخدم [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) للتكاملات. تسمح الطريقتان بتحديد الحدود السفلية والعلوية.

![جمع مع حدود سفلية وعليا](powerpoint-math-equations_7.png)

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

المشغلات N-ary مخصصة للمشغلات الكبيرة مع حدود اختيارية. المشغلات البسيطة مثل `+`، `-`، و`=` عادةً ما تُضاف كـ [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) وتُدمج في التعبير.

للتكامل، استخدم [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) للصفوف والأعمدة. لا تتضمن المصفوفات أقواسًا بشكل افتراضي، لذا أدرج المصفوفة بين أقواس أو أقواس مربعة أو قوسين حسب الحاجة.

![مصفوفة رياضية ذات صفين وخلية فارغة واحدة](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # المصفوفة لا تحتوي على أقواس خاصة بها، لذا احصرها بين أقواس.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` يبني شبكة الصفوف والأعمدة، يحدّد الفجوات بينها، ويضبط محاذاة الأعمدة، لكن Aspose.Slides for Python via .NET لا يوفر وسيلة للوصول إلى خلية مفردة في المصفوفة. لذلك تبقى الخلايا الفارغة عند إنشاء مصفوفة برمجيًا؛ ويمكن قراءة خلايا مصفوفة موجودة في عرض تقديمي باستخدام `get_children`. استخدم مصفوفة المعادلات عندما تحتاج إلى ملء الصفوف برمجيًا.
{{% /alert %}}

## **إضافة مصفوفات معادلات**

استخدم [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) عندما تحتاج إلى معادلات محاذية أو مجموعة رأسية من التعبيرات.

![مصفوفة رياضية رأسية مع x أعلى y](powerpoint-math-equations_11.png)

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

### **محاذاة المصفوفة مع العناصر المجاورة**

تتحكم الخاصية [IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) في محاذاة المصفوفة عموديًا بالنسبة للعناصر الرياضية المجاورة. يقارن المثال أدناه المحاذاة مع الصف الأول، مركز المصفوفة، والصف الأخير.

ينشئ المثال التالي ثلاث مصفوفات متطابقة، كل واحدة بثلاث صفوف والعناصر المجاورة `A=` و`=B`. جميع النصوص الرياضية تستخدم خط Cambria Math بحجم 24 نقطة. يتغير فقط محاذاة المصفوفة.

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

المقارنة التالية تُظهر العرض المحفوظ في PowerPoint. لاحظ موقع `A=` و`=B` بجانب كل مصفوفة.

![مصوفات معادلات في PowerPoint مع محاذاة أعلى، وسط، وأسفل وعناصر مجاورة متطابقة](equation-array-alignment.png)

### **تكوين تباعد الصفوف**

تختار الخاصية [row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) قاعدة التباعد للصفوف داخل المصفوفة. تُعطي الخاصية [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) قيمة عددية لقاعدة تباعد صريحة وتُهمل عندما تُستخدم القواعد المسبقة.

للتباعد الدقيق، تُقاس القيمة بالنقاط. للتباعد النسبي، تُقاس بالنصف سطر: القيمة `3` في المثال تعني 1.5 سطر. عيّن الخاصيتين معًا عند تحديد قيمة صريحة؛ تغيير القيمة العددية وحدها لا يختار قاعدة تباعد.

يحفظ المثال أدناه خمس عروض تقديمية بنفس المعادلات، والمحاذاة، وإعدادات الخط. الثلاثة الأولى تستخدم القواعد المسبقة؛ الأخيرة تُظهر قيمًا صريحة.

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

تباعد صفوف المصفوفة منفصل عن تباعد الفقرات. تضيف الخاصيتان [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) و[space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) مسافة حول الفقرة المحتوية، وليس بين صفوف المصفوفة. بالمثل، تحدد الخاصية [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) موضع الفقرة الرياضية بالكامل أفقياً؛ ولا تُستبدل بإعداد محاذاة المصفوفة العمودية.

## **إضافة دوال مثلثية**

استخدم [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) عندما يكون المتغير هو العنصر الحالي واسم الدالة معروفًا.

![دالة مثلثية cos مطبقة على 2x](powerpoint-math-equations_6.png)

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

## **إضافة مؤشرات وصيغ عليا**

استخدم المساعدات للمؤشرات والصيغ العُليا للفهارس والقياسات. عندما يجب أن تظهر الفهارس على الجانب الأيسر من القاعدة، استخدم [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![حرف Y كبير مع مؤشر سفلي 1 وصيغة عليا n على اليسار](powerpoint-math-equations_9.png)

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

استخدم [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) لوضع تعبير داخل محددات. يمكنك أيضًا تحديد حرف فاصل لتعبيرات محددات تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x وy وz مفصولة بأشرطة عمودية](powerpoint-math-equations_13.png)

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

### **حجم وتنسيق المحددات**

عيّن [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) إلى `True` للسماح للأقواس بالنمو حول عنصر طويل، أو إلى `False` لإبقائها بالحجم الطبيعي. الخاصية [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) تأخذ إحدى قيمتي [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/). القيمة `CENTERED` تُوسط الأقواس على محور الرياضيات، وهو يمر عبر وسط علامة المساواة. القيمة `MATCH` تُطابق ارتفاع الأقواس مع المحتوى المغلق. كلا الإعدادين يؤثران فقط على المحددات؛ يبقى التعبير داخلها دون تغيير.

يضع المثال كسرًا في أسس `x` بحيث يمتد التعبير إلى أعلى من الخط الأساسي أكثر من الأسفل. تستخدم جميع المعادلات الأربعة نفس الأقواس وإعدادات الخط.

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

في PowerPoint، قارن الصفوف لرؤية تأثير النمو. في الصف العلوي، تنمو الأقواس لتغطي الأس وتظهر متشابهة لكلا الشكلين. في الصف السفلي، يكون النمو معطلاً. الأقواس الأصغر على اليسار (`CENTERED`) تُحاذى مع علامة المساواة، بينما تلك على اليمين (`MATCH`) تُرفع أعلى حول التعبير.

![أربع معادلات في PowerPoint مع تمكين نمو المحددات في الأعلى وإلغاءه في الأسفل، مع CENTERED على اليسار وMATCH على اليمين](delimiter-sizing.png)

## **إضافة صندوق حدودي**

استدعِ [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) على كسر لتأطير التعبير كاملًا. يعرض كائن [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) الأربعة جوانب بشكل افتراضي. استخدم [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/)، [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/)، [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/)، و[hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) لإزالة جوانب معينة.

يضع المثال ست نسخ من الكسر نفسه على شريحة واحدة. لإظهار الإلغاء، أخفِ جميع الجوانب الأربعة واضبط [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) للحصول على خط قطني صاعد (↗) أو [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) للحصول على خط قطني هابط (↘). يمكنك أيضًا استعمال [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) أو [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) مع أي تركيبة من الجوانب المرئية.

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

![ستة كسور قابلة للتحرير في PowerPoint. الصف العلوي: حد كامل، أسفل ويسار، خط قطني صاعد. الصف السفلي: خط قطني هابط، خط أفقي، خط عمودي مع حد كامل.](border-box-fractions.png)

في هذا الكسر، يتقاطع الخط الأفقي مع شريط الكسر. يتقاطع الخط العمودي مع البسط والمقام بينما يبقى الحد السحيق مرئيًا. تُزين هذه الخطوط التعبير بأكمله. يُطبق خط الشطب العادي على الأحرف داخل تشغيل نص. بعد إعادة فتح العرض في PowerPoint، لا يزال بإمكانك تحرير البسط والمقام بشكل مستقل.

## **التحكم في الرؤية والتخطيط باستخدام عناصر Phantom**

لفّ التعبير داخل [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) للتحكم في رؤيته والمساحة التي يضيفها للمعادلة بشكل مستقل. تتحكم خصائص [IMathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/) فيما يلي:

| الخاصية | الأثر |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/show/) | اضبطها على `False` لإخفاء التعبير. أبعادها لا تزال تُساهم في التخطيط ما لم تُضبط الخصائص التالية إلى `True`. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_width/) | عالج العرض الأفقي للتعبير كصفر، مما يسمح للعناصر المجاورة بالاقتراب. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_asc/) | عالج الارتفاع فوق الخط الأساسي كصفر. يمكن لهذا أن يقلل المسافة المحجوزة أعلى العناصر المجاورة. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_desc/) | عالج الارتفاع تحت الخط الأساسي كصفر. يمكن لهذا أن يقترب شريط الكسر أو أي محتوى آخر أسفل التعبير من جيرانه. |

الخط الأساسي هو الخط المرجعي الذي تجلس عليه الأحرف الرياضية العادية. إخفاء المحتوى لا يزيل أبعاده، ومعالجة البُعد كصفر لا يحذف التعبير. يبقى التعبير الأساسي متاحًا عبر [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/base/). عيّن [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/show/) إلى `True` لإظهاره مرة أخرى؛ تبقى إعدادات الأبعاد كما هي.

ينشئ المثال أدناه خمسة متغيرات جنبًا إلى جنب: كسر مرئي، كسر مخفي يحتفظ بالمسافة، وثلاثة كسور مخفية مع معالجة بُعد واحد كصفر. كل متغير يستخدم نفس التعبير المحيط وخط Cambria Math بحجم 24 نقطة. جميع أشكال المعادلات لها نفس الموضع العلوي، مُمثلًا بالخط الرمادي. وضع Phantom في البسط لكسر خارجي يجعل تغييرات التخطيط العمودي أسهل للملاحظة.

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

![خمسة معادلات في PowerPoint تقارن كسرًا مرئيًا، كسرًا مخفيًا يحتفظ بالمسافة، وكسرًا مخفيًا مع ZeroWidth أو ZeroAsc أو ZeroDesc مفعلة](math-phantom.png)

## **تجميع المصطلحات**

استخدم [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) لوضع حرف تجميع أعلى أو أسفل تعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![التعبير x + y مُجمّع مع تسمية أي نص أسفله](powerpoint-math-equations_15.png)

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

لتنسيق النص عبر معادلة موجودة، تجول في شجرة عناصر كل كتلة رياضية. تُعيد [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) الأطفال المباشرين فقط، لذا استدعِها بصورة متكررة للوصول إلى النص داخل الكسور، والأنصبة، والجذور، والهياكل المتداخلة الأخرى. افحص العنصر الحالي وكذلك أطفاله لتضمين العنصر الابتدائي عندما يكون [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

يفترض هذا المثال أن `input.pptx` يحتوي على معادلة مثل `z = xᵢ / ∛y`، حيث يحتوي الكسر على مؤشر سفلي في البسط وجذر في المقام. سيؤدي معالجة العناصر العليا للكتلة فقط إلى فقدان النص داخل الكسر. يعثر المثال على أجزاء رياضية في إطارات نص الشرائح، يصل إلى كتلها عبر [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)، ويضبط [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) إلى 28 نقطة عبر خاصية [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) لكل عنصر نصي.

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

العرض المُحفظ يحتوي على تنسيق النص المحدث في كل مستوى من كل معادلة تمت معالجتها، مع الحفاظ على محتوى النص والهيكلة الرياضية.

## **مرجع سريع**

| المهمة | API الرئيسي |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| دمج العناصر | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| إنشاء كسور | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| إضافة صُفْر أو أس | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| إضافة دوال | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| إضافة جذور | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| إضافة حدود | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| إضافة أنصبة جانبية | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| إضافة جمع وتكامل | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| إضافة مصفوفات معادلات | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| إضافة أشرطة وحدود | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **الأسئلة المتكررة**

**هل يمكن تحرير معادلة PowerPoint موجودة؟**

نعم. افتح العرض، اعثر على الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، احصل على [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف بصيغة PPTX، يكتب Aspose.Slides المعادلة ك内容 رياضي Office قابل للتحرير.

**هل يمكن تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، واستدعِ [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) لتصديره مباشرة. للحصول على مثال كامل، راجع [Export Math Equations from Presentations in Python via .NET](/slides/ar/python-net/exporting-math-equations/#export-math-equations-to-latex).