---
title: C++ में प्रस्तुतियों को लिखित‑सुरक्षित बनाना
linktitle: लिखित सुरक्षा
type: docs
weight: 25
url: /hi/cpp/write-protected-presentation/
keywords:
- लिखित सुरक्षा
- PowerPoint लिखित‑सुरक्षा
- संशोधित करने का पासवर्ड
- प्रस्तुति संपादन प्रतिबंधित करें
- लिखित सुरक्षा हटाएँ
- संशोधन पासवर्ड सत्यापित करें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint PPT और PPTX प्रस्तुतियों में लिखित‑सुरक्षा पासवर्ड को सेट, डिटेक्ट, वैधता जांचें और हटाएँ।"
---
## **परिचय**

एक लिखित‑सुरक्षा पासवर्ड प्रस्तुति में संशोधन को प्रतिबंधित करता है लेकिन उसकी सामग्री को एन्क्रिप्ट नहीं करता। उपयोगकर्ता बिना पासवर्ड के लिखित‑सुरक्षित प्रस्तुति को लोड और देख सकते हैं। एप्लिकेशन के आधार पर, वे सामग्री को संपादित करके इसे किसी अन्य नाम से सहेज भी सकते हैं, इसलिए लिखित सुरक्षा को गोपनीयता तंत्र नहीं माना जाना चाहिए।

एक खोलने वाला पासवर्ड अलग उद्देश्य रखता है: यह प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री को लोड करने के लिए आवश्यक है। प्रस्तुति को एन्क्रिप्ट करने या खोलने वाले पासवर्ड को मान्य करने के लिए, देखें [Password-Protect Presentations](/slides/hi/cpp/password-protected-presentation/)।

इस लेख में कार्यप्रवाह दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण PPTX फ़ाइलों का उपयोग करते हैं; PPT में सहेजते समय, `.ppt` एक्सटेंशन और संबंधित PPT सहेजने प्रारूप का उपयोग करें।

## **प्रस्तुति पर लिखित सुरक्षा सेट करें**

प्रस्तुति को संशोधित करने के लिए पासवर्ड सौंपने हेतु [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) का उपयोग करें। प्रस्तुति को सहेजने से सुरक्षा सेटिंग स्थायी रहती है।

निम्न उदाहरण PPTX प्रस्तुति पर लिखित सुरक्षा सेट करता है:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **लिखित‑सुरक्षित प्रस्तुति को लोड करें**

क्योंकि लिखित सुरक्षा प्रस्तुति की सामग्री को एन्क्रिप्ट नहीं करती, प्रस्तुति को लोड करने के लिए कोई पासवर्ड आवश्यक नहीं है। पासवर्ड केवल तब प्रासंगिक होता है जब सुरक्षित प्रस्तुति को संशोधित करने की अनुमति की पुष्टि की जाती है।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

लिखित‑सुरक्षा पासवर्ड को [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) में न पास करें। यह प्रॉपर्टी एन्क्रिप्टेड सामग्री के लिए खोलने वाला पासवर्ड स्वीकार करती है। यदि प्रस्तुति में दोनों सुरक्षा प्रकार हैं, तो उसे लोड करने के लिए खोलने वाला पासवर्ड प्रदान करें और लिखित‑सुरक्षा पासवर्ड को अलग से संभालें।

## **प्रस्तुति से लिखित सुरक्षा हटाएँ**

संशोधन प्रतिबंध हटाने हेतु [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) का उपयोग करें, फिर प्रस्तुति को सहेजें।

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **जाँचें कि प्रस्तुति लिखित‑सुरक्षित है या नहीं**

एक पूरी [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस बनाए बिना फ़ाइल का निरीक्षण करने के लिए, [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) को कॉल करें और [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) की जाँच करें। यह प्रॉपर्टी [NullableBool](https://reference.aspose.com/slides/hi/cpp/aspose.slides/nullablebool/) का उपयोग करती है और जब लिखित सुरक्षा पाई जाती है तो `NullableBool::True` लौटाती है।

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) का स्ट्रीम ओवरलोड, स्ट्रीम के रूप में प्रदान की गई प्रस्तुति के लिए समान जानकारी देता है।

## **लिखित‑सुरक्षा पासवर्ड को मान्य करें**

पूरा प्रस्तुति लोड किए बिना संशोधन पासवर्ड को मान्य करने हेतु [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) का उपयोग करें। पहले [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) को जाँचें ताकि एप्लिकेशन केवल तब पासवर्ड का अनुरोध या मान्य करे जब लिखित सुरक्षा मौजूद हो।

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) केवल लिखित‑सुरक्षा पासवर्ड को मान्य करता है। यह खोलने वाले पासवर्ड को मान्य नहीं करता या यह निर्धारित नहीं करता कि एन्क्रिप्टेड सामग्री लोड की जा सकती है या नहीं। इसके विपरीत, [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/checkpassword/) केवल खोलने वाले पासवर्ड को मान्य करता है। यदि पूरी प्रस्तुति पहले ही लोड हो चुकी है, तो [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) अपने प्रोटेक्शन मैनेजर के माध्यम से समान लिखित‑सुरक्षा जांच प्रदान करता है।

प्रोडक्शन अनुप्रयोगों में पासवर्ड को लॉग न करें या उन्हें डायग्नॉस्टिक संदेशों में शामिल न करें। अनावश्यक पुनः मान्यकरण प्रयासों से बचें, और पासवर्ड को मेमोरी में केवल आवश्यक अवधि तक रखें।

{{% alert color="info" title="संबंधित देखें" %}}
- [Password-Protect Presentations](/slides/hi/cpp/password-protected-presentation/)
- [Read-Only Presentations](/slides/hi/cpp/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या लिखित सुरक्षा प्रस्तुति को एन्क्रिप्ट करती है?**  
नहीं। यह संशोधन को प्रतिबंधित करती है लेकिन प्रस्तुति की सामग्री को लोड और देखने के लिए उपलब्ध रखती है।

**क्या लिखित‑सुरक्षा पासवर्ड को प्रस्तुति खोलने के लिए आवश्यक है?**  
नहीं। केवल एन्क्रिप्टेड प्रस्तुति सामग्री को लोड करने के लिए खोलने वाला पासवर्ड आवश्यक है।

**क्या एक प्रस्तुति में दोनों खोलने वाला पासवर्ड और लिखित‑सुरक्षा पासवर्ड हो सकते हैं?**  
हाँ। लोड विकल्पों के माध्यम से खोलने वाला पासवर्ड प्रदान करके एन्क्रिप्टेड प्रस्तुति को खोलें, और जब संशोधन की अनुमति चाहिए तो लिखित‑सुरक्षा पासवर्ड को अलग से मान्य करें।