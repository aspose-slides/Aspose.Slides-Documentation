---
title: C++ में प्रस्तुति पाठ को स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/cpp/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घूर्णन
- घूर्णन कोण
- पाठ फ्रेम
- लाइन स्पेसिंग
- ऑटॉफ़िट प्रॉपर्टी
- पाठ फ्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फॉर्मेट और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण और अधिक को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को कैसे स्वरूपित किया जाए। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटोफ़िट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

यदि अन्यथा नहीं कहा गया है, तो उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। उसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए पाठ को सम्मिलित करता है। स्लाइड और आकार दोनों के सूचक शून्य-आधारित होते हैं। ऐसे उदाहरण जो बोल्ड भाग चुनते हैं प्रभावी स्वरूपण का उपयोग करते हैं, जिसमें विरासत में मिला बोल्ड स्वरूपण शामिल है:

![नमूना पाठ](sample_text.png)

शाब्दिक पाठ या रेगुलर एक्सप्रेशन मिलान खोजने और हाइलाइट करने के लिए, देखें [पाठ खोजें और बदलें](/slides/hi/cpp/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

किसी पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) का प्रयोग करें, या व्यक्तिगत पाठ भागों के लिए [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए डिफ़ॉल्ट रूप में हल्का ग्रे हाइलाइट सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेते हैं:

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

// पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले पाठ भागों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

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
        // पाठ भाग के लिए हाइलाइट रंग सेट करें।
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![ग्रे पाठ भाग](gray_text_portions.png)

## **पाठ पैराग्राफ संरेखित करें**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) का उपयोग करके पाठ फ्रेम के भीतर पैराग्राफ संरेखण सेट करें। मान केंद्रित, बाएँ-समरेखित, दाएँ-समरेखित, समानांतर (जस्टिफ़ाइड) आदि हो सकता है।

निम्न कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

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
// पैराग्राफ की संरेखण को केंद्र पर सेट करें।

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **लाइन के भीतर फ़ॉन्ट संरेखित करें**

[IParagraphFormat::set_FontAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_fontalignment/) का उपयोग करके लाइन में विभिन्न फ़ॉन्ट आकारों के पाठ भागों को लंबवत रूप से संरेखित किया जा सकता है। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और उसकी प्रत्येक पंक्तियों के भीतर संरेखण नियंत्रित करती है।

निम्नलिखित स्व-समायोजित उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36 और 54 पॉइंट के समान पाठ होते हैं, प्रत्येक का फ़ॉन्ट संरेखण अलग होता है। यह Arial का उपयोग करता है, ऑटोफ़िट और रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ़्रेम को एकल लाइन के लिए पर्याप्त बड़ा रखता है।

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

![बेसलाइन, टॉप, सेंटर और बॉटम फ़ॉन्ट संरेखण (मिश्रित फ़ॉन्ट आकार)](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स का उपयोग करता है, इसलिए व्यक्तिगत अक्षरों के दिखाई देने वाले किनारे जरूरी नहीं कि बिल्कुल मिलें। उदाहरण में एक बड़े अक्षर और एक डीस्केंडर शामिल है जिससे बेसलाइन और बॉटम संरेखण के बीच अंतर दिखाया जा सके। फ़ॉन्ट उपलब्धता और प्रतिस्थापन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकार में अंतर परिणाम को प्रभावित करते हैं। फ्रेम आयाम, मार्जिन, लाइन स्पेसिंग, रैपिंग और ऑटोफ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय वही फ़ॉन्ट और लेआउट सेटिंग्स उपयोग करें।

यह सेटिंग [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) से अलग है, जो क्षैतिज पैराग्राफ संरेखण नियंत्रित करता है, और [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) से, जो आकार के भीतर पाठ ब्लॉक को ऊर्ध्वाधर रूप से स्थित करता है। [IBasePortionFormat::set_Escapement](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_escapement/) द्वारा सुपरस्क्रिप्ट और सबस्क्रिप्ट स्वरूपण व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करता है, बजाय पैराग्राफ की लाइनों के लिए फ़ॉन्ट संरेखण सेट करने के।

## **पाठ के लिए पारदर्शिता सेट करें**

पाठ की पारदर्शिता उस रंग के अल्फा घटक द्वारा नियंत्रित होती है जो [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) के माध्यम से असाइन किया गया है। नीचे दिए गए उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर पारदर्शिता कैसे लागू की जाए:

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

// पाठ का भराव रंग पारदर्शी रंग में सेट करें।
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले पाठ भागों** पर पारदर्शिता कैसे लागू की जाए:

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
        // पाठ भाग की पारदर्शिता सेट करें।
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

## **पाठ के लिए अक्षर अंतराल सेट करें**

पाठ बॉक्स में अक्षरों के बीच की दूरी बढ़ाने या घटाने के लिए [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_spacing/) का उपयोग करें। उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान पाठ को घटाते हैं।

निम्न C++ कोड दिखाता है कि **पूरा पैराग्राफ** में अक्षर अंतराल कैसे बढ़ाया जाए:

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

// ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // अक्षर अंतराल बढ़ाएँ.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले पाठ भागों** में अक्षर अंतराल कैसे बढ़ाया जाए:

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
        // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें.
        portionFormat->set_Spacing(3.0f); // अक्षर अंतराल बढ़ाएँ.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पाठ भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए कर्निंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए पाठ से थोड़ा कसा हुआ लग सकता है। ऐसा इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए कर्निंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में मान्य कर्निंग जानकारी हो और PowerPoint सेटिंग्स में कर्निंग सक्षम हो।

ऐसे मामलों में रेंडर किए गए आउटपुट को PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले पाठ भागों के लिए कर्निंग अक्षम कर सकते हैं। वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करने के लिए [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) का उपयोग करें। यह उदाहरण "presentation.pptx" की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स हो। यह प्रभावी फ़ॉन्ट नामों की जाँच करता है, जिसमें विरासत में मिलने वाले फ़ॉन्ट भी शामिल हैं, और Roboto का उपयोग करने वाले भागों के लिए 100 पॉइंट की सीमा निर्धारित करता है। यह 100 पॉइंट से कम फ़ॉन्ट आकार वाले मेल खाते भागों के लिए कर्निंग अक्षम करता है:

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

सीमा से नीचे के मेल खाते पाठ के लिए, यह सेटिंग कर्निंग को रोकती है और Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है, उन फ़ॉन्ट्स के लिए जो इस PowerPoint-विशिष्ट व्यवहार से प्रभावित होते हैं।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) के माध्यम से या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न उदाहरण पहले पैराग्राफ का डिफ़ॉल्ट फ़ॉन्ट 12 पॉइंट Times New Roman सेट करता है, जिसमें बोल्ड, इटैलिक और डॉटेड अंडरलाइन स्वरूपण शामिल है। व्यक्तिगत भागों पर स्पष्ट स्वरूपण इन डिफ़ॉल्ट्स पर प्राथमिकता लेता है:

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

// पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
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

निम्न उदाहरण 13 पॉइंट Times New Roman, इटैलिक स्वरूपण और डॉटेड अंडरलाइन को उन भागों पर लागू करता है जिनका प्रभावी स्वरूपण बोल्ड है:

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

## **पाठ ऊँचाई सामान्यीकरण नियंत्रित करें**

[IBasePortionFormat::set_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_normaliseheight/) का उपयोग तब करें जब टेम्पलेट टाइपोग्राफी दोहराते हों या अक्षर ऊँचाई में अंतर की जाँच करते हों। PowerPoint में, सामान्यीकरण को सक्षम करने से व्यक्तिगत अक्षरों को ऊर्ध्वर रूप से खींचा या संकुचित किया जाता है ताकि वे टेक्स्ट भाग के भीतर समान दृश्यमान ऊँचाई प्राप्त कर सकें। यह विभिन्न फ़ॉन्ट्स में समान टेक्स्ट ऊँचाई की गारंटी नहीं देता।

संपत्ति को [NullableBool::True या False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) पर सेट करके स्पष्ट रूप से सामान्यीकरण सक्षम या अक्षम करें। `NullableBool::NotDefined` स्थानीय सेटिंग को अनसेट छोड़ देता है ताकि भाग पैराग्राफ के [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) से मान विरासत में ले सके। इसका अर्थ `False` नहीं है। [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) का उपयोग करके और [IBasePortionFormatEffectiveData::get_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformateffectivedata/get_normaliseheight/) को पढ़कर निर्धारित बूलियन मान प्राप्त करें।

निम्न स्व-समायोजित उदाहरण के लिए **Arial** स्थापित होना आवश्यक है। यह 54 पॉइंट पर एक ही बड़े अक्षरों, छोटे अक्षरों, डीस्केंडर और उच्चारण चिह्नों वाले दो टेक्स्ट ब्लॉक बनाता है। दोनों पैराग्राफ डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम करते हैं। शीर्ष भाग स्पष्ट रूप से इसे अक्षम करता है; निचला भाग इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और पैराग्राफ स्पेसिंग समान हैं, रैपिंग और ऑटोफ़िट अक्षम हैं ताकि तुलना निरंतर रहती है। उदाहरण `False: False` और `NotDefined: True` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है:

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

नीचे दिया गया तुलना सहेजी गई प्रस्तुति से निर्यात किया गया था। शीर्ष पंक्ति में सामान्यीकरण अक्षम है (`False`); निचली पंक्ति में सक्षम सेटिंग विरासत में मिली है (`NotDefined` → `True`)। इस दृश्य को पुन: उत्पन्न करने के लिए Arial स्थापित रखें।

![Arial 54‑पॉइंट टेक्स्ट (ऊपर सामान्यीकरण अक्षम, नीचे विरासत में मिला सामान्यीकरण सक्षम)](text_height_normalization.png)

सामान्यीकरण अक्षर की ऊँचाई बदलता है बिना असाइन किए गए [IBasePortionFormat::get_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fontheight/) मान को बदले, जो फ़ॉन्ट आकार पॉइंट में निर्दिष्ट करता है। पैराग्राफ [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) लाइन स्पेसिंग नियंत्रित करता है, जबकि टेक्स्ट-फ़्रेम [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) निर्धारित करता है कि टेक्स्ट या उसका कंटेनर कैसे फिट हो। ये सेटिंग्स अलग उद्देश्य रखती हैं और लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ स्वरूपण और विरासत के बारे में अधिक जानकारी के लिए, देखें [Manage Paragraph](/slides/hi/cpp/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू करें और हटाएँ**

[IBasePortionFormat::set_StrikethroughType](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_strikethroughtype/) का उपयोग करके आप पाठ भाग पर सुधार, रद्द किए गए शब्द या पूर्व कीमतों को मूल पाठ हटाए बिना प्रदर्शित कर सकते हैं। इसे [TextStrikethroughType::Single या Double](https://reference.aspose.com/slides/cpp/aspose.slides/textstrikethroughtype/) पर सेट करने से टेक्स्ट पर एक या दो रेखाएँ लगती हैं।

स्ट्राइकथ्रू हटाने के लिए, `TextStrikethroughType::None` असाइन करें। यह स्पष्ट रूप से प्रभाव को अक्षम करता है, चाहे आसपास का स्वरूपण स्ट्राइकथ्रू निर्दिष्ट करे या नहीं। इसके विपरीत, `TextStrikethroughType::NotDefined` स्थानीय सेटिंग को अनडिफ़ाइंड छोड़ देता है, जिससे भाग पैराग्राफ आदि से स्वरूपण विरासत में लेता है। इससे यह गारंटी नहीं होती कि स्ट्राइकथ्रू हट गया है। परिणामस्वरूप स्वरूपण, जिसमें विरासत में मिले मान शामिल हैं, पढ़ने के लिए [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) का उपयोग करें।

निम्न स्व-समायोजित उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पूर्व कीमत और वर्तमान कीमत के लिए अलग-अलग भाग होते हैं, इसलिए केवल पूर्व कीमत प्रभावित होती है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; अन्य पंक्तियों में क्रमशः सिंगल और डबल स्ट्राइकथ्रू रहता है। इस गुण को बदलने से टेक्स्ट और इसके अन्य स्वरूपण, सहित बोल्ड पूर्व कीमत, संरक्षित रहती है।

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

// स्ट्राइकथ्रू लागू करें, फिर पहले पूर्व कीमत से इसे स्पष्ट रूप से हटाएँ।
auto firstPriceFormat = textFrame->get_Paragraph(0)->get_Portion(1)->get_PortionFormat();
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::Single);
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::None);

textFrame->get_Paragraph(1)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Single);
textFrame->get_Paragraph(2)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Double);

