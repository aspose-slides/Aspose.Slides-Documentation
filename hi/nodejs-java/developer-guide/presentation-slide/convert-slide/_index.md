---
title: JavaScript में प्रेजेंटेशन स्लाइड्स को इमेज में बदलें
linktitle: स्लाइड से इमेज
type: docs
weight: 35
url: /hi/nodejs-java/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड निर्यात करें
- स्लाइड से इमेज
- स्लाइड को इमेज के रूप में सहेजें
- स्लाइड से EMF
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के साथ JavaScript में PPT, PPTX और ODP प्रेजेंटेशन्स की स्लाइड्स को PNG, JPEG, GIF, TIFF, EMF और अन्य इमेज फ़ॉर्मैट्स में बदलें।"
---
## **परिचय**

Aspose.Slides for Node.js via Java व्यक्तिगत स्लाइड्स को PowerPoint और OpenDocument प्रेजेंटेशन्स से PNG, JPEG, GIF, TIFF और अन्य इमेज फ़ॉर्मैट्स में रेंडर कर सकता है।

स्लाइड को इमेज में बदलने के लिए, इन चरणों का पालन करें:

1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उपयोग करके लोड करें।
2. उस स्लाइड का चयन करें जिसे आप रेंडर करना चाहते हैं।
3. यदि आवश्यक हो, तो रेंडरिंग को [RenderingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/renderingoptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) क्लास के साथ कॉन्फ़िगर करें।
4. [Slide.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#getImage) मेथड को कॉल करें। यह एक [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) ऑब्जेक्ट लौटाता है।
5. [IImage.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/#save) मेथड को कॉल करें और आउटपुट फ़ॉर्मैट को एक [ImageFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imageformat/) वैल्यू के साथ निर्दिष्ट करें।

## **स्लाइड को PNG इमेज में परिवर्तित करें**

सबसे सरल रूपांतरण डिफ़ॉल्ट रेंडरिंग सेटिंग्स का उपयोग करता है। परिणामी [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) ऑब्जेक्ट को मेमोरी में प्रोसेस किया जा सकता है या फ़ाइल में सहेजा जा सकता है।

निम्नलिखित JavaScript उदाहरण प्रथम स्लाइड को रेंडर करता है और उसे PNG इमेज के रूप में सहेजता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **कस्टम आकारों के साथ स्लाइड को इमेज में बदलें**

ऐसी स्लाइड को रेंडर करने के लिए जो ठीक पिक्सेल आयामों के साथ हो, [Slide.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#getImage) ओवरलोड का उपयोग करें जो `java.awt.Dimension` वैल्यू को स्वीकार करता है।

निम्न उदाहरण 1820 × 1040 JPEG इमेज बनाता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **नोट्स और कमेंट्स के साथ स्लाइड को इमेज में बदलें**

डिफ़ॉल्ट रूप से, स्लाइड इमेज में नोट्स या कमेंट्स शामिल नहीं होते। नोट्स और कमेंट्स की स्थिति को नियंत्रित करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट को [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) मेथड में पास करें।

निम्न उदाहरण स्लाइड के नीचे ट्रंकेटेड नोट्स और दाईं ओर कमेंट्स रखता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
स्लाइड‑टू‑इमेज रूपांतरण के लिए, [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) मेथड में [BottomFull](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notespositions/) को पास न करें। नोट्स में अधिक टेक्स्ट हो सकता है जो स्थिर इमेज आकार में फिट नहीं हो पाएगा। इसके बजाय [BottomTruncated](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notespositions/) उपयोग करें।
{{% /alert %}}

## **TIFF विकल्पों का उपयोग करके स्लाइड को इमेज में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) क्लास आपको रेंडर किए गए TIFF इमेज का आकार, रिज़ॉल्यूशन और अन्य गुण नियंत्रित करने देती है।

निम्न उदाहरण प्रथम स्लाइड को 2160 × 2880 TIFF इमेज के रूप में 300 DPI पर रेंडर करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
TIFF समर्थन Java 9 से पहले के संस्करणों में सुनिश्चित नहीं है।
{{% /alert %}}

## **सभी स्लाइड को इमेज में बदलें**

स्लाइड कलेक्शन के माध्यम से इटेरेट करके पूरी प्रेजेंटेशन को इमेज की श्रंखला में बदलें। छिपी हुई स्लाइड्स को शामिल किया जाता है जब तक आप उन्हें स्पष्ट रूप से स्किप नहीं करते।

निम्न उदाहरण प्रत्येक स्लाइड को 2 के क्षैतिज और लंबवत स्केल फैक्टर के साथ JPEG इमेज के रूप में रेंडर करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Enhanced Metafile आउटपुट बनाएं**

Enhanced Metafile (EMF) उन परिस्थितियों में उपयोगी है जहाँ वेक्टर‑आधारित ग्राफ़िक्स को Microsoft Office या अन्य Windows एप्लिकेशन्स के साथ बदलना आवश्यक होता है जो Windows metafiles को सपोर्ट करते हैं। पिक्सेल‑आधारित इमेज के विपरीत, EMF वेक्टर ड्राइंग ऑपरेशन्स को बनाए रख सकता है जो स्केल होने पर भी तीक्ष्णता नहीं खोते। हालांकि, EMF मुख्यतः Windows metafile सपोर्ट वाले एप्लिकेशन्स के लिए एक संगतता फ़ॉर्मैट है, सार्वभौमिक इंटरचेंज फ़ॉर्मैट नहीं। अतिरिक्त रूप से, जटिल स्लाइड कंटेंट जैसे बिटमैप इमेज और कुछ इफ़ेक्ट्स वेक्टर metafile कंटेनर के अंदर रास्टराइज़्ड एलीमेंट्स के रूप में संग्रहीत हो सकते हैं।

### **स्लाइड को EMF में एक्सपोर्ट करें**

[Slide.writeAsEmf](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#writeAsEmf) मेथड स्लाइड को EMF फ़ॉर्मैट में लक्ष्य स्ट्रीम पर लिखता है। निम्न उदाहरण एक प्रेजेंटेशन लोड करता है, प्रथम स्लाइड का चयन करता है, और उसे EMF फ़ाइल स्ट्रीम में लिखता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

कॉलर द्वारा पास किए गए स्ट्रीम की ज़िम्मेदारी [Slide.writeAsEmf](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#writeAsEmf) को होती है और उसे बंद करने की ज़िम्मेदारी भी कॉलर की होती है, जैसा कि ऊपर दिखाया गया है।

### **SVG इमेज को EMF में बदलें और प्रेजेंटेशन में जोड़ें**

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/#writeAsEmf) का उपयोग करके SVG कंटेंट को EMF में बदलें। परिणामी बाइट्स को [ImageCollection.addImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagecollection/#addImage) के माध्यम से प्रेजेंटेशन में जोड़ें और [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) से स्लाइड पर रखें।

निम्न उदाहरण SVG मार्कअप से एक [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/) बनाता है, उसे मेमोरी में EMF में बदलता है, प्रथम स्लाइड पर मेटाफाइल डालता है, और प्रेजेंटेशन को सहेजता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/#writeAsEmf) गंतव्य स्ट्रीम की स्वामित्व नहीं लेता। `java.io.ByteArrayOutputStream` सभी उत्पन्न डेटा को मेमोरी में संग्रहीत करता है, इसलिए `toByteArray` कॉल करने से पहले पोज़िशन रीसेट की आवश्यकता नहीं होती। लौटाया गया बाइट एरे स्ट्रीम बंद होने के बाद भी वैध रहता है।

EMF जेनरेशन उन ऑपरेटिंग सिस्टम्स पर उपलब्ध है जो चयनित Aspose.Slides for Node.js via Java और JDK कॉन्फ़िगरेशन द्वारा समर्थित हैं, लेकिन फ़ॉन्ट्स या ग्राफ़िक्स निर्भरताओं की अनुपलब्धता के कारण प्लेटफ़ॉर्म के बीच रेंडरिंग में अंतर हो सकता है। स्रोत कंटेंट द्वारा उपयोग किए जाने वाले फ़ॉन्ट्स इंस्टॉल करें या उपयुक्त विकल्प सेट करें, Aspose.Slides for Node.js via Java के लिए [platform requirements](/slides/hi/nodejs-java/system-requirements/) का पालन करें, और लक्ष्य EMF‑उपभोक्ता एप्लिकेशन में परिणाम को वैलिडेट करें। Linux और macOS एप्लिकेशन्स अक्सर Windows metafiles को प्रदर्शित या एडिट करने में सीमित या असंगत समर्थन रखते हैं।

## **कलर इमोजी रेंडरिंग**

{{% alert title="Note" color="info" %}}
प्रेजेंटेशन स्लाइड्स को इमेज में बदलते समय रंगीन इमोजी सही तरह से रेंडर करने के लिए, प्रेजेंटेशन में उपयोग किए गए इमोजी फ़ॉन्ट्स सिस्टम में इंस्टॉल और उपलब्ध होने चाहिए। उदाहरण के लिए, यदि प्रेजेंटेशन में **Segoe UI Emoji** फ़ॉन्ट उपयोग किया गया है और वह गायब है, तो आउटपुट इमेज में इमोजी मोनोक्रोम दिख सकते हैं।
{{% /alert %}}

## **FAQ**

**क्या Aspose.Slides स्लाइड्स को एनिमेशन के साथ रेंडर करने का समर्थन करता है?**

नहीं। [Slide.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#getImage) मेथड स्लाइड की एक स्थैतिक इमेज बनाता है और एनिमेशन को एक्सपोर्ट नहीं करता।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में एक्सपोर्ट किया जा सकता है?**

हां। छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह रेंडर किया जा सकता है। ऊपर दिए गए उदाहरण की तरह प्रोसेसिंग लूप में उन्हें शामिल करें।

**क्या स्लाइड इमेज में छाया और अन्य प्रभाव संरक्षित रहते हैं?**

हां। Aspose.Slides स्लाइड इमेज में छाया, ट्रांसपैरेंसी और अन्य समर्थित ग्राफ़िकल इफ़ेक्ट्स को रेंडर करता है।