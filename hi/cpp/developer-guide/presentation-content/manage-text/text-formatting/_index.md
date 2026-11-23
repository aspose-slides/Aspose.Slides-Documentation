---
title: C++ में प्रस्तुति टेक्स्ट को फ़ॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/cpp/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घुमाव
- घुमाव कोण
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटोफ़िट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फॉर्मेट और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण और अन्य कई विकल्पों को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख दिखाता है कि PowerPoint और OpenDocument प्रस्तुतियों में Aspose.Slides for C++ का उपयोग करके टेक्स्ट को कैसे फॉर्मेट किया जाए। इसमें बैकग्राउंड रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घुमाव, पैराग्राफ अंतराल, ऑटोफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप, और भाषा सेटिंग्स शामिल हैं।

जब तक अन्यथा नहीं कहा गया हो, उदाहरण [sample.pptx](sample.pptx) का उपयोग किया गया है। उसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए टेक्स्ट को रखता है। स्लाइड और आकार दोनों के इंडेक्स शून्य‑आधारित हैं। जिन उदाहरणों में बोल्ड भाग चुने गए हैं, वे प्रभावी फॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिला बोल्ड फॉर्मेटिंग शामिल है:

![नमूना टेक्स्ट](sample_text.png)

शाब्दिक टेक्स्ट या नियमित अभिव्यक्ति मेल को खोजने और हाइलाइट करने के लिए देखें [Search and Replace Text](/slides/hi/cpp/search-and-replace-text/)।

## **टेक्स्ट बैकग्राउंड रंग सेट करें**

