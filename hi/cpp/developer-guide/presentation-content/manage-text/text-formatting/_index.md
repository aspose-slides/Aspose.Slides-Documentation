---
title: C++ में प्रस्तुति पाठ को स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/cpp/text-formatting/
keywords:
- अनुच्छेद संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घुमाव
- घुमाव कोण
- पाठ फ्रेम
- लाइन स्पेसिंग
- ऑटोफ़िट गुण
- पाठ फ्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण और अधिक को कस्टमाइज़ करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतीकरण में पाठ को स्वरूपित करने के तरीके को दिखाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर स्पेसिंग, फ़ॉन्ट गुण, घुमाव, अनुच्छेद स्पेसिंग, ऑटोफ़िट व्यवहार, पाठ एंकरिंग, टैब स्टॉप, और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा नहीं कहा गया हो, उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। इसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसके पहले अनुच्छेद में नीचे दिखाया गया पाठ होता है। स्लाइड और आकार दोनों के सूचकांक शून्य-आधारित हैं। जो उदाहरण मोटे भागों को चुनते हैं वे प्रभावी स्वरूपण का उपयोग करते हैं, जिसमें विरासत में मिला मोटा स्वरूपण शामिल है:

![नमूना पाठ](sample_text.png)

पाठ खोजें और बदलें: [Search and Replace Text](/slides/hi/cpp/search-and-replace-text/).

## **पाठ पृष्ठभूमि रंग सेट करें**

एक अनुच्छेद के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) का उपयोग करें, या व्यक्तिगत पाठ भागों के लिए [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) का उपयोग करें।

निम्नलिखित उदाहरण पहले अनुच्छेद के लिए डिफ़ॉल्ट रूप में हल्का धूसर हाइलाइट सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेते हैं:

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

// पूरे अनुच्छेद के लिए हाइलाइट रंग सेट करें।
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![धूसर अनुच्छेद](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **मोटे फ़ॉन्ट वाले पाठ भागों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाता है:

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
        // टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें।
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![धूसर पाठ भाग](gray_text_portions.png)

## **पाठ अनुच्छेद संरेखित करें**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) का उपयोग करके टेक्स्ट फ़्रेम के भीतर अनुच्छेद संरेखण सेट करें। मान केंद्रित, बाएँ-संरेखित, दाएँ-संरेखित, न्यायसंगत आदि हो सकता है।

निम्नलिखित कोड उदाहरण दिखाता है कि **केंद्र** में अनुच्छेद कैसे संरेखित किया जाए:

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

// अनुच्छेद का संरेखण केंद्र में सेट करें।
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![संरेखित अनुच्छेद](aligned_paragraph.png)

## **पंक्ति के भीतर फ़ॉन्ट संरेखित करें**

[IParagraphFormat::set_FontAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_fontalignment/) का उपयोग करके पंक्ति में विभिन्न फ़ॉन्ट आकारों के पाठ भागों को उर्ध्वाधर रूप से संरेखित करें। यह सेटिंग पूरे अनुच्छेद पर लागू होती है और प्रत्येक पंक्ति में संरेखण को नियंत्रित करती है।

निम्नलिखित स्व-निहित उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक अनुच्छेद में 18, 36, और 54 पॉइंट के समान पाठ होते हैं, विभिन्न फ़ॉन्ट संरेखण के साथ। यह Arial का उपयोग करता है, ऑटोफ़िट और रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ्रेम को एक पंक्ति के लिए पर्याप्त बड़ा रखता है।

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

![बेसलाइन, टॉप, सेंटर और बॉटम फ़ॉन्ट संरेखण की तुलना (मिश्रित फ़ॉन्ट आकार)](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक का उपयोग करता है, इसलिए व्यक्तिगत अक्षरों के दृश्य किनारे जरूरी नहीं कि बिल्कुल मिलें। उदाहरण में बड़े अक्षर और नीचे की ओर जाने वाला भाग दोनों शामिल हैं ताकि बेसलाइन और बॉटम संरेखण के अंतर को दिखाया जा सके। फ़ॉन्ट उपलब्धता और प्रतिस्थापन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकारों में अंतर परिणाम को प्रभावित करते हैं। फ्रेम आयाम, मार्जिन, लाइन स्पेसिंग, रैपिंग और ऑटोफ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) से अलग है, जो क्षैतिज अनुच्छेद संरेखण को नियंत्रित करता है, और [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) से भी अलग है, जो आकार के भीतर पाठ ब्लॉक को ऊर्ध्वाधर रूप से स्थित करता है। सुपरस्क्रिप्ट और सबस्क्रिप्ट स्वरूपण [IBasePortionFormat::set_Escapement](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_escapement/) के माध्यम से व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करता है, बजाय पैराग्राफ की पंक्तियों के लिए फ़ॉन्ट संरेखण सेट करने के।

## **पाठ की पारदर्शिता सेट करें**

पाठ पारदर्शिता को उस रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है जो [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) के द्वारा असाइन किया गया है। नीचे दिखाए गए उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-चैनल मान है, न कि प्रतिशत रूप में पारदर्शिता।

नीचे दिया गया कोड उदाहरण दिखाता है कि **पूरे अनुच्छेद** पर पारदर्शिता कैसे लागू की जाए:

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

// टेक्स्ट का भराव रंग पारदर्शी रंग में सेट करें।
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पारदर्शी अनुच्छेद](transparent_paragraph.png)

