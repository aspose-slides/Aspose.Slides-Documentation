---
title: PHP में प्रस्तुतियों में चार्ट डेटा श्रृंखला प्रबंधित करें
linktitle: डेटा श्रृंखला
type: docs
url: /hi/php-java/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रृंखला नाम
- डेटा पॉइंट
- वर्कबुक सेल
- श्रृंखला गैप
- नकारात्मक मान
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा पॉइंट्स, वर्कबुक सेल्स, फॉर्मेटिंग, ओवरलैप, गैप चौड़ाई, और नकारात्मक मानों को कैसे प्रबंधित करें, सीखें।"
---
## **परिचय**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/) एक या अधिक वर्कबुक सेल को संदर्भित करता है। [ChartCategory](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स लेबल या समूह मान प्रदान करते हैं जो श्रृंखला के बीच साझा होते हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ और पॉइंट मान [ChartDataCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं न कि केवल प्रदर्शित टेक्स्ट के रूप में संग्रहीत।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 का उपयोग श्रृंखला नामों के लिए, स्तम्भ 0 का उपयोग श्रेणी नामों के लिए, और शेष सेल्स का उपयोग श्रृंखला मानों के लिए करता है। वर्कशीट, पंक्ति और स्तम्भ अनुक्रमांक जो [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#getCell) को पास किए जाते हैं, शून्य‑आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मानकर नहीं चलना चाहिए कि हर मौजूदा चार्ट इसका उपयोग करता है। किसी लोडेड प्रेजेंटेशन के लिए, वर्कबुक मानों को बदलने से पहले श्रृंखला, श्रेणियों और डेटा पॉइंट्स द्वारा संदर्भित सेल्स की जांच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्तर होते हैं:

- सीरीज़‑स्तर की सेटिंग्स, जैसे [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getFormat), एक श्रृंखला के सभी पॉइंट्स के लिए डिफ़ॉल्ट स्वरूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getFormat), एक पॉइंट के लिए श्रृंखला के स्वरूप को ओवरराइड करती हैं।
- ग्रुप सेटिंग्स लागू होती हैं संगत श्रृंखलाओं पर जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/) से संबंधित हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने की आवश्यकता हो, तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से ग्रुप तक पहुंचें।

जब कोई स्पष्ट पॉइंट या श्रृंखला फ़िल सेट नहीं किया गया हो, तो चार्ट शैली और थीम स्वचालित रूप से स्वरूप निर्धारित करती हैं। जब दोनों श्रृंखला और पॉइंट फ़ॉर्मेटिंग मौजूद हों, तो उस पॉइंट के लिए पॉइंट फ़ॉर्मेटिंग को प्राथमिकता मिलती है।

![चार्ट सीरीज़ पॉवरपॉइंट](chart-series-powerpoint.png)

## **चार्ट सीरीज़ ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getOverlap) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितना ओवरलैप होते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट सीरीज़ ग्रुप पर सेटिंग का केवल‑पढ़ने‑योग्य प्रोजेक्शन है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह मिश्रित चार्ट में असंबंधित श्रृंखला ग्रुप को प्रभावित नहीं करता।

निम्न उदाहरण पहली श्रृंखला को शामिल करने वाले ग्रुप का ओवरलैप सेट करता है:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ और मान शामिल करता है।
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

![सीरीज़ ओवरलैप](series_overlap.png)

## **सीरीज़ भराव रंग बदलें**

पूरा सीरीज़ के लिए डिफ़ॉल्ट फ़िल सेट करने हेतु [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getFormat) का उपयोग करें। यदि किसी पॉइंट का स्पष्ट फ़िल पहले से मौजूद है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस पॉइंट के लिए श्रृंखला फ़िल को ओवरराइड करती है।

निम्न उदाहरण पहली श्रृंखला पर ठोस नीले फ़िल को लागू करता है:

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

![सीरीज़ का रंग](series_color.png)

## **सीरीज़ नाम बदलें**

एक सीरीज़ नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाई गई डिफ़ॉल्ट वर्कबुक में, सेल B1 (पंक्ति 0, स्तम्भ 1) पहले श्रृंखला का नाम रखती है। नीचे दिए गए उदाहरण में नामित वेरिएबल्स इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशेष पंक्ति या स्तम्भ को मानने से बचाता है:

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

![सीरीज़ नाम](series_name.png)