डिफ़ॉल्ट हाइलाइट रंग पैराग्राफ के लिए सेट करने हेतु [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए डिफ़ॉल्ट रूप से हल्का ग्रे हाइलाइट सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

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

// पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट भागों** के लिए बैकग्राउंड रंग कैसे सेट किया जाए, दर्शाता है:

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
        // टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![ग्रे टेक्स्ट भाग](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ को संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) का उपयोग करें। मान केंद्रित, बाएँ‑संरेखित, दाएँ‑संरेखित, समानांतर, आदि हो सकता है।

निम्न कोड उदाहरण **केंद्र** में पैराग्राफ संरेखित करने को दर्शाता है:

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

// पैराग्राफ का संरेखण केंद्र में सेट करें.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **एक पंक्ति में फ़ॉन्ट को संरेखित करें**

विभिन्न फ़ॉन्ट आकार वाले टेक्स्ट भागों को एक पंक्ति में ऊर्ध्वाधर रूप से संरेखित करने के लिए [IParagraphFormat::set_FontAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_fontalignment/) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक पंक्ति के भीतर संरेखण को नियंत्रित करती है।

निम्न स्व-निहित उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36 और 54 पॉइंट के समान टेक्स्ट होते हैं, विभिन्न फ़ॉन्ट संरेखण के साथ। यह Arial उपयोग करता है, ऑटोफ़िट और रैपिंग निष्क्रिय करता है, और टेक्स्ट फ्रेम को केवल एक लाइन के लिए पर्याप्त बड़ा रखता है।

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

परिणाम:

![Baseline, Top, Center, और Bottom फ़ॉन्ट संरेखण की तुलना (मिश्रित फ़ॉन्ट आकार)](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों के दृश्यमान किनारे आवश्यक रूप से बिल्कुल मेल नहीं खा सकते। उदाहरण में एक बड़े अक्षर और एक नीचे की ओर लटकने वाला अक्षर दोनों शामिल हैं ताकि बेसलाइन बनाम नीचे संरेखण के अंतर को दिखाया जा सके। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकार का अंतर परिणाम को प्रभावित करता है। फ्रेम आयाम, मार्जिन, लाइन स्पेसिंग, रैपिंग, और ऑटोफ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) से अलग है, जो क्षैतिज पैराग्राफ संरेखण नियंत्रित करता है, तथा [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) से भी अलग है, जो आकार के भीतर टेक्स्ट ब्लॉक को ऊर्ध्वाधर रूप से स्थित करता है। [IBasePortionFormat::set_Escapement](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_escapement/) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट फॉर्मेटिंग व्यक्तिगत भागों को बेसलाइन के सापेक्ष स्थानांतरित करती है, न कि पैराग्राफ की लाइनों के लिए फ़ॉन्ट संरेखण सेट करती है।

## **टेक्स्ट के लिए पारदर्शिता सेट करें**

पारदर्शिता को [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) के माध्यम से असाइन किए गए रंग के अल्फा घटक द्वारा नियंत्रित किया जाता है। नीचे दिए गए उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण **पूरे पैराग्राफ** पर पारदर्शिता लागू करने को दर्शाता है:

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

// टेक्स्ट का फिल रंग पारदर्शी रंग पर सेट करें.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट भागों** पर पारदर्शिता लागू करने को दर्शाता है:

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
        // टेक्स्ट भाग की पारदर्शिता सेट करें.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पारदर्शी टेक्स्ट भाग](transparent_text_portions.png)

## **टेक्स्ट के लिए अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरांतर को विस्तारित या घटाने के लिए [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_spacing/) का उपयोग करें। उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को सघन कर देते हैं।

निम्न C++ कोड **पूरे पैराग्राफ** में अक्षर अंतराल को विस्तारित करने को दर्शाता है:

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
// नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // अक्षर अंतराल बढ़ाएँ.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट भागों** में अक्षर अंतराल को विस्तारित करने को दर्शाता है:

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
        // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें.
        portionFormat->set_Spacing(3.0f); // अक्षर अंतराल बढ़ाएँ.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए करनिंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखने वाले टेक्स्ट से थोड़ा अधिक सघन लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए करनिंग डेटा को अनदेखा कर देता है, भले ही फ़ॉन्ट में वैध करनिंग जानकारी हो और PowerPoint सेटिंग्स में करनिंग सक्षम हो।

ऐसे मामलों में PowerPoint के समान रेंडरिंग प्राप्त करने के लिए, आप उन फ़ॉन्ट्स का उपयोग करने वाले टेक्स्ट भागों के लिए करनिंग निष्क्रिय कर सकते हैं। इससे बड़ा मान सेट करने के लिए [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) का उपयोग करें। यह उदाहरण "presentation.pptx" में पहले स्लाइड के पहले आकार के रूप में एक टेक्स्ट बॉक्स मानता है। यह प्रभावी फ़ॉन्ट नामों की जाँच करता है, जिसमें विरासत में मिले फ़ॉन्ट शामिल हैं, और Roboto उपयोग करने वाले भागों के लिए 100‑पॉइंट थ्रेशोल्ड सेट करता है। इससे 100 पॉइंट से कम फ़ॉन्ट आकार वाले मेल खाते भागों की करनिंग निष्क्रिय हो जाती है:

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

थ्रेशोल्ड से नीचे के मेल खाते टेक्स्ट के लिए, यह सेटिंग करनिंग को रोकती है और Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ अधिक करीब लाने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) के माध्यम से या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/) के माध्यम से सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट फॉर्मेटिंग इन डिफ़ॉल्ट पर प्राथमिकता लेती है:

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

// पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण प्रभावी फॉर्मेटिंग में बोल्ड होने वाले भागों पर 13‑पॉइंट Times New Roman, इटैलिक और डॉटेड अंडरलाइन लागू करता है:

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
        // टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें.
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![टेक्स्ट भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्पलेट टाइपोग्राफी को दोहराते समय या अक्षर ऊँचाई में अंतर की जाँच करते समय [IBasePortionFormat::set_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_normaliseheight/) का उपयोग करें। PowerPoint में, सामान्यीकरण को सक्षम करने से व्यक्तिगत अक्षर ऊर्ध्वाधर रूप से खिंचते या संकुचित होते हैं ताकि वे टेक्स्ट भाग के भीतर समान दृश्यमान ऊँचाई प्राप्त करें। यह विभिन्न फ़ॉन्ट्स के बीच समान टेक्स्ट ऊँचाई की गारंटी नहीं देता।

[NullableBool::True or False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) पर सेट करके आप स्पष्ट रूप से सामान्यीकरण को सक्षम या निष्क्रिय कर सकते हैं। `NullableBool::NotDefined` स्थानीय सेटिंग को अनसेट छोड़ता है ताकि भाग पैराग्राफ के [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) से विरासत में ले। इसका अर्थ `False` नहीं है। वास्तविक बूलियन मान प्राप्त करने के लिए [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) और [IBasePortionFormatEffectiveData::get_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformateffectivedata/get_normaliseheight/) का उपयोग करें।

निम्न स्व-निहित उदाहरण **Arial** स्थापित होने की आवश्यकता रखता है। यह दो टेक्स्ट ब्लॉक बनाता है जिनमें समान बड़े अक्षर, छोटे अक्षर, डिसेंडर और उच्चारण वाले अक्षर 54 पॉइंट पर होते हैं। दोनों पैराग्राफ डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम रखते हैं। ऊपर वाला भाग स्पष्ट रूप से इसे निष्क्रिय करता है; नीचे वाला भाग इसे विरासत में लेता है। फ्रेम आकार, मार्जिन, और पैराग्राफ अंतराल समान हैं, रैपिंग और ऑटोफ़िट निष्क्रिय हैं ताकि तुलना सटीक रहे। उदाहरण `False: False` और `NotDefined: True` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है।

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

नीचे का तुलना सहेजे गए प्रेज़ेंटेशन से एक्सपोर्ट किया गया है। ऊपर की पंक्ति में सामान्यीकरण निष्क्रिय (`False`) है; नीचे की पंक्ति में यह विरासत में मिला और सक्षम (`NotDefined` → `True`) है। इस रूप को पुन: बनाने के लिए Arial स्थापित रखें।

![Arial 54‑पॉइंट टेक्स्ट जिसमें ऊपर सामान्यीकरण निष्क्रिय और नीचे विरासत में प्राप्त सामान्यीकरण सक्षम है](text_height_normalization.png)

सामान्यीकरण फ़ॉन्ट ऊँचाई को बदले बिना [IBasePortionFormat::get_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fontheight/) मान को बदलता है, जो पॉइंट में फ़ॉन्ट आकार निर्दिष्ट करता है। पैराग्राफ [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) लाइन स्पेसिंग को नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) टेक्स्ट या उसके कंटेनर के आकार को समायोजित करता है। ये सेटिंग्स अलग‑अलग उद्देश्यों के लिए हैं और लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ फॉर्मेटिंग और विरासत के बारे में अधिक जानकारी के लिए देखें [Manage Paragraph](/slides/hi/cpp/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू और हटाएँ**

एक टेक्स्ट भाग पर स्ट्राइकथ्रू लागू करने के लिए [IBasePortionFormat::set_StrikethroughType](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_strikethroughtype/) का उपयोग करें, जिससे संशोधित, रद्द किए गए शब्द या पिछले मूल्य बिना मूल टेक्स्ट को हटाए दिखाए जा सकते हैं। इसे [TextStrikethroughType::Single or Double](https://reference.aspose.com/slides/cpp/aspose.slides/textstrikethroughtype/) पर सेट करके एक या दो रेखाएँ टेक्स्ट के ऊपर बन सकती हैं।

स्ट्राइकथ्रू हटाने के लिए `TextStrikethroughType::None` असाइन करें। यह प्रभाव को स्पष्ट रूप से निरस्त करता है, भले ही आसपास का फॉर्मेटिंग स्ट्राइकथ्रू निर्दिष्ट करता हो। इसके विपरीत, `TextStrikethroughType::NotDefined` स्थानीय सेटिंग को अनपरिभाषित छोड़ता है, जिससे भाग पैराग्राफ से विरासत में फॉर्मेटिंग ले सकता है। यह गारंटी नहीं देता कि स्ट्राइकथ्रू हट गया है। परिणामस्वरूप फॉर्मेटिंग, जिसमें विरासत मान शामिल हैं, पढ़ने के लिए [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) का उपयोग करें।

निम्न स्व‑निहित उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पूर्व कीमत, और वर्तमान कीमत के लिए अलग‑अलग भाग होते हैं, इसलिए केवल पूर्व कीमत प्रभावित होती है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; अन्य पंक्तियाँ क्रमशः एकल और डबल स्ट्राइकथ्रू रखती हैं। इस गुण को बदलने से टेक्स्ट और उसका अन्य फॉर्मेटिंग, जिसमें बोल्ड पूर्व कीमत शामिल है, संरक्षित रहता है।

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

// स्ट्राइकथ्रू लागू करें, फिर पहले पिछले मूल्य से इसे स्पष्ट रूप से हटाएँ.
auto firstPriceFormat = textFrame->get_Paragraph(0)->get_Portion(1)->get_PortionFormat();
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::Single);
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::None);

