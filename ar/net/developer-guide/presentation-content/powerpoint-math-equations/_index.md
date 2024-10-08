---
title: معادلات الرياضيات في PowerPoint
type: docs
weight: 80
url: /ar/net/powerpoint-math-equations/
keywords: "معادلات الرياضيات PowerPoint، رموز الرياضيات PowerPoint، صيغة PowerPoint، نص الرياضيات PowerPoint، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "معادلات الرياضيات PowerPoint، رموز الرياضيات، صيغة، ونص الرياضيات في C# أو .NET"
---

## **نظرة عامة**
في PowerPoint، من الممكن كتابة معادلة رياضية أو صيغة وعرضها في العرض التقديمي. لتحقيق ذلك، يتم تمثيل العديد من الرموز الرياضية في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لذلك، يتم استخدام مُنشئ المعادلات الرياضية في PowerPoint، الذي يساعد في إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذري رياضي
- دالة رياضية
- حدود ودوال لوغاريتمية
- عمليات N-ary
- مصفوفة
- مشغلات كبيرة
- دوال الجيب، جيب التمام

لإضافة معادلة رياضية في PowerPoint، يتم استخدام قائمة *إدراج -> معادلة*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيؤدي ذلك إلى إنشاء نص رياضي في XML يمكن عرضه في PowerPoint كما يلي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يقدم PowerPoint العديد من الرموز الرياضية لإنشاء معادلات رياضية. ومع ذلك، فإن إنشاء معادلات رياضية معقدة في PowerPoint غالبًا لا ينتج عنه نتائج جيدة ومهنية. يلجأ المستخدمون، الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر، إلى استخدام حلول طرف ثالث لإنشاء صيغ رياضية رائعة.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/net/)، يمكنك العمل مع المعادلات الرياضية في عروض PowerPoint برمجيًا في C#. أنشئ تعبيرات رياضية جديدة أو حرر التعبيرات التي تم إنشاؤها مسبقًا. كما أن تصدير الهياكل الرياضية إلى الصور مدعوم جزئيًا.


