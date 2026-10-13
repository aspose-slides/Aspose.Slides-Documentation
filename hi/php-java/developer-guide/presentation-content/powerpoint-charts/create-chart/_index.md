---
title: PHP में PowerPoint प्रस्तुति चार्ट बनाना या अपडेट करना
linktitle: चार्ट बनाना या अपडेट करना
type: docs
weight: 10
url: /hi/php-java/create-chart/
keywords:
- चार्ट जोड़ें
- चार्ट बनाएं
- चार्ट संपादित करें
- चार्ट बदलें
- चार्ट अपडेट करें
- स्कैटर चार्ट
- पाई चार्ट
- लाइन चार्ट
- ट्री मैप चार्ट
- स्टॉक चार्ट
- बॉक्स एंड व्हिस्कर चार्ट
- फ़नल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- मल्टीकैटेगरी चार्ट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। PHP में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, स्वरूपित करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for PHP via Java का उपयोग करके चार्ट बनाना और अनुकूलित करना कैसे किया जाता है, इस पर एक व्यापक गाइड प्रदान करता है। आप सीखेंगे कि कैसे प्रोग्रामेटिकली एक स्लाइड में चार्ट जोड़ा जाए, उसे डेटा से भरा जाए, और विभिन्न फॉर्मेटिंग विकल्पों को लागू किया जाए ताकि आपके विशिष्ट डिजाइन आवश्यकताओं से मेल खाए। लेख के दौरान, विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रस्तुति और चार्ट ऑब्जेक्ट को प्रारंभ करने से लेकर सीरीज़, एक्सिस, और लीजेंड को कॉन्फ़िगर करने तक। इस गाइड का पालन करके, आप अपने PHP अनुप्रयोगों में डायनामिक चार्ट जनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा‑ड्रिवन प्रस्तुतियों को बनाना आसान हो जाएगा।

## **चार्ट बनाना**

चार्ट लोगों को डेटा को जल्दी से विज़ुअलाइज़ करने और ऐसे अंतर्दृष्टि प्राप्त करने में मदद करते हैं जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं हो सकते।

**चार्ट क्यों बनाएं?**

* एक प्रस्तुति में एक ही स्लाइड पर बड़े पैमाने पर डेटा को संकुचित, संक्षिप्त या सारांशित करना;
* डेटा में पैटर्न और रुझान उजागर करना;
* समय के साथ या किसी विशिष्ट माप इकाई के सापेक्ष डेटा की दिशा और गति का अनुमान लगाना;
* आउट्लायर, विचलन, त्रुटियों और बेतुके डेटा को पहचानना;
* जटिल डेटा को संप्रेषित या प्रस्तुत करना।

PowerPoint में, आप *Insert* फ़ंक्शन के माध्यम से चार्ट बना सकते हैं, जो कई प्रकार के चार्ट डिजाइन करने के लिए टेम्पलेट प्रदान करता है। Aspose.Slides का उपयोग करके, आप सामान्य चार्ट (प्रचलित चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" title="Note" %}}
उपयोग करें [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) enumeration को [aspose\slides](https://reference.aspose.com/slides/php-java/aspose.slides/) namespace में। इस enumeration में मान विभिन्न चार्ट प्रकारों के अनुरूप होते हैं।
{{% /alert %}}

### **क्लस्टर कॉलम चार्ट बनाना**

यह उदाहरण [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) का उपयोग करके एक क्लस्टर कॉलम चार्ट बनाता है जो तीन श्रेणियों में दो सीरीज़ की तुलना करता है। सीरीज़ लाल और हरे रंग से भरी जाती हैं, और व्यक्तिगत लेबल श्रेणी नाम, सीरीज़ नाम, और मान प्रदर्शित करते हैं। वर्कशीट इंडेक्स 0 एम्बेडेड चार्ट वर्कबुक की पहली शीट को संदर्भित करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $categoryCell = $workbook->getCell($worksheetIndex, 1, 0, "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 2, 0, "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 3, 0, "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 20);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 50);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 0, 0);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $series = $chart->getChartData()->getSeries()->get_Item(1);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 2, 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 2, 10);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 2, 60);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 128, 0);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $label = $series->getDataPoints()->get_Item(0)->getLabel();
    $label->getDataLabelFormat()->setShowCategoryName(true);

    $label = $series->getDataPoints()->get_Item(1)->getLabel();
    $label->getDataLabelFormat()->setShowSeriesName(true);

    $label = $series->getDataPoints()->get_Item(2)->getLabel();
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setShowSeriesName(true);
    $label->getDataLabelFormat()->setSeparator("/");

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![क्लस्टर कॉलम चार्ट](clustered_column_chart.png)

### **स्कैटर चार्ट बनाना**

स्कैटर चार्ट (जिसे स्कैटर प्लॉट या x‑y ग्राफ भी कहा जाता है) अक्सर दो चरों के बीच पैटर्न या सहसंबंध जांचने के लिए उपयोग किए जाते हैं।

स्कैटर चार्ट तब उपयोग करें जब:

* आपके पास युग्मित संख्यात्मक डेटा हो।
* दो चर एक साथ अच्छी तरह से पेयर हों।
* आप यह निर्धारित करना चाहते हों कि दो चर संबंधित हैं या नहीं।
* आपके पास एक स्वतंत्र चर हो जिसके कई मान हों किसी आश्रित चर के लिए।

यह उदाहरण दो सेट के x‑y मानों को प्लॉट करता है। पहली सीरीज़ सीधी लाइनों के साथ स्टार मार्कर का उपयोग करती है, जबकि दूसरी स्मूद लाइनों के साथ सर्कल मार्कर का उपयोग करती है; दोनों की मार्कर आकार 10 है, जिसे [setSize](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsize/) से कॉन्फ़िगर किया गया है। [setSymbol](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsymbol/) मेथड मार्कर आकार को नियंत्रित करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\MarkerStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 20, 20, 500, 300);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, 1, 1, "Series 1");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());
    $seriesNameCell = $workbook->getCell($worksheetIndex, 1, 3, "Series 2");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $xValueCell = $workbook->getCell($worksheetIndex, 2, 1, 1);
    $yValueCell = $workbook->getCell($worksheetIndex, 2, 2, 3);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 3, 1, 2);
    $yValueCell = $workbook->getCell($worksheetIndex, 3, 2, 10);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);

    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);

    $series = $chart->getChartData()->getSeries()->get_Item(1);

    $xValueCell = $workbook->getCell($worksheetIndex, 2, 3, 5);
    $yValueCell = $workbook->getCell($worksheetIndex, 2, 4, 2);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 3, 3, 3);
    $yValueCell = $workbook->getCell($worksheetIndex, 3, 4, 1);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 4, 3, 2);
    $yValueCell = $workbook->getCell($worksheetIndex, 4, 4, 2);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 5, 3, 5);
    $yValueCell = $workbook->getCell($worksheetIndex, 5, 4, 1);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![स्कैटर चार्ट](scatter_chart.png)

