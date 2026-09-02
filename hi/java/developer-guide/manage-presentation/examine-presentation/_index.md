---
title: जावा में प्रेजेंटेशन जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रेजेंटेशन जानकारी
type: docs
weight: 30
url: /hi/java/examine-presentation/
keywords:
- प्रेजेंटेशन फ़ॉर्मेट
- प्रेजेंटेशन प्रॉपर्टीज़
- दस्तावेज़ प्रॉपर्टीज़
- प्रॉपर्टीज़ प्राप्त करें
- प्रॉपर्टीज़ पढ़ें
- प्रॉपर्टीज़ बदलें
- प्रॉपर्टीज़ संशोधित करें
- प्रॉपर्टीज़ अपडेट करें
- PPTX जांचें
- PPT जांचें
- ODP जांचें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "जावा का उपयोग करके PowerPoint और OpenDocument प्रेजेंटेशन में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और स्मार्ट कंटेंट ऑडिट्स के लिए।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रेजेंटेशन जानकारी का निरीक्षण कैसे करें, यह दर्शाता है। यह बताता है कि पूर्ण फ़ाइल लोड किए बिना प्रेजेंटेशन के वर्तमान फ़ॉर्मेट का निर्धारण कैसे करें, उसकी दस्तावेज़ प्रॉपर्टीज़ पढ़ें, और आवश्यकता पड़ने पर उन प्रॉपर्टीज़ को अपडेट करें।

उदाहरण PresentationInfo और DocumentProperties API पर आधारित हैं और प्रेजेंटेशन मेटा डेटा के साथ काम करने के सामान्य संचालन को प्रदर्शित करते हैं।

## **प्रेजेंटेशन फ़ॉर्मेट जाँचें**

आप यह जानना चाह सकते हैं कि वर्तमान में प्रेजेंटेशन किस फ़ॉर्मेट (PPT, PPTX, ODP, इत्यादि) में है।

आप प्रेजेंटेशन को लोड किए बिना उसके फ़ॉर्मेट की जाँच कर सकते हैं। इस Java कोड को देखें:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX फ़ॉर्मेट

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT फ़ॉर्मेट

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP फ़ॉर्मेट
```

## **प्रेजेंटेशन प्रॉपर्टीज़ प्राप्त करें**

यह Java कोड आपको प्रेजेंटेशन प्रॉपर्टीज़ (प्रेजेंटेशन की जानकारी) प्राप्त करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

आप DocumentProperties क्लास के अंतर्गत प्रॉपर्टीज़ देखना चाह सकते हैं।

## **प्रेजेंटेशन प्रॉपर्टीज़ अपडेट करें**

Aspose.Slides PresentationInfo.updateDocumentProperties मेथड प्रदान करता है जो आपको प्रेजेंटेशन प्रॉपर्टीज़ में परिवर्तन करने की अनुमति देता है।

मान लीजिए हमारे पास नीचे दिखाए गए दस्तावेज़ प्रॉपर्टीज़ वाला एक PowerPoint प्रेजेंटेशन है।

![Original document properties of the PowerPoint presentation](input_properties.png)

यह कोड उदाहरण आपको कुछ प्रेजेंटेशन प्रॉपर्टीज़ को संपादित करने का तरीका दिखाता है:

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

दस्तावेज़ प्रॉपर्टीज़ को बदलने के परिणाम नीचे दिखाए गए हैं।

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **उपयोगी लिंक**

प्रेजेंटेशन और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी प्राप्त करने के लिए आप इन लिंक को उपयोगी पा सकते हैं:

- [Password-Protect Presentations](/slides/hi/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/java/write-protected-presentation/)

## **FAQ**

**मैं यह कैसे जाँच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं या नहीं और कौन‑से हैं?**

प्रेजेंटेशन स्तर पर embedded‑font जानकारी देखें, फिर उन प्रविष्टियों की तुलना सामग्री में वास्तविक उपयोग किए गए फ़ॉन्ट्स के सेट से करें ताकि यह पता चल सके कि कौन‑से फ़ॉन्ट रेंडरिंग के लिए महत्वपूर्ण हैं।

**मैं फ़ाइल में छिपी स्लाइड्स हैं या नहीं और कितनी हैं, यह जल्दी से कैसे पता कर सकता हूँ?**

slide collection पर इटररेट करें और प्रत्येक स्लाइड के visibility flag को जांचें।

**क्या मैं यह पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में हैं या नहीं, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हाँ। वर्तमान slide size और orientation की मानक प्रीसेट्स से तुलना करें; इससे प्रिंटिंग और एक्सपोर्ट के व्यवहार का अनुमान लगाने में मदद मिलती है।

**क्या चार्ट्स बाहरी डेटा स्रोतों का संदर्भ दे रहे हैं, यह जल्दी से देखने का कोई तरीका है?**

हाँ। सभी charts को ट्रैवर्स करें, उनके data source को जांचें, और नोट करें कि डेटा आंतरिक है या लिंक‑आधारित, जिसमें टूटे हुए लिंक भी शामिल हैं।

**मैं 'हैवी' स्लाइड्स का मूल्यांकन कैसे कर सकता हूँ जो रेंडरिंग या PDF एक्सपोर्ट को धीमा कर सकती हैं?**

हर स्लाइड के लिए, ऑब्जेक्ट काउंट गिनें और बड़े इमेजेज़, ट्रांसपरेंसी, शैडो, एनीमेशन और मल्टीमीडिया देखें; संभावित प्रदर्शन समस्याओं को चिन्हित करने के लिए एक मोटा जटिलता स्कोर दें।