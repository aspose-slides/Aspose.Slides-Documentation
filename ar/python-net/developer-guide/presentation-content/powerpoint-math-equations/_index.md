---
title: معادلات الرياضيات في PowerPoint
type: docs
weight: 80
url: /ar/python-net/powerpoint-math-equations/
keywords: " معادلات الرياضيات في PowerPoint, رموز الرياضيات في PowerPoint, صيغة PowerPoint, نص الرياضيات في PowerPoint, عرض PowerPoint, بايثون, Aspose.Slides لـ بايثون عبر .NET"
description: "معادلات الرياضيات في PowerPoint، رموز الرياضيات، صيغة، ونص الرياضيات في بايثون"
---

## **نظرة عامة**
في PowerPoint، من الممكن كتابة معادلة رياضية أو صيغة وعرضها في العرض التقديمي. للقيام بذلك، يتم تمثيل رموز رياضية متنوعة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لذلك، يتم استخدام منشئ المعادلات الرياضية في PowerPoint، والذي يساعد في إنشاء صيغ معقدة مثل:

- الكسر الرياضي
- الجذر الرياضي
- الدالة الرياضية
- الحدود ودوال اللوغاريتم
- العمليات N-ary
- المصفوفة
- العمليات الكبيرة
- دوال الجيب والجيب التمام

لإضافة معادلة رياضية في PowerPoint، يتم استخدام القائمة *إدراج -> معادلة*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

هذا سوف ينشئ نصًا رياضيًا في XML يمكن عرضه في PowerPoint كما يلي: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint العديد من الرموز الرياضية لإنشاء معادلات رياضية. ومع ذلك، فإن إنشاء معادلات رياضية معقدة في PowerPoint غالبًا لا يعطي نتيجة جيدة ومهنية. المستخدمون، الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر، يلجئون إلى استخدام حلول الطرف الثالث لإنشاء صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/python-net/)، يمكنك العمل مع المعادلات الرياضية في برامج عروض PowerPoint بشكل برمجي في بايثون. أنشئ تعبيرات رياضية جديدة أو عدل التعبيرات التي أنشئت مسبقاً. يتم أيضًا دعم تصدير الهياكل الرياضية إلى الصور جزئياً.

## **كيفية إنشاء معادلة رياضية**
تستخدم العناصر الرياضية لبناء أي إنشاءات رياضية بأي مستوى من التعشيش. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية تمثلها فئة [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). فئة [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) هي في الأساس تعبير رياضي منفصل أو صيغة أو معادلة. [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) هي جزء رياضي، وتستخدم لاحتواء نص رياضي (لا تخلط بينها وبين [**Portion**](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)). [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) تسمح بالتلاعب بمجموعة من الكتل الرياضية. تعتبر الفئات السالفة الذكر هي المفتاح للعمل مع معادلات الرياضيات في PowerPoint عبر Aspose.Slides API.

لنرى كيف يمكننا إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، أولاً، أضف شكلًا سيحتوي على النص الرياضي:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```

بعد الإنشاء، سيكون الشكل يحتوي بالفعل على فقرة واحدة مع جزء رياضي بشكل افتراضي. فئة [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) هي جزء يحتوي على نص رياضي داخلي. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)، ارجع إلى المتغير [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/):

```py
    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph
```

فئة [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) تسمح بقراءة، إضافة، تعديل وحذف الكتل الرياضية ([**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/))، التي تتكون من مزيج من العناصر الرياضية. على سبيل المثال، قم بإنشاء كسر وضعه في العرض التقديمي:

```py
    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))
```

كل عنصر رياضي يتم تمثيله بواسطة فئة معينة تImplement the[**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)interface. يوفر هذا الواجهة الكثير من الطرق لإنشاء تعبيرات رياضية بسهولة. يمكنك إنشاء تعبير رياضي معقد تمامًا بسطر واحد من التعليمات البرمجية. على سبيل المثال، سيكون مبرهنة فيثاغورس كما يلي:

```py
    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))
```

تُنفذ عمليات الواجهة [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) في أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

مثال كامل على كود المصدر:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))

    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    mathParagraph.add(mathBlock)

    pres.save("math.pptx", slides.export.SaveFormat.PPTX)
```

## **أنواع العناصر الرياضية**
تتشكل التعبيرات الرياضية من تسلسل من العناصر الرياضية. يتم تمثيل تسلسل العناصر الرياضية بواسطة كتلة رياضية، وتشكّل معايير العناصر الرياضية تعشيشًا شبيها بالشجرة.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. يمكن تضمين كل من هذه العناصر (تجميعها) في عنصر آخر. أي أن العناصر هي في الواقع حاويات لغيرها، تشكل بنية شبيهة بالشجرة. أبسط نوع من العناصر التي لا تحتوي على عناصر أخرى من النص الرياضي.

