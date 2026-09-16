---
title: C++ में प्रेजेंटेशन हाइपरलिंक प्रबंधित करें
linktitle: हाइपरलिंक प्रबंधित करें
type: docs
weight: 20
url: /hi/cpp/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक फ़ॉर्मेट करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रेजेंटेशन में Aspose.Slides for C++ का उपयोग करके हाइपरलिंक जोड़ें, फ़ॉर्मेट करें, अपडेट करें और हटाएं, C++ उदाहरणों के साथ।"
---
## **परिचय**

एक हाइपरलिंक प्रेजेंटेशन की सामग्री को वेबसाइट या प्रेजेंटेशन के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आम तौर पर दो उद्देश्यों के लिए उपयोग होते हैं:

* टेक्स्ट, आकार या मीडिया फ्रेम से वेबसाइट खोलना।  
* दूसरे स्लाइड पर नेविगेट करना, उदाहरण के लिए, सामग्री तालिका से।

Aspose.Slides for C++ आपको ये लिंक जोड़ने, उनके रूप और आवाज़ को नियंत्रित करने, सेटिंग्स को अपडेट करने और उन्हें हटाने की सुविधा देता है। नीचे के उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक के साथ कैसे काम किया जाए और प्रेजेंटेशन, स्लाइड या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुंचा जाए।

{{% alert color="info" title="नोट" %}}
आप प्रेजेंटेशन को [नि:शुल्क ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/hi/editor) से भी संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

आप टेक्स्ट, आकार या मीडिया फ्रेम को वेबसाइट URL असाइन कर सकते हैं। जिस तत्व को आप हाइपरलिंक असाइन करते हैं, वह क्लिक करने योग्य क्षेत्र निर्धारित करता है: टेक्स्ट भाग चयनित टेक्स्ट से लिंक करता है, जबकि आकार या फ्रेम स्लाइड ऑब्जेक्ट से लिंक करता है।

### **टेक्स्ट में URL हाइपरलिंक जोड़ें**

