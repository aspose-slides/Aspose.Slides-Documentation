---
title: إضافة معادلات رياضية إلى عروض PowerPoint تقديمية في Python
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
description: "إدراج وتحرير معادلات رياضية في عروض PowerPoint بصيغ PPT و PPTX باستخدام Aspose.Slides for Python عبر .NET، مع دعم OMML، أدوات تنسيق، وعينات شفرة Python واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات كـ Office Math Markup Language (OMML). باستخدام Aspose.Slides for Python عبر .NET، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجيًا: الكسور، الجذور، الدوال، الحدود، العمليات N-ary، المصفوفات، المصفوفات المتعددة، وكتل الرياضيات المنسقة.

في PowerPoint، يضيف المستخدمون عادةً المعادلات من **Insert > Equation**:

![علامة تبويب Insert في PowerPoint مع اختيار أمر Equation](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي عبر ثلاثة كائنات رئيسية:

- شكل رياضي، يتم إنشاؤه باستخدام [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/)، هو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) يخزن محتوى الرياضيات داخل إطار النص الخاص بالشكل.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) يحتوي على كائن أو أكثر من [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

معظم الأمثلة أدناه تستخدم [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) والطُرق التراسلية من [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) لجعل الكود قصيرًا وسهل القراءة.

للحالات التي تتطلب تصدير MathML، راجع [تصدير معادلات الرياضيات من العروض التقديمية في Python عبر .NET](/slides/ar/python-net/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال يستخدم [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) لإنشاء شكل رياضي ويضيف نظرية فيثاغورس:

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) ينشئ شكلًا يحتوي بالفعل على فقرة رياضية. يمكن الوصول إلى أول [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، الحصول على [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)، ثم إضافة كتل أو عناصر رياضية إليها.
{{% /alert %}}

## **إضافة كسور**

استخدم [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) لإنشاء كسراً. يمكنك اختيار نمط كسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![كسر رياضي مائل يظهر واحد مقسومًا على x](powerpoint-math-equations_4.png)

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

استخدم [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) لإنشاء جذر تربيعي أو مكعب أو أي جذر آخر. العنصر الحالي يصبح القاعدة، والوسيط يصبح الدرجة.

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

## **إضافة دوال وحدود**

استخدم [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) أو [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) للدوال مثل `sin(x)`، `log(x)`، أو أسماء دوال مخصصة. للحدود، ضع `lim` داخل [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) أو استخدم [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

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

لإنشاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي واستدعِ [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) مع وسيطه:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **إضافة عوامل N-ary وتكاملات**

استخدم [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) للجمع، الاتحاد، التقاطع وغيرها من العوامل الكبيرة. استخدم [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) للتكاملات. تسمح الطريقتان بتحديد الحدود السفلية والعليا.

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

العوامل N-ary مخصصة للعوامل الكبيرة مع حدود اختيارية. العوامل البسيطة مثل `+`، `-`، و`=` عادةً تُضاف كـ [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) وتُدمج في التعبير.

لإنشاء تكامل، استخدم [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تشمل الأقواس افتراضيًا، لذا قم بلف المصفوفة عندما تحتاج إلى أقواس أو مربعات أو أقواس معقوفة.

![مصفوفة رياضية ذات صفين بها خلية فارغة واحدة](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # المصفوفة لا تحتوي على أقواس خاصة بها، لذا يلزم إحاطتها بأقواس مدورة.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` يبني شبكة الصفوف والأعمدة، يحدد الفجوات بينها، ويُحاذي الأعمدة، لكن Aspose.Slides for Python عبر .NET لا يُظهر وسيلة للوصول إلى خلية منفردة في المصفوفة. لذا فإن المصفوفة المُنشأة برمجيًا تبقى بها خلايا فارغة؛ يمكن قراءة خلايا مصفوفة موجودة في عرض تقديمي باستخدام `get_children`. استخدم مصفوفة معادلات عندما تحتاج إلى تعبئة الصفوف برمجيًا.
{{% /alert %}}

## **إضافة مصفوفات المعادلات**

استخدم [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) عندما تحتاج إلى معادلات مُحاذاة أو مجموعة رأسية من التعبيرات.

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

## **إضافة الدوال المثلثية**

استخدم [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) عندما يكون الوسيط هو العنصر الحالي ويكون اسم الدالة معروفًا.

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

## **إضافة الحروف السفلية والعليا**

استخدم المساعدات الخاصة بالحروف السفلية والعليا للمؤشرات والأسس. عندما يجب أن تظهر المؤشرات على الجانب الأيسر من القاعدة، استخدم [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![حرف Y الكبير مع مؤشر سفلي 1 وحرف علوي n على الجانب الأيسر](powerpoint-math-equations_9.png)

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

![تعبير محدد يحتوي على x و y و z مفصولة بأعمدة رأسية](powerpoint-math-equations_13.png)

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

اضبط [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) إلى `True` للسماح للأقواس بالنمو حول عملية طويلة، أو إلى `False` للحفاظ على حجمها الطبيعي.  
[delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) يقبل إحدى قيمتي [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/). `CENTERED` يوسّط الأقواس على المحور الرياضي، الذي يمر عبر منتصف علامة المساواة. `MATCH` يطابقها مع المحتوى المحاط. كلا الإعدادين يؤثران فقط على المحددات. يبقى التعبير داخلها كما هو.

المثال يضع كسراً في أس `x` بحيث يمتد التعبير أعلى الخط الأساسي أكثر من أسفله. جميع المعادلات الأربعة تستخدم نفس الأقواس وإعدادات الخط.

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

في PowerPoint، قارن الصفوف لرؤية تأثير النمو. في الصف العلوي، تنمو الأقواس لتغلق الأس وتبدو متساوية للشفرتين. في الصف السفلي، يكون النمو معطَّلًا. الأقواس الأصغر على اليسار (`CENTERED`) تُحاذى مع علامة المساواة، بينما الأقواس على اليمين (`MATCH`) تُوضع أعلى حول التعبير.

![أربع معادلات في PowerPoint مع تمكين نمو المحددات في الأعلى وتعطيله في الأسفل، مع CENTERED على اليسار و MATCH على اليمين](delimiter-sizing.png)

## **إضافة مربع إطار**

استدعِ [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) على كسر لتأطير التعبير بالكامل. تُظهر [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) الأربعة جوانب بشكل افتراضي. استخدم [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/)، [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/)، [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/)، و[hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) لإزالة جوانب محددة.

المثال يضع ست نسخ من نفس الكسر على شريحة واحدة. لإظهار الإلغاء، أخفِ جميع الجوانب الأربعة واضبط [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) لخط مائل صاعد (↗) أو [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) لخط مائل هابط (↘). يمكنك أيضًا استخدام [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) أو [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) مع أي تركيبة من الجوانب المرئية.

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

![ستة كسور قابلة للتحرير في PowerPoint. الصف العلوي: حد كامل، الجانب الأسفل واليسار، قطري صاعد. الصف السفلي: قطري هابط، شطبة أفقية، شطبة عمودية مع حد كامل.](border-box-fractions.png)

في هذا الكسر، تتقاطع الشطبة الأفقية مع شريط الكسر. الشطبة العمودية تعبر كلًا من البسط والمقام بينما يظل الإطار المحيط مرئيًا. تزيّن هذه الخطوط التعبير بالكامل. شطبة النص العادية تُطبق على الأحرف داخل تشكيلة النص. بعد إعادة فتح العرض في PowerPoint، لا يزال بإمكانك تحرير البسط والمقام بشكل مستقل.

## **تجميع المصطلحات**

استخدم [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) لوضع حرف تجميع فوق أو تحت تعبير. أضف حدًا لتسمية المصطلحات المُجمعة.

![التعبير x زائد y مجمع مع التسمية أي نص أسفله](powerpoint-math-equations_15.png)

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

استخدم مساعدات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) يضع شطبة فوق عنصر رياضي.

![تعبير رياضي ABC مع شطبة فوقه](powerpoint-math-equations_14.png)

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

لتنسيق النص في معادلة موجودة، تجول في شجرة عناصر كل كتلة رياضية. تُعيد [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) الأطفال المباشرين فقط، لذا استدعِها بصورة متكررة للوصول إلى النص داخل الكسور، والأنظمة، والجذور، والهياكل المتداخلة الأخرى. تحقق من العنصر الحالي وكذلك من أطفاله لتضمين العنصر الابتدائي عندما يكون [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

هذا المثال يفترض أن `input.pptx` يحتوي على معادلة مثل `z = xᵢ / ∛y`، مع كسر يحتوي على مؤشر سفلي في البسط وجذر في المقام. معالجة العناصر العليا فقط للكتلة سيتجاوز النص داخل الكسر. يجد المثال أجزاء رياضية في إطارات نص الشرائح، يحصل على كتلها عبر [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)، ويضبط [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) إلى 28 نقطة عبر خاصية [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) لكل عنصر نص.

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

| المهمة | الواجهة الأساسية |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| دمج العناصر | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| إنشاء كسور | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| إضافة حرف علوي أو سفلي | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| إضافة دوال | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| إضافة جذور | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| إضافة حدود | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| إضافة مؤشرات من الجانب الأيسر | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| إضافة جمع وتكامل | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| إضافة مصفوفات المعادلات | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| إضافة أشرطة وإطارات | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **الأسئلة المتكررة**

**هل يمكنني تحرير معادلة PowerPoint موجودة؟**

نعم. افتح العرض، ابحث عن الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، احصل على [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)، وحدث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ العرض بصيغة PPTX، يكتب Aspose.Slides المعادلة كـ Office Math محتوى قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، ثم استدعِ [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) لتصديره مباشرة. لمثال كامل، راجع [تصدير معادلات الرياضيات من العروض التقديمية في Python عبر .NET](/slides/ar/python-net/exporting-math-equations/#export-math-equations-to-latex).