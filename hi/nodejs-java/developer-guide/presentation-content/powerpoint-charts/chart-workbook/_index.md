---
title: प्रस्तुतियों में जावास्क्रिप्ट का उपयोग करके चार्ट वर्कबुक प्रबंधित करें
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
description: "Aspose.Slides for Node.js via Java को खोजें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को सहजता से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट वर्कबुक्स के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को कैसे पढ़ा और लिखा जाए, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग किया जाए, वर्कशीट कलेक्शन्स तक पहुंचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट किया जाए।

यह बाहरी वर्कबुक्स को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और असाइन किया जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित किया जाए।

गुम डेटा को दर्शाने वाली वर्कबुक सेल्स के लिए, देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/nodejs-java/chart-series/) ताकि खाली कोशिका और शून्य के बीच अंतर तथा उपलब्ध डिस्प्ले मोड्स की लाइन-चार्ट तुलना को समझा जा सके।

## **छिपी हुई पंक्तियों और स्तम्भों से डेटा शामिल करें**

छिपी हुई वर्कशीट पंक्तियों और स्तम्भों से डेटा प्लॉट करता है या नहीं, इसे नियंत्रित करने के लिए [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) का उपयोग करें। इसे `true` सेट करने पर केवल दिखाई देने वाली कोशिकाएँ प्लॉट होंगी, या `false` सेट करने पर दिखाई देने वाली और छिपी हुई दोनों कोशिकाएँ शामिल होंगी। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तम्भों को छिपाती या प्रदर्शित नहीं करती।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहली स्लाइड पर पहला आकार एक कॉलम चार्ट है। अंतर्निहित वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तम्भ C छिपी हुई हैं, लेकिन उनकी कोशिकाएँ अभी भी मान रखती हैं।

| Worksheet row | A: Month | B: Retail | C: Wholesale (hidden column) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (hidden row) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुंचने के लिए [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) का उपयोग करें और उनकी छिपी अवस्था को जांचने के लिए [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) पढ़ें। यह मेथड छिपी अवस्था को बदले बिना रिपोर्ट करता है। इस फ़ाइल में, B2 दृश्य है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तम्भ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण के लिये, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: अंतर्निहित वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) से रखे रखें और इसे [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) से पुनःलोड करें। सभी कोशिकाओं को शामिल करने पर, छिपी फ़रवरी श्रेणी सहित पूर्ण रेंज पुनर्स्थापित करने के लिये भी [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) का उपयोग करें। बस फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिये अपर्याप्त है। उदाहरण लिखने की विधि को पास करने से पहले लौटाए गए Node.js बफ़र को Java बाइट एरे में परिवर्तित करता है।

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

                // एंबेडेड वर्कबुक से चार्ट डेटा रीफ़्रेश करें।
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

उदाहरण दो संस्करणों में प्रस्तुति को सहेजता है: एक में केवल दृश्य रिटेल मान (10 और 20) हैं, और दूसरा में सभी छह मान हैं। नीचे दी गई छवियाँ दो प्लॉटिंग मोड को दर्शाती हैं। पंक्ति 3 और स्तम्भ C दोनों अंतर्निहित वर्कबुक्स में छिपे रहते हैं।

| केवल दृश्य कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![केवल दृश्य कोशिकाएँ: जनवरी और मार्च के लिए रिटेल मान 10 और 20.](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी और मार्च के लिए रिटेल और होलसेल मान.](hidden_cells_False.png) |

