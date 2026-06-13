---
title: Android पर OpenDocument प्रस्तुतियों को बदलें
linktitle: OpenDocument बदलें
type: docs
weight: 10
url: /hi/androidjava/convert-openoffice-odp/
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
  - Android
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Android आपको ODP को PDF, HTML और इमेज फ़ॉर्मैट्स में आसानी से बदलने देता है। तेज़ और सटीक प्रस्तुति रूपांतरण के साथ अपने Java ऐप्स को बढ़ाएँ।"
---
## **परिचय**

[**Aspose.Slides API**](https://products.aspose.com/slides/hi/androidjava/) आपको OpenDocument (ODP) प्रस्तुतियों को कई फ़ॉर्मैट्स (HTML, PDF, TIFF, SWF, XPS, आदि) में बदलने की अनुमति देता है। ODP फ़ाइलों को अन्य दस्तावेज़ फ़ॉर्मैट्स में बदलने के लिए प्रयुक्त API वही है जो PowerPoint (PPT और PPTX) रूपांतरण संचालन के लिए उपयोग की जाती है।

उदाहरण के लिए, यदि आपको ODP प्रस्तुति को PDF में बदलने की आवश्यकता है, तो आप इसे इस प्रकार कर सकते हैं:
```java
Presentation presentation = null;
try {
    presentation = new Presentation("pres.odp");
    presentation.save("pres.pdf", SaveFormat.Pdf);
    
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मेरे ODP फ़ाइल का स्वरूपण रूपांतरण के बाद बदल जाता है तो क्या होगा?**

ODP और PowerPoint अलग प्रस्तुति मॉडल का उपयोग करते हैं, और कुछ तत्व—जैसे तालिकाएँ, कस्टम फ़ॉन्ट्स, या भराव शैलियाँ—सटीक रूप से समान नहीं दिख सकते हैं। आवश्यक होने पर आउटपुट की समीक्षा करने और कोड में लेआउट या स्वरूपण को समायोजित करने की सिफ़ारिश की जाती है।

**क्या ODP रूपांतरण के लिए OpenOffice या LibreOffice स्थापित होना आवश्यक है?**

नहीं, Aspose.Slides एक स्वतंत्र लाइब्रेरी है और आपके सिस्टम में OpenOffice या LibreOffice स्थापित होने की आवश्यकता नहीं है।

**क्या मैं ODP रूपांतरण के दौरान आउटपुट फ़ॉर्मेट को अनुकूलित कर सकता हूँ (उदाहरण के लिए, PDF विकल्प सेट कर सकता हूँ)?**

हाँ, Aspose.Slides आउटपुट को अनुकूलित करने के लिए समृद्ध विकल्प प्रदान करता है। उदाहरण के लिए, PDF में सहेजते समय आप संपीड़न, छवि गुणवत्ता, टेक्स्ट रेंडरिंग आदि को [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/) वर्ग के माध्यम से नियंत्रित कर सकते हैं।

**क्या Aspose.Slides सर्वर-साइड या क्लाउड-आधारित ODP प्रोसेसिंग के लिए उपयुक्त है?**

बिल्कुल। Aspose.Slides को डेस्कटॉप और सर्वर दोनों वातावरणों में काम करने के लिए डिज़ाइन किया गया है, जिसमें Azure, AWS और Docker कंटेनर जैसी क्लाउड-आधारित प्लेटफ़ॉर्म शामिल हैं, और यह किसी UI निर्भरता के बिना कार्य करता है।