---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية باستخدام PHP
linktitle: معادلات رياضية لبرنامج PowerPoint
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
description: "إدراج وتحرير المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides للـ PHP عبر Java، مع دعم OMML، أدوات تنسيق، وأمثلة شفرة واضحة."
---

## **نظرة عامة**
في PowerPoint، من الممكن كتابة معادلة رياضية أو صيغة وعرضها في العرض التقديمي. للقيام بذلك، يتم تمثيل رموز رياضية مختلفة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لهذا، يتم استخدام منشئ المعادلات الرياضية في PowerPoint، والذي يساعد على إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- حدود ودوال اللوغاريتم
- عمليات n-ary
- مصفوفة
- عامل كبير
- دوال الجيب والجيب التمام

لإضافة معادلة رياضية في PowerPoint، يتم استخدام قائمة *Insert -> Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيؤدي هذا إلى إنشاء نص رياضي بصيغة XML يمكن عرضه في PowerPoint كالتالي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint عددًا كبيرًا من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، غالبًا ما لا ينتج عن إنشاء معادلات رياضية معقدة في PowerPoint نتيجة جيدة ومظهرًا احترافيًا. المستخدمون الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر يلجؤون إلى حلول الطرف الثالث لإنشاء صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/)، يمكنك العمل مع المعادلات الرياضية في عروض PowerPoint برمجيًا في C#. أنشئ تعبيرات رياضية جديدة أو حرّر تلك التي تم إنشاؤها مسبقًا. كما أن تصدير الهياكل الرياضية إلى صور مدعوم جزئيًا.

## **كيفية إنشاء معادلة رياضية**
تُستخدم العناصر الرياضية لبناء أي بنية رياضية مع أي مستوى من التعشيق. تشكّل مجموعة خطية من العناصر الرياضية كتلة رياضية يُمثِّلها صفّ [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). صفّ [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) هو أساسًا تعبيرًا رياضيًا منفصلًا أو صيغة أو معادلة. صفّ [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) هو جزء رياضي يُستخدم لحمل النص الرياضي (لا تخلطه مع [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). صفّ [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) يتيح التعامل مع مجموعة من كتل الرياضيات. الفئات المذكورة أعلاه هي المفتاح للعمل مع معادلات PowerPoint الرياضية عبر Aspose.Slides API.

دعونا نرى كيف يمكن إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

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


بعد الإنشاء، سيحتوي الشكل مسبقًا على فقرة واحدة مع جزء رياضي بشكل افتراضي. صفّ [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) هو جزء يحتوي على نص رياضي داخله. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion)، راجع متغيّر [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph):
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

The [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) class allows to read, add, edit and delete math blocks ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)), that consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));

``` 

Each mathematical element is represented by some class that implements the [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) interface. This interface provides a lot of methods for easily creating mathematical expressions. You can create a fairly complex mathematical expression with a single line of code. For example, the Pythagorean theorem would look like this:

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));

``` 

Operations of the interface [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) are implemented in any type of element, including the [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

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
تتكوّن التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يُمثَّل تسلسل العناصر الرياضية بكتلة رياضية، وتشكّل حجج العناصر شجرة تعشيقية.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لتكوين كتلة رياضية. يمكن تضمين (تجميع) كل من هذه العناصر داخل عنصر آخر. بمعنى آخر، تُعد العناصر حاويات للآخرين، مكوّنةً بنية شجرية. أبسط نوع من العنصر هو الذي لا يحتوي على عناصر أخرى من النص الرياضي.

كل نوع من عناصر الرياضيات يُنفّذ [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) الواجهة، مما يتيح استخدام مجموعة مشتركة من عمليات الرياضيات على أنواع مختلفة من العناصر.

### **صفّ MathematicalText**
صفّ [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) يُمثِّل نصًا رياضيًا – العنصر الأساسي لجميع البنيات الرياضية. قد يُمثِّل النص الرياضي معاملات وعوامل، متغيّرات، وأي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐

### **صفّ MathFraction**
صفّ [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) يحدد كائن الكسر، المكوّن من البسط والمقام المفصولين بشريط الكسر. يمكن أن يكون شريط الكسر أفقيًا أو قطريًا حسب خصائص الكسر. يُستخدم كائن الكسر أيضًا لتمثيل دالة الـ stack التي تضع عنصرًا فوق آخر دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **صفّ MathRadical**
صفّ [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) يحدد دالة الجذر الرياضي، المكوّنة من القاعدة ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **صفّ MathFunction**
صفّ [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) يحدد دالة لمعطى. يحتوي على الخصائص: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) اسم الدالة و [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) معطى الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **صفّ MathNaryOperator**
صفّ [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) يحدد كائنًا رياضيًا N-ary، مثل الجمع والتكامل. يتكون من عامل، قاعدة (أو مُعامل)، ودرجات علوية وسفلية اختيارية. أمثلة على عوامل N-ary هي الجمع، الاتحاد، التقاطع، والتكامل.

