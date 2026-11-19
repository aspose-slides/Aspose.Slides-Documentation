---
title: PHP में प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं का प्रबंधन
linktitle: डेटा श्रृंखला
type: docs
url: /hi/php-java/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रृंखला नाम
- डेटा बिंदु
- वर्कबुक कोशिका
- श्रृंखला गैप
- नकारात्मक मान
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा बिंदुओं, वर्कबुक कोशिकाओं, फ़ॉर्मेटिंग, ओवरलैप, गैप चौड़ाई, और नकारात्मक मानों का प्रबंधन कैसे करें, जानें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए मानों को वर्कबुक कोशिकाओं में या सीधे संख्यात्मक लिटरल्स के रूप में संग्रहीत कर सकता है। एक [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) उस श्रृंखला में एक बिंदु का प्रतिनिधित्व करता है। [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स लेबल या समूह मान प्रदान करते हैं जो श्रृंखला द्वारा साझा किए जाते हैं। डिफ़ॉल्ट डेटा के साथ बनाए गए चार्ट में, श्रृंखला नाम, श्रेणियाँ, और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स का उपयोग करते हैं जो चार्ट वर्कबुक से आते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक में पंक्ति 0 श्रृंखला नामों के लिये, स्तंभ 0 श्रेणी नामों के लिये, और शेष कोशिकाएँ श्रृंखला मानों के लिये उपयोग होती हैं। [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) को पास किए गए वर्कशीट, पंक्ति और स्तंभ सूचकांक शून्य‑आधारित होते हैं। यह लेआउट डिफ़ॉल्ट डेटा के साथ चार्ट बनाते समय उपयोगी है, लेकिन यह मानने से बचें कि हर मौजूदा चार्ट इसे ही उपयोग करता है। लोडेड प्रस्तुति के लिये, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों और डेटा बिंदुओं द्वारा संदर्भित कोशिकाओं की जाँच करें।

चार्ट सेटिंग्स के तीन विभिन्न स्तर होते हैं:

- श्रृंखला‑स्तर सेटिंग्स, जैसे [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), सभी बिंदुओं के लिये डिफ़ॉल्ट स्वरूप प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), एक बिंदु के लिये श्रृंखला स्वरूप को ओवरराइड करती हैं।
- समूह सेटिंग्स संगत श्रृंखलाओं पर लागू होती हैं जो समान [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) से संबंधित हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने हों, तो [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला भराव सेट नहीं होता, तो चार्ट शैली और थीम स्वचालित स्वरूप निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु स्वरूप मौजूद होते हैं, तो बिंदु स्वरूप उस बिंदु के लिये प्राथमिकता लेता है।

![chart-series-powerpoint](chart-series-powerpoint.png)

क्लस्टर्ड सिलेंडर चार्ट के लिये, देखें कि कैसे [changing the 3D series type or bar shape](/slides/hi/php-java/3d-chart/#change-the-3d-series-type-and-bar-shape) प्रथम श्रृंखला को प्रभावित करता है।

## **संख्यात्मक लिटरल्स का उपयोग करके श्रृंखला मान सेट करें**

जब श्रृंखला मान अनुप्रयोग डेटा या गणनाओं से आते हैं और उन्हें वर्कशीट कोशिका संदर्भों की आवश्यकता नहीं होती, तो संख्यात्मक लिटरल्स का उपयोग करें। प्रत्येक बिंदु के [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) परिणाम को [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/) के माध्यम से असाइन करने से पहले [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) को [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) के साथ कॉल करें।

कलेक्शन सेटिंग उस श्रृंखला के सभी बिंदु मानों के स्रोत प्रकार को नियंत्रित करती है। प्रत्येक बिंदु मान का [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) मेथड चयनित प्रकार दर्शाता है; इसे कलेक्शन सेटिंग के माध्यम से बदलें। `Worksheet` के साथ, संदर्भित कोशिका तक पहुँचने के लिये [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) का उपयोग करें। `DoubleLiterals` के साथ, संख्या को सीधे पढ़ने या लिखने के लिये [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) या `setAsLiteralDouble` का उपयोग करें।

निम्न उदाहरण एक कॉलम चार्ट बनाता है जिसमें डिफ़ॉल्ट श्रृंखला और श्रेणियाँ होती हैं, फिर पहले श्रृंखला के मौजूदा बिंदुओं को गणना किए गए 10, 20, … मान असाइन करता है। यह प्रस्तुति को सहेजता है, पुनः खोलता है, और संग्रहीत मानों को प्रिंट करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

बिंदु मान स्रोत प्रकार [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) से अलग है, जो चार्ट के आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन को पहचानता है। संख्यात्मक लिटरल्स का उपयोग करने से स्वयम् एम्बेडेड वर्कबुक हटता नहीं है। इस उदाहरण में, श्रेणी लेबल, श्रृंखला नाम, और अन्य श्रृंखलाओं के लिये वर्कबुक उपलब्ध रहता है। वर्कबुक प्रबंधन के लिये देखें [Chart Workbook](/slides/hi/php-java/chart-workbook/)।

स्कैटर और बबल चार्ट के लिये, क्रमशः [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) और [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) का उपयोग करके [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) और [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/) के स्रोत चुनें। बबल चार्ट में [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) का उपयोग [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/) के लिये किया जाता है। प्रत्येक लागू स्रोत को `DoubleLiterals` पर सेट करें और फिर उस मान के `setAsLiteralDouble` मेथड के माध्यम से संख्या असाइन करें।

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) बताता है कि 2 डी चार्ट में बार या कॉलम कितना ओवरलैप करते हैं, -100 से 100 % तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल पढ़ने‑योग्य प्रक्षेपण है। समूह में सभी संगत श्रृंखलाओं को अपडेट करने के लिये [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम प्रदर्शित करते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहले श्रृंखला को सम्मिलित करने वाले समूह के लिये ओवरलैप सेट करता है:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ और मान रखता है।
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

## **श्रृंखला भराव रंग बदलें**

पूरी श्रृंखला के लिये डिफ़ॉल्ट भराव सेट करने के लिये [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) का उपयोग करें। यदि किसी बिंदु के पास पहले से स्पष्ट भराव है, तो उसका [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) सेटिंग उस बिंदु के लिये श्रृंखला भराव को ओवरराइड करती है।

निम्न उदाहरण पहले श्रृंखला पर ठोस नीला भराव लागू करता है:

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

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत रहता है और सामान्यतः लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के डिफ़ॉल्ट वर्कबुक में, कोशिका B1 पंक्ति 0, स्तंभ 1 पर स्थित है और प्रथम श्रृंखला का नाम रखती है। नीचे के उदाहरण में नामित वेरिएबल्स इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/) द्वारा पहले से संदर्भित कोशिका को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशिष्ट पंक्ति और स्तंभ के अनुमान से बचाता है:

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

### **कई कोशिकाओं से नाम वाली श्रृंखला बनाएं**

जब उत्पाद नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक कोशिकाओं में संग्रहीत हों, तो समग्र श्रृंखला नाम उपयोगी होता है। उदाहरण के लिये, आप B1 में `Product A` और C1 में `2026` को मिलाकर एकल श्रृंखला नाम बना सकते हैं, जबकि दोनों भाग अपने स्रोत कोशिकाओं से जुड़े रहें।

नाम रेंज प्राप्त करने के लिये [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) का उपयोग करें, फिर उस कलेक्शन को [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/) में पास करें। `skipHiddenCells` तर्क यह निर्धारित करता है कि छिपी हुई कोशिकाएँ शामिल हों या नहीं: `true` उन्हें बाहर रखता है, जबकि `false` शामिल करता है। यह उदाहरण नाम रेंज में प्रत्येक कोशिका को शामिल करने के लिये `false` इस्तेमाल करता है।

निम्न उदाहरण एक प्रस्तुति बनाता है जिसमें एक श्रृंखला और दो डेटा बिंदु होते हैं। कोशिकाएँ B1:C1 केवल श्रृंखला नाम देती हैं; A2:A3 श्रेणी लेबल देती हैं, और B2:B3 संख्यात्मक मान देती हैं।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // ये दो कोशिकाएँ श्रृंखला नाम प्रदान करती हैं।
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // अलग-अलग कोशिकाएँ श्रेणियों और संख्यात्मक डेटा बिंदुओं को प्रदान करती हैं।
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणामी श्रृंखला नाम `Product A 2026` है, दो कोशिका मानों के बीच एक स्पेस के साथ। लेजेंड इसे दोनों स्तंभों के लिये एक ही प्रविष्टि के रूप में दिखाता है। नीचे की छवि परिणाम दर्शाती है:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **स्वचालित श्रृक्ति भराव रंग प्राप्त करें**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) श्रृंखला सूचकांक और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वही रंग है जो तब उपयोग होता है जब श्रृंखला भराव स्पष्ट रूप से परिभाषित नहीं होता। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया भराव निर्धारित नहीं करता।

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

