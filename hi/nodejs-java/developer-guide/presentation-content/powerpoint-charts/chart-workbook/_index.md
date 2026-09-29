---
title: प्रेजेंटेशन में जावास्क्रिप्ट का उपयोग करके चार्ट वर्कबुक प्रबंधन
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
- वर्कबुक पुनःप्राप्ति
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java को खोजें: PowerPoint और OpenDocument प्रारूपों में चार्ट वर्कबुक्स का सहजता से प्रबंधन करें और अपने प्रस्तुति डेटा को सुगम बनाएं।"
---
## **परिचय**

यह लेख Aspose.Slides में चार्ट वर्कबुक्स के साथ काम करने का तरीका बताता है। यह वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को पढ़ने और लिखने, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करने, वर्कशीट कलेक्शन तक पहुंचने, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट करने को दर्शाता है।

यह बाहरी वर्कबुक्स को डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और नियत किया जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित किया जाए।

वर्कबुक सेल्स जो अनुपलब्ध डेटा दर्शाते हैं, उसके लिए देखें [Control the Display of Empty Cells](/slides/hi/nodejs-java/chart-series/) जहाँ खाली सेल और शून्य के बीच अंतर तथा उपलब्ध डिस्प्ले मोड का लाइन-चार्ट तुलना बताया गया है।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट किया जाए या नहीं, इसे नियंत्रित करने के लिए [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) का उपयोग करें। केवल दृश्यमान सेल्स को प्लॉट करने के लिए `true` सेट करें, या दृश्यमान और छिपी दोनों सेल्स को शामिल करने के लिए `false` सेट करें। यह सेटिंग चार्ट के प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या प्रदर्शित नहीं करती।

[hidden-source-data.pptx](hidden-source-data.pptx) डाउनलोड करें और इसे कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में पहले आकार के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, परंतु उनके सेल्स में अभी भी मान हैं।

| Worksheet row | A: Month | B: Retail | C: Wholesale (hidden column) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

