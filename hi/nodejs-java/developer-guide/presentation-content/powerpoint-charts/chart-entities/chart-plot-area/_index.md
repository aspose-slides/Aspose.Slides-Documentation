---
title: जावास्क्रिप्ट में प्रस्तुति चार्ट के प्लॉट एरिया को कस्टमाइज़ करें
linktitle: प्लॉट एरिया
type: docs
url: /hi/nodejs-java/chart-plot-area/
keywords:
- चार्ट
- प्लॉट एरिया
- प्लॉट एरिया चौडाई
- प्लॉट एरिया ऊँचाई
- प्लॉट एरिया आकार
- लेआउट मोड
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js के साथ PowerPoint प्रस्तुतियों में चार्ट प्लॉट एरिया को कस्टमाइज़ करने की विधि जानें। आसानी से अपनी स्लाइड दृश्य को सुधारें।"
---
## **समीक्षा**

यह लेख Aspose.Slides में चार्ट के प्लॉट एरिया के साथ काम करने के तरीके को दर्शाता है। यह चार्ट लेआउट को वैध करके और फिर उसके X, Y, चौड़ाई और ऊँचाई मान पढ़कर प्लॉट एरिया की वास्तविक स्थिति और आकार प्राप्त करने की प्रक्रिया को समझाता है।

यह यह भी दर्शाता है कि जब लेआउट को मैन्युअल रूप से सेट किया जाता है, तो `LayoutTargetType` का उपयोग करके प्लॉट एरिया के लेआउट मोड को कैसे कॉन्फ़िगर किया जाए, जिससे यह निर्धारित किया जा सके कि प्लॉट एरिया उसके आंतरिक क्षेत्र द्वारा या बाहरी क्षेत्र (धुरी और धुरी लेबल के साथ) द्वारा गणना किया जाता है।

## **चार्ट प्लॉट एरिया की चौड़ाई और ऊँचाई प्राप्त करना**

Aspose.Slides for Node.js via Java सरल API प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
1. पहली स्लाइड तक पहुंचें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. वास्तविक मान प्राप्त करने के लिए पहले [Chart.validateChartLayout()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Chart#validateChartLayout--) मेथड को कॉल करें।
1. चार्ट तत्व का वास्तविक X स्थान (बाएँ) चार्ट के बायें ऊपरी कोने के सापेक्ष प्राप्त करता है।
1. चार्ट तत्व का वास्तविक शीर्ष चार्ट के बायें ऊपरी कोने के सापेक्ष प्राप्त करता है।
1. चार्ट तत्व की वास्तविक चौड़ाई प्राप्त करता है।
1. चार्ट तत्व की वास्तविक ऊँचाई प्राप्त करता है।

```javascript
// Presentation क्लास का एक उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चार्ट प्लॉट एरिया के लेआउट मोड को सेट करना**

Aspose.Slides for Node.js via Java चार्ट प्लॉट एरिया के लेआउट मोड को सेट करने के लिए एक सरल API प्रदान करता है। मेथड्स [**setLayoutTargetType**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) और [**getLayoutTargetType**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) को [**ChartPlotArea**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartPlotArea) क्लास में जोड़ा गया है। यदि प्लॉट एरिया का लेआउट मैन्युअल रूप से परिभाषित किया गया है, तो यह प्रॉपर्टी निर्धारित करती है कि प्लॉट एरिया को उसके अंदर (धुरी और धुरी लेबल को छोड़कर) या बाहर (धुरी और धुरी लेबल सहित) द्वारा लेआउट किया जाए। दो संभावित मान हैं जो [**LayoutTargetType**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LayoutTargetType) enum में परिभाषित हैं।

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LayoutTargetType#Inner) - दर्शाता है कि प्लॉट एरिया का आकार प्लॉट एरिया के आकार को निर्धारित करेगा, टिक मार्क और धुरी लेबल को छोड़कर।
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LayoutTargetType#Outer) - दर्शाता है कि प्लॉट एरिया का आकार प्लॉट एरिया, टिक मार्क और धुरी लेबल के आकार को निर्धारित करेगा।

नीचे नमूना कोड दिया गया है।

```javascript
// Presentation क्लास का एक उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**वास्तविक X, वास्तविक Y, वास्तविक चौड़ाई और वास्तविक ऊँचाई किन इकाइयों में लौटाए जाते हैं?**

पॉइंट्स में; 1 इंच = 72 पॉइंट्स। ये Aspose.Slides समन्वय इकाइयाँ हैं।

**सामग्री के संदर्भ में प्लॉट एरिया और चार्ट एरिया में क्या अंतर है?**

प्लॉट एरिया डेटा ड्रॉइंग क्षेत्र है (सीरीज़, ग्रिडलाइन, ट्रेंडलाइन आदि); चार्ट एरिया में आसपास के तत्व शामिल होते हैं (शीर्षक, लेजेंड आदि)। 3D चार्ट में, प्लॉट एरिया में दीवारें/फ़्लोर और धुरियाँ भी शामिल होती हैं।

**जब लेआउट मैन्युअल हो तो प्लॉट एरिया के X, Y, चौड़ाई और ऊँचाई को कैसे व्याख्यायित किया जाता है?**

ये चार्ट के कुल आकार के अंश (0–1) होते हैं; इस मोड में ऑटो‑पोजिशनिंग निष्क्रिय हो जाता है और आप द्वारा सेट किए गए अंश उपयोग होते हैं।

**लेजेंड जोड़ने/स्थानांतरित करने के बाद प्लॉट एरिया की स्थिति क्यों बदल गई?**

लेजेंड प्लॉट एरिया के बाहर चार्ट एरिया में स्थित होता है, लेकिन लेआउट और उपलब्ध स्थान को प्रभावित करता है, इसलिए ऑटो‑पोजिशनिंग सक्रिय होने पर प्लॉट एरिया स्थान बदल सकता है। (यह PowerPoint चार्ट्स में सामान्य व्यवहार है।)