---
title: معادلات الرياضيات في PowerPoint
type: docs
weight: 80
url: /ar/java/powerpoint-math-equations/
keywords: "معادلات الرياضيات في PowerPoint, رموز الرياضيات في PowerPoint, صيغة PowerPoint, نص الرياضيات في PowerPoint"
description: "معادلات الرياضيات في PowerPoint, رموز الرياضيات في PowerPoint, صيغة PowerPoint, نص الرياضيات في PowerPoint"
---

## **نظرة عامة**
في PowerPoint، من الممكن كتابة معادلة أو صيغة رياضية وعرضها في العرض التقديمي. للقيام بذلك، تمثل رموز رياضية متنوعة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لذلك، يتم استخدام مُنشئ المعادلات الرياضية في PowerPoint، الذي يساعد على إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- حدود ودوال اللوغاريتم
- عمليات N-ary
- مصفوفة
- عمليات كبيرة
- دوال جيب وجيب التمام

لإضافة معادلة رياضية في PowerPoint، يتم استخدام قائمة *إدراج -> معادلة*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيؤدي هذا إلى إنشاء نص رياضي بتنسيق XML يمكن عرضه في PowerPoint كما يلي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint الكثير من الرموز الرياضية لإنشاء معادلات رياضية. ومع ذلك، فإن إنشاء معادلات رياضية معقدة في PowerPoint غالباً لا يؤدي إلى نتائج جيدة ومهنية. يلجأ المستخدمون، الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر، إلى استخدام حلول طرف ثالث لإنشاء صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/java/)، يمكنك العمل مع المعادلات الرياضية في عروض PowerPoint البرمجية في C#. قم بإنشاء تعبيرات رياضية جديدة أو تحرير التعبيرات التي تم إنشاؤها مسبقًا. يتم دعم تصدير الهياكل الرياضية إلى الصور جزئيًا أيضًا.

## **كيفية إنشاء معادلة رياضية**
تُستخدم العناصر الرياضية لبناء أي إنشاءات رياضية بأي مستوى من التعشيش. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية ممثلة بواسطة [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) class. تُعتبر [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) class في الأساس تعبيرًا رياضيًا منفصلًا، صيغة، أو معادلة. تُستخدم [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) لتحتوي على نص رياضي (لا ت混ه مع [**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)). يسمح [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) بالتلاعب بمجموعة من كتل الرياضيات. تعتبر الفئات المذكورة أعلاه الأساس للعمل مع معادلات الرياضيات في PowerPoint عبر Aspose.Slides API.

دعونا نرى كيف يمكننا إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

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

بعد الإنشاء، سيحتوي الشكل بالفعل على فقرة واحدة مع جزء رياضي بشكل افتراضي. تُعتبر [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) class جزءًا يحتوي على نص رياضي في الداخل. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion)، يرجى الرجوع إلى [**MathParagraph** ](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) variable:

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

تتيح [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) class قراءة وإضافة وتحرير وحذف كتل الرياضيات ([**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock))، التي تتكون من مجموعة من العناصر الرياضية. على سبيل المثال، قم بإنشاء كسر وضعه في العرض التقديمي:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

تمثل كل عنصر رياضي بعض الفئات التي تنفذ واجهة [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). توفر هذه الواجهة العديد من الأساليب لإنشاء تعبيرات رياضية بسهولة. يمكنك إنشاء تعبير رياضي معقد نسبيًا في سطر واحد من التعليمات. على سبيل المثال، سيكون لمبرهنة فيثاغورس الشكل التالي:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

تُطبق عمليات الواجهة [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) على أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock).

نموذج الشيفرة المصدرية بالكامل:

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
تُشكل التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يُمثل تسلسل العناصر الرياضية بواسطة كتلة رياضية، وتقوم معلمات العناصر الرياضية بتشكيل تعشيش شجري.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. يمكن تضمين كل من هذه العناصر (تجميعها) في عنصر آخر. أي أن العناصر هي في الواقع حاويات لآخرين، مكونةً هيكلًا شجريًا. أبسط نوع من العناصر هو الذي لا يحتوي على عناصر أخرى من النص الرياضي.

