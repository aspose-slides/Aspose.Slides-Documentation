---
title: "PHP का उपयोग करके प्रस्तुतियों में चार्ट एक्सिस को अनुकूलित करें"
linktitle: "चार्ट एक्सिस"
type: docs
url: /hi/php-java/chart-axis/
keywords:
- "चार्ट एक्सिस"
- "ऊर्ध्वाधर एक्सिस"
- "समतल एक्सिस"
- "एक्सिस को अनुकूलित करें"
- "एक्सिस को संचालित करें"
- "एक्सिस का प्रबंधन"
- "एक्सिस गुण"
- "अधिकतम मान"
- "न्यूनतम मान"
- "एक्सिस रेखा"
- "तारीख स्वरूप"
- "एक्सिस शीर्षक"
- "एक्सिस स्थिति"
- "PowerPoint"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट एक्सिस को अनुकूलित करने हेतु Aspose.Slides for PHP via Java के उपयोग का पता लगाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट एक्सिस को अनुकूलित करने के तरीकों को समझाता है। यह वास्तविक एक्सिस मान प्राप्त करना, एक्सिस के बीच डेटा स्वैप करना, लाइन चार्ट के लिए वर्टिकल या हॉरिज़ॉन्टल एक्सिस को छिपाना, कैटेगरी एक्सिस प्रकार बदलना, कैटेगरी एक्सिस मानों के लिए डेट फ़ॉर्मेट सेट करना, एक्सिस शीर्षक को घुमाना, एक्सिस की स्थिति निर्धारित करना, और वैल्यू एक्सिस पर यूनिट लेबल दिखाना दर्शाता है।

## **चार्ट में वर्टिकल एक्सिस पर अधिकतम मान प्राप्त करना**
Aspose.Slides for PHP via Java आपको वर्टिकल एक्सिस पर न्यूनतम और अधिकतम मान प्राप्त करने की सुविधा देता है। इन चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का उदाहरण बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. एक्सिस पर वास्तविक अधिकतम मान प्राप्त करें।
1. एक्सिस पर वास्तविक न्यूनतम मान प्राप्त करें।
1. एक्सिस की वास्तविक मेजर यूनिट प्राप्त करें।
1. एक्सिस की वास्तविक माइनर यूनिट प्राप्त करें।
1. एक्सिस की वास्तविक मेजर यूनिट स्केल प्राप्त करें।
1. एक्सिस की वास्तविक माइनर यूनिट स्केल प्राप्त करें।

उपरोक्त चरणों का कार्यान्वयन दिखाने वाला यह नमूना कोड आवश्यक मान प्राप्त करने का तरीका प्रदर्शित करता है :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # प्रस्तुति को सहेजता है
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **एक्सिस के बीच डेटा स्वैप करना**
Aspose.Slides आपको तेजी से एक्सिस के बीच डेटा स्वैप करने की अनुमति देता है— वर्टिकल एक्सिस (y‑axis) पर प्रदर्शित डेटा हॉरिज़ॉन्टल एक्सिस (x‑axis) पर जाता है और इसके विपरीत।

इस PHP कोड में दिखाया गया है कि चार्ट में एक्सिस के बीच डेटा स्वैप कार्य कैसे किया जाए:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # पंक्तियों और स्तंभों को स्वैप करता है
    $chart->getChartData()->switchRowColumn();
    # प्रस्तुति को सहेजता है
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **लाइन चार्ट के लिए वर्टिकल एक्सिस को अक्षम करना**

यह PHP कोड दिखाता है कि लाइन चार्ट के लिए वर्टिकल एक्सिस को कैसे छिपाया जाए:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **लाइन चार्ट के लिए हॉरिज़ॉन्टल एक्सिस को अक्षम करना**

यह कोड दिखाता है कि लाइन चार्ट के लिए हॉरिज़ॉन्टल एक्सिस को कैसे छिपाया जाए:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **कैटेगरी एक्सिस बदलना**

**CategoryAxisType** प्रॉपर्टी का उपयोग करके आप अपनी पसंदीदा कैटेगरी एक्सिस प्रकार (**date** या **text**) निर्दिष्ट कर सकते हैं। यह कोड इस ऑपरेशन को प्रदर्शित करता है:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **कैटेगरी एक्सिस मानों के लिए डेट फ़ॉर्मेट सेट करना**
Aspose.Slides for PHP via Java आपको कैटेगरी एक्सिस मान के लिए डेट फ़ॉर्मेट सेट करने की अनुमति देता है। इस PHP कोड में ऑपरेशन दिखाया गया है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **चार्ट एक्सिस शीर्षक के लिए रोटेशन एंगल सेट करना**
Aspose.Slides for PHP via Java आपको चार्ट एक्सिस शीर्षक का रोटेशन एंगल सेट करने की सुविधा देता है। यह PHP कोड इस ऑपरेशन को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **कैटेगरी या वैल्यू एक्सिस पर एक्सिस की स्थिति सेट करना**
Aspose.Slides for PHP via Java आपको कैटेगरी या वैल्यू एक्सिस में एक्सिस की स्थिति निर्धारित करने की अनुमति देता है। यह PHP कोड कार्य को करने का तरीका दिखाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चार्ट वैल्यू एक्सिस पर डिस्प्ले यूनिट लेबल सक्षम करना**
Aspose.Slides for PHP via Java आपको चार्ट को उसके वैल्यू एक्सिस पर यूनिट लेबल दिखाने के लिए कॉन्फ़िगर करने की सुविधा देता है। यह PHP कोड इस ऑपरेशन को प्रदर्शित करता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**एक्सिस क्रॉसिंग (axis crossing) के लिए वह मान कैसे सेट करें जिस पर एक एक्सिस दूसरे को पार करता है?**

Axes एक [crossing setting](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/setcrosstype/) प्रदान करती हैं: आप शून्य पर, अधिकतम कैटेगरी/वैल्यू पर, या एक विशिष्ट संख्यात्मक मान पर क्रॉस करना चुन सकते हैं। यह X‑axis को ऊपर या नीचे शिफ्ट करने या बेसलाइन को उजागर करने में उपयोगी है।

**टिक लेबल्स को एक्सिस के सापेक्ष (साइडबाय, बाहर, अंदर) कैसे स्थिति दें?**

[label position](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/setmajortickmark/) को "cross", "outside", या "inside" पर सेट करें। यह पठनीयता को प्रभावित करता है और विशेष रूप से छोटे चार्ट पर स्थान बचाने में मदद करता है।