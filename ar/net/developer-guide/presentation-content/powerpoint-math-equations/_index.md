---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية باستخدام C#
linktitle: معادلات رياضية PowerPoint
type: docs
weight: 80
url: /ar/net/powerpoint-math-equations/
keywords:
- معادلة رياضية
- معادلة رياضية PowerPoint
- رمز رياضي
- رمز رياضي PowerPoint
- صيغة رياضية
- صيغة رياضية PowerPoint
- نص رياضي
- نص رياضي PowerPoint
- إضافة معادلة رياضية إلى PowerPoint
- إضافة رمز رياضي إلى PowerPoint
- إضافة صيغة رياضية إلى PowerPoint
- إضافة نص رياضي إلى PowerPoint
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية العمل مع المعادلات الرياضية في PowerPoint باستخدام Aspose.Slides لـ .NET. احصل على إرشادات مفصلة، أمثلة على الشيفرة، ونصائح لأتمتة إنشاء وتعديل العروض التقديمية."
---

## **نظرة عامة**

في PowerPoint، يمكنك كتابة معادلة أو صيغة رياضية وعرضها في العرض التقديمي الخاص بك. تتوفر رموز رياضية مختلفة ويمكن إضافتها إلى النص أو المعادلات. يُستخدم مُنشئ المعادلات الرياضية لإنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- حدود ودوال اللوغاريتم
- عمليات n-ary
- مصفوفة
- عوامل كبيرة
- دوال جيب وجيب تمام

لإضافة معادلة رياضية في PowerPoint، يُستخدم القائمة *Insert -> Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيفتح هذا ملف نص رياضي بصيغة XML يمكن عرضه في PowerPoint كما يلي:  

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint مجموعة واسعة من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، غالبًا ما لا ينتج عن توليد معادلات رياضية معقدة في PowerPoint نتيجة أنيقة ومهنية. نتيجة لذلك، يلجأ المستخدمون الذين ينشئون عروضًا تقديمية رياضية بشكل متكرر إلى حلول الطرف الثالث للحصول على صيغ رياضية ذات مظهر أفضل.

باستخدام [**Aspose.Slides API**](https://products.aspose.com/slides/net/)، يمكنك التعامل مع المعادلات الرياضية في عروض PowerPoint برمجيًا بلغة C#. أنشئ تعبيرات رياضية جديدة أو حرّر تلك التي تم إنشاؤها مسبقًا. يتوفر دعم جزئي لتصدير الهياكل الرياضية كصور.

## **كيفية إنشاء معادلة رياضية**

تُستخدم العناصر الرياضية لبناء أي تركيب رياضي، بغض النظر عن مستوى التداخل. تشكّل مجموعة خطية من هذه العناصر كتلة رياضية، يُمثّلها الصف [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). تمثل فئة [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) تعبيرًا رياضيًا مستقلاً أو صيغة أو معادلة. تُستخدم فئة [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) لاحتواء النص الرياضي (مختلف عن فئة [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) العادية)، بينما تسمح فئة [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) بالتعامل مع مجموعة من كائنات [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). هذه الفئات أساسية للعمل مع معادلات PowerPoint الرياضية عبر Aspose.Slides API.

لنرَ كيف يمكننا إنشاء المعادلة الرياضية التالية باستخدام Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، أضف أولاً شكلًا سيحتوي على النص الرياضي:
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```


بعد إنشاء الشكل، يحتوي افتراضيًا على فقرة واحدة مع جزء رياضي. تمثل فئة [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) جزءًا يحتوي على نص رياضي. للوصول إلى المحتوى الرياضي داخل [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion)، راجع متغيّر [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph):
```cs
var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```


تسمح فئة [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) بقراءة وإضافة وتحرير وحذف كتل رياضية ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock))، والتي تتكوّن من مجموعة من العناصر الرياضية. على سبيل المثال، أنشئ كسرًا وضعه في العرض التقديمي:
```cs
var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));
```


يمثل كل عنصر رياضي فئة تنفّذ الواجهة [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement). توفر هذه الواجهة العديد من الأساليب لإنشاء تعبيرات رياضية بسهولة، ما يتيح لك بناء معادلات معقدة بسطر واحد من الشيفرة. على سبيل المثال، سيظهر مبرهنة فيثاغورس هكذا:
```cs
var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```


تُطبق عمليات الواجهة [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) في كل نوع من العناصر، بما في ذلك فئة [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

فيما يلي عينة الشيفرة الكاملة:
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

تُكوّن التعبيرات الرياضية تسلسلات من العناصر الرياضية. تمثّل الكتلة الرياضية مثل هذا التسلسل، وتُكوّن وسائط هذه العناصر بنية شجرية متداخلة.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لتكوين كتلة رياضية. يمكن تجميع كلٍ منها داخل أخرى، مكوّنةً بنية شجرية. أبسط نوع من العناصر هو ذلك الذي لا يحتوي على أي عناصر نصية رياضية أخرى.

كل نوع من العناصر الرياضية يطبق الواجهة [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)، مما يتيح لك استعمال مجموعة مشتركة من عمليات الرياضيات على أنواع مختلفة من العناصر.

### **فئة MathematicalText**

تمثل فئة [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) نصًا رياضيًا—العنصر الأساسي لجميع التركيبات الرياضية. قد يُمثل النص الرياضي معاملات ومشغّلات، أو متغيّرات، أو أي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐

### **فئة MathFraction**

تُحدد فئة [MathFraction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) كائن كسر يتكوّن من بسط ومقام مفصولين بشريط كسر. يمكن أن يكون شريط الكسر أفقيًا أو مائلًا بحسب خصائص الكسر. يُستخدم كائن الكسر أيضًا لتمثيل دالة المكدس، التي تضع عنصرًا فوق آخر دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **فئة MathRadical**

تُحدد فئة [MathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) دالة الجذر (الجذر الرياضي)، وتتكوّن من قاعدة ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **فئة MathFunction**

تُحدد فئة [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) دالة لوسيط. تحتوي على خصائص مثل [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name) لاسم الدالة، و[Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base) لوسيط الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **فئة MathNaryOperator**

تُحدد فئة [MathNaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) كائنًا رياضيًا n-ary، مثل التجميع أو التكامل. يتكوّن من مشغّل، قاعدة (أو معامل)، وحدود علوية وسفلية اختيارية. من أمثلة المشغّلات n-ary: الجمع، الاتحاد، التقاطع، والتكامل.

هذه الفئة لا تشمل المشغّلات البسيطة مثل الجمع أو الطرح؛ فهذه ممثلة بنص واحد من فئة [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **فئة MathLimit**

تُنشئ فئة [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) الحد العلوي أو السفلي. تحدد كائن الحد الذي يتكوّن من نص على الخط الأساسي ونص أصغر حجما فوقه أو تحته مباشرة. لا يتضمن هذا العنصر كلمة "lim"، بل يتيح لك وضع نص في أعلى أو أسفل التعبير.

مثال:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يُنشأ باستخدام مزيج من فئتي [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) و[MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) كما يلي:
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```