## **स्वचालित सीरीज़ भराव रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) श्रृंखला अनुक्रमांक और चार्ट शैली के आधार पर गणना किया गया रंग लौटाता है। यह वही रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

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

डिफ़ॉल्ट चार्ट शैली के लिए उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **चार्ट सीरीज़ के लिए इनवर्ट भराव रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को एक अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को ठोस रूप में सेट करें, इनवर्शन सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शन रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला में बदल देता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तम्भ 0 में श्रेणी नाम, और स्तम्भ 1 में मान होते हैं:

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

![इनवर्टेड ठोस भराव रंग](inverted_solid_fill_color.png)

आप एक पॉइंट के लिए इनवर्शन को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के माध्यम से सक्षम कर सकते हैं। नीचे दिए गए उदाहरण में श्रृंखला के लिए इनवर्शन बंद किया गया है और केवल चयनित पॉइंट के लिए सक्रिय किया गया है। प्रभाव को देखने के लिए पॉइंट को नकारात्मक मान भी असाइन किया गया है:

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

## **विशिष्ट डेटा पॉइंट मान साफ़ करें**

एक पॉइंट को खाली करने के लिए, उसके बैकिंग वर्कबुक सेल को `null` सेट करें, जबकि अन्य पॉइंट्स को न हटाएँ। कॉलम चार्ट में, प्लॉट किया गया मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से उपलब्ध है। डेटा पॉइंट समान श्रेणी स्थिति पर बना रहता है, परंतु चार्ट उसके मान को ब्लैंक‑वैल्यू सेटिंग के अनुसार खाली मानता है।

निम्न उदाहरण पहली श्रृंखला के केवल दूसरे पॉइंट को साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट एक आकार सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। सभी पॉइंट्स को रखने के लिए [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointcollection/#clear) न बुलाएँ, क्योंकि यह मेथड संग्रह से सभी डेटा पॉइंट्स हटा देता है।

## **खाली कोशिकाओं की प्रदर्शनी नियंत्रित करें**

एक खाली वर्कबुक सेल अनुपस्थित डेटा को दर्शाता है; `0` मान वाली सेल ज्ञात संख्यात्मक मान दर्शाती है। किसी सेल को खाली करने के लिए `[ChartDataCell::setValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setValue)` को `null` पास करें। शून्य संख्या हमेशा शून्य ही रहेगी, चाहे ब्लैंक‑सेल सेटिंग कुछ भी हो।

[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/#setDisplayBlanksAs) का उपयोग करके चुनें कि चार्ट खाली कोशिकाओं को कैसे प्रदर्शित करे। यह सेटिंग पूरे चार्ट पर लागू होती है। यह ब्लैंक्स की प्लॉटिंग को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरने के।

निम्न स्वयंपूर्ण उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) वर्कशीट 0, स्तम्भ 0 को श्रेणी लेबल्स के लिए, और स्तम्भ 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम होता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा पॉइंट को बरकरार रखें।
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले असाइन किया गया मोड दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, वांछित मोड असाइन करें और प्रस्तुति को एक बार सहेएँ, सभी मोडों पर इटरेट न करें।

नीचे तुलना वही डेटा तीनों फ़ाइलों में दिखाती है। दिन 3 सभी मामलों में वर्कबुक में खाली है:

![लाइन चार्ट में समान डेटा: गैप — दिन 3 पर लाइन तोड़ता है, ज़ीरो — लाइन को शून्य पर गिराता है, स्पैन — दिन 2 से दिन 4 को जोड़ता है।](display_blanks_as.png)

दृश्य प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड की तुलना आसान बनाता है। बार और कॉलम चार्ट में किसी मिसिंग श्रेणी के ऊपर जोड़ने के लिये कोई लाइन नहीं होती, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को नहीं बना सकता; एक मिसिंग कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकता है। इसी प्रकार, केवल मार्कर्स वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन अलग‑अलग परिणाम की उम्मीद न रखें; अपने उपयोग किए गए प्रकार के आउटपुट को जांचें।

## **सीरीज़ गैप चौड़ाई सेट करें**

गैप चौड़ाई पड़ोसी बार या कॉलम क्लस्टर्स के बीच का अंतर है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत के रूप में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट सीरीज़ ग्रुप से जुड़ा होता है, न कि किसी एकल श्रृंखला से। ग्रुप के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ा मान क्लस्टर्स के बीच अधिक जगह बनाता है; छोटा मान उन्हें घना करता है।

निम्न उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

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

![गैप चौड़ाई](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन-से चार्ट प्रकार डेटा सीरीज़ का समर्थन करते हैं?**  
[ChartType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/) enumeration द्वारा दर्शाए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, परंतु उनकी श्रृंखलाओं में संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट में श्रेणियाँ और मान होते हैं, स्कैटर चार्ट में X और Y मान होते हैं, और बबल चार्ट में बबल आकार जोड़ता है। उस श्रृंखला प्रकार से मेल खाने वाले डेटा‑पॉइंट निर्माण मेथड को उपयोग करें। ओवरलैप और गैप चौड़ाई जैसे विकल्प केवल संगत बार या कॉलम ग्रुप पर लागू होते हैं।

**चार्ट सीरीज़ ग्रुप क्या है?**  
[ChartSeriesGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/) संगत श्रृंखलाओं को समेटता है जो ग्रुप‑स्तर की प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक ग्रुप हो सकते हैं, इसलिए किसी एक श्रृंखला के माध्यम से पहुँचे ग्रुप को बदलने से आवश्यक नहीं कि चार्ट की सभी श्रृंखलाएँ बदलें।

**क्या नया बनाया गया चार्ट डिफ़ॉल्ट डेटा रखता है?**  
हां। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addChart) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप इन सेल्स को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला एवं श्रेणी संग्रह को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**  
श्रृंखला नाम, श्रेणी लेबल और डेटा‑पॉइंट मान एक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) में सेल्स को संदर्भित करते हैं। किसी संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय, श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस तरह संरेखित रखें कि प्रत्येक पॉइंट इच्छित श्रेणी के अंतर्गत प्लॉट हो।

