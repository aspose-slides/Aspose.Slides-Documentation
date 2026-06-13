---
title: JavaScript में PowerPoint स्लाइड्स को PNG में बदलें
linktitle: PowerPoint से PNG
type: docs
weight: 30
url: /hi/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से PNG
- प्रेजेंटेशन से PNG
- स्लाइड से PNG
- PPT से PNG
- PPTX से PNG
- PPT को PNG के रूप में सहेजें
- PPTX को PNG के रूप में सहेजें
- PPT को PNG में निर्यात करें
- PPTX को PNG में निर्यात करें
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript में Aspose.Slides for Node.js का उपयोग करके PowerPoint प्रस्तुतियों को उच्च गुणवत्ता वाली PNG छवियों में तेज़ी से बदलें, सटीक और स्वचालित परिणाम सुनिश्चित करते हुए।"
---
## **Overview**

यह लेख समझाता है कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को PNG छवियों में कैसे बदलें। यह दिखाता है कि PPT, PPTX, और ODP जैसे स्वरूपों में प्रस्तुति फ़ाइलों को कैसे लोड करें, स्लाइड को छवियों के रूप में रेंडर करें, और परिणाम को PNG स्वरूप में सहेजें।

लेख यह भी दर्शाता है कि उत्पन्न PNG छवियों को स्केल मान सेट करके या इच्छित चौड़ाई और ऊँचाई निर्दिष्ट करके कैसे अनुकूलित किया जा सकता है।

## **Convert PowerPoint to PNG**

इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
2. [Presentation.getSlides()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) मेथड द्वारा लौटाए गए संग्रह से स्लाइड ऑब्जेक्ट प्राप्त करें, जो [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Slide) क्लास के अंतर्गत है।
3. प्रत्येक स्लाइड की थंबनेल प्राप्त करने के लिए [Slide.getImage()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Slide) मेथड का उपयोग करें।
4. स्लाइड थंबनेल को PNG स्वरूप में सहेजने के लिए [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/#save) मेथड का उपयोग करें।

यह JavaScript कोड दिखाता है कि PowerPoint प्रस्तुति को PNG में कैसे बदलें:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Convert PowerPoint to PNG With Custom Dimensions**

यदि आप एक निश्चित पैमाने के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `desiredX` और `desiredY` के मान सेट कर सकते हैं, जो परिणामी थंबनेल के आयाम निर्धारित करते हैं।

यह कोड JavaScript में वर्णित ऑपरेशन को दर्शाता है:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Convert PowerPoint to PNG With Custom Size**

यदि आप एक निश्चित आकार के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `ImageSize` के लिए अपनी पसंदीदा `width` और `height` तर्क पास कर सकते हैं।

यह कोड दिखाता है कि PowerPoint को PNG में बदलते समय छवियों के आकार को कैसे निर्दिष्ट किया जाए:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**मैं केवल एक विशिष्ट आकार (जैसे चार्ट या चित्र) को पूरी स्लाइड की बजाय कैसे निर्यात कर सकता हूँ?**

Aspose.Slides [व्यक्तिगत आकारों के लिए थंबनेल बनाना](/slides/hi/nodejs-java/create-shape-thumbnails/) का समर्थन करता है; आप किसी आकार को PNG छवि में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर परिवर्तन समर्थित है?**

हाँ, लेकिन [थ्रेड्स के बीच एक ही प्रस्तुति इंस्टेंस को साझा न करें](/slides/hi/nodejs-java/multithreading/); प्रत्येक थ्रेड या प्रक्रिया के लिए एक अलग इंस्टेंस प्रयोग करें।

**PNG में निर्यात करते समय ट्रायल-वर्ज़न की सीमाएँ क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों में वॉटरमार्क जोड़ता है और लाइसेंस लागू होने तक [अन्य प्रतिबंध](/slides/hi/nodejs-java/licensing/) लागू करता है।