textFrame->get_Paragraph(1)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Single);
textFrame->get_Paragraph(2)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Double);

presentation->Save(u"strikethrough.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम, ऊपर से नीचे: कोई स्ट्राइकथ्रू नहीं, एकल स्ट्राइकथ्रू, और डबल स्ट्राइकथ्रू।

![पहले मूल्य बिना स्ट्राइकथ्रू, एकल स्ट्राइकथ्रू, और डबल स्ट्राइकथ्रू के साथ](strikethrough.png)


## **टेक्स्ट घुमाव सेट करें**

एक आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_textverticaltype/) का उपयोग करें।

निम्न कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/) पर सेट करता है, जिससे टेक्स्ट **90 डिग्री एंटिक्लॉकवाइज** घुम जाता है:

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

परिणाम:

![टेक्स्ट घुमाव](text_rotation.png)

## **वर्टिकल टेक्स्ट में अंकों को साइड‑बाय‑साइड दिखाएँ**

वर्टिकल जापानी लेबल में दो-अंकीय संख्या को साथ में रखने के लिए, दोनों अंकों को एक ही टेक्स्ट भाग में रखें और उस भाग पर [IBasePortionFormat::set_Kumimoji](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kumimoji/) को कॉल करें। यह उदाहरण दोनों लेबल के लिए [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/) और 40‑पॉइंट MS Gothic का उपयोग करता है। केवल संख्यात्मक भाग के लिए पास किया गया [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) मान अलग है।

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto addLabel = [&slide](float x, NullableBool kumimoji)
{
    auto label = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, 48, 120, 420);
    label->get_FillFormat()->set_FillType(FillType::NoFill);
    label->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto frame = label->AddTextFrame(u"");
    frame->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::EastAsianVertical);

    auto paragraph = frame->get_Paragraph(0);
    auto format = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    auto font = MakeObject<FontData>(u"MS Gothic");
    format->set_LatinFont(font);
    format->set_EastAsianFont(font);
    format->set_FontHeight(40);
    format->get_FillFormat()->set_FillType(FillType::Solid);
    format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    auto digits = MakeObject<Portion>(u"12");
    digits->get_PortionFormat()->set_Kumimoji(kumimoji);

    auto portions = paragraph->get_Portions();
    portions->Clear();
    portions->Add(MakeObject<Portion>(u"令和"));
    portions->Add(digits);
    portions->Add(MakeObject<Portion>(u"年"));
};

addLabel(120, NullableBool::True);
addLabel(360, NullableBool::False);

