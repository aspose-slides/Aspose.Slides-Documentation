---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية في PHP
linktitle: معادلات PowerPoint الرياضية
type: docs
weight: 80
url: /ar/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "إدراج وتحرير المعادلات الرياضية في PowerPoint بصيغ PPT و PPTX باستخدام Aspose.Slides للـ PHP عبر Java، مع دعم OMML، أدوات تنسيق، وعينات شفرة واضحة."
---

## **نظرة عامة**
في PowerPoint، يمكن كتابة معادلة أو صيغة رياضية وعرضها في العرض التقديمي. للقيام بذلك، يتم تمثيل رموز رياضية مختلفة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لاستخدام ذلك، يتم الاعتماد على مُنشئ المعادلات الرياضية في PowerPoint، الذي يساعد في إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- حدود ودوال اللوغاريتم
- عمليات N-ary
- مصفوفة
- عوامل كبيرة
- دوال الجيب والجيب التمام

لإضافة معادلة رياضية في PowerPoint، يتم استخدام قائمة *Insert->Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيؤدي ذلك إلى إنشاء نص رياضي بصيغة XML يمكن عرضه في PowerPoint كما يلي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint عددًا كبيرًا من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، فإن إنشاء معادلات رياضية معقدة في PowerPoint غالبًا لا ينتج عنه مظهر جيد ومهني. المستخدمون الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر يلجؤون إلى حلول الطرف الثالث للحصول على صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/)، يمكنك العمل مع المعادلات الرياضية في عروض PowerPoint برمجيًا بلغة C#. إنشاء تعابير رياضية جديدة أو تعديل التعابير الموجودة. كما يتم دعم تصدير البُنى الرياضية إلى صور جزئيًا.

## **كيفية إنشاء معادلة رياضية**
تُستخدم العناصر الرياضية لبناء أي تركيبات رياضية مهما كان مستوى تعشيقها. تُشكِّل مجموعة خطية من العناصر الرياضية كتلة رياضية تمثلها الفئة [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). فئة [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) هي في الأساس تعبير رياضي منفصل أو صيغة أو معادلة. فئة [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) هي جزء رياضي يُستخدم لحمل النص الرياضي (لا تُخلط مع [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). فئة [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) تُتيح التعامل مع مجموعة من كتل الرياضيات. الفئات المذكورة أعلاه هي المفتاح للعمل مع معادلات PowerPoint الرياضية عبر Aspose.Slides API.

دعنا نرى كيف يمكننا إنشاء المعادلة الرياضية التالية باستخدام Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، أولاً أضف شكلًا سيحتوي على النص الرياضي:
```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


بعد الإنشاء، سيحتوي الشكل تلقائيًا على فقرة واحدة مع جزء رياضي بصورة افتراضية. فئة [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) هي الجزء الذي يحتوي على النص الرياضي. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion)، راجع المتغيّر [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph):
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
``` 

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));
``` 

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
``` 

