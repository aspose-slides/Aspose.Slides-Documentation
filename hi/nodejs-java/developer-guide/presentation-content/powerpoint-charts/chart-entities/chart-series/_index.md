---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट डेटा श्रृंखला प्रबंधित करें
linktitle: डेटा श्रृंखला
type: docs
url: /hi/nodejs-java/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रृंखला नाम
- डेटा बिंदु
- वर्कबुक सेल
- श्रृंखला गैप
- नकारात्मक मान
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा बिंदुओं, वर्कबुक सेल्स, स्वरूपण, ओवरलैप, गैप चौड़ाई, और नकारात्मक मानों को प्रबंधित करना सीखें।"
---
## **समीक्षा**

एक चार्ट अपनी प्लॉटेड डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) एक संबंधित मानों का सेट दर्शाता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) एक या अधिक वर्कबुक सेल को संदर्भित करता है। [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स लेबल या समूह मान प्रदान करते हैं जो श्रृंखला द्वारा साझा किए जाते हैं। श्रृंखला का नाम, श्रेणियां, और बिंदु मान इसलिए [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत होते।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, स्तंभ 0 को श्रेणी नामों के लिए, और शेष सेल को श्रृंखला मानों के लिए उपयोग करती है। [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getCell) को पास किए जाने वाले कार्यपत्रक, पंक्ति, और स्तंभ सूचकांक शून्य‑आधारित हैं। यह लेआउट डिफ़ॉल्ट डेटा के साथ चार्ट बनाते समय उपयोगी होता है, लेकिन यह मान लेना कि हर मौजूदा चार्ट इसका उपयोग करता है, सही नहीं है। लोड किए गए प्रेज़ेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियां और डेटा पॉइंट्स द्वारा संदर्भित सेल्स की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- श्रृंखला‑स्तर सेटिंग्स, जैसे [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getFormat), एक श्रृंखला के सभी बिंदुओं के लिए डीफ़ॉल्ट उपस्थिति प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getFormat), एक बिंदु के लिए श्रृंखला की उपस्थिति को ओवरराइड करती हैं।
- समूह सेटिंग्स समान प्रकार की श्रृंखलाओं पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) से संबंधित हैं। समूह तक पहुँचने के लिए [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) का उपयोग करें जब आपको ओवरलैप या गैप‑विथ जैसी विकल्प सेट करने की आवश्यकता हो।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल सेट नहीं किया गया हो, तो चार्ट शैली और थीम स्वचालित उपस्थिति निर्धारित करती हैं। जब दोनों, श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद हों, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राबल्य रखती है।

