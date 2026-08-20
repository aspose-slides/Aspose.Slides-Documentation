---
title: C++ में PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/cpp/convert-ppt-to-pptx/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में लेगेसी PPT फ़ाइलों को PPTX में बदलें। इसमें एकल-फ़ाइल और बैच रूपांतरण, त्रुटि संचालन, और सटीकता नोट्स के लिए C++ उदाहरण शामिल हैं।"
---
## **अवलोकन**

PPT एक लेगेसी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for C++ Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर सकता है और उसे PPTX के रूप में सहेज सकता है। यह लेख दिखाता है कि कैसे एक फ़ाइल या फ़ाइलों की डिरेक्टरी को बदलना है और परिवर्तन के बाद क्या सत्यापित करना चाहिए।

## **PPT फ़ाइल को PPTX में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास से लोड करें, फिर [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) को [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) के साथ कॉल करें। जब प्रस्तुति अब आवश्यक न हो तो उसे Dispose करके उसके संसाधनों को मुक्त करें।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मेट का चयन नहीं करता; यह [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) तर्क करता है। यदि आपको मूल PPT फ़ाइल को बनाए रखना है तो इनपुट और आउटपुट पाथ अलग रखें।

## **एकाधिक PPT फ़ाइलों को बदलें**

निम्नलिखित उदाहरण एक डायरेक्ट्री में सभी `.ppt` फ़ाइलों को बदलता है। प्रत्येक फ़ाइल को स्वतंत्र रूप से प्रोसेस किया जाता है, इसलिए एक विफल परिवर्तन बाकी बैच को नहीं रोकता।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

प्रोडक्शन कार्यभार के लिए, पूर्ण अपवाद को लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और विफल फ़ाइल नामों को पुनः प्रयास या समीक्षा कतार में लिखें। दूषित फ़ाइलें, पासवर्ड‑सुरक्षित फ़ाइलें जो बिना आवश्यक पासवर्ड के खोली गई हैं, असुविधाजनक पाथ, और असमर्थित सामग्री सभी परिवर्तन को विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए [Password-Protected Presentations](/cpp/password-protected-presentation/) देखें।

## **सटीकता और लेगेसी सुविधाएँ**

परिवर्तन सामान्यतः स्लाइड्स, मास्टर्स, लेआउट्स, टेक्स्ट, शेप्स, इमेजेज, टेबल्स और चार्ट्स को बनाए रखता है। हालांकि, PPT और PPTX हर सुविधा को बिल्कुल समान तरीके से नहीं दर्शाते। ऐसी लेगेसी सुविधा जिसके पास कोई PPTX समकक्ष नहीं है, या लाइब्रेरी द्वारा समर्थित नहीं है, उसे सामान्यीकृत, हटाया या अलग ढंग से प्रदर्शित किया जा सकता है।

जब परिवर्तित फ़ाइल में एनीमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, दुर्लभ फ़ॉन्ट्स, या VBA मैक्रोज़ हों, तो फ़ाइल की जाँच करें। एक साधारण PPTX फ़ाइल मैक्रो‑सक्षम फ़ॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उचित मैक्रो‑सक्षम कार्यप्रवाह का उपयोग करें। साथ ही यह सत्यापित करें कि आवश्यक फ़ॉन्ट्स और बाहरी संसाधन उस वातावरण में मौजूद हैं जहाँ परिवर्तित प्रस्तुति को खोला या रेंडर किया जाएगा।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामेटिक रूप से पुनः खोलें और मुख्य स्लाइड गिनती और सामग्री की जाँच करें, फिर उसे इच्छित व्यूअर में प्रदर्शित होने के रूप और स्लाइड‑शो व्यवहार से तुलना करें। यह न समझें कि सफल [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) कॉल यह प्रमाण है कि हर लेगेसी सुविधा का सटीक PPTX प्रतिनिधित्व है।

## **जब PPTX का उपयोग करें**

PPTX का उपयोग तब करें जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाले सिस्टमों के साथ आदान‑प्रदान किया जाएगा, या इसे ऐसे फ़ॉर्मेट में संग्रहीत किया जाए जो लेगेसी बाइनरी PPT की तुलना में निरीक्षण और पुनर्प्राप्ति में आसान हो। मूल PPT को एक संग्रह या रोलबैक प्रतिलिपि के रूप में रखें जब तक कि परिवर्तित प्रस्तुति आपके सटीकता परीक्षणों को पास न कर ले।

यदि आपको PDF, HTML, इमेजेज, XPS, या कोई अन्य आउटपुट प्रकार चाहिए, तो सभी लक्ष्यों के संपादन योग्य PowerPoint सुविधाओं को संरक्षित करने का अनुमान लगाने के बजाय [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) में दिए गए फ़ॉर्मेट‑विशिष्ट मार्गदर्शन का उपयोग करें।

## **ऑनलाइन कन्वर्टर**

कभी‑कभी फ़ाइल या त्वरित तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहराने योग्य परिवर्तन, बैच प्रोसेसिंग, या एप्लिकेशन‑स्तरीय त्रुटि संभालने के लिए C++ API का उपयोग करें।

## **संबंधित लेख**

- [C++ में प्रेजेंटेशन्स सहेजें](/cpp/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट्स](/cpp/supported-file-formats/)
- [C++ में प्रेजेंटेशन्स खोलें](/cpp/open-presentation/)

## **अक्सर पूछे गये प्रश्न**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for C++ Microsoft PowerPoint की आवश्यकता के बिना प्रेजेंटेशन फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX परिवर्तन सभी सामग्री को बिल्कुल संरक्षित करेगा?**

यह सामान्य प्रेजेंटेशन सामग्री को संरक्षित करता है, लेकिन प्रत्येक लेगेसी या असमर्थित सुविधा के लिए सटीक सटीकता की गारंटी नहीं है। जब उत्पन्न फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशिष्ट एनीमेशन, या दुर्लभ फ़ॉन्ट्स हों तो फ़ाइल की समीक्षा करें।

**क्या मैं पासवर्ड‑सुरक्षित PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि आप फ़ाइल को लोड करते समय सही पासवर्ड प्रदान करते हैं। यदि पासवर्ड अनुपलब्ध या गलत है तो लोड ऑपरेशन विफल हो जाता है।

**क्या मुझे परिवर्तन के बाद PPT फ़ाइल हटानी चाहिए?**

मूल फ़ाइल को तब तक रखें जब तक आप उन व्यूअर्स और कार्यप्रवाहों में PPTX की पुष्टि नहीं कर लेते जो आपके लिए महत्वपूर्ण हैं। यदि कोई लेगेसी सुविधा अलग ढंग से बदलती है तो यह एक रोलबैक प्रतिलिपि प्रदान करता है।