### **पाई चार्ट बनाना**

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेषकर जब डेटा में श्रेणीबद्ध लेबल और संख्यात्मक मान होते हैं। हालांकि, यदि आपके डेटा में बहुत अधिक भाग या लेबल हों, तो बार चार्ट पर विचार किया जा सकता है।

यह उदाहरण तीन त्रिमासिक मानों के साथ एक पाई चार्ट बनाता है। प्रत्येक स्लाइस का कस्टम फ़िल और बॉर्डर है, और लेबल विभिन्न संयोजन में मान, प्रतिशत, और सीरीज़ जानकारी दिखाते हैं। [setFirstSliceAngle](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setfirstsliceangle/) मेथड पहला स्लाइस 180 डिग्री पर शुरू करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 20, 20, 500, 300);

    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $categoryCell = $workbook->getCell(0, 1, 0, "1st Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 2, 0, "2nd Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 3, 0, "3rd Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 20);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 50);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 30);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);

    $firstSlice = $series->getDataPoints()->get_Item(0);
    $firstSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 255, 255);
    $firstSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $firstSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 128, 128, 128);
    $firstSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $firstSlice->getFormat()->getLine()->setWidth(3.0);
    $firstSlice->getFormat()->getLine()->setStyle(LineStyle::ThinThick);
    $firstSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDash);

    $secondSlice = $series->getDataPoints()->get_Item(1);
    $secondSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $secondSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $secondSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 0, 255);
    $secondSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $secondSlice->getFormat()->getLine()->setWidth(3.0);
    $secondSlice->getFormat()->getLine()->setStyle(LineStyle::Single);
    $secondSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDashDot);

    $thirdSlice = $series->getDataPoints()->get_Item(2);
    $thirdSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 127, 80);
    $thirdSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $thirdSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 0, 0);
    $thirdSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $thirdSlice->getFormat()->getLine()->setWidth(2.0);
    $thirdSlice->getFormat()->getLine()->setStyle(LineStyle::ThinThin);
    $thirdSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDashDotDot);

    $firstLabel = $series->getDataPoints()->get_Item(0)->getLabel();
    $firstLabel->getDataLabelFormat()->setShowValue(true);

    $secondLabel = $series->getDataPoints()->get_Item(1)->getLabel();
    $secondLabel->getDataLabelFormat()->setShowValue(true);
    $secondLabel->getDataLabelFormat()->setShowLegendKey(true);
    $secondLabel->getDataLabelFormat()->setShowPercentage(true);

    $thirdLabel = $series->getDataPoints()->get_Item(2)->getLabel();
    $thirdLabel->getDataLabelFormat()->setShowSeriesName(true);
    $thirdLabel->getDataLabelFormat()->setShowPercentage(true);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);

    $presentation->save("PieChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![पाई चार्ट](pie_chart.png)

### **लाइन चार्ट बनाना**

लाइन चार्ट (जिसे लाइन ग्राफ भी कहा जाता है) सबसे अच्छा उन स्थितियों में उपयोग होते हैं जहाँ आप समय के साथ मान में परिवर्तन दिखाना चाहते हैं। लाइन चार्ट के माध्यम से आप बड़ी मात्रा में डेटा की तुलना एक साथ कर सकते हैं, समय के साथ परिवर्तन और रुझानों को ट्रैक कर सकते हैं, डेटा सीरीज़ में असामान्यताओं को हाइलाइट कर सकते हैं, आदि।

यह उदाहरण [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) का उपयोग करके डिफ़ॉल्ट सीरीज़ और श्रेणियों के साथ एक लाइन चार्ट बनाता है, फिर प्रस्तुति को PPTX के रूप में सहेजता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $lineChart = $slide->getShapes()->addChart(ChartType::Line, 20, 20, 500, 300);

    $presentation->save("lineChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

डिफ़ॉल्ट रूप से, लाइन चार्ट में बिंदु निरंतर सीधी लाइनों से जुड़े होते हैं। यदि आप बिंदुओं को डैश द्वारा जोड़ना चाहते हैं, तो [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) को [LineDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) के मान के साथ कॉल करें:

```php
use aspose\slides\ChartType;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $lineChart = $slide->getShapes()->addChart(ChartType::Line, 20, 20, 500, 300);

    for ($i = 0; $i < java_values($lineChart->getChartData()->getSeries()->size()); $i++)
    {
        $series = $lineChart->getChartData()->getSeries()->get_Item($i);
        $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![लाइन चार्ट](line_chart.png)

### **ट्री मैप चार्ट बनाना**

ट्री मैप चार्ट बिक्री डेटा के लिए सबसे उपयुक्त होते हैं जब आप डेटा श्रेणियों के सापेक्ष आकार दिखाना चाहते हैं और प्रत्येक श्रेणी के बड़े योगदानकर्ताओं पर तेजी से ध्यान आकर्षित करना चाहते हैं।

यह उदाहरण आठ पत्तियों को चार स्टेम और दो शाखाओं में समूहित करके एक ट्री मैप बनाता है। [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) मेथड स्टेम को ग्रुपिंग लेवल 1 पर और शाखाओं को लेवल 2 पर असाइन करता है। मान आकार निर्धारित करते हैं, जबकि श्रेणी लेबल और ओवरलैपिंग पैरेंट लेबल पदानुक्रम को पहचानते हैं।

```php
use aspose\slides\ChartType;
use aspose\slides\ParentLabelLayoutType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Treemap, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // शाखा 1
    $categoryCell = $workbook->getCell(0, "C1", "Leaf1");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");

    $categoryCell = $workbook->getCell(0, "C2", "Leaf2");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C3", "Leaf3");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");

    $categoryCell = $workbook->getCell(0, "C4", "Leaf4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    // शाखा 2
    $categoryCell = $workbook->getCell(0, "C5", "Leaf5");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");

    $categoryCell = $workbook->getCell(0, "C6", "Leaf6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C7", "Leaf7");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");

    $categoryCell = $workbook->getCell(0, "C8", "Leaf8");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $valueCell = $workbook->getCell(0, "D1", 4);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D2", 5);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D3", 3);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D4", 6);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D5", 9);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D6", 9);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D7", 4);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D8", 3);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);

    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);

    $presentation->save("Treemap.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![ट्रीमैप चार्ट](treemap_chart.png)

### **वॉटरफ़ॉल चार्ट बनाना**

वॉटरफ़ॉल चार्ट दर्शाता है कि सकारात्मक और नकारात्मक परिवर्तन अंतिम मान में कैसे योगदान देते हैं। उदाहरण के तौर पर, लाभ विभाजन राजस्व से शुरू हो सकता है, लागत घटाई जा सकती है, और अन्य आय जोड़ी जा सकती है। परिवर्तन कॉलम पिछले और नए चल रहे मानों के बीच तैरते हैं, जबकि कुल कॉलम शून्य से संचयी मान तक विस्तारित होते हैं।

निम्नलिखित उदाहरण हजारों यूएस डॉलर में राशि का उपयोग करता है:

| श्रेणी | वर्कबुक मान | कॉलम प्रकार |
| --- | ---: | --- |
| राजस्व | 1000 | वृद्धि |
| बिक्री लागत | -400 | कमी |
| सकल लाभ | 600 | मध्यवर्ती कुल |
| परिचालन खर्च | -200 | कमी |
| अन्य आय | 50 | वृद्धि |
| शुद्ध लाभ | 450 | अंतिम कुल |

किसी बिंदु को मध्यवर्ती या अंतिम कुल के रूप में चिह्नित करने के लिए, उसके [setSetAsTotal](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setsetastotal/) मेथड को `true` के साथ कॉल करें। उस बिंदु के वर्कबुक सेल में वास्तविक संचयी राशि प्रदान करें: `600` सकल लाभ (`1000 - 400`) के लिए और `450` शुद्ध लाभ (`600 - 200 + 50`) के लिए। यह मेथड कॉलम को कुल के रूप में चिह्नित करता है; यह सेल मान की गणना या भराव नहीं करता। शून्य को प्लेसहोल्डर के रूप में उपयोग न करें या कुल बिंदु के लिए कोई अन्य परिवर्तन न दें। कुल कॉलम संचयी मान को दिखाता है बिना उसे दोबारा चल रहे मान में जोड़ते।

यह पूर्ण PHP उदाहरण [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) के `Waterfall` सदस्य का उपयोग करके चार्ट बनाता है, डिफ़ॉल्ट डेटा साफ़ करता है, और एम्बेडेड वर्कबुक को भरता है। वर्कशीट इंडेक्स `0` पहली वर्कशीट चुनता है; कॉलम A में श्रेणी नाम और कॉलम B में मान होते हैं। प्रत्येक मान सेल को [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/adddatapointforwaterfallseries/) से जोड़ा जाता है। शून्य‑आधारित बिंदु इंडेक्स `2` और `5` क्रमशः मध्यवर्ती और अंतिम कुल को दर्शाते हैं। [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) को `true` के साथ कॉल करने से मान कॉलम पर दिखते हैं। इनपुट प्रस्तुति या वर्कबुक की आवश्यकता नहीं है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Waterfall, 20, 20, 680, 200);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Profit breakdown (USD thousands)");
    $chart->getChartTitle()->setOverlay(false);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $workbook->clear($worksheetIndex);

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Profit");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Waterfall);
    $categories = [ "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" ];
    $values = [ 1000, -400, 600, -200, 50, 450 ];

    for ($i = 0; $i < count($categories); $i++)
    {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categories[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForWaterfallSeries($valueCell);
    }

    // तीसरा और छठा बिंदु कुल को दर्शाते हैं, अतिरिक्त परिवर्तन नहीं।
    $series->getDataPoints()->get_Item(2)->setSetAsTotal(true);
    $series->getDataPoints()->get_Item(5)->setSetAsTotal(true);
    $series->setShowConnectorLines(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("WaterfallChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

सीरीज़‑लेवल पर [setShowConnectorLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setshowconnectorlines/) को `true` करने से क्रमिक कॉलम को जोड़ने वाली लाइन्स दिखती हैं और चल रहे मान को समझना आसान हो जाता है। इन लाइन्स को छुपाने के लिए, सहेजने से पहले कोड में `$series->setShowConnectorLines(false);` से बदलें। यह केवल लाइन की दृश्यता बदलता है, न कि डेटा या कुल को।

परिणाम:

![वॉटरफ़ॉल चार्ट जिसमें राजस्व, लागत, 600 का सकल लाभ और 450 का शुद्ध लाभ दिखाया गया है, मान लेबल और कनेक्टर लाइन्स के साथ](waterfall_chart.png)

### **स्टॉक चार्ट बनाना**

स्टॉक चार्ट वित्तीय डेटा जैसे खुला, उच्च, निम्न, और बंद कीमतें दर्शाने के लिए उपयोग होते हैं, जिससे बाजार रुझान और उतार‑चढ़ाव का विश्लेषण किया जा सके। ये स्टॉक प्रदर्शन पर आवश्यक अंतर्दृष्टि प्रदान करते हैं और निवेशकों व विश्लेषकों को सूचित निर्णय लेने में मदद करते हैं।

यह उदाहरण चार सीरीज़ के साथ एक ओपन‑हाई‑लो‑क्लोज़ चार्ट बनाता है, क्रम में और तीन श्रेणियों के साथ। [setUpDownBars](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/setupdownbars/) मेथड अप/डाउन बार को सक्षम करता है, और [getHiLowLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/gethilowlinesformat/) हाई‑लो लाइनों को नियंत्रित करता है जो कीमत रेंज दिखाते हैं, जबकि व्यक्तिगत सीरीज़ लाइनों और क्षैतिज ग्रिडलाइन को छिपाया गया है।

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::OpenHighLowClose, 20, 20, 500, 300, false);

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $categoryCell = $workbook->getCell(0, 1, 0, "A");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 2, 0, "B");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 3, 0, "C");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Open");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 2, "High");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 3, "Low");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 4, "Close");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $valueCell = $workbook->getCell(0, 1, 1, 72);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 1, 25);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 1, 38);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $valueCell = $workbook->getCell(0, 1, 2, 172);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 2, 57);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 2, 57);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $valueCell = $workbook->getCell(0, 1, 3, 12);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 3, 12);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 3, 13);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $valueCell = $workbook->getCell(0, 1, 4, 25);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 4, 38);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 4, 50);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++)
    {
        $stockSeries = $chart->getChartData()->getSeries()->get_Item($i);
        $stockSeries->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    $presentation->save("Stock-chart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![स्टॉक चार्ट](stock_chart.png)

### **बॉक्स एंड व्हिस्कर चार्ट बनाना**

बॉक्स एंड व्हिस्कर चार्ट डेटा वितरण को प्रमुख सांख्यिकीय माप जैसे माध्य, क्वार्टाइल और संभावित आउट्लायर को सारांशित करके दर्शाते हैं। ये अन्वेषी डेटा विश्लेषण और सांख्यिकीय अध्ययन में डेटा परिवर्तनशीलता को जल्दी समझने और किसी भी असामान्यताओं की पहचान करने में उपयोगी होते हैं।

यह उदाहरण छह मानों से एक बॉक्स एंड व्हिस्कर चार्ट बनाता है। [setQuartileMethod](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setquartilemethod/) मेथड एक्सक्लूसिव क्वार्टाइल गणना चुनता है। उदाहरण में मीन लाइन्स, मीन मार्कर्स, इनर पॉइंट्स और आउट्लायर पॉइंट्स को भी सक्षम किया गया है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\QuartileMethodType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::BoxAndWhisker, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A1", "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A2", "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A3", "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A4", "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A5", "Category 5");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A6", "Category 6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);

    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);

    $valueCell = $workbook->getCell(0, "B1", 15);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B2", 41);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B3", 16);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B4", 10);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B5", 23);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B6", 16);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);

    $presentation->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

