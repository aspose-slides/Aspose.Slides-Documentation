---
title: प्रेज़ेंटेशन में JavaScript का उपयोग करके चार्ट डेटा श्रृंखलाओं का प्रबंधन
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
- प्रेज़ेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "जाने कैसे JavaScript के साथ प्रेज़ेंटेशन में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक सेल, फॉर्मैटिंग, ओवरलैप, गैप चौड़ाई, और नकारात्मक मान को प्रबंधित करें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/) एक संबंधित मानों का सेट दर्शाता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/) एक या अधिक वर्कबुक कोशिकाओं को संदर्भित करता है। [ChartCategory](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स लेबल या समूहिंग मान प्रदान करते हैं जो श्रृंखला में साझा होते हैं। इसलिए श्रृंखला का नाम, श्रेणियां, और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, स्तंभ 0 को श्रेणी नामों के लिए, और शेष कोशिकाओं को श्रृंखला मानों के लिए उपयोग करती है। [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#getCell) को पास किए जाने वाले वर्कशीट, पंक्ति, और स्तंभ सूचकांक शून्य-आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मान न रखें कि हर मौजूदा चार्ट इसका उपयोग करता है। लोडेड प्रेजेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियां, और डेटा बिंदुओं द्वारा संदर्भित कोशिकाओं की जाँच करें।

चार्ट सेटिंग्स के तीन विभिन्न स्तर होते हैं:

- श्रृंखला-स्तर सेटिंग्स, जैसे [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getFormat), सभी बिंदुओं के लिए डिफ़ॉल्ट स्वरूप प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#getFormat), एक बिंदु के लिए श्रृंखला स्वरूप को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/) से संबंधित होती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने की आवश्यकता हो तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से समूह तक पहुंचें।

जब कोई स्पष्ट बिंदु या श्रृंखला भराव सेट नहीं किया जाता, तो चार्ट शैली और थीम स्वचालित स्वरूप निर्धारित करते हैं। जब दोनों, श्रृंखला और बिंदु स्वरूप मौजूद हों, तो बिंदु स्वरूप उस बिंदु के लिए प्राथमिकता लेता है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getOverlap) 2D चार्ट में बार या कॉलम के ओवरलैप प्रतिशत को -100 से 100 तक रिपोर्ट करता है। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल-पढ़ने योग्य प्रोजेक्शन है। उस समूह में सभी संगत श्रृंखलाओं को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह मिश्रित चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्नलिखित उदाहरण पहले श्रृंखला को शामिल करने वाले समूह के लिए ओवरलैप सेट करता है:

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

    // नया चार्ट नमूना श्रृंखला, श्रेणियों, और मानों को शामिल करता है।
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

## **श्रृंखला भराव रंग बदलें**

पूरा श्रृंखला का डिफ़ॉल्ट भराव सेट करने के लिए [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getFormat) का उपयोग करें। यदि किसी बिंदु का पहले से स्पष्ट भराव है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस बिंदु के लिए श्रृंखला भराव को ओवरराइड करती है।

निम्नलिखित उदाहरण पहले श्रृंखला पर ठोस नीला भराव लागू करता है:

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

एक श्रृंखला का नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लीजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाए गए डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, स्तंभ 1 पर स्थित है और पहले श्रृंखला का नाम रखता है। निम्नलिखित उदाहरण में नामित कॉन्स्टेंट्स इस संरचना को स्पष्ट करते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति और स्तंभ को मानने से बचता है:

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

## **स्वचालित श्रृंखला भराव रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) श्रृंखला सूचकांक और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला भराव स्पष्ट रूप से निर्धारित नहीं किया गया हो। यह मेथड गणना किए गए रंग को पढ़ता है; यह नया भराव असाइन नहीं करता।

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

डिफ़ॉल्ट चार्ट शैली के लिए उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **एक चार्ट श्रृंखला के लिए उलटा भराव रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को अलग भराव के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला भराव को ठोस सेट करें, उलटाव सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। नकारात्मक संख्याएं वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्नलिखित उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला के साथ बदलता है। कार्यपत्र पंक्ति 0 श्रृंखला नाम रखती है, स्तंभ 0 श्रेणी नाम रखता है, और स्तंभ 1 मान रखता है:

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

आप एक बिंदु के लिए उलटाव को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) द्वारा सक्षम कर सकते हैं। नीचे दिए गए उदाहरण में श्रृंखला के लिए उलटाव निष्क्रिय किया गया है और केवल चयनित बिंदु के लिए सक्रिय किया गया है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखे:

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

## **विशिष्ट डेटा बिंदु मान को साफ़ करें**

एक बिंदु को खाली करने के लिए, लेकिन अन्य बिंदुओं को न हटाने के लिए, उसकी बैकिंग वर्कबुक सेल को `null` सेट करें। कॉलम चार्ट के लिए, प्लॉट किया गया मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से उपलब्ध होता है। डेटा बिंदु उसी श्रेणी स्थिति पर रहता है, लेकिन चार्ट अपनी खाली‑मान सेटिंग के अनुसार इसे खाली मानता है।

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट में आकार कोशिका भी होती है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। यदि आप अन्य बिंदुओं को बनाए रखना चाहते हैं तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapointcollection/#clear) न कॉल करें, क्योंकि यह मेथड संग्रह से सभी डेटा बिंदु हटा देता है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

