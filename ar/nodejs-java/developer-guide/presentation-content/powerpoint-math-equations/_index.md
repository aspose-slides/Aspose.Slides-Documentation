---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية باستخدام JavaScript
linktitle: معادلات رياضية في PowerPoint
type: docs
weight: 80
url: /ar/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "إدراج وتحرير المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides لـ Node.js، مع دعم OMML، وضبط تنسيقات، وأمثلة شفرة واضحة."
---

## **نظرة عامة**
في PowerPoint يمكن كتابة معادلة أو صيغة رياضية وعرضها في العرض التقديمي. للقيام بذلك يتم تمثيل رموز رياضية متعددة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لهذا يُستخدم مُنشئ المعادلات الرياضية في PowerPoint، والذي يساعد على إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- حدود ودوال اللوغارتم
- عمليات N-ary
- مصفوفة
- معاملات كبيرة
- دوال الجيب والجيب التمام

لإضافة معادلة رياضية في PowerPoint يُستخدم القائمة *Insert -> Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيتم إنشاء نص رياضي بصيغة XML يمكن عرضه في PowerPoint كما يلي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يُدعم PowerPoint عددًا كبيرًا من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، غالبًا ما لا يعطي إنشاء معادلات رياضية معقدة في PowerPoint نتيجة احترافية وجيدة. يلجأ المستخدمون الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر إلى حلول الطرف الثالث للحصول على صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/)، يمكنك التعامل مع المعادلات الرياضية في عروض PowerPoint برمجياً بلغة C#. أنشئ تعبيرات رياضية جديدة أو حرّر تلك التي تم إنشاؤها مسبقًا. كما يدعم جزئيًا تصدير الهياكل الرياضية إلى صور.


## **كيفية إنشاء معادلة رياضية**
يُستخدم العنصر الرياضي لبناء أي بنية رياضية بمستويات تعشيش مختلفة. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية يُمثّلها الصف [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock). صف **MathBlock** هو في الأساس تعبير رياضي منفصل أو صيغة أو معادلة. صف **MathPortion** هو جزء رياضي يُستخدم لحفظ النص الرياضي (لا تمزج مع [**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)). يتيح صف **MathParagraph** تعديل مجموعة من كتل الرياضيات. هذه الأصناف المذكورة أعلاه هي المفتاح للعمل مع معادلات PowerPoint الرياضية عبر Aspose.Slides API.

لنرى كيف يمكن إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، أضف أولًا شكلًا سيحتوي على النص الرياضي:

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

بعد الإنشاء، سيحتوي الشكل بالفعل على فقرة واحدة مع جزء رياضي بشكل افتراضي. صف [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) هو الجزء الذي يحتوي على نص رياضي. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion)، استخدم متغيّر [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph):

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

يسمح صف [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) بقراءة وإضافة وتعديل وحذف كتل الرياضيات ([**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock))، التي تتكوّن من مجموعة من العناصر الرياضية. على سبيل المثال، أنشئ كسرًا وضعه في العرض التقديمي:

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

كل عنصر رياضي يُمثَّل بواسطة صف يُنفّذ صف **MathElement**. يوفّر هذا الصف العديد من الأساليب لإنشاء تعبيرات رياضية بسهولة. يمكنك إنشاء تعبير رياضي معقّد نسبيًا بسطر واحد من الشيفرة. على سبيل المثال، يبدو مبرهن فيثاغورس هكذا:

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

تُطبّق عمليات صف **MathElement** على أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock).

العينة الكاملة للشيفرة:

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
تتكوّن التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يُمثَّل تسلسل العناصر الرياضية بكتلة رياضية، وتُشكّل وسائط العناصر شجرةً متداخلة.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. يمكن تضمين كل عنصر داخل عنصر آخر، أي أن العناصر تعمل كحاويات للأخرى، مُشكِّلةً بنية شجرية. أبسط نوع من العنصر هو الذي لا يحتوي على عناصر أخرى من النص الرياضي.

كل نوع من العناصر يُنفّذ صف **MathElement**، مما يتيح استخدام مجموعة مشتركة من عمليات الرياضيات على أنواع مختلفة من العناصر.

### **صف MathematicalText**
يمثّل الصف [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) نصًا رياضيًا – العنصر الأساسي لجميع البنى الرياضية. قد يَكون النص الرياضي عوامل أو معطيات أو متغيّرات أو أي نص خطّي آخر.

مثال: 𝑎=𝑏+𝑐

