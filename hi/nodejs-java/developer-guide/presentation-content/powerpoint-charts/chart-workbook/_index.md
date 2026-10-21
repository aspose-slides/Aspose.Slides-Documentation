---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
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
- वर्कबुक रिकवरी
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java को खोजें: PowerPoint और OpenDocument प्रारूपों में चार्ट वर्कबुक को सहजता से प्रबंधित करें जिससे आपके प्रस्तुतिकरण डेटा को सरल बनाया जा सके।"
---
## **परिचय**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीकों को समझाता है। यह वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ने और लिखने, वर्कबुक कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करने, वर्कशीट संग्रहों तक पहुँचने, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट करने के तरीकों को दिखाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और असाइन किया जाता है, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाता है, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित किया जाता है।

गायब डेटा को दर्शाने वाली वर्कबुक कोशिकाओं के बारे में, खाली कोशिका और शून्य के बीच अंतर के लिए [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/nodejs-java/chart-series/) देखें, साथ ही उपलब्ध प्रदर्शन मोड्स की लाइन-चार्ट तुलना देखें।

## **छिपी हुई पंक्तियों और स्तंभों से डेटा शामिल करें**

एक चार्ट को छिपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करना है या नहीं, यह नियंत्रित करने के लिए [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) का उपयोग करें। इसे `true` सेट करने से केवल दृश्यमान कोशिकाएँ प्लॉट होंगी, या `false` सेट करने से दृश्यमान और छिपी दोनों कोशिकाएँ शामिल होंगी। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या दर्शाती नहीं है।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहली स्लाइड पर पहला आकार एक कॉलम चार्ट है। एंबेडेड वर्कशीट, `Sheet1`, में स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: महीना | B: रिटेल | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (छिपी पंक्ति) | February | 40 | 60 |
| 4 | March | 20 | 50 |

स्रोत कोशिकाओं तक पहुँचने के लिए [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) का उपयोग करें और उनकी छिपी स्थिति का निरीक्षण करने के लिए [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) पढ़ें। यह विधि छिपी स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से है, और C2 छिपे स्तंभ से है; उदाहरण क्रमशः `false`, `true`, `true` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एंबेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) से बनाये रखें और उसे [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) से पुनः लोड करें। सभी कोशिकाओं को शामिल करने के लिए, छिपी हुई फरवरी श्रेणी को पुनर्स्थापित करने हेतु [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) का भी उपयोग करें। केवल फ़्लैग बदलना इस नमूने की कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए पर्याप्त नहीं है। उदाहरण लौटाए गए Node.js बफ़र को Java बाइट एरे में परिवर्तित करता है और फिर लिखने की विधि को पास करता है।

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
                // छिपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

उदाहरण दो संस्करणों में प्रस्तुतिकरण को सहेजता है: एक जिसमें केवल दृश्यमान रिटेल मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे की छवियाँ दो प्लॉटिंग मोड्स को दर्शाती हैं। पंक्ति 3 और स्तंभ C दोनों एंबेडेड वर्कबुक में छिपे रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए रिटेल मान 10 और 20।](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फरवरी और मार्च के लिए रिटेल और थोक मान।](hidden_cells_False.png) |

एक मान वाले छिपे हुए कोशिका का अंतर एक खाली कोशिका से होता है। [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) यह नियंत्रित करता है कि गायब मान कैसे दिखाए जाएँ; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिये देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/nodejs-java/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट की डेटा रेंज प्राप्त करें**

