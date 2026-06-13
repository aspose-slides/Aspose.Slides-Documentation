---
title: Aspose.Slides for C++ का उपयोग करके Hello World एप्लिकेशन
type: docs
weight: 80
url: /hi/cpp/hello-world-application-using-aspose-slides/
keywords:
- हैलो वर्ल्ड
- एप्लिकेशन
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ अपना पहला C++ एप्लिकेशन बनाएं, एक सरल Hello World उदाहरण जो आपको PPT, PPTX और ODP प्रस्तुतियों को स्वचालित करने के लिए तैयार करता है।"
---
## **समीक्षा**

यह लेख Aspose.Slides का उपयोग करके एक साधारण Hello World PowerPoint प्रस्तुति बनाने का तरीका दिखाता है। उदाहरण यह प्रदर्शित करता है कि नई Presentation कैसे बनाएँ, पहली स्लाइड तक पहुँचें, निर्दिष्ट स्थिति पर Rectangle AutoShape जोड़ें, Hello World पाठ वाला TextFrame सम्मिलित करें, और Shape तथा Text के स्वरूपण को समायोजित करें।

यह यह भी बताता है कि टेक्स्ट को काले रंग में बदलकर कैसे दिखाई दें, Shape की सीमा को सफेद लाइन रंग सेट करके कैसे छुपाएँ, Shape के Fill को हटाएँ, और Presentation को PPTX फ़ाइल के रूप में सहेजें।

## **Hello World एप्लिकेशन बनाने के चरण**

- Presentation क्लास का एक इंस्टेंस बनाएँ
- Presentation के इंस्टैंसिएशन पर बनाई गई पहली स्लाइड का रेफ़रेंस प्राप्त करें
- स्लाइड की निर्दिष्ट स्थिति पर ShapeType को Rectangle रखते हुए AutoShape जोड़ें
- AutoShape में Hello World को डिफ़ॉल्ट टेक्स्ट के रूप में रखते हुए TextFrame जोड़ें
- डिफ़ॉल्ट सफ़ेद टेक्स्ट रंग को काला बदलें ताकि सफ़ेद पृष्ठभूमि वाली स्लाइड पर यह दिखाई दे
- Shape की लाइन का रंग सफ़ेद करें ताकि बॉर्डर छुपे
- Shape के डिफ़ॉल्ट Fill Format को हटा दें
- अंत में, Presentation ऑब्जेक्ट का उपयोग करके प्रस्तुति को वांछित फ़ाइल फ़ॉर्मेट में लिखें

ऊपर वर्णित चरणों का कार्यान्वयन नीचे एक उदाहरण में दर्शाया गया है।

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // पहली स्लाइड प्राप्त करें
    auto slide = pres->get_Slides()->idx_get(0);

    // Rectangle प्रकार का AutoShape जोड़ें
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // Rectangle में TextFrame जोड़ें
    shape->AddTextFrame(u"Hello World");

    // टेक्स्ट का रंग काले में बदलें (जो डिफ़ॉल्ट रूप में सफ़ेद है)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // Rectangle की लाइन का रंग सफ़ेद में बदलें
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // Shape में किसी भी Fill फ़ॉर्मेट को हटाएँ
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // प्रस्तुति को डिस्क पर सहेजें
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```