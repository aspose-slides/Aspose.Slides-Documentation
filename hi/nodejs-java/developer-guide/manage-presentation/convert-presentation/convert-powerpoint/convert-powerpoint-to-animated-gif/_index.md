---
title: JavaScript में PowerPoint प्रस्तुतियों को एनिमेटेड GIF में परिवर्तित करें
linktitle: PowerPoint को GIF में
type: docs
weight: 65
url: /hi/nodejs-java/convert-powerpoint-to-animated-gif/
keywords:
- एनिमेटेड GIF
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
- PowerPoint को GIF में
- प्रस्तुति को GIF में
- स्लाइड को GIF में
- PPT को GIF में
- PPTX को GIF में
- PPT को GIF के रूप में सहेजें
- PPTX को GIF के रूप में सहेजें
- PPT को GIF के रूप में निर्यात करें
- PPTX को GIF के रूप में निर्यात करें
- डिफ़ॉल्ट सेटिंग्स
- कस्टम सेटिंग्स
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript में Aspose.Slides for Node.js का उपयोग करके (Java के माध्यम से) PowerPoint प्रस्तुतियों (PPT, PPTX) को आसानी से एनिमेटेड GIF में परिवर्तित करें। तेज़, उच्च-गुणवत्ता वाले परिणाम।"
---
## **सारांश**

Aspose.Slides आपको केवल कुछ ही कोड पंक्तियों के साथ PowerPoint प्रस्तुतियों को एनिमेटेड GIF फ़ाइलों में परिवर्तित करने की अनुमति देता है। यह तब उपयोगी होता है जब आपको स्लाइड सामग्री को हल्के, व्यापक रूप से समर्थित एनिमेटेड फ़ॉर्मेट में साझा करना होता है, जिसे वेब पृष्ठों, मैसेजर्स या दस्तावेज़ों में एम्बेड किया जा सकता है। यह लेख डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुति को GIF में निर्यात करने और फ्रेम आकार, स्लाइड विलंब, और ट्रांज़िशन फ्रेम दर जैसी विकल्पों को कॉन्फ़िगर करके आउटपुट को अनुकूलित करने के बारे में बताता है, जिसके लिए आप [GifOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/gifoptions/) का उपयोग कर सकते हैं।

## **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में बदलना**

यह JavaScript में नमूना कोड आपको मानक सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में बदलना दिखाता है:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

डिफ़ॉल्ट पैरामीटरों के साथ एनिमेटेड GIF बनाया जाएगा।

{{%  alert  title="TIP"  color="primary"  %}} 
यदि आप GIF के पैरामीटर को अनुकूलित करना पसंद करते हैं, तो आप [GifOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GifOptions) क्लास का उपयोग कर सकते हैं। नीचे दिया गया नमूना कोड देखें।
{{% /alert %}} 

## **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में बदलना**

यह नमूना कोड आपको JavaScript में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में बदलना दिखाता है:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// परिणामी GIF का आकार
    gifOptions.setDefaultDelay(2000);// प्रत्येक स्लाइड को अगले पर बदलने से पहले कितनी देर तक दिखाया जाएगा
    gifOptions.setTransitionFps(35);// बेहतर ट्रांज़िशन एनीमेशन गुणवत्ता के लिए FPS बढ़ाएँ
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
आप Aspose द्वारा विकसित एक निःशुल्क [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर देख सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि प्रस्तुति में उपयोग किए गए फ़ॉन्ट सिस्टम पर स्थापित नहीं हैं तो क्या होगा?**

गुम फ़ॉन्ट स्थापित करें या [फ़ॉन्ट फॉलबैक कॉन्फ़िगर करें](/slides/hi/nodejs-java/powerpoint-fonts/). Aspose.Slides प्रतिस्थापन करेगा, लेकिन दिखावट अलग हो सकती है। ब्रांडिंग के लिए हमेशा सुनिश्चित करें कि आवश्यक टाइपफ़ेस स्पष्ट रूप से उपलब्ध हों।

**क्या मैं GIF फ्रेम पर वाटरमार्क ओवरले कर सकता हूँ?**

हां। [अर्ध- पारदर्शी वस्तु/लोगो जोड़ें](/slides/hi/nodejs-java/watermark/) मास्टर स्लाइड या व्यक्तिगत स्लाइड पर निर्यात से पहले — वाटरमार्क हर फ्रेम पर दिखाई देगा।