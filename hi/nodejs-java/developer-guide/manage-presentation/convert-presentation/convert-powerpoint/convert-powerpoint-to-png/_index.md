---
title: JavaScript में PowerPoint स्लाइड को PNG में बदलें
linktitle: PowerPoint से PNG
type: docs
weight: 30
url: /hi/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint बदलें
- प्रेजेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
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
description: "Aspose.Slides for Node.js के साथ JavaScript में PowerPoint प्रस्तुतियों को तेज़ी से उच्च‑गुणवत्ता वाली PNG छवियों में बदलें, जिससे सटीक, स्वचालित परिणाम मिलें।"
---
## **परिचय**

यह लेख बताता है कि Aspose.Slides for Node.js via Java का उपयोग करके प्रस्तुति स्लाइड्स को PNG छवियों में कैसे बदलें। आप PPT, PPTX, और ODP जैसे फॉर्मैट में प्रस्तुतियों को लोड कर सकते हैं, प्रत्येक स्लाइड को रेंडर कर सकते हैं, और इसे अलग‑अलग PNG छवि के रूप में सहेज सकते हैं।

नीचे दिए गए उदाहरण डिफ़ॉल्ट स्केल पर रेंडरिंग, स्केल बढ़ाने, पिक्सेल में आउटपुट आयाम निर्दिष्ट करने, और ग्रेडिएंट रेंडरिंग स्टाइल चुनने को दर्शाते हैं।

## **PowerPoint को PNG में बदलें**

Load a presentation with the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class and access its slides through the [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) collection. The example renders every slide with [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) without parameters to create a thumbnail. It then calls [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) with [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) to save each rendered slide as a PNG image.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
पैरामीटर‑रहित [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) ओवरलोड 0.2 स्केल पर रेंडर करता है। उदाहरण के लिए, 720 × 540 पॉइंट आकार की स्लाइड 144 × 108 पिक्सेल थंबनेल बनाती है। आउटपुट आयामों को नियंत्रित करने के लिए, नीचे दिखाए गए स्केल फैक्टर या स्पष्ट छवि आकार वाले ओवरलोड का उपयोग करें।
{{% /alert %}}

## **PowerPoint को PNG में बदलें कस्टम आयामों के साथ**

रेन्डर किए गए आयामों को नियंत्रित करने के लिए क्षैतिज और लंबवत स्केल फैक्टर को [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) में पास करें। इस उदाहरण में, दोनों फ़ैक्टर 2 हैं, इसलिए 720 × 540 पॉइंट की स्लाइड 1440 × 1080 पिक्सेल की छवि बनाती है। समान स्केल फैक्टर स्लाइड के आस्पेक्ट रेशियो को बनाए रखते हैं। प्रत्येक छवि को PNG फ़ॉर्मेट में [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) के साथ सहेजा जाता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **PowerPoint को PNG में बदलें कस्टम आकार के साथ**

पिक्सेल में आउटपुट आयाम निर्दिष्ट करने के लिए, स्केल फैक्टर की बजाय एक आकार को [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) में पास करें। यह उदाहरण प्रत्येक स्लाइड को 960 × 720 पिक्सेल पर रेंडर करता है और परिणाम को [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) द्वारा सहेजता है। छवि के खिंचाव से बचने हेतु स्लाइड के आस्पेक्ट रेशियो से मेल खाने वाले आयाम चुनें।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **ग्रेडिएंट रेंडरिंग स्टाइल चुनें**

मान लें कि किसी स्लाइड में ग्रेडिएंट फ़िल हैं, लेकिन निर्यात की गई PNG में परिवर्तन PowerPoint में दिखने वाले से हल्के या अलग दिखते हैं। आप [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) द्वारा विरासत में मिली [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) मेथड का उपयोग करके ग्रेडिएंट कैसे रेंडर हों, चुन सकते हैं।

डाउनलोड करें [gradient-styles.pptx](gradient-styles.pptx) और इसे एप्लिकेशन की कार्यरत डायरेक्टरी में रखें। उसकी पहली स्लाइड में दो रैखिक ग्रेडिएंट हैं: ऊपर सियान से ऑरेंज और नीचे ब्लू से येलो। प्रत्येक ग्रेडिएंट में दो स्टॉप हैं, 0% और 100% पर।

निम्नलिखित उदाहरण इस प्रस्तुतिकरण को लोड करता है और दोनों मोड में उसी पहली स्लाइड को [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) के साथ रेंडर करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

The images below show the output from the same slide, with both gradients in each image:

| Default | PowerPointUI |
| --- | --- |
| ![डिफ़ॉल्ट के साथ रेंडर किए गए सियान‑से‑ऑरेंज और ब्लू‑से‑येलो ग्रेडिएंट](gradient-Default.png) | ![PowerPointUI के साथ रेंडर किए गए वही ग्रेडिएंट](gradient-PowerPointUI.png) |

इस उदाहरण में, `Default` हल्के मध्यवर्ती रंग उत्पन्न करता है, जबकि `PowerPointUI` गहरे मध्यवर्ती रंग उत्पन्न करता है। अंतर ग्रेडिएंट में उपयोग किए गए रंगों और स्टॉप्स पर निर्भर करता है।

जब मानक Aspose.Slides आउटपुट आपकी आवश्यकता के अनुकूल हो, तो `Default` चुनें। यदि आपका प्राथमिकता PowerPoint में दिखाई देने वाले स्वरूप से मेल खाना है, तो `PowerPointUI` आज़माएँ। दोनों आउटपुट को अपने इच्छित परिणाम से तुलना करें; कोई भी मोड सार्वभौमिक रूप से श्रेष्ठ नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी स्लाइड के बजाय विशिष्ट शेम, जैसे चार्ट या चित्र, को कैसे निर्यात कर सकता हूँ?**

Aspose.Slides [व्यक्तिगत शेमों के लिए थंबनेल बनाना](/slides/hi/nodejs-java/create-shape-thumbnails/) को सपोर्ट करता है, जिससे आप किसी शेम को PNG छवि के रूप में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**

हाँ। प्रत्येक थ्रेड या प्रोसेस के लिए एक अलग प्रस्तुति इंस्टेंस उपयोग करें; [थ्रेड्स के बीच एक ही इंस्टेंस साझा न करें](/slides/hi/nodejs-java/multithreading/)।

**PNG निर्यात करते समय मूल्यांकन सीमाएँ क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों पर वॉटरमार्क जोड़ता है और लाइसेंस लागू होने तक [अन्य प्रतिबंध](/slides/hi/nodejs-java/licensing/) लागू करता है।