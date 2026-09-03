---
title: C++ का प्रयोग करके प्रस्तुतियों में टेक्स्ट बॉक्स को प्रबंधित करें
linktitle: टेक्स्ट बॉक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/cpp/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अपडेट करें
- टेक्स्ट बॉक्स बनाएं
- टेक्स्ट बॉक्स जांचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- PowerPoint
- प्रेज़ेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट बॉक्स बनाना, पहचानना, फॉर्मेट करना और अपडेट करना।"
---
## **परिचय**

Aspose.Slides for C++ में स्लाइड टेक्स्ट को टेक्स्ट फ्रेमों में संग्रहीत किया जाता है जो आकारों (shapes) से जुड़े होते हैं। [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) इंटरफ़ेस सबसे सामान्य टेक्स्ट‑धारक आकार को दर्शाता है और इसका टेक्स्ट [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/get_textframe/) मेथड के माध्यम से उपलब्ध कराता है।

{{% alert color="info" title="नोट" %}}

हर ऑटो शेप [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) को लागू करता है, लेकिन हर आकार ऑटो शेप नहीं होता या सभी में टेक्स्ट फ्रेम नहीं होता। किसी मौजूदा प्रेज़ेंटेशन को प्रोसेस करते समय, उसके टेक्स्ट तक पहुंचने से पहले यह जाँचें कि आकार [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) लागू करता है या नहीं।

