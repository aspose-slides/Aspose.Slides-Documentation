---
title: معادلات رياضية PowerPoint
type: docs
weight: 80
url: /ar/nodejs-java/powerpoint-math-equations/
keywords: " معادلات رياضية PowerPoint, رموز رياضية PowerPoint, صيغة PowerPoint, نص رياضي PowerPoint"
description: "معادلات رياضية PowerPoint, رموز رياضية PowerPoint, صيغة PowerPoint, نص رياضي PowerPoint"
---

## **نظرة عامة**
في PowerPoint، من الممكن كتابة معادلة رياضية أو صيغة وعرضها في العرض التقديمي. للقيام بذلك، يتم تمثيل رموز رياضية مختلفة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لهذا، يُستخدم مُنشئ المعادلات الرياضية في PowerPoint، الذي يساعد على إنشاء صيغ مركبة مثل:

- كسر رياضي
- جذور رياضية
- دالة رياضية
- حدود ودوال اللوغاريتم
- عمليات N-ary
- مصفوفة
- عمليات كبيرة
- دوال sin, cos

لإضافة معادلة رياضية في PowerPoint، يُستخدم القائمة *Insert -> Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيتم إنشاء نص رياضي بصيغة XML يمكن عرضه في PowerPoint كما يلي: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint العديد من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، غالبًا ما لا ينتج عن إنشاء معادلات رياضية معقدة في PowerPoint نتيجة ذات مظهر جيد واحترافي. يلجأ المستخدمون الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر إلى حلول طرف ثالث لإنشاء صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/)، يمكنك العمل مع المعادلات الرياضية في عروض PowerPoint برمجيًا باستخدام C#. أنشئ تعابير رياضية جديدة أو حرر التعابير التي تم إنشاؤها مسبقًا. كما يتم دعم تصدير الهياكل الرياضية إلى صور جزئيًا.

## **كيفية إنشاء معادلة رياضية**
تُستخدم العناصر الرياضية لبناء أي تركيبات رياضية بمستوى تعشيق أيًا كان. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية يُمثّلها صنف [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock). صنف [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) هو في الأساس تعبير رياضي منفصل أو صيغة أو معادلة. يُعد صنف [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) جزءًا رياضيًا يُستخدم لحفظ النص الرياضي (لا تخلطه مع [**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)). يسمح صنف [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) بالتعامل مع مجموعة من كتل الرياضيات. تُعد الأصناف المذكورة أعلاه المفتاح للعمل مع معادلات PowerPoint الرياضية عبر API الخاص بـ Aspose.Slides.

دعنا نرى كيف يمكننا إنشاء المعادلة الرياضية التالية عبر API الخاص بـ Aspose.Slides:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، أضف أولاً شكلًا سيحتوي على النص الرياضي:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

بعد الإنشاء، سيحتوي الشكل بالفعل على فقرة واحدة مع جزء رياضي بشكل افتراضي. صنف [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) هو جزء يحتوي على نص رياضي داخل. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion)، اشّر إلى المتغيّر [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) كالتالي:

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

يُتيح صنف [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) قراءة وإضافة وتعديل وحذف كتل الرياضيات ([**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)) التي تتكوّن من مجموعة من العناصر الرياضية. على سبيل المثال، أنشئ كسرًا وضعه في العرض:

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

كل عنصر رياضي يُمثَّل بصنف ينفّذ الصنف [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement). يوفّر هذا الصنف عددًا كبيرًا من الأساليب لإنشاء تعابير رياضية بسهولة. يمكنك إنشاء تعبير رياضي معقّد باستخدام سطر واحد من الشيفرة. على سبيل المثال، ستظهر معادلة فيثاغورس هكذا:

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

تُنفّذ عمليات الصنف [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) في أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock).

