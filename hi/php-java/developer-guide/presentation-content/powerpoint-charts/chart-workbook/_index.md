---
title: PHP का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/php-java/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी वर्कबुक
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- पावरपॉइंट
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java की खोज करें: पावरपॉइंट और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को सहजता से प्रबंधित करके अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को पढ़ने और लिखने, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करने, वर्कशीट संग्रहों तक पहुंचने, और चार्ट मानों के लिये डेटा स्रोत प्रकार निर्दिष्ट करने को दर्शाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी सम्मिलित करता है। उदाहरण दिखाते हैं कि बाहरी वर्कबुक कैसे बनाया और असाइन किया जाए, चार्ट से जुड़े बाहरी वर्कबुक का पथ कैसे प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को कैसे संपादित किया जाए।

गैर-उपलब्ध डेटा दर्शाने वाले वर्कबुक सेल्स के लिए, खाली सेल और शून्य के अंतर तथा उपलब्ध प्रदर्शन मोड्स की रेखा-चार्ट तुलना के लिए देखें [खाली सेल के प्रदर्शित को नियंत्रित करें](/slides/hi/php-java/chart-series/)।

## **छिपी पंक्तियों और स्तम्भों से डेटा शामिल करना**

छिपी वर्कशीट पंक्तियों और स्तम्भों से डेटा को चार्ट प्लॉट करे या नहीं, इसको नियंत्रित करने के लिये [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) का उपयोग करें। इसे `true` पर सेट करने से केवल दिखने वाले सेल्स प्लॉट होते हैं, या `false` पर सेट करने से दिखने वाले तथा छिपे दोनों सेल्स शामिल होते हैं। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तम्भों को छिपाने या दिखाने का कार्य नहीं करती।

यह [नमूना प्रस्तुति](hidden-source-data.pptx) अपने पहले स्लाइड की पहली आकृति के रूप में एक स्तम्भ चार्ट रखती है। एम्बेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज, `A1:C4`, सम्मिलित है। पंक्ति 3 और स्तम्भ C छिपे हुए हैं, लेकिन उनके सेल्स में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: माह | B: खुदरा | C: थोक (छिपा स्तम्भ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

सोर्स सेल्स तक पहुंचने के लिये [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) का उपयोग करें और उनका छिपा स्थिति जाँचने के लिये [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) पढ़ें। यह मेथड स्थिति को बदले बिना रिपोर्ट करता है। इस फ़ाइल में, B2 दिखाई देता है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तम्भ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण में, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रिफ्रेश करें: एम्बेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) के साथ रखें और इसे [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) से पुनः लोड करें। सभी सेल्स को शामिल करने पर, छिपी फ़रवरी श्रेणी सहित पूर्ण रेंज पुनर्स्थापित करने के लिये [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) का उपयोग करें। केवल फ़्लैग बदलने से इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल्स को रिफ्रेश करने के लिये अपर्युक्त है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // एम्बेडेड वर्कबुक से चार्ट डेटा को रिफ्रेश करें।
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // संपूर्ण स्रोत रेंज को पुनर्स्थापित करें, जिसमें छिपी श्रेणियाँ शामिल हों।
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

उदाहरण प्रस्तुति के दो संस्करण सहेजता है: एक केवल दिखने वाले खुदरा मानों (10 और 20) के साथ, और दूसरा सभी छह मानों के साथ। नीचे की छवियां दो प्लॉटिंग मोड्स को दर्शाती हैं। पंक्ति 3 और स्तम्भ C दोनों एम्बेडेड वर्कबुक में छिपे रहते हैं।

| केवल दिखाई देने वाले सेल्स (`true`) | सभी सेल्स (`false`) |
| --- | --- |
| ![केवल दिखाई देने वाले सेल्स: जनवरी और मार्च के लिए खुदरा मान 10 और 20।](hidden_cells_True.png) | ![सभी सेल्स: जनवरी, फ़रवरी और मार्च के लिए खुदरा और थोक मान।](hidden_cells_False.png) |

