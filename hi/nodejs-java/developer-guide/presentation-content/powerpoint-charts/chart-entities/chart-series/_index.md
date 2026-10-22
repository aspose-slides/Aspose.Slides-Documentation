---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट डेटा सीरीज़ प्रबंधित करें
linktitle: डेटा सीरीज़
type: docs
url: /hi/nodejs-java/chart-series/
keywords:
- चार्ट सीरीज़
- सीरीज़ ओवरलैप
- सीरीज़ रंग
- सीरीज़ नाम
- डेटा पॉइंट
- वर्कबुक सेल
- सीरीज़ गैप
- नकारात्मक मान
- PowerPoint
- प्रेज़ेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट के साथ प्रस्तुतियों में चार्ट सीरीज़, डेटा पॉइंट्स, वर्कबुक सेल्स, फ़ॉर्मेटिंग, ओवरलैप, गैप विड्थ और नकारात्मक मानों को कैसे प्रबंधित करें, यह सीखें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए मानों को वर्कबुक सेल्स में या सीधे संख्यात्मक लिटरल के रूप में संग्रहित कर सकता है। एक [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) उस सीरीज़ में एक बिंदु को दर्शाता है। [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) वस्तुएँ लेबल या समूहित मान प्रदान करती हैं जो सीरीज़ द्वारा साझा किए जाते हैं। डिफ़ॉल्ट डेटा के साथ बनाए गए चार्ट में, सीरीज़ नाम, श्रेणियां, और बिंदु मान चार्ट वर्कबुक से [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) वस्तुओं का उपयोग करते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को सीरीज़ नामों के लिए, कॉलम 0 को श्रेणी नामों के लिए, और शेष सेल्स को सीरीज़ मानों के लिए उपयोग करती है। [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) को पास किए जाने वाले कार्यपत्रक, पंक्ति, और कॉलम क्रमांक शून्य‑आधारित होते हैं। यह लेआउट उस समय उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ चार्ट बनाते हैं, लेकिन यह मानना सही नहीं है कि हर मौजूदा चार्ट इसका उपयोग करता है। किसी लोड किए गए प्रेज़ेंटेशन के लिए, वर्कबुक मानों को बदलने से पहले सीरीज़, श्रेणियों, और डेटा पॉइंट्स द्वारा संदर्भित सेल्स का निरीक्षण करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- सीरीज़‑स्तर की सेटिंग्स, जैसे [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), एक सीरीज़ के सभी बिंदुओं के लिए डिफ़ॉल्ट दिखावट प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), एक बिंदु के लिए सीरीज़ दिखावट को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत सीरीज़ पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) से संबंधित हैं। जब आपको ओवरलैप या गैप विड्थ जैसी विकल्प सेट करने की आवश्यकता हो, तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) के माध्यम से समूह तक पहुंचें।

जब कोई स्पष्ट बिंदु या सीरीज़ फिल सेट नहीं किया जाता, तो चार्ट शैली और थीम स्वचालित दिखावट निर्धारित करती हैं। जब दोनों सीरीज़ और बिंदु फ़ॉर्मेटिंग मौजूद होती हैं, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **संख्यात्मक लिटरल का उपयोग करके सीरीज़ मान सेट करें**

जब सीरीज़ मान एप्लिकेशन डेटा या गणनाओं से आते हैं और कार्यपत्रक सेल रेफ़रेंस की आवश्यकता नहीं होती, तो संख्यात्मक लिटरल का उपयोग करें। प्रत्येक बिंदु के [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) परिणाम को [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/) के माध्यम से असाइन करने से पहले [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) को [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) के साथ कॉल करें।

कलेक्शन सेटिंग उस सीरीज़ में सभी बिंदु मानों के स्रोत प्रकार को नियंत्रित करती है। प्रत्येक बिंदु मान की [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) मेथड चयनित प्रकार को रिपोर्ट करती है; इसे कलेक्शन सेटिंग के द्वारा बदलें। `Worksheet` के साथ, रेफ़रेंस किए गए सेल तक पहुंचने के लिए [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) का उपयोग करें। `DoubleLiterals` के साथ, संख्या को सीधे पढ़ने या लिखने के लिए [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) या `setAsLiteralDouble` का प्रयोग करें।

निम्न उदाहरण एक कॉलम चार्ट बनाता है जिसमें डिफ़ॉल्ट सीरीज़ और श्रेणियां होती हैं, फिर उसकी पहली सीरीज़ के मौजूदा बिंदुओं को 10, 20, आदि की गणना किए गए मान असाइन करता है। यह प्रेज़ेंटेशन को सहेजता है, पुनः खोलता है, और संग्रहीत मानों को प्रिंट करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