هذا الصف لا يشمل عوامل بسيطة مثل الجمع أو الطرح؛ تمثَّل هذه العناصر بنص [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **صفّ MathLimit**
صفّ [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) يُنشئ حدًا علويًا أو سفليًا. يُحدد كائن الحد نصًا على الخط الأساسي ونصًا أصغر حجمًا أعلى أو أسفل ذلك مباشرة. لا يتضمن هذا العنصر كلمة “lim”، بل يتيح وضع النص أعلى أو أسفل التعبير. وبالتالي، يُنشأ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مزيج من [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) و [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) يُكتب على النحو التالي:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **صفوف MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

تحدد هذه الفئات مؤشرًا سفليًا أو عُلويًا. يمكنك ضبط المؤشر السفلي والعُلوي معًا على الجانب الأيسر أو الأيمن من المعطى، لكن يُدعم مؤشر سفلي أو عُلوي واحد فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) لتعيين درجة رياضية لعدد.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **صفّ MathMatrix**
صفّ [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) يحدد كائن المصفوفة، المكوّن من عناصر فرعية مرتّبة في صفوف وأعمدة. من المهم ملاحظة أن المصفوفات لا تحتوي على محددات مدمجة؛ لوضع المصفوفة بين أقواس يجب استخدام كائن المحدد [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter). يمكن استخدام حجج فارغة لإنشاء فراغات في المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **صفّ MathArray**
صفّ [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) يحدد مصفوفة عمودية من المعادلات أو أي كائنات رياضية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**
- صفّ [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox) : يرسم حدًا مستطيلاً أو شكلًا آخر حول [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).

  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- صفّ [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox) : يحدد صندوقًا منطقيًا للعنصر الرياضي. على سبيل المثال، يمكن أن يكون الصندوق محاكيًا للعامل مع أو بدون نقطة محاذاة، أو يحد من انقطاع السطر.

- صفّ [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter) : يحدد كائن المحدد، المكوّن من أحرف فتح وإغلاق (مثل الأقواس أو الأقواس المعقوفة أو الأقواس المربعة أو الشرطات العمودية)، وعناصر رياضية داخلية مفصولة بحرف محدد. أمثلة: (𝑥²); [𝑥²|𝑦²].

  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- صفّ [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent) : يحدد دالة التنوين، المكوّن من قاعدة وعلامة تركيبة.

  مثال: 𝑎́.

- صفّ [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar) : يحدد دالة الشريط، المكوّن من معامل قاعدة وشريط علوي أو سفلي.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- صفّ [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter) : يحدد رمز تجميع أعلى أو أسفل التعبير، عادة لتسليط الضوء على العلاقات بين العناصر.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**
كل عنصر رياضي وتعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) يطبق [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) الواجهة. يتيح لك ذلك استخدام عمليات على البنية الحالية وتكوين تعبيرات رياضية أكثر تعقيدًا. جميع العمليات لها مجموعتين من المعاملات: إما [**IMathElement**] أو string كحجج. تُنشأ كائنات [**MathematicalText**] ضمنيًا من السلاسل عند استخدام حجج نصية. تُدرج عمليات الرياضيات المتاحة في Aspose.Slides أدناه.