निम्नलिखित कोड उदाहरण दिखाता है कि **मोटे फ़ॉन्ट वाले पाठ भागों** पर पारदर्शिता कैसे लागू की जाए:

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
        // टेक्स्ट भाग की पारदर्शिता सेट करें।
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

![पारदर्शी पाठ भाग](transparent_text_portions.png)

## **पाठ के लिए अक्षर स्पेसिंग सेट करें**

[IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_spacing/) का उपयोग करके टेक्स्ट बॉक्स में अक्षरों के बीच स्पेसिंग को बढ़ाया या घटाया जा सकता है। उदाहरण 3 पॉइंट की स्पेसिंग जोड़ते हैं; नकारात्मक मान टेक्स्ट को घटाते हैं।

निम्नलिखित C++ कोड दिखाता है कि **पूरे अनुच्छेद** में अक्षर स्पेसिंग कैसे बढ़ाई जाए:

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
// ध्यान दें: अक्षर स्पेसिंग को संकुचित करने के लिये नकारात्मक मानों का उपयोग करें।
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // अक्षर स्पेसिंग बढ़ाएँ।

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![अनुच्छेद में अक्षर स्पेसिंग](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **मोटे फ़ॉन्ट वाले पाठ भागों** में अक्षर स्पेसिंग कैसे बढ़ाई जाए:

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
        // ध्यान दें: अक्षर स्पेसिंग को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
        portionFormat->set_Spacing(3.0f); // अक्षर स्पेसिंग बढ़ाएँ।
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पाठ भागों में अक्षर स्पेसिंग](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए कर्निंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए समान पाठ से थोड़ा अधिक कसकर दिखाई दे सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए कर्निंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध कर्निंग जानकारी हो और PowerPoint सेटिंग्स में कर्निंग सक्षम हो।

ऐसे मामलों में आउटपुट को PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले पाठ भागों के लिए कर्निंग अक्षम कर सकते हैं। [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) का उपयोग करके वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। यह उदाहरण "presentation.pptx" को आवश्यकता करता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स हो। यह प्रभावी फ़ॉन्ट नामों की जाँच करता है, जिसमें विरासत में मिला फ़ॉन्ट भी शामिल है, और Roboto का उपयोग करने वाले भागों के लिए 100‑पॉइंट थ्रेशोल्ड निर्धारित करता है। यह 100 पॉइंट से नीचे के फ़ॉन्ट आकार वाले मिलते भागों के लिए कर्निंग को अक्षम करता है:

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

थ्रेशोल्ड से नीचे के मिलते पाठ के लिए, यह सेटिंग कर्निंग को रोकती है और Aspose.Slides की रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण अनुच्छेद स्तर पर [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) के द्वारा या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/) के द्वारा सेट किए जा सकते हैं।

निम्नलिखित उदाहरण पहले अनुच्छेद की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, मोटा, इटैलिक और बिंदीदार रेखा वाले अंडरलाइन के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट स्वरूपण इन डिफ़ॉल्ट्स से प्राथमिकता लेता है:

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

// अनुच्छेद के लिए फ़ॉन्ट गुण सेट करें।
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

