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
- अक्ष को हेरफेर करें
- अक्ष का प्रबंधन करें
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
description: "Aspose.Slides for PHP via Java का उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करने के तरीके की खोज करें।"
---
## **परिचय**

यह लेख Aspose.Slides for PHP via Java का उपयोग करके चार्ट अक्षों को अनुकूलित करने के तरीके को समझाता है। यह गणना किए गए अक्ष मानों, चार्ट पंक्तियों और स्तंभों को बदलने, अक्ष दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियों और स्वरूपण, शीर्षक घूर्णन, अक्ष स्थिति, प्रदर्शन इकाइयाँ, और लघुगणकीय स्केलिंग को कवर करता है।

## **चार्ट्स में वर्टिकल अक्ष पर अधिकतम मान प्राप्त करें**

एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) बनाएं और डिफॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) को कॉल करें ताकि चार्ट लेआउट अद्यतन रहे।

अक्ष सीमाओं के लिए [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) और [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) पढ़ें, तथा टिक अंतराल के लिए [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) और [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) पढ़ें। [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) और [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक होते हैं। उदाहरण इन मानों को स्थानीय परिवर्तनीयों में संग्रहीत करता है और चार्ट को सहेजता है।

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

## **अक्षों के बीच डेटा स्वैप करें**

चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाओं को बदलने के लिए [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) का उपयोग करें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा के समूह को बदलता है; यह क्षैतिज और वर्टिकल अक्षों को नहीं बदलता। उदाहरण डिफॉल्ट डेटा को `Sheet1!A1:D5` से बंधित करने के लिए [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) का उपयोग करता है, जिसमें हेडर पंक्ति और श्रेणी स्तंभ शामिल है, पंक्तियों और स्तंभों को स्विच करने से पहले। यह चार श्रृंखला और तीन श्रेणियों वाला चार्ट सहेजता है।

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

## **लाइन चार्ट्स के लिए वर्टिकल अक्ष अक्षम करें**

[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) को `false` के साथ वर्टिकल अक्ष पर कॉल करें ताकि वह छिपा रहे। उदाहरण डिफॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और वर्टिकल अक्ष छिपा हुए सहेजता है।

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

## **लाइन चार्ट्स के लिए क्षैतिज अक्ष अक्षम करें**

[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) को `false` के साथ क्षैतिज अक्ष पर कॉल करें ताकि वह छिपा रहे। उदाहरण डिफॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और क्षैतिज अक्ष छिपा हुए सहेजता है।

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

## **एक श्रेणी अक्ष बदलें**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) का उपयोग करके तिथि या पाठ श्रेणी अक्ष चुनें। इस उदाहरण को `ExistingChart.pptx` की आवश्यकता होती है, जिसमें पहले स्लाइड पर पहला आकार चार्ट है और श्रेणी कोशिकाओं में संख्यात्मक Excel तिथि मान होते हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) को `false` के साथ, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) को `1` के साथ, और [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) को `TimeUnitType::Months` के साथ कॉल करने से प्रमुख टिक एक‑माह अंतराल पर रखे जाते हैं।

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

जब किसी चार्ट में कई श्रेणियाँ होती हैं, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दृश्यमान अक्ष लेबलों की संख्या को कम करें। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) को `false` के साथ कॉल करें, फिर वांछित श्रेणी अंतराल को [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) को पास करें। सामान्य क्रम में पाठ श्रेणियों के लिए गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, ... श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, ... श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, ... श्रेणी 22 |

`3` का अंतराल प्रत्येक तीसरे लेबल को प्रदर्शित करता है, प्रदर्शित लेबलों के बीच दो लेबल छिपे रहते हैं। यह संबंधित स्तंभों को नहीं हटाता। स्वचलित अंतराल उपलब्ध स्थान के आधार पर चुना जाता है; यह जरूरी नहीं कि हर लेबल दिखे।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) को `false` के साथ कॉल करें और [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) का उपयोग करके उनका अंतराल सेट करें। उदाहरण के रूप में, `1` हर श्रेणी अंतराल पर एक टिक‑मार्क रखता है जबकि लेबल केवल हर तीसरी श्रेणी पर दिखते हैं। दृश्यमान शैली के साथ [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) का उपयोग करें ताकि परिणाम देखा जा सके। स्वचलित‑अंतराल सेटर को `true` फिर से सेट करने से चार्ट को वही अंतराल चुनने की अनुमति मिलती है।

