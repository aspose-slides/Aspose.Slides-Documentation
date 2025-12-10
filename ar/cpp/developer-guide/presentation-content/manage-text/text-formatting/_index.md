---
title: تنسيق نص PowerPoint في C++
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/cpp/text-formatting/
keywords:
- تمييز النص
- التعبير النمطي
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- تدوير النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة التلقائية
- تثبيت إطار النص
- جدولة النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تنسيق وتشكيل النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. تخصيص الخطوط والألوان والمحاذاة والمزيد."
---

## **تسليط الضوء على النص**
تمت إضافة طريقة HighlightText الجديدة إلى فئتي ITextFrame و TextFrame. تسمح بتسليط الضوء على جزء من النص بلون خلفية باستخدام عينة النص، مشابهة لأداة Text Highlight Color في PowerPoint 2019.

يعرض مقتطف الشيفرة أدناه كيفية استخدام هذه الميزة:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 
توفر Aspose خدمة تحرير PowerPoint مجانية على الإنترنت ومبسطة[free online PowerPoint editing service](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **تسليط الضوء على النص باستخدام التعابير النمطية**
تمت إضافة طريقة HighlightRegex الجديدة إلى فئتي ITextFrame و TextFrame. تسمح بتسليط الضوء على جزء من النص بلون خلفية باستخدام تعبير نمطي، مشابهة لأداة Text Highlight Color في PowerPoint 2019.

يعرض مقتطف الشيفرة أدناه كيفية استخدام هذه الميزة:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **تعيين لون خلفية النص**
تسمح Aspose.Slides بتحديد اللون المفضل لخلفية النص.

يظهر هذا الكود C++ كيفية تعيين لون الخلفية لكامل النص:
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
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


يظهر هذا الكود C++ كيفية تعيين لون الخلفية لجزء فقط من النص:
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
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
        return portion->get_Text().Contains(u"Red");
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
تنسيق النص هو أحد العناصر الأساسية عند إنشاء أي نوع من المستندات أو العروض التقديمية. نعلم أن Aspose.Slides for C++ يدعم إضافة النص إلى الشرائح، وفي هذا الموضوع سنرى كيف يمكننا التحكم في محاذاة فقرات النص داخل الشريحة. يرجى اتباع الخطوات أدناه لمحاذاة فقرات النص باستخدام Aspose.Slides for C++ :

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة باستخدام رقم الفهرس الخاص بها.
3. الوصول إلى الأشكال النائبة (Placeholder) الموجودة في الشريحة وتحويلها إلى AutoShape.
4. الحصول على الفقرة (Paragraph) التي تحتاج إلى محاذاة من TextFrame المعروضة بواسطة AutoShape.
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين، اليسار، الوسط أو ضبط التبرير.
6. حفظ العرض التقديمي المعدل كملف PPTX.

التنفيذ الخاص بالخطوات أعلاه موضح أدناه.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **تعيين الشفافية للنص**
يوضح هذا المقال كيفية تعيين خصيصة الشفافية لأي شكل نصي باستخدام Aspose.Slides. لتعيين الشفافية للنص، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة Presentation.
2. الحصول على مرجع شريحة.
3. تعيين لون الظل.
4. حفظ العرض التقديمي كملف PPTX.

التنفيذ الخاص بالخطوات أعلاه موضح أدناه.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **تعيين تباعد الأحرف للنص**
تسمح Aspose.Slides بتعيين المسافة بين الأحرف داخل مربع النص. بهذه الطريقة يمكنك تعديل الكثافة البصرية لسطر أو كتلة نصية عن طريق توسيع أو تقليص التباعد بين الأحرف.

يظهر هذا الكود C++ كيفية توسيع التباعد لسطر نص واحد وتقليل التباعد لسطر آخر:
```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // توسيع
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // تضييق

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```


## **إدارة خصائص خط النص**
عادةً ما تحتوي العروض التقديمية على نصوص وصور. يمكن تنسيق النص بطرق مختلفة، سواء لتسليط الضوء على أقسام وكلمات معينة، أو للتماشي مع الأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تنويع مظهر ومحتوى العرض. يوضح هذا المقال كيفية استخدام Aspose.Slides for C++ لتكوين خصائص الخط للفقرات النصية على الشرائح. لإدارة خصائص الخط لفقرات النص باستخدام Aspose.Slides for C++ :

1. إنشاء كائن من الفئة `Presentation` .
2. الحصول على مرجع شريحة باستخدام رقم الفهرس.
3. الوصول إلى الأشكال النائبة في الشريحة وتحويلها إلى AutoShape.
4. الحصول على الفقرة من TextFrame المعروضة بواسطة AutoShape.
5. ضبط التبرير للفقرة.
6. الوصول إلى جزء النص (Portion) في الفقرة.
7. تعريف الخط باستخدام FontData وتعيين الخط للجزء وفقًا لذلك.
   1. تعيين الخط إلى عريض (Bold).
   2. تعيين الخط إلى مائل (Italic).
8. تعيين لون الخط باستخدام FillFormat المعروضة من قبل كائن Portion.
9. حفظ العرض التقديمي المعدل كملف PPTX.

التنفيذ الخاص بالخطوات أعلاه موضح أدناه. يستخدم عرضًا تقديميًا غير مُزَيّن ويُنسق الخطوط على إحدى الشرائح.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}

