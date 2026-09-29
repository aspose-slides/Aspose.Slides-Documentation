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
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java की खोज करें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने का तरीका बताता है। यह दिखाता है कि वर्कबुक स्ट्रीम द्वारा चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में कैसे उपयोग करें, वर्कशीट संग्रहों तक कैसे पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित करें।

ग़ायब डेटा को दर्शाने वाले वर्कबुक सेल्स के बारे में, देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/php-java/chart-series/) जहाँ खाली सेल और शून्य के बीच अंतर तथा उपलब्ध प्रदर्शन मोड की रेखा‑चार्ट तुलना दर्शायी गई है।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करने के लिये या न करने के लिये, [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/setplotvisiblecellsonly/) का उपयोग करें। केवल दृश्यमान कोशिकाओं को प्लॉट करने के लिये इसे `true` और दृश्यमान एवं छिपी दोनों कोशिकाओं को शामिल करने के लिये `false` सेट करें। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या प्रदर्शित नहीं करती।

[hidden-source-data.pptx](hidden-source-data.pptx) डाउनलोड करके इसे कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में पहला आकार एक कॉलम चार्ट है। एम्बेडेड वर्कशीट `Sheet1` में निम्न स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, पर उनकी कोशिकाएँ अभी भी मान रखती हैं।

| वर्कशीट पंक्ति | A: माह | B: रिटेल | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुँचने के लिये [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getchartdataworkbook/) का उपयोग करें और उनकी छिपी स्थिति जांचने के लिये [ChartDataCell::isHidden](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/ishidden/) पढ़ें। यह विधि स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से है, और C2 छिपे स्तंभ से है; उदाहरण क्रमशः `false`, `true`, `true` प्रिंट करता है।

इस उदाहरण के लिये, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रिफ्रेश करें: एम्बेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/readworkbookstream/) से पुनः प्राप्त करें और [writeWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/writeworkbookstream/) से पुनः लोड करें। सभी कोशिकाओं को शामिल करने पर, छिपी फ़रवरी श्रेणी को पुनर्स्थापित करने के लिये [setRange](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/setrange/) का भी उपयोग करें। केवल फ्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रिफ्रेश करने के लिये अपर्याप्त है।

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

            // एंबेडेड वर्कबुक से चार्ट डेटा को रीफ़्रेश करें।
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // छिपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

उदाहरण `hidden_cells_true.pptx` को केवल दृश्यमान रिटेल मान (10 और 20) के साथ सहेजता है, और `hidden_cells_false.pptx` को सभी छह मानों के साथ। नीचे की छवियाँ दो प्लॉटिंग मोड को दर्शाती हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड वर्कबुक में छिपे हुए रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए रिटेल मान 10 और 20।](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी और मार्च के लिए रिटेल और थोक मान।](hidden_cells_False.png) |

एक मान वाला छिपा सेल खाली सेल से अलग होता है। [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/setdisplayblanksas/) निर्धारित करता है कि ग़ायब मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिये देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/php-java/chart-series/#control-the-display-of-empty-cells)।

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for PHP via Java प्रदान करता है [readWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/readworkbookstream/) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/writeworkbookstream/) विधियाँ जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells से संपादित चार्ट डेटा को समाहित) को पढ़ने और लिखने की अनुमति देती हैं। **ध्यान दें** कि चार्ट डेटा को उसी रूप में या स्रोत के समान संरचना वाले रूप में व्यवस्थित किया गया होना चाहिए।

यह उदाहरण `chart.pptx` को खोलता है, जिसमें प्रथम स्लाइड के प्रथम आकार के रूप में एक चार्ट होना आवश्यक है। यह एम्बेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहता है; यह उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को सत्यापित करें**

जब आप एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहों को बरकरार रखता है। यह असंगति [Chart::validateChartLayout](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/validatechartlayout/) को इंडेक्स‑आउट‑ऑफ‑रेंज त्रुटि के साथ विफल कर सकती है। अद्यतन वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण `chart.pptx` की आवश्यकता रखता है जिसमें प्रथम स्लाइड पर प्रथम आकार के रूप में एक चार्ट हो। टिप्पणी चिह्नित करता है कि जहाँ वर्कबुक संपादन होगा; निष्पादन योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को सत्यापित करता है।

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

        // वर्कबुक बाइट्स को यहाँ संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

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

संकलनों को साफ़ करने से वर्कबुक लिखे जाने से पहले पुरानी डेटा रेफ़रेंसेज़ हट जाती हैं। अपडेटेड वर्कबुक के लिये आवश्यक कोई भी श्रृंखला और श्रेणी मानचित्र फिर से बनाएं, फिर चार्ट का उपयोग करें।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक सेल्स से टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं। निम्न चरण दिखाते हैं कि बबल चार्ट में लेबल्स को उसके डेटा वर्कबुक की कोशिकाओं से कैसे लिंक करें।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. शून्य‑आधारित इंडेक्स द्वारा पहली स्लाइड तक पहुँचें।  
3. डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ें।  
4. चार्ट श्रृंखला तक पहुँचें।  
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
6. प्रस्तुति को सहेजें।