मौजूदा प्रस्तुतिकरण में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंज की जाँच करें ताकि यह पहचाना जा सके कि प्रत्येक चार्ट कौन‑से वर्कशीट कोशिकाओं का उपयोग करता है। [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) विधि वर्तमान डेटा रेंज को वर्कशीट‑योग्य फ़ॉर्मूला के रूप में लौटाती है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` वर्कशीट का नाम है, `!` उसे रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाओं A1‑D5 को शामिल करता है। डॉलर संकेत निरपेक्ष पंक्ति और स्तंभ संदर्भ दर्शाते हैं।

यह विधि चार्ट या उसके वर्कबुक को बदले बिना वर्तमान रेंज को पढ़ती है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता है, तो यह `InvalidOperationException` फेंकता है। अधिक जानकारी के लिये देखें [ChartData API संदर्भ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुतिकरण खोलता है और प्रत्येक स्लाइड पर आकारों की जाँच करता है कि कौन‑से चार्ट हैं। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह संदेश प्रिंट करता है और अगले चार्ट पर आगे बढ़ता है।

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

Aspose.Slides for Node.js via Java, [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) और [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) विधियों के माध्यम से चार्ट डेटा वर्कबुक (Aspose.Cells से संपादित) को पढ़ने और लिखने की सुविधा देता है। **नोट** कि चार्ट डेटा को उसी तरह व्यवस्थित होना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह उदाहरण पहली स्लाइड पर पहला आकार एक चार्ट वाला प्रस्तुतिकरण उपयोग करता है। यह एंबेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा श्रृंखलाएँ और श्रेणियाँ साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुतिकरण को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट सत्यापित करें**

जब आप एंबेडेड वर्कबुक को संशोधित संस्करण से बदलते हैं, तो चार्ट अपनी मूल श्रृंखलाओं और श्रेणी संग्रहों को बरकरार रखता है। यह असंगतता [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) को इंडेक्स‑आउट‑ऑफ़‑रेंज त्रुटि के साथ विफल कर सकती है। अद्यतन वर्कबुक को वापस लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहला आकार एक चार्ट उपयोग करता है। टिप्पणी उन स्थानों को दर्शाती है जहाँ वर्कबुक संपादन किया जाएगा; चलाने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को सत्यापित करता है।

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

संग्रहों को साफ़ करने से लिखे जाने से पहले पुराने डेटा रेफ़रेंस हट जाते हैं। अद्यतन वर्कबुक के लिये आवश्यक श्रृंखलाएँ और श्रेणी मैपिंग पुनः बनाएँ, फिर चार्ट का उपयोग करें।

## **वर्कबुक कोशिकाओं के लिए कस्टम संख्या प्रारूप सेट करें**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) का उपयोग करके आप तय कर सकते हैं कि चार्ट के एंबेडेड वर्कबुक में संख्यात्मक मान कैसे दिखेंगे। उदाहरण के लिए, एक रिपोर्ट को रूपांतरण दर को चार दशमलव स्थान के साथ प्रतिशत में तथा गुणांक को पाँच दशमलव स्थान के साथ दिखाना पड़ सकता है। दोनों मान संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिये उपलब्ध रहें।

संख्या प्रारूप दिखावे को बदलता है, न कि संग्रहीत मान को। `0.0000%` प्रारूप `0.125` को `12.5000%` दिखाता है; यह संग्रहीत संख्या को `12.5` नहीं बनाता। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को गोल किए। यदि कस्टम प्रारूप खाली स्ट्रिंग (`""`) है, तो [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) द्वारा लौटाया गया प्रारूप उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसकी कोशिकाओं को [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) के माध्यम से एक्सेस करता है। वर्कशीट 0 में, B2 में रूपांतरण दर और C2 में गुणांक है। दोनों कोशिकाएँ चार्ट मान प्रदान करती हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़े मान लेबल भी सक्रिय करता है।

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

वर्कबुक कोशिका प्रारूप चार्ट अक्ष या डेटा लेबल पर सीधे सेट किए गए प्रारूपों से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपना स्रोत कोशिका मान प्रदर्शित करता है क्योंकि [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) `true` पर सेट है, और स्रोत संख्या प्रारूप का पालन करता है क्योंकि [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true` पर सेट है। सहेजने और पुनः खोलने के बाद, लेबल `12.5000%` और `0.12346` दिखाते हैं, जैसा नीचे दिखाया गया है। ऊर्ध्वाधर अक्ष अपना स्वयं का संख्या प्रारूप उपयोग करता है, जिसे [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) द्वारा `0.00` और [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) `false` पर सेट किया गया है।

डेटा लेबल को स्वतंत्र रूप से स्वरूपित करने हेतु, उसके स्रोत‑लिंक फ़्लैग को `false` सेट करें और [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) द्वारा एक प्रारूप असाइन करें। यह वर्कबुक कोशिका के प्रारूप को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल प्रारूप `0.00` पहली मान को `0.13` दिखाता है, जबकि B2 अभी भी `12.5000%` दिखाता है। सीधे लेबल स्वरूपण के लिये देखें [Chart Data Labels](/slides/hi/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

![स्रोत-लिंक लेबल्स के साथ कॉलम चार्ट जिसमें 12.5000% और 0.12346 दिखाए गए हैं और स्वतंत्र रूप से स्वरूपित संख्यात्मक अक्ष।](custom-cell-formats.png)

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं के टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुतिकरण की पहली स्लाइड पर एक बबल चार्ट जोड़ता है, जो डिफ़ॉल्ट डेटा रखता है। यह वर्कशीट 0 की कोशिकाएँ A10:A12 को पहली श्रृंखला के पहले तीन लेबल के लिए उपयोग करता है, कोशिकाओं से लेबल सक्षम करता है, और अद्यतन प्रस्तुतिकरण को सहेजता है।

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

## **वर्कशीट्स को प्रबंधित करें**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) विधि चार्ट वर्कबुक में मौजूद वर्कशीट्स की पहुँच प्रदान करती है। यह उदाहरण एक डिफ़ॉल्ट डेटा वाले पाई चार्ट को बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

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

यह उदाहरण डिफ़ॉल्ट डेटा वाले एक 3D कॉलम चार्ट को बनाता है और विभिन्न डेटा स्रोतों का उपयोग करके दो श्रृंखला नाम सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा नाम वर्कशीट 0 के सेल C1 से लिया गया है। [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) enumeration प्रत्येक नाम के लिये स्रोत चुनता है। उदाहरण अद्यतन श्रृंखला नामों के साथ प्रस्तुतिकरण को सहेजता है।

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

## **असमर्थित एंबेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता जो कुछ चार्ट में एंबेडेड हो सकते हैं। आप [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` विधि को [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) enumeration के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुतिकरण की पहली स्लाइड पर आकारों की जाँच करता है, गैर‑चार्ट आकारों को छोड़ता है, और प्रत्येक .xlsb एंबेडेड वर्कबुक वाले चार्ट के लिये एक डायग्नोस्टिक संदेश प्रिंट करता है।

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

Aspose.Slides चार्ट्स के लिये बाहरी वर्कबुक को डेटा स्रोत के रूप में उपयोग करने का समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएँ**

[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) और [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) का उपयोग करके एंबेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा वाला एक पाई चार्ट बनाता है और उसकी वर्कबुक को निर्यात करता है। फ़ाइल लिखने के बाद इसे बाहरी वर्कबुक के रूप में डेटा स्रोत असाइन करता है, फिर लिंक किया गया प्रस्तुतिकरण सहेजता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) विधि का उपयोग करके आप किसी चार्ट को बाहरी वर्कबुक को डेटा स्रोत के रूप में असाइन कर सकते हैं। यह विधि का उपयोग बाहरी वर्कबुक के पथ को अपडेट करने के लिये भी किया जा सकता है (अगर वह स्थानांतरित किया गया हो)।

