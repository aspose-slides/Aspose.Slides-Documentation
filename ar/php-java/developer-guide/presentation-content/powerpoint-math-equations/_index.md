---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية باستخدام PHP
linktitle: معادلات رياضية في PowerPoint
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
description: "إدراج وتحرير المعادلات الرياضية في عروض PowerPoint PPT و PPTX باستخدام Aspose.Slides للـ PHP عبر Java، مع دعم OMML، التحكم في التنسيقات، وعينات شفرة واضحة."
---

## **نظرة عامة**
في PowerPoint، يمكن كتابة معادلة أو صيغة رياضية وعرضها في العرض التقديمي. للقيام بذلك، يتم تمثيل رموز رياضية مختلفة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لهذا، يتم استخدام منشئ المعادلات الرياضية في PowerPoint، والذي يساعد على إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- حدود ودوال اللوغاريتم
- عمليات n‑ary
- مصفوفة
- عاملات كبيرة
- دوال الجيب وجيب التمام

لإضافة معادلة رياضية في PowerPoint، يتم استخدام قائمة *Insert -> Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيؤدي ذلك إلى إنشاء نص رياضي بصيغة XML يمكن عرضه في PowerPoint كما يلي: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint الكثير من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، غالبًا ما لا ينتج عن إنشاء معادلات رياضية معقدة في PowerPoint نتيجة جيدة ومظهر احترافي. يلجأ المستخدمون الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر إلى حلول الطرف الثالث لإنتاج صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/)، يمكنك العمل مع المعادلات الرياضية في عروض PowerPoint برمجيًا بلغة C#. أنشئ تعبيرات رياضية جديدة أو حرّر تلك التي تم إنشاؤها مسبقًا. كما يتم دعم تصدير الهياكل الرياضية إلى صور جزئيًا.

## **كيفية إنشاء معادلة رياضية**
تُستخدم العناصر الرياضية لبناء أي تركيبات رياضية بأي مستوى من التعشيق. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية يتم تمثيلها بواسطة الفئة [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). الفئة [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) تمثل أساسًا تعبيرًا رياضيًا منفصلًا أو صيغة أو معادلة. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) هي جزء رياضي يُستخدم لحفظ النص الرياضي (لا تخلطه مع [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) تسمح بالتعامل مع مجموعة من كتل الرياضيات. الفئات المذكورة أعلاه هي المفتاح للعمل مع معادلات الرياضيات في PowerPoint عبر Aspose.Slides API.

دعنا نرى كيف يمكننا إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، أولاً أضف شكلاً سيحتوي على النص الرياضي:
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


بعد الإنشاء، سيحتوي الشكل بالفعل على فقرة واحدة مع جزء رياضي بشكل افتراضي. الفئة [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) هي جزء يحتوي على نص رياضي داخله. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion)، ارجع إلى متغيّر [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph):
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

The [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) class allows to read, add, edit and delete math blocks ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)), that consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));
``` 

Each mathematical element is represented by some class that implements the `MathElement` class. This class provides a lot of methods for easily creating mathematical expressions. You can create a fairly complex mathematical expression with a single line of code. For example, the Pythagorean theorem would look like this:

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
``` 

