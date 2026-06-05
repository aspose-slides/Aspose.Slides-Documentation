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
- "خاصية الملاءمة التلقائية"
- "مرساة إطار النص"
- "تبويب النص"
- "اللغة الافتراضية"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ C++. تخصيص الخطوط، الألوان، المحاذاة، وأكثر."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ C++. تغطي التمييز، ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، مسافات التبويب، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا باسم "sample.pptx" يحتوي على صندوق نص واحد في الشريحة الأولى مع النص التالي:

![نص مثال](sample_text.png)

## **تمييز النص**

استخدم طريقة [ITextFrame.HighlightText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlighttext/) عندما تحتاج إلى تمييز النص الذي يطابق عينة معينة داخل إطار نص. تطبق الطريقة لون تمييز على مقاطع النص المتطابقة ويمكن استخدامها مع [ITextSearchOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextsearchoptions/) للتحكم في كيفية إجراء البحث، على سبيل المثال لمطابقة الكلمات الكاملة فقط.

يوضح المثال البرمجي أدناه تمييز جميع تكرارات الأحرف **"try"** ثم يميز فقط الكلمة الكاملة **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// احصل على الشكل الأول من الشريحة الأولى.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// ظلِّل كلمة "try" في الشكل.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// ظلِّل كلمة "to" في الشكل.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![النص المميز](highlighted_text.png)

## **تمييز النص باستخدام التعبيرات النمطية**

الطريقة [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/highlightregex/) تميز التطابقات النصية التي تم العثور عليها بواسطة تعبير نمطي. في C++، يتم تقديم هذه الـ API على [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/).

يوضح المثال البرمجي أدناه تمييز جميع الكلمات التي تحتوي على **سبعة أحرف أو أكثر**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// تمييز جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![النص المميز باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تعيين لون خلفية النص**

