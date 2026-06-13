---
title: PHP में ODP को PPTX में बदलें
linktitle: ODP से PPTX
type: docs
weight: 10
url: /hi/php-java/convert-odp-to-pptx/
keywords:
- OpenDocument बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- ODP बदलें
- OpenDocument से PPTX
- ODP से PPTX
- ODP को PPTX के रूप में सहेजें
- ODP को PPTX में निर्यात करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ ODP को PPTX में बदलें। साफ़ कोड उदाहरण, बैच टिप्स, और उच्च‑गुणवत्ता परिणाम—PowerPoint की जरूरत नहीं।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके ODP प्रस्तुति को PPTX प्रारूप में परिवर्तित करने के तरीके को समझाता है।

## **ODP को PPTX/PPT प्रस्तुति में परिवर्तित करें**
Aspose.Slides for PHP via Java [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास प्रदान करता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है। अब [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास ODP को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) कंस्ट्रक्टर के माध्यम से भी एक्सेस कर सकती है जब ऑब्जेक्ट को इंस्टैंशिएट किया जाता है। निम्नलिखित उदाहरण दिखाता है कि ODP प्रस्तुति को PPTX प्रस्तुति में कैसे परिवर्तित किया जाए।

```php
// ODP फ़ाइल खोलें
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # ODP प्रस्तुति को PPTX रूप में सहेजना
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **लाइव उदाहरण**
आप [**Aspose.Slides Conversion**](https://products.aspose.app/slides/hi/conversion/) वेब ऐप पर जा सकते हैं, जो **Aspose.Slides API** के साथ बनाया गया है। यह ऐप दिखाता है कि ODP से PPTX परिवर्तन Aspose.Slides API के साथ कैसे कार्यान्वित किया जा सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ODP को PPTX में बदलने के लिए मुझे Microsoft PowerPoint या LibreOffice इंस्टॉल करना आवश्यक है?**

नहीं। Aspose.Slides स्वतंत्र रूप से कार्य करता है और ODP/PPTX को पढ़ने या लिखने के लिए किसी तृतीय‑पक्ष अनुप्रयोग की आवश्यकता नहीं होती।

**क्या मास्टर स्लाइड्स, लेआउट और थीम्स परिवर्तन के दौरान संरक्षित रहती हैं?**

हाँ। लाइब्रेरी पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल का उपयोग करती है और संरचना को बनाए रखती है, जिसमें मास्टर स्लाइड्स और लेआउट शामिल हैं, इसलिए परिवर्तन के बाद डिज़ाइन सही रहता है।

**क्या मैं पासवर्ड‑सुरक्षित ODP फ़ाइलों को परिवर्तित कर सकता हूँ?**

हाँ। Aspose.Slides सुरक्षा का पता लगाने, पासवर्ड प्रदान करने पर [protected presentations](/slides/hi/php-java/password-protected-presentation/) (जिसमें ODP शामिल है) को खोलने और काम करने का समर्थन करता है, साथ ही एन्क्रिप्शन कॉन्फ़िगर करना और दस्तावेज़ गुणों तक पहुँच प्रदान करता है।

**क्या Aspose.Slides क्लाउड या REST‑आधारित परिवर्तन सेवाओं के लिए उपयुक्त है?**

हाँ। आप अपने बैक‑एंड में स्थानीय लाइब्रेरी या [Aspose.Slides Cloud](https://products.aspose.cloud/slides/hi/family/) (REST API) का उपयोग कर सकते हैं; दोनों विकल्प ODP → PPTX परिवर्तन का समर्थन करते हैं।