![अनुच्छेद के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्नलिखित उदाहरण 13‑पॉइंट Times New Roman, इटैलिक स्वरूपण और बिंदीदार अंडरलाइन को उन भागों पर लागू करता है जिनका प्रभावी स्वरूपण मोटा है:

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
        // पाठ भाग के लिए फ़ॉन्ट गुण सेट करें।
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

![पाठ भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ घुमाव सेट करें**

[ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_textverticaltype/) का उपयोग करके आकार के भीतर पूर्वनिर्धारित पाठ अभिविन्यास सेट किया जा सकता है।

निम्नलिखित कोड उदाहरण टेक्स्ट अभिविन्यास को [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/) पर सेट करता है, जो पाठ को **90 डिग्री वामावर्त** घुमा देता है:

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

![पाठ घुमाव](text_rotation.png)

## **पाठ फ्रेम के लिए कस्टम घुमाव सेट करें**

[ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) का उपयोग करके [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) के लिए कस्टम घुमाव कोण सेट किया जा सकता है।

निचले कोड उदाहरण आकार के भीतर पाठ फ्रेम को 3 डिग्री घड़ी की दिशा में घुमा देता है:

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

![कस्टम पाठ घुमाव](custom_text_rotation.png)

## **अनुच्छेदों की लाइन स्पेसिंग सेट करें**

Aspose.Slides [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/), और [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) प्रदान करता है ताकि अनुच्छेद स्पेसिंग को नियंत्रित किया जा सके। इन विधियों का प्रयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिये सकारात्मक मान का प्रयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिये नकारात्मक मान का प्रयोग करें।

निम्नलिखित उदाहरण पहली अनुच्छेद के भीतर स्पेसिंग को लाइन की ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

![अनुच्छेद के भीतर लाइन स्पेसिंग](line_spacing.png)

## **लाइन ब्रेकिंग नियंत्रित करें**

अनुच्छेद लाइन‑ब्रेकिंग नियम संकीर्ण टेक्स्ट ब्लॉकों और मिश्रित लैटिन एवं ईस्ट एशियन पाठ वाले प्रस्तुतियों में उपयोगी होते हैं। निम्नलिखित विधियां [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/) से संबंधित हैं, इसलिए वे पूरे अनुच्छेद पर लागू होती हैं:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) लैटिन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित पाठ में इसे बदलने से आस-पास के ईस्ट एशियन पाठ और विराम चिह्नों की रैपिंग भी बदल सकती है।
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) ईस्ट एशियन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षर प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। ये रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक अक्षर सम्मिलित नहीं करते। स्पष्ट लाइन‑ब्रेक उपलब्ध चौड़ाई से स्वतंत्र रूप से अनुच्छेद के भीतर नई पंक्ति बनाता है।

