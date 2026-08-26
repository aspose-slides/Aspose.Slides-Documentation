---
title: C++ में प्रस्तुतियों की पासवर्ड सुरक्षा
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/cpp/password-protected-presentation/
keywords:
- पासवर्ड-रक्षित प्रस्तुति
- ओपनिंग पासवर्ड
- PowerPoint एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति पासवर्ड मान्य करें
- प्रस्तुति पासवर्ड जांचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में पासवर्ड-रक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पहचान, मान्य, खोलें और डिक्रिप्ट करें।"
---
## **अवलोकन**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। प्रस्तुति सामग्री को लोड और देखने के लिए सही पासवर्ड आवश्यक है, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक ओपनिंग पासवर्ड write‑protection पासवर्ड से अलग होता है। Write‑protection संशोधन को सीमित करता है लेकिन सामग्री को एन्क्रिप्ट नहीं करता या प्रस्तुति को लोड होने से नहीं रोकता। प्रस्तुतियों को संशोधित करने के पासवर्ड प्रबंधित करने के लिए, देखें [Write‑Protect Presentations](/slides/hi/cpp/write-protected-presentation/)।

नीचे दिए गए वर्कफ़्लो दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों फ़ॉर्मैट का उपयोग करते हैं जहाँ फ़ाइल‑आधारित और स्ट्रीम‑आधारित व्यवहार महत्वपूर्ण है।

## **एक ओपनिंग पासवर्ड के साथ प्रस्तुति को एन्क्रिप्ट करें**

एक ओपनिंग पासवर्ड सौंपने के लिए [IProtectionManager::Encrypt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/encrypt/) का उपयोग करें। फिर एन्क्रिप्टेड प्रस्तुति को सहेजने के लिए [IPresentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/save/) का उपयोग करें।

निम्न उदाहरण एक PPTX प्रस्तुति को एन्क्रिप्ट करता है:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **एक एन्क्रिप्टेड प्रस्तुति लोड करें**

[LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) को ओपनिंग पासवर्ड पर सेट करें और फ़ाइल लोड करते समय विकल्प को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) में पास करें। जब ओपनिंग पासवर्ड आवश्यक होता है लेकिन दिया गया पासवर्ड अनुपलब्ध या गलत होता है, तो लोडिंग विफल हो जाती है।

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// डिक्रिप्टेड प्रस्तुति के साथ काम करें।
```

## **एक प्रस्तुति से एन्क्रिप्शन हटाएँ**

प्रस्तुति को उसके ओपनिंग पासवर्ड के साथ लोड करें, [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/removeencryption/) को कॉल करें, और परिणाम को सहेजें। सहेजी गई प्रस्तुति को तब पासवर्ड के बिना लोड किया जा सकता है।

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **लोड करने से पहले ओपनिंग पासवर्ड को मान्य करें**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) का उपयोग करके पूरा प्रस्तुति इंस्टेंस बनाए बिना [IPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/) प्राप्त करें। पासवर्ड अनुरोध या मान्यकरण से पहले [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) को जांचें। जब सुरक्षा मौजूद हो, तो प्रदान किए गए मान को [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/checkpassword/) से मान्य करें।

### **फ़ाइल‑पथ वर्कफ़्लो**

निम्न उदाहरण एक PPTX फ़ाइल के लिए ओपनिंग पासवर्ड को मान्य करता है, मान्य किए गए मान को [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) को पास करता है, और फिर पूरी प्रस्तुति को लोड करता है:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **स्ट्रीम वर्कफ़्लो**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) का स्ट्रीम ओवरलोड वही वर्कफ़्लो प्रदान करता है। स्ट्रीम से पूरी प्रस्तुति लोड करने से पहले एक seekable स्ट्रीम की स्थिति रीसेट करें।

निम्न उदाहरण एक PPT फ़ाइल का उपयोग करता है:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **CheckPassword रिटर्न वैल्यूज़**

जब प्रस्तुति में ओपनिंग पासवर्ड हो और दिया गया पासवर्ड सही हो, तभी [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/checkpassword/) `true` लौटाता है। यह निम्नलिखित मामलों में `false` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में ओपनिंग पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड null या खाली है।

यह व्यवहार PPT और PPTX प्रस्तुतियों के लिए समान है।

## **क्या लोड की गई प्रस्तुति एन्क्रिप्टेड है, जांचें**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, यह पुष्टि करने के लिए [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) को देखें कि स्रोत प्रस्तुति एन्क्रिप्टेड थी। लोड करने से पहले ओपनिंग‑पासवर्ड सुरक्षा का पता लगाने के लिए, ऊपर दिखाए अनुसार `IPresentationInfo::get_IsPasswordProtected` का उपयोग करें।

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **सुरक्षा सिफ़ारिशें**

{{% alert color="warning" title="Security" %}}
ओपनिंग पासवर्ड को लॉग न करें या निदान संदेशों में शामिल न करें। अनावश्यक पुनः‑मान्यकरण प्रयासों से बचें, पासवर्ड को केवल आवश्यक अवधि तक मेमोरी में रखें, और प्रस्तुति को तुरंत लोड करते समय सफल मान्यकरण परिणाम को पुनः प्रयोग करें।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड‑प्रोटेक्ट करें**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रस्तुति का चयन करें या उसे अपलोड करें।
3. व्यू प्रोटेक्शन के लिए पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिए एक अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और परिणामी फ़ाइल डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [Write‑Protect Presentations](/slides/hi/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**ओपनिंग पासवर्ड और write‑protection पासवर्ड में क्या अंतर है?**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और इसकी सामग्री लोड करने के लिए आवश्यक होता है। एक write‑protection पासवर्ड सामग्री को एन्क्रिप्ट किए बिना संशोधन को सीमित करता है।

**क्या मैं सभी स्लाइड्स लोड किए बिना ओपनिंग पासवर्ड को मान्य कर सकता हूँ?**

हां। प्रस्तुति जानकारी प्राप्त करें, देखें कि ओपनिंग‑पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाने से पहले पासवर्ड को मान्य करें।

**क्या पासवर्ड‑जांच वर्कफ़्लो PPT और PPTX दोनों को सपोर्ट करते हैं?**

हां। फ़ाइल‑पथ और स्ट्रीम‑आधारित पासवर्ड का पता लगाने और मान्यकरण का व्यवहार PPT और PPTX प्रस्तुतियों के लिए समान है।