## **كيفية إنشاء معادلة رياضية**
تستخدم العناصر الرياضية لبناء أي منشآت رياضية مع أي مستوى من التعشيش. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية ممثلة بواسطة [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)class. تعد [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)class في الأساس تعبيرًا رياضيًا منفصلًا أو صيغة أو معادلة. [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) هي جزء رياضي، يُستخدم لحمل نص رياضي (لا تخلط بينها وبين [**Portion**](https://reference.aspose.com/slides/net/aspose.slides/portion)). يتيح [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph)التلاعب بمجموعة من الكتل الرياضية. الفصول المذكورة أعلاه هي المفتاح للعمل مع معادلات الرياضيات في PowerPoint عبر Aspose.Slides API.



لنرى كيف يمكننا إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي على الشريحة، أولاً، أضف شكلًا سيكون يحتوي على النص الرياضي:

``` csharp

 using (Presentation pres = new Presentation())

{

    var mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

}

```


بعد الإنشاء، سيتضمن الشكل بالفعل فقرة واحدة مع جزء رياضي بشكل افتراضي. تعد [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion)class جزءًا يحتوي على نص رياضي في داخله. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion)، اشير إلى متغير [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph):

``` csharp

 var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

```


تسمح [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph)class بقراءة وإضافة وتحرير وحذف كتل الرياضيات ([**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock))، التي تتكون من مجموعة من العناصر الرياضية. على سبيل المثال، أنشئ كسرًا وضعه في العرض التقديمي:

``` csharp

 var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));

```


يمثل كل عنصر رياضي بعض الفصول التي تنفذ واجهة [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement). توفر هذه الواجهة العديد من الطرق لإنشاء تعبيرات رياضية بسهولة. يمكنك إنشاء تعبير رياضي معقد إلى حد ما بخط واحد من التعليمات البرمجية. على سبيل المثال، ستبدو نظرية فيثاغورس كما يلي:

``` csharp

 var mathBlock = new MathematicalText("c")

    .SetSuperscript("2")

    .Join("=")

    .Join(new MathematicalText("a").SetSuperscript("2"))

    .Join("+")

    .Join(new MathematicalText("b").SetSuperscript("2"));

```



تُنفذ عمليات واجهة [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) في أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

الكود المصدر الكامل:

``` csharp

 using (Presentation pres = new Presentation())

{

    IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

   var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;



   var fraction = new MathematicalText("x").Divide("y");

    mathParagraph.Add(new MathBlock(fraction));



   var mathBlock = new MathematicalText("c")

        .SetSuperscript("2")

        .Join("=")

        .Join(new MathematicalText("a").SetSuperscript("2"))

        .Join("+")

        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);

    pres.Save("math.pptx", SaveFormat.Pptx);

}

```


## **أنواع العناصر الرياضية**
تتكون التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يُمثل تسلسل العناصر الرياضية كتلة رياضية، وتشكل حجج العناصر الرياضية تعشيشًا شبيهاً بالشجرة.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. يمكن تضمين كل من هذه العناصر (تجميعها) في عنصر آخر. بمعنى، العناصر هي في الواقع حاويات للأخرى، تشكل بنية شبيهة بالشجرة. أبسط نوع من العناصر هو الذي لا يحتوي على عناصر أخرى من النص الرياضي.

يطبق كل نوع من عناصر الرياضيات واجهة [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)، مما يسمح باستخدام مجموعة شائعة من العمليات الرياضية على أنواع مختلفة من عناصر الرياضيات.
### **فئة MathematicalText**
تمثل [**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext)class نصًا رياضيًا - العنصر الأساسي لجميع الإنشاءات الرياضية. يمكن أن يمثل النص الرياضي المعاملات والمشغلات والمتغيرات وأي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐
### **فئة MathFraction**
تحدد [**MathFraction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction)class كائن الكسر، الذي يتكون من بسط ومقام مفصولين بعرض كسر. يمكن أن يكون عرض الكسر أفقيًا أو مائلًا، اعتمادًا على خصائص الكسر. يُستخدم كائن الكسر أيضًا لتمثيل دالة الكومة، التي تضع عنصرًا فوق عنصر آخر، بدون عرض كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **فئة MathRadical**
تحدد [**MathRadical**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical)class دالة الجذر (الجذر الرياضي)، التي تتكون من قاعدة، ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **فئة MathFunction**
تحدد [**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction)class دالة من وسيط. يحتوي على الخصائص: [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name) - اسم الدالة و[Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base) - وسيط الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **فئة MathNaryOperator**
تحدد [**MathNaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator)class كائن رياضي N-ary، مثل الجمع والتكامل. يتكون من مشغل، قاعدة (أو وسيط)، وحدود علوية وسفلية اختيارية. تشمل أمثلة مشغلات N-ary الجمع، الاتحاد، التقاطع، التكامل.

لا تشمل هذه الفئة المشغلين البسيطين مثل الجمع، الطرح، وما إلى ذلك. يتم تمثيلهم بعنصر نصي واحد - [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **فئة MathLimit**
تحدد [**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit)class الحد العلوي أو السفلي. تحدد كائن الحد، الذي يتكون من نص على قاعدة النص ونص بحجم مصغر عالٍ أو منخفض مباشرةً فوقه أو تحته. لا تتضمن هذه العنصر كلمة "lim"، ولكنها تسمح لك بوضع النص في الجزء العلوي أو السفلي من التعبير. لذلك، يتم إنشاء التعبير

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مجموعة من عناصر [**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction)و[**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) بهذه الطريقة:

``` csharp

 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));

```


### **فئات MathSubscriptElement و MathSuperscriptElement و MathRightSubSuperscriptElement و MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

تحدد الفئات التالية مؤشرًا سفليًا أو مؤشراً علويًا. يمكنك تعيين الكتابة السفلية والكتابة الفوقية في نفس الوقت على الجانب الأيسر أو الأيمن من وسيط، ولكن يتم دعم الكتابة السفلية أو الكتابة الفوقية المفردة فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)لتعيين الدرجة الرياضية لعدد.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **فئة MathMatrix**
تحدد [**MathMatrix**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix)class كائن المصفوفة، الذي يتكون من عناصر فرعية مرتبة في صفوف وأعمدة واحدة أو أكثر. من المهم ملاحظة أن المصفوفات لا تحتوي على محددات مدمجة. لوضع المصفوفة في الأقواس، يجب عليك استخدام كائن المحدد - [**IMathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). يمكن استخدام وسيطات فارغة لإنشاء فجوات في المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **فئة MathArray**
تحدد [**MathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray)class مصفوفة عمودية من المعادلات أو أي كائنات رياضية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **تنسيق العناصر الرياضية**
- [**MathBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox)class: يرسم حدًا مستطيلًا أو حدًا آخر حول [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox)class: تحدد تغليفًا منطقيًا (تعبئة) للعناصر الرياضية. على سبيل المثال، يمكن أن يكون الكائن المعبأ بمثابة محاكي عامل تشغيل مع أو بدون نقطة محاذاة، أو أن يكون نقطة كسر سطر، أو يتم تجميعه بحيث لا يُسمح بحدوث فواصل سطر ضمن ذلك. على سبيل المثال، يجب أن يتم تعبئة عامل التشغيل "==" لمنع حدوث فواصل سطر.
- [**MathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter)class: تحدد كائن المحدد، الذي يتكون من أحرفopening وclosing (مثل الأقواس، والأقفال، والأقواس، والأعمدة الرأسية)، وواحد أو أكثر من العناصر الرياضية بالداخل، مفصولة بحرف محدد. أمثلة: (𝑥2); [𝑥2|𝑦2].
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent)class: تحدد دالة التمييز، التي تتكون من قاعدة وعلامة مميزة تجمع.

  مثال: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar)class: تحدد دالة الشريط، والتي تتكون من وسيط أساسي وشريط علوي أو سفلي.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter)class: تحدد رمز التجميع فوق أو تحت تعبير، عادةً لإبراز العلاقات بين العناصر.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **العمليات الرياضية**
