---
title: Java में ODP को PPTX में बदलें
linktitle: ODP से PPTX
type: docs
weight: 10
url: /hi/java/convert-odp-to-pptx/
keywords:
- OpenDocument को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- ODP को परिवर्तित करें
- OpenDocument से PPTX
- ODP से PPTX
- ODP को PPTX के रूप में सहेजें
- ODP को PPTX में निर्यात करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ ODP को PPTX में बदलें। साफ़ Java कोड उदाहरण, बैच टिप्स, और उच्च‑गुणवत्ता परिणाम—PowerPoint की आवश्यकता नहीं।"
---
## **परिचय**

यह लेख समझाता है कि कैसे Aspose.Slides का उपयोग करके ODP प्रेजेंटेशन को PPTX प्रारूप में परिवर्तित किया जाए।

## **ODP को PPTX/PPT प्रेजेंटेशन में बदलें**
Aspose.Slides for Java एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास प्रदान करता है जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है। जब ऑब्जेक्ट को इंस्टैंशिएट किया जाता है, तो अब [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) कन्स्ट्रक्टर के माध्यम से ODP तक भी पहुंचा जा सकता है। निम्न उदाहरण दिखाता है कि कैसे ODP प्रेजेंटेशन को PPTX प्रेजेंटेशन में बदला जाए।

```java
// ODP फ़ाइल खोलें
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// ODP प्रेजेंटेशन को PPTX प्रारूप में सहेजना
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **सजीव उदाहरण**
आप [**Aspose.Slides Conversion**](https://products.aspose.app/slides/hi/conversion/) वेबऐप पर जा सकते हैं, जो **Aspose.Slides API** के साथ निर्मित है। यह ऐप दिखाता है कि Aspose.Slides API के साथ ODP से PPTX परिवर्तन कैसे लागू किया जा सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ODP को PPTX में बदलने के लिए मुझे Microsoft PowerPoint या LibreOffice स्थापित करने की आवश्यकता है?**

नहीं। Aspose.Slides स्वयंस्थ है और ODP/PPTX को पढ़ने या लिखने के लिए तृतीय‑पक्षीय अनुप्रयोगों की आवश्यकता नहीं पड़ती।

**क्या रूपांतरण के दौरान मास्टर स्लाइड, लेआउट और थीम संरक्षित रहती हैं?**

हाँ। लाइब्रेरी पूरी प्रेजेंटेशन ऑब्जेक्ट मॉडल का उपयोग करती है और संरचना, जिसमें मास्टर स्लाइड और लेआउट शामिल हैं, को बनाए रखती है, इसलिए डिज़ाइन रूपांतरण के बाद भी सही रहता है।

**क्या मैं पासवर्ड‑सुरक्षित ODP फ़ाइलों को बदल सकता हूँ?**

हाँ। Aspose.Slides पासवर्ड प्रदान करने पर [संरक्षित प्रेजेंटेशन](/slides/hi/java/password-protected-presentation/) (ODP सहित) का पता लगा सकता है, खोल सकता है और उन पर काम कर सकता है, साथ ही एन्क्रिप्शन और दस्तावेज़ गुणों तक पहुँच को कॉन्फ़िगर कर सकता है।

**क्या Aspose.Slides क्लाउड या REST‑आधारित परिवर्तन सेवाओं के लिए उपयुक्त है?**

हाँ। आप अपने बैकएंड में स्थानीय लाइब्रेरी का उपयोग कर सकते हैं या [Aspose.Slides Cloud](https://products.aspose.cloud/slides/hi/family/) (REST API) का उपयोग कर सकते हैं; दोनों विकल्प ODP → PPTX परिवर्तन का समर्थन करते हैं।