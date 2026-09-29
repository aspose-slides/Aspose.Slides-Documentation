---
title: PHP में प्रस्तुतियों में चार्ट डेटा श्रृंखला को प्रबंधित करें
linktitle: डेटा श्रृंखला
type: docs
url: /hi/php-java/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रृंखला नाम
- डेटा बिंदु
- वर्कबुक सेल
- श्रृंखला गैप
- नकारात्मक मान
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के साथ प्रस्तुतियों में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक सेल, फ़ॉर्मेटिंग, ओवरलैप, गैप चौड़ाई, और नकारात्मक मान को कैसे प्रबंधित करें, सीखें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/) संबंधित मानों के एक सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/) एक या अधिक वर्कबुक सेल को संदर्भित करता है। [ChartCategory](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स श्रृंखला द्वारा साझा किए गए लेबल या समूह मान प्रदान करते हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ, और पॉइंट मान [ChartDataCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, कॉलम 0 को श्रेणी नामों के लिए, और शेष सेल्स को श्रृंखला मानों के लिए उपयोग करती है। वर्कशीट, पंक्ति, और कॉलम इंडेक्स जो [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#getCell) को पास किए जाते हैं, शून्य-आधारित होते हैं। यह लेआउट डिफ़ॉल्ट डेटा के साथ चार्ट बनाने पर उपयोगी है, लेकिन यह मानकर न चलें कि हर मौजूदा चार्ट इसका उपयोग करता है। लोडेड प्रस्तुति के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों और डेटा पॉइंट्स द्वारा संदर्भित सेल्स की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे कि [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getFormat), एक श्रृंखला के सभी पॉइंट्स की डिफ़ॉल्ट उपस्थिति प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे कि [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getFormat), एक पॉइंट के लिए श्रृंखला की उपस्थिति को ओवरराइड करती हैं।
- समूह सेटिंग्स संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/) से संबंधित हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसे विकल्प सेट करने की आवश्यकता हो तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट पॉइंट या श्रृंखला फ़िल सेट नहीं किया जाता, तो चार्ट शैली और थीम स्वचालित उपस्थिति निर्धारित करती हैं। जब श्रृंखला और पॉइंट दोनों फ़ॉर्मेटिंग मौजूद होती है, तो उस पॉइंट के लिए पॉइंट फ़ॉर्मेटिंग को प्राथमिकता मिलती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getOverlap) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी प्रतिशत तक ओवरलैप करते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने योग्य प्रतिबिंब है। प्रत्येक संगत श्रृंखला को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम प्रदर्शित करते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्नलिखित उदाहरण पहले श्रृंखला को सम्मिलित करने वाले समूह के लिए ओवरलैप सेट करता है:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // नया चार्ट नमूना श्रृंखला, श्रेणियां और मान शामिल करता है।
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

## **श्रृंखला फ़िल रंग बदलें**

पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने के लिए [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getFormat) का उपयोग करें। यदि किसी पॉइंट का पहले से स्पष्ट फ़िल है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस पॉइंट के लिए श्रृंखला फ़िल को ओवरराइड करता है।

निम्नलिखित उदाहरण पहली श्रृंखला पर सॉलिड नीला फ़िल लागू करता है:

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

## **श्रृंखला नाम बदलें**

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और आमतौर पर लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिए डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर होता है और पहली श्रृंखला का नाम रखता है। नीचे दिए गए उदाहरण में नामित वेरिएबल्स इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशेष पंक्ति या कॉलम को मानते हुए कार्य नहीं करता:

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

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) श्रृंखला इंडेक्स और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जिसका उपयोग तब किया जाता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं हुआ हो। यह मेथड गणना किया गया रंग पढ़ता है; यह नया फ़िल असाइन नहीं करता।

निम्नलिखित उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

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

सटीक रंग चार्ट शैली और थीम पर निर्भर करता है।

## **एक चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को सॉलिड सेट करें, इनवर्शन को सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनके प्रदर्शित रंग बदलते हैं।

निम्नलिखित उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

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

आप एक पॉइंट के लिए इनवर्शन को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के माध्यम से सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए इनवर्शन अक्षम है और केवल चयनित पॉइंट के लिए सक्षम है। पॉइंट को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखाई दे:

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

## **एक विशिष्ट डेटा पॉइंट मान साफ़ करें**

एक पॉइंट को खाली करने के लिए, उसके बैकिंग वर्कबुक सेल को `null` सेट करें, जबकि अन्य पॉइंट्स को नहीं हटाएँ। कॉलम चार्ट के लिए, प्लॉटेड मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से उपलब्ध होता है। डेटा पॉइंट उसी श्रेणी स्थिति पर रहता है, लेकिन चार्ट उसकी मान को खाली मानता है, जैसा कि चार्ट के ब्लैंक‑वैल्यू सेटिंग्स में निर्धारित है।

निम्नलिखित उदाहरण पहली श्रृंखला के दूसरे पॉइंट को ही साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट एक आकार सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो हटाना चाहते हैं। यदि आप अन्य पॉइंट्स को रखना चाहते हैं तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointcollection/#clear) को न कॉल करें, क्योंकि यह मेथड पूरे संग्रह से सभी डेटा पॉइंट्स हटा देता है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करें**