يتم تنفيذ كل عنصر رياضي وتعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) الواجهة [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)واجهة. يسمح لك ذلك باستخدام العمليات على الهيكل الحالي وشكل التعبيرات الرياضية الأكثر تعقيدًا. تحتوي جميع العمليات على مجموعتين من المعلمات: إما [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)أو سلسلة كوسائط. يتم إنشاء مثيلات فئة [**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText)implicit من السلاسل المحددة عند استخدام وسائط سلسلة. تتوفر العمليات الرياضية في Aspose.Slides مدرجة أدناه.
### **طريقة Join**
- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

تنضم إلى عنصر رياضي وتشكيل كتلة رياضية. على سبيل المثال:

``` csharp

 IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);

```
### **طريقة Divide**
- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

ينشئ كسرًا من النوع المحدد باستخدام البسط المحدد والمقام المحدد. على سبيل المثال:

``` csharp

 IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);

```
### **طريقة Enclose**
- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

تغلق العنصر في أحرف محددة مثل الأقواس أو حرف آخر كتأطير.

``` csharp

 /// <summary>

/// تغلق عنصر رياضي في الأقواس

/// </summary>

IMathDelimiter Enclose();

/// <summary>

/// تغلق هذا العنصر في أحرف محددة مثل الأقواس أو أحرف أخرى كتأطير

/// </summary>

IMathDelimiter Enclose(char beginningCharacter, char endingCharacter);

```


على سبيل المثال:

``` csharp

 IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();

```
### **طريقة Function**
- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

