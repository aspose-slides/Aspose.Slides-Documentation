---
title: PHP का उपयोग करके प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें
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
description: "PowerPoint प्रस्तुतियों में Aspose.Slides for PHP (Java के माध्यम से) का उपयोग करके चार्ट डेटा लेबल जोड़ने और फ़ॉर्मैट करने का तरीका सीखें, ताकि अधिक आकर्षक स्लाइड बनाए जा सकें।"
---
## **परिचय**

डेटा लेबल चार्ट श्रृंखला और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी दिखाते हैं, जिससे पाठकों को मान पहचानने और चार्ट को समझने में मदद मिलती है। यह लेख बताता है कि मानों को कैसे फ़ॉर्मेट करें, प्रतिशत कैसे प्रदर्शित करें, लेबल टेक्स्ट कैसे पढ़ें, श्रेणी अक्ष लेबल की स्पेसिंग कैसे समायोजित करें, और पाई चार्ट लेबल की स्थिति कैसे निर्धारित करें।

## **चार्ट डेटा लेबल में डेटा की सटीकता सेट करें**

सीरीज़ मानों को फ़ॉर्मेट करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसका डेटा टेबल दिखाता है, और पहली सीरीज़ के लिए वैल्यू लेबल सक्षम करता है। फ़ॉर्मेट `#,##0.00` हजारों विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

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

एक स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट फ्रेम को [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) द्वारा लौटाए गए फ्रेम में टेक्स्ट असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8‑पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत प्रदर्शित करता है। शून्य कुल वाले वर्गों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। चार्ट डेटा बदलने पर कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल के साथ प्रतिशत चिह्न सेट करें**

जब मानों को भिन्न के रूप में संग्रहीत किया जाता है, तो प्रतिशत दिखाने के लिए [setNumberFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/#setNumberFormat) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) को `false` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीले सीरीज़ के साथ 100 % स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान का जोड़ा 1 के बराबर होता है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0 % के रूप में दिखाता है, जबकि वर्टिकल अक्ष दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ सफ़ेद, 10‑पॉइंट लेबल टेक्स्ट का उपयोग करती हैं।

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

## **डेटा लेबल का वास्तविक टेक्स्ट पढ़ें**

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट को प्राप्त करने के लिए [getActualLabelText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#getActualLabelText) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकालते समय, प्रस्तुति सामग्री खोजते समय, या उत्पन्न चार्ट की वैधता जाँचते समय उपयोगी है। नीचे के उदाहरण में, डिफ़ॉल्ट [डेटा लेबल फ़ॉर्मेट](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम, और मान को संयोजित करता है। एक बिंदु अपना मान प्रतिशत के रूप में फ़ॉर्मेट करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) से कस्टम टेक्स्ट का उपयोग करता है।

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

डेटा बिंदु में संग्रहीत संख्या `0.75` ही रहती है, भले ही उसका लेबल `75%` तथा श्रेणी और सीरीज़ नामों के साथ दिखे। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को प्रतिस्थापित करता है। [getActualLabelText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#getActualLabelText) दोनों मामलों में परिणामी लेबल स्ट्रिंग लौटाता है। केवल दृश्य लेबल निकालना चाहते हैं तो ऊपर दिखाए अनुसार [isVisible](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#isVisible) को अलग से जांचें।

## **एक अक्ष से लेबल की दूरी सेट करें**

श्रेणी अक्ष लेबल और अक्ष के बीच की दूरी को नियंत्रित करने के लिए [setLabelOffset](https://reference.aspose.com/slides/hi/php-java/aspose.slides/axis/#setLabelOffset) का उपयोग करें। मान अक्ष लेबल की अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा बिंदुओं से जुड़े लेबलों के बजाय श्रेणी अक्ष लेबल पर प्रभाव डालती है।

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

## **लेबल का स्थान समायोजित करें**

पाई चार्ट पर, डेटा लेबल की स्थिति को समायोजित करें ताकि स्पेसिंग बेहतर हो और लीडर लाइन के लिये जगह बन सके।

यह उदाहरण पहले डेटा बिंदु का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#setX) तथा [setY](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/#setY) का उपयोग करके क्षैतिज व ऊर्ध्वाधर ऑफ़सेट समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

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

**मैं घने चार्ट पर डेटा लेबल के ओवरलैप को कैसे रोक सकता हूँ?**

ऑटोमैटिक लेबल प्लेसमेंट, लीडर लाइन्स, और फ़ॉन्ट आकार को घटाकर संयोजन करें; आवश्यक होने पर कुछ फ़ील्ड (जैसे श्रेणी) छिपाएँ या केवल अत्यधिक मानों या प्रमुख बिंदुओं के लिए लेबल दिखाएँ।

**मैं केवल शून्य, नकारात्मक, या खाली मानों के लिए लेबल कैसे निष्क्रिय कर सकता हूँ?**

लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और 0, नकारात्मक या अनुपलब्ध मानों के लिए डिस्प्ले बंद करें, जैसा कि एक परिभाषित नियम में निर्दिष्ट किया गया हो।

**PDF/छवियों में निर्यात करते समय लेबल शैली को सुसंगत कैसे रखें?**

फ़ॉन्ट परिवार और आकार को स्पष्ट रूप से सेट करें और रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध है यह सुनिश्चित करें ताकि फ़ॉलबैक से बचा जा सके।