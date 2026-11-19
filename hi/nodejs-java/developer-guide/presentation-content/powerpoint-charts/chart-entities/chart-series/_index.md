---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट डेटा श्रृंखलाएँ प्रबंधित करें
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
description: "जावास्क्रिप्ट के साथ प्रस्तुतियों में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक सेल, स्वरूपण, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों का प्रबंधन कैसे करें सीखें।"
---
## **समीक्षा**

एक चार्ट अपने प्लॉट किए गए मानों को वर्कबुक कोशिकाओं में या सीधे संख्यात्मक लिटेरल्स के रूप में संग्रहीत कर सकता है। एक [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) उस श्रृंखला में एक बिंदु को दर्शाता है। [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स श्रृंखला द्वारा साझा किए गए लेबल या समूह मान प्रदान करते हैं। डिफ़ॉल्ट डेटा के साथ बनाए गए चार्ट्स में, श्रृंखला नाम, श्रेणियां और बिंदु मान चार्ट वर्कबुक के [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स का उपयोग करते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए स्तंभ 0, और शेष कोशिकाओं को श्रृंखला मानों के लिए उपयोग करती है। [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) को पास किए जाने वाले वर्कशीट, पंक्ति और स्तंभ सूचकांक शून्य‑आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मानने से बचें कि हर मौजूदा चार्ट इसे उपयोग करता है। लोड किए गए प्रेजेंटेशन के लिए, श्रृंखला, श्रेणियों और डेटा बिंदुओं द्वारा संदर्भित कोशिकाओं की जांच करें इससे पहले कि आप वर्कबुक मानों को बदलें।

चार्ट सेटिंग्स के तीन विभिन्न प्रकार होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), एक श्रृंखला के सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), एक बिंदु के लिए श्रृंखला रूप को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) से संबंधित हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसे विकल्प सेट करने हों, तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) के माध्यम से समूह तक पहुंचें।

जब कोई स्पष्ट बिंदु या श्रृंखला भराव सेट नहीं होता, तो चार्ट शैली और थीम स्वचालित रूप से स्वरूप निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फॉर्मेट मौजूद होते हैं, तो बिंदु फॉर्मेट उस बिंदु के लिए प्राथमिकता लेता है।

![चार्ट‑श्रृंखला‑पावरपॉइंट](chart-series-powerpoint.png)

एक क्लस्टर्ड सिलेंडर चार्ट के लिए, देखें कि कैसे [changing the 3D series type or bar shape](/slides/hi/nodejs-java/3d-chart/#change-the-3d-series-type-and-bar-shape) पहली श्रृंखला को प्रभावित करता है।

## **संख्यात्मक लिटेरल्स का उपयोग करके श्रृंखला मान सेट करें**

जब श्रृंखला मान एप्लिकेशन डेटा या गणनाओं से आते हैं और उन्हें वर्कशीट कोशिका संदर्भों की आवश्यकता नहीं होती, तो संख्यात्मक लिटेरल्स का उपयोग करें। प्रत्येक बिंदु के [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) परिणाम को [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/) के माध्यम से असाइन करने से पहले [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) को [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) के साथ कॉल करें।

संग्रह सेटिंग उस श्रृंखला में सभी बिंदु मानों के स्रोत प्रकार को नियंत्रित करती है। प्रत्येक बिंदु मान का [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) मेथड चयनित प्रकार रिपोर्ट करता है; इसे संग्रह सेटिंग के माध्यम से बदलें। `Worksheet` के साथ, संदर्भित कोशिका तक पहुंचने के लिए [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) का उपयोग करें। `DoubleLiterals` के साथ, संख्या को सीधे पढ़ने या लिखने के लिए [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) या `setAsLiteralDouble` का उपयोग करें।

निम्नलिखित उदाहरण डिफ़ॉल्ट श्रृंखला और श्रेणियों के साथ एक कॉलम चार्ट बनाता है, फिर उसकी पहली श्रृंखला के मौजूदा बिंदुओं को 10, 20, इत्यादि की गणना किए गए मान असाइन करता है। यह प्रेजेंटेशन को सहेजता है, पुनः खोलता है, और संग्रहीत मान प्रिंट करता है।

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

बिंदु मान स्रोत प्रकार अलग है [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) से, जो चार्ट के आंतरिक या बाह्य वर्कबुक कॉन्फ़िगरेशन को पहचानता है। संख्यात्मक लिटेरल्स का उपयोग स्वयं एम्बेडेड वर्कबुक को नहीं हटाता। इस उदाहरण में, वर्कबुक श्रेणी लेबल, श्रृंखला नाम और अन्य श्रृंखलाओं के लिए उपलब्ध रहती है। वर्कबुक प्रबंधन के लिए [Chart Workbook](/slides/hi/nodejs-java/chart-workbook/) देखें।

स्कैटर और बबल चार्ट के लिए, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) और [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) का उपयोग करके क्रमशः [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) और [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/) के स्रोत चुनें। बबल चार्ट में [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) का उपयोग करके [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/) का स्रोत चुना जाता है। प्रत्येक लागू स्रोत को `DoubleLiterals` पर सेट करें और फिर उस मान के `setAsLiteralDouble` मेथड के माध्यम से संख्याएँ असाइन करें।

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी ओवरलैप करते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑रेडियो प्रोजेक्शन है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम प्रदर्शित करते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

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