### **صف MathFraction**
يحدد الصف [**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction) كائن الكسر المكوّن من بسط ومقام مفصولين بشريط كسر. يمكن أن يكون شريط الكسر أفقيًا أو مائلًا حسب خصائص الكسر. يُستَخدم كائن الكسر أيضًا لتمثيل دالة المكدس التي تضع عنصرًا فوق آخر دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **صف MathRadical**
يحدد الصف [**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical) دالة الجذر الرياضي، المكوّن من قاعدة وجذر اختياري الدرجة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **صف MathFunction**
يحدد الصف [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) دالة ذات معامل. يحتوي على الخاصيتين: [getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getName--) – اسم الدالة و[getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getBase--) – معامل الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **صف MathNaryOperator**
يحدد الصف [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) كائنًا رياضيًا متعدد الحدود، مثل الجمع والتكامل. يتكوّن من معامل، وقاعدة (أو معامل)، وحدود علوية وسفلية اختيارية. من أمثلة المشغّلين المتعددين: الجمع، الاتحاد، التقاطع، التكامل.

هذا الصف لا يتضمن المشغّلات البسيطة مثل الجمع أو الطرح؛ تُمثَّل تلك بواسطة عنصر نصي واحد – [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **صف MathLimit**
يُنشئ الصف [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) حدًا علويًا أو سفليًا. يحدّد كائن الحد نصًا على الخط الأساسي ونصًا مصغرًا فوقه أو تحته مباشرة. لا يتضمن هذا العنصر كلمة “lim”، لكنه يسمح بوضع النص في أعلى أو أسفل التعبير. لذا، يُنشأ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مزيج من صفوف [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) و[**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) هكذا:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 

### **صفوف MathSubscriptElement، MathSuperscriptElement، MathRightSubSuperscriptElement، MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

تُحدِّد الصفوف التالية مؤشرًا سفليًا أو علويًا. يمكنك ضبط الفهرس السفلي والعلوي في آنٍ واحد على الجهة اليسرى أو اليمنى للمعامل، لكن يُدعم الفهرس الفردي (سفلي أو علوي) على الجانب الأيمن فقط. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement) لتحديد درجة عددية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **صف MathMatrix**
يحدد الصف [**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix) كائن المصفوفة، المكوّن من عناصر فرعية مرتبة في صفوف وأعمدة. تجدر الإشارة إلى أن المصفوفات لا تحتوي على محددات مدمجة؛ لوضع المصفوفة بين أقواس يجب استعمال كائن المحدد – [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter). يمكن استخدام قيم `null` لإنشاء فراغات داخل المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **صف MathArray**
يحدد الصف [**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray) مصفوفةً رأسيةً من المعادلات أو أي كائنات رياضية أخرى.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**
- صف [**MathBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox): يرسم حدًا مستطيلًا أو شكلًا آخر حول **MathElement**.  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- صف [**MathBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox): يحدِّد تغليفًا منطقيًا للعنصر الرياضي. على سبيل المثال، يمكن استخدام كائن مغلق كمحاكي للمشغل مع أو بدون نقطة محاذاة، أو لتجنب كسر السطر داخل الكائن.

- صف [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter): يحدِّد كائن المحدد، المكوّن من حرفي افتتاح وإغلاق (مثل الأقواس أو الأقواس المربعة أو الأعمدة العمودية)، وواحد أو أكثر من العناصر الرياضية داخله، مفصولة بحرف محدد. أمثلة: (𝑥²); [𝑥²|𝑦²].  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- صف [**MathAccent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent): يحدِّد دالة التشكيل، المكوّن من قاعدة وعلامة تشكيلية مُدمجة.  
  مثال: 𝑎́.

- صف [**MathBar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar): يحدِّد دالة الشريط، المكوّن من معامل أساسي وشريط علوي أو سفلي.  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- صف [**MathGroupingCharacter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter): يحدِّد رمزًا تجميعيًا فوق أو تحت تعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **العمليات الرياضية**
كل عنصر أو تعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)) يُنفّذ صف **MathElement**. يتيح لك ذلك إجراء عمليات على البنية الحالية وتكوين تعبيرات رياضية أكثر تعقيدًا. لكل عملية مجموعتان من المعاملات: إما **MathElement** أو سلسلة نصية. تُخلق كائنات من صف [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) ضمنيًا من السلاسل عندما تُستعمل كوسائط. تُدرج العمليات الرياضية المتاحة في Aspose.Slides أدناه.

### **طريقة Join**
- `join(String)`
- `join(MathElement)`

تدمج عنصرًا رياضيًا وتُكوّن كتلة رياضية. مثال:

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **طريقة Divide**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