### **फनल चार्ट बनाना**

फनल चार्ट उन प्रक्रियाओं को विज़ुअलाइज़ करने के लिए उपयोग होते हैं जिसमें क्रमिक चरण होते हैं, जहाँ डेटा की मात्रा एक चरण से अगले चरण तक घटती जाती है। ये रूपांतरण दरों का विश्लेषण, बाधाओं की पहचान, और बिक्री या मार्केटिंग प्रक्रियाओं की दक्षता को ट्रैक करने में विशेष रूप से मददगार होते हैं।

यह उदाहरण [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) का उपयोग करके मौजूदा प्रस्तुति की पहली स्लाइड में एक फनल चार्ट जोड़ता है। यह डिफ़ॉल्ट डेटा को छह श्रेणियों और 50‑से‑500 मानों के साथ बदलता है, फिर अद्यतन प्रस्तुति को सहेजता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होना आवश्यक है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A1", "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A2", "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A3", "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A4", "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A5", "Category 5");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A6", "Category 6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);

    $valueCell = $workbook->getCell(0, "B1", 50);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B2", 100);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B3", 200);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B4", 300);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B5", 400);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B6", 500);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);

    $presentation->save("Funnel.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![फनल चार्ट](funnel_chart.png)

### **सनबर्स्ट चार्ट बनाना**

सनबर्स्ट चार्ट पदानुक्रमित डेटा को विज़ुअलाइज़ करने के लिए उपयोग होते हैं, जहाँ स्तरों को गोले‑गोलाकार रिंग में दर्शाया जाता है। ये भाग‑से‑सम्पूर्ण संबंधों को दिखाते हैं और नेस्टेड श्रेणियों व उपश्रेणियों को स्पष्ट एवं संक्षिप्त रूप में प्रस्तुत करने के लिए आदर्श होते हैं।

यह उदाहरण आठ पत्तियों को चार स्टेम और दो शाखाओं में समूहित करके एक सनबर्स्ट चार्ट बनाता है। [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) मेथड स्टेम को ग्रुपिंग लेवल 1 पर और शाखाओं को लेवल 2 पर असाइन करता है। श्रेणी लेबल सेगमेंट को पहचानते हैं, और मान उनके सापेक्ष आकार निर्धारित करते हैं।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Sunburst, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // शाखा 1
    $categoryCell = $workbook->getCell(0, "C1", "Leaf1");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");

    $categoryCell = $workbook->getCell(0, "C2", "Leaf2");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C3", "Leaf3");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");

    $categoryCell = $workbook->getCell(0, "C4", "Leaf4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    // शाखा 2
    $categoryCell = $workbook->getCell(0, "C5", "Leaf5");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");

    $categoryCell = $workbook->getCell(0, "C6", "Leaf6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C7", "Leaf7");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");

    $categoryCell = $workbook->getCell(0, "C8", "Leaf8");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $valueCell = $workbook->getCell(0, "D1", 4);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D2", 5);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D3", 3);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D4", 6);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D5", 9);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D6", 9);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D7", 4);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D8", 3);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);

    $presentation->save("Sunburst.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![सनबर्स्ट चार्ट](sunburst_chart.png)

### **हिस्टोग्राम चार्ट बनाना**

हिस्टोग्राम चार्ट संख्यात्मक डेटा के वितरण को रेंज या बिन में समूहित करके प्रदर्शित करने के लिए उपयोग होते हैं। ये आवृत्ति, तिरछापन और प्रसार जैसी डेटा पैटर्न की पहचान करने, तथा डेटासेट में आउट्लायर खोजने में विशेष रूप से उपयोगी होते हैं।

यह उदाहरण छह संख्यात्मक मानों, जिसमें नकारात्मक मान भी शामिल हैं, से एक हिस्टोग्राम बनाता है। [setAggregationType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaggregationtype/) को स्वचालित एग्रीगेशन टाइप के साथ कॉल करने से चार्ट द्वारा उपयोग किए जाने वाले बिन निर्धारित किए जाते हैं।

```php
use aspose\slides\AxisAggregationType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Histogram, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
    $valueCell = $workbook->getCell(0, "A1", 15);
    $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    $valueCell = $workbook->getCell(0, "A2", -41);
    $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    $valueCell = $workbook->getCell(0, "A3", 16);
    $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    $valueCell = $workbook->getCell(0, "A4", 10);
    $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    $valueCell = $workbook->getCell(0, "A5", -23);
    $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    $valueCell = $workbook->getCell(0, "A6", 16);
    $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);

    $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);

    $presentation->save("Histogram.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![हिस्टोग्राम चार्ट](histogram_chart.png)

### **रेडार चार्ट बनाना**

रेडार चार्ट बहुवैध डेटा को दो‑आयामी प्रारूप में प्रदर्शित करने के लिए उपयोग होते हैं, जिससे कई चरों की एक साथ आसान तुलना संभव होती है। ये कई प्रदर्शन मीट्रिक्स या विशेषताओं में पैटर्न, ताकत और कमजोरियों की पहचान करने में विशेष रूप से उपयोगी होते हैं।

यह उदाहरण [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) का उपयोग करके डिफ़ॉल्ट सीरीज़ और श्रेणियों के साथ एक रेडार चार्ट बनाता है, फिर प्रस्तुति को PPTX के रूप में सहेजता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addChart(ChartType::Radar, 20, 20, 500, 300);

    $presentation->save("Radar-chart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![रेडार चार्ट](radar_chart.png)

### **मल्टी‑कैटेगरी चार्ट बनाना**

मल्टी‑कैटेगरी चार्ट उन डेटा को प्रदर्शित करने के लिए उपयोग होते हैं जिनमें एक से अधिक श्रेणीबद्ध समूह होते हैं, जिससे आप कई आयामों में मानों की तुलना एक साथ कर सकते हैं। ये जटिल, मल्टी‑लेयर डेटा सेट में रुझान और संबंधों का विश्लेषण करने के लिए विशेष रूप से मददगार होते हैं।

यह उदाहरण चार जोड़ों में व्यवस्थित आठ श्रेणियों के साथ एक क्लस्टर कॉलम चार्ट बनाता है। [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) मेथड प्रत्येक जोड़े को ग्रुपिंग लेवल 1 पर साझा लेबल देता है, जिससे व्यक्तिगत और समूह लेबल दोनों वाले श्रेणी एक्सिस बनते हैं।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $worksheetIndex = 0;

    $categoryCell = $workbook->getCell(0, "c2", "A");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $categoryCell = $workbook->getCell(0, "c3", "B");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c4", "C");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $categoryCell = $workbook->getCell(0, "c5", "D");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c6", "E");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $categoryCell = $workbook->getCell(0, "c7", "F");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c8", "G");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $categoryCell = $workbook->getCell(0, "c9", "H");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, "D1", "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $valueCell = $workbook->getCell($worksheetIndex, "D2", 10);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D3", 20);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D4", 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D5", 40);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D6", 50);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D7", 60);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D8", 70);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D9", 80);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![मल्टी‑कैटेगरी चार्ट](multi_category_chart.png)

### **मैप चार्ट बनाना**

मैप चार्ट भू‑भौगोलिक डेटा को विशिष्ट स्थानों (देश, राज्य या शहर) से मैप करने के लिए उपयोग होते हैं। ये क्षेत्रीय रुझान, जनसांख्यिकीय डेटा, और स्थानिक वितरण का स्पष्ट और दृश्यात्मक रूप से आकर्षक विश्लेषण करने में मदद करते हैं।

यह उदाहरण [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) का उपयोग करके डिफ़ॉल्ट भू‑भौगोलिक डेटा के साथ एक मैप चार्ट बनाता है और PowerPoint में देखने के लिए सहेजता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Map, 20, 20, 500, 300);

    $presentation->save("mapChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

परिणाम:

![मैप चार्ट](map_chart.png)

{{% alert color="info" title="Note" %}}
ऊपर दिखाया गया चित्र सहेजी गई प्रस्तुति को PowerPoint में खोलते हुए दिखाता है। Aspose.Slides मैप चार्ट और उसके डेटा को सही ढंग से लिखता है, लेकिन स्वयं मैप चार्ट को ड्रॉ नहीं करता: जब एक स्लाइड जिसमें मैप चार्ट हो, उसे इमेज में रेंडर किया जाता है या PDF या SVG में रूपांतरित किया जाता है, तो चार्ट क्षेत्र खाली निकलता है। उसी स्लाइड के अन्य आकार अप्रभावित रहते हैं।
{{% /alert %}}

### **कॉम्बिनेशन चार्ट बनाना**

कॉम्बिनेशन चार्ट (या कॉम्बो चार्ट) एक ही ग्राफ में दो या अधिक चार्ट प्रकारों को मिलाता है। यह चार्ट दो या अधिक डेटा सेटों के बीच अंतर को उजागर, तुलना या परीक्षण करने की अनुमति देता है, जिससे उनके बीच संबंधों की पहचान आसान हो जाती है।

![कॉम्बिनेशन चार्ट](combination_chart.png)

यह उदाहरण चार समूहित कॉलम सीरीज़ को एक लाइन सीरीज़ के साथ चार श्रेणियों में मिलाता है। कॉलम प्राथमिक लंबवत अक्ष का उपयोग करते हैं, जबकि [setPlotOnSecondAxis](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setplotonsecondaxis/) लाइन को दाएँ सेकेंडरी लंबवत अक्ष पर रखता है। सहायक फ़ंक्शन शीर्षक, लीजेंड, अक्ष लेबल और ग्रिडलाइन को कॉन्फ़िगर करते हैं।

```php
use aspose\slides\AxisPositionType;
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\FillType;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function createComboChart()
{
    $presentation = new Presentation();
    try
    {
        $chart = createChartWithFirstSeries($presentation->getSlides()->get_Item(0));

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    }
    finally
    {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide)
{
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $portionFormat = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $portionFormat->setFontBold(NullableBool::False);
    $portionFormat->setFontHeight(18);

    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $categoryCell = $workbook->getCell($worksheetIndex, 1, 0, "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 2, 0, "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 3, 0, "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 4, 0, "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 4.3);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 2.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 3.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 1, 4.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    return $chart;
}

function addSecondSeriesToChart($chart)
{
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 2, 2.4);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 2, 4.4);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 2, 1.8);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 2, 2.8);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
}

