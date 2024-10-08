---
title: معادلات الرياضيات في PowerPoint
type: docs
weight: 80
url: /ar/androidjava/powerpoint-math-equations/
keywords: "معادلات الرياضيات في PowerPoint, رموز الرياضيات في PowerPoint, صيغة PowerPoint, نص الرياضيات في PowerPoint"
description: "معادلات الرياضيات في PowerPoint, رموز الرياضيات في PowerPoint, صيغة PowerPoint, نص الرياضيات في PowerPoint"
---

## **نظرة عامة**
في PowerPoint، من الممكن كتابة معادلة أو صيغة رياضية وعرضها في العرض التقديمي. للقيام بذلك، يتم تمثيل رموز رياضية متنوعة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. من أجل ذلك، يتم استخدام منشئ المعادلات الرياضية في PowerPoint، والذي يساعد على إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- حدود ودوال لوغاريتمية
- عمليات N-ary
- مصفوفة
- عوامل كبيرة
- دوال الجيب وجيب التمام

لإضافة معادلة رياضية في PowerPoint، يتم استخدام قائمة *إدراج -> معادلة*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيؤدي ذلك إلى إنشاء نص رياضي بتنسيق XML يمكن عرضه في PowerPoint كما يلي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint العديد من الرموز الرياضية لإنشاء المعادلات الرياضية. ومع ذلك، فإن إنشاء معادلات رياضية معقدة في PowerPoint غالبًا ما لا ينتج عنه نتيجة جيدة ومهنية. يلجأ المستخدمون، الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر، إلى استخدام حلول طرف ثالث لإنشاء صيغ رياضية جذابة.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/)، يمكنك العمل مع المعادلات الرياضية في العروض التقديمية لـ PowerPoint برمجيًا بلغة C#. قم بإنشاء تعبيرات رياضية جديدة أو تحرير التعبيرات التي تم إنشاؤها مسبقًا. كما يتم دعم تصدير الهياكل الرياضية إلى صور جزئيًا.


## **كيف يتم إنشاء معادلة رياضية**
تستخدم العناصر الرياضية لبناء أي إنشائات رياضية بمستويات تعشيق مختلفة. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية تمثلها فئة [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock). تعتبر فئة [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) معادلة رياضية منفصلة أو صيغة أو معادلة. [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) هو جزء رياضي، يستخدم للاحتفاظ بالنص الرياضي (لا تخلط بينه وبين [**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)). تتيح فئة [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) التلاعب بمجموعة من الكتل الرياضية. تعتبر الفئات المذكورة أعلاه المفتاح للعمل مع معادلات الرياضيات في PowerPoint عن طريق Aspose.Slides API.

دعنا نرى كيف يمكننا إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي على الشريحة، أولاً، أضف شكلًا سيحتوي على النص الرياضي:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

بعد الإنشاء، سيكون الشكل يحتوي بالفعل على فقرة واحدة مع جزء رياضي بشكل افتراضي. تسمح فئة [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) بالوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) بالإشارة إلى المتغير [**MathParagraph** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph):

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

تسمح لك فئة [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) بقراءة وإضافة وتحرير وحذف كتل رياضية ([**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock))، التي تتكون من مجموعة من العناصر الرياضية. على سبيل المثال، قم بإنشاء كسر وضعه في العرض التقديمي:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

كل عنصر رياضي يمثل بفئة معينة تنفذ واجهة [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). توفر هذه الواجهة العديد من الطرق لإنشاء تعبيرات رياضية بسهولة. يمكنك إنشاء تعبير رياضي معقد تمامًا بسطر واحد من الشيفرة. على سبيل المثال، ستبدو نظرية فيثاغورس كما يلي:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

تُنفذ عمليات واجهة [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) في أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock).

عينة الشيفرة المصدرية الكاملة:

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
تتكون التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يتم تمثيل تسلسل العناصر الرياضية بواسطة كتلة رياضية، وتشكل معاملات العناصر الرياضية تعشيقًا على شكل شجرة.

هناك الكثير من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. يمكن تضمين كل من هذه العناصر (تجميعها) في عنصر آخر. أي، العناصر في الواقع حاويات لعناصر أخرى، تشكل هيكلًا شجريًا. أبسط نوع من العناصر هو ذلك الذي لا يحتوي على عناصر أخرى من النص الرياضي.

