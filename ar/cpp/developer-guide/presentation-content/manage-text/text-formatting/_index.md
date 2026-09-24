---
title: تنسيق نص العرض التقديمي في C++
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/cpp/text-formatting/
keywords:
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- دوران النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملء التلقائي
- تثبيت إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "قم بتنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. خصّص الخطوط والألوان والمحاذاة والمزيد."
---
## **نظرة عامة**

تُظهر هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for C++. تغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملء التلقائي، تثبيت النص، مسافات التبويب، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا اسمه "sample.pptx"، يحتوي على مربع نص واحد في الشريحة الأولى بالنص التالي:

![Sample text](sample_text.png)

للعثور على نص حرفي أو مطابقة تعبيرٍ نمطي وتحديده، راجع [Search and Replace Text](/slides/ar/cpp/search-and-replace-text/).

## **Set Text Background Color**

استخدم [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) لتعيين لون التحديد الافتراضي لفقرة، أو استخدم [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) لأجزاء النص الفردية.

يوضح مثال الشيفرة التالي كيفية تعيين لون الخلفية لل**فقرة كاملة**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
auto highlightColor = System::Drawing::Color::get_LightGray();

// تعيين لون التحديد للفقرة بأكملها.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The gray paragraph](gray_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية تعيين لون الخلفية لل**أجزاء النص بخط عريض**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto highlightColor = System::Drawing::Color::get_LightGray();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // تعيين لون التحديد لجزء النص.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The gray text portions](gray_text_portions.png)

## **Align Text Paragraphs**

استخدم [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزية، محاذاة لليسار، محاذاة لليمين، مبررة، وما إلى ذلك.

يوضح مثال الشيفرة التالي كيفية محاذاة الفقرة إلى **الوسط**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextAlignment.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// اضبط محاذاة الفقرة إلى الوسط.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The aligned paragraph](aligned_paragraph.png)

## **Set Transparency for Text**

يتم التحكم في شفافية النص من خلال مكون ألفا للون المُعيّن عبر [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/get_fillformat/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا بصيغة ARGB على مقياس 0‑255، وليس نسبة شفافية.

يوضح مثال الشيفرة أدناه كيفية تطبيق الشفافية على **الفقرة كاملة**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// تعيين لون تعبئة النص إلى لون شفاف.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The transparent paragraph](transparent_paragraph.png)

يوضح مثال الشيفرة التالي كيفية تطبيق الشفافية على **أجزاء النص بخط عريض**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // تعيين شفافية جزء النص.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The transparent text portions](transparent_text_portions.png)

## **Set Character Spacing for Text**

استخدم [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_spacing/) لتوسيع أو تضييق التباعد بين الأحرف في مربع النص.

يوضح كود C++ التالي كيفية توسيع تباعد الأحرف في **الفقرة كاملة**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// ملاحظة: استخدم قيمًا سالبة لضغط تباعد الأحرف.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // توسيع تباعد الأحرف.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية توسيع تباعد الأحرف في **أجزاء النص بخط عريض**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // ملاحظة: استخدم قيمًا سالبة لضغط تباعد الأحرف.
        portionFormat->set_Spacing(3.0f); // توسيع تباعد الأحرف.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Disable Kerning for Specific Fonts**

في بعض الحالات، قد يبدو النص المُصدَّر بواسطة Aspose.Slides أكثر ضيقًا قليلًا مقارنةً بالنص نفسه المعروض في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات الـ kerning لبعض الخطوط، حتى وإن كان الخط يحتوي على معلومات kerning صالحة وكانت الـ kerning مفعَّلة في إعدادات PowerPoint.

لجعل الناتج المُصدَّر أقرب إلى PowerPoint في مثل هذه الحالات، يمكنك تعطيل الـ kerning لأجزاء النص التي تستخدم الخط المتأثر. استخدم [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) لتعيين قيمة أكبر بكثير من حجم الخط الفعلي:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
System::String targetFont = u"Roboto";
auto textFrame = autoShape->get_TextFrame();
auto paragraphs = textFrame->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
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

يمنع هذا الإعداد تطبيق الـ kerning على أجزاء النص المطابقة ويمكن أن يساعد في محاذاة عرض Aspose.Slides مع النتيجة البصرية لـ PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **Manage Text Font Properties**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) أو على الأجزاء الفردية عبر [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/).

يعرض المثال التالي الشيفرة التي تُعيّن الخط ونمط النص للفقرة كاملة: يطبق حجم الخط، العريض، المائل، خط تحت نقطي، وخط Times New Roman على جميع الأجزاء في الفقرة.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// تعيين خصائص الخط للفقرة.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The font properties for the paragraph](font_properties_for_paragraph.png)

يوضح مثال الشيفرة أدناه تطبيق خصائص مماثلة على **أجزاء النص بخط عريض**:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto font = System::MakeObject<FontData>(u"Times New Roman");

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // تعيين خصائص الخط لجزء النص.
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Set Text Rotation**

استخدم [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_textverticaltype/) لتعيين اتجاه نص مسبق التعريف داخل الشكل.

يعين مثال الشيفرة التالي اتجاه النص في الشكل إلى [TextVerticalType::Vertical270](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textverticaltype/)، مما يدور النص **90 درجة عكس اتجاه عقرب الساعة**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The text rotation](text_rotation.png)

