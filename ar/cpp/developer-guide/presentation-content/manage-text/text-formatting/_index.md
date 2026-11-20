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
- خاصية الملاءمة الذاتية
- مرساة إطار النص
- جدولة النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. خصّص الخطوط والألوان والمحاذاة والمزيد."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. وهي تغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة الذاتية، تثبيت النص، علامات التبويب، وإعدادات اللغة.

ما لم يُذكر خلاف ذلك، تستخدم الأمثلة [sample.pptx](sample.pptx). الشكل الأول في شريحةه الأولى هو مربع نص، والفقرة الأولى منه تحتوي على النص المعروض أدناه. كل من فهارس الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تختار أجزاءً عريضة تستخدم تنسيقًا فعالًا، بما في ذلك التنسيق العريض الموروث:

![نص تجريبي](sample_text.png)

للعثور على نص حرفي أو مطابقة تعبير عادي وإبرازها، راجع [البحث واستبدال النص](/slides/ar/cpp/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) لأجزاء النص الفردية.

المثال التالي يضبط تظليلًا رماديًا فاتحًا كافتراضي للفقرة الأولى. ألوان التظليل الصريحة في الأجزاء الفردية لها أولوية على هذا الافتراضي:

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

// اضبط لون التظليل للفقرة بأكملها.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

يُظهر مثال الشيفرة أدناه كيفية تعيين لون الخلفية **لأجزاء النص بخط عريض**:

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
        // اضبط لون التظليل للجزء النصي.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزة، محاذاة إلى اليسار، محاذاة إلى اليمين، مبررة، وما إلى ذلك.

المثال التالي يوضح كيفية محاذاة الفقرة إلى **المركز**:

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

// اضبط محاذاة الفقرة إلى المركز.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الفقرة المُحاذاة](aligned_paragraph.png)

## **محاذاة الخطوط داخل السطر**

استخدم [IParagraphFormat::set_FontAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_fontalignment/) لمواءمة أجزاء النص ذات أحجام الخط المختلفة عموديًا داخل سطر. ينطبق هذا الإعداد على الفقرة بأكملها ويتحكم في المحاذاة داخل كل سطر منها.

المثال التالي المستقل يُنشئ أربعة مربعات نص مُعنوَنة على شريحة واحدة. يحتوي كل فقرة على نفس النص بنقاط 18 و36 و54، مع محاذاة خط مختلفة. يستخدم الخط Arial، ويُعطل الملاءمة الذاتية واللف، ويجعل إطارات النص كبيرة بما يكفي لسطر واحد.

