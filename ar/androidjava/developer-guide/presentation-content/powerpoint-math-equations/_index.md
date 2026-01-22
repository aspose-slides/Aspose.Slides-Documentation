---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية على Android
linktitle: معادلات PowerPoint الرياضية
type: docs
weight: 80
url: /ar/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "إدراج وتعديل المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides لنظام Android، مع دعم OMML، أدوات تنسيق، وعينات شفرة Java واضحة."
---

## **نظرة عامة**
في PowerPoint، يمكن كتابة معادلة أو صيغة رياضية وعرضها في العرض التقديمي. لتحقيق ذلك، يتم تمثيل رموز رياضية مختلفة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لهذا الغرض يُستخدم مُنشئ المعادلات الرياضية في PowerPoint، الذي يساعد على إنشاء صيغ معقدة مثل:

- كسور رياضية
- جذور رياضية
- وظائف رياضية
- حدود ودوال اللوغاريتم
- عمليات N-ary
- مصفوفة
- عوامل كبيرة
- دوال sin، cos

لإضافة معادلة رياضية في PowerPoint، يتم استخدام قائمة *إدراج → معادلة*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيتم إنشاء نص رياضي بصيغة XML يمكن عرضه في PowerPoint كما يلي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint العديد من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، غالبًا ما لا ينتج عن إنشاء معادلات رياضية معقدة في PowerPoint نتيجة جيدة ومظهر احترافي. يلجأ المستخدمون الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر إلى حلول طرف ثالث للحصول على صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/)، يمكنك العمل مع المعادلات الرياضية في عروض PowerPoint برمجيًا بلغة C#. يمكنك إنشاء تعبيرات رياضية جديدة أو تعديل المعاملات التي تم إنشاؤها مسبقًا. كما يتم دعم تصدير الهياكل الرياضية إلى صور جزئيًا.

## **كيفية إنشاء معادلة رياضية**
تُستخدم العناصر الرياضية لبناء أي تركيبات رياضية بمستوى تعشيق أيًا كان. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية يُمثِّلها الفئة [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock). فئة [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) هي في الأساس تعبير رياضي منفصل أو صيغة أو معادلة. فئة [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) هي جزء رياضي يُستخدم لحفظ النص الرياضي (لا تُخلط مع [**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)). فئة [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) تسمح بمعالجة مجموعة من كتل الرياضيات. الفئات المذكورة أعلاه هي المفتاح للعمل مع معادلات PowerPoint الرياضية عبر Aspose.Slides API.

دعونا نرى كيف يمكننا إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، ابدأ بإضافة شكل يحتوي على النص الرياضي:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

بعد الإنشاء، سيحتوي الشكل تلقائيًا على فقرة واحدة مع جزء رياضي بشكل افتراضي. فئة [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) هي الجزء الذي يحتوي على نص رياضي داخل. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)، استخدم المتغير [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) كالتالي:

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

تسمح فئة [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) بقراءة وإضافة وتعديل وحذف كتل الرياضيات ([**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock))، والتي تتكون من مجموعة من العناصر الرياضية. على سبيل المثال، لإنشاء كسر ووضعه في العرض:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

كل عنصر رياضي يُمثَّل بفئة تنفِّذ واجهة [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). توفر هذه الواجهة العديد من الطرق لإنشاء تعبيرات رياضية بسهولة. يمكنك إنشاء تعبير رياضي معقد بخط واحد من الشيفرة. على سبيل المثال، مبرهنة فيثاغورس تُكتب هكذا:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

تُنفَّذ عمليات الواجهة [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) في أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock).