यह उदाहरण `chart2.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए, और डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह वर्कशीट 0 की कोशिकाएँ A10:A12 को प्रथम श्रृंखला के पहले तीन लेबल्स के लिये उपयोग करता है, कोशिकाओं से लेबल सक्षम करता है, और परिणाम को `resultchart.pptx` में सहेजता है।

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

## **वर्कशीट प्रबंधित करें**

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/getworksheets/) विधि आपको चार्ट वर्कबुक में वर्कशीट्स तक पहुँच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल में प्रिंट करता है।

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

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों से सेट करता है। पहला नाम एक स्ट्रिंग लिटरल है; दूसरा कार्यपत्रक 0 की कोशिका C1 से। [DataSourceType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datasourcetype/) एनीमरेशन प्रत्येक नाम के लिये स्रोत चुनता है। परिणाम `pres.pptx` में सहेजा जाता है।

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता। आप [ChartData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` विधि को [WorkbookType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/workbooktype/) एनीमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं। यह उदाहरण `sample.pptx` की प्रथम स्लाइड पर आकारों को निरीक्षण करता है, गैर‑चार्ट आकारों को छोड़ता है, और एम्बेडेड .xlsb वर्कबुक वाले प्रत्येक चार्ट के लिये एक डायग्नोस्टिक संदेश प्रिंट करता है।

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

        // समर्थित चार्ट वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
    }
} finally {
    $presentation->dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिये डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/readworkbookstream/) और [setExternalWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/setexternalworkbook/) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, उसकी वर्कबुक को `externalWorkbook1.xlsx` में लिखता है, और फ़ाइल को चार्ट डेटा स्रोत के रूप में असाइन करने से पहले लिखना पूर्ण करता है। यह लिंक्ड प्रस्तुति को `externalWorkbook.pptx` में सहेजता है।

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

### **एक बाहरी वर्कबुक सेट करें**

[setExternalWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/setexternalworkbook/) विधि का उपयोग करके आप किसी चार्ट को उसकी डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यह विधि बाहरी वर्कबुक के पथ को अपडेट करने (यदि वह स्थानांतरित किया गया हो) के लिये भी उपयोग की जा सकती है।

जबकि आप रिमोट लोकेशन या संसाधनों में स्थित वर्कबुक के डेटा को संपादित नहीं कर सकते, फिर भी आप ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि किसी बाहरी वर्कबुक के लिये सापेक्ष पथ दिया गया है, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण कार्य निर्देशिका में `externalWorkbook.xlsx` की आवश्यकता रखता है। इसका कार्यपत्रक `Sheet1` में B1 में एक श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान होने चाहिए। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/setrange/) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों से मैप करता है। परिणाम `Presentation_with_externalWorkbook.pptx` में सहेजा जाता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/setexternalworkbook/) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `false` हो, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक उपलब्ध नहीं भी हो सकती।  
* जब `updateChartData` `true` हो, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

नीचे का उदाहरण `updateChartData` को `false` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **चार्ट की बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक की पहचान करने के लिये, पहले जांचें कि क्या चार्ट बाहरी डेटा स्रोत उपयोग करता है। यदि हाँ, तो निम्न चरणों द्वारा वर्कबुक पथ प्राप्त करें।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. शून्य‑आधारित इंडेक्स द्वारा पहली स्लाइड तक पहुँचें।  
3. जाँचें कि प्रथम आकार एक चार्ट है।  
4. चार्ट डेटा स्रोत प्रकार पढ़ें।  
5. यदि स्रोत एक बाहरी वर्कबुक है, तो उसका पथ पढ़ें।

यह उदाहरण पहले बनाए गए `externalWorkbook.pptx` को खोलता है और प्रथम स्लाइड पर प्रथम आकार को निरीक्षण करता है। यदि वह बाहरी वर्कबुक से लिंक्ड एक चार्ट है, तो उदाहरण कंसोल में [getExternalWorkbookPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) को प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी `Result.pptx` में सहेजता है।

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

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसा आप अंदरूनी वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो अपवाद फेंका जाता है।

यह उदाहरण `presentation.pptx` को आवश्यक मानता है जिसमें प्रथम स्लाइड पर प्रथम आकार के रूप में एक चार्ट हो और एक सुलभ बाहरी वर्कबुक हो। यह प्रथम श्रृंखला के प्रथम डेटा पॉइंट का सेल‑बैक्ड मान 100 सेट करता है और प्रस्तुति को `presentation_out.pptx` में सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिये एक प्रति उपयोग करें।

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

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो ग़ायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/) बनाएं, [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) को कॉल करें, और [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) को `true` सेट करें, फिर प्रस्तुति खोलें।

निम्न PHP उदाहरण `presentation.pptx` को खोलता है, जिसकी प्रथम स्लाइड पर प्रथम आकार एक चार्ट होना चाहिए जो एक अनुपलब्य बाहरी वर्कबुक का संदर्भ देता है, और पुनः प्राप्त डेटा को [Chart::getChartData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/getchartdata/) और [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getchartdataworkbook/) के माध्यम से एक्सेस करता है:

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

        // यहाँ पुनः प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्य है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकता है। पुनर्प्राप्ति केवल तब सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य फॉलबैक हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए बदलावों को सम्मिलित नहीं किया गया हो सकता।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getdatasourcetype/) और एक [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर पुष्टि कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [बाहरी फ़ाइल के लिंक](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) को संग्रहीत करती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल को अपरिवर्तित रखना है, तो वर्कबुक की एक प्रति उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑प्रोटेक्टेड हो तो क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य उपाय यह है कि पहले सुरक्षा हटाएँ या एक डिक्रिप्टेड प्रति (उदाहरण के लिये [Aspose.Cells](https://reference.aspose.com/cells/java/)) तैयार करें और उस प्रति को लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल को इंगित करते हैं, तो फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में प्रतिबिंबित होगा।