---
title: C++ में प्रस्तुति जानकारी प्राप्त करें और अद्यतन करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/cpp/examine-presentation/
keywords:
- प्रस्तुति स्वरूप
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अद्यतन करें
- PPTX जांचें
- PPT जांचें
- ODP जांचें
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और अधिक बुद्धिमान सामग्री ऑडिट के लिए।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides में प्रस्तुति जानकारी कैसे निरीक्षण करें। यह समझाता है कि पूरी फ़ाइल लोड किए बिना प्रस्तुति का वर्तमान स्वरूप कैसे निर्धारित करें, उसके दस्तावेज़ गुणों को पढ़ें, और आवश्यकतानुसार उन गुणों को अद्यतित करें।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/documentproperties/) APIs पर आधारित हैं और प्रस्तुति मेटाडेटा के साथ काम करने के सामान्य कार्यों को दर्शाते हैं।

## **प्रस्तुति स्वरूप जांचें**

प्रस्तुति पर काम करने से पहले, आप यह जानना चाह सकते हैं कि वर्तमान में प्रस्तुति किस स्वरूप (PPT, PPTX, ODP, और अन्य) में है।

आप प्रस्तुति को लोड किए बिना उसकी स्वरूप जांच सकते हैं। इस C++ कोड को देखें:

``` cpp
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

## **प्रस्तुति गुण प्राप्त करें**

यह C++ कोड दिखाता है कि आप प्रस्तुति गुण (प्रस्तुति के बारे में जानकारी) कैसे प्राप्त कर सकते हैं:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// इत्यादि
```

## **प्रस्तुति गुण अद्यतन करें**

Aspose.Slides [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) मेथड प्रदान करता है जो आपको प्रस्तुति गुणों में परिवर्तन करने की अनुमति देता है।

मान लीजिए हमारे पास एक PowerPoint प्रस्तुति है जिसमें नीचे दिखाए गए दस्तावेज़ गुण हैं।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

यह कोड उदाहरण दिखाता है कि आप कुछ प्रस्तुति गुणों को कैसे संपादित कर सकते हैं:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

दस्तावेज़ गुणों को बदलने के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

प्रस्तुति और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी के लिए, आप इन लिंक को उपयोगी पा सकते हैं:

- [प्रस्तुति एन्क्रिप्टेड है या नहीं जांचना](https://docs.aspose.com/slides/hi/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [प्रस्तुति लिखित संरक्षित (केवल-पढ़ने योग्य) है या नहीं जांचना](https://docs.aspose.com/slides/hi/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [लोड करने से पहले प्रस्तुति पासवर्ड द्वारा संरक्षित है या नहीं जांचना](https://docs.aspose.com/slides/hi/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [प्रस्तुति को संरक्षित करने के लिए उपयोग किए गए पासवर्ड की पुष्टि करना](https://docs.aspose.com/slides/hi/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं यह कैसे जांच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं या नहीं और कौन‑से हैं?**

प्रस्तुति स्तर पर [embedded-font information](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/getembeddedfonts/) देखें, फिर उन प्रविष्टियों की तुलना [fonts actually used across content](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/getfonts/) के सेट से करें ताकि यह पहचान सकें कि कौन‑से फ़ॉन्ट रेंडरिंग के लिए महत्वपूर्ण हैं।

**मैं कैसे जल्दी पता कर सकता हूँ कि फ़ाइल में छिपी स्लाइड्स हैं और उनकी संख्या क्या है?**

[slide collection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidecollection/) के माध्यम से इटरेट करें और प्रत्येक स्लाइड का [visibility flag](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/get_hidden/) जांचें।

**क्या मैं पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग हो रहा है या नहीं, और क्या वे डिफ़ॉल्ट से भिन्न हैं?**

हाँ। वर्तमान [slide size and orientation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slidesize/) की तुलना मानक प्रीसेट्स से करें; यह प्रिंटिंग और निर्यात के व्यवहार का अनुमान लगाने में मदद करता है।

**क्या चार्ट्स बाहरी डेटा स्रोतों को संदर्भित कर रहे हैं, इसे देखना कोई तेज़ तरीका है?**

हाँ। सभी [charts](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/) को ट्रैवर्स करें, उनके [data source](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) की जांच करें, और यह नोट करें कि डेटा आंतरिक है या लिंक‑आधारित, साथ ही किसी भी टूटे हुए लिंक को।

**मैं 'भारी' स्लाइड्स का कैसे मूल्यांकन कर सकता हूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए, ऑब्जेक्ट की गिनती करें और बड़े इमेज, ट्रांसपैरेंसी, शैडोज़, एनीमेशन्स और मल्टीमीडिया की तलाश करें; संभावित प्रदर्शन मुद्दों को चिन्हित करने के लिए एक मोटा जटिलता स्कोर असाइन करें।