كل نوع من عناصر الرياضيات ينفذ واجهة [**IMathElement** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) مما يسمح باستخدام مجموعة مشتركة من العمليات الرياضية على أنواع مختلفة من عناصر الرياضيات.
### **فئة MathematicalText**
تُمثل فئة [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) نصًا رياضيًا - العنصر الأساسي لجميع الإنشاءات الرياضية. قد يمثل النص الرياضي المعاملات والعوامل والمتغيرات وأي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐
### **فئة MathFraction**
تحدد فئة [**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction) كائن الكسر، والذي يتكون من بسط ومقام مفصولين بشرط كسر. يمكن أن يكون شرط الكسر أفقيًا أو مائلًا، اعتمادًا على خصائص الكسر. يُستخدم كائن الكسر أيضًا لتمثيل دالة التكديس، التي تضع عنصرًا فوق آخر، بدون شرط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **فئة MathRadical**
تحدد فئة [**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical) دالة الجذر (الجذر الرياضي)، والتي تتكون من قاعدة، ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **فئة MathFunction**
تحدد فئة [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) دالة لمعامل. تحتوي على الخصائص: [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--) - اسم الدالة و[getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--) - معامل الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **فئة MathNaryOperator**
تحدد فئة [**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator) كائن رياضي N-ary، مثل الجمع والتكامل. يتكون من عامل، قاعدة (أو معامل)، وحدود عليا وسفلى اختيارية. من أمثلة العوامل N-ary الجمع، الاتحاد، التقاطع، التكامل.

لا تتضمن هذه الفئة عوامل بسيطة مثل الجمع، الطرح، وما إلى ذلك. يتم تمثيلها بواسطة عنصر نصي واحد - [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **فئة MathLimit**
تُنشئ فئة [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) الحد العلوي أو السفلي. تحدد كائن الحد، الذي يتكون من نص على الخط الأساسي ونص بحجم مصغر مباشرةً أعلاه أو أسفله. لا تتضمن هذه العنصر كلمة "lim"، لكن تسمح لك بإضافة نص في الجزء العلوي أو السفلي من التعبير. لذا، فإن التعبير 

![todo:image_alt_text](powerpoint-math-equations_8.png)

يتم إنشاؤه باستخدام مزيج من عناصر [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) و[**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) بهذه الطريقة:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 


### **فئات MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

تحدد الفئات التالية فهرسًا سفليًا أو علوياً. يمكنك تعيين النقص العلوي والسفلي في نفس الوقت على الجانب الأيسر أو الأيمن من معامل، ولكن النقص الفردي أو العلوي مدعوم فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) لتعيين الدرجة الرياضية لعدد.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **فئة MathMatrix**
تحدد فئة [**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix) كائن المصفوفة، الذي يتكون من عناصر فرعية مرتبة في صفوف وأعمدة. من المهم ملاحظة أن المصفوفات لا تحتوي على فواصل زمنية مضمنة. لوضع المصفوفة بين الأقواس، يجب استخدام كائن الفاصل - [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter). يمكن استخدام معاملات فارغة لإنشاء فجوات في المصفوفات.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **فئة MathArray**
تحدد فئة [**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray) مصفوفة عمودية من المعادلات أو أي كائنات رياضية.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **تنسيق العناصر الرياضية**
- فئة [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox): ترسم إطارًا مستطيلًا أو أي إطار آخر حول [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox): تحدد التعبئة المنطقية (تغليف) العنصر الرياضي. على سبيل المثال، يمكن أن يكون الكائن المعبأ جهاز محاكاة عامل مع أو بدون نقطة محاذاة، أو يكون نقطة انقطاع، أو يتم تجميعها بحيث لا تسمح بانقطاعات داخلية. على سبيل المثال، يجب تغليف عامل "==" لمنع الانقطاعات.

