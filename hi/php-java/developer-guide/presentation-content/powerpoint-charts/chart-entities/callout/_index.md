---
title: PHP का उपयोग करके प्रस्तुति चार्ट में कॉलआउट्स प्रबंधित करें
linktitle: कॉलआउट
type: docs
url: /hi/php-java/callout/
keywords:
- चार्ट कॉलआउट
- कॉलआउट का उपयोग
- डेटा लेबल
- लेबल फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में संक्षिप्त कोड उदाहरणों के साथ कॉलआउट्स बनाएं और शैलीबद्ध करें, PPT और PPTX के साथ संगत, ताकि प्रस्तुति वर्कफ़्लो को स्वचालित किया जा सके।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट डेटा लेबल के लिए कॉलआउट्स के साथ काम करने की विधि समझाता है। यह दिखाता है कि लेबल को कॉलआउट के रूप में प्रदर्शित करने के लिए `setShowLabelAsDataCallout` मेथड का उपयोग कैसे किया जाए, डोनट चार्ट के लिए कॉलआउट‑संबंधित लेबल सेटिंग्स को कैसे कॉन्फ़िगर किया जाए, और यह उल्लेख करता है कि प्रस्तुति को PDF, HTML5, SVG और रास्टर इमेज फ़ॉर्मेट्स में निर्यात करने पर कॉलआउट्स और उनकी उपस्थिति संरक्षित रहती है।

## **कॉलआउट्स का उपयोग**
नए मेथड्स [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) और [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/) को [DataLabelFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat) क्लास में जोड़ा गया है। ये मेथड्स निर्धारित करते हैं कि निर्दिष्ट चार्ट का डेटा लेबल डेटा कॉलआउट के रूप में या डेटा लेबल के रूप में प्रदर्शित होगा।

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 500, 400);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowLabelAsDataCallout(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->get_Item(2)->getDataLabelFormat()->setShowLabelAsDataCallout(false);
    $pres->save("DisplayCharts.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **डोनट चार्ट के लिए कॉलआउट सेट करना**
Aspose.Slides for PHP via Java डोनट चार्ट के लिए सीरीज़ डेटा लेबल कॉलआउट आकार को सेट करने का समर्थन प्रदान करता है। नीचे एक नमूना उदाहरण दिया गया है।

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Doughnut, 10, 10, 500, 500, false);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(false);
    $seriesIndex = 0;
    while ($seriesIndex < 15) {
      $series = $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, $seriesIndex + 1, "SERIES " . $seriesIndex), $chart->getType());
      $series->setExplosion(0);
      $series->getParentSeriesGroup()->setDoughnutHoleSize(20);
      $series->getParentSeriesGroup()->setFirstSliceAngle(351);
      $seriesIndex++;
    } 
    $categoryIndex = 0;
    while ($categoryIndex < 15) {
      $chart->getChartData()->getCategories()->add($workBook->getCell(0, $categoryIndex + 1, 0, "CATEGORY " . $categoryIndex));
      $i = 0;
      while ($i < java_values($chart->getChartData()->getSeries()->size())) {
        $iCS = $chart->getChartData()->getSeries()->get_Item($i);
        $dataPoint = $iCS->getDataPoints()->addDataPointForDoughnutSeries($workBook->getCell(0, $categoryIndex + 1, $i + 1, 1));
        $dataPoint->getFormat()->getFill()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
        $dataPoint->getFormat()->getLine()->setWidth(1);
        $dataPoint->getFormat()->getLine()->setStyle(LineStyle->Single);
        $dataPoint->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
        if ($i == java_values($chart->getChartData()->getSeries()->size()) - 1) {
          $lbl = $dataPoint->getLabel();
          $lbl->getTextFormat()->getTextBlockFormat()->setAutofitType(TextAutofitType::Shape);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setLatinFont(new FontData("DINPro-Bold"));
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(12);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
          $lbl->getDataLabelFormat()->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
          $lbl->getDataLabelFormat()->setShowValue(false);
          $lbl->getDataLabelFormat()->setShowCategoryName(true);
          $lbl->getDataLabelFormat()->setShowSeriesName(false);
          $lbl->getDataLabelFormat()->setShowLeaderLines(true);
          $lbl->getDataLabelFormat()->setShowLabelAsDataCallout(false);
          $chart->validateChartLayout();
          $lbl->setX($lbl->getX() + 0.5);
          $lbl->setY($lbl->getY() + 0.5);
        }
        $i++;
      } 
      $categoryIndex++;
    } 
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या प्रस्तुति को PDF, HTML5, SVG या इमेज में बदलते समय कॉलआउट्स संरक्षित रहते हैं?**

हाँ। कॉलआउट्स चार्ट रेंडरिंग का हिस्सा हैं, इसलिए जब आप इसे [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/hi/php-java/export-to-html5/), [SVG](/slides/hi/php-java/render-a-slide-as-an-svg-image/) या [raster images](/slides/hi/php-java/convert-powerpoint-to-png/) में निर्यात करते हैं, तो वे स्लाइड के फॉर्मेटिंग के साथ ही संरक्षित रहते हैं।

**क्या कस्टम फ़ॉन्ट्स कॉलआउट्स में काम करते हैं, और क्या उनका स्वरूप निर्यात पर संरक्षित रहता है?**

हाँ। Aspose.Slides प्रस्तुति में [फ़ॉन्ट एम्बेडिंग](/slides/hi/php-java/embedded-font/) का समर्थन करता है और निर्यात जैसे [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/) के दौरान फ़ॉन्ट एम्बेडिंग को नियंत्रित करता है, जिससे कॉलआउट्स विभिन्न सिस्टमों में समान दिखते हैं।