## **श्रृंखला भराव रंग बदलें**

पूरी श्रृंखला के लिए डिफ़ॉल्ट भराव सेट करने हेतु [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) का उपयोग करें। यदि किसी बिंदु का स्पष्ट भराव पहले से मौजूद है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) सेटिंग उस बिंदु के लिए श्रृंखला भराव को ओवरराइड करती है।

निम्नलिखित उदाहरण पहली श्रृंखला पर ठोस नीला भराव लागू करता है:

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

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत रहता है और सामान्यतः लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिए बनायीं गई डिफ़ॉल्ट वर्कबुक में, सेल B1 (पंक्ति 0, स्तंभ 1) में पहली श्रृंखला का नाम होता है। निम्न उदाहरण में नामांकित स्थिरांक इस संरचना को स्पष्ट करते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह विधि मौजूदा चार्ट में किसी निश्चित पंक्ति और स्तंभ के अनुमान से बचती है:

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

### **कई कोशिकाओं से नाम वाले श्रृंखला बनाएं**

यदि उत्पाद नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक कोशिकाओं में संग्रहीत हों, तो सम्मिलित श्रृंखला नाम उपयोगी होता है। उदाहरण के लिए, आप B1 में `Product A` और C1 में `2026` को एक ही श्रृंखला नाम में संयोजित कर सकते हैं जबकि दोनों भाग अपने स्रोत कोशिकाओं से जुड़े रहें।

[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) का उपयोग करके नाम रेंज प्राप्त करें, फिर उसे [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/) को पास करें। `skipHiddenCells` तर्क यह नियंत्रित करता है कि छिपी हुई कोशिकाएँ शामिल होंगी या नहीं: `true` उन्हें बाहर करता है, `false` उन्हें शामिल करता है। इस उदाहरण में सभी कोशिकाओं को शामिल करने के लिए `false` का उपयोग किया गया है।

निम्नलिखित उदाहरण एक प्रेजेंटेशन बनाता है जिसमें एक श्रृंखला और दो डेटा बिंदु होते हैं। कोशिकाएँ B1:C1 केवल श्रृंखला नाम प्रदान करती हैं; A2:A3 श्रेणी लेबल देती हैं, और B2:B3 संख्यात्मक मान देती हैं।

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

    // ये दो कोशिकाएँ श्रृंखला नाम प्रदान करती हैं।
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // अलग-अलग कोशिकाएँ श्रेणियों और संख्यात्मक डेटा बिंदुओं को प्रदान करती हैं।
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

परिणामी श्रृंखला नाम `Product A 2026` है, दो कोशिका मानों के बीच एक स्पेस के साथ। लेजेंड इसे दोनों कॉलम के लिए एक एंट्री के रूप में दिखाता है। नीचे की छवि परिणाम दर्शाती है:

![Legend में Product A 2026 के साथ संयुक्त श्रृंखला नाम वाला कॉलम चार्ट](composite_series_name.png)

## **स्वचालित श्रृंखला भराव रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) श्रृंखला अनुक्रम और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वही रंग है जो तब उपयोग होता है जब श्रृंखला भराव स्पष्ट रूप से परिभाषित नहीं है। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया भराव असाइन नहीं करता।

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

बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) नकारात्मक मानों को अलग रंग से प्रदर्शित कर सकता है। सामान्य श्रृंखला भराव को ठोस सेट करें, उलटा सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्नलिखित उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तंभ 0 में श्रेणी नाम, और स्तंभ 1 में मान होते हैं:

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

![उलटा ठोस भराव रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिए उलटा सेटिंग को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) के माध्यम से सक्षम कर सकते हैं। निम्न उदाहरण में, उलटा श्रृंखला के लिए अक्षम किया गया है और केवल चयनित बिंदु के लिए सक्षम किया गया है। बिंदु को एक नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखे:

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

