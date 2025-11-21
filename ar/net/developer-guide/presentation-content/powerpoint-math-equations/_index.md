---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية في .NET
linktitle: معادلات رياضية PowerPoint
type: docs
weight: 80
url: /ar/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "إدراج وتحرير المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides لـ .NET، مع دعم OMML، وتنسيق التحكم، وعينات شفرة C# واضحة."
---

## **نظرة عامة**

في PowerPoint، يمكنك كتابة معادلة رياضية أو صيغة وعرضها في العرض التقديمي الخاص بك. تتوفر رموز رياضية متنوعة يمكن إضافتها إلى النص أو المعادلات. يُستخدم منشئ المعادلات الرياضية لإنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- الحدود والدوال اللوغاريتمية
- عمليات N-ary
- مصفوفة
- عوامل كبيرة
- دوال الجيب وجيب التمام

لإضافة معادلة رياضية في PowerPoint، يتم استخدام القائمة *Insert -> Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيفتح هذا نصاً رياضياً بصيغة XML يمكن عرضه في PowerPoint كما يلي: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint مجموعة واسعة من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، غالباً ما لا ينتج عن توليد معادلات رياضية معقدة في PowerPoint نتيجة polished ، احترافية. لذلك، يلجأ المستخدمون الذين ينشئون عروضاً تقديمية رياضية كثيراً إلى حلول خارجية للحصول على صيغ رياضية ذات مظهر أفضل.

باستخدام [**Aspose.Slides API**](https://products.aspose.com/slides/net/)، يمكنك التعامل مع المعادلات الرياضية في عروض PowerPoint برمجياً باستخدام C#. أنشئ تعبيرات رياضية جديدة أو حرّر تلك التي تم إنشاؤها مسبقاً. يتوفر دعم جزئي لتصدير البُنى الرياضية كصور.

## **كيفية إنشاء معادلة رياضية**

تُستَخدم العناصر الرياضية لبناء أي تركيب رياضي، بغض النظر عن مستوى التداخل. تُشكل مجموعة خطية من هذه العناصر كتلة رياضية، تمثّلها الفئة [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). تمثّل فئة [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) تعبيراً رياضياً مستقلاً أو صيغة أو معادلة. تُستخدم فئة [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) لحمل النص الرياضي (مختلف عن فئة [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) العادية)، بينما تسمح فئة [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) بالتعامل مع مجموعة من كائنات [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). تُعد هذه الفئات أساسية للعمل مع معادلات PowerPoint الرياضية عبر Aspose.Slides API.

دعونا نرى كيف يمكننا إنشاء المعادلة الرياضية التالية باستخدام Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، أضف أولاً شكلاً سيحتوي على النص الرياضي:
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```


بعد إنشاء الشكل، يحتوي افتراضياً على فقرة واحدة مع Portion رياضية. تمثّل فئة [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) Portion يحتوي على نص رياضي. للوصول إلى المحتوى الرياضي داخل [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion)، راجع المتغيّر [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph):
```cs
var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```


تتيح لك فئة [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) قراءة وإضافة وتحرير وحذف كتل رياضية ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock))، والتي تتألف من مجموعة من العناصر الرياضية. على سبيل المثال، أنشئ كسراً وضعه في العرض:
```cs
var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));
```


يُمثَّل كل عنصر رياضي بفئة تنفّذ واجهة [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement). توفّر هذه الواجهة العديد من الأساليب لإنشاء تعبيرات رياضية بسهولة، مما يتيح لك بناء معادلات معقدة بسطر واحد من الشيفرة. على سبيل المثال، صيغة فيثاغورس ستبدو هكذا:
```cs
var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```


يتم تنفيذ عمليات واجهة [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) في كل نوع من العناصر، بما في ذلك فئة [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

فيما يلي مثال كامل على الشيفرة المصدرية:
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
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

    presentation.Save("math.pptx", SaveFormat.Pptx);
}
```


## **أنواع العناصر الرياضية**

تتكوّن التعبيرات الرياضية من تسلسلات من العناصر الرياضية. تمثّل الكتلة الرياضية مثل هذا التسلسل، وتشكل معاملات هذه العناصر بنية شجرية متداخلة.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. يمكن تجميع كل من هذه العناصر داخل أخرى، مكوّنةً بنية شجرية. أبسط نوع من العناصر هو الذي لا يحتوي على أي عناصر نصية رياضية أخرى.

كل نوع من العناصر الرياضية ينفّذ واجهة [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)، مما يتيح لك استعمال مجموعة موحَّدة من عمليات الرياضيات على أنواع مختلفة من العناصر.

### **فئة MathematicalText**

تمثّل فئة [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) نصاً رياضياً - العنصر الأساسي لجميع التركيبات الرياضية. قد يرمز النص الرياضي إلى معاملات وعوامل، أو متغيّرات، أو أي نص خطّي آخر.