एक मान वाला छिपा सेल एक खाली सेल से अलग होता है। [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) नियंत्रित करता है कि अनुपलब्ध मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। एक उदाहरण के लिये देखें [खाली सेल के प्रदर्शित को नियंत्रित करें](/slides/hi/php-java/chart-series/#control-the-display-of-empty-cells)।

## **एक चार्ट की डेटा रेंज प्राप्त करना**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंजेस की जाँच करें ताकि यह पता लगाया जा सके कि प्रत्येक चार्ट कौन सी वर्कशीट सेल्स का उपयोग करता है। [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) मेथड वर्तमान डेटा रेंज को वर्कशीट-योग्य सूत्र के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` वर्कशीट का नाम है, `!` इसे सेल रेंज से अलग करता है, और `$A$1:$D$5` A1 से D5 तक की सेल्स को शामिल करता है। डॉलर संकेत पूर्ण पंक्ति व स्तम्भ संदर्भ दर्शाते हैं।

यह मेथड वर्तमान रेंज को पढ़ता है बिना चार्ट या उसकी वर्कबुक को बदले। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता, तो यह अपवाद फेंकेगा। अधिक जानकारी के लिये देखें [ChartData API संदर्भ](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर आकृतियों को सीधे चार्ट के लिये जाँचता है। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करता है और अगले चार्ट की ओर बढ़ता है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides for PHP via Java [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) और [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) मेथड्स प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells से संपादित चार्ट डेटा) पढ़ने और लिखने की अनुमति देता है। **ध्यान दें** कि चार्ट डेटा को समान रूप से व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण एक प्रस्तुति का उपयोग करता है जिसमें पहला स्लाइड की पहली आकृति एक चार्ट है। यह एम्बेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ करता है, और वही वर्कबुक वापस लिखता है। बदलाव मेमोरी में रहते हैं; यह उदाहरण प्रस्तुति को सहेजता नहीं है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को मान्य करें**

जब आप एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी संग्रहों को बरकरार रखता है। यह असमर्थता [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) को इंडेक्स-आउट-ऑफ-रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ करें। यह उदाहरण एक चार्ट का उपयोग करता है जो पहले स्लाइड की पहली आकृति है। टिप्पणी उस स्थान को दर्शाती है जहाँ वर्कबुक संपादन होगा; कार्यशील उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // यहाँ वर्कबुक बाइट्स को संशोधित करें, उदाहरण के लिये, Aspose.Cells का उपयोग करके।

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

संग्रहों को साफ करने से वर्कबुक वापस लिखने से पहले पुराने डेटा रेफ़रेंसेज़ हटती हैं। चार्ट उपयोग करने से पहले अपडेटेड वर्कबुक के लिये आवश्यक सीरीज़ और श्रेणी मैपिंग को पुनर्निर्मित करें।

## **वर्कबुक सेल्स के लिये कस्टम नंबर फ़ॉर्मेट सेट करें**

एक चार्ट के एम्बेडेड वर्कबुक में संख्यात्मक मानों की प्रदर्शित शैली को नियंत्रित करने के लिये [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) का उपयोग करें। उदाहरण के लिये, रिपोर्ट को रूपांतरण दर को चार दशमलव स्थानों के साथ प्रतिशत में और गुणांक को पाँच दशमलव स्थानों के साथ दिखाने की आवश्यकता हो सकती है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिये उपलब्ध रहें।

नंबर फ़ॉर्मेट केवल प्रदर्शित को बदलता है, संग्रहीत मान को नहीं। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` के रूप में दिखाता है; यह संग्रहीत संख्या को `12.5` से नहीं बदलता। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` के रूप में दिखाता है बिना संग्रहीत मान को गोल किए। यदि कस्टम फ़ॉर्मेट खाली स्ट्रिंग (`""`) है, तो इसके बजाय [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) द्वारा लौटाए गया फ़ॉर्मेट उपयोग किया जाता है।

निम्न उदाहरण एक स्तम्भ चार्ट बनाता है और उसके सेल्स को [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) के माध्यम से एक्सेस करता है। वर्कशीट 0 पर, B2 में रूपांतरण दर है और C2 में गुणांक है। दोनों सेल्स चार्ट मान प्रदान करते हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़े मान लेबल को भी सक्षम करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

वर्कबुक सेल फ़ॉर्मेट चार्ट अक्ष या डेटा लेबल पर सीधे सेट किए गए फ़ॉर्मेट से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपने स्रोत सेल का मान दिखाता है क्योंकि [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) `true` पर सेट है, और स्रोत नंबर फ़ॉर्मेट को फॉलो करता है क्योंकि [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true` पर सेट है। प्रस्तुति को सहेजने और पुनः खोलने के बाद, लेबल नीचे दिखाए अनुसार `12.5000%` और `0.12346` प्रदर्शित करते हैं। लंबवत अक्ष अपना स्वयं का नंबर फ़ॉर्मेट उपयोग करता है, जिसे [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) द्वारा `0.00` के रूप में असाइन किया गया है, और [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) `false` पर सेट है।

डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिये, उसके स्रोत-लिंक फ़्लैग को `false` सेट करें और [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) से फ़ॉर्मेट असाइन करें। यह वर्कबुक सेल के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहले मान को `0.13` के रूप में दिखाता है, जबकि B2 अभी भी `12.5000%` दर्शाता है। प्रत्यक्ष लेबल फ़ॉर्मेटिंग के लिये देखें [Chart Data Labels](/slides/hi/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

![स्तम्भ चार्ट जिसमें स्रोत-लिंक्ड लेबल 12.5000% और 0.12346 दिखाते हैं और एक स्वतंत्र रूप से फ़ॉर्मेटेड संख्या अक्ष है।](custom-cell-formats.png)

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक सेल्स के पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति के पहले स्लाइड में डिफॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह वर्कशीट 0 पर सेल्स A10:A12 का उपयोग पहले सीरीज़ के पहले तीन लेबल्स के लिये करता है, सेल्स से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **वर्कशीट्स का प्रबंधन करें**

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) मेथड चार्ट वर्कबुक में वर्कशीट्स तक पहुंच प्रदान करता है। यह उदाहरण डिफॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल में प्रिंट करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह उदाहरण डिफॉल्ट डेटा के साथ एक 3D स्तम्भ चार्ट बनाता है और विभिन्न डेटा स्रोतों का उपयोग करके दो सीरीज़ नाम सेट करता है। पहला नाम स्ट्रिंग लिटेरल से उपयोग करता है; दूसरा वर्कशीट 0 पर सेल C1 से उपयोग करता है। [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) एन्‍युमरेशन प्रत्येक नाम के लिये स्रोत चुनता है। उदाहरण अपडेटेड सीरीज़ नामों के साथ प्रस्तुति को सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट्स का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता। आप [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) एन्‍युमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट्स का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति के पहले स्लाइड पर आकृतियों का निरीक्षण करता है, गैर-चार्ट आकृतियों को छोड़ता है, और प्रत्येक .xlsb एम्बेडेड वर्कबुक वाले चार्ट के लिये एक निदान संदेश प्रिंट करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // यहाँ समर्थित चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
    }
} finally {
    $presentation->dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिये बाहरी वर्कबुक को डेटा स्रोत के रूप में उपयोग करने का समर्थन करता है।

### **बाहरी वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) और [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक निर्यात करता है। यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करने से पहले फ़ाइल लिखना पूर्ण करता है, फिर लिंक्ड प्रस्तुति को सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **बाहरी वर्कबुक सेट करें**

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) मेथड का उपयोग करके आप एक चार्ट को बाहरी वर्कबुक को डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक का पथ अपडेट करने के लिये भी उपयोग किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

हालांकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक डेटा को संपादित नहीं कर सकते, फिर भी आप ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिये सापेक्ष पथ दिया गया है, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में एक सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान होते हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) का उपयोग करके A1:B4 को एक सीरीज़ और तीन श्रेणियों से मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `false` है, केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक उपलब्ध नहीं भी हो सकता है।
* जब `updateChartData` `true` है, चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण एक प्लेसहोल्डर URL को `updateChartData` `false` के साथ असाइन करता है। यह पाई चार्ट के डिफॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **एक चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ को प्राप्त करें**

एक चार्ट से जुड़ी वर्कबुक की पहचान करने के लिये, जाँचें कि चार्ट बाहरी डेटा स्रोत उपयोग करता है या नहीं और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण एक प्रस्तुति में पहले स्लाइड की पहली आकृति को निरीक्षण करता है जिसमें लिंक्ड बाहरी वर्कबुक है। यदि यह एक चार्ट है जो बाहरी वर्कबुक से लिंक्ड है, तो उदाहरण [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) को कंसोल पर प्रिंट करता है। फिर यह प्रस्तुति की एक प्रति सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाता, तो अपवाद फेंका जाता है।

यह उदाहरण एक चार्ट का उपयोग करता है जो पहले स्लाइड की पहली आकृति है और एक सुलभ बाहरी वर्कबुक से लिंक्ड है। यह पहली सीरीज़ के पहले डेटा पॉइंट के सेल-बैक्ड मान को 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए यदि मूल वर्कबुक को बरकरार रखना है तो एक कॉपी का उपयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश्ड डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। प्रस्तुति खोलने से पहले [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) बनाएं, [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) को कॉल करें, और [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) को `true` सेट करें।

निम्न PHP उदाहरण एक चार्ट के लिये वर्कबुक डेटा पुनर्प्राप्त करता है जो पहले स्लाइड की पहली आकृति है और अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है। यह पुनर्प्राप्त डेटा तक [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) और [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) के माध्यम से पहुँचता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और रिकवरी अक्षम है, तो Aspose.Slides अपवाद फेंकेगा। केवल तब रिकवरी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य बैकअप हो, क्योंकि कैश में प्रस्तुति के अंतिम अपडेट के बाद बाहरी वर्कबुक में किए गए परिवर्तन नहीं हो सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हां। एक चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) और एक [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं ताकि यह सुनिश्चित किया जा सके कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना आवश्यक हो सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [बाहरी फ़ाइल के लिंक](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) संग्रहीत करती है। सेल-बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल वर्कबुक को अपरिवर्तित रखना आवश्यक है, तो वर्कबुक की एक कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड-सुरक्षित है तो मैं क्या करूँ?**

Aspose.Slides लिंक करने के समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका है पहले सुरक्षा हटाना या एक डिक्रिप्टेड कॉपी तैयार करना (उदाहरण के लिये, [Aspose.Cells](https://reference.aspose.com/cells/java/) का उपयोग करके) और उस कॉपी से लिंक करना।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगले डेटा लोड होने पर प्रत्येक चार्ट में प्रतिबिंबित होगा।