استخدم [IParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` لتعيين لون التمييز الافتراضي لفقرة، أو استخدم [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/)`.HighlightColor` لأجزاء النص الفردية.

يوضح المثال البرمجي التالي كيفية تعيين لون الخلفية للـ **فقرة كاملة**:

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

يوضح المثال البرمجي أدناه كيفية تعيين لون الخلفية لـ **أجزاء النص ذات الخط الغامق**:

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
        // تعيين لون التمييز لجزء النص.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [IParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/)`.Alignment` لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزة، محاذاة إلى اليسار، محاذاة إلى اليمين، مبررة، وما إلى ذلك.

يوضح المثال البرمجي التالي كيفية محاذاة الفقرة إلى **المركز**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// تعيين محاذاة الفقرة إلى الوسط.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الفقرة المحاذاة](aligned_paragraph.png)

## **تعيين الشفافية للنص**

يتم التحكم في شفافية النص من خلال المكوّن ألفا للون المخصص لـ [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/)`.FillFormat`. في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0-255، وليس نسبة شفافية.

يوضح المثال البرمجي أدناه كيفية تطبيق الشفافية على الـ **فقرة كاملة**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Set the fill color of the text to transparent color.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

يوضح المثال البرمجي التالي كيفية تطبيق الشفافية على **أجزاء النص ذات الخط الغامق**:

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

استخدم [IBasePortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/)`.Spacing` لتوسيع أو تضييق التباعد بين الأحرف في صندوق النص.

يعرض الكود C++ التالي كيفية توسيع تباعد الأحرف في الـ **فقرة كاملة**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

يوضح المثال البرمجي أدناه كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط الغامق**:

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
        // ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **إلغاء التآزر للخطوط المحددة**

في بعض الحالات، قد يبدو النص الذي تنتجه Aspose.Slides أكثر إحكامًا قليلاً من النص نفسه المعروض في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات التآزر لبعض الخطوط، حتى عندما يحتوي الخط على معلومات تآزر صالحة ويتم تمكين التآزر في إعدادات PowerPoint.

لجعل الإخراج المعروض أقرب إلى PowerPoint في هذه الحالات، يمكنك إلغاء تفعيل التآزر لأجزاء النص التي تستخدم الخط المتأثر. اضبط [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` إلى قيمة أكبر بشكل ملحوظ من حجم الخط الفعلي:

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

هذا الإعداد يمنع تطبيق التآزر على أجزاء النص المتطابقة ويمكن أن يساعد في مطابقة عرض Aspose.Slides مع النتيجة البصرية في PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن ضبط خصائص الخط على مستوى الفقرة عبر [IParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` أو على الأجزاء الفردية عبر [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/).

الكود التالي يضبط الخط ونمط النص للفقرة بالكامل: يطبق حجم الخط، الغامق، المائل، الخط السفلي المنقّط، وخط Times New Roman على جميع الأجزاء في الفقرة.

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

يوضح المثال البرمجي التالي تطبيق خصائص مماثلة على **أجزاء النص ذات الخط الغامق**:

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

استخدم [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` لتعيين اتجاه نص محدد مسبقًا داخل الشكل.

الكود التالي يضبط اتجاه النص داخل الشكل إلى `Vertical270`، مما يدور النص **90 درجة عكس اتجاه عقارب الساعة**:

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

استخدم [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/)`.RotationAngle` لتعيين زاوية دوران مخصصة لـ [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/).

الكود التالي يدور إطار النص بمقدار 3 درجات باتجاه عقارب الساعة داخل الشكل:

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

توفر Aspose.Slides [IParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`، `IParagraphFormat.SpaceBefore`، و `IParagraphFormat.SpaceWithin` للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

الكود التالي يوضح كيفية تحديد تباعد السطر داخل الفقرة:

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

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

[ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/)`.AutofitType` يحدّد كيفية تصرف النص عندما يتجاوز حدود الحاوية الخاصة به. استخدمه للتحكم فيما إذا كان النص يتقلص، يتجاوز أو يغيّر حجم الشكل تلقائيًا.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تعيين مرساة إطارات النص**

[ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/)`.AnchoringType` يحدد كيفية تموضع النص عموديًا داخل الشكل، على سبيل المثال في الأعلى، الوسط، أو الأسفل.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تعيين تبويب النص**

استخدم [IParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` و `IParagraphFormat.Tabs` لتكوين مواضع التبويب في الفقرة.

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

توفر Aspose.Slides [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/)`.LanguageId`، والتي تسمح لك بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والقواعد في PowerPoint.

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

استخدم [ILoadOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` لتحديد اللغة الافتراضية للنص الذي يتم إنشاؤه أثناء تحميل أو إنشاء عرض تقديمي.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// إضافة شكل مستطيل جديد مع نص.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// التحقق من لغة الجزء الأول.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق النص الافتراضي على مستوى العرض التقديمي، استخدم [IPresentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`.

الكود التالي يوضح كيفية تعيين خط افتراضي غامق بحجم 14 نقطة لجميع النصوص عبر الشرائح في عرض تقديمي جديد.

```cpp
auto presentation = System::MakeObject<Presentation>();

// الحصول على تنسيق الفقرة من المستوى الأعلى.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **استخراج النص مع تأثير الحروف الكبيرة**

في PowerPoint، يؤدي تطبيق تأثير **All Caps** على الخط إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرجاع هذا الجزء من النص باستخدام Aspose.Slides، تقوم المكتبة بإرجاع النص تمامًا كما تم إدخاله. لمطابقة النص المعروض، افحص [TextCapType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textcaptype/) وحوّل السلسلة المرجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

لنفترض أن لدينا صندوق النص التالي في الشريحة الأولى من ملف sample2.pptx.

![تأثير الحروف الكبيرة](all_caps_effect.png)

يوضح المثال البرمجي أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

الإخراج:

```text
النص الأصلي: Hello, Aspose!
تأثير الحروف الكبيرة: HELLO, ASPOSE!
```

## **الأسئلة الشائعة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/). قم بالتكرار عبر الخلايا وقم بتحديث كل خلية عبر [ICell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icell/)`.TextFrame` وتنسيق الفقرة عبر [IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/)`.ParagraphFormat`.

**كيف يمكن تطبيق لون متدرج على النص في شريحة PowerPoint؟**

لتطبيق لون متدرج على النص، استخدم [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/)`.FillFormat`. اضبط [IFillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformat/)`.FillType` إلى [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/)`.Gradient` وقم بتكوين نقاط التدرج، الاتجاه، والشفافية.