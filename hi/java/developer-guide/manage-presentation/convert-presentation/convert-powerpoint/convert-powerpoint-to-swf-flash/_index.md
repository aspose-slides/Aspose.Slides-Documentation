---
title: Java में PowerPoint प्रस्तुतियों को SWF Flash में परिवर्तित करें
linktitle: PowerPoint से SWF
type: docs
weight: 80
url: /hi/java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint रूपांतरित करें
- प्रेज़ेंटेशन रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
- PowerPoint से SWF
- प्रेज़ेंटेशन से SWF
- स्लाइड से SWF
- PPT से SWF
- PPTX से SWF
- PowerPoint से Flash
- प्रेज़ेंटेशन से Flash
- स्लाइड से Flash
- PPT से Flash
- PPTX से Flash
- PPT को SWF के रूप में सहेजें
- PPTX को SWF के रूप में सहेजें
- PPT को SWF में निर्यात करें
- PPTX को SWF में निर्यात करें
- PowerPoint
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: Aspose.Slides के साथ Java में PowerPoint (PPT/PPTX) को SWF Flash में परिवर्तित करें। चरण-दर-चरण कोड उदाहरण, तेज़ गुणवत्ता आउटपुट, कोई PowerPoint ऑटोमेशन नहीं।
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को SWF में परिवर्तित करने की विधि समझाता है। यह दिखाता है कि कैसे प्रस्तुति को SWF फ़ाइल के रूप में [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड का उपयोग करके सहेजा जाए और निर्यात को [SwfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/swfoptions/) द्वारा कैसे कॉन्फ़िगर किया जाए, जिसमें व्यूअर सेटिंग्स तथा नोट्स या टिप्पणियों की लेआउट शामिल है।

## **प्रस्तुतियों को फ़्लैश में परिवर्तित करें**

[save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास द्वारा एक्सपोज़ किया गया है और इसका उपयोग पूरी प्रस्तुति को **SWF** दस्तावेज़ में परिवर्तित करने के लिए किया जा सकता है। निम्नलिखित उदाहरण दिखाता है कि कैसे विकल्पों के साथ प्रस्तुति को **SWF** दस्तावेज़ में परिवर्तित किया जा सकता है, जो [**SWFOptions**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SwfOptions) क्लास द्वारा प्रदान किए गए हैं। आप जेनरेटेड SWF में टिप्पणियों को शामिल करने के लिए [**ISWFOptions**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISwfOptions) क्लास और [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INotesCommentsLayoutingOptions) इंटरफ़ेस का भी उपयोग कर सकते हैं।

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // प्रस्तुति सहेजना
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं SWF में छिपी स्लाइड्स शामिल कर सकता हूँ?**

हाँ। छिपी स्लाइड्स को सक्षम करने के लिए [setShowHiddenSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) मेथड को [SwfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/swfoptions/) में उपयोग करें। डिफ़ॉल्ट रूप से, छिपी स्लाइड्स निर्यात नहीं की जातीं।

**मैं संपीड़न और अंतिम SWF आकार को कैसे नियंत्रित कर सकता हूँ?**

[setCompressed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) मेथड और [adjust JPEG quality](https://reference.aspose.com/slides/hi/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) का उपयोग करके फ़ाइल आकार और छवि गुणवत्ता के बीच संतुलन बनाएँ।

**'setViewerIncluded' का क्या उद्देश्य है, और इसे कब निष्क्रिय करना चाहिए?**

[setViewerIncluded](https://reference.aspose.com/slides/hi/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) एक एम्बेडेड प्लेयर UI (नेविगेशन कंट्रोल, पैनल, खोज) जोड़ता है। यदि आप अपना खुद का प्लेयर उपयोग करने की योजना बनाते हैं या बिना UI के साधा SWF फ्रेम चाहिए, तो इसे निष्क्रिय करें।

**यदि निर्यात मशीन पर स्रोत फ़ॉन्ट अनुपलब्ध हो तो क्या होगा?**

Aspose.Slides [SwfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/swfoptions/) में [setDefaultRegularFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) द्वारा निर्दिष्ट फ़ॉन्ट को प्रतिस्थापित करेगा ताकि अनचाहा फॉलबैक न हो।