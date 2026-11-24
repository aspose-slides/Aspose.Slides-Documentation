---
title: प्रेज़ेंटेशन्स में जावास्क्रिप्ट का उपयोग करके चार्ट वर्कबुक प्रबंधन
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/nodejs-java/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- कार्यपत्रक
- डेटा स्रोत
- बाहरी वर्कबुक
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java की खोज करें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को सहजता से प्रबंधित करें ताकि आपकी प्रस्तुति डेटा का प्रवाह सरल हो जाए।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट कार्यपुस्तकों के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि कार्यपुस्तक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ा और लिखा जाए, कार्यपुस्तक कोशिकाओं को चार्ट डेटा लेबल के रूप में कैसे उपयोग किया जाए, कार्यपत्रक संग्रहों तक कैसे पहुँचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट किया जाए।

यह बाहरी कार्यपुस्तकों को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरणों में दिखाया गया है कि बाहरी कार्यपुस्तक कैसे बनाई और असाइन की जाए, चार्ट से जुड़ी बाहरी कार्यपुस्तक का पथ कैसे प्राप्त किया जाए, और जब कार्यपुस्तक उपलब्ध हो तो चार्ट डेटा कैसे संपादित किया जाए।

छूटे हुए डेटा का प्रतिनिधित्व करने वाली कार्यपुस्तक कोशिकाओं के लिए, देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/nodejs-java/chart-series/) जिसमें खाली कोशिका और शून्य के बीच का अंतर तथा उपलब्ध प्रदर्शन मोड की लाइन‑चार्ट तुलना दिखाए गए हैं।

## **छिपी हुई पंक्तियों और स्तंभों से डेटा शामिल करें**

चार्ट को छिपी हुई कार्यपत्रक पंक्तियों और स्तंभों से डेटा प्लॉट करना है या नहीं, इसे नियंत्रित करने के लिये [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) का उपयोग करें। केवल दृश्यमान कोशिकाएँ प्लॉट करने के लिये `true` सेट करें, या दृश्यमान और छिपी दोनों कोशिकाएँ शामिल करने के लिये `false` सेट करें। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह कार्यपत्रक पंक्तियों या स्तंभों को छिपाती या दिखाती नहीं है।

