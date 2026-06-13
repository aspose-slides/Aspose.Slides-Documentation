---
title: JavaScript में ODP को PPTX में बदलें
linktitle: ODP से PPTX
type: docs
weight: 10
url: /hi/nodejs-java/convert-odp-to-pptx/
keywords:
- OpenDocument को बदलें
- प्रेजेंटेशन को बदलें
- स्लाइड को बदलें
- ODP को बदलें
- OpenDocument से PPTX
- ODP से PPTX
- ODP को PPTX के रूप में सहेजें
- ODP को PPTX में निर्यात करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ ODP को PPTX में बदलें। साफ़ JavaScript कोड उदाहरण, बैच सुझाव, और उच्च-गुणवत्ता परिणाम—PowerPoint की आवश्यकता नहीं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके ODP प्रेजेंटेशन को PPTX फ़ॉर्मेट में बदलने की प्रक्रिया समझाता है।

## **ODP को PPTX/PPT प्रेजेंटेशन में बदलें**
Aspose.Slides for Node.js via Java एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास प्रदान करता है जो प्रेजेंटेशन फ़ाइल को दर्शाता है। [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास अब ऑब्जेक्ट को इंस्टैंसिएट करते समय [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) कंस्ट्रक्टर के माध्यम से ODP तक भी पहुँच सकता है। नीचे दिया गया उदाहरण दिखाता है कि ODP प्रेजेंटेशन को PPTX प्रेजेंटेशन में कैसे बदला जाए।

```javascript
// ODP फ़ाइल खोलें
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// ODP प्रेजेंटेशन को PPTX फ़ॉर्मेट में सहेजना
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **लाइव उदाहरण**
आप [**Aspose.Slides Conversion**](https://products.aspose.app/slides/hi/conversion/) वेब ऐप पर जा सकते हैं, जो **Aspose.Slides API** के साथ निर्मित है। यह ऐप दर्शाता है कि Aspose.Slides API का उपयोग करके ODP से PPTX रूपांतरण कैसे लागू किया जा सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ODP को PPTX में बदलने के लिए मुझे Microsoft PowerPoint या LibreOffice स्थापित करने की आवश्यकता है?**

नहीं। Aspose.Slides स्वतंत्र रूप से कार्य करता है और ODP/PPTX को पढ़ने या लिखने के लिए तीसरे पक्ष के अनुप्रयोगों की आवश्यकता नहीं होती।

**क्या रूपांतरण के दौरान मास्टर स्लाइड्स, लेआउट्स और थीम्स बनाए रखे जाते हैं?**

हाँ। लाइब्रेरी पूर्ण प्रेजेंटेशन ऑब्जेक्ट मॉडल का उपयोग करती है और संरचना को बरकरार रखती है, जिसमें मास्टर स्लाइड्स और लेआउट्स शामिल हैं, इसलिए रूपांतरण के बाद डिज़ाइन सही बना रहता है।

**क्या मैं पासवर्ड-संरक्षित ODP फ़ाइलों को बदल सकता हूँ?**

हाँ। Aspose.Slides सुरक्षा का पता लगाने, पासवर्ड प्रदान करने पर [protected presentations](/slides/hi/nodejs-java/password-protected-presentation/) (ODP सहित) को खोलने और काम करने का समर्थन करता है, साथ ही एन्क्रिप्शन कॉन्फ़िगर करने और दस्तावेज़ गुणों तक पहुँच प्रदान करता है।

**क्या Aspose.Slides क्लाउड या REST-आधारित रूपांतरण सेवाओं के लिए उपयुक्त है?**

हाँ। आप अपने बैकएंड में स्थानीय लाइब्रेरी या [Aspose.Slides Cloud](https://products.aspose.cloud/slides/hi/family/) (REST API) का उपयोग कर सकते हैं; दोनों विकल्प ODP → PPTX रूपांतरण का समर्थन करते हैं।