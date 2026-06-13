---
title: Java में OpenDocument प्रस्तुतियों को परिवर्तित करें
linktitle: OpenDocument परिवर्तित करें
type: docs
weight: 10
url: /hi/java/convert-openoffice-odp/
keywords:
- ODP परिवर्तित करें
- ODP से छवि
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java आपको आसानी से ODP को PDF, HTML और छवि प्रारूपों में परिवर्तित करने देता है। तेज और सटीक प्रस्तुति रूपांतरण के साथ अपने Java एप्लिकेशन को बढ़ाएँ।"
---
## **परिचय**

[**Aspose.Slides API**](https://products.aspose.com/slides/hi/java/) आपको OpenDocument (ODP) प्रस्तुतियों को कई स्वरूपों (HTML, PDF, TIFF, SWF, XPS, आदि) में परिवर्तित करने की अनुमति देता है। ODP फ़ाइलों को अन्य दस्तावेज़ स्वरूपों में परिवर्तित करने के लिए प्रयुक्त API वही है जो PowerPoint (PPT और PPTX) रूपांतरण कार्यों के लिए उपयोग किया जाता है।

उदाहरण के तौर पर, यदि आपको ODP प्रस्तुति को PDF में परिवर्तित करने की आवश्यकता है, तो आप इसे इस प्रकार कर सकते हैं:

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

## **विभिन्न अनुप्रयोगों में OpenDocument प्रस्तुति**

जब एक OpenDocument प्रस्तुति (ODP) फ़ाइल को PowerPoint में खोला जाता है, तो वह संभवतः उस एप्लिकेशन से मूल स्वरूपण को बनाए नहीं रख पाता जिसमें इसे बनाया गया था। यह इसलिए होता है क्योंकि OpenDocument प्रस्तुति एप और PowerPoint एप विभिन्न सुविधाएँ और रेंडरिंग व्यवहार प्रदान करते हैं।

इनमें से कुछ अंतर इस प्रकार हैं:

- PowerPoint में, तालिकाएँ आमतौर पर अंत में रेंडर की जाती हैं और ODP स्लाइड पर उनके क्रम की परवाह किए बिना अन्य आकारों के ऊपर ओवरले हो सकती हैं।
- PowerPoint में ODP तालिकाओं के लिए चित्र भराव समर्थित नहीं है।
- LibreOffice/OpenOffice Impress में पाठ का लंबवत घुमाव (270°, stacked) और वितरित संरेखण समर्थित नहीं हैं।
- LibreOffice/OpenOffice Impress में पाठ के लिए चित्र भराव, ग्रेडिएंट भराव, और पैटर्न भराव समर्थित नहीं हैं।

MS PowerPoint और LibreOffice/OpenOffice Impress सूचियों को भी अलग तरह से संभालते हैं। PowerPoint में निर्मित ODP फ़ाइल LibreOffice/OpenOffice Impress में सही ढंग से प्रदर्शित नहीं हो सकती, और इसके विपरीत भी।

नीचे चित्र दिखाता है कि LibreOffice Impress में बनाई गई सूची कैसे दिखाई देती है:

![ODP सूची उदाहरण](odp-list-example.png)

Aspose.Slides ODP सूचियों को इस तरह सहेजता है कि वे LibreOffice/OpenOffice Impress में सही ढंग से प्रदर्शित हों।

[OpenDocument प्रारूप और PowerPoint के बारे में अधिक जानें](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मेरे ODP फ़ाइल का स्वरूपण रूपांतरण के बाद बदल जाता है तो क्या करें?**

ODP और PowerPoint विभिन्न प्रस्तुति मॉडलों का उपयोग करते हैं, और कुछ तत्व—जैसे तालिकाएँ, कस्टम फ़ॉन्ट्स, या भराव शैलियाँ—एक समान नहीं दिख सकते। सुझाव दिया जाता है कि आउटपुट की समीक्षा करें और आवश्यकता पड़ने पर कोड में लेआउट या स्वरूपण को समायोजित करें।

**क्या ODP रूपांतरण के लिए OpenOffice या LibreOffice इंस्टॉल होना आवश्यक है?**

नहीं, Aspose.Slides एक स्वतंत्र लाइब्रेरी है और इसे आपके सिस्टम पर OpenOffice या LibreOffice इंस्टॉल होने की आवश्यकता नहीं है।

**क्या मैं ODP रूपांतरण के दौरान आउटपुट स्वरूप को अनुकूलित कर सकता हूँ (उदाहरण के लिए, PDF विकल्प सेट कर सकता हूँ)?**

हाँ, Aspose.Slides आउटपुट को अनुकूलित करने के लिए विस्तृत विकल्प प्रदान करता है। उदाहरण के लिए, PDF में सहेजते समय आप संपीड़न, छवि गुणवत्ता, पाठ रेंडरिंग, आदि को [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/) क्लास के माध्यम से नियंत्रित कर सकते हैं।

**क्या Aspose.Slides सर्वर-साइड या क्लाउड-आधारित ODP प्रोसेसिंग के लिए उपयुक्त है?**

बिल्कुल। Aspose.Slides को दोनों डेस्कटॉप और सर्वर वातावरण में काम करने के लिए डिज़ाइन किया गया है, जिसमें Azure, AWS, और Docker कंटेनर जैसी क्लाउड-आधारित प्लेटफ़ॉर्म शामिल हैं, और यह किसी भी UI निर्भरता के बिना कार्य करता है।