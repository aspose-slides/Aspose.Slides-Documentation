---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية بلغة Java
linktitle: معادلات رياضية في PowerPoint
type: docs
weight: 80
url: /ar/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "إدراج وتعديل المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides للـ Java، مع دعم OMML، أدوات تنسيق، وعينات شفرة Java واضحة."
---

## **نظرة عامة**
في PowerPoint، يمكن كتابة معادلة رياضية أو صيغة وعرضها في العرض التقديمي. للقيام بذلك، يتم تمثيل رموز رياضية متعددة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لهذا، يُستخدم مُنشئ المعادلات الرياضية في PowerPoint، والذي يساعد على إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- حدود ودوال اللوغاريتم
- عمليات N-ary
- مصفوفة
- عوامل كبيرة
- دوال sin, cos

لإضافة معادلة رياضية في PowerPoint، يُستخدم قائمة *إدراج → معادلة*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيتم إنشاء نص رياضي بصيغة XML يمكن عرضه في PowerPoint كما يلي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint الكثير من الرموز الرياضية لإنشاء معادلات رياضية. ومع ذلك، غالبًا لا ينتج عن إنشاء معادلات رياضية معقدة في PowerPoint نتيجة ذات مظهر مهني جيد. المستخدمون الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بانتظام يلجؤون إلى حلول طرف ثالث لإنشاء صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/java/)، يمكنك العمل مع المعادلات الرياضية في عروض PowerPoint برمجيًا بلغة C#. أنشئ تعبيرات رياضية جديدة أو حرّر تعبيرات تم إنشاؤها مسبقًا. كما يتم دعم تصدير الهياكل الرياضية إلى صور بشكل جزئي.

## **كيفية إنشاء معادلة رياضية**
تُستخدم العناصر الرياضية لبناء أي بنية رياضية مع أي مستوى تعشيق. تشكّل مجموعة خطية من العناصر الرياضية كتلة رياضية تمثلها فئة [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock). فئة [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) هي أساسًا تعبير رياضي منفصل، صيغة أو معادلة. فئة [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) هي جزء رياضي يُستخدم لحفظ نص رياضي (لا تخلطها مع [**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)). فئة [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) تسمح بالتعامل مع مجموعة من كتل الرياضيات. الفئات المذكورة أعلاه هي المفتاح للعمل مع معادلات PowerPoint الرياضية عبر Aspose.Slides API.

دعنا نرى كيف يمكننا إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، أولاً أضف شكلًا سيحتوي على النص الرياضي:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

بعد الإنشاء، سيحتوي الشكل بالفعل على فقرة واحدة مع جزء رياضي بشكل افتراضي. فئة [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) هي جزء يحتوي على نص رياضي داخله. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion)، ارجع إلى متغيّر [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph):

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

تسمح فئة [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) بقراءة وإضافة وتحرير وحذف كتل الرياضيات ([**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock))، التي تتكوّن من مجموعة من العناصر الرياضية. على سبيل المثال، أنشئ كسرًا وضعه في العرض التقديمي:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

كل عنصر رياضي يُمثَّل بواسطة فئة تنفّذ واجهة [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). توفر هذه الواجهة الكثير من الأساليب لإنشاء تعبيرات رياضية بسهولة. يمكنك إنشاء تعبير رياضي معقّد باستخدام سطر واحد من الشيفرة. على سبيل المثال، سيبدو مبرهنة فيثاغورس هكذا:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

تُنفّذ عمليات الواجهة [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) في أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock).

العينة الكاملة للكود:

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
تتشكل التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يُمثّل تسلسل العناصر الرياضية بكتلة رياضية، وتُشكّل معاملات العناصر الرياضية شجرة متعشّبة.

هناك الكثير من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. يمكن تضمين (تجميع) كل عنصر داخل عنصر آخر. أي أن العناصر هي في الواقع حاويات لأخرى، مكوّنة بنية شجرية. أبسط نوع من العنصر لا يحتوي على عناصر نص رياضي أخرى.

كل نوع من عناصر الرياضيات ينفّذ واجهة [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)، مما يسمح باستخدام مجموعة مشتركة من عمليات الرياضيات على أنواع مختلفة من العناصر.

