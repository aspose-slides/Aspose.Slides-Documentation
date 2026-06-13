---
title: "जावास्क्रिप्ट में प्रेजेंटेशन शैप्स के थंबनेल बनाएं"
linktitle: "शैप थंबनेल"
type: docs
weight: 70
url: /hi/nodejs-java/create-shape-thumbnails/
keywords:
- शैप थंबनेल
- शैप इमेज
- शैप रेंडर
- शैप रेंडरिंग
- PowerPoint
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js के साथ PowerPoint स्लाइड्स से उच्च गुणवत्ता वाले शैप थंबनेल उत्पन्न करें – प्रेजेंटेशन थंबनेल आसानी से बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides का उपयोग प्रेजेंटेशन फ़ाइलें बनाने के लिए किया जाता है जहाँ प्रत्येक पृष्ठ एक स्लाइड होता है। इन स्लाइडों को Microsoft PowerPoint का उपयोग करके प्रेजेंटेशन फ़ाइलें खोल कर देखा जा सकता है। लेकिन कभी‑कभी, डेवलपर्स को शैप्स की छवियों को अलग से इमेज व्यूअर में देखना पड़ता है। ऐसे मामलों में, Aspose.Slides आपको स्लाइड शैप्स के थंबनेल इमेज बनाने में सहायता करता है। इस सुविधा का उपयोग कैसे करें, यह लेख में बताया गया है।

यह लेख विभिन्न तरीकों से स्लाइड थंबनेल बनाने का विवरण देता है:

- स्लाइड के भीतर शैप थंबनेल बनाना।
- उपयोगकर्ता‑परिभाषित आयामों के साथ स्लाइड शैप के लिए शैप थंबनेल बनाना।
- शैप की उपस्थिति की सीमाओं के भीतर शैप थंबनेल बनाना।

## **स्लाइड्स से आकार थंबनेल बनाना**
Aspose.Slides for Node.js via Java का उपयोग कर किसी भी स्लाइड से शैप थंबनेल बनाने के लिए निम्न कार्य करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
2. उसकी ID या इंडेक्स का उपयोग कर किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. [आकार थंबनेल छवि प्राप्त करें](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getImage--) डिफ़ॉल्ट स्केल पर रेफ़रेंस की गई स्लाइड की।
4. थंबनेल इमेज को अपनी पसंद के इमेज फॉर्मेट में सहेजें।

```javascript
// प्रेजेंटेशन फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // इमेज को PNG फॉर्मेट में डिस्क पर सहेजें
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **उपयोगकर्ता‑परिभाषित स्केलिंग फैक्टर के साथ आकार थंबनेल बनाना**
Aspose.Slides for Node.js via Java का उपयोग कर स्लाइड का शैप थंबनेल बनाने के लिए निम्न कार्य करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
2. उसकी ID या इंडेक्स का उपयोग कर किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. [उपयोगकर्ता‑परिभाषित आयामों के साथ शैप थंबनेल छवि प्राप्त करें](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) रेफ़रेंस की गई स्लाइड की।
4. थंबनेल इमेज को अपनी पसंद के इमेज फॉर्मेट में सहेजें।

```javascript
// प्रेजेंटेशन फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **सीमाओं के आकार थंबनेल बनाना**
यह विधि शैप्स के थंबनेल बनाने में डेवलपर्स को शैप की उपस्थिति की सीमाओं के भीतर थंबनेल बनाने की अनुमति देती है। यह सभी शैप इफ़ेक्ट्स को ध्यान में रखती है। उत्पन्न शैप थंबनेल स्लाइड की सीमाओं द्वारा प्रतिबंधित रहता है। शैप की उपस्थिति की सीमा में स्लाइड शैप का थंबनेल बनाने के लिए निम्न कार्य करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
2. उसकी ID या इंडेक्स का उपयोग कर किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. शैप की सीमाओं को उपस्थिति के रूप में लेकर रेफ़रेंस की गई स्लाइड की थंबनेल इमेज प्राप्त करें।
4. थंबनेल इमेज को अपनी पसंद के इमेज फॉर्मेट में सहेजें।

```javascript
// प्रेजेंटेशन फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**आकार थंबनेल सहेजते समय कौन से इमेज फ़ॉर्मेट का उपयोग किया जा सकता है?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imageformat/), और अन्य। शैप को SVG के रूप में भी [वीक्टर SVG के रूप में निर्यात किया जा सकता है](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/writeassvg/) शैप की सामग्री को SVG के रूप में सहेज कर।

**थंबनेल रेंडर करते समय Shape और Appearance बॉउंड्स में क्या अंतर है?**  
`Shape` का उपयोग शैप की ज्यामिति के आधार पर किया जाता है; `Appearance` [visual effects](/slides/hi/nodejs-java/shape-effect/) (शैडोज़, ग्लो, आदि) को ध्यान में रखता है।

**यदि कोई शैप hidden के रूप में चिह्नित है तो क्या वह अभी भी थंबनेल के रूप में रेंडर होगा?**  
एक hidden शैप मॉडल का हिस्सा बना रहता है और रेंडर किया जा सकता है; hidden फ़्लैग स्लाइडशो प्रदर्शन को प्रभावित करता है लेकिन शैप की इमेज बनाने में बाधा नहीं बनता।

**क्या ग्रुप शैप्स, चार्ट्स, SmartArt और अन्य जटिल ऑब्जेक्ट्स समर्थित हैं?**  
हाँ। कोई भी ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) के रूप में दर्शाया जाता है (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartart/) शामिल हैं) थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम‑इंडस्टॉल फ़ॉन्ट्स टेक्स्ट शैप्स के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**  
हँ। आपको [आवश्यक फ़ॉन्ट प्रदान करना](/slides/hi/nodejs-java/custom-font/) चाहिए (या [फ़ॉन्ट सब्स्टिट्यूशन कॉन्फ़िगर करना](/slides/hi/nodejs-java/font-substitution/)) ताकि अनपेक्षित fallback और टेक्स्ट रीफ़्लो से बचा जा सके।