---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/nodejs-java/chart-axis/
keywords:
- चार्ट अक्ष
- ऊर्ध्वाधर अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को नियंत्रित करें
- अक्ष को प्रबंधित करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट को Aspose.Slides for Node.js via Java के साथ उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिये PowerPoint प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करने का तरीका जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Node.js via Java के साथ चार्ट अक्षों को अनुकूलित करने के तरीकों को बताता है। इसमें गणना किए गए अक्ष मान, चार्ट पंक्तियों और स्तंभों का अदला‑बदली, अक्ष दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियाँ और स्वरूपण, शीर्षक घूर्णन, अक्ष स्थितिकरण, डिस्प्ले इकाइयाँ, और लॉगरिदमिक स्केलिंग शामिल हैं।

## **वर्टिकल अक्ष पर चार्ट में अधिकतम मान प्राप्त करें**

एक [प्रस्तुति](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) बनाकर डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मानों को पढ़ने से पहले चार्ट लेआउट को अद्यतन रखने के लिए [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) को कॉल करें।

अक्ष सीमाओं के लिए [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) और [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) पढ़ें, तथा टिक अंतराल के लिए [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) और [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) का उपयोग करें। समय‑एकक स्केल, जो तिथि अक्षों के लिए प्रासंगिक हैं, के लिए [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) और [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) प्रदान किए जाते हैं। यह उदाहरण इन मानों को स्थानीय चर में संग्रहीत करता है और चार्ट को सहेजता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्षों के बीच डेटा बदलें**

चार्ट डेटा में श्रृंखलाओं और श्रेणियों की भूमिकाओं को अदला‑बदली करने के लिए [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) का उपयोग करें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा समूहित करने के तरीके को बदलता है; यह क्षैतिज और ऊर्ध्वाधर अक्षों को अदला‑बदली नहीं करता। उदाहरण में डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करने के लिए [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) का उपयोग किया जाता है, जिसमें हेडर पंक्ति और श्रेणी स्तंभ शामिल हैं, फिर पंक्तियों और स्तंभों को बदला जाता है। यह चार श्रृंखलाओं और तीन श्रेणियों वाला चार्ट सहेजता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एक अक्ष का प्लॉट क्रम उलटें**

एक श्रेणी या मान अक्ष को उलटने के लिए [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) का उपयोग करें। उदाहरण के लिये, एक हॉरिज़ोंटल बार चार्ट कार्य परियोजना चरणों को शीर्ष से नीचे तक उसी क्रम में दिखा सकता है जैसा कि कार्यपत्र में है: योजना, विकास, परीक्षण। अक्ष को उलटने से प्लॉट दिशा बदलती है; यह कार्यपत्र डेटा को क्रमबद्ध या पुनर्व्यवस्थित नहीं करता। तुलना के तौर पर, [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) श्रृंखलाओं और श्रेणियों की भूमिकाओं को अदला‑बदली करता है।

निम्न उदाहरण तीन चरणों और एक श्रृंखला वाला हॉरिज़ोंटल बार चार्ट बनाता है। यह तीन स्लाइडों के साथ एक प्रस्तुति सहेजता है: सामान्य क्रम, उल्टे श्रेणियाँ, और उल्टे मान। प्रत्येक कॉपी समान डेटा सेट का उपयोग करती है, और प्रत्येक कॉपी में केवल एक अक्ष को उलटा जाता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // स्लाइड 2: पहले श्रेणी को शीर्ष पर दिखाएँ।
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // क्षैतिज मान अक्ष को नीचे रखें।
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // स्लाइड 3: केवल क्षैतिज संख्यात्मक स्केल को उलटें।
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अक्ष को उलटने से लंबवत अक्ष को प्लॉट के विपरीत पक्ष पर ले जाया जा सकता है। दूसरे अक्ष के उस बिंदु को नियंत्रित करने के लिए [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) का उपयोग करें जहाँ वह कॉन्फ़िगर किया गया अक्ष पार करता है। स्लाइड 2 में, उल्टे श्रेणी अक्ष पर `aspose.slides.CrossesType.Maximum` के साथ इसे कॉल करने से हॉरिज़ोंटल मान अक्ष नीचे रहता है। विशिष्ट क्रॉस बिंदु के लिए, [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) का उपयोग करें। दिशा बदलते समय क्रॉसिंग सेटिंग्स की जाँच करें, विशेषकर यदि चार्ट में पहले से एक कस्टम क्रॉस बिंदु है। सामान्य प्लॉट दिशा पुनर्स्थापित करने के लिए `setPlotOrderReversed` को `false` के साथ कॉल करें; क्रॉसिंग सेटिंग्स अलग रहती हैं।

