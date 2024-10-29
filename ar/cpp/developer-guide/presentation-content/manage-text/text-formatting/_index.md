---
title: تنسيق النص
type: docs
weight: 50
url: /ar/cpp/text-formatting/
keywords:
- تسليط الضوء على النص
- تعبير عادي
- محاذاة فقرات النص
- شفافية النص
- خصائص خط الفقرة
- عائلة الخط
- دوران النص
- زاوية دوران مخصصة
- إطار النص
- تباعد الأسطر
- خاصية النفاذ التلقائي
- ربط إطار النص
- تبويب النص
- نمط النص الافتراضي
- C++
- Aspose.Slides لـ .C++
description: "إدارة ومعالجة خصائص النص وإطار النص في C++"
---

## **تسليط الضوء على النص**
تم إضافة طريقة HighlightText جديدة إلى فئتي ITextFrame و TextFrame. تسمح بتسليط الضوء على جزء من النص بلون خلفية باستخدام نموذج نص، مشابه لأداة لون تسليط الضوء على النص في PowerPoint 2019.

الشفرة البرمجية أدناه توضح كيفية استخدام هذه الميزة:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 

Aspose توفر خدمة تحرير PowerPoint عبر الإنترنت بسيطة [مجانية](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **تسليط الضوء على النص باستخدام تعبير عادي**
تم إضافة طريقة HighlightRegex جديدة إلى فئتي ITextFrame و TextFrame. تسمح بتسليط الضوء على جزء من النص بلون خلفية باستخدام regex، مشابه لأداة لون تسليط الضوء على النص في PowerPoint 2019.

الشفرة البرمجية أدناه توضح كيفية استخدام هذه الميزة:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **Set Text Background Color**

Aspose.Slides يسمح لك بتحديد اللون المفضل لديك لخلفية النص.

توضح هذه الشفرة البرمجية في C++ كيفية تعيين لون الخلفية لنص كامل:

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"أسود");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" أحمر ");

    auto portion3 = System::MakeObject<Portion>(u"أسود");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));
    auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    for (auto&& portion : portions)
    {
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Blue());
    }
    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```

توضح هذه الشفرة البرمجية في C++ كيفية تعيين لون الخلفية لجزء فقط من النص:

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"أسود");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" أحمر ");

    auto portion3 = System::MakeObject<Portion>(u"أسود");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));

	auto predicate = [](System::SharedPtr<IPortion> portion) -> bool {
        return portion->get_Text().Contains(u"أحمر");
	};

	auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    System::SharedPtr<IPortion> redPortion;
	for (auto&& portion : portions)
        if (predicate(portion))
            redPortion = portion;

    redPortion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Red());

    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```

## **محاذاة فقرات النص**
يعد تنسيق النص أحد العناصر الرئيسية أثناء إنشاء أي نوع من الوثائق أو العروض التقديمية. نحن نعلم أن Aspose.Slides لـ C++ تدعم إضافة نصوص إلى الشرائح، ولكن في هذا الموضوع، سنرى كيف يمكننا التحكم في محاذاة فقرات النص في شريحة. يرجى اتباع الخطوات أدناه لمحاذاة فقرات النص باستخدام Aspose.Slides لـ C++ :

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على مرجع شريحة باستخدام فهرسها.
3. الوصول إلى أشكال العنصر النائب الموجودة في الشريحة وتحويلها إلى AutoShape.
4. احصل على الفقرة (التي تحتاج إلى محاذاة) من إطار النص المقدم بواسطة AutoShape.
5. قم بمحاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين، اليسار، الوسط، والتبرير.
6. قم بكتابة العرض التقديمي المعدل كملف PPTX.

تImplementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **Set Transparency for Text**
توضح هذه المقالة كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides. من أجل تعيين الشفافية للنص، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلًا من فئة Presentation.
2. احصل على مرجع شريحة.
3. قم بتعيين لون الظل.
4. اكتب العرض التقديمي كملف PPTX.

تImplementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **Set Character Spacing for Text**

Aspose.Slides يسمح لك بتعيين المسافة بين الحروف في مربع النص. بهذه الطريقة، يمكنك ضبط الكثافة البصرية لسطر أو كتلة نص عن طريق توسيع أو تقليص المسافة بين الحروف.

توضح هذه الشفرة البرمجية في C++ كيفية توسيع المسافة لخط واحد من النص وتقليص المسافة لخط آخر:

```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // expand
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // condense

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```

## **إدارة خصائص خط الفقرة**

تحتوي العروض التقديمية عادةً على نصوص وصور. يمكن تنسيق النص بطرق مختلفة، إما لتسليط الضوء على أقسام وكلمات محددة، أو للتوافق مع أنماط الشركات. يساعد تنسيق النص المستخدمين في تغيير المظهر والشعور بمحتوى العرض التقديمي. توضح هذه المقالة كيفية استخدام Aspose.Slides لـ C++ لتكوين خصائص الخط للفقرات النصية على الشرائح. لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides لـ C++ :

