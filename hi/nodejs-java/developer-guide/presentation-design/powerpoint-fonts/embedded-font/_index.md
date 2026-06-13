---
title: JavaScript का उपयोग करके प्रस्तुतियों में फ़ॉन्ट एम्बेड करें
linktitle: फ़ॉन्ट एम्बेडिंग
type: docs
weight: 40
url: /hi/nodejs-java/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एम्बेड करें
- फ़ॉन्ट एम्बेडिंग
- एम्बेडेड फ़ॉन्ट प्राप्त करें
- एम्बेडेड फ़ॉन्ट जोड़ें
- एम्बेडेड फ़ॉन्ट हटाएँ
- एम्बेडेड फ़ॉन्ट संपीड़ित करें
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के माध्यम से Java का उपयोग करके PowerPoint और OpenDocument प्रेज़ेंटेशन में TrueType फ़ॉन्ट्स एम्बेड करें, जिससे सभी प्लेटफ़ॉर्म पर सटीक रेंडरिंग सुनिश्चित हो।"
---
## **परिचय**

**PowerPoint में एम्बेडेड फ़ॉन्ट्स** तब उपयोगी होते हैं जब आप चाहते हैं कि आपका प्रेज़ेंटेशन किसी भी सिस्टम या डिवाइस पर खोलने पर सही दिखे। यदि आपने अपने कार्य में रचनात्मकता दिखाते हुए तृतीय‑पक्ष या गैर‑मानक फ़ॉन्ट का उपयोग किया है, तो फ़ॉन्ट एम्बेड करने के और भी कारण मिलते हैं। अन्यथा (बिना एम्बेडेड फ़ॉन्ट्स के), आपकी स्लाइड्स पर टेक्स्ट या नंबर, लेआउट, स्टाइलिंग आदि बदल सकता है या भ्रमित करने वाले आयताकार आकार में बदल सकते हैं। 

The [FontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontsManager) क्लास, [FontData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontdata/) क्लास, [Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) क्लास, और उनकी क्लासें वह अधिकांश गुण और मेथड्स रखती हैं जिनकी आपको PowerPoint प्रेज़ेंटेशन में एम्बेडेड फ़ॉन्ट्स के साथ काम करने के लिए आवश्यकता होती है।

## **प्रेज़ेंटेशन से एम्बेडेड फ़ॉन्ट्स प्राप्त करें या हटाएँ**

Aspose.Slides [getEmbeddedFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) मेथड (जो [FontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontsManager) क्लास द्वारा उपलब्ध कराया गया है) आपको प्रेज़ेंटेशन में एम्बेडेड फ़ॉन्ट्स को प्राप्त (या जानने) की अनुमति देता है। फ़ॉन्ट्स हटाने के लिए, [removeEmbeddedFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) मेथड (जो उसी क्लास द्वारा उपलब्ध कराया गया है) उपयोग किया जाता है।

यह JavaScript कोड दिखाता है कि प्रेज़ेंटेशन से एम्बेडेड फ़ॉन्ट्स को कैसे प्राप्त और हटाया जाए:

```javascript
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // एक स्लाइड रेंडर करता है जिसमें एक टेक्स्ट फ्रेम है जो एम्बेडेड "FunSized" का उपयोग करता है
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // इमेज को JPEG फॉर्मेट में डिस्क पर सहेजें
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // सभी एम्बेडेड फ़ॉन्ट्स प्राप्त करता है
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // "Calibri" फ़ॉन्ट को खोजता है
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // "Calibri" फ़ॉन्ट को हटाता है
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // प्रस्तुति को रेंडर करता है; "Calibri" फ़ॉन्ट को मौजूदा फ़ॉन्ट से बदल दिया जाता है
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // इमेज को JPEG फॉर्मेट में डिस्क पर सहेजें
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // प्रेज़ेंटेशन को एम्बेडेड "Calibri" फ़ॉन्ट के बिना सहेजता है
    // डिस्क
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **प्रेज़ेंटेशन में एम्बेडेड फ़ॉन्ट्स जोड़ें**

आप [EmbedFontCharacters](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/embedfontcharacters/) enum और [addEmbeddedFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) मेथड के दो ओवरलोड का उपयोग करके, प्रेज़ेंटेशन में फ़ॉन्ट्स को एम्बेड करने के लिए अपनी पसंदीदा (एम्बेडिंग) नियम चुन सकते हैं। यह JavaScript कोड दिखाता है कि फ़ॉन्ट्स को प्रेज़ेंटेशन में कैसे एम्बेड और जोड़ें:

```javascript
// प्रस्तुति लोड करता है
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // प्रेज़ेंटेशन को डिस्क पर सहेजता है
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **एम्बेडेड फ़ॉन्ट्स को संपीड़ित करें**

एक प्रेज़ेंटेशन में एम्बेडेड फ़ॉन्ट्स को संपीड़ित करने और फ़ाइल आकार घटाने के लिए, Aspose.Slides [compressEmbeddedFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) मेथड (जो [Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) क्लास द्वारा उपलब्ध कराई गई है) प्रदान करता है।

यह JavaScript कोड दिखाता है कि एम्बेडेड PowerPoint फ़ॉन्ट्स को कैसे संपीड़ित किया जाए:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जान सकता हूँ कि प्रेज़ेंटेशन में कोई विशेष फ़ॉन्ट एम्बेडिंग के बावजूद रेंडरिंग के दौरान अभी भी प्रतिस्थापित होगा?**

फ़ॉन्ट मैनेज़र में [substitution information](/slides/hi/nodejs-java/font-substitution/) और [fallback/substitution rules](/slides/hi/nodejs-java/fallback-font/) देखें: यदि फ़ॉन्ट उपलब्ध नहीं है या प्रतिबंधित है, तो एक फॉलबैक उपयोग किया जाएगा।

**क्या Arial/Calibri जैसे “सिस्टम” फ़ॉन्ट्स को एम्बेड करना सार्थक है?**

आमतौर पर नहीं—वे लगभग हमेशा उपलब्ध होते हैं। लेकिन “पतले” वातावरण (Docker, प्री‑इंस्टॉल्ड फ़ॉन्ट्स के बिना Linux सर्वर) में पूरी पोर्टेबिलिटी के लिए, सिस्टम फ़ॉन्ट्स को एम्बेड करने से अनपेक्षित प्रतिस्थापनों के जोखिम को समाप्त किया जा सकता है।