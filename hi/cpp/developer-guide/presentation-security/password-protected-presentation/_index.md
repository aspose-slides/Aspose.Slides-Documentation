---
title: "C++ में प्रस्तुतियों को पासवर्ड-से सुरक्षित करें"
linktitle: "पासवर्ड सुरक्षा"
type: docs
weight: 20
url: /hi/cpp/password-protected-presentation/
keywords:
- "पासवर्ड-रक्षित प्रस्तुति"
- "खोलने वाला पासवर्ड"
- "PowerPoint एन्क्रिप्ट करें"
- "PowerPoint डिक्रिप्ट करें"
- "प्रस्तुति पासवर्ड सत्यापित करें"
- "प्रस्तुति पासवर्ड जांचें"
- "एन्क्रिप्टेड प्रस्तुति खोलें"
- "एन्क्रिप्शन हटाएँ"
- "PowerPoint"
- "PPT"
- "PPTX"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "C++ में Aspose.Slides के साथ पासवर्ड-रक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पहचान, सत्यापित, खोल और डिक्रिप्ट करें।"
---
## **परिचय**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सही पासवर्ड आवश्यक होता है ताकि प्रस्तुति की सामग्री लोड और देखी जा सके, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

ओपनिंग पासवर्ड लिखने‑सुरक्षा पासवर्ड से अलग होता है। लिखने‑सुरक्षा संशोधन को प्रतिबंधित करती है लेकिन सामग्री को एन्क्रिप्ट नहीं करती और प्रस्तुति को लोड होने से नहीं रोकती। प्रस्तुतियों को संशोधित करने के लिए पासवर्ड प्रबंधित करने हेतु देखें [Write-Protect Presentations](/slides/hi/cpp/write-protected-presentation/)।

नीचे दिए गए वर्कफ़्लो दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों फ़ॉर्मेट का उपयोग करते हैं जहाँ फ़ाइल‑आधारित और स्ट्रीम‑आधारित व्यवहार महत्व रखता है।

## **ओपनिंग पासवर्ड के साथ प्रस्तुति एन्क्रिप्ट करें**

ओपनिंग पासवर्ड निर्धारित करने के लिए [IProtectionManager::Encrypt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/encrypt/) का उपयोग करें। फिर एन्क्रिप्टेड प्रस्तुति को सहेजने हेतु [IPresentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/save/) का उपयोग करें।

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

## **डॉक्यूमेंट प्रॉपर्टीज़ को सार्वजनिक रखें**

डिफ़ॉल्ट रूप से Aspose.Slides प्रस्तुति एन्क्रिप्शन में डॉक्यूमेंट प्रॉपर्टीज़ को शामिल करता है। [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) इस व्यवहार को स्लाइड‑सामग्री एन्क्रिप्शन से स्वतंत्र रूप से नियंत्रित करता है। जब कोई इंडेक्सिंग, वर्गीकरण, खोज या डॉक्यूमेंट‑मैनेजमेंट सिस्टम बिना ओपनिंग पासवर्ड के मेटाडेटा पढ़ना आवश्यक हो, तब इस मेथड को कॉल करने से पहले `false` पास करें और फिर [IProtectionManager::Encrypt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/encrypt/) को बुलाएँ।

निम्न उदाहरण एक एन्क्रिप्टेड PPTX प्रस्तुति बनाता है जबकि उसकी अंतर्निर्मित डॉक्यूमेंट प्रॉपर्टीज़ सार्वजनिक रहती हैं:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`set_EncryptDocumentProperties` को `false` पास करने से स्लाइड, मास्टर, लेआउट, शेप, मीडिया या अन्य प्रस्तुति सामग्री सार्वजनिक नहीं होती। यह केवल डॉक्यूमेंट प्रॉपर्टीज़ को प्रभावित करता है। एन्क्रिप्टेड सामग्री लोड किए बिना उन प्रॉपर्टीज़ को पढ़ने के लिए देखें [Manage Presentation Properties](/slides/hi/cpp/presentation-properties/)।

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

[LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) को ओपनिंग पासवर्ड सेट करें और फ़ाइल लोड करते समय विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) को पास करें। जब ओपनिंग पासवर्ड आवश्यक हो लेकिन प्रदान किया गया पासवर्ड अनुपलब्ध या गलत हो, तो लोडिंग विफल हो जाएगी।

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// डिक्रिप्टेड प्रस्तुति के साथ काम करें।
```

## **प्रस्तुति से एन्क्रिप्शन हटाएँ**

ओपनिंग पासवर्ड के साथ प्रस्तुति लोड करें, फिर [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/removeencryption/) को कॉल करें और परिणाम सहेजें। सहेजी गई प्रस्तुति अब बिना पासवर्ड के लोड की जा सकती है।

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

## **लोड करने से पहले ओपनिंग पासवर्ड सत्यापित करें**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) का उपयोग करके पूर्ण प्रस्तुति इंस्टेंस बनाए बिना [IPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/) प्राप्त करें। पासवर्ड अनुरोधित या सत्यापित करने से पहले [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) की जाँच करें। जब सुरक्षा उपस्थित हो, तो आपूर्ति किए गए मान को [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/checkpassword/) से सत्यापित करें।

### **फ़ाइल‑पाथ वर्कफ़्लो**

निम्न उदाहरण PPTX फ़ाइल के लिए ओपनिंग पासवर्ड को वैध करता है, वैध मान को [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) को पास करता है, और फिर पूरी प्रस्तुति लोड करता है:

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

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) का स्ट्रीम ओवरलोड भी वही वर्कफ़्लो प्रदान करता है। पूर्ण प्रस्तुति को उस स्ट्रीम से लोड करने से पहले सीकियेबल स्ट्रीम की पोजीशन रीसेट करें।

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

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/checkpassword/) केवल तब `true` रिटर्न करता है जब प्रस्तुति में ओपनिंग पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह प्रत्येक निम्न स्थितियों में `false` रिटर्न करता है:

- पासवर्ड गलत है।
- प्रस्तुति में ओपनिंग पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड null या खाली है।

यह व्यवहार PPT और PPTX दोनों प्रस्तुतियों के लिए समान है।

## **जाँचें कि लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) की जाँच करके पुष्टि करें कि स्रोत प्रस्तुति एन्क्रिप्टेड थी। लोड करने से पहले ओपनिंग‑पासवर्ड सुरक्षा का पता लगाने के लिए ऊपर दिखाए अनुसार `IPresentationInfo::get_IsPasswordProtected` का उपयोग करें।

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

## **सुरक्षा सिफारिशें**

{{% alert color="warning" title="सुरक्षा" %}}
ओपनिंग पासवर्ड को लॉग न करें या उन्हें डायग्नोस्टिक संदेशों में शामिल न करें। अनावश्यक दोहराए गए वैधता प्रयासों से बचें, पासवर्ड को केवल आवश्यकता के समय मेमोरी में रखें, और तुरंत प्रस्तुति लोड करने पर सफल वैधता परिणाम को पुनः प्रयोग करें।

सार्वजनिक डॉक्यूमेंट प्रॉपर्टीज़ लेखक का नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी और कस्टम मान प्रकट कर सकती हैं, जबकि प्रस्तुति सामग्री एन्क्रिप्टेड रहती है। संवेदनशील मेटाडेटा को प्रस्तुति के साथ एन्क्रिप्ट करें। प्रॉपर्टीज़ को सार्वजनिक रखने का निर्णय केवल तब ही स्पष्ट रूप से लें जब सिस्टम को फ़ाइल को इंडेक्स, वर्गीकृत, खोज या प्रबंधित करने की आवश्यकता हो बिना ओपनिंग पासवर्ड के।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड‑सुरक्षित करें**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
1. प्रस्तुति चुनें या अपलोड करें।
1. दृश्य सुरक्षा के लिए पासवर्ड दर्ज करें।
1. वैकल्पिक रूप से संपादन सुरक्षा के लिए अलग पासवर्ड दर्ज करें।
1. सुरक्षा लागू करें और परिणामी फ़ाइल डाउनलोड करें।

{{% alert color="info" title="संबंधित देखें" %}}
- [Write-Protect Presentations](/slides/hi/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **प्रश्नोत्तरी**

**ओपनिंग पासवर्ड और लिखने‑सुरक्षा पासवर्ड में क्या अंतर है?**

ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री लोड करने के लिए आवश्यक होता है। लिखने‑सुरक्षा पासवर्ड संशोधन को प्रतिबंधित करता है बिना सामग्री को एन्क्रिप्ट किए।

**क्या मैं सभी स्लाइड लोड किए बिना ओपनिंग पासवर्ड सत्यापित कर सकता हूँ?**

हां। प्रस्तुति जानकारी प्राप्त करें, जाँचें कि ओपनिंग‑पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाने से पहले पासवर्ड को सत्यापित करें।

**क्या कोई एप्लिकेशन ओपनिंग पासवर्ड के बिना मेटाडेटा पढ़ सकता है?**

हां, लेकिन केवल तब जब प्रस्तुति को `set_EncryptDocumentProperties(false)` के साथ एन्क्रिप्ट किया गया हो। उस स्थिति में एप्लिकेशन को [Manage Presentation Properties](/slides/hi/cpp/presentation-properties/) में वर्णित डॉक्यूमेंट‑प्रॉपर्टीज‑ओनली लोडिंग मोड का उपयोग करना होगा।

**क्या पासवर्ड‑जाँच वर्कफ़्लो PPT और PPTX दोनों के लिए समर्थित हैं?**

हां। फ़ाइल‑पाथ और स्ट्रीम‑आधारित पासवर्ड डिटेक्शन और वैधता PPT और PPTX दोनों प्रस्तुतियों के लिए समान व्यवहार प्रदर्शित करता है।