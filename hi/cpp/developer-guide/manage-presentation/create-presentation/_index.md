---
title: C++ में प्रस्तुतियां बनाएं
linktitle: प्रस्तुति बनाएं
type: docs
weight: 10
url: /hi/cpp/create-presentation/
keywords:
- प्रस्तुति बनाएं
- नई प्रस्तुति
- PPT बनाएं
- नया PPT
- PPTX बनाएं
- नया PPTX
- ODP बनाएं
- नया ODP
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में प्रस्तुतियां बनाएं—PPT, PPTX, और ODP फ़ाइलें उत्पन्न करें, OpenDocument समर्थन से लाभ उठाएं, और विश्वसनीय परिणामों के लिए उन्हें प्रोग्रामेटिक रूप से सहेजें।"
---
## **परिचय**

यह लेख दर्शाता है कि Aspose.Slides में प्रस्तुति कैसे बनाएं, उसकी पहली स्लाइड में टेक्स्ट बॉक्स कैसे जोड़ें, और परिणाम को फ़ाइल के रूप में सहेजें। अंत में एक संक्षिप्त FAQ आम प्रश्नों को कवर करता है, जिसमें फ़ॉर्मेट, टेम्प्लेट, स्लाइड आकार, इकाइयाँ, मेमोरी उपयोग, थ्रेडिंग, लाइसेंसिंग, डिजिटल हस्ताक्षर, और VBA समर्थन शामिल हैं।

शुरू करने से पहले, अपने प्रोजेक्ट में Aspose.Slides जोड़ें: विंडोज़ पर Visual Studio प्रोजेक्ट में NuGet से, या लिनक्स पर CMake के साथ ZIP पैकेज से। देखिए [Installation](/slides/hi/cpp/installation/).

## **PowerPoint प्रस्तुति बनाएं**

एक प्रस्तुति बनाने और उसकी पहली स्लाइड पर टेक्स्ट बॉक्स रखने के लिए, निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं। नई प्रस्तुति में पहले से ही एक खाली स्लाइड होती है।
2. उस स्लाइड को [Presentation::get_Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slide/) मेथड और उसके सूचकांक, 0, से प्राप्त करें।
3. [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addautoshape/) मेथड से एक आयत जोड़ें, और उसके टेक्स्ट को [ITextFrame::set_Text](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/set_text/) मेथड से सेट करें।
4. [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड से प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

आयत का ऊपर-बायाँ कोना स्लाइड के बाएँ किनारे से 50 पॉइंट और ऊपर के किनारे से 50 पॉइंट दूर है, और आयत की चौड़ाई 400 पॉइंट तथा ऊँचाई 100 पॉइंट है। प्रोग्राम अपनी कार्यशील निर्देशिका में *hello.pptx* सहेजता है, जिसमें एक स्लाइड होती है जिसमें आयत और उसका टेक्स्ट होता है। बिना लाइसेंस के, Aspose.Slides प्रत्येक सहेजी गई स्लाइड में एक मूल्यांकन वॉटरमार्क भी जोड़ता है; देखें [Licensing](/slides/hi/cpp/licensing/).

## **अक्सर पूछे जाने वाले प्रश्न**

### नई प्रस्तुति को किन फ़ॉर्मेट में सहेजा जा सकता है?

आप इसे [PPTX, PPT, और ODP](/slides/hi/cpp/save-presentation/) में सहेज सकते हैं, और [PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/hi/cpp/convert-powerpoint-to-xps/), [HTML](/slides/hi/cpp/convert-powerpoint-to-html/), [SVG](/slides/hi/cpp/render-a-slide-as-an-svg-image/), और [images](/slides/hi/cpp/convert-powerpoint-to-png/) सहित कई अन्य फ़ॉर्मेट में एक्सपोर्ट कर सकते हैं।

### क्या मैं टेम्प्लेट (POTX/POTM) से शुरू करके सामान्य PPTX के रूप में सहेज सकता हूँ?

हाँ। टेम्प्लेट को लोड करें और वांछित फ़ॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मेट [समर्थित हैं](/slides/hi/cpp/supported-file-formats/)।

### प्रस्तुति बनाते समय स्लाइड आकार/आस्पेक्ट रेशियो कैसे नियंत्रित करें?

स्लाइड आकार को सेट करें [slide size](/slides/hi/cpp/slide-size/) (जैसे 4:3, 16:9 प्रीसेट या कस्टम आयाम) और तय करें कि सामग्री कैसे स्केल होनी चाहिए।

### आकार और समन्वय किस इकाई में मापे जाते हैं?

पॉइंट में: 1 इंच बराबर है 72 इकाइयों के।

### बहुत बड़ी प्रस्तुतियों (कई मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए कैसे संभालें?

डाटा ब्लॉब प्रबंधन रणनीतियों का उपयोग करें [BLOB management strategies](/slides/hi/cpp/manage-blob/), अस्थायी फ़ाइलों के माध्यम से इन‑मेमोरी स्टोरेज को सीमित करें, और पूरी तरह इन‑मेमोरी स्ट्रीम्स की बजाय फाइल‑आधारित वर्कफ़्लो को प्राथमिकता दें।

### क्या मैं प्रस्तुतियों को समानांतर में बना/सहेज सकता हूँ?

आप एक ही [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को [multiple threads](/slides/hi/cpp/multithreading/) से संचालित नहीं कर सकते। प्रत्येक थ्रेड या प्रोसेस के लिए अलग, अलग‑थलग इंस्टेंस चलाएँ।

### ट्रायल वॉटरमार्क और सीमाओं को कैसे हटाएँ?

[एक लाइसेंस लागू करें](/slides/hi/cpp/licensing/) प्रत्येक प्रोसेस में एक बार। लाइसेंस XML को अपरिवर्तित रहना चाहिए, और यदि कई थ्रेड्स शामिल हों तो लाइसेंस सेटअप को समन्वित किया जाना चाहिए।

### क्या मैं बनायी गयी PPTX को डिजिटल रूप से साइन कर सकता हूँ?

हाँ। [डिजिटल सिग्नेचर](/slides/hi/cpp/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) प्रस्तुतियों के लिए समर्थित हैं।

### क्या बनाए गए प्रस्तुतियों में मैक्रो (VBA) समर्थित हैं?

हाँ। आप [VBA प्रोजेक्ट बनाना/संपादित करना](/slides/hi/cpp/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसे मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।