| सामान्य क्रम (स्लाइड 1) | उल्टे श्रेणियाँ (स्लाइड 2) | उल्टे मान (स्लाइड 3) |
| --- | --- | --- |
| ![सामान्य श्रेणी और मान अक्ष क्रम वाला हॉरिज़ोंटल बार चार्ट](axis-order-normal.png) | ![ऊपर‑से‑नीचे तक श्रेणियाँ दिखाने वाला हॉरिज़ोंटल बार चार्ट](axis-order-categories-reversed.png) | ![उल्टा मान अक्ष और दाएं शून्य वाला हॉरिज़ोंटल बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियाँ नीचे से ऊपर तक चलती हैं; मान बाएँ से दाएँ बढ़ते हैं। | योजना, विकास, और परीक्षण ऊपर से नीचे तक चलते हैं। मान और कार्यपत्र पंक्ति क्रम अपरिवर्तित रहता है। | श्रेणियों का सामान्य क्रम बना रहता है; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी अक्ष दाएँ शून्य पर पार करता है। |

## **लाइन चार्ट के लिए वर्टिकल अक्ष को निष्क्रिय करें**

वर्टिकल अक्ष को छिपाने के लिए `false` के साथ [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) को कॉल करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और वर्टिकल अक्ष को छिपा कर सहेजता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लाइन चार्ट के लिए हॉरिज़ोंटल अक्ष को निष्क्रिय करें**

हॉरिज़ोंटल अक्ष को छिपाने के लिए `false` के साथ [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) को कॉल करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और हॉरिज़ोंटल अक्ष को छिपा कर सहेजता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चार्ट ग्रिडलाइन दिखाएँ या छुपाएँ**

किसी अक्ष द्वारा कौन‑सी ग्रिडलाइन प्रदर्शित की जाती हैं, यह जानने के लिए [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) और [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) को कॉल करें। माइनर ग्रिडलाइन दिखाने के लिए, [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) का उपयोग कर लाइन भर को ठोस, दृश्यमान रंग में सेट करें। उन्हें छिपाने के लिए भर को [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) पर सेट करें। मेजर ग्रिडलाइन के लिए लाइन भर बदलने हेतु [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) का उपयोग समान तरीका है। भर बदलने से अक्ष की दृश्यता और टिक‑मार्क संरक्षित रहते हैं।

इस क्लस्टर्ड कॉलम चार्ट के वर्टिकल अक्ष में प्रारम्भ में केवल मेजर ग्रिडलाइन दिखाई देती थी। उदाहरण में माइनर ग्रिडलाइन को गहराते नारंगी रंग में दिखाया गया, फिर फिर से छिपा कर प्रस्तुति सहेजी गई। प्रत्येक चरण पर ग्रिडलाइन दृश्यता को प्रिंट किया गया।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| माइनर ग्रिडलाइन सक्षम | माइनर ग्रिडलाइन छिपी |
| --- | --- |
| ![वर्टिकल अक्ष पर मेजर ग्रिडलाइन के बीच नारंगी माइनर ग्रिडलाइन](minor-gridlines-enabled.png) | ![केवल मेजर ग्रिडलाइन दिखने वाला वही कॉलम चार्ट](minor-gridlines-hidden.png) |

## **एक श्रेणी अक्ष बदलें**

[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) का उपयोग करके तिथि या टेक्स्ट श्रेणी अक्ष चुनें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें प्रथम स्लाइड पर प्रथम आकार के रूप में एक चार्ट और श्रेणी कोशिकाएँ संख्यात्मक Excel तिथि मान रखती हैं। यह हॉरिज़ोंटल अक्ष को तिथि अक्ष में बदलता है। `false` के साथ [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) को, `1` के साथ [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) को, और `TimeUnitType.Months` के साथ [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) को कॉल करने से मेजर टिक एक‑माह अंतराल पर रखा जाता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **डेटा से श्रेणी अक्ष प्रकार निर्धारित करें**

श्रेणियों को भरने के बाद [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/) को कॉल करें, फिर चयन की जाँच हेतु [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) को पढ़ें। यह तब उपयोगी है जब वही चार्ट टेक्स्ट लेबल या संख्यात्मक तिथि मान प्राप्त कर सकता है। यह विधि कॉल किए जाने पर प्रकार निर्धारित करती है; यह बाद में डेटा बदलावों पर पुनः‑मूल्यांकन करने वाला स्थायी मोड सक्षम नहीं करती। श्रेणियों को बदलने के बाद इसे पुनः‑कॉल करें।

निम्न उदाहरण टेक्स्ट श्रेणियों वाले चार्ट बनाता है और जब चयनित प्रकार `CategoryAxisType.Text` हो तो `true` प्रिंट करता है। फिर यह श्रेणी कोशिका मानों को तिथियों से बदलता है और फिर से विधि को कॉल कर `CategoryAxisType.Date` होने पर `true` प्रिंट करता है। तिथियों को संख्यात्मक OLE Automation मानों के रूप में संग्रहीत किया जाता है, जो 30 December 1899 से दिनों की संख्या के रूप में गणना होते हैं, न कि तिथि स्ट्रिंग के रूप में। जावास्क्रिप्ट गणना UTC टाइमस्टैम्प का उपयोग कर अंतर को 86 400 000 ms प्रति दिन से विभाजित करती है; माह सूचकांक शून्य‑आधारित होते हैं। प्रत्येक तिथि मान को जावा को डबल के रूप में पास करने के लिये `java.newDouble` का उपयोग करें। [setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) इन मानों के प्रदर्शित होने के तरीके को नियंत्रित करता है; यह टेक्स्ट को संख्यात्मक तिथियों में परिवर्तित नहीं करता। श्रेणी कोशिकाओं के बारे में अधिक जानकारी के लिये देखें [Chart Workbook](/slides/hi/nodejs-java/chart-workbook/)।

डेटा में टेक्स्ट श्रेणियों या संख्यात्मक तिथियों होने पर स्वचालित निर्धारण का प्रयोग करें, जैसा कि इस उदाहरण में दिखाया गया है। सामान्य संख्यात्मक लेबल, मिश्रित श्रेणियाँ, या खाली डेटा के लिये स्पष्ट रूप से [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) को कॉल करके इच्छित अर्थ के अनुकूल बनाएँ। केवल संख्यात्मक मान यह स्थापित नहीं करते कि श्रेणियाँ तिथियों को दर्शाती हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // true

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **श्रेणी अक्ष लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियाँ हों, तो श्रेणियों या डेटा पॉइंट को हटाए बिना दृश्यमान अक्ष लेबलों की संख्या घटाएँ। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) को `false` करके, फिर वांछित श्रेणी अंतराल को [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) को पास करके लेबल अंतराल सेट करें। सामान्य क्रम में टेक्स्ट श्रेणियों के लिये गिनती पहले श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में दिखाए गए लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, … श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, … श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, … श्रेणी 22 |

