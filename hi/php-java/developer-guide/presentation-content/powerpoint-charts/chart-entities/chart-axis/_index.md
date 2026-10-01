---
title: "PHP का उपयोग करके प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें"
linktitle: "चार्ट अक्ष"
type: docs
url: /hi/php-java/chart-axis/
keywords:
- "चार्ट अक्ष"
- "ऊर्ध्वाधर अक्ष"
- "क्षैतिज अक्ष"
- "अक्ष अनुकूलन"
- "अक्ष में परिवर्तन"
- "अक्ष प्रबंधन"
- "अक्ष गुण"
- "अधिकतम मान"
- "न्यूनतम मान"
- "अक्ष रेखा"
- "तिथि स्वरूप"
- "अक्ष शीर्षक"
- "अक्ष स्थिति"
- "PowerPoint"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुतियों में रिपोर्ट और विज़ुअलाइज़ेशन के लिए चार्ट अक्षों को अनुकूलित करना सीखें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for PHP via Java के साथ चार्ट अक्षों को कैसे अनुकूलित करें, यह समझाता है। यह गणना किए गए अक्ष मानों, चार्ट की पंक्तियों और कॉलमों को बदलने, अक्ष की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियों और स्वरूपण, शीर्षक घुमाव, अक्ष की स्थिति, और प्रदर्शन इकाइयों को कवर करता है।

## **चार्ट्स में ऊर्ध्वाधर अक्ष पर अधिकतम मान प्राप्त करें**

एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) बनाएं और डिफॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मानों को पढ़ने से पहले [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) को कॉल करें ताकि चार्ट लेआउट नवीनतम हो।

अक्ष की सीमाओं के लिए [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) और [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) पढ़ें, और टिक अंतराल के लिए [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) और [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) पढ़ें। [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) और [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) समय-इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय चर में संग्रहीत करता है और चार्ट को सहेजता है।

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

## **अक्षों के बीच डेटा बदलें**

[swapRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) का उपयोग करके चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाएँ बदलें। प्रत्येक पहले की श्रेणी श्रृंखला बन जाती है, और प्रत्येक पहले की श्रृंखला श्रेणी बनती है। इससे डेटा के समूहण में बदलाव आता है; यह क्षैतिज और ऊर्ध्वाधर अक्षों को नहीं बदलता। उदाहरण [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) का उपयोग करके डिफॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करता है, जिसमें हेडर पंक्ति और श्रेणी कॉलम शामिल हैं, पंक्तियों और कॉलमों को बदलने से पहले। यह चार श्रृंखला और तीन श्रेणियों के साथ एक चार्ट सहेजता है।

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

## **लाइन चार्ट्स के लिए ऊर्ध्वाधर अक्ष को निष्क्रिय करें**

ऊर्ध्वाधर अक्ष पर `false` के साथ [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) कॉल करें ताकि इसे छिपाया जा सके। उदाहरण डिफॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और ऊर्ध्वाधर अक्ष छिपा कर सहेजता है।

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

## **लाइन चार्ट्स के लिए क्षैतिज अक्ष को निष्क्रिय करें**

क्षैतिज अक्ष पर `false` के साथ [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) कॉल करें ताकि इसे छिपाया जा सके। उदाहरण डिफॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और क्षैतिज अक्ष छिपा कर सहेजता है।

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

## **श्रेणी अक्ष बदलें**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) का उपयोग करके तिथि या टेक्स्ट श्रेणी अक्ष चुनें। इस उदाहरण को `ExistingChart.pptx` की आवश्यकता है, जिसमें पहली स्लाइड पर पहला आकार चार्ट है और श्रेणी सेल में संख्यात्मक एक्सेल तिथि मान हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) को `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) को `1`, और [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) को `TimeUnitType::Months` के साथ कॉल करने से प्रमुख टिक एक‑महीने के अंतराल पर स्थित होते हैं।

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

## **श्रेणी अक्ष लेबल अंतराल नियंत्रित करें**

जब किसी चार्ट में कई श्रेणियाँ हों, तो श्रेणियों या डेटा पॉइंट्स को हटाए बिना दिखने वाले अक्ष लेबलों की संख्या कम करें। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) को `false` के साथ कॉल करें, फिर इच्छित श्रेणी अंतराल को [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) में पास करें। सामान्य क्रम में टेक्स्ट श्रेणियों के लिए गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, ... श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, ... श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, ... श्रेणी 22 |

`3` का अंतराल हर तीसरे लेबल को प्रदर्शित करता है, प्रदर्शित लेबलों के बीच दो लेबल छिपे रहते हैं। यह संबंधित कॉलम को नहीं हटाता। स्वचालित स्पेसिंग उपलब्ध स्थान के आधार पर एक अंतराल चुनती है; यह अवश्य सभी लेबल नहीं दिखाती।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) को `false` के साथ कॉल करें और उनके अंतराल को सेट करने के लिए [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) का उपयोग करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर एक टिक‑मार्क रखता है जबकि लेबल केवल हर तीसरी श्रेणी पर दिखाई देते हैं। परिणाम देखने के लिए [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) को एक दृश्यमान शैली के साथ उपयोग करें। दोनों स्वचालित‑स्पेसिंग सेट्टर को फिर से `true` करने से चार्ट को वही अंतराल पुनः चुनने देता है।

