---
title: "PHP का उपयोग करके प्रस्तुतियों में चार्ट एक्सिस को अनुकूलित करें"
linktitle: "चार्ट एक्सिस"
type: docs
url: /hi/php-java/chart-axis/
keywords:
- "चार्ट एक्सिस"
- "ऊर्ध्वाधर एक्सिस"
- "क्षैतिज एक्सिस"
- "एक्सिस को अनुकूलित करें"
- "एक्सिस को नियंत्रित करें"
- "एक्सिस का प्रबंधन"
- "एक्सिस गुण"
- "अधिकतम मान"
- "न्यूनतम मान"
- "एक्सिस रेखा"
- "दिनांक प्रारूप"
- "एक्सिस शीर्षक"
- "एक्सिस स्थिति"
- "PowerPoint"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट एक्सिस को अनुकूलित करने हेतु जावा के माध्यम से PHP के लिए Aspose.Slides के उपयोग को जानें।"
---
## **सारांश**

यह लेख Aspose.Slides for PHP via Java का उपयोग करके चार्ट की एक्सिस को अनुकूलित करने का तरीका समझाता है। यह गणना किए गए एक्सिस मान, चार्ट की पंक्तियों और स्तंभों को बदलना, एक्सिस की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियां और फ़ॉर्मेटिंग, शीर्षक का घुमाव, एक्सिस की स्थिति, प्रदर्शन इकाइयाँ, और लघुगणकीय स्केलिंग को कवर करता है।

## **चार्ट में लंबवत एक्सिस पर अधिकतम मान प्राप्त करें**

एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) बनाइए और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़िए। गणना किए गए एक्सिस मान पढ़ने से पहले [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) को कॉल करें ताकि चार्ट लेआउट अद्यतन हो।