```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $fraction = new MathematicalText("x")->divide("y");
    $mathParagraph->add(new MathBlock($fraction));
    $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
    $mathParagraph->add($mathBlock);
    $pres->save("math.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **أنواع العناصر الرياضية**
تُشكل التعابير الرياضية من سلسلة من العناصر الرياضية. تُمثَّل سلسلة العناصر الرياضية بكتلة رياضية، وتكوّن وسائط العناصر شجرة تعشيق.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. كل من هذه العناصر يمكن تضمينه (تجميعه) داخل عنصر آخر. أي أن العناصر في الأساس حاويات لعناصر أخرى، مُشكِّلةً بنية شجرية. أبسط نوع من العناصر هو ذلك الذي لا يحتوي على عناصر نصية رياضية أخرى.

كل نوع من عناصر الرياضيات يُطبق فئة `MathElement`، مما يسمح باستخدام مجموعة مشتركة من عمليات الرياضيات على أنواع مختلفة من العناصر.

### **فئة MathematicalText**
تمثل فئة [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) نصًا رياضيًا — العنصر الأساسي لجميع التركيبات الرياضية. يمكن أن يمثل النص الرياضي المعاملات والمشغلات والمتغيّرات وأي نص خطّي آخر.

مثال: 𝑎=𝑏+𝑐

### **فئة MathFraction**
فئة [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) تُحدد كائن الكسر، المكوّن من البسط والمقام مفصولين بشريط الكسر. يمكن أن يكون شريط الكسر أفقيًا أو مائلًا، حسب خصائص الكسر. يُستخدم كائن الكسر أيضًا لتمثيل دالة الرفّ، التي تضع عنصرًا فوق آخر دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **فئة MathRadical**
فئة [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) تُحدد الدالة الجذرية (الجذر الرياضي)، المكوّنة من قاعدة وجذر اختياري.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **فئة MathFunction**
فئة [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) تُحدد دالة ذات معامل. تحتوي على الخصائص: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) — اسم الدالة و[getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) — معامل الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **فئة MathNaryOperator**
فئة [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) تُحدد كائنًا رياضيًا N-ary مثل الجمع والتكامل. يتكوّن من مشغل، قاعدة (أو معامل)، وحدود علوية وسفلية اختيارية. أمثلة على المشغلات N-ary هي الجمع، الاتحاد، التقاطع، والتكامل.

هذه الفئة لا تشمل المشغلات البسيطة مثل الجمع أو الطرح؛ يتم تمثيلها بعنصر نصّي واحد — [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **فئة MathLimit**
فئة [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) تُنشئ حدًا علويًا أو سفليًا. تُحدد كائن الحد بنص على الخط الأساسي ونص مصغّر إما فوقه أو تحته. لا يتضمن هذا العنصر كلمة “lim”، لكنه يتيح وضع النص في أعلى أو أسفل التعبير. لذا يُنشأ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مزيج من [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) و[**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) كما في المثال التالي:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **فئات MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

تُحدِّد الفئات السابقة موضع الفهرس السفلي أو العلوي. يمكنك تعيين كل من الفهرس السفلي والعلوي في آن واحد على الجانب الأيسر أو الأيمن للمعامل، لكن يُدعم الفهرس الواحد (سوّاء سفلي أو علوي) على الجانب الأيمن فقط. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) لضبط درجة الجذر الرياضي للعدد.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **فئة MathMatrix**
فئة [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) تُحدد كائن المصفوفة، المكوّن من عناصر فرعية مرتبة في صفوف وأعمدة. من المهم ملاحظة أن المصفوفات لا تحتوي على محددات مدمجة. لوضع المصفوفة بين أقواس، يجب استخدام كائن المحدد — [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/). يمكن استخدام الوسائط الفارغة لإنشاء فراغات داخل المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **فئة MathArray**
فئة [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) تُحدد مصفوفة رأسية من المعادلات أو أي كائنات رياضية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**
- فئة [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox): تُرسم حدًا مستطيلاً أو شكلًا آخر حول `MathElement`.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox): تُحدِّد تغليفًا منطقيًا للعنصر الرياضي. على سبيل المثال، يمكن أن يُستخدم الصندوق كمعوض للمشغل مع أو بدون نقطة محاذاة، أو لتحديد نقطة كسر سطر، أو لتجميعه بحيث لا يُسمح بكسر السطر داخله. مثال، يجب تغليف المشغل “==” لمنع كسر السطر.
- فئة [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter): تُحدِّد كائن المحدد، المكوّن من حروف افتتاحية وإغلاقية (مثل الأقواس، الأقواس المعقوفة، القوسين المربعات، أو الشرطيات العمودية)، وعنصر أو أكثر داخلها مفصولين بحرف محدد. أمثلة: (𝑥2); [𝑥2|𝑦2].

  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent): تُحدِّد دالة اللكنة، المكوّنة من قاعدة وعلامة صرفية مُدمجة.

  مثال: 𝑎́.

- فئة [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar): تُحدِّد دالة الشريط، المكوّنة من معامل أساسي وشريط فوق أو تحت.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter): تُحدِّد رمز تجميع فوق أو تحت التعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**
كل عنصر أو تعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) يرث فئة `MathElement`. يسمح ذلك باستخدام عمليات على البنية الحالية وتكوين تعابير رياضية أكثر تعقيدًا. جميع العمليات تتقبل مجموعتين من المعاملات: إما `MathElement` أو سلسلة نصية. تُنشَأ مثيلات فئة [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) ضمنيًا من السلاسل النصية عند استخدامها كمعاملات. تُدرج عمليات الرياضيات المتاحة في Aspose.Slides أدناه.

### **طريقة Join**
- `join(String)`
- `join(MathElement)`

تنضم عنصرًا رياضيًا وتشكل كتلة رياضية. مثال:

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 

### **طريقة Divide**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

تنشئ كسرًا من النوع المحدد باستخدام هذا البسط والمقام المحدد. مثال:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **طريقة Enclose**
- `enclose()`
- `enclose(Char, Char)`

تحيط العنصر بحروف محددة مثل الأقواس أو أي حرف آخر كإطار.

```php