छिपे हुए सेल्स जिनमें मान होते हैं, वे खाली सेल्स से अलग मामला है। छिपी हुई वर्कशीट पंक्तियों और कॉलमों से डेटा को शामिल या बाहर करने के लिए देखें [Include Data from Hidden Rows and Columns](/slides/hi/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपलब्ध डेटा दर्शाता है; `0` मान वाला सेल ज्ञात संख्यात्मक मान को दर्शाता है। सेल को खाली करने के लिए [ChartDataCell::setValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setValue) को `null` पास करें। संख्यात्मक शून्य ब्लैंक‑सेल सेटिंग से प्रभावित नहीं होता।

[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/#setDisplayBlanksAs) का उपयोग करके तय करें कि चार्ट खाली सेल्स को कैसे प्रदर्शित करे। यह सेटिंग पूरे चार्ट पर लागू होती है और खाली सेल्स को शून्य या इंटरपोलेटेड मान से भरने के बिना प्लॉटिंग को बदलती है।

निम्नलिखित स्वतंत्र उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 के मान को साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) वर्कशीट 0, कॉलम 0 को श्रेणी लेबल और कॉलम 1 को मान के रूप में उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

प्रत्येक आउटपुट फ़ाइल में सहेजने से पहले असाइन किया गया मोड संग्रहीत होता है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, इच्छित मोड को असाइन करें और प्रस्तुति को एक बार सहेजें, मोड पर इटरेट करने के बजाय।

नीचे तुलना दिखाती है कि सभी तीन फ़ाइलों में एक ही डेटा है। दिन 3 हर मामले में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दिखावट प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड्स को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में कोई लाइन नहीं होती जो गायब श्रेणी के पार जुड़ सके, इसलिए `Span` उपर्युक्त कनेक्टिंग सेगमेंट नहीं बना सकता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों के लिए तीन स्पष्ट परिणामों की उम्मीद न रखें; अपने उपयोग किए गए प्रकार के आउटपुट की जाँच करें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई आसन्न बार या कॉलम क्लस्टर्स के बीच का अंतर है, जिसे बार या कॉलम चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबद्ध है, न कि किसी एकल श्रृंखला से। समूह के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ा मान क्लस्टर्स के बीच अधिक स्थान बनाता है; छोटा मान उन्हें अधिक सघन कर देता है।

निम्नलिखित उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति सहेजता है:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखला का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/) एनीमरेशन द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं का मान संरचना या सेटिंग्स समान नहीं होता। उदाहरण के लिए, श्रेणी चार्ट में श्रेणियां और मान होते हैं, स्कैटर चार्ट में X और Y मान होते हैं, और बबल चार्ट में बबल आकार जोड़ते हैं। श्रृंखला प्रकार से मेल खाने वाली डेटा‑पॉइंट निर्माण मेथड का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

एक [ChartSeriesGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/) में संगत श्रृंखलाएँ होती हैं जो समूह‑स्तर की प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को नहीं बदलता।

**क्या नया बनाया गया चार्ट डिफ़ॉल्ट डेटा रखता है?**

हां। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addChart) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले दोनों श्रृंखला और श्रेणी संग्रह को साफ़ कर सकते हैं। एक ओवरलोड भी बिना डिफ़ॉल्ट डेटा के चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑पॉइंट मान [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) में सेल्स को संदर्भित करते हैं। किसी संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय, श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक पॉइंट इच्छित श्रेणी के नीचे प्लॉट हो सके।

**मैं पूरी श्रृंखला के बजाय एक पॉइंट कैसे साफ़ करूँ?**

संबंधित मान सेल को `null` सेट करें ताकि पॉइंट की श्रेणी स्थिति खाली पॉइंट के रूप में बनी रहे। केवल पूरी श्रृंखला को हटाने के लिए [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointcollection/#clear) का उपयोग करें। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को इस प्रकार अपडेट करें कि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली पॉइंट्स कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/#setDisplayBlanksAs) में कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान, या पड़ोसी पॉइंट्स को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में अनुपलब्ध डेटा के अर्थ से मेल खाने वाला सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें [खाली सेल्स के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)।

**नकारात्मक मानों को कैसे फ़ॉर्मेट किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#setInvertIfNegative) को कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) से प्राप्त रंग असाइन करें। आप व्यक्तिगत पॉइंट के लिए इनवर्शन को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) से ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और पॉइंट दोनों फ़ॉर्मेट किए हों तो कौन जीतता है?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस पॉइंट के लिए प्राथमिकता रखती है। अन्य पॉइंट्स स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और पॉइंट‑स्तर फ़ॉर्मेटिंग ओवरराइड नहीं हैं।

**क्या किसी चार्ट में श्रृंखलाओं की संख्या पर सीमा है?**

Aspose.Slides कोई अलग स्थायी श्रृंखला‑गणना सीमा नहीं लगाता। व्यवहार में, प्रस्तुति फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पठनीयता उपयोगी सीमा तय करती हैं।

**जब कॉलम बहुत पास या बहुत दूर हों तो क्या बदलना चाहिए?**

उचित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/#setGapWidth) को कॉल करें। मान बढ़ाने से क्लस्टर्स के बीच स्थान विस्तारित होता है, घटाने से क्लस्टर्स एक‑दूसरे के करीब आ जाते हैं।