- فئة [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter): تحدد كائن الفاصل، الذي يتكون من أحرف مفتوحة ومغلقة (مثل الأقواس، والأقواس، والأطواق، والأشرطة الرأسية)، وواحدة أو أكثر من العناصر الرياضية بالداخل، مفصولة بواسطة حرف معين. أمثلة: (𝑥2); [𝑥2|𝑦2].
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent): تحدد وظيفة الانحناء، التي تتكون من قاعدة وعلامة تشكيل مركبة.

  مثال: 𝑎́.

- فئة [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar): تحدد وظيفة الشريط، والتي تتكون من حجة الأساس وشريط فوقها أو تحتها.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter): تحدد رمز التجميع فوق أو أسفل تعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **عمليات رياضية**
كل عنصر رياضي ومعادلة رياضية (عبر [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)) تنفذ واجهة [**IMathElement** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) مما يسمح لك باستخدام العمليات على الهيكل الحالي وتشكيل تعبيرات رياضية أكثر تعقيدًا. جميع العمليات لديها مجموعتين من المعلمات: إما [**IMathElement** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) أو سلسلة كوسيطات. يتم إنشاء مثيلات فئة [**MathematicalText** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) ضمنيًا من السلاسل المحددة عند استخدام وسيطات السلسلة. العمليات الرياضية المتاحة في Aspose.Slides مدرجة أدناه.
### **طريقة الانضمام**
- [join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

ينضم عنصر رياضي ويشكل كتلة رياضية. على سبيل المثال:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **طريقة القسمة**
- [divide(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

يخلق كسرًا من النوع المحدد مع البسط هذا والمقام المحدد. على سبيل المثال:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **طريقة الإغلاق**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

يُغلق العنصر في أحرف محددة مثل الأقواس أو حرف آخر كإطار.

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


على سبيل المثال:

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **طريقة الدالة**
- [function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

تأخذ دالة لمعامل مستخدمة الحالية كاسم الدالة.

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


على سبيل المثال:

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **طريقة asArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

تأخذ الدالة المحددة باستخدام المثيل الحالي كحجة. يمكنك:

- تحديد سلسلة كاسم الدالة، على سبيل المثال "cos".
- اختيار واحدة من القيم المحددة مسبقًا من التعدادات [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments)، على سبيل المثال [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- اختيار مثيل من [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).

على سبيل المثال:

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

تعيين فهرس سفلي وعلوي. يمكنك تعيين فهرس سفلي وعلوي في نفس الوقت على الجانب الأيسر أو الأيمن من المعامل، لكن يتم دعم الفهرس الفردي أو العلوي فقط على الجانب الأيمن. يمكن أيضًا استخدام الفهرس العلوي لتعيين الدرجة الرياضية لعدد.

مثال:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **طريقة الجذر**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

تحدد الجذر الرياضي من الدرجة المحددة من المعامل المحدد.

مثال:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **طرق SetUpperLimit و SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

تأخذ الحد العلوي أو السفلي. هنا، يشير الحد العلوي والسفلي ببساطة إلى موقع المعامل بالنسبة للأساس.

دعونا نفكر في تعبير: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعابير من خلال مزيج من فئات [MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) و [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)، وعمليات [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) كالتالي:

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

تقوم كلا من **nary** و **integral** بإنشاء وإرجاع عامل N-ary يتم تمثيله بواسطة نوع [**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator) . في طريقة nary، يحدد تعداد [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes) نوع العامل: الجمع، الاتحاد، إلخ، دون تضمين التكامل. في طريقة التكامل، هناك عملية متخصصة هي التكامل مع تعداد من أنواع التكامل [**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes). 

مثال:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **طريقة toMathArray**
[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) تضع العناصر في مصفوفة عمودية. إذا تم استدعاء هذه العملية على مثيل [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)، ستوضع جميع العناصر الفرعية في المصفوفة المرتجعة.

مثال:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- تحدد طريقة [**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-) علامة الانحناء (حرف على قمة العنصر).
- تحدد طرق [**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--) و[**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--) شريطًا في الأعلى أو الأسفل.
- تضع طريقة [**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--) في مجموعة باستخدام حرف التجميع مثل قوس سفلي ملتوي أو أي شيء آخر.
- تضع طريقة [**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--) في صندوق حدود.
- تضع طريقة [**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--) في صندوق غير مرئي (تجميع منطقي).

أمثلة:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 