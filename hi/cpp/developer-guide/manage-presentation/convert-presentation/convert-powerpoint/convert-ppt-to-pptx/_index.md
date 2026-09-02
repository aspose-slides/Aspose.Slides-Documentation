---
title: C++ में PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/cpp/convert-ppt-to-pptx/
keywords:
- PowerPoint परिवर्तित करें
- प्रेज़ेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रेज़ेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में लेगेसी PPT फ़ाइलों को PPTX में परिवर्तित करें। इसमें एकल फ़ाइल और बैच परिवर्तन के लिए C++ उदाहरण, त्रुटि हैंडलिंग, और सटीकता नोट्स शामिल हैं।"
---
## **अवलोकन**

PPT लेगेसी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for C++ Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर सकता है और इसे PPTX के रूप में सहेज सकता है। यह लेख दिखाता है कि कैसे एक फ़ाइल या फ़ाइलों की डायरेक्टरी को परिवर्तित किया जाए और परिवर्तित करने के बाद क्या जांचना चाहिए।

## **PPT फ़ाइल को PPTX में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास से लोड करें, फिर [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) को [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) के साथ कॉल करें। जब प्रस्तुति अब आवश्यक न हो तो इसे डिस्पोज़ करके संसाधन मुक्त कर दें।

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

फ़ाइल एक्स्टेंशन स्वयं आउटपुट फ़ॉर्मेट नहीं चुनता; यह [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) तर्क करता है। यदि आपको मूल PPT फ़ाइल को बनाए रखना है तो इनपुट और आउटपुट पाथ अलग रखें।

## **एकाधिक PPT फ़ाइलों को बदलें**

निम्नलिखित उदाहरण एक डायरेक्टरी में सभी `.ppt` फ़ाइलों को बदलता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस होती है, इसलिए एक विफल परिवर्तन बाकी बैच को नहीं रोकता।

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

प्रोडक्शन कार्यभार के लिए, पूर्ण अपवाद को लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और विफल फ़ाइल नामों को रीट्राई या रिव्यू क्यू में लिखें। भ्रष्ट फ़ाइलें, पासवर्ड‑सुरक्षित फ़ाइलें बिना आवश्यक पासवर्ड के खोलना, पहुँच न होने वाले पाथ, और असमर्थित सामग्री सभी परिवर्तन विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलें लोड करने के लिए [Password-Protected Presentations](/slides/hi/cpp/password-protected-presentation/) देखें।

## **सटीकता और लेगेसी फीचर**

परिवर्तन सामान्यतः स्लाइड्स, मास्टर, लेआउट, टेक्स्ट, शैप्स, इमेजेज, टेबल्स और चार्ट्स को संरक्षित करता है। हालांकि, PPT और PPTX हर फीचर को बिल्कुल समान रूप में नहीं दर्शाते। एक लेगेसी फीचर जिसके पास PPTX समकक्ष नहीं है, या जो लाइब्रेरी द्वारा समर्थित नहीं है, उसे सामान्यीकृत, हटा या अलग ढंग से दिखाया जा सकता है।

जब परिवर्तित फ़ाइल में एनिमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, असामान्य फोंट या VBA मैक्रो हों, तो फ़ाइल की जाँच करें। साधारण PPTX फ़ाइल मैक्रो‑सक्षम फ़ॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उचित मैक्रो‑सक्षम वर्कफ़्लो उपयोग करें। यह भी सत्यापित करें कि आवश्यक फोंट और बाहरी संसाधन उस पर्यावरण में उपलब्ध हों जहाँ परिवर्तित प्रस्तुति खोली या रेंडर की जाएगी।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामेटिकली फिर से खोलें और मुख्य स्लाइड संख्या और सामग्री जांचें, फिर इच्छित व्यूअर में उसकी रूपरेखा और स्लाइड‑शो व्यवहार की तुलना करें। सफल [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) कॉल को यह प्रमाण न मानें कि हर लेगेसी फीचर का सटीक PPTX प्रतिनिधित्व है।

## **जब PPTX का उपयोग करें**

PPTX का उपयोग करें जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाले सिस्टमों के बीच साझा किया जाएगा, या ऐसे फ़ॉर्मेट में संग्रहीत किया जाएगा जो लेगेसी बाइनरी PPT से अधिक निरीक्षण और पुनर्प्राप्ति में आसान हो। जब तक परिवर्तित प्रस्तुति आपके सटीकता जाँच पास नहीं कर ले, मूल PPT को अभिलेखीय या रोलबैक कॉपी के रूप में रखें।

यदि आपको PDF, HTML, इमेजेज, XPS, या अन्य आउटपुट टाइप चाहिए, तो सभी लक्ष्यों के संपादन योग्य PowerPoint फ़ीचर संरक्षित रखने का अनुमान लगाने के बजाय [Convert Presentations to Multiple Formats](/slides/hi/cpp/convert-presentation/) में दी गई फ़ॉर्मेट‑विशिष्ट गाइडेंस का उपयोग करें।

## **ऑनलाइन कनवर्टर**

कभी‑कभी फाइल या त्वरित तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। पुनरावृत्त परिवर्तन, बैच प्रोसेसिंग, या एप्लीकेशन‑लेवल एरर हैंडलिंग के लिए, C++ API का उपयोग करें।

## **संबंधित लेख**

- [C++ में प्रस्तुतियों को सहेजें](/slides/hi/cpp/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट्स](/slides/hi/cpp/supported-file-formats/)
- [C++ में प्रस्तुतियों को खोलें](/slides/hi/cpp/open-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Microsoft PowerPoint इंस्टॉल किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for C++ Microsoft PowerPoint की आवश्यकता के बिना प्रस्तुति फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX परिवर्तन सभी सामग्री को बिल्कुल सटीक रूप से संरक्षित करेगा?**

यह सामान्य प्रस्तुति सामग्री को संरक्षित करता है, लेकिन हर लेगेसी या असमर्थित फीचर के लिए सटीक सटीकता गारंटीकृत नहीं है। जब उत्पन्न फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशेष एनीमेशन, या असामान्य फ़ॉन्ट हों तो फ़ाइल की समीक्षा करें।

**क्या मैं पासवर्ड‑सुरक्षित PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि आप फ़ाइल लोड करते समय सही पासवर्ड प्रदान करते हैं। यदि पासवर्ड गायब या गलत है तो लोड ऑपरेशन विफल हो जाएगा।

**क्या मुझे परिवर्तन के बाद PPT फ़ाइल को हटाना चाहिए?**

अपनी आवश्यक व्यूअर्स और वर्कफ़्लो में PPTX की जाँच करने तक मूल फ़ाइल को रखें। यदि कोई लेगेसी फीचर अलग रूप में बदलता है तो यह रोलबैक कॉपी प्रदान करता है।