एक बिंदु को खाली बनाने के लिए, उसके बैकिंग वर्कबुक सेल को `null` सेट करें, जबकि अन्य बिंदुओं को न हटाएँ। कॉलम चार्ट के लिए, प्लॉट किया गया मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) के माध्यम से उपलब्ध होता है। डेटा बिंदु उसी श्रेणी स्थान पर रहता है, लेकिन चार्ट उसकी मान को ब्लैंक‑वैल्यू सेटिंग के अनुसार खाली मानता है।

निम्नलिखित उदाहरण पहली श्रृंखला के केवल दूसरे बिंदु को साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट एक आकार कोशिका भी उपयोग करता है। केवल उस कोशिका को साफ़ करें जो हटाने वाले मान का प्रतिनिधित्व करती है। जब आप अन्य बिंदुओं को रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) को कॉल न करें, क्योंकि यह मेथड उस श्रृंखला के सभी डेटा बिंदुओं को हटा देता है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

छिपी हुई कोशिकाएँ जिनमें मान होते हैं, वे खाली कोशिकाओं से अलग केस हैं। छिपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा को शामिल या बाहर करने के लिए, देखें [Include Data from Hidden Rows and Columns](/slides/hi/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक कोशिका अनुपलब्ध डेटा को दर्शाती है; `0` वाली कोशिका ज्ञात संख्यात्मक मान को दर्शाती है। एक कोशिका को खाली बनाने के लिए [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) को `null` के साथ कॉल करें। संख्यात्मक शून्य ब्लैंक‑सेल सेटिंग के बावजूद शून्य ही रहेगा।

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) का उपयोग करके चुनें कि चार्ट खाली कोशिकाओं को कैसे प्रदर्शित करता है। यह सेटिंग पूरे चार्ट पर लागू होती है। यह ब्लैंक्स को कैसे प्लॉट किया जाता है, उसे बदलती है, बिना खाली वर्कबुक कोशिका को शून्य या इंटरपोलेटर मान से भरने के।

निम्नलिखित स्व‑निहित उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) वर्कशीट 0, श्रेणी लेबल के लिए स्तंभ 0, और मान के लिए स्तंभ 1 का उपयोग करता है; पंक्ति 0 में श्रृंखला नाम होता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    // Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा बिंदु को बरकरार रखें।
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

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले असाइन किए गए मोड को संग्रहीत करती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, इच्छित मोड असाइन करें और प्रेजेंटेशन को एक बार सहेजें, मोड पर इटरेट करने के बजाय।

नीचे तुलना में सभी तीन फ़ाइलों में समान डेटा दिखाया गया है। दिन 3 प्रत्येक केस में वर्कबुक में खाली है:

![एक ही डेटा वाले लाइन चार्ट: Gap दिन 3 पर लाइन को तोड़ता है, Zero लाइन को शून्य पर ले जाता है, और Span दिन 2 से दिन 4 को जोड़ता है](display_blanks_as.png)

दिखाया गया प्रभाव चार्ट प्रकार पर निर्भर करता है। एक लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में अनुपलब्ध श्रेणी के ऊपर जोड़ने के लिए कोई लाइन नहीं होती, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को नहीं बना सकता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर्स वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों के लिए तीन अलग-अलग परिणाम की उम्मीद न करें; अपने उपयोग के प्रकार के लिए आउटपुट जांचें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई क्रमबद्ध बार या कॉलम क्लस्टर के बीच की जगह है, जो बार या कॉलम चौड़ाई के प्रतिशत में व्यक्त की जाती है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि किसी एकल श्रृंखला से। समूह के लिए केवल एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) को कॉल करें। बड़ी मान अधिक जगह बनाती है; छोटी मान क्लस्टरों को अधिक घना बनाता है।

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

![गैप चौड़ाई](gap_width.png)

## **श्रृंखला लाइनों को दिखाएँ या छुपाएँ**

श्रृंखला लाइने चार्ट के संबंधित भागों को दृश्य रूप से जोड़ती हैं। समर्थित स्टैक्ड बार और ऑफ़पाइ चार्ट में उन्हें दिखाने या छुपाने के लिए [ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setserieslines/) का उपयोग करें। दो‑आयामी स्टैक्ड बार और कॉलम चार्ट में, वे श्रेणियों के पार संबंधित स्टैक सीमाओं को जोड़ती हैं। पाई ऑफ़ पाई और बार ऑफ़ पाई चार्ट में, वे मुख्य प्लॉट को द्वितीयक प्लॉट से जोड़ती हैं। यह सेटिंग अन्य चार्ट प्रकारों के लिए सामान्य कनेक्टर नहीं है।

