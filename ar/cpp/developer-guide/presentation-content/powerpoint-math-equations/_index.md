---
title: معادلات الرياضيات في باوربوينت
type: docs
weight: 80
url: /ar/cpp/powerpoint-math-equations/
keywords: "معادلات الرياضيات في باوربوينت، رموز الرياضيات في باوربوينت، صيغة باوربوينت، نص رياضي في باوربوينت"
description: "معادلات الرياضيات في باوربوينت، رموز الرياضيات في باوربوينت، صيغة باوربوينت، نص رياضي في باوربوينت"
---

## **نظرة عامة**
في باوربوينت، من الممكن كتابة معادلة رياضية أو صيغة وعرضها في العرض التقديمي. لتحقيق ذلك، يتم تمثيل الرموز الرياضية المختلفة في باوربوينت ويمكن إضافتها إلى النص أو المعادلة. لذلك، يتم استخدام مُنشئ معادلات الرياضيات في باوربوينت، والذي يساعد في إنشاء صيغ معقدة مثل:

- كسر رياضي
- جذري رياضي
- دالة رياضية
- حدود ودوال اللوغاريتم
- عمليات N-ary
- مصفوفة
- مشغلين كبار
- دوال جيب، جيب تمام

لإضافة معادلة رياضية في باوربوينت، يتم استخدام قائمة *إدراج -> معادلة*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

هذا سينشئ نصًا رياضيًا بصيغة XML يمكن عرضه في باوربوينت كما يلي:

![todo:image_alt_text](powerpoint-math-equations_2.png)

يدعم باوربوينت الكثير من الرموز الرياضية لإنشاء معادلات. ومع ذلك، فإن إنشاء معادلات رياضية معقدة في باوربوينت غالبًا ما لا يعطي نتيجة جيدة ومهنية. يلجأ المستخدمون، الذين يحتاجون إلى إنشاء عروض تقديمية رياضية بشكل متكرر، إلى استخدام حلول طرف ثالث لإنشاء صيغ رياضية ذات مظهر جيد.

باستخدام [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/)، يمكنك العمل مع المعادلات الرياضية في عروض باوربوينت برمجيًا بلغة C++. يمكنك إنشاء تعبيرات رياضية جديدة أو تعديل التعبيرات التي تم إنشاؤها سابقًا. كما أن تصدير الهياكل الرياضية إلى صور مدعوم جزئيًا.


## **كيفية إنشاء معادلة رياضية**
تستخدم العناصر الرياضية لبناء أي تركيبات رياضية بمستوى تعشيش معين. تشكل مجموعة خطية من العناصر الرياضية كتلة رياضية ممثلة بواسطة [**MathBlock** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)class. [**MathBlock** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)class هي تعبير رياضي منفصل، صيغة، أو معادلة. [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) هي جزء رياضي، تستخدم لحفظ النص الرياضي (لا تخلطها مع [**Portion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)). [**MathParagraph** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph)تسمح بالتلاعب بمجموعة من كتل الرياضيات. تعتبر الفئات المذكورة أعلاه هي المفتاح للعمل مع معادلات الرياضيات في باوربوينت عبر Aspose.Slides API.


دعونا نرى كيف يمكننا إنشاء المعادلة الرياضية التالية عبر Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

لإضافة تعبير رياضي على الشريحة، أولاً، أضف شكلًا سيتضمن النص الرياضي:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 


بعد الإنشاء، سيتضمن الشكل بالفعل فقرة واحدة تحتوي على جزء رياضي بشكل افتراضي. تُعد [**MathPortion** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion)فئة تحتوي على نص رياضي داخلها. للوصول إلى المحتوى الرياضي داخل [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion)، الإشارة إلى المتغير [**MathParagraph** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph):

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 


تسمح فئة [**MathParagraph** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph)بقراءة وإضافة وتحرير وحذف كتل الرياضيات ([**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block))، والتي تتكون من مجموعة من العناصر الرياضية. على سبيل المثال، أنشئ كسرًا وضعه في العرض التقديمي:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 


يمثل كل عنصر رياضي فئة معينة تنفذ واجهة [**IMathElement** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element). توفر هذه الواجهة العديد من الطرق لإنشاء التعبيرات الرياضية بسهولة. يمكنك إنشاء تعبير رياضي معقد تمامًا بسطر واحد من التعليمات البرمجية. على سبيل المثال، ستكون صيغة فيثاغورس على هذا النحو:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 


تُطبق عمليات الواجهة [**IMathElement** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)على أي نوع من العناصر، بما في ذلك [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block).