تنشئ كسرًا من النوع المحدد باستخدام هذا البسط والمقام المحدد. مثال:

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **طريقة Enclose**
- `enclose()`
- `enclose(Char, Char)`

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

```javascript
var delimiter = new aspose.slides.MathematicalText("x").enclose('[', ']');
var delimiter2 = new aspose.slides.MathematicalText("elem1").join("elem2").enclose();
``` 

### **طريقة Function**
- `function(String)`
- `function(MathElement)`

تُعرِّف دالة ذات معامل باستخدام الكائن الحالي كاسم الدالة.

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(MathElement functionArgument);

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
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

تُعطي الدالة المحددة باستخدام الكائن الحالي كمعامل. يمكنك:

- تحديد سلسلة كاسم الدالة، مثل “cos”.
- اختيار أحد القيم المعرفة في تعداد [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfTwoArguments)، مثل [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument).ArcSin.
- اختيار كائن **MathElement**.

مثال:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 

### **طرق SetSubscript و SetSuperscript و SetSubSuperscriptOnTheRight و SetSubSuperscriptOnTheLeft**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

تُعيّن الفهرس السفلي والعلوي. يمكنك ضبطهما معًا على اليمين أو اليسار، لكن الفهرس الفردي (سفلي أو علوي) يُدعم فقط على اليمين. يمكن أيضًا استخدام **Superscript** لتحديد درجة عددية.

مثال:

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **طريقة Radical**
- `radical(String)`
- `radical(MathElement)`

تحدد الجذر الرياضي للدرجة المحددة من المعامل المعطى.

مثال:

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **طرق SetUpperLimit و SetLowerLimit**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

تُعيّن الحد العلوي أو السفلي. هنا يُشير الحد العلوي والسفلي ببساطة إلى موقع المعامل بالنسبة للقاعدة.

نُعيد النظر في التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات عبر دمج صفوف [MathFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) و[MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) وعمليات **MathElement** كما يلي:

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **طرق Nary و Integral**
- `nary(MathNaryOperatorTypes, MathElement, MathElement)`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

كلا الطريقتين **nary** و**integral** تُنشئ وتُعيد المشغّل متعدد الحدود المُمَثَّل بالصف [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator). في طريقة **nary**، يحدِّد تعداد [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperatorTypes) نوع المشغّل: جمع، اتحاد، إلخ، ولا يشمل التكاملات. في طريقة **integral**، يُستَخدم تعداد [**MathIntegralTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathIntegralTypes) لتحديد نوع التكامل.

مثال:

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **طريقة ToMathArray**
تضع طريقة **toMathArray** العناصر في مصفوفة رأسية. إذا استُدعِيَت على كائن من صف [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)، فستُوضع جميع العناصر الفرعية في المصفوفة المرجعة.

مثال:

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **عمليات التنسيق: Accent، Overbar، Underbar، Group، ToBorderBox، ToBox**
- طريقة **accent** تُضيف علامة تشكيلية (حرف فوق العنصر).
- طريقتا **overbar** و**underbar** تضيفان شريطًا فوق أو تحت العنصر.
- طريقة **group** تُوضِّع العنصر في مجموعة باستخدام رمز تجميع مثل القوس المعقوف السفلي أو غيره.
- طريقة **toBorderBox** تُضع العنصر في حدّ‑مربع.
- طريقة **toBox** تُضع العنصر في صندوقٍ غير مرئي (تجميع منطقي).

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

لإضافة معادلة رياضية، عليك إنشاء كائن `MathShape`، والذي يحتوي تلقائيًا على جزء رياضي. ثم تستخرج `MathParagraph` من `MathPortion` وتضيف كائنات `MathBlock` إليه.

**هل يمكن إنشاء تعبيرات رياضية متداخلة ومعقّدة؟**

نعم، يُتيح Aspose.Slides إنشاء تعبيرات رياضية معقّدة عبر تعشيش `MathBlock`. كل عنصر رياضي يرث صف `MathElement`، ما يسمح بتطبيق عمليات (Join، Divide، Enclose، إلخ) لدمج العناصر في هياكل أكثر تعقيدًا.

**كيف يمكن تعديل أو تحديث معادلة رياضية موجودة؟**

لتحديث معادلة، عليك الوصول إلى `MathBlock` الموجود عبر `MathParagraph`. ثم باستخدام طرق مثل Join، Divide، Enclose، وغيرها، يمكنك تعديل عناصر المعادلة. بعد التحرير، احفظ العرض لتطبيق التغييرات.