```cpp
#include <DOM/FontAlignment.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

FontAlignment alignments[] = { FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom };
String labels[] = { u"Baseline", u"Top", u"Center", u"Bottom" };
float fontSizes[] = { 18.0f, 36.0f, 54.0f };
auto font = MakeObject<FontData>(u"Arial");

for (auto i = 0; i < 4; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20 + i * 130, 660, 120);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);

    auto label = textFrame->get_Paragraph(0);
    label->set_Text(labels[i]);
    label->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto labelFormat = label->get_ParagraphFormat()->get_DefaultPortionFormat();
    labelFormat->set_FontHeight(14);
    labelFormat->set_LatinFont(font);
    labelFormat->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_FontAlignment(alignments[i]);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto portionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    portionFormat->set_LatinFont(font);
    portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
    portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    for (auto fontSize : fontSizes)
    {
        auto portion = MakeObject<Portion>(u"Ag ");
        portion->get_PortionFormat()->set_FontHeight(fontSize);
        paragraph->get_Portions()->Add(portion);
    }

    textFrame->get_Paragraphs()->Add(paragraph);
}

presentation->Save(u"font_alignment.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![مقارنة بين محاذاة Baseline وTop وCenter وBottom مع أحجام خطوط مختلطة](font_alignment.png)

محاذاة الخط تستخدم مقاييس الخط، لذا فإن الحواف الظاهرة للأحرف الفردية قد لا تتطابق تمامًا. يتضمن المثال حرفًا كبيرًا وحرفًا منخفضًا لتوضيح الفرق بين محاذاة القاعدة والسفلي. تتأثر النتيجة بتوفر الخط واستبداله، الأحرف المستخدمة، واختلاف أحجام الخطوط. كما تؤثر أبعاد الإطار والهوامش وتباعد الأسطر واللف والملاءمة الذاتية على التخطيط؛ استخدم نفس الخطوط وإعدادات التخطيط عند مقارنة الأنماط.

يختلف هذا الإعداد عن [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/)، الذي يتحكم في المحاذاة الأفقية للفقرة، وعن [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/)، الذي يحدد موضع كتلة النص عموديًا داخل الشكل. يغيّر تنسيق الأسطر العلوية والسفلية عبر [IBasePortionFormat::set_Escapement](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_escapement/) موضع الأجزاء الفردية بالنسبة للقاعدة بدلاً من ضبط محاذاة الخط لأسطر الفقرة.

## **تعيين الشفافية للنص**

تُتحكم شفافية النص عبر المكوّن ألفا للون المعين عبر [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

يُظهر مثال الشيفرة أدناه كيفية تطبيق الشفافية على **الفقرة بأكملها**:

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

// قم بتعيين لون تعبئة النص إلى لون شفاف.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

المثال التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص بخط عريض**:

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
        // قم بتعيين شفافية الجزء النصي.
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

![أجزاء النص الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_spacing/) لتوسيع أو تقليل التباعد بين الأحرف في مربع نص. تضيف الأمثلة 3 نقاط من التباعد؛ القيم السالبة تقلل النص.

المثال التالي بلغة C++ يُظهر كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

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

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

المثال أدناه يُظهر كيفية توسيع تباعد الأحرف في **أجزاء النص بخط عريض**:

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

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل التآلف للخطوط المحددة**

في بعض الحالات، قد يبدو النص المُصدَّر بواسطة Aspose.Slides أكثر ضيقًا قليلاً من النص نفسه المعروض في PowerPoint. يمكن أن يحدث هذا لأن PowerPoint قد يتجاهل بيانات التآلف لبعض الخطوط، حتى عندما يحتوي الخط على معلومات تآلف صالحة ويكون التآلف مفعَّلًا في إعدادات PowerPoint.

لتقريب المخرجات المُصدَّرة من مظهر PowerPoint في هذه الحالات، يمكنك تعطيل التآلف لأجزاء النص التي تستخدم الخط المتأثر. استخدم [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) لتعيين قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال ملف "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يتحقق من أسماء الخطوط الفعَّالة، بما في ذلك الخطوط الموروثة، ويضبط حدًا قدره 100 نقطة للأجزاء التي تستخدم خط Roboto. هذا يعطّل التآلف للأجزاء المطابقة ذات حجم الخط أقل من 100 نقطة:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
#include <DOM/IPortionFormatEffectiveData.h>
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
        auto textFormat = portionFormat->GetEffective();
        auto latinFont = textFormat->get_LatinFont();
        auto eastAsianFont = textFormat->get_EastAsianFont();
        auto complexScriptFont = textFormat->get_ComplexScriptFont();

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

للنص المطابق الذي يكون حجمه أقل من الحد، يمنع هذا الإعداد التآلف ويمكن أن يساعد على تقريب مخرجات Aspose.Slides من مظهر PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) أو على أجزاء فردية عبر [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/).

المثال التالي يضبط الخط الافتراضي للفقرة الأولى إلى 12 نقطة Times New Roman مع تنسيق عريض ومائل وتسطير منقط. يَسودُ التنسيق الصريح على الأجزاء الفردية هذه الإعدادات الافتراضية.

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

// اضبط خصائص الخط للفقرة.
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

![خصائص الخط للفقرة](font_properties_for_paragraph.png)

المثال التالي يطبق حجم 13 نقطة Times New Roman، وتنسيق مائل، وتسطير منقط على الأجزاء التي يكون تنسيقها الفعلي عريضًا:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection>
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
auto the                      auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions  ال     auto  int  portions  //  ??????



```

النتيجة:

![خصائص الخط لأجزاء النص](font_properties_for_text_portions.png)

## **التحكم في تسوية ارتفاع النص**