बिंदु मान स्रोत प्रकार [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) से अलग है, जो चार्ट के आंतरिक या बाहरी वर्कबुक कॉफ़िगरेशन को पहचानता है। संख्यात्मक लिटरल का उपयोग स्वयं एम्बेडेड वर्कबुक को नहीं हटाता। इस उदाहरण में, वर्कबुक श्रेणी लेबल, सीरीज़ नाम, और अन्य सीरीज़ के लिए उपलब्ध रहती है। वर्कबुक प्रबंधन के लिए देखें [Chart Workbook](/slides/hi/nodejs-java/chart-workbook/)।

स्कैटर और बबल चार्ट के लिए, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) और [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) का उपयोग करके क्रमशः [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) और [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/) के स्रोत चुनें। बबल चार्ट में [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) का उपयोग करके [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/) का स्रोत निर्धारित किया जाता है। प्रत्येक लागू स्रोत को `DoubleLiterals` पर सेट करें और फिर उस मान के `setAsLiteralDouble` मेथड के द्वारा संख्या असाइन करें।

## **चार्ट सीरीज़ ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी हद तक ओवरलैप होते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट सीरीज़ समूह पर सेटिंग का केवल‑पढ़ने योग्य प्रोजेक्शन है। सभी संगत सीरीज़ को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) का प्रयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो ग्रुपेड बार या कॉलम दिखाते हैं; यह कॉम्बिनेशन चार्ट के असंबंधित सीरीज़ समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहले सीरीज़ को शामिल करने वाले समूह के लिए ओवरलैप सेट करता है:

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

    // नया चार्ट नमूना सीरीज़, श्रेणियाँ और मान शामिल करता है।
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

## **सीरीज़ फ़िल रंग बदलें**

पूरी सीरीज़ के लिए डिफ़ॉल्ट फ़िल सेट करने हेतु [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) का प्रयोग करें। यदि कोई बिंदु पहले से स्पष्ट फ़िल रखता है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) सेटिंग उस बिंदु के लिए सीरीज़ फ़िल को ओवरराइड कर देती है।

निम्न उदाहरण पहले सीरीज़ पर ठोस नीला फ़िल लागू करता है:

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

## **सीरीज़ नाम बदलें**

सीरीज़ नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और आमतौर पर लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाया गया डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर स्थित होता है और पहली सीरीज़ का नाम रखता है। निम्न उदाहरण में स्थिरांक इस संरचना को स्पष्ट करते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह विधि किसी विशेष पंक्ति और कॉलम को मानते हुए उपयोग नहीं करती:

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

### **कई सेल्स से नाम वाली सीरीज़ बनाएं**

जब उत्पाद नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक सेल में संग्रहीत हों, तो सम्मिलित सीरीज़ नाम उपयोगी होता है। उदाहरण के लिए, आप B1 में `Product A` और C1 में `2026` को एकल सीरीज़ नाम में संयोजित कर सकते हैं, जबकि दोनों भागों को उनके स्रोत सेल से लिंक रख सकते हैं।

[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) का उपयोग करके नाम रेंज प्राप्त करें, फिर उस कलेक्शन को [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/) को पास करें। `skipHiddenCells` तर्क यह नियंत्रित करता है कि छिपे हुए सेल शामिल हों या नहीं: `true` उन्हें बाहर रखता है, जबकि `false` उन्हें शामिल करता है। यह उदाहरण `false` का उपयोग करके नाम रेंज के सभी सेल शामिल करता है।

निम्न उदाहरण एक प्रेज़ेंटेशन बनाता है जिसमें एक सीरीज़ और दो डेटा पॉइंट्स होते हैं। सेल B1:C1 केवल सीरीज़ नाम प्रदान करते हैं; A2:A3 श्रेणी लेबल प्रदान करते हैं, और B2:B3 संख्यात्मक मान प्रदान करते हैं।

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

    // ये दो सेल्स सीरीज़ नाम प्रदान करती हैं।
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // अलग-अलग सेल्स श्रेणियों और संख्यात्मक डेटा पॉइंट्स प्रदान करती हैं।
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