टेक्स्ट को वेबसाइट से लिंक करने के लिए, एक [हाइपरलिंक](https://reference.aspose.com/slides/hi/cpp/aspose.slides/hyperlink/) बनाएं और उसे टेक्स्ट भाग की [set_HyperlinkClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides/portionformat/set_hyperlinkclick/) मेथड से असाइन करें, जैसा कि नीचे दिखाया गया है। केवल वह टेक्स्ट भाग क्लिक करने योग्य बनता है।

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **आकार और मीडिया फ्रेम में URL हाइपरलिंक जोड़ें**

आकार या फ्रेम को क्लिक करने योग्य बनाना है तो उसकी [set_HyperlinkClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/set_hyperlinkclick/) मेथड का उपयोग करें। हाइपरलिंक ऑब्जेक्ट खुद से जुड़ा होता है, न कि उसके अंदर के टेक्स्ट भाग से।

इसी विधि को चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू किया जा सकता है: फ्रेम को हाइपरलिंक असाइन करें और आवश्यकता पड़ने पर [set_Tooltip](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/set_tooltip/) से संकेत जोड़ें।

निम्न उदाहरण एक आयत को क्लिक करने योग्य बनाता है:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **हाइपरलिंक का उपयोग करके सामग्री तालिका बनाएं**

आंतरिक हाइपरलिंक पाठकों को सामग्री तालिका से किसी विशिष्ट स्लाइड पर ले जा सकते हैं। नीचे का उदाहरण [SetInternalHyperlinkClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) का उपयोग करके पहली स्लाइड पर “Page 2” टेक्स्ट को दूसरी स्लाइड से जोड़ता है।

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **हाइपरलिंक को फॉर्मेट करें**

### **रंग**

[IHyperlink](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/) की [set_ColorSource](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/set_colorsource/) मेथड निर्धारित करती है कि हाइपरलिंक प्रेजेंटेशन के हाइपरलिंक रंग का उपयोग करे या टेक्स्ट भाग की फ़ॉर्मेटिंग का। कस्टम टेक्स्ट रंग लागू करने के लिए [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/hyperlinkcolorsource/) चुनें और भाग की फ़िल रंग सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण एक ही स्लाइड में दो टेक्स्ट हाइपरलिंक जोड़ता है। पहला लाल टेक्स्ट फ़िल से है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग रखता है।

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

### **ध्वनि**

हाइपरलिंक को सक्रिय करने पर ध्वनि चलाया जा सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्न मेथड का उपयोग करें:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/set_sound/) हाइपरलिंक से जुड़ी ऑडियो निर्दिष्ट करता है।  
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) नियंत्रित करता है कि हाइपरलिंक सक्रिय करने पर पूर्व ध्वनि रुक जाए।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` लोड करता है और उसे पहली स्लाइड पर एक बटन से जोड़ता है। बटन पर क्लिक करने से ध्वनि बजती है और अगली स्लाइड पर नेविगेट होता है। उसी स्लाइड का दूसरा आकार क्लिक करने पर ध्वनि को रोकता है, बिना नेविगेशन किए।

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **हाइपरलिंक ध्वनि निकालें**

निम्न उदाहरण ऊपर निर्मित प्रेजेंटेशन को खोलता है और पहली आकार की हाइपरलिंक ऑडियो को [get_Sound](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/get_sound/) और [get_BinaryData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iaudio/get_binarydata/) के माध्यम से मेमोरी में पढ़ता है।

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **टूलटिप और इंटरैक्शन सेटिंग्स**

टेक्स्ट या आकार को हाइपरलिंक असाइन करने के बाद आप निम्न [IHyperlink](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/) सेटिंग्स को इन मेथड्स से अपडेट कर सकते हैं:

- [set_Tooltip](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/set_tooltip/) लिंक के लिए दर्शक को दिखाने योग्य संकेत सेट करता है।  
- [set_TargetFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/set_targetframe/) लागू होने पर पैरेंट HTML फ्रेमसेट में लक्ष्य फ्रेम निर्दिष्ट करता है।  
- [set_History](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/set_history/) निर्धारित करता है कि लिंक सक्रिय करने से उसका लक्ष्य देखे गए हाइपरलिंक सूची में जोड़ दिया जाए।  
- [set_HighlightClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/set_highlightclick/) निर्धारित करता है कि क्लिक करने पर हाइपरलिंक हाईलाइट हो या नहीं।

## **प्रेजेंटेशन से हाइपरलिंक हटाएं**

हाइपरलिंक हटाने से पहले सभी हाइपरलिंक कंटेनर (टेक्स्ट‑पोर्टन लिंक सहित) एकत्र करने के लिए [GetAnyHyperlinks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) का उपयोग करें। नीचे का उदाहरण पहली स्लाइड से दोनों सक्रियता प्रकार हटाता है। केवल एक प्रकार हटाने के लिए आप केवल [RemoveHyperlinkClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) या [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) को कॉल करें; क्लिक कार्रवाई हटाने से माउस‑ओवर कार्रवाई नहीं हटती।

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

सशर्त हटाने के लिए, [RemoveAllHyperlinks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) चुने हुए स्कोप में दोनों सक्रियता प्रकार को एक ही कॉल में हटाता है। चयनात्मक सफाई और मास्टर्स, लेआउट्स, नोट्स को कवर करने के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

## **हाइपरलिंक इन्वेंटरी बनाएं**

प्रेजेंटेशन वितरित करने से पहले उसकी इंटरैक्टिव क्रियाओं और वेब लिंक की सूचनात्मक सूची बनाएं। [GetAnyHyperlinks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट लौटाता है, न कि URL स्ट्रिंग की फ्लैट सूची। प्रत्येक कंटेनर पर [get_HyperlinkClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) और [get_HyperlinkMouseOver](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) जाँचें। वे स्वतंत्र हैं: एक ही कंटेनर दोनों क्रिया रख सकता है, इसलिए पूर्ण रिपोर्ट के लिए प्रत्येक कंटेनर के दो पंक्तियों तक की आवश्यकता हो सकती है।

केवल आकार‑स्तर के हाइपरलिंक स्कैन करने से टेक्स्ट‑पोर्टन से जुड़े लिंक छूट सकते हैं। उचित स्कोप को क्वेरी करें, और बाद में उनके कार्यों को अपडेट या हटाने के लिए लौटाए गए कंटेनर को रखें।

### **प्रेजेंटेशन, स्लाइड और टेक्स्ट‑फ़्रेम स्कोप क्वेरी करें**

[IHyperlinkQueries](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkqueries/) इंटरफ़ेस उपलब्ध है [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/), और [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_hyperlinkqueries/) पर। प्रत्येक स्कोप समान क्वेरी का समर्थन करता है:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) क्लिक क्रिया वाले कंटेनर लौटाता है।  
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) माउस‑ओवर क्रिया वाले कंटेनर लौटाता है।  
- [GetAnyHyperlinks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) किसी भी या दोनों क्रिया वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें बाहरी क्लिक लिंक, फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, टेक्स्ट माउस‑ओवर लिंक और मैक्रो कार्रवाई शामिल हैं। यह इन कार्यों में से कोई भी निष्पादित नहीं करता। समान तीन क्वेरी हर स्कोप पर काम करती हैं; गणना कंटेनर की संख्या बताती है, न कि कुल क्रिया की। टेक्स्ट‑फ़्रेम स्कोप enclosing आकार के अपने लिंक को बाहर रखता है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

इस उदाहरण में, प्रेजेंटेशन और स्लाइड क्वेरी प्रत्येक तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर और तीन मिश्रित कंटेनर रिपोर्ट करती हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **क्रियाओं और गंतव्यों को वर्गीकृत करें**

हाइपरलिंक की गंतव्य को समझने से पहले उसकी कार्रवाई को समझने के लिए [IHyperlink::get_ActionType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/get_actiontype/) उपयोग करें। [HyperlinkActionType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से अधिक कार्यों को कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाह्य हाइपरलिंक; URL और उसका स्कीम जाँचें। |
| `JumpSpecificSlide` | विशेष स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | बिल्ट‑इन स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो समाप्त करें या कस्टम शो प्रारंभ करें। |
| `StartMacro` | मैक्रो चलाएँ। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रेजेंटेशन खोलें; वेब URL से अलग जाँचें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन कार्रवाई नहीं, या अपरिचित कार्रवाई जिन्हें समीक्षा की आवश्यकता है। |

बाह्य गंतव्य को [get_ExternalUrl](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/get_externalurl/) से पढ़ें और विशिष्ट आंतरिक गंतव्य को [get_TargetSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/get_targetslide/) से। आंतरिक कार्रवाई और बिल्ट‑इन कमांड में कभी‑कभी बाह्य URL नहीं होता; खाली URL का अर्थ यह नहीं कि कंटेनर में कोई कार्रवाई नहीं है। जब [get_ExternalUrlOriginal](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) मान सामान्यीकृत URL से भिन्न हो तो उसे सुरक्षित रखें, और उपलब्ध होने पर [get_Tooltip](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlink/get_tooltip/) द्वारा लौटाए गए टूलटिप को शामिल करें।

### **हाइपरलिंक की रिपोर्ट, साफ‑सफाई और सत्यापन करें**

निम्न C++ उदाहरण मौजूदा प्रेजेंटेशन (उपर्युक्त निर्मित फ़ाइल) पढ़ता है, `hyperlink-audit.json` लिखता है, नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और फिर दोनों सक्रियता प्रकारों को फिर से जाँचता है। यह कंटेनर को बदलने से पहले एकत्र करता है और एक ही कंटेनर को दो बार प्रोसेस करने से बचने के लिए पॉइंटर पहचान का उपयोग करता है। प्रेजेंटेशन क्वेरी सामान्य स्लाइड को कवर करती है; पैकेज‑व्यापी इन्वेंटरी के लिए यह स्पष्ट रूप से मास्टर्स, लेआउट्स, नोट्स और उपलब्ध होने पर नोट्स‑और‑हैंडआउट मास्टर्स को भी क्वेरी करती है।

रिपोर्ट में एक‑आधारिक स्लाइड अनुक्रमांक और उपलब्ध होने पर [get_SlideId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/get_slideid/) दर्शाया जाता है। [ISlideComponent::get_Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecomponent/get_slide/) समर्थन योग्य कंटेनर के लिए मालिक स्लाइड प्रदान करता है। मास्टर, लेआउट और नोट्स के पास सामान्य स्लाइड अनुक्रमांक नहीं होता और उन्हें उनके स्कोप से पहचाना जाता है। आकार‑कंटेनर और टेक्स्ट‑पोर्टन फ़ॉर्मेटिंग कंटेनर को अलग‑अलग लेबल किया जाता है; अन्य कंटेनर प्रकार अपना रन‑टाइम टाइप नाम रखते हैं। प्रत्येक कंटेनर को रिपोर्ट‑स्थानीय ID दी जाती है ताकि उसकी दो क्रियाओं को जोड़ा जा सके।

यह प्रतिबंधात्मक नीति केवल पूर्ण HTTPS URL और मान्य आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्य, अन्य स्लाइडशो कार्य, अज्ञात कार्य और अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकार नीति निर्णय हैं, न कि Aspose.Slides सुरक्षा निर्णय। केवल HTTPS भरोसेमंद नहीं है: अपने एप्लिकेशन के लिये होस्ट अलाउलिस्ट और अन्य जाँच जोड़ें। मूल और सामान्यीकृत दोनों बाह्य URL की जाँच की जाती है। उदाहरण लिंक का अनुसरण किए बिना या कार्य चलाए बिना मेटाडाटा का ऑडिट करता है।

सुधार के लिये, कंटेनर के [get_HyperlinkManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) द्वारा [SetExternalHyperlinkClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), और [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) समर्थित हैं। यहां प्रतिबंधित बाह्य क्लिक लिंक को एक निश्चित HTTPS लैंडिंग पृष्ठ से प्रतिस्थापित किया जाता है; अन्य प्रतिबंधित क्लिक और माउस‑ओवर कार्रवाई स्वतंत्र रूप से हटाई जाती हैं। सभी नीति उल्लंघनों को हटाने के लिये `replaceExternalClicks` को `false` सेट करें। तैनाती से पहले अनुप्रयोग‑स्वामित्व वाला प्रतिस्थापन पृष्ठ चुनें।

रिपोर्ट का एक्सपोर्ट फ़्लैग एक रूढ़िवादी PDF समीक्षा नीति का उपयोग करता है: माउस‑ओवर कार्रवाई और कोई भी गैर‑बाह्य लिंक या विशेष स्लाइड जंप को संभावित असमर्थित के रूप में फ़्लैग करता है। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि फ़्लैग‑रहित लिंक निर्यात में टिकेंगे। समर्थित [PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/cpp/convert-powerpoint-to-html/) निर्यात हाइपरलिंक को संरक्षित रख सकते हैं, कार्रवाई, निर्यात विकल्प और दर्शक पर निर्भर करता है। रास्टर [छवियां](/slides/hi/cpp/convert-powerpoint-to-png/) और [वीडियो](/slides/hi/cpp/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक नहीं रख सकते; उन आउटपुट के लिये ऑडिट करते समय सभी कार्रवाई को फ़्लैग करें।

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

ऊपर निर्मित इनपुट के साथ, रिपोर्ट में पाँच कार्रवाई पंक्तियां होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए गए, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बरकरार रहे। सत्यापन शून्य प्रतिबंधित कार्रवाई प्रिंट करता है। एक प्रतिबंधित बाह्य क्लिक URL वाला इनपुट प्रतिस्थापन शाखा को भी सक्रिय करता है। अनुमत क्लिक और प्रतिबंधित माउस‑ओवर वाला कंटेनर अपनी क्लिक कार्रवाई रखता है।

यह चयनात्मक साफ‑सफ़ाई [RemoveAllHyperlinks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) से अलग है, जो नीति की परवाह किए बिना चुने हुए स्कोप में दोनों सक्रियता प्रकार को हटा देता है। यहाँ सत्यापन केवल हाइपरलिंक कार्रवाई की जाँच करता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को नहीं हटाता, और न ही निर्यातित PDF या HTML फ़ाइल की वैधता की पुष्टि करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं किसी सेक्शन या उसकी पहली स्लाइड से कैसे लिंक कर सकता हूँ?**  
PowerPoint में सेक्शन स्लाइड्स को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक एक व्यक्तिगत स्लाइड को लक्ष्य बनाता है। सेक्शन पर नेविगेट करने के लिये उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड के तत्वों पर हाइपरलिंक जोड़ सकता हूँ ताकि यह सभी स्लाइड्स पर काम करे?**  
हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर लिंक उस मास्टर या लेआउट का उपयोग करने वाली स्लाइड शो में उपलब्ध होते हैं।

**क्या हाइपरलिंक PDF, HTML, छवियां या वीडियो में निर्यात करने पर संरक्षित रहते हैं?**  
समर्थित PDF और HTML निर्यात हाइपरलिंक को संरक्षित रख सकते हैं; रास्टर छवियां और वीडियो इंटरैक्टिव हाइपरलिंक नहीं रख सकते। अधिक जानकारी के लिये देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।