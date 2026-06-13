---
title: Android पर PowerPoint प्रस्तुतियों को SWF Flash में बदलें
linktitle: PowerPoint से SWF
type: docs
weight: 80
url: /hi/androidjava/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से SWF
- प्रस्तुति से SWF
- स्लाइड से SWF
- PPT से SWF
- PPTX से SWF
- PowerPoint से Flash
- प्रस्तुति से Flash
- स्लाइड से Flash
- PPT से Flash
- PPTX से Flash
- PPT को SWF के रूप में सहेजें
- PPTX को SWF के रूप में सहेजें
- PPT को SWF में निर्यात करें
- PPTX को SWF में निर्यात करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Android के लिए Aspose.Slides के साथ Java में PowerPoint (PPT/PPTX) को SWF Flash में बदलें। चरण‑दर‑चरण कोड उदाहरण, तेज़ गुणवत्ता आउटपुट, कोई PowerPoint स्वचालन नहीं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को SWF में बदलने के तरीके को समझाता है। यह दिखाता है कि कैसे प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड का उपयोग करके SWF फ़ाइल के रूप में सहेजा जाए और निर्यात को [SwfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/swfoptions/) के साथ कैसे कॉन्फ़िगर किया जाए, जिसमें व्यूअर सेटिंग्स तथा नोट्स या टिप्पणियों का लेआउट शामिल है।

## **PPT(X) को SWF में परिवर्तित करें**
[Presentation] क्लास द्वारा प्रदान किया गया [Save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड पूरी प्रस्तुति को **SWF** दस्तावेज़ में बदलने के लिए उपयोग किया जा सकता है। निम्नलिखित उदाहरण दर्शाता है कि कैसे [**SWFOptions**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SwfOptions) क्लास द्वारा प्रदान किए गए विकल्पों का उपयोग करके प्रस्तुति को **SWF** दस्तावेज़ में बदला जा सकता है। आप उत्पन्न SWF में टिप्पणियों को शामिल करने के लिए [**ISWFOptions**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISwfOptions) क्लास और [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) इंटरफ़ेस का भी उपयोग कर सकते हैं।

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

हाँ। छिपी स्लाइड्स को सक्षम करने के लिए [SwfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/swfoptions/) में [setShowHiddenSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) मेथड का उपयोग करें। डिफ़ॉल्ट रूप से, छिपी स्लाइड्स निर्यात नहीं की जातीं।

**मैं संपीड़न और अंतिम SWF आकार को कैसे नियंत्रित कर सकता हूँ?**

[setCompressed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) मेथड और [adjust JPEG quality](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) मेथड का उपयोग करके फ़ाइल आकार और चित्र की गुणवत्ता के बीच संतुलन बना सकते हैं।

**‘setViewerIncluded’ का क्या उद्देश्य है, और इसे कब अक्षम करना चाहिए?**

[setViewerIncluded](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) एक एंबेडेड प्लेयर UI (नेविगेशन कंट्रोल, पैनल, खोज) जोड़ता है। यदि आप अपना स्वयं का प्लेयर उपयोग करने की योजना बना रहे हैं या बिना UI के केवल एक साधारण SWF फ्रेम चाहिए, तो इसे अक्षम कर दें।

**यदि निर्यात मशीन पर स्रोत फ़ॉन्ट अनुपलब्ध है तो क्या होता है?**

Aspose.Slides [SwfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/swfoptions/) में [setDefaultRegularFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) द्वारा निर्दिष्ट फ़ॉन्ट को प्रतिस्थापित करेगा ताकि अनपेक्षित फ़ॉन्ट फ़ॉलबैक न हो।