[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) के माध्यम से समूह तक पहुंचें। यह सेटिंग उस समूह की प्रत्येक श्रृंखला पर लागू होती है। [ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/hasserieslines/) केवल‑रेडियो है और पैरेंट समूह की सेटिंग को प्रतिबिंबित करता है; इसे अपडेट करने के लिए समूह की सेटर को कॉल करें।

निम्नलिखित उदाहरण एक [PieOfPie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा है। यह एक ही चार्ट को श्रृंखला लाइनों के सक्षम और अक्षम दोनों रूप में सहेजता है, दो प्रेजेंटेशन बनाता है तुलना के लिए।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 400);
    const series = chart.getChartData().getSeries().get_Item(0);
    const seriesGroup = series.getParentSeriesGroup();

    seriesGroup.setSeriesLines(true);
    presentation.save("series_lines_enabled.pptx", aspose.slides.SaveFormat.Pptx);

    seriesGroup.setSeriesLines(false);
    presentation.save("series_lines_disabled.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| श्रृंखला लाइने सक्षम | श्रृंखला लाइने अक्षम |
| --- | --- |
| ![Series lines enabled वाला Pie of Pie चार्ट](series_lines_enabled.png) | ![Series lines disabled वाला Pie of Pie चार्ट](series_lines_disabled.png) |
| दो लाइने मुख्य पाई को द्वितीयक पाई से जोड़ती हैं। | दोनों पाई दिखाई देती हैं, लेकिन कनेक्टिंग लाइने छिपी हुई हैं। |

श्रृंखला लाइने डेटा लेबल लीडर लाइनों से अलग होती हैं, जो लेबल को उनके डेटा बिंदुओं से जोड़ती हैं; ग्रिडलाइन, जो चार्ट अक्षों के साथ अंतराल चिह्नित करती हैं; और लाइन चार्ट की लाइने, जो डेटा मान का प्रतिनिधित्व करती हैं। यह सेटिंग उन तत्वों को नियंत्रित नहीं करती।

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखला को सपोर्ट करते हैं?**

[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) एनेमरेशन द्वारा दर्शाए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, पर उनकी श्रृंखलाओं की मान संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट श्रेणियों और मानों का उपयोग करते हैं, स्कैटर चार्ट X और Y मानों का, और बबल चार्ट बबल आकार जोड़ते हैं। श्रृंखला प्रकार के अनुसार उपयुक्त डेटा‑बिंदु निर्माण मेथड का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसे विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**एक चार्ट श्रृंखला समूह क्या है?**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) वह समूह है जिसमें संगत श्रृंखलाएँ होती हैं जो समूह‑स्तरीय प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को आवश्यक नहीं बदलेगा।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा होता है?**

हां। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑बिंदु मान [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) की कोशिकाओं को संदर्भित करते हैं। संदर्भित कोशिका को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस तरह संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय एक बिंदु को कैसे साफ़ करूँ?**

संबंधित मान कोशिका को `null` सेट करके बिंदु की श्रेणी स्थिति को एक खाली बिंदु के रूप में रखें। [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) का उपयोग केवल तब करें जब आप उस श्रृंखला के सभी बिंदुओं को हटाना चाहते हों, क्योंकि यह मेथड उस श्रृंखला के प्रत्येक बिंदु को हटा देता है। यदि आप श्रेणियों को भी हटाते हैं, तो सुनिश्चित करें कि सभी श्रृंखलाएँ अपने मानों को श्रेणी संग्रह के साथ संरेखित रखें।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) में कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान, या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। अपने प्रेजेंटेशन में अनुपलब्ध डेटा के अर्थ के अनुसार सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मान कैसे स्वरूपित होते हैं?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) को कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) से प्राप्त रंग सेट करें। आप व्यक्तिगत बिंदु के लिए उलटा सेटिंग को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) से ओवरराइड कर सकते हैं। ये मेथड स्वरूपण को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेटेड हों तो कौन सा फ़ॉर्मेट जीतता है?**

विशिष्ट बिंदु के लिए स्पष्ट डेटा‑बिंदु फ़ॉर्मेट की प्राथमिकता होती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग करते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर फ़ॉर्मेट ओवरराइड नहीं होतीं।

**क्या किसी चार्ट में अधिकतम कितनी श्रृंखलाएँ हो सकती हैं?**

Aspose.Slides में कोई अलग निश्चित श्रृंखला‑गणना सीमा नहीं है। व्यावहारिक रूप से, प्रेजेंटेशन फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत पास या बहुत दूर हों तो क्या बदलना चाहिए?**

समुचित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) को कॉल करें। मान बढ़ाने से क्लस्टरों के बीच की जगह बढ़ेगी, और घटाने से क्लस्टर एक‑दूसरे के करीब आएँगे।