स्रोत सेल्स तक पहुंचने के लिए [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) का उपयोग करें और छिपी स्थिति को जाँचने के लिए [ChartDataCell.isHidden](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#isHidden) पढ़ें। यह मेथड छिपी स्थिति को बदले बिना रिपोर्ट करता है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एम्बेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) के साथ बनाए रखें और उसे [writeWorkbookStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) से पुनः लोड करें। सभी सेल्स को शामिल करने पर, छिपी हुई फ़रवरी श्रेणी सहित पूर्ण रेंज को पुनर्स्थापित करने के लिए [setRange](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#setRange) भी उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए अपर्याप्त है। उदाहरण लौटाए हुए Node.js बफ़र को जावा बाइट एरे में परिवर्तित करता है और उसे लिखने वाले मेथड को पास करता है।

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

            // एम्बेडेड वर्कबुक से चार्ट डेटा को रीफ़्रेश करें।
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // छिपी श्रेणियों सहित संपूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

उदाहरण `hidden_cells_true.pptx` को केवल दृश्यमान Retail मानों (10 और 20) के साथ, तथा `hidden_cells_false.pptx` को सभी छह मानों के साथ सहेजता है। नीचे दी गई छवियां दो प्लॉटिंग मोड दिखाती हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड वर्कबुक्स में छिपे रहते हैं।

| केवल दृश्यमान सेल्स (`true`) | सभी सेल्स (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान युक्त छिपा सेल खाली सेल से अलग होता है। [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) नियंत्रित करता है कि अनुपलब्ध मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिए देखें [Control the Display of Empty Cells](/slides/hi/nodejs-java/chart-series/#control-the-display-of-empty-cells)।

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Node.js via Java, [readWorkbookStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) मेथड प्रदान करता है, जिससे आप चार्ट डेटा वर्कबुक्स (Aspose.Cells से संपादित) को पढ़ और लिख सकते हैं। **ध्यान दें** कि चार्ट डेटा को उसी प्रकार संरचित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण `chart.pptx` खोलता है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए। यह एम्बेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को वैध बनाएं**

जब आप एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी कलेक्शन को बनाए रखता है। यह असंगतता [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/#validateChartLayout) को इंडेक्स-आउट-ऑफ़-रेंज त्रुटि के साथ असफल बना सकती है। अद्यतन वर्कबुक को चार्ट में लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें। यह उदाहरण `chart.pptx` की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट है। टिप्पणी उन स्थानों को दर्शाती है जहाँ वर्कबुक संपादन हो सकता है; चलाने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को वैध करता है।

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

        // यहाँ वर्कबुक बाइट्स को संशोधित करें, उदाहरण के लिए Aspose.Cells का उपयोग करके।

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

कलेक्शन को साफ़ करने से वर्कबुक वापस लिखने से पहले पुरानी डेटा रेफ़रेंसेज़ हट जाती हैं। अपडेटेड वर्कबुक के लिए आवश्यक सीरीज़ और श्रेणी मैपिंग को फिर से बनाएं, फिर चार्ट का उपयोग करें।

## **वर्कबुक सेल को चार्ट डेटा लेबल बनाएं**

आप वर्कबुक सेल्स के टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं। नीचे के चरण बबल चार्ट में लेबल को डेटा वर्कबुक के सेल्स से लिंक करने का तरीका दर्शाते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. शून्य-आधारित इंडेक्स द्वारा पहली स्लाइड तक पहुंचें।
1. डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ें।
1. चार्ट सीरीज़ तक पहुंचें।
1. वर्कबुक सेल को डेटा लेबल सेट करें।
1. प्रस्तुति सहेजें।

यह उदाहरण `chart2.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए, और डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह वर्कशीट 0 पर सेल्स A10:A12 का उपयोग पहले सीरीज़ के पहले तीन लेबल के लिए करता है, सेल्स से लेबल सक्षम करता है, और परिणाम `resultchart.pptx` में सहेजता है।

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

## **वर्कशीट्स का प्रबंधन करें**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) मेथड चार्ट वर्कबुक में वर्कशीट्स तक पहुंच प्रदान करता है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल में प्रिंट करता है।

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

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो सीरीज़ नाम विभिन्न डेटा स्रोतों से सेट करता है। पहला नाम स्ट्रिंग लिटरल से लिया गया है; दूसरा नाम वर्कशीट 0 पर सेल C1 से लिया गया है। [DataSourceType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datasourcetype/) एनोमरेशन प्रत्येक नाम के स्रोत को चुनता है। परिणाम `pres.pptx` में सहेजा जाता है।

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मैट का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मैट को समर्थन नहीं देता। आप [ChartData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/workbooktype/) एनोमरेशन के साथ उपयोग कर असमर्थित फ़ॉर्मैट का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं। यह उदाहरण `sample.pptx` की पहली स्लाइड पर आकारों की जाँच करता है, गैर-चार्ट आकारों को छोड़ता है, और प्रत्येक .xlsb एम्बेडेड वर्कबुक वाले चार्ट के लिए निदान संदेश प्रिंट करता है।

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

Aspose.Slides चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक्स के उपयोग का समर्थन करता है।

### **बाहरी वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) और [setExternalWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, उसकी वर्कबुक को `externalWorkbook1.xlsx` में लिखता है, और फ़ाइल लिखने के बाद उसे चार्ट डेटा स्रोत के रूप में नियत करता है। लिंक्ड प्रस्तुति `externalWorkbook.pptx` में सहेजी जाती है।

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

### **बाहरी वर्कबुक नियत करें**

[setExternalWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) मेथड का उपयोग करके आप एक बाहरी वर्कबुक को चार्ट के डेटा स्रोत के रूप में नियत कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को भी अपडेट कर सकता है (यदि बाद वाला स्थानांतरित किया गया हो)।

हालांकि आप रिमोट लोकेशन या संसाधनों में संग्रहीत वर्कबुक्स के डेटा को संपादित नहीं कर सकते, फिर भी इन्हें बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया गया है, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण कार्य निर्देशिका में `externalWorkbook.xlsx` की आवश्यकता रखता है। उसकी वर्कशीट `Sheet1` में B1 में एक सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान होने चाहिए। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#setRange) का उपयोग करके A1:B4 को एक सीरीज़ और तीन श्रेणियों के रूप में मैप करता है। परिणाम `Presentation_with_externalWorkbook.pptx` में सहेजा जाता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) का `updateChartData` पैरामीटर यह नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `false` हो, तो केवल वर्कबुक पथ अपडेट किया जाता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता, इसलिए वर्कबुक उपलब्ध नहीं भी हो सकती।
* जब `updateChartData` `true` हो, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट किया जाता है।

निम्न उदाहरण `updateChartData` को `false` पर सेट करके प्लेसहोल्डर URL नियत करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **चार्ट का बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक को पहचानने के लिए, पहले जाँचें कि चार्ट बाहरी डेटा स्रोत का उपयोग करता है या नहीं। यदि हाँ, तो इन चरणों का पालन करके वर्कबुक पथ प्राप्त करें।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. शून्य-आधारित इंडेक्स द्वारा पहली स्लाइड तक पहुंचें।
1. जांचें कि पहला आकार एक चार्ट है या नहीं।
1. चार्ट डेटा स्रोत प्रकार पढ़ें।
1. यदि स्रोत एक बाहरी वर्कबुक है, तो उसका पथ पढ़ें।

यह उदाहरण पहले उदाहरण में निर्मित `externalWorkbook.pptx` खोलता है और पहली स्लाइड पर पहले आकार की जाँच करता है। यदि वह बाहरी वर्कबुक से लिंक्ड चार्ट है, तो यह कंसोल में [getExternalWorkbookPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) को प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी `Result.pptx` में सहेजता है।

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

आप बाहरी वर्कबुक्स के डेटा को उसी प्रकार संपादित कर सकते हैं जैसा आप आंतरिक वर्कबुक्स के साथ करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद उत्पन्न होता है।

यह उदाहरण `presentation.pptx` की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट हो और एक सुलभ बाहरी वर्कबुक उपलब्ध हो। यह पहले सीरीज़ के पहले डेटा पॉइंट का सेल-आधारित मान 100 पर सेट करता है और प्रस्तुति को `presentation_out.pptx` में सहेजता है। सेल मानों का संपादन लिंक्ड बाहरी XLSX फ़ाइल को अपडेट कर सकता है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिए एक प्रतिलिपि का उपयोग करें।

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

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करें**

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक का पुनर्निर्माण कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/) बनाएं, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) को कॉल करें, और [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को `true` सेट करें, फिर प्रस्तुति खोलें।

निम्न जावास्क्रिप्ट उदाहरण `presentation.pptx` खोलता है, जिसकी पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए जो अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है, और पुनर्प्राप्त डेटा को [Chart.getChartData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/#getChartData) तथा [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

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

        // यहाँ पुनः प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकता है। केवल तब पुनर्प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग स्वीकार्य विकल्प हो, क्योंकि कैश में बाहरी वर्कबुक में प्रस्तुति के अंतिम अपडेट के बाद किए गए परिवर्तन नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से लिंक्ड है?**

हां। चार्ट के पास एक [data source type](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#getDataSourceType) और एक [path to an external workbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं ताकि पुष्टि हो सके कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयर्स पर स्थित वर्कबुक्स का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक्स को सीधे संपादित नहीं किया जा सकता—वे केवल स्रोत के रूप में उपयोग होते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को अधिलेखित करता है?**

प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) संग्रहीत करती है। सेल-आधारित चार्ट डेटा का संपादन लिंक्ड स्थानीय XLSX फ़ाइल को भी अपडेट कर सकता है। यदि मूल फ़ाइल अपरिवर्तित रहनी चाहिए, तो वर्कबुक की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड-प्रोटेक्टेड है तो क्या करें?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले सुरक्षा हटाएँ या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/java/) का उपयोग करके) और उस कॉपी को लिंक करें।

**क्या कई चार्ट्स एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल को इंगित करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट्स पर असर पड़ेगा।