परिणामी सीरीज़ नाम `Product A 2026` होगा, जिसमें दो सेल मानों के बीच एक स्पेस रहेगा। लेजेंड इसे दोनों कॉलम के लिए एक एंट्री के रूप में दिखाता है। नीचे छवि परिणाम दर्शाती है:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **स्वचालित सीरीज़ फ़िल रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) सीरीज़ इंडेक्स और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो सीरीज़ फ़िल स्पष्ट रूप से परिभाषित न होने पर उपयोग किया जाता है। मेथड को कॉल करने से केवल गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट सीरीज़ का स्वचालित रंग प्रिंट करता है:

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

डिफ़ॉल्ट चार्ट शैली का उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **चार्ट सीरीज़ के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल सीरीज़ के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) का उपयोग करके नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित किया जा सकता है। नियमित सीरीज़ फ़िल को ठोस सेट करें, इनवर्ज़न सक्रिय करें, और नकारात्मक‑मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका डिस्प्ले रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक सीरीज़ से प्रतिस्थापित करता है। कार्यपत्रक पंक्ति 0 में सीरीज़ नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

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

आप [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) से किसी एक बिंदु के लिए इनवर्ज़न सक्षम कर सकते हैं। नीचे के उदाहरण में सीरीज़ के लिए इनवर्ज़न निष्क्रिय है और केवल चयनित बिंदु के लिए सक्षम किया गया है। बिंदु को दृश्य प्रभाव दिखाने के लिए नकारात्मक मान भी असाइन किया गया है:

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

## **विशिष्ट डेटा पॉइंट मान साफ़ करें**

एक बिंदु को खाली करने के लिए, उसके बैकिंग वर्कबुक सेल को `null` सेट करें, जबकि अन्य बिंदु बरकरार रहें। कॉलम चार्ट में, प्लॉट किया गया मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) से प्राप्त किया जाता है। डेटा पॉइंट अपनी श्रेणी स्थिति में रहता है, लेकिन चार्ट इसे ब्लैंक मान मानता है, जैसा कि चार्ट की ब्लैंक‑वैल्यू सेटिंग्स में परिभाषित है।

निम्न उदाहरण पहली सीरीज़ के केवल दूसरे बिंदु को साफ़ करता है:

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

स्कैटर चार्ट X और Y के लिए अलग‑अलग सेल्स उपयोग करते हैं, और बबल चार्ट आकार सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। यदि आप अन्य बिंदुओं को रखे रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) न कॉल करें, क्योंकि यह मेथड कलेक्शन से सभी डेटा पॉइंट्स हटा देता है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करें**

छिपे हुए सेल्स जिनमें मान होते हैं, वे खाली सेल्स से अलग केस होते हैं। छिपी हुई पंक्तियों और कॉलम्स से डेटा को शामिल या बाहर करने के लिए देखें [Include Data from Hidden Rows and Columns](/slides/hi/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थित डेटा को दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान को दर्शाता है। सेल को खाली करने के लिए [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) को `null` पास करें। संख्यात्मक शून्य हमेशा शून्य ही रहेगा, चाहे ब्लैंक‑सेल सेटिंग कुछ भी हो।

खाली सेल्स के प्रदर्शन को चुनने के लिए [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है। यह ब्लैंक्स को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरने के।

निम्न स्व-निर्भर उदाहरण एक लाइन चार्ट बनाता है जिसमें एक सीरीज़ है, Day 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ उसी चार्ट को सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) कार्यपत्रक 0, कॉलम 0 को श्रेणी लेबल्स के लिए, और कॉलम 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में सीरीज़ नाम होता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    // Day 3 को वास्तव में खाली छोड़ें, जबकि इसकी श्रेणी और डेटा पॉइंट बनाए रखें।
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

प्रत्येक आउटपुट फ़ाइल सहेजे जाने से पहले सेट किए गए मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। यदि केवल एक संस्करण चाहिए, तो इच्छित मोड असाइन करें और प्रस्तुति को एक बार सहेजें, मोड पर इटरेशन न करें।

नीचे तुलना दर्शाती है कि सभी तीन फ़ाइलों में डेटा समान है। Day 3 प्रत्येक केस में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दृश्यमान प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में लापता श्रेणी के कारण जोड़ने वाली लाइन नहीं होती, इसलिए `Span` उपर्युक्त कनेक्टिंग सेगमेंट नहीं बना पाता; एक लापता कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों के लिए तीन अलग परिणाम मिलने की अपेक्षा न रखें; अपने उपयोग के प्रकार के लिए आउटपुट की जाँच करें।

## **सीरीज़ गैप विड्थ सेट करें**

गैप विड्थ पड़ोसी बार या कॉलम क्लस्टर के बीच का अंतराल है, जो बार या कॉलम की चौड़ाई के प्रतिशत के रूप में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट सीरीज़ समूह से जुड़ा होता है, न कि व्यक्तिगत सीरीज़ से। समूह के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) कॉल करें। बड़ा मान क्लस्टर्स के बीच अधिक स्थान बनाता है; छोटा मान उन्हें घना बनाता है।