**मैं पूरे सीरीज़ के बजाय एक पॉइंट कैसे साफ़ करूँ?**  
संबंधित मान सेल को `null` सेट करें ताकि पॉइंट का श्रेणी स्थान खाली पॉइंट के रूप में बना रहे। केवल उस पॉइंट को साफ़ करने के लिए [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointcollection/#clear) का उपयोग न करें, क्योंकि यह मेथड श्रृंखला के सभी पॉइंट्स को हटा देता है। यदि आप श्रेणियों को भी हटाते हैं, तो प्रत्येक श्रृंखला को इस तरह अपडेट करें कि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली पॉइंट्स कैसे प्रदर्शित होते हैं?**  
परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/#setDisplayBlanksAs) द्वारा कॉन्‍फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान, या पड़ोसी पॉइंट्स को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में मिसिंग डेटा के अर्थ के अनुसार उपयुक्त सेटिंग चुनें। सभी विकल्पों और दृश्य तुलना के लिए देखें **खाली कोशिकाओं की प्रदर्शनी नियंत्रित करें** सेक्शन।

**नकारात्मक मानों का स्वरूप कैसे किया जाता है?**  
समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#setInvertIfNegative) कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) द्वारा लौटाए गए रंग को असाइन करें। किसी विशिष्ट पॉइंट के लिये इनवर्शन को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) से ओवरराइड कर सकते हैं। ये मेथड्स फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब दोनों सीरीज़ और पॉइंट को स्वरूपित किया गया हो, तो कौन-सा स्वरूप प्राथमिकता लेता है?**  
स्पष्ट डेटा‑पॉइंट फॉर्मेटिंग उस पॉइंट के लिए प्राथमिकता लेती है। अन्य पॉइंट्स स्पष्ट श्रृंखला फॉर्मेट या, यदि श्रृंखला फॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। ग्रुप सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और पॉइंट‑स्तर की फ़ॉर्मेटिंग ओवरराइड नहीं करतीं।

**क्या किसी चार्ट में सीरीज़ की संख्या पर कोई सीमा है?**  
Aspose.Slides में कोई अलग‑थलग स्थिर सीमा नहीं है। व्यवहार में, प्रस्तुति फ़ाइल की सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पठनीयता प्रभावी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत पास या बहुत दूर हों, तो मुझे क्या बदलना चाहिए?**  
उचित पैरेंट सीरीज़ ग्रुप पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। मान को बढ़ाकर क्लस्टर्स के बीच की जगह बढ़ाएँ, या मान को घटाकर क्लस्टर्स को करीब लाएँ।