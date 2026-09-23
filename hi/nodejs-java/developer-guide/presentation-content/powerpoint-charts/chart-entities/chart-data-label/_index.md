---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/nodejs-java/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट और Node.js के लिए Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और फ़ॉर्मेट करने के बारे में जानें, जिससे अधिक आकर्षक स्लाइड्स बनें।"
---
## **परिचय**

डेटा लेबल चार्ट सीरीज़ और व्यक्तिगत डेटा पॉइंट्स के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट को समझने में मदद मिलती है। इस लेख में बताया गया है कि मानों को कैसे फ़ॉर्मेट करें, प्रतिशत कैसे दिखाएँ, लेबल टेक्स्ट को कैसे पढ़ें, श्रेणी अक्ष लेबल के अंतराल को कैसे समायोजित करें, और पाई चार्ट लेबल को कैसे स्थित करें।

## **चार्ट डेटा लेबल में डेटा प्रिसीजन सेट करें**

सीरीज़ मानों को फ़ॉर्मेट करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसकी डेटा टेबल प्रदर्शित करता है, और पहली सीरीज़ के लिए वैल्यू लेबल सक्षम करता है। फ़ॉर्मेट `#,##0.00` हज़ार विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मान बदले।

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

## **लेबल के रूप में प्रतिशत दिखाएँ**

एक स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट फ्रेम को असाइन करें जो [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) द्वारा लौटाया जाता है। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8 पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत प्रदर्शित करता है। शून्य कुल वाली श्रेणियों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल में प्रतिशत संकेत सेट करें**

जब मान भागों (फ्रैक्शन) के रूप में संग्रहीत होते हैं, तो प्रतिशत दिखाने के लिए [setNumberFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) को `false` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीले सीरीज़ के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान जोड़ी का योग 1 होता है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0% के रूप में दिखाता है, जबकि वर्टिकल अक्ष दो दशमलव स्थान का उपयोग करता है। दोनों सीरीज़ सफ़ेद, 10-पॉइंट लेबल टेक्स्ट का उपयोग करती हैं।

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

## **डेटा लेबल का वास्तविक टेक्स्ट पढ़ें**

डेटा लेबल सेटिंग्स द्वारा उत्पन्न टेक्स्ट को प्राप्त करने के लिए [getActualLabelText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकालते समय, प्रस्तुतीकरण सामग्री खोजते समय, या उत्पन्न चार्ट को वैधता देते समय उपयोगी होता है। नीचे के उदाहरण में, डिफ़ॉल्ट [डेटा लेबल फ़ॉर्मेट](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम और मान को संयोजित करता है। एक बिंदु अपने मान को प्रतिशत के रूप में फ़ॉर्मेट करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) से कस्टम टेक्स्ट का उपयोग करता है।

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

डेटा पॉइंट में संग्रहित संख्या `0.75` बनी रहती है, भले ही उसका लेबल `75%` श्रेणी और सीरीज़ नामों के साथ दिखाए। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [getActualLabelText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) दोनों स्थितियों में परिणामी लेबल स्ट्रिंग लौटाता है। जैसा कि ऊपर दिखाया गया है, केवल दृश्यमान लेबल निकालना चाहते हैं तो अलग से [isVisible](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabel/isvisible/) जांचें।

## **अक्ष से लेबल की दूरी सेट करें**

[setLabelOffset](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/axis/setlabeloffset/) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच की दूरी को नियंत्रित करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा पॉइंट्स से जुड़े लेबल के बजाय श्रेणी अक्ष लेबल को प्रभावित करती है।

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

पाई चार्ट में डेटा लेबल की स्थिति को समायोजित करके अंतराल में सुधार करें और लीडर लाइनों के लिए जगह बनाएं।

यह उदाहरण पहले डेटा पॉइंट का मान प्रदर्शित करता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabel/setx/) और [setY](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabel/sety/) का उपयोग करके उसके क्षैतिज और लम्बवत ऑफ़सेट समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**डेटा लेबल को घने चार्ट में ओवरलैप होने से कैसे रोकें?**  
ऑटोमैटिक लेबल प्लेसमेंट, लीडर लाइनों, और छोटे फ़ॉन्ट आकार को संयोजित करें; यदि आवश्यक हो तो कुछ फ़ील्ड (उदाहरण के लिए, श्रेणी) को छुपाएँ या केवल चरम मानों या मुख्य बिंदुओं के लिए ही लेबल दिखाएँ।

**केवल शून्य, नकारात्मक या खाली मानों के लिए लेबल कैसे अक्षम करूँ?**  
लेबल सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक या अनुपलब्ध मानों के लिए प्रदर्शन को बंद करें।

**PDF/छवियों में निर्यात करते समय लेबल शैली को स्थिर कैसे सुनिश्चित करें?**  
फ़ॉन्ट फ़ैमिली और आकार को स्पष्ट रूप से सेट करें तथा रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध है या नहीं, यह सत्यापित करें ताकि फ़ॉलबैक न हो।