छिपी हुई कोशिकाओं में मान होना एक अलग मामला है। छिपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा को शामिल या बाहर करने के लिए देखें: [Include Data from Hidden Rows and Columns](/slides/hi/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपलब्ध डेटा को दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। एक सेल को खाली बनाने के लिए [ChartDataCell.setValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setValue) को `null` पास करें। संख्यात्मक शून्य सेटिंग के बावजूद शून्य ही रहता है।

खाली कोशिकाओं के प्रदर्शन को चुनने के लिए [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है। यह खाली मानों को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरें।

निम्नलिखित स्वयं‑समावेशी उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) कार्यपत्र 0, स्तंभ 0 को श्रेणी लेबल और स्तंभ 1 को मान के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले सेट किए गए मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, इच्छित मोड असाइन करें और प्रेजेंटेशन को एक बार सहेजें बजाय कई मोड पर इटरिटे करने के।

नीचे तुलना दिखाती है कि एक ही डेटा तीन फ़ाइलों में कैसे दिखता है। दिन 3 हर मामले में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दिखाई देने वाला प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड की आसान तुलना प्रदान करता है। बार और कॉलम चार्टों में कोई लाइन नहीं होती जिससे गायब श्रेणी पर कनेक्ट किया जा सके, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को उत्पन्न नहीं कर सकता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों के लिए तीन अलग परिणाम की उम्मीद न रखें; अपने उपयोग किए गये प्रकार के आउटपुट की जाँच करें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई बार या कॉलम क्लस्टर के बीच का अंतराल है, जो बार या कॉलम की चौड़ाई के प्रतिशत के रूप में व्यक्त होता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि व्यक्तिगत श्रृंखला से। समूह के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ी मान क्लस्टर के बीच अधिक अंतराल बनाती है; छोटी मान उन्हें अधिक घना बनाती है।

निम्नलिखित उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रेजेंटेशन सहेजता है:

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

## **FAQ**

**कौन से चार्ट प्रकार डेटा श्रृंखला को समर्थन देते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/) एन्‍युमरेशन द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं में मूल्य संरचना या सेटिंग्स समान नहीं होतीं। उदाहरण के लिए, श्रेणी चार्ट श्रेणियों और मानों का उपयोग करते हैं, स्कैटर चार्ट X और Y मानों का, और बबल चार्ट बबल आकार जोड़ते हैं। श्रृंखला प्रकार से मेल खाती डेटा‑बिंदु निर्माण विधि का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

एक [ChartSeriesGroup](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/) संगत श्रृंखलाओं को समाहित करता है जो समूह‑स्तर के प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को अनिवार्य रूप से नहीं बदलता।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा होता है?**

हां। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addChart) नमूना श्रृंखलाएँ, श्रेणियाँ, और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑बिंदु मान [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) में कोशिकाओं को संदर्भित करते हैं। एक संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय, श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस तरह संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो।

**मैं पूरे श्रृंखला की बजाय एक बिंदु कैसे साफ़ करूँ?**

संबंधित मान सेल को `null` सेट करें ताकि बिंदु की श्रेणी स्थिति बनी रहे जबकि वह खाली बिंदु बन जाए। केवल तभी [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapointcollection/#clear) का उपयोग करें जब आप पूरे श्रृंखला के सभी बिंदु हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो प्रत्येक श्रृंखला को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ सहेजें।

**खाली बिंदुओं को कैसे प्रदर्शित किया जाता है?**

परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) द्वारा कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट खाली मानों को गैप, शून्य मान, या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। अपने प्रेजेंटेशन में अनुपलब्ध डेटा के अर्थ के अनुसार सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें: [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मान कैसे स्वरूपित होते हैं?**

समर्थित बार, कॉलम, और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) से प्राप्त रंग असाइन करें। आप व्यक्तिगत बिंदु के लिए [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) द्वारा व्यवहार को ओवरराइड कर सकते हैं। ये मेथड स्वरूपण को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों स्वरूपित हों तो कौन सा स्वरूप जीतता है?**

स्पष्ट डेटा‑बिंदु स्वरूपण उस बिंदु के लिए प्राथमिकता लेता है। अन्य बिंदु स्पष्ट श्रृंखला स्वरूप या, यदि श्रृंखला स्वरूप परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर के स्वरूप ओवरराइड नहीं करतीं।

**एक चार्ट में अधिकतम कितनी श्रृंखलाएं हो सकती हैं?**

Aspose.Slides कोई अलग स्थिर श्रृंखला‑गणना सीमा निर्धारित नहीं करता। व्यावहारिक रूप से, प्रेजेंटेशन फ़ाइल की बाधाएं, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट पढ़ने योग्यता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत करीब या बहुत दूर हों तो मुझे क्या बदलना चाहिए?**

उचित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। क्लस्टर के बीच स्थान को विस्तृत करने के लिए मान बढ़ाएँ, या उन्हें करीब लाने के लिए घटाएँ।