presentation->Save(u"vertical_date.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint में, बायाँ लेबल (`True`) अंकों को सीधे और साइड‑बाय‑साइड दिखाता है, जबकि दायाँ लेबल (`False`) अंकों को 90 डिग्री क्लॉकवाइज घुमाता है। दोनों लेबल में आसपास के जापानी अक्षर सीधे रहते हैं।

![वर्टिकल डेट लेबल्स की तुलना: बाएँ में सीधे अंक और दाएँ में घुमा हुआ अंक](vertical_date.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घुमाव सेट करें**

[ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) के लिए कस्टम घुमाव कोण सेट करें।

नीचे दिया गया कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइज घुमाता है:

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

परिणाम:

![कस्टम टेक्स्ट घुमाव](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides निम्न तरीकों से पैराग्राफ अंतराल नियंत्रित करता है: [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/), और [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/)। इनका उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहली पैराग्राफ की स्पेसिंग को लाइन ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

परिणाम:

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **लाइन‑ब्रेकिंग नियंत्रित करें**

पैराग्राफ लाइन‑ब्रेकिंग नियम संकीर्ण टेक्स्ट ब्लॉक और लैटिन व ईस्ट एशियन टेक्स्ट मिश्रित प्रस्तुतियों में उपयोगी होते हैं। निम्न विधियाँ [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/) से संबंध रखती हैं, इसलिए वे पूरे पैराग्राफ पर लागू होती हैं:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) लैटिन लाइन‑ब्रेकिंग नियम को नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से पड़ोसी ईस्ट एशियन टेक्स्ट और विराम चिह्नों के रैप पर भी असर पड़ सकता है।
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) ईस्ट एशियन लाइन‑ब्रेकिंग नियम को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षर प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। ये रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक अक्षर नहीं डालते। स्पष्ट लाइन‑ब्रेक उपलब्ध चौड़ाई से स्वतंत्र रूप से पैराग्राफ में नई पंक्ति बनाता है।

निम्न स्व‑निहित उदाहरण चीनी और लैटिन टेक्स्ट वाला एक संकीर्ण टेक्स्ट ब्लॉक बनाता है। यह दोनों लाइन‑ब्रेक नियम स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम को प्रयोग करने के लिए, उसके सेट्टर को पास किए गए मान को बदलें और अन्य सेटिंग्स को स्थिर रखें। यह उदाहरण 24‑पॉइंट Arial और SimSun, 160‑पॉइंट फ्रेम चौड़ाई, तथा शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ उपयोग करता है। [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) को [TextAutofitType::None](https://reference.aspose.com/slides/cpp/aspose.slides/textautofittype/) पर सेट किया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

## **हैंगिंग पंक्चुएशन नियंत्रित करें**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) पात्रों को टेक्स्ट लाइन के दाएँ किनारे से आगे बढ़ने की अनुमति देता है, बजाय अगले लाइन में जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्व‑निहित उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ्रेम में हैंगिंग पंक्चुएशन सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम अवधि "sentence" के बाद रहती है और दाएँ टेक्स्ट किनारे से बाहर निकलती है। तुलना के लिए सेट्टर को [NullableBool::False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) पास करें: इन सेटिंग्स के साथ, अवधि अलग पंक्ति में आती है। रैपिंग सक्षम है और उपलब्ध चौड़ाई को स्थिर रखने के लिए ऑटोफ़िट निष्क्रिय है।

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

हर पंक्चुएशन चिह्न हैंग नहीं कर सकता। ऊपर वर्णित [फ़ॉन्ट और लेआउट स्थितियाँ](#control-line-breaking) इस तुलना पर भी लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन, या ऑटोफ़िट सेटिंग बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमाओं से बाहर निकलने पर वह कैसे व्यवहार करता है। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि टेक्स्ट छोटा हो, अतिप्रवाह हो, या आकार को स्वचालित रूप से पुनः आकारित करे। निम्न उदाहरण आकार को उसके टेक्स्ट के अनुरूप रिसाइज़ करने के लिए कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है।

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

ऑटो‑रैपिंग के बाद लाइनों की गिनती और टेक्स्ट या आकार की चौड़ाई के बदलाव के परिणाम को देखने के लिए देखें [Count Rendered Lines](/slides/hi/cpp/manage-paragraph/)। केवल लाइनों की गिनती यह संकेत नहीं देती कि टेक्स्ट कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) आकार के भीतर टेक्स्ट को ऊर्ध्वाधर रूप से शीर्ष, मध्य या नीचे जैसी स्थिति में रखता है। निम्न उदाहरण पहले आकार के टेक्स्ट को नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

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

## **टेक्स्ट टैबुलेशन सेट करें**

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) और [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_tabs/) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑संकालित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

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

परिणाम:

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) प्रदान करता है, जिससे आप टेक्स्ट भाग की प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न उदाहरण के लिए "presentation.pptx" चाहिए, जिसमें पहली स्लाइड के पहले आकार पर एक टेक्स्ट बॉक्स है और कम से कम एक पैराग्राफ है। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और प्रूफिंग भाषा को Simplified Chinese (`zh‑CN`) असाइन करता है। परिणाम "proofing_language.pptx" में सहेजता है:

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