استخدم [IBasePortionFormat::set_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_normaliseheight/) عند إعادة إنتاج طباع القوالب أو فحص اختلافات ارتفاع الأحرف. في PowerPoint، يتيح تمكين التسوية تمديد أو ضغط الأحرف الفردية عموديًا لمنحها ارتفاع مرئي موحد داخل جزء النص. لا يضمن ذلك تساوي ارتفاع النص عبر خطوط مختلفة.

اضبط الخاصية إلى [NullableBool::True أو False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) لتمكين أو تعطيل التسوية صراحة. يبقى `NullableBool::NotDefined` دون ضبط محلي بحيث يرث الجزء قيمته، على سبيل المثال من [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/). لا يعني ذلك `False`. استخدم [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) واقرأ [IBasePortionFormatEffectiveData::get_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformateffectivedata/get_normaliseheight/) للحصول على القيمة المنطقية المحلولة.

المثال المستقل التالي يتطلب تثبيت **Arial**. ينشئ كتلتين نصيتين تحتوي كل منهما على نفس الأحرف الكبيرة والصغيرة، الأحرف السفلية، والحروف المشكَّلة بحجم 54 نقطة. كلتا الفقرتين تمكّنا التسوية بشكل افتراضي. الجزء العلوي يعطّلها صراحة؛ الجزء السفلي يرث الإعداد. أبعاد الإطارات والهوامش وتباعد الفقرات متطابقة، مع تعطيل اللف والملاءمة الذاتية للحفاظ على المقارنة متسقة. يطبع المثال `False: False` و`NotDefined: True`، ثم يحفظ "text_height_normalization.pptx".

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

NullableBool settings[] = { NullableBool::False, NullableBool::NotDefined };

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 60 + i * 200, 660, 150);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(u"Hxgjpq ÅÉ 0123");
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_MarginTop(0);
    textFrame->get_TextFrameFormat()->set_MarginLeft(0);

    auto paragraph = textFrame->get_Paragraph(0);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceBefore(0);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(0);
    paragraph->get_ParagraphFormat()->set_SpaceWithin(100);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_NormaliseHeight(NullableBool::True);

    auto portion = paragraph->get_Portion(0);
    auto font = MakeObject<FontData>(u"Arial");
    portion->get_PortionFormat()->set_LatinFont(font);
    portion->get_PortionFormat()->set_FontHeight(54);
    portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    portion->get_PortionFormat()->set_NormaliseHeight(settings[i]);

    Console::WriteLine(u"{0}: {1}", settings[i], portion->get_PortionFormat()->GetEffective()->get_NormaliseHeight());
}