كل نوع من عناصر الرياضيات ينفذ واجهة [**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) interface، مما يسمح باستخدام مجموعة مشتركة من العمليات الرياضية على أنواع مختلفة من العناصر الرياضية.
### **فئة MathematicalText**
تُمثل [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) class نصًا رياضيًا - العنصر الأساسي لجميع الإنشاءات الرياضية. يمكن أن يمثل النص الرياضي عوامل وعمليات، ومتغيرات، وأي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐
### **فئة MathFraction**
تحدد [**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) class كائن الكسر، الذي يتكون من بسط ومقام مفصولين بشريط كسر. يمكن أن يكون شريط الكسر أفقيًا أو مائلًا، اعتمادًا على خصائص الكسر. يُستخدم كائن الكسر أيضًا لتمثيل دالة المكدس، التي تضع عنصرًا فوق الآخر، دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **فئة MathRadical**
تحدد [**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) class وظيفة الجذر الرياضي (الجذر الرياضي)، الذي يتكون من قاعدة، ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **فئة MathFunction**
تحدد [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) class دالة لعامل. تحتوي على الخصائص: [getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) - اسم الدالة و[getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) - عامل الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **فئة MathNaryOperator**
تحدد [**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) class كائن رياضي N-ary، مثل التجميع والتكامل. يتكون من عامل، قاعدة (أو عامل)، وحدود علوية وسفلية اختيارية. تشمل أمثلة المشغلات N-ary: التجميع، الاتحاد، التقاطع، التكامل.

لا تتضمن هذه الفئة العمليات البسيطة مثل الجمع والطرح، إلخ. يُمثلها عنصر نصي واحد - [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **فئة MathLimit**
تحدد [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) class الحدود العلوية أو السفلية. تحدد كائن الحد، الذي يتكون من نص على الخط الأساسي ونص بالحجم المخفض مباشرةً أعلاه أو أدناه. لا تتضمن هذه العنصر كلمة "lim"، ولكنها تتيح لك وضع نص في الأعلى أو الأسفل من التعبير. لذلك، يتم إنشاء التعبير

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مجموعة من العناصر [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) و[**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) بهذه الطريقة:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **فئات MathSubscriptElement وMathSuperscriptElement وMathRightSubSuperscriptElement وMathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

تحدد الفئات التالية مؤشرًا سفليًا أو علويًا. يمكنك تعيين الأحرف السفلى والعلوية في وقت واحد على الجانب الأيسر أو الأيمن من عامل، ولكن مؤشر فردي أو مُعَالٍ مدعوم فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) لتعيين درجة الرياضيات لعدد.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **فئة MathMatrix**
تحدد [**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) class كائن المصفوفة، الذي يتكون من عناصر فرعية موزعة في صفوف وأعمدة. من المهم أن نلاحظ أن المصفوفات ليس لديها فواصل مدمجة. لوضع المصفوفة في الأقواس، يجب عليك استخدام كائن الفاصل - [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter). يمكن استخدام الوسائط الفارغة لإنشاء فواصل في المصفوفات.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **فئة MathArray**
تحدد [**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) class مصفوفة عمودية من المعادلات أو أي كائنات رياضية.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **تنسيق العناصر الرياضية**
- [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox) class: ترسم حدودًا مستطيلة أو حدودًا أخرى حول [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox) class: تحدد التعبئة المنطقية (التغليف) للعناصر الرياضية. على سبيل المثال، يمكن أن يعمل كائن مؤطر كنموذج مشغل مع أو بدون نقطة محاذاة، أو يعمل كنقطة انقطاع خط، أو يتم تجميعه بحيث لا يسمح بانقطاعات الخط داخل. على سبيل المثال، يجب تعبئة المشغل "==" لمنع انقطاع الخطوط.
- [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter) class: تحدد كائن الفاصل، الذي يتكون من أحرف فتح وإغلاق (مثل الأقواس، الأقواس، الحواشي، والأشرطة الرأسية)، وواحد أو أكثر من العناصر الرياضية في الداخل، مفصولة بحرف محدد. الأمثلة: (𝑥2); [𝑥2|𝑦2].
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent) class: تحدد وظيفة النبرة، والتي تتكون من قاعدة وعلامة تشكيل مدمجة. 

  مثال: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar) class: تحدد دالة الشريط، التي تتكون من عامل أساسي وشريط فوقه أو تحته.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter) class: تحدد رمز التجميع فوق أو تحت تعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**
