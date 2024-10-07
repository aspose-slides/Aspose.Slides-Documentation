---
title: معادلات الرياضيات في PowerPoint
type: docs
weight: 80
url: /php-java/powerpoint-math-equations/
keywords: "معادلات الرياضيات في PowerPoint, رموز الرياضيات في PowerPoint, صيغة PowerPoint, نص الرياضيات في PowerPoint"
description: "معادلات الرياضيات في PowerPoint, رموز الرياضيات في PowerPoint, صيغة PowerPoint, نص الرياضيات في PowerPoint"
---

## **نظرة عامة**
في PowerPoint، من الممكن كتابة معادلة رياضية أو صيغة وعرضها في العرض التقديمي. لتحقيق ذلك، تمثل مجموعة متنوعة من الرموز الرياضية في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لذلك، يتم استخدام مُنشئ المعادلات الرياضية في PowerPoint، الذي يساعد في إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- حدود ودوال اللوغاريتم
- عمليات N-ary
- مصفوفة
- مشغلات كبيرة
- دوال الجيب وجيب التمام

لإضافة معادلة رياضية في PowerPoint، يتم استخدام قائمة *إدراج -> معادلة*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سوف ينشئ هذا نص رياضي بتنسيق XML يمكن عرضه في PowerPoint كما يلي: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint الكثير من الرموز الرياضية لإنشاء معادلات رياضية. ومع ذلك، فإن إنشاء معادلات رياضية معقدة في PowerPoint غالباً لا يؤدي إلى نتائج جيدة ومهنية. يلجأ المستخدمون، الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر، إلى استخدام حلول من طرف ثالث لإنشاء صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/)، يمكنك العمل مع المعادلات الرياضية في عروض PowerPoint بشكل برمجي في C#. قم بإنشاء تعبيرات رياضية جديدة أو تحرير تلك التي تم إنشاؤها مسبقًا. كما يتم دعم تصدير الهياكل الرياضية إلى صور جزئيًا.

## **كيفية إنشاء معادلة رياضية**
تستخدم العناصر الرياضية لبناء أي إنشاءات رياضية بأي مستوى من التعشيق. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية ممثلة بواسطة فئة [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). تعتبر فئة [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) تعبيرًا رياضيًا منفصلًا أو صيغة أو معادلة. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) هي جزء رياضي، يُستخدم لحمل النص الرياضي (لا تخلط بينه وبين [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). تقوم فئة [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) بإتاحة التحكم في مجموعة من كتل الرياضيات. تعتبر الفئات المذكورة أعلاه مفتاحًا للعمل مع معادلات الرياضيات في PowerPoint عبرAspose.Slides API.

لنرى كيف يمكننا إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي على الشريحة، أولاً، أضف شكلًا سيحتوي على النص الرياضي:

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

بعد الإنشاء، سيحتوي الشكل بالفعل على فقرة واحدة مع جزء رياضي بشكل افتراضي. تسمح فئة [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) بالوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) بالرجوع إلى المتغير [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph):

```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

تسمح فئة [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) بقراءة وإضافة وتحرير وحذف كتل الرياضيات ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock))، والتي تتكون من مجموعة من العناصر الرياضية. على سبيل المثال، إنشاء كسر ووضعه في العرض التقديمي:

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));

``` 

يمثل كل عنصر رياضي فئة معينة تنفذ واجهة [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). توفر هذه الواجهة الكثير من الطرق لإنشاء التعبيرات الرياضية بسهولة. يمكنك إنشاء تعبير رياضي معقد نسبياً بسطر واحد من التعليمات البرمجية. على سبيل المثال، ستبدو نظرية فيثاغورس كالتالي:

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));