Operations of the class `MathElement` are implemented in any type of element, including the [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

The full source code sample:

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
تتشكل التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يُمثل تسلسل العناصر الرياضية كتلة رياضية، وتشكل حجج العناصر شجرة تعشيقية.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لإنشاء كتلة رياضية. يمكن تضمين كل عنصر داخل عنصر آخر. أي أن العناصر هي في الواقع حاويات لأخرى، مكوِّنةً بنية شجرية. أبسط نوع من العناصر لا يحتوي على عناصر أخرى من النص الرياضي.

كل نوع من عناصر الرياضيات يطبق الفئة `MathElement`، مما يتيح استخدام مجموعة مشتركة من عمليات الرياضيات على أنواع مختلفة من العناصر.

### **فئة MathematicalText**
الفئة [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) تمثل نصًا رياضيًا – العنصر الأساسي لجميع التركيبات الرياضية. قد يمثل النص الرياضي معاملات ومشغلات، متغيرات، وأي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐

### **فئة MathFraction**
الفئة [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) تحدد كائن الكسر، المكوّن من بسط ومقام مفصولين بشريط الكسر. يمكن أن يكون شريط الكسر أفقيًا أو مائلًا حسب خصائص الكسر. يُستخدم كائن الكسر أيضًا لتمثيل دالة المكدس، التي تضع عنصرًا فوق آخر بدون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **فئة MathRadical**
الفئة [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) تحدد دالة الجذر (الجذر الرياضي)، المكوّنة من قاعدة وجذر اختياري.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **فئة MathFunction**
الفئة [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) تحدد دالة ذات معامل. تحتوي على خصائص: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) – اسم الدالة و[getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) – معامل الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **فئة MathNaryOperator**
الفئة [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) تحدد كائنًا رياضيًا n‑ary، مثل الجمع والتكامل. يتكوّن من مشغّل، قاعدة (أو معامل)، وحدود علوية وسفلية اختيارية. أمثلة المشغلات n‑ary: الجمع، الاتحاد، التقاطع، التكامل.

هذه الفئة لا تشمل المشغلات البسيطة مثل الجمع والطرح؛ فهي ممثلة بعنصر نصي واحد – [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **فئة MathLimit**
الفئة [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) تُنشئ حدًا علويًا أو سفليًا. تحدد كائن الحد، المكوّن من نص على الخط الأساسي ونص أصغر حجماً فوقه أو أسفه مباشرة. لا يتضمن هذا العنصر كلمة “lim”، لكنه يسمح بوضع نص في أعلى أو أسفل التعبير. لذلك، التعبير  

![todo:image_alt_text](powerpoint-math-equations_8.png)

يُنشأ باستخدام مزيج من عناصر [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) و[**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) كالتالي:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **فئات MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

تحدد الفئات التالية مؤشرًا سفليًا أو علويًا. يمكنك تعيين كل من النص السفلي والعلوي في وقت واحد على اليمين أو اليسار، لكن يُدعم مؤشر واحد فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) لتحديد درجة رياضية لعدد.

مثال:  

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **فئة MathMatrix**
الفئة [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) تحدد كائن المصفوفة، المكوّن من عناصر فرعية مرتبة في صفوف وأعمدة. يجب مراعاة أن المصفوفات لا تملك محددات مدمجة. لوضع المصفوفة داخل أقواس، استخدم كائن المحدد – [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/). يمكن استخدام حجج فارغة لإنشاء فجوات في المصفوفات.

مثال:  

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **فئة MathArray**
الفئة [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) تحدد مصفوفة عمودية من المعادلات أو أي كائنات رياضية.

مثال:  

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**
- الفئة [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox): ترسم إطارًا مستطيلًا أو نوعًا آخر من الحدود حول `MathElement`.  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- الفئة [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox): تحدد تغليفًا منطقيًا (تعبئة) للعنصر الرياضي. على سبيل المثال، يمكن أن يعمل كائن معبَّأ كمحاكٍ للمشغل مع أو بدون نقطة محاذاة، أو كفاصل سطري، أو يُجمّع لتجنب فواصل الأسطر داخل التعبير.

- الفئة [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter): تحدد كائن المحدد، المكوّن من حروف افتتاحية وإغلاقية (مثل الأقواس، الأقواس المعقوفة، الأقواس المربعة، أو الخطوط العمودية)، وعناصر رياضية واحدة أو أكثر داخله، مفصولة بحرف محدد. أمثلة: (𝑥²); [𝑥²|𝑦²].  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- الفئة [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent): تحدد دالة التشكيل، المكوّنة من قاعدة وعلامة تشكيلية مدمجة.  
  مثال: 𝑎́.

- الفئة [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar): تحدد دالة الشريط، المكوّنة من معلمة قاعدة وشريط علوي أو سفلي.  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- الفئة [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter): تحدد رمز تجميع فوق أو تحت التعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**
كل عنصر رياضي وتعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) يرث الفئة `MathElement`. يتيح لك ذلك استخدام عمليات على البنية الحالية وتشكيل تعبيرات رياضية أكثر تعقيدًا. جميع العمليات لديها مجموعتين من المعاملات: إما `MathElement` أو سلسلة نصية كوسائط. تُنشأ كائنات الفئة [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) ضمنيًا من السلاسل المحددة عندما تُستخدم سلاسل نصية كوسائط. تُدرج عمليات الرياضيات المتاحة في Aspose.Slides أدناه.

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