### **طريقة Join**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

ينضم عنصرًا رياضيًا ويكوّن كتلة رياضية. مثال:

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

يُنشئ كسرًا من النوع المحدد باستخدام هذا البسط والمقام المحدد. مثال:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **طريقة Enclose**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

يُحاط العنصر بأحرف محددة مثل الأقواس أو أي حرف آخر كإطار.

```php

``` 

مثال:

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **طريقة Function**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

يأخذ دالة لمعطى باستخدام الكائن الحالي كاسم الدالة.

```php

``` 

مثال:

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **طريقة AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

يأخذ الدالة المحددة باستخدام الكائن الحالي كمعطى. يمكنك:

- تحديد سلسلة كاسم الدالة مثل “cos”.
- اختيار قيمة من تعداد [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments)، مثال [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- اختيار كائن [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).

مثال:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 

### **طرق SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

يضبط المؤشر السفلي والعُلوي. يمكنك ضبط المؤشرين معًا على اليسار أو اليمين من المعطى، لكن يُدعم مؤشر سفلي أو عُلوي واحد فقط على الجانب الأيمن. يمكن أيضًا استخدام **Superscript** لتعيين درجة رياضية لعدد.

مثال:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **طريقة Radical**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

يحدد الجذر الرياضي للدرجة المعطاة من المعطى المحدد.

مثال:

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **طرق SetUpperLimit و SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

يأخذ حدًا علويًا أو سفليًا. هنا، يشير الحد العلوي والسفلي ببساطة إلى موضع المعطى بالنسبة للقاعدة.

دعنا نلاحظ التعبير:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات من خلال دمج صفّ [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) و [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) وعمليات [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) كما يلي:

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

تنشئ كل من طريقتي nary و integral كائن [**IMathNaryOperator**] وتعيده. في طريقة nary، يُحدد تعداد [**MathNaryOperatorTypes**] نوع العامل: جمع، اتحاد، إلخ، دون تضمين التكاملات. في طريقة integral، يُستخدم تعداد [**MathIntegralTypes**] لتحديد نوع التكامل.

مثال:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **طريقة ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) توضع العناصر في مصفوفة عمودية. إذا تم استدعاء هذه العملية على كائن [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)، فستُوضَع جميع العناصر الفرعية في المصفوفة المُرجعة.

مثال:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- طريقة [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-) تضيف علامة تنوين (حرف فوق العنصر).
- طريقتا [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--) و [**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--) تضيفان شريطًا علويًا أو سفليًا.
- طريقة [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--) تجمع العناصر باستخدام رمز تجميع مثل القوس المعقوف السفلي أو غيره.
- طريقة [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--) توضع العنصر في صندوق حد.
- طريقة [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--) توضع العنصر في صندوق منطقي غير مرئي.

أمثلة:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **الأسئلة المتداولة**

**كيف يمكن إضافة معادلة رياضية إلى شريحة PowerPoint؟**

لإضافة معادلة رياضية، تحتاج إلى إنشاء كائن شكل رياضي يحتوي تلقائيًا على جزء رياضي. ثم تسترجع [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) وتضيف كائنات [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) إليها.

**هل يمكن إنشاء تعبيرات رياضية متداخلة معقدة؟**

نعم، يتيح Aspose.Slides إنشاء تعبيرات رياضية معقدة عبر تعشيق MathBlocks. كل عنصر رياضي يتيح تطبيق عمليات (Join، Divide، Enclose، إلخ) لدمج العناصر في بنى أكثر تعقيدًا.

**كيف يمكن تحديث أو تعديل معادلة رياضية موجودة؟**

لتحديث معادلة، تحتاج إلى الوصول إلى MathBlocks الموجودة عبر [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). ثم باستخدام طرق مثل Join، Divide، Enclose، وغيرها، يمكنك تعديل عناصر المعادلة الفردية. بعد التحرير، احفظ العرض التقديمي لتطبيق التغييرات.