// प्रूफिंग भाषा को सरल चीनी पर सेट करें.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **भाषा मेटाडेटा कॉपी करें**

टेम्प्लेट से बहुभाषी टेक्स्ट कॉपी करते समय, दोनों भाषा पहचानकर्ता को [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) और [IBasePortionFormat::set_AlternativeLanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_alternativelanguageid/) के साथ सुरक्षित रखें। निम्न स्व‑निहित उदाहरण स्रोत भाग को US English भाषा और French वैकल्पिक भाषा के साथ बनाता है और इन पहचानकों को नई प्रस्तुति के एक भाग में कॉपी करता है।

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
// यदि स्रोत में वैकल्पिक भाषा नहीं है, तो null स्ट्रिंग गंतव्य मान को साफ़ करती है.
destination->get_PortionFormat()->set_AlternativeLanguageId(source->get_PortionFormat()->get_AlternativeLanguageId());
paragraph->get_Portions()->Add(destination);

presentation->Save(u"copied_language_metadata.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

वैकल्पिक भाषा के बिना स्रोत आज़माने के लिए, `u"fr-FR"` असाइनमेंट को छोड़ दें। वैकल्पिक पहचानकर्ता तब null स्ट्रिंग होगा, और वही कॉपी स्टेटमेंट उसकी अनुपस्थिति को डिफ़ॉल्ट मान जोड़े बिना बरकरार रखेगा, भले ही गंतव्य में पहले वैकल्पिक भाषा असाइन किया गया हो।

ये पहचानकर्ता भाषा मेटाडेटा के रूप में संग्रहीत होते हैं। उनका संरक्षण यह निर्धारित नहीं करता कि PowerPoint कौन-सा शब्दकोश वर्तनी या व्याकरण जाँच के लिए चुनता है।

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) का उपयोग करके प्रस्तुति लोड या बनाते समय बनाए गए टेक्स्ट की डिफ़ॉल्ट भाषा परिभाषित करें। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिए `en‑US` प्रिंट करता है।

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

// टेक्स्ट के साथ नया आयताकार आकार जोड़ें.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// पहले भाग की भाषा जाँचें.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रेज़ेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट फॉर्मेटिंग लागू करने के लिए [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_defaulttextstyle/) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर पैराग्राफ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट रूप से सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट को विरासत में ले सकता है, जब तक कि अधिक विशिष्ट फॉर्मेटिंग उन्हें ओवरराइड न करे।

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

// शीर्ष स्तर पैराग्राफ फॉर्मेट प्राप्त करें.
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

## **ऑल‑कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखाई देता है, भले ही मूल रूप से छोटे अक्षरों में टाइप किया गया हो। Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करने पर लाइब्रेरी मूल दर्ज किए गए टेक्स्ट को ही लौटाती है। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) की जाँच करें और जब मान [TextCapType::All](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) हो, तब लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड के पहले आकार पर एक टेक्स्ट बॉक्स है। उसके पहले पैराग्राफ के पहले भाग में **All Caps** प्रभाव लागू किया गया "Hello, Aspose!" होता है, जैसा कि नीचे दिखाया गया है।

![ऑल‑कैप्स प्रभाव](all_caps_effect.png)

निम्न कोड उदाहरण **All Caps** प्रभाव लागू होने के साथ टेक्स्ट निकालने को दर्शाता है:

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

आउटपुट:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**मैं स्लाइड पर तालिका में टेक्स्ट कैसे संशोधित करूँ?**

तालिका में टेक्स्ट संशोधित करने के लिए [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटरेट करें और प्रत्येक कोशिका को [ICell::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) तथा पैराग्राफ फ़ॉर्मेटिंग को [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड पर टेक्स्ट के लिए ग्रेडिएंट रंग कैसे लागू करें?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) का उपयोग करें। [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) को [FillType::Gradient](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, और पारदर्शिता को कॉन्फ़िगर करें।

संबंधित फीचर: [Format text within slides](/slides/hi/features/text-formatting/).