### **فئة MathematicalText**
تمثل فئة [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) نصًا رياضيًا — العنصر الأساسي لكل البُنى الرياضية. قد يمثل النص الرياضي المت operands والoperators والمتغيّرات وأي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐

### **فئة MathFraction**
تحدد فئة [**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) كائن الكسر، المكوّن من بسط ومقام مفصولين بشريط كسر. يمكن أن يكون شريط الكسر أفقيًا أو مائلًا حسب خصائص الكسر. يُستخدم كائن الكسر أيضًا لتمثيل دالة المكدس، التي تُضع عنصرًا فوق آخر دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **فئة MathRadical**
تحدد فئة [**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) دالة الجذر الرياضي، المكوّن من قاعدة ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **فئة MathFunction**
تحدد فئة [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) دالة ذات معامل. تحتوي على الخصائص: [getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) — اسم الدالة و[getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) — معامل الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **فئة MathNaryOperator**
تحدد فئة [**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) كائنًا رياضيًا N-ary، مثل الجمع والتكامل. يتكوّن من عامل، قاعدة (أو operand)، وحدود علوية وسفلية اختيارية. تشمل أمثلة المشغلات N-ary: الجمع، الاتحاد، التقاطع، التكامل.

هذه الفئة لا تشمل المشغلات البسيطة مثل الجمع والطرح، حيث يتم تمثيلها بعنصر نصي واحد — [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **فئة MathLimit**
تُنشئ فئة [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) الحد العلوي أو السفلي. تحدد كائن الحد، المكوّن من نص على الخط القاعدي ونص أصغر حجما فوقه أو تحته مباشرة. لا تتضمن هذه الفئة كلمة “lim”، بل تسمح بوضع النص في أعلى أو أسفل التعبير. لذلك، يُنشأ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مزيج من فئتي [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) و[**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) كما يلي:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **فئات MathSubscriptElement و MathSuperscriptElement و MathRightSubSuperscriptElement و MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

تحدد هذه الفئات مؤشرًا سفليًا أو علويًا. يمكنك ضبط الحرف سفليًا وعلويًا في الوقت ذاته على الجانب الأيسر أو الأيمن من المعامل، لكن يُدعم الحرف السُفلي أو العلوي المفرد فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) لتعيين درجة رياضية لعدد.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **فئة MathMatrix**
تحدد فئة [**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) كائن المصفوفة، المكوّن من عناصر فرعية مرتبة في صفوف وأعمدة متعددة. تجدر الإشارة إلى أن المصفوفات لا تحتوي على محددات مدمجة؛ لوضع المصفوفة داخل أقواس يجب استخدام كائن المحدد — [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter). يمكن تمرير معاملات فارغة لإنشاء فجوات في المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **فئة MathArray**
تحدد فئة [**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) مصفوفة رأسية من المعادلات أو أي كائنات رياضية أخرى.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**
- فئة [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox): تُرسم حدودًا مستطيلة أو أشكالًا أخرى حول [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).

  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox): تحدد تغليفًا منطقيًا للعنصر الرياضي. على سبيل المثال، يمكن أن يُستعمل كعامل محاكي مع أو بدون نقطة محاذاة، أو لتحديد كسر سطر، أو لتجميع بحيث لا يُسمح بكسور سطر داخله. مثال، يجب تغليف عامل “==” لمنع كسر السطر.

- فئة [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter): تحدد كائن المحدد، المكوّن من أحرف افتتاحية وإغلاقية (مثل الأقواس، الأقواس المدورة، الأقواس المربعة، أو الشرطات العمودية) وعنصر (عناصر) رياضية داخله مفصولة بحرف محدد.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent): تحدد دالة التشكيل، المكوّنة من قاعدة وعلامة إِضافة صوتية.

  مثال: 𝑎́.

- فئة [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar): تحدد دالة الشريط، المكوّنة من معامل أساسي وشريط فوقي أو سفلي.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter): تحدد رمز تجميع فوق أو تحت التعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**
كل عنصر رياضي وتعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) ينفّذ واجهة [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). تسمح لك باستخدام عمليات على الهيكل الحالي وتكوين تعبيرات رياضية أكثر تعقيدًا. جميع العمليات لها مجموعتا معلمات: إما [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) أو سلسلة كوسائط. تُنشأ كائنات فئة [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) ضمنيًا من السلاسل عند استخدامها كوسائط. العمليات المتاحة في Aspose.Slides مذكورة أدناه.

