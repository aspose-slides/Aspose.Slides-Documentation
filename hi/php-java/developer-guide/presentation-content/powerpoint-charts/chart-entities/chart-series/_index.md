---
title: PHP में प्रस्तुतियों में चार्ट डेटा सीरीज़ का प्रबंधन
linktitle: डेटा सीरीज़
type: docs
url: /hi/php-java/chart-series/
keywords:
- चार्ट सीरीज़
- सीरीज़ ओवरलैप
- सीरीज़ रंग
- सीरीज़ नाम
- डेटा पॉइंट
- वर्कबुक सेल
- सीरीज़ गैप
- नकारात्मक मान
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के साथ प्रस्तुतियों में चार्ट सीरीज़, डेटा पॉइंट, वर्कबुक सेल, फ़ॉर्मैटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित करें, सीखें।"
---
## **Overview**

एक chart अपने प्लॉटेड डेटा को chart data workbook में स्टोर करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और series में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/) एक या अधिक workbook सेल्स से जुड़ा होता है। [ChartCategory](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स लेबल या समूहित मान प्रदान करते हैं जो series द्वारा साझा किए जाते हैं। इसलिए series का नाम, श्रेणियाँ, और पॉइंट मान [ChartDataCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल डिस्प्ले टेक्स्ट के रूप में स्टोर किए जाते हैं।

एक सामान्य category chart के लिए, डिफ़ॉल्ट workbook पंक्ति 0 को series नामों के लिए, कॉलम 0 को category नामों के लिए, और शेष सेल्स को series मानों के लिए उपयोग करता है। worksheet, पंक्ति, और कॉलम इंडेक्स जो [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#getCell) को पास किए जाते हैं, ज़ीरो‑आधारित होते हैं। यह लेआउट तब उपयोगी है जब आप डिफ़ॉल्ट डेटा के साथ एक chart बनाते हैं, लेकिन यह मानना गलत है कि हर मौजूदा chart इसे उपयोग करता है। लोडेड प्रस्तुति के लिए, workbook मान बदलने से पहले series, categories, और data points द्वारा संदर्भित सेल्स की जाँच करें।

Chart सेटिंग्स के तीन अलग-अलग दायरे होते हैं:

- Series‑level सेटिंग्स, जैसे कि [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getFormat), एक series के सभी पॉइंट्स के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- Data‑point सेटिंग्स, जैसे कि [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getFormat), एक पॉइंट के लिए series की उपस्थिति को ओवरराइड करती हैं।
- Group सेटिंग्स समान [ChartSeriesGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/) से संबंधित संगत series पर लागू होती हैं। जब आपको overlap या gap width जैसी विकल्प सेट करने हों, तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से समूह तक पहुँचें।

जब स्पष्ट रूप से पॉइंट या series fill सेट नहीं किया जाता, तो chart शैली और थीम स्वचालित रूप से उपस्थिति निर्धारित करती है। जब दोनों series और पॉइंट फ़ॉर्मेटिंग मौजूद होते हैं, तो पॉइंट फ़ॉर्मेटिंग उस पॉइंट के लिए प्राथमिकता लेती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Set the Chart Series Overlap**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getOverlap) रिपोर्ट करता है कि 2D chart में बार या कॉलम कितनी प्रतिशत ओवरलैप करते हैं, -100 से 100 प्रतिशत के बीच। यह पैरेंट series समूह पर सेटिंग का एक read‑only प्रोजेक्शन है। सभी संगत series को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन chart प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन chart में असंबंधित series समूहों को प्रभावित नहीं करता।

नीचे दिया गया उदाहरण पहली series को शामिल करने वाले समूह के लिए overlap सेट करता है:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // नया चार्ट नमूना सीरीज़, श्रेणियाँ, और मान शामिल करता है।
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

परिणाम:

![The series overlap](series_overlap.png)

## **Change the Series Fill Color**

पूरा series के लिए डिफ़ॉल्ट fill सेट करने हेतु [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getFormat) का प्रयोग करें। यदि किसी पॉइंट के पास पहले से स्पष्ट fill है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस पॉइंट के लिए series fill को ओवरराइड करती है।

नीचे दिया गया उदाहरण पहली series पर ठोस नीला fill लागू करता है:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

परिणाम:

![The color of the series](series_color.png)

## **Change the Series Name**

Series का नाम chart data workbook में संग्रहीत होता है और सामान्यतः लेजेंड में दिखाया जाता है। क्लस्टरड कॉलम chart के लिए डिफ़ॉल्ट workbook में, सेल B1 पंक्ति 0, कॉलम 1 पर स्थित है और पहली series का नाम रखता है। नीचे के उदाहरण में नामित वेरिएबल्स इस संरचना को स्पष्ट रूप से दर्शाते हैं:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

आप [ChartSeries.getName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा chart में किसी विशिष्ट पंक्ति और कॉलम को मानने से बचाता है:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

परिणाम:

![The series name](series_name.png)

## **Get the Automatic Series Fill Color**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) series इंडेक्स और chart शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो series fill स्पष्ट रूप से परिभाषित न होने पर उपयोग होता है। मेथड को कॉल करने से केवल गणना किया गया रंग पढ़ा जाता है; यह नया fill नहीं सेट करता।

नीचे दिया गया उदाहरण प्रत्येक डिफ़ॉल्ट series का स्वचालित रंग प्रिंट करता है:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

डिफ़ॉल्ट chart शैली के लिए उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग chart शैली और थीम पर निर्भर करते हैं।

## **Set Invert Fill Color for a Chart Series**

बार, कॉलम, और बबल series के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को अलग fill के साथ दिखा सकता है। नियमित series fill को ठोस सेट करें, inversion को सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। workbook में नकारात्मक संख्याएँ वही रहती हैं; केवल उनका डिस्प्ले रंग बदलता है।

नीचे दिया गया उदाहरण डिफ़ॉल्ट chart डेटा को एक series में बदलता है। worksheet की पंक्ति 0 में series नाम है, कॉलम 0 में category नाम, और कॉलम 1 में मान हैं:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

परिणाम:

![The inverted solid fill color](inverted_solid_fill_color.png)

आप एक पॉइंट के लिए inversion को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के माध्यम से सक्षम कर सकते हैं। नीचे के उदाहरण में series के लिए inversion अक्षम किया गया है और केवल चयनित पॉइंट के लिए सक्षम किया गया है। प्रभाव दिखाने के लिए पॉइंट को नकारात्मक मान सौंपा गया है:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Clear a Specific Data Point Value**

एक पॉइंट को खाली करने के लिए, उसके backing workbook सेल को `null` सेट करें, जबकि अन्य पॉइंट्स को नहीं हटाएँ। कॉलम chart के लिए, प्लॉटेड मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से उपलब्ध होता है। डेटा पॉइंट उसी category स्थिति पर रहता है, लेकिन chart उसकी मान को ब्लैंक मानता है, जैसा कि chart की blank‑value सेटिंग्स निर्धारित करती हैं।

नीचे दिया गया उदाहरण पहली series के दूसरे पॉइंट को ही साफ़ करता है:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Scatter charts अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और bubble charts एक size सेल भी उपयोग करते हैं। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य पॉइंट्स को रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointcollection/#clear) को कॉल न करें, क्योंकि यह मेथड संग्रह से सभी डेटा पॉइंट्स को हटा देता है।

## **Set the Series Gap Width**

Gap width बारी‑बारी से पड़ते बार या कॉलम क्लस्टर्स के बीच का अंतराल है, जो बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। overlap की तरह, यह पैरेंट series समूह से जुड़ा होता है, न कि किसी एकल series से। समूह के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ा मान क्लस्टर्स के बीच अधिक जगह बनाता है; छोटा मान उन्हें अधिक घनिष्ठ बनाता है।

नीचे दिया गया उदाहरण gap width बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

परिणाम:

![The gap width](gap_width.png)

## **FAQ**

**Which chart types support data series?**

[ChartType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/) enumeration द्वारा प्रतिनिधित्व किए गए सभी chart प्रकार chart डेटा का उपयोग करते हैं, लेकिन उनकी series सभी में समान मान संरचना या सेटिंग्स नहीं होतीं। उदाहरण के लिए, category charts में categories और values होते हैं, scatter charts में X और Y values होते हैं, और bubble charts में bubble sizes जोड़ते हैं। series प्रकार से मेल खाती data‑point निर्माण विधि का उपयोग करें। overlap और gap width जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**What is a chart series group?**

[ChartSeriesGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/) संगत series को रखता है जो समूह‑स्तरीय प्लॉटिंग सेटिंग्स साझा करते हैं। एक combination chart में एक से अधिक समूह हो सकते हैं, इसलिए एक series के माध्यम से पहुँचा गया समूह सभी series को बदल नहीं सकता।

**Does a newly created chart contain default data?**

हाँ। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addChart) नमूना series, categories, और values बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले series और category संग्रह दोनों को साफ़ कर सकते हैं। एक overload का उपयोग करके chart को डिफ़ॉल्ट डेटा के बिना भी बनाया जा सकता है।

**How are chart objects connected to workbook cells?**

Series नाम, category लेबल, और data‑point मान एक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) में स्थित सेल्स को संदर्भित करते हैं। संदर्भित सेल में परिवर्तन करने पर संबंधित chart तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय, category पंक्तियों और series‑value पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक पॉइंट इच्छित category के तहत प्लॉट हो।

**How do I clear one point instead of the whole series?**

संबंधित value सेल को `null` सेट करें ताकि पॉइंट की category स्थिति एक खाली पॉइंट के रूप में बनी रहे। केवल उस केस में [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointcollection/#clear) का उपयोग करें जब आप पूरे series के सभी पॉइंट्स हटाना चाहते हों। यदि आप categories भी हटाते हैं, तो प्रत्येक series को अपडेट करें ताकि उनके मान category संग्रह के साथ संरेखित रहें।

**How are empty points displayed?**

परिणाम chart प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/#setDisplayBlanksAs) में कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित charts ब्लैंक्स को gaps, zero values, या निकटस्थ पॉइंट्स को जोड़कर डिस्प्ले कर सकते हैं। वह सेटिंग चुनें जो आपके प्रस्तुतीकरण में अनुपलब्ध डेटा के अर्थ के अनुरूप हो।

**How are negative values formatted?**

समर्थित बार, कॉलम, और बबल series के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#setInvertIfNegative) को कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) द्वारा लौटाए गए रंग को सेट करें। आप व्यक्तिगत पॉइंट के लिए [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के माध्यम से व्यवहार को ओवरराइड कर सकते हैं। ये मेथड्स फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**Which formatting wins when both a series and a point are formatted?**

स्पष्ट data‑point फ़ॉर्मेटिंग उस पॉइंट के लिए प्राथमिकता लेती है। अन्य पॉइंट्स स्पष्ट series फ़ॉर्मेट या, यदि series फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित chart शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे overlap और gap width लेआउट को नियंत्रित करती हैं और पॉइंट‑स्तर की फ़ॉर्मेटिंग ओवरराइड नहीं होतीं।

**Is there a limit to how many series a chart can contain?**

Aspose.Slides कोई अलग स्थिर series‑count सीमा नहीं लगाता। व्यवहार में, प्रस्तुति फ़ाइल की सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और chart की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**What should I change when columns are too close together or too far apart?**

उचित पैरेंट series समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/#setGapWidth) को कॉल करें। मान को बढ़ाएँ ताकि क्लस्टर्स के बीच की दूरी बढ़े, या घटाएँ ताकि क्लस्टर्स एक‑दूसरे के निकट आएँ।