निम्न स्वनिर्भर उदाहरण 24 श्रेणियों और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचलित अंतराल, स्वतंत्र टिक‑मार्क के साथ मैनुअल लेबल अंतराल, और पुनर्स्थापित स्वचलित अंतराल। दोनों प्रतियां मूल चार्ट डेटा को बरकरार रखती हैं। इनपुट प्रेजेंटेशन की आवश्यकता नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व में अंतर को स्पष्ट देखाता है।

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

    // Slide 2: हर तीसरे लेबल को दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए एक टिक‑मार्क रखें.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Slide 3: चार्ट को फिर से दोनों अंतराल चुनने दें.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**स्वचलित अंतराल (स्लाइड 1):** इस रेंडरिंग में हर दूसरी श्रेणी लेबल प्रदर्शित होती है और दो पंक्तियों में लपेटती है। स्वचलित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार भिन्न हो सकता है।

![स्वचलित श्रेणी लेबल अंतराल जिसमें सभी 24 स्तंभ दिखाई देते हैं](category-axis-automatic.png)

**हस्तचालित अंतराल (स्लाइड 2):** हर तीसरा लेबल एक पंक्ति पर प्रदर्शित होता है, जबकि टिक‑मार्क हर श्रेणी अंतराल पर बने रहते हैं। सभी 24 स्तंभ, जिसमें बिना लेबल वाले भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 ऊपर दिखाए गए स्वचलित रूप को पुनर्स्थापित करती है।

![हस्तचालित श्रेणी लेबल अंतराल तीन के साथ जिसमें सभी 24 स्तंभ दिखाई देते हैं](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

पाठ श्रेणी अक्ष के लिए इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे कि कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष वर्टिकल होता है, इसलिए इन सेटिंग्स को [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) द्वारा लौटाए गए अक्ष पर लागू करें। टिक‑मार्क अंतराल उन चार्ट्स में श्रृंखला अक्ष पर भी लागू होता है जिनमें वह मौजूद हो।

श्रेणी लेबल अंतराल का उपयोग मान अक्ष की संख्यात्मक स्केल सेट करने के लिए न करें। मान अक्ष पर, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) मानों में अंतर निर्दिष्ट करता है: उदाहरण के लिए, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों को नहीं। स्कैटर और बबल चार्ट्स टेक्स्ट श्रेणी अक्ष के बजाय मान अक्षों का उपयोग करते हैं। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयों और स्केलों का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

उदाहरण डिफॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियां पहली वर्कशीट (इंडेक्स `0`) में OLE Automation सीरियल नंबर के रूप में संग्रहीत होती हैं, जो 30 दिसंबर 1899 से दिनों की संख्या के रूप में गणना होती हैं। [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) को `CategoryAxisType::Date` के साथ, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) को `false` के साथ, और `yyyy` को [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) को पास करके श्रेणी लेबल को सेल स्वरूपण से स्वतंत्र रूप से चार-अंकीय वर्ष दिखाने के लिए सेट करें।

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

वर्टिकल अक्ष पर शीर्षक को सक्रिय करने के लिए `true` के साथ [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) कॉल करें, शीर्षक पाठ प्रदान करें, और [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) का उपयोग करके शीर्षक को घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण एक कॉलम चार्ट को उसके मान‑अक्ष शीर्षक को 90 डिग्री घुमा कर सहेजता है।

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

## **श्रेणी या मान अक्ष पर अक्ष स्थिति सेट करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) का उपयोग करके तय करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर पार करे। यह सेटिंग केवल श्रेणी अक्षों पर लागू होती है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `true` सेट करता है और परिणाम सहेजता है।

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

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) का उपयोग करके मूल डेटा को बदले बिना मान अक्ष पर लेबल को स्केल करें। जब [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) को `Millions` पर सेट किया जाता है, तो 60,000,000 का मान 60 के रूप में दिखता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके वर्टिकल अक्ष पर मिलियन प्रदर्शन इकाई लागू करता है।

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

## **लघुगणकीय मान अक्ष को कॉन्फ़िगर करें**

लघुगणकीय मान अक्ष तब उपयोगी होता है जब सकारात्मक मान कई क्रम में विस्तारित हों। उदाहरण के लिए, एक सेवा पाँच अवधियों में 10, 100, 1,000, 10,000 और 100,000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट एक साथ दिखते हैं। लघुगणकीय स्केल उनके सापेक्ष विकास को तुलना करने में आसान बनाता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

