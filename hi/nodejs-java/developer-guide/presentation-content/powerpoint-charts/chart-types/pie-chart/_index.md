---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में पाई चार्ट को अनुकूलित करें
linktitle: पाई चार्ट
type: docs
url: /hi/nodejs-java/pie-chart/
keywords:
- पाई चार्ट
- चार्ट प्रबंधित करें
- चार्ट को अनुकूलित करें
- चार्ट विकल्प
- चार्ट सेटिंग्स
- प्लॉट विकल्प
- स्लाइस रंग
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके जावास्क्रिप्ट में पाई चार्ट बनाएं और उन्हें अनुकूलित करें। द्वितीयक प्लॉट कॉन्फ़िगर करें, डेटा लेबल प्रदर्शित करें, और PowerPoint में स्वचालित स्लाइस रंग लागू करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पाई चार्ट के साथ काम करने के तरीके को समझाता है। यह Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्पों को कॉन्फ़िगर करना और मानक पाई चार्ट के लिए स्वचालित स्लाइस रंग निर्धारण सक्षम करना दर्शाता है।

उदाहरण चार्ट अनुकूलन कार्यों जैसे स्लाइड पर चार्ट जोड़ना, श्रृंखला और लेबल सेटिंग्स को समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, और अद्यतन प्रस्तुति को सहेजना, पर केंद्रित हैं।

## **पाई ऑफ पाई और बार ऑफ पाई चार्ट के लिए द्वितीयक प्लॉट विकल्प**

Aspose.Slides for Node.js via Java Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्पों का समर्थन करता है। ये विकल्प द्वितीयक प्लॉट के आकार और दो प्लॉट के बीच डेटा पॉइंट्स के विभाजन को नियंत्रित करते हैं।

नीचे दिया गया उदाहरण एक Pie of Pie चार्ट नई प्रस्तुति में बनाता है और डेटा पॉइंट मानों को लेबल के रूप में प्रदर्शित करता है। [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) मेथड द्वितीयक प्लॉट आकार को मुख्य प्लॉट के 149 % पर सेट करता है। [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) प्रतिशत‑आधारित विभाजन चुनता है, और [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) सीमा को 53 % पर सेट करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // मान प्रदर्शित करें और द्वितीयक प्लॉट को कॉन्फ़िगर करें।
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **द्वितीयक प्लॉट के लिए श्रेणियों का चयन करें**

जब आप विशिष्ट श्रेणियों को उनके प्रतिशत मानों की परवाह किए बिना द्वितीयक प्लॉट में समूहित करना चाहते हैं, तो कस्टम विभाजन का उपयोग करें। उदाहरण के लिए, एक बिक्री रिपोर्ट में Online और Events को एक साथ दिखाया जा सकता है ताकि पाठक इन दो चैनलों की तुलना कर सकें, भले ही वे कुल बिक्री के 35 % और 10 % होते हों।

[setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) को [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) के साथ कॉल करें और बिंदुओं का चयन [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) के माध्यम से करें। कलेक्शन की [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) मेथड श्रृंखला में शून्य‑आधारित अनुक्रमांक स्वीकार करती है; डेटा पॉइंट ऑब्जेक्ट जोड़ने के लिए [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) का उपयोग करें। इस उदाहरण में, अनुक्रमांक 1 Online का चयन करता है, और अनुक्रमांक 3 Events का चयन करता है। Partners को अस्थायी रूप से भी जोड़ा जाता है, फिर [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem) से बाहर किया जाता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // डिफ़ॉल्ट डेटा को चैनल के हिसाब से बिक्री डेटा से बदलें।
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Online को उसके शून्य-आधारित अनुक्रमांक से और Events को डेटा पॉइंट ऑब्जेक्ट से चुनें।
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Partners को चयन से बाहर करें बिना उसके स्रोत डेटा को हटाए।
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) और Events (10) द्वितीयक प्लॉट में पृथक स्लाइस के रूप में दिखते हैं। प्राथमिक प्लॉट में वे 45 मान वाले एक संयुक्त स्लाइस द्वारा दर्शाए जाते हैं, साथ ही Retail (40) और Partners (15) भी होते हैं। Partners को कस्टम चयन से हटाने से वह प्राथमिक प्लॉट में रहता है; यह चार्ट के स्रोत डेटा से श्रेणी या उसका मान नहीं हटाता।

नीचे सहेजे गए प्रस्तुति का PowerPoint में रूप दिखाया गया है:

![दूसरे प्लॉट में Online और Events के साथ और प्राथमिक प्लॉट में उनका संयुक्त मान 45 वाला Pie of Pie चार्ट](pie_of_pie_custom.png)

## **स्वचालित पाई चार्ट स्लाइस रंग सेट करें**

Aspose.Slides for Node.js via Java पाई चार्ट स्लाइस को स्वचालित रूप से विभिन्न रंग असाइन कर सकता है। निम्न उदाहरण एक केंद्रित शीर्षक के साथ पाई चार्ट बनाता है और डिफ़ॉल्ट डेटा को तीन त्रैमासिक श्रेणियों और उनके मानों से बदल देता है। [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) मेथड 20, 50 और 30 मानों को लेबल के रूप में दर्शाता है, जबकि [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) प्रत्येक स्लाइस के लिए अलग रंग सक्षम करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // एक केंद्रित चार्ट शीर्षक जोड़ें।
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // पहले कार्यपत्रक का उपयोग करके डिफ़ॉल्ट डेटा को बदलें।
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // मान प्रदर्शित करें और स्लाइस को विभिन्न रंग असाइन करें।
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**क्या Pie of Pie और Bar of Pie वैरिएंट्स समर्थित हैं?**

हां, लाइब्रेरी [supports](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) पाई चार्ट के लिए द्वितीयक प्लॉट, जिसमें Pie of Pie और Bar of Pie प्रकार सम्मिलित हैं।

**क्या मैं केवल चार्ट को छवि (जैसे PNG) के रूप में निर्यात कर सकता हूँ?**

हां, आप पूरे प्रस्तुति को निर्यात किए बिना [export the chart itself as an image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (जैसे PNG) कर सकते हैं।