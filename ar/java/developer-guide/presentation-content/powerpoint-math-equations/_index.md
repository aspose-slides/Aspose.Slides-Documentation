---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية في Java
linktitle: معادلات الرياضيات في PowerPoint
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
description: "إدراج وتعديل المعادلات الرياضية في PowerPoint PPT و PPTX باستخدام Aspose.Slides للغة Java، مع دعم OMML، والتحكم في التنسيق، وعينات كود Java واضحة."
---

## **نظرة عامة**
في PowerPoint، يمكن كتابة معادلة رياضية أو صيغة وعرضها في العرض التقديمي. للقيام بذلك، يتم تمثيل رموز رياضية مختلفة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لهذا يتم استخدام منشئ المعادلات الرياضية في PowerPoint، الذي يساعد على إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- حدود وظائف اللوغاريتم
- عمليات N-ary
- مصفوفة
- عوامل كبيرة
- دوال جيب وجيب تمام

لإضافة معادلة رياضية في PowerPoint، يتم استخدام قائمة *إدراج -> المعادلة*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

هذا سيقوم بإنشاء نص رياضي بصيغة XML يمكن عرضه في PowerPoint كالتالي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint الكثير من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، غالبًا ما لا ينتج عن إنشاء معادلات رياضية معقدة في PowerPoint نتيجة جيدة ومهنية. المستخدمون الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر يلجؤون إلى حلول الطرف الثالث لإنشاء صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/java/)، يمكنك العمل مع المعادلات الرياضية في عروض PowerPoint برمجيًا بلغة C#. أنشئ تعبيرات رياضية جديدة أو عدّل تلك التي تم إنشاؤها مسبقًا. كما يتم دعم تصدير الهياكل الرياضية إلى صور جزئيًا.

## **كيفية إنشاء معادلة رياضية**
يتم استخدام العناصر الرياضية لبناء أي تركيبات رياضية بأي مستوى تعشيق. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية تمثلها الفئة [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock). تمثل فئة [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) تعبيرًا أو صيغة أو معادلة رياضية منفصلة. الفئة [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) هي جزء رياضي، تُستخدم لحفظ النص الرياضي (لا تخلطها مع [**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)). فئة [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) تسمح بالتلاعب بمجموعة من كتل الرياضيات. الفئات المذكورة أعلاه هي المفتاح للعمل مع معادلات PowerPoint الرياضية عبر Aspose.Slides API.

دعنا نرى كيف يمكننا إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، أولاً، أضف شكلاً سيحمل النص الرياضي:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

بعد الإنشاء، سيحتوي الشكل تلقائيًا على فقرة واحدة تحتوي على جزء رياضي بشكل افتراضي. فئة [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) هي جزء يحتوي على نص رياضي. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion)، ارجع إلى المتغيّر [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph):

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

تسمح فئة [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) بقراءة وإضافة وتعديل وحذف كتل الرياضيات ([**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) التي تتألف من مجموعة من العناصر الرياضية. على سبيل المثال، أنشئ كسرًا وضعه في العرض التقديمي:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

كل عنصر رياضي يُمثَّل بواسطة فئة تُطبِّق واجهة [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). توفر هذه الواجهة الكثير من الطرق لإنشاء تعبيرات رياضية بسهولة. يمكنك إنشاء تعبير رياضي معقد بسطر واحد من الشيفرة. على سبيل المثال، مبرهنة فيثاغورس ستظهر هكذا:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

يُطبق عمليات الواجهة [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) على أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock).

الكود الكامل:

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
تتكوّن التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يُمثَّل تسلسل العناصر الرياضية بكتلة رياضية، وتُكوّن وسائط العناصر شجرة تعشيقية.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. يمكن تضمين كل عنصر داخل عنصر آخر، أي أن العناصر هي فعليًا حاويات لأخرى، مكوّنةً بنية شجرية. أبسط نوع من العناصر هو ذلك الذي لا يحتوي على عناصر أخرى من النص الرياضي.

كل نوع من العناصر الرياضية يُطبق واجهة [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)، مما يسمح باستخدام مجموعة مشتركة من عمليات الرياضيات على أنواع مختلفة من العناصر.