`3` का अंतराल हर तीसरे लेबल को दिखाता है, तथा दो लेबल छिपे रहते हैं। यह संबंधित स्तंभों को नहीं हटाता। स्वचालित अंतराल उपलब्ध स्थान के आधार पर अंतराल चुनता है; यह आवश्यक नहीं कि हर लेबल दिखे।

टिक‑मार्क के लिये अलग नियंत्रण होते हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) को `false` करके और [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) को उपयोग करके उनका अंतराल सेट करें। उदाहरण के लिये, `1` प्रत्येक श्रेणी अंतराल पर टिक‑मार्क रखता है जबकि लेबल केवल प्रत्येक तीसरी श्रेणी पर दिखते हैं। दृश्यमान शैली के साथ [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) को कॉल करें, ताकि परिणाम देखा जा सके। `true` के साथ किसी भी स्वचालित‑अंतराल सेटर को फिर से कॉल करने से चार्ट को वही अंतराल चुनने की अनुमति मिलती है।

निम्न स्वनिर्दिष्ट उदाहरण 24 श्रेणियों और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइडें सहेजता है: स्वचालित अंतराल, स्वतंत्र लेबल अंतराल के साथ मैन्युअल टिक‑मार्क, और पुनः‑स्वचालित अंतराल। दो कॉपी मूल चार्ट डेटा को बरकरार रखती हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। हॉरिज़ोंटल लेबल टेक्स्ट घनत्व को आसानी से देखाता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // स्लाइड 2: प्रत्येक तीसरा लेबल दिखाएँ, लेकिन प्रत्येक श्रेणी के लिये एक टिक‑मार्क रखें।
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // स्लाइड 3: चार्ट को दोनों अंतराल फिर से चुनने दें।
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**स्वचालित अंतराल (slide 1):** इस रेंडरिंग में प्रत्येक दूसरी श्रेणी लेबल दिखती है और दो पंक्तियों में लिपटी होती है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![सभी 24 स्तंभ दृश्यमान के साथ स्वचालित श्रेणी लेबल अंतराल](category-axis-automatic.png)

