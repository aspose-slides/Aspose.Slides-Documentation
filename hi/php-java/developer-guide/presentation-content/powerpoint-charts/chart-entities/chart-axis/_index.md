---
title: PHP का उपयोग करके प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/php-java/chart-axis/
keywords:
- चार्ट अक्ष
- ऊर्ध्वाधर अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को नियंत्रित करें
- अक्ष को व्यवस्थित करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "जानिए कैसे Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुतियों में रिपोर्ट और विज़ुअलाइज़ेशन के लिए चार्ट अक्षों को अनुकूलित किया जा सकता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides for PHP via Java का उपयोग करके चार्ट अक्षों को अनुकूलित करने के तरीके को समझाता है। यह गणना किए गए अक्ष मानों, चार्ट पंक्तियों और स्तंभों को स्विच करने, अक्ष दृश्यमानता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियों और स्वरूपण, शीर्षक घूर्णन, अक्ष स्थितिकरण, प्रदर्शन इकाइयों और लघुगणकीय स्केलिंग को शामिल करता है।

## **चार्ट में लंबवत अक्ष पर अधिकतम मान प्राप्त करें**

Create a [प्रस्तुति](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) and add an area chart with default data. Call [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) before reading calculated axis values so that the chart layout is up to date.

अक्ष सीमाओं के लिए [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) और [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) पढ़ें, और टिक अंतराल के लिए [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) और [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) पढ़ें। [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) और [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय चर में संग्रहीत करता है और चार्ट को सहेजता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्षों के बीच डेटा अदला‑बदली करें**

[ switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) का उपयोग करके चार्ट डेटा में श्रृंखलाओं और श्रेणियों की भूमिकाओं को बदलें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा के समूह बनाने के तरीके को बदलता है; यह क्षैतिज और लंबवत अक्षों को नहीं बदलता। उदाहरण [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करता है, जिसमें हेडर पंक्ति और श्रेणी स्तंभ शामिल हैं, पंक्तियों और स्तंभों को स्वैप करने से पहले। यह चार श्रृंखलाओं और तीन श्रेणियों के साथ एक चार्ट को सहेजता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्ष के प्लॉट क्रम को उलटें**

[setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) का उपयोग करके श्रेणी या मान अक्ष को उलटा करें। उदाहरण के लिए, एक क्षैतिज बार चार्ट योजना, विकास, परीक्षण को कार्यपत्र की उसी क्रम में ऊपर से नीचे तक दिखा सकता है। अक्ष को उलटा करने से प्लॉटिंग दिशा बदलती है; यह कार्यपत्र डेटा को नहीं सॉर्ट या पुनर्व्यवस्थित करता। तुलना के लिए, [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) श्रृंखलाओं और श्रेणियों की भूमिकाओं को बदलता है।

निम्न उदाहरण तीन चरणों और एक श्रृंखला के साथ एक क्षैतिज बार चार्ट बनाता है। यह तीन स्लाइडों के साथ एक प्रस्तुति को सहेजता है: सामान्य क्रम, उल्टी श्रेणियाँ, और उल्टे मान। प्रत्येक कॉपी समान डेटासेट का उपयोग करती है, और प्रत्येक कॉपी में केवल एक अक्ष उलटा होता है।

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // स्लाइड 2: शीर्ष पर पहली श्रेणी दिखाएँ।
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // क्षैतिज मान अक्ष को नीचे रखें।
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // स्लाइड 3: केवल क्षैतिज संख्यात्मक स्केल को उलटें।
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

अक्ष को उलटा करने से लम्बवत अक्ष को प्लॉट के विपरीत किनारे पर ले जाया भी जा सकता है। [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) नियंत्रित करता है कि अन्य अक्ष किस बिंदु पर कॉन्फ़िगर किए जा रहे अक्ष को काटता है। स्लाइड 2 में, `CrossesType::Maximum` के साथ उल्टी श्रेणी अक्ष पर इसे कॉल करने से क्षैतिज मान अक्ष नीचे रहता है। विशिष्ट कट बिंदु के लिए, [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) का उपयोग करें। दिशा बदलते समय क्रॉसिंग सेटिंग्स की जाँच करें, विशेषकर जब चार्ट में पहले से ही एक कस्टम क्रॉसिंग बिंदु हो। `setPlotOrderReversed` को `false` के साथ कॉल करने से सामान्य प्लॉटिंग दिशा पुनर्स्थापित होती है; क्रॉसिंग सेटिंग्स अलग हैं।

| सामान्य क्रम (स्लाइड 1) | उल्टी श्रेणियाँ (स्लाइड 2) | उल्टे मान (स्लाइड 3) |
| --- | --- | --- |
| ![लंबवत अक्ष पर मुख्य ग्रिडलाइन के बीच नारंगी छोटे ग्रिडलाइन](axis-order-normal.png) | ![ऊपर से नीचे तक श्रेणियों को दिखाने वाला क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![दाएँ ओर शून्य पर कटने वाले उल्टे मान अक्ष के साथ क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियाँ नीचे से ऊपर तक जाती हैं; मान बाएँ से दाएँ बढ़ते हैं। | योजना, विकास, और परीक्षण ऊपर से नीचे तक चलते हैं। मान और वर्कबुक पंक्तियों का क्रम अपरिवर्तित रहता है। | श्रेणियाँ अपना सामान्य क्रम बनाए रखती हैं; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी अक्ष दाएँ ओर शून्य पर कटता है। |

## **लाइन चार्ट के लिए लंबवत अक्ष को अक्षम करें**

[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) को `false` के साथ लंबवत अक्ष पर कॉल करके इसे छिपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और इसे लंबवत अक्ष छिपे हुए सहेजता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **लाइन चार्ट के लिए क्षैतिज अक्ष को अक्षम करें**

[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) को `false` के साथ क्षैतिज अक्ष पर कॉल करके इसे छिपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और इसे क्षैतिज अक्ष छिपे हुए सहेजता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **चार्ट ग्रिडलाइन दिखाएँ या छुपाएँ**

[getShowMajorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowmajorgridlines/) और [getShowMinorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowminorgridlines/) को कॉल करके पता लगाएँ कि कौन सी ग्रिडलाइनें अक्ष प्रदर्शित करता है। छोटे ग्रिडलाइन दिखाने के लिए, [getMinorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getminorgridlinesformat/) का उपयोग करें और लाइन फाइल को ठोस, दिखाई देने वाले रंग पर सेट करें। उन्हें छिपाने के लिए, फाइल को [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) पर सेट करें। प्रमुख ग्रिडलाइन के लिए भी इसी तरह लाइन फाइल बदलने हेतु [getMajorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getmajorgridlinesformat/) का उपयोग करें। फाइल बदलने से अक्ष की दृश्यमानता और टिक‑मार्क नहीं बदलते।

इस क्लस्टर्ड कॉलम चार्ट के लंबवत अक्ष में शुरू में केवल प्रमुख ग्रिडलाइन दिखाई देती है। उदाहरण छोटे ग्रिडलाइन को गहरा नारंगी रंग में दिखाता है, फिर उन्हें फिर से छिपाता है और प्रस्तुति को सहेजता है। यह प्रत्येक चरण पर ग्रिडलाइन की दृश्यमानता को प्रिंट करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
    $axis = $chart->getAxes()->getVerticalAxis();
    printf("Initial: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill = $axis->getMinorGridLinesFormat()->getLine()->getFillFormat();
    $minorFill->setFillType(FillType::Solid);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $minorFill->getSolidFillColor()->setColor($darkOrange);
    printf("Enabled: minor=%s\n", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill->setFillType(FillType::NoFill);
    printf("Hidden: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $presentation->save("ChartGridlines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| छोटे ग्रिडलाइन सक्षम | छोटे ग्रिडलाइन छिपे |
| --- | --- |
| ![लंबवत अक्ष पर मुख्य ग्रिडलाइन के बीच नारंगी छोटे ग्रिडलाइन](minor-gridlines-enabled.png) | ![केवल मुख्य ग्रिडलाइन दिखाते हुए वही कॉलम चार्ट](minor-gridlines-hidden.png) |

## **श्रेणी अक्ष बदलें**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) का उपयोग करके तिथि या टेक्स्ट श्रेणी अक्ष चुना जा सकता है। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें पहले स्लाइड पर पहला आकार चार्ट है और श्रेणी कोशिकाओं में संख्यात्मक Excel तिथि मान होते हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) को `false` के साथ, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) को `1` के साथ, और [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) को `TimeUnitType::Months` के साथ कॉल करने से मुख्य टिकें एक‑माह अंतराल पर रखी जाती हैं।

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **डेटा से श्रेणी अक्ष प्रकार निर्धारित करें**

श्रेणियों को भरने के बाद [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistypeautomatically/) को कॉल करें, फिर [getCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getcategoryaxistype/) को पढ़कर चयन का निरीक्षण करें। यह वही समय उपयोगी है जब समान चार्ट को या तो टेक्स्ट लेबल या संख्यात्मक तिथि मान प्राप्त होते हैं। यह विधि कॉल पर प्रकार निर्धारित करती है; यह कोई स्थायी मोड नहीं बनाती जो बाद में डेटा परिवर्तन पर पुनः‑मूल्यांकन करे। श्रेणियों को बदलने के बाद इसे फिर से कॉल करें।

निम्न उदाहरण टेक्स्ट श्रेणियों के साथ एक चार्ट बनाता है और जब चयनित प्रकार `CategoryAxisType::Text` हो तो `true` प्रिंट करता है। फिर श्रेणी कोशिका मानों को तिथियों से बदलता है और फिर से विधि को कॉल करता है, जब चयनित प्रकार `CategoryAxisType::Date` हो तो `true` प्रिंट करता है। तिथियों को संख्यात्मक OLE Automation मान के रूप में संग्रहीत किया जाता है, जो 30 December 1899 से दिनों के रूप में गणना की जाती हैं, न कि तिथि स्ट्रिंग से। [setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) इन मानों के दिखने के तरीके को नियंत्रित करता है; यह टेक्स्ट को संख्यात्मक तिथियों में परिवर्तित नहीं करता। श्रेणी कोशिकाओं के बारे में अधिक जानकारी के लिए देखें [चार्ट वर्कबुक](/slides/hi/php-java/chart-workbook/)।

इनपुट में ज्ञात है कि टेक्स्ट श्रेणियां या संख्यात्मक तिथियां हैं तो स्वचालित निर्धारण का उपयोग करें, जैसा कि इस उदाहरण में है। सामान्य संख्यात्मक लेबल, मिश्रित श्रेणियां या खाली डेटा के लिए, इच्छित अर्थ के अनुसार स्पष्ट रूप से [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) को कॉल करें। केवल संख्यात्मक मान यह स्थापित नहीं करते कि श्रेणियां तिथियां दर्शाती हैं।

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $seriesName = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());
    $labels = ["First", "Second", "Third"];

    for ($i = 0; $i < count($labels); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $labels[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Text ? "true" : "false") . PHP_EOL;

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);
    $dates = [gmmktime(0, 0, 0, 1, 1, 2026), gmmktime(0, 0, 0, 1, 2, 2026), gmmktime(0, 0, 0, 2, 1, 2026)];

    for ($i = 0; $i < count($dates); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0);
        $categoryCell->setValue((float)(($dates[$i] - $baseDate) / 86400));
        $categoryCell->setCustomNumberFormat("yyyy-mm-dd");
    }

    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Date ? "true" : "false") . PHP_EOL;

    $presentation->save("AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **श्रेणी अक्ष लेबल अंतराल को नियंत्रित करें**

जब चार्ट में बहुत सी श्रेणियां हों, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दृश्य अक्ष लेबलों की संख्या घटाएँ। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) को `false` पर सेट करें, फिर वांछित श्रेणी अंतराल को [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) को पास करें। सामान्य क्रम में टेक्स्ट श्रेणियों के लिए, गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, ... श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, ... श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, ... श्रेणी 22 |

`3` का अंतराल हर तीसरे लेबल को दिखाता है, दर्शाए गए लेबलों के बीच दो लेबल गुप्त रहते हैं। यह संबंधित स्तंभों को नहीं हटाता। स्वचालित अंतराल उपलब्ध स्थान के आधार पर अंतराल चुनता है; यह आवश्यक नहीं कि हर लेबल दिखाया जाए।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) को `false` पर सेट करें और [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) का उपयोग करके उनका अंतराल निर्धारित करें। उदाहरण के लिए, `1` रखने से प्रत्येक श्रेणी अंतराल पर एक टिक‑मार्क रहेगा जबकि लेबल केवल हर तीसरी श्रेणी पर दिखाई देंगे। एक दृश्यमान शैली के साथ [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) का उपयोग करके परिणाम देख सकते हैं। किसी भी स्वचालित‑अंतराल सेटर को `true` पर फिर से कॉल करने से चार्ट को वही अंतराल चुनने देता है।

निम्न स्व-समाहित उदाहरण 24 श्रेणियों और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित अंतर, स्वतंत्र टिक‑मार्क के साथ मैनुअल लेबल अंतर, और पुनर्स्थापित स्वचालित अंतर। दोनों प्रतियां मूल चार्ट डेटा को बरकरार रखती हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं। क्षैतिज लेबल टेक्स्ट घनीभवन को स्पष्ट रूप से दिखाता है।

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // स्लाइड 2: हर तीसरा लेबल दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए एक टिक‑मार्क रखें।
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // स्लाइड 3: चार्ट को फिर से दोनों अंतराल चुनने दें।
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**स्वचालित अंतर (स्लाइड 1):** इस रेंडरिंग में प्रत्येक दूसरी श्रेणी लेबल दिखाई देती है और दो पंक्तियों में लिपटती है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के आधार पर भिन्न हो सकता है।

![स्वचालित श्रेणी लेबल अंतराल जिसमें सभी 24 स्तंभ दिख रहे हैं](category-axis-automatic.png)

**मैनुअल अंतर (स्लाइड 2):** प्रत्येक तीसरा लेबल एक पंक्ति में दिखता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बने रहते हैं। सभी 24 स्तंभ, जिनमें बिना लेबल वाले भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 ऊपर दिखाए गए स्वचालित स्वरूप को पुनर्स्थापित करता है।

![तीन के मैनुअल श्रेणी लेबल अंतराल जिसमें सभी 24 स्तंभ दिख रहे हैं](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

इस श्रेणी‑गणना अंतराल का उपयोग टेक्स्ट श्रेणी अक्ष के लिए करें, जैसे कि कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष लम्बवत होता है, इसलिए इन्हें [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) द्वारा लौटाए गए अक्ष पर लागू करें। टिक‑मार्क अंतराल उन चार्टों में श्रृंखला अक्ष पर भी लागू होता है जिनमें यह मौजूद होता है।

श्रेणी लेबल अंतराल का उपयोग मान अक्ष के संख्यात्मक स्केल को सेट करने के लिए न करें। मान अक्ष पर, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिए, `10` का प्रमुख इकाई शून्य से शुरू होने पर 0, 10, 20 आदि पर टिक स्थापित करता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों की परवाह किए बिना। बिखराव (scatter) और बबल चार्ट मान अक्षों का उपयोग करते हैं, न कि टेक्स्ट श्रेणी अक्ष का। तिथि अक्ष के लिए, [श्रेणी अक्ष बदलें](#%E0%A4%B6%E0%A5%8D%E0%A4%B0%E0%A5%87%E0%A4%A3%E0%A5%80-%E0%A4%85%E0%A4%95%E0%A5%8D%E0%A4%B7-%E0%A4%AC%E0%A4%A6%E0%A4%B2%E0%A5%87%E0%A4%82) में वर्णित समय‑आधारित प्रमुख इकाइयों और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

यह उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियों को पहले कार्यपत्र (इंडेक्स `0`) में OLE Automation क्रमांक के रूप में संग्रहीत किया गया है, जो इन तिथियों के लिए 30 December 1899 से दिनों की संख्या के रूप में गणना की गई हैं। [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) को `CategoryAxisType::Date` के साथ, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) को `false` के साथ, और [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) को `yyyy` के साथ कॉल करके श्रेणी लेबल चार सेल स्वरूप से स्वतंत्र चार-अंकीय वर्ष दर्शाते हैं।

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करें**

[setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) को `true` के साथ लंबवत अक्ष पर कॉल करें, शीर्षक पाठ प्रदान करें, और [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) का उपयोग करके शीर्षक को घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण मान‑अक्ष शीर्षक को 90 डिग्री घुमाए हुए कॉलम चार्ट को सहेजता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **श्रेणी या मान अक्ष पर अक्ष की स्थिति सेट करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) का उपयोग करके निर्धारित करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर कहाँ काटेगा। यह सेटिंग केवल श्रेणी अक्षों पर लागू होती है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `true` पर सेट करता है और परिणाम सहेजता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **चार्ट मान अक्ष पर प्रदर्शन इकाई सेट करें**

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) का उपयोग करके मान अक्ष पर लेबल को स्केल किया जा सकता है जबकि मूल डेटा नहीं बदलता। जब [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) `Millions` पर सेट हो, तो 60,000,000 का मान 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके लंबवत अक्ष पर मिलियन प्रदर्शन इकाई लागू करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **लघुगणकीय मान अक्ष सेट करें**

लघुगणकीय मान अक्ष तब उपयोगी है जब सकारात्मक मान कई क्रम magnitude में फैले हों। उदाहरण के तौर पर, एक सेवा पाँच अवधियों में 10, 100, 1 000, 10 000 और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट बहुत करीब दिखाई देते हैं। लघुगणकीय स्केल उनके सापेक्ष वृद्धि को तुलना करने में आसान बनाता है: समान दूरी समान अनुपात को दर्शाती है न कि समान अंतर को।

[setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) को `true` के साथ मान अक्ष पर कॉल करें और [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) का उपयोग करके आधार चुनें। यह मौजूदा मानों के प्रदर्शित रूप को बदलता है; यह डेटा नहीं बदलता और न ही लघुगणकीय ट्रेंड‑लाइन जोड़ता है। ट्रेंड‑लाइन डेटा में फिटी हुई संबंध को दर्शाती है और एक अलग सुविधा है।

### **मान अक्ष और आधार चुनें**

लाइन या कॉलम चार्ट के लिए, मान अक्ष [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) द्वारा लौटाया जाता है। क्षैतिज बार चार्ट के लिए, यह [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) द्वारा लौटाया जाता है। बिखराव (scatter) और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मानों के लिए क्षैतिज अक्ष, Y मानों के लिए लंबवत अक्ष या दोनों चुनें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय आधार `10` है। PPTX चार्ट में, `2` से `1000` तक के आधार का उपयोग किया जा सकता है; भिन्नात्मक आधार जैसे `2.5` भी समर्थित है। आधार `10` के साथ 10, 100, 1 000 और 10 000 क्रमशः समान दूरी पर होते हैं।

### **रैखिक और लघुगणकीय स्केलिंग की तुलना**

निम्न स्व-समाहित उदाहरण पहले स्लाइड पर पाँच अनुरोध गणनाओं के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन करता है और दूसरी स्लाइड पर आधार‑10 लघुगणकीय मान अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा रखती हैं।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // पहली स्लाइड को रैखिक रखें और केवल कॉपी के मान-अक्ष स्केल को बदलें।
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**रेखीय स्केल (स्लाइड 1):** समान लंबवत दूरी समान अनुरोध गणनाओं के अंतर को दर्शाती है। सबसे बड़ा मान चार्ट पर हावी रहता है, जिससे छोटे मानों को अलग से देखना कठिन हो जाता है।

![PowerPoint में रैखिक मान अक्ष पर पाँच अनुरोध गणनाओं के साथ लाइन चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान लंबवत दूरी समान अनुपात को दर्शाती है। प्रत्येक अवधि में अनुरोध पिछली अवधि की तुलना में दस गुना अधिक होते हैं, इसलिए बिंदु आधार‑10 स्केल पर एक सीधी ऊपर की ओर रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गणनाओं को दिखाते हैं।

![PowerPoint में आधार‑10 लघुगणकीय मान अक्ष पर वही पाँच अनुरोध गणनाएं](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल कठोर सकारात्मक मानों को दिखा सकता है। इसे सक्षम करने से पहले डेटा जाँचें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि विश्लेषण के लिए उन मानों को बाहर करना उपयुक्त है, तो हटाने का कारण समझाएँ। उन्हें छोटे सकारात्मक संख्याओं से मौन रूप से बदलना डेटा का अर्थ बदल देता है, इसलिए ऐसा न करें। लघुगणकीय अक्ष के लिए मैन्युअली सेट किया गया न्यूनतम या अधिकतम भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाते प्रश्न**

**मैं कैसे सेट करूँ कि एक अक्ष दूसरे को कहाँ काटता है (अक्ष क्रॉसिंग)?**

[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) का उपयोग करके कट व्यवहार चुनें। संख्यात्मक कट मान निर्दिष्ट करने के लिए, [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) का उपयोग करें। ये सेटिंग्स आपको अक्ष क्रॉसिंग को उपयुक्त बेसलाइन पर ले जाने देती हैं।

**मैं टिक लेबल को अक्ष के सापेक्ष कैसे स्थित कर सकता हूँ?**

[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) को [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) के साथ कॉल करें: `Low`, `High`, `NextTo`, या `None`। टिक‑मार्क स्वयं को नियंत्रित करने के लिए, [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) या [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) का उपयोग करें; ये लेबल स्थितिकरण से अलग हैं।