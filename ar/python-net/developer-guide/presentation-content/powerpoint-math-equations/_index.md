---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية بلغة Python
linktitle: معادلات رياضية
type: docs
weight: 80
url: /ar/python-net/powerpoint-math-equations/
keywords:
- معادلة رياضية
- معادلة رياضية في PowerPoint
- رمز رياضي
- رمز رياضي في PowerPoint
- صيغة رياضية
- صيغة رياضية في PowerPoint
- نص رياضي
- نص رياضي في PowerPoint
- إضافة معادلة رياضية إلى PowerPoint
- إضافة رمز رياضي إلى PowerPoint
- إضافة صيغة رياضية إلى PowerPoint
- إضافة نص رياضي إلى PowerPoint
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية التعامل مع المعادلات الرياضية في PowerPoint باستخدام Aspose.Slides للغة Python عبر .NET. احصل على تعليمات مفصلة، أمثلة على الشيفرة، ونصائح لأتمتة إنشاء وتحرير العروض التقديمية."
---

## **نظرة عامة**

في PowerPoint، يمكنك كتابة معادلة أو صيغة رياضية وعرضها في عرضك التقديمي. تتوفر رموز رياضية مختلفة ويمكن إضافتها إلى النص أو المعادلات. يتم استخدام مُنشئ المعادلات الرياضية لإنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- الحدود واللوغاريتمات
- عمليات N-ary
- مصفوفة
- عوامل كبيرة
- دوال sin و cos

لإضافة معادلة رياضية في PowerPoint، يتم استخدام قائمة *Insert -> Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيتم إنشاء نص رياضي بصيغة XML يمكن عرضه في PowerPoint كما يلي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint مجموعة واسعة من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، لا ينتج عن إنشاء معادلات رياضية معقدة في PowerPoint نتيجة مصقولة ومهنية غالبًا. لذلك يلجأ المستخدمون الذين ينشئون عروضًا تقديمية رياضية بشكل متكرر إلى حلول من أطراف ثالثة للحصول على صيغ رياضية أكثر جاذبية.

باستخدام [**Aspose.Slides API**](https://products.aspose.com/slides/python-net/)، يمكنك التعامل مع المعادلات الرياضية في عروض PowerPoint برمجيًا بلغة Python. أنشئ تعبيرات رياضية جديدة أو عدل تلك التي تم إنشاؤها مسبقًا. يتوفر دعم جزئي لتصدير الهياكل الرياضية كصور.

## **كيفية إنشاء معادلة رياضية**

تُستخدم العناصر الرياضية لبناء أي تركيبة رياضية بغض النظر عن مستوى التعشيق. تشكل مجموعة خطية من هذه العناصر كتلة رياضية، تمثلها فئة [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). تمثل فئة [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) تعبيرًا رياضيًا مستقلاً أو صيغة أو معادلة. تُستخدم فئة [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) لاحتواء النص الرياضي (مختلف عن فئة [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) العادية)، بينما تتيح لك فئة [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) معالجة مجموعة من كائنات [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). تُعد هذه الفئات أساسية للعمل مع معادلات PowerPoint الرياضية عبر Aspose.Slides API.

دعنا نرى كيف يمكننا إنشاء المعادلة الرياضية التالية باستخدام Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، أضف أولاً شكلًا سيحتوي على النص الرياضي:
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


بعد إنشاء الشكل، يحتوي تلقائيًا على فقرة واحدة مع جزء رياضي افتراضيًا. تمثل فئة [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) جزءًا يحتوي على نص رياضي. للوصول إلى المحتوى الرياضي داخل [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، يُشار إلى متغيّر [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/):
```py
math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
```


تتيح لك فئة [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) قراءة وإضافة وتعديل وحذف كتل رياضية ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/))، والتي تتكون من مجموعة من العناصر الرياضية. على سبيل المثال، أنشئ كسرًا وضعه في العرض التقديمي:
```py
fraction = math.MathematicalText("x").divide("y")
math_paragraph.add(math.MathBlock(fraction))
```