निम्नलिखित स्वयं‑समाहित उदाहरण 24 श्रेणियाँ और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित स्पेसिंग, स्वतंत्र टिक‑मार्क के साथ मैनुअल लेबल स्पेसिंग, और पुनर्स्थापित स्वचालित स्पेसिंग। दोनों प्रतियों में मूल चार्ट डेटा बना रहता है। कोई इनपुट प्रेजेंटेशन आवश्यक नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व में अंतर को आसानी से दिखाता है।

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

    // स्लाइड 2: हर तीसरा लेबल दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए टिक‑मार्क रखें।
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

**स्वचालित अंतराल (स्लाइड 1):** इस रेंडरिंग में हर दूसरी श्रेणी लेबल दिखाई देता है और दो पंक्तियों में रैप हो जाता है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![स्वचालित श्रेणी लेबल अंतराल सभी 24 कॉलम दृश्यमान के साथ](category-axis-automatic.png)

**हस्तचलित अंतराल (स्लाइड 2):** हर तीसरा लेबल एक पंक्ति में दिखाई देता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बना रहता है। सभी 24 कॉलम, जिनमें बिना लेबल वाले भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 स्वचालित स्वरूप को पुनर्स्थापित करता है।

![हस्तचलित श्रेणी लेबल अंतराल तीन के साथ सभी 24 कॉलम दृश्यमान](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

टेक्स्ट श्रेणी अक्ष, जैसे कॉलम, लाइन, एरिया या बार चार्ट के श्रेणी अक्ष के लिए इस श्रेणी‑गणना अंतराल का उपयोग करें। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष ऊर्ध्वाधर होता है, इसलिए इन सेटिंग्स को [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) द्वारा लौटाए गए अक्ष पर लागू करें। टिक‑मार्क स्पेसिंग उन चार्ट्स में सीरीज़ अक्ष पर भी लागू होती है जिनमें वह मौजूद हो।

मान अक्ष की संख्यात्मक स्केल सेट करने के लिए श्रेणी लेबल स्पेसिंग का उपयोग न करें। मान अक्ष पर, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिए, `10` की प्रमुख इकाई शून्य से शुरू होने पर 0, 10, 20 आदि पर टिक‑मार्क बनाता है। `3` की श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनती है, चाहे उनके डेटा मान कुछ भी हों। स्कैटर और बबल चार्ट टेक्स्ट श्रेणी अक्ष की बजाय मान अक्षों का उपयोग करते हैं। तिथि अक्ष के लिए, [श्रेणी अक्ष बदलें](#change-a-category-axis) में वर्णित अनुसार समय‑आधारित प्रमुख इकाइयों और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप निर्धारित करें**

उदाहरण डिफॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियाँ पहले कार्यपत्रक (सूचकांक `0`) में OLE ऑटोमेशन सीरियल नंबर के रूप में संग्रहित होती हैं, जो 30 दिसंबर 1899 से दिन गिनती के रूप में होती हैं। [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) को `CategoryAxisType::Date` के साथ उपयोग करें, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) को `false` के साथ कॉल करें, और [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) को `yyyy` पास करें ताकि श्रेणी लेबल सेल फ़ॉर्मेट से स्वतंत्र रूप से चार-अंकीय वर्ष दिखाएँ।

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

## **चार्ट अक्ष शीर्षक के लिए घूर्णन कोण निर्धारित करें**

ऊर्ध्वाधर अक्ष पर `true` के साथ [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) कॉल करें, शीर्षक पाठ प्रदान करें, और [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) का उपयोग करके शीर्षक को घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण कॉलम चार्ट को उसके वैल्यू‑अक्ष शीर्षक को 90 डिग्री घुमाकर सहेजता है।

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

## **श्रेणी या मान अक्ष पर अक्ष स्थिति निर्धारित करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) का उपयोग करके नियंत्रित करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर क्रॉस करता है। यह सेटिंग केवल श्रेणी अक्षों पर लागू होती है। उदाहरण कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर इसे `true` सेट करता है और परिणाम सहेजता है।

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

## **चार्ट मान अक्ष पर डिस्प्ले यूनिट निर्धारित करें**

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) का उपयोग करके मान अक्ष पर लेबल को डेटा बदले बिना स्केल किया जा सकता है। जब [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) को `Millions` पर सेट किया जाता है, तो 60,000,000 का मान 60 के रूप में प्रदर्शित होता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके ऊर्ध्वाधर अक्ष पर मिलियन डिस्प्ले यूनिट लागू करता है।

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

## **FAQ**

**मैं एक अक्ष को दूसरे के पार (अक्ष क्रॉसिंग) किस मान पर सेट करूँ?**

[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) का उपयोग करके क्रॉसिंग व्यवहार चुनें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिए [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) का उपयोग करें। ये सेटिंग्स आपको अक्ष के क्रॉसिंग को उपयुक्त बेसलाइन पर ले जाने देती हैं।

**मैं टिक लेबल को अक्ष के सापेक्ष कैसे स्थित करूँ?**

[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) को [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) के साथ उपयोग करें: `Low`, `High`, `NextTo`, या `None`। टिक‑मार्क स्वयं को नियंत्रित करने के लिए, [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) या [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) का उपयोग करें; ये लेबल पोजिशनिंग से अलग हैं।