डिफ़ॉल्ट चार्ट शैली के लिये नमूना आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **एक चार्ट श्रृंखला के लिये इनवर्ट भराव रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिये, [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) नकारात्मक मानों को अलग भराव के साथ दिखा सकता है। नियमित श्रृंखला भराव को ठोस सेट करें, इनवर्ज़न सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका डिस्प्ले रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तंभ 0 में श्रेणी नाम, और स्तंभ 1 में मान होते हैं:

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

आप एक बिंदु के लिये [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) के माध्यम से इनवर्ज़न सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिये इनवर्ज़न अक्षम है और केवल चयनित बिंदु के लिये सक्षम है। प्रभाव दिखाने के लिये बिंदु को नकारात्मक मान भी असाइन किया गया है:

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

## **एक विशिष्ट डेटा बिंदु मान साफ़ करें**

एक बिंदु को खाली करने के लिये, जबकि अन्य बिंदुओं को न हटाएँ, उसकी बैकिंग वर्कबुक कोशिका को `null` सेट करें। कॉलम चार्ट में, प्लॉट किया गया मान [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) के माध्यम से उपलब्ध होता है। डेटा बिंदु वही श्रेणी स्थिति बनाए रखता है, लेकिन चार्ट उसकी मान को खाली मानते हुए संभालता है।