``` 

تُنفذ عمليات واجهة [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) في أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

نموذج التعليمات البرمجية بالكامل:

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
تتكون التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يمثل تسلسل العناصر الرياضية كتلة رياضية، وتشكل معاملات العناصر الرياضية تعشيقًا شبيهًا بالشجرة.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. يمكن تضمين كل من هذه العناصر (تجميعها) في عنصر آخر. أي أن العناصر هي في الواقع حاويات للآخرين، مما يشكل هيكلًا شبيهًا بالشجرة. أبسط نوع من العناصر هو الذي لا يحتوي على عناصر أخرى من النص الرياضي.

يتم تنفيذ كل نوع من عنصر الرياضيات لواجهة [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)، مما يسمح باستخدام مجموعة شائعة من عمليات الرياضيات على أنواع مختلفة من عناصر الرياضيات.
### **فئة MathematicalText**
تمثل فئة [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) نصًا رياضيًا - العنصر الأساسي لجميع الإنشاءات الرياضية. يمكن أن يمثل النص الرياضي العوامل والمشغلين والمتغيرات وأي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐
### **فئة MathFraction**
تمثل فئة [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) كائن الكسر، الذي يتكون من بسط ومقام مفصولين بواسطة شريط كسر. يمكن أن يكون شريط الكسر أفقيًا أو مائلًا، اعتمادًا على خصائص الكسر. يتم استخدام كائن الكسر أيضًا لتمثيل دالة التراص، التي تضع عنصرًا فوق عنصر آخر، دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **فئة MathRadical**
تمثل فئة [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) دالة جذر (جذر رياضي)، تتكون من قاعدة ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **فئة MathFunction**
تمثل فئة [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) دالة لمعامل. تحتوي على الخصائص: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) - اسم الدالة و[getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) - معامل الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **فئة MathNaryOperator**
تمثل فئة [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) كائن رياضي N-ary، مثل الجمع والتكامل. يتكون من مشغل وقاعدة (أو عامل)، وحدود علوية وسفلية اختيارية. تتضمن أمثلة مشغلات N-ary الجمع، الاتحاد، التقاطع، التكامل.

لا تشمل هذه الفئة المشغلين البسيطين مثل الجمع والطرح، وما إلى ذلك. يتم تمثيلها بواسطة عنصر نصي واحد - [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **فئة MathLimit**
تقوم فئة [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) بإنشاء الحد العلوي أو السفلي. تحدد كائن الحد، الذي يتكون من نص على الخط الأساسي ونص بحجم مخفض مباشرة فوقه أو تحته. لا تتضمن هذه العنصر كلمة "lim"، ولكنها تسمح بوضع نص في أعلى أو أسفل التعبير. لذا، فإن التعبير 

![todo:image_alt_text](powerpoint-math-equations_8.png)

يتم إنشاؤه باستخدام مجموعة من عناصر [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) و [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) بهذه الطريقة:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));

``` 


### **فئات MathSubscriptElement، MathSuperscriptElement، MathRightSubSuperscriptElement، MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

تحدد الفئات التالية مؤشرًا سفليًا أو علويًا. يمكنك ضبط التفريغ والكتابة العلوية في نفس الوقت على الجانب الأيسر أو الأيمن من المعامل، ولكن يتم دعم التفريغ أو الكتابة العلوية المفردة فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) لضبط الدرجة الرياضية لرقم.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **فئة MathMatrix**
تحدد فئة [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) كائن المصفوفة، الذي يتكون من عناصر فرعية مرتبة في صفوف وأعمدة. من المهم ملاحظة أن المصفوفات لا تحتوي على فواصل زمنية مدمجة. لوضع المصفوفة في الأقواس، يجب استخدام كائن الفاصل - [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter). يمكن استخدام معاملات فارغة لإنشاء فراغات في المصفوفات.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **فئة MathArray**
تحدد فئة [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) مصفوفة عمودية من المعادلات أو أي كائنات رياضية.

مثال: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **تنسيق العناصر الرياضية**
- فئة [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox): ترسم حدودًا مستطيلة أو أي حدود أخرى حول [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox): تحدد التعبئة المنطقية للعناصر الرياضية. على سبيل المثال، يمكن أن تكون الكائنات المعبأة بمثابة محاكي لمشغل مع أو بدون نقطة محاذاة، أو أن تكون نقطة انقطاع سطر، أو أن تكون مجمعة بحيث لا تسمح بانكسارات الأسطر. على سبيل المثال، يجب تعبئة مشغل "==" لمنع انكسارات الأسطر.
- فئة [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter): تحدد كائن الفاصل، الذي يتكون من أحرف فتح وإغلاق (مثل الأقواس، والأقواس، والأطراف، والأعمدة الرأسية)، وواحد أو أكثر من العناصر الرياضية داخلها، تفصلها حرف محدد. أمثلة: (𝑥2); [𝑥2|𝑦2].
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent): تحدد دالة التمييز، التي تتكون من قاعدة وعلامة تمييز مركبة.

  مثال: 𝑎́.