एक्सिस सीमाओं के लिए [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) और [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) पढ़ें, और टिक अंतराल के लिए [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) तथा [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) पढ़ें। [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) और [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि एक्सिस के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय परिवर्तनीयों में संग्रहीत करता है और चार्ट को सहेजता है।

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

## **एक्सिस के बीच डेटा अदल‑बदल करें**

चार्ट डेटा में सीरीज़ और श्रेणियों की भूमिकाओं को बदलने के लिए [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) का उपयोग करें। प्रत्येक पूर्व श्रेणी एक सीरीज़ बन जाती है, और प्रत्येक पूर्व सीरीज़ एक श्रेणी बन जाती है। यह डेटा के समूह बनाने के तरीके को बदलता है; यह क्षैतिज और लंबवत एक्सिस को नहीं बदलता। उदाहरण पंक्तियों और स्तंभों को बदलने से पहले डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करने के लिए [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) का उपयोग करता है, जिसमें हेडर पंक्ति और श्रेणी स्तंभ शामिल हैं। यह चार सीरीज़ और तीन श्रेणियों के साथ चार्ट को सहेजता है।

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

## **एक्सिस के प्लॉटिंग क्रम को उल्टा करें**

[setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) का उपयोग करके किसी श्रेणी या मान एक्सिस को उल्टा करें। उदाहरण के लिए, एक क्षैतिज बार चार्ट प्रोजेक्ट चरणों को शीर्ष से नीचे तक कार्यपत्र के समान क्रम में दिखा सकता है: Planning, Development, Testing। एक्सिस को उल्टा करने से प्लॉटिंग दिशा बदलती है; यह वर्कबुक डेटा को सॉर्ट या पुनः व्यवस्थित नहीं करता। तुलना में, [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) सीरीज़ और श्रेणियों की भूमिकाओं को बदलता है।

निम्न उदाहरण तीन चरणों और एक सीरीज़ के साथ एक क्षैतिज बार चार्ट बनाता है। यह तीन स्लाइडों के साथ एक प्रस्तुति सहेजता है: सामान्य क्रम, उल्टे श्रेणियां, और उल्टे मान। प्रत्येक प्रति समान डेटा सेट का उपयोग करती है, और प्रत्येक प्रति में केवल एक एक्सिस उल्टा किया जाता है।

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

    // स्लाइड 2: पहली श्रेणी को शीर्ष पर प्रदर्शित करें।
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // क्षैतिज मान एक्सिस को नीचे रखें।
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // स्लाइड 3: केवल क्षैतिज संख्यात्मक स्केल को उल्टा करें।
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

एक्सिस को उल्टा करने से लम्बवत एक्सिस को प्लॉट के विपरीत पक्ष में भी ले जाया जा सकता है। [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) नियंत्रित करता है कि कॉन्फ़िगर किए जा रहे एक्सिस को दूसरा एक्सिस कहाँ काटता है। स्लाइड 2 में, उलटी श्रेणी एक्सिस पर `CrossesType::Maximum` के साथ इसे कॉल करने से क्षैतिज मान एक्सिस नीचे रहता है। एक विशिष्ट क्रॉसिंग बिंदु के लिए, [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) का उपयोग करें। दिशा बदलते समय क्रॉसिंग सेटिंग्स जांचें, विशेषकर यदि चार्ट में पहले से एक कस्टम क्रॉसिंग बिंदु है। सामान्य प्लॉटिंग दिशा को बहाल करने के लिए `setPlotOrderReversed` को `false` के साथ कॉल करें; क्रॉसिंग सेटिंग्स स्वतंत्र हैं।

| सामान्य क्रम (स्लाइड 1) | उल्टे श्रेणियां (स्लाइड 2) | उल्टे मान (स्लाइड 3) |
| --- | --- | --- |
| ![सामान्य श्रेणी और मान एक्सिस क्रम के साथ क्षैतिज बार चार्ट](axis-order-normal.png) | ![ऊपर से नीचे तक श्रेणियों के साथ क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![उल्टा मान एक्सिस और दाएँ शून्य के साथ क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियां नीचे से ऊपर चलती हैं; मान बाएँ से दाएँ बढ़ते हैं। | Planning, Development, और Testing शीर्ष से नीचे चलते हैं। मान और वर्कबुक पंक्ति क्रम अपरिवर्तित रहता है। | श्रेणियां अपना सामान्य क्रम बरकरार रखती हैं; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी एक्सिस दाएँ शून्य पर मिलती है। |

## **लाइन चार्ट के लिए लंबवत एक्सिस अक्षम करें**

[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) को लंबवत एक्सिस पर `false` के साथ कॉल करके इसे छिपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और लंबवत एक्सिस को छिपाकर सहेजता है।

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

## **लाइन चार्ट के लिए क्षैतिज एक्सिस अक्षम करें**

[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) को क्षैतिज एक्सिस पर `false` के साथ कॉल करके इसे छिपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और क्षैतिज एक्सिस को छिपाकर सहेजता है।

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

## **श्रेणी एक्सिस बदलें**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) का उपयोग करके तिथि या टेक्स्ट श्रेणी एक्सिस चुनें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें पहले स्लाइड पर पहला आकार एक चार्ट है और श्रेणी कोशिकाओं में संख्यात्मक Excel तिथि मान होते हैं। यह क्षैतिज एक्सिस को तिथि एक्सिस में बदलता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) को `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) को `1`, और [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) को `TimeUnitType::Months` के साथ कॉल करने से प्रमुख टिक एक‑महीने के अंतराल पर रखे जाते हैं।

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

## **श्रेणी एक्सिस लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियां हों, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दृश्य एक्सिस लेबलों की संख्या कम करें। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) को `false` के साथ कॉल करें, फिर इच्छित श्रेणी अंतराल [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) को पास करें। सामान्य क्रम में टेक्स्ट श्रेणियों के लिए, गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में दिखाए गए लेबल |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` का अंतराल हर तीसरा लेबल दिखाता है, प्रदर्शित लेबलों के बीच दो लेबल छुपे रहते हैं। यह संबंधित स्तंभों को नहीं हटाता। स्वचालित अंतराल उपलब्ध स्थान के आधार पर चुनता है; यह अनिवार्य रूप से हर लेबल नहीं दिखाता।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) को `false` के साथ कॉल करें और उनके अंतराल को सेट करने के लिए [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) का उपयोग करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर टिक‑मार्क रखता है जबकि लेबल केवल हर तीसरी श्रेणी पर दिखते हैं। परिणाम देखने के लिए एक दृश्यमान शैली के साथ [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) का उपयोग करें। फिर से `true` के साथ किसी भी स्वचालित‑अंतराल सेटटर को कॉल करने से चार्ट को वह अंतराल फिर से चुनने दिया जाता है।

निम्न स्वयं‑समाविष्ट उदाहरण 24 श्रेणियां और एक सीरीज़ बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित अंतराल, स्वतंत्र टिक‑मार्क के साथ मैन्युअल लेबल अंतराल, और पुनर्स्थापित स्वचालित अंतराल। दोनों प्रतियां मूल चार्ट डेटा को बरकरार रखती हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व में अंतर को स्पष्ट रूप से दिखाता है।

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

    // स्लाइड 2: हर तीसरा लेबल दिखाएं, लेकिन प्रत्येक श्रेणी के लिए एक टिक‑मार्क रखें।
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

**स्वचालित अंतराल (स्लाइड 1):** इस रेंडरिंग में हर दूसरा श्रेणी लेबल दिखाया जाता है और दो पंक्तियों में लपेटा जाता है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![स्वचालित श्रेणी लेबल अंतराल जिसमें सभी 24 स्तंभ दिखे हुए हैं](category-axis-automatic.png)

**मैन्युअल अंतराल (स्लाइड 2):** हर तीसरा लेबल एक पंक्ति पर दिखाया जाता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बना रहता है। सभी 24 स्तंभ, जिसमें बिना लेबल वाले भी शामिल हैं, समान मानों के साथ दिखते हैं। स्लाइड 3 ऊपर दिखाए गए स्वचालित स्वरूप को पुनर्स्थापित करता है।

![तीन के मैन्युअल श्रेणी लेबल अंतराल के साथ सभी 24 स्तंभ दिखे हुए](category-axis-manual.png)

### **सही एक्सिस और अंतराल चुनें**

टेक्स्ट श्रेणी एक्सिस के लिए इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे कॉलम, लाइन, एरिया, या बार चार्ट का श्रेणी एक्सिस। कॉलम चार्ट में यह क्षैतिज एक्सिस होता है। क्षैतिज बार चार्ट में श्रेणी एक्सिस लंबवत होता है, इसलिए इन सेटिंग्स को [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) द्वारा लौटाए गए एक्सिस पर लागू करें। टिक‑मार्क अंतराल उन चार्टों में सीरीज़ एक्सिस पर भी लागू होता है जिनमें वह होता है।

श्रेणी लेबल अंतराल का उपयोग मान एक्सिस के संख्यात्मक स्केल को सेट करने के लिए न करें। मान एक्सिस पर, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिए, `10` का प्रमुख इकाई शून्य से शुरू होने पर 0, 10, 20 आदि पर टिक बनाता है। `3` का श्रेणी लेबल अंतराल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट टेक्स्ट श्रेणी एक्सिस के बजाय मान एक्सिस का उपयोग करते हैं। तिथि एक्सिस के लिए, समय‑आधारित प्रमुख इकाइयों और स्केल का उपयोग करें जैसा कि [श्रेणी एक्सिस बदलें](#change-a-category-axis) में वर्णित है।

## **श्रेणी एक्सिस मानों के लिए तिथि फ़ॉर्मेट सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियां पहली वर्कशीट (इंडेक्स `0`) में OLE Automation क्रमांक के रूप में संग्रहित हैं, जो 30 दिसंबर 1899 से दिनों की संख्या के रूप में गणना की गई हैं। [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) को `CategoryAxisType::Date` के साथ उपयोग करें, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) को `false` के साथ कॉल करें, और [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) को `yyyy` पास करें ताकि श्रेणी लेबल सेल फ़ॉर्मेट से स्वतंत्र रूप से चार-अंकीय वर्ष दिखाएँ।

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

## **चार्ट एक्सिस शीर्षक के लिए घुमाव कोण सेट करें**

लंबवत एक्सिस पर `true` के साथ [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) को कॉल करें, शीर्षक टेक्स्ट प्रदान करें, और शीर्षक को घुमाने के लिए [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) का उपयोग करें। यह कोण डिग्री में मापा जाता है; यह उदाहरण अपने मान‑एक्सिस शीर्षक को 90 डिग्री घुमा कर एक कॉलम चार्ट सहेजता है।

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

## **श्रेणी या मान एक्सिस पर एक्सिस स्थिति सेट करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) का उपयोग करके नियंत्रित करें कि मान एक्सिस श्रेणी एक्सिस को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर काटता है। यह सेटिंग श्रेणी एक्सिस पर लागू होती है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी एक्सिस पर `true` सेट करता है और परिणाम सहेजता है।

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

## **चार्ट मान एक्सिस पर डिस्प्ले यूनिट सेट करें**

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) का उपयोग करके मान एक्सिस पर लेबलों को स्केल करें बिना अधीन डेटा बदले। जब [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) को `Millions` सेट किया जाता है, तो 60,000,000 का मान 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके लंबवत एक्सिस पर मिलियन डिस्प्ले यूनिट लागू करता है।

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

## **लघुगणकीय मान एक्सिस को कॉन्फ़िगर करें**

लघुगणकीय मान एक्सिस तब उपयोगी होता है जब सकारात्मक मान कई क्रमों में विस्तारित होते हैं। उदाहरण के लिए, एक सेवा पाँच अवधियों में 10, 100, 1,000, 10,000, और 100,000 अनुरोध प्राप्त कर सकती है। रैखिक पैमाने पर छोटे मान शून्य के निकट साथ-साथ दिखते हैं। लघुगणकीय स्केल उनके सापेक्ष विकास को तुलना करना आसान बनाता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

मान एक्सिस पर `true` के साथ [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) को कॉल करें और आधार चुनने के लिए [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) का उपयोग करें। यह मौजूदा मानों के प्रदर्शित होने के तरीके को बदलता है; यह डेटा नहीं बदलता या लघुगणकीय ट्रेंड लाइन नहीं जोड़ता। ट्रेंड लाइन डेटा में फिटेड संबंध को दर्शाती है और एक अलग सुविधा है।

### **मान एक्सिस और आधार चुनें**

लाइन या कॉलम चार्ट के लिए, मान एक्सिस [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) द्वारा लौटाया जाता है। क्षैतिज बार चार्ट के लिए, यह [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) द्वारा लौटाया जाता है। स्कैटर और बबल चार्ट में दो मान एक्सिस होते हैं, इसलिए X मानों के लिए क्षैतिज एक्सिस, Y मानों के लिए लंबवत एक्सिस, या दोनों चुनें। श्रेणी एक्सिस पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय आधार `10` है। PPTX चार्ट्स के लिए, `2` से `1000` तक का आधार उपयोग करें, शामिल; भिन्नात्मक आधार जैसे `2.5` भी समर्थित हैं। आधार `10` के साथ, क्रमिक घात जैसे 10, 100, 1,000, और 10,000 समान दूरी पर होते हैं।

### **रैखिक और लघुगणकीय स्केलिंग की तुलना**

निम्न स्वयं‑समाविष्ट उदाहरण पहले स्लाइड पर पाँच अनुरोध गिनती के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड की प्रति बनाता है और दूसरे पर आधार‑10 लघुगणकीय मान एक्सिस सक्षम करता है। दोनों स्लाइड्स समान डेटा बरकरार रखती हैं।

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

    // पहले स्लाइड को रैखिक रखें और केवल कॉपी के मान‑एक्सिस स्केल को बदलें।
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

**रेखीय स्केल (स्लाइड 1):** समान ऊर्ध्वाधर दूरी अनुरोध गिनती में समान अंतर दर्शाती है। सबसे बड़ा मान चार्ट पर हावी होता है, जिससे छोटे मानों को अलग पहचानना कठिन हो जाता है।

![रैखिक मान एक्सिस पर पाँच अनुरोध गिनती दिखाने वाला PowerPoint में लाइन चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊर्ध्वाधर दूरी समान अनुपात दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु आधार‑10 स्केल पर एक सीधी उठती रेखा बनाते हैं। एक्सिस लेबल अभी भी मूल अनुरोध गिनती दिखाते हैं।

![PowerPoint में वही पाँच अनुरोध गिनती आधार‑10 लघुगणकीय मान एक्सिस पर](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल शुद्ध सकारात्मक मान दिखा सकता है। इसे सक्षम करने से पहले डेटा जांचें। यदि शून्य या नकारात्मक मान महत्वपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि विश्लेषण के लिए उन मानों को बाहर करना उपयुक्त है, तो अपवाद का कारण बताएं। उन्हें चुपचाप छोटे सकारात्मक संख्याओं से न बदलें, क्योंकि यह डेटा का अर्थ बदल देता है। लघुगणकीय एक्सिस के लिए मैन्युअल रूप से निर्धारित न्यूनतम या अधिकतम भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं किसी एक्सिस को दूसरे के साथ किस मान पर काटता हूँ (एक्सिस क्रॉसिंग) को कैसे सेट करूँ?**  
[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) का उपयोग करके क्रॉसिंग व्यवहार चुनें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिए [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) का उपयोग करें। ये सेटिंग्स आपको एक्सिस क्रॉसिंग को एक उपयुक्त बेसलाइन पर ले जाने देती हैं।

**मैं एक्सिस के सापेक्ष टिक लेबल को कैसे स्थित करूँ?**  
[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) को [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) के साथ कॉल करें: `Low`, `High`, `NextTo`, या `None`। टिक‑मार्क को स्वयं नियंत्रित करने के लिए, [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) या [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) का उपयोग करें; ये लेबल स्थिति से अलग हैं।