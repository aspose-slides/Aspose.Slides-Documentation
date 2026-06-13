---
title: Python में ODP को PPTX में बदलें
linktitle: ODP से PPTX
type: docs
weight: 10
url: /hi/python-net/convert-odp-to-pptx/
keywords:
- OpenDocument परिवर्तित करें
- ODP परिवर्तित करें
- OpenDocument से PPTX
- ODP से PPTX
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ ODP को PPTX में बदलें। साफ़ कोड उदाहरण, बैच टिप्स, और उच्च-गुणवत्ता परिणाम—बिना PowerPoint की आवश्यकता।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके ODP प्रस्तुति को PPTX प्रारूप में बदलने की विधि समझाता है।

## **ODP को PPTX में निर्यात करें**

Aspose.Slides for Python via .NET Presentation क्लास प्रदान करता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है। [**Presentation**](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास अब Presentation कन्स्ट्रक्टर के माध्यम से ODP तक पहुँच सकती है जब ऑब्जेक्ट बनाया जाता है। नीचे दिया गया उदाहरण दिखाता है कि कैसे ODP प्रस्तुति को PPTX प्रस्तुति में बदला जा सकता है।

```py
# Aspose.Slides for Python via .NET मॉड्यूल आयात करें
import aspose.slides as slides

# ODP फ़ाइल खोलें
pres = slides.Presentation("AccessOpenDoc.odp")

# ODP प्रस्तुति को PPTX स्वरूप में सहेजना
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **लाइव उदाहरण**

आप [**Aspose.Slides Conversion**](https://products.aspose.app/slides/hi/conversion/) वेब ऐप पर जा सकते हैं, जो **Aspose.Slides API** का उपयोग करके निर्मित है। यह ऐप दर्शाता है कि कैसे ODP से PPTX रूपांतरण को Aspose.Slides API के साथ लागू किया जा सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ODP को PPTX में बदलने के लिए मुझे Microsoft PowerPoint या LibreOffice स्थापित करने की आवश्यकता है?**

नहीं। Aspose.Slides स्वतंत्र रूप से कार्य करता है और ODP/PPTX को पढ़ने या लिखने के लिए किसी तृतीय-पक्ष एप्लिकेशन की आवश्यकता नहीं होती।

**क्या रूपांतरण के दौरान मास्टर स्लाइड्स, लेआउट्स और थीम्स संरक्षित रहते हैं?**

हां। लाइब्रेरी पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल का उपयोग करती है और संरचना को बरकरार रखती है, जिसमें मास्टर स्लाइड्स और लेआउट्स शामिल हैं, इसलिए रूपांतरण के बाद डिज़ाइन सही रहता है।

**क्या मैं पासवर्ड-संरक्षित ODP फाइलों को बदल सकता हूं?**

हां। Aspose.Slides सुरक्षा का पता लगाने, पासवर्ड प्रदान करने पर [protected presentations](/slides/hi/python-net/password-protected-presentation/) (ODP सहित) को खोलने और उस पर काम करने का समर्थन करता है, साथ ही एन्क्रिप्शन को कॉन्फ़िगर करने और दस्तावेज़ गुणों तक पहुंचने की सुविधा भी देता है।

**क्या Aspose.Slides क्लाउड या REST-आधारित रूपांतरण सेवाओं के लिए उपयुक्त है?**

हां। आप अपने बैकएण्ड में स्थानीय लाइब्रेरी का उपयोग कर सकते हैं या [Aspose.Slides Cloud](https://products.aspose.cloud/slides/hi/family/) (REST API) का उपयोग कर सकते हैं; दोनों विकल्प ODP → PPTX रूपांतरण का समर्थन करते हैं।