---
title: ".NET में OpenDocument प्रस्तुतियों को परिवर्तित करें"
linktitle: "OpenDocument को परिवर्तित करें"
type: docs
weight: 10
url: /hi/net/convert-openoffice-odp/
keywords:
- ODP को परिवर्तित करें
- ODP से इमेज
- ODP से GIF
- ODP से HTML
- ODP से JPG
- ODP से MD
- ODP से PDF
- ODP से PNG
- ODP से PPT
- ODP से PPTX
- ODP से TIFF
- ODP से वीडियो
- ODP से Word
- ODP से XPS
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET आपको ODP को PDF, HTML और इमेज फ़ॉर्मैट में आसानी से परिवर्तित करने देता है। तेज़ और सटीक प्रस्तुति रूपांतरण के साथ अपने .NET एप्लिकेशन को बढ़ाएँ।"
---
## **परिचय**

[**Aspose.Slides API**](https://products.aspose.com/slides/hi/net/) आपको OpenDocument (ODP) प्रस्तुतियों को कई फ़ॉर्मैट (HTML, PDF, TIFF, SWF, XPS, आदि) में परिवर्तित करने की अनुमति देता है। ODP फ़ाइलों को अन्य दस्तावेज़ फ़ॉर्मैट में परिवर्तित करने के लिए उपयोग किया जाने वाला API, PowerPoint (PPT और PPTX) रूपांतरण कार्यों के लिए उपयोग किए जाने वाले API के समान है।

उदाहरण के लिए, यदि आपको ODP प्रस्तुति को PDF में बदलने की आवश्यकता है, तो आप इसे निम्नानुसार कर सकते हैं:

```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```

## **विभिन्न अनुप्रयोगों में OpenDocument प्रस्तुति**

जब OpenDocument प्रस्तुति (ODP) फ़ाइल को PowerPoint में खोला जाता है, तो यह उस एप्लिकेशन से मूल फ़ॉर्मैटिंग को बनाए नहीं रख सकती जिसमें यह निर्मित थी। यह इसलिए होता है क्योंकि OpenDocument प्रस्तुति एप्लिकेशन और PowerPoint एप्लिकेशन विभिन्न सुविधाएँ और रेंडरिंग व्यवहार प्रदान करते हैं।

कुछ अंतर इस प्रकार हैं:

- PowerPoint में, टेबलें आमतौर पर अंत में रेंडर की जाती हैं और ODP स्लाइड पर उनके क्रम की परवाह किए बिना अन्य आकृतियों के ऊपर ओवरले हो सकती हैं।
- PowerPoint में ODP टेबलों के लिए पिक्चर फ़िल का समर्थन नहीं है।
- LibreOffice/OpenOffice Impress में टेक्स्ट का ऊर्ध्वाधर रोटेशन (270°, स्टैक्ड) और वितरित संरेखण समर्थित नहीं है।
- LibreOffice/OpenOffice Impress में टेक्स्ट के लिए पिक्चर फ़िल, ग्रेडिएंट फ़िल और पैटर्न फ़िल समर्थित नहीं हैं।

MS PowerPoint और LibreOffice/OpenOffice Impress सूचियों को भी अलग-अलग संभालते हैं। PowerPoint में बनाया गया ODP फ़ाइल LibreOffice/OpenOffice Impress में सही ढंग से प्रदर्शित नहीं हो सकता, और इसके विपरीत भी।

नीचे दिखाए गए चित्र में LibreOffice Impress में बनाई गई सूची कैसे दिखाई देती है, यह दिखाया गया है:

![ODP सूची उदाहरण](odp-list-example.png)

Aspose.Slides ODP सूचियों को इस प्रकार सहेजता है कि वे LibreOffice/OpenOffice Impress में सही रूप से प्रदर्शित हों।

[OpenDocument फ़ॉर्मैट और PowerPoint के बारे में अधिक जानें](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मेरे ODP फ़ाइल का फ़ॉर्मैट बदल जाता है तो क्या होगा?**

ODP और PowerPoint अलग-अलग प्रस्तुति मॉडलों का उपयोग करते हैं, और कुछ तत्व—जैसे टेबलें, कस्टम फ़ॉन्ट, या फ़िल स्टाइल—सही रूप से रेंडर नहीं हो सकते। आउटपुट की समीक्षा करना और कोड में लेआउट या फ़ॉर्मैटिंग को आवश्यकतानुसार समायोजित करना अनुशंसित है।

**ODP रूपांतरण के लिए क्या मुझे OpenOffice या LibreOffice स्थापित करने की आवश्यकता है?**

नहीं, Aspose.Slides for .NET एक स्टैंडअलोन लाइब्रेरी है और आपके सिस्टम पर OpenOffice या LibreOffice स्थापित होने की आवश्यकता नहीं है।

**क्या मैं ODP रूपांतरण के दौरान आउटपुट फ़ॉर्मैट को कस्टमाइज़ कर सकता हूँ (जैसे, PDF विकल्प सेट करना)?**

हाँ, Aspose.Slides आउटपुट को कस्टमाइज़ करने के लिए समृद्ध विकल्प प्रदान करता है। उदाहरण के लिए, PDF में सहेजते समय आप संपीड़न, छवि गुणवत्ता, टेक्स्ट रेंडरिंग और अधिक को [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) क्लास के माध्यम से नियंत्रित कर सकते हैं।

**क्या Aspose.Slides सर्वर‑साइड या क्लाउड‑आधारित ODP प्रोसेसिंग के लिए उपयुक्त है?**

बिल्कुल। Aspose.Slides for .NET को डेस्कटॉप और सर्वर दोनों पर्यावरणों में, जिसमें Azure, AWS और Docker कंटेनर जैसे क्लाउड‑आधारित प्लेटफ़ॉर्म शामिल हैं, किसी भी UI निर्भरता के बिना काम करने के लिए डिज़ाइन किया गया है।