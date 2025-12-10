---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية في С++
linktitle: معادلات رياضية PowerPoint
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
description: "إدراج وتحرير المعادلات الرياضية في PowerPoint PPT و PPTX باستخدام Aspose.Slides للـ С++، مع دعم OMML، وإجراءات تنسيق، وعينات شفرة C++ واضحة."
---

## **نظرة عامة**
في PowerPoint، يمكن كتابة معادلة أو صيغة رياضية وعرضها في العرض التقديمي. للقيام بذلك، تُمثَّل رموز حسابية مختلفة في PowerPoint ويمكن إضافتها إلى النص أو المعادلة. لهذا تُستَخدم أداة بناء المعادلات الرياضية في PowerPoint، التي تساعد على إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذــر رياضي
- دالة رياضية
- الحدود ووظائف اللوغاريتم
- عمليات N-ary
- مصفوفة
- عوامل كبيرة
- دوال جا sinus, cos

لإضافة معادلة رياضية في PowerPoint، يُستخدم القائمة *Insert->Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

سيتم إنشاء نص رياضي بصيغة XML يمكن عرضه في PowerPoint كما يلي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم PowerPoint عددًا كبيرًا من الرموز الرياضية لإنشاء المعادلات. ومع ذلك، فإن إنشاء معادلات رياضية معقدة في PowerPoint لا ينتج دائمًا نتائج مهنية وجذابة. المستخدمون الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر يلجؤون إلى حلول الطرف الثالث للحصول على صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/)، يمكنك العمل مع المعادلات الرياضية في عروض PowerPoint برمجيًا باستخدام C++. يمكنك إنشاء تعبيرات رياضية جديدة أو تعديل التعبيرات الموجودة. كما يتم دعم تصدير الهياكل الرياضية إلى صور جزئيًا.

## **كيفية إنشاء معادلة رياضية**
تُستخدم العناصر الرياضية لبناء أي تركيبات رياضية على أي مستوى من التداخل. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية تُمثَّل بواسطة فئة [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block). فئة [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block) هي في الأساس تعبير رياضي منفصل، صيغة أو معادلة. فئة [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) هي جزء رياضي يُستخدم لاحتواء النص الرياضي (لا تُخلط مع [**Portion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)). فئة [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) تسمح بالتعامل مع مجموعة من كتل الرياضيات. الفئات المذكورة أعلاه هي المفتاح للعمل مع معادلات PowerPoint الرياضية عبر Aspose.Slides API.

دعنا نرى كيف يمكن إنشاء المعادلة الرياضية التالية باستخدام Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي إلى الشريحة، أولًا أضف شكلًا سيحتوي على النص الرياضي:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

بعد الإنشاء، سيحتوي الشكل بالفعل على فقرة واحدة مع جزء رياضي افتراضيًا. فئة [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) هي جزء يحتوي على نص رياضي داخله. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion)، يُشار إلى متغيّر [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph):

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

تسمح فئة [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) بقراءة وإضافة وتعديل وحذف كتل الرياضيات ([**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)) التي تتكون من مجموعة من العناصر الرياضية. على سبيل المثال، لإنشاء كسر ووضعه في العرض:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

كل عنصر رياضي يُمثَّل بفئة تُنفِّذ واجهة [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element). توفر هذه الواجهة العديد من الطرق لإنشاء تعبيرات رياضية بسهولة. يمكنك إنشاء تعبير رياضي معقد باستخدام سطر واحد من الشيفرة. على سبيل المثال، مبرهنة فيثاغورث ستظهر هكذا:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 

تُطبَّق عمليات واجهة [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) على أي نوع من العناصر، بما فيها [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block).

الكود الكامل للمثال:

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
تُكوَّن التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يُمثَّل تسلسل العناصر الرياضية بكتلة رياضية، وتشكِّل حجج العناصر الرياضية شجرةً متداخلة.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لإنشاء كتلة رياضية. كل عنصر من هذه العناصر يمكن تضمينه داخل عنصر آخر. أي أن العناصر هي حاويات لأخرى، ما يُكوِّن بنية شجرية. أبسط نوع من العناصر هو الذي لا يحتوي على عناصر أخرى من النص الرياضي.

كل نوع من العناصر الرياضية يطبق واجهة [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)، مما يتيح استخدام مجموعة مشتركة من عمليات الرياضيات على أنواع مختلفة من العناصر.

### **فئة MathematicalText**
فئة [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) تمثِّل النص الرياضي - العنصر الأساسي لجميع التركيبات الرياضية. يمكن أن يمثل النص الرياضي معاملات ومؤثرات، متغيِّرات، أو أي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐

