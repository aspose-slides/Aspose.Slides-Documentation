---
title: जावा में प्रेजेंटेशन चार्ट्स के प्लॉट एरिया को कस्टमाइज़ करें
linktitle: प्लॉट एरिया
type: docs
url: /hi/java/chart-plot-area/
keywords:
- चार्ट
- प्लॉट एरिया
- प्लॉट एरिया चौड़ाई
- प्लॉट एरिया ऊँचाई
- प्लॉट एरिया आकार
- लेआउट मोड
- पावरपॉइंट
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में चार्ट प्लॉट एरिया को कस्टमाइज़ करने का तरीका जानें। अपने स्लाइड दृश्य को आसानी से सुधारें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में एक चार्ट के प्लॉट एरिया के साथ काम करने का तरीका दर्शाता है। यह चार्ट लेआउट को सत्यापित करके और फिर उसके X, Y, चौड़ाई और ऊँचाई मान पढ़कर प्लॉट एरिया की वास्तविक स्थिति और आकार प्राप्त करने की प्रक्रिया समझाता है।

यह यह भी दर्शाता है कि जब लेआउट को मैन्युअली सेट किया जाता है, तो प्लॉट एरिया के लेआउट मोड को कैसे कॉन्फ़िगर किया जाए, `LayoutTargetType` का उपयोग करके यह निर्धारित किया जा सके कि प्लॉट एरिया का आकार उसके आंतरिक क्षेत्र द्वारा गणना किया जाए या बाहरी क्षेत्र (धुरी और धुरी लेबल सहित) द्वारा।

## **एक चार्ट प्लॉट एरिया की चौड़ाई और ऊँचाई प्राप्त करें**
Aspose.Slides for Java एक सरल API प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
2. पहली स्लाइड तक पहुँचें।
3. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
4. वास्तविक मान प्राप्त करने के लिए पहले [IChart.validateChartLayout()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChart#validateChartLayout--) मेथड को कॉल करें।
5. चार्ट तत्व की वास्तविक X स्थिति (बाएँ) प्राप्त करता है, जो चार्ट के बाएँ ऊपर कोने के सापेक्ष होती है।
6. चार्ट तत्व के वास्तविक शीर्ष को प्राप्त करता है, जो चार्ट के बाएँ ऊपर कोने के सापेक्ष होता है।
7. चार्ट तत्व की वास्तविक चौड़ाई प्राप्त करता है।
8. चार्ट तत्व की वास्तविक ऊँचाई प्राप्त करता है।

```java
// Presentation क्लास का एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **एक चार्ट प्लॉट एरिया का लेआउट मोड सेट करें**
Aspose.Slides for Java चार्ट प्लॉट एरिया के लेआउट मोड को सेट करने के लिए एक सरल API प्रदान करता है। मेथड **setLayoutTargetType** और **getLayoutTargetType** को **ChartPlotArea** क्लास और **IChartPlotArea** इंटरफ़ेस में जोड़ा गया है। यदि प्लॉट एरिया का लेआउट मैन्युअली परिभाषित किया गया है, तो यह प्रॉपर्टी यह निर्दिष्ट करती है कि प्लॉट एरिया को उसके अंदर (अक्ष और अक्ष लेबल शामिल नहीं) या बाहर (अक्ष और अक्ष लेबल सहित) द्वारा लेआउट किया जाए। दो संभावित मान हैं जो **LayoutTargetType** एन्‍यूम में परिभाषित हैं।

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LayoutTargetType#Inner) - यह निर्दिष्ट करता है कि प्लॉट एरिया का आकार प्लॉट एरिया द्वारा निर्धारित किया जाएगा, टिक मार्क और अक्ष लेबल को शामिल किए बिना।
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LayoutTargetType#Outer) - यह निर्दिष्ट करता है कि प्लॉट एरिया का आकार प्लॉट एरिया, टिक मार्क और अक्ष लेबल द्वारा निर्धारित किया जाएगा।

नीचे नमूना कोड दिया गया है।

```java
// Presentation क्लास का एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**वास्तविक x, वास्तविक y, वास्तविक चौड़ाई और वास्तविक ऊँचाई किन इकाइयों में लौटाए जाते हैं?**

पॉइंट्स में; 1 इंच = 72 पॉइंट्स। ये Aspose.Slides के समन्वय इकाइयाँ हैं।

**सामग्री के संदर्भ में प्लॉट एरिया और चार्ट एरिया में क्या अंतर है?**

प्लॉट एरिया डेटा ड्रॉइंग क्षेत्र है (श्रृंखलाएँ, ग्रिडलाइन, ट्रेंडलाइन आदि); चार्ट एरिया में आसपास के तत्व शामिल होते हैं (शीर्षक, लेजेंड आदि)। 3D चार्ट्स में, प्लॉट एरिया में दीवारें/फ़्लोर और धुरियों को भी शामिल किया जाता है।

**जब लेआउट मैन्युअल होता है, तो प्लॉट एरिया के x, y, चौड़ाई और ऊँचाई की व्याख्या कैसे की जाती है?**

ये चार्ट के कुल आकार के अंश (0–1) होते हैं; इस मोड में, स्वतः‑स्थिति निष्क्रिय होती है और आप द्वारा सेट किए गए अंश उपयोग होते हैं।

**लेजेंड जोड़ने/स्थानांतरित करने के बाद प्लॉट एरिया की स्थिति क्यों बदल गई?**

लेजेंड प्लॉट एरिया के बाहर चार्ट एरिया में स्थित होता है, लेकिन लेआउट और उपलब्ध स्थान को प्रभावित करता है, इसलिए जब स्वतः‑स्थिति सक्रिय होती है तो प्लॉट एरिया बदल सकता है। (यह PowerPoint चार्ट्स का सामान्य व्यवहार है।)