function addThirdSeriesToChart($chart)
{
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 3, 2.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 3, 2.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 3, 3.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 3, 5.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart)
{
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 217, 217, 217);
    $majorGridLinesFormat->getSolidFillColor()->setColor($color);
}

function setSecondaryAxesFormat($chart)
{
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle)
{
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titlePortionFormat = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $titlePortionFormat->setFontBold(NullableBool::False);
    $titlePortionFormat->setFontHeight(12);
}

createComboChart();
```

## **चार्ट अपडेट करना**

Aspose.Slides for PHP via Java आपको PowerPoint चार्ट को डेटा, फॉर्मेटिंग और स्टाइलिंग को संशोधित करके अपडेट करने की सुविधा देता है। यह कार्यक्षमता डायनामिक सामग्री के साथ प्रस्तुतियों को अद्यतित रखने की प्रक्रिया को सरल बनाती है और सुनिश्चित करती है कि चार्ट वर्तमान डेटा और दृश्य मानकों को सटीक रूप से दर्शाते हों।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर "My chart" नामक चार्ट को अपडेट करता है। इसमें तीन डेटा पॉइंट वाले दो कॉलम सीरीज़ की आवश्यकता होती है, जहाँ श्रेणी लेबल कॉलम A में और सीरीज़ नाम पहली शीट की पहली पंक्ति में होते हैं। उदाहरण [getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) का उपयोग करके वर्कबुक सेल बदलता है, सीरीज़ मान अपडेट करता है, तीसरी सीरीज़ जोड़ता है, और [setType](https://reference.aspose.com/slides/php-java/aspose.slides/chart/settype/) के माध्यम से चार्ट को क्लस्टर्ड सिलेंडर में बदलता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$chartName = "My chart";
$chartClass = new JavaClass("com.aspose.slides.IChart");

$presentation = new Presentation("ExistingChart.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++)
    {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartClass) && $chartName === java_values($shape->getName()))
        {
            $chart = $shape;
            $worksheetIndex = 0;

            $workbook = $chart->getChartData()->getChartDataWorkbook();

            $workbook->getCell($worksheetIndex, 1, 0, "Modified Category 1");
            $workbook->getCell($worksheetIndex, 2, 0, "Modified Category 2");

            $series = $chart->getChartData()->getSeries()->get_Item(0);

            $workbook->getCell($worksheetIndex, 0, 1, "New_Series 1");
            $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
            $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
            $series->getDataPoints()->get_Item(2)->getValue()->setData(44);

            $series = $chart->getChartData()->getSeries()->get_Item(1);

            $workbook->getCell($worksheetIndex, 0, 2, "New_Series 2");
            $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
            $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
            $series->getDataPoints()->get_Item(2)->getValue()->setData(99);

            $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
            $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

            $valueCell = $workbook->getCell($worksheetIndex, 1, 3, 20);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
            $valueCell = $workbook->getCell($worksheetIndex, 2, 3, 50);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
            $valueCell = $workbook->getCell($worksheetIndex, 3, 3, 30);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);

            $chart->setType(ChartType::ClusteredCylinder);
        }
    }

    $presentation->save("AsposeChartModified.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **चार्ट के लिए डेटा रेंज सेट करना**

पहले से मौजूद चार्ट द्वारा उपयोग की गई रेंज को देखने के लिए, देखें [Retrieve a Chart's Data Range](/slides/hi/php-java/chart-workbook/#retrieve-a-charts-data-range)।

Aspose.Slides for PHP via Java आपको वर्कशीट से विशिष्ट डेटा रेंज को अपने चार्ट के डेटा स्रोत के रूप में परिभाषित करने की लचीलापन प्रदान करता है। इसका अर्थ है कि आप सीधे वर्कशीट के एक हिस्से को चार्ट से मैप कर सकते हैं, जिससे आप नियंत्रित कर सकते हैं कि कौन से सेल चार्ट की सीरीज़ और श्रेणियों में योगदान देते हैं। परिणामस्वरूप, आप अपने चार्ट को आसानी से नवीनतम डेटा परिवर्तनों के साथ अपडेट और सिंक्रनाइज़ कर सकते हैं, यह सुनिश्चित करते हुए कि आपके PowerPoint प्रस्तुतियों में वर्तमान और सटीक जानकारी प्रतिबिंबित हो।

यह उदाहरण [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) का उपयोग करके मौजूदा प्रस्तुति की पहली स्लाइड पर "My chart" नामक चार्ट के डेटा स्रोत को `Sheet1!A1:B4` पर सेट करता है। चार्ट वर्कबुक में वह शीट और एक भरपूर रेंज होना चाहिए जिसमें पहली पंक्ति में सीरीज़ हेडिंग, कॉलम A में श्रेणी लेबल, और कॉलम B में तीन मान हों।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$chartName = "My chart";
$chartClass = new JavaClass("com.aspose.slides.IChart");

$presentation = new Presentation("ExistingChart.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++)
    {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartClass) && $chartName === java_values($shape->getName()))
        {
            $chart = $shape;
            $chart->getChartData()->setRange("Sheet1!A1:B4");
        }
    }

    $presentation->save("SetDataRange.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **चार्ट में डिफ़ॉल्ट मार्कर उपयोग करना**

जब आप चार्ट में डिफ़ॉल्ट मार्कर उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वचालित रूप से अलग‑अलग डिफ़ॉल्ट मार्कर प्रतीक मिलते हैं।

यह उदाहरण [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) का उपयोग करके दो लाइन सीरीज़ और एक लीजेंड वाला चार्ट बनाता है। [getMarker](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getmarker/) के माध्यम से एक्सेस किए गए मार्कर सेटिंग्स स्वचालित रूप से असाइन किए गए मार्कर प्रतीकों को बरकरार रखती हैं। पहली सीरीज़ में एक नकारात्मक मान और एक अनुपस्थित मान (`null`) होता है, जबकि दूसरी में प्रत्येक श्रेणी के लिए मान होता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $categoryCell = $workbook->getCell(0, 1, 0, "C1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 1, 1, 24);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 2, 0, "C2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 2, 1, 23);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 3, 0, "C3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 3, 1, -10);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 4, 0, "C4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 4, 1, null);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $seriesNameCell = $workbook->getCell(0, 0, 2, "Series 2");
    $secondSeries = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $valueCell = $workbook->getCell(0, 1, 2, 30);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 2, 10);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 2, 60);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 4, 2, 40);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);

    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);

    $presentation->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides for PHP via Java द्वारा कौन‑से चार्ट प्रकार समर्थित हैं?**

Aspose.Slides for PHP via Java कई प्रकार के चार्ट समर्थन करता है, जिसमें बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार और कई अन्य शामिल हैं। यह लचीलापन आपको अपने डेटा विज़ुअलाइज़ेशन की आवश्यकताओं के अनुसार सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

**मैं स्लाइड में नया चार्ट कैसे जोड़ूं?**

चार्ट जोड़ने के लिए, पहले आप [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने वाले मेथड को कॉल करते हैं, जिसमें चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट किया जाता है। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में एकीकृत करती है।

**मैं चार्ट में प्रदर्शित डेटा को कैसे अपडेट करूं?**

आप चार्ट के डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)) को एक्सेस करके, किसी भी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करके, और अपनी कस्टम डेटा जोड़कर चार्ट का डेटा अपडेट कर सकते हैं। यह आपको प्रोग्रामेटिकली चार्ट को नवीनतम डेटा के साथ ताज़ा करने की सुविधा देता है।

**क्या चार्ट की उपस्थिति को कस्टमाइज़ करना संभव है?**

हाँ, Aspose.Slides for PHP via Java विस्तृत कस्टमाइज़ेशन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लीजेंड और अन्य फॉर्मेटिंग तत्वों को संशोधित करके चार्ट की उपस्थिति को अपने विशिष्ट डिजाइन आवश्यकताओं के अनुरूप बना सकते हैं।