### **فئات MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**

- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

تحدد هذه الفئات موضعًا سفليًا أو علويًا. يمكنك تعيين كل من المؤشر السفلي والعلوي معًا على الجانب الأيسر أو الأيمن من الوسيط، لكن يُدعم مؤشر واحد فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) لتعيين درجة رياضية لعدد.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **فئة MathMatrix**

تُحدد فئة [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) كائن المصفوفة، الذي يتكوّن من عناصر فرعية مرتّبة في صفوف وأعمدة متعددة. تجدر الإشارة إلى أن المصفوفات لا تحتوي على محددات مدمجة؛ لتضمين المصفوفة بين أقواس، استخدم كائن المحدد [IMathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). يمكن استخدام معاملات `null` لإنشاء فجوات داخل المصفوفات.

مثال:  

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **فئة MathArray**

تُحدد فئة [MathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) مصفوفة رأسية من المعادلات أو أي كائنات رياضية أخرى.

مثال:  

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**

- فئة [MathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox): ترسم حدًا مستطيلاً أو بديلًا حول [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).

مثال:  

![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [MathBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox): تحدد تغليفًا منطقيًا لكائن رياضي. يمكن أن يُستخدم الكائن المعبأ كمحاكي مشغّل—مع أو بدون نقطة محاذاة—أو كفاصل سطر، أو لتجميعه لمنع كسر السطر داخله. على سبيل المثال، يجب تعبئة المشغّل "==" لمنع كسر السطر.

- فئة [MathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter): تحدد كائن المحدد، الذي يتكوّن من حرفي فتح وإغلاق (مثل الأقواس أو الأقواس المعقوفة أو الأقواس المربعة أو القوائم العمودية) وعنصر (عناصر) رياضية داخلها، مفصولة بحرف محدد.

مثال:  

![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [MathAccent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent): تحدد دالة التكسِّية، التي تتكوّن من قاعدة وعلامة صوتية متصلة.

مثال: 𝑎́.

- فئة [MathBar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar): تحدد دالة الشريط، التي تتكوّن من وسيط قاعدة وشريط علوي أو سفلي.

مثال:  

![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [MathGroupingCharacter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter): تحدد رمز تجميع يُوضع فوق أو تحت تعبير، عادة لتسليط الضوء على العلاقات بين العناصر.

مثال:  

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**

كل عنصر رياضي وكل تعبير رياضي (عبر فئة [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) يطبق الواجهة [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement). يتيح لك ذلك تنفيذ عمليات على البنية الحالية وتكوين تعبيرات رياضية أكثر تعقيدًا. تحتوي جميع العمليات على مجموعتين من المعاملات: إما مع [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) أو سلاسل نصية. تُنشأ مثيلات فئة [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) ضمنيًا من السلاسل النصية عند استخدامها كمعاملات. تُدرج عمليات الرياضيات المتوفرة في Aspose.Slides أدناه.

### **طريقة Join**

- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

هذه الطرق تجمع عنصرًا رياضيًا وتُكوّن كتلة رياضية. مثال:
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

هذه الطرق تُنشئ كسرًا من النوع المحدد مع بسط ومقام مُحدّدين. مثال:
```cs
IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```


### **طريقة Enclose**

- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

هذه الطرق تحيط العنصر بأحرف محددة، مثل الأقواس أو أي أحرف إطارية أخرى. مثال:
```cs
IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```


### **طريقة Function**

- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

هذه الطرق تأخذ دالة لوسيط باستخدام الكائن الحالي كاسم الدالة. مثال:
```cs
IMathFunction func = new MathematicalText("sin").Function("x");
```


### **طريقة AsArgumentOfFunction**

- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/methods/3)

تأخذ هذه الطرق الدالة المحددة باستخدام المثيل الحالي كوسيط. يمكنك:
- تحديد اسم الدالة كسلسلة، مثل "cos".
- اختيار أحد القيم المعرّفة مسبقًا في تعداد [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) أو [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments)، مثل `MathFunctionsOfOneArgument.ArcSin`.
- اختيار مثيل من [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement).

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

تُعيّن هذه الطرق المؤشر السفلي والعلوي. يمكنك تعيينهما معًا إما على اليسار أو اليمين؛ ومع ذلك، يُدعم مؤشر واحد فقط على الطرف الأيمن. يمكن أيضًا استخدام **Superscript** لتعيين درجة رياضية لعدد.

مثال:
```cs
var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```


### **طريقة Radical**

- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

تُحدد هذه الطرق الجذر الرياضي للدرجة المعطاة بناءً على الوسيط المحدد.

مثال:
```cs
var radical = new MathematicalText("x").Radical("3");
```


### **طرق SetUpperLimit و SetLowerLimit**

- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

تُحدد هذه الطرق حدًا علويًا أو سفليًا، حيث يشير "upper" و "lower" إلى موضع الوسيط بالنسبة إلى القاعدة.

ننظر في التعبير:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات عبر مزيج من فئتي [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) و[MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit)، إلى جانب عمليات الواجهة [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) كما يلي:
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

كلا الطريقتين **Nary** و**Integral** تُنشئ وتُعيد المشغّل n-ary المُمثَّل بنوع [INaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator). في طريقة Nary، يُحدِّد تعداد [MathNaryOperatorTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) نوع المشغّل—مثل الجمع أو الاتحاد—مستثنياً التكاملات. في طريقة Integral، تُوفَّر عملية متخصصة للتكاملات باستخدام تعداد [MathIntegralTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes).

مثال:
```cs
IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```


### **طريقة ToMathArray**

[ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) تُضع العناصر في مصفوفة رأسية. إذا استُدعيت هذه العملية على مثيل من فئة [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)، فستُوضع جميع عناصره الفرعية في المصفوفة المرجعة.

مثال:
```cs
var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```


### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- طريقة [Accent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) تُعيّن علامة إعراب (حرف فوق العنصر).
- طريقتا [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) و[Underbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) تُعيّنان شريطًا علويًا أو سفليًا.
- طريقة [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) تُوضع في مجموعة باستخدام رمز تجميع مثل القوس المعقوف السفلي أو غيره.
- طريقة [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) تُضع العنصر في حدّ‑مربع.
- طريقة [ToBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) تُضع العنصر في صندوق غير مرئي (تجميع منطقي).

أمثلة:
```cs
var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```


## **الأسئلة الشائعة**

**كيف يمكن إضافة معادلة رياضية إلى شريحة PowerPoint؟**

لإضافة معادلة رياضية، تحتاج إلى إنشاء كائن `MathShape`، والذي يحتوي تلقائيًا على جزء رياضي. بعد ذلك، تستخرج `MathParagraph` من `MathPortion` وتضيف كائنات `MathBlock` إليه.

**هل يمكن إنشاء تعبيرات رياضية متداخلة معقدة؟**

نعم، يسمح Aspose.Slides بإنشاء تعبيرات رياضية معقدة عن طريق تداخل `MathBlock`. كل عنصر رياضي يطبق الواجهة `IMathElement`، التي تُتيح لك تطبيق عمليات (Join, Divide, Enclose, إلخ) لدمج العناصر في تراكيب أكثر تعقيدًا.

**كيف يمكن تحديث أو تعديل معادلة رياضية موجودة؟**

لتحديث معادلة، تحتاج إلى الوصول إلى `MathBlock` الحالية عبر `MathParagraph`. ثم باستخدام أساليب مثل Join, Divide, Enclose وغيرها، يمكنك تعديل عناصر المعادلة الفردية. بعد التحرير، احفظ العرض التقديمي لتطبيق التغييرات.