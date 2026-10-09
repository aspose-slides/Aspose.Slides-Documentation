---
title: जावास्क्रिप्ट के साथ प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/nodejs-java/chart-workbook/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java को खोजें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करें और अपनी प्रस्तुति डेटा को सरल बनाएं।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ने और लिखने, चार्ट डेटा लेबल के रूप में वर्कबुक सेल्स का उपयोग करने, वर्कशीट संग्रहों तक पहुंचने और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट करने को दिखाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि बाहरी वर्कबुक कैसे बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ कैसे प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को कैसे संपादित करें।

गुम डाटा का प्रतिनिधित्व करने वाले वर्कबुक सेल्स के लिए, [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/nodejs-java/chart-series/) देखें ताकि खाली सेल और शून्य के बीच अंतर समझ सकें, और उपलब्ध प्रदर्शन मोड की तुलना के लिए एक लाइन‑चार्ट देखें।

## **छिपी हुई पंक्तियों और स्तम्भों से डेटा शामिल करें**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) का उपयोग करें यह नियंत्रित करने के लिए कि क्या चार्ट छिपे हुए वर्कशीट पंक्तियों और स्तम्भों से डेटा प्लॉट करता है। केवल दृश्यमान कोशिकाएँ प्लॉट करने के लिए इसे `true` सेट करें, या दोनों दृश्यमान एवं छिपी हुई कोशिकाएँ शामिल करने के लिए `false` सेट करें। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तम्भों को छिपाती या दिखाती नहीं है।

[नमूना प्रस्तुति](hidden-source-data.pptx) में अपनी पहली स्लाइड पर पहला आकार कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तम्भ C छिपे हुए हैं, लेकिन उनके सेल अभी भी मान रखते हैं।