**मैन्युअल अंतराल (slide 2):** प्रत्येक तीसरा लेबल एक पंक्ति में दिखता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बरकरार रहते हैं। सभी 24 स्तंभ, जिसमें बिना लेबल वाले भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 ऊपर दिखाए गए स्वचालित रूप को पुनर्स्थापित करता है।

![सभी 24 स्तंभ दृश्यमान के साथ तीन का मैन्युअल श्रेणी लेबल अंतराल](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

टेक्स्ट श्रेणी अक्ष के लिये यह श्रेणी‑गणना अंतराल उपयोग करें, जैसे कॉलम, लाइन, एरिया, या बार चार्ट का श्रेणी‑अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। हॉरिज़ोंटल बार चार्ट में श्रेणी अक्ष वर्टिकल होता है, इसलिए इन सेटिंग्स को [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) द्वारा लौटाए गए अक्ष पर लागू करें। टिक‑मार्क अंतराल उन चार्टों में श्रृंखला‑अक्ष पर भी लागू होता है जिनमें वह मौजूद होता है।

श्रेणी लेबल अंतराल का उपयोग मान अक्ष के संख्यात्मक स्केल को सेट करने के लिये न करें। मान अक्ष पर, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) मानों में अंतर निर्दिष्ट करता है: उदाहरण के लिये `10` का मेजर यूनिट शून्य से शुरू होने पर 0, 10, 20 आदि पर टिक बनाता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों से असंबंधित। स्कैटर और बबल चार्ट मान अक्षों का उपयोग करते हैं, न कि टेक्स्ट श्रेणी अक्ष का। तिथि अक्ष के लिये, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित मेजर यूनिट और स्केल का प्रयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियाँ पहले कार्यपत्र (इंडेक्स `0`) में OLE Automation क्रमिक संख्याओं के रूप में संग्रहीत होती हैं, जो 30 December 1899 से दिनों की संख्या के रूप में गणना की गई हैं। जावास्क्रिप्ट गणना UTC टाइमस्टैम्प का प्रयोग कर अंतर को 86 400 000 ms / day से विभाजित करती है। [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) को `CategoryAxisType.Date` के साथ, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) को `false` के साथ, और `yyyy` को [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) को पास करके श्रेणी लेबल चार्ट सेल फ़ॉर्मेट से स्वतंत्र चार अंकों में वर्ष दिखाते हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करें**

वर्टिकल अक्ष पर `true` के साथ [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) को कॉल करें, शीर्षक टेक्स्ट प्रदान करें, और [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) का उपयोग कर शीर्षक को घुमाएँ। यह कोण डिग्री में मापा जाता है; यह उदाहरण मान‑अक्ष शीर्षक को 90 डिग्री घुमाकर एक कॉलम चार्ट सहेजता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **श्रेणी या मान अक्ष पर अक्ष की स्थिति सेट करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) का उपयोग कर निर्धारित करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच पार करता है या श्रेणी टिक‑मार्क पर। यह सेटिंग केवल श्रेणी अक्षों पर लागू होती है। उदाहरण में इसे कॉलम चार्ट के हॉरिज़ोंटल श्रेणी अक्ष पर `true` कर सेट किया गया है और परिणाम सहेजा गया है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चार्ट मान अक्ष पर डिस्प्ले यूनिट सेट करें**

[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) का उपयोग कर मान अक्ष पर लेबल को स्केल किया जा सकता है, जबकि मूल डेटा अपरिवर्तित रहता है। [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) को `Millions` पर सेट करने पर 60 000 000 को 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके वर्टिकल अक्ष पर मिलियन डिस्प्ले यूनिट लागू करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लॉगरिदमिक मान अक्ष कॉन्फ़िगर करें**

जब सकारात्मक मान कई क्रम (orders) में फैले हों तो लॉगरिदमिक मान अक्ष उपयोगी होता है। उदाहरण के लिये, एक सेवा पाँच अवधि में 10, 100, 1 000, 10 000, और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट एक साथ दिखाई देते हैं। लॉगरिदमिक स्केल उनके सापेक्ष वृद्धि को तुलना‑योग्य बनाता है: समान दूरी समान अनुपात को दर्शाती है, न कि समान अंतर को।

