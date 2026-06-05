---
title: "تنسيق نص العرض التقديمي في C++"
linktitle: "تنسيق النص"
type: docs
weight: 50
url: /ar/cpp/text-formatting/
keywords:
- "تمييز النص"
- "تعبير نمطي"
- "محاذاة الفقرة"
- "نمط النص"
- "خلفية النص"
- "شفافية النص"
- "تباعد الأحرف"
- "خصائص الخط"
- "عائلة الخط"
- "دوران النص"
- "زاوية الدوران"
- "إطار النص"
- "تباعد الأسطر"
- "خاصية الضبط التلقائي"
- "تثبيت إطار النص"
- "تبويب النص"
- "اللغة الافتراضية"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. تخصيص الخطوط، الألوان، المحاذاة، والمزيد."
---
## **نظرة عامة**

تُظهر هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. تغطي إبراز النص، ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الضبط التلقائي، تثبيت النص، مسافات التبويب، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا يُدعى "sample.pptx" يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص العينة](sample_text.png)

## **إبراز النص**

استخدم طريقة [ITextFrame.HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlighttext/) عندما تحتاج إلى إبراز النص الذي يطابق عينة محددة داخل إطار نص. تطبّق الطريقة لون إبراز على أجزاء النص المطابقة ويمكن استخدامها مع [ITextSearchOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/) للتحكم في كيفية إجراء البحث، مثلاً لتطابق الكلمات الكاملة فقط.

الكود التالي يبرز جميع تكرارات الأحرف **"try"** ثم يبرز فقط الكلمة الكاملة **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// الحصول على الشكل الأول من الشريحة الأولى.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// تمييز الكلمة "try" في الشكل.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// تمييز الكلمة "to" في الشكل.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![النص المبرز](highlighted_text.png)

## **إبراز النص باستخدام التعبيرات النمطية**

طريقة [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlightregex/) تبرز التطابقات النصية التي تم العثور عليها باستخدام تعبير نمطي. في C++، يتم توفير هذه الواجهة عبر [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/).