### **فئة MathematicalText**
تمثل الفئة [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) نصًا رياضيًا – العنصر الأساسي لجميع التركيبات الرياضية. يمكن أن يمثل النص الرياضي معاملات ومشغِّلات ومتغيّرات وأي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐

### **فئة MathFraction**
تمثل الفئة [**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) كائن الكسر، المكوّن من بسط ومقام مفصولين بخط كسر. يمكن أن يكون خط الكسر أفقيًا أو قطريًا حسب خصائص الكسر. يُستَخدم كائن الكسر أيضًا لتمثيل الدالة المكدسة التي تضع عنصرًا فوق آخر دون خط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **فئة MathRadical**
تمثل الفئة [**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) الدالة الجذرية (الجذر الرياضي)، المكوّنة من قاعدة ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **فئة MathFunction**
تمثل الفئة [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) دالة لوسيط. تحتوي على خصائص: [getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) – اسم الدالة و[getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) – معامل الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **فئة MathNaryOperator**
تمثل الفئة [**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) كائنًا رياضيًا N-ary، مثل الجمع أو التكامل. يتكوّن من مشغِّل، قاعدة (أو معامل)، ودرجات علوية وسفلية اختيارية. أمثلة على المشغِّلات N-ary هي الجمع، الاتحاد، التقاطع، التكامل.

هذه الفئة لا تشمل المشغِّلات البسيطة مثل الجمع أو الطرح؛ فهذه تمثَّل بنص واحد – [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **فئة MathLimit**
تنشئ الفئة [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) حدًا علويًا أو سفليًا. يحدّد كائن الحد نصًا على خط الأساس ونصًا أصغر حجماً أعلى أو أسفل ذلك مباشرة. لا تتضمن هذه العنصر كلمة “lim”، بل تسمح بوضع نص في أعلى أو أسفل التعبير. وبالتالي يُنشأ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام الفئتين [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) و[**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) كما يلي:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **فئات MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

تحدد الفئات التالية مقدارًا سفليًا أو علويًا. يمكنك تعيين كل من الإسفلية والعلوية في نفس الوقت على الجانب الأيسر أو الأيمن للمُعامل، لكن يُدعّم الإسفلية أو العلوية المفردة فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) لتعيين الدرجة الرياضية لعدد.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **فئة MathMatrix**
تحدد الفئة [**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) كائن المصفوفة، المكوّن من عناصر فرعية مرتبة في صفوف وأعمدة. تجدر الإشارة إلى أن المصفوفات لا تحتوي على محددات مدمجة. لوضع المصفوفة بين أقواس، يجب استخدام كائن المحدد – [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter). يمكن استخدام قيم null لإنشاء فراغات داخل المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **فئة MathArray**
تحدد الفئة [**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) مصفوفة عمودية من المعادلات أو أي كائنات رياضية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**
- فئة [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox): ترسم حدودًا مستطيلة أو أخرى حول [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).

  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox): تحدد تغليفًا منطقيًا للعنصر الرياضي. على سبيل المثال، يمكن أن يعمل الكائن المعبأ كمحاكي مشغِّل مع أو بدون نقطة محاذاة، أو كنقطة انقطاع سطر، أو مجمّع لمنع تقسيم السطر داخل العنصر. مثال: يجب تغليف المشغِّل “==” لمنع انقطاع السطر.

- فئة [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter): تحدد كائن المحدد، المكوّن من حرفي الفتح والإغلاق (مثل الأقواس، الأقواس المعقوفة، الأقواس المربعة، أو الخطوط الرأسية)، وعناصر رياضية واحدة أو أكثر داخلها، مفصولة بحرف محدد. أمثلة: (𝑥2); [𝑥2|𝑦2].

  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent): تحدد دالة اللكنة، المكوّنة من قاعدة وعلامة تشكيلية مدمجة.

  مثال: 𝑎́.

