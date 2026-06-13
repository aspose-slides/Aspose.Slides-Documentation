---
title: जावास्क्रिप्ट में प्रस्तुतियों के लिए चार्ट गणनाओं का अनुकूलन
linktitle: चार्ट गणनाएं
type: docs
weight: 50
url: /hi/nodejs-java/chart-calculations/
keywords:
- चार्ट गणनाएँ
- चार्ट तत्व
- तत्व स्थिति
- वास्तविक स्थिति
- संतान तत्व
- पैरेंट तत्व
- चार्ट मान
- वास्तविक मान
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में PPT और PPTX के लिए चार्ट गणनाओं, डेटा अपडेट और सटीकता नियंत्रण को समझें, साथ ही व्यावहारिक जावास्क्रिप्ट कोड उदाहरणों के साथ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुतियों में चार्ट गणनाओं और लेआउट डेटा के साथ काम करने के लिए API प्रदान करता है। यह लेख दिखाता है कि चार्ट तत्वों के वास्तविक मान, जिसमें तत्वों की वास्तविक स्थिति और आकार तथा चार्ट अक्षों के वास्तविक मान शामिल हैं, कैसे प्राप्त करें। यह यह भी समझाता है कि ये मान चार्ट लेआउट सत्यापन के बाद भरते हैं।

इसके अतिरिक्त, यह लेख पैरेंट चार्ट तत्वों की वास्तविक स्थिति कैसे प्राप्त करें और शीर्षक, अक्ष, लेजेंड और ग्रिड लाइनों जैसे चार्ट घटकों को कैसे छिपाएँ, यह प्रदर्शित करता है। ये उदाहरण आपको प्रोग्रामmatically PowerPoint प्रस्तुतियों में चार्ट लेआउट जानकारी का निरीक्षण करने और चार्ट तत्वों की दृश्यता को नियंत्रित करने में मदद करेंगे।

## **चार्ट तत्वों के वास्तविक मानों की गणना**

Aspose.Slides for Node.js via Java इन गुणों को प्राप्त करने के लिए सरल API प्रदान करता है। [Axis](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Axis) वर्ग की गुणों से अक्ष चार्ट तत्व की वास्तविक स्थिति की जानकारी मिलती है ([Axis.getActualMaxValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--))। वास्तविक मानों से गुणों को भरने के लिए पहले [Chart.validateChartLayout()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Chart#validateChartLayout--) मेथड को कॉल करना आवश्यक है।

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **पैरेंट चार्ट तत्वों की वास्तविक स्थिति की गणना**

Aspose.Slides for Node.js via Java इन गुणों को प्राप्त करने के लिए सरल API प्रदान करता है। `ActualLayout` वर्ग की गुणों से पैरेंट चार्ट तत्व की वास्तविक स्थिति की जानकारी मिलती है `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`। वास्तविक मानों से गुणों को भरने के लिए पहले [Chart.validateChartLayout()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Chart#validateChartLayout--) मेथड को कॉल करना आवश्यक है।

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चार्ट से जानकारी छिपाएँ**

यह विषय आपको चार्ट से जानकारी छिपाने के तरीके समझाता है। Aspose.Slides for Node.js via Java का उपयोग करके आप चार्ट से **शीर्षक, लंबवत अक्ष, क्षैतिज अक्ष** और **ग्रिड लाइन्स** को छिपा सकते हैं। नीचे दिया गया कोड उदाहरण इन गुणों के उपयोग को दर्शाता है।

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // चार्ट शीर्षक छिपाना
    chart.setTitle(false);
    // /मान अक्ष छिपाना
    chart.getAxes().getVerticalAxis().setVisible(false);
    // श्रेणी अक्ष दृश्यता
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // लीजेंड छिपाना
    chart.setLegend(false);
    // मुख्य ग्रिड लाइनों को छिपाना
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // श्रृंखला रेखा का रंग सेट करना
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी Excel वर्कबुक डेटा स्रोत के रूप में काम करता है, और उसका पुनर्गणना पर क्या प्रभाव पड़ता है?**

हाँ। एक चार्ट बाहरी वर्कबुक का संदर्भ दे सकता है: जब आप बाहरी स्रोत को कनेक्ट या रिफ्रेश करते हैं, तो सूत्र और मान उस वर्कबुक से लिए जाते हैं, और चार्ट खुलने/संपादन के दौरान अपडेट को प्रतिबिंबित करता है। API आपको बाहरी वर्कबुक का पथ निर्दिष्ट करने और लिंक्ड डेटा को प्रबंधित करने की सुविधा देता है।

**क्या मैं बिना स्वयं रिग्रेशन लागू किए ट्रेंडलाइन की गणना और प्रदर्शन कर सकता हूँ?**

हाँ। [Trendlines](/slides/hi/nodejs-java/trend-line/) (रेखीय, घातांक और अन्य) Aspose.Slides द्वारा जोड़ी और अपडेट की जाती हैं; उनके पैरामीटर श्रृंखला डेटा से स्वचालित रूप से पुनर्गणना होते हैं, इसलिए आपको अपनी स्वयं की गणनाएँ लागू करने की आवश्यकता नहीं है।

**यदि प्रस्तुति में कई चार्ट हैं जिनमें बाहरी लिंक हैं, तो क्या मैं नियंत्रित कर सकता हूँ कि प्रत्येक चार्ट कौन सा वर्कबुक उपयोग करे?**

हाँ। प्रत्येक चार्ट अपने स्वयं के [external workbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) की ओर संकेत कर सकता है, या आप प्रत्येक चार्ट के लिए अन्य चार्टों से स्वतंत्र रूप से बाहरी वर्कबुक बनाकर/बदलकर उपयोग कर सकते हैं।