एक मान वाला छिपा सेल खाली सेल से अलग होता है। [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) नियंत्रित करता है कि गुम मान कैसे प्रदर्शित किए जाएँ; यह छिपा स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिये देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/nodejs-java/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट की डेटा रेंज प्राप्त करें**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंज को जांचें ताकि यह पहचाना जा सके कि प्रत्येक चार्ट कौन सी वर्कशीट कोशिकाएँ उपयोग करता है। [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) मेथड वर्तमान डेटा रेंज को वर्कशीट‑क्वालीफ़ाईड फ़ॉर्मूला के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` वर्कशीट का नाम है, `!` इसे कोशिका रेंज से अलग करता है, और `$A$1:$D$5` सेल्स A1 से D5 तक निर्दिष्ट करता है। डॉलर संकेत निरपेक्ष पंक्ति और स्तम्भ संदर्भ दर्शाते हैं।

यह मेथड चार्ट या उसकी वर्कबुक बदले बिना वर्तमान रेंज पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक उपयोग नहीं करता, तो यह `InvalidOperationException` थ्रो करता है। अधिक जानकारी के लिये देखें [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकारों को चार्ट के लिये जांचता है। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक उपयोग नहीं करता, तो यह संदेश प्रिंट कर अगले चार्ट पर जारी रहता है।

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

Aspose.Slides for Node.js via Java [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) और [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक्स (Aspose.Cells के साथ संपादित) को पढ़ने और लिखने की अनुमति देता है। **ध्यान दें** कि चार्ट डेटा को उसी प्रकार व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह उदाहरण पहली स्लाइड के पहले आकार के रूप में एक चार्ट वाली प्रस्तुति का उपयोग करता है। यह अंतर्निहित वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, और उसी वर्कबुक को वापस लिखता है। परिवर्तन स्मृति में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

जब आप संशोधित वर्कबुक को अंतर्निहित वर्कबुक के स्थान पर रखते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी कलेक्शन्स को बरकरार रखता है। यह विसंगति [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) को इंडेक्स‑आउट‑ऑफ़‑रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को वापस लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहला आकार एक चार्ट है। टिप्पणी दर्शाती है कि जहाँ वर्कबुक संपादन होगा; चलने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को वैध करता है।

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

        // वर्कबुक बाइट्स को यहाँ संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

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

संकलनों को साफ़ करने से पुरानी डेटा रेफ़रेंसेज़ हट जाती हैं इससे पहले कि वर्कबुक वापस लिखी जाए। अपडेटेड वर्कबुक के लिये आवश्यक श्रृंखला और श्रेणी मैपिंग को पुनः बनाएं इससे पहले कि चार्ट उपयोग किया जाए।

## **वर्कबुक कोशिकाओं के लिये कस्टम नंबर फ़ॉर्मेट सेट करें**

एक चार्ट की अंतर्निहित वर्कबुक में संख्यात्मक मानों को कैसे दिखाना है, इसे नियंत्रित करने के लिये [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) का उपयोग करें। उदाहरण के लिये, एक रिपोर्ट को परिवर्तन दर को चार दशमलव स्थानों के साथ प्रतिशत के रूप में और गुणांक को पाँच दशमलव स्थानों के साथ प्रदर्शित करने की आवश्यकता हो सकती है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिये उपलब्ध रहें।

एक नंबर फ़ॉर्मेट केवल प्रदर्शित रूप को बदलता है, संग्रहीत मान को नहीं। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` के रूप में दिखाता है; यह संग्रहीत संख्या को `12.5` में नहीं बदलता। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को राउंड किए। यदि कस्टम फ़ॉर्मेट खाली स्ट्रिंग (`""`) है, तो [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) द्वारा लौटाया गया फ़ॉर्मेट उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसकी कोशिकाओं तक पहुंचता है [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) के द्वारा। वर्कशीट 0 में, B2 में परिवर्तन दर और C2 में गुणांक है। दोनों कोशिकाएँ चार्ट मान प्रदान करती हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़ी मान लेबल भी सक्षम करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

वर्कबुक सेल फ़ॉर्मेट्स चार्ट अक्षों या डेटा लेबल्स पर सीधे सेट किए गए फ़ॉर्मेट्स से अलग होते हैं। इस उदाहरण में प्रत्येक लेबल अपना स्रोत सेल मान दिखाता है क्योंकि [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) `true` है, और स्रोत नंबर फ़ॉर्मेट का अनुसरण करता है क्योंकि [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true` है। सहेजने और पुनः खोलने के बाद लेबल्स `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दिखाया गया है। ऊर्ध्वाधर अक्ष अपना स्वयं का नंबर फ़ॉर्मेट उपयोग करता है, जिसे [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) से `0.00` सेट किया गया है, और [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) `false` है।

डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिये, उसका स्रोत‑लिंक फ़्लैग `false` सेट करें और [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) से फ़ॉर्मेट असाइन करें। यह वर्कबुक सेल के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहला मान `0.13` दिखाएगा, जबकि B2 अभी भी `12.5000%` दिखाएगा। सीधे लेबल फ़ॉर्मेटिंग के लिये देखें [Chart Data Labels](/slides/hi/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

नीचे दी गई छवि सहेजी गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![स्रोत‑लिंक्ड लेबल्स के साथ कॉलम चार्ट जो 12.5000% और 0.12346 दिखाते हैं तथा स्वतंत्र रूप से फ़ॉर्मेटेड संख्यात्मक अक्ष.](custom-cell-formats.png)

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक सेल्स के टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण एक मौजूदा प्रस्तुति की पहली स्लाइड में एक बबल चार्ट जोड़ता है जिसमें डिफ़ॉल्ट डेटा है। यह वर्कशीट 0 में A10:A12 कोशिकाओं को पहली श्रृंखला के पहले तीन लेबल के लिये उपयोग करता है, सेल‑आधारित लेबल्स को सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) मेथड एक चार्ट वर्कबुक में वर्कशीट्स तक पहुंच प्रदान करता है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

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

श्रृंखला बिंदु मानों को सीधे संख्यात्मक लिटेरल्स के रूप में भी संग्रहीत किया जा सकता है। पूर्ण उदाहरण के लिये देखें [Set Series Values Using Numeric Literals](/slides/hi/nodejs-java/chart-series/#set-series-values-using-numeric-literals) जो उन्हें सहेजता और पढ़ता है। बिंदु मानों का स्रोत प्रकार चार्ट के आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन से अलग है; संख्यात्मक लिटेरल्स का उपयोग स्वाभाविक रूप से अंतर्निहित वर्कबुक को नहीं हटाता।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नामों को विभिन्न डेटा स्रोतों के साथ सेट करता है। पहला नाम स्ट्रिंग लिटेरल है; दूसरा वर्कशीट 0 की कोशिका C1 है। [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) एन्यूमरेशन प्रत्येक नाम के लिये स्रोत चुनता है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति को सहेजता है।

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

## **असमर्थित अंतर्निहित वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता। आप [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) एन्यूमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों की जाँच करता है, गैर‑चार्ट आकारों को छोड़ता है, और प्रत्येक चार्ट के लिये एक डायग्नोस्टिक संदेश प्रिंट करता है जिसमें .xlsb वर्कबुक एम्बेडेड है।

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

        // यहाँ समर्थित चार्ट वर्कबुक डेटा पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिये डेटा स्रोत के रूप में बाहरी वर्कबुक्स का उपयोग समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) और [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) का उपयोग करके एक एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक को निर्यात करता है। फ़ाइल लिखना पूरा होने के बाद बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, फिर लिंक्ड प्रस्तुति को सहेजता है।

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

### **एक बाहरी वर्कबुक असाइन करें**

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) मेथड का उपयोग करके आप एक चार्ट को उसके डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिये भी उपयोग किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

हालाँकि आप रिमोट लोकेशन्स या संसाधनों में संग्रहीत वर्कबुक्स के डेटा को संपादित नहीं कर सकते, आप अभी भी ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिये एक सापेक्ष पथ प्रदान किया जाता है, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों से मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) का `updateChartData` पैरामीटर निर्धारित करता है कि वर्कबुक लोड की जाए या नहीं।