presentation->Save(u"strikethrough.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम, ऊपर से नीचे: कोई स्ट्राइकथ्रू नहीं, सिंगल स्ट्राइकथ्रू, और डबल स्ट्राइकथ्रू।

![स्ट्राइकथ्रू बिना, सिंगल स्ट्राइकथ्रू, डबल स्ट्राइकथ्रू वाली पूर्व कीमतें](strikethrough.png)

## **पाठ घूर्णन सेट करें**

[ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_textverticaltype/) का उपयोग करके आकार के भीतर एक पूर्वनिर्धारित पाठ अभिविन्यास सेट करें।

निम्न कोड उदाहरण आकार में पाठ अभिविन्यास को [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/) पर सेट करता है, जो पाठ को **90 डिग्री विरुद्ध दिशा में** घुमाता है:

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

![पाठ घूर्णन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) का उपयोग करके एक [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) के लिए कस्टम घूर्णन कोण सेट करें।

नीचे दिया गया कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

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

![कस्टम टेक्स्ट घूर्णन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides निम्न मेथड्स प्रदान करता है: [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/), और [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/)। इनका उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहली पैराग्राफ के भीतर स्पेसिंग को लाइन ऊँचाई के 200% (डबल स्पेसिंग) पर सेट करता है:

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

## **लाइन ब्रेキング नियंत्रित करें**

पैराग्राफ लाइन-ब्रेकिंग नियम संकीर्ण टेक्स्ट ब्लॉक्स और लैटिन तथा ईस्ट एशियन पाठ मिश्रित प्रस्तुतियों में उपयोगी होते हैं। निम्न मेथड्स [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/) के अंतर्गत आते हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) लैटिन लाइन-ब्रेकिंग नियम नियंत्रित करता है। मिश्रित पाठ में इसे बदलने से पड़ोसी ईस्ट एशियन पाठ और विराम चिह्नों के रैपिंग बिंदु भी बदल सकते हैं।
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) ईस्ट एशियन लाइन-ब्रेकिंग नियम नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग सक्षम करता है। ये रैपिंग होने पर लेआउट को प्रभावित करते हैं; ये लाइन‑ब्रेक अक्षर नहीं डालते। एक स्पष्ट लाइन‑ब्रेक उपलब्ध चौड़ाई से स्वतंत्र रूप से पैराग्राफ के भीतर नई पंक्ति बनाता है।

