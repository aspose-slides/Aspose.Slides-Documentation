---
title: JavaScript का उपयोग करके प्रस्तुतियों में पाई चार्ट को अनुकूलित करें
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
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ JavaScript में पाई चार्ट बनाना और अनुकूलित करना सीखें, जिन्हें PowerPoint में निर्यात किया जा सकता है, और कुछ ही सेकंड में आपके डेटा स्टोरीटेलिंग को बढ़ावा मिले।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पाई चार्ट्स के साथ कैसे काम करें, यह समझाता है। यह पाई ऑफ़ पाई और बार ऑफ़ पाई चार्ट्स के लिए द्वितीयक प्लॉट विकल्पों को कॉन्फ़िगर करने और मानक पाई चार्ट के लिए स्वचालित स्लाइस रंग सक्षम करने का तरीका दिखाता है।

उदाहरण व्यावहारिक चार्ट अनुकूलन चरणों पर केंद्रित हैं, जैसे स्लाइड में चार्ट जोड़ना, श्रृंखला और लेबल सेटिंग्स को समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, और अपडेटेड प्रस्तुति को सहेजना।

## **पाई ऑफ़ पाई और बार ऑफ़ पाई चार्ट के लिए द्वितीयक प्लॉट विकल्प**

Aspose.Slides for Node.js via Java अब पाई ऑफ़ पाई या बार ऑफ़ पाई चार्ट के लिए द्वितीयक प्लॉट विकल्पों को समर्थन देता है। इस विषय में, हम दिखाएंगे कि Aspose.Slides का उपयोग करके इन विकल्पों को कैसे निर्दिष्ट किया जाए। गुणों को निर्दिष्ट करने के लिए, निम्न करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास ऑब्जेक्ट बनाएं।
2. स्लाइड पर चार्ट जोड़ें।
3. चार्ट के द्वितीयक प्लॉट विकल्प निर्धारित करें।
4. प्रस्तुति को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में हमने पाई ऑफ़ पाई चार्ट के विभिन्न गुण सेट किए हैं।

```javascript
// Presentation क्लास का एक उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    // स्लाइड पर चार्ट जोड़ें
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // विभिन्न गुण सेट करें
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // प्रस्तुति को डिस्क पर लिखें
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **स्वचालित पाई चार्ट स्लाइस रंग सेट करें**

Aspose.Slides for Node.js via Java स्वचालित पाई चार्ट स्लाइस रंग सेट करने के लिए एक सरल API प्रदान करता है। नमूना कोड उपर्युक्त गुणों को लागू करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. पहली स्लाइड तक पहुँचें।
3. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
4. चार्ट शीर्षक सेट करें।
5. पहली श्रृंखला को मान दिखाने के लिए सेट करें।
6. चार्ट डेटा शीट का इंडेक्स सेट करें।
7. चार्ट डेटा वर्कशीट प्राप्त करें।
8. डिफ़ॉल्ट उत्पन्न हुई श्रृंखला और श्रेणियाँ हटाएँ।
9. नई श्रेणियाँ जोड़ें।
10. नई श्रृंखला जोड़ें।

बदलाव किए गए प्रस्तुति को PPTX फ़ाइल में लिखें।

```javascript
// Presentation क्लास का एक उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    // डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // चार्ट शीर्षक सेट करना
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // पहली श्रृंखला को मान दिखाने के लिए सेट करें
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // चार्ट डेटा शीट का इंडेक्स सेट करना
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त करना
    var fact = chart.getChartData().getChartDataWorkbook();
    // डिफ़ॉल्ट उत्पन्न श्रृंखला और श्रेणियाँ हटाएँ
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // नई श्रेणियाँ जोड़ना
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // नई श्रृंखला जोड़ना
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // अब श्रृंखला डेटा भर रहा है
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**क्या 'Pie of Pie' और 'Bar of Pie' वैरिएंट समर्थित हैं?**

हाँ, लाइब्रेरी [समर्थन करती है](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/) पाई चार्ट्स के लिए द्वितीयक प्लॉट, जिसमें 'Pie of Pie' और 'Bar of Pie' प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को एक छवि (उदाहरण के लिए, PNG) के रूप में निर्यात कर सकता हूँ?**

हाँ, आप पूरी प्रस्तुति के बिना केवल [चार्ट को स्वयं छवि रूप में निर्यात कर सकते हैं](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getImage) (जैसे PNG)।