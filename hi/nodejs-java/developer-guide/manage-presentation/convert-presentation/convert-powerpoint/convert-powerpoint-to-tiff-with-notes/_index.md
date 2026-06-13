---
title: JavaScript में नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में परिवर्तित करें
linktitle: PowerPoint को नोट्स के साथ TIFF में
type: docs
weight: 100
url: /hi/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से TIFF
- प्रस्तुति से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- नोट्स के साथ PowerPoint
- नोट्स के साथ प्रस्तुति
- नोट्स के साथ स्लाइड
- नोट्स के साथ PPT
- नोट्स के साथ PPTX
- नोट्स के साथ TIFF
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके JavaScript में नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में परिवर्तित करें। स्लाइडों को स्पीकर नोट्स के साथ प्रभावी ढंग से निर्यात करना सीखें।"
---
## **परिचय**

Aspose.Slides for Node.js via Java PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को नोट्स सहित TIFF फ़ॉर्मेट में परिवर्तित करने का एक सरल समाधान प्रदान करता है। यह फ़ॉर्मेट उच्च‑गुणवत्ता वाली छवि संग्रहण, प्रिंटिंग और दस्तावेज़ अभिलेखण के लिए व्यापक रूप से उपयोग किया जाता है। Aspose.Slides के साथ, आप न केवल संपूर्ण प्रस्तुतियों को स्पीकर नोट्स के साथ निर्यात कर सकते हैं बल्कि नोट्स स्लाइड दृश्य में स्लाइड थंबनेल भी जेनरेट कर सकते हैं। परिवर्तन प्रक्रिया सरल और कुशल है, जो पूरे प्रस्तुतिकरण को TIFF छवियों की श्रृंखला में रूपांतरित करने के लिए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की `save` मेथड का उपयोग करती है, जबकि नोट्स और लेआउट को संरक्षित रखती है।

## **Notes के साथ प्रस्तुति को TIFF में परिवर्तित करें**

Notes के साथ PowerPoint या OpenDocument प्रस्तुति को TIFF में सहेजने के लिए Aspose.Slides for Node.js via Java निम्नलिखित चरणों में किया जाता है:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं: PowerPoint या OpenDocument फ़ाइल लोड करें।  
2. आउटपुट लेआउट विकल्पों को कॉन्फ़िगर करें: नोट्स और कमेंट्स को कैसे प्रदर्शित किया जाना है, इसे निर्दिष्ट करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करें।  
3. प्रस्तुति को TIFF में सहेजें: कॉन्फ़िगर किए गए विकल्पों को [save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) मेथड में पास करें।

मान लीजिए हमारे पास "speaker_notes.pptx" नामक फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![स्पीकर नोट्स के साथ प्रस्तुति स्लाइड](slide_with_notes.png)

नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) मेथड का उपयोग करके नोट्स स्लाइड दृश्य में प्रस्तुति को TIFF छवि में बदला जा सकता है।

```js
// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं।
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // स्लाइड के नीचे नोट्स दिखाएं।

    // नोट्स लेआउट के साथ TIFF विकल्प कॉन्फ़िगर करें।
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // स्पीकर नोट्स के साथ प्रस्तुति को TIFF में सहेजें।
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

परिणाम:

![स्पीकर नोट्स के साथ TIFF छवि](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose के [मुफ्त PowerPoint से पोस्टर कनवर्टर](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं परिणामी TIFF में नोट्स क्षेत्र की स्थिति को नियंत्रित कर सकता हूँ?**

हाँ। नोट्स लेआउट सेटिंग्स ([notes layout settings](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions)) का उपयोग करके `None`, `BottomTruncated` या `BottomFull` जैसे विकल्पों में से चुन सकते हैं, जो क्रमशः नोट्स को छिपाते हैं, एक पृष्ठ में फिट करते हैं, या अतिरिक्त पृष्ठों पर जारी रखने की अनुमति देते हैं।

**मैं नोट्स वाले TIFF फ़ाइल का आकार बिना स्पष्ट गुणवत्ता हानि के कैसे कम कर सकता हूँ?**

एक प्रभावी संपीड़न चुनें (उदाहरण के लिए `LZW` या `RLE`) ([efficient compression](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/)), उचित DPI सेट करें, और यदि स्वीकार्य हो तो कम पिक्सेल फ़ॉर्मेट (जैसे मोनोक्रोम के लिए 8 bpp या 1 bpp) उपयोग करें ([pixel format](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/setpixelformat/))। छवि के आकार को थोड़ा घटाना भी बिना स्पष्ट पढ़ने की क्षमता को नुकसान पहुँचाए मदद कर सकता है ([image dimensions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/setimagesize/))।

**यदि सिस्टम में मूल फ़ॉन्ट अनुपलब्ध हों तो नोट्स में फ़ॉन्ट परिणाम को प्रभावित करता है क्या?**

हाँ। लापता फ़ॉन्ट्स [substitution](/slides/hi/nodejs-java/font-selection-sequence/) को ट्रिगर करते हैं, जिससे टेक्स्ट मेट्रिक्स और दिखावट बदल सकती है। इसे टालने के लिए आवश्यक फ़ॉन्ट्स [supply the required fonts](/slides/hi/nodejs-java/custom-font/) प्रदान करें या डिफ़ॉल्ट [fallback font](/slides/hi/nodejs-java/fallback-font/) सेट करें ताकि इच्छित टाइपफ़ेस का उपयोग हो सके।