تأخذ دالة من وسيط باستخدام الكائن الحالي كاسم الدالة.

``` csharp

 /// <summary>

/// تأخذ دالة من وسيط باستخدام هذه الحالة كاسم للدالة

/// </summary>

/// <param name="functionArgument">وسيط الدالة</param>

IMathFunction Function(IMathElement functionArgument);

IMathFunction Function(string functionArgument);

```


على سبيل المثال:

``` csharp

 IMathFunction func = new MathematicalText("sin").Function("x");

```
### **طريقة AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/methods/3)

تأخذ الدالة المحددة باستخدام العينة الحالية كوسيط. يمكنك:

- تحديد سلسلة كاسم الدالة، على سبيل المثال "cos".
- اختيار واحدة من القيم المحددة مسبقًا من التعدادات [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument)أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments)، مثل **MathFunctionsOfOneArgument.ArcSin.**
- تحديد مثيل من [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement).

على سبيل المثال:

``` csharp

 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);

var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");

var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3")

```
### **طرق SetSubscript و SetSuperscript و SetSubSuperscriptOnTheRight و SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

تحدد الكتابة السفلية والكتابة الفوقية. يمكنك تعيين الكتابة السفلية والكتابة الفوقية في نفس الوقت على الجانب الأيسر أو الأيمن من الوسيطة، ولكن يتم دعم الكتابة السفلية أو الكتابة الفوقية المفردة فقط على الجانب الأيمن. يمكن أيضًا استخدام الكتابة الفوقية لتعيين الدرجة الرياضية لعدد.

مثال:

``` csharp

 var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");

```
### **طريقة Radical**
- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

تحدد الجذر الرياضي للدرجة المحددة من الوسيطة المحددة.

مثال:

``` csharp

 var radical = new MathematicalText("x").Radical("3");

```
### **طرق SetUpperLimit و SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

تأخذ الحد العلوي أو السفلي. يشير الحد العلوي والأسفل ببساطة إلى موقع الوسيطة بالنسبة للأساس.

لننظر في تعبير: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات من خلال مجموعة من الفصول [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction)و[MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit)، وعمليات [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)كما يلي:

``` csharp

 var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");

```
### **طرق Nary و Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/4)

تقوم طرق **Nary** و **Integral** بإنشاء وإرجاع المشغل N-ary الممثل بواسطة النوع [**INaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator). في طريقة Nary، يحدد التعداد [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes)نوع المشغل: الجمع، الاتحاد، وما إلى ذلك، دون تضمين التكاملات. في طريقة Integral، هناك عملية متخصصة هي Integral مع تعداد أنواع التكامل [**MathIntegralTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes). 

مثال:

``` csharp

 IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());

IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");

```
### **طريقة ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) تضع العناصر في مصفوفة عمودية. إذا تم استدعاء هذه العملية لمثيل **MathBlock**، فسيتم وضع جميع العناصر الفرعية في المصفوفة المعادة.

مثال:

``` csharp

 var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();

```
### **عمليات التنسيق: Accent و Overbar و Underbar و Group و ToBorderBox و ToBox**
- تحدد طريقة [**Accent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) علامة التمييز (حرف في أعلى العنصر).
- تحدد طرق [**Overbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) و [**Underbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) بارًا في الأعلى أو الأسفل.
- تحدد طريقة [**Group**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) العنصر بوضعه في مجموعة باستخدام علامة تجميع مثل قوس سفلي متعرج أو غيره.
- تحدد طريقة [**ToBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) العنصر بوضعه في صندوق حدود.
- تحدد طريقة [**ToBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) العنصر بوضعه في صندوق غير مرئي (تجميع منطقي).

أمثلة:

``` csharp

 var accent = new MathematicalText("x").Accent('\u0303');

var bar = new MathematicalText("x").Overbar();

var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

var borderBox = new MathematicalText("x+y+z").ToBorderBox();

var boxedOperator = new MathematicalText(":=").ToBox();

```