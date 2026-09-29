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
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "PowerPoint प्रस्तुतियों में Aspose.Slides for PHP (Java के माध्यम से) का उपयोग करके चार्ट डेटा लेबल जोड़ने और स्वरूपित करने के तरीके सीखें, जिससे अधिक आकर्षक स्लाइड बनें।"
---
## **परिचय**

डेटा लेबल चार्ट सीरीज़ और व्यक्तिगत डेटा पॉइंट्स के बारे में जानकारी प्रदर्शित करते हैं, जो पाठकों को मानों की पहचान करने और चार्ट को समझने में मदद करते हैं। यह लेख मूल्य स्वरूपित करने, प्रतिशत प्रदर्शित करने, लेबल पाठ पढ़ने, अक्ष अधिकतम से परे लेबल नियंत्रित करने, श्रेणी अक्ष लेबल स्पेसिंग समायोजित करने, और पाई चार्ट लेबल की स्थिति निर्धारित करने के तरीकों को समझाता है।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करें**

सीरीज़ मानों को स्वरूपित करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसकी डेटा तालिका दिखाता है, और पहली सीरीज़ के लिए मान लेबल सक्षम करता है। फॉर्मेट `#,##0.00` हजारों विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

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

## **लेबल के रूप में प्रतिशत प्रदर्शित करें**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और उसे टेक्स्ट फ्रेम में असाइन करें जो [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) द्वारा लौटाया जाता है। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8‑पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल पाठ को पुनः गणना करें।

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

## **चार्ट डेटा लेबल के साथ प्रतिशत संकेत सेट करें**