تحيط العنصر بأحرف محددة مثل القوسين أو حرف آخر كإطار.

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

تأخذ دالةً لمعامل باستخدام الكائن الحالي كاسم الدالة.

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

تأخذ الدالة المحددة باستخدام المثيل الحالي كمعامل. يمكنك:
- تحديد سلسلة كاسم الدالة، مثل “cos”.
- اختيار واحدة من القيم المسبقة التعريف في تعداد [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments)، مثل [**MathFunctionsOfOneArgument::ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- اختيار مثيل من `MathElement`.

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

تضبط المؤشر السفلي والعلوي. يمكنك ضبط كلاهما في نفس الوقت على اليسار أو اليمين، لكن يُدعم مؤشر واحد فقط على الجانب الأيمن. يمكن أيضًا استخدام **Superscript** لتحديد درجة رياضية لعدد.

مثال:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **طريقة Radical**
- `radical(String)`
- `radical(MathElement)`

تحدد الجذر الرياضي للدرجة المعطاة من المعامل المحدد.

مثال:

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **طرق SetUpperLimit و SetLowerLimit**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

تأخذ الحد العلوي أو السفلي. هنا، يشير الحد العلوي والسفلي ببساطة إلى موقع المعامل بالنسبة للقاعدة.

لننظر إلى تعبير:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات من خلال دمج فئات [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) و[MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) والعمليات على `MathElement` كما يلي:

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

كلا الطريقتين **nary** و**integral** تُنشئ وتُعيد المشغل n‑ary المُمَثَّل بنوع [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator). في طريقة nary، يحدد تعداد [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) نوع المشغل: جمع، اتحاد، إلخ، دون تضمين التكاملات. في طريقة Integral، يوجد عملية مخصصة للتكامل مع تعداد أنواع التكامل [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes).

مثال:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **طريقة ToMathArray**
`MathElement.toMathArray` تضع العناصر في مصفوفة عمودية. إذا تم استدعاء هذه العملية على مثيل من [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)، ستُوضَع جميع العناصر الفرعية في المصفوفة المرتجعة.

مثال:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- طريقة **`accent`** تضبط علامة تشكيل (حرف فوق العنصر).
- طريقتا **`overbar`** و**`underbar`** تضع شريطًا أعلى أو أسفل العنصر.
- طريقة **`group`** تضع العنصر في مجموعة باستخدام رمز تجميع مثل القوس المعقوف السفلي أو غيره.
- طريقة **`toBorderBox`** تضع العنصر في صندوق حد.
- طريقة **`toBox`** تضع العنصر في صندوق منطقي غير مرئي (تجميع منطقي).

أمثلة:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **الأسئلة المتكررة**

**كيف يمكنني إضافة معادلة رياضية إلى شريحة PowerPoint؟**

لإضافة معادلة رياضية، تحتاج إلى إنشاء كائن شكل رياضي، والذي يحتوي تلقائيًا على جزء رياضي. ثم تستخرج [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) وتضيف كائنات [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) إليه.

**هل من الممكن إنشاء تعبيرات رياضية متداخلة ومعقدة؟**

نعم، يتيح Aspose.Slides إنشاء تعبيرات رياضية معقدة عبر تعشيق MathBlocks. كل عنصر رياضي يسمح لك بتطبيق عمليات (Join, Divide, Enclose, إلخ) لدمج العناصر في هياكل أكثر تعقيدًا.

**كيف يمكنني تحديث أو تعديل معادلة رياضية موجودة؟**

لتحديث معادلة، تحتاج إلى الوصول إلى MathBlocks الحالية عبر [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). ثم باستخدام طرق مثل Join, Divide, Enclose وغيرها، يمكنك تعديل عناصر المعادلة الفردية. بعد التحرير، احفظ العرض التقديمي لتطبيق التغييرات.