```py
math_block = (
    math.MathematicalText("c").set_superscript("2").
        join("=").
        join(math.MathematicalText("a").set_superscript("2")).
        join("+").
        join(math.MathematicalText("b").set_superscript("2")))
```


تُنفَّذ عمليات واجهة [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) في كل نوع من العناصر، بما في ذلك فئة [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

فيما يلي مثال كامل للمصدر:
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    math_paragraph.add(math.MathBlock(fraction))

    math_block = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    math_paragraph.add(math_block)

    presentation.save("math.pptx", slides.export.SaveFormat.PPTX)
```


## **أنواع العناصر الرياضية**

تتكوّن التعبيرات الرياضية من تسلسلات من العناصر الرياضية. تمثل الكتلة الرياضية مثل هذا التسلسل، وتكوّن وسائط هذه العناصر بنية شجرية متعشقة.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. يمكن تجميع كلٍ من هذه العناصر داخل أخرى، مما يُكوّن بنية شجرية. أبسط نوع من العناصر هو ما لا يحتوي على أي عناصر نصية رياضية أخرى.

كل نوع من العناصر الرياضية يطبق واجهة [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)، مما يسمح لك باستخدام مجموعة مشتركة من العمليات الرياضية على أنواع مختلفة من العناصر.

### **فئة MathematicalText**

تمثل فئة [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) نصًا رياضيًا — العنصر الأساسي لجميع التركيبات الرياضية. قد يمثل النص الرياضي معاملات وعوامل، متغيرات، أو أي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐

### **فئة MathFraction**

تحدد فئة [MathFraction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) كائن كسر يتكوّن من بسط ومقام مفصولين بشريط كسر. يمكن أن يكون شريط الكسر أفقيًا أو قطريًا حسب خصائص الكسر. يُستخدم كائن الكسر أيضًا لتمثيل دالة المكدس، التي تُضع عنصرًا فوق آخر دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **فئة MathRadical**

تحدد فئة [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) دالة الجذر (الجذر الرياضي)، وتتكوّن من قاعدة ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **فئة MathFunction**

تحدد فئة [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) دالة لوسيط. تحتوي على خصائص مثل [name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/name/) الذي يمثل اسم الدالة، و[base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/base/) الذي يمثل وسيط الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **فئة MathNaryOperator**

تحدد فئة [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) عنصرًا رياضيًا N-ary، مثل الجمع أو التكامل. يتكوّن من عامل، قاعدة (أو معامل)، وحدود عليا وسفلى اختيارية. من أمثلة عوامل N-ary: الجمع، الاتحاد، التقاطع، والتكامل.

هذه الفئة لا تشمل عوامل بسيطة مثل الجمع أو الطرح؛ فهذه ممثلة بنص واحد من فئة [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **فئة MathLimit**

تنشئ فئة [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) الحد العلوي أو السفلي. تحدد كائن الحد نصًا على خط الأساس ونصًا أصغر حجماً فوقه أو تحته مباشرة. لا تتضمن هذه العنصر كلمة "lim"، بل تسمح لك بوضع نص في أعلى أو أسفل التعبير. لذا، يُنشأ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مزيج من فئتي [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) و[MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/):
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
math_function = math.MathFunction(function_name, math.MathematicalText("𝑥"))
```


### **فئات MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**

- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

تحدد هذه الفئات مؤشرًا سالبًا أو موجبًا. يمكنك تعيين كل من المؤشر السالب والموجب معًا على الجانب الأيسر أو الأيمن للوسيط، لكن يدعم الجانب الأيمن مؤشرًا واحدًا فقط. يمكن استخدام [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) أيضًا لتعيين درجة عددية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **فئة MathMatrix**

تحدد فئة [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) كائن المصفوفة، الذي يتكوّن من عناصر فرعية مرتبة في صفوف وأعمدة واحدة أو أكثر. تجدر الإشارة إلى أن المصفوفات لا تحتوي على محددات مدمجة. لتضمين المصفوفة بين أقواس، استخدم كائن المحدد [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/). يمكن تمرير قيم `null` لإنشاء فراغات داخل المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **فئة MathArray**

تحدد فئة [MathArray](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) مصفوفة رأسية من المعادلات أو أي كائنات رياضية أخرى.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**

- فئة [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/): ترسم حدًا مستطيلًا أو بديلاً حول [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

مثال:

![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [MathBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/): تحدد تغليفًا منطقيًا (تعبئة) للعنصر الرياضي. يمكن أن يعمل الكائن المعبأ كمحاكي عامل مع أو بدون نقطة محاذاة، أو كفاصل سطر، أو يتجمّع لمنع كسر السطر داخله. على سبيل المثال، يجب تعبئة العامل "==" لمنع كسر السطر.

- فئة [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/): تحدد كائن المحدد، والذي يتكوّن من حرفي افتتاح وإغلاق (مثل الأقواس، الأقواس المعقوفة، الأقواس المربعة أو الشرطات العمودية) وعنصر أو أكثر داخلها، مفصولة بحرف محدد. أمثلة: (𝑥2); [𝑥2|𝑦2].

مثال:

![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [MathAccent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/): تحدد الدالة النبرة، التي تتكوّن من قاعدة وعلامة تشكيلية مدمجة.

مثال: 𝑎́.

- فئة [MathBar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/): تحدد دالة الشريط، التي تتكوّن من وسيط أساسي وشريط علوي أو سفلي.

مثال:

![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [MathGroupingCharacter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/): تحدد رمز تجميع يُوضع فوق أو تحت التعبير، عادة لتسليط الضوء على العلاقات بين العناصر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**

كل عنصر رياضي وكل تعبير رياضي (عبر [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) يطبّق واجهة [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). هذا يتيح لك إجراء عمليات على البنية الحالية وتكوين تعبيرات رياضية أكثر تعقيدًا. جميع العمليات لها مجموعتان من المعاملات: إما [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) أو سلاسل نصية. تُنشأ كائنات فئة [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) ضمنيًا من السلاسل النصية عند استخدام معاملات نصية. تُدرج عمليات الرياضيات المتوفرة في Aspose.Slides أدناه.

### **طريقة Join**

- [join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#str)
- [join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#imathelement)

تجمع هذه الطرق عنصرًا رياضيًا وتكوّن كتلة رياضية. مثال:
```py
element1 = math.MathematicalText("x")
element2 = math.MathematicalText("y")
block = element1.join(element2)
```


### **طريقة Divide**

- [divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str)
- [divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str-mathfractiontypes)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement-mathfractiontypes)

تنشئ هذه الطرق كسرًا من النوع المحدد مع بسط ومقام محددين. مثال:
```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```


### **طريقة Enclose**

- [enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#)
- [enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#char-char)

تُحيط هذه الطرق العنصر بحروف محددة، مثل الأقواس أو غيرها من أحرف الإطار. مثال:
```py
delimiter = math.MathematicalText("x").enclose('[', ']')
delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```


### **طريقة Function**

- [function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#str)
- [function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#imathelement)

تُمرِّر هذه الطرق دالة لوسيط باستخدام الكائن الحالي كاسم الدالة. مثال:
```py
function = math.MathematicalText("sin").function("x")
```


### **طريقة AsArgumentOfFunction**

- [as_argument_of_function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

تستقبل هذه الطرق الدالة المحددة باستخدام المثيل الحالي كوسيط. يمكنك:

- تحديد سلسلة كاسم الدالة، مثلًا "cos"
- اختيار أحد القيم المحددة مسبقًا في تعداد [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) أو [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/)، مثلًا `MathFunctionsOfOneArgument.ARC_SIN`
- اختيار مثيل [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

مثال:
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
func1 = math.MathematicalText("2x").as_argument_of_function(function_name)
func2 = math.MathematicalText("x").as_argument_of_function("sin")
func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```


### **طرق SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**

- [set_subscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#str)
- [set_subscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#imathelement)
- [set_superscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#str)
- [set_superscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#imathelement)
- [set_sub_superscript_on_the_right(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#str-str)
- [set_sub_superscript_on_the_right(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#imathelement-imathelement)
- [set_sub_superscript_on_the_left(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#str-str)
- [set_sub_superscript_on_the_left(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#imathelement-imathelement)

تحدد هذه الطرق المؤشر السالب والمؤشر العلوي. يمكنك تعيين كليهما معًا إما على الجانب الأيسر أو الأيمن للوسيط؛ ومع ذلك، يدعم الجانب الأيمن مؤشرًا واحدًا فقط. يمكن أيضًا استخدام **Superscript** لتعيين درجة عددية.

مثال:
```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```


### **طريقة Radical**

- [radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#str)
- [radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#imathelement)

تحدد هذه الطرق الجذر الرياضي للدرجة المحددة بناءً على الوسيط المقدم.

مثال:
```py
radical = math.MathematicalText("x").radical("3")
```


### **طريقتا SetUpperLimit و SetLowerLimit**

- [set_upper_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#str)
- [set_upper_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#imathelement)
- [set_lower_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#str)
- [set_lower_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#imathelement)

تقبل هذه الطرق حدًا علويًا أو سفليًا، حيث يشير "upper" و"lower" إلى موضع الوسيط مقارنةً بالقاعدة.

نأخذ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات عبر دمج فئتي [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) و[MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/)، إلى جانب عمليات واجهة [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)، كما يلي:
```py
math_expression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```


### **طرق Nary و Integral**

- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-imathelement-imathelement)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-str-str)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement-mathlimitlocations)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str-mathlimitlocations)

كل من طريقتي `nary` و`integral` تنشئ وتعيد المشغّل N-ary الممثل بنوع [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/). في طريقة Nary، يحدد تعداد [MathNaryOperatorTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) نوع المشغّل—مثل الجمع أو الاتحاد—مع استبعاد التكاملات. في طريقة Integral، تُقدم عملية متخصصة للتكاملات باستخدام تعداد [MathIntegralTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/).

مثال:
```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```


### **طريقة ToMathArray**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) تضع العناصر في مصفوفة رأسية. إذا تم استدعاء هذه العملية على مثيل [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)، فستوضع جميع العناصر الفرعية في المصفوفة المُعادّة.

مثال:
```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```


### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- طريقة [accent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/accent/) تُضيف علامة تشكيل (حرف فوق العنصر).
- طريقتا [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) و[underbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/underbar/) تُضيف شريطًا أعلى أو أسفل العنصر.
- طريقة [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) تُضع العنصر في مجموعة باستخدام رمز تجميع مثل القوس المعقوف السفلي أو غيره.
- طريقة [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) تُضع العنصر داخل حد‑مربع.
- طريقة [to_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_box/) تُضع العنصر داخل مربع غير مرئي (تجميع منطقي).

أمثلة:
```py
accent = math.MathematicalText("x").accent(chr(0x0303))
bar = math.MathematicalText("x").overbar()
group_chr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
        math.MathTopBotPositions.BOTTOM, 
        math.MathTopBotPositions.TOP)
border_box = math.MathematicalText("x+y+z").to_border_box()
boxed_operator = math.MathematicalText(":=").to_box()
```


## **الأسئلة المتكررة**

**كيف يمكنني إضافة معادلة رياضية إلى شريحة PowerPoint؟**

لإضافة معادلة رياضية، تحتاج إلى [إنشاء شكل رياضي](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) يُضاف تلقائيًا جزء رياضي. ثم تسترجع [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) وتضيف كائنات [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) إليه.

**هل يمكن إنشاء تعبيرات رياضية معقدة متداخلة؟**

نعم، يسمح Aspose.Slides بإنشاء تعبيرات رياضية معقدة عبر تعشيق [MathBlocks](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). كل عنصر رياضي يتيح لك تطبيق عمليات (Join، Divide، Enclose، إلخ) لدمج العناصر في بنى أكثر تعقيدًا.

**كيف يمكنني تحديث أو تعديل معادلة رياضية موجودة؟**

لتحديث معادلة، عليك الوصول إلى [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) الموجود عبر [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). ثم باستخدام طرق مثل Join وDivide وEnclose وغيرها، يمكنك تعديل عناصر المعادلة الفردية. بعد التعديل، احفظ العرض لتطبيق التغييرات.