مثال: 𝑎=𝑏+𝑐

### **فئة MathFraction**

تحدِّد فئة [MathFraction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) كائن كسر يتكوّن من بسط ومقام يفصلهما شريط الكسر. قد يكون شريط الكسر أفقياً أو مائلاً حسب خصائص الكسر. يُستخدم كائن الكسر أيضاً لتمثيل دالة الستاك، التي تضع عنصراً فوق آخر دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **فئة MathRadical**

تحدِّد فئة [MathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) دالة الجذر الرياضي، وتتكوّن من أساس ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **فئة MathFunction**

تحدّد فئة [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) دالة لوسيط. تحتوي على خصائص مثل [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name) التي تمثِّل اسم الدالة، و[Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base) التي تمثّل وسيط الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **فئة MathNaryOperator**

تحدِّد فئة [MathNaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) كائناً رياضياً من نوع N‑ary، مثل الجمع أو التكامل. يتكوّن من عامل، أساس (أو معامل)، ودرجات سفلية وعليا اختيارية. تشمل أمثلة عوامل N‑ary الجمع، الاتحاد، التقاطع، والتكامل.

هذه الفئة لا تشمل عوامل بسيطة مثل الجمع أو الطرح؛ يتم تمثيلها بنص واحد من فئة [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **فئة MathLimit**

تُنشئ فئة [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) الحد العلوي أو السفلي. تحدد كائن الحد نصاً على خط القاعدة ونصاً أصغر حجماً فوقه أو تحته مباشرة. لا يتضمّن هذا العنصر كلمة "lim"، بل يتيح لك وضع النص في أعلى أو أسفل التعبير. وبالتالي، يُنشأ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مزيج من فئتي [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) و[MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) كما يلي:
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```


### **فئات MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**

- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

تحدد هذه الفئات مؤشرًا سفليًا أو علويًا. يمكنك ضبط كلٍ من المؤشر السفلي والعلوي معًا على الجانب الأيسر أو الأيمن من الوسيط، لكن يُدعم مؤشر واحد فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) لتعيين درجة رياضية لعدد.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **فئة MathMatrix**

تحدِّد فئة [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) كائن مصفوفة يتكوّن من عناصر فرعية مرتبة في صفوف وأعمدة. تجدر الإشارة إلى أن المصفوفات لا تحتوي على فواصل داخلية مدمجة؛ لتطويق المصفوفة بأقواس استخدم كائن الفاصل [IMathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). يمكن تمرير حجج فارغة لإنشاء فراغات داخل المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **فئة MathArray**

تحدِّد فئة [MathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) مصفوفة رأسية من معادلات أو أي كائنات رياضية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**

- فئة [MathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox): ترسم حدًا مستطيلاً أو بديلاً حول عنصر [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).

مثال:

![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [MathBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox): تحدد تغليفًا منطقيًا لكائن رياضي. يمكن أن يعمل الكائن المغلف كمحاكٍ للعامل—مع أو بدون نقطة محاذاة—أو يعمل كقاطع سطر، أو يتم تجميعه لمنع كسر السطر داخله. على سبيل المثال، يجب تغليف العامل "==" لمنع كسر السطر.

- فئة [MathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter): تحدد كائن الفاصل، الذي يتكوّن من حرفي فتح وإغلاق (مثل الأقواس أو الأقواس المربعة أو الأعمدة العمودية) وعناصر رياضية داخلية مفصولة بحرف محدد. أمثلة: (𝑥2); [𝑥2|𝑦2].

مثال:

![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [MathAccent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent): تحدد دالة اللكنة، التي تتكوّن من قاعدة وعلامة تشكيلية ملتحمة.

مثال: 𝑎́.

- فئة [MathBar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar): تحدد دالة الشريط، التي تتكوّن من وسيط أساسي وشريط علوي أو سفلي.

مثال:

![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [MathGroupingCharacter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter): تحدد رموز تجميع توضع أعلى أو أسفل تعبير، عادةً لتوضيح العلاقات بين العناصر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**

كل عنصر رياضي وكل تعبير رياضي (عبر فئة [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) ينفّذ واجهة [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement). يتيح لك ذلك إجراء عمليات على البنية الحالية وتكوين تعبيرات رياضية أكثر تعقيدًا. جميع العمليات لها مجموعتان من المعاملات: إما [IMathElement] أو سلاسل نصية. تُنشَأ كائنات فئة [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) ضمنيًا من السلاسل النصية عند استخدامها كمعاملات. تُدرج عمليات الرياضيات المتاحة في Aspose.Slides أدناه.

### **طريقة Join**

- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

تدمج هذه الطرق عنصرًا رياضيًا وتكوّن كتلة رياضية. مثال:
```cs
IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);
```


### **طريقة Divide**

- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

تنشئ هذه الطرق كسرًا من النوع المحدد مع بسط ومقام محدد. مثال:
```cs
IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```


### **طريقة Enclose**

- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

تطويق العنصر بأحرف محددة، مثل الأقواس أو غيرها من أحرف الإطار. مثال:
```cs
IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```


### **طريقة Function**

- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

تُنشئ دالة لوسيط باستخدام الكائن الحالي كاسم الدالة. مثال:
```cs
IMathFunction func = new MathematicalText("sin").Function("x");
```


### **طريقة AsArgumentOfFunction**

- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

تُمرّر الدالة المحددة باستخدام الكائن الحالي كوسيط. يمكنك:

- تحديد سلسلة كاسم الدالة، مثل "cos";
- اختيار أحد القيم المُعرّفة مسبقاً في تعداد [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) أو [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments)، مثل `MathFunctionsOfOneArgument.ArcSin`;
- تمرير مثال من واجهة [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement).

مثال:
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);
var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");
var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);
var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3")
```