## **إدارة عائلة الخط للنص**
يُستخدم الجزء (Portion) لاحتواء النص ذي النمط التنسيقي المتشابه داخل الفقرة. يوضح هذا المقال كيفية استخدام Aspose.Slides for C++ لإنشاء مربع نص يحتوي على نص ثم تعريف خط معين بالإضافة إلى خصائص أخرى لعائلة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص فيه:

1. إنشاء كائن من الفئة `Presentation` .
2. الحصول على مرجع شريحة باستخدام رقم الفهرس.
3. إضافة AutoShape من النوع Rectangle إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بـ AutoShape.
5. الوصول إلى TextFrame الخاص بـ AutoShape.
6. إضافة بعض النص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ TextFrame.
8. تعريف الخط المستخدم للـ Portion.
9. تعيين خصائص الخط الأخرى مثل العريض، المائل، تحتي الخط، اللون والارتفاع باستخدام الخصائص المتاحة في كائن Portion.
10. حفظ العرض التقديمي المعدل كملف PPTX.

التنفيذ الخاص بالخطوات أعلاه موضح أدناه.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **تعيين حجم الخط للنص**
تسمح Aspose.Slides باختيار حجم الخط المفضل للنص الموجود بالفعل في الفقرة وأي نص قد يُضاف إلى الفقرة لاحقًا.

يظهر هذا الكود C++ كيفية تعيين حجم الخط للنصوص الموجودة في الفقرة:
```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// يحصل على الشكل الأول، على سبيل المثال.
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // يحصل على الفقرة الأولى، على سبيل المثال.
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // يحدد حجم الخط الافتراضي إلى 20 نقطة لكل أجزاء النص في الفقرة.
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // يحدد حجم الخط إلى 20 نقطة لأجزاء النص الحالية في الفقرة.
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **تعيين دوران النص**
تسمح Aspose.Slides for C++ للمطورين بتدوير النص. يمكن ضبط النص ليظهر أفقيًا، عموديًا، Vertical270، WordArtVertical، EastAsianVertical، MongolianVertical أو WordArtVerticalRightToLeft. لتدوير نص أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة `Presentation` .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى TextFrame.
5. تدوير النص.
6. حفظ الملف إلى القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}

## **العلامات والفواصل الفعّالة في العرض التقديمي**
- الخاصية EffectiveTabs.ExplicitTabCount (2 في مثالنا) تساوي Tabs.Count.
- مجموعة EffectiveTabs تشمل جميع العلامات (من مجموعة Tabs والعلامات الافتراضية).
- الخاصية EffectiveTabs.ExplicitTabCount (2 في مثالنا) تساوي Tabs.Count.
- الخاصية EffectiveTabs.DefaultTabSize (294) تُظهر المسافة بين العلامات الافتراضية (3 و4 في مثالنا).
- الدالة EffectiveTabs.GetTabByIndex(index) مع index = 0 تُعيد أول علامة صريحة (Position = 731)، index = 1 تُعيد العلامة الثانية (Position = 1241). إذا حاولت الحصول على العلامة التالية مع index = 2 فستُعيد أول علامة افتراضية (Position = 1470) وهكذا.
- الدالة EffectiveTabs.GetTabAfterPosition(pos) تُستخدم للحصول على العلامة التالية بعد نص معين. على سبيل المثال لديك النص: "Helloworld!". لتص rendering هذا النص تحتاج إلى معرفة مكان بدء رسم "world!". أولًا، احسب طول "Hello" بالبكسل واستدعِ GetTabAfterPosition بالقيمة. ستحصل على موضع العلامة التالي لرسم "world!".

## **تباعد الأسطر في الفقرة**
توفر Aspose.Slides خصائص ضمن `ParagraphFormat`—`SpaceAfter` و `SpaceBefore` و `SpaceWithin`—تتيح لك إدارة تباعد الأسطر لفقرة. تُستعمل الخصائص الثلاثة كالتالي:

* لتحديد تباعد السطر للفقرة بالنسبة المئوية، استخدم قيمة موجبة.
* لتحديد تباعد السطر للفقرة بالنقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق تباعد سطر 16pt للفقرة عن طريق ضبط الخاصية `SpaceBefore` إلى -16.

طريقة تحديد تباعد السطر لفقرة معينة:

1. تحميل عرض تقديمي يحتوي على AutoShape مع نص داخله.
2. الحصول على مرجع شريحة من خلال رقم الفهرس.
3. الوصول إلى TextFrame.
4. الوصول إلى الفقرة.
5. ضبط خصائص الفقرة.
6. حفظ العرض التقديمي.

يظهر هذا الكود C++ كيفية تحديد تباعد الأسطر لفقرة:
``` cpp
// مسار دليل الوثائق.
System::String dataDir = GetDataPath();