- فئة [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar): تحدد دالة الشريط، التي تتكون من معامل أساسي و شريط علوي أو سفلي.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter): تحدد رمز التجميع فوق أو تحت تعبير، عادة لتسليط الضوء على العلاقات بين العناصر.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **العمليات الرياضية**
كل عنصر رياضي وتعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) ينفذ واجهة [**IMathElement** ](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). يسمح لك باستخدام العمليات على الهيكل الموجود وتشكيل تعبيرات رياضية أكثر تعقيدًا. جميع العمليات لها مجموعتان من المعلمات: إما [**IMathElement** ](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) أو نص كمعاملات. يتم إنشاء مثيلات من فئة [**MathematicalText** ](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) بشكل ضمني من السلاسل المحددة عند استخدام معاملات نصية. العمليات الرياضية المتاحة في Aspose.Slides مدرجة أدناه.
### **طريقة Join**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

تنضم عنصر رياضي وتشكل كتلة رياضية. على سبيل المثال:

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);

``` 

### **طريقة Divide**
- [divide(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

تنشئ كسرًا من النوع المحدد مع هذا البسط والمقام المحدد. على سبيل المثال:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);

``` 

### **طريقة Enclose**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

تغلق العنصر في أحرف محددة مثل الأقواس أو حرف آخر كإطار.

```php

``` 


على سبيل المثال:

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();

``` 

### **طريقة Function**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

تأخذ دالة لمعامل باستخدام الكائن الحالي كاسم الدالة.

```php

``` 


على سبيل المثال:

```php
  $func = new MathematicalText("sin")->function("x");

``` 

### **طريقة AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

تأخذ الدالة المحددة باستخدام المثيل الحالي كحجة. يمكنك:

- تحديد سلسلة كاسم الدالة، على سبيل المثال "cos".
- اختيار إحدى القيم المعروفة من enumerations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments)، على سبيل المثال [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- اختيار مثيل من [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).

على سبيل المثال:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");

``` 

### **طرق SetSubscript، SetSuperscript، SetSubSuperscriptOnTheRight، SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

تضبط المفتاح السفلي والكتابة العلوية. يمكنك ضبط المفتاح السفلي والكتابة العلوية في نفس الوقت على الجانب الأيسر أو الأيمن من المعامل، ولكن يتم دعم المفتاح السفلي أو الكتابة العلوية المفردة فقط على الجانب الأيمن. يمكن أيضًا استخدام **Superscript** لضبط درجة رياضية لعدد.

مثال:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");

``` 

### **طريقة Radical**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

تحدد الجذر الرياضي من الدرجة المحددة من المعامل المحدد.

مثال:

```php
  $radical = new MathematicalText("x")->radical("3");

``` 

### **طرق SetUpperLimit و SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

تأخذ الحد العلوي أو السفلي. هنا، تشير الأعلى والأسفل ببساطة إلى موقع المعامل بالنسبة للقاعدة.

لننظر في تعبير: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات من خلال مجموعة من فئات [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) و [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) وعمليات [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) كما يلي:

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");

``` 

### **طرق Nary و Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

تقوم كل من **nary** و**integral** بإنشاء وإرجاع مشغل N-ary ممثل بنوع [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator). في طريقة nary، تحدد [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) نوع المشغل: الجمع، الاتحاد، إلخ، ولا تشمل التكاملات. في طريقة التكامل، هناك عملية متخصصة لتكامل مع تعداد أنواع التكامل [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes).

مثال:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");

``` 

### **طريقة toMathArray**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) تضع العناصر في مصفوفة رأسية. إذا تم استدعاء هذه العملية لمثيل [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)، سيتم وضع جميع العناصر الفرعية في المصفوفة المرجعة.

مثال:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();

``` 

### **عمليات التنسيق: Accent، Overbar، Underbar، Group، ToBorderBox، ToBox**
- تحدد طريقة [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-) علامة التمييز (حرف أعلى العنصر).
- تحدد طرق [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--) و [**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--) شريطًا أعلى أو أسفل.
- تحدد طريقة [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--) مكانًا في مجموعة باستخدام حرف تجميع مثل الأقواس السفلية المتعرجة أو غيرها.
- تحدد طريقة [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--) مكانًا في مربع الحدود.
- تحدد طريقة [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--) مكانًا في مربع غير مرئي (تجميع منطقي).

أمثلة:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();

``` 