निम्न स्व-समायोजित उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन पाठ मिश्रित हैं। यह दोनों लाइन‑ब्रेकिंग नियम स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम के साथ प्रयोग करने के लिए, उसका मान बदलें जबकि अन्य सेटिंग्स को अपरिवर्तित रखें। उदाहरण 24‑पॉइंट Arial और SimSun को 160‑पॉइंट फ़्रेम चौड़ाई तथा शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ उपयोग करता है। [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) को [TextAutofitType::None](https://reference.aspose.com/slides/cpp/aspose.slides/textautofittype/) के साथ बुलाया जाता है ताकि पाठ आकार और फ़्रेम आयाम स्थिर रहें।

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

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) योग्य विराम चिह्नों को टेक्स्ट पंक्ति के दाएँ किनारे से बाहर तक विस्तारित करने की अनुमति देता है, बजाय अगले पंक्ति में बैठने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्व-समायोजित उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ़्रेम में हैंगिंग विराम चिह्न सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ किनारे से बाहर तक विस्तारित होता है। तुलना के लिए सेट करने के लिए [NullableBool::False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) पास करें: इन सेटिंग्स के साथ बिंदु अलग पंक्ति ले लेता है। रैपिंग सक्षम है और ऑटोफ़िट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न हैंग नहीं सकता। ऊपर वर्णित [फ़ॉन्ट और लेआउट स्थितियाँ](#control-line-breaking) भी इस तुलना पर लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफ़िट सेटिंग्स बदलने से दृश्यमान अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) यह निर्धारित करता है कि कंटेनर की सीमाओं से अधिक होने पर पाठ कैसे व्यवहार करता है। इसका उपयोग करके आप तय कर सकते हैं कि पाठ छोटा हो, ओवरफ़्लो हो या आकार स्वचालित रूप से पुनः आकारित हो। निम्न उदाहरण आकार को उसके पाठ के अनुसार पुनः आकारित करता है और परिणाम को "autofit_type.pptx" में सहेजता है:

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

स्वचालित रैपिंग के बाद लाइनों की गिनती करने और देखना कि टेक्स्ट या आकार की चौड़ाई परिणाम को कैसे बदलती है, इसके लिए देखें [Count Rendered Lines](/slides/hi/cpp/manage-paragraph/). लाइन काउंट अकेले यह नहीं बताता कि टेक्स्ट कंटेनर से बाहर है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) यह निर्धारित करता है कि टेक्स्ट आकार के भीतर ऊर्ध्वाधर रूप से कैसे स्थित हो, जैसे शीर्ष, मध्य या निचला। निम्न उदाहरण टेक्स्ट को पहले आकार के निचले हिस्से में एंकर करता है और परिणाम को "text_anchor.pptx" में सहेजता है:

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

[IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) और [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_tabs/) का उपयोग करके पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर एक बाएँ‑समरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

```cpp
#include <DOM/IAutoShape>A
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITabCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include //? 
```

परिणाम:

![पैराग्राफ टैब](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) प्रदान करता है, जिससे आप किसी पाठ भाग के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा वह भाषा निर्धारित करती है जिसका उपयोग PowerPoint में वर्तनी और व्याकरण जांच के लिए किया जाता है।

निम्न उदाहरण "presentation.pptx" की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स हो और कम से कम एक पैराग्राफ हो। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, SimSun को फ़ॉन्ट सेट करता है, और सरलित चीनी प्रूफ़िंग भाषा (`zh-CN`) असाइन करता है। परिणाम को "proofing_language.pptx" में सहेजता है:

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


### **भाषा मेटाडाटा कॉपी करें**

जब टेम्पलेट से बहुभाषी पाठ को कॉपी करते हैं, तो दोनों भाषा पहचानकर्ताओं को [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) और [IBasePortionFormat::set_AlternativeLanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_alternativelanguageid/) के उपयोग से संरक्षित रखें। निम्न स्व-समायोजित उदाहरण स्रोत भाग बनाता है जिसका भाषा US English है और वैकल्पिक भाषा French है, तथा इन पहचानकर्ताओं को नई प्रस्तुति के एक भाग में कॉपी करता है:

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
// यदि स्रोत में कोई वैकल्पिक भाषा नहीं है, तो null स्ट्रिंग लक्ष्य मान को साफ़ कर देती है।
destination->get_PortionFormat()->set_AlternativeLanguageId(source->get_PortionFormat()->get_AlternativeLanguageId());
paragraph->get_Portions()->Add(destination);

