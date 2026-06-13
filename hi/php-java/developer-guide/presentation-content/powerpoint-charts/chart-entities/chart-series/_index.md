---
title: PHP का उपयोग करके प्रस्तुतियों में चार्ट डेटा सीरीज़ प्रबंधित करें
linktitle: डेटा सीरीज़
type: docs
url: /hi/php-java/chart-series/
keywords:
- चार्ट सीरीज़
- सीरीज़ ओवरलैप
- सीरीज़ रंग
- श्रेणी रंग
- सीरीज़ नाम
- डेटा पॉइंट
- सीरीज़ गैप
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के साथ PowerPoint (PPT/PPTX) के लिए चार्ट डेटा सीरीज़ को प्रबंधित करने के तरीके सीखें, जिसमें व्यावहारिक कोड उदाहरण और सर्वोत्तम प्रथाएँ शामिल हैं, जो आपके डेटा प्रस्तुतियों को सुधारती हैं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में [ChartSeries](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/) की भूमिका का वर्णन करता है, जिसमें प्रस्तुतियों में डेटा कैसे संरचित और दृश्यीकृत किया जाता है, इस पर ध्यान केंद्रित किया गया है। ये ऑब्जेक्ट्स बुनियादी तत्व प्रदान करते हैं जो चार्ट में व्यक्तिगत डेटा पॉइंट्स, श्रेणियों और उपस्थिति पैरामीटर को परिभाषित करते हैं। [ChartSeries](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/) के साथ काम करके, डेवलपर्स अंतर्निहित डेटा स्रोतों को सहजता से एकीकृत कर सकते हैं और जानकारी के प्रदर्शन पर पूर्ण नियंत्रण रख सकते हैं, जिससे गतिशील, डेटा‑प्रेरित प्रस्तुतियाँ बनती हैं जो स्पष्ट रूप से अंतर्दृष्टि और विश्लेषण को संप्रेषित करती हैं।

एक सीरीज़ वह पंक्ति या कॉलम है जिसमें संख्याएँ चार्ट में प्लॉट की जाती हैं।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट सीरीज़ ओवरलैप सेट करें**

[getParentSeriesGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getParentSeriesGroup) मेथड का उपयोग करके, आप 2D चार्ट में बार और कॉलम के ओवरलैप की मात्रा निर्दिष्ट कर सकते हैं (रेंज: -100 से 100)। यह प्रॉपर्टी पैरेंट सीरीज़ ग्रुप की सभी सीरीज़ पर लागू होती है: यह उपयुक्त ग्रुप प्रॉपर्टी का प्रोजेक्शन है। इसलिए, यह प्रॉपर्टी केवल‑पढ़ने योग्य है।

`ChartSeriesGroup::setOverlap` मेथड का उपयोग करके `Overlap` का वांछित मान सेट करें।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड पर एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
1. पहली चार्ट सीरीज़ तक पहुँचें।
1. चार्ट सीरीज़ के `ParentSeriesGroup` तक पहुँचें और सीरीज़ के लिए वांछित ओवरलैप मान सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह PHP कोड दिखाता है कि चार्ट सीरीज़ के ओवरलैप को कैसे सेट किया जाए:

```php
  $pres = new Presentation();
  try {
    # चार्ट जोड़ता है
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # सीरीज़ ओवरलैप सेट करता है
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # प्रस्तुति फ़ाइल को डिस्क पर लिखता है
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **सीरीज़ का रंग बदलें**
Aspose.Slides for PHP via Java आपको इस तरह से सीरीज़ का रंग बदलने की अनुमति देता है:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. जिस सीरीज़ का रंग बदलना है, उसे एक्सेस करें।
1. अपनी इच्छित फ़िल टाइप और फ़िल रंग सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह PHP कोड दिखाता है कि सीरीज़ का रंग कैसे बदला जाए:

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **सीरीज़ श्रेणी का रंग बदलें**
Aspose.Slides for PHP via Java आपको इस तरह से सीरीज़ श्रेणी का रंग बदलने की अनुमति देता है:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. जिस सीरीज़ श्रेणी का रंग बदलना है, उसे एक्सेस करें।
1. अपनी इच्छित फ़िल टाइप और फ़िल रंग सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह कोड दिखाता है कि सीरीज़ श्रेणी का रंग कैसे बदला जाए:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **सीरीज़ का नाम बदलें** 

डिफ़ॉल्ट रूप से, चार्ट के लेजेंड नाम प्रत्येक कॉलम या पंक्ति के डेटा के ऊपर स्थित सेल की सामग्री होते हैं। 

हमारे उदाहरण (नमूना छवि) में,

* कॉलम हैं *Series 1, Series 2,* और *Series 3*;
* पंक्तियाँ हैं *Category 1, Category 2, Category 3,* और *Category 4*।

Aspose.Slides for PHP via Java आपको चार्ट डेटा और लेजेंड में सीरीज़ नाम को अपडेट या बदलने की अनुमति देता है।

यह PHP कोड दिखाता है कि `ChartDataWorkbook` में सीरीज़ का नाम कैसे बदला जाए:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

यह PHP कोड दिखाता है कि लेजेंड के माध्यम से `Series` के द्वारा सीरीज़ नाम कैसे बदला जाए:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चार्ट सीरीज़ फ़िल रंग सेट करें**

Aspose.Slides for PHP via Java आपको प्लॉट एरिया के भीतर चार्ट सीरीज़ के लिए स्वचालित फ़िल रंग इस तरह सेट करने देता है:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. अपनी इच्छित प्रकार (नीचे के उदाहरण में हमने `ChartType::ClusteredColumn` उपयोग किया) के आधार पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. चार्ट सीरीज़ तक पहुँचें और फ़िल रंग को Automatic पर सेट करें।
1. प्रस्तुति को PPTX फ़ाइल में सहेजें।

यह PHP कोड दिखाता है कि चार्ट सीरीज़ के लिए स्वचालित फ़िल रंग कैसे सेट किया जाए:

```php
  $pres = new Presentation();
  try {
    # एक क्लस्टर्ड कॉलम चार्ट बनाता है
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # सीरीज़ फ़िल फ़ॉर्मेट को स्वतः सेट करता है
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # प्रस्तुति फ़ाइल को डिस्क पर लिखता है
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चार्ट सीरीज़ के लिए इनवर्ट फ़िल रंग सेट करें**
Aspose.Slides आपको प्लॉट एरिया के भीतर चार्ट सीरीज़ के लिए इनवर्ट फ़िल रंग इस तरह सेट करने देता है:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. अपनी इच्छित प्रकार (नीचे के उदाहरण में हमने `ChartType::ClusteredColumn` उपयोग किया) के आधार पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. चार्ट सीरीज़ तक पहुँचें और फ़िल रंग को Invert पर सेट करें।
1. प्रस्तुति को PPTX फ़ाइल में सहेजें।

यह PHP कोड ऑपरेशन को दर्शाता है:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # नई सीरीज़ और श्रेणियाँ जोड़ता है
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # पहले चार्ट सीरीज़ को लेता है और उसकी सीरीज़ डेटा को भरता है।
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **मान नकारात्मक होने पर सीरीज़ को इनवर्ट सेट करें**
Aspose.Slides आपको `IChartDataPoint.InvertIfNegative` और `ChartDataPoint.InvertIfNegative` प्रॉपर्टी द्वारा इनवर्ट सेट करने देता है। जब इनवर्ट इन प्रॉपर्टी के माध्यम से सेट किया जाता है, तो डेटा पॉइंट नकारात्मक मान मिलने पर अपने रंगों को उलट देता है।

यह PHP कोड ऑपरेशन को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **विशिष्ट पॉइंट डेटा साफ़ करें**
Aspose.Slides for PHP via Java आपको किसी विशिष्ट चार्ट सीरीज़ के `DataPoints` डेटा को इस तरह साफ़ करने देता है:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. इंडेक्स द्वारा चार्ट का रेफ़रेंस प्राप्त करें.
4. सभी चार्ट `DataPoints` पर इटररेट करें और `XValue` और `YValue` को null सेट करें।
5. विशिष्ट चार्ट सीरीज़ के सभी `DataPoints` को साफ़ करें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह PHP कोड ऑपरेशन को दर्शाता है:

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **सीरीज़ गैप चौड़ाई सेट करें**
Aspose.Slides for PHP via Java आपको **`GapWidth`** प्रॉपर्टी के माध्यम से सीरीज़ की गैप चौड़ाई इस तरह सेट करने देता है:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. पहली स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. किसी भी चार्ट सीरीज़ तक पहुँचें।
1. `GapWidth` प्रॉपर्टी सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह कोड दिखाता है कि सीरीज़ की गैप चौड़ाई कैसे सेट की जाए:

```php
  # खाली प्रस्तुति बनाता है
  $pres = new Presentation();
  try {
    # प्रस्तुति की पहली स्लाइड तक पहुंचता है
    $slide = $pres->getSlides()->get_Item(0);
    # डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # चार्ट डेटा शीट का इंडेक्स सेट करता है
    $defaultWorksheetIndex = 0;
    # चार्ट डेटा वर्कशीट प्राप्त करता है
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # सीरीज़ जोड़ता है
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # श्रेणियाँ जोड़ता है
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # दूसरी चार्ट सीरीज़ लेता है
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # सीरीज़ डेटा को भरता है
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # GapWidth मान सेट करता है
    $series->getParentSeriesGroup()->setGapWidth(50);
    # प्रस्तुति को डिस्क पर सहेजता है
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एकल चार्ट में शामिल की जा सकने वाली सीरीज़ की संख्या पर कोई सीमा है?**

Aspose.Slides द्वारा सीरीज़ की संख्या पर कोई निश्चित सीमा नहीं रखी गई है। व्यावहारिक सीमा चार्ट की पठनीयता और आपके एप्लिकेशन में उपलब्ध मेमोरी द्वारा निर्धारित होती है।

**यदि क्लस्टर के भीतर कॉलम बहुत करीब या बहुत दूर हों तो क्या करें?**

उस सीरीज़ (या उसके पैरेंट सीरीज़ ग्रुप) के लिए `GapWidth` सेटिंग को समायोजित करें। मान बढ़ाने से कॉलम के बीच की दूरी बढ़ती है, जबकि घटाने से वे करीब आ जाते हैं।