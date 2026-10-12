---
title: "PHP का उपयोग करके प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें"
linktitle: "डेटा लेबल"
type: docs
url: /hi/php-java/chart-data-label/
keywords:
- "चार्ट"
- "डेटा लेबल"
- "डेटा सटीकता"
- "प्रतिशत"
- "लेबल दूरी"
- "लेबल स्थान"
- "PowerPoint"
- "प्रेज़ेंटेशन"
- "PHP"
- "Aspose.Slides"
description: "PowerPoint प्रस्तुतियों में Aspose.Slides for PHP via Java का उपयोग करके चार्ट डेटा लेबल जोड़ने और स्वरूपित करने के बारे में जानें, जिससे अधिक आकर्षक स्लाइड बनाए जा सकें."
---
## **परिचय**

डेटा लेबल चार्ट सीरीज़ और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मानों की पहचान करने और चार्ट को समझने में मदद मिलती है। यह लेख बताता है कि मानों को कैसे स्वरूपित किया जाए, प्रतिशत कैसे प्रदर्शित किए जाएँ, लेबल टेक्स्ट को कैसे पढ़ा जाए, अक्ष अधिकतम सीमा से परे लेबलों को कैसे नियंत्रित किया जाए, श्रेणी अक्ष लेबल स्पेसिंग को कैसे समायोजित किया जाए, और पाई चार्ट लेबलों को कैसे स्थित किया जाए।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करना**

