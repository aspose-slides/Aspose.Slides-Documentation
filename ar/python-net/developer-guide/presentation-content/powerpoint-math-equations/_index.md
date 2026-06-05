---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية باستخدام Python
linktitle: معادلات الرياضيات في PowerPoint
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
description: "إدراج وتحرير المعادلات الرياضية في عروض PowerPoint بصيغ PPT و PPTX باستخدام Aspose.Slides لبايثون عبر .NET، مع دعم OMML، وضوابط التنسيق، وعينات شفرة بايثون واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات بصيغة Office Math Markup Language (OMML). باستخدام Aspose.Slides for Python عبر .NET، يمكنك إنشاء نفس نوع المحتوى الرياضي برمجياً: الكسور، الجذور، الدوال، الحدود، العوامل N-ary، المصفوفات، المصفوفات المتعددة، وكتل الرياضيات المنسقة.

في PowerPoint، يضيف المستخدمون عادة المعادلات من **إدراج > معادلة**:

![علامة تبويب إدراج في PowerPoint مع تحديد أمر المعادلة](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يتم إنشاؤه باستخدام [add_math_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_math_shape/)، هو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathportion/) يخزن محتوى الرياضيات داخل إطار النص في الشكل.
- [MathParagraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathparagraph/) يحتوي على كائن واحد أو أكثر من [MathBlock](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathblock/).

معظم الأمثلة أدناه تستخدم [MathematicalText](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathematicaltext/) والطرق المتسلسلة من [IMathElement](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/) لجعل الشيفرة قصيرة وسهلة القراءة.

لسيناريوهات تصدير MathML، راجع [Export Math Equations from Presentations in Python via .NET](/slides/ar/python-net/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال ينشئ شكلاً رياضياً ويضيف نظرية فيثاغورس:

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

{{% alert color="primary" %}}
`add_math_shape` ينشئ شكلاً يحتوي مسبقاً على فقرة رياضية. احصل على أول `MathPortion`، ثم على `MathParagraph` الخاص به، وأضف كتل رياضية أو عناصر رياضية إليها.
{{% /alert %}}

## **إضافة كسور**

استخدم [`divide`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/divide/) لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathfractiontypes/).

![كسر مائل يُظهر 1 مقسومًا على x](powerpoint-math-equations_4.png)

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

لإنشاء كسر مكدس، استخدم `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **إضافة جذور**

استخدم [`radical`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/radical/) لإنشاء جذر تربيعي، أو جذر مكعب، أو أي جذر آخر. العنصر الحالي يصبح الأساس، والوسيط يصبح الدرجة.

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

## **إضافة الدوال والحدود**

استخدم [`as_argument_of_function`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) أو [`function`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/function/) للدوال مثل `sin(x)`، `log(x)`، أو أسماء دوال مخصصة. للحدود، ضع `lim` في [MathLimit](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathlimit/) أو استخدم [`set_lower_limit`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![حد x عندما يقترب x من ما لا نهاية](powerpoint-math-equations_8.png)

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

لإعطاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **إضافة عوامل N-ary والتكاملات**

استخدم [`nary`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/nary/) للجمعيات، الاتحادات، التقاطعات، وغيرها من العوامل الكبيرة. استخدم [`integral`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/integral/) للتكاملات. كلا الطريقتين تسمحان بتحديد الحدود السفلية والعلوية.

![جمعية مع حدود سفلية وعليا](powerpoint-math-equations_7.png)

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

العوامل N-ary مخصصة للعوامل الكبيرة ذات حدود اختيارية. تُضاف العوامل البسيطة مثل `+`، `-`، و`=` عادةً كـ `MathematicalText` وتُربط في التعبير.

للتكامل، استخدم `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تتضمن أقواسًا افتراضيًا، لذا احط المصفوفة بالأقواس أو الأقواس المربعة أو الأقواس المعقوفة حسب الحاجة.

![مصفوفة رياضية ذات صفين وخلية فارغة واحدة](powerpoint-math-equations_10.png)

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

## **إضافة مصفوفات المعادلات**

استخدم [`to_math_array`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/to_math_array/) عندما تحتاج إلى معادلات محاذاة أو مجموعة رأسية من التعابير.

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

استخدم [`as_argument_of_function`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) عندما يكون الوسيط هو العنصر الحالي ويكون اسم الدالة معروفًا.

![الدالة المثلثية cos مطبقة على 2x](powerpoint-math-equations_6.png)

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

## **إضافة المؤشرات السفلية والعلوية**

استخدم مساعدي المؤشر السفلي والعلوي للفهارس والقوى. عندما يجب أن تظهر الفهارس على الجانب الأيسر من الأساس، استخدم [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![حرف Y كبير مع مؤشر سفلي 1 ومؤشر علوي n على الجانب الأيسر](powerpoint-math-equations_9.png)

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

استخدم [`enclose`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/enclose/) لوضع تعبير داخل محددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات المحدد التي تحتوي على عدة عناصر.

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

## **إضافة صندوق حدودي**

استخدم [`to_border_box`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/to_border_box/) عندما يجب أن تكون المعادلة نفسها محاطة بإطار.

![معادلة محاطة بمربع تُظهر a² = b² + c²](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **تجميع المصطلحات**

استخدم [`group`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/group/) لوضع حرف تجميع أعلى أو أسفل تعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![التعبير x + y مجمّع مع تسمية أي نص تحته](powerpoint-math-equations_15.png)

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

استخدم مساعدات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، [`overbar`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/overbar/) يضع شريطًا فوق عنصر رياضي.

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

## **مرجع سريع**

| المهمة | واجهة برمجة التطبيقات الأساسية |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathematicaltext/) |
| دمج العناصر | [IMathElement.join](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/join/) |
| إنشاء كسور | [IMathElement.divide](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/divide/) |
| إضافة أس أو أس سفلي | [set_superscript](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| إضافة دوال | [function](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| إضافة جذور | [radical](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/radical/) |
| إضافة حدود | [set_lower_limit](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| إضافة مؤشرات على الجانب الأيسر | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| إضافة جمعيات وتكاملات | [nary](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/integral/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathmatrix/) |
| إضافة مصفوفات المعادلات | [to_math_array](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| إضافة أشرطة وإطارات | [overbar](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/imathelement/group/) |

## **الأسئلة الشائعة**

**هل يمكنني تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، ابحث عن الشكل الذي يحتوي على `MathPortion`، احصل على `MathParagraph` الخاص به، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف كـ PPTX، يكتب Aspose.Slides المعادلة كـ Office Math قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

Aspose.Slides يصدر المعادلات إلى MathML. إذا كنت تحتاج إلى LaTeX، قم أولاً بتصدير إلى MathML ثم حوّله إلى LaTeX باستخدام أداة تدعم صيغ LaTeX المستهدفة.