مثال كامل على كود المصدر:

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
تتشكل التعبيرات الرياضية من تسلسلات من العناصر الرياضية. يُمثل تسلسل العناصر الرياضية بكتلة رياضية، وتشكل معلمات العناصر الرياضية هيكلًا شبيهًا بالشجرة.

هناك العديد من أنواع العناصر الرياضية التي يمكن استخدامها لبناء كتلة رياضية. يمكن تضمين كل من هذه العناصر (تجميعها) في عنصر آخر. أي أن العناصر هي في الواقع حاويات للأخرى، مكونة هيكلًا شبيهًا بالشجرة. أبسط نوع من العناصر لا يحتوي على عناصر أخرى من النص الرياضي.

كل نوع من عنصر الرياضيات ينفذ واجهة [**IMathElement** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)ويتيح استخدام مجموعة مشتركة من العمليات الرياضية على أنواع مختلفة من عناصر الرياضيات.
### **فئة MathematicalText**
تُمثل فئة [**MathematicalText** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text)نصًا رياضيًا - العنصر الأساسي لجميع التركيبات الرياضية. يمكن أن يمثل النص الرياضي العوامل والمشغلين والمتغيرات وأي نص خطي آخر.

مثال: 𝑎=𝑏+𝑐
### **فئة MathFraction**
تحدد فئة [**MathFraction** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction)كائن الكسر، الذي يتكون من بسط ومقام مفصولين بواسطة شريط كسر. يمكن أن يكون شريط الكسر أفقيًا أو قطريًا، اعتمادًا على خصائص الكسر. يتم استخدام كائن الكسر أيضًا لتمثيل دالة الكومة، التي تضع عنصرًا فوق عنصر آخر، دون شريط كسر.

مثال:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **فئة MathRadical**
تحدد فئة [**MathRadical** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical)دالة الجذر (الجذر الرياضي)، وتتكون من قاعدة، ودرجة اختيارية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **فئة MathFunction **
تحدد فئة [**MathFunction** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function)دالة لمتغير. تحتوي على طرق: [get_Name() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a88b5a46342839d7ef1a8d273694bf0b3)- اسم الدالة و[get_Base()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a765fa6bcbeb9b48730dbcb6504d9b543) - متغير الدالة.

مثال:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **فئة MathNaryOperator **
تحدد فئة [**MathNaryOperator** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator)كائن رياضي N-ary، مثل الجمع والعدد التكاملي. يتكون من مشغل، قاعدة (أو عامل)، وحدود علوية وسفلية اختيارية. من أمثلة مشغلات N-ary الجمع، الاتحاد، التقاطع، التكامل.

تتضمن هذه الفئة مشغلين بسيطين مثل الجمع، الطرح، وما إلى ذلك. يتم تمثيلها بواسطة عنصر نص واحد - [MathematicalText](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text).

مثال:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **فئة MathLimit **
تحدد فئة [**MathLimit** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit)الحد العلوي أو السفلي. تحدد كائن الحد، الذي يتكون من نص على خط الأساس ونص بحجم مصغر مباشرة أعلاه أو تحته. لا تتضمن هذه العنصر كلمة "lim"، لكنها تسمح لك بوضع النص في أعلى أو أسفل التعبير. لذا، يتم إنشاء التعبير 

![todo:image_alt_text](powerpoint-math-equations_8.png)

باستخدام مجموعة من العناصر [**MathFunction** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function)و [**MathLimit** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit)بهذه الطريقة:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 


### **فئات MathSubscriptElement و MathSuperscriptElement و MathRightSubSuperscriptElement و MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

تحدد الفئات التالية فهرسًا سفليًا أو فهرسًا علويًا. يمكنك تعيين الفقرة السفلية والعليا في نفس الوقت على الجانب الأيسر أو الأيمن من المتغير، ولكن يتم دعم الفقرة الفردية السفلية أو العليا فقط على الجانب الأيمن. يمكنك أيضًا استخدام [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)لتعيين درجة رياضية لرقم.

مثال:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **فئة MathMatrix **
تحدد فئة [**MathMatrix** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix)كائن المصفوفة، الذي يتكون من عناصر طفلة مرتبة في صفوف وأعمدة واحدة أو أكثر. من المهم ملاحظة أن المصفوفات لا تحتوي على فواصل مدمجة. لوضع المصفوفة في الأقواس، يجب عليك استخدام كائن الفاصل - [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_delimiter). يمكن استخدام معاملات فارغة لإنشاء فراغات في المصفوفات.