जबकि आप रिमोट लोकेशन या संसाधनों में संग्रहीत वर्कबुक डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि एक बाहरी वर्कबुक का रिलेटिव पथ दिया गया है, तो वह स्वतः पूर्ण पथ में बदल दिया जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जहाँ वर्कशीट `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों से मैप करता है। फिर लिंक किए गए चार्ट के साथ प्रस्तुतिकरण को सहेजता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) का `updateChartData` पैरामीटर यह नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `false` है, तो केवल वर्कबुक पथ अपडेट किया जाता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता, इसलिए वर्कबुक अनुपलब्ध हो सकता है।
* जब `updateChartData` `true` है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट किया जाता है।

निम्न उदाहरण `updateChartData` को `false` पर सेट करके प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुतिकरण को सहेजता है।

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

किसी चार्ट से जुड़ी वर्कबुक को पहचानने के लिये, जाँचें कि चार्ट बाहरी डेटा स्रोत का उपयोग करता है या नहीं और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण प्रस्तुतिकरण की पहली स्लाइड पर पहले आकार को inspe
क्शन करता है, यदि वह बाहरी वर्कबुक से लिंक किया हुआ चार्ट है तो वह [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) को कंसोल पर प्रिंट करता है। फिर प्रस्तुतिकरण की एक कॉपी सहेजता है।

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

आप बाहरी वर्कबुक के डेटा को उसी प्रकार संपादित कर सकते हैं जैसा आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड पर पहला आकार एक चार्ट है और वह एक सुलभ बाहरी वर्कबुक से जुड़ा है। यह पहली श्रृंखला के पहले डेटा बिंदु की सेल‑बैक्ड मान को `100` पर सेट करता है और अद्यतन प्रस्तुतिकरण को सहेजता है। सेल मानों को संपादित करने से लिंक की गई बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिये एक कॉपी का उपयोग करें।

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

### **चार्ट कैश से वर्कबुक को पुनः प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रस्तुतिकरण में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः बना सकता है। [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) बनाइए, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) को कॉल करें, और [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) को `true` सेट करें, फिर प्रस्तुतिकरण खोलें।

निम्न JavaScript उदाहरण एक ऐसे चार्ट के लिये वर्कबुक डेटा को पुनः प्राप्त करता है जो पहली स्लाइड पर पहला आकार है और अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है। यह पुनः प्राप्त डेटा को [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) और [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) के माध्यम से एक्सेस करता है:

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

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनः प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकेगा। केवल तभी पुनः प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा उपयोग करना स्वीकार्य बैक‑अप हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए बाद के परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एंबेडेड वर्कबुक से लिंक है?**

हाँ। एक चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) और एक [एक बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़कर सुनिश्चित कर सकते हैं कि एक बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पाथ में परिवर्तित हो जाता है। प्रस्तुतिकरण PPTX फ़ाइल में पूर्ण पाथ संग्रहीत करता है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करने की आवश्यकता पड़ सकती है।

**क्या मैं नेटवर्क संसाधनों/शेयर्स पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुतिकरण सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुतिकरण एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) संग्रहीत करता है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक की गई स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल वर्कबुक अपरिवर्तित रहना आवश्यक है, तो उसकी एक कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक बनाते समय पासवर्ड स्वीकार नहीं करता। आम तौर पर पहले सुरक्षा हटाना या किसी डिक्रिप्टेड कॉपी तैयार करना (उदाहरण के लिये [Aspose.Cells](https://reference.aspose.com/cells/java/) का उपयोग करके) उचित समाधान है।

**क्या विभिन्न चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपनी स्वयं की लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल में किए गए अपडेट प्रत्येक चार्ट में अगली बार डेटा लोड होने पर प्रतिबिंबित होंगे।