1. أنشئ مثيلًا من فئة `Presentation`.
1. احصل على مرجع شريحة باستخدام فهرسها.
1. الوصول إلى أشكال العنصر النائب في الشريحة وتحويلها إلى AutoShape.
1. احصل على الفقرة من إطار النص المقدَّم بواسطة AutoShape.
1. قم بتبرير الفقرة.
1. الوصول إلى جزء نص الفقرة.
1. تعريف الخط باستخدام FontData وتعيين الخط بناءً عليه.
   1. تعيين الخط ليكون عريضًا.
   1. تعيين الخط ليكون مائلًا.
1. تعيين لون الخط باستخدام FillFormat المقدَّم بواسطة كائن Portion.
1. اكتب العرض التقديمي المعدل كملف PPTX.

تImplementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}


## **إدارة عائلة الخط للنص**
تستخدم جزء للاحتفاظ بالنص بتنسيق مشابه في الفقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides لـ C++ لإنشاء مربع نص ببعض النصوص ثم تعريف خط معين، وعدد من الخصائص الأخرى لفئة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص فيه:

1. أنشئ مثيلًا من فئة `Presentation`.
2. احصل على مرجع شريحة باستخدام فهرسها.
3. أضف AutoShape من النوع Rectangle إلى الشريحة.
4. قم بإزالة نمط الحشو المرتبط بـ AutoShape.
5. الوصول إلى إطار النص الخاص بـ AutoShape.
6. أضف بعض النصوص إلى إطار النص.
7. الوصول إلى كائن Portion المرتبط بإطار النص.
8. تعريف الخط المستخدم للجزء.
9. تعيين خصائص الخط الأخرى مثل العريض، المائل، التسطير، اللون والارتفاع باستخدام الخصائص ذات الصلة المقدمة بواسطة كائن Portion.
10. اكتب العرض التقديمي المعدل كملف PPTX.

تImplementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **تعيين حجم الخط للنص**

Aspose.Slides يسمح لك باختيار حجم الخط المفضل لديك للنص الحالي في الفقرة وغيرها من النصوص التي قد تتم إضافتها إلى الفقرة لاحقًا.

توضح هذه الشفرة البرمجية في C++ كيفية تعيين حجم الخط للنصوص الموجودة في فقرة:

```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// يحصل على الشكل الأول، على سبيل المثال.
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // يحصل على الفقرة الأولى، على سبيل المثال.
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // تعيين حجم الخط الافتراضي إلى 20 نقطة لجميع أجزاء النص في الفقرة.
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // تعيين حجم الخط إلى 20 نقطة لأجزاء النص الحالية في الفقرة.
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **تعيين دوران النص**

Aspose.Slides لـ C++ يسمح للمطورين بتدوير النص. يمكن تعيين النص ليظهر أفقيًا، عموديًا، عمودي270، WordArtVertical، EastAsianVertical، MongolianVertical أو WordArtVerticalRightToLeft. لتدوير نص أي إطار نص، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلًا من `Presentation` class.
2. الوصول إلى الشريحة الأولى.
3. أضف أي شكل إلى الشريحة.
4. الوصول إلى إطار النص.
5. تدوير النص.
6. حفظ الملف على القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}


## **التبويبات و EffectiveTabs في العرض التقديمي**
- خاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- مجموعة EffectiveTabs تتضمن جميع التبويبات (من مجموعة التبويبات والتبويبات الافتراضية)
- خاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- خاصية EffectiveTabs.DefaultTabSize (294) تُظهر المسافة بين التبويبات الافتراضية (3 و 4 في مثالنا).
- EffectiveTabs.GetTabByIndex(index) مع index = 0 ستعيد أول تبويب صريح (Position = 731)، index = 1 - تبويب الثاني (Position = 1241). إذا كنت تحاول الحصول على تبويب التالي مع index = 2 فسوف تعيد أول تبويب افتراضي (Position = 1470) وما إلى ذلك.
- EffectiveTabs.GetTabAfterPosition(pos) تستخدم للحصول على التبويب التالي بعد نص معين. على سبيل المثال، لديك نص: "Helloworld!". لرسم مثل هذا النص، يجب أن تعرف أين تبدأ في رسم "world!". أولاً، يجب عليك حساب طول "Hello" بالبكسل واستدعاء GetTabAfterPosition باستخدام هذه القيمة. ستحصل على موضع التبويب التالي لرسم "world!".

## **تباعد الأسطر للفقرة**

Aspose.Slides يوفر خصائص ضمن `ParagraphFormat`—`SpaceAfter`، `SpaceBefore` و `SpaceWithin`—التي تتيح لك إدارة تباعد الأسطر لفقرة. تُستخدم الخصائص الثلاث بهذه الطريقة:

* لتحديد تباعد الأسطر لفقرة بالنسبة المئوية، استخدم قيمة موجبة. 
* لتحديد تباعد الأسطر لفقرة بالنقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق تباعد أسطر بمقدار 16 نقطة لفقرة عن طريق تعيين خاصية `SpaceBefore` إلى -16.

هذه هي الطريقة التي تحدد بها تباعد الأسطر لفقرة معينة:

1. قم بتحميل عرض تقديمي يحتوي على AutoShape مع بعض النصوص فيه.
2. احصل على مرجع شريحة من خلال فهرسها.
3. الوصول إلى إطار النص.
4. الوصول إلى الفقرة.
5. تعيين خصائص الفقرة.
6. حفظ العرض التقديمي.

توضح هذه الشفرة البرمجية في C++ كيفية تحديد تباعد الأسطر لفقرة:

``` cpp
// مسار دليل الوثائق.
System::String dataDir = GetDataPath();