मान अक्ष पर [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) को `true` के साथ कॉल करें और बेस चुनने के लिए [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) का उपयोग करें। यह मौजूदा मानों के प्रदर्शित होने के तरीके को बदलता है; यह डेटा बदलता नहीं या लघुगणकीय ट्रेंड लाइन नहीं जोड़ता। ट्रेंड लाइन डेटा में फिटेड संबंध का प्रतिनिधित्व करती है और एक अलग विशेषता है।

### **मान अक्ष और आधार चुनें**

लाइन या कॉलम चार्ट के लिए मान अक्ष [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) द्वारा लौटाया जाता है। क्षैतिज बार चार्ट के लिए यह [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) द्वारा लौटाया जाता है। स्कैटर और बबल चार्ट्स में दो मान अक्ष होते हैं, इसलिए X मानों के लिए क्षैतिज अक्ष, Y मानों के लिए वर्टिकल अक्ष या दोनों चुनें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग लागू न करें।

डिफॉल्ट लघुगणकीय आधार `10` है। PPTX चार्ट्स के लिए बेस `2` से `1000` तक, समावेशी, प्रयोग किया जा सकता है; अंशीय बेस जैसे `2.5` भी समर्थित हैं। बेस `10` के साथ क्रमिक शक्तियां जैसे 10, 100, 1,000, और 10,000 समान दूरी पर होती हैं।

### **रैखिक और लघुगणकीय स्केलिंग की तुलना**

निम्न स्वनिर्भर उदाहरण पहले स्लाइड पर पाँच अनुरोध गणनाओं के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन करता है और दूसरे स्लाइड पर बेस‑10 लघुगणकीय मान अक्ष को सक्षम करता है। दोनों स्लाइड एक ही डेटा रखती हैं।

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

    // पहली स्लाइड को रैखिक रखें और केवल प्रतिलिपि के मान-अक्ष स्केल को बदलें।
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

**रैखिक स्केल (स्लाइड 1):** समान ऊर्ध्वाधर दूरी अनुरोध गणनाओं के समान अंतर को दर्शाती है। सबसे बड़ा मान चार्ट को प्रभुत्व देता है, जिससे छोटे मानों को अलग करना कठिन हो जाता है।

![लाइन चार्ट जिसमें रैखिक मान अक्ष पर पाँच अनुरोध गणनाएँ दिखती हैं](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊर्ध्वाधर दूरी समान अनुपात को दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु बेस‑10 स्केल पर एक सीधी बढ़ती रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गणनाएँ दिखाते हैं।

![एक ही पाँच अनुरोध गणनाएँ PowerPoint में बेस‑10 लघुगणकीय मान अक्ष पर दिखती हैं](value-axis-logarithmic.png)

### **शून्य और ऋणात्मक मानों को संभालें**

लघुगणकीय स्केल केवल शून्य से बड़े मानों को दर्शा सकता है। इसे सक्षम करने से पहले डेटा जांचें। यदि शून्य या ऋणात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से प्रदर्शित करें। यदि विश्लेषण के लिए उन मानों को बाहर करना उपयुक्त है, तो अपवाद को समझाते हुए बताएं। उन्हें छोटे सकारात्मक नंबरों से चुपचाप बदलना डेटा की अर्थव्याख्या बदल देता है। लघुगणकीय अक्ष के किसी भी मैन्युअल न्यूनतम या अधिकतम को भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं एक अक्ष का दूसरा अक्ष को पार करने का मान कैसे सेट करूँ (अक्ष क्रॉसिंग)?**

एक्स़िंग व्यवहार चुनने के लिए [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) का उपयोग करें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिए [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) का उपयोग करें। ये सेटिंग्स आपको अक्ष क्रॉसिंग को उपयुक्त बेसलाइन पर ले जाने की अनुमति देती हैं।

**मैं अक्ष के सापेक्ष टिक लेबलों को कैसे स्थित करूँ?**

[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) को [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) के साथ कॉल करें: `Low`, `High`, `NextTo`, या `None`। टिक‑मार्क को नियंत्रित करने के लिए, [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) या [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) का उपयोग करें; ये लेबल स्थिति से अलग होते हैं।