[sample presentation](hidden-source-data.pptx) में पहली स्लाइड पर पहली आकृति के रूप में एक स्तंभ चार्ट है। एंबेडेड कार्यपत्रक, `Sheet1`, में स्रोत सीमा `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनके कोशिकाओं में अभी भी मान हैं।

| कार्यपत्रक पंक्ति | A: माह | B: खुदरा | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फरवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुँचने के लिये [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) का उपयोग करें और उनकी छिपी स्थिति को जांचने के लिये [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) पढ़ें। यह विधि छिपी स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण के लिये, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा रीफ़्रेश करें: एंबेडेड कार्यपुस्तक को [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) से रखें और [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) से पुनः लोड करें। सभी कोशिकाएँ शामिल करने के लिये, छिपी फ़रवरी श्रेणी को पुनर्स्थापित करने के लिये भी [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिये पर्याप्त नहीं है। उदाहरण लौटाए गये Node.js बफ़र को Java बाइट एरे में बदलता है और फिर लिखने की विधि को पास करता है।

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

            // एंबेडेड कार्यपुस्तक से चार्ट डेटा को रीफ़्रेश करें।
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

उदाहरण दो संस्करणों की प्रस्तुति सहेजता है: एक जिसमें केवल दृश्यमान खुदरा मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे की तस्वीरें दो प्लॉटिंग मोड को दर्शाती हैं। पंक्ति 3 और स्तंभ C दोनों एंबेडेड कार्यपुस्तकों में छिपे रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक छिपी हुई कोशिका जिसमें मान है, वह खाली कोशिका से अलग होती है। [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) नियंत्रित करता है कि अनुपलब्ध मान कैसे दिखाए जाएँ; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिये देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/nodejs-java/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट के डेटा रेंज को प्राप्त करें**

किसी मौजूदा प्रस्तुति में कार्यपुस्तक डेटा को अपडेट करने से पहले, स्रोत रेंज की जाँच करें ताकि यह पता चल सके कि प्रत्येक चार्ट कौन‑सी कार्यपत्रक कोशिकाएँ उपयोग करता है। [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) विधि वर्तमान डेटा रेंज को कार्यपत्रक‑योग्य सूत्र के रूप में लौटाती है, जैसे `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` कार्यपत्रक का नाम है, `!` इसे कोशिका रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाओं A1‑से‑D5 को दर्शाता है। डॉलर संकेत स्थायी पंक्ति और स्तंभ संदर्भ दर्शाते हैं।

यह विधि वर्तमान रेंज को पढ़ती है बिना चार्ट या उसकी कार्यपुस्तक को बदले। यदि चार्ट कार्यपुस्तक को डेटा स्रोत के रूप में नहीं उपयोग करता, तो यह `InvalidOperationException` फेंकता है। अधिक जानकारी हेतु देखें [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकृतियों की जाँच करता है ताकि चार्ट मिलें। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट कार्यपुस्तक का उपयोग नहीं करता, तो वह एक संदेश प्रिंट करता है और अगले चार्ट पर जारी रहता है।

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

## **कार्यपुस्तक से चार्ट डेटा को पढ़ें और लिखें**

Aspose.Slides for Node.js via Java, [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) और [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) विधियों को प्रदान करता है जिससे आप चार्ट डेटा कार्यपुस्तकों (जो Aspose.Cells से संपादित डेटा रखते हैं) को पढ़ और लिख सकते हैं। **ध्यान दें** कि चार्ट डेटा को उसी प्रकार व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण पहली स्लाइड पर पहली आकृति के रूप में एक चार्ट वाली प्रस्तुति उपयोग करता है। यह एंबेडेड कार्यपुस्तक को बाइट एरे में पढ़ता है, मौजूदा श्रृंखलाएँ और श्रेणियाँ साफ करता है, और वही कार्यपुस्तक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **कार्यपुस्तक संशोधन के बाद चार्ट लेआउट को सत्यापित करें**

जब आप एंबेडेड कार्यपुस्तक को संशोधित संस्करण से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहीतियों को बरकरार रखता है। यह असंगति [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) को इंडेक्स‑आउट‑ऑफ‑रेंज त्रुटि के साथ असफल कर सकती है। अपडेटेड कार्यपुस्तक को चार्ट में लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ करें। यह उदाहरण पहली स्लाइड पर पहली आकृति के रूप में एक चार्ट उपयोग करता है। टिप्पणी में वह स्थान दर्शाया गया है जहाँ कार्यपुस्तक संपादन होगा; रन‑योग्य उदाहरण मूल कार्यपुस्तक को वापस लिखता है और मेमोरी में लेआउट को सत्यापित करता है।

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

        // यहाँ कार्यपुस्तक बाइट्स को संशोधित करें, उदाहरण के लिये Aspose.Cells का उपयोग करके.

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

संग्रहों को साफ करने से कार्यपुस्तक को वापस लिखते समय पुराने डेटा संदर्भ हट जाते हैं। अपडेटेड कार्यपुस्तक के लिये आवश्यक किसी भी श्रृंखला और श्रेणी मैपिंग को फिर से बनाएँ, फिर चार्ट का उपयोग करें।

## **श्रेणी लेबल को संग्रहीत करने का तरीका चुनें**

लेबल जोड़ने से पहले खाली श्रेणी संग्रह पर [ChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorycollection/setusecells/) को कॉल करें। उन लेबलों के लिये कार्यपत्रक कोशिकाओं का उपयोग करें जो कार्यपुस्तक डेटा को संदर्भित करती हैं या जो पदानुक्रम बनाती हैं, जैसे वर्ष‑के‑आधार पर तिमाही। एकल‑स्तर के लेबल जो कोशिका संदर्भ की आवश्यकता नहीं रखते, उनके लिये स्ट्रिंग लिटरल का उपयोग करें। यह सेटिंग केवल श्रेणियों पर लागू होती है। दोनों उदाहरणों में संख्यात्मक श्रृंखला मानों के लिये कार्यपत्रक कोशिकाओं का उपयोग किया गया है।

उदाहरण दो स्तंभ चार्ट बनाता है और प्रत्येक के लिये भंडारण मोड तथा `Q1 Q2 Q3 Q4` प्रिंट करता है। कार्यपत्रक‑समर्थित लेबल के लिये, [ChartCategory.getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/getascell/) अंतर्निहित कोशिका लौटाता है और [ChartDataCell.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getvalue/) उसका लेबल। लिटरल लेबल के लिये, सीधे [ChartCategory.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/getvalue/) से स्ट्रिंग पढ़ें। उदाहरण दोनों चार्ट को `category-labels.pptx` में सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    for (const useCells of [true, false]) {
        const x = useCells ? 20 : 360;
        const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, x, 20, 320, 250);
        const data = chart.getChartData();
        data.getSeries().clear();
        const categories = data.getCategories();
        categories.clear();
        categories.setUseCells(useCells);

        const workbook = data.getChartDataWorkbook();
        const seriesName = workbook.getCell(0, 0, 1, "Sales");
        const series = data.getSeries().add(seriesName, chart.getType());
        for (let row = 1; row <= 4; row++) {
            const label = "Q" + row;
            if (useCells) {
                const labelCell = workbook.getCell(0, row, 0, label);
                categories.add(labelCell);
            } else {
                categories.add(label);
            }

            const valueCell = workbook.getCell(0, row, 1, row * 10);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        const storedInCells = categories.getUseCells();
        const labels = [];
        for (let i = 0; i < categories.size(); i++) {
            const category = categories.get_Item(i);
            labels.push(storedInCells ? category.getAsCell().getValue() : category.getValue());
        }
        console.log("UseCells = " + storedInCells + ": " + labels.join(" "));
    }

    presentation.save("category-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **कार्यपुस्तक कोशिकाओं के लिये कस्टम नंबर फ़ॉर्मेट सेट करें**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) का उपयोग करके आप निर्धारित कर सकते हैं कि संख्यात्मक मान चार्ट के एंबेडेड कार्यपुस्तक में कैसे दिखेंगे। उदाहरण के लिये, एक रिपोर्ट को परिवर्तनीय दर को चार दशमलव स्थानों के साथ प्रतिशत के रूप में तथा गुणांक को पाँच दशमलव स्थानों के साथ दिखाना पड़ सकता है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिये उपलब्ध रहें।

नंबर फ़ॉर्मेट केवल प्रदर्शन को बदलता है, संग्रहीत मान नहीं। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` के रूप में दिखाता है; यह संग्रहीत संख्या को `12.5` नहीं बदलता। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को गोल किए। यदि कस्टम फ़ॉर्मेट खाली स्ट्रिंग (`""`) है, तो [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) द्वारा लौटाया गया फ़ॉर्मेट उपयोग किया जाता है।

