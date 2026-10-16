---
title: "JavaScript का उपयोग कर प्रस्तुतियों में चार्ट डेटा लेबल्स प्रबंधित करें"
linktitle: "डेटा लेबल"
type: docs
url: /hi/nodejs-java/chart-data-label/
keywords:
- "चार्ट"
- "डेटा लेबल"
- "डेटा सटीकता"
- "प्रतिशत"
- "लेबल दूरी"
- "लेबल स्थान"
- "PowerPoint"
- "प्रस्तुति"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "JavaScript और Aspose.Slides for Node.js का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और फ़ॉर्मेट करने के बारे में सीखें, जिससे स्लाइड्स अधिक आकर्षक बनें।"
---
## **परिचय**

डेटा लेबल्स चार्ट सीरीज़ और व्यक्तिगत डेटा पॉइंट्स के बारे में जानकारी दर्शाते हैं, जिससे पाठकों को मान पहचानने और चार्ट को समझने में मदद मिलती है। यह लेख बताता है कि मानों को कैसे फ़ॉर्मेट करें, प्रतिशत कैसे दिखाएँ, लेबल टेक्स्ट कैसे पढ़ें, अक्ष अधिकतम से परे लेबल को कैसे नियंत्रित करें, श्रेणी अक्ष लेबल स्पेसिंग को कैसे समायोजित करें, और पाई चार्ट लेबल्स को कैसे स्थित करें।

## **चार्ट डेटा लेबल्स में डेटा की सटीकता निर्धारित करें**

सेरीज़ मानों को फ़ॉर्मेट करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसका डेटा टेबल दिखाता है, और पहले सीरीज़ के लिए वैल्यू लेबल्स को सक्षम करता है। फ़ॉर्मेट `#,##0.00` हजार विभाजक और दो दशमलव स्थान प्रदर्शित करता है बिना मूल मानों को बदले।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लैबल्स के रूप में प्रतिशत दिखाएँ**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट को उस टेक्स्ट फ्रेम में असाइन करें जो [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) द्वारा लौटाया जाता है। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8-पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चार्ट डेटा लेबल्स के साथ प्रतिशत चिह्न सेट करें**

जब मान अंश के रूप में संग्रहीत होते हैं, तो प्रतिशत दिखाने के लिए [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) को `false` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीली सीरीज़ के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मानों की जोड़ी का योग 1 है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0% के रूप में दर्शाता है, जबकि वर्टिकल एक्सिस दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ सफेद, 10-पॉइंट लेबल टेक्स्ट का उपयोग करती हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डेटा लेबल्स का वास्तविक टेक्स्ट पढ़ें**

[getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) का उपयोग डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करने के लिए करें। यह रिपोर्ट के लिए लेबल निकालने, प्रस्तुति सामग्री खोजने, या उत्पन्न चार्ट्स को मान्य करने में उपयोगी है। नीचे के उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम और मान को संयोजित करता है। एक पॉइंट अपना मान प्रतिशत के रूप में फ़ॉर्मेट करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) से कस्टम टेक्स्ट उपयोग करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

डेटा पॉइंट में संग्रहीत संख्या `0.75` रहती है, भले ही उसका लेबल `75%` श्रेणी और सीरीज़ नामों के साथ दिखाए। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को प्रतिस्थापित करता है। [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) दोनों मामलों में परिणामी लेबल स्ट्रिंग लौटाता है। यदि आप केवल दृश्य लेबल निकालना चाहते हैं, तो ऊपर दिखाए अनुसार [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) को अलग से जांचें।

## **अक्ष अधिकतम से परे डेटा लेबल्स को नियंत्रित करें**

जब आप मैन्युअल रूप से किसी अक्ष की रेंज सीमित करते हैं, तो कुछ डेटा पॉइंट्स उसके अधिकतम से अधिक हो सकते हैं। यह नियंत्रित करने के लिए कि उनके डेटा लेबल दिखाए जाएँ या नहीं, [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) का उपयोग करें। यह सेटिंग लेबल की दृश्यता बदलती है; यह अक्ष रेंज या मूल डेटा मानों को नहीं बदलती।

नीचे का उदाहरण 60 और 120 मानों के साथ 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह वर्टिकल अक्ष पर [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) को `false` पास करता है और [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) के साथ अधिकतम को 100 सेट करता है। पहली स्लाइड अधिकतम से परे लेबल की अनुमति देती है; उस स्लाइड की एक कॉपी उन्हें अक्षम करती है। दोनों स्लाइड्स `DataLabelsOverMaximum.pptx` में सहेजी गई हैं।

[setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) के साथ वैल्यू लेबल्स को सक्षम करें। चार्ट-स्तर की सेटिंग स्वयं वैल्यू डिस्प्ले को सक्रिय नहीं करती या व्यक्तिगत लेबल की अक्षम वैल्यू डिस्प्ले को ओवरराइड नहीं करती। यह उदाहरण पूरी सीरीज़ के लिए वैल्यू को सक्षम करता है और [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) का उपयोग करके प्रत्येक कॉलम के बाहरी छोर पर लेबल रखता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

निम्न छवियां सहेजी गई स्लाइड्स को Microsoft PowerPoint द्वारा रेंडर किए हुए दिखाती हैं। `true` के साथ लेबल **120** ऊपरी सीमा पर दिखाई देता है; `false` के साथ वह छिपा रहता है। लेबल **60** दृश्यमान रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा पॉइंट दोनों मामलों में **120** रहता है।

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint चार्ट जो मान लेबल 120 को अक्ष अधिकतम 100 के साथ दिखा रहा है](data-labels-over-maximum-true.png) | ![PowerPoint चार्ट जो मान लेबल 120 को अक्ष अधिकतम 100 के साथ छिपा रहा है](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण वैल्यू एक्सिस वाले 2D कॉलम चार्ट का उपयोग करता है। वैल्यू एक्सिस के बिना चार्ट, जैसे पाई और डोनट चार्ट, इस तरह के अक्ष अधिकतम को सीमित नहीं करते।
{{% /alert %}}

## **अक्ष से लेबल दूरी निर्धारित करें**

[setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) का उपयोग करके श्रेणी अक्ष लेबल्स और अक्ष के बीच की दूरी को नियंत्रित करें। मान अक्ष लेबल्स के अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफसेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा पॉइंट्स से जुड़े लेबल्स के बजाय श्रेणी अक्ष लेबल्स को प्रभावित करती है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लेबल स्थान समायोजित करें**

पाई चार्ट पर, डेटा लेबल स्थितियों को समायोजित करें ताकि स्पेसिंग बेहतर हो और लीडर लाइनों के लिए जगह बन सके।

यह उदाहरण पहले डेटा पॉइंट का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) और [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) का उपयोग करके उसके क्षैतिज और ऊर्ध्वाधर ऑफसेट को समायोजित करता है। ये ऑफसेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![समायोजित डेटा लेबल स्थिति वाला पाई चार्ट](pie-chart-adjusted-label.png)

## **लीडर लाइनों का फ़ॉर्मेट करें**

जब पाई चार्ट लेबल्स स्लाइस के बाहर होते हैं, तो लीडर लाइने प्रत्येक मान को सही स्लाइस से मेल करने में मदद करती हैं। विरोधी रंग और थोड़ा मोटी लाइन इन कनेक्शनों को आसानी से समझने योग्य बनाती है, जबकि ट्रांसपेरेंसी और डैश्ड स्टाइल लाइन को दृश्य रूप से कम बाधित रखती है।

सीरीज़ के डेटा लेबल कलेक्शन स्तर पर लीडर लाइनों को फ़ॉर्मेट करने के लिए [getLeaderLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelcollection/getleaderlinesformat/) का उपयोग करें। `series.getLabels().getLeaderLinesFormat().getLine()` में सेटिंग्स कलेक्शन पर लागू होती हैं, न कि व्यक्तिगत लेबल पर।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ पाई चार्ट बनाता है, स्लाइस के बाहर मान दिखाता है, और [setShowLeaderLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowleaderlines/) को सक्षम करता है। यह दो लेबल्स को उनके स्लाइस से अधिक दूर ले जाने के लिए [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) और [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) ऑफसेट का उपयोग करता है, जो चार्ट की चौड़ाई और ऊँचाई के अंश के रूप में व्यक्त होते हैं। किसी इनपुट प्रस्तुति की आवश्यकता नहीं है।