// أنشئ مثيلًا من فئة Presentation
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// احصل على مرجع شريحة باستخدام فهرسها
auto sld = presentation->get_Slides()->idx_get(0);

// الوصول إلى إطار النص
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// الوصول إلى الفقرة
auto para = tf1->get_Paragraphs()->idx_get(0);

// تعيين خصائص الفقرة
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// حفظ العرض التقديمي
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```


## **تعيين خاصية AutofitType لإطار النص**
في هذا الموضوع، سنستكشف الخصائص المختلفة لتنسيق إطار النص. تغطي هذه المقالة كيفية تعيين خاصية AutofitType لإطار النص، وموضع النص وتدوير النص في العرض التقديمي. Aspose.Slides لـ C++ يسمح للمطورين بتعيين خاصية AutofitType لأي إطار نص. يمكن تعيين AutofitType إلى Normal أو Shape. إذا تم تعيينه على Normal، فسيظل الشكل كما هو بينما سيتم ضبط النص دون تغيير الشكل نفسه. أما إذا تم تعيين AutofitType على الشكل، فسيتم تعديل الشكل بحيث يحتوي فقط على النص المطلوب. لتعيين خاصية AutofitType لإطار نص، يرجى اتباع الخطوات التالية:

1. أنشئ مثيلًا من فئة Presentation.
2. الوصول إلى الشريحة الأولى.
3. أضف أي شكل إلى الشريحة.
4. الوصول إلى إطار النص.
5. تعيين AutofitType لإطار النص.
6. حفظ الملف على القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}


## **تعيين ربط إطار النص**
Aspose.Slides لـ C++ يسمح للمطورين بتعيين رابط لأي إطار نص. يحدد TextAnchorType مكان وضع النص في الشكل. يمكن تعيين TextAnchorType إلى أعلى أو مركز أو أسفل أو تبرير أو توزيع. لتعيين رابط أي إطار نص، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلًا من `Presentation` class.
2. الوصول إلى الشريحة الأولى.
3. أضف أي شكل إلى الشريحة.
4. الوصول إلى إطار النص.
5. تعيين TextAnchorType لإطار النص.
6. حفظ الملف على القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}


## **تعيين زاوية التدوير المخصصة لإطار النص**
Aspose.Slides لـ C++ تدعم الآن تعيين زاوية تدوير مخصصة لإطار النص. في هذا الموضوع، سنرى من خلال المثال كيفية تعيين خاصية RotationAngle في Aspose.Slides. تمت إضافة الخاصية الجديدة RotationAngle إلى واجهتي IChartTextBlockFormat و ITextFrameFormat، مما يسمح بتعيين زاوية التدوير المخصصة لإطار النص. من أجل تعيين خاصية RotationAngle، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلًا من فئة Presentation.
2. أضف رسمًا بيانيًا على الشريحة.
3. تعيين خاصية RotationAngle.
4. اكتب العرض التقديمي كملف PPTX.

في المثال أدناه، نقوم بتعيين خاصية RotationAngle.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **تعيين لغة التدقيق**

يوفر Aspose.Slides خاصية [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (المقدمة بواسطة [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)class) للسماح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم التحقق من هجاءها وقواعدها في PowerPoint.

توضح هذه الشفرة البرمجية في C++ كيفية تعيين لغة التدقيق لوثيقة PowerPoint:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// تعيين معرف لغة التدقيق

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **تعيين اللغة الافتراضية**

توضح هذه الشفرة البرمجية في C++ كيفية تعيين اللغة الافتراضية لعرض تقديمي كامل من PowerPoint:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// إضافة شكل مستطيل جديد مع نص
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"نص جديد");

// تحقق من لغة الجزء الأول
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **تعيين النمط الافتراضي للنص**

إذا كنت بحاجة إلى تطبيق نفس تنسيق نص افتراضي على جميع عناصر النص في عرض تقديمي مرة واحدة، فإنك تستطيع استخدام `get_DefaultTextStyle` من واجهة [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) وتعيين التنسيق المفضل. يوضح المثال البرمجي أدناه كيفية تعيين الخط العريض الافتراضي (14 نقطة) للنص على جميع الشرائح في عرض تقديمي جديد.

```c++
auto presentation = MakeObject<Presentation>();

// احصل على تنسيق الفقرة في المستوى الأعلى.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```