निम्न उदाहरण एक स्तंभ चार्ट बनाता है और उसकी कोशिकाओं को [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) के माध्यम से एक्सेस करता है। कार्यपत्रक 0 में, B2 में परिवर्तनीय दर और C2 में गुणांक है। दोनों कोशिकाएँ चार्ट मान प्रदान करती हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़े मान लेबल को भी सक्षम करता है।

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

कार्यपुस्तक कोशिका फ़ॉर्मेट चार्ट धुरी या डेटा लेबल पर सीधे सेट किए गये फ़ॉर्मेट से अलग होते हैं। इस उदाहरण में प्रत्येक लेबल अपना स्रोत कोशिका मान दिखाता है क्योंकि [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) को `true` पर सेट किया गया है, और स्रोत नंबर फ़ॉर्मेट का अनुसरण करता है क्योंकि [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) को `true` पर सेट किया गया है। प्रस्तुति सहेजने और पुनः खोलने के बाद, लेबल `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दर्शाया गया है। ऊर्ध्वाधर धुरी अपना स्वयं का नंबर फ़ॉर्मेट उपयोग करती है, जिसे [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) द्वारा `0.00` तथा [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) द्वारा `false` पर सेट किया गया है।

डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिये, उसके स्रोत‑लिंक फ़्लैग को `false` करें और [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) से फ़ॉर्मेट असाइन करें। यह कार्यपुस्तक कोशिका के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहला मान `0.13` दिखाता है, जबकि B2 अभी भी `12.5000%` दिखाता है। अधिक जानकारी हेतु देखें [Chart Data Labels](/slides/hi/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

नीचे की चित्र सहेजी गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **वर्कबुक कोशिका को चार्ट डेटा लेबल के रूप में सेट करें**

आप कार्यपुस्तक कोशिकाओं के पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक बबल चार्ट डिफ़ॉल्ट डेटा के साथ जोड़ता है। यह कार्यपत्रक 0 में कोशिकाएँ A10:A12 का उपयोग पहली श्रृंखला के पहले तीन लेबल के लिये करता है, कोशिकाओं से लेबल सक्षम करता है, और अद्यतन प्रस्तुति सहेजता है।

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

## **वर्कशीट प्रबंधन**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) विधि चार्ट कार्यपुस्तक में कार्यशीट्स तक पहुँच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक कार्यशीट का नाम कंसोल में प्रिंट करता है।

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

श्रृंखला बिंदु मान सीधे संख्यात्मक लिटरल के रूप में भी संग्रहीत किए जा सकते हैं। पूर्ण उदाहरण के लिये देखें [Set Series Values Using Numeric Literals](/slides/hi/nodejs-java/chart-series/#set-series-values-using-numeric-literals) जो उन्हें सहेजता और पढ़ता है। बिंदु मानों का स्रोत प्रकार चार्ट के आंतरिक या बाहरी कार्यपुस्तक कॉन्फ़िगरेशन से अलग है; संख्यात्मक लिटरल का उपयोग स्वयं एंबेडेड कार्यपुस्तक को नहीं हटाता।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D स्तंभ चार्ट बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों से सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा कार्यपत्रक 0 के कोशिका C1 से है। [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) एनीमरेशन प्रत्येक नाम के लिये स्रोत चुनता है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति सहेजता है।

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

## **एंबेडेड कार्यपुस्तक फ़ॉर्मेट की असमर्थितता का पता लगाएँ**

Aspose.Slides उन Excel बाइनरी कार्यपुस्तकों (.xlsb) को सपोर्ट नहीं करता जो कुछ चार्टों में एंबेडेड हो सकते हैं। आप [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` मेथड के साथ [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) एनीमरेशन का उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्टों को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकृतियों की जाँच करता है, गैर‑चार्ट आकृतियों को छोड़ता है, और प्रत्येक चार्ट जिसके पास एंबेडेड .xlsb कार्यपुस्तक है, उसके लिये निदान संदेश प्रिंट करता है।

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

        // यहाँ समर्थित चार्ट कार्यपुस्तक डेटा को पढ़ें या संशोधित करें.
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी कार्यपुस्तक**