presentation->Save(u"copied_language_metadata.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

वैकल्पिक भाषा के बिना स्रोत आज़माने के लिए, `u"fr-FR"` असाइनमेंट को छोड़ दें। वैकल्पिक पहचानकर्ता तब null स्ट्रिंग होगा, और वही कॉपी स्टेटमेंट इसकी अनुपस्थिति को बिना डिफ़ॉल्ट मान डाले संरक्षित रखेगा, भले ही गंतव्य में पहले वैकल्पिक भाषा असाइन की गई हो।

ये पहचानकर्ता भाषा मेटाडाटा के रूप में संग्रहीत होते हैं। इन्हें संरक्षित करने से यह नहीं तय होता कि PowerPoint वर्तनी या व्याकरण जांच के लिए कौन सा शब्दकोश चुनता है।

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) का उपयोग करके प्रस्तुति लोड या बनाते समय बनते पाठ की डिफ़ॉल्ट भाषा निर्धारित करें। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले पाठ भाग के लिए `en-US` प्रिंट करता है:

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

// नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// पहले भाग की भाषा जांचें।
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रेजेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट स्वरूपण लागू करने के लिए [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_defaulttextstyle/) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर पैराग्राफ़ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट रूप में सेट करता है और इसे "default_text_style.pptx" में सहेजता है। अधिक विशिष्ट स्वरूपण न होने तक पाठ इन डिफ़ॉल्ट्स को विरासत में ले सकता है।

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

// शीर्ष स्तर पैराग्राफ स्वरूप प्राप्त करें।
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

## **ऑल-कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से पाठ स्लाइड पर सभी बड़े अक्षरों में दिखाई देता है, भले ही वह मूल रूप से छोटे अक्षरों में टाईप किया गया हो। जब आप Aspose.Slides के साथ ऐसा पाठ भाग प्राप्त करते हैं, तो लाइब्रेरी उसी तरह का पाठ लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित पाठ से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) को जांचें और यदि मान [TextCapType::All](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) हो तो लौटाई गई स्ट्रिंग को अपर केस में परिवर्तित करें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स हो। उसके पहले पैराग्राफ के पहले भाग में "Hello, Aspose!" है, जिस पर All Caps प्रभाव लागू है, जैसा कि नीचे दिखाया गया है।

![ऑल-कैप्स प्रभाव](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू होने वाले पाठ को कैसे निकालें:

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

**मैं स्लाइड पर एक तालिका में पाठ को कैसे संशोधित करूँ?**

स्लाइड पर तालिका में पाठ को संशोधित करने के लिए [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करें और प्रत्येक कोशिका को [ICell::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) के माध्यम से अद्यतन करें तथा पैराग्राफ स्वरूपण को [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड पर पाठ पर ग्रेडिएंट रंग कैसे लागू करूँ?**

पाठ पर ग्रेडिएंट रंग लागू करने के लिए [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) का उपयोग करें। [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) को [FillType::Gradient](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा और पारदर्शिता को कॉन्फ़िगर करें।

संबंधित फीचर: [Format text within slides](/slides/hi/features/text-formatting/).