الكود التالي يبرز جميع الكلمات التي تحتوي على **سبعة أحرف أو أكثر**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![النص المبرز باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تعيين لون خلفية النص**

استخدم [IParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` لتعيين لون الإبراز الافتراضي لفقرة، أو استخدم [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/)`.HighlightColor` لأجزاء النص الفردية.

الكود التالي يوضح كيفية تعيين لون الخلفية للـ **فقرة كاملة**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

الكود التالي يوضح كيفية تعيين لون الخلفية لـ **أجزاء النص ذات الخط العريض**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // تعيين لون الإبراز لجزء النص.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [IParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/)`.Alignment` لتحديد محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة متمركزة، محاذاة إلى اليسار، محاذاة إلى اليمين، مبررة، إلخ.

الكود التالي يوضح كيفية محاذاة الفقرة إلى الـ **مركز**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// تعيين محاذاة الفقرة إلى المركز.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الفقرة المحاذية](aligned_paragraph.png)

## **تعيين الشفافية للنص**

تتحكم الشفافية في النص عبر المكوّن ألفا للون المعيّن إلى [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/)`.FillFormat`. في الأمثلة أدناه، `alpha = 50` هي قيمة ألفا في نظام ARGB على مقياس 0-255، وليست نسبة شفافية.

الكود التالي يوضح كيفية تطبيق الشفافية على الـ **فقرة كاملة**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// تعيين لون ملء النص إلى لون شفاف.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

الكود التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // تعيين شفافية جزء النص.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![أجزاء النص الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [IBasePortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/)`.Spacing` لتوسيع أو تقليص التباعد بين الأحرف في صندوق النص.

الكود التالي يظهر كيفية توسيع تباعد الأحرف في الـ **فقرة كاملة**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// ملاحظة: استخدم القيم السالبة لتقليل تباعد الأحرف.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

الكود التالي يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // ملاحظة: استخدم القيم السالبة لتقليل تباعد الأحرف.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **إيقاف التآلف للخطوط المحددة**

في بعض الحالات، قد يبدو النص الذي تُولده Aspose.Slides أكثر ضيقًا قليلاً من النص نفسه في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات التآلف لبعض الخطوط، حتى عندما يحتوي الخط على معلومات تآلف صالحة وكان التآلف مفعَّلًا في إعدادات PowerPoint.

لتقريب الناتج المُولَّد من مظهر PowerPoint في مثل هذه الحالات، يمكنك إيقاف التآلف لأجزاء النص التي تستخدم الخط المتأثر. عيّن [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` إلى قيمة أكبر بكثير من حجم الخط الفعلي:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

هذا الإعداد يمنع تطبيق التآلف على أجزاء النص المطابقة ويمكن أن يساعد في مواءمة عرض Aspose.Slides مع مخرجات PowerPoint البصرية للخطوط المتأثرة بسلوك PowerPoint المحدد.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [IParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` أو على الأجزاء الفردية عبر [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/).

الكود التالي يحدد الخط ونمط النص للـ **فقرة كاملة**: يطبق حجم الخط، العريض، المائل، خط سفلي منقط، وخط Times New Roman على جميع الأجزاء في الفقرة.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// تعيين خصائص الخط للفقرة.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![خصائص الخط للفقرة](font_properties_for_paragraph.png)

الكود التالي يطبق خصائص مشابهة على **أجزاء النص ذات الخط العريض**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // تعيين خصائص الخط لجزء النص.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![خصائص الخط لأجزاء النص](font_properties_for_text_portions.png)

## **تعيين دوران النص**

استخدم [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` لتعيين اتجاه نص مسبق التعريف داخل الشكل.

الكود التالي يضبط اتجاه النص داخل الشكل إلى `Vertical270`، ما يدور النص **90 درجة عكس اتجاه عقرب الساعة**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![دوران النص](text_rotation.png)

## **تعيين دوران مخصص لإطارات النص**

استخدم [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/)`.RotationAngle` لتعيين زاوية دوران مخصصة لإطار نص [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/).

الكود التالي يدور إطار النص بزاوية 3 درجات في اتجاه عقرب الساعة داخل الشكل:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![دوران النص المخصص](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides الخصائص [IParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`، `IParagraphFormat.SpaceBefore`، و `IParagraphFormat.SpaceWithin` للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد الأسطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد الأسطر بالنقاط.

الكود التالي يوضح كيفية تحديد تباعد الأسطر داخل الفقرة:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![تباعد الأسطر داخل الفقرة](line_spacing.png)

## **تعيين نوع الضبط التلقائي لإطارات النص**

يحدد [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/)`.AutofitType` كيفية تصرف النص عندما يتجاوز حدود الحاوية الخاصة به. استخدمه للتحكم فيما إذا كان النص سيُقلّص، سيتجاوز، أو سيعيد تحجيم الشكل تلقائيًا.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تعيين تثبيت إطارات النص**

يُعرّف [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/)`.AnchoringType` كيفية تموضع النص عموديًا داخل الشكل، مثلًا في الأعلى، الوسط، أو الأسفل.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تعيين تبويب النص**

استخدم [IParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` و `IParagraphFormat.Tabs` لتكوين مسافات التبويب في الفقرة.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![تبويبات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/)`.LanguageId`، والتي تتيح لك تعيين لغة التدقيق لجزء نص. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والقواعد في PowerPoint.

الكود التالي يوضح كيفية تعيين لغة التدقيق لجزء نص:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// تعيين معرف لغة التدقيق.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تعيين اللغة الافتراضية**

استخدم [ILoadOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Add a new rectangle shape with text.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Check the first portion language.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [IPresentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`.

الكود التالي يوضح كيفية تعيين خط عريض افتراضي بحجم 14 نقطة لجميع النصوص عبر الشرائح في عرض تقديمي جديد.

```cpp
auto presentation = System::MakeObject<Presentation>();

// احصل على تنسيق الفقرة من المستوى الأعلى.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **استخراج النص مع تأثير الأحرف الكبيرة جميعًا**

في PowerPoint، يُظهر تطبيق تأثير **All Caps** للخط النص بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عندما تسترجع جزء نص بهذه الطريقة باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله بالضبط. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textcaptype/) وحوّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

لنفترض أن لدينا صندوق النص التالي في الشريحة الأولى من ملف sample2.pptx.

![تأثير الأحرف الكبيرة جميعًا](all_caps_effect.png)

الكود التالي يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

الناتج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة المتكررة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/). قم بالتنقل عبر الخلايا وتحديث كل خلية عبر [ICell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icell/)`.TextFrame` وتنسيق الفقرات عبر [IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/)`.ParagraphFormat`.

**كيف يمكن تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/)`.FillFormat`. عيّن [IFillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformat/)`.FillType` إلى [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/)`.Gradient` وقم بتكوين نقاط التدرج، الاتجاه، والشفافية.