| वर्कशीट पंक्ति | A: महीना | B: रिटेल | C: थोक (छिपा स्तम्भ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी हुई पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुँचने के लिए [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) का उपयोग करें और उनके छिपे होने की स्थिति का निरीक्षण करने के लिए [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#isHidden) को पढ़ें। यह विधि स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी हुई पंक्ति से संबंधित है, और C2 छिपे हुए स्तम्भ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण में, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रिफ़्रेश करें: एम्बेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) से रखें और [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) से पुनः लोड करें। सभी कोशिकाओं को शामिल करने के लिए, छिपे हुए फ़रवरी श्रेणी को भी पुनर्स्थापित करने हेतु [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) का उपयोग करें। केवल फ्लैग बदलना इस नमूने के कैश किए गए चार्ट डेटा और श्रेणी लेबल को रिफ़्रेश करने के लिए पर्याप्त नहीं है। उदाहरण लौटाए गए Node.js बफ़र को Java बाइट एरे में बदलता है फिर लिखने वाली विधि को पास करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // एंबेडेड वर्कबुक से चार्ट डेटा रिफ्रेश करें।
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // छिपी हुई वर्गों को सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

उदाहरण दो संस्करणों की प्रस्तुति सहेजता है: एक जिसमें केवल दृश्यमान रिटेल मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे की छवियाँ दो प्लॉटिंग मोड को दर्शाती हैं। पंक्ति 3 और स्तम्भ C दोनों एम्बेडेड वर्कबुक में छिपे हुए रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए रिटेल मान 10 और 20।](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी और मार्च के लिए रिटेल और थोक मान।](hidden_cells_False.png) |

एक छिपा हुआ सेल जिसमें मान है, वह खाली सेल से अलग होता है। [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) नियंत्रित करता है कि गुम मान कैसे दिखाए जाएँ; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। अधिक उदाहरण के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/nodejs-java/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट की डेटा रेंज प्राप्त करें**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंज की जाँच करें ताकि यह पहचाना जा सके कि प्रत्येक चार्ट कौन‑सी वर्कशीट कोशिकाएँ उपयोग करता है। [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getRange) विधि वर्तमान डेटा रेंज को वर्कशीट‑योग्य फ़ॉर्मूला के रूप में लौटाती है, जैसे `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` वर्कशीट का नाम है, `!` इसे कोशिका रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाओं A1‑से‑D5 को शामिल करता है। डॉलर चिह्न निरपेक्ष पंक्ति और स्तम्भ संदर्भ दर्शाते हैं।

यह विधि चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज पढ़ती है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक उपयोग नहीं करता, तो यह `InvalidOperationException` फेंकता है। अधिक जानकारी के लिए देखें [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकारों की जाँच करता है ताकि चार्ट मिल सकें। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करता है और अगले चार्ट पर जारी रहता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Node.js via Java [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) विधियाँ प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित) को पढ़ने और लिखने देता है। **Note** कि चार्ट डेटा को उसी क्रम में व्यवस्थित होना चाहिए या स्रोत के समान संरचना होना चाहिए।

यह उदाहरण एक प्रस्तुति का उपयोग करता है जिसमें पहली स्लाइड पर पहला आकार एक चार्ट है। यह एम्बेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **वर्कबुक संशोधन के बाद चार्ट लेआउट मान्य करें**

जब आप एक संशोधित वर्कबुक से एम्बेडेड वर्कबुक को बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहों को बरकरार रखता है। यह असंगति [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#validateChartLayout) को इंडेक्स‑आउट‑ऑफ‑रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को चार्ट में लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहला आकार एक चार्ट है। टिप्पणी में दर्शाया गया है कि जहाँ वर्कबुक संपादन होगा; चलने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // यहाँ वर्कबुक बाइट्स को संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

संग्रहों को साफ़ करने से वर्कबुक लिखे जाने से पहले स्थिर डेटा संदर्भ हट जाते हैं। अपडेटेड वर्कबुक के लिए आवश्यक कोई भी श्रृंखला और श्रेणी मैपिंग फिर से बनाएँ पहले कि चार्ट का उपयोग करें।

## **एक वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं से पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह वर्कशीट 0 की कोशिकाएँ A10:A12 को पहली श्रृंखला के पहले तीन लेबल के रूप में उपयोग करता है, कोशिकाओं से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **वर्कशीट प्रबंधित करें**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) विधि चार्ट वर्कबुक में वर्कशीट्स तक पहुँच प्रदान करती है। यह उदाहरण एक डिफ़ॉल्ट डेटा के साथ पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **डेटा स्रोत प्रकार निर्धारित करें**

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम अलग-अलग डेटा स्रोतों से सेट करता है। पहला नाम स्ट्रिंग लिटेरल है; दूसरा वर्कशीट 0 की कोशिका C1 से लिया गया है। [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) एन्यूमरेशन प्रत्येक नाम के स्रोत को चुनता है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता। आप [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) विधि का उपयोग [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) एन्यूमरेशन के साथ करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों की जाँच करता है, गैर‑चार्ट आकारों को छोड़ता है, और प्रत्येक .xlsb एम्बेडेड वर्कबुक वाले चार्ट के लिए निदान संदेश प्रिंट करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // समर्थित चार्ट वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थित करता है।

### **एक बाहरी वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) और [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक को निर्यात करता है। यह फ़ाइल लिखने को पूरा करता है फिर बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, और फिर लिंक्ड प्रस्तुति को सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **एक बाहरी वर्कबुक सेट करें**

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) विधि का उपयोग करके आप एक चार्ट को उसका डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यह विधि बाहरी वर्कबुक का पथ अपडेट करने (यदि इसे स्थानांतरित किया गया हो) के लिए भी उपयोग की जा सकती है।

आप रिमोट लोकेशनों या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, लेकिन ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया जाता है, तो यह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों के रूप में मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड की जाए या नहीं।

* जब `updateChartData` `false` है, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध हो सकती है।
* जब `updateChartData` `true` है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण `updateChartData` को `false` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **एक चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ को प्राप्त करें**

यह पहचानने के लिए कि किसी चार्ट से कौन‑सी वर्कबुक जुड़ी है, जांचें कि क्या चार्ट बाहरी डेटा स्रोत उपयोग कर रहा है और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण प्रस्तुति की पहली स्लाइड पर पहले आकार की जाँच करता है जो बाहरी वर्कबुक से लिंक्ड है। यदि यह कोई ऐसा चार्ट है, तो यह [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) को कंसोल पर प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो अपवाद फेंका जाता है।

यह उदाहरण एक चार्ट का उपयोग करता है जो पहली स्लाइड पर पहला आकार है और एक सुलभ बाहरी वर्कबुक से लिंक्ड है। यह पहली श्रृंखला के पहले डेटा पॉइंट का सेल‑बैक्ड मान 100 पर सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को सुरक्षित रखने के लिए एक कॉपी का उपयोग करें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) बनाएं, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) को कॉल करें, और [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को `true` सेट करें प्रस्तुति खोलने से पहले।

निम्न JavaScript उदाहरण एक चार्ट के लिए वर्कबुक डेटा को पुनः प्राप्त करता है जिससे यह पहली स्लाइड पर पहला आकार है और एक अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है। यह पुनर्प्राप्त डेटा को [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getChartData) और [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकता है। पुनर्प्राप्ति केवल तभी सक्षम करें जब कैश किया गया चार्ट डेटा एक स्वीकार्य बैकअप हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए बदलाव शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट का एक [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getDataSourceType) और एक [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर पुष्टि कर सकते हैं कि एक बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो यह स्वचालित रूप से पूर्ण पथ में बदल जाता है। प्रस्तुति इस पूर्ण पथ को PPTX फ़ाइल में संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करने की आवश्यकता हो सकती है।

**क्या मैं नेटवर्क रिसोर्स/शेयर पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) संग्रहीत करती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल को अपरिवर्तित रखना है तो वर्कबुक की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो क्या करें?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य दृष्टिकोण यह है कि पहले सुरक्षा हटाएँ या एक डिक्रिप्टेड कॉपी (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/java/)) तैयार करें और उस पर लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिवर्तन परिलक्षित होगा।