निम्न उदाहरण गैप विड्थ बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

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

**कौन से चार्ट प्रकार डेटा सीरीज़ का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) enumeration द्वारा दर्शाए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी सीरीज़ सभी के पास समान मान संरचना या सेटिंग नहीं होती। उदाहरण के लिए, श्रेणी चार्ट्स में श्रेणियां और मान होते हैं, स्कैटर चार्ट्स में X और Y मान होते हैं, और बबल चार्ट्स में बबल आकार जोड़ते हैं। डेटा‑पॉइंट निर्माण मेथड को सीरीज़ प्रकार के अनुसार चुनें। ओवरलैप और गैप विड्थ जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट सीरीज़ समूह क्या है?**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) संगत सीरीज़ को रखता है जो समूह‑स्तर के प्लॉटिंग सेटिंग्स साझा करते हैं। एक कॉम्बिनेशन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक सीरीज़ के माध्यम से पहुंचा गया समूह बदलना आवश्यक नहीं है कि चार्ट की सभी सीरीज़ बदलें।

**क्या नया बनाया गया चार्ट डिफ़ॉल्ट डेटा रखता है?**

हां। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) नमूना सीरीज़, श्रेणियां, और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले दोनों सीरीज़ और श्रेणी कलेक्शन साफ़ कर सकते हैं। एक ओवरलोड भी चार्ट को बिना डिफ़ॉल्ट डेटा के बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

सीरीज़ नाम, श्रेणी लेबल, और डेटा‑पॉइंट मान एक [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) में सेल्स को संदर्भित करते हैं। रेफ़रेंस किए गए सेल को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय, सुनिश्चित करें कि श्रेणी पंक्तियां और सीरीज़‑मान पंक्तियां संरेखित हों ताकि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरे सीरीज़ की बजाय एक बिंदु कैसे साफ़ करूँ?**

संबंधित मान सेल को `null` सेट करें ताकि बिंदु की श्रेणीय स्थिति खाली बिंदु के रूप में बनी रहे। [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) को केवल तभी कॉल करें जब आप पूरी सीरीज़ के सभी बिंदु हटाना चाहते हों। यदि आप श्रेणियां भी हटाते हैं, तो सभी सीरीज़ को इस तरह अपडेट करें कि उनके मान श्रेणी कलेक्शन के साथ संरेखित रहें।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) में सेट किए गए मान पर निर्भर करता है। समर्थित चार्ट खाली को गैप, शून्य मान, या निकटतम बिंदुओं को जोड़कर दर्शा सकते हैं। अपनी प्रस्तुति में लापता डेटा के अर्थ के अनुरूप सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मान कैसे फ़ॉर्मेट किए जाते हैं?**

समर्थित बार, कॉलम और बबल सीरीज़ के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) को कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) के द्वारा लौटाए गए रंग को सेट करें। आप [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) के साथ व्यक्तिगत बिंदु के लिए इस व्यवहार को ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब सीरीज़ और बिंदु दोनों फ़ॉर्मेट किए गए हों तो कौन सी फ़ॉर्मेटिंग जीतती है?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट सीरीज़ फ़ॉर्मेट या जब सीरीज़ फ़ॉर्मेट परिभाषित नहीं हो तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप विड्थ लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर की फ़ॉर्मेटिंग ओवरराइड नहीं होतीं।

**क्या चार्ट में सीरीज़ की संख्या पर कोई सीमा है?**

Aspose.Slides कोई अलग निश्चित सीरीज़‑गणना सीमा नहीं लगाता। व्यावहारिक रूप से, प्रेज़ेंटेशन फ़ाइल सीमाएं, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत करीब या बहुत दूर हों तो मुझे क्या बदलना चाहिए?**

उपयुक्त पैरेंट सीरीज़ समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) कॉल करें। मान बढ़ाने से क्लस्टर्स के बीच का अंतराल विस्तृत होगा, और मान घटाने से क्लस्टर्स एक-दूसरे के करीब आ जाएंगे।