Aspose.Slides चार्टों के लिये बाहरी कार्यपुस्तकों को डेटा स्रोत के रूप में उपयोग करने का समर्थन करता है।

### **बाहरी कार्यपुस्तक बनाएँ**

[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) और [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) का उपयोग करके एंबेडेड चार्ट कार्यपुस्तक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी कार्यपुस्तक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी कार्यपुस्तक निर्यात करता है। फ़ाइल लिखना पूर्ण होने के बाद बाहरी कार्यपुस्तक को चार्ट डेटा स्रोत के रूप में असाइन करता है, फिर लिंक्ड प्रस्तुति सहेजता है।

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

### **बाहरी कार्यपुस्तक असाइन करें**

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) विधि के द्वारा आप किसी चार्ट को बाहरी कार्यपुस्तक को उसके डेटा स्रोत के रूप में असाइन कर सकते हैं। यह विधि बाहरी कार्यपुस्तक के पथ को अपडेट करने के लिये भी उपयोग की जा सकती है (यदि वह स्थानांतरित किया गया हो)।

आप रिमोट स्थानों या संसाधनों में संग्रहीत कार्यपुस्तकों के डेटा को संपादित नहीं कर सकते, लेकिन इन्हें बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी कार्यपुस्तक हेतु सापेक्ष पथ प्रदान किया जाता है, तो यह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी कार्यपुस्तक उपयोग करता है जिसकी कार्यपत्रक `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। यह पाई चार्ट बनाता है, कार्यपुस्तक को लिंक करता है, और A1:B4 को एक श्रृंखला और तीन श्रेणियों से मैप करने के लिये [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) का उपयोग करता है। यह लिंक्ड चार्ट सहित प्रस्तुति सहेजता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) का `updateChartData` पैरामीटर नियंत्रित करता है कि कार्यपुस्तक लोड हो।

* जब `updateChartData` `false` है, तो केवल कार्यपुस्तक पथ अपडेट होता है। चार्ट डेटा लक्ष्य कार्यपुस्तक से लोड या अपडेट नहीं होता, इसलिए कार्यपुस्तक अनुपलब्ध हो सकती है।
* जब `updateChartData` `true` है, तो चार्ट डेटा लक्ष्य कार्यपुस्तक से अपडेट होता है।

निम्न उदाहरण `updateChartData` को `false` पर सेट करके प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध कार्यपुस्तक को लोड किए बिना प्रस्तुति सहेजता है।

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

### **चार्ट की बाहरी डेटा स्रोत कार्यपुस्तक पथ प्राप्त करें**

किसी चार्ट से जुड़ी कार्यपुस्तक को पहचानने के लिये, जांचें कि चार्ट बाहरी डेटा स्रोत उपयोग करता है या नहीं और उसकी कार्यपुस्तक पथ प्राप्त करें।

यह उदाहरण प्रस्तुति की पहली स्लाइड पर पहली आकृति की जाँच करता है जो बाहरी कार्यपुस्तक से लिंक्ड है। यदि यह बाहरी कार्यपुस्तक से लिंक्ड चार्ट है, तो यह कंसोल में [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) प्रिंट करता है। फिर यह प्रस्तुति की एक प्रतिलिपि सहेजता है।

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

आप बाहरी कार्यपुस्तकों के डेटा को उसी तरह संपादित कर सकते हैं जैसा आप आंतरिक कार्यपुस्तकों में करते हैं। जब कोई बाहरी कार्यपुस्तक लोड नहीं हो पाती, तो अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड पर पहली आकृति के रूप में एक चार्ट उपयोग करता है जो सुलभ बाहरी कार्यपुस्तक से लिंक्ड है। यह पहली श्रृंखला के पहले डेटा बिंदु के सेल‑बैक्ड मान को 100 पर सेट करता है और अद्यतन प्रस्तुति सहेजता है। सेल मानों का संपादन लिंक्ड बाहरी XLSX फ़ाइल को अपडेट कर सकता है, इसलिए मूल कार्यपुस्तक को संरक्षित रखने हेतु एक कॉपी उपयोग करें।

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

### **चार्ट कैश से कार्यपुस्तक को पुनः प्राप्त करें**

यदि कोई चार्ट बाहरी कार्यपुस्तक का उपयोग करता है जो अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैशेड डेटा से चार्ट कार्यपुस्तक को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) बनायें, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) को कॉल करें, और [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) को `true` पर सेट करें, फिर प्रस्तुति खोलें।

निम्न JavaScript उदाहरण एक चार्ट के लिये कार्यपुस्तक डेटा पुनः प्राप्त करता है जो पहली स्लाइड पर पहली आकृति है और अनुपलब्ध बाहरी कार्यपुस्तक का संदर्भ देता है। यह पुनः प्राप्त डेटा को [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) और [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) के माध्यम से एक्सेस करता है:

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

        // पुनः प्राप्त कार्यपुस्तक डेटा को यहाँ पढ़ें या संशोधित करें.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

यदि बाहरी कार्यपुस्तक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकेगा। केवल तब पुनर्प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य विकल्प हो, क्योंकि कैश में बाहरी कार्यपुस्तक में प्रस्तुति के अंतिम अपडेट के बाद किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एंबेडेड कार्यपुस्तक से जुड़ा है?**

हाँ। एक चार्ट के पास [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) और एक [बाहरी कार्यपुस्तक का पथ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत बाहरी कार्यपुस्तक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाहरी कार्यपुस्तकों के लिये सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति पूर्ण पथ को PPTX फ़ाइल में संग्रहीत करती है, इसलिए कार्यपुस्तक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित कार्यपुस्तकों का उपयोग कर सकता हूँ?**

हाँ, ऐसी कार्यपुस्तकों को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालाँकि, Aspose.Slides से रिमोट कार्यपुस्तकों को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में इस्तेमाल हो सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [बाहरी फ़ाइल के लिंक](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) को संग्रहीत करती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल कार्यपुस्तक अपरिवर्तित रहना चाहिए, तो उसकी एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑संरक्षित है तो क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य दृष्टिकोण यह है कि पहले संरक्षण हटाएँ या डिक्रिप्टेड कॉपी (उदाहरण के लिये [Aspose.Cells](https://reference.aspose.com/cells/java/)) तैयार करके उसके लिंक का उपयोग करें।

**क्या कई चार्ट समान बाहरी कार्यपुस्तक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल को दर्शाते हैं, तो उस फ़ाइल में बदलाव अगले बार डेटा लोड होने पर प्रत्येक चार्ट में प्रतिबिंबित होगा।