``` 

مثال:

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **طريقة Function**
- `function(String)`
- `function(MathElement)`

تُنشئ دالة لمعامل باستخدام الكائن الحالي كاسم للدالة.

```php

``` 

مثال:

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **طريقة AsArgumentOfFunction**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

تُعيّن الدالة المحددة باستخدام المثيل الحالي كمعامل. يمكنك:

- تحديد سلسلة كاسم للدالة، مثل “cos”.
- اختيار إحدى القيم المُعرّفة مسبقًا في تعداد [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments)، مثل [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- اختيار مثيل `MathElement`.

مثال:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 

### **طرق SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

تُعيّن الفهرس السفلي والعلوي. يمكنك تعيين الفهرس السفلي والعلوي معًا على اليمين أو اليسار، لكن الفهرس المفرد يُدعم فقط على اليمين. يمكن أيضًا استخدام الـ **Superscript** لتعيين درجة عدد رياضية.

مثال:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **طريقة Radical**
- `radical(String)`
- `radical(MathElement)`

تُحدِّد الجذر الرياضي للدرجة المعطاة من المعامل المحدد.

مثال:

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **طرق SetUpperLimit و SetLowerLimit**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

تُعيّن الحد العلوي أو السفلي. هنا، يُشير الحد العلوي والسفلي إلى موضع المعامل بالنسبة للقاعدة.

لننظر إلى التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعابير عبر الجمع بين فئتي [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) و[MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) والعمليات على `MathElement` كما يلي:

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **طرق Nary و Integral**
- `nary(MathNaryOperatorTypes, MathElement, MathElement`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

تُنشئ كلًّا من طريقتي **nary** و **integral** وتُعيد كائن المشغل N-ary المُمَثَّل بالفئة [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator). في طريقة nary، يُحدِّد تعداد [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) نوع المشغل: جمع، اتحاد، إلخ، ولا تشمل التكاملات. في طريقة Integral، توجد عملية متخصصة للتكامل باستخدام تعداد أنواع التكامل [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes).

مثال:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **طريقة ToMathArray**
`MathElement.toMathArray` تضع العناصر في مصفوفة رأسية. إذا تم استدعاء هذه العملية على مثيل [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)، فستُوضع جميع العناصر الفرعية في المصفوفة المُعيدَة.

مثال:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- طريقة **`accent`** تُضيف علامة إكسنت على العنصر.
- طريقتا **`overbar`** و **`underbar`** تُضيفان شريطًا أعلى أو أسفل العنصر.
- طريقة **`group`** تُضع العنصر في مجموعة باستخدام رمز تجميع مثل القوس المائل السفلي أو غيره.
- طريقة **`toBorderBox`** تُضع العنصر في حدّ مربع.
- طريقة **`toBox`** تُضع العنصر في صندوق غير مرئي (تجميع منطقي).

أمثلة:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **الأسئلة الشائعة**

**كيف يمكنني إضافة معادلة رياضية إلى شريحة PowerPoint؟**

لإضافة معادلة رياضية، عليك إنشاء كائن شكل رياضي، والذي يحتوي تلقائيًا على جزء رياضي. بعد ذلك، استرجع [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) وأضف كائنات [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) إليه.

**هل يمكن إنشاء تعابير رياضية مُعقَّدة متشابكة؟**

نعم، يسمح Aspose.Slides بإنشاء تعابير رياضية معقدة عبر تعشيق MathBlocks. كل عنصر رياضي يتيح لك تطبيق عمليات (Join, Divide, Enclose, ...) لدمج العناصر في هياكل أكثر تعقيدًا.

**كيف يمكنني تحديث أو تعديل معادلة رياضية موجودة؟**

لتحديث المعادلة، عليك الوصول إلى MathBlocks الحالية عبر [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). ثم باستخدام طرق مثل Join, Divide, Enclose وغيرها، يمكنك تعديل عناصر المعادلة الفردية. بعد التعديل، احفظ العرض التقديمي لتطبيق التغييرات.