presentation->Save(u"text_height_normalization.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

المقارنة أدناه تم تصديرها من العرض المحفوظ. الصف العلوي به تسوية معطَّلة (`False`); الصف السفلي يرث الإعداد المفعَّل (`NotDefined` → `True`). احتفظ بتثبيت Arial لإعادة إنتاج هذا المظهر.

![نص Arial بحجم 54 نقطة مع تسوية معطَّلة فوق وتسوية موروثة مفعَّلة أسفل](text_height_normalization.png)

تغيّر التسوية ارتفاع الأحرف دون تغيير القيمة المعينة لـ [IBasePortionFormat::get_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fontheight/) التي تحدد حجم الخط بالنقاط. يتحكم [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) في تباعد الأسطر، بينما يتحكم [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) في كيفية تعديل النص أو حاويته ليتناسب. تخدم هذه الإعدادات أغراضًا مختلفة ويمكن أن تؤثر على التخطيط الكلي بشكل مستقل. لمزيد من المعلومات حول تنسيق الفقرات والوراثة، راجع [إدارة الفقرات](/slides/ar/cpp/manage-paragraph/).

## **تطبيق وإزالة الخط عبر النص**

استخدم [IBasePortionFormat::set_StrikethroughType](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_strikethroughtype/) على جزء نص لعرض تصحيحات أو مصطلحات مُلغاة أو أسعار سابقة دون حذف النص الأصلي. اضبطه إلى [TextStrikethroughType::Single أو Double](https://reference.aspose.com/slides/cpp/aspose.slides/textstrikethroughtype/) لسطر واحد أو سطرين يعبران النص.

لإزالة الخط عبر النص، عيّن `TextStrikethroughType::None`. يعطل هذا التأثير صراحةً، حتى إذا كان التنسيق المحيط يحدده كخط عبر. بالمقابل، يترك `TextStrikethroughType::NotDefined` الإعداد المحلي غير معرف، مما يسمح للجزء بورث التنسيق، على سبيل المثال من الفقرة. لا يضمن ذلك إزالة الخط عبر. استخدم [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) لقراءة التنسيق الناتج، بما في ذلك القيم الموروثة.

المثال المستقل التالي يُنشئ ثلاث مقارنات أسعار. لكل فقرة أجزاء منفصلة للملصق، السعر السابق، والسعر الحالي، بحيث يتأثر السعر السابق فقط. الصف الأول يطبق ثم يزيل الخط عبر؛ الصفوف الأخرى تحتفظ بخط عبر واحد ومزدوج. يضمن تغيير هذه الخاصية إبقاء النص وتنسيقه الآخر، بما في ذلك الخط العريض للسعر السابق.

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextStrikethroughType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

String labels[] = { u"None: ", u"Single: ", u"Double: " };

for (auto label : labels)
{
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(20);

    auto format = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    format->set_FontHeight(28);
    auto font = MakeObject<FontData>(u"Arial");
    format->set_LatinFont(font);
    format->get_FillFormat()->set_FillType(FillType::Solid);
    format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    auto labelPortion = MakeObject<Portion>(label);
    paragraph->get_Portions()->Add(labelPortion);

    auto previousPrice = MakeObject<Portion>(u"$100");
    previousPrice->get_PortionFormat()->set_FontBold(NullableBool::True);
    paragraph->get_Portions()->Add(previousPrice);
    auto currentPrice = MakeObject<Portion>(u" → $80");
    paragraph->get_Portions()->Add(currentPrice);

    textFrame->get_Paragraphs()->Add(paragraph);
}

// تطبيق الخط عبر، ثم إزالته صراحةً من السعر السابق الأول.
auto firstPriceFormat = textFrame->get_Paragraph(0)->get_Portion(1)->get_PortionFormat();
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::Single);
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::None);

textFrame->get_Paragraph(1)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Single);
textFrame->get_Paragraph(2)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Double);

presentation->Save(u"strikethrough.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة من الأعلى إلى الأسفل: بلا خط عبر، خط عبر واحد، وخط عبر مزدوج.

![الأسعار السابقة بلا خط عبر، بخط عبر واحد، وبخط عبر مزدوج](strikethrough.png)


## **تعيين دوران النص**

استخدم [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_textverticaltype/) لتعيين اتجاه نص مُعرَّف مسبقًا داخل شكل.

المثال التالي يضبط اتجاه النص في الشكل إلى [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/)، والذي يدور النص **90 درجة عكس اتجاه عقارب الساعة**:

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

![دوران النص](text_rotation.png)

## **تعيين دوران مخصص لإطارات النص**

استخدم [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) لتحديد زاوية دوران مخصصة لإطار نصي ([ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)).

المثال أدناه يدور إطار النص بمقدار 3 درجات باتجاه عقارب الساعة داخل الشكل:

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

![الدوران المخصص للنص](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/)، [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/)، و[IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) للتحكم في تباعد الفقرات. تُستخدم هذه الطرق كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

المثال التالي يعيّن التباعد داخل الفقرة الأولى إلى 200% من ارتفاع السطر (تباعد مزدوج):

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

![تباعد الأسطر داخل الفقرة](line_spacing.png)

## **التحكم في كسر السطر**

قواعد كسر سطر الفقرة مفيدة في كتل النص الضيقة والعروض التي تمزج بين النص اللاتيني والنص الآسيوي الشرقي. تنتمي الطرق التالية إلى [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/)، لذا فهي تُطبق على الفقرة بأكملها:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) يتحكم في قواعد كسر السطر اللاتيني. في النص المختلط، قد يغيّر ذلك موضع النص الآسيوي الشرقي وعلامات الترقيم المجاورة.
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) يتحكم في قواعد كسر السطر الآسيوي الشرقي، بما في ذلك القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تحل محل [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/)، الذي يُفعِّل اللف التلقائي داخل إطار النص. إنها تؤثر على التخطيط عندما يحدث اللف؛ لا تُدرج أحرف كسر السطر. يُجبر كسر السطر الصريح على سطر جديد داخل الفقرة بغض النظر عن العرض المتاح.

