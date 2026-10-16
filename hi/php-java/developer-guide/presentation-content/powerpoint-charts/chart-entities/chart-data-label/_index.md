---
title: PHP का उपयोग करके प्रस्तुतियों में चार्ट डेटा लेबल्स प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/php-java/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा शुद्धता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और स्वरूपित करने के बारे में जानें, जिससे अधिक आकर्षक स्लाइड्स बनें।"
---
## **परिचय**

डेटा लेबल चार्ट श्रृंखलाओं और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठक मानों की पहचान कर सकते हैं और चार्ट को समझ सकते हैं। यह लेख मानों को स्वरूपित करने, प्रतिशत प्रदर्शित करने, लेबल पाठ पढ़ने, अक्ष अधिकतम से परे लेबल को नियंत्रित करने, श्रेणी अक्ष लेबल स्पेसिंग को समायोजित करने, और पाई चार्ट लेबल्स की स्थिति निर्धारित करने के तरीके समझाता है।

## **चार्ट डेटा लेबल्स में डेटा प्रिसिशन सेट करें**

सीरीज़ मानों को स्वरूपित करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसका डेटा टेबल प्रदर्शित करता है, और पहली श्रृंखला के लिए मान लेबल सक्षम करता है। फ़ॉर्मेट `#,##0.00` हज़ार विभाजक और दो दशमलव स्थान प्रदर्शित करता है बिना मूल मान बदलें।

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

## **लेबल्स के रूप में प्रतिशत प्रदर्शित करें**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट को उस टेक्स्ट फ्रेम में असाइन करें जो [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/) द्वारा लौटाया जाता है। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8-पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत प्रदर्शित करता है। शून्य कुल वाली श्रेणियों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल्स के साथ प्रतिशत संकेत सेट करें**

जब मान अंशों के रूप में संग्रहित होते हैं, तो प्रतिशत प्रदर्शित करने के लिए [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत सेल्स से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) को `false` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीले श्रृंखलाओं के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान जोड़ी का योग 1 होता है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0% के रूप में प्रदर्शित करता है, जबकि ऊर्ध्वाधर अक्ष दो दशमलव स्थान उपयोग करता है। दोनों श्रृंखलाएँ सफ़ेद, 10-पॉइंट लेबल टेक्स्ट का उपयोग करती हैं।

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

## **डेटा लेबल्स का वास्तविक टेक्स्ट पढ़ें**

डेटा लेबल सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करने के लिए [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकालते समय, प्रस्तुति सामग्री खोजते समय, या उत्पन्न चार्टों की वैधता जाँचते समय उपयोगी होता है। नीचे के उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) प्रत्येक श्रेणी नाम, श्रृंखला नाम और मान को संयोजित करता है। एक बिंदु अपना मान प्रतिशत के रूप में स्वरूपित करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा बिंदु में संग्रहित संख्या `0.75` रहती है, भले ही उसका लेबल `75%` श्रेणी और श्रृंखला नामों के साथ दिखाए। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) दोनों मामलों में परिणामी लेबल स्ट्रिंग लौटाता है। जब आप केवल दृश्यमान लेबल निकालना चाहते हैं, तो ऊपर दर्शाए अनुसार अलग से [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/) जाँचें।

## **अक्ष अधिकतम से परे डेटा लेबल्स को नियंत्रित करें**

जब आप मैन्युअल रूप से अक्ष रेंज को सीमित करते हैं, तो कुछ डेटा बिंदु उसके अधिकतम से अधिक हो सकते हैं। यह नियंत्रित करने के लिए कि उनके डेटा लेबल दिखाए जाएँ या नहीं, [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/) का उपयोग करें। यह सेटिंग लेबल दृश्यता बदलती है; यह अक्ष रेंज या अंतर्निहित डेटा मानों को नहीं बदलती।

नीचे का उदाहरण 60 और 120 मानों के साथ 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह वर्टिकल अक्ष पर [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) को `false` पास करता है और [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) के साथ अधिकतम 100 सेट करता है। पहली स्लाइड अधिकतम से परे लेबल की अनुमति देती है; उस स्लाइड की एक कॉपी उन्हें अक्षम करती है। दोनों स्लाइड्स `DataLabelsOverMaximum.pptx` में सहेजी गई हैं।

[setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) के साथ मान लेबल सक्षम करें। चार्ट-स्तर की सेटिंग स्वयं मान प्रदर्शन को सक्षम नहीं करती या व्यक्तिगत लेबल के निष्क्रिय मान प्रदर्शन को ओवरराइड नहीं करती। यह उदाहरण पूरी श्रृंखला के लिए मान सक्षम करता है और [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/) का उपयोग करके प्रत्येक कॉलम के बाहरी छोर पर लेबल रखता है।

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

निम्न छवियां सहेजी गई स्लाइड्स को Microsoft PowerPoint द्वारा रेंडर दिखाती हैं। `true` के साथ, लेबल **120** ऊपरी सीमा पर दृश्यमान रहता है; `false` के साथ, यह छुपा रहता है। लेबल **60** दृश्यमान बना रहता है, अक्ष अधिकतम **100** पर रहता है, और दूसरे डेटा बिंदु दोनों मामलों में **120** रहता है।

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint चार्ट जो मान लेबल 120 को अक्ष अधिकतम 100 के साथ दिखा रहा है](data-labels-over-maximum-true.png) | ![PowerPoint चार्ट जो मान लेबल 120 को अक्ष अधिकतम 100 के साथ छिपा रहा है](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण मान अक्ष वाला 2D कॉलम चार्ट उपयोग करता है। मान अक्ष के बिना चार्ट, जैसे पाई और डोनट चार्ट, इस प्रकार सीमित करने के लिए कोई अक्ष अधिकतम नहीं रखते हैं।
{{% /alert %}}

## **अक्ष से लेबल दूरी सेट करें**

[setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच दूरि नियंत्रित करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा बिंदुओं से जुड़े लेबल के बजाय श्रेणी अक्ष लेबल को प्रभावित करती है।

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

पाई चार्ट पर, डेटा लेबल स्थितियों को समायोजित करके स्पेसिंग सुधारें और लीडर लाइन्स के लिए स्थान बनाएं।

यह उदाहरण पहला डेटा बिंदु का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और उसके क्षैतिज तथा ऊर्ध्वाधर ऑफ़सेट को [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) और [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) का उपयोग करके समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊंचाई के सापेक्ष होते हैं।

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

## **लीडर लाइन्स का स्वरूप**

जब पाई चार्ट लेबल अपने स्लाइस के बाहर होते हैं, तो लीडर लाइन्स पाठकों को प्रत्येक मान को सही स्लाइस से मिलाने में मदद करती हैं। एक कंट्रास्ट रंग और थोड़ा मोटी लाइन इन कनेक्शनों को आसान बनाती है, जबकि ट्रांसपेरेंसी और डैश्ड शैली लाइन को दृश्य रूप से कम दिखाती है।

[getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/) का उपयोग करके श्रृंखला के डेटा लेबल संग्रह स्तर पर लीडर लाइन्स को स्वरूपित करें। `$series->getLabels()->getLeaderLinesFormat()->getLine()` में स्थित सेटिंग्स संग्रह पर लागू होती हैं, न कि व्यक्तिगत लेबल पर।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ पाई चार्ट बनाता है, स्लाइस के बाहर मान प्रदर्शित करता है, और [setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/) को सक्षम करता है। यह दो लेबल को उनके स्लाइस से दूर ले जाता है, [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) और [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) ऑफ़सेट का उपयोग करके, जो चार्ट की चौड़ाई और ऊंचाई के अंश में व्यक्त होते हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है।

लाइन का [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) 255 में से 191 अल्फा मान के साथ सॉलिड नीला रंग सेट करता है, जो लगभग 25% ट्रांसपेरेंसी देता है। [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) मोटाई को 2 पॉइंट सेट करता है, और [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) लाइन को डैश्ड बनाता है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 80, 50, 560, 400);
    $chart->setLegend(false);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
    $labelFormat->setShowValue(true);
    $labelFormat->setPosition(LegendDataLabelPosition::OutsideEnd);
    $labelFormat->setShowLeaderLines(true);

    // दो लेबल को उनके स्लाइस से और दूर ले जाएँ.
    $series->getLabels()->get_Item(0)->setX(0.10);
    $series->getLabels()->get_Item(0)->setY(-0.05);
    $series->getLabels()->get_Item(1)->setX(-0.10);
    $series->getLabels()->get_Item(1)->setY(0.05);

    $line = $series->getLabels()->getLeaderLinesFormat()->getLine();
    $line->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 30, 90, 160, 191);
    $line->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $line->setWidth(2);
    $line->setDashStyle(LineDashStyle::Dash);

    $presentation->save("FormattedLeaderLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

लीडर लाइन्स को सक्षम करने से यह गारंटी नहीं मिलती कि हर लेबल के लिए लाइन दिखाई देगी। दृश्यता लेबल की स्थिती और चार्ट के लेआउट व्यवहार पर निर्भर करती है। इस उदाहरण में, दो हटाए गए लेबलों के पास दृश्यमान लीडर लाइन्स हैं; जो लेबल अपने स्लाइस के पास रहते हैं उन्हें इसकी आवश्यकता नहीं होती।

![पाई चार्ट जिसमें दो बाहरी लेबल्स को उनके स्लाइस से नीले, अधपारदर्शी डैश्ड लीडर लाइन्स से जोड़ा गया है](formatted-leader-lines.png)

## **कॉलम चार्ट के ऊपर डेटा लेबल्स की कई पंक्तियों जोड़ें**

यह उदाहरण प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल्स के साथ एक कॉलम चार्ट बनाता है। श्रृंखला A दृश्य कॉलम दिखाती है, जबकि श्रृंखला B और श्रृंखला C अतिरिक्त लेबल प्रदान करती हैं। उनके कॉलम को फ़िल और आउटलाइन हटाकर छुपा दिया जाता है। [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) मेथड सभी तीन श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करता है।

[ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) सेटिंग्स लेबल पंक्तियों के लिए स्थान आरक्षित करती हैं। [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) डिफ़ॉल्ट स्थितियों की गणना करने के बाद, [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) और [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) क्षैतिज संरेखण बनाए रखते हैं और दो पंक्तियों में लेबल व्यवस्थित करने के लिए ऊर्ध्वाधर ऑफ़सेट लागू करते हैं। संख्याएँ श्रृंखला मानों से जुड़ी डेटा लेबल्स बनी रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट आकार होते हैं।

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
            // B और C के कॉलम छिपाएँ, लेकिन उनके डेटा लेबल रखें.
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

    // सभी तीन श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करें.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // इस संक्षिप्त उदाहरण के लिए कम ग्रिडलाइन उपयोग करें.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // प्लॉट के ऊपर दो पंक्तियों के डेटा लेबल्स के लिए स्थान आरक्षित करें.
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
            // डिफ़ॉल्ट क्षैतिज स्थिति रखें. Y डिफ़ॉल्ट लेबल स्थिति से एक ऑफ़सेट है,
            // जो चार्ट-ऊँचाई अंश के रूप में व्यक्त किया गया है.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // केवल पंक्ति शीर्षक एक अलग टेक्स्ट शेप है.
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

![प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल्स वाला कॉलम चार्ट](multiple-rows-of-labels.png)


## **FAQ**

**मैं घने चार्ट्स में डेटा लेबल्स के ओवरलैप को कैसे रोक सकता हूँ?**

ऑटोमैटिक लेबल प्लेसमेंट, लीडर लाइन्स, और छोटा फ़ॉन्ट आकार संयोजित करें; यदि आवश्यक हो तो कुछ फ़ील्ड (जैसे श्रेणी) को छुपाएँ या केवल चरम मानों या मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**मैं केवल शून्य, नकारात्मक या खाली मानों के लिए लेबल कैसे अक्षम करूँ?**

लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक या अनुपलब्ध मानों के प्रदर्शन को बंद करें।

**PDF/छवियों में निर्यात करते समय लेबल शैली को लगातार कैसे सुनिश्चित करूँ?**

फ़ॉन्ट परिवार और आकार को स्पष्ट रूप से सेट करें और रेंडरिंग परिवेश में फ़ॉन्ट उपलब्ध है या नहीं जांचें ताकि फ़ॉलबैक से बचा जा सके।