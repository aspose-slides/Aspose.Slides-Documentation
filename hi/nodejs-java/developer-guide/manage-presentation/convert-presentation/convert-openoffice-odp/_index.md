---
title: जावास्क्रिप्ट में OpenDocument प्रस्तुतियों को परिवर्तित करें
linktitle: OpenDocument बदलें
type: docs
weight: 10
url: /hi/nodejs-java/convert-openoffice-odp/
keywords:
- ODP बदलें
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
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js आपको ODP को PDF, HTML और इमेज फ़ॉर्मैट्स में आसानी से बदलने देता है। तेज़ और सटीक प्रस्तुति रूपांतरण के साथ अपने ऐप्स को बढ़ाएँ।"
---
[**Aspose.Slides API**](https://products.aspose.com/slides/hi/nodejs-java/) आपको OpenDocument (ODP) प्रस्तुतियों को कई फ़ॉर्मैट्स (HTML, PDF, TIFF, SWF, XPS, आदि) में बदलने की सुविधा देता है। ODP फ़ाइलों को अन्य दस्तावेज़ फ़ॉर्मैट्स में परिवर्तित करने के लिए उपयोग किया जाने वाला API PowerPoint (PPT और PPTX) रूपांतरण कार्यों के लिए उपयोग किए जाने वाले API के समान है।

उदाहरण के लिए, यदि आपको ODP प्रस्तुतीकरण को PDF में बदलना है, तो आप इसे इस प्रकार कर सकते हैं:

```js
let presentation = null;
try {
  presentation = new aspose.slides.Presentation("presentation.odp");
  presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मेरे ODP फ़ाइल का स्वरूप परिवर्तन के बाद बदल जाता है तो क्या करें?**

ODP और PowerPoint अलग-अलग प्रस्तुति मॉडल का उपयोग करते हैं, और कुछ तत्व—जैसे तालिकाएँ, कस्टम फ़ॉन्ट्स, या भराव शैलियाँ—सटीक रूप से समान रूप से रेंडर नहीं हो सकते। आउटपुट की समीक्षा करना और आवश्यक होने पर कोड में लेआउट या स्वरूप को समायोजित करना अनुशंसित है।

**क्या ODP रूपांतरण के लिए OpenOffice या LibreOffice स्थापित होना आवश्यक है?**

नहीं, Aspose.Slides एक स्टैंडअलोन लाइब्रेरी है और इसे आपके सिस्टम में OpenOffice या LibreOffice स्थापित होने की आवश्यकता नहीं है।

**क्या मैं ODP रूपांतरण के दौरान आउटपुट फ़ॉर्मेट को अनुकूलित कर सकता हूँ (जैसे PDF विकल्प सेट करना)?**

हाँ, Aspose.Slides आउटपुट को अनुकूलित करने के लिए समृद्ध विकल्प प्रदान करता है। उदाहरण के लिए, PDF में सहेजते समय आप संपीड़न, छवि गुणवत्ता, टेक्स्ट रेंडरिंग, आदि को [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfoptions/) क्लास के माध्यम से नियंत्रित कर सकते हैं।

**क्या Aspose.Slides सर्वर‑साइड या क्लाउड‑आधारित ODP प्रोसेसिंग के लिए उपयुक्त है?**

बिल्कुल। Aspose.Slides को डेस्कटॉप और सर्वर दोनों वातावरणों, जिसमें Azure, AWS, और Docker कंटेनर जैसे क्लाउड‑आधारित प्लेटफ़ॉर्म शामिल हैं, में उपयोग करने के लिए डिज़ाइन किया गया है, और यह किसी भी UI निर्भरता के बिना काम करता है।