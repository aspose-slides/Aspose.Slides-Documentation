---
title: C++ में PowerPoint प्रस्तुतियों को XML में बदलें
linktitle: PowerPoint से XML
type: docs
weight: 145
url: /hi/cpp/convert-powerpoint-to-xml/
keywords:
- PowerPoint को XML में बदलें
- प्रस्तुति को XML में बदलें
- PPT को XML में
- PPTX को XML में
- ODP को XML में
- PowerPoint XML प्रस्तुति
- SaveFormat::Xml
- प्रस्तुति को XML के रूप में सहेजें
- प्रस्तुति को XML में निर्यात करें
- XML स्ट्रीम
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ C++ में PowerPoint और OpenDocument प्रस्तुतियों को PowerPoint XML फ़ाइलों या स्ट्रीम में बदलें।"
---
## **सारांश**

Aspose.Slides for C++ PowerPoint प्रस्तुतियों को PowerPoint XML Presentation फ़ॉर्मेट में बदल सकता है। XML आउटपुट उपयोगी होता है जब आपको प्रस्तुति संरचना की जांच, उत्पन्न दस्तावेज़ों की समस्याओं का निवारण, स्वचालित परीक्षणों में आउटपुट की तुलना, या ऐसी कार्यप्रवाह के साथ एकीकरण करने के लिए टेक्स्ट-आधारित प्रतिनिधित्व चाहिए जो प्रस्तुति पैकेज के बजाय XML का उपयोग करता है।

इसे करने के लिए [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड को [SaveFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) enumeration से `Xml` मान के साथ उपयोग करें। आप परिणाम को सीधे फ़ाइल में या स्ट्रीम में लिख सकते हैं।

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` एक PowerPoint XML Presentation बनाता है। यह PPTX पैकेज के अंदर संग्रहीत व्यक्तिगत Office Open XML भागों को निकालता नहीं है। यदि आपको सटीक PPTX पैकेज भागों की आवश्यकता है, जैसे `ppt/presentation.xml` या व्यक्तिगत स्लाइड XML फ़ाइलें, तो सीधे PPTX पैकेज की जाँच करें।
{{% /alert %}}

## **एक प्रस्तुति को XML फ़ाइल में परिवर्तित करें**

[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) वर्ग का उपयोग करके स्रोत प्रस्तुति लोड करें, और फिर आउटपुट पथ तथा `SaveFormat::Xml` को [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) को पास करें। स्रोत कोई भी प्रस्तुति फ़ॉर्मेट हो सकता है जो लोडिंग के लिये समर्थित है, जैसे PPT, PPTX, या ODP।

निम्न उदाहरण PPTX प्रस्तुति को XML फ़ाइल में बदलता है:
```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **XML आउटपुट को स्ट्रीम में लिखें**

जब XML को मेमोरी में रहना हो या किसी अन्य कंपोनेंट को पास करना हो, जैसे वेब सेवा, स्टोरेज प्रोवाइडर, या XML प्रोसेसिंग पाइपलाइन, तो [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) की स्ट्रीम ओवरलोड का उपयोग करें। निम्न उदाहरण परिणाम को एक [MemoryStream](https://reference.aspose.com/slides/hi/cpp/system.io/memorystream/) में लिखता है और बाद में पढ़ने के लिए उसे रीवाइंड करता है:
```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// वर्कफ़्लो में अगले घटक को xmlStream पास करें।
```

## **XML की प्रस्तुति और निर्यात फ़ॉर्मेट्स से तुलना**

परिणाम के उपयोग के आधार पर आउटपुट फ़ॉर्मेट चुनें:

| फ़ॉर्मेट | आउटपुट | सामान्य उपयोग |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | एक PowerPoint XML Presentation | संरचना की जांच, समस्याओं का निवारण, उत्पन्न आउटपुट की तुलना, और XML-आधारित एकीकरण |
| PPT (`.ppt`) | एक पुरानी बाइनरी प्रस्तुति फ़ाइल | पुराने PowerPoint कार्यप्रवाहों के साथ संगतता |
| PPTX (`.pptx`) | एक Office Open XML पैकेज जिसमें कई भाग होते हैं | सामान्य PowerPoint संपादन और प्रस्तुति आदान‑प्रदान |
| PDF or TIFF | स्थिर-लेआउट पृष्ठ या बहु-पृष्ठ छवि | देखना, प्रिंट करना और अभिलेखीय करना |
| PNG, JPEG, or SVG | एक व्यक्तिगत स्लाइड का रेंडर किया गया प्रतिनिधित्व | थंबनेल, पूर्वावलोकन, और इमेज एसेट्स |
| HTML or HTML5 | वेब-उन्मुख प्रस्तुति आउटपुट | ब्राउज़र में देखना और वेब प्रकाशन |

PPT और PPTX के विपरीत, XML आउटपुट मुख्यतः निरीक्षण और डेटा-उन्मुख कार्यप्रवाहों के लिए अभिप्रेत है। PDF, TIFF, HTML और स्लाइड इमेज फ़ॉर्मेट्स के विपरीत, यह प्रस्तुति डेटा को दर्शाता है न कि स्लाइड्स को पृष्ठों या दृश्य एसेट्स के रूप में रेंडर करता है। [supported file formats](/slides/hi/cpp/supported-file-formats/) तालिका PowerPoint XML Presentation को केवल-सेव फ़ॉर्मेट के रूप में सूचीबद्ध करती है, इसलिए जब कार्यप्रवाह को निर्यातित फ़ाइल को वापस Aspose.Slides में लोड करके निरंतर संपादन करना हो तो इसका उपयोग न करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या `SaveFormat::Xml` PPTX फ़ाइल को सहेजने के समान है?**  
नहीं। PPTX एक पैकेज है जिसमें कई Office Open XML भाग होते हैं, जबकि `SaveFormat::Xml` एक PowerPoint XML Presentation फ़ाइल बनाता है।

**क्या मैं XML आउटपुट को बिना डिस्क पर फ़ाइल बनाए सहेज सकता हूँ?**  
हाँ। एक लिखने योग्य स्ट्रीम को [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) को पास करें। उदाहरण के लिए, इन‑मेमोरी प्रोसेसिंग के लिए एक [MemoryStream](https://reference.aspose.com/slides/hi/cpp/system.io/memorystream/) उपयोग करें।

**क्या Aspose.Slides निर्यातित XML फ़ाइल को फिर से लोड कर सकता है?**  
नहीं। PowerPoint XML Presentation वर्तमान में केवल सहेजने के लिये समर्थित है, लोड करने के लिये नहीं। जब राउंड‑ट्रिप संपादन आवश्यक हो तो PPTX या कोई अन्य समर्थित प्रस्तुति फ़ॉर्मेट उपयोग करें।

**क्या XML रूपांतरण प्रत्येक स्लाइड को पृष्ठ या छवि के रूप में रेंडर करता है?**  
नहीं। XML रूपांतरण संरचित प्रस्तुति डेटा लिखता है। पृष्ठ‑उन्मुख आउटपुट के लिये PDF या TIFF उपयोग करें, या व्यक्तिगत स्लाइड छवियों के लिये PNG, JPEG, और SVG उपयोग करें।