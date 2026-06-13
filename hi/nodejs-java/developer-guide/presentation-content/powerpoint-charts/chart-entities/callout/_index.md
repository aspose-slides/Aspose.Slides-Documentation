---
title: जावास्क्रिप्ट का उपयोग करके प्रेजेंटेशन चार्ट्स में कॉलआउट प्रबंधित करें
linktitle: कॉलआउट
type: docs
url: /hi/nodejs-java/callout/
keywords:
- चार्ट कॉलआउट
- कॉलआउट का उपयोग
- डेटा लेबल
- लेबल फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java में कॉलआउट बनाएं और शैलीबद्ध करें, संक्षिप्त कोड उदाहरणों के साथ, PPT और PPTX के साथ संगत, ताकि प्रेजेंटेशन कार्यप्रवाह को स्वचालित किया जा सके।"
---
## **समीक्षा**

यह लेख Aspose.Slides में चार्ट डेटा लेबल के लिए कॉलआउट के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि `setShowLabelAsDataCallout` मेथड का उपयोग करके लेबल को कॉलआउट के रूप में कैसे प्रदर्शित किया जाए, डोनट चार्ट के लिए कॉलआउट‑संबंधी लेबल सेटिंग्स को कैसे कॉन्फ़िगर किया जाए, और यह नोट करता है कि प्रस्तुतीकरण को PDF, HTML5, SVG और रास्टर इमेज फ़ॉर्मैट में निर्यात करने पर कॉलआउट और उनका रूप संरक्षित रहता है।

## **कॉलआउट का उपयोग**

नए मेथड [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) और [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) को [DataLabelFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabelformat) क्लास में जोड़ा गया है। ये मेथड निर्धारित करते हैं कि निर्दिष्ट चार्ट का डेटा लेबल कॉलआउट के रूप में या डेटा लेबल के रूप में प्रदर्शित होगा।

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 500, 400);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    pres.save("DisplayCharts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **डोनट चार्ट के लिए कॉलआउट सेट करें**

Aspose.Slides for Node.js via Java डोनट चार्ट के लिए श्रृंखला डेटा लेबल कॉलआउट आकार सेट करने का समर्थन प्रदान करता है। नीचे एक नमूना उदाहरण दिया गया है।

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Doughnut, 10, 10, 500, 500, false);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    var seriesIndex = 0;
    while (seriesIndex < 15) {
        var series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize(20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    var categoryIndex = 0;
    while (categoryIndex < 15) {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        var i = 0;
        while (i < chart.getChartData().getSeries().size()) {
            var iCS = chart.getChartData().getSeries().get_Item(i);
            var dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
            if (i == (chart.getChartData().getSeries().size() - 1)) {
                var lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new aspose.slides.FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX(lbl.getX() + 0.5);
                lbl.setY(lbl.getY() + 0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**क्या प्रस्तुतीकरण को PDF, HTML5, SVG या छवियों में परिवर्तित करने पर कॉलआउट संरक्षित रहते हैं?**

हाँ। कॉलआउट चार्ट रेंडरिंग का हिस्सा होते हैं, इसलिए जब आप इसे [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/hi/nodejs-java/export-to-html5/), [SVG](/slides/hi/nodejs-java/render-a-slide-as-an-svg-image/), या [रास्टर छवियों](/slides/hi/nodejs-java/convert-powerpoint-to-png/) में निर्यात करते हैं, तो वे स्लाइड के फ़ॉर्मेटिंग के साथ संरक्षित रहते हैं।

**क्या कस्टम फ़ॉन्ट कॉलआउट में काम करते हैं, और क्या उनका रूप निर्यात पर संरक्षित रहता है?**

हाँ। Aspose.Slides प्रस्तुतीकरण में [फ़ॉन्ट एम्बेडिंग](/slides/hi/nodejs-java/embedded-font/) का समर्थन करता है और निर्यात जैसे [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/) के दौरान फ़ॉन्ट एम्बेडिंग को नियंत्रित करता है, जिससे कॉलआउट विभिन्न सिस्टमों पर समान दिखते हैं।