العينة الكاملة للشيفرة:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);

    IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
    
    IMathFraction fraction = new MathematicalText("x").divide("y");

    mathParagraph.add(new MathBlock(fraction));

    IMathBlock mathBlock = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);

    pres.save("math.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
``` 

## **أنواع العناصر الرياضية**
تُكوَّن التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يُمثَّل تسلسل العناصر الرياضية بكتلة رياضية، وتُشكل وسائط العناصر شجرة تعشيق.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لإنشاء كتلة رياضية. يمكن تضمين كل عنصر داخل عنصر آخر؛ أي أن العناصر هي حاويات لأخرى، مكوِّنةً بنية شجرية. أبسط نوع من العناصر لا يحتوي على عناصر نصية أخرى.

كل نوع من العناصر الرياضية ينفّذ واجهة [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)، مما يتيح استخدام مجموعة مشتركة من عمليات الرياضيات على أنواع مختلفة من العناصر.

### **فئة MathematicalText**
تمثل فئة [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) نصًا رياضيًا – العنصر الأساسي لكل التركيبات الرياضية. يمكن أن يمثل النص الرياضي عوامل، مشغلات، متغيّرات، أو أي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐

### **فئة MathFraction**
تحدد فئة [**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction) كائن الكسر، المتكوّن من بسط ومقام مفصولين بشريط كسر. يمكن أن يكون الشريط أفقيًا أو قطريًا بحسب خصائص الكسر. يُستَخدم كائن الكسر أيضًا لتمثيل وظيفة المكدس التي تضع عنصرًا فوق آخر دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **فئة MathRadical**
تحدد فئة [**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical) دالة الجذر (الجذر الرياضي)، المتكوّنة من قاعدة ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **فئة MathFunction**
تحدد فئة [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) دالة لوسيط. تحتوي على خاصيتين: [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--) – اسم الدالة، و[getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--) – وسيط الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **فئة MathNaryOperator**
تحدد فئة [**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator) كائنًا رياضيًا من نوع N-ary مثل الجمع والتكامل. يتكوّن من مشغل، قاعدة (أو عامل)، ودرجات عليا وسفلى اختيارية. أمثلة على المشغلات N-ary: Summation، Union، Intersection، Integral.

هذه الفئة لا تشمل المشغلات البسيطة مثل الجمع أو الطرح؛ فهي مُمثَّلة بعنصر نصي واحد – [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **فئة MathLimit**
تُنشئ فئة [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) حدًا علويًا أو سفليًا. تحدد كائن الحد نصًا على الخط الأساسي ونصًا أصغر حجماً فوقه أو تحته مباشرة. لا تشمل هذه الفئة كلمة “lim”، بل تسمح بوضع النص في أعلى أو أسفل التعبير. وبالتالي يُنشأ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

بهذا الشكل عبر دمج فئتي [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) و[**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit):

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **فئات MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

تحدّد الفئات السابقة إما مؤشرًا سفليًا أو علويًا. يمكن ضبط المؤشر السفلي والعلوي معًا على الجانب الأيسر أو الأيمن من الوسيط، بينما يُدعم المؤشر الفردي فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) لتعيين الدرجة الرياضية لعدد ما.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **فئة MathMatrix**
تحدد فئة [**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix) كائن المصفوفة، المتكوّن من عناصر فرعية مرتبة في صفوف وأعمدة. تجدر الإشارة إلى أن المصفوفات لا تتضمن محددات مدمجة؛ لإحاطتها بأقواس يجب استخدام كائن المحدد – [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter). يمكن استخدام معاملات فارغة لإنشاء فراغات داخل المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **فئة MathArray**
تحدد فئة [**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray) صفًا عموديًا من المعادلات أو أي كائنات رياضية أخرى.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**
- فئة [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox): ترسم إطارًا مستطيلًا أو غيره حول [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).

  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox): تُحدِّد التغليف المنطقي للعنصر الرياضي. على سبيل المثال، يمكن أن يعمل العنصر المُغلق كمحاكي مشغل مع أو بدون نقطة محاذاة، أو كفاصل سطر، أو يُجمَّع لمنع فواصل الأسطر داخله. على سبيل المثال، يجب تغليف المشغل “==” لمنع فواصل الأسطر.

- فئة [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter): تُحدِّد كائن المحدد، المتكوّن من حرفي بدء وإغلاق (مثل الأقواس، الأقواس المعقوفة، القوسين المربعين، أو الشرطتين العموديتين) وعنصر أو أكثر داخلها مفصولين بحرف محدد. أمثلة: (𝑥2)؛ [𝑥2|𝑦2].

  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent): تُحدِّد دالة التنوين، المتكوّنة من قاعدة وعلامة تشكيلية مدمجة.

  مثال: 𝑎́.

- فئة [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar): تُحدِّد دالة الشريط، المتكوّنة من وسيط أساسي وشريط علوي أو سفلي.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter): تُحدِّد رمز تجميع فوق أو تحت التعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**
كل عنصر رياضي وتعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)) ينفّذ واجهة [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). تسمح لك باستخدام عمليات على البنية الحالية وتكوين تعبيرات رياضية أكثر تعقيدًا. جميع العمليات لها مجموعتا معاملات: إما [**IMathElement**] أو سلسلة نصية كوسيطات. يتم إنشاء كائنات فئة [**MathematicalText**] ضمنيًا من السلاسل النصية عند استخدامها.

### **طريقة Join**
- [join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

تجمع عنصرًا رياضيًا وتشكّل كتلة رياضية. مثال:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **طريقة Divide**
- [divide(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

تنشئ كسرًا من النوع المحدد باستخدام هذا البسط والمقام المحدد. مثال:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **طريقة Enclose**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

تحيط العنصر بحروف محددة مثل الأقواس أو أي حرف آخر كإطار.

```java
/**
 * <p>
 * Enclose a math element in parenthesis
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Encloses this element in specified characters such as parenthesis or another characters as framing
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 

مثال:

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **طريقة Function**
- [function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

تُنشئ دالة لوسيطة باستخدام الكائن الحالي كاسم الدالة.

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 

مثال:

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **طريقة AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

تُمرِّر الدالة المحددة باستخدام الكائن الحالي كوسيطة. يمكنك:

- تحديد سلسلة كاسم الدالة، مثل “cos”.
- اختيار أحد القيم المعرَّفة مسبقًا في تعداد [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments)، مثل [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- اختيار مثال من [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).

مثال:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **طرق SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

تُعيّن المؤشرات السفلى والعلوية. يمكنك ضبط المؤشرين معًا على اليمين أو اليسار من الوسيط، لكن يُدعم المؤشر الفردي فقط على اليمين. يمكن أيضًا استخدام **Superscript** لتعيين درجة رياضية لعدد ما.

مثال:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **طريقة Radical**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

تُحدد الجذر الرياضي للدرجة المحددة من الوسيط المحدد.

مثال:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **طرق SetUpperLimit و SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

تُحدِّد الحد الأعلى أو السفلي. يشير الحد الأعلى أو السفلي ببساطة إلى موضع الوسيط بالنسبة للقاعدة.

لنفترض التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذا التعبير عبر دمج فئتي [MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) و[MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) واستخدام عمليات [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) كما يلي:

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **طرق Nary و Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

كلاً من طريقتي **nary** و **integral** تُنشئ وتُعيد مُشغِل N-ary من نوع [**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator). في طريقة nary، يُحدِّد تعداد [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes) نوع المشغّل: جمع، اتحاد، إلخ، دون تضمين التكاملات. في طريقة Integral، يُستخدم نوع تكامل محدد عبر تعداد [**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes).

مثال:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **طريقة ToMathArray**
تُحوِّل طريقة [**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) العناصر إلى صف عمودي. إذا استُدعيّت على كائن [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)، تُوضع جميع العناصر الفرعية في المصفوفة المرجعة.

مثال:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- طريقة [**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-) تُضيف علامة تشديد (حرف فوق العنصر).
- طريقتا [**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--) و[**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--) تُضيفان شريطًا فوق أو تحت العنصر.
- طريقة [**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--) تُضع العنصر في مجموعة باستخدام رمز تجميع مثل القوس المعقوف السفلي أو غيره.
- طريقة [**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--) تُضع العنصر في إطار حدود.
- طريقة [**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--) تُضع العنصر في صندوق غير مرئي (تجميع منطقي).

أمثلة:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **الأسئلة الشائعة**

**كيف يمكن إضافة معادلة رياضية إلى شريحة PowerPoint؟**

لإضافة معادلة رياضية، تحتاج إلى إنشاء كائن شكل رياضي يحتوي تلقائيًا على جزء رياضي. بعد ذلك، استرجع [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) وأضف كائنات [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) إليه.

**هل يمكن إنشاء تعبيرات رياضية متداخلة معقدة؟**

نعم، تسمح Aspose.Slides بإنشاء تعبيرات رياضية معقدة عبر تعشيق MathBlocks. كل عنصر رياضي يُنفّذ واجهة [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) التي تتيح لك تطبيق عمليات (Join، Divide، Enclose، إلخ) لدمج العناصر في بنى أكثر تعقيدًا.

**كيف يمكن تحديث أو تعديل معادلة رياضية موجودة؟**

لتحديث معادلة، تحتاج إلى الوصول إلى MathBlocks الحالية عبر [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/). ثم باستخدام طرق مثل Join، Divide، Enclose وغيرها، يمكنك تعديل عناصر المعادلة الفردية. بعد التحرير، احفظ العرض لتطبيق التغييرات.