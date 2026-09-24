---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं का प्रबंधन करें
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
description: "जावास्क्रिप्ट के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा बिंदुओं, वर्कबुक सेल्स, फ़ॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित करें, यह सीखें।"
---
## **परिचय**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/) एक या अधिक वर्कबुक सेल्स को संदर्भित करता है। [ChartCategory](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स लेबल या समूह मान प्रदान करते हैं जो श्रृंखला द्वारा साझा किए जाते हैं। इस प्रकार श्रृंखला का नाम, श्रेणियाँ, और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल प्रदर्शित टेक्स्ट के रूप में संग्रहीत।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक में पंक्ति 0 को श्रृंखला नामों के लिए, कॉलम 0 को श्रेणी नामों के लिए, और शेष सेल्स को श्रृंखला मानों के लिए उपयोग किया जाता है। [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#getCell) को पास किए गए वर्कशीट, पंक्ति, और कॉलम सूचकांक शून्य‑आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मानने की आवश्यकता नहीं है कि प्रत्येक मौजूदा चार्ट इसका उपयोग करता है। लोड किए गए प्रेजेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों, और डेटा बिंदुओं द्वारा संदर्भित सेल्स की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे कि [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getFormat), एक श्रृंखला के सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे कि [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#getFormat), एक बिंदु के लिए श्रृंखला की उपस्थिति को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/) में रहती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसे विकल्प सेट करने हों, तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल सेट नहीं होता, तो चार्ट शैली और थीम स्वचालित रूप से उपस्थिति निर्धारित करती हैं। जब दोनों, श्रृंखला और बिंदु फ़ॉर्मैटिंग मौजूद होते हैं, तो बिंदु फ़ॉर्मैटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![चार्ट-श्रृंखला-पावरपॉइंट](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getOverlap) 2D चार्ट में बार या कॉलम का ओवरलैप प्रतिशत (-100 से 100 तक) रिपोर्ट करता है। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑रिड प्रोजेक्शन है। इस समूह में सभी संगत श्रृंखलाओं को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण उन समूह के लिए ओवरलैप सेट करता है जिसमें पहली श्रृंखला शामिल है:

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

    // नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ और मान शामिल करता है।
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

[ChartSeries.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getFormat) का उपयोग करके पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करें। यदि किसी बिंदु का फ़िल पहले से स्पष्ट रूप से सेट है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड करता है।

निम्न उदाहरण पहली श्रृंखला पर सॉलिड ब्लू फ़िल लागू करता है:

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

![श्रृंखला का रंग](series_color.png)

## **श्रृंखला नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाए गए डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर स्थित है और पहली श्रृंखला का नाम रखता है। नीचे के उदाहरण में नामित कॉन्स्टेंट्स इस संरचना को स्पष्ट रूप में दर्शाते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getName) द्वारा पहले संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशेष पंक्ति और कॉलम को मानने से बचाता है:

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

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) श्रृंखला इंडेक्स और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

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

उदाहरण आउटपुट डिफ़ॉल्ट चार्ट शैली के लिए:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **चार्ट श्रृंखला के लिए उल्टा फ़िल रंग सेट करें**

बार, कॉलम, और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। सामान्य श्रृंखला फ़िल को सॉलिड सेट करें, उलटाव सक्षम करें, और नकारात्मक मूल्य रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। वर्कबुक में नकारात्मक संख्याएँ अपरिवर्तित रहती हैं; केवल उनका प्रदर्शन रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

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

![उल्टा सॉलिड फ़िल रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिए उलटाव को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के माध्यम से सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए उलटाव निष्क्रिय है और केवल चयनित बिंदु के लिए सक्रिय है। बिंदु को नकारात्मक मान असाइन किया गया है ताकि प्रभाव दिखे:

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

## **विशिष्ट डेटा बिंदु मान साफ़ करें**

एक बिंदु को खाली करने के लिए, अन्य बिंदुओं को हटाए बिना, उसकी बैकिंग वर्कबुक सेल को `null` सेट करें। कॉलम चार्ट में, प्लॉटेड मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से उपलब्ध है। डेटा बिंदु वही श्रेणी स्थान बनाए रखता है, लेकिन चार्ट उसके मान को खाली मानता है, चार्ट की ब्लैंक‑वैल्यू सेटिंग के अनुसार।

निम्न उदाहरण पहली श्रृंखला में केवल दूसरे बिंदु को साफ़ करता है:

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

स्कैटर चार्ट अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट एक साइज सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। यदि आप अन्य बिंदुओं को रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapointcollection/#clear) को कॉल न करें, क्योंकि यह मेथड संग्रह से सभी डेटा बिंदु हटा देता है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करें**

एक खाली वर्कबुक सेल अनुपलब्ध डेटा को दर्शाता है; `0` वाले सेल एक ज्ञात संख्यात्मक मान दर्शाता है। किसी सेल को खाली करने के लिए [ChartDataCell.setValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setValue) को `null` के साथ कॉल करें। ब्लैंक‑सेल सेटिंग के बावजूद शून्य संख्या शून्य ही रहती है।

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) का उपयोग करके चुनें कि चार्ट खाली सेल्स को कैसे प्रदर्शित करता है। यह सेटिंग पूरे चार्ट पर लागू होती है। यह ब्लैंक्स को प्लॉट करने का तरीका बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरें।

