---
title: एंड्रॉइड पर प्रस्तुतियों में पाई चार्ट को अनुकूलित करें
linktitle: पाई चार्ट
type: docs
url: /hi/androidjava/pie-chart/
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
- Android
- Java
- Aspose.Slides
description: "जावा के साथ Aspose.Slides for Android का उपयोग करके पाई चार्ट बनाना और अनुकूलित करना सीखें, जिसे PowerPoint में निर्यात किया जा सकता है, और कुछ ही सेकंड में आपके डेटा कहानी को बढ़ाता है।"
---
## **परिचय**

यह लेख Aspose.Slides में पाई चार्ट के साथ काम करने के तरीके को समझाता है। यह Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्प को कॉन्फ़िगर करने तथा मानक पाई चार्ट के लिए स्वचालित स्लाइस रंगाकरण को सक्षम करने का तरीका दिखाता है।

उदाहरण व्यावहारिक चार्ट अनुकूलन चरणों पर केंद्रित हैं, जैसे स्लाइड में चार्ट जोड़ना, सीरीज़ और लेबल सेटिंग्स को समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, तथा अद्यतन प्रस्तुति को सहेजना।

## **Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्प**

Aspose.Slides for Android via Java अब Pie of Pie या Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्पों का समर्थन करता है। इस विषय में, हम आपको Aspose.Slides का उपयोग करके उन विकल्पों को निर्दिष्ट करने का तरीका दिखाएंगे। गुण निर्दिष्ट करने के लिए, नीचे बताएँ अनुसार कार्य करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का ऑब्जेक्ट बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट के द्वितीयक प्लॉट विकल्प निर्दिष्ट करें।
1. प्रेजेंटेशन को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने Pie of Pie चार्ट की विभिन्न गुणधर्म सेट किए हैं।

```java
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // स्लाइड पर चार्ट जोड़ें
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // विभिन्न गुणधर्म सेट करें
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // प्रस्तुति को डिस्क पर लिखें
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **स्वचालित पाई चार्ट स्लाइस रंग सेट करें**

Aspose.Slides for Android via Java स्वचालित पाई चार्ट स्लाइड रंग सेट करने के लिए एक सरल API प्रदान करता है। नमूना कोड ऊपर बताए गए गुणों को लागू करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
1. पहले स्लाइड तक पहुंचें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. चार्ट शीर्षक सेट करें।
1. पहली श्रृंखला को मान दिखाने के लिए सेट करें।
1. चार्ट डेटा शीट का इंडेक्स सेट करें।
1. चार्ट डेटा वर्कशीट प्राप्त करें।
1. डिफ़ॉल्ट उत्पन्न श्रृंखला और श्रेणियों को हटाएँ।
1. नई श्रेणियां जोड़ें।
1. नई श्रृंखला जोड़ें।

संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```java
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // चार्ट शीर्षक सेट करना
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // पहली श्रृंखला को मान दिखाने के लिए सेट करें
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // चार्ट डेटा शीट का इंडेक्स सेट करना
    int defaultWorksheetIndex = 0;

    // चार्ट डेटा वर्कशीट प्राप्त करना
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // डिफ़ॉल्ट उत्पन्न श्रृंखला और श्रेणियों को हटाएँ
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // नई श्रेणियां जोड़ना
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // नई श्रृंखला जोड़ना
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // अब श्रृंखला डेटा को भर रहा है
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**'Pie of Pie' और 'Bar of Pie' विविधताएं समर्थित हैं क्या?**

हाँ, लाइब्रेरी [समर्थित](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/) करती है एक द्वितीयक प्लॉट को पाई चार्ट के लिए, जिसमें 'Pie of Pie' और 'Bar of Pie' प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को छवि (जैसे PNG) के रूप में निर्यात कर सकता हूँ?**

हाँ, आप [चार्ट को स्वयं छवि के रूप में निर्यात](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) कर सकते हैं (जैसे PNG) पूरी प्रस्तुति के बिना।