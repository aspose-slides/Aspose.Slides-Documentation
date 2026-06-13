---
title: JavaScript में PowerPoint प्रस्तुतियों को SWF Flash में बदलें
linktitle: PowerPoint से SWF
type: docs
weight: 80
url: /hi/nodejs-java/convert-powerpoint-to-swf-flash/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ PowerPoint (PPT/PPTX) को SWF Flash में बदलें। चरण‑बद्ध कोड नमूने, तेज़ गुणवत्ता आउटपुट, कोई PowerPoint ऑटोमेशन नहीं।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को SWF में कैसे बदलें। यह दिखाता है कि कैसे [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) मेथड का उपयोग करके प्रस्तुति को SWF फ़ाइल के रूप में सहेजा जाए और [SwfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/swfoptions/) के साथ निर्यात को कैसे कॉन्फ़िगर किया जाए, जिसमें व्यूअर सेटिंग्स तथा नोट्स या टिप्पणी लेआउट शामिल हैं।

## **PPT(X) को SWF में बदलें**
[save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) मेथड, जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास द्वारा उपलब्ध है, का उपयोग पूरी प्रस्तुति को **SWF** दस्तावेज़ में बदलने के लिए किया जा सकता है। निम्नलिखित उदाहरण दिखाता है कि कैसे [**SWFOptions**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SwfOptions) क्लास द्वारा प्रदान किए गए विकल्पों का उपयोग करके प्रस्तुति को **SWF** दस्तावेज़ में बदला जा सकता है। आप उत्पन्न SWF में टिप्पणियाँ भी शामिल कर सकते हैं [**SWFOptions**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SwfOptions) क्लास और [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) क्लास का उपयोग करके।

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // प्रस्तुति सहेजा जा रहा है
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं SWF में छिपी स्लाइड्स शामिल कर सकता हूँ?**

हाँ। [SwfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/swfoptions/) में [setShowHiddenSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) मेथड का उपयोग करें। डिफ़ॉल्ट रूप से, छिपी स्लाइड्स निर्यात नहीं की जाती हैं।

**मैं संपीड़न और अंतिम SWF आकार को कैसे नियंत्रित कर सकता हूँ?**

[setCompressed](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/swfoptions/setcompressed/) मेथड और [setJpegQuality](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/swfoptions/setjpegquality/) का उपयोग करके फ़ाइल आकार और छवि गुणवत्ता के बीच संतुलन स्थापित करें।

**'setViewerIncluded' का उद्देश्य क्या है, और इसे कब उपयोग करना चाहिए?**

[setViewerIncluded](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) एक एम्बेडेड प्लेयर UI (नेविगेशन नियंत्रण, पैनल, खोज) जोड़ता है। इसे तब उपयोग करें जब आप अपना स्वयं का प्लेयर उपयोग करने का इरादा रखें या बिना UI के साधा SWF फ़्रेम चाहिए हो।

**यदि निर्यात मशीन पर स्रोत फ़ॉन्ट उपलब्ध नहीं है तो क्या होता है?**

Aspose.Slides, [SwfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/swfoptions/) में [setDefaultRegularFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) द्वारा निर्दिष्ट फ़ॉन्ट को प्रतिस्थापित करेगा ताकि अनपेक्षित फ़ॉलबैक न हो।