`true` के साथ मान अक्ष पर [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) को कॉल करें और बेस चुनने के लिये [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) का उपयोग करें। यह मौजूदा मानों के प्रदर्शित होने के तरीके को बदलता है; यह डेटा नहीं बदलता या लॉगरिदमिक ट्रेंड‑लाइन नहीं जोड़ता। ट्रेंड‑लाइन डेटा में फिटेड रिलेशनशिप का प्रतिनिधित्व करती है और अलग सुविधा है।

### **मान अक्ष और बेस चुनें**

लाइन या कॉलम चार्ट के लिये, मान अक्ष को [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) द्वारा प्राप्त किया जाता है। हॉरिज़ोंटल बार चार्ट के लिये, इसे [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) से प्राप्त करें। स्कैटर और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मान के लिये हॉरिज़ोंटल अक्ष, Y मान के लिये वर्टिकल अक्ष, या दोनों का उपयोग करें। श्रेणी अक्ष पर लॉगरिदमिक स्केलिंग लागू न करें।

डिफ़ॉल्ट लॉगरिदमिक बेस `10` है। PPTX चार्ट के लिये, `2` से `1000` (समावेशी) के भीतर कोई भी बेस उपयोग किया जा सकता है; अंशात्मक बेस जैसे `2.5` भी समर्थित हैं। बेस `10` के साथ 10, 100, 1 000, 10 000 जैसी क्रमिक पावर समान रूप से अंतरित होती हैं।

### **रेखीय और लॉगरिदमिक स्केलिंग की तुलना करें**

निम्न स्वनिर्दिष्ट उदाहरण पहले स्लाइड पर पाँच अनुरोध गणना के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन कर दूसरे पर बेस‑10 लॉगरिदमिक मान अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा रखती हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // पहली स्लाइड को रैखिक रखें और केवल कॉपी के मान‑अक्ष स्केल को बदलें।
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**रेखीय स्केल (slide 1):** समान ऊर्ध्वाधर दूरी अनुरोध गणना के समान अंतर को दर्शाती है। अधिकतम मान चार्ट को हावी करता है, जिससे छोटे मानों को अलग‑अलग देखना कठिन हो जाता है।

![रेखीय मान अक्ष के साथ पाँच अनुरोध गणना दिखाने वाला PowerPoint लाइन चार्ट](value-axis-linear.png)

**लॉगरिदमिक स्केल (slide 2):** समान ऊर्ध्वाधर दूरी समान अनुपात को दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु बेस‑10 स्केल पर सीधी बढ़ती रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गणना दिखाते हैं।

![बेस‑10 लॉगरिदमिक मान अक्ष के साथ वही पाँच अनुरोध गणना दिखाने वाला PowerPoint चार्ट](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लॉगरिदमिक स्केल केवल शून्य से बड़ा मान दिखा सकता है। इसे सक्षम करने से पहले डेटा जाँचें। यदि शून्य या नकारात्मक मान महत्त्वपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग‑अलग दिखाएँ। यदि विश्लेषण के लिये उन मानों को बाहर निकालना उपयुक्त है, तो कारण स्पष्ट करें। उन्हें छोटे सकारात्मक संख्याओं से चुपचाप बदलने से डेटा का अर्थ बदल जाता है। लॉगरिदमिक अक्ष के लिये मैनुअली कॉन्फ़िगर किया गया न्यूनतम या अधिकतम भी सकारात्मक होना चाहिए।

## **FAQ**

**मैं एक अक्ष को दूसरे के साथ कहाँ पार करता है (axis crossing) इसका मान कैसे सेट करूँ?**

अक्ष पार करने वाले व्यवहार को चुनने के लिये [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) का उपयोग करें। संख्यात्मक क्रॉस मान निर्दिष्ट करने के लिये [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) का उपयोग करें। ये सेटिंग्स आपको अक्ष पार को उपयुक्त बेसलाइन पर ले जाने देती हैं।

**मैं टिक लेबल को अक्ष के सापेक्ष कैसे स्थित करूँ?**

[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) को [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) के साथ कॉल करें: `Low`, `High`, `NextTo`, या `None`। टिक‑मार्क स्वयं को नियंत्रित करने के लिये, [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) या [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) का उपयोग करें; ये लेबल स्थितिकरण से अलग होते हैं।