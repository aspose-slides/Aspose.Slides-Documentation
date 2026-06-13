---
title: प्रस्तुतियों में PHP के लिए चार्ट गणनाओं को अनुकूलित करें
linktitle: चार्ट गणनाएँ
type: docs
weight: 50
url: /hi/php-java/chart-calculations/
keywords:
- चार्ट गणनाएँ
- चार्ट तत्व
- तत्व स्थिति
- वास्तविक स्थिति
- संतान तत्व
- मूल तत्व
- चार्ट मान
- वास्तविक मान
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में PPT और PPTX के लिए चार्ट गणनाओं, डेटा अपडेट और सटीकता नियंत्रण को समझें, व्यावहारिक कोड उदाहरणों के साथ।"
---
## **परिचय**

Aspose.Slides प्रस्तुतियों में चार्ट गणनाओं और लेआउट डेटा के साथ काम करने के लिए API प्रदान करता है। यह लेख चार्ट तत्वों के वास्तविक मानों को प्राप्त करने के तरीके को दर्शाता है, जिसमें तत्वों की वास्तविक स्थिति और आकार तथा चार्ट अक्षों के वास्तविक मान शामिल हैं। यह यह भी समझाता है कि ये मान चार्ट लेआउट सत्यापन के बाद भर दिए जाते हैं।

इसके अतिरिक्त, लेख यह दिखाता है कि पैरेंट चार्ट तत्वों की वास्तविक स्थिति कैसे प्राप्त करें और शीर्षक, अक्ष, लेजेंड और ग्रिड लाइनों जैसे चार्ट घटकों को कैसे छिपाएँ। ये उदाहरण आपको प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों में चार्ट लेआउट जानकारी का निरीक्षण करने और चार्ट तत्वों की दृश्यता को नियंत्रित करने में सहायता करते हैं।

## **चार्ट तत्वों के वास्तविक मानों की गणना**
Aspose.Slides for PHP via Java इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। [Axis](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/) क्लास की विधियाँ अक्ष चार्ट तत्व की वास्तविक स्थिति के बारे में जानकारी देती हैं ([getActualMaxValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/getactualminorunitscale/))। गुणों को वास्तविक मानों से भरने के लिए पहले [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/validatechartlayout/) विधि को कॉल करना आवश्यक है।

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **पैरेंट चार्ट तत्वों की वास्तविक स्थिति की गणना**
Aspose.Slides for PHP via Java इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। `ActualLayout` क्लास की विधियाँ पैरेंट चार्ट तत्व की वास्तविक स्थिति (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`) के बारे में जानकारी देती हैं। गुणों को वास्तविक मानों से भरने के लिए पहले [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/validatechartlayout/) विधि को कॉल करना आवश्यक है।

```php
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

## **चार्ट तत्वों को छिपाएँ**
यह विषय आपको चार्ट से जानकारी छिपाने के तरीकों को समझने में मदद करता है। Aspose.Slides for PHP via Java का उपयोग करके आप चार्ट से **शीर्षक, ऊर्ध्वाधर अक्ष, क्षैतिज अक्ष** और **ग्रिड लाइनों** को छिपा सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि इन गुणों का उपयोग कैसे किया जाता है।

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # चार्ट शीर्षक छुपाएँ
    $chart->setTitle(false);
    # / मान अक्ष छुपाएँ
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # श्रेणी अक्ष दृश्यता
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # लेजेंड छुपाएँ
    $chart->setLegend(false);
    # मुख्य ग्रिड रेखाओं को छुपाएँ
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # श्रृंखला रेखा रंग सेट करना
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**क्या बाहरी Excel वर्कबुक को डेटा स्रोत के रूप में इस्तेमाल किया जा सकता है, और इसका पुनःगणना पर क्या प्रभाव पड़ता है?**

हाँ। एक चार्ट बाहरी वर्कबुक का संदर्भ ले सकता है: जब आप बाहरी स्रोत को कनेक्ट या रीफ़्रेश करते हैं, तो सूत्र और मान उस वर्कबुक से लिए जाते हैं, और चार्ट खुले/संपादित होने के दौरान अपडेट को दर्शाता है। API आपको [बाहरी वर्कबुक निर्दिष्ट करने](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/setexternalworkbook/) का पथ देने और लिंक्ड डेटा को प्रबंधित करने की अनुमति देता है।

**क्या मैं अपना खुद का रिग्रेशन लागू किए बिना ट्रेंडलाइन की गणना और प्रदर्शन कर सकता हूँ?**

हाँ। [ट्रेंडलाइन](/slides/hi/php-java/trend-line/) (रेखीय, घातीय एवं अन्य) को Aspose.Slides द्वारा जोड़ा और अपडेट किया जाता है; उनके पैरामीटर श्रृंखला डेटा से स्वचालित रूप से पुनःगणना होते हैं, इसलिए आपको अपने स्वयं के गणना लागू करने की आवश्यकता नहीं है।

**यदि प्रस्तुति में कई चार्ट हैं जिनमें बाहरी लिंक हैं, तो क्या मैं प्रत्येक चार्ट के लिए उपयोग किए जाने वाले वर्कबुक को नियंत्रित कर सकता हूँ?**

हाँ। प्रत्येक चार्ट अपना स्वयं का [बाहरी वर्कबुक](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/setexternalworkbook/) निर्दिष्ट कर सकता है, या आप प्रत्येक चार्ट के लिए अन्य चार्टों से स्वतंत्र रूप से एक बाहरी वर्कबुक बना/बदल सकते हैं।