### **طرق SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**

- [SetSubscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

تحدد هذه الطرق مؤشرًا سفليًا أو علويًا. يمكنك ضبط كلاهما معًا إما على اليسار أو اليمين؛ لكن يُسمح بمؤشر واحد فقط على اليمين. يمكن أيضًا استخدام **Superscript** لضبط درجة رياضية لعدد.

مثال:
```cs
var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```


### **طريقة Radical**

- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

تحدِّد هذه الطرق الجذر الرياضي للدرجة المعطاة بناءً على الوسيط المحدد.

مثال:
```cs
var radical = new MathematicalText("x").Radical("3");
```


### **طريقة SetUpperLimit و SetLowerLimit**

- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

تأخذ هذه الطرق حدًا علويًا أو سفليًا، حيث يشير "upper" و"lower" إلى موضع الوسيط بالنسبة للأساس.

ننظر إلى التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات عبر دمج فئتي [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) و[MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit) مع عمليات واجهة [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) كالتالي:
```cs
var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");
```


### **طرق Nary و Integral**

- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/methods/4)

تنشئ كل من طريقتي **Nary** و**Integral** وتعيد كائن عامل N‑ary من نوع [INaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator). في طريقة Nary، يحدّد تعداد [MathNaryOperatorTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) نوع العامل—مثل الجمع أو الاتحاد—مع استثناء التكاملات. في طريقة Integral، يُوفَّر عملية متخصصة للتكاملات باستخدام تعداد [MathIntegralTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes).

مثال:
```cs
IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```


### **طريقة ToMathArray**

تضع طريقة [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) العناصر في مصفوفة رأسية. إذا نُفّذت هذه العملية على مثال من [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)، توضع جميع عناصره الفرعية في المصفوفة المرجعة.

مثال:
```cs
var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```


### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- طريقة [Accent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) تضيف علامة تشديد (حرف فوق العنصر).
- طريقتا [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) و[Underbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) تضيفان شريطًا أعلى أو أسفل العنصر.
- طريقة [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) تضع العنصر في مجموعة باستخدام رمز تجميع مثل القوس المعقوف السفلي أو غيره.
- طريقة [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) تضع العنصر في صندوق حدود.
- طريقة [ToBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) تضع العنصر في صندوق غير مرئي (تجميع منطقي).

أمثلة:
```cs
var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```


## **الأسئلة المتكررة**

**كيف يمكنني إضافة معادلة رياضية إلى شريحة PowerPoint؟**

لإضافة معادلة رياضية، تحتاج إلى إنشاء كائن `MathShape`، الذي يحتوي تلقائيًا على Portion رياضي. بعد ذلك، تستخرج `MathParagraph` من `MathPortion` وتضيف كائنات `MathBlock` إليه.

**هل يمكن إنشاء تعبيرات رياضية متداخلة معقدة؟**

نعم، يتيح لك Aspose.Slides إنشاء تعبيرات رياضية معقدة عبر تداخل MathBlocks. كل عنصر رياضي ينفّذ واجهة `IMathElement` التي تسمح لك بتطبيق عمليات (Join، Divide، Enclose، إلخ) لدمج العناصر في تركيبات أكثر تعقيدًا.

**كيف يمكنني تعديل أو تحديث معادلة رياضية موجودة؟**

لتحديث معادلة، عليك الوصول إلى MathBlocks الموجودة عبر `MathParagraph`. ثم باستخدام أساليب مثل Join، Divide، Enclose وغيرها، يمكنك تعديل عناصر المعادلة الفردية. بعد التحرير، احفظ العرض لتطبيق التغييرات.