{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाना**

टेक्स्ट बॉक्स बनाने के लिए, स्लाइड में एक ऑटो शेप जोड़ें, उसके टेक्स्ट फ्रेम में टेक्स्ट डालें, और प्रेज़ेंटेशन को सहेजें। निम्न उदाहरण एक आयताकार टेक्स्ट बॉक्स बनाता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

[IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addautoshape/) को पास किए गए निर्देशांक और आयाम पॉइंट्स में मापे जाते हैं। [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/addtextframe/) प्रदान किए गए टेक्स्ट से टेक्स्ट फ्रेम को प्रारंभ करता है।

## **टेक्स्ट बॉक्स आकार की जाँच**

किसी ऑटो शेप को टेक्स्ट बॉक्स माना जाता है या नहीं, यह निर्धारित करने के लिए [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/get_istextbox/) मेथड का उपयोग करें। यह तब उपयोगी होता है जब प्रेज़ेंटेशन में टेक्स्ट‑धारक और केवल ग्राफ़िकल ऑटो शेप दोनों मौजूद हों।

![एक टेक्स्ट बॉक्स और एक आकार](istextbox.png)

निम्न उदाहरण प्रेज़ेंटेशन में प्रत्येक ऑटो शेप की जाँच करता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

नया जोड़ा गया ऑटो शेप तभी टेक्स्ट बॉक्स माना जाता है जब उसमें शून्य‑से‑अधिक टेक्स्ट हो। आप यह टेक्स्ट [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/addtextframe/) या [ITextFrame::set_Text](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/set_text/) के माध्यम से प्रदान कर सकते हैं। खाली स्ट्रिंग असाइन करने या जोड़ने से [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/get_istextbox/) `false` लौटाता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

पहले दो जाँच `true` लौटाती हैं; अंतिम दो `false`।

## **टेक्स्ट फ्रेम वाले आकार का पता लगाना**

सामान्य टेक्स्ट‑प्रोसेसिंग कोड को कभी‑कभी [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) मिल सकता है बिना यह जान पाए कि वह किस प्रेज़ेंटेशन ऑब्जेक्ट में है। उसके स्वामी [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) पर नेविगेट करने के लिए [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentshape/) मेथड का प्रयोग करें।

यदि टेक्स्ट फ्रेम ऑटो शेप या किसी अन्य टेक्स्ट‑धारक आकार का है, तो [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentshape/) मालिक को और [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr` लौटाता है। दोनों मेथड केवल‑पढ़ने योग्य नेविगेशन प्रदान करते हैं। इसे एक्सेस करने से पहले लौटाए गए मान की `nullptr` जाँच करें। आकार और तालिका‑सेल दोनों मालिकों की पहचान करने के लिए, जिसमें SmartArt नोड से जुड़े आकार भी शामिल हैं, देखें [Search and Replace Text](/slides/hi/cpp/search-and-replace-text/)।

## **टेक्स्ट बॉक्स में कॉलम जोड़ना**

[ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/set_columncount/) मेथड टेक्स्ट फ्रेम को कॉलमों में विभाजित करता है, जबकि [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/set_columnspacing/) कॉलमों के बीच का अंतर पॉइंट्स में सेट करता है। दोनों मेथड [ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/) का हिस्सा हैं और मौजूदा टेक्स्ट बॉक्स के टेक्स्ट फ्रेम के माध्यम से बुलाए जा सकते हैं। टेक्स्ट समान आकार के भीतर कॉलमों के बीच पुनः प्रवाहित होता है; यह किसी अन्य आकार में नहीं चलता।

निम्न उदाहरण 10 पॉइंट कॉलम स्पेसिंग के साथ तीन‑कॉलम टेक्स्ट बॉक्स बनाता है, प्रेज़ेंटेशन सहेजता है, और आउटपुट फ़ाइल से सेटिंग्स वापस पढ़ता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **व्यक्तिगत कॉलम से टेक्स्ट निकालना**

[ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/splittextbycolumns/) का उपयोग करके आप मौजूदा टेक्स्ट फ्रेम में प्रत्येक दृश्य कॉलम में असाइन किया गया टेक्स्ट प्राप्त कर सकते हैं। यह मेथड प्रत्येक कॉलम के लिए एक स्ट्रिंग लौटाता है, कॉलम‑आधारित पढ़ने के क्रम में। एक‑कॉलम टेक्स्ट फ्रेम एक तत्व वाला ऐरे देता है, और खाली कॉलम एक खाली स्ट्रिंग द्वारा दर्शाया जाता है। स्ट्रिंग्स में केवल सादा टेक्स्ट होता है; भाग‑स्तर फ़ॉर्मेटिंग संरक्षित नहीं रहती।

यह उपयोगी होता है जब आपको आवश्यकता हो:

- कॉलम‑आधारित पढ़ने के क्रम को बरकरार रखते हुए टेक्स्ट निकालना।
- बहु‑कॉलम स्लाइड्स की सामग्री को इंडेक्स या तुलना करना।
- प्रत्येक कॉलम को अलग फ़ाइल, डेटाबेस फ़ील्ड या अन्य गंतव्य पर निर्यात करना।
- कॉलम संख्या को [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/set_columncount/) या स्पेसिंग को [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/set_columnspacing/) से बदलने के बाद या फ़ॉन्ट या टेक्स्ट‑फ़्रेम आकार बदलने पर टेक्स्ट के पुनः वितरण का निरीक्षण करना।

यह मेथड वर्तमान [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) में वितरित टेक्स्ट को रिपोर्ट करता है; यह अलग-अलग आकारों या टेक्स्ट बॉक्सों के बीच स्वचालित रूप से टेक्स्ट प्रवाहित नहीं करता। कॉलम वितरण उपलब्ध फ़ॉन्टों और अन्य टेक्स्ट‑लेआउट सेटिंग्स पर निर्भर करता है, इसलिए सुसंगत परिणामों के लिए आवश्यक फ़ॉन्ट उपलब्ध रखें।

निम्न उदाहरण प्रेज़ेंटेशन लोड करता है, पहले स्लाइड पर पहला बहु‑कॉलम ऑटो शेप ढूँढ़ता है जिसमें टेक्स्ट फ्रेम है, उसके कॉन्फ़िगर किए गए कॉलम काउंट को पढ़ता है, और प्रत्येक कॉलम के टेक्स्ट को अलग फ़ाइल में लिखता है। उन आकारों को छोड़ दिया जाता है जिनमें टेक्स्ट फ्रेम नहीं है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **टेक्स्ट अपडेट करना**

प्रेज़ेंटेशन में टेक्स्ट को अपडेट करने के लिए, स्लाइड और आकारों पर क्रमिक रूप से पारित हों, ऑटो शेप चुनें, तथा उनके टेक्स्ट भागों को संपादित करें। भाग‑स्तर पर काम करने से आप टेक्स्ट और कैरेक्टर फ़ॉर्मेटिंग दोनों बदल सकते हैं।

निम्न उदाहरण प्रत्येक ऑटो‑शेप टेक्स्ट भाग में `years` को `months` से बदलता है और प्रभावित भाग को बोल्ड करता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

यह प्रवाह केवल ऑटो शेप में टेक्स्ट को अपडेट करता है। तालिकाओं, चार्ट्स, SmartArt या समूहित आकारों में संग्रहीत टेक्स्ट को अपडेट करने के लिए उन वस्तुओं के अपने संग्रहों पर पारित होना आवश्यक है।

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ना**

हाइपरलिंक किसी विशेष टेक्स्ट भाग को सौंपा जा सकता है, जिससे केवल वही टेक्स्ट क्लिक करने योग्य बनता है। भाग को बाहरी URL से जोड़ने के लिए [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) का उपयोग करें।

निम्न उदाहरण लिंक्ड टेक्स्ट बनाता है और उसे प्रेज़ेंटेशन में सहेजता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर या लेआउट स्लाइड पर टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/cpp/manage-placeholder/) अपनी स्थिति और फ़ॉर्मेटिंग को [master slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/masterslide/) या [layout slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/layoutslide/) से विरासत में ले सकता है। एक सामान्य टेक्स्ट बॉक्स वह स्वतंत्र आकार है जो उस स्लाइड पर बना रहता है जहाँ इसे निर्मित किया गया था और लेआउट बदलने पर प्लेसहोल्डर व्यवहार नहीं अपनाता।

**मैं टेक्स्ट को कैसे बदलूं बिना चार्ट्स, टेबल्स या SmartArt के टेक्स्ट को प्रभावित किए?**

जैसे कि Update Text उदाहरण में दिखाया गया है, केवल उन आकारों को प्रोसेस करें जो [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) को लागू करते हैं। चार्ट्स, टेबल्स और SmartArt अपने स्वयं के ऑब्जेक्ट मॉडल में टेक्स्ट संग्रहीत करते हैं, इसलिए वे उस लूप द्वारा संशोधित नहीं होते।