// إنشاء مثيل من فئة Presentation
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// الحصول على مرجع الشريحة عبر الفهرس الخاص بها
auto sld = presentation->get_Slides()->idx_get(0);

// الوصول إلى TextFrame
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// الوصول إلى الفقرة
auto para = tf1->get_Paragraphs()->idx_get(0);

// ضبط خصائص الفقرة
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// حفظ العرض التقديمي
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```


## **تعيين خاصية AutofitType لإطار النص**
في هذا الموضوع نستكشف خصائص تنسيق مختلفة لإطار النص. يغطي المقال كيفية تعيين خاصية AutofitType لإطار النص، وتثبيت النص وتدويره في العرض التقديمي. تسمح Aspose.Slides for C++ للمطورين بتعيين خاصية AutofitType لأي إطار نص. يمكن ضبط AutofitType إلى Normal أو Shape. إذا تم ضبطه إلى Normal سيبقى الشكل كما هو بينما يتم تعديل النص دون تغيير الشكل، أما إذا تم ضبطه إلى Shape، فسيتم تعديل الشكل بحيث يحتوي فقط على النص المطلوب. لتعيين خاصية AutofitType لإطار النص، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة Presentation.
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى TextFrame.
5. تعيين AutofitType لإطار النص.
6. حفظ الملف إلى القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}

## **تعيين تثبيت النص (Anchor) لإطار النص**
تسمح Aspose.Slides for C++ للمطورين بتثبيت أي TextFrame. يحدد TextAnchorType موضع النص داخل الشكل. يمكن ضبط TextAnchorType إلى Top أو Center أو Bottom أو Justified أو Distributed. لتعيين تثبيت النص لأي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة `Presentation` .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى TextFrame.
5. تعيين TextAnchorType لإطار النص.
6. حفظ الملف إلى القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}

## **تعيين زاوية دوران مخصصة لإطار النص**
يدعم Aspose.Slides for C++ الآن تعيين زاوية دوران مخصصة لإطار النص. في هذا الموضوع، سنستعرض مثالًا يوضح كيفية تعيين خاصية RotationAngle في Aspose.Slides. تمت إضافة الخاصية RotationAngle إلى واجهتي IChartTextBlockFormat و ITextFrameFormat، وتسمح بتعيين زاوية دوران مخصصة لإطار النص. لتعيين خاصية RotationAngle، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة Presentation.
2. إضافة مخطط (Chart) إلى الشريحة.
3. تعيين خاصية RotationAngle.
4. حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، نقوم بتعيين خاصية RotationAngle.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **تعيين لغة التدقيق**
توفر Aspose.Slides الخاصية [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (المعروضة عبر فئة [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)) لتعيين لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد النحوية داخل PowerPoint.

يظهر هذا الكود C++ كيفية تعيين لغة التدقيق لمستند PowerPoint:
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
يظهر هذا الكود C++ كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint:
```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// يضيف شكل مستطيل جديد مع نص
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// يتحقق من لغة الجزء الأول
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **تعيين نمط النص الافتراضي**
إذا كنت بحاجة لتطبيق تنسيق نص افتراضي موحد على جميع عناصر النص في عرض تقديمي مرة واحدة، يمكنك استخدام طريقة `get_DefaultTextStyle` من واجهة [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) وتعيين التنسيق المفضل. يوضح المثال أدناه كيفية تعيين خط عريض افتراضي (14 pt) للنص على جميع الشرائح في عرض تقديمي جديد.
```c++
auto presentation = MakeObject<Presentation>();

// احصل على تنسيق الفقرة من المستوى الأعلى.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **استخراج النص مع تأثير الأحرف الكبيرة كلها**
في PowerPoint، يؤدي تطبيق تأثير الخط **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء من النص باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله بالضبط. للتعامل مع ذلك، تحقق من [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/)—إذا كان يُشير إلى `All`، حوّل السلسلة المسترجعة إلى أحرف كبيرة لتطابق ما يراه المستخدمون على الشريحة.

لنفترض أن لدينا صندوق نص كما في الشريحة الأولى من ملف sample2.pptx.

![The All Caps effect](all_caps_effect.png)

 يظهر المثال أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:
```cpp
auto presentation = MakeObject<Presentation>(u"sample2.pptx");
auto autoShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```


الناتج:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **الأسئلة الشائعة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، تحتاج إلى استخدام كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). يمكنك المرور عبر جميع الخلايا في الجدول وتغيير النص في كل خلية عبر الوصول إلى إطار النص الخاص بها وخصائص تنسيق الفقرة داخل كل خلية.

**كيف يمكن تطبيق تدرج لوني على النص في شريحة PowerPoint؟**

لتطبيق تدرج لوني على النص، استخدم طريقة `get_FillFormat` في [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/). اضبط تنسيق التعبئة إلى `Gradient`، حيث يمكنك تعريف ألوان البداية والنهاية للتدرج، بالإضافة إلى خصائص أخرى مثل الاتجاه والشفافية لإنشاء تأثير التدرج على النص.