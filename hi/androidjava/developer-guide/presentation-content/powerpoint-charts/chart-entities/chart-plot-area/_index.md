---
title: Android पर प्रस्तुति चार्ट के प्लॉट एरिया को अनुकूलित करें
linktitle: प्लॉट एरिया
type: docs
url: /hi/androidjava/chart-plot-area/
keywords:
- चार्ट
- प्लॉट एरिया
- प्लॉट एरिया चौड़ाई
- प्लॉट एरिया ऊँचाई
- प्लॉट एरिया आकार
- लेआउट मोड
- पावरपॉइंट
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ पावरपॉइंट प्रस्तुतियों में चार्ट प्लॉट एरिया को कैसे अनुकूलित करें, यह जानें। अपने स्लाइड विज़ुअल को आसानी से सुधारें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट के प्लॉट एरिया के साथ काम करने का तरीका दिखाता है। यह चार्ट लेआउट को वैलिडेट करके और उसके X, Y, चौड़ाई और ऊँचाई मान पढ़कर प्लॉट एरिया की वास्तविक स्थिति और आकार प्राप्त करने की प्रक्रिया को समझाता है।

यह यह भी दर्शाता है कि लेआउट को मैन्युअली सेट करने पर प्लॉट एरिया का लेआउट मोड कैसे कॉन्फ़िगर किया जाए, `LayoutTargetType` का उपयोग करके यह निर्धारित किया जाए कि प्लॉट एरिया को उसके आंतरिक क्षेत्र या बाहरी क्षेत्र (धुरी और धुरी लेबल सहित) द्वारा गणना किया जाए।

## **चार्ट प्लॉट एरिया की चौड़ाई और ऊँचाई प्राप्त करें**
Aspose.Slides for Android via Java एक सरल API प्रदान करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
2. पहली स्लाइड तक पहुँचें।
3. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
4. वास्तविक मान प्राप्त करने से पहले [IChart.validateChartLayout()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChart#validateChartLayout--) मेथड को कॉल करें।
5. चार्ट तत्व का वास्तविक X स्थान (बाएं) प्राप्त करता है, जो चार्ट के बाएँ शीर्ष कोने के सापेक्ष होता है।
6. चार्ट तत्व का वास्तविक शीर्ष प्राप्त करता है, जो चार्ट के बाएँ शीर्ष कोने के सापेक्ष होता है।
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

## **चार्ट प्लॉट एरिया का लेआउट मोड सेट करें**
Aspose.Slides for Android via Java चार्ट प्लॉट एरिया के लेआउट मोड को सेट करने के लिए एक सरल API प्रदान करता है। मेथड [**setLayoutTargetType**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) और [**getLayoutTargetType**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) को [**ChartPlotArea**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartPlotArea) क्लास और [**IChartPlotArea**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartPlotArea) इंटरफ़ेस में जोड़ा गया है। यदि प्लॉट एरिया का लेआउट मैन्युअली परिभाषित किया गया है, तो यह प्रॉपर्टी निर्धारित करती है कि प्लॉट एरिया को उसके भीतर (धुरी और धुरी लेबल को शामिल नहीं) या बाहर (धुरी और धुरी लेबल सहित) द्वारा लेआउट किया जाए। दो संभावित मान हैं जो [**LayoutTargetType**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LayoutTargetType) enum में परिभाषित हैं।

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LayoutTargetType#Inner) - यह निर्दिष्ट करता है कि प्लॉट एरिया का आकार प्लॉट एरिया के आकार को निर्धारित करेगा, टिक मार्क और धुरी लेबल को शामिल नहीं करेगा।
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LayoutTargetType#Outer) - यह निर्दिष्ट करता है कि प्लॉट एरिया का आकार प्लॉट एरिया, टिक मार्क और धुरी लेबल को निर्धारित करेगा।

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

## **FAQ**

**वास्तविक x, वास्तविक y, वास्तविक चौड़ाई और वास्तविक ऊँचाई किस इकाइयों में लौटाए जाते हैं?**  
पॉइंट्स में; 1 इंच = 72 पॉइंट्स। ये Aspose.Slides के समन्वय इकाइयाँ हैं।

**सामग्री के मामले में प्लॉट एरिया और चार्ट एरिया में क्या अंतर है?**  
प्लॉट एरिया डेटा ड्रॉइंग क्षेत्र है (सीरीज़, ग्रिडलाइन, ट्रेंडलाइन आदि); चार्ट एरिया में आसपास के तत्व शामिल होते हैं (शीर्षक, लेजेंड आदि)। 3D चार्ट्स में प्लॉट एरिया में दीवारें/फ़्लोर और धुरियाँ भी शामिल होती हैं।

**जब लेआउट मैन्युअल हो तो प्लॉट एरिया के x, y, चौड़ाई और ऊँचाई को कैसे समझा जाता है?**  
वे चार्ट के कुल आकार के भाग (0–1) के रूप में होते हैं; इस मोड में ऑटो-पोज़िशनिंग बंद हो जाती है और आपके द्वारा सेट किए गए भागों को उपयोग किया जाता है।

**लेजेंड जोड़ने/हिलाने के बाद प्लॉट एरिया की स्थिति क्यों बदल गई?**  
लेजेंड चार्ट एरिया के बाहर बैठता है लेकिन लेआउट और उपलब्ध स्थान को प्रभावित करता है, इसलिए ऑटो-पोज़िशनिंग सक्रिय होने पर प्लॉट एरिया स्थानांतरित हो सकता है। (यह PowerPoint चार्ट्स के लिए सामान्य व्यवहार है।)