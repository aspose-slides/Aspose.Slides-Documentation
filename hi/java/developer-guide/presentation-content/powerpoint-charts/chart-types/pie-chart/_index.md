---
title: जावा का उपयोग करके प्रस्तुतियों में पाई चार्ट को अनुकूलित करें
linktitle: पाई चार्ट
type: docs
url: /hi/java/pie-chart/
keywords:
- पाई चार्ट
- चार्ट प्रबंधन
- चार्ट अनुकूलन
- चार्ट विकल्प
- चार्ट सेटिंग्स
- प्लॉट विकल्प
- स्लाइस रंग
- पावरपॉइंट
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ जावा में पाई चार्ट बनाना और अनुकूलित करना सीखें, जिसे पावरपॉइंट में निर्यात किया जा सकता है, और कुछ ही सेकंड में आपके डेटा कहानी कहने को बढ़ाता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पाई चार्ट के साथ काम करने के तरीके को समझाता है। यह Pie of Pie और Bar of Pie चार्ट्स के लिए द्वितीयक प्लॉट विकल्पों को कॉन्फ़िगर करने और एक मानक पाई चार्ट के लिए स्वचालित स्लाइस रंगिंग सक्षम करने का तरीका दिखाता है।

उदाहरण व्यावहारिक चार्ट अनुकूलन चरणों पर केंद्रित हैं, जैसे स्लाइड में चार्ट जोड़ना, सीरीज़ और लेबल सेटिंग्स को समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, और अद्यतन प्रस्तुति को सहेजना।

## **Pie of Pie और Bar of Pie चार्ट्स के लिए द्वितीयक प्लॉट विकल्प**

अब Aspose.Slides for Java Pie of Pie या Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्पों को समर्थन देता है। इस विषय में, हम आपको Aspose.Slides का उपयोग करके इन विकल्पों को निर्दिष्ट करने का तरीका दिखाएंगे। गुणों को निर्दिष्ट करने के लिए, यह करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास ऑब्जेक्ट को इंस्टेंटिएट करें।
2. स्लाइड पर चार्ट जोड़ें।
3. चार्ट के द्वितीयक प्लॉट विकल्प निर्दिष्ट करें।
4. प्रेजेंटेशन को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने Pie of Pie चार्ट की विभिन्न गुण सेट किए हैं।

```java
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // स्लाइड पर चार्ट जोड़ें
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // विभिन्न गुण सेट करें
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // प्रेजेंटेशन को डिस्क पर लिखें
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **स्वचालित पाई चार्ट स्लाइस रंग सेट करें**

Aspose.Slides for Java स्वचालित पाई चार्ट स्लाइड रंग सेट करने के लिए एक सरल API प्रदान करता है। नमूना कोड उपर्युक्त गुणों को लागू करता है।

1. Presentation क्लास की एक इंस्टेंस बनाएं।
2. पहली स्लाइड तक पहुंचें।
3. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
4. चार्ट शीर्षक सेट करें।
5. पहली सीरीज़ को मान दिखाने के लिए सेट करें।
6. चार्ट डेटा शीट का इंडेक्स सेट करें।
7. चार्ट डेटा वर्कशीट प्राप्त कर रहे हैं।
8. डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियों को हटा दें।
9. नई श्रेणियां जोड़ें।
10. नई सीरीज़ जोड़ें।

परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

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

    // पहली सीरीज़ को मान दिखाने के लिए सेट करें
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // चार्ट डेटा शीट का इंडेक्स सेट करना
    int defaultWorksheetIndex = 0;

    // चार्ट डेटा वर्कशीट प्राप्त कर रहे हैं
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियों को हटाएँ
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // नई श्रेणियां जोड़ना
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // नई सीरीज़ जोड़ना
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // अब सीरीज़ डेटा भर रहे हैं
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या 'Pie of Pie' और 'Bar of Pie' वेरिएंट्स समर्थित हैं?**

हां, लाइब्रेरी पाई चार्ट्स के लिए द्वितीयक प्लॉट को [समर्थन](https://reference.aspose.com/slides/hi/java/com.aspose.slides/charttype/) देती है, जिसमें 'Pie of Pie' और 'Bar of Pie' प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को एक छवि (उदाहरण के लिए, PNG) के रूप में निर्यात कर सकता हूँ?**

हां, आप पूरी प्रस्तुति के बिना चार्ट को स्वयं एक छवि (जैसे PNG) के रूप में [निर्यात कर सकते हैं](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getImage-int-float-float-).