كل نوع من عناصر الرياضيات ي实现the[**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)interface، مما يسمح باستخدام مجموعة شائعة من العمليات الرياضية على أنواع مختلفة من عناصر الرياضيات.
### **فئة MathematicalText**
تمثل فئة [**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) نصًا رياضيًا - العنصر الأساسي لجميع الإنشاءات الرياضية. يمكن أن يمثل النص الرياضي عوامل وعمليات، متغيرات، وأي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐
### **فئة MathFraction**
تحدد فئة [**MathFraction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) كائن الكسر، المكون من بسط ومقام مفصولين بعلامة كسر. يمكن أن تكون علامة الكسر أفقية أو قطرية، حسب خصائص الكسر. يُستخدم كائن الكسر أيضًا لتمثيل دالة المكدس، التي تضع عنصرًا فوق آخر، دون علامة كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **فئة MathRadical**
تحدد فئة [**MathRadical**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) دالة الجذر (الجذر الرياضي)، المكونة من قاعدة، ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **فئة MathFunction**
تحدد فئة [**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) دالة من وسيط. تحتوي على خصائص: [Name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/)- اسم الدالة و[Base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - وسيط الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **فئة MathNaryOperator**
تحدد فئة [**MathNaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) كائن رياضي N-ary، مثل الجمع والتكامل. يتكون من عامل، قاعدة (أو عامل)، وحدود عليا وسفلى اختيارية. أمثلة على العمليات N-ary هي الجمع، الاتحاد، التقاطع، التكامل.

تتناسب هذه الفئة مع العوامل البسيطة مثل الجمع، الطرح، وما إلى ذلك، حيث يتم تمثيلها بعنصر نصي واحد - [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **فئة MathLimit**
تحدد فئة [**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) الحد العلوي أو السفلي. تحدد كائن الحد، المكون من نص على الخط الأساسي ونص بحجم مصغر مباشرة فوقه أو تحته. لا تتضمن هذه العناصر كلمة "lim"، لكنها تسمح لك بوضع نص في الأعلى أو في الأسفل من التعبير. لذلك، يتم إنشاء التعبير

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مزيج من عناصر [**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) و[**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) بهذه الطريقة:

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
    mathFunc = math.MathFunction(funcName, math.MathematicalText("𝑥"))
```

### **فئات MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

تحدد الفئات التالية مؤشرًا سفليًا أو علويًا. يمكنك ضبط الأسفل والعلوي في نفس الوقت على الجانب الأيسر أو الأيمن من وسيط، ولكن يتم دعم المؤشر السفلي أو العلوي المنفرد فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) لضبط الدرجة الرياضية لعدد.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **فئة MathMatrix**
تحدد فئة [**MathMatrix**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) كائن المصفوفة، الذي يتكون من عناصر فرعية مرتبة في صفوف وأعمدة واحدة أو أكثر. من المهم ملاحظة أن المصفوفات لا تحتوي على فواصل مدرجة. لوضع المصفوفة في الأقواس، يجب أن تستخدم كائن الفاصل - [**IMathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/). يمكن استخدام الوسائط Null لإنشاء فواصل في المصفوفات.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **فئة MathArray**
تحدد فئة [**MathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) مصفوفة رأسية من المعادلات أو أي كائنات رياضية.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **تنسيق العناصر الرياضية**
- فئة [**MathBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/): ترسم حدودًا مستطيلة أو غيرها حول [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [**MathBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/): تحدد تغليف (تعبئة) منطقي للعنصر الرياضي. على سبيل المثال، يمكن أن يكون الكائن المغلف بمثابة محاكي عامل مع أو بدون نقطة توسيط، أو يمكن أن يكون نقطة كسر سطر، أو أن يتم تجميعها بحيث لا تسمح بانقطاع الأسطر داخل. على سبيل المثال، يجب أن يتم تغليف العامل "==" لمنع انقطاعات الأسطر.
- فئة [**MathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/): تحدد كائن الفاصل، المكون من حروف الافتتاح والإغلاق (مثل الأقواس، والأقواس، والإطارات، والأعمدة الرأسية)، وواحد أو أكثر من العناصر الرياضية بداخله، مفصولة بحرف محدد. الأمثلة: (𝑥2); [𝑥2|𝑦2].
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [**MathAccent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/): تحدد دالة التنوين، المكونة من قاعدة وعلامة ديكرية تجمع.

  مثال: 𝑎́.

- فئة [**MathBar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/): تحدد دالة البار، المكونة من وسيط أساسي وبار فوق أو تحت.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [**MathGroupingCharacter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/): تحدد رمز تجميع فوق أو تحت تعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **العمليات الرياضية**
كل عنصر رياضي وتعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) ينفذ الواجهة [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). يسمح لك باستخدام العمليات على الهيكل القائم وتشكيل التعبيرات الرياضية الأكثر تعقيدًا. جميع العمليات لها مجموعتي معلمات: إما [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) أو سلسلة كوسائط. يتم إنشاء مثيلات من فئة [**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) ضمنيًا من السلاسل المحددة عند استخدام وسائط السلاسل. العمليات الرياضية المتاحة في Aspose.Slides مُدرجة أدناه.
### **طريقة Join**
- [Join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

يضم عنصر رياضي ويشكل كتلة رياضية. على سبيل المثال:

```py
    element1 = math.MathematicalText("x")
    element2 = math.MathematicalText("y")
    block = element1.join(element2)
```
### **طريقة Divide**
- [Divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

تنشئ كسرًا من النوع المحدد مع هذا البسط والمقام المحددين. على سبيل المثال:

```py
    numerator = math.MathematicalText("x")
    fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```
### **طريقة Enclose**
- [Enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

يحيط العنصر بحروف محددة مثل الأقواس أو حرف آخر كإطار.

```py
# يحيط عنصر رياضي بأقواس
MathDelimiter enclose()

# يحيط هذا العنصر بحروف محددة مثل الأقواس أو حروف أخرى كإطار
MathDelimiter enclose(char beginningCharacter, char endingCharacter)
```


على سبيل المثال:

```py
    delimiter = math.MathematicalText("x").enclose('[', ']')
    delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```
### **طريقة Function**
- [Function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

تأخذ دالة من وسيط باستخدام الكائن الحالي كاسم الدالة.

على سبيل المثال:

```py
func = math.MathematicalText("sin").function("x")
```
### **طريقة AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

تأخذ الدالة المحددة باستخدام المثيل الحالي كوسيط. يمكنك:

- تحديد سلسلة كاسم الدالة، على سبيل المثال "cos".
- اختيار واحدة من القيم المحددة مسبقًا للتعدادات [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/)، على سبيل المثال **MathFunctionsOfOneArgument.ArcSin.**
- اختيار مثيل [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

على سبيل المثال:

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
    func1 = math.MathematicalText("2x").as_argument_of_function(funcName)
    func2 = math.MathematicalText("x").as_argument_of_function("sin")
    func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
    func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```
### **طرق SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

تضبط الأسفل والعلوي. يمكنك ضبط الأسفل والعلوي في نفس الوقت على الجانب الأيسر أو الأيمن من الوسيط، لكن يتم دعم المؤشر السفلي أو العلوي المنفرد فقط على الجانب الأيمن. يمكن استخدام **Superscript** أيضًا لضبط الدرجة الرياضية لعدد.

مثال:

```py
    script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```
### **طريقة Radical**
- [Radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

تحدد الجذر الرياضي من الدرجة المعطاة من الوسيط المحدد.

مثال:

```py
    radical = math.MathematicalText("x").radical("3")
```
### **طرق SetUpperLimit وSetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

تأخذ الحد العلوي أو السفلي. هنا، يشير العلوي والسفلي ببساطة إلى موقع الوسيط بالنسبة للأساس.

دعونا نعتبر تعبيرًا: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات من خلال مزيج من الفئات [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) و[MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/)، وعمليات [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) كما يلي:

```py
mathExpression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```
### **طرق Nary وIntegral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

تقوم كل من **Nary** و**Integral** بإنشاء وإرجاع عامل N-ary تمثله نوع [**INaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathnaryoperator/) . في طريقة Nary، تحدد التعدادات [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) نوع العامل: الجمع، الاتحاد، وما إلى ذلك، دون تضمين التكاملات. في طريقة التكامل، هناك العملية المتخصصة Integral مع تعداد أنواع التكامل [**MathIntegralTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/). 

مثال:

```py
    baseArg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
    integral = baseArg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```
### **طريقة ToMathArray**
تضع [**ToMathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) العناصر في مصفوفة عمودية. إذا تم استدعاء هذه العملية لنسخة **MathBlock**، سيتم وضع جميع العناصر الفرعية في المصفوفة المعادة.

مثال:

```py
    arrayFunction = math.MathematicalText("x").join("y").to_math_array()
```
### **عمليات التنسيق: Accent، Overbar، Underbar، Group، ToBorderBox، ToBox**
- تحدد طريقة [**Accent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) علامة التنوين (حرف على قمة العنصر).
- تحدد طرق [**Overbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) و[**Underbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) شريطًا في الأعلى أو الأسفل.
- تحدد طريقة [**Group**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) التجميع باستخدام حرف التجميع مثل القوس السفلي المتعرج أو أي قوس آخر.
- تحدد طريقة [**ToBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) وضعها في مربع حدود.
- تحدد طريقة [**ToBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) وضعها في مربع غير مرئي (تجميع منطقي).

أمثلة:

```py
    accent = math.MathematicalText("x").accent(chr(0x0303))
    bar = math.MathematicalText("x").overbar()
    groupChr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
            math.MathTopBotPositions.BOTTOM, 
            math.MathTopBotPositions.TOP)
    borderBox = math.MathematicalText("x+y+z").to_border_box()
    boxedOperator = math.MathematicalText(":=").to_box()
```