عينة الشيفرة الكاملة:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
    var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    var fraction = new aspose.slides.MathematicalText("x").divide("y");
    mathParagraph.add(new aspose.slides.MathBlock(fraction));
    var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);
    pres.save("math.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

## **أنواع العناصر الرياضية**
تتشكل التعابير الرياضية من تسلسلات من العناصر الرياضية. يُمثَّل تسلسل العناصر الرياضية بكتلة رياضية، وتشكل حجج العناصر الرياضية تعشُّقًا شجريًا.

هناك عدد كبير من أنواع العناصر الرياضية التي يمكن استخدامها لإنشاء كتلة رياضية. يمكن تضمين كل عنصر (تجميع) داخل عنصر آخر. أي أن العناصر هي في الواقع حاويات لعناصر أخرى، مكوّنةً بنية شجرية. أبسط نوع من العنصر لا يحتوي على عناصر نصية رياضية أخرى.

كل نوع من العناصر الرياضية ينفّذ الصنف [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement)؛ مما يسمح باستخدام مجموعة مشتركة من عمليات الرياضيات على أنواع مختلفة من العناصر.

### **الصنف MathematicalText**
الصنف [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) يُمثّل نصًا رياضيًا — العنصر الأساسي لكل التركيبات الرياضية. قد يمثل النص الرياضي معاملات ومشغّلات، متغيرات، أو أي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐

### **الصنف MathFraction**
الصنف [**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction) يُحدّد كائن الكسر، المكوّن من بسط ومقام مفصولين بشريط الكسر. يمكن أن يكون شريط الكسر أفقيًا أو مائلًا بحسب خصائص الكسر. يُستَخدم كائن الكسر أيضًا لتمثيل دالة المكدس، التي تضع عنصرًا فوق آخر دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **الصنف MathRadical**
الصنف [**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical) يُحدّد دالة الجذر (جذر رياضي)، مكوّنًا من قاعدة ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **الصنف MathFunction**
الصنف [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) يُحدّد دالة لوسيط. يحتوي على خاصيتين: [getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getName--) — اسم الدالة، و[getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getBase--) — وسيط الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **الصنف MathNaryOperator**
الصنف [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) يُحدّد كائنًا رياضيًا N-ary مثل الجمع التراكمي (Summation) والتكامل. يتكوّن من مشغّل، قاعدة (أو معامل)، ودرجات علوية وسفلية اختيارية. من أمثلة المشغّلات N-ary: Summation، Union، Intersection، Integral.

هذا الصنف لا يتضمن المشغّلات البسيطة مثل الجمع أو الطرح؛ تُمثل هذه المشغّلات بعنصر نصي واحد — [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **الصنف MathLimit**
الصنف [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) يُنشئ حدًا علويًا أو سفليًا. يُحدّد كائن الحد نصًا على الخط الأساسي ونصًا مصغّرًا فوقه أو أسفله مباشرة. لا يحتوي هذا العنصر على كلمة “lim”، بل يسمح لك بوضع النص في أعلى أو أسفل التعبير. لذا، يُنشأ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مزيج من عناصر [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) و[**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) يتم إنشاؤه كالتالي:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 

### **الصنف MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

تُحدّد الأصناف التالية مؤشرًا سفليًا أو علويًا. يمكن ضبط كل من النص السُفْلي والعُلوي في الوقت نفسه على الجانب الأيسر أو الأيمن للوسيط، لكن يُدعم النص السُفْلي أو العُلوي المفرد فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement) لتحديد درجة رياضية لعدد.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **الصنف MathMatrix**
الصنف [**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix) يُحدّد كائن المصفوفة، المكوّن من عناصر فرعية مرتبة في صفوف وأعمدة. تجدر الإشارة إلى أن المصفوفات لا تتضمن محددات مدمجة. لوضع المصفوفة بين أقواس يجب استخدام كائن المحدد — [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter). يمكن استخدام قيم فارغة لإنشاء فراغات داخل المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **الصنف MathArray**
الصنف [**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray) يُحدّد مصفوفة رأسية من المعادلات أو أي كائنات رياضية أخرى.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**
- الصنف [**MathBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox): يرسم حدودًا مستطيلة أو غيرها حول [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement).

  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- الصنف [**MathBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox): يُحدّد تغليفًا منطقيًا (تعبئة) للعنصر الرياضي. على سبيل المثال، يمكن أن يكون الكائن المغلف محاكٍ للمشغّل مع أو بدون نقطة محاذاة، أو يُستخدم كفاصل سطر، أو يُجمّع بحيث لا يسمح بحدوث فواصل سطر داخله. على سبيل المثال، يجب تغليف مشغّل “==” لمنع فواصل الأسطر.

- الصنف [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter): يُحدّد كائن المحدد، المكوّن من أحرف افتتاحية وإغلاقية (مثل الأقواس، القوس المعقوف، الأقواس المربعة، أو الخطوط العمودية)، وعنصر أو أكثر داخلية مفصولة بحرف محدد. أمثلة: (𝑥2); [𝑥2|𝑦2].

  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- الصنف [**MathAccent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent): يُحدّد دالة اللكنة، المكوّن من قاعدة وعلامة دمجية.

  مثال: 𝑎́.

- الصنف [**MathBar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar): يُحدّد دالة الشريط، المكوّن من وسيط أساسي وشريط فوقي أو سفلي.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- الصنف [**MathGroupingCharacter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter): يُحدّد رمز تجميع فوق أو تحت التعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**
كل عنصر رياضي وتعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)) ينفّذ الصنف [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement). يسمح لك باستخدام عمليات على البنية الحالية وتكوين تعابير رياضية أكثر تعقيدًا. جميع العمليات لها مجموعتين من الوسائط: إما [**MathElement**] أو سلسلة كوسائط. تُنشأ كائنات الصنف [**MathematicalText**] ضمنيًا من السلاسل المحددة عند استخدام وسائط نصية. تُدرج عمليات الرياضيات المتاحة في Aspose.Slides أدناه.