निम्न स्व‑समावेशी उदाहरण एक लाइन चार्ट एक श्रृंखला के साथ बनाता है, दिन 3 के मान को साफ़ करता है, और प्रत्येक मोड के साथ उसी चार्ट को सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) वर्कशीट 0, कॉलम 0 को श्रेणी लेबल के लिए, और कॉलम 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम होता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    // Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा बिंदु को बनाए रखें।
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

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले असाइन किए गए मोड को संग्रहीत करती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, इच्छित मोड असाइन करें और प्रस्तुति को एक बार सहेजें, मोड्स के ऊपर लूप करने के बजाय।

नीचे तुलना में तीन फ़ाइलों में समान डेटा दिखाया गया है। सभी मामलों में दिन 3 वर्कबुक में खाली है:

![एक ही डेटा वाले लाइन चार्ट: गैप दिन 3 पर लाइन तोड़ता है, ज़ीरो लाइन को शून्य तक लाता है, और Span दिन 2 से दिन 4 को जोड़ता है](display_blanks_as.png)

दिखाई देने वाला प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड्स की आसानी से तुलना करता है। बार और कॉलम चार्ट में किसी गायब श्रेणी के ऊपर जुड़ने वाली लाइन नहीं होती, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को नहीं बना सकता; एक गायब कॉलम और शून्य‑ऊंचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, मार्कर वाला स्कैटर चार्ट भी कोई कनेक्टिंग लाइन नहीं रखता। हर चार्ट प्रकार के लिए तीन अलग-अलग परिणामों की उम्मीद न रखें; आप जिस प्रकार का उपयोग करते हैं, उसके आउटपुट की जाँच करें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई आस‑पास की बार या कॉलम क्लस्टर्स के बीच की दूरी है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह एकल श्रृंखला के बजाय पैरेंट श्रृंखला समूह का हिस्सा है। समूह के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ी मूल्य क्लस्टर्स के बीच अधिक जगह बनाता है; छोटी मूल्य उन्हें घना बनाती है।

निम्न उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रेजेंटेशन को सहेजता है:

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

![गैप चौड़ाई](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं का समर्थन करते हैं?**  
सभी चार्ट प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/) enumeration द्वारा प्रतिनिधित्व किए गए हैं, डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की मूल्य संरचना या सेटिंग्स समान नहीं होतीं। उदाहरण के लिए, श्रेणी चार्ट श्रेणियाँ और मान उपयोग करते हैं, स्कैटर चार्ट X और Y मान, और बबल चार्ट बबल आकार जोड़ते हैं। श्रृंखला प्रकार से मेल खाने वाली डेटा‑बिंदु निर्माण विधि का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**  
एक [ChartSeriesGroup](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/) संगत श्रृंखलाओं को सम्मिलित करता है जो समूह‑स्तर की प्लॉट सेटिंग्स साझा करती हैं। संयोजन चार्ट एक से अधिक समूह रख सकता है, इसलिए एक श्रृंखला के माध्यम से पहुँचे समूह को बदलना आवश्यक नहीं कि चार्ट की सभी श्रृंखलाओं को बदल दे।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा होता है?**  
हां। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addChart) नमूना श्रृंखलाएँ, श्रेणियाँ, और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**  
श्रृंखला नाम, श्रेणी लेबल, और डेटा‑बिंदु मान [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) में सेल्स को संदर्भित करते हैं। संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो।

**पूरी श्रृंखला के बजाय एक बिंदु कैसे साफ़ करें?**  
संबंधित मान सेल को `null` सेट करें ताकि बिंदु अपनी श्रेणी स्थिति को एक खाली बिंदु के रूप में बनाए रखे। केवल तभी [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapointcollection/#clear) को कॉल करें जब आप पूरी श्रृंखला को हटाना चाहते हों। यदि आप साथ ही श्रेणियाँ भी हटाते हैं, तो सभी श्रृंखलाओं को इस प्रकार अपडेट करें कि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**  
परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) द्वारा कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट खाली को गैप, शून्य या निकटवर्ती बिंदुओं को जोड़कर दिखा सकते हैं। अपने प्रेजेंटेशन में गायब डेटा का अर्थ किस प्रकार है, इस अनुसार सेटिंग चुनें। पूरी उदाहरण और दृश्य तुलना के लिए **[खाली सेल्स के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)** देखें।

**नकारात्मक मान कैसे फ़ॉर्मैट किए जाते हैं?**  
समर्थित बार, कॉलम, और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) को कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) द्वारा लौटाए गए रंग को असाइन करें। किसी व्यक्तिगत बिंदु के लिए उलटाव को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) से ओवरराइड किया जा सकता है। ये मेथड फ़ॉर्मैटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मैट किए गए हों तो कौन सा फ़ॉर्मैट प्राथमिकता लेता है?**  
स्पष्ठ डेटा‑बिंदु फ़ॉर्मैटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मैट या, यदि श्रृंखला फ़ॉर्मैट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट नियंत्रित करती हैं और बिंदु‑स्तर की फ़ॉर्मैट ओवरराइड नहीं हैं।

**क्या चार्ट में शामिल की जा सकने वाली श्रृंखलाओं की संख्या पर कोई सीमा है?**  
Aspose.Slides कोई अलग‑थलग स्थायी श्रृंखला‑गणना सीमा नहीं लगाता। व्यावहारिक रूप से, प्रेजेंटेशन फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत पास या बहुत दूर हों तो मुझे क्या बदलना चाहिए?**  
उपयुक्त पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) को कॉल करें। मान बढ़ाने से क्लस्टर्स के बीच की जगह विस्तृत होती है, और घटाने से क्लस्टर्स आपस में अधिक निकट आते हैं।