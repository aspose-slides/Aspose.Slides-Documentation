---
title: PHP का उपयोग करके प्रस्तुति में चार्ट डेटा लेबल्स प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/php-java/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और फ़ॉर्मेट करने के तरीके सीखें, जिससे स्लाइड्स अधिक आकर्षक बनें।"
---
## **परिचय**

चार्ट पर डेटा लेबल्स चार्ट की डेटा सीरीज़ या व्यक्तिगत डेटा पॉइंट्स के बारे में विवरण दिखाते हैं। ये पाठकों को डेटा सीरीज़ को जल्दी पहचानने में मदद करते हैं और चार्ट को समझने में भी आसान बनाते हैं।

## **चार्ट डेटा लेबल्स में डेटा प्रिसीजन सेट करें**

यह PHP कोड आपको दर्शाता है कि चार्ट डेटा लेबल में डेटा प्रिसीजन कैसे सेट किया जाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **लेबल्स के रूप में प्रतिशत प्रदर्शित करें**
Aspose.Slides for PHP via Java आपको प्रदर्शित चार्ट्स पर प्रतिशत लेबल सेट करने की अनुमति देता है। यह PHP कोड इस प्रक्रिया को दर्शाता है:

```php
  # Presentation वर्ग का एक उदाहरण बनाता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करता है
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # चार्ट वाले प्रस्तुतीकरण को सहेजता है
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चार्ट डेटा लेबल्स के साथ प्रतिशत संकेत सेट करें**
यह PHP कोड आपको चार्ट डेटा लेबल के लिए प्रतिशत संकेत सेट करने का तरीका दिखाता है:

```php
  # Presentation वर्ग का एक उदाहरण बनाता है
  $pres = new Presentation();
  try {
    # इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करता है
    $slide = $pres->getSlides()->get_Item(0);
    # स्लाइड पर PercentsStackedColumn चार्ट बनाता है
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # NumberFormatLinkedToSource को false सेट करता है
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # चार्ट डेटा वर्कशीट प्राप्त करता है
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # नया सीरीज़ जोड़ता है
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # सीरीज़ का fill रंग सेट करता है
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # LabelFormat गुण सेट करता है
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # नया सीरीज़ जोड़ता है
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # Fill प्रकार और रंग सेट करता है
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # प्रस्तुति को डिस्क पर सहेजता है
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्ष से लेबल की दूरी सेट करें**
जब आप अक्षों से प्लॉट किए गए चार्ट के साथ काम कर रहे हों, तो यह PHP कोड आपको श्रेणी अक्ष से लेबल की दूरी कैसे सेट की जाए दिखाता है:

```php
  # Presentation वर्ग का एक उदाहरण बनाता है
  $pres = new Presentation();
  try {
    # स्लाइड का रेफ़रेंस प्राप्त करता है
    $sld = $pres->getSlides()->get_Item(0);
    # स्लाइड पर चार्ट बनाता है
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # अक्ष से लेबल की दूरी सेट करता है
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # प्रस्तुतीकरण को डिस्क पर सहेजता है
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **लेबल स्थान समायोजित करें**

जब आप ऐसी चार्ट बनाते हैं जो किसी भी अक्ष पर निर्भर नहीं करती, जैसे पाई चार्ट, तो चार्ट के डेटा लेबल किनारे के बहुत पास हो सकते हैं। ऐसे मामलों में आपको डेटा लेबल का स्थान समायोजित करना पड़ता है ताकि लीडर लाइन्स स्पष्ट रूप से दिखें।

यह PHP कोड आपको पाई चार्ट पर लेबल स्थान कैसे समायोजित किया जाता है दिखाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घने चार्ट्स में डेटा लेबल्स के ओवरलैप होने से कैसे रोक सकता हूँ?**

स्वतः लेबल प्लेसमेंट, लीडर लाइन्स, और छोटे फ़ॉन्ट आकार को संयोजित करें; यदि आवश्यक हो तो कुछ फ़ील्ड छिपाएँ (जैसे श्रेणी) या केवल अत्यधिक/मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**मैं शून्य, नकारात्मक, या खाली मानों के लिए लेबल केवल कैसे बंद कर सकता हूँ?**

लेबल सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और 0, नकारात्मक मानों या गायब मानों के लिए प्रदर्शित करना बंद करने का नियम लागू करें।

**PDF/इमेज में निर्यात करते समय मैं लेबल शैली को सुसंगत कैसे रख सकता हूँ?**

फ़ॉन्ट (परिवार, आकार) को स्पष्ट रूप से सेट करें और यह सुनिश्चित करें कि रेंडरिंग साइड पर फ़ॉन्ट उपलब्ध हो ताकि फ़ॉलबैक न हो।