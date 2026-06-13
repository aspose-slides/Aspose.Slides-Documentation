---
title: एंड्रॉइड पर प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/androidjava/examine-presentation/
keywords:
- प्रस्तुति प्रारूप
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अपडेट करें
- PPTX का परीक्षण करें
- PPT का परीक्षण करें
- ODP का परीक्षण करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, त्वरित अंतर्दृष्टि और अधिक बुद्धिमान सामग्री ऑडिट के लिए।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुतिकरण जानकारी को कैसे निरीक्षण किया जाए दिखाता है। यह समझाता है कि पूर्ण फ़ाइल लोड किए बिना प्रस्तुतिकरण का वर्तमान प्रारूप कैसे निर्धारित किया जाए, उसके दस्तावेज़ गुण पढ़ें, और आवश्यकता पड़ने पर उन गुणों को अपडेट करें।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/documentproperties/) APIs पर आधारित हैं और प्रस्तुतिकरण मेटाडेटा के साथ काम करने के लिए सामान्य संचालन दर्शाते हैं।

## **प्रस्तुति प्रारूप की जाँच**

किसी प्रस्तुति पर काम करने से पहले, आप यह जानना चाह सकते हैं कि वर्तमान में प्रस्तुति किस प्रारूप (PPT, PPTX, ODP, और अन्य) में है।

आप प्रस्तुति को लोड किए बिना उसकी फ़ॉर्मेट की जाँच कर सकते हैं। इस जावा कोड को देखें:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **प्रस्तुति गुण प्राप्त करें**

यह जावा कोड आपको दिखाता है कि कैसे प्रस्तुति गुण (प्रस्तुति की जानकारी) प्राप्त किए जाएँ:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

आप [DocumentProperties के तहत गुण](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) क्लास को देखना चाह सकते हैं।

## **प्रस्तुति गुण अपडेट करें**

Aspose.Slides [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) मेथड प्रदान करता है जो आपको प्रस्तुति गुणों में परिवर्तन करने की अनुमति देता है।

मान लीजिए हमारे पास नीचे दिखाए गए दस्तावेज़ गुणों वाला एक PowerPoint प्रस्तुति है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

यह कोड उदाहरण दिखाता है कि कैसे कुछ प्रस्तुति गुण संपादित किए जाएँ:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

दस्तावेज़ गुणों में परिवर्तन के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति के बदलें हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

प्रस्तुति और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी प्राप्त करने के लिए, आप इन लिंक को उपयोगी पा सकते हैं:

- [जाँचें कि क्या प्रस्तुति एन्क्रिप्टेड है](https://docs.aspose.com/slides/hi/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [जाँचें कि क्या प्रस्तुति लिखने से सुरक्षित (पढ़ने-के-लिए-केवल) है](https://docs.aspose.com/slides/hi/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [जाँचें कि क्या प्रस्तुति लोड करने से पहले पासवर्ड‑सुरक्षित है](https://docs.aspose.com/slides/hi/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [पुष्टि करें वह पासवर्ड जो प्रस्तुति की सुरक्षा के लिए उपयोग किया गया है](https://docs.aspose.com/slides/hi/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जाँच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं और कौन‑से हैं?**

प्रस्तुति स्तर पर [एम्बेडेड‑फ़ॉन्ट जानकारी](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) देखें, फिर उन प्रविष्टियों की तुलना उस सेट से करें जिसमें [सामग्री में वास्तव में उपयोग किए गए फ़ॉन्ट](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsmanager/#getFonts--) हों, ताकि यह पहचाना जा सके कि रेंडरिंग के लिए कौन‑से फ़ॉन्ट्स महत्वपूर्ण हैं।

**मैं जल्दी से कैसे पता लगा सकता हूँ कि फाइल में छिपी स्लाइड्स हैं और उनकी संख्या क्या है?**

आप [slide collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidecollection/) के माध्यम से इटरेट करें और प्रत्येक स्लाइड का [visibility flag](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slide/#getHidden--) निरीक्षण करें।

**क्या मैं यह पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में है या नहीं, और क्या यह डिफ़ॉल्ट से अलग है?**

हां। वर्तमान [slide size](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlideSize--) और अभिविन्यास की तुलना मानक प्रीसेट्स से करें; यह प्रिंटिंग और एक्सपोर्ट के व्यवहार का अनुमान लगाने में मदद करता है।

**क्या चार्ट्स बाहरी डेटा स्रोतों का संदर्भ दे रहे हैं, इसे जल्दी से देखना संभव है?**

हां। सभी [charts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/) को ट्रैवर्स करें, उनके [data source](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) की जाँच करें, और नोट करें कि डेटा आंतरिक है या लिंक‑आधारित, साथ ही किसी भी टूटे हुए लिंक को भी।

**मैं 'भारी' स्लाइड्स को कैसे आंक सकता हूँ जो रेंडरिंग या PDF एक्सपोर्ट को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए, ऑब्जेक्ट काउंट गिनें और बड़े इमेज, ट्रांसपरेंसी, शैडो, एनीमेशन और मल्टीमीडिया देखें; संभावित प्रदर्शन समस्याओं को चिह्नित करने के लिए एक मोटा जटिलता स्कोर निर्धारित करें।