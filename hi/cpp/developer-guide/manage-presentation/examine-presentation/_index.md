---
title: C++ में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/cpp/examine-presentation/
keywords:
- प्रस्तुति स्वरूप
- प्रस्तुति प्रॉपर्टीज़
- डॉक्यूमेंट प्रॉपर्टीज़
- प्रॉपर्टीज़ प्राप्त करें
- प्रॉपर्टीज़ पढ़ें
- प्रॉपर्टीज़ बदलें
- प्रॉपर्टीज़ संशोधित करें
- प्रॉपर्टीज़ अपडेट करें
- PPTX जाँचें
- PPT जाँचें
- ODP जाँचें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और स्मार्ट सामग्री ऑडिट्स के लिए।"
---
## **सारांश**

यह लेख दर्शाता है कि Aspose.Slides में प्रस्तुति जानकारी कैसे निरीक्षण की जाए। यह बताता है कि पूरी फ़ाइल को लोड किए बिना प्रस्तुति के वर्तमान फ़ॉर्मेट का निर्धारण कैसे किया जाए, उसकी डॉक्यूमेंट प्रॉपर्टीज़ को पढ़ा जाए, और आवश्यकता पड़ने पर उन प्रॉपर्टीज़ को अपडेट किया जाए।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/documentproperties/) APIs पर आधारित हैं और प्रस्तुति मेटाडेटा के साथ काम करने के सामान्य कार्यों को प्रदर्शित करते हैं।

## **प्रस्तुति फ़ॉर्मेट जाँचें**

कोई प्रस्तुति पर काम करने से पहले, आप यह जानना चाह सकते हैं कि वर्तमान में प्रस्तुति किस फ़ॉर्मेट (PPT, PPTX, ODP और अन्य) में है।

आप प्रस्तुति को लोड किए बिना उसकी फ़ॉर्मेट जाँच सकते हैं। इस C++ कोड को देखें:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **प्रस्तुति प्रॉपर्टीज़ प्राप्त करें**

यह C++ कोड दर्शाता है कि आप प्रस्तुति प्रॉपर्टीज़ (प्रस्तुति की जानकारी) कैसे प्राप्त कर सकते हैं:

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **प्रस्तुति प्रॉपर्टीज़ अपडेट करें**

Aspose.Slides [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) मेथड प्रदान करता है जो आपको प्रस्तुति प्रॉपर्टीज़ में बदलाव करने की अनुमति देता है।

मान लीजिए हमारे पास एक PowerPoint प्रस्तुति है जिसकी डॉक्यूमेंट प्रॉपर्टीज़ नीचे दिखायी गई हैं।

![PowerPoint प्रस्तुति की मूल डॉक्यूमेंट प्रॉपर्टीज़](input_properties.png)

यह कोड उदाहरण दर्शाता है कि आप कुछ प्रस्तुति प्रॉपर्टीज़ को कैसे संपादित कर सकते हैं:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

डॉक्यूमेंट प्रॉपर्टीज़ बदलने के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति की बदली हुई डॉक्यूमेंट प्रॉपर्टीज़](output_properties.png)

## **उपयोगी लिंक**

प्रस्तुति और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी के लिए, आप इन लिंक को उपयोगी पा सकते हैं:

- [प्रस्तुति को पासवर्ड से सुरक्षित करें](/slides/hi/cpp/password-protected-presentation/)
- [प्रस्तुति को लिखने से सुरक्षित करें](/slides/hi/cpp/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं यह कैसे जाँच सकता हूँ कि फ़ॉन्ट्स एम्बेडेड हैं या नहीं और कौन से हैं?**

[एम्बेडेड फ़ॉन्ट जानकारी](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/getembeddedfonts/) देखें, फिर उन प्रविष्टियों की तुलना [वास्तविक में उपयोग किए गए फ़ॉन्ट्स](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/getfonts/) के सेट से करें ताकि यह पहचाना जा सके कि रेंडरिंग के लिए कौन से फ़ॉन्ट्स महत्वपूर्ण हैं।

**मैं जल्दी से कैसे पता कर सकता हूँ कि फ़ाइल में छुपी हुई स्लाइड्स हैं या नहीं और उनकी संख्या क्या है?**

स्लाइड संग्रह [स्लाइड संग्रह](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidecollection/) के माध्यम से इटररेट करें और प्रत्येक स्लाइड के [विज़िबिलिटी फ़्लैग](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/get_hidden/) को जांचें।

**क्या मैं यह पता लगा सकता हूँ कि कस्टम स्लाइड आकार और ओरिएंटेशन इस्तेमाल हुए हैं या नहीं, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हाँ। वर्तमान [स्लाइड आकार और ओरिएंटेशन](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slidesize/) की तुलना मानक प्रीसेट्स से करें; इससे प्रिंटिंग और एक्सपोर्ट के व्यवहार का अनुमान लगाना मदद मिलती है।

**क्या चार्ट्स बाहरी डेटा स्रोतों का रेफ़रेंस करते हैं, यह देखने का कोई तेज़ तरीका है?**

हाँ। सभी [चार्ट्स](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/) को ट्रैवर्स करें, उनके [डेटा स्रोत](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) की जाँच करें, और नोट करें कि डेटा आंतरिक है या लिंक-आधारित, साथ ही कोई टूटे हुए लिंक भी।

**मैं 'भारी' स्लाइड्स का मूल्यांकन कैसे कर सकता हूँ जो रेंडरिंग या PDF एक्सपोर्ट को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए, ऑब्जेक्ट काउंट गिनें और बड़े इमेजेज़, ट्रांसपेरेंसी, शैडो, एनीमेशन और मल्टीमीडिया की तलाश करें; संभावित प्रदर्शन समस्याओं को चिन्हित करने के लिए एक मोटा जटिलता स्कोर असाइन करें।