تنفذ كل عنصر رياضي وتعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) واجهة [**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) interface. يسمح لك باستخدام العمليات على الهيكل القائم وتشكيل تعبيرات رياضية أكثر تعقيدًا. تحتوي جميع العمليات على مجموعتي معلمات: إما [**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) أو سلسلة كمعلمات. يتم إنشاء حالات من الفئة [**MathematicalText** ](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) ضمنيًا من السلاسل المحددة عند استخدام معلمات السلسلة. عمليات الرياضيات المتاحة في Aspose.Slides مدرجة أدناه.
### **أسلوب Join**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

تربط عنصر رياضي وتشكيل كتلة رياضية. على سبيل المثال:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **أسلوب Divide**
- [divide(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

يخلق كسرًا من النوع المحدد مع هذا البسط والمقام المحددين. على سبيل المثال:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **أسلوب Enclose**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

يحيط العنصر في أحرف محددة مثل الأقواس أو حرف آخر كعمل تأطير.

```java
/**
 * <p>
 * يحيط عنصر رياضي في أقواس
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * يحيط هذا العنصر في أحرف محددة مثل الأقواس أو أحرف أخرى كعمل تأطير
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 

على سبيل المثال:

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **أسلوب Function**
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

تأخذ دالة لعامل باستخدام الكائن الحالي كاسم الدالة.

```java
/**
 * <p>
 * تأخذ دالة لعامل باستخدام هذه النسخة كاسم الدالة
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * تأخذ دالة لعامل باستخدام هذه النسخة كاسم الدالة
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 

على سبيل المثال:

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **أسلوب AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

تأخذ الدالة المحددة باستخدام النسخة الحالية كمعامل. يمكنك:

- تحديد سلسلة كاسم الدالة، على سبيل المثال "cos".
- اختيار واحدة من القيم المحددة مسبقًا من التعدادات [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments)، على سبيل المثال [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- اختيار مثيل من [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).

على سبيل المثال:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **أساليب SetSubscript و SetSuperscript و SetSubSuperscriptOnTheRight و SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

تعيين أحرف سفلى وأحرف عليا. يمكنك تعيين الأحرف السفلى والعلوية في وقت واحد على الجانب الأيسر أو الأيمن من العامل، ولكن يتم دعم مؤشر فردي أو مُعَالٍ فقط على الجانب الأيمن. يمكن أيضًا استخدام **Superscript** لتعيين درجة الرياضيات لعدد.

مثال:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **أسلوب Radical**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

يحدد الجذر الرياضي من الدرجة المحددة من العامل المحدد.

مثال:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **أساليب SetUpperLimit و SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

تأخذ الحدود العليا أو السفلى. هنا، تشير العليا والسفلى ببساطة إلى موقع العامل بالنسبة للقاعدة.

دعونا نعتبر تعبيرًا: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات من خلال مجموعة من الفئات [MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) و[MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit)، وعمليات [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) كما يلي:

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **أساليب Nary و Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

تخلق كلا من **nary** و**integral** وتُرجع المشغل N-ary الممثل بواسطة النوع [**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator). في أسلوب nary، يحدد التعداد [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) نوع العامل: التجميع، الاتحاد، إلخ، ولا تشمل التكامل. في أسلوب التكامل، هناك العملية المتخصصة التكامل مع تعداد أنواع التكامل [**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes). 

مثال:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **أسلوب toMathArray**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) يضع العناصر في مصفوفة عمودية. إذا تم استدعاء هذه العملية لفئة [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) ، ستوضع جميع العناصر الفرعية في المصفوفة المعادة.

مثال:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **عمليات التنسيق: Accent و Overbar و Underbar و Group و ToBorderBox و ToBox**
- تحدد دالة [**accent**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#accent-char-) علامة نبرة (حرف على الجزء العلوي من العنصر).
- تحدد دالتي [**overbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#overbar--) و [**underbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#underbar--) شريطًا على الجزء العلوي أو السفلي.
- تحدد دالة [**group**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#group--) مجموعة باستخدام حرف التجميع مثل القوس السفلي المتعرج أو آخر.
- تحدد دالة [**toBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBorderBox--) مجموعة في إطار حدود.
- تحدد دالة [**toBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBox--) مجموعة داخل مربع غير مرئي (تجميع منطقي).

أمثلة:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 