निम्न उदाहरण प्रथम श्रृंखला के दूसरे बिंदु को ही हटाता है:

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट एक आकार कोशिका भी उपयोग करता है। केवल उस कोशिका को साफ़ करें जो हटाने योग्य मान का प्रतिनिधित्व करती है। जब आप अन्य बिंदुओं को बनाए रखना चाहते हैं, तो [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) न कॉल करें, क्योंकि यह मेथड श्रृंखला के सभी डेटा बिंदुओं को हटा देता है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

छिपी हुई कोशिकाएँ जो मान रखती हैं, वह खाली कोशिकाओं से अलग मामला है। छिपी हुई पंक्तियों और स्तंभों से डेटा को शामिल या बाहर करने के लिये देखें [Include Data from Hidden Rows and Columns](/slides/hi/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक कोशिका अनुपलब्ध डेटा को दर्शाती है; `0` वाली कोशिका ज्ञात संख्यात्मक मान को दर्शाती है। एक कोशिका को खाली बनाने के लिये [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) को `null` पास करें। संख्यात्मक शून्य खाली‑कोशिका सेटिंग से स्वतंत्र रूप से शून्य ही रहता है।

खाली कोशिकाओं को चार्ट कैसे प्रदर्शित करता है, यह चुनने के लिये [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है। यह खाली मानों को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक कोशिका को शून्य या इंटरपोलेशन मान से भरते हुए।

निम्न स्वतंत्र उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला होती है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) वर्कशीट 0, स्तंभ 0 को श्रेणी लेबल और स्तंभ 1 को मान के लिये उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रखता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    // Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा बिंदु बरकरार रखें।
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

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले निर्धारित मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, तथा `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिये, इच्छित मोड असाइन करें और प्रस्तुति को एक बार सहेँ, सभी मोड पर पुनरावृति न करें।

नीचे तुलना तीन फ़ाइलों में समान डेटा दिखाती है। दिन 3 सभी मामलों में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दिखाई देने वाला प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में गायब श्रेणी के ऊपर जोड़ने हेतु कोई रेखा नहीं होती, इसलिए `Span` उपर्युक्त कनेक्टिंग सेगमेंट नहीं बना पाता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी तरह, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग रेखा नहीं होती। इसलिए सभी चार्ट प्रकारों में तीन अलग-अलग परिणाम की उम्मीद न रखें; अपने उपयोग किए गये प्रकार के लिये आउटपुट जाँचें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई आसन्न बार या कॉलम क्लस्टर के बीच की दूरी है, जो बार या कॉलम चौड़ाई के प्रतिशत के रूप में व्यक्त होती है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से सम्बंधित है, न कि व्यक्तिगत श्रृंखला से। समूह के लिये एक बार [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) को कॉल करें। बड़ा मान क्लस्टर के बीच अधिक स्थान बनाता है; छोटा मान उन्हें अधिक घना बनाता है।

निम्न उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति सहेजता है:

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

## **श्रृंखला रेखाएँ दिखाएँ या छुपाएँ**

श्रृंखला रेखाएँ चार्ट के संबंधित भागों को दृश्य रूप से जोड़ती हैं। समर्थित स्टैक्ड बार और ऑफ‑पाई चार्ट में उन्हें दिखाने या छिपाने के लिये [ChartSeriesGroup::setSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setserieslines/) का उपयोग करें। दो‑आयामी स्टैक्ड बार और कॉलम चार्ट में, ये श्रेणियों के पार संबंधित स्टैक सीमाओं को जोड़ती हैं। पाई ऑफ़ पाई और बार ऑफ़ पाई चार्ट में, ये मुख्य प्लॉट को द्वितीयक प्लॉट से जोड़ती हैं। यह सेटिंग अन्य चार्ट प्रकारों के लिये सामान्य कनेक्टर नहीं है।

समूह तक पहुँचने के लिये [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) का उपयोग करें। यह सेटिंग समूह की प्रत्येक श्रृंखला पर लागू होती है। [ChartSeries::hasSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/hasserieslines/) केवल पढ़ने‑योग्य है और पैरेंट समूह की सेटिंग को दर्शाता है; इसे अपडेट करने के लिये समूह के सेट्टर को कॉल करें।

निम्न उदाहरण एक [ChartType::PieOfPie](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा होता है। यह वही चार्ट श्रृंखला रेखाओं को सक्षम और फिर अक्षम करके दो प्रस्तुतियों को सहेजता है, तुलना हेतु।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $seriesGroup = $series->getParentSeriesGroup();

    $seriesGroup->setSeriesLines(true);
    $presentation->save("series_lines_enabled.pptx", SaveFormat::Pptx);

    $seriesGroup->setSeriesLines(false);
    $presentation->save("series_lines_disabled.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| श्रृंखला रेखाएँ सक्षम | श्रृंखला रेखाएँ अक्षम |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| दो रेखाएँ मुख्य पाई को द्वितीयक पाई से जोड़ती हैं। | दोनों पाई दिखाई देती हैं, लेकिन कनेक्टिंग रेखाएँ छिपी हुई हैं। |

श्रृंखला रेखाएँ डेटा लेबल लीडर रेखाओं से अलग होती हैं, जो लेबल को उनके डेटा बिंदुओं से जोड़ती हैं; ग्रिडलाइन, जो चार्ट एक्सिस पर अंतराल दर्शाती हैं; और लाइन चार्ट में रेखाएँ, जो डेटा मानों को दर्शाती हैं। यह सेटिंग उन तत्वों को नियंत्रित नहीं करती।

## **बार‑बार पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखला का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) एन्ह्यूमरेशन द्वारा प्रतिनिधित्व किए गये सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की मान संरचना या सेटिंग समान नहीं होती। उदाहरण के लिये, श्रेणी चार्ट में श्रेणियाँ और मान, स्कैटर चार्ट में X और Y मान, और बबल चार्ट में बबल आकार होते हैं। श्रृंखला प्रकार के अनुरूप डेटा‑बिंदु निर्माण मेथड का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसे विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**एक चार्ट श्रृंखला समूह क्या है?**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) संगत श्रृंखलाओं को सम्मिलित करता है जो समूह‑स्तर की प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचे समूह को बदलने से आवश्यक नहीं कि चार्ट की सभी श्रृंखलाएँ बदलें।

**क्या नया बना चार्ट डिफ़ॉल्ट डेटा रखता है?**

हां। डिफ़ॉल्ट रूप से, [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) नमूना श्रृंखलाएँ, श्रेणियाँ, और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले दोनों श्रृंखला और श्रेणी कलेक्शन को साफ़ कर सकते हैं। एक ओवरलोड भी बिना डिफ़ॉल्ट डेटा के चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑बिंदु मान [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) की कोशिकाओं को संदर्भित करते हैं। किसी संदर्भित कोशिका को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय एक बिंदु को कैसे साफ़ करूँ?**

बिंदु की संबंधित मान कोशिका को `null` सेट करें ताकि बिंदु का श्रेणी स्थान खाली बिंदु के रूप में बना रहे। केवल तब [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) का उपयोग करें जब आप पूरी श्रृंखला के सभी बिंदुओं को हटाना चाहते हों, क्योंकि यह मेथड श्रृंखला के सभी डेटा बिंदुओं को हटा देता है।

**खाली बिंदुओं को कैसे प्रदर्शित किया जाता है?**

परिणाम चार्ट प्रकार और [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) द्वारा निर्धारित मान पर निर्भर करता है। समर्थित चार्ट गुणसूची को खाली को गैप, शून्य मान, या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। अपने प्रस्तुतिकरण में लापता डेटा के अर्थ के अनुरूप सेटिंग चुनें। पूरी उदाहरण और दृश्य तुलना के लिये देखें [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मानों को कैसे स्वरूपित किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिये, [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) कॉल करें और [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) द्वारा लौटाए गए रंग को सेट करें। आप [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) के द्वारा व्यक्तिगत बिंदु के लिये व्यवहार को ओवरराइड कर सकते हैं। ये मेथड स्वरूपण को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों स्वरूपित हों तो कौन जीतेगा?**

स्पष्ट डेटा‑बिंदु स्वरूपण उस बिंदु के लिये प्राथमिकता रखता है। अन्य बिंदु स्पष्ट श्रृंखला स्वरूप या, यदि श्रृंखला स्वरूप परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम को अपनाते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट नियंत्रित करती हैं और बिंदु‑स्तर के स्वरूपण ओवरराइड नहीं होतीं।

**क्या कोई सीमा है कि एक चार्ट अधिकतम कितनी श्रृंखलाएँ रख सकता है?**

Aspose.Slides कोई अलग स्थिर श्रृंखला‑गिनती सीमा नहीं थोपता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत पास‑पास या बहुत दूर हों तो क्या बदलना चाहिए?**

सही पैरेंट श्रृंखला समूह पर [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) कॉल करें। मान बढ़ाएँ तो क्लस्टर के बीच अंतराल बढ़ेगा, घटाएँ तो क्लस्टर एक‑दूसरे के पास आएँगे।