### **طريقة Join**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

تنضم عنصرًا رياضيًا وتشكل كتلة رياضية. مثال:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **طريقة Divide**
- [divide(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

ينشئ كسرًا من النوع المحدد باستخدام هذا البسط والمقام المحدد. مثال:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **طريقة Enclose**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

يُحُط العنصر بأحرف محددة مثل الأقواس أو حرف آخر كإطار.

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
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

تأخذ دالة لوسيط باستخدام الكائن الحالي كاسم الدالة.

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
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

تأخذ الدالة المحددة باستخدام المثيل الحالي كوسيط. يمكنك:

- تحديد سلسلة كاسم للدالة، مثل “cos”.
- اختيار أحد القيم المحددة مسبقًا من تعداد [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments)، مثال [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- اختيار مثيل من [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).

مثال:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **طرق SetSubscript و SetSuperscript و SetSubSuperscriptOnTheRight و SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

تضبط الحرف السفلي والعلوي. يمكنك ضبطهما معًا على الجانب الأيسر أو الأيمن من المعامل، لكن الحرف السفلي أو العلوي المفرد يُدعم فقط على الجانب الأيمن. يمكن أيضًا استخدام **Superscript** لتعيين درجة رياضية لعدد.

مثال:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **طريقة Radical**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

تحدد الجذر الرياضي للدرجة المعطاة من المعامل المحدد.

مثال:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **طرق SetUpperLimit و SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

تأخذ الحد العلوي أو السفلي. هنا يُشير العلوي والسفلي فقط إلى موقع المعامل بالنسبة للقاعدة.

لنأخذ مثالًا:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات من خلال دمج فئتي [MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) و[MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) والعمليات على [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) كما يلي:

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **طرق Nary و Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

كلاّ الطريقتين **nary** و **integral** تنشئ وتُعيد المشغّل N-ary المُمثَّل بنوع [**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator). في طريقة nary، يحدد تعداد [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) نوع المشغّل: جمع، اتحاد، إلخ، ولا تشمل التكاملات. في طريقة Integral، يُستخدم النوع المتخصص Integral مع تعداد أنواع التكامل [**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes).

مثال:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **طريقة ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) تضع العناصر في مصفوفة رأسية. إذا تم استدعاء هذه العملية على كائن من فئة [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)، سيتم وضع جميع العناصر الفرعية في المصفوفة المرجعة.

مثال:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- طريقة **accent** تُضيف علامة تشكيل (حرف فوق العنصر).
- طريقتا **overbar** و **underbar** تضيفان شريطًا فوق أو تحت العنصر.
- طريقة **group** تُعيد العنصر ضمن مجموعة باستخدام رمز تجميع مثل القوس المتعرّج السفلي أو غيره.
- طريقة **toBorderBox** تُضع العنصر داخل صندوق حدود.
- طريقة **toBox** تُضع العنصر داخل صندوق منطقي غير مرئي (تجميع منطقي).

أمثلة:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **الأسئلة المتكررة**

**كيف يمكن إضافة معادلة رياضية إلى شريحة PowerPoint؟**

لإضافة معادلة رياضية، تحتاج إلى إنشاء كائن شكل رياضي، والذي يحتوي تلقائيًا على جزء رياضي. بعد ذلك، تستخرج [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) وتضيف كائنات [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/) إليه.

**هل يمكن إنشاء تعبيرات رياضية متداخلة معقدة؟**

نعم، يسمح Aspose.Slides بإنشاء تعبيرات رياضية معقدة عن طريق تعشيق MathBlocks. كل عنصر رياضي ينفّذ واجهة [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) التي تسمح بتطبيق عمليات (Join، Divide، Enclose، إلخ) لدمج العناصر في هياكل أكثر تعقيدًا.

**كيف يمكن تحديث أو تعديل معادلة رياضية موجودة؟**

لتحديث معادلة، يجب الوصول إلى MathBlocks الحالية عبر [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/). ثم، باستخدام أساليب مثل Join، Divide، Enclose، وغيرها، يمكنك تعديل عناصر المعادلة الفردية. بعد التحرير، احفظ العرض التقديمي لتطبيق التغييرات.