مثال:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **فئة MathArray**
تحدد فئة [**MathArray** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array)مصفوفة عمودية من المعادلات أو أي كائنات رياضية.

مثال:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **تنسيق العناصر الرياضية**
- [**MathBorderBox** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_border_box)class: يرسم حدًا مستطيلًا أو شيء آخر حول [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_box)class: تحدد التعبئة المنطقية للعنصر الرياضي. على سبيل المثال، يمكن أن يعمل كائن مغلق كمحاكي عامل مع أو بدون نقطة المحاذاة، أو يعمل كنقطة كسر سطر، أو يتم تجميعه بحيث لا يسمح بكسور الأسطر ضمنه. على سبيل المثال، يجب أن يتم تغليف عامل "==" لمنع كسور الأسطر.
- [**MathDelimiter** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_delimiter)class: تحدد كائن الفاصل، الذي يتكون من شخصيات فتح وإغلاق (مثل الأقواس، والأقواس المعقوفة، والفراغات العمودية)، وواحد أو أكثر من العناصر الرياضية بداخله، مفصولة بشخصية محددة. أمثلة: (𝑥2); [𝑥2|𝑦2].
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_accent)class: تحدد دالة اللكنة، التي تتكون من قاعدة وعلامة diacritical مدمجة. 

  مثال: 𝑎́.

- [**MathBar** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_bar)class: تحدد دالة الشريط، التي تتكون من متغير أساسي وشريط فوق أو تحت.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_grouping_character)class: تحدد رمز التجميع فوق أو أسفل تعبير، عادة لتسليط الضوء على العلاقات بين العناصر.
  
  مثال: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **العمليات الرياضية**
كل عنصر رياضي وتعبير رياضي (عبر [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)) ينفذ واجهة [**IMathElement** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)interface. يسمح لك باستخدام العمليات على الهيكل الموجود وتشكيل تعبيرات رياضية أكثر تعقيدًا. تحتوي جميع العمليات على مجموعتي معلمات: إما [**IMathElement** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)أو سلسلة كوسائط. يتم إنشاء مثيلات فئة [**MathematicalText** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text)ضمنيًا من السلاسل المحددة عندما تستخدم وسائط السلاسل. العمليات الرياضية المتاحة في Aspose.Slides مدرجة أدناه.
### **طريقة Join**
- [Join(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a40d44a0f16d2832ab67decf5e4698b49)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a372375a4f990a157018466622d5d52d9)

يجمع عنصرًا رياضيًا ويشكل كتلة رياضية. على سبيل المثال:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 


### **طريقة Divide**
- [Divide(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae3175481538f5a0a2d6bd3606e7ecfb6)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae1b231db04fff125e5e8c96fd18e608a)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2a1029bda3a198390da3f1b6cb0f677d)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4a19fcb4fcc3a09327793f0ac823e19a)

ينشئ كسراً من النوع المحدد مع هذا البسط والمقام المحددين. على سبيل المثال:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 
### **طريقة Enclose**
- [Enclose()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab0aa4399c0d506050a7aac9dc7f78804)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a36d623c14594a0926fc8121c42b87bf5)

يُغلف العنصر في شخصيات محددة مثل الأقواس أو شخصية أخرى كإطار.

``` cpp
/// <summary>
/// يختار عنصر رياضي في الأقواس
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// يختار هذا العنصر في شخصيات محددة مثل الأقواس أو شخصيات أخرى كإطار
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 


على سبيل المثال:

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **طريقة Function**
- [Function(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afef234e875543a6437a9e2546174ae04)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a320fcf20f060c1a378164558bfa670d4)

تأخذ دالة لمتغير باستخدام الكائن الحالي كاسم الدالة.

``` cpp
/// <summary>
/// تأخذ دالة لمتغير باستخدام هذه المثيل كاسم الدالة
/// </summary>
/// <param name="functionArgument">متغير الدالة</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 


على سبيل المثال:

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 
### **طريقة AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2f9d0d8b693637f52f8aa9243fd5988e)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac1c703c0ed93628b61e20f622e3d91e9)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac540ffa6839db0e17b1096bc57803b3e)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a93dbde6d11b23e577c427a7d02cf13aa)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a304ca31f530ac1cf6c55dc59995a)

تأخذ الدالة المحددة باستخدام المثيل الحالي كحجة. يمكنك:

- تحديد سلسلة كاسم الدالة، على سبيل المثال “cos”.
- اختيار واحدة من القيم المحددة مسبقًا من التعدادات [**MathFunctionsOfOneArgument** ](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#adc9da096602adece523e68cb7f302415)أو [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#a161816c6905df993b6c0aae0d98d597b)، على سبيل المثال **MathFunctionsOfOneArgument.ArcSin.**
- اختيار مثيل من [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).

على سبيل المثال:

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 
### **طرق SetSubscript و SetSuperscript و SetSubSuperscriptOnTheRight و SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a1610efd629e0fef10f46397c3c671829)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a747a756f05c3a5ebaf96ae4b9853d300)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a3e3613e5c07f1b9df5f59c533d5430d0)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aed4ce1bd63e756b9585214ad832d174a)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acedc512b9952ca9ae6750ff75fd10b1d)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aba884260e8d8b434cbe666444bcb7cdc)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad3a3850ed28e26b627a46a6e7198228f)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afb8cea063303a9e81b6d7f50d9ce8c7c)

تحدد الفقرة السفلية والفقرات العليا. يمكنك تعيين الفقرة السفلية والعليا في نفس الوقت على الجانب الأيسر أو الأيمن من المتغير، ولكن يتم دعم الفقرة الفردية السفلية أو العليا فقط على الجانب الأيمن. يمكن استخدام **Superscript** أيضًا لتعيين الدرجة الرياضية لرقم.

مثال:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 
### **طريقة Radical**
- [Radical(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aee6b34eb9da73f4c213b93228bfb2fab)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5a144aefdd800d5e564d368e4885ce30)

تحدد الجذر الرياضي من الدرجة المعطاة من المتغير المحدد.

مثال:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 
### **طرق SetUpperLimit و SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a8382894852974a63b242a303ad4973d0)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acbcf1b88a42676de8794c889a4a33354)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a530d7e4e8296ce38fc54b154c059)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2b580a403a87e19f64672cc50e7c53dd)

تؤخذ الحد العلوي أو السفلي. هنا، تشير العلوية والسفلية ببساطة إلى موقع الحجة بالنسبة للقاعدة.

دعونا نعتبر تعبيرًا: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

يمكن إنشاء مثل هذه التعبيرات من خلال مجموعة من الفئات [MathFunction ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function)و [MathLimit](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit)، وعمليات [IMathElement ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)على النحو التالي:

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 
### **طرق Nary و Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab850b5a7244cf71b89810555e5f55e26)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a667e2c89d5d77aacc51599177f543f75)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad2a93a7e43548d38e23552f480c85c01)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afed3647d15dc6bd636f5bfa111dfd726)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a27d1ee66c5a31ed7ac1b2d9cc1f6af7d)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aef3e63bdeb956c428b7b1ea385bcdad5)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a16a7f1cd3aa5d09543dfbf0b18bb024e)

تُنشئ كل من **Nary** و **Integral** طرق وتُعيد مشغل N-ary الممثل من قبل نوع [**IMathNaryOperator** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_nary_operator). في طريقة Nary، تحدد التعداد [**MathNaryOperatorTypes** ](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#abd1cf265844d1b4a2e33970bc64d1167)نوع المشغل: الجمع، الاتحاد، إلخ، دون تضمين التكامل. في طريقة التكامل، هناك العملية المتخصصة التكامل مع التعداد من الأنواع التكاملية [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#ab12cc959f134cc6693e552d5b7f78607). 

مثال:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 
### **طريقة ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab3130531dfa9403d42ae02466100ddc1) تضع العناصر في مصفوفة عمودية. إذا تم استدعاء هذه العملية على مثيل **MathBlock**، سيتم وضع جميع العناصر الفرعية في المصفوفة المعادة.

مثال:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 
### **عمليات التنسيق: Accent و Overbar و Underbar و Group و ToBorderBox و ToBox**
- تحدد طريقة [**Accent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acd0f38691b52fb83294c0da9f3690483) علامة اللكنة (حرف على قمة العنصر).
- تحدد طرائق [**Overbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5d4780f9be6d0709465f50f5d830d4e3) و [**Underbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a97d93a1fc79a31f4ffd20d233e06c5a5) شريطًا في الأعلى أو الأسفل.
- تحدد طريقة [**Group** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4662589060e34723455b8164ce556546)تضع في مجموعة باستخدام رمز التجميع مثل قوس أسفل أو آخر.
- تحدد طريقة [**ToBorderBox** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aa32771655d8931aa8e0b5d3c1c7e160b)تضع في صندوق حد.
- تحدد طريقة [**ToBox** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac18b6b70362303cb307862a9aaa7dce2)تضع في صندوق غير مرئي (تجميع منطقي).

أمثلة:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 