## **Set Custom Rotation for Text Frames**

استخدم [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_rotationangle/) لتعيين زاوية دوران مخصَّصة لإطار [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/).

يدور مثال الشيفرة أدناه إطار النص 3 درجات باتجاه عقرب الساعة داخل الشكل:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The custom text rotation](custom_text_rotation.png)

## **Set Line Spacing of Paragraphs**

يوفر Aspose.Slides [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_spaceafter/)، [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_spacebefore/)، و [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_spacewithin/) للتحكم في تباعد الفقرات. تُستَخدم هذه الطرق كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

يوضح مثال الشيفرة التالي كيفية تحديد تباعد السطر داخل الفقرة:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The line spacing within the paragraph](line_spacing.png)

## **Set Autofit Type for Text Frames**

يحدد [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_autofittype/) كيف يتصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم ما إذا كان النص سيُصغر، سيُفيض، أو سيُعيد تحجيم الشكل تلقائيًا.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

لحساب عدد الأسطر بعد الالتفاف التلقائي ورؤية كيف يتغيّر عرض النص أو الشكل، راجع [Count Rendered Lines](/slides/ar/cpp/manage-paragraph/). عدد الأسطر وحده لا يُظهر ما إذا كان النص يفيض عن حاويته.

## **Set Anchor of Text Frames**

يحدد [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_anchoringtype/) كيفية توضع النص عموديًا داخل الشكل، مثلًا في الأعلى أو الوسط أو الأسفل.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAnchorType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Set Text Tabulation**

استخدم [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) و [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/get_tabs/) لتكوين مسافات تبويب في الفقرة.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITabCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TabAlignment.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![The paragraph tabs](paragraph_tabs.png)

## **Set Proofing Language**

يوفر Aspose.Slides [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_languageid/)، والذي يتيح لك تعيين لغة التدقيق لجزء نص. تحدد لغة التدقيق اللغة المستخدمة في فحص الإملاء والقواعد في PowerPoint.

يعرض مثال الشيفرة التالي كيفية تعيين لغة التدقيق لجزء نص:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
auto portionFormat = textPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

// Set the Id of a proofing language.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Set Default Language**

استخدم [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Add a new rectangle shape with text.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Check the first portion language.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **Set Default Text Style**

لتطبيق تنسيق نص افتراضي على مستوى العرض، استخدم [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_defaulttextstyle/).

يعرض مثال الشيفرة التالي كيفية تعيين خط غامق افتراضي بحجم 14 نقطة لجميع النصوص عبر الشرائح في عرض تقديمي جديد.

```cpp
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

// احصل على تنسيق الفقرة المستوى الأعلى.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    auto defaultPortionFormat = paragraphFormat->get_DefaultPortionFormat();
    defaultPortionFormat->set_FontHeight(14.0f);
    defaultPortionFormat->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Extract Text with the All-Caps Effect**

في PowerPoint، يؤدي تطبيق تأثير **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى وإن تم كتابته أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، افحص [TextCapType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textcaptype/) وحوِّل السلسلة المرتجعة إلى أحرف كبيرة عندما تكون القيمة [TextCapType::All](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textcaptype/).

لنفترض أن لدينا مربع نص التالي على الشريحة الأولى من ملف sample2.pptx.

![The All Caps effect](all_caps_effect.png)

يعرض مثال الشيفرة أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextCapType.h>
#include <system/console.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

auto originalText = textPortion->get_Text();
System::Console::WriteLine(u"Original text: " + originalText);

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto uppercaseText = originalText.ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + uppercaseText);
}

presentation->Dispose();
```

الإخراج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**How to modify text in a table on a slide?**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/). قم بالتكرار عبر الخلايا وحدث كل خلية عبر [ICell::get_TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icell/get_textframe/) وتنسيق الفقرة عبر [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/get_paragraphformat/).

**How to apply gradient color to text in a PowerPoint slide?**

لتطبيق لون تدرج على النص، استخدم [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/get_fillformat/). عيّن [IFillFormat::set_FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformat/set_filltype/) إلى [FillType::Gradient](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) و‑ configure the gradient stops, direction, and transparency.