जब मान भिन्न के रूप में संग्रहीत होते हैं, तो प्रतिशत प्रदर्शित करने के लिए [setNumberFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/#setNumberFormat) का उपयोग करें। लेबल फॉर्मेट को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) को `false` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीली सीरीज़ के साथ 100 % स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान जोड़ी का योग 1 होता है। लेबल फॉर्मेट `0.0%` 0.30 को 30.0 % के रूप में दिखाता है, जबकि लंबवत अक्ष दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ सफ़ेद, 10‑पॉइंट लेबल टेक्स्ट उपयोग करती हैं।

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

## **डेटा लेबल के वास्तविक टेक्स्ट को पढ़ें**

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट को प्राप्त करने के लिए [getActualLabelText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#getActualLabelText) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकाले, प्रस्तुति सामग्री खोजे, या जेनरेटेड चार्ट वेलिडेट करने में उपयोगी है। नीचे के उदाहरण में, डिफ़ॉल्ट [डेटा लेबल फॉर्मेट](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम, और मान को मिलाता है। एक पॉइंट अपना मान प्रतिशत के रूप में फॉर्मेट करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा पॉइंट में संग्रहीत संख्या `0.75` रहती है, भले ही उसका लेबल `75%` दिखाए साथ में श्रेणी और सीरीज़ नाम। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [getActualLabelText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#getActualLabelText) दोनों स्थितियों में परिणामी लेबल स्ट्रिंग लौटाता है। यदि आप केवल दृश्यमान लेबल निकालना चाहते हैं तो उपरोक्त दिखाए अनुसार अलग से [isVisible](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#isVisible) जाँचें।

## **अक्ष अधिकतम से परे डेटा लेबल नियंत्रित करें**

जब आप मैन्युअली अक्ष रेंज सीमित करते हैं, तो कुछ डेटा पॉइंट्स उसका अधिकतम पार कर सकते हैं। यह नियंत्रित करने के लिए कि उनका डेटा लेबल दिखे या नहीं, [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) का उपयोग करें। यह सेटिंग लेबल की दृश्यता बदलती है; यह अक्ष रेंज या अंतर्निहित डेटा मानों को नहीं बदलती।

नीचे का उदाहरण 60 और 120 मूल्यों के साथ 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह [setAutomaticMaxValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/#setAutomaticMaxValue) को `false` पास करता है और लंबवत अक्ष पर [setMaxValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/#setMaxValue) से अधिकतम को 100 सेट करता है। पहली स्लाइड अधिकतम से परे लेबल की अनुमति देती है; उस स्लाइड की एक प्रति उन्हें अक्षम करती है। दोनों स्लाइड्स `DataLabelsOverMaximum.pptx` में सहेजी जाती हैं।

[setShowValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/#setShowValue) से मान लेबल सक्षम करें। चार्ट‑स्तर की सेटिंग स्वयं मान प्रदर्शन को सक्षम नहीं करती या किसी व्यक्तिगत लेबल के अक्षम मान प्रदर्शन को ओवरराइड नहीं करती। यह उदाहरण पूरी सीरीज़ के लिए मान सक्षम करता है और [setPosition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/#setPosition) का उपयोग करके प्रत्येक कॉलम के बाहरी छोर पर लेबल रखता है।

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

निम्नलिखित चित्र Microsoft PowerPoint द्वारा रेंडर किए गए सहेजे गए स्लाइड्स दिखाते हैं। `true` के साथ, लेबल **120** ऊपरी सीमा पर दृश्य है; `false` के साथ, यह छिपा रहता है। लेबल **60** दृश्य बना रहता है, अक्ष अधिकतम **100** पर रहता है, और दूसरा डेटा पॉइंट दोनों मामलों में **120** रहता है।

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint चार्ट जो मान लेबल 120 दिखा रहा है, अक्ष अधिकतम 100 के साथ](data-labels-over-maximum-true.png) | ![PowerPoint चार्ट जो मान लेबल 120 को छिपा रहा है, अक्ष अधिकतम 100 के साथ](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण मान अक्ष के साथ 2D कॉलम चार्ट उपयोग करता है। मान अक्ष के बिना चार्ट, जैसे पाई और डोनट चार्ट, इस प्रकार के अक्ष अधिकतम को सीमित नहीं कर सकते।
{{% /alert %}}

## **अक्ष से लेबल दूरी सेट करें**

[setLabelOffset](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/#setLabelOffset) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच दूरी नियंत्रित करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार के प्रतिशत के रूप में है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा पॉइंट्स से जुड़े लेबल के बजाय श्रेणी अक्ष लेबल को प्रभावित करती है।

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

## **लेबल स्थान समायोजित करें**

पाई चार्ट पर, डेटा लेबल की स्थितियों को समायोजित करें ताकि स्पेसिंग बेहतर हो और लीडर लाइनों के लिए जगह बन सके।

यह उदाहरण पहले डेटा पॉइंट का मान दर्शाता है, उसका लेबल स्लाइस के बाहर रखता है, और क्षैतिज तथा ऊर्ध्वाधर ऑफ़सेट को [setX](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#setX) और [setY](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#setY) का उपयोग करके समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष हैं।

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

![समायोजित डेटा लेबल स्थिति के साथ पाई चार्ट](pie-chart-adjusted-label.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**सघन चार्ट पर डेटा लेबल के ओवरलैप को कैसे रोकें?**  
स्वचालित लेबल प्लेसमेंट, लीडर लाइनों, और फ़ॉन्ट आकार घटाकर संयोजन करें; यदि आवश्यक हो तो कुछ फ़ील्ड (जैसे श्रेणी) को छिपाएँ या केवल चरम मानों या मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**केवल शून्य, नकारात्मक या खाली मानों के लिए लेबल कैसे अक्षम करें?**  
लेबल सक्षम करने से पहले डेटा पॉइंट को फ़िल्टर करें और 0, नकारात्मक मान या अनुपलब्ध मानों के लिए डिस्प्ले बंद करें, एक परिभाषित नियम के अनुसार।

**PDF/इमेज में निर्यात करते समय एकसमान लेबल शैली कैसे सुनिश्चित करें?**  
फ़ॉन्ट फ़ैमिली और आकार स्पष्ट रूप से सेट करें और रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध है यह सत्यापित करें ताकि फ़ॉलबैक से बचा जा सके।