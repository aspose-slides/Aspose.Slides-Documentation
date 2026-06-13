---
title: C++ में ODP को PPTX में बदलें
linktitle: ODP से PPTX
type: docs
weight: 10
url: /hi/cpp/convert-odp-to-pptx/
keywords:
- OpenDocument को बदलें
- प्रेजेंटेशन बदलें
- स्लाइड बदलें
- ODP को बदलें
- OpenDocument से PPTX
- ODP से PPTX
- ODP को PPTX के रूप में सहेजें
- ODP को PPTX में निर्यात करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ ODP को PPTX में बदलें। साफ़ कोड उदाहरण, बैच टिप्स, और उच्च‑गुणवत्ता परिणाम—PowerPoint की जरूरत नहीं।"
---
## **Overview**

यह लेख Aspose.Slides का उपयोग करके ODP प्रस्तुति को PPTX स्वरूप में बदलने के बारे में समझाता है।

## **ODP to PPTX Conversion**

Aspose.Slides for .NET, Presentation क्लास प्रदान करता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है। [**Presentation**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास अब ऑब्जेक्ट को निर्मित करने पर Presentation कंस्ट्रक्टर के माध्यम से ODP तक पहुँच सकता है। निम्नलिखित उदाहरण दिखाता है कि ODP Presentation को PPTX Presentation में कैसे बदलें।

``` cpp
// दस्तावेज़ निर्देशिका का पथ।
String dataDir = GetDataPath();

// ODP फ़ाइल खोलें
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// ODP प्रस्तुति को PPTX स्वरूप में सहेजना
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Live Example**

आप [**Aspose.Slides Conversion**](https://products.aspose.app/slides/hi/conversion/) वेब ऐप देख सकते हैं, जिसे **Aspose.Slides API** से बनाया गया है। यह ऐप दर्शाता है कि Aspose.Slides API के साथ ODP से PPTX रूपांतरण को कैसे लागू किया जा सकता है।

## **FAQ**

**Do I need to install Microsoft PowerPoint or LibreOffice to convert ODP to PPTX?**

नहीं। Aspose.Slides स्वतंत्र रूप से काम करता है और ODP/PPTX को पढ़ने या लिखने के लिए किसी थर्ड‑पार्टी एप्लिकेशन की आवश्यकता नहीं होती।

**Are master slides, layouts, and themes preserved during conversion?**

हां। लाइब्रेरी पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल का उपयोग करती है और संरचना, जिसमें मास्टर स्लाइड्स और लेआउट शामिल हैं, को बनाए रखती है, इसलिए रूपांतरण के बाद डिज़ाइन सही रहता है।

**Can I convert password-protected ODP files?**

हां। Aspose.Slides सुरक्षा का पता लगा सकता है, पासवर्ड प्रदान करने पर [संरक्षित प्रस्तुतियाँ](/slides/hi/cpp/password-protected-presentation/) (जिसमें ODP भी शामिल है) को खोल सकता और काम कर सकता है, साथ ही एन्क्रिप्शन और दस्तावेज़ गुणों तक पहुँच को कॉन्फ़िगर कर सकता है।

**Is Aspose.Slides suitable for cloud or REST-based conversion services?**

हां। आप अपना स्थानीय लाइब्रेरी अपने बैकएंड में उपयोग कर सकते हैं या [Aspose.Slides Cloud](https://products.aspose.cloud/slides/hi/family/) (REST API) का उपयोग कर सकते हैं; दोनों विकल्प ODP → PPTX रूपांतरण का समर्थन करते हैं।