---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट धुरियों को कस्टमाइज़ करें
linktitle: चार्ट धुरी
type: docs
url: /hi/nodejs-java/chart-axis/
keywords:
- चार्ट धुरी
- ऊर्ध्वाधर धुरी
- क्षैतिज धुरी
- धुरी को अनुकूलित करें
- धुरी को बदलें
- धुरी का प्रबंधन करें
- धुरी गुण
- अधिकतम मान
- न्यूनतम मान
- धुरी रेखा
- तिथि स्वरूप
- धुरी शीर्षक
- धुरी स्थिति
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट को Aspose.Slides for Node.js के साथ जावा के माध्यम से उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट धुरियों को कस्टमाइज़ करने का तरीका जानें।"
---
## **आवलोकन**

यह लेख Aspose.Slides for Node.js via Java का उपयोग करके चार्ट धुरी को अनुकूलित करने के तरीकों को समझाता है। इसमें गणना किए गए धुरी मान, चार्ट पंक्तियों और स्तंभों को स्विच करना, धुरी की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियां और स्वरूपण, शीर्षक का घुमाव, धुरी की स्थिति, प्रदर्शनी इकाइयाँ, और लघुगणकीय स्केलिंग शामिल हैं।

## **चार्ट्स में ऊर्ध्वाधर धुरी पर अधिकतम मान प्राप्त करें**

डिफ़ॉल्ट डेटा के साथ एक [प्रस्तुति](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) बनाएँ और एक एरिया चार्ट जोड़ें। गणना किए गए धुरी मान पढ़ने से पहले [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) को कॉल करें ताकि चार्ट लेआउट अद्यतित हो।

[getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) और [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) को धुरी की सीमा के लिए पढ़ें, तथा [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) और [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) को टिक अंतराल के लिए पढ़ें। [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) और [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि धुरियों के लिए प्रासंगिक होते हैं। उदाहरण इन मानों को स्थानीय वेरिएबल में संग्रहीत करता है और चार्ट को सहेजता है।

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

## **धुरियों के बीच डेटा अदल‑बदल करें**

[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) का उपयोग करके चार्ट डेटा में श्रृंखलाओं (series) और श्रेणियों (categories) की भूमिकाओं को बदलें। प्रत्येक पूर्व श्रेणी अब एक श्रृंखला बन जाएगी, और प्रत्येक पूर्व श्रृंखला अब एक श्रेणी बन जाएगी। यह डेटा के समूह बनावट को बदलता है; यह क्षैतिज और ऊर्ध्वाधर धुरियों को नहीं बदलता। उदाहरण [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करता है, जिसमें हेडर पंक्ति और श्रेणी स्तंभ दोनों शामिल हैं, फिर पंक्तियों और स्तंभों को स्विच करता है। यह चार श्रृंखला और तीन श्रेणियों वाला चार्ट सहेजता है।

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

## **धुरी की प्लॉट क्रम को उलटें**

[setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) का उपयोग करके किसी श्रेणी या मान धुरी को उलटा करें। उदाहरण के लिए, एक क्षैतिज बार चार्ट प्रोजेक्ट चरणों को वर्कशीट के समान क्रम में ऊपर से नीचे दिखा सकता है: योजना, विकास, परीक्षण। धुरी को उलटने से प्लॉट दिशा बदलती है; यह वर्कबुक डेटा को क्रमबद्ध या पुनर्व्यवस्थित नहीं करता। तुलना में, [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) श्रृंखलाओं और श्रेणियों की भूमिकाओं को अदल‑बदल करता है।

निम्नलिखित उदाहरण तीन चरणों वाले एक क्षैतिज बार चार्ट बनाता है और तीन स्लाइड्स के साथ प्रस्तुति सहेजता है: सामान्य क्रम, उलटी श्रेणियां, और उलटे मान। प्रत्येक कॉपी एक ही डेटासेट का उपयोग करती है, और प्रत्येक कॉपी में केवल एक धुरी उलटी होती है।

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

    // स्लाइड 2: पहली श्रेणी को ऊपर दिखाएँ।
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // क्षैतिज मान धुरी को नीचे रखें।
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

धुरी को उलटने से लम्बवत धुरी को प्लॉट के विपरीत पक्ष पर ले जाया जा सकता है। [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) निर्धारित करता है कि अन्य धुरी किस बिंदु पर वर्तमान धुरी को पार करती है। स्लाइड 2 में, `aspose.slides.CrossesType.Maximum` के साथ इसे कॉल करने पर उलटी श्रेणी धुरी पर क्षैतिज मान धुरी नीचे रहती है। विशिष्ट क्रॉसिंग बिंदु के लिए, [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) का उपयोग करें। दिशा बदलते समय क्रॉसिंग सेटिंग्स की जाँच करें, विशेषकर यदि चार्ट में पहले से एक अनुकूलित क्रॉसिंग बिंदु मौजूद है। सामान्य प्लॉट दिशा पुनः स्थापित करने के लिए `setPlotOrderReversed` को `false` के साथ कॉल करें; क्रॉसिंग सेटिंग्स अलग रहती हैं।

| सामान्य क्रम (स्लाइड 1) | उलटी श्रेणियां (स्लाइड 2) | उलटे मान (स्लाइड 3) |
| --- | --- | --- |
| ![सामान्य श्रेणी और मान धुरी क्रम वाला क्षैतिज बार चार्ट](axis-order-normal.png) | ![ऊपर से नीचे प्रदर्शित श्रेणियों वाला क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![दायें शून्य पर क्रॉस करने वाली उल्टी मान धुरी वाला क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियां नीचे से ऊपर तक चलती हैं; मान बाएँ से दाएँ बढ़ते हैं। | योजना, विकास, और परीक्षण ऊपर से नीचे चलते हैं। मान और वर्कबुक पंक्ति क्रम अपरिवर्तित रहते हैं। | श्रेणियां अपने सामान्य क्रम को बनाए रखती हैं; मान दायें से बाएँ बढ़ते हैं। श्रेणी धुरी दायें शून्य पर क्रॉस करती है। |

## **रेखा चार्ट्स के लिए ऊर्ध्वाधर धुरी निष्क्रिय करें**

ऊर्ध्वाधर धुरी को छिपाने के लिए `false` के साथ [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) को कॉल करें। उदाहरण डिफ़ॉल्ट डेटा वाले एक रेखा चार्ट को बनाता है और ऊर्ध्वाधर धुरी को छिपाकर सहेजता है।

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

## **रेखा चार्ट्स के लिए क्षैतिज धुरी निष्क्रिय करें**

क्षैतिज धुरी को छिपाने के लिए `false` के साथ [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) को कॉल करें। उदाहरण डिफ़ॉल्ट डेटा वाले एक रेखा चार्ट को बनाता है और क्षैतिज धुरी को छिपाकर सहेजता है।

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

## **श्रेणी धुरी बदलें**

[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) का उपयोग करके तिथि या पाठ श्रेणी धुरी चुनें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें पहला स्लाइड का पहला आकार एक चार्ट है और श्रेणी कोशिकाएं संख्यात्मक Excel तिथि मान रखती हैं। यह क्षैतिज धुरी को तिथि धुरी में बदल देता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) को `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) को `1`, और [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) को `TimeUnitType.Months` के साथ कॉल करने से प्रमुख टिक एक‑माह अंतराल पर रखी जाती हैं।

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

## **श्रेणी धुरी लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियां हों, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दृश्यमान धुरी लेबलों की संख्या घटाएँ। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) को `false` के साथ कॉल करें, फिर इच्छित श्रेणी अंतराल को [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) को पास करें। सामान्य क्रम में पाठ श्रेणियों के लिए, गणना प्रथम श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

अंतराल `3` हर तीसरे लेबल को दिखाता है, बीच में दो लेबल छिपे रहते हैं। यह संबंधित स्तम्भों को नहीं हटाता। स्वचालित अंतराल उपलब्ध स्थान के आधार पर तय होता है; यह आवश्यक नहीं कि प्रत्येक लेबल दिखे।

टिक मार्क के लिए अलग नियंत्रण होते हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) को `false` के साथ कॉल करें और [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) का उपयोग करके उनका अंतराल निर्धारित करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर एक टिक रखता है जबकि लेबल केवल हर तीसरी श्रेणी पर दिखते हैं। दृश्यमान शैली के साथ [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) को कॉल करें ताकि परिणाम देखा जा सके। फिर किसी भी स्वचालित‑स्पेसिंग सेटर को `true` करने से चार्ट फिर से वही अंतराल चुन लेगा।

निम्नलिखित स्वतंत्र उदाहरण 24 श्रेणियां और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड्स सहेजता है: स्वचालित स्पेसिंग, स्वतंत्र लेबल स्पेसिंग के साथ मैनुअल टिक मार्क, और पुनः स्वचालित स्पेसिंग। दोनों कॉपी मूल चार्ट डेटा को बरकरार रखती हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व अंतर को स्पष्ट रूप से दिखाता है।

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

    // स्लाइड 2: हर तीसरा लेबल दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए एक टिक मार्क रखें।
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // स्लाइड 3: चार्ट को फिर से दोनों अंतराल चुनने दें।
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**स्वचालित स्पेसिंग (स्लाइड 1):** इस रेंडरिंग में प्रत्येक दूसरी श्रेणी लेबल प्रदर्शित होता है और दो पंक्तियों में रैप होता है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![सभी 24 स्तम्भ दृश्यमान वाले स्वचालित श्रेणी लेबल स्पेसिंग](category-axis-automatic.png)

**मैनुअल स्पेसिंग (स्लाइड 2):** प्रत्येक तीसरा लेबल एक पंक्ति में दिखता है, जबकि टिक मार्क प्रत्येक श्रेणी अंतराल पर बना रहता है। सभी 24 स्तम्भ, जिनमें बिना लेबल वाले भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 स्वचालित रूप से दिखाए गए रूप को पुनर्स्थापित करता है।

![सभी 24 स्तम्भ दृश्यमान वाले तीन के मैनुअल श्रेणी लेबल अंतराल](category-axis-manual.png)

### **सही धुरी और अंतराल चुनें**

पाठ श्रेणी धुरी के लिए इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे कॉलम, रेखा, एरिया या बार चार्ट की श्रेणी धुरी। कॉलम चार्ट में यह क्षैतिज धुरी होती है। क्षैतिज बार चार्ट में श्रेणी धुरी लम्बवत होती है, इसलिए इसे [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) द्वारा लौटाई गई धुरी पर लागू करें। टिक‑मार्क अंतराल उन चार्ट्स में श्रृंखला धुरी पर भी लागू होता है जिनमें वह मौजूद होती है।

मान धुरी की संख्यात्मक स्केल सेट करने के लिए श्रेणी लेबल अंतराल का उपयोग न करें। मान धुरी पर, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिए, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब धुरी शून्य से शुरू होती है। श्रेणी लेबल अंतराल `3` केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट पाठ श्रेणी धुरी की बजाय मान धुरियों का उपयोग करते हैं। तिथि धुरी के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयों और स्केले का उपयोग करें।

## **श्रेणी धुरी मानों के लिए तिथि स्वरूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियां पहले कार्यपत्रक (सूचकांक `0`) में OLE Automation क्रमिक संख्याओं के रूप में संग्रहीत होती हैं, जो 30 December 1899 से दिन गिनती पर आधारित हैं। जावास्क्रिप्ट गणना UTC टाइमस्टैम्प का उपयोग करती है और अंतर को 86 400 000 मिलीसेकंड (एक दिन) से विभाजित करती है। `CategoryAxisType.Date` के साथ [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) को कॉल करें, फिर `false` के साथ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) को कॉल करें, और `yyyy` को [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) में पास करें ताकि श्रेणी लेबल सेल स्वरूप से स्वतंत्र रूप से चार-अंकीय वर्ष दिखाएँ।

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

## **चार्ट धुरी शीर्षक के लिए घुमाव कोण सेट करें**

ऊर्ध्वाधर धुरी पर `true` के साथ [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) को कॉल करें, शीर्षक पाठ प्रदान करें, और शीर्षक को घुमाने के लिए [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) का उपयोग करें। कोण डिग्री में मापा जाता है; यह उदाहरण 90 डिग्री पर मूल्य‑धुरी शीर्षक घुमा हुआ एक कॉलम चार्ट सहेजता है।

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

## **श्रेणी या मान धुरी पर धुरी स्थिति सेट करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) का उपयोग करके निर्धारित करें कि मान धुरी श्रेणी धुरी को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर पार करे। यह सेटिंग केवल श्रेणी धुरियों पर लागू होती है। उदाहरण इसे कॉलम चार्ट की क्षैतिज श्रेणी धुरी पर `true` सेट करता है और परिणाम सहेजता है।

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

## **चार्ट मान धुरी पर प्रदर्शनी इकाई सेट करें**

[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) का उपयोग करके मान धुरी पर लेबल को स्केल करें बिना मूल डेटा बदले। जब [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) `Millions` पर सेट हो, तो 60 000 000 मान को 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसकी ऊर्ध्वाधर धुरी पर मिलियन प्रदर्शनी इकाई लागू करता है।

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

## **लघुगणकीय मान धुरी कॉन्फ़िगर करें**

लघुगणकीय मान धुरी तब उपयोगी होती है जब सकारात्मक मान कई क्रम magnitude में फैले हों। उदाहरण के लिए, एक सेवा पाँच अवधियों में क्रमशः 10, 100, 1 000, 10 000 और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट एक साथ दिखाई देते हैं। लघुगणकीय स्केल अनुपात को समान दूरी पर समान बनाता है, जिससे वृद्धि की तुलना आसान हो जाती है।

मान धुरी पर `true` के साथ [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) को कॉल करें और आधार चुनने के लिए [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) का उपयोग करें। यह मौजूदा मानों के प्रदर्शित होने का तरीका बदलता है; यह डेटा या कोई लघुगणकीय ट्रेंड‑लाइन नहीं जोड़ता। ट्रेंड‑लाइन डेटा में फिटेड रिलेशनशिप का प्रतिनिधित्व करती है और एक अलग सुविधा है।

### **मान धुरी और आधार चुनें**

रेखा या कॉलम चार्ट के लिए, मान धुरी को [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) द्वारा प्राप्त किया जाता है। क्षैतिज बार चार्ट के लिए, इसे [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) द्वारा प्राप्त किया जाता है। स्कैटर और बबल चार्ट में दो मान धुरियां होती हैं, इसलिए X मानों के लिए क्षैतिज धुरी, Y मानों के लिए ऊर्ध्वाधर धुरी, या दोनों चुनें। श्रेणी धुरी पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय आधार `10` है। PPTX चार्ट्स में, आधार `2` से `1000` तक (समावेशी) हो सकता है; अंशीय आधार जैसे `2.5` भी समर्थित हैं। आधार `10` पर क्रमिक शक्ति जैसे 10, 100, 1 000, 10 000 समान अंतराल में होते हैं।

### **रैखिक और लघुगणकीय स्केल की तुलना**

निम्नलिखित स्वतंत्र उदाहरण पाँच अनुरोध गणनाओं के साथ एक रेखा चार्ट बनाता है, फिर उस स्लाइड को क्लोन करके दूसरी स्लाइड पर आधार‑10 लघुगणकीय मान धुरी सक्षम करता है। दोनों स्लाइड्स समान डेटा बरकरार रखती हैं।

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

    // पहले स्लाइड को रैखिक रखें और केवल कॉपी की मान-धुरी स्केल बदलें।
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

**रैखिक स्केल (स्लाइड 1):** समान ऊर्ध्वाधर दूरी समान अनुरोध गणना अंतर को दर्शाती है। सबसे बड़ा मान चार्ट को प्रमुखता देता है, जिससे छोटे मान स्पष्ट नहीं होते।

![रैखिक मान धुरी पर पाँच अनुरोध गणनाओं वाला रेखा चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊर्ध्वाधर दूरी समान अनुपात को दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु आधार‑10 स्केल पर एक सीधी ऊपर की ओर रेखा बनाते हैं। धुरी लेबल अभी भी मूल अनुरोध गणना दिखाते हैं।

![आधार‑10 लघुगणकीय मान धुरी पर वही पाँच अनुरोध गणनाएँ](value-axis-logarithmic.png)

### **शून्य और ऋणात्मक मान संभालें**

लघुगणकीय स्केल केवल शुद्ध सकारात्मक मान दिखा सकती है। इसे सक्षम करने से पहले डेटा जाँचें। यदि शून्य या ऋणात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि विश्लेषण के लिए उन मानों को बाहर निकालना उपयुक्त है, तो हटाने का कारण बताएँ। उन्हें छोटे सकारात्मक संख्याओं से चुपके से बदलना डेटा की अर्थ को बदल देगा। लघुगणकीय धुरी के लिए मैन्युअल रूप से सेट किया गया किसी भी न्यूनतम या अधिकतम मान भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं किसी धुरी को दूसरी धुरी के पार करने के बिंदु (धुरी क्रॉसिंग) को कैसे सेट करूँ?**

[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) का उपयोग करके क्रॉसिंग व्यवहार चुनें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिए [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) का उपयोग करें। ये सेटिंग्स आपको धुरी क्रॉसिंग को उपयुक्त बेसलाइन पर ले जाने की सुविधा देती हैं।

**मैं टिक लेबल को धुरी के सापेक्ष कैसे स्थित करूँ?**

[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) को [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) के साथ उपयोग करें: `Low`, `High`, `NextTo` या `None`। टिक मार्क स्वयं को नियंत्रित करने के लिए, [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) या [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) का उपयोग करें; ये लेबल स्थितिकरण से अलग हैं।