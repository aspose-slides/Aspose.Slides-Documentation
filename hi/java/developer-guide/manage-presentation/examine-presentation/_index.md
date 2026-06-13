---
title: Java में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/java/examine-presentation/
keywords:
- प्रस्तुति फ़ॉर्मेट
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अपडेट करें
- PPTX जाँचें
- PPT जाँचें
- ODP जाँचें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, जिससे तेज़ अंतर्दृष्टि और अधिक बुद्धिमान सामग्री ऑडिट प्राप्त हों।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides में प्रस्तुति सूचना की जाँच कैसे करें। यह समझाता है कि पूरी फ़ाइल लोड किए बिना प्रस्तुति के वर्तमान फ़ॉर्मेट का निर्धारण कैसे किया जाए, उसके दस्तावेज़ गुण पढ़े जाएँ, और आवश्यकता पड़ने पर उन गुणों को अपडेट किया जाए।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/documentproperties/) API पर आधारित हैं और प्रस्तुति मेटाडेटा के साथ काम करने के सामान्य कार्यों को प्रदर्शित करते हैं।

## **प्रस्तुति फ़ॉर्मेट जाँचें**

प्रस्तुति पर काम करने से पहले, आप यह जानना चाहते हो सकते हैं कि वर्तमान में प्रस्तुति किस फ़ॉर्मेट (PPT, PPTX, ODP, आदि) में है।

आप प्रस्तुति को लोड किए बिना उसकी फ़ॉर्मेट जाँच सकते हैं। इस जावा कोड को देखें:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **प्रस्तुति गुण प्राप्त करें**

यह जावा कोड आपको दिखाता है कि कैसे प्रस्तुति गुण (प्रस्तुति की जानकारी) प्राप्त करें:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ...
```

आप [DocumentProperties के अंतर्गत गुण](https://reference.aspose.com/slides/hi/java/com.aspose.slides/documentproperties/#DocumentProperties--) वर्ग देखना चाह सकते हैं।

## **प्रस्तुति गुण अद्यतन करें**

Aspose.Slides [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) मेथड प्रदान करता है जो आपको प्रस्तुति गुणों में परिवर्तन करने की अनुमति देता है।

मान लीजिए हमारे पास नीचे दिखाए गए दस्तावेज़ गुणों वाली एक PowerPoint प्रस्तुति है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

यह कोड उदाहरण दिखाता है कि कैसे कुछ प्रस्तुति गुण संपादित करें:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

दस्तावेज़ गुणों को बदलने के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

प्रस्तुति और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी के लिए, आप इन लिंक को उपयोगी पा सकते हैं:

- [जाँचें कि क्या प्रस्तुति एन्क्रिप्टेड है](https://docs.aspose.com/slides/hi/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [जाँचें कि क्या प्रस्तुति लिखित-रक्षित (केवल-पढ़ने योग्य) है](https://docs.aspose.com/slides/hi/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [जाँचें कि क्या प्रस्तुति को लोड करने से पहले पासवर्ड से सुरक्षित किया गया है](https://docs.aspose.com/slides/hi/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [प्रस्तुति को सुरक्षित करने के लिए उपयोग किए गए पासवर्ड की पुष्टि करना](https://docs.aspose.com/slides/hi/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जाँच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं और कौन‑से हैं?**

प्रस्तुति स्तर पर [एंबेडेड फ़ॉन्ट जानकारी](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) देखें, फिर उन प्रविष्टियों की तुलना [सामग्री में वास्तविक रूप से प्रयुक्त फ़ॉन्ट्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsmanager/#getFonts--) के सेट से करें ताकि यह पहचाना जा सके कि रेंडरिंग के लिए किन फ़ॉन्ट्स का महत्व है।

**मैं जल्दी से कैसे जान सकता हूँ कि फ़ाइल में छिपे स्लाइड्स हैं और उनकी संख्या क्या है?**

फ़ाइल में [स्लाइड संग्रह](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidecollection/) को इटररेट करें और प्रत्येक स्लाइड के [दृश्यता फ़्लैग](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/#getHidden--) को जांचें।

**क्या मैं पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग किए गए हैं, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हां। वर्तमान [स्लाइड आकार](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlideSize--) और अभिविन्यास की मानक प्रीसेट्स से तुलना करें; यह प्रिंटिंग और निर्यात के व्यवहार का अनुमान लगाने में मदद करता है।

**क्या चार्ट्स बाहरी डेटा स्रोतों को रेफ़र कर रहे हैं, यह देखना जल्दी संभव है?**

हां। सभी [चार्ट्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/) को ट्रैवर्स करें, उनके [डेटा स्रोत](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getDataSourceType--) की जाँच करें, और नोट करें कि डेटा अंतर्निहित है या लिंक‑आधारित, जिसमें टूटे हुए लिंक भी शामिल हैं।

**मैं कैसे 'भारी' स्लाइड्स का मूल्यांकन कर सकता हूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए, ऑब्जेक्ट गणना करें और बड़े इमेज, ट्रांसपैरेंसी, शैडो, एनीमेशन तथा मल्टीमीडिया देखें; संभावित प्रदर्शन समस्याओं को चिन्हित करने के लिए एक मोटा जटिलता स्कोर असाइन करें।