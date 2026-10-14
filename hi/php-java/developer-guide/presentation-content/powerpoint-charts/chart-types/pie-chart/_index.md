---
title: PHP का उपयोग करके प्रस्तुतियों में पाई चार्ट को अनुकूलित करें
linktitle: पाई चार्ट
type: docs
url: /hi/php-java/pie-chart/
keywords:
- पाई चार्ट
- चार्ट प्रबंधन
- चार्ट अनुकूलन
- चार्ट विकल्प
- चार्ट सेटिंग्स
- प्लॉट विकल्प
- स्लाइस रंग
- पावरपॉइंट
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में पाई चार्ट बनाएं और अनुकूलित करें। द्वितीय प्लॉट कॉन्फ़िगर करें, डेटा लेबल प्रदर्शित करें, और PowerPoint में स्वचालित स्लाइस रंग लागू करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पाई चार्ट के साथ काम करने के तरीके को समझाता है। यह Pie of Pie और Bar of Pie चार्ट्स के लिए द्वितीय प्लॉट विकल्पों को कॉन्फ़िगर करने तथा एक मानक पाई चार्ट के लिए स्वचालित स्लाइस रंगिंग सक्षम करने का प्रदर्शन करता है।

उदाहरण चार्ट अनुकूलन कार्यों पर केंद्रित हैं, जैसे कि स्लाइड में चार्ट जोड़ना, श्रृंखला और लेबल सेटिंग्स को समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, और अपडेटेड प्रस्तुति को सहेजना।

## **पाई ऑफ पाई और बार ऑफ पाई चार्ट्स के लिए द्वितीय प्लॉट विकल्प**

Aspose.Slides for PHP via Java Pie of Pie और Bar of Pie चार्ट्स के लिए द्वितीय प्लॉट विकल्पों का समर्थन करता है। ये विकल्प द्वितीय प्लॉट का आकार और दो प्लॉट्स के बीच डेटा पॉइंट्स के विभाजन को नियंत्रित करते हैं।

निम्न उदाहरण एक नई प्रस्तुति में Pie of Pie चार्ट बनाता है और डेटा पॉइंट मूल्यों को लेबल के रूप में प्रदर्शित करता है। [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) मेथड मुख्य प्लॉट के 149% के रूप में द्वितीय प्लॉट आकार सेट करता है। [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) प्रतिशत-आधारित विभाजन चुनता है, और [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) थ्रेशोल्ड को 53% सेट करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // मान दर्शाएँ और द्वितीय प्लॉट कॉन्फ़िगर करें।
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **द्वितीय प्लॉट के लिए श्रेणियां चुनें**

जब आप द्वितीय प्लॉट में विशिष्ट श्रेणियों को उनके प्रतिशत मानों की परवाह किए बिना समूहित करना चाहते हैं, तब कस्टम स्प्लिटिंग का उपयोग करें। उदाहरण के लिए, एक बिक्री रिपोर्ट में Online और Events को साथ में दिखाया जा सकता है जिससे पाठक इन दो चैनलों की तुलना कर सकें, हालांकि वे कुल बिक्री के 35% और 10% के प्रतिनिधित्व करते हैं।

Call [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) के साथ [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) का उपयोग करें और [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) के माध्यम से पॉइंट चुनें। कलेक्शन का [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) मेथड श्रृंखला में शून्य-आधारित इंडेक्स स्वीकार करता है; डेटा पॉइंट ऑब्जेक्ट जोड़ने के लिए [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) का उपयोग करें। इस उदाहरण में, इंडेक्स 1 Online को चुनता है, और इंडेक्स 3 पर का पॉइंट Events को चुनता है। Partners को भी अस्थायी रूप से जोड़ा गया है, फिर उसे [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem) का उपयोग करके बाहर किया गया है।

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // डिफ़ॉल्ट डेटा को चैनल द्वारा बिक्री के साथ बदलें।
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Online को उसके शून्य-आधारित इंडेक्स द्वारा और Events को उसके डेटा पॉइंट ऑब्जेक्ट द्वारा चुनें।
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // स्रोत डेटा को हटाए बिना चयन से Partners को बाहर करें।
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) और Events (10) द्वितीय प्लॉट में अलग-अलग स्लाइस के रूप में दिखते हैं। प्राथमिक प्लॉट में, वे 45 मान वाले एक संयुक्त स्लाइस द्वारा प्रतिनिधित्व किए जाते हैं, साथ ही Retail (40) और Partners (15) भी। कस्टम चयन से Partners को हटाने से वह प्राथमिक प्लॉट में रहता है; यह श्रेणी या उसके मान को चार्ट के स्रोत डेटा से नहीं हटाता।

निम्न छवि PowerPoint में सहेजी गई प्रस्तुति को दर्शाती है:

![द्वितीय प्लॉट में Online और Events के साथ Pie of Pie चार्ट और प्राथमिक प्लॉट में उनका संयुक्त मान 45](pie_of_pie_custom.png)

## **स्वचालित पाई चार्ट स्लाइस रंग सेट करें**

Aspose.Slides for PHP via Java पाई चार्ट स्लाइस को स्वचालित रूप से विभिन्न रंग असाइन कर सकता है। निम्न उदाहरण केंद्रित शीर्षक के साथ एक पाई चार्ट बनाता है और डिफ़ॉल्ट डेटा को तीन त्रैमासिक श्रेणियों और उनके मानों से बदलता है। [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) मेथड मान 20, 50 और 30 को लेबल के रूप में दर्शाता है, जबकि [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) प्रत्येक स्लाइस के लिए एक विशिष्ट रंग सक्षम करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // एक केंद्रित चार्ट शीर्षक जोड़ें।
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // पहले कार्यपत्रक का उपयोग करके डिफ़ॉलट डेटा बदलें।
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // मान दिखाएँ और स्लाइसों को विभिन्न रंग आवंटित करें।
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Pie of Pie और Bar of Pie वेरिएंट्स समर्थित हैं?**

हाँ, लाइब्रेरी [समर्थित करता है](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) पाई चार्ट्स के लिए द्वितीय प्लॉट का समर्थन करती है, जिसमें Pie of Pie और Bar of Pie प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को एक छवि (उदाहरण के लिए, PNG) के रूप में निर्यात कर सकता हूँ?**

हाँ, आप पूरे प्रस्तुति को निर्यात किए बिना [चार्ट को स्वयं एक छवि के रूप में निर्यात करना](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (जैसे PNG) को एक छवि के रूप में निर्यात कर सकते हैं।