### **طريقة Join**
- [join(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-aspose.slides.IMathElement-)

تدمج عنصرًا رياضيًا وتشكل كتلة رياضية. مثال:

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **طريقة Divide**
- [divide(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-int-)

ينشئ كسرًا من النوع المحدد مع هذا البسط والمقام المحدد. مثال:

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **طريقة Enclose**
- [enclose()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose-char-char-)

يحيط العنصر بأحرف محددة مثل الأقواس أو حرف آخر كإطار.

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

```javascript
var delimiter = new aspose.slides.MathematicalText("x").enclose('[', ']');
var delimiter2 = new aspose.slides.MathematicalText("elem1").join("elem2").enclose();
``` 

### **طريقة Function**
- [function(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-aspose.slides.IMathElement-)

تُنشئ دالة لوسيط باستخدام الكائن الحالي كاسم للدالة.

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

```javascript
var func = new aspose.slides.MathematicalText("sin").function("x");
``` 

### **طريقة AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-java.lang.String-)

تُخذ الدالة المحددة باستخدام المثيل الحالي كوسيط. يمكنك:

- تحديد سلسلة كاسم للدالة، مثل “cos”.
- اختيار إحدى القيم المُعرَّفة مسبقًا في تعداد [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfTwoArguments)، مثل [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- اختيار مثيل من [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement).

مثال:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 

### **طرق SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-aspose.slides.IMathElement-aspose.slides.IMathElement-)

يضبط النص السفلي والعُلوي. يمكنك ضبط النص السفلي والعُلوي معًا على الجانب الأيسر أو الأيمن من الوسيط، لكن النص السفلي أو العُلوي المفرد يُدعم فقط على الجانب الأيمن. يمكن أيضًا استخدام **Superscript** لتحديد درجة رياضية لعدد.

مثال:

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **طريقة Radical**
- [radical(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-aspose.slides.IMathElement-)

يحدد الجذر الرياضي للدرجة المعطاة من الوسيط المحدد.

مثال:

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **طرق SetUpperLimit و SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-aspose.slides.IMathElement-)

تُحدد حدًا علويًا أو سفليًا. يشير الحد العلوي والسفلي ببساطة إلى موقع الوسيط بالنسبة للقاعدة.

لنأخذ مثالًا على التعبير:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات عبر مزيج من أصناف [MathFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) و[MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) وعمليات [MathElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) كما يلي:

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **طرق Nary و Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-int-)

تنشئ كل من طريقتي **nary** و **integral** كائنًا من النوع [**MathNaryOperator**]. في طريقة nary، يحدِّد تعداد [**MathNaryOperatorTypes**] نوع المشغّل: جمع متسلسل، اتحاد، إلخ، ولا تشمل التكاملات. في طريقة Integral، يُستخدم تعداد [**MathIntegralTypes**] لتحديد نوع التكامل.

مثال:

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **طريقة ToMathArray**
تضع طريقة [**toMathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toMathArray--) العناصر في مصفوفة رأسية. إذا تم استدعاء هذه العملية على كائن من صنف [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)، فستوضع جميع العناصر الفرعية في المصفوفة المُسترجعة.

مثال:

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- طريقة **accent** تضبط علامةً فوق العنصر.
- طريقتا **overbar** و **underbar** تضبطان شريطًا فوق أو تحت العنصر.
- طريقة **group** تضع العنصر داخل مجموعة باستخدام رمز تجميع مثل القوس المعقوف السفلي أو غيره.
- طريقة **toBorderBox** تضع العنصر داخل صندوق حد.
- طريقة **toBox** تضع العنصر داخل صندوق غير مرئي (تجميع منطقي).

أمثلة:

```javascript
var accent = new aspose.slides.MathematicalText("x").accent('̃');
var bar = new aspose.slides.MathematicalText("x").overbar();
var groupChr = new aspose.slides.MathematicalText("x").join("y").join("z").group('⏡', aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top);
var borderBox = new aspose.slides.MathematicalText("x+y+z").toBorderBox();
var boxedOperator = new aspose.slides.MathematicalText(":=").toBox();
``` 

## **الأسئلة الشائعة**

**كيف يمكن إضافة معادلة رياضية إلى شريحة PowerPoint؟**

لإضافة معادلة رياضية، تحتاج إلى إنشاء كائن `MathShape`، والذي يحتوي تلقائيًا على جزء رياضي. بعد ذلك، استرجع `MathParagraph` من `MathPortion` وأضف كائنات `MathBlock` إليها.

**هل من الممكن إنشاء تعابير رياضية متداخلة معقدة؟**

نعم، يتيح Aspose.Slides إنشاء تعابير رياضية معقدة عن طريق تعشيق كتل MathBlocks. كل عنصر رياضي ينفّذ الصنف `IMathElement`، والذي يتيح لك تطبيق عمليات (Join، Divide، Enclose، إلخ) لتجميع العناصر في هياكل أكثر تعقيدًا.

**كيف يمكن تحديث أو تعديل معادلة رياضية موجودة؟**

لتحديث معادلة، عليك الوصول إلى كتل MathBlocks الحالية عبر `MathParagraph`. ثم باستخدام طرق مثل Join، Divide، Enclose، وغيرها، يمكنك تعديل عناصر المعادلة الفردية. بعد التحرير، احفظ العرض التقديمي لتطبيق التغييرات.