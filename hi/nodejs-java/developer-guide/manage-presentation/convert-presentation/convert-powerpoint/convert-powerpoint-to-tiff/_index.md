---
title: JavaScript में PowerPoint प्रस्तुतियों को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint बदलें
- OpenDocument बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
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
description: "Aspose.Slides for Node.js का उपयोग करके JavaScript कोड उदाहरणों के साथ PowerPoint (PPT, PPTX) प्रस्तुतियों को आसानी से उच्च-गुणवत्ता वाले TIFF इमेज में बदलना सीखें।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फ़ॉर्मेट है जो अपनी असाधारण गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र और डेस्कटॉप प्रकाशक अक्सर लेयर्स, रंग सटीकता और मूल सेटिंग्स को बनाए रखने के लिए TIFF चुनते हैं।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF इमेज में आसानी से बदल सकते हैं, जिससे आपके प्रस्तुतियों में अधिकतम दृश्य सटीकता बनी रहती है।

## **प्रेजेंटेशन को TIFF में परिवर्तित करें**

[save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) मेथड को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास द्वारा प्रदान किया जाता है, जिससे आप पूरी PowerPoint प्रस्तुति को शीघ्रता से TIFF में बदल सकते हैं। उत्पन्न TIFF इमेजेज़ डिफ़ॉल्ट स्लाइड आकार के अनुरूप होती हैं।

यह JavaScript कोड दिखाता है कि PowerPoint प्रस्तुति को TIFF में कैसे बदलना है:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **प्रेजेंटेशन को ब्लैक-एंड-वाइट TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) क्लास में [setBwConversionMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) मेथड आपको रंगीन स्लाइड या इमेज को ब्लैक-एंड-वाइट TIFF में बदलते समय उपयोग किए जाने वाले एल्गोरिद्म को निर्दिष्ट करने की अनुमति देता है। ध्यान दें कि यह सेटिंग केवल तब लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) मेथड `CCITT4` या `CCITT3` पर सेट हो।

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) एक एक्सपोर्ट‑लेवल सेटिंग है जो पूर्ण TIFF इमेज के लिए पिक्सेल‑कन्वर्ज़न एल्गोरिद्म चुनती है। जब ब्लैक‑एंड‑वाइट डिस्प्ले मोड सक्रिय हो, तो व्यक्तिगत आकार के लिए किस प्रकार दिखना चाहिए, इसे निर्धारित करने हेतु [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) का उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/slides/hi/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह JavaScript कोड दिखाता है कि रंगीन स्लाइड को ब्लैक‑एंड‑वाइट TIFF में कैसे बदलना है:

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

![ब्लैक‑एंड‑वाइट TIFF](TIFF_black_and_white.png)

## **कस्टम आकार के साथ प्रेजेंटेशन को TIFF में परिवर्तित करें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपने इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setImageSize) मेथड आपको परिणामी इमेज का आकार परिभाषित करने की अनुमति देता है।

यह JavaScript कोड दिखाता है कि PowerPoint प्रस्तुति को कस्टम आकार वाले TIFF इमेज में कैसे बदलना है:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // संपीड़न प्रकार सेट करें।
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    संपीड़न प्रकार:
        Default - डिफ़ॉल्ट संपीड़न योजना (LZW) को निर्दिष्ट करता है।
        None - कोई संपीड़न नहीं होने को निर्दिष्ट करता है।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // रंग गहराई पिक्सेल फ़ॉर्मेट द्वारा नियंत्रित होती है (नीचे उदाहरण देखें); CCITT3 और CCITT4 हमेशा प्रति पिक्सेल 1 बिट उत्पन्न करते हैं।

    // छवि DPI सेट करें।
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // छवि आकार सेट करें।
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

## **कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ प्रेजेंटेशन को TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) क्लास से [setPixelFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) मेथड का उपयोग करके आप परिणामी TIFF इमेज के लिए अपना पसंदीदा पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह JavaScript कोड दिखाता है कि PowerPoint प्रस्तुति को कस्टम पिक्सेल फ़ॉर्मेट वाले TIFF इमेज में कैसे बदलना है:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में बताया गया है):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB।
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB।
    */

    /// प्रस्तुति को निर्दिष्ट छवि आकार के साथ TIFF के रूप में सहेजें।
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose के **फ्री** PowerPoint से पोस्टर रूपांतरण टूल को देखें: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सम्पूर्ण PowerPoint प्रस्तुति के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हां। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों की व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेज में बदलने की अनुमति देता है।

**प्रेजेंटेशन को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है क्या?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर किसी भी प्रतिबंध को नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या स्लाइड्स को TIFF में बदलते समय PowerPoint एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित रहते हैं?**

नहीं, TIFF एक स्थिर इमेज फ़ॉर्मेट है। इसलिए एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइडों के स्थिर स्नैपशॉट निर्यातित होते हैं।