निम्नलिखित स्व-निहित उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन पाठ है। यह दोनों लाइन‑ब्रेकिंग नियमों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम के साथ प्रयोग करने के लिये, अन्य सेटिंग्स को स्थिर रखकर उसके सेटर को पास किया गया मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun को 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ उपयोग करता है। [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) को [TextAutofitType::None](https://reference.aspose.com/slides/cpp/aspose.slides/textautofittype/) के साथ बुलाया गया है ताकि पाठ आकार और फ्रेम आयाम स्थिर रहें।

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

## **हैंगिंग विराम चिह्न नियंत्रित करें**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) पात्र विराम चिह्न को पाठ पंक्ति के दाएँ किनारे से बाहर तक विस्तारित होने की अनुमति देता है, बजाय अगले पंक्ति में ले जाने के। यह पूरे अनुच्छेद पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्नलिखित स्व-निहित उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ्रेम में हैंगिंग विराम चिह्न को सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम पूर्ण विराम "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक विस्तारित होता है। तुलना के लिये [NullableBool::False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) को सेटर में पास करें: इन सेटिंग्स के साथ, पूर्ण विराम अलग पंक्ति में स्थित होता है। रैपिंग सक्षम है और ऑटोफ़िट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न हैंग नहीं कर सकता। ऊपर वर्णित [फ़ॉन्ट और लेआउट स्थितियाँ](#control-line-breaking) इस तुलना पर भी लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन, या ऑटोफ़िट सेटिंग्स बदलने से दृश्य अंतर हट सकता है।

## **पाठ फ्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) निर्धारित करता है कि जब पाठ कंटेनर की सीमाओं से बाहर हो तो वह कैसे व्यवहार करता है। इसका उपयोग यह नियंत्रित करने के लिये करें कि पाठ छोटा हो, ओवरफ़्लो हो, या आकार स्वचालित रूप से रिसाइज़ हो। निम्नलिखित उदाहरण आकार को उसके पाठ के अनुसार रिसाइज़ करने के लिये कॉन्फ़िगर करता है और परिणाम को "autofit_type.pptx" में सहेजता है।

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

ऑटोरैपिंग के बाद पंक्तियों की गिनती और यह देखने के लिये कि पाठ या आकार की चौड़ाई बदलने से परिणाम कैसे बदलता है, देखें [Count Rendered Lines](/slides/hi/cpp/manage-paragraph/)। केवल पंक्तियों की गिनती यह संकेत नहीं देती कि पाठ कंटेनर से बाहर निकल रहा है या नहीं।

## **पाठ फ्रेम का एंकर सेट करें**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) निर्धारित करता है कि आकार के भीतर पाठ को ऊर्ध्वाधर रूप से कैसे स्थित किया जाए, उदाहरण के लिये शीर्ष, मध्य या निचला भाग। निम्नलिखित उदाहरण पहले आकार के नीचे पाठ को एंकर करता है और परिणाम को "text_anchor.pptx" में सहेजता है।

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

## **पाठ टैबुलेशन सेट करें**

[IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) और [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_tabs/) का उपयोग करके अनुच्छेद में टैब स्टॉप कॉन्फ़िगर करें। निम्नलिखित उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब अक्षर वाले पाठ को प्रभावित करती हैं।

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

![अनुच्छेद टैब](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) प्रदान करता है, जिससे आप किसी पाठ भाग की प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिये उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्नलिखित उदाहरण को "presentation.pptx" की आवश्यकता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स हो और कम से कम एक अनुच्छेद हो। यह पहले अनुच्छेद की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरलित चीनी प्रूफिंग भाषा (`zh-CN`) असाइन करता है। परिणाम को "proofing_language.pptx" में सहेजता है:

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

// प्रूफ़िंग भाषा को सरलित चीनी में सेट करें।
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) का उपयोग करके प्रस्तुतीकरण लोड या बनाने के समय बनाए गए पाठ की डिफ़ॉल्ट भाषा निर्धारित करें। निम्नलिखित उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करके एक प्रस्तुतीकरण बनाता है, टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिये `en-US` प्रिंट करता है।

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

// एक नया आयताकार आकार पाठ के साथ जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// पहले भाग की भाषा जाँचें।
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रस्तुतीकरण स्तर पर डिफ़ॉल्ट टेक्स्ट स्वरूपण लागू करने के लिये, [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_defaulttextstyle/) का उपयोग करें।

निम्नलिखित उदाहरण नई प्रस्तुतीकरण में शीर्ष‑स्तर के अनुच्छेदों के लिये डिफ़ॉल्ट रूप में 14‑पॉइंट मोटा फ़ॉन्ट सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट स्वरूपण उन्हें ओवरराइड न करे।

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

// शीर्ष स्तर का पैराग्राफ फ़ॉर्मेट प्राप्त करें।
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

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से पाठ स्लाइड पर सभी बड़े अक्षरों में दिखता है, भले ही मूल रूप से छोटा लिखा गया हो। जब आप Aspose.Slides के साथ ऐसा भाग प्राप्त करते हैं, तो लाइब्रेरी पाठ को वही रूप में लौटाती है जैसा वह दर्ज किया गया था। दिखाए गए पाठ से मेल खाने के लिये, [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) की जाँच करें और जब मान [TextCapType::All](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में परिवर्तित करें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स हो। उसके पहले अनुच्छेद के पहले भाग में "Hello, Aspose!" है, जिस पर All Caps प्रभाव लागू है, जैसा कि नीचे दिखाया गया है।

![ऑल कैप्स प्रभाव](all_caps_effect.png)

निम्नलिखित कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू किए हुए पाठ को कैसे निकालें:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड पर तालिका में टेक्स्ट कैसे संशोधित करूँ?**

तालिका में टेक्स्ट संशोधित करने के लिये [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) का उपयोग करें। कोशिकाओं पर इटररेट करके प्रत्येक को [ICell::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) के माध्यम से अपडेट करें और पैराग्राफ स्वरूपण को [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) के द्वारा बदलें।

**मैं PowerPoint स्लाइड पर टेक्स्ट में ग्रेडिएंट रंग कैसे लागू करूँ?**

ग्रेडिएंट रंग लागू करने के लिये [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) का उपयोग करें। [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) को [FillType::Gradient](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा और पारदर्शिता को कॉन्फ़िगर करें।