श्रृंखला मानों को स्वरूपित करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसकी डेटा तालिका दर्शाता है, और पहली श्रृंखला के लिए मान लेबल सक्षम करता है। फॉर्मेट `#,##0.00` हज़ार विभाजक और दो दशमलव स्थान दर्शाता है, बिना मूल मानों को बदले।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->setNumberFormatOfValues("#,##0.00");
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **लेबल के रूप में प्रतिशत दिखाना**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट को उस टेक्स्ट फ्रेम में असाइन करें जो [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) द्वारा लौटाया गया है। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8‑पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य द्वारा विभाजन से बचने के लिए छोड़ दिया जाता है। चार्ट डेटा बदलने पर कस्टम लेबल टेक्स्ट को फिर से गणना करें।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\Portion;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);

    $categoryCount = java_values($chart->getChartData()->getCategories()->size());
    $categoryTotals = array_fill(0, $categoryCount, 0.0);
    for ($k = 0; $k < $categoryCount; $k++) {
        for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
            $series = $chart->getChartData()->getSeries()->get_Item($i);
            $pointValue = java_values($series->getDataPoints()->get_Item($k)->getValue()->getData());
            $categoryTotals[$k] += $pointValue;
        }
    }

    for ($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()); $x++) {
        $series = $chart->getChartData()->getSeries()->get_Item($x);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);

        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $label = $series->getDataPoints()->get_Item($j)->getLabel();
            if ($categoryTotals[$j] == 0) {
                continue;
            }

            $pointValue = java_values($series->getDataPoints()->get_Item($j)->getValue()->getData());
            $dataPointPercent = ($pointValue / $categoryTotals[$j]) * 100;

            $portion = new Portion();
            $portion->setText(sprintf("%.2F %%", $dataPointPercent));
            $portion->getPortionFormat()->setFontHeight(8);

            $label->getTextFrameForOverriding()->setText("");
            $paragraph = $label->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
            $paragraph->getPortions()->add($portion);

            $label->getDataLabelFormat()->setShowValue(true);
            $label->getDataLabelFormat()->setShowSeriesName(false);
            $label->getDataLabelFormat()->setShowPercentage(false);
            $label->getDataLabelFormat()->setShowLegendKey(false);
            $label->getDataLabelFormat()->setShowCategoryName(false);
            $label->getDataLabelFormat()->setShowBubbleSize(false);
        }
    }

    $presentation->save("DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **चार्ट डेटा लेबल के साथ प्रतिशत चिह्न सेट करना**

यदि मान भिन्न के रूप में संग्रहीत हैं, तो प्रतिशत दिखाने के लिए [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setNumberFormat) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) को `false` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीली श्रृंखला के साथ 100 % स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान की जोड़ी का योग 1 है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0 % के रूप में दिखाता है, जबकि लम्बवत अक्ष दो दशमलव स्थान का उपयोग करता है। दोनों श्रृंखला सफ़ेद, 10‑पॉइंट लेबल टेक्स्ट उपयोग करती हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    for ($i = 0; $i < 4; $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    $colors = java("java.awt.Color");
    $seriesNames = [ "Reds", "Blues" ];
    $seriesColors = [ $colors->RED, $colors->BLUE ];
    $values = [ [ 0.30, 0.50, 0.80, 0.65 ], [ 0.70, 0.50, 0.20, 0.35 ] ];

    for ($i = 0; $i < count($seriesNames); $i++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $i + 1, $seriesNames[$i]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());
        for ($j = 0; $j < 4; $j++) {
            $valueCell = $workbook->getCell($worksheetIndex, $j + 1, $i + 1, $values[$i][$j]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $series->getFormat()->getFill()->setFillType(FillType::Solid);
        $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColors[$i]);

        $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(false);
        $labelFormat->setNumberFormat("0.0%");
        $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(10);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($colors->WHITE);
    }

    $presentation->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **डेटा लेबल के वास्तविक टेक्स्ट को पढ़ना**

[getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getActualLabelText) का उपयोग करके डेटा लेबल सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करें। यह रिपोर्ट के लिए लेबल्स निकालने, प्रस्तुति सामग्री खोजने, या उत्पन्न चार्ट की पुष्टि करने के समय उपयोगी है। नीचे दिया गया उदाहरण दिखाता है कि डिफ़ॉल्ट [डेटा लेबल फ़ॉर्मेट](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) प्रत्येक श्रेणी नाम, श्रृंखला नाम, और मान को मिलाता है। एक बिंदु अपना मान प्रतिशत के रूप में स्वरूपित करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) से कस्टम टेक्स्ट का उपयोग करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $firstCategoryCell = $workbook->getCell(0, 1, 0, "Q1");
    $chart->getChartData()->getCategories()->add($firstCategoryCell);
    $secondCategoryCell = $workbook->getCell(0, 2, 0, "Q2");
    $chart->getChartData()->getCategories()->add($secondCategoryCell);

    $northSeriesCell = $workbook->getCell(0, 0, 1, "North");
    $north = $chart->getChartData()->getSeries()->add($northSeriesCell, $chart->getType());
    $northFirstValueCell = $workbook->getCell(0, 1, 1, 0.25);
    $north->getDataPoints()->addDataPointForBarSeries($northFirstValueCell);
    $northSecondValueCell = $workbook->getCell(0, 2, 1, 0.75);
    $north->getDataPoints()->addDataPointForBarSeries($northSecondValueCell);

    $southSeriesCell = $workbook->getCell(0, 0, 2, "South");
    $south = $chart->getChartData()->getSeries()->add($southSeriesCell, $chart->getType());
    $southFirstValueCell = $workbook->getCell(0, 1, 2, 0.40);
    $south->getDataPoints()->addDataPointForBarSeries($southFirstValueCell);
    $southSecondValueCell = $workbook->getCell(0, 2, 2, 0.60);
    $south->getDataPoints()->addDataPointForBarSeries($southSecondValueCell);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        $format = $series->getLabels()->getDefaultDataLabelFormat();
        $format->setShowCategoryName(true);
        $format->setShowSeriesName(true);
        $format->setShowValue(true);
    }

    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormat("0%");
    $south->getLabels()->get_Item(0)->getTextFrameForOverriding()->setText("Reviewed");

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $point = $series->getDataPoints()->get_Item($j);
            $label = $point->getLabel();
            if (!java_values($label->isVisible())) {
                continue;
            }

            echo "Value: " . java_values($point->getValue()->getData()) . "; label: " . java_values($label->getActualLabelText()) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