المثال المستقل التالي يُنشئ كتلة نصية ضيقة تحتوي على نص صيني ولاتيني. يحدد قواعد كسر السطر لكل منهما صراحةً ويحفظ "line_breaking.pptx". لتجربة أي قاعدة، غيّر القيمة التي تُمرَّر إلى المُعيّن مع إبقاء الإعدادات الأخرى ثابتة. يستخدم المثال خط Arial 24 نقطة وSimSun بعرض إطار 160 نقطة وهوامش أفقية صفرية. يُستدعى [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) مع [TextAutofitType::None](https://reference.aspose.com/slides/cpp/aspose.slides/textautofittype/) لتثبيت حجم النص وأبعاد الإطار.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 160.0f, 300.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"中文排版测试，PowerPoint 中文演示。");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
auto eastAsianFont = System::MakeObject<FontData>(u"SimSun");
portionFormat->set_EastAsianFont(eastAsianFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_LatinLineBreak(NullableBool::False);
format->set_EastAsianLineBreak(NullableBool::True);

presentation->Save(u"line_breaking.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **التحكم في علامات الترقيم المتدلية**

يسمح [IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) للعلامات الترقيمية المؤهلة بأن تمتد إلى ما وراء الحافة اليمنى لسطر النص بدلاً من الانتقال إلى السطر التالي. ينطبق ذلك على الفقرة بأكملها ويختلف عن مسافة السطر المتدلية.

المثال المستقل التالي يُفعِّل علامات الترقيم المتدلية في إطار نص بعرض 100 نقطة ويحفظ "hanging_punctuation.pptx". باستخدام Arial 24 نقطة وهوامش أفقية صفرية، يبقى النقطة النهائية بعد كلمة "sentence" وتمتد إلى ما وراء حافة النص اليمنى. مرّر [NullableBool::False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) إلى المُعيّن للمقارنة: مع هذه الإعدادات، تحتل النقطة سطرًا منفصلًا. يُفعل اللف ويُعطل الملاءمة الذاتية لإبقاء العرض المتاح ثابتًا.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 200.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"Simple text, next sentence.");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_HangingPunctuation(NullableBool::True);

presentation->Save(u"hanging_punctuation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ليس كل علامة ترقيم يمكنها التعليق. تنطبق [الشروط المتعلقة بالخط والتخطيط الموضحة أعلاه](#control-line-breaking) على هذه المقارنة أيضًا: تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الملاءمة الذاتية قد يزيل الفرق المرئي.

## **تعيين نوع الملاءمة الذاتية لإطارات النص**

يحدد [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص يُصغَّر، يتجاوز، أو يُعيد تحجيم الشكل تلقائيًا. المثال التالي يضبط الشكل لإعادة التحجيم ليتناسب مع نصه ويحفظ النتيجة إلى "autofit_type.pptx".

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

لعدّ الأسطر بعد اللف التلقائي ورؤية كيفية تغيّر النص أو عرض الشكل للنتيجة، راجع [عدّ الأسطر المُعروضة](/slides/ar/cpp/manage-paragraph/). عدد الأسطر وحده لا يدل على ما إذا كان النص يتجاوز حاويته.

## **تعيين مرساة إطارات النص**

يحدد [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) كيفية وضع النص عموديًا داخل الشكل، مثلًا في الأعلى أو الوسط أو الأسفل. المثال التالي يرسخ النص إلى أسفل الشكل الأول ويحفظ النتيجة إلى "text_anchor.pptx".

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

## **تعيين جدولة النص**

استخدم [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) و[IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_tabs/) لتكوين نقاط التبويب في فقرة. المثال التالي يضبط الفاصل الافتراضي للتاب إلى 100 نقطة ويضيف نقطة تبويب محاذاة إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

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

![علامات تبويب الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/)، والتي تسمح لك بتعيين لغة التدقيق لجزء نص. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والقواعد في PowerPoint.

المثال التالي يتطلب ملف "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتوى الفقرة الأولى بـ "1。"، يضبط SimSun كخط لها، ويعيّن لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة إلى "proofing_language.pptx":

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

// اضبط لغة التدقيق إلى الصينية المبسطة.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **نسخ بيانات اللغة الوصفية**

عند نسخ نص متعدد اللغات من قالب، احفظ كلا معرفي اللغة باستخدام [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) و[IBasePortionFormat::set_AlternativeLanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_alternativelanguageid/). المثال المستقل التالي ينشئ جزء مصدر بلغة الإنجليزية الأمريكية كلغة أساسية والفرنسية كلغة بديلة، وينسخ النص والمعرفات إلى جزء في عرض تقديمي جديد.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto source = System::MakeObject<Portion>(u"Hello! Bonjour!");
source->get_PortionFormat()->set_LanguageId(u"en-US");
source->get_PortionFormat()->set_AlternativeLanguageId(u"fr-FR");

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto destination = System::MakeObject<Portion>();
destination->set_Text(source->get_Text());
destination->get_PortionFormat()->set_LanguageId(source->get_PortionFormat()->get_LanguageId());
// إذا لم يكن للمصدر لغة بديلة، فإن السلسلة الفارغة تمسح قيمة الوجهة.
destination->get_PortionFormat()->set_AlternativeLanguageId(source->get_PortionFormat()->get_AlternativeLanguageId());
paragraph->get_Portions()->Add(destination);

presentation->Save(u"copied_language_metadata.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

لتجربة مصدر بدون لغة بديلة، احذف تعيين `u"fr-FR"`. يصبح المعرف البديل سلسلة فارغة، وتُحافظ عبارة النسخ نفسها على غيابه دون إدخال قيمة افتراضية، حتى لو كان للوجهة لغة بديلة مُعينة مسبقًا.

تُخزن هذه المعرفات كبيانات لغة وصفية. الحفاظ عليها لا يحدد القاموس الذي تختاره PowerPoint لتدقيق الإملاء أو القواعد.

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) لتحديد اللغة الافتراضية للنص المُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي ينشئ عرضًا تقديميًا باللغة الإنجليزية الأمريكية كلغة نص افتراضية، يضيف مربع نص، ويطبع `en-US` لأول جزء نص فيه.

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

// أضف شكل مستطيل جديد مع نص.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// تحقق من لغة الجزء الأول.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض، استخدم [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_defaulttextstyle/).

المثال التالي يضبط خطًا عريضًا بحجم 14 نقطة كافتراضي للفقرات العليا في عرض تقديمي جديد ويحفظه إلى "default_text_style.pptx". يمكن للنص أن يرث هذه الإعدادات ما لم يُستبدل بتنسيق أكثر تحديدًا.

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

// احصل على تنسيق الفقرة من المستوى الأعلى.
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

## **استخراج النص مع تأثير الحروف الكبيرة**

في PowerPoint، يؤدي تطبيق تأثير الخط **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو كُتب أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما كُتب بالضبط. لمطابقة النص المعروض، افحص [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) وحوِّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة [TextCapType::All](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/).

يتطلب هذا المثال ملف "sample2.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.

![تأثير الحروف الكبيرة](all_caps_effect.png)

يُظهر مثال الشيفرة أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

## **أسئلة شائعة**

**كيف يمكنني تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). تجول عبر الخلايا وحدث كل خلية عبر [ICell::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) وتنسيق الفقرة عبر [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/).

**كيف يمكنني تطبيق لون متدرج على نص في شريحة PowerPoint؟**

لتطبيق لون متدرج على النص، استخدم [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/). اضبط [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) إلى [FillType::Gradient](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) و configure the gradient stops, direction, and transparency.

الميزة ذات الصلة: [تنسيق النص داخل الشرائح](/slides/ar/features/text-formatting/).