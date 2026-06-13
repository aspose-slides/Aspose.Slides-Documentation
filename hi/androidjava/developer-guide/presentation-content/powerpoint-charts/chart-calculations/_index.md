---
title: Android पर प्रस्तुतियों के लिये चार्ट गणनाओं का अनुकूलन
linktitle: चार्ट गणनाएँ
type: docs
weight: 50
url: /hi/androidjava/chart-calculations/
keywords:
- चार्ट गणनाएँ
- चार्ट तत्व
- तत्व स्थिति
- वास्तविक स्थिति
- संतान तत्व
- अभिभावक तत्व
- चार्ट मान
- वास्तविक मान
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में PPT और PPTX के लिए चार्ट गणनाओं, डेटा अपडेट्स और सटीकता नियंत्रण को समझें, साथ में व्यावहारिक Java कोड उदाहरण।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुतियों में चार्ट गणनाओं और लेआउट डेटा को संभालने के लिए API प्रदान करता है। यह लेख दिखाता है कि चार्ट तत्वों के वास्तविक मान कैसे प्राप्त किए जाएँ, जिसमें `IActualLayout` को लागू करने वाले तत्वों की वास्तविक स्थिति और आकार तथा चार्ट अक्षों के वास्तविक मान शामिल हैं। यह भी बताता है कि ये मान चार्ट लेआउट वैधता के बाद भरते हैं।

इसके अतिरिक्त, लेख यह दर्शाता है कि पैरेंट चार्ट तत्वों की वास्तविक स्थिति कैसे प्राप्त की जाए और शीर्षक, अक्ष, लेजेंड और ग्रिड लाइनों जैसे चार्ट घटकों को कैसे छिपाया जाए। यह उदाहरण आपको प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों में चार्ट लेआउट जानकारी का निरीक्षण करने और चार्ट तत्वों की दृश्यता को नियंत्रित करने में मदद करता है।

## **चार्ट तत्वों के वास्तविक मानों की गणना**
Aspose.Slides for Android via Java इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। [IAxis](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAxis) इंटरफ़ेस के गुण अक्ष चार्ट तत्व की वास्तविक स्थिति के बारे में जानकारी देते हैं ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--))। गुणों को वास्तविक मानों से भरने के लिए पहले विधि [IChart.validateChartLayout()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChart#validateChartLayout--) को कॉल करना आवश्यक है।

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **पैरेंट चार्ट तत्वों की वास्तविक स्थिति की गणना**
Aspose.Slides for Android via Java इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। [IActualLayout](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IActualLayout) इंटरफ़ेस के गुण पैरेंट चार्ट तत्व की वास्तविक स्थिति के बारे में जानकारी देते हैं ([IActualLayout.getActualX](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IActualLayout#getActualHeight--))। गुणों को वास्तविक मानों से भरने के लिए पहले विधि [IChart.validateChartLayout()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChart#validateChartLayout--) को कॉल करना आवश्यक है।

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट तत्वों को छिपाएँ**
यह विषय आपको चार्ट से जानकारी छिपाने के तरीके समझाने में मदद करता है। Aspose.Slides for Android via Java का उपयोग करके आप **शीर्षक, वर्टिकल अक्ष, हॉरिज़ॉन्टल अक्ष** और **ग्रिड लाइनों** को चार्ट से छिपा सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि इन गुणों का उपयोग कैसे किया जाए।

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //चार्ट शीर्षक छिपाना
    chart.setTitle(false);

    ///मूल्य अक्ष छिपाना
    chart.getAxes().getVerticalAxis().setVisible(false);

    //श्रेणी अक्ष दृश्यता
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //लीजेंड छिपाना
    chart.setLegend(false);

    //मुख्य ग्रिड लाइनों को छिपाना
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //श्रृंखला रेखा रंग सेट करना
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या बाहरी Excel वर्कबुक्स डेटा स्रोत के रूप में काम करती हैं, और इसका पुनर्गणना पर क्या प्रभाव पड़ता है?**

हाँ। एक चार्ट बाहरी वर्कबुक को संदर्भित कर सकता है: जब आप बाहरी स्रोत को कनेक्ट या रिफ्रेश करते हैं, तो फ़ॉर्मूले और मान उस वर्कबुक से लिये जाते हैं, और चार्ट खुले/संपादित करने के दौरान अपडेट को दर्शाता है। API आपको [specify the external workbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) पथ निर्दिष्ट करने और लिंक्ड डेटा प्रबंधित करने की अनुमति देती है।

**क्या मैं खुद रिग्रेशन लागू किए बिना ट्रेंडलाइन की गणना और प्रदर्शन कर सकता हूँ?**

हाँ। [Trendlines](/slides/hi/androidjava/trend-line/) (रेखीय, घातीय और अन्य) Aspose.Slides द्वारा जोड़े और अपडेट किए जाते हैं; उनके पैरामीटर श्रृंखला डेटा से स्वचालित रूप से पुनः गणना होते हैं, इसलिए आपको स्वयं गणना लागू करने की आवश्यकता नहीं है।

**यदि किसी प्रस्तुति में कई चार्ट बाहरी लिंक के साथ हैं, तो क्या मैं नियंत्रित कर सकता हूँ कि प्रत्येक चार्ट कौन सा वर्कबुक उपयोग करे गणना किए गए मानों के लिए?**

हाँ। प्रत्येक चार्ट अपने स्वयं के [external workbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) को इंगित कर सकता है, या आप प्रत्येक चार्ट के लिए स्वतंत्र रूप से एक बाहरी वर्कबुक बना/बदल सकते हैं।