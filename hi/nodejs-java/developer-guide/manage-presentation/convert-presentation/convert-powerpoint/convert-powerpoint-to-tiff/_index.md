---
title: PowerPoint प्रस्तुतियों को JavaScript में TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/nodejs-java/convert-powerpoint-to-tiff/
keywords:
  - PowerPoint रूपांतरण
  - OpenDocument रूपांतरण
  - प्रस्तुति रूपांतरण
  - स्लाइड रूपांतरण
  - PPT रूपांतरण
  - PPTX रूपांतरण
  - PowerPoint से TIFF
  - प्रस्तुति से TIFF
  - स्लाइड से TIFF
  - PPT से TIFF
  - PPTX से TIFF
  - PPT को TIFF के रूप में सहेजें
  - PPTX को TIFF के रूप में सहेजें
  - PPT को TIFF में निर्यात करें
  - PPTX को TIFF में निर्यात करें
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके JavaScript कोड उदाहरणों के साथ PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च‑गुणवत्ता वाले TIFF इमेज में आसानी से बदलना सीखें।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रैस्टर इमेज फ़ॉर्मेट है जो अपनी असाधारण गुणवत्ता और ग्राफिक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिज़ाइनर, फ़ोटोग्राफ़र और डेस्कटॉप पब्लिशर अक्सर अपने इमेज में लेयर्स, रंग सटीकता और मूल सेटिंग्स को बनाए रखने के लिए TIFF का चयन करते हैं।

Aspose.Slides का उपयोग करके आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF इमेज में बिना किसी कठिनाई के बदल सकते हैं, जिससे आपकी प्रस्तुतियों में अधिकतम दृश्य विश्वसनीयता बनी रहती है।

## **प्रेजेंटेशन को TIFF में बदलें**

Using the [save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) method provided by the [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the default slide size.

यह JavaScript कोड दिखाता है कि PowerPoint प्रेजेंटेशन को TIFF में कैसे बदला जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **प्रेजेंटेशन को ब्लैक-एंड-व्हाइट TIFF में बदलें**

The method [setBwConversionMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) in the [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) class allows you to specify the algorithm used when converting a colored slide or image to a black-and-white TIFF. Note that this setting applies only when the [setCompressionType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) method is set to `CCITT4` or `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) एक एक्सपोर्ट‑लेवल सेटिंग है जो पूरी TIFF इमेज के लिए पिक्सेल‑कन्वर्ज़न एल्गोरिद्म चुनती है। जब ब्लैक‑एंड‑व्हाइट डिस्प्ले मोड सक्रिय हो, तो किसी व्यक्तिगत शैप को कैसे दिखाना है, यह निर्धारित करने के लिए [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) का उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह JavaScript कोड दिखाता है कि रंगीन स्लाइड को ब्लैक‑एंड‑व्हाइट TIFF में कैसे बदला जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ब्लैक‑एंड‑व्हाइट TIFF](TIFF_black_and_white.png)

## **कस्टम साइज़ के साथ प्रेजेंटेशन को TIFF में बदलें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setImageSize) मेथड आपको परिणामी इमेज का आकार परिभाषित करने की अनुमति देता है।

यह JavaScript कोड दिखाता है कि PowerPoint प्रेजेंटेशन को कस्टम साइज़ वाली TIFF इमेजेज में कैसे बदला जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // संपीड़न प्रकार सेट करें।
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    संपीड़न प्रकार:
        Default - डिफ़ॉल्ट संपीड़न योजना (LZW) निर्दिष्ट करता है।
        None - कोई संपीड़न नहीं निर्दिष्ट करता।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // पिक्सेल फ़ॉर्मेट द्वारा रंग गहराई नियंत्रित होती है (नीचे उदाहरण देखें); CCITT3 और CCITT4 हमेशा 1 बिट प्रति पिक्सेल उत्पन्न करते हैं।

    // इमेज DPI सेट करें।
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // इमेज आकार सेट करें।
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ प्रेजेंटेशन को TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) क्लास से [setPixelFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) मेथड का उपयोग करके आप परिणामी TIFF इमेज के लिए अपनी पसंद का पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह JavaScript कोड दिखाता है कि PowerPoint प्रेजेंटेशन को कस्टम पिक्सेल फ़ॉर्मेट वाली TIFF इमेज में कैसे बदला जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में जैसा बताया गया है):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, अनुक्रमित।
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, अनुक्रमित।
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, अनुक्रमित।
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB।
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB।
    */

    /// निर्दिष्ट इमेज आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरे PowerPoint प्रेजेंटेशन की बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हां। Aspose.Slides आपको PowerPoint और OpenDocument प्रेजेंटेशन की व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेज में बदलने की सुविधा देता है।

**क्या प्रेजेंटेशन को TIFF में बदलते समय स्लाइड की संख्या पर कोई सीमा है?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार के प्रेजेंटेशन को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या स्लाइड्स को TIFF में बदलते समय PowerPoint एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स बरकरार रहते हैं?**

नहीं, TIFF एक स्थिर इमेज फ़ॉर्मेट है। इसलिए एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइड की स्थिर स्नैपशॉट एक्सपोर्ट होते हैं।