* जब `updateChartData` `false` है, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता, इसलिए वर्कबुक अनुपलब्ध भी हो सकती है।
* जब `updateChartData` `true` है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट किया जाता है।

निम्न उदाहरण `updateChartData` को `false` सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **एक चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक को पहचानने के लिये, जांचें कि चार्ट बाहरी डेटा स्रोत उपयोग करता है या नहीं और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण एक लिंक्ड बाहरी वर्कबुक वाली प्रस्तुति की पहली स्लाइड के पहले आकार की जाँच करता है। यदि वह एक चार्ट है जो बाहरी वर्कबुक से जुड़ा है, तो उदाहरण कंसोल में [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) प्रिंट करता है। फिर प्रस्तुति की एक प्रति सहेजता है।

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

आप बाहरी वर्कबुक्स के डेटा को उसी प्रकार संपादित कर सकते हैं जैसा आप आंतरिक वर्कबुक्स को करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाता, तो एक अपवास्था (exception) फेंकी जाती है।

यह उदाहरण पहली स्लाइड के पहले आकार के रूप में एक चार्ट का उपयोग करता है जो एक सुलभ बाहरी वर्कबुक से जुड़ा है। यह पहले श्रृंखला के पहले डेटा पॉइंट को 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों का संपादन लिंक्ड बाहरी XLSX फाइल को अपडेट कर सकता है, इसलिए मूल वर्कबुक को संरक्षित रखने हेतु एक कॉपी का प्रयोग करें।

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

यदि कोई चार्ट ऐसी बाहरी वर्कबुक उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश्ड डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) बनाएँ, फिर [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) को कॉल करें, और [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) को `true` सेट करें, फिर प्रस्तुति खोलें।

निम्न JavaScript उदाहरण पहले आकार के रूप में एक चार्ट के लिये वर्कबुक डेटा को पुनः प्राप्त करता है जो पहली स्लाइड पर है और अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है। यह पुनः प्राप्त डेटा को [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) और [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) के माध्यम से एक्सेस करता है:

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

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनः प्राप्ति अक्षम है, तो Aspose.Slides अपवास्था फेंकेगा। पुनः प्राप्ति तभी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग स्वीकार्य फॉलबैक हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए बदलाव प्रतिबिंबित नहीं हो सकते।

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट के पास [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) और एक [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक्स के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयर पर स्थित वर्कबुक्स का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालाँकि, Aspose.Slides से रिमोट वर्कबुक्स को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) संग्रहीत करती है। सेल‑आधारित चार्ट डेटा का संपादन भी लिंक्ड स्थानीय XLSX फ़ाइल को अपडेट कर सकता है। यदि मूल फ़ाइल को अपरिवर्तित रखना है, तो वर्कबुक की एक कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित हो तो क्या करें?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले सुरक्षा हटा दी जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिये, [Aspose.Cells](https://reference.aspose.com/cells/java/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट्स एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो फ़ाइल को अपडेट करने से प्रत्येक चार्ट में अगले डेटा लोड पर परिवर्तन प्रतिबिंबित होंगे।