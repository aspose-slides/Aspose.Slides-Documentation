---
title: Android पर प्रस्तुति जानकारी को प्राप्त करें और अपडेट करें
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
- PPTX की जाँच करें
- PPT की जाँच करें
- ODP की जाँच करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडाटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और अधिक स्मार्ट सामग्री ऑडिट के लिए।
---
## **सारांश**

यह लेख Aspose.Slides में प्रस्तुति जानकारी की जाँच कैसे करें, दिखाता है। यह बताता है कि पूरी फ़ाइल लोड किए बिना प्रस्तुति के वर्तमान फ़ॉर्मेट का निर्धारण कैसे करें, उसके दस्तावेज़ गुण पढ़ें, और आवश्यकता पड़ने पर उन गुणों को अपडेट करें।

उदाहरणों में [PresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/documentproperties/) API का उपयोग किया गया है और प्रस्तुति मेटाडेटा के साथ काम करने के सामान्य संचालन को दर्शाया गया है।

## **प्रेज़ेंटेशन फ़ॉर्मेट जाँचें**

प्रेज़ेंटेशन पर काम करने से पहले, आप यह जानना चाहेंगे कि वर्तमान में प्रस्तुति किस फ़ॉर्मेट (PPT, PPTX, ODP, आदि) में है।

आप प्रेज़ेंटेशन को लोड किए बिना उसके फ़ॉर्मेट की जाँच कर सकते हैं। नीचे दिया गया Java कोड देखें:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **प्रेज़ेंटेशन गुण प्राप्त करें**

यह Java कोड दिखाता है कि प्रेज़ेंटेशन गुण (प्रेज़ेंटेशन की जानकारी) कैसे प्राप्त करें:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

आप [DocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) वर्ग के तहत गुण देखना चाह सकते हैं।

## **प्रेज़ेंटेशन गुण अपडेट करें**

Aspose.Slides प्रदान करता है [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) मेथड, जिससे आप प्रेज़ेंटेशन गुणों में बदलाव कर सकते हैं।

मान लीजिए हमारे पास नीचे दिखाए गए दस्तावेज़ गुणों वाला PowerPoint प्रेज़ेंटेशन है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

यह कोड उदाहरण दिखाता है कि कुछ प्रेज़ेंटेशन गुणों को कैसे संपादित करें:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

दस्तावेज़ गुणों में परिवर्तन के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

प्रेज़ेंटेशन और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी प्राप्त करने के लिए आप निम्नलिखित लिंक उपयोगी पा सकते हैं:

- [Password-Protect Presentations](/slides/hi/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/androidjava/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जाँच सकता हूँ कि फॉन्ट एम्बेडेड हैं या नहीं, और कौन‑से हैं?**

प्रेज़ेंटेशन स्तर पर [embedded‑font जानकारी](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) देखें, फिर उन प्रविष्टियों की तुलना सामग्री में वास्तव में प्रयुक्त [फ़ॉन्ट्स](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsmanager/#getFonts--) से करें ताकि यह पता चल सके कि कौन‑से फ़ॉन्ट रेंडरिंग के लिए महत्वपूर्ण हैं।

**फ़ाइल में छिपी स्लाइड्स हैं या नहीं, और कितनी, मैं जल्दी कैसे पता करूँ?**

[slide collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidecollection/) में इटरनेट करके प्रत्येक स्लाइड के [visibility flag](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slide/#getHidden--) की जाँच करें।

**क्या मैं कस्टम स्लाइड आकार और ओरिएंटेशन की पहचान कर सकता हूँ, और क्या वे डिफ़ॉल्ट से भिन्न हैं?**

हाँ। वर्तमान [slide size](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlideSize--) और ओरिएंटेशन की तुलना मानक प्रीसेट्स से करें; यह प्रिंटिंग और एग्ज़्पोर्ट के व्यवहार को पूर्वानुमानित करने में मदद करता है।

**क्या चार्ट्स बाहरी डेटा स्रोतों का संदर्भ दे रहे हैं, यह देखना तेज़ तरीका है?**

हाँ। सभी [charts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/) को पार करें, उनके [data source](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) की जाँच करें, और नोट करें कि डेटा आंतरिक है या लिंक‑आधारित, साथ ही किसी भी टूटे हुए लिंक को भी।

**मैं 'भारी' स्लाइड्स का मूल्यांकन कैसे करूँ जो रेंडरिंग या PDF एक्सपोर्ट को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए ऑब्जेक्ट काउंट गिनें और बड़े चित्र, ट्रांसपरेंस, शैडो, एनीमेशन, और मल्टीमीडिया की तलाश करें; संभावित प्रदर्शन हॉटस्पॉट्स को चिह्नित करने के लिए मोटा जटिलता स्कोर निर्धारित करें।