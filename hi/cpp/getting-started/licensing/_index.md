---
title: "लाइसेंसिंग"
type: docs
weight: 120
url: /hi/cpp/licensing/
keywords:
- "लाइसेंस"
- "अस्थायी लाइसेंस"
- "लाइसेंस सेट करें"
- "लाइसेंस का उपयोग करें"
- "लाइसेंस सत्यापित करें"
- "लाइसेंस फ़ाइल"
- "मूल्यांकन संस्करण"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ में लाइसेंस लागू करें, प्रबंधित करें और समस्याओं का समाधान करें। हमारे चरण‑दर‑चरण लाइसेंसिंग गाइड के साथ पूर्ण सुविधाओं तक निरंतर पहुंच सुनिश्चित करें।"
---
## **अवलोकन**

Aspose.Slides का उपयोग मूल्यांकन मोड में या वैध लाइसेंस के साथ किया जा सकता है। मूल्यांकन संस्करण लाइसेंस प्राप्त संस्करण के समान कार्यक्षमता प्रदान करता है, लेकिन यह प्रत्येक सहेजी गई प्रस्तुति की प्रत्येक स्लाइड में एक मूल्यांकन वॉटरमार्क जोड़ता है और आपके कोड द्वारा प्रस्तुतियों से पढ़े जाने वाले पाठ को छोटा कर देता है।

यह लेख समझाता है कि Aspose.Slides में लाइसेंसिंग कैसे काम करती है और लाइब्रेरी का उपयोग करने से पहले लाइसेंस कैसे लागू किया जाए। `License` क्लास का उपयोग करके लाइसेंस को फाइल या स्ट्रीम से लोड किया जा सकता है। यह लेख यह भी दिखाता है कि लाइसेंस सही तरीके से लागू हुआ है या नहीं, कैसे सत्यापित करें।

## **Aspose.Slides का मूल्यांकन**

