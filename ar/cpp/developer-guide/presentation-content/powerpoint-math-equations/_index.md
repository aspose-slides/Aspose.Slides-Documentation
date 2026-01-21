---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية في С++
linktitle: معادلات رياضية في PowerPoint
type: docs
weight: 80
url: /ar/cpp/powerpoint-math-equations/
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
- С++
- Aspose.Slides
description: "إدراج وتحرير المعادلات الرياضية في PowerPoint PPT و PPTX باستخدام Aspose.Slides للغة С++، مع دعم OMML، والتحكم في التنسيق، وعينات شفرة С++ واضحة."
---

## **نظرة عامة**
في PowerPoint، يمكن كتابة معادلة أو صيغة رياضية وعرضها في العرض التقديمي. لتحقيق ذلك، يتم تمثيل رموز رياضية مختلفة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لهذا يستخدم مُنشئ المعادلات الرياضية في PowerPoint، والذي يساعد على إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذر رياضي
- دالة رياضية
- الحدود والدوال اللوغاريتمية
- عمليات N-ary
- مصفوفة
- عوامل كبيرة
- دوال Sin, cos

لإضافة معادلة رياضية في PowerPoint، يتم استخدام قائمة *Insert -> Equation* :

![todo:image_alt_text](powerpoint-math-equations_1.png)

سوف ينشئ هذا نصًا رياضيًا بصيغة XML يمكن عرضه في PowerPoint كما يلي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint العديد من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، غالبًا ما لا ينتج عن إنشاء معادلات رياضية معقدة في PowerPoint نتيجة جيدة ومظهر احترافي. يلجأ المستخدمون الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر إلى حلول طرف ثالث للحصول على صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/)، يمكنك التعامل مع المعادلات الرياضية في عروض PowerPoint برمجياً بلغة C++. أنشئ تعبيرات رياضية جديدة أو عدل ما تم إنشاؤه مسبقًا. كما أن تصدير الهياكل الرياضية إلى صور مدعوم جزئيًا.

## **كيفية إنشاء معادلة رياضية**
تُستخدم العناصر الرياضية لبناء أي تركيبة رياضية مع أي مستوى من التعشيق. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية يتم تمثيلها بواسطة فئة [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/). فئة [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) هي أساسًا تعبيرًا رياضيًا منفصلًا أو صيغة أو معادلة. فئة [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) هي جزء رياضي يستخدم لحفظ النص الرياضي (لا تخلطها مع [**Portion**](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)). فئة [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) تسمح بالتعامل مع مجموعة من كتل الرياضيات. الفئات المذكورة أعلاه هي المفتاح للعمل مع معادلات PowerPoint الرياضية عبر Aspose.Slides API.

دعنا نرى كيف يمكن إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي على الشريحة، أضف أولاً شكلًا سيحتوي على النص الرياضي:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

بعد الإنشاء، سيحتوي الشكل بالفعل على فقرة واحدة بها جزء رياضي بشكل افتراضي. فئة [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) هي جزء يحتوي على نص رياضي داخل. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/)، استخدم متغيّر [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/):

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

تسمح فئة [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) بقراءة، إضافة، تعديل وحذف كتل الرياضيات ([**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/))، التي تتكون من مجموعة من العناصر الرياضية. على سبيل المثال، أنشئ كسرًا وضعه في العرض التقديمي:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

كل عنصر رياضي يُمثَّل بفئة تطبيق [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) . توفر هذه الواجهة العديد من الطرق لإنشاء تعبيرات رياضية بسهولة. يمكنك إنشاء تعبير رياضي معقد بخط واحد. على سبيل المثال، تبدو نظرية فيثاغورس هكذا:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 

يُطبق عمليات الواجهة [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) على أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/).

الكود الكامل:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
mathParagraph->Add(mathBlock);

pres->Save(u"math.pptx", SaveFormat::Pptx);
``` 

## **أنواع العناصر الرياضية**
تُكوَّن التعبيرات الرياضية من سلاسل من العناصر الرياضية. تمثل سلسلة العناصر الرياضية كتلة رياضية، وتُكوِّن معاملات العناصر الرياضية شجرة متداخلة.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لإنشاء كتلة رياضية. كل عنصر يمكن تضمينه داخل عنصر آخر، أي أن العناصر هي في الواقع حاويات لتكوين بنية شجرية. أبسط نوع هو العنصر الذي لا يحتوي على عناصر أخرى من النص الرياضي.

كل نوع من العناصر الرياضية يطبق الواجهة [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) مما يسمح باستخدام مجموعة مشتركة من العمليات الرياضية على أنواع مختلفة.

### **فئة MathematicalText**
فئة [**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) تمثل نصًا رياضيًا – العنصر الأساسي لكل التركيبات الرياضية. قد يمثل النص الرياضي عوامل، مشغلات، متغيرات، أو أي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐

### **فئة MathFraction**
فئة [**MathFraction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfraction/) تُحدد كائن الكسر، المكوَّن من البسط والمقام مفصولين بشريط كسر. يمكن أن يكون الشريط أفقيًا أو قطريًا حسب خصائص الكسر. يُستخدم كائن الكسر أيضًا لتمثيل دالة الستاك التي تضع عنصرًا فوق آخر بدون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **فئة MathRadical**
فئة [**MathRadical**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathradical/) تُحدد الدالة الجذرية (الجدري)، المكوَّنة من القاعدة ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **فئة MathFunction**
فئة [**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) تُحدد دالة لها وسيط. تحتوي على طريقتين: [get_Name()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_name/) – اسم الدالة و [get_Base()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_base/) – وسيط الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **فئة MathNaryOperator**
فئة [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperator/) تُحدد كائنًا رياضيًا N-ary مثل المجموع والتكامل. يتكون من مشغل، قاعدة (أو عامل)، وحدود علوية وسفلية اختيارية. أمثلة على المشغلات N-ary: Summation, Union, Intersection, Integral.

هذه الفئة لا تشمل المشغلات البسيطة مثل الجمع والطرح؛ فهي تُمثل بنص [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **فئة MathLimit**
فئة [**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) تُنشئ حدًا علويًا أو سفليًا. تُحدد كائن الحد بنص على الخط الأساسي ونص أصغر حجمًا فوقه أو تحته. لا تشمل هذه العنصر كلمة “lim”، لكنها تسمح بوضع النص أعلى أو أسفل التعبير.

مثال يُظهر باستخدام مزيج من [**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) و [**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/):

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **فئات MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

تحدد الفئات التالية مؤشرًا سفليًا أو علويًا. يمكنك تعيين كل من الفهرس السفلي والعلوي في الوقت نفسه على اليسار أو اليمين، بينما يُدعم الفهرس الفردي فقط على اليمين. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/) لتعيين درجة عددية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **فئة MathMatrix**
فئة [**MathMatrix**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/) تُحدد كائن المصفوفة، المكوَّن من عناصر فرعية مرتبة في صفوف وأعمدة. لا تحتوي المصفوفات على محددات مدمجة؛ لذا يجب استخدام كائن المحدد [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathdelimiter/) لوضع المصفوفة بين أقواس. يمكن استخدام معاملات null لإنشاء فراغات داخل المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **فئة MathArray**
فئة [**MathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/matharray/) تُحدد مجموعة رأسية من المعادلات أو أي كائنات رياضية أخرى.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**
- فئة [**MathBorderBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathborderbox/) ترسم حدودًا مستطيلة أو شكلًا آخر حول [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/).  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [**MathBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbox/) تحدد تجميعًا منطقيًا للعنصر الرياضي. على سبيل المثال، يمكن استخدام كائن مُغلق كمحاكٍ للمشغل مع أو بدون نقطة محاذاة، أو لتحديد عدم السماح بانكسارات الأسطر داخل التجميع.

- فئة [**MathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathdelimiter/) تحدد كائن المحدد، المكوَّن من أحرف افتتاحية وإغلاقية (مثل الأقواس أو الأقواس المعقوفة أو الأقواس المربعة أو الشرطيات الرأسية) وعنصر أو أكثر داخلها.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [**MathAccent**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathaccent/) تحدد دالة الـ accent، المكوَّنة من قاعدة وعلامة تشكيلية مدمجة.  
  مثال: 𝑎́.

- فئة [**MathBar**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbar/) تحدد دالة الـ bar، المكوَّنة من وسيط أساسي وشريط علوي أو سفلي.  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathgroupingcharacter/) تحدد رمز تجميع فوق أو أسفل التعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **عمليات رياضية**
كل عنصر رياضي وتعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)) يطبق الواجهة [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/). يتيح ذلك استخدام عمليات على الهيكل الحالي وتكوين تعبيرات رياضية أكثر تعقيدًا. لكل عملية مجموعتان من المعاملات: إما [**IMathElement**] أو String. تُنشأ كائنات [**MathematicalText**] ضمنيًا من السلاسل النصية عند استخدام سلاسل كمعاملات. تُدرج عمليات الرياضيات المتاحة في Aspose.Slides أدناه.

### **طريقة Join**
- [Join(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemstring-method)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemsharedptrimathelement-method)

تدمج عنصرًا رياضيًا وتكوِّن كتلة رياضية. مثال:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 

### **طريقة Divide**
- [Divide(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-method)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-method)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-mathfractiontypes-method)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-mathfractiontypes-method)

ينشئ كسرًا من النوع المحدد باستخدام هذا البسط والمقام المحدد. مثال:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **طريقة Enclose**
- [Enclose()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclose-method)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclosechar16_t-char16_t-method)

تُحاط العنصر بأحرف محددة مثل الأقواس أو أي حرف آخر كإطار.

``` cpp
/// <summary>
/// Encloses a math element in parenthesis
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Encloses this element in specified characters such as parenthesis or another characters as framing
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

مثال:

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **طريقة Function**
- [Function(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemstring-method)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemsharedptrimathelement-method)

تأخذ دالة ذات وسيط باستخدام الكائن الحالي كاسم الدالة.

``` cpp
/// <summary>
/// Takes a function of an argument using this instance as the function name
/// </summary>
/// <param name="functionArgument">An argument of the function</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 

مثال:

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 

### **طريقة AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemstring-method)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsofoneargument-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemstring-method)

تأخذ الدالة المحددة باستخدام الكائن الحالي كوسيط. يمكنك:

- تحديد سلسلة كاسم الدالة، مثال “cos”.
- اختيار إحدى القيم المعرفة مسبقًا في تعداد [**MathFunctionsOfOneArgument**] أو [**MathFunctionsOfTwoArguments**]، مثال **MathFunctionsOfOneArgument.ArcSin**.
- اختيار كائن [**IMathElement**].

مثال:

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 

### **طرق SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemstring-method)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemsharedptrimathelement-method)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemstring-method)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemsharedptrimathelement-systemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemsharedptrimathelement-systemsharedptrimathelement-method)

تحدد الفهارس السفلية والعليا. يمكنك تعيين الفهرس السفلي والعلوي معًا على اليمين أو اليسار، بينما يُدعم الفهرس الوحيد فقط على اليمين. يمكن أيضًا استخدام Superscript لتعيين درجة عددية.

مثال:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **طريقة Radical**
- [Radical(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemstring-method)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemsharedptrimathelement-method)

تحدد جذرًا رياضيًا من الدرجة المحددة للوسيط المعيَّن.

مثال:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **طرق SetUpperLimit و SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemstring-method)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemsharedptrimathelement-method)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemstring-method)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemsharedptrimathelement-method)

تُحدد حدًا علويًا أو سفليًا. يشير الحد العلوي والسفلي ببساطة إلى موقع الوسيط بالنسبة للقاعدة.

مثال تعبيري:

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 

### **طرق Nary و Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-mathlimitlocations-method)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-mathlimitlocations-method)

كلا الطريقتين Nary و Integral تنشئ وتعيد مشغلًا N-ary مُمثَّلًا بنوع [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathnaryoperator/). في طريقة Nary، يحدد تعداد [**MathNaryOperatorTypes**] نوع المشغل: جمع، اتحاد، إلخ، ولا تشمل التكاملات. في طريقة Integral، يُستخدم تعداد [**MathIntegralTypes**] لتحديد نوع التكامل.

مثال:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **طريقة ToMathArray**
تضع العناصر في مصفوفة رأسية. إذا استُدعِيت لهذه الطريقة على كائن MathBlock، فستُوضع جميع العناصر الفرعية في المصفوفة المرجعة.

مثال:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **عمليات تنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- طريقة [**Accent**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/accent/) تضيف علامة تشديد (حرف فوق العنصر).
- طريقة [**Overbar**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/overbar/) و [**Underbar**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/underbar/) تضيف شريطًا أعلى أو أسفل العنصر.
- طريقة [**Group**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/group/) تجمع العنصر باستخدام رمز تجميع مثل القوس المعقوف السفلي أو غيره.
- طريقة [**ToBorderBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/toborderbox/) توضع العنصر في صندوق حدود.
- طريقة [**ToBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tobox/) توضع العنصر في صندوق منطقي غير مرئي.

أمثلة:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **الأسئلة المتكررة**

**كيف يمكن إضافة معادلة رياضية إلى شريحة PowerPoint؟**

لإضافة معادلة رياضية، تحتاج إلى إنشاء كائن شكل رياضي، والذي يحتوي تلقائيًا على جزء رياضي. ثم تستخرج [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) وتضيف كائنات [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) إلىه.

**هل يمكن إنشاء تعبيرات رياضية معقدة متداخلة؟**

نعم، تسمح Aspose.Slides بإنشاء تعبيرات رياضية معقدة عن طريق تعشيق MathBlocks. كل عنصر رياضي يطبق واجهة [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) التي تتيح تطبيق عمليات (Join, Divide, Enclose, …) لتكوين هياكل أكثر تعقيدًا.

**كيف يمكن تحديث أو تعديل معادلة رياضية موجودة؟**

لتحديث معادلة، يمكنك الوصول إلى MathBlocks ال vorhandenen [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/). بعد ذلك، باستخدام طرق مثل Join, Divide, Enclose وغيرها، يمكنك تعديل عناصر المعادلة. بعد التعديل، احفظ العرض التقديمي لتطبيق التغييرات.