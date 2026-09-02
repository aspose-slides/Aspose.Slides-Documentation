---
title: JavaScript का उपयोग करके प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं का प्रबंधन
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
description: "JavaScript के साथ प्रस्तुतियों में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक सेल, स्वरूपण, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित करें, सीखें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/) संबंधित मानों के एक सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/) एक या अधिक वर्कबुक सेल को संदर्भित करता है। [ChartCategory](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स उन लेबल या समूह मानों को प्रदान करते हैं जो श्रृंखलाओं द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियां, और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं न कि केवल डिस्प्ले टेक्स्ट के रूप में संग्रहीत।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक श्रृंखला के नामों के लिए पंक्ति 0, श्रेणी नामों के लिए कॉलम 0, और शेष सेल्स श्रृंखला मानों के लिए उपयोग करती है। वर्कशीट, पंक्ति, और कॉलम इंडेक्स जो [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#getCell) को पास किए जाते हैं, शून्य-आधारित होते हैं। यह लेआउट तभी उपयोगी है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मत मानें कि हर मौजूदा चार्ट इसका उपयोग करता है। लोड की गई प्रस्तुति के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियां, और डेटा पॉइंट्स द्वारा संदर्भित सेल्स का निरीक्षण करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- श्रृंखला-स्तर की सेटिंग्स, जैसे [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getFormat), एक श्रृंखला में सभी बिंदुओं के लिए डिफ़ॉल्ट स्वरूप प्रदान करती हैं।
- डेटा-पॉइंट सेटिंग्स, जैसे [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#getFormat), एक बिंदु के लिए श्रृंखला के स्वरूप को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो समान [ChartSeriesGroup](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/) में होती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने की आवश्यकता हो, तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल सेट नहीं किया गया हो, तो चार्ट स्टाइल और थीम स्वचालित रूप से स्वरूप तय करती हैं। जब दोनों, श्रृंखला और बिंदु का फ़ॉर्मेट मौजूद हो, तो उस बिंदु के लिए बिंदु फ़ॉर्मेट को प्राथमिकता दी जाती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getOverlap) 2D चार्ट में बार या कॉलम के ओवरलैप की मात्रा -100 से 100 प्रतिशत तक रिपोर्ट करता है। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल- पढ़ने योग्य प्रोजेक्शन है। उस समूह में सभी संगत श्रृंखलाओं को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्नलिखित उदाहरण उस समूह के लिए ओवरलैप सेट करता है जिसमें पहली श्रृंखला शामिल है:

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

    // नया चार्ट नमूना श्रृंखला, श्रेणियां और मान शामिल करता है।
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The series overlap](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलें**

पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने के लिए [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getFormat) का उपयोग करें। यदि किसी बिंदु का फ़िल पहले से स्पष्ट रूप से सेट है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड करती है।

निम्नलिखित उदाहरण पहली श्रृंखला पर ठोस नीला फ़िल लागू करता है:

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

![The color of the series](series_color.png)

## **श्रृंखला नाम बदलें**

एक श्रृंखला का नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए निर्मित डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर होता है और इसमें पहली श्रृंखला का नाम होता है। निम्नलिखित उदाहरण में नामित स्थिरांक इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति और कॉलम को मानने से बचाता है:

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

![The series name](series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) श्रृंखला अनुक्रमांक और चार्ट स्टाइल से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल नहीं सौंपता।

निम्नलिखित उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

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

डिफ़ॉल्ट चार्ट स्टाइल के लिए उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट स्टाइल और थीम पर निर्भर करते हैं।

## **चार्ट श्रृंखला के लिए इन्वर्ट फ़िल रंग सेट करें**

बार, कॉलम, और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को अलग फ़िल के साथ दिखा सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इन्वर्ज़न सक्षम करें, और नकारात्मक मान का रंग [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से सौंपें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका डिस्प्ले रंग बदलता है।

निम्नलिखित उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम होता है, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

आप एक बिंदु के लिए इन्वर्ज़न को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के माध्यम से सक्षम कर सकते हैं। निम्नलिखित उदाहरण में, श्रृंखला के लिए इन्वर्ज़न निष्क्रिय है और केवल चयनित बिंदु के लिए सक्षम किया गया है। बिंदु को नकारात्मक मान भी सौंपा गया है ताकि प्रभाव दिखे:

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

एक बिंदु को ख़ाली करने के लिए बिना बाकी बिंदुओं को हटाए, उसके बैकिंग वर्कबुक सेल को `null` सेट करें। कॉलम चार्ट के लिए, प्लॉट किया गया मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से उपलब्ध है। डेटा पॉइंट वही श्रेणी स्थिति पर रहता है, लेकिन चार्ट अपने ब्लैंक-वैल्यु सेटिंग्स के अनुसार उसके मान को खाली मानता है।

निम्नलिखित उदाहरण पहली श्रृंखला के दूसरे बिंदु को ही साफ़ करता है:

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

स्कैटर चार्ट अलग-अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट एक आकार सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदुओं को रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapointcollection/#clear) को कॉल न करें, क्योंकि यह मेथड संग्रह से सभी डेटा पॉइंट्स हटा देता है।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई बार या कॉलम क्लस्टर्स के बीच की जगह है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि किसी एक श्रृंखला से। समूह के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) को कॉल करें। बड़ा मान क्लस्टर्स के बीच अधिक जगह बनाता है; छोटा मान उन्हें अधिक घना बनाता है।

निम्नलिखित उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

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

![The gap width](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं को समर्थन देते हैं?**

सभी चार्ट प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/) एन्युमरेशन द्वारा दर्शाए गए हैं, चार्ट डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं में मान संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट श्रेणियां और मान उपयोग करते हैं, स्कैटर चार्ट X और Y मान उपयोग करते हैं, और बबल चार्ट बबल के आकार जोड़ते हैं। उस श्रृंखला प्रकार से मेल खाने वाले डेटा-पॉइंट निर्माण मेथड का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**एक चार्ट श्रृंखला समूह क्या है?**

[ChartSeriesGroup](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/) में संगत श्रृंखलाएँ होती हैं जो समूह-स्तर की प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचे समूह को बदलने से आवश्यक नहीं कि चार्ट में सभी श्रृंखलाएँ बदल जाएँ।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा होता है?**

हाँ। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addChart) नमूना श्रृंखलाएँ, श्रेणियां और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला के नाम, श्रेणी लेबल, और डेटा-पॉइंट मान [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) में सेल्स को संदर्भित करते हैं। किसी संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला-मान पंक्तियों को इस तरह संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय एक बिंदु कैसे साफ़ करूँ?**

संबंधित मान सेल को `null` सेट करें ताकि बिंदु की श्रेणी स्थिति एक खाली बिंदु के रूप में बनी रहे। [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapointcollection/#clear) का उपयोग केवल तब करें जब आप उस श्रृंखला के सभी बिंदु हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदुओं को कैसे दिखाया जाता है?**

परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) के माध्यम से कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट खाली जगहों को गैप, शून्य मान, या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। ऐसी सेटिंग चुनें जो आपके प्रस्तुति में लापता डेटा के अर्थ से मेल खाती हो।

**नकारात्मक मानों का स्वरूपण कैसे किया जाता है?**

समर्थित बार, कॉलम, और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) को कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) द्वारा लौटाए गए रंग को सेट करें। आप व्यक्तिगत बिंदु के लिए व्यवहार को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) से ओवरराइड कर सकते हैं। ये मेथड्स फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब दोनों, श्रृंखला और बिंदु का फ़ॉर्मेट किया गया हो, तो किस फ़ॉर्मेटिंग को प्राथमिकता मिलती है?**

स्पष्ट डेटा-पॉइंट फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट स्टाइल और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और बिंदु-स्तर के फ़ॉर्मेटिंग ओवरराइड नहीं हैं।

**क्या किसी चार्ट में अधिकतम श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides कोई अलग स्थिर श्रृंखला-गणना सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल प्रतिबंध, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता एक उपयोगी सीमा निर्धारित करती है।

**जब कॉलम बहुत निकट या बहुत दूर हों तो मुझे क्या बदलना चाहिए?**

उचित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) को कॉल करें। मान बढ़ाने से क्लस्टर्स के बीच की दूरी बढ़ेगी, या इसे घटाने से क्लस्टर्स एक‑दूसरे के पास आएँगे।