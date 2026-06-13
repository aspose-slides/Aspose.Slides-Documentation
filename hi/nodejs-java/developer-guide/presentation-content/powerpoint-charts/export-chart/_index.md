---
title: जावास्क्रिप्ट में प्रस्तुति चार्ट निर्यात करें
linktitle: चार्ट निर्यात करें
type: docs
weight: 90
url: /hi/nodejs-java/export-chart/
keywords:
- चार्ट
- चार्ट से छवि
- चार्ट को छवि के रूप में
- चार्ट छवि निकालें
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ प्रस्तुति चार्ट को निर्यात करना सीखें, PPT और PPTX फ़ॉर्मेट का समर्थन करता है, और किसी भी कार्यप्रवाह में रिपोर्टिंग को सहज बनाएं।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतीकरण से एक चार्ट को छवि के रूप में निर्यात करने की अनुमति देता है। यह लेख दिखाता है कि चार्ट से छवि कैसे प्राप्त करें और उसे सहेजें, जो तब उपयोगी होता है जब आपको PowerPoint प्रस्तुति के बाहर चार्ट विज़ुअल्स को पुनः उपयोग करना हो।

## **चार्ट छवि प्राप्त करें**
Aspose.Slides for Node.js via Java विशिष्ट चार्ट की छवि निकालने के लिए समर्थन प्रदान करता है। नीचे दिया गया नमूना उदाहरण है।

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
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

**क्या मैं एक चार्ट को रास्टर छवि के बजाय वेक्टर (SVG) के रूप में निर्यात कर सकता हूँ?**

हाँ। एक चार्ट एक आकार है, और इसकी सामग्री को SVG में सहेजा जा सकता है [shape-to-SVG saving method](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/writeassvg/) का उपयोग करके।

**मैं निर्यात किए गए चार्ट का पिक्सेल में सटीक आकार कैसे निर्धारित कर सकता हूँ?**

चित्र-रेंडरिंग ओवरलोड का उपयोग करें जो आकार या स्केल निर्दिष्ट करने की अनुमति देते हैं—लाइब्रेरी दी गई आयाम/स्केल के साथ वस्तुओं को रेंडर करने का समर्थन करती है।

**निर्यात के बाद लेबल्स और लीजन में फ़ॉन्ट्स गलत दिखें तो मुझे क्या करना चाहिए?**

[आवश्यक फ़ॉन्ट्स लोड करें](/slides/hi/nodejs-java/custom-font/) को [FontsLoader](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/) के द्वारा लोड करें ताकि चार्ट रेंडरिंग मीट्रिक्स और टेक्स्ट रूप को बनाए रखे।

**क्या निर्यात PowerPoint थीम, शैलियों और प्रभावों का सम्मान करता है?**

हाँ। Aspose.Slides का रेंडरर प्रस्तुति के फ़ॉर्मेटिंग (थीम, शैलियाँ, फिल, प्रभाव) का पालन करता है, इसलिए चार्ट की उपस्थिति बनी रहती है।

**चार्ट छवियों से परे उपलब्ध रेंडरिंग/निर्यात क्षमताएँ मुझे कहाँ मिलेंगी?**

आउटपुट टार्गेट्स के लिए [API](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/)/[documentation](/slides/hi/nodejs-java/convert-powerpoint/) देखें ([PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/hi/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/hi/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/), आदि) और संबंधित रेंडरिंग विकल्प।