{{% alert color="info" title="Note" %}}
आप **Aspose.Slides for C++** का मूल्यांकन संस्करण [उसके NuGet डाउनलोड पेज](https://www.nuget.org/packages/Aspose.Slides.Cpp/) से या ज़िप पैकेज के रूप में [डाउनलोड पेज](https://releases.aspose.com/slides/cpp/) से डाउनलोड कर सकते हैं। मूल्यांकन संस्करण लाइसेंस प्राप्त उत्पाद के समान कार्यक्षमता प्रदान करता है। वास्तव में, मूल्यांकन पैकेज खरीदी गई पैकेज के समान ही है—यह केवल कुछ कोड लाइनों को जोड़ने के बाद लाइसेंस प्राप्त हो जाता है।

जब आप **Aspose.Slides** के मूल्यांकन से संतुष्ट हो जाएँ, तो आप [लाइसेंस खरीद सकते हैं](https://purchase.aspose.com/pricing/slides/cpp/)। हम उपलब्ध सब्सक्रिप्शन प्रकारों की समीक्षा करने की सलाह देते हैं। यदि आपके पास कोई प्रश्न हों, तो नि:संकोच Aspose बिक्री टीम से संपर्क करें।

प्रत्येक Aspose लाइसेंस में एक वर्ष की सब्सक्रिप्शन शामिल होती है, जिसमें नई संस्करण और बग फ़िक्सेस जैसी मुफ्त अपडेट शामिल हैं। चाहे आप लाइसेंस प्राप्त संस्करण उपयोग कर रहे हों या मूल्यांकन संस्करण, आपको मुफ्त और असीमित तकनीकी समर्थन मिलता है।
{{% /alert %}}

**मूल्यांकन संस्करण की सीमाएँ**

* मूल्यांकन संस्करण (बिना किसी लाइसेंस के) पूरी उत्पाद कार्यक्षमता प्रदान करता है, लेकिन यह प्रत्येक सहेजी गई प्रस्तुति की प्रत्येक स्लाइड में एक मूल्यांकन वॉटरमार्क टेक्स्ट बॉक्स जोड़ता है।
* आपके कोड द्वारा प्रस्तुति से पढ़ा गया टेक्स्ट पहले कुछ अक्षरों तक सीमित किया जाता है, उसके बाद मूल्यांकन सीमा के बारे में एक नोटिस जोड़ा जाता है। आपके कोड द्वारा लिखा गया टेक्स्ट पूरा सहेजा जाता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides को बिना सीमाओं के परीक्षण करने के लिए, आप **30-Day Temporary License** का अनुरोध कर सकते हैं। अधिक जानकारी के लिए, [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) पेज देखें।
{{% /alert %}}

## **Aspose.Slides में लाइसेंसिंग**

* एक मूल्यांकन संस्करण लाइसेंस खरीदने और कुछ कोड लाइनों को जोड़कर लाइसेंस लागू करने के बाद लाइसेंस प्राप्त हो जाता है।
* लाइसेंस एक साधारण टेक्स्ट XML फाइल है जिसमें उत्पाद का नाम, लाइसेंस प्राप्त डेवलपर्स की संख्या, सब्सक्रिप्शन समाप्ति तिथि आदि विवरण होते हैं।
* लाइसेंस फाइल डिजिटल रूप से साइन की गई ہوتی है, इसलिए इसे संशोधित नहीं किया जाना चाहिए। यहां तक कि एक आकस्मिक परिवर्तन—जैसे लाइन ब्रेक जोड़ना—भी फाइल को अमान्य कर देगा।
* जब आप फाइल नाम बिना फ़ोल्डर के पास करते हैं, तो Aspose.Slides for C++ केवल वर्तमान कार्यशील डायरेक्टरी में लाइसेंस फाइल खोजता है। यह आपके एक्सीक्यूटेबल या Aspose.Slides लाइब्रेरी के फ़ोल्डर को नहीं खोजता, इसलिए यदि लाइसेंस फाइल कहीं और संग्रहीत है तो पूर्ण पथ पास करें।
* मूल्यांकन संस्करण की सीमाओं से बचने के लिए, आपको Aspose.Slides का उपयोग करने से पहले लाइसेंस सेट करना चाहिए। एक लाइसेंस को प्रत्येक एप्लिकेशन या प्रोसेस में केवल एक बार सेट करने की आवश्यकता होती है।

## **लाइसेंस लागू करें**

लाइसेंस को **फ़ाइल** या **स्ट्रीम** से लोड किया जा सकता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides लाइसेंसिंग संचालन के लिए [License](https://reference.aspose.com/slides/cpp/aspose.slides/license/) क्लास प्रदान करता है।
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
नए लाइसेंस केवल संस्करण 21.4 या उसके बाद के साथ Aspose.Slides को सक्रिय कर सकते हैं। पहले के संस्करण अलग लाइसेंसिंग सिस्टम उपयोग करते हैं और इन लाइसेंसों को पहचान नहीं पाएंगे।
{{% /alert %}}

### **फ़ाइल**

लाइसेंस सेट करने का सबसे आसान तरीका है लाइसेंस फ़ाइल को आपके प्रोग्राम की कार्यशील डायरेक्टरी में रखें और केवल फ़ाइल नाम निर्दिष्ट करें, पथ के बिना। अन्यथा, फ़ाइल का पूर्ण पथ निर्दिष्ट करें।

निम्नलिखित C++ कोड कार्यशील डायरेक्टरी से लाइसेंस फ़ाइल *Aspose.Slides.lic* को लागू करता है:
```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

यदि लाइसेंस वैध है, तो [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) लौटता है और प्रोग्राम बिना किसी आउटपुट के समाप्त हो जाता है; इसके बाद, Aspose.Slides मूल्यांकन सीमाओं के बिना कार्य करता है। यदि फ़ाइल कार्यशील डायरेक्टरी में नहीं है, तो मेथड एक [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) उत्पन्न करता है जिसमें संदेश *License "Aspose.Slides.lic" doesn't exist or access is restricted* होता है। उदाहरण अपवाद को संभालता नहीं है, इसलिए प्रोग्राम रुक जाता है।

{{% alert color="warning" title="Warning" %}}
यदि आप लाइसेंस फ़ाइल को किसी अलग डायरेक्टरी में रखते हैं, तो जब आप [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) मेथड को कॉल करते हैं, तो निर्दिष्ट स्पष्ट पथ के अंत में फ़ाइल नाम बिल्कुल आपके लाइसेंस फ़ाइल के नाम से मेल खाना चाहिए।

उदाहरण के लिए, यदि आप अपनी लाइसेंस फ़ाइल का नाम *Aspose.Slides.lic.xml* रखते हैं, तो आपको अपने कोड में [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) मेथड को पूर्ण पथ देना होगा जो *Aspose.Slides.lic.xml* से समाप्त होता हो।
{{% /alert %}}

### **स्ट्रीम**

जब आपका प्रोग्राम लाइसेंस को फ़ाइल के रूप में नहीं रखता जिसे वह नाम दे सके, उदाहरण के लिए जब वह लाइसेंस को डेटाबेस से पढ़ता है, तब लाइसेंस को स्ट्रीम से लोड करें। [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) किसी भी [Stream](https://reference.aspose.com/slides/cpp/system.io/stream/) को स्वीकार करता है जिसमें लाइसेंस हो। उदाहरण छोटा रखने के लिए, निम्नलिखित C++ कोड कार्यशील डायरेक्टरी में *Aspose.Slides.lic* को [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) के साथ खोलता है और उस स्ट्रीम से लाइसेंस लागू करता है:
```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

एक वैध लाइसेंस फ़ाइल उदाहरण के समान परिणाम देता है। यदि फ़ाइल मौजूद नहीं है, तो लाइसेंस लागू होने से पहले [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) एक [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) उत्पन्न करता है, और प्रोग्राम रुक जाता है।

## **लाइसेंस को मान्य करें**

जांचने के लिए कि लाइसेंस सही तरीके से सेट किया गया है या नहीं, [License::IsLicensed](https://reference.aspose.com/slides/cpp/aspose.slides/license/islicensed/) को कॉल करें। यह केवल वैध लाइसेंस लागू होने के बाद `true` लौटाता है, और उससे पहले `false`। निम्नलिखित C++ कोड कार्यशील डायरेक्टरी से लाइसेंस फ़ाइल लागू करता है और फिर इसे जांचता है:
```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

वैध लाइसेंस के साथ, प्रोग्राम *License is good!* प्रिंट करता है। यदि फ़ाइल गायब है या लाइसेंस फ़ाइल नहीं है, तो जाँच से पहले [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) एक अपवाद उछालता है, और प्रोग्राम कुछ भी प्रिंट किए बिना रुक जाता है। यदि फ़ाइल ऐसा लाइसेंस है जिसकी हस्ताक्षर मेल नहीं खाती, उदाहरण के लिए क्योंकि उसे संपादित किया गया है, तो SetLicense बिना त्रुटि के लौटता है लेकिन `IsLicensed` `false` लौटाता है, इसलिए कुछ भी प्रिंट नहीं होता और Aspose.Slides मूल्यांकन मोड में रहता है।

## **थ्रेड सुरक्षा**

{{% alert color="warning" title="Warning" %}}
[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) मेथड **थ्रेड-सेफ नहीं** है। यदि आपको इस मेथड को कई थ्रेड्स से एक साथ कॉल करना है, तो संभावित समस्याओं से बचने के लिए सिंक्रनाइज़ेशन प्रिमिटिव (जैसे लॉक) का उपयोग करने की सलाह दी जाती है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं लाइसेंस को पूरी तरह से ऑफ़लाइन वातावरण (बिना इंटरनेट एक्सेस) में लागू कर सकता हूँ?
हाँ। लाइसेंस सत्यापन लाइसेंस फ़ाइल का उपयोग करके स्थानीय रूप से किया जाता है; इंटरनेट कनेक्शन की आवश्यकता नहीं है।

### एक साल की सब्सक्रिप्शन समाप्त होने के बाद क्या होता है? क्या लाइब्रेरी काम करना बंद कर देगी?
नहीं। लाइसेंस स्थायी है: आप अपनी सब्सक्रिप्शन समाप्ति तिथि से पहले जारी किए गए संस्करणों का उपयोग जारी रख सकते हैं; लेकिन नई रिलीज़ उपयोग करने के लिए नवीनीकरण आवश्यक होगा।