डेटा बिंदु में संग्रहित संख्या `0.75` बनी रहती है, भले ही उसका लेबल `75 %` दिखाए और श्रेणी तथा श्रृंखला नाम भी शामिल हों। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। दोनों मामलों में [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getActualLabelText) परिणामस्वरूप लेबल स्ट्रिंग लौटाता है। जैसा कि ऊपर दिखाया गया है, केवल दृश्यमान लेबल निकालने के लिए अलग से [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#isVisible) की जाँच करें।

## **अक्ष अधिकतम सीमा से परे डेटा लेबल नियंत्रित करना**

जब आप मैन्युअल रूप से अक्ष रेंज सीमित करते हैं, तो कुछ डेटा बिंदु अधिकतम से अधिक हो सकते हैं। यह निर्धारित करने के लिए कि उनके डेटा लेबल दिखाए जाएँ या नहीं, [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) का उपयोग करें। यह सेटिंग लेबल की दृश्यता को बदलती है; यह अक्ष रेंज या मूल डेटा मानों को नहीं बदलती।

निचले उदाहरण में 60 और 120 मानों के साथ 2D क्लस्टर्ड कॉलम चार्ट बनाया गया है। यह लम्बवत अक्ष पर `false` को [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setAutomaticMaxValue) को पास करता है और [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setMaxValue) के साथ अधिकतम 100 सेट करता है। पहली स्लाइड अधिकतम से परे लेबलों को अनुमति देती है; उसकी कॉपी इन लेबलों को निष्क्रिय करती है। दोनों स्लाइड्स `DataLabelsOverMaximum.pptx` में सेव की जाती हैं।

[setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) के साथ मान लेबल सक्षम करें। चार्ट‑स्तरीय सेटिंग स्वयं मान प्रदर्शन को सक्रिय नहीं करती और न ही व्यक्तिगत लेबल के निष्क्रिय मान प्रदर्शन को ओवरराइड करती है। यह उदाहरण पूरे श्रृंखला के लिए मान सक्षम करता है और [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setPosition) का उपयोग करके प्रत्येक कॉलम के बाहर के अंत में लेबल रखता है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $firstCategory = $workbook->getCell(0, 1, 0, "Within range");
    $secondCategory = $workbook->getCell(0, 2, 0, "Above maximum");

    $chart->getChartData()->getCategories()->add($firstCategory);
    $chart->getChartData()->getCategories()->add($secondCategory);

    $seriesName = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());

    $firstValue = $workbook->getCell(0, 1, 1, 60);
    $secondValue = $workbook->getCell(0, 2, 1, 120);

    $series->getDataPoints()->addDataPointForBarSeries($firstValue);
    $series->getDataPoints()->addDataPointForBarSeries($secondValue);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(100);
    $chart->setShowDataLabelsOverMaximum(true);

    $secondSlide = $presentation->getSlides()->addClone($slide);
    $secondChart = $secondSlide->getShapes()->get_Item(0);
    $secondChart->setShowDataLabelsOverMaximum(false);

    $presentation->save("DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

निम्न छवियाँ Microsoft PowerPoint द्वारा रेंडर की गई सेव्ड स्लाइड्स दर्शाती हैं। `true` के साथ लेबल **120** ऊपरी सीमा पर दिखाई देता है; `false` के साथ यह छिपा रहता है। लेबल **60** दृश्यमान रहता है, अक्ष अधिकतम **100** बना रहता है, और दूसरा डेटा बिंदु दोनों मामलों में **120** रहता है।

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![अक्ष अधिकतम 100 के साथ मूल्य लेबल 120 दिखाने वाला PowerPoint चार्ट](data-labels-over-maximum-true.png) | ![अक्ष अधिकतम 100 के साथ मूल्य लेबल 120 छुपाने वाला PowerPoint चार्ट](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण मूल्य अक्ष के साथ 2D कॉलम चार्ट उपयोग करता है। मूल्य अक्ष के बिना चार्ट, जैसे पाई और डोनट चार्ट, इस तरह के अक्ष अधिकतम सीमा सीमांकन नहीं रखते हैं।
{{% /alert %}}

## **अक्ष से लेबल की दूरी सेट करना**

[setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setLabelOffset) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच की दूरी नियंत्रित करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत है। यह उदाहरण क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 पर सेट करता है। यह सेटिंग श्रेणी अक्ष लेबल को प्रभावित करती है, न कि व्यक्तिगत डेटा बिंदु से जुड़े लेबल को।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $chart->getAxes()->getHorizontalAxis()->setLabelOffset(500);

    $presentation->save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **लेबल स्थान को समायोजित करना**

पाई चार्ट पर, डेटा लेबल स्थितियों को समायोजित करके स्पेसिंग सुधारें और लीडर लाइन के लिए जगह बनाएं।

यह उदाहरण पहले डेटा बिंदु का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setX) और [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setY) का उपयोग करके क्षैतिज तथा लम्बवत ऑफ़सेट समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();

    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![समायोजित डेटा लेबल स्थिति वाला पाई चार्ट](pie-chart-adjusted-label.png)

## **कॉलम चार्ट के ऊपर कई पंक्तियों के डेटा लेबल जोड़ना**

यह उदाहरण प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल वाले कॉलम चार्ट को बनाता है। श्रृंखला A दृश्यमान कॉलम दिखाती है, जबकि श्रृंखला B और श्रृंखला C अतिरिक्त लेबल प्रदान करती हैं। उनके कॉलम को फ़िल और आउटलाइन हटाकर छुपा दिया जाता है। [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap) मेथड सभी तीन श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करता है।

[ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) सेटिंग्स लेबल पंक्तियों के लिए स्थान आरक्षित करती हैं। [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#validateChartLayout) डिफ़ॉल्ट स्थितियों की गणना करने के बाद, [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setX) और [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setY) क्षैतिज संरेखण बनाए रखते हैं और दो पंक्तियों में लेबल व्यवस्थित करने के लिए लम्बवत ऑफ़सेट लागू करते हैं। संख्याएँ श्रृंखला मानों से जुड़ी डेटा लेबल ही रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट शैप होते हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\LayoutTargetType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$colors = java("java.awt.Color");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 40, 40, 640, 200);
    $chart->setTitle(false);
    $chart->setLegend(false);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categories = [ "North", "South", "East", "West" ];
    $seriesNames = [ "Series A", "Series B", "Series C" ];
    $seriesValues = [
        [ 35, 42, 28, 47 ],
        [ 22, 31, 19, 26 ],
        [ 12, 16, 14, 18 ]
    ];
    
    for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
        $categoryCell = $workbook->getCell(0, $categoryIndex + 1, 0, $categories[$categoryIndex]);
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $seriesCell = $workbook->getCell(0, 0, $seriesIndex + 1, $seriesNames[$seriesIndex]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, ChartType::ClusteredColumn);

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $valueCell = $workbook->getCell(0, $categoryIndex + 1, $seriesIndex + 1, $seriesValues[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        if ($seriesIndex > 0) {
            // B और C की कॉलम छुपाएँ, लेकिन उनके डेटा लेबल रखें।
            $series->getFormat()->getFill()->setFillType(FillType::NoFill);
            $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
            $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
            $labelFormat->setShowValue(true);
            $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(12);
            $labelFill = $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
            $labelFill->setFillType(FillType::Solid);
            $labelFill->getSolidFillColor()->setColor($colors->BLACK);
            $labelFormat->setPosition(LegendDataLabelPosition::InsideBase);
        }
    }

    // सभी तीन श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करें।
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // इस कॉम्पैक्ट उदाहरण के लिए कम ग्रिडलाइन उपयोग करें।
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // डेटा लेबल की दो पंक्तियों के लिए प्लॉट के ऊपर स्थान आरक्षित करें।
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $chart->getPlotArea()->setX(0.15);
    $chart->getPlotArea()->setY(0.32);
    $chart->getPlotArea()->setWidth(0.80);
    $chart->getPlotArea()->setHeight(0.48);
    $chart->validateChartLayout();

    $chartX = java_values($chart->getX());
    $chartY = java_values($chart->getY());
    $chartHeight = java_values($chart->getHeight());
    for ($seriesIndex = 1; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $rowTop = $seriesIndex == 1 ? 0.15 : 0.03;

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $dataLabel = $series->getDataPoints()->get_Item($categoryIndex)->getLabel();
            // डिफ़ॉल्ट क्षैतिज स्थिति रखें। Y एक ऑफ़सेट है
            // डिफ़ॉल्ट लेबल स्थिति से, जिसे चार्ट‑ऊँचाई के अंश के रूप में व्यक्त किया गया है।
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // केवल पंक्ति शीर्षक एक अलग टेक्स्ट शैप है।
        $rowHeading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $chartX, $chartY + $rowTop * $chartHeight, 85, 18);
        $rowHeading->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->addTextFrame($seriesNames[$seriesIndex]);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginTop(0);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginBottom(0);
        $headingFormat = $rowHeading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $headingFormat->setFontHeight(12);
        $headingFormat->getFillFormat()->setFillType(FillType::Solid);
        $headingFormat->getFillFormat()->getSolidFillColor()->setColor($colors->BLACK);
    }

    $presentation->save("multiple-rows-of-labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल वाला कॉलम चार्ट](multiple-rows-of-labels.png)


## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घनी चार्ट में डेटा लेबल के ओवरलैप को कैसे रोकूँ?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइन्स और छोटे फ़ॉन्ट आकार को मिलाकर उपयोग करें; यदि आवश्यक हो तो कुछ फ़ील्ड (जैसे श्रेणी) को छुपाएँ या केवल चरम मानों या मुख्य बिंदुओं के लिए लेबल प्रदर्शित करें।

**मैं शून्य, नकारात्मक या खाली मानों के लिए केवल लेबल कैसे निष्क्रिय करूँ?**

लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और 0, नकारात्मक या अनुपलब्ध मानों के लिए प्रदर्शन बंद करें, जैसा कि एक निर्धारित नियम में परिभाषित किया गया हो।

**PDF/इमेज में निर्यात करते समय लेबल शैली को सुसंगत कैसे रखें?**

फ़ॉन्ट परिवार और आकार को स्पष्ट रूप से सेट करें और रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध हो, इस बात की पुष्टि करें ताकि फ़ॉलबैक से बचा जा सके।