लाइन का [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) 255 में से 191 अल्फा मान के साथ एक ठोस नीला रंग सेट करता है, जिससे लगभग 25% ट्रांसपेरेंसी मिलती है। [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) मोटाई को 2 पॉइंट सेट करता है, और [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) लाइन को डैश्ड बनाता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    const series = chart.getChartData().getSeries().get_Item(0);

    const labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // दो लेबल्स को उनके स्लाइस से अधिक दूर ले जाएँ।
    series.getLabels().get_Item(0).setX(java.newFloat(0.10));
    series.getLabels().get_Item(0).setY(java.newFloat(-0.05));
    series.getLabels().get_Item(1).setX(java.newFloat(-0.10));
    series.getLabels().get_Item(1).setY(java.newFloat(0.05));

    const line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 30, 90, 160, 191);
    line.getFillFormat().getSolidFillColor().setColor(lineColor);
    line.setWidth(2);
    line.setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    presentation.save("FormattedLeaderLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

लीडर लाइनों को सक्षम करना यह सुनिश्चित नहीं करता कि हर लेबल के लिए लाइन दिखाई दे। दृश्यता लेबल की स्थिति और चार्ट के लेआउट व्यवहार पर निर्भर करती है। इस उदाहरण में, दो विस्थापित लेबल्स के पास दृश्य लीडर लाइन्स हैं; जो लेबल्स अपनी स्लाइस के पास रहते हैं उन्हें उनकी आवश्यकता नहीं है।

निम्न छवि `FormattedLeaderLines.pptx` को Aspose.Slides के साथ रेंडर किए हुए दिखाती है:

![नीले, अर्धपारदर्शी, डैश्ड लीडर लाइनों के साथ पाई चार्ट जो दो बाहरी लेबल्स को उनके स्लाइस से जोड़ते हैं](formatted-leader-lines.png)

## **कॉलम चार्ट के ऊपर डेटा लेबल्स की कई पंक्तियाँ जोड़ें**

यह उदाहरण प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल्स के साथ एक कॉलम चार्ट बनाता है। सीरीज़ A दिखाई देने वाले कॉलम दिखाता है, जबकि सीरीज़ B और सीरीज़ C अतिरिक्त लेबल प्रदान करते हैं। उनके कॉलम को फ़िल और आउटलाइन हटाकर छिपा दिया जाता है। [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) मेथड सभी तीन सीरीज़ को समान श्रेणी केंद्रों के साथ संरेखित करता है।

[ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) सेटिंग्स लेबल पंक्तियों के लिए स्थान आरक्षित करती हैं। [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) डिफ़ॉल्ट स्थितियों की गणना करने के बाद, [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) और [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) क्षैतिज संरेखण को बनाए रखते हैं और दो पंक्तियों में लेबल्स को व्यवस्थित करने के लिए ऊर्ध्वाधर ऑफसेट लागू करते हैं। संख्याएँ सीरीज़ मानों से जुड़ी डेटा लेबल्स बनी रहती हैं; केवल पंक्तियों के शीर्षक अलग टेक्स्ट शैप्स हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // B और C के कॉलम छिपाएँ, लेकिन उनके डेटा लेबल बनाए रखें।
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // तीनों सीरीज़ को समान श्रेणी केंद्रों पर संरेखित करें।
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // इस संक्षिप्त उदाहरण के लिए कम ग्रिडलाइन उपयोग करें।
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // डेटा लेबल की दो पंक्तियों के लिए प्लॉट के ऊपर स्थान आरक्षित करें।
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // डिफ़ॉल्ट क्षैतिज स्थिति रखें। Y एक ऑफ़सेट है
            // डिफ़ॉल्ट लेबल स्थिति से, चार्ट ऊँचाई के अंश के रूप में व्यक्त।
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // केवल पंक्ति शीर्षक एक अलग टेक्स्ट शेप है।
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल्स वाला कॉलम चार्ट](multiple-rows-of-labels.png)

## **FAQ**

**मैं घने चार्ट्स पर डेटा लेबल्स के ओवरलैप को कैसे रोक सकता हूँ?**  
ऑटोमैटिक लेबल प्लेसमेंट, लीडर लाइन्स, और छोटे फ़ॉन्ट आकार को मिलाकर उपयोग करें; यदि आवश्यक हो, तो कुछ फ़ील्ड्स (उदाहरण के लिए, श्रेणी) को छिपाएँ या केवल अत्यधिक मानों या प्रमुख बिंदुओं के लिए लेबल दिखाएँ।

**मैं शून्य, नकारात्मक, या ख़ाली मानों के लिए केवल लेबल्स को कैसे अक्षम कर सकता हूँ?**  
लेबल्स सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और 0, नकारात्मक मानों, या अनुपलब्ध मानों के लिए परिभाषित नियम के अनुसार डिस्प्ले को बंद करें।

**PDF/इमेज में एक्सपोर्ट करते समय लेबल शैली को स्थिर कैसे रखें?**  
फ़ॉन्ट फ़ैमिली और आकार को स्पष्ट रूप से सेट करें और रेंडरिंग वातावरण में फ़ॉन्ट उपलब्ध होने की जाँच करें ताकि फ़ॉलबैक से बचा जा सके।