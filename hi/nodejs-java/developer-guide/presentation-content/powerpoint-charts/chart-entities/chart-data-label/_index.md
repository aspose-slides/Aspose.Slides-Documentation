---
title: JavaScript का उपयोग करके प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/nodejs-java/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ना और स्वरूपित करना सीखें, ताकि स्लाइड अधिक आकर्षक बनें."
---
## **परिचय**

चार्ट पर डेटा लेबल्स चार्ट डेटा श्रृंखला या व्यक्तिगत डेटा बिंदुओं के बारे में विवरण दिखाते हैं। वे पाठकों को डेटा श्रृंखला को जल्दी पहचानने में मदद करते हैं और चार्ट को समझना आसान बनाते हैं।

## **चार्ट डेटा लेबल्स में डेटा की सटीकता सेट करें**

यह JavaScript कोड दिखाता है कि चार्ट डेटा लेबल में डेटा की सटीकता कैसे सेट की जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **लेबल्स के रूप में प्रतिशत प्रदर्शित करें**

Aspose.Slides for Node.js via Java आपको प्रदर्शित चार्ट्स पर प्रतिशत लेबल सेट करने की अनुमति देता है। यह JavaScript कोड इस संचालन को प्रदर्शित करता है:

```javascript
// Presentation क्लास का एक इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // चार्ट वाले प्रस्तुतीकरण को सहेजता है
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चार्ट डेटा लेबल्स के साथ प्रतिशत चिन्ह सेट करें**

यह JavaScript कोड दिखाता है कि चार्ट डेटा लेबल के लिए प्रतिशत चिन्ह कैसे सेट किया जाए:

```javascript
// Presentation क्लास का एक इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation();
try {
    // इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करता है
    var slide = pres.getSlides().get_Item(0);
    // स्लाइड पर PercentsStackedColumn चार्ट बनाता है
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // NumberFormatLinkedToSource को false सेट करता है
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    var workbook = chart.getChartData().getChartDataWorkbook();
    // नए श्रृंखला (सीरीज़) जोड़ता है
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // सीरीज़ का भरने (फ़िल) रंग सेट करता है
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // LabelFormat गुण सेट करता है
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // नया श्रृंखला जोड़ता है
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // फ़िल प्रकार और रंग सेट करता है
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्ष से लेबल की दूरी सेट करें**

यह JavaScript कोड दिखाता है कि जब आप अक्षों से निर्मित चार्ट के साथ काम कर रहे हों तो वर्ग (category) अक्ष से लेबल की दूरी कैसे सेट की जाए:

```javascript
// Presentation क्लास का एक इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation();
try {
    // स्लाइड का रेफ़रेंस प्राप्त करता है
    var sld = pres.getSlides().get_Item(0);
    // स्लाइड पर चार्ट बनाता है
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // अक्ष से लेबल दूरी सेट करता है
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **लेबल स्थान समायोजित करें**

जब आप ऐसा चार्ट बनाते हैं जो किसी भी अक्ष पर निर्भर नहीं करता, जैसे पाई चार्ट, तो चार्ट के डेटा लेबल्स किनारे के बहुत करीब हो सकते हैं। ऐसी स्थिति में आपको डेटा लेबल का स्थान समायोजित करना पड़ता है ताकि लीडर लाइन्स स्पष्ट रूप से दिखें।

यह JavaScript कोड पाई चार्ट पर लेबल स्थान को समायोजित करने का तरीका दिखाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**घने चार्ट्स में लेबल्स के ओवरलैप को कैसे रोकूँ?**

ऑटोमैटिक लेबल प्लेसमेंट, लीडर लाइन्स, और फ़ॉन्ट साइज को कम करने को मिलाएँ; यदि आवश्यक हो तो कुछ फ़ील्ड्स (जैसे वर्ग) को छुपाएँ या केवल चरम/मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**शून्य, नकारात्मक या खाली मानों के लिए लेबल्स को कैसे अक्षम करूँ?**

लेबल्स सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और 0, नकारात्मक मानों या अनुपलब्ध मानों के लिए प्रदर्शन को बंद करने के नियम निर्धारित करें।

**PDF/छवियों में एक्सपोर्ट करने पर लेबल शैली को सुसंगत कैसे रखें?**

फ़ॉन्ट (परिवार, आकार) को स्पष्ट रूप से सेट करें और रेंडरिंग पक्ष पर फ़ॉन्ट उपलब्ध हो यह सुनिश्चित करें ताकि फ़ॉलबैक न हो।