![चार्ट‑सीरीज़‑पावरपॉइंट](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getOverlap) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी प्रतिशत ओवरलैप करते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल रीड‑ओनली प्रोजेक्शन है। सभी संगत श्रृंखलाओं को अद्यतन करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम प्रदर्शित करते हैं; यह कॉम्बिनेशन चार्ट में असंबद्ध श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण में पहली श्रृंखला वाले समूह के लिए ओवरलैप सेट किया गया है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ, और मान शामिल करता है।
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![श्रृंखला ओवरलैप](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलें**

पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने के लिए [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getFormat) का उपयोग करें। यदि किसी बिंदु का फ़िल पहले से स्पष्ट रूप से सेट है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड करती है।

निम्न उदाहरण में पहली श्रृंखला को ठोस नीला फ़िल लागू किया गया है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![श्रृंखला रंग](series_color.png)

## **श्रृंखला नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिए डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, स्तंभ 1 पर होता है और पहले श्रृंखला का नाम रखता है। नीचे दिए गए उदाहरण में स्थिरांक इस संरचना को स्पष्ट रूप से दर्शाते हैं:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आप [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित सेल को भी अद्यतन कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति और स्तंभ को मानने से बचाता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![श्रृंखला नाम](series_name.png)

### **एकाधिक सेल्स से नाम वाली श्रृंखला बनाएं**

यदि उत्पाद नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक सेल्स में संग्रहीत हैं, तो संयुक्त श्रृंखला नाम उपयोगी होता है। उदाहरण के लिए, आप B1 में `Product A` और C1 में `2026` को मिलाकर एक ही श्रृंखला नाम बना सकते हैं, जबकि दोनों भाग अपनी स्रोत सेल्स से जुड़े रहें।

नाम रेंज प्राप्त करने के लिए [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getCellCollection) का उपयोग करें, फिर उस संग्रह को [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/#add) को पास करें। `skipHiddenCells` तर्क यह नियंत्रित करता है कि छिपे हुए सेल्स शामिल हों या नहीं: `true` उन्हें बाहर रखता है, `false` उन्हें शामिल करता है। यह उदाहरण `false` का उपयोग करके नाम रेंज के सभी सेल्स को शामिल करता है।

निम्न उदाहरण में एक प्रस्तुति बनाई गई है जिसमें एक श्रृंखला और दो डेटा पॉइंट्स हैं। सेल B1:C1 केवल श्रृंखला नाम प्रदान करते हैं; A2:A3 श्रेणी लेबल देते हैं, और B2:B3 संख्यात्मक मान देते हैं।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // ये दो सेल्स श्रृंखला का नाम प्रदान करती हैं।
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // अलग-अलग सेल्स श्रेणियाँ और संख्यात्मक डेटा पॉइंट्स प्रदान करती हैं।
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणामी श्रृंखला नाम `Product A 2026` होगा, दो सेल मानों के बीच एक स्पेस के साथ। लेजेंड इसे दोनों कॉलम के लिए एक एंट्री के रूप में दिखाता है। नीचे चित्र परिणाम दर्शाता है:

![उत्तरी और दक्षिणी मानों के साथ कॉलम चार्ट तथा सम्मिलित श्रृंखला नाम Product A 2026 लेजेंड में](composite_series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) उन रंगों को लौटाता है जो श्रृंखला अनुक्रमांक और चार्ट शैली से गणना किए जाते हैं। यह वही रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

डिफ़ॉल्ट चार्ट शैली के लिए उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करता है।

## **एक चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्शन सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका डिस्प्ले रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। कार्यपत्रक पंक्ति 0 में श्रृंखला नाम, स्तंभ 0 में श्रेणी नाम, और स्तंभ 1 में मान होते हैं:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![इनवर्टेड ठोस फ़िल रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिए इनवर्शन को केवल [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) से सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए इनवर्शन निष्क्रिय है और केवल चयनित बिंदु के लिए सक्रिय किया गया है। बिंदु को नकारात्मक मान भी असाइन किया गया है जिससे प्रभाव देखी जा सके:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एक विशिष्ट डेटा पॉइंट मान साफ़ करें**

एक बिंदु को खाली करने के लिए, उसके बैकिंग वर्कबुक सेल को `null` सेट करें, जबकि अन्य बिंदु उन्हीं राह पर रहें। कॉलम चार्ट में, प्लॉटेड मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से प्राप्त किया जाता है। डेटा पॉइंट उसी श्रेणी स्थिति में रहता है, लेकिन चार्ट उसके मान को ब्लैंक मान सेटिंग के अनुसार खाली मानता है।

निम्न उदाहरण पहली श्रृंखला के केवल दूसरे बिंदु को साफ़ करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट में आकार सेल भी होता है। जिससे आप हटाना चाहते हैं, उस मान वाले सेल को ही साफ़ करें। जब आप अन्य बिंदु रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/#clear) न बुलाएँ, क्योंकि यह मेथड श्रृंखला के सभी डेटा पॉइंट्स को हटा देता है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करें**

छिपे हुए सेल्स जो मान रखते हैं, वे खाली सेल्स से अलग मामला हैं। छिपी हुई कार्यपत्रक पंक्तियों और स्तंभों से डेटा को शामिल या बाहर करने के लिए देखें: [Include Data from Hidden Rows and Columns](/slides/hi/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थित डेटा को दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। सेल को खाली करने के लिए [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setValue) को `null` के साथ कॉल करें। शून्य संख्यात्मक शून्य बना रहता है चाहे ब्लैंक‑सेल सेटिंग कुछ भी हो।

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) का उपयोग करके तय करें कि चार्ट खाली सेल्स को कैसे प्रदर्शित करता है। यह सेटिंग पूरे चार्ट पर लागू होती है। यह ब्लैंक्स के प्लॉटिंग को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरें।

निम्न स्व-सम्पूर्ण उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला, दिन 3 का मान साफ़ किया गया है, और प्रत्येक मोड के साथ वही चार्ट सहेजा गया है। इनपुट फ़ाइल की ज़रूरत नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) कार्यपत्रक 0, स्तंभ 0 को श्रेणी लेबल के लिए, और स्तंभ 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Day 3 को वास्तव में खाली रखें, जबकि उसकी श्रेणी और डेटा पॉइंट बरकरार रखें।
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

प्रत्येक आउटपुट फ़ाइल में सहेजने से पहले निर्धारित मोड शामिल रहता है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, वांछित मोड असाइन करें और प्रस्तुति को एक बार सहेजें, सभी मोड्स पर इटरेट करने के बजाय।

नीचे तुलना में सभी तीन फ़ाइलों में समान डेटा दिखाया गया है। दिन 3 प्रत्येक केस में वर्कबुक में खाली है:

![लाइन चार्ट में समान डेटा: गैप लाइन को दिन 3 पर तोड़ता है, ज़ीरो लाइन को शून्य पर नीचे ले जाता है, और स्पैन दिन 2 को दिन 4 से जोड़ता है।](display_blanks_as.png)

दिखाया गया प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना योग्य बनाता है। बार और कॉलम चार्ट में मिसिंग श्रेणी के ऊपर कनेक्ट करने वाली कोई लाइन नहीं होती, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को नहीं बना सकता; एक मिसिंग कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकता है। समान रूप से, मार्कर‑केवल वाले स्कैटर चार्ट में भी कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन अलग-अलग परिणाम मिलने की उम्मीद न रखें; उपयोग किए जाने वाले प्रकार के लिए आउटपुट जाँचें।

## **श्रृंखला गैप‑विथ सेट करें**

गैप‑विथ निकटवर्ती बार या कॉलम क्लस्टरों के बीच की दूरी है, जो बार या कॉलम की चौड़ाई के प्रतिशत के रूप में व्यक्त की जाती है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से सम्बंधित है, न कि किसी एक श्रृंखला से। समूह के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ा मान क्लस्टरों के बीच अधिक जगह बनाता है; छोटा मान उन्हें अधिक घना बनाता है।

निम्न उदाहरण गैप‑विथ बदलता है और केवल अंतिम प्रस्तुति सहेजता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![गैप‑विथ](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखला को सपोर्ट करते हैं?**

[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) enumeration द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट में श्रेणियां और मान होते हैं, स्कैटर चार्ट में X और Y मान होते हैं, और बबल चार्ट में बबल आकार भी जोड़ता है। डेटा‑पॉइंट निर्माण मेथड को उस श्रृंखला प्रकार के अनुसार चुनें। ओवरलैप और गैप‑विथ जैसे विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

एक [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) में संगत श्रृंखलाएं होती हैं जो समूह‑स्तर के प्लॉटिंग सेटिंग्स साझा करती हैं। एक कॉम्बिनेशन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुंचे गए समूह को बदलने से ज़रूरी नहीं कि चार्ट की सभी श्रृंखलाएं बदलें।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा शामिल होता है?**

हां। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addChart) नमूना श्रृंखलाएं, श्रेणियां और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड का उपयोग करके डिफ़ॉल्ट डेटा के बिना चार्ट भी बनाया जा सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑पॉइंट मान एक [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) में सेल्स को संदर्भित करते हैं। संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अद्यतन हो जाता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को संरेखित रखें ताकि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो।

**मैं संपूर्ण श्रृंखला की बजाय एक बिंदु को कैसे साफ़ करूँ?**

उस बिंदु के मान वाली सेल को `null` सेट करें ताकि बिंदु अपनी श्रेणी स्थिति बनाए रखे लेकिन खाली बिंदु बन जाए। पूरे श्रृंखला को हटाने के लिए [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/#clear) केवल तभी उपयोग करें जब आप सभी बिंदुओं को हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो प्रत्येक श्रृंखला को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**

परिणाम [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) में चयनित सेटिंग और चार्ट प्रकार पर निर्भर करता है। समर्थित चार्ट खाली जगहों को गैप, शून्य मान, या निकटवर्ती बिंदुओं को जोड़कर प्रदर्शित कर सकते हैं। अपनी प्रस्तुति में अनुपस्थित डेटा के अर्थ के अनुसार सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें: [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मानों को कैसे फ़ॉर्मेट किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) को कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) द्वारा लौटाए गए रंग को सेट करें। आप व्यक्तिगत बिंदु के लिए [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) द्वारा व्यवहार को ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहित संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेट किए गए हों तो कौन जीतता है?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस बिंदु के लिए प्राबल्य रखती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, जब श्रृंखला फ़ॉर्मेट परिभाषित नहीं हो, स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। ओवरलैप और गैप‑विथ जैसी समूह सेटिंग्स लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर के फ़ॉर्मेट ओवरराइड नहीं होतीं।

**एक चार्ट में अधिकतम कितनी श्रृंखलाएं हो सकती हैं?**

Aspose.Slides कोई अलग स्थिर श्रृंखला‑संख्या सीमा नहीं लगाता। व्यवहार में, प्रस्तुति फ़ाइल की सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा तय करती हैं।

**जब कॉलम बहुत करीब या बहुत दूर हों तो मुझे क्या बदलना चाहिए?**

उपयुक्त पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) को कॉल करें। मान बढ़ाएँ ताकि क्लस्टरों के बीच स्थान विस्तृत हो, या घटाएँ ताकि क्लस्टर करीब आएँ।