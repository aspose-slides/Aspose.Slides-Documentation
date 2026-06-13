---
title: PHP में प्रस्तुति चार्ट के प्लॉट एरिया को अनुकूलित करें
linktitle: प्लॉट एरिया
type: docs
url: /hi/php-java/chart-plot-area/
keywords:
- चार्ट
- प्लॉट एरिया
- प्लॉट एरिया की चौड़ाई
- प्लॉट एरिया की ऊँचाई
- प्लॉट एरिया का आकार
- लेआउट मोड
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुतियों में चार्ट प्लॉट एरिया को अनुकूलित करने का तरीका जानें। अपनी स्लाइड विज़ुअल्स को आसानी से सुधारें।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट के प्लॉट एरिया के साथ काम करने का तरीका दिखाता है। यह चार्ट लेआउट को वैधित करके और फिर उसके X, Y, चौड़ाई और ऊँचाई मान पढ़कर प्लॉट एरिया की वास्तविक स्थिति और आकार प्राप्त करने की प्रक्रिया समझाता है।

यह भी प्रदर्शित करता है कि लेआउट को मैन्युअल रूप से सेट करने पर प्लॉट एरिया के लेआउट मोड को कैसे कॉन्फ़िगर करें, `LayoutTargetType` का उपयोग करके यह निर्धारित किया जाता है कि प्लॉट एरिया का आकार उसकी आंतरिक क्षेत्र द्वारा गणना किया जाए या बाहरी क्षेत्र (जिसमें अक्ष और अक्ष लेबल शामिल हैं) द्वारा।

## **चार्ट प्लॉट एरिया की चौड़ाई और ऊँचाई प्राप्त करें**
Aspose.Slides for PHP via Java एक सरल API प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
2. पहली स्लाइड तक पहुंचें।
3. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
4. वास्तविक मान प्राप्त करने के लिए पहले [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/validatechartlayout/) मेथड को कॉल करें।
5. चार्ट तत्व के बाएँ शीर्ष कोने की तुलना में चार्ट तत्व का वास्तविक X स्थान (बाएँ) प्राप्त करता है।
6. चार्ट तत्व के बाएँ शीर्ष कोने की तुलना में चार्ट तत्व का वास्तविक शीर्ष प्राप्त करता है।
7. चार्ट तत्व की वास्तविक चौड़ाई प्राप्त करता है।
8. चार्ट तत्व की वास्तविक ऊँचाई प्राप्त करता है।

```php
  # Presentation क्लास का एक इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चार्ट प्लॉट एरिया का लेआउट मोड सेट करें**
Aspose.Slides for PHP via Java चार्ट प्लॉट एरिया के लेआउट मोड को सेट करने के लिए एक सरल API प्रदान करता है। मेथड्स [**setLayoutTargetType**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) और [**getLayoutTargetType**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) को [**ChartPlotArea**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ChartPlotArea) क्लास में जोड़ा गया है। यदि प्लॉट एरिया का लेआउट मैन्युअल रूप से परिभाषित किया गया है तो यह प्रॉपर्टी निर्दिष्ट करती है कि प्लॉट एरिया को उसकी अंदरूनी (अक्ष और अक्ष लेबल को छोड़कर) या बाहरी (अक्ष और अक्ष लेबल सहित) हिस्सा द्वारा लेआउट किया जाए। दो संभावित मान हैं जो [**LayoutTargetType**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LayoutTargetType) एन्‍युम में परिभाषित हैं।

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LayoutTargetType#Inner) - निर्दिष्ट करता है कि प्लॉट एरिया का आकार प्लॉट एरिया के आकार को निर्धारित करेगा, जिसमें टिक मार्क और अक्ष लेबल शामिल नहीं होंगे।
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LayoutTargetType#Outer) - निर्दिष्ट करता है कि प्लॉट एरिया का आकार प्लॉट एरिया के आकार, टिक मार्क और अक्ष लेबल को निर्धारित करेगा।

नीचे नमूना कोड दिया गया है।

```php
  # Presentation क्लास का एक इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**वास्तविक x, वास्तविक y, वास्तविक चौड़ाई और वास्तविक ऊँचाई किस इकाइयों में लौटाए जाते हैं?**

पॉइंट्स में; 1 इंच = 72 पॉइंट्स। ये Aspose.Slides कोऑर्डिनेट इकाइयाँ हैं।

**सामग्री के संदर्भ में प्लॉट एरिया चार्ट एरिया से कैसे भिन्न है?**

प्लॉट एरिया डेटा ड्राइंग क्षेत्र है (सीरीज़, ग्रिडलाइन, ट्रेंडलाइन आदि); चार्ट एरिया में आसपास के तत्व (शीर्षक, लीजेंड आदि) शामिल होते हैं। 3D चार्ट्स में, प्लॉट एरिया में दीवारें/फ़्लोर और अक्ष भी शामिल होते हैं।

**जब लेआउट मैन्युअल होता है तो प्लॉट एरिया के x, y, चौड़ाई और ऊँचाई को कैसे समझा जाता है?**

वे चार्ट के कुल आकार के अंश (0–1) होते हैं; इस मोड में ऑटो-पोजिशनिंग निष्क्रिय हो जाता है और आप द्वारा सेट किए गए अंश उपयोग किए जाते हैं।

**लीजेंड जोड़ने/हटाने के बाद प्लॉट एरिया की स्थिति क्यों बदल गई?**

लीजेंड प्लॉट एरिया के बाहर चार्ट एरिया में स्थित होता है लेकिन लेआउट और उपलब्ध स्थान को प्रभावित करता है, इसलिए ऑटो-पोजिशनिंग सक्रिय होने पर प्लॉट एरिया स्थानांतरित हो सकता है। (यह PowerPoint चार्ट्स का मानक व्यवहार है।)