- فئة [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar): تحدد دالة الشريط، المكوّنة من معامل قاعدة وشريط علوي أو سفلي.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter): تحدد رمز تجميع فوق أو تحت تعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**
كل عنصر أو تعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) يطبق واجهة [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). تتيح لك هذه الواجهة إجراء عمليات على البنية الحالية وتكوين تعابير رياضية أكثر تعقيدًا. جميع العمليات لها مجموعتين من المعاملات: إما [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) أو سلسلة نصية كمعاملات. تُنشأ كائنات [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) ضمنيًا من السلاسل النصية عند استخدامها.

### **طريقة Join**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

تجمع عنصرًا رياضيًا وتكوّن كتلة رياضية. مثال:

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

تنشئ كسرًا من النوع المحدد باستخدام هذا البسط والمقام المحدد. مثال:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **طريقة Enclose**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

تحيط العنصر بأحرف محددة مثل الأقواس أو أي حرف آخر كإطار.

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

تُستخدم لتحديد دالة لوسيط باستخدام الكائن الحالي كاسم الدالة.

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

تُستخدم لتحديد الدالة المحددة باستخدام الكائن الحالي كمعامل. يمكنك:

- تحديد سلسلة كاسم الدالة، مثل “cos”.
- اختيار أحد القيم المعرفة مسبقًا للعدادات [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments)، مثل [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- اختيار كائن [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).

مثال:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **طرق SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

تُعيّن الإشارة السفلية والعليا. يمكنك تعيينهما معًا على اليسار أو اليمين، لكن الإشارة المفردة تُدعَم فقط على اليمين. يمكن أيضًا استخدام **Superscript** لتعيين درجة رياضية لعدد.

مثال:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **طريقة Radical**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

تحدّد الجذر الرياضي للدرجة المحددة من المعامل المحدد.

مثال:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **طرق SetUpperLimit و SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

تُحدد حدًا علويًا أو سفليًا. هنا، يشير الحد العلوي والسفلي ببساطة إلى موضع المعامل بالنسبة للقاعدة.

نأخذ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات عبر الجمع بين فئتي [MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) و[MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) وعمليات [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) كما يلي:

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

كلا الطريقتين **nary** و**integral** تنشئان وتُعيدان المشغِّل N-ary الممثل بنوع [**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator). في طريقة nary، تُحدِّد عدديات [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) نوع المشغِّل: جمع، اتحاد، إلخ، ولا تشمل التكاملات. في طريقة Integral، تُستَخدم عملية التكامل مع تعداد أنواع التكامل [**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes).

مثال:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **طريقة ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) تضع العناصر في مصفوفة عمودية. إذا تم استدعاء هذه العملية على كائن [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)، فستُوضع جميع العناصر الفرعية في المصفوفة المرجعة.

مثال:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- الطريقة [**accent**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#accent-char-) تُضيف علامة تشديد (حرف فوق العنصر).
- الطريقتان [**overbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#overbar--) و[**underbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#underbar--) تُضيفان شريطًا أعلى أو أسفل العنصر.
- الطريقة [**group**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#group--) تضع العنصر في مجموعة باستخدام رمز تجميع مثل القوس المعقوف السفلي أو غيره.
- الطريقة [**toBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBorderBox--) تضع العنصر في صندوق حدود.
- الطريقة [**toBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBox--) تضع العنصر في صندوق غير مرئي (تجميع منطقي).

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

لإضافة معادلة رياضية، تحتاج إلى إنشاء كائن شكل رياضي، والذي يحتوي تلقائيًا على جزء رياضي. ثم تستخرج [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) وتضيف كائنات [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/) إليه.

**هل يمكن إنشاء تعبيرات رياضية متداخلة ومعقدة؟**

نعم، يتيح Aspose.Slides إنشاء تعبيرات رياضية معقدة عبر تعشيق MathBlocks. كل عنصر رياضي يطبق واجهة [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) التي تسمح بدمج العناصر باستخدام عمليات (Join, Divide, Enclose, إلخ) لتكوين هياكل أكثر تعقيدًا.

**كيف يمكن تحديث أو تعديل معادلة رياضية موجودة؟**

لتحديث معادلة، تحتاج إلى الوصول إلى MathBlocks الحالية عبر [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/). ثم باستخدام طرق مثل Join, Divide, Enclose وغيرها، يمكنك تعديل عناصر المعادلة الفردية. بعد التحرير، احفظ العرض التقديمي لتطبيق التغييرات.