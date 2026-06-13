---
title: PHP का उपयोग करके प्रस्तुतियों में पाई चार्ट को अनुकूलित करें
linktitle: पाई चार्ट
type: docs
url: /hi/php-java/pie-chart/
keywords:
- पाई चार्ट
- चार्ट प्रबंधन
- चार्ट अनुकूलन
- चार्ट विकल्प
- चार्ट सेटिंग्स
- प्लॉट विकल्प
- स्लाइस रंग
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके पाई चार्ट बनाना और अनुकूलित करना सीखें, जिसे PowerPoint में निर्यात किया जा सकता है, और कुछ ही सेकंड में आपके डेटा कहानी कहने को बढ़ावा देता है।"
---
## **सारांश**

यह लेख Aspose.Slides में पाई चार्ट के साथ काम करने के तरीके को समझाता है। यह Pie of Pie और Bar of Pie चार्ट के लिए द्वितीय प्लॉट विकल्पों को कॉन्फ़िगर करने तथा मानक पाई चार्ट के लिए स्वचालित स्लाइस रंग सक्षम करने का प्रदर्शन करता है।

उदाहरण व्यावहारिक चार्ट अनुकूलन चरणों पर केंद्रित हैं जैसे स्लाइड में चार्ट जोड़ना, श्रृंखला और लेबल सेटिंग्स समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, और अद्यतन प्रस्तुति को सहेजना।

## **Pie of Pie और Bar of Pie चार्ट के लिए द्वितीय प्लॉट विकल्प**
Aspose.Slides for PHP via Java अब Pie of Pie या Bar of Pie चार्ट के लिए द्वितीय प्लॉट विकल्पों को समर्थन देता है। इस विषय में हम दिखाएँगे कि Aspose.Slides का उपयोग करके इन विकल्पों को कैसे निर्दिष्ट किया जाए। गुणों को निर्दिष्ट करने के लिए निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास ऑब्जेक्ट बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट के द्वितीय प्लॉट विकल्प निर्दिष्ट करें।
1. प्रस्तुति को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में हमने Pie of Pie चार्ट की विभिन्न गुणों को सेट किया है।

```php
  # Presentation क्लास का एक इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    # स्लाइड पर चार्ट जोड़ें
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # विभिन्न गुण सेट करें
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # प्रस्तुति को डिस्क पर लिखें
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **स्वचालित पाई चार्ट स्लाइस रंग सेट करें**
Aspose.Slides for PHP via Java स्वचालित पाई चार्ट स्लाइस रंग सेट करने के लिए एक सरल API प्रदान करता है। नमूना कोड ऊपर बताए गए गुणों को लागू करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
1. पहली स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. चार्ट शीर्षक सेट करें।
1. पहली श्रृंखला को मान दिखाने के लिए सेट करें।
1. चार्ट डेटा शीट का इंडेक्स सेट करें।
1. चार्ट डेटा कार्यपत्रक प्राप्त करें।
1. डिफ़ॉल्ट उत्पन्न श्रृंखलाओं और श्रेणियों को हटाएँ।
1. नई श्रेणियां जोड़ें।
1. नई श्रृंखला जोड़ें।

संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```php
  # Presentation क्लास का एक इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    # डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # चार्ट शीर्षक सेट करना
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # पहली श्रृंखला को मान दिखाने के लिए सेट करें
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # चार्ट डेटा शीट का इंडेक्स सेट करना
    $defaultWorksheetIndex = 0;
    # चार्ट डेटा कार्यपत्रक प्राप्त करना
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # डिफ़ॉल्ट उत्पन्न श्रृंखलाएं और श्रेणियां हटाएं
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # नई श्रेणियां जोड़ना
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # नई श्रृंखला जोड़ना
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # अब श्रृंखला डेटा भरना
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**क्या 'Pie of Pie' और 'Bar of Pie' वैरिएंट्स समर्थित हैं?**

हाँ, लाइब्रेरी एक द्वितीय प्लॉट को [समर्थित](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/) करती है, जिसमें 'Pie of Pie' और 'Bar of Pie' प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को छवि (उदाहरण के लिए, PNG) के रूप में निर्यात कर सकता हूँ?**

हाँ, आप पूरी प्रस्तुति के बिना केवल चार्ट को छवि के रूप में [निर्यात](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage) कर सकते हैं (जैसे PNG)।