### **فئة MathFraction**
فئة [**MathFraction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction) تحدد كائن الكسر، المكوَّن من البسط والمقام مفصولين بشريط كسر. يمكن أن يكون شريط الكسر أفقيًا أو مائلًا حسب خصائص الكسر. يُستَخدم كائن الكسر أيضًا لتمثيل دالة المكدس، التي تضع عنصرًا فوق آخر دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **فئة MathRadical**
فئة [**MathRadular**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical) تحدد دالة الجذر (العددية)، المكوَّنة من قاعدة وجذر اختياري.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **فئة MathFunction**
فئة [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) تحدد دالة لوسيط. تحتوي على طريقتين: [get_Name()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a88b5a46342839d7ef1a8d273694bf0b3) – اسم الدالة و [get_Base()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a765fa6bcbeb9b48730dbcb6504d9b543) – وسيط الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **فئة MathNaryOperator**
فئة [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator) تحدد كائنًا رياضيًا N-ary، مثل الجمع المتسلسل (Summation) أو التكامل (Integral). يتكوّن من عامل، قاعدة (أو معامل)، وحدود علوية وسفلية اختيارية. لا تشمل هذه الفئة عوامل بسيطة مثل الجمع أو الطرح؛ فهذه تُمثَّل بعنصر نصي واحد – [MathematicalText](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **فئة MathLimit**
فئة [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) تُنشئ حدًا علويًا أو سفليًا. تحدد كائن الحد بنص على خط الأساس ونص أصغر حجماً فوقه أو أسفله مباشرة. لا تشمل العنصر كلمة “lim”، بل تسمح بوضع النص أعلاه أو أسفله. لذا يُنشأ التعبير التالي:

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مزيج من [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) و[**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) هكذا:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **فئات MathSubscriptElement و MathSuperscriptElement و MathRightSubSuperscriptElement و MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

الفئات التالية تحدد مؤشرًا سفليًا أو علويًا. يمكن تعيين كل من السُفْلِي والعُلوي في وقتٍ واحد على اليمين أو اليسار، لكن يُدعم مؤشرًا سفليًا أو علويًا منفردًا فقط على الجانب الأيمن. يمكن أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element) لتعيين درجة رياضية لعدد.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **فئة MathMatrix**
فئة [**MathMatrix**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix) تحدد كائن المصفوفة، المكوَّن من عناصر فرعية مرتبة في صفوف وأعمدة. تجدر الإشارة إلى أن المصفوفات لا تحتوي على محددات مدمجة؛ لوضع المصفوفة داخل أقواس يجب استخدام كائن المحدد – [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_delimiter). يمكن تمرير قيم `null` لإنشاء فراغات داخل المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **فئة MathArray**
فئة [**MathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array) تحدد مصفوفة عمودية من المعادلات أو أي كائنات رياضية أخرى.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **تنسيق العناصر الرياضية**
- فئة [**MathBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_border_box): ترسم حدًا مستطيلًا أو بشكل آخر حول عنصر [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).

  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- فئة [**MathBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_box): تحدد تغليفًا منطقيًا للعنصر الرياضي. على سبيل المثال، يمكن أن يُستخدم العنصر المغلف كمحاكي عامل مع أو بدون نقطة محاذاة، أو لتحديد نقطة انقطاع سطر، أو لتجميعه بحيث لا يُسمح بكسور سطر داخله. مثال: يجب تغليف العامل “==” لمنع كسور السطر.

- فئة [**MathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_delimiter): تحدد كائن المحدد، المكوَّن من حرف افتتاحي وحرف إغلاق (مثل الأقواس، القوس المعقوف، القوس المربع، أو الشرطات العمودية)، وعنصر أو أكثر داخل المحدد مفصولين بحرف محدد.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- فئة [**MathAccent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_accent): تحدد دالة التَرْفِيع، المكوَّنة من قاعدة وعلامة تشكيلية مدمجة.

  مثال: 𝑎́.

- فئة [**MathBar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_bar): تحدد دالة الشريط، المكوَّنة من وسيط أساسي وشريط فوقي أو سفلي.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- فئة [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_grouping_character): تحدد رمز تجميع فوق أو أسفل تعبير، عادةً لتسليط الضوء على العلاقات بين العناصر.

  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **العمليات الرياضية**
كل عنصر أو تعبير رياضي (عبر فئة [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)) يطبق واجهة [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element). تسمح لك باستخدام عمليات على البنية الحالية وتكوين تعبيرات رياضية أكثر تعقيدًا. كل عملية تقبل إما كائنًا من نوع [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) أو سلسلة نصية كوسيط. عندما تُستخدم سلاسل نصية، تُنشَأ كائنات من فئة [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) بصورة ضمنية.

### **طريقة Join**
- `Join(String)`
- `Join(IMathElement)`

تجمع عنصرًا رياضيًا وتكوّن كتلة رياضية. مثال:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
auto element2 = System::MakeObject<MathematicalText>(u"y");
auto block = element1->Join(element2);
``` 

### **طريقة Divide**
- `Divide(String)`
- `Divide(IMathElement)`
- `Divide(String, MathFractionTypes)`
- `Divide(IMathElement, MathFractionTypes)`

تُنشئ كسرًا من النوع المحدد باستخدام هذا البسط والمقام المحدد. مثال:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **طريقة Enclose**
- `Enclose()`
- `Enclose(Char, Char)`

تحيط العنصر بأحرف محددة مثل القوس أو أي حرف آخر كإطار.

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
- `Function(String)`
- `Function(IMathElement)`

تُعرِّف دالة لوسيط باستخدام الكائن الحالي كاسم الدالة.

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
- `AsArgumentOfFunction(String)`
- `AsArgumentOfFunction(IMathElement)`
- `AsArgumentOfFunction(MathFunctionsOfOneArgument)`
- `AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)`
- `AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

تُحدد الدالة باستخدام الكائن الحالي كوسيط. يمكن:

- تمرير سلسلة كنص اسم الدالة، مثل “cos”.
- اختيار قيمة من التعدادات [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#adc9da096602adece523e68cb7f302415) أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#a161816c6905df993b6c0aae0d98d597b)، مثل **MathFunctionsOfOneArgument.ArcSin**.
- تمرير كائن من نوع [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).

مثال:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);
auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");
auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);
auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");
``` 

### **طرق SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- `SetSubscript(String)` / `SetSubscript(IMathElement)`
- `SetSuperscript(String)` / `SetSuperscript(IMathElement)`
- `SetSubSuperscriptOnTheRight(String, String)` / `SetSubSuperscriptOnTheRight(IMathElement, IMathElement)`
- `SetSubSuperscriptOnTheLeft(String, String)` / `SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)`

تعيّن مؤشرات سُفْلِيّة أو عُلْوِيّة. يمكن تعيين كلاً منها في وقتٍ واحد على اليسار أو اليمين، لكن يُدعم مؤشرات منفردة فقط على الجانب الأيمن. يمكن أيضًا استخدام **Superscript** لتعيين درجة رياضية لعدد.

مثال:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **طريقة Radical**
- `Radical(String)`
- `Radical(IMathElement)`

تحدد جذرًا رياضيًا من الدرجة المحددة للوسيط المعطى.

مثال:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **طرق SetUpperLimit و SetLowerLimit**
- `SetUpperLimit(String)` / `SetUpperLimit(IMathElement)`
- `SetLowerLimit(String)` / `SetLowerLimit(IMathElement)`

تُعيّن حدًا علويًا أو سفليًا. يشير الحد العلوي إلى موضع الوسيط فوق القاعدة، والحد السفلي إلى موضعه أسفل القاعدة.

مثال على تعبير:

![todo:image_alt_text](powerpoint-math-equations_8.png)

يُنشأ باستخدام مزيج من فئتي [MathFunction](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) و[MathLimit](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) وعبر عمليات [IMathElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element):

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 

### **طرق Nary و Integral**
- `Nary(MathNaryOperatorTypes, IMathElement, IMathElement)`
- `Nary(MathNaryOperatorTypes, String, String)`
- `Integral(MathIntegralTypes)`
- `Integral(MathIntegralTypes, IMathElement, IMathElement)`
- `Integral(MathIntegralTypes, String, String)`
- `Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)`
- `Integral(MathIntegralTypes, String, String, MathLimitLocations)`

كلاً من الطريقتين **Nary** و **Integral** تُنشئ وتُرجع عاملًا N-ary ممثلًا بنوع [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_nary_operator). تُحدِّد تعداد [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#abd1cf265844d1b4a2e33970bc64d1167) نوع العامل (جمع، اتحاد، …) ولا تشمل التكاملات. بالنسبة للتكامل، يُستخدم تعداد [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#ab12cc959f134cc6693e552d5b7f78607).

مثال:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **طريقة ToMathArray**
تضع العناصر في مصفوفة عمودية. إذا طُبِّقَت على كائن **MathBlock**، تُرتَّب جميع العناصر الفرعية في المصفوفة المرجعة.

مثال:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **عمليات التنسيق: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **Accent** تُضيف علامة تشديد (حرف فوق العنصر).
- **Overbar** و **Underbar** تضيفان شريطًا علوِيًا أو سفليًا.
- **Group** تُجمع العناصر باستخدام رمز تجميع مثل القوس المعقوف السفلي أو غيره.
- **ToBorderBox** تُضع العنصر داخل صندوق حدود.
- **ToBox** تُضع العنصر داخل صندوق منطقي غير مرئي (تجميع منطقي).

أمثلة:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();
auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();
auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **الأسئلة الشائعة**

**كيف يمكن إضافة معادلة رياضية إلى شريحة PowerPoint؟**  
لإضافة معادلة رياضية، تحتاج إلى إنشاء كائن شكل رياضي، والذي يحتوي تلقائيًا على جزء رياضي. ثم تستخرج [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) وتضيف كائنات [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) إليه.

**هل يمكن إنشاء تعبيرات رياضية معقدة متداخلة؟**  
نعم، يتيح Aspose.Slides إنشاء تعبيرات رياضية معقدة عبر تعشيق كائنات MathBlock. كل عنصر رياضي يطبق واجهة [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) التي تسمح باستخدام عمليات (Join، Divide، Enclose، إلخ) لدمج العناصر في بنى أكثر تعقيدًا.

**كيف يمكن تحديث أو تعديل معادلة رياضية موجودة؟**  
لتحديث معادلة، عليك الوصول إلى كتل MathBlocks الحالية عبر [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/). ثم باستخدام طرق مثل Join، Divide، Enclose، وغيرها، يمكنك تعديل عناصر المعادلة. بعد التحرير، احفظ العرض لتطبيق التغييرات.