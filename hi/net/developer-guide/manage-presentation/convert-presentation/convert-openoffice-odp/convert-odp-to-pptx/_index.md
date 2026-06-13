---
title: .NET में ODP को PPTX में बदलें
linktitle: ODP को PPTX में
type: docs
weight: 10
url: /hi/net/convert-odp-to-pptx/
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
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides के साथ ODP को PPTX में बदलें। साफ़ C# कोड उदाहरण, बैच टिप्स, और उच्च-गुणवत्ता वाले परिणाम—कोई PowerPoint की आवश्यकता नहीं।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides का उपयोग करके ODP प्रस्तुति को PPTX फ़ॉर्मेट में कैसे रूपांतरित किया जाए।

## **ODP से PPTX रूपांतरण**

Aspose.Slides for .NET Presentation क्लास प्रदान करता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है। [**Presentation**](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास अब Presentation कंस्ट्रक्टर के माध्यम से ODP तक पहुँच सकता है जब वस्तु को इंस्टैंशिएट किया जाता है। नीचे दिया गया उदाहरण दिखाता है कि ODP प्रस्तुति को PPTX प्रस्तुति में कैसे रूपांतरित किया जाए।

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>चरण: C# में ODP को PPTX में रूपांतरित करें</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>चरण: C# में ODP को PowerPoint में रूपांतरित करें</strong></a>

```c#
// ODP फ़ाइल खोलें
Presentation pres = new Presentation("AccessOpenDoc.odp");

// ODP प्रस्तुति को PPTX फ़ॉर्मेट में सहेजा जा रहा है
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **लाइव उदाहरण**

आप [**Aspose.Slides Conversion**](https://products.aspose.app/slides/hi/conversion/) वेब ऐप पर जा सकते हैं, जो **Aspose.Slides API** के साथ बनाया गया है। यह ऐप दर्शाता है कि Aspose.Slides API के साथ ODP से PPTX रूपांतरण कैसे लागू किया जा सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ODP को PPTX में रूपांतरित करने के लिए मुझे Microsoft PowerPoint या LibreOffice स्थापित करने की आवश्यकता है?**

नहीं। Aspose.Slides स्वतंत्र रूप से कार्य करता है और ODP/PPTX को पढ़ने या लिखने के लिए किसी तृतीय‑पक्ष अनुप्रयोग की आवश्यकता नहीं होती।

**क्या रूपांतरण के दौरान मास्टर स्लाइड्स, लेआउट और थीम संरक्षित रहती हैं?**

हां। लाइब्रेरी एक पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल का उपयोग करती है और संरचना को बरकरार रखती है, जिसमें मास्टर स्लाइड्स और लेआउट शामिल हैं, इसलिए रूपांतरण के बाद डिज़ाइन सही रहता है।

**क्या मैं पासवर्ड‑प्रोटेक्टेड ODP फ़ाइलों को रूपांतरित कर सकता हूँ?**

हां। Aspose.Slides सुरक्षा का पता लगाना, पासवर्ड प्रदान करने पर [protected presentations](/slides/hi/net/password-protected-presentation/) (ODP सहित) को खोलना और उस पर काम करना, साथ ही एन्क्रिप्शन और दस्तावेज़ गुणों तक पहुंच को कॉन्फ़िगर करना समर्थन करता है।

**क्या Aspose.Slides क्लाउड या REST‑आधारित रूपांतरण सेवाओं के लिए उपयुक्त है?**

हां। आप अपने बैकएंड में स्थानीय लाइब्रेरी का उपयोग कर सकते हैं या [Aspose.Slides Cloud](https://products.aspose.cloud/slides/hi/family/) (REST API) का उपयोग कर सकते हैं; दोनों विकल्प ODP → PPTX रूपांतरण को समर्थन करते हैं।