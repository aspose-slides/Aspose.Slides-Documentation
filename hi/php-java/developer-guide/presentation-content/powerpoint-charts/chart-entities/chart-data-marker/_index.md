---
title: प्रस्तुतियों में PHP का उपयोग करके चार्ट डेटा मार्कर्स का प्रबंधन
linktitle: डेटा मार्कर
type: docs
url: /hi/php-java/chart-data-marker/
keywords:
- चार्ट
- डेटा पॉइंट
- मार्कर
- मार्कर विकल्प
- मार्कर आकार
- भराव प्रकार
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के लिए PHP में चार्ट डेटा मार्कर्स को कस्टमाइज़ करने का तरीका जानें, स्पष्ट कोड उदाहरणों के साथ PPT और PPTX फ़ॉर्मेट्स में प्रस्तुति प्रभाव को बढ़ाते हुए।"
---
## **Overview**

यह लेख Aspose.Slides में चार्ट डेटा मार्कर्स के साथ काम करने का तरीका समझाता है। यह दिखाता है कि चार्ट कैसे बनाया जाए, एक श्रृंखला और उसके डेटा पॉइंट्स तक कैसे पहुँचें, डेटा‑पॉइंट स्तर पर मार्कर्स पर तस्वीर भराव लागू करें, मार्कर का आकार समायोजित करें, और अपडेटेड प्रस्तुति को सेव करें। यह यह भी बताता है कि मानक मार्कर आकार `MarkerStyleType` एन्युमरेशन द्वारा उपलब्ध हैं और जब चार्ट को रास्टर फॉर्मेट या SVG में निर्यात किया जाता है तो मार्कर की उपस्थिति बनी रहती है।

## **Set Chart Marker Options**
मार्कर्स को विशेष श्रृंखला के भीतर चार्ट डेटा पॉइंट्स पर सेट किया जा सकता है। चार्ट मार्कर विकल्प सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास को इंस्टैंशिएट करें।
- डिफ़ॉल्ट चार्ट बनाएं।
- चित्र सेट करें।
- पहली चार्ट श्रृंखला लें।
- नया डेटा पॉइंट जोड़ें।
- प्रस्तुति को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने डेटा पॉइंट स्तर पर चार्ट मार्कर विकल्प सेट किए हैं।

```php
  # खाली प्रस्तुति बना रहे हैं
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँचें
    $slide = $pres->getSlides()->get_Item(0);
    # डिफ़ॉल्ट चार्ट बना रहे हैं
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त कर रहे हैं
    $defaultWorksheetIndex = 0;
    # चार्ट डेटा वर्कशीट प्राप्त कर रहे हैं
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # डेमो श्रृंखला हटाएँ
    $chart->getChartData()->getSeries()->clear();
    # नई श्रृंखला जोड़ें
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # चित्र 1 लोड करें
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # चित्र 2 लोड करें
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # पहली चार्ट श्रृंखला लें
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # वहाँ नया बिंदु (1:3) जोड़ें।
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # चार्ट श्रृंखला मार्कर बदल रहे हैं
    $series->getMarker()->setSize(15);
    # चार्ट के साथ प्रस्तुति सहेजें
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**कौन से मार्कर शैलियाँ बॉक्स से बाहर उपलब्ध हैं?**

मानक शैलियाँ उपलब्ध हैं (वृत्त, वर्ग, हीरा, त्रिभुज आदि); यह सूची [MarkerStyleType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markerstyletype/) क्लास द्वारा परिभाषित है। यदि आपको गैर‑मानक आकार चाहिए, तो कस्टम विज़ुअल्स के अनुकरण के लिए चित्र भराव वाला मार्कर उपयोग करें।

**क्या चार्ट को छवि या SVG में निर्यात करने पर मार्कर संरक्षित रहते हैं?**

हां। जब चार्ट को [raster formats](/slides/hi/php-java/convert-powerpoint-to-png/) में रेंडर किया जाता है या [shapes as SVG](/slides/hi/php-java/render-a-slide-as-an-svg-image/) के रूप में सहेजा जाता है, तो मार्कर